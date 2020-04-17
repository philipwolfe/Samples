IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Bank')
	DROP DATABASE [Bank]
GO



CREATE DATABASE Bank

GO

USE  Bank

/****** Object:  Table [dbo].[ChequeAccount]    Script Date: 5/27/2005 4:33:11 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ChequeAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ChequeAccount]
GO

/****** Object:  Table [dbo].[SavingsAccount]    Script Date: 5/27/2005 4:33:11 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SavingsAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SavingsAccount]
GO

/****** Object:  Table [dbo].[ChequeAccount]    Script Date: 5/27/2005 4:33:12 PM ******/

CREATE TABLE [dbo].[ChequeAccount] (
	[ChequeAccountId] [int] IDENTITY (1, 1) NOT NULL ,
	[Balance] [money] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SavingsAccount]    Script Date: 5/27/2005 4:33:12 PM ******/
CREATE TABLE [dbo].[SavingsAccount] (
	[SavingsAccountId] [int] IDENTITY (1, 1) NOT NULL ,
	[Balance] [money] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ChequeAccount] ADD 
	CONSTRAINT [DF_ChequeAccount_Balance] DEFAULT (0) FOR [Balance]
GO

ALTER TABLE [dbo].[SavingsAccount] ADD 
	CONSTRAINT [DF_SavingsAccount_Balance] DEFAULT (0) FOR [Balance]
GO

INSERT INTO [dbo].[SavingsAccount] values(100)

GO

INSERT INTO [dbo].[ChequeAccount] values(100)

