Use AdventureWorks2017
GO

CREATE TABLE Sales.CustomerTracking
(
	CustomerID int,
	EventType nvarchar(56),
	date_of_update datetime
)

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER CustomerTrigger
	ON Sales.Customer 
	AFTER INSERT,DELETE
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO sales.CustomerTracking (CustomerID, EventType, date_of_update)
		SELECT CustomerID, 'INSERT', GetDate() FROM inserted


END

GO

SELECT * FROM Sales.CustomerTracking
SELECT CustomerID FROM Sales.Customer Where AccountNumber = 'AW00000004'


UPDATE Sales.Customer 
SET TerritoryID = 4
WHERE AccountNumber = 'AW00000004'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER Sales.CustomerTriggerExcept
	ON [Sales].[Customer] 
	INSTEAD OF INSERT,UPDATE,DELETE
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO sales.CustomerTracking (CustomerID, EventType, date_of_update)
		SELECT CustomerID, 'DELETE', GetDate() FROM deleted


END

GO

SELECT Min(CustomerID) FROM Sales.Customer
DELETE FROM Sales.Customer WHERE CUSTOMERID = 0
SELECT * FROM Sales.CustomerTracking
GO