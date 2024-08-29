USE [OGRIT-DB]
GO

/****** Object:  Table [dbo].[ServerConfig]    Script Date: 22-Aug-24 12:03:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServerConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServerIPorName] [varchar](50) NOT NULL,
	[Port] [int] NOT NULL,
	[InstanceName] [varchar](50) NOT NULL,
	[SQLAuth] [bit] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	CONSTRAINT [UNIQUE_Connection] UNIQUE(ServerIPorName, Port, InstanceName),
	CONSTRAINT [PK_ServerConfig] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ServerConfig] ADD  DEFAULT ((1433)) FOR [Port]
GO

ALTER TABLE [dbo].[ServerConfig] ADD  DEFAULT ((0)) FOR [SQLAuth]
GO


