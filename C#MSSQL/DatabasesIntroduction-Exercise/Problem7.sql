CREATE TABLE [People](
	[Id] BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL
	,[Name] NVARCHAR(200) NOT NULL
	,[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture])<= 200000)
	,[Height] DECIMAL(3,2)
	,[Weight] DECIMAL(5,2)
	,[Gender] CHAR(1)
	CHECK ([Gender] IN ('m', 'f'))
	,[Birthdate] DATETIME2 NOT NULL
	,[Biography] NVARCHAR(MAX)
	)


INSERT INTO [People]
VALUES	('Valio', NULL, 1.22, 20.33, 'm', '2018-06-23 07:30:20', NULL)
		,('Pesho', NULL, 1.33, 22.44, 'm', '2017-06-23 07:30:20', NULL)
		,('Gosho', NULL, 1.55, 44.63, 'm', '2016-06-23 07:30:20', NULL)
		,('Vanio', NULL, 1.77, 66.88, 'm', '2015-06-23 07:30:20', NULL)
		,('Petia', NULL, 1.99, 56.333, 'f', '2014-06-23 07:30:20', NULL)