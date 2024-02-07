CREATE PROCEDURE [dbo].[Login]
	@Username NVARCHAR(100),
	@Password NVARCHAR(30)
AS
BEGIN

	IF EXISTS (SELECT * FROM [User] WHERE UserName = @Username)
		BEGIN
			
			DECLARE @Pepper NVARCHAR(100)

			SET @Pepper = dbo.GetPepper();
			
			SELECT * 
			From [User] 
			Where UserName = @Username AND Password = HASHBYTES('SHA_512', Salt + @Password + @Pepper)


		END


END
