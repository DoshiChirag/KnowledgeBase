use AdventureWorks2017
GO
Create view employee_report
AS
select [BusinessEntityID],[LoginID],[HireDate],[VacationHours]
from HumanResources.Employee
GO

---only shows necessary sensitive data
Select * from employee_report