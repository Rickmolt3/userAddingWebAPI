USE userAddingWebAPIDB

GO

CREATE TABLE appUser(
	appUserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,

	appUserEmail VARCHAR(150) NOT NULL,

	appUserPassword BINARY(64) NOT NULL,

	appUserFirstName VARCHAR(150) NOT NULL,

	appUserLastName VARCHAR(150) NOT NULL,

	appUserAge INT NOT NULL

	
)

GO
