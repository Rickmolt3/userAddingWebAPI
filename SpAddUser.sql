USE userAddingWebAPIDB

GO

CREATE PROCEDURE dbo.spAddUser
    @appUserEmail NVARCHAR(150), 
	@appUserPassword NVARCHAR(150),
    @appUserFirstName NVARCHAR(150), 
    @appUserLastName NVARCHAR(150), 
    @appUserAge INT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO dbo.[appUser] (appUserEmail, appUserPassword, appUserFirstName, appUserLastName, appUserAge)
        VALUES(@appUserEmail, HASHBYTES('SHA2_512', @appUserPassword), @appUserFirstName, @appUserLastName,@appUserAge)


    END TRY
    BEGIN CATCH
		--future error handling
    END CATCH

END
	