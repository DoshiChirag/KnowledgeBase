USE AdventureWorks2017
SET STATISTICS IO ON
GO

--Sales Order Header column lookup
SELECT 
	* 
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.CustomerID = 29811

--count the number of records in the table
SELECT 
	Count(*)
FROM Sales.SalesOrderHeader

--check distinct customer ids and calculate ratio of all records to unique column records which is @1.65
--most record rows and values would not repeat much
SELECT 
	Count(DISTINCT Sales.SalesOrderHeader.CustomerID)
FROM Sales.SalesOrderHeader

--For each customer id check the count
SELECT 
	SalesOrderHeader.CustomerID,
	COUNT(*) AS CustomerID_Count
FROM Sales.SalesOrderHeader
GROUP BY SalesOrderHeader.CustomerID
ORDER BY COUNT(*) DESC;

--get statistics for each customer id
--results - relatively low range of data values
-- may decide on execution plan based off cardinality and metrics
--Not all queries will be against a single column
SELECT 
	COUNT(*) AS total_values,
	MIN(SalesOrderHeader.CustomerID) AS min_value,
	MAX(SalesOrderHeader.CustomerID) AS max_value,
	AVG(SalesOrderHeader.CustomerID) AS avg_value,
	STDEV(SalesOrderHeader.CustomerID) AS st_dev
FROM Sales.SalesOrderHeader


--perform the same analysis as before for second column each column in where clause
SELECT
	*
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.CustomerID = 29811
AND SalesOrderHeader.SalesPersonID = 277


--find distinct combinations of each record
--only slightly more unique with sparse values
SELECT DISTINCT
	SalesOrderHeader.CustomerID,
	SalesOrderHeader.SalesPersonID
FROM Sales.SalesOrderHeader;

--find sales person id range of values which is even smaller than CustomerID
SELECT SalesOrderHeader.SalesPersonID,
	COUNT(*) AS SalesPersonID_Count
FROM Sales.SalesOrderHeader
GROUP BY SalesPersonID
ORDER BY COUNT(*) DESC;

--get statistics for each sales person id
--results - relatively low range of data values
-- may decide on execution plan based off cardinality and metrics
--even smaller statistics
SELECT 
	COUNT(*) AS total_values,
	MIN(SalesOrderHeader.SalesPersonID) AS min_value,
	MAX(SalesOrderHeader.SalesPersonID) AS max_value,
	AVG(SalesOrderHeader.SalesPersonID) AS avg_value,
	STDEV(SalesOrderHeader.SalesPersonID) AS st_dev
FROM Sales.SalesOrderHeader


--check cardinality against primary key values
--index seek happens when atleast one row exists
SELECT 
	Count(*)
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.SalesOrderID = 48759

--Even when value does not exists Index seek does happen to decide the value does not exist
SELECT 
	Count(*)
FROM Sales.SalesOrderHeader
WHERE SalesOrderHeader.SalesOrderID = 25624

--Check constraints can also allow you to find or restrict cardinaliy of rows participating in a query
-- within its business domain values
-- from optimization perspective
USE AdventureWorks2017
GO
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_DueDate2
CHECK ((DueDate >= OrderDate))
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_ShipDate
CHECK ((ShipDate >= OrderDate OR ShipDate IS NULL))
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_Status
CHECK ((Status >= 0 AND  Status <= 8))
GO
--Constrain dollar amount to be positive when placing the orders thereby limiting values and records in the table
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_Freight
CHECK ((Freight >= 0))
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_SubTotal
CHECK ((SubTotal >= 0.00))
ALTER TABLE Sales.SalesOrderHeader WITH CHECK ADD CONSTRAINT CK_SalesOrderHeader_TaxAmt
CHECK ((TaxAmt >= 0.00))
GO

--A Datetime, smalldatetime, DateTime2 have different ranges and can be constrained as such








