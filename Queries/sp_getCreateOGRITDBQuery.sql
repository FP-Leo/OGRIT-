CREATE PROCEDURE sp_getCreateOGRITDBQuery
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);

    -- Construct the full SQL statement as a string
    SET @sql =  'IF NOT EXISTS (SELECT * FROM master.sys.databases WHERE name = ''OGRIT-DB'') '+
				'BEGIN ' +
					'EXEC (''CREATE DATABASE [OGRIT-DB]'') ' +
				'END ' +
				'EXEC (''USE [OGRIT-DB]'') ' +
				'IF NOT EXISTS (SELECT * FROM [OGRIT-DB].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = ''StatisticsTable'') ' +
				'BEGIN ' +
					'EXEC(''CREATE TABLE [OGRIT-DB].[dbo].[StatisticsTable](' +
						'ID int PRIMARY KEY,' +
						'Name varchar(50) NOT NULL' +
					')'') ' +
				'END;'

    SELECT @sql AS QueryToExecute;
END
GO
