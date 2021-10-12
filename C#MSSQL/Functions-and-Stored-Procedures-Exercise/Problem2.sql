--2.	Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [Salary] >= @salary

GO

EXEC usp_GetEmployeesSalaryAboveNumber 20000