if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WebNotes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[WebNotes]
GO

CREATE TABLE [dbo].[WebNotes] (
	[Url] [nvarchar] (120) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Note] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

