USE AdventureWorks2017;
GO



DELETE FROM dbo.TestTable 
WHERE TestID < 140
SELECT * FROM dbo.TestTable
GO

TRUNCATE TABLE dbo.TestTable
SELECT * FROM dbo.TestTable
GO

DROP TABLE dbo.TestTable
SELECT * FROM dbo.TestTable -- No such dbo
GO


