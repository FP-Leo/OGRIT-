CREATE PROCEDURE sp_createOGRITDB
AS
BEGIN
    -- Check if the database exists
    IF NOT EXISTS (SELECT * FROM master.sys.databases WHERE name = 'OGRIT-DB')
    BEGIN
        -- Create the database if it does not exist
        EXEC ('CREATE DATABASE [OGRIT-DB]')
    END
    ELSE
    BEGIN
        PRINT 'Database Exists'
    END

    -- Switch to the new database context
    EXEC ('USE [OGRIT-DB]')

    -- Check if the table exists in the newly created database
    IF NOT EXISTS (SELECT * FROM [OGRIT-DB].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StatisticsTable')
    BEGIN
        -- Create the table if it does not exist
        EXEC('CREATE TABLE [OGRIT-DB].[dbo].[StatisticsTable](
            ID int PRIMARY KEY,
            Name varchar(50) NOT NULL
        )')
    END
    ELSE
    BEGIN
        PRINT 'Table Exists'
    END
END
GO
