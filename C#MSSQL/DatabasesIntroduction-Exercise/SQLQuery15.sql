--Problem 15.	Hotel Database

CREATE DATABASE [Hotel]

USE [Hotel]

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
		,('Petar', 'Petrov', 'Receptionist', NULL)
		,('Maria', 'Koleva', 'Receptionist', NULL)

--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE [Customers](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[AccountNumber] NVARCHAR(10) UNIQUE NOT NULL
	,[FirstName] NVARCHAR(15) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[PhoneNumber] NVARCHAR(20) NOT NULL
	,[EmergencyName] NVARCHAR(10) NOT NULL
	,[EmergencyNumber] SMALLINT NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Customers]
VALUES  ('N102030', 'Valya', 'Valentinova', '0888234567', 'Varna', 1111, NULL)
		,('N112233', 'Mariya', 'Marcheva', '0888123456', 'Montana', 2222, NULL)
		,('N122334', 'Panajot', 'Panajotov', '0885123456', 'Burgas', 3333, NULL)

--•	RoomStatus (RoomStatus, Notes)
CREATE TABLE [RoomStatus](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[RoomStatus] NVARCHAR(10) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [RoomStatus]
VALUES  ('Occupied', NULL)
		,('Free', NULL)
		,('Reserved', NULL)

--•	RoomTypes (RoomType, Notes)
CREATE TABLE [RoomTypes](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[RoomType] NVARCHAR(10) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [RoomTypes]
VALUES  ('Single', NULL)
		,('Double', NULL)
		,('Apartment', NULL)

--•	BedTypes (BedType, Notes)
CREATE TABLE [BedTypes] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[BedType] NVARCHAR(20) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [BedTypes]
VALUES  ('Single', NULL)
		,('Single and a half', NULL)
		,('Double', NULL)

--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE [Rooms] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[RoomNumber] SMALLINT UNIQUE NOT NULL
	,[RoomType] INT NOT NULL
	FOREIGN KEY REFERENCES [RoomTypes]([Id])
	,[BedType] INT NOT NULL
	FOREIGN KEY REFERENCES [BedTypes]([Id])
	,[Rate] DECIMAL NOT NULL
	,[RoomStatus] INT NOT NULL
	FOREIGN KEY REFERENCES [RoomStatus]([Id])
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Rooms]
VALUES	(212, 1, 1, 2.00, 1, NULL)
		,(213, 2, 2, 3.00, 2, NULL)
		,(214, 3, 3, 4.00, 3, NULL)

--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied,
-- TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE [Payments](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[EmployeeId] INT NOT NULL
	FOREIGN KEY REFERENCES [Employees]([Id])
	,[PaymentDate] DATE NOT NULL
	,[AccountNumber] NVARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES [Customers]([AccountNumber])
	,[FirstDateOccupied] DATE NOT NULL
	,[LastDateOccupied] DATE NOT NULL
	,[TotalDays] SMALLINT NOT NULL
	,[AmountCharged] DECIMAL NOT NULL
	,[TaxRate] DECIMAL NOT NULL
	,[TaxAmount] DECIMAL NOT NULL
	,[PaymentTotal] DECIMAL NOT NULL
	,[Notes] NVARCHAR(MAX)
	)


INSERT INTO [Payments]
VALUES	(1, '2021-06-21', 'N102030', '2021-06-21', '2021-06-23', 2, 200.00, 0.2, 40.00, 240.00, NULL)
		,(2, '2021-06-21', 'N112233', '2021-06-21', '2021-06-23', 2, 200.00, 0.2, 40.00, 240.00, NULL)
		,(3, '2021-06-21', 'N122334', '2021-06-21', '2021-06-23', 2, 200.00, 0.2, 40.00, 240.00, NULL)

--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, 
--RateApplied, PhoneCharge, Notes)

CREATE TABLE [Occupancies](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[EmployeeId] INT NOT NULL
	FOREIGN KEY REFERENCES [Employees]([Id])
	,[DateOccupied] DATE NOT NULL
	,[AccountNumber] NVARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES [Customers]([AccountNumber])
	,[RoomNumber] SMALLINT NOT NULL
	FOREIGN KEY REFERENCES [Rooms]([RoomNumber])
	,[RateApplied] DECIMAL NOT NULL
	,[PhoneCharge] CHAR(3) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Occupancies]
VALUES	(1, '2021-06-21', 'N102030', 212, 240.00, 'YES', NULL)
		,(2, '2021-06-21', 'N112233', 213, 240.00, 'NO', NULL)
		,(3, '2021-06-21', 'N122334', 214, 240.00, 'NO', NULL)