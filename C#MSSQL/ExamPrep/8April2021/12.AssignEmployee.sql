CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @EmpoyeeDepartmentId INT
	SET @EmpoyeeDepartmentId = (SELECT DepartmentId 
	                            FROM Employees 
							    WHERE Id = @EmployeeId)
	DECLARE @ReportDepartmentId INT
	SET @ReportDepartmentId = (SELECT c.DepartmentId 
							   FROM Reports AS r
							   LEFT JOIN Categories AS c
							   ON r.CategoryId = c.Id
							   WHERE r.Id = @ReportId)

	IF (@EmpoyeeDepartmentId <> @ReportDepartmentId)
	BEGIN 
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	END
	ELSE
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
	END

END

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2
