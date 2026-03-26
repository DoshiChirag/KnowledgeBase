USE AdventureWorks2017
GO

DROP TABLE IF EXISTS dbo.TestTable

GO

CREATE TABLE dbo.TestTable
( TestID int IDENTITY (100,10),
   TestCode char(2) NOT NULL,
	TestName varchar(10),
	TestDate date DEFAULT('01/01/2019'),
	TestNote varchar(50) NULL
)

GO

INSERT dbo.TestTable
VALUES ('C3', 'C3PO', '20181130', 'Fluent in 6 million languages')

GO

SELECT * FROM dbo.TestTable

GO


INSERT INTO dbo.TestTable
(TestCode, TestNAme, TestDate, TestNote)
VALUES ('L3', 'L337', '02-14-2016', 'Droid'),
		('R2', 'R2D2', DEFAULT, NULL)


GO

SET IDENTITY_INSERT dbo.TestTable ON
INSERT INTO dbo.TestTable
(TestID, TestCode, TestName, TestDate, TestNote)
VALUES (99, 'BB', 'BB-8', '12/18/2015', 'A round orange')

SET IDENTITY_INSERT dbo.TestTable OFF

GO

INSERT INTO dbo.TestTable
(TestCode, TestName, TestDate, TestNote)
VALUES ('K2', 'K2SO', '12/16/2016', 'A rogue droid')

SELECT * FROM dbo.TestTable

GO

