USE AdventureWorks2017;
SET STATISTICS IO ON;
GO

--Since SQL Server Restart
SELECT 
	schemas.name AS [schema_name],
	tables.name as table_name,
	indexes.name as Index_Name,
	dm_db_index_usage_stats.user_seeks AS User_Seek_Count,
	dm_db_index_usage_stats.user_scans AS User_Scan_Count,
	dm_db_index_usage_stats.user_lookups AS User_Lookup_Count,
	dm_db_index_usage_stats.user_updates AS User_Update_Count,
	dm_db_index_usage_stats.last_user_seek AS Last_User_Seek,
	dm_db_index_usage_stats.last_user_scan AS Last_User_Scan,
	dm_db_index_usage_stats.last_user_lookup AS Last_User_Lookup,
	dm_db_index_usage_stats.last_user_update AS Last_User_Update,
	ISNULL(indexes.is_primary_key, 0) AS Is_Primary_Key,
	ISNULL(CASE WHEN indexes.type_desc = 'CLUSTERED' THEN 1 ELSE 0 END, 0) AS Is_Clustered_Index
FROM sys.dm_db_index_usage_stats
INNER JOIN sys.indexes 
ON indexes.object_id = dm_db_index_usage_stats.object_id AND 
indexes.index_id = dm_db_index_usage_stats.index_id
INNER JOIN sys.tables 
ON tables.object_id = indexes.object_id
INNER JOIN sys.schemas
ON schemas.schema_id = tables.schema_id AND indexes.name IS NOT NULL
ORDER BY dm_db_index_usage_stats.user_seeks ASC, User_SCAN_Count ASC


--Unused Indexes list within last 12 or more hours
SELECT 
	schemas.name AS [schema_name],
	tables.name as table_name,
	indexes.name as Index_Name
FROM sys.indexes 
INNER JOIN sys.tables 
ON tables.object_id = indexes.object_id
INNER JOIN sys.schemas
ON schemas.schema_id = tables.schema_id AND indexes.name IS NOT NULL
WHERE NOT EXISTS ( --indicates no usage stats entries found
	SELECT 
		*
	FROM sys.dm_db_index_usage_stats
	INNER  JOIN sys.indexes INDEX_USAGE
	ON indexes.object_id = dm_db_index_usage_stats.object_id
	AND indexes.index_id = dm_db_index_usage_stats.index_id
	INNER JOIN sys.tables TABLE_USAGE 
	ON tables.object_id = indexes.object_id 
	INNER JOIN sys.schemas SCHEMA_USAGE
	ON schemas.schema_id = tables.schema_id
	AND indexes.name is not null
	WHERE INDEX_USAGE.index_id = indexes.index_id
	AND TABLE_USAGE .object_id = tables.object_id
	AND SCHEMA_USAGE.schema_id = schemas.schema_id);


