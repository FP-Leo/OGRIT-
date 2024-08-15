/** Object:  Table [dbo].[ServerConfig]    Script Date: 8.08.2024 17:40:12 **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ServerConfig](
	[ID] [int] NOT NULL,
	[ServerIPorName] [varchar](50) NOT NULL,
	[InstanceName] [varchar](50) NOT NULL,
	[Port] [int] NOT NULL default 1433,
	[SQLAuth] bit NOT NULL default 0,
	[DomainName] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_ServerConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO