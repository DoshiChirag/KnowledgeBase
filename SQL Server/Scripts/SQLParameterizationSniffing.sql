USE AdventureWorks2017;
SET STATISTICS IO ON;
SET NOCOUNT ON;
DBCC FREEPROCCACHE;
GO
DROP PROCEDURE dbo.search_orders
DBCC FREEPROCCACHE;
GO


CREATE PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	SELECT 
		SalesOrderHeader.SalesOrderID,
		Sales.SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID
END

--Table 'SalesOrderHeader'. Scan count 0, logical reads 8, physical reads 0, page server reads 0, read-ahead reads 0, page server read-ahead reads 0, lob logical reads 0, lob physical reads 0, lob page server reads 0, lob read-ahead reads 0, lob page server read-ahead reads 0.
--Table 'SalesOrderDetail'. Scan count 1, logical reads 2, physical reads 2, page server reads 0, read-ahead reads 0, page server read-ahead reads 0, lob logical reads 0, lob physical reads 0, lob page server reads 0, lob read-ahead reads 0, lob page server read-ahead reads 0.
EXEC dbo.search_orders @ProductID = 897;--Low Cardinality Execution
DBCC FREEPROCCACHE;
EXEC dbo.search_orders @ProductID = 870; --High Cardinality Execution
DBCC FREEPROCCACHE;

--Reuse of query plan
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution

--Reuse of query plan wih larger numbe of rows for a larger result set
EXEC dbo.search_orders @ProductID = 870;-- High cardinality execvution

--Reuse of query plan wih larger numbe of rows for a smaller result set subsequently
EXEC dbo.search_orders @ProductID = 942;-- High cardinality execvution

GO

--OPTION (RECOMPILE) - Useful when query doesn't run too often and we can afford overhead of generating
--execution plans every time it runs
ALTER PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	SELECT 
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID
	OPTION(RECOMPILE);
END
GO

--With Recompile option for every execution of sp query
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution

--New query plan wih larger numbe of rows for a larger result set
EXEC dbo.search_orders @ProductID = 870;-- High cardinality execvution

--New query plan wih smaller number of rows for a smaller result set subsequently
EXEC dbo.search_orders @ProductID = 942;-- Low cardinality execvution

--This is equivalent of DBCC command after each query clearing the cached execution plan
--without executing the DBCC command

GO

--OPTION (RECOMPILE) - Useful when query doesn't run too often and we can afford overhead of generating
--execution plans every time it runs with TOP n rows
--improves the performance significantly
ALTER PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	SELECT TOP 25
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID
	OPTION(RECOMPILE);
END
GO

--With Recompile option for every execution of sp query with top 25
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution

--New query plan wih larger numbe of rows for a larger result set with top 25
EXEC dbo.search_orders @ProductID = 870;-- High cardinality execvution

--New query plan wih smaller number of rows for a smaller result set subsequently with top 25
EXEC dbo.search_orders @ProductID = 942;-- Low cardinality execvution


GO

--OPTION (RECOMPILE) - Useful when query doesn't run too often and we can afford overhead of generating
--execution plans every time 
--improves the performance significantly for a given value taken by the variable
ALTER PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	SELECT TOP 25
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID
	OPTION(OPTIMIZE FOR (@ProductID = 870)); -- High cardinality estimate due to a larger result set - good for optimizing the variable
END
GO

--With optimize option for every execution of sp query with indexed scan
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution

--Query plan wih larger number of rows for a larger result set with indexed scan
--This query became low
EXEC dbo.search_orders @ProductID = 870;-- low cardinality execvution now

--query plan wih smaller number of rows for a smaller result set subsequently
EXEC dbo.search_orders @ProductID = 942;-- Low cardinality execvution


GO

CREATE PROCEDURE #search_orders
	@ProductID INT
AS
BEGIN
	SELECT TOP 25
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID
	OPTION(OPTIMIZE FOR (@ProductID = 870)); -- High cardinality estimate due to a larger result set - good for optimizing the variable
END
GO

--With optimize option for every execution of sp query with indexed scan
EXEC #search_orders @ProductID = 897;--Low cardinality execution but with larger rows in execution

--Query plan wih larger number of rows for a larger result set with indexed scan
--This query became low
EXEC #search_orders @ProductID = 870;-- High cardinality execvution now as it does not use any stored dbo

--query plan wih smaller number of rows for a smaller result set subsequently
EXEC #search_orders @ProductID = 942;-- Low cardinality execvution

DROP PROCEDURE #search_orders;
GO

--More Hacks
--Redeclare a local parameter and set it to the SP parameter

--Useful hack with local SP parameter
ALTER PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	DECLARE @ProductID_LOCAL INT;
	SELECT @ProductID_LOCAL = @ProductID;
	SELECT 
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = @ProductID_LOCAL;
	
END
GO

--With optimize option for every execution of sp query with indexed scan
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution but with larger rows in execution

--Query plan wih larger number of rows for a larger result set with indexed scan
--This query became low
EXEC dbo.search_orders @ProductID = 870;-- Higher cardinality execvution now

--query plan wih smaller number of rows for a smaller result set subsequently
EXEC dbo.search_orders @ProductID = 942;-- Low cardinality execvution

GO


--Useful hack with many values passed in
ALTER PROCEDURE dbo.search_orders
	@ProductID INT
AS
BEGIN
	DECLARE @sql_Command NVARCHAR(MAX);
	SELECT @sql_Command = '
	SELECT 
		SalesOrderHeader.SalesOrderID,
		SalesOrderDetail.SalesOrderDetailID
	FROM Sales.SalesOrderHeader
	INNER JOIN Sales.SalesOrderDetail
	ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
	WHERE SalesOrderDetail.ProductID = ' + CAST(@ProductID AS NVARCHAR(MAX)) +';';

	EXEC sp_executesql @sql_command;
	
END
GO

--With optimize option for every execution of sp query with indexed scan
EXEC dbo.search_orders @ProductID = 897;--Low cardinality execution but with fewer rows in execution < 80 rows

--Query plan wih larger number of rows for a larger result set with indexed scan
--This query became low
EXEC dbo.search_orders @ProductID = 870;-- Higher cardinality execvution but with fewer rows in execution as compared to all other approaches < 4700 rows

--query plan wih smaller number of rows for a smaller result set subsequently
EXEC dbo.search_orders @ProductID = 942;-- Low cardinality execvution with fewer rows in execution typically < 99

GO

