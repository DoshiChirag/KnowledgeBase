Use AdventureWorks2017
GO

SELECT SUM(OrderQty) AS TotalQty,
AVG(OrderQty) As AvgQty,
MIN(OrderQty) AS MinQty,
MAX(OrderQty) AS MaxQty
FROM Sales.SalesOrderDetail

GO

CREATE TABLE CountTable
( Numbers tinyint)

GO

INSERT INTO CountTable
VALUES (25), (10), (NULL),
		(30), (45), (NULL)

GO

SELECT 
	Count(Numbers) AS CountNoNulls,
	Count(*) AS CountWithNulls,
	AVG(Numbers) AS AverageNoNulls,
	SUM(Numbers) / Count(*) AS AverageWithNulls,
	AVG(ISNULL(Numbers, 0)) AS AverageWithNulls
FROM CountTable

GO

