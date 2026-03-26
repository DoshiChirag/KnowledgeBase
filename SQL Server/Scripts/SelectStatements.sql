USE [AdventureWorks2017]
GO

SELECT  FirstName, LastName
FROM Nipa.AdventureWorks2017.Person.Person
WHERE FirstName = 'Kim'

GO

/**Expression**/
SELECT  (LastName +','+ FirstName) AS 'Full Name'
FROM Person.Person AS P
WHERE FirstName = 'Kim'


GO

SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
WHERE BusinessEntityID <= 38

GO

SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
WHERE BusinessEntityID = 38 or BusinessEntityID = 32 or BusinessEntityID = 36

GO

SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
WHERE BusinessEntityID IN (32,36,38)

GO

SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
WHERE LastNAme = 'Adams' AND FirstName = 'Alex'

GO

SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
WHERE LastNAme = 'Adams' AND FirstName LIKE '_A%'

GO
/**Divides**/
SELECT 4/01/2012
/**Subtracts**/
SELECT 4-01-2012
/**Date as string**/
SELECT '04/01/2012'



GO

SELECT SalesOrderID, OrderDate
FROM Sales.SalesOrderHeader
--WHERE  OrderDate  >= '04/01/2012' AND OrderDate <= '08/31/2012'
WHERE  OrderDate  BETWEEN '04/01/2012' AND '08/31/2012'


GO

--Fields with novalues take default value for primitive types (if specified in schema) and NULL otherwise
SELECT FIRSTNAME, LASTNAME, MiddleName
FROM Person.Person
WHERE MiddleName = 'NULL' or MiddleName IS NOT NULL

GO

SELECT FirstName, LastName
FROM Person.Person
WHERE LastNAme IN('Adams', 'Zimmerman')
ORDER BY LastNAme DESC, FirstNAme ASC

GO

SELECT SalesOrderID, OrderDate
FROM Sales.SalesOrderHeader
ORDER BY SalesOrderID DESC

GO

SELECT TOP 100 PERCENT SalesOrderID, OrderDate
FROM Sales.SalesOrderHeader
ORDER BY SalesOrderID DESC

GO
