Use AdventureWorks2017
GO

SELECT SalesOrderID, SUM(OrderQty * UnitPrice) AS LineTotal 
FROM Sales.SalesOrderDetail
WHERE SalesOrderID < 43662
GROUP BY SalesOrderID

GO

SELECT SalesOrderID, SUM(OrderQty * UnitPrice) AS LineTotal 
FROM Sales.SalesOrderDetail
WHERE SalesOrderID < 43680
GROUP BY SalesOrderID
HAVING SUM(OrderQty * UnitPrice) > 15000
GO

GO