CREATE PROCEDURE sp_dropOGRITDB
AS
BEGIN
	IF EXISTS (SELECT * FROM master.sys.databases WHERE name = 'OGRIT-DB')
    BEGIN
        -- Create the database if it does not exist
        EXEC ('DROP DATABASE [OGRIT-DB]')
    END
    ELSE
    BEGIN
        PRINT 'Database Exists'
    END
END
GO