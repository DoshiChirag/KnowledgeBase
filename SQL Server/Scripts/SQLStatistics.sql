USE AdventureWorks2017
GO

--statistics are objects in database eg. sys.stats dm_Db_stats_proeprties
SELECT
	stats.object_id,
	stats.name,
	stats.stats_id,
	stats.auto_created,
	dm_db_stats_properties.*
FROM sys.stats
CROSS APPLY sys.dm_db_stats_properties(stats.object_id, stats.stats_id)
WHERE stats.object_id = OBJECT_ID('Sales.SalesOrderHeader');


DBCC SHOW_STATISTICS ("Sales.SalesOrderHeader", IX_SalesOrderHeader_SalesPersonID);

--Discrepancy in number of rows estimated count very large and actual rows just 12
SELECT
	Sales.SalesOrderHeader.CustomerID,
	Sales.SalesOrderHeader.SalesOrderID
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.CustomerID = 29811;

--Over 200 steps in execution plan
DBCC SHOW_STATISTICS ("Sales.SalesOrderDetail", IX_SalesOrderDetail_CarrierTrackingNumber);


--Estiamted paln row count >>> Actual row count returned
SELECT * FROM Sales.SalesOrderDetail 
	WHERE Sales.SalesOrderDetail.CarrierTrackingNumber = '9429-430D-89'

--Regenerate filtered statistics within a given range of column values (most frequently recurring values)
CREATE STATISTICS STATS_SalesOrderDetail_CarrierTrackingNumber_filtered ON Sales.SalesOrderDetail(CarrierTrackingNumber)
WHERE CarrierTrackingNumber > '9000-0000-00' AND CarrierTrackingNumber < '9500-0000-00'

--Only 60 steps in execution plan
DBCC SHOW_STATISTICS ("Sales.SalesOrderDetail", STATS_SalesOrderDetail_CarrierTrackingNumber_filtered);

--Estiamted  row count :== Actual row count returned after generating filtered statistics based off where clause
SELECT * FROM Sales.SalesOrderDetail 
	WHERE Sales.SalesOrderDetail.CarrierTrackingNumber = '9429-430D-89'

--determine if auto stats is on on each db
SELECT 
	databases.name,
	databases.is_auto_create_stats_on,
	databases.is_auto_update_stats_on
FROM sys.databases
 WHERE databases.name = 'AdventureWorks2017';

 --very labor intensive process
ALTER DATABASE AdventureWorks2017 SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE AdventureWorks2017 SET AUTO_UPDATE_STATISTICS ON;

DROP STATISTICS Sales.SalesOrderDetail.STATS_SalesOrderDetail_CarrierTrackingNumber_filtered;

--Statistics Maintenance

USE AdventureWorks2017;
SET STATISTICS IO ON;
GO

ALTER DATABASE AdventureWorks2017 SET AUTO_UPDATE_STATISTICS OFF;
GO


--Estimated number of rows in query (6) is @ same as Actual number of rows returned (4) and low logical reads
SELECT 
	Sales.SalesOrderHEader.*
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.CustomerID = 29566


--update all rows to the same customerID
--Auto update stats would update stats if number of rows modifeid > 20% of table rows
UPDATE Sales.SalesOrderHeader
	SET CustomerID = 29566
FROM Sales.SalesOrderHeader;

--Now Estimated number of rows in query is same as where as Actual number of rows returned is much higher
--Statistics may not update but it actually does in SQL Server 2022 
--May be some global option or update caused it due to number of rows updated??
SELECT 
	Sales.SalesOrderHEader.*
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.CustomerID = 29566

--Stats can be update for all create and update options
SELECT * 
	FROM sys.dm_db_partition_stats
	INNER JOIN sys.tables
	ON tables.object_id = dm_db_partition_stats.object_id;

--update all stats on a table
UPDATE STATISTICS sales.SalesOrderHeader;
--whole da
Exec sys.sp_updatestats


--update statisitics with a specified sample size
UPDATE STATISTICS sales.SalesOrderHeader IX_SalesOrderHeader_CustomerID
WITH Sample  50 PERCENT;


CREATE STATISTICS IX_SalesOrderHeader_CustomerID_2 ON sales.SalesOrderHeader(CustomerID);

--update statistics on and maintain statistics
--eliminate duplicate statistics by dropping and recreating statistics
WITH CTE_STATS (object_id, stats_id, name, column_id)
AS ( SELECT sys.stats.object_id,
			sys.stats.stats_id,
			sys.stats.name,
			sys.stats_columns.column_id
		FROM sys.stats
		INNER JOIN sys.stats_columns ON sys.stats.object_id = sys.stats_columns.object_id
		AND sys.stats.stats_id = sys.stats_columns.stats_id
		WHERE sys.stats_columns.stats_column_id = 1)
SELECT OBJECT_NAME(sys.stats.object_id) AS [Table],
		sys.columns.name AS [Column],
		sys.stats.name AS [Overlapped],
		CTE_STATS.name AS [Overlapping],
		'DROP STATISTICS [' + OBJECT_SCHEMA_NAME(sys.stats.object_id) + '].[' + OBJECT_NAME(sys.stats.object_id) + '].[' 
		+ CTE_STATS.name + ']'
	FROM sys.stats 
	INNER JOIN sys.stats_columns ON sys.stats.object_id = sys.stats_columns.object_id
	AND sys.stats.stats_id = sys.stats_columns.stats_id
	INNER JOIN CTE_STATS ON sys.stats_columns.object_id = CTE_STATS.object_id
	AND sys.stats_columns.column_id =CTE_STATS.column_id
	INNER JOIN sys.columns ON sys.stats.object_id = sys.columns.object_id
	AND sys.stats_columns.column_id = sys.columns.column_id
	INNER JOIN sys.objects
	ON sys.objects.object_id = sys.stats.object_id
	WHERE  sys.stats.auto_created = 0
	AND sys.stats_Columns.stats_column_id = 1
	AND sys.stats_columns.stats_id != CTE_STATS.stats_id
	AND objects.is_ms_shipped = 0;

	












