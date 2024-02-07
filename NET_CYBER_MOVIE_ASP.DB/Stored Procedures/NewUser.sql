CREATE PROCEDURE [dbo].[NewUser]
	@Email NVARCHAR(100),
	@Password NVARCHAR(30),
	@Username NVARCHAR(100),
	@LastName NVARCHAR(100),
	@FirstName NVARCHAR(100)

AS
BEGIN

	DECLARE @Salt VARCHAR(50)
	DECLARE @HashedPassword VARBINARY(64)
	DECLARE @Pepper VARCHAR(100)

	SET @Pepper = dbo.GetPepper()
	SET @Salt = CONVERT(VARCHAR(50),NEWID())
	SET @HashedPassword = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Pepper))

	INSERT INTO [User] (UserName, LastName,FirstName,Email,Salt,Password)
	VALUES (@Username, @LastName, @FirstName,@Email,@Salt,@HashedPassword)

END
