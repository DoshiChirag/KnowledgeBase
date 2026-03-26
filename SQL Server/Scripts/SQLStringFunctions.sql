USE AdventureWorks2017

SELECT Name, LEFT(Name, 5) AS FIRSTFIVE,
	RIGHT(Name, 3) AS LASTTHREE,
	SUBSTRING(Name, 3,4) AS SubResult
FROM Production.Product

GO

SELECT OrderDate, ShipDate ,
	DATEDIFF(d, OrderDate, ShipDate) AS ProcessTime,
	DATEADD(d, 90, ShipDate) AS InvoiceDue,
	YEAR(OrderDate) AS OrderYear
	FROM SALES.SalesOrderHeader

GO

SELECT GETDATE() AS SQL_DateTime_in_ms,
		CURRENT_TIMESTAMP AS ANSI_DateTimeString,
		SYSDATETIME() AS SQL_DateTime2_in_ns

GO

SELECT UnitPrice,
	IIF(UnitPrice > 500, 'Bicycle', 'Accessories')
	FROM Sales.SalesOrderDetail

GO

SELECT DISTINCT SpecialOfferID,
	IIF(SpecialOfferID<= 4,CHOOSE(SpecialOfferID, 'No Discount', 'Seasonal Discount', 'Volume Discount', 'Bargain'), 'FIGHT')
	FROM Sales.SalesOrderDetail

GO
		

SELECT  ModifiedDate ,
	FORMAT(ModifiedDate, 'd', 'en-US') AS USDates,
	FORMAT(ModifiedDate, 'd', 'en-UK') AS UKDates
FROM Sales.SalesOrderDetail

GO


SELECT  ModifiedDate ,
	FORMAT(ModifiedDate, 'M/d/yy') AS USDates,
	FORMAT(ModifiedDate, 'M/d/yyyy') AS USDates2
FROM Sales.SalesOrderDetail

GO

SELECT  UnitPrice,
	FORMAT(UnitPrice, 'N', 'en-US') AS Number_Format,
	FORMAT(UnitPrice, 'G', 'en-US') AS General_Format,
	FORMAT(UnitPrice, 'C', 'en-US') AS Currency_Format,
	FORMAT(UnitPrice, 'N3', 'en-US') AS Decimal_Format,
	FORMAT(UnitPrice, '00,000.###') AS Custom_Format
FROM Sales.SalesOrderDetail

GO

SELECT FirstName, LastName, ISNULL(MiddleName, '')
FROM PERSON.Person

GO

DROP TABLE IF EXISTS PERSON.PhoneContact

CREATE TABLE PERSON.PhoneContact
(
	ContactID tinyint IDENTITY,
	HomePhone varchar(12),
	WorkPhone varchar(12),
	CellPhone varchar(12)
)

GO

INSERT INTO PERSON.PhoneContact
VALUES ('697-555-0142', '697-555-7075', 'NULL'),
		('697-555-0142', '697-555-7075', 'NULL'),
		(NULL, NULL, '317-555-2929'),
		(NULL, NULL, '905-555-8679')


SELECT *,
COALESCE(HomePhone, WorkPhone, CellPhone) AS FirstContact
FROM PERSON.PhoneContact
GO





