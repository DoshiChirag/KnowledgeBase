USE AdventureWorks2017;
SET STATISTICS IO ON;
GO

SELECT 
	SalesOrderID,
	SalesOrderDetailID,
	UnitPrice
FROM Sales.SalesOrderDetail
WHERE SalesOrderDetail.ModifiedDate = '6/30/2014'
AND SalesOrderDetail.UnitPrice >= 100;

DROP INDEX IX_SalesOrderDetail_ModifiedDate_LineTotal ON sales.SalesOrderDetail;
GO

CREATE NONCLUSTERED INDEX IX_SalesOrderDetail_ModifiedDate_Filtered ON sales.SalesOrderDetail (ModifiedDate)
INCLUDE (UnitPrice)
WHERE UnitPrice >= 100;
--subset of data from filtered index - logical reads 2
SELECT 
	SalesOrderID,
	SalesOrderDetailID,
	UnitPrice
FROM Sales.SalesOrderDetail
WHERE SalesOrderDetail.ModifiedDate = '6/30/2014'
AND SalesOrderDetail.UnitPrice >= 120;

--includes more data now takes more time - original logical reads of 1248
SELECT 
	SalesOrderID,
	SalesOrderDetailID,
	UnitPrice
FROM Sales.SalesOrderDetail
WHERE SalesOrderDetail.ModifiedDate = '6/30/2014'
AND SalesOrderDetail.UnitPrice >= 99;
