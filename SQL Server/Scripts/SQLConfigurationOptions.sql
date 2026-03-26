USe AdventureWorks2017
GO

DECLARE @Result INT;
Exec @Result = sys.sp_configure 'clr strict security', 0
SELECT Config = @Result
GO

DECLARE @Result INT;
Exec @Result = sys.sp_add_trusted_assembly 'C:/ACM/TrainingResources/SQL Server/CLR/CLRFunctions/CLRFunctions/bin/Debug/CLRFunctions.dll'
SELECT Config = @Result
GO

EXECUTE sp_configure 'show advanced options', 1;
RECONFIGURE
GO

EXECUTE sp_configure 'clr strict security';
GO

EXECUTE sp_configure 'clr strict security', '0';
RECONFIGURE;
GO

EXECUTE sp_configure 'clr enable';
GO

EXECUTE sp_configure 'clr enabled', '1';
RECONFIGURE;
GO


