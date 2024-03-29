--Problem 6.	University Database

CREATE DATABASE [University]

USE [University]

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY
	,[SubjectName] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Students] (
	[StudentID] INT PRIMARY KEY IDENTITY
	,[StudentNumber] BIGINT NOT NULL
	,[StudentName] NVARCHAR(50) NOT NULL
	,[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)


CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
	,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID])
	CONSTRAINT PK_StudentSubject
	PRIMARY KEY ([StudentID], [SubjectID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY
	,[PaymentDate] DATE NOT NULL
	,[PaymentAmount] DECIMAL(10,2) NOT NULL
	,[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)