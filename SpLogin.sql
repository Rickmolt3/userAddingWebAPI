USE userAddingWebAPIDB

GO

ALTER PROCEDURE dbo.spLogin
    @appUserEmail NVARCHAR(150),
    @appUserPassword NVARCHAR(150)

AS
BEGIN
SET NOCOUNT ON;
SELECT  appUserEmail
FROM dbo.appUser
WHERE appUserEmail=@appUserEmail AND appUserPassword=HASHBYTES('SHA2_512', @appUserPassword)
end
--BEGIN

--    SET NOCOUNT ON

--    DECLARE @appUserID INT

--    IF EXISTS (SELECT TOP 1 appUserID FROM [dbo].[appUser] WHERE appUserEmail=@appUserEmail)
--    BEGIN
--        SET @appUserID=(SELECT appUserID FROM [dbo].[appUser] WHERE appUserEmail=@appUserEmail AND appUserPassword=HASHBYTES('SHA2_512', @appUserPassword))

--    END
    

--END