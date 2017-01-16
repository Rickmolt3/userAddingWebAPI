USE userAddingWebAPIDB
GO

EXEC dbo.spAddUser
          @appUserEmail = N'Chuck@chuck.com',
          @appUserPassword = N'6666666',
          @appUserFirstName = N'Admin',
          @appUserLastName = N'Administrator',
		  @appUserAge = N'15'

SELECT *
FROM [dbo].[appUser]