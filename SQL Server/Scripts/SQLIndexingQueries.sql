USE AdventureWorks2017;
SET STATISTICS IO ON;
GO

SELECT * 
INTO dbo.sales_heap
FROM Sales.SalesOrderDetail

GO

SELECT 
	SalesOrderDetailID,
	SalesOrderID,
	ProductID,
	OrderQty
FROM dbo.sales_heap
WHERE sales_heap.SalesOrderID = 51875

GO
--Clustered Index
SELECT 
	SalesOrderDetailID,
	SalesOrderID,
	ProductID,
	OrderQty
FROM Sales.SalesOrderDetail
WHERE SalesOrderID = 51875


SELECT 
	*
FROM Sales.SalesOrderDetail
WHERE CarrierTrackingNumber = '260F-4DCF-A1'

CREATE NONCLUSTERED INDEX IX_SalesOrderDetail_CarrierTrackingNumber 
ON [Sales].[SalesOrderDetail] ([CarrierTrackingNumber]) 
GO

Update SalesPerson	
	SET rowguid = NEWID()
FROM Sales.SalesPerson
WHERE SalesPerson.BusinessEntityID = 290;
