CREATE TABLE [dbo].[UserMovie]
(
	[UserId] INT NOT NULL,
	[MovieId] INT NOT NULL,
	CONSTRAINT PK_UserId_MovieId PRIMARY KEY ([UserId], [MovieId]),
	CONSTRAINT FK_UserMovie_User_UserId FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT FK_UserMovie_Movie_MovieId FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id])
)
