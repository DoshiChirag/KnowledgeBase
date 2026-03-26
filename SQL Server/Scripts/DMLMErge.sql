USE AdventureWorks2017
GO

DROP TABLE IF EXISTS StudentSource
DROP TABLE IF EXISTS StudentTarget

GO
CREATE TABLE StudentSource
( ID tinyint,
  FirstName varchar(10),
  LastName varchar(10)
)
GO

CREATE TABLE StudentTarget
( ID tinyint,
  FirstName varchar(10),
  LastName varchar(10)
)
GO

INSERT INTO STUDENTSOURCE
VALUES (3, 'Sara', 'Summers'),
	   (5, 'John', 'Smith')

GO

INSERT INTO STUDENTTARGET
VALUES (1, 'Penny', 'Layne'),
		(2, 'Bob', 'Rogers'),
		(3, 'Sara', 'Springs'),
		(4, 'Winston' ,'Smith')

GO


SELECT * from StudentSource
SELECT * FROM StudentTarget
GO


MERGE StudentTarget AS T
USING STUDENTSOURCE AS S
ON T.ID = S.ID
WHEN MATCHED THEN
	UPDATE SET T.LASTNAME = S.LASTNAME;

--WHEN NOT MATCHED BY TARGET THEN
-- INSERT (ID, FirstName, LastName)
--		VALUES(S.ID, S.FirstName, S.LastName)
--WHEN NOT MATCHED BY SOURCE THEN
-- DELETE;

DROP TABLE IF EXISTS StudentSource
DROP TABLE IF EXISTS StudentTarget

GO
CREATE TABLE StudentSource
( ID tinyint,
  FirstName varchar(10),
  LastName varchar(10)
)
GO

CREATE TABLE StudentTarget
( ID tinyint,
  FirstName varchar(10),
  LastName varchar(10)
)
GO

INSERT INTO STUDENTSOURCE
VALUES (3, 'Sara', 'Summers'),
	   (5, 'John', 'Smith')

GO

INSERT INTO STUDENTTARGET
VALUES (1, 'Penny', 'Layne'),
		(2, 'Bob', 'Rogers'),
		(3, 'Sara', 'Springs'),
		(4, 'Winston' ,'Smith')

GO

SELECT * from StudentSource
SELECT * FROM StudentTarget
GO


MERGE StudentTarget AS T
USING STUDENTSOURCE AS S
ON T.ID = S.ID
WHEN MATCHED THEN
	UPDATE SET T.LASTNAME = S.LASTNAME

WHEN NOT MATCHED BY TARGET THEN
 INSERT (ID, FirstName, LastName)
		VALUES(S.ID, S.FirstName, S.LastName)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
GO

SELECT * from StudentSource
SELECT * FROM StudentTarget
GO