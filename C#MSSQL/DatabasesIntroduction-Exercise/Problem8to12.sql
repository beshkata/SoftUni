-- Problem 8.	Create Table Users
CREATE TABLE [Users](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY
	,[Username] VARCHAR(30) UNIQUE NOT NULL
	,[Password] VARCHAR(26) NOT NULL
	,[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH([ProfilePicture]) <= 900000)
	,[LastLoginTime] DATETIME2
	,[IsDeleted] VARCHAR(5)
	CHECK ([IsDeleted] IN ('true', 'false'))
	)

INSERT INTO [Users]
VALUES	('Pesho', '123444', NULL, GETDATE(), 'false')
		, ('Gosho', 'qwerty', NULL, GETDATE(), 'true')
		, ('Stamat', 'dfgh44', NULL, GETDATE(), 'false')
		, ('Ivan', 'zxcv23', NULL, GETDATE(), 'false')
		, ('Petkan', 'qwsdf', NULL, GETDATE(), 'false')

-- Problem 9.	Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC07D4DDA251

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_IdUsername PRIMARY KEY([Id], [Username])

--Problem 10.	Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT CHECK_Password_Length CHECK(LEN([Password]) >= 5)

--Problem 11.	Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime 
DEFAULT GETDATE() FOR [LastLoginTime]

--Problem 12.	Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT PK_Users_IdUsername

ALTER TABLE [Users]
DROP CONSTRAINT UQ__Users__536C85E44B4F5A2E

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_Id PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT UQ_Users_Username UNIQUE([Username])

ALTER TABLE [Users]
ADD CONSTRAINT CHECK_Users_UsernameLength
CHECK (LEN([Username]) >=3)