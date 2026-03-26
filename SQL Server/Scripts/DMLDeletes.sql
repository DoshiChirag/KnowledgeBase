USE AdventureWorks2017;
GO

-- DELETE FROM dbo.TestTable deletes all records

DELETE FROM dbo.TestTable 
WHERE TestID = 130
SELECT * FROM dbo.TestTable
GO

DELETE FROM dbo.TestTable 
WHERE TestID IN (140, 170)

SELECT * FROM dbo.TestTable

