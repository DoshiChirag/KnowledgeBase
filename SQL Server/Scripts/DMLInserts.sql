USE AdventureWorks2017
GO

DROP TABLE IF EXISTS dbo.TestTable

GO

CREATE TABLE dbo.TestTable
( TestID int IDENTITY,
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

