CREATE FUNCTION dbo.Hello
(@name as nvarchar(255))
RETURNS nvarchar(255)
AS
EXTERNAL NAME CLRFunctions.CLRFunction.Hello
GO

SELECT dbo.Hello ('Chirag Doshi')
GO