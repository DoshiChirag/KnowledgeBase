USE AdventureWorks2017
GO

CREATE TABLE dbo.TestTable
( AcctID int IDENTITY,
 FirstName varchar(10),
 LastName varchar(10),
 ModifiedDate date
)

GO

INSERT INTO dbo.TestTable 
VALUES ('John', 'Deardurff', '20160216'),
		('Jane' , 'Doe', '20150314'),
		('Jenny' , 'Day', '20171108')


GO

SELECT * FROM dbo.TestTable

GO

UPDATE dbo.TestTable
	SET ModifiedDate = '20181225'
GO

DELETE dbo.TestTable
 WHERE AcctID = 2

GO