--duplicated indexes
use AdventureWorks2017;
GO
WITH CTE_INDEX_DATA AS 
	(SELECT 
		SCHEMA_DATA.name as schema_name,
		TABLE_DATA.name AS table_name,
		INDEX_DATA.name as index_name,
		STUFF((SELECT ',' +COLUMN_DATA_KEY_COLS.name + ' ' + CASE WHEN INDEX_COLUMN_DATA_KEYS_COLS.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END  --Include column order in indexes
				FROM sys.tables T
				INNER JOIN sys.indexes INDEX_DATA_KEY_COLS
				ON T.object_id = INDEX_DATA_KEY_COLS.object_id
				INNER JOIN sys.index_columns INDEX_COLUMN_DATA_KEYS_COLS
				ON INDEX_DATA_KEY_COLS.object_id = INDEX_COLUMN_DATA_KEYS_COLS.object_id
				AND INDEX_DATA_KEY_COLS.index_id = INDEX_COLUMN_DATA_KEYS_COLS.index_id
				INNER JOIN sys.columns COLUMN_DATA_KEY_COLS
				ON T.object_id = COLUMN_DATA_KEY_COLS.object_id
				AND INDEX_COLUMN_DATA_KEYS_COLS.column_id = COLUMN_DATA_KEY_COLS.column_id
			WHERE INDEX_DATA.object_id = INDEX_DATA_KEY_COLS.object_id
			AND INDEX_DATA.index_id = INDEX_DATA_KEY_COLS.index_id 
			AND INDEX_COLUMN_DATA_KEYS_COLS.is_included_column = 0
			ORDER BY INDEX_COLUMN_DATA_KEYS_COLS.key_ordinal
			FOR XML PATH('')), 1, 2, '') AS key_column_list,
		STUFF ((SELECT ',' +COLUMN_DATA_INC_COLS.name
			FROM  sys.tables T
			INNER JOIN sys.indexes INDEX_DATA_INC_COLS 
			ON T.object_id = INDEX_DATA_INC_COLS.object_id
			INNER JOIN sys.index_columns INDEX_COLUMN_DATA_INC_COLS
			ON INDEX_DATA_INC_COLS.object_id = INDEX_COLUMN_DATA_INC_COLS.object_id
			AND INDEX_DATA_INC_COLS.index_id = INDEX_COLUMN_DATA_INC_COLS.index_id
			INNER JOIN sys.columns COLUMN_DATA_INC_COLS
				ON T.object_id = COLUMN_DATA_INC_COLS.object_id
				AND INDEX_COLUMN_DATA_INC_COLS.column_id = COLUMN_DATA_INC_COLS.column_id
		WHERE INDEX_DATA.object_id = INDEX_DATA_INC_COLS.object_id
			AND INDEX_DATA.index_id = INDEX_DATA_INC_COLS.index_id 
			AND INDEX_COLUMN_DATA_INC_COLS.is_included_column = 1
			ORDER BY INDEX_COLUMN_DATA_INC_COLS.key_ordinal
			FOR XML PATH('')), 1, 2, '') AS include_column_list,
	INDEX_DATA.is_disabled,
	INDEX_DATA.has_filter,
	INDEX_DATA.filter_definition
	FROM sys.indexes INDEX_DATA
	INNER JOIN sys.tables TABLE_DATA
	ON TABLE_DATA.object_id = INDEX_DATA.object_id
	INNER JOIN sys.schemas SCHEMA_DATA
	ON SCHEMA_DATA.schema_id = TABLE_DATA.schema_id
	WHERE TABLE_DATA.is_ms_shipped = 0
	AND INDEX_DATA.type_desc IN ('NONCLUSTERED','CLUSTERED')
)
SELECT 
	*
FROM CTE_INDEX_DATA DUPE1
WHERE EXISTS
( SELECT * FROM  CTE_INDEX_DATA DUPE2
WHERE DUPE1.schema_name = DUPE2.schema_name
AND DUPE1.table_name = DUPE2.table_name
AND DUPE1.key_column_list = DUPE2.key_column_list
AND ISNULL(DUPE1.include_column_list, '') = ISNULL(DUPE2.include_Column_list, '')
AND DUPE1.index_name <> DUPE2.index_name);

--determine fragmentation of all standard indexes in the current database
SELECT 
	CAST(SD.name AS NVARCHAR(MAX)) AS database_name,
	CAST(SS.name AS NVARCHAR(MAX)) AS schema_name,
	CAST(SO.name AS NVARCHAR(MAX)) AS object_name,
	CAST(SI.name AS NVARCHAR(MAX)) AS index_name,
	IPS.index_type_desc,
	IPS.avg_fragmentation_in_percent,
	(page_count * 8 / 1024/1024) AS size_in_GB
FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) IPS
INNER JOIN sys.databases SD
ON SD.database_id =IPS.database_id
INNER JOIN sys.indexes SI
ON SI.index_id = IPS.index_id
INNER JOIN sys.objects SO
ON SO.object_id = SI.object_id
AND IPS.object_id = SO.object_id
INNER JOIN sys.schemas SS
ON SS.schema_id = SO.schema_id
WHERE IPS.alloc_unit_type_desc = 'IN_ROW_DATA'
AND IPS.index_level = 0
AND SI.name IS NOT NULL
AND SO.is_ms_shipped = 0
AND SD.name = DB_NAME()
ORDER BY IPS.avg_fragmentation_in_percent DESC;

--Did not make much difference as the current fragmentation on disc is optimal
ALTER INDEX AK_SpecialOfferProduct_rowguid ON SALES.SpecialOfferProduct
REBUILD;

ALTER INDEX IX_vStateProvinceCountryRegion ON Person.vStateProvinceCountryRegion
REBUILD;





