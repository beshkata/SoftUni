--Problem 16.	Create SoftUni Database
CREATE DATABASE [SoftUni]

USE [SoftUni]

--•	Towns (Id, Name)
CREATE TABLE [Towns](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[Name] NVARCHAR(50) NOT NULL
	)

--•	Addresses (Id, AddressText, TownId)
CREATE TABLE [Addresses](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	, [AddressText] NVARCHAR(200) NOT NULL
	, [TownId] INT NOT NULL
	FOREIGN KEY REFERENCES [Towns]([Id])
	)

--•	Departments (Id, Name)
CREATE TABLE [Departments](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[Name] NVARCHAR(50) NOT NULL
	)

--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, 
--HireDate, Salary, AddressId)
CREATE TABLE [Employees](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[FirstName] NVARCHAR(15) NOT NULL
	,[MiddleName] NVARCHAR(15) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[JobTitle]  NVARCHAR(30) NOT NULL
	,[DepartmentId] INT NOT NULL
	FOREIGN KEY REFERENCES [Departments]([Id])
	,[HireDate] DATE NOT NULL
	,[Salary] DECIMAL NOT NULL
	,[AddressId] INT 
	FOREIGN KEY REFERENCES [Addresses]([Id])
	)
	

--Problem 17.	Backup Database
BACKUP DATABASE [SoftUni]
TO DISK = 'd:\SoftUniDB.bak'
WITH FORMAT,
	MEDIANAME = 'SoftUniDBBackup',
	NAME ='Full Backup of SoftUni DATABASE'

USE [master]
DROP DATABASE [SoftUni]

RESTORE DATABASE [SoftUni]
FROM DISK = 'd:\SoftUniDB.bak'

USE [SoftUni]

--Problem 18.	Basic Insert

INSERT INTO [Towns]
VALUES	('Sofia')
		,('Plovdiv')
		,('Varna')
		,('Burgas')
--Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO [Departments]
VALUES	('Engineering')
		,('Sales')
		,('Marketing')
		,('Software Development')
		,('Quality Assurance')


INSERT INTO [Employees]
VALUES	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, NULL)
		,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, NULL)
		,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, NULL)
		,('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, NULL)
		,('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, NULL)

--Problem 19.	Basic Select All Fields

