# Assignment_ITS_MahmoudBadawy

MahmoudBadawy_Assignment
Front is done by angular 14
to open Front you should update your CLI and Run this commands

npm i ng s --o

Back is done by .net Core API (.Net 6)
to open Back you should Rebuild All projects and Ensure that all Packages is Ok then Run Project (API as Start project) ensure that the link for project is and ensure that Connection String with DB is OK

DB Script :
CREATE DATABASE [ITS_Assignment]

GO

USE [ITS_Assignment] GO

/****** Object: Table [dbo].[Customer] Script Date: 11/09/2022 12:11:35 ص ******/ SET ANSI_NULLS ON GO

SET QUOTED_IDENTIFIER ON GO

CREATE TABLE [dbo].[Customer]( [ID] [int] NOT NULL, [CustomerName] nvarchar NULL, [Class] nchar NULL, [Phone] nvarchar NULL, [Email] nvarchar NULL, [Comment] nvarchar NULL, CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] GO
