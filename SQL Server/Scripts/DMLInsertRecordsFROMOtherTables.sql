USE AdventureWorks2017
GO

SELECT * FROM dbo.TestTable
SELECT * from Person.Person


INSERT INTO dbo.TestTable
SELECT 
PersonType, LastName, ModifiedDate, 'Not Droids'
FROM PERSON.Person
WHERE BusinessEntityID < 10

SELECT * FROM dbo.TestTable
GO

SELECT * INTO Dbo.NewArchiveTable
FROM dbo.TestTable


SELECT * FROM dbo.NewArchiveTable

GO