USE AdventureWorks2017

SELECT * FROM dbo.TestTable

GO

UPDATE dbo.TestTable
SET TestCode= 'ND'
WHERE TestID = 140

SELECT * FROM dbo.TestTable

GO

UPDATE dbo.TestTable
SET TestCode= 'ND',
TESTDate='20190101'
WHERE TestID = 150

SELECT * FROM dbo.TestTable

GO

UPDATE dbo.TestTable
SET TestCode= 'ND',
TESTDate='20190101'
WHERE TestID > 150

SELECT * FROM dbo.TestTable

GO