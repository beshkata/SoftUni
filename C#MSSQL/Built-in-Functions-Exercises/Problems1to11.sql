--Problem 1.	Find Names of All Employees by First Name
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

--Problem 2.	Find Names of All employees by Last Name 
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'


--Problem 3.	Find First Names of All Employees
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--Problem 4.	Find All Employees Except Engineers
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE CHARINDEX('engineer', [JobTitle]) = 0

--Problem 5.	Find Towns with Name Length
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--Problem 6.	Find Towns Starting With
  SELECT *
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--Problem 7.	Find Towns Not Starting With
  SELECT *
    FROM [Towns]
   WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

--Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE YEAR([HireDate]) > 2000


--Problem 9.	Length of Last Name
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

--Problem 10.	Rank Employees by Salary
  SELECT [EmployeeID], [FirstName], [LastName], [Salary],
         DENSE_RANK () OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--Problem 11.	Find All Employees with Rank 2 *

 SELECT *
   FROM (
		  SELECT [EmployeeID], [FirstName], [LastName], [Salary],
				 DENSE_RANK () OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
			FROM [Employees]
		   WHERE [Salary] BETWEEN 10000 AND 50000
		 )    AS r
   WHERE r.[Rank] = 2
ORDER BY [Salary] DESC
