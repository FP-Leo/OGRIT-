CREATE PROCEDURE InsertEmailAddress
    @BusinessEntityID INT,
	@EmailAddressID INT,
    @EmailAddress NVARCHAR(50),
    @RowGuid UNIQUEIDENTIFIER,
    @ModifiedDate DATETIME
AS
BEGIN
    INSERT INTO [dbo].[EmailAddress]
           ([BusinessEntityID]
		   ,[EmailAddressID]
           ,[EmailAddress]
           ,[rowguid]
           ,[ModifiedDate])
     VALUES
           (@BusinessEntityID
		   ,@EmailAddressID
           ,@EmailAddress
           ,@RowGuid
           ,@ModifiedDate)
END
GO