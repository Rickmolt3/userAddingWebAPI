USE userAddingWebAPIDB
GO
ALTER PROCEDURE dbo.spGetAllUsers
AS
SELECT 
			appUserEmail,
			appUserFirstName,
			appUserLastName,
			appUserAge

		FROM appUser

		WHERE appUserID > 0