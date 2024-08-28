USE [OGRIT-DB]
GO

CREATE TABLE [dbo].[ServerProcedures](
	[ProcedureName] [nvarchar](128) PRIMARY KEY,
	[Description] [nvarchar](256) NOT NULL,
	[StoredAtDatabase] [nvarchar](128) NOT NULL DEFAULT 'OGRIT-DB',
	[UsesSchema] [nvarchar](128) DEFAULT 'dbo',
	[NumberOfParameters] [int] NOT NULL DEFAULT 0,
	[ParameterDescription] [nvarchar](256) NULL DEFAULT NULL,
	[OnReturnExecute] [nvarchar](128) NULL DEFAULT NULL,
)


