USE AdventureWorks2017
GO

CREATE TABLE dbo.TestTable
(TestID tinyint IDENTITY,
 TestName char(15))

GO

INSERT INTO dbo.TestTable
OUTPUT inserted.*
VALUES ('FIRST ROW'), ('SECOND ROW'), ('THIRD ROW'), ('FOURTH ROW')
GO


DELETE dbo.TestTable
	OUTPUT deleted.*
WHERE TestID = 4

GO


UPDATE dbo.TestTable
SET TestName = 'Updated Row'
	OUTPUT inserted.TestName, deleted.TestName
	WHERE TestID = 3
GO