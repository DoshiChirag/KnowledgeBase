USE AdventureWorks2017
GO

CREATE TABLE North_Orders
(OrderID int PRIMARY KEY,
 Store char(5)
 )
GO

CREATE TABLE South_Orders
(OrderID int PRIMARY KEY,
 Store char(5)
 )
GO

CREATE SEQUENCE dbo.SeqOrders
AS int START with 100 INCREMENT BY 100
GO


INSERT INTO North_Orders
VALUES (NEXT VALUE for dbo.SeqOrders, 'North')

INSERT INTO SOUTH_Orders
VALUES (NEXT VALUE for dbo.SeqOrders, 'South')

GO 3

SELECT * FROM North_Orders
UNION
SELECT * FROM South_Orders
ORDER BY OrderID

Go



