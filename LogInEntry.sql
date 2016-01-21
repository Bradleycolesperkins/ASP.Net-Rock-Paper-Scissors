USE [RPSLS]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_LogInEntry_Wins]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogInEntry] DROP CONSTRAINT [DF_LogInEntry_Wins]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_LogInEntry_Losses]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogInEntry] DROP CONSTRAINT [DF_LogInEntry_Losses]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_LogInEntry_Ties]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogInEntry] DROP CONSTRAINT [DF_LogInEntry_Ties]
END

GO

USE [RPSLS]
GO

/****** Object:  Table [dbo].[LogInEntry]    Script Date: 03/05/2014 19:23:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogInEntry]') AND type in (N'U'))
DROP TABLE [dbo].[LogInEntry]
GO

USE [RPSLS]
GO

/****** Object:  Table [dbo].[LogInEntry]    Script Date: 03/05/2014 19:23:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LogInEntry](
	[Username] [nvarchar](50) NOT NULL,
	[DOB] [char](10) NULL,
	[Wins] [int] NOT NULL,
	[Losses] [int] NOT NULL,
	[Ties] [int] NOT NULL,
	[TempID] [int] IDENTITY(1,1) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LogInEntry] ADD  CONSTRAINT [DF_LogInEntry_Wins]  DEFAULT ((0)) FOR [Wins]
GO

ALTER TABLE [dbo].[LogInEntry] ADD  CONSTRAINT [DF_LogInEntry_Losses]  DEFAULT ((0)) FOR [Losses]
GO

ALTER TABLE [dbo].[LogInEntry] ADD  CONSTRAINT [DF_LogInEntry_Ties]  DEFAULT ((0)) FOR [Ties]
GO

