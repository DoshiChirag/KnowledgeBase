USE AdventureWorks2017;
SET STATISTICS IO ON;
SET NOCOUNT ON;
GO


--Drops execution plan cache resulting in rebuilding the cache in susequent queries
DBCC FREEPROCCACHE;

--Execute and select the results at runtime using exec_sql_text and exec_query_plan
USE AdventureWorks2017;
SET STATISTICS IO ON;
SET NOCOUNT ON;
GO

SELECT 
	[databases].name,
	dm_exec_sql_text.text AS TSQL_Text,
	dm_exec_query_stats.creation_time,
	dm_exec_query_stats.execution_count,
	dm_exec_query_stats.total_worker_time AS total_cpu_time,
	dm_exec_query_stats.total_elapsed_time,
	dm_exec_query_stats.total_logical_reads,
	dm_exec_query_stats.total_physical_reads,
	dm_exec_query_plan.query_plan
FROM sys.dm_exec_query_stats
CROSS APPLY sys.dm_exec_sql_text(dm_exec_query_stats.plan_handle)
CROSS APPLY sys.dm_exec_query_plan(dm_exec_query_stats.plan_handle)
INNER JOIN sys.databases
ON dm_exec_sql_text.dbid = databases.database_id
WHERE databases.name = 'AdventureWorks2017';
GO

SELECT 
	[databases].name,
	dm_exec_sql_text.text AS TSQL_Text,
	dm_exec_query_stats.creation_time,
	dm_exec_query_stats.execution_count,
	dm_exec_query_stats.total_worker_time AS total_cpu_time,
	dm_exec_query_stats.total_elapsed_time,
	dm_exec_query_stats.total_logical_reads,
	dm_exec_query_stats.total_physical_reads,
	dm_exec_query_plan.query_plan
FROM sys.dm_exec_query_stats
CROSS APPLY sys.dm_exec_sql_text(dm_exec_query_stats.plan_handle)
CROSS APPLY sys.dm_exec_query_plan(dm_exec_query_stats.plan_handle)
INNER JOIN sys.databases
ON dm_exec_sql_text.dbid = databases.database_id
WHERE databases.name = 'adventureWorks2017';

--Check create procedure query execution times and plans
CREATE PROCEDURE dbo.search_orders
	(@ProductID INT, @CustomerID  INT)
AS
BEGIN
	SELECT
		Sales.SalesOrderHeader.SalesOrderID,
		Sales.SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON Sales.SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderHeader.CustomerID = @CustomerID
	AND SalesOrderDetail.ProductID = @ProductID;
END
GO

--Drops execution plan cache resulting in rebuilding the cache in susequent queries
DBCC FREEPROCCACHE;


exec dbo.search_orders @ProductID = 716 , @CustomerID = 17949;
exec dbo.search_orders @ProductID = 781 , @CustomerID = 19076;
exec dbo.search_orders @ProductID = 870 , @CustomerID = 22049;
exec dbo.search_orders @ProductID = 712 , @CustomerID = 18557;
exec dbo.search_orders @ProductID = 712 , @CustomerID = 15340;
exec dbo.search_orders @ProductID = 712 , @CustomerID = 18557;
exec dbo.search_orders @ProductID = 712 , @CustomerID = 15340;


--The plan for creating stored procedure uses indexes involved in the query in the select statemnet.
SELECT 
	[databases].name,
	dm_exec_sql_text.text AS TSQL_Text,
	dm_exec_query_stats.creation_time,
	dm_exec_query_stats.execution_count,
	dm_exec_query_stats.total_worker_time AS total_cpu_time,
	dm_exec_query_stats.total_elapsed_time,
	dm_exec_query_stats.total_logical_reads,
	dm_exec_query_stats.total_physical_reads,
	dm_exec_query_plan.query_plan
FROM sys.dm_exec_query_stats
CROSS APPLY sys.dm_exec_sql_text(dm_exec_query_stats.plan_handle)
CROSS APPLY sys.dm_exec_query_plan(dm_exec_query_stats.plan_handle)
INNER JOIN sys.databases
ON dm_exec_sql_text.dbid = databases.database_id
WHERE databases.name = 'AdventureWorks2017';
GO

--Scalar values in queries are much faster and use less resources than variables
--Query execution plan uses Index Seek with 16 rows
--Key Lookup Clustered index uses 16 rows as well
SELECT 
	SalesOrderHeader.SalesOrderID,
	SalesOrderHeader.DueDate,
	SalesOrderHeader.ShipDate
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.SalesPersonID = 285;

--When using a variable, it generates a custom index scan
--with 1748 rows as opposed to 16+16 rows in earlier lookups
-- with number of rows read = 31000+
--Full use of stats after cardinality estimates is the best way to execute queries without any variables
DECLARE @SalesPersonID INT = 285;
SELECT 
	SalesOrderHeader.SalesOrderID,
	SalesOrderHeader.DueDate,
	SalesOrderHeader.ShipDate
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.SalesPersonID = @SalesPersonID;

--Cleanup
DROP PROCEDURE dbo.search_orders;
GO

