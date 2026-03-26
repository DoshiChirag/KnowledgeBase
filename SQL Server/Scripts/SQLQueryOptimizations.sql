USE AdventureWorks2017
SET STATISTICS IO ON;
GO

SELECT
	Employee.BusinessEntityID,
	Employee.LoginID,
	Employee.NationalIDNumber
FROM HumanResources.Employee
WHERE EMployee.HireDate = '2011-02-07';


SELECT 
	db_name() AS database_name,
    schemas.name AS schema_name,
	TABLE_DATA.name AS table_name,
	INDEX_DATA.name AS index_name,
	STUFF((SELECT ',' + columns.name
	FROM sys.tables
	INNER JOIN sys.Indexes
	ON tables.object_id = indexes.object_id
	INNER JOIN sys.index_columns
	ON indexes.object_id = index_columns.object_id AND indexes.index_id = index_columns.index_id
	INNER JOIN sys.columns
	ON tables.object_id = columns.object_id AND index_columns.column_id = columns.column_id
	WHERE INDEX_DATA.object_id = indexes.object_id AND INDEX_DATA.index_id = indexes.index_id
	AND index_columns.is_included_column = 0
	ORDER BY index_columns.key_ordinal
FOR XML PATH('')),1, 2, '') AS key_column_list,
	STUFF((SELECT ',' + columns.name
	FROM sys.tables
	INNER JOIN sys.Indexes
	ON tables.object_id = indexes.object_id
	INNER JOIN sys.index_columns
	ON indexes.object_id = index_columns.object_id AND indexes.index_id = index_columns.index_id
	INNER JOIN sys.columns
	ON tables.object_id = columns.object_id AND index_columns.column_id = columns.column_id
	WHERE INDEX_DATA.object_id = indexes.object_id AND INDEX_DATA.index_id = indexes.index_id
	AND index_columns.is_included_column = 1
	ORDER BY index_columns.key_ordinal
FOR XML PATH('')),1, 2, '') AS include_column_list
FROM sys.indexes INDEX_DATA
INNER JOIN sys.tables TABLE_DATA
ON TABLE_DATA.object_id = INDEX_DATA.object_id
INNER JOIN sys.schemas 
ON TABLE_DATA.schema_id = schemas.schema_id
WHERE TABLE_DATA.name = 'Employee'
AND schemas.name = 'HumanResources';


DROP INDEX  HumanResources.Employee.IX_Employee_HireDate;
CREATE NONCLUSTERED INDEX IX_Employee_HireDate ON HumanResources.Employee (HireDate ASC);
--INCLUDE (LoginID, NationalIDNumber);

SELECT
	Employee.BusinessEntityID,
	Employee.LoginID,
	Employee.NationalIDNumber
FROM HumanResources.Employee
WHERE EMployee.HireDate = '2011-02-07';


DROP INDEX  HumanResources.Employee.IX_Employee_HireDate;
CREATE NONCLUSTERED INDEX IX_Employee_HireDate ON HumanResources.Employee (HireDate ASC)
INCLUDE (LoginID, NationalIDNumber);

SELECT
	Employee.BusinessEntityID,
	Employee.LoginID,
	Employee.NationalIDNumber
FROM HumanResources.Employee
WHERE EMployee.HireDate = '2011-02-07';


