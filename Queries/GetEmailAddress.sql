CREATE PROCEDURE GetEmailAddress
AS
BEGIN
    DECLARE @queryString NVARCHAR(MAX)

    -- Assign the SQL query to the variable
    SET @queryString = 'SELECT * FROM [AdventureWorks2022].[Person].[EmailAddress]'

    -- Return the query string
    SELECT @queryString AS QueryString
END
GO
