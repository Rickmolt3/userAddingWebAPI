USE userAddingWebAPIDB
Go
EXEC	dbo.spLogin
		@appUserEmail = N'Admin',
		@appUserPassword = N'123'
