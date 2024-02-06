﻿CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PosterUrl] NVARCHAR(250),
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX),
	[Release] DATETIME NOT NULL,
	[Score] INT NOT NULL,

)