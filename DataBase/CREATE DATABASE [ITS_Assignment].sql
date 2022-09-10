CREATE DATABASE [ITS_Assignment]

GO

USE [ITS_Assignment]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 11/09/2022 12:11:35 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[Class] [nchar](1) NULL,
	[Phone] [nvarchar](11) NULL,
	[Email] [nvarchar](100) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
