--Problem 13.	Movies Database

CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY
	,[DirectorName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Directors]
VALUES	('Petar', NULL)
		,('Ivan', NULL)
		,('Gosho', NULL)
		,('Maria', NULL)
		,('Valya', NULL)

CREATE TABLE [Genres](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[GenreName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Genres]
VALUES	('Fantasy', NULL)
		,('Sci-Fi', NULL)
		,('Action', NULL)
		,('Triler', NULL)
		,('Horor', NULL)

CREATE TABLE [Categories](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[CategoryName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Categories]
VALUES	('First', NULL)
		,('Second', NULL)
		,('Third', NULL)
		,('Fourth', NULL)
		,('Fifth', NULL)

CREATE TABLE [Movies](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY
	,[Title] NVARCHAR(50) NOT NULL
	,[DirectorId] BIGINT NOT NULL
	FOREIGN KEY REFERENCES [Directors]([Id])
	,[CopyrightYear] SMALLINT NOT NULL
	,[Length] DECIMAL(3,2)
	,[GenreId] INT
	FOREIGN KEY REFERENCES [Genres]([Id])
	,[CategoryId] INT
	FOREIGN KEY REFERENCES [Categories]([Id])
	,[Rating] DECIMAL(3,1)
	,[Notes] NVARCHAR(MAX)
	)

INSERT INTO [Movies]
VALUES	('First movie', 1, 1972, 1.32, 1, 1, 8.1, 'Some notes')
		,('Second movie', 2, 1982, 1.42, 2, 2, 6.7, 'Some notes')
		,('Third movie', 3, 1988, 1.52, 3, 3, 7.3, 'Some notes')
		,('Fourth movie', 4, 1990, 2.12, 4, 4, 6.3, 'Some notes')
		,('Fifth movie', 5, 1991, 1.42, 5, 5, 10.0, 'Some notes')

