--Problem 14.	Car Rental Database

CREATE DATABASE [CarRental]

USE [CarRental]

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE [Categories](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[CategoryName] NVARCHAR(50) NOT NULL
	,[DailyRate] DECIMAL(5,2)
	,[WeeklyRate] DECIMAL(5,2)
	,[MonthlyRate] DECIMAL(5,2)
	,[WeekendRate] DECIMAL(5,2)
	)

INSERT INTO [Categories]
VALUES	('First category', 10.00, 50.00, 150.00, 15.00)
		,('Second category', 12.00, 60.00, 200.00, 20.00)
		,('Third category', 15.00, 70.00, 230.00, 25.00)

--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)

CREATE TABLE [Cars](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[PlateNumber] NVARCHAR(10) NOT NULL
	,[Manufacturer] NVARCHAR(20) NOT NULL
	,[Model] NVARCHAR(20) NOT NULL
	,[CarYear] SMALLINT NOT NULL
	,[CategoryId] INT NOT NULL
	FOREIGN KEY REFERENCES [Categories]([Id])
	,[Doors] TINYINT NOT NULL
	,[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 2000000)
	,[Condition] NVARCHAR(10) NOT NULL
	,[Available] CHAR(1) NOT NULL
	CHECK ([Available] IN ('Y', 'N'))
	)

INSERT INTO [Cars]
VALUES	('CB1234TA', 'OPEL', 'ASTRA', 2010, 1, 4, NULL, 'GOOD','Y')
		,('CB2345TA', 'NISAN', 'MIKRA', 2012, 2, 4, NULL, 'VERY GOOD','Y')
		,('CB3333TA', 'BMW', 'Q7', 2018, 3, 5, NULL, 'NEW','N')

--•	Employees (Id, FirstName, LastName, Title, Notes)

CREATE TABLE [Employees](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[FirstName] NVARCHAR(15) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[Title] NVARCHAR(20) NOT NULL
	,[Notes]NVARCHAR(MAX)
	)

INSERT INTO [Employees]
VALUES  ('Ivan', 'Ivanov', 'Manager', NULL)
		,('Petar', 'Petrov', 'Seller', NULL)
		,('Maria', 'Koleva', 'Seller', NULL)

--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)

CREATE TABLE [Customers](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[DriverLicenceNumber] NVARCHAR(10) UNIQUE NOT NULL
	,[FullName] NVARCHAR(60) NOT NULL
	,[Address] NVARCHAR(100) NOT NULL
	,[City] NVARCHAR(50) NOT NULL
	,[ZIPCode] SMALLINT NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Customers]
VALUES	('1234567890', 'Petar Ivanov Stoyanov', 'bul. Levski 2', 'Varna', 2000, NULL)
		,('2345678901', 'Stoyan Ivanov Stoyanov', 'ul. Maritca 16', 'Shumen', 9700, NULL)
		,('3456789012', 'Mariya Ivanova Popova', 'ul. 3-ti Mart 23', 'Provadiya', 2340, NULL)

--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
-- TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE [RentalOrders](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[EmployeeId] INT NOT NULL
	FOREIGN KEY REFERENCES [Employees]([Id])
	,[CustomerId] INT NOT NULL
	FOREIGN KEY REFERENCES [Customers]([Id])
	,[CarId] INT NOT NULL
	FOREIGN KEY REFERENCES [Cars]([Id])
	,[TankLevel] SMALLINT NOT NULL
	,[KilometrageStart] INT NOT NULL
	,[KilometrageEnd] INT NOT NULL
	,[TotalKilometrage] INT NOT NULL
	,[StartDate] DATE NOT NULL
	,[EndDate] DATE NOT NULL
	,[TotalDays] SMALLINT NOT NULL
	,[RateApplied] DECIMAL NOT NULL
	,[TaxRate] DECIMAL NOT NULL
	,[OrderStatus] NVARCHAR(10)
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [RentalOrders]
VALUES	(1, 1, 1, 30, 21000, 21100, 100, '2021-01-01', '2021-01-03', 3, 10.00, 0.2, 'CLOSED', NULL)
		,(2, 2, 2, 50, 22000, 22100, 100, '2021-01-05', '2021-01-07', 3, 12.00, 0.2, 'CLOSED', NULL)
		,(3, 3, 3, 50, 23000, 23100, 100, '2021-01-10', '2021-01-15', 3, 15.00, 0.2, 'OPEN', NULL)