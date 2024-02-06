﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100),
	[FirstName] NVARCHAR(100),
	[Email] NVARCHAR(100) NOT NULL,
	[Password] VARBINARY(64) NOT NULL,
	[Salt] VARCHAR(50) NOT NULL,

	CONSTRAINT UK_UserName UNIQUE (UserName)
	

)