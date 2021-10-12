USE [SoftUni]

GO

--13. Departments Total Salaries
  SELECT [DepartmentID]
         ,SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14. Employees Minimum Salaries
  SELECT [DepartmentID]
         ,MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]
  HAVING [DepartmentID] IN (2, 5, 7)

 GO
--15. Employees Average Salaries

SELECT * INTO  [EmployeesWithSalaryMoreThan30000]
 FROM [Employees]
 WHERE [Salary] > 30000
 GO
DELETE FROM [EmployeesWithSalaryMoreThan30000]
WHERE [ManagerID] = 42

UPDATE [EmployeesWithSalaryMoreThan30000]
SET [Salary] = [Salary] + 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID] , AVG([Salary]) AS AverageSalary
FROM [EmployeesWithSalaryMoreThan30000]
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries

SELECT [DepartmentID]
       ,[MaxSalary]
  FROM 
		(
			  SELECT [DepartmentID] , MAX([Salary]) AS [MaxSalary]
			    FROM [Employees]
			GROUP BY [DepartmentID]
		) AS MaxSalaryPerDepartmentSubQuery
 WHERE [MaxSalary] < 30000 OR [MaxSalary] >70000


 --17. Employees Count Salaries
 SELECT COUNT([Salary]) AS [Count]
   FROM [Employees]
  WHERE [ManagerID] IS NULL

--18. 3rd Highest Salary
SELECT DISTINCT [DepartmentID]
                ,[Salary] AS [ThirdHighestSalary]
           FROM
				(
					SELECT [DepartmentID]
					       ,[Salary]
						   ,DENSE_RANK() OVER (PARTITION BY [DepartmentID]
						                           ORDER BY [Salary] DESC) AS [Rank]
					  FROM [Employees]
				) AS [SalaryRankSubQuery]
WHERE [Rank] = 3

--19. Salary Challenge 


SELECT TOP(10) [FirstName], [LastName],[DepartmentID] 
          FROM [Employees] AS e
         WHERE [Salary] > 
						(
							  SELECT AVG([Salary])
							    FROM [Employees]
							   WHERE [DepartmentID] = e.[DepartmentID]
							GROUP BY [DepartmentID]
						)

