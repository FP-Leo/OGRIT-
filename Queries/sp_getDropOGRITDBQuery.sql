CREATE PROCEDURE sp_getDropOGRITDBQuery
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);

    -- Construct the full SQL statement as a string
    SET @sql = 'IF EXISTS (SELECT * FROM master.sys.databases WHERE name = ''OGRIT-DB'') ' +
               'BEGIN ' +
               'DROP DATABASE [OGRIT-DB] ' +
               'END';

    -- Return the full SQL query
    SELECT @sql AS QueryToExecute;
END
GO

