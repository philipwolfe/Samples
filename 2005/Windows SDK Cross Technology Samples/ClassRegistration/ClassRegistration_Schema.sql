if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Class]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Class]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClassSession]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ClassSession]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Registration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Registration]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Student]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Student]
GO

CREATE TABLE [dbo].[Class] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[CoursePrefix] [nvarchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CourseNumber] [int] NOT NULL ,
	[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClassSession] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassId] [int] NOT NULL ,
	[SessionId] [int] NOT NULL ,
	[StartDate] [datetime] NOT NULL ,
	[Length] [int] NOT NULL ,
	[SeatCount] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Registration] (
	[StudentId] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SessionId] [int] NOT NULL ,
	[Status] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Student] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[UserId] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Status] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

