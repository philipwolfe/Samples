if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_ConfirmUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_ConfirmUser]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_CreateUnconfirmedUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_CreateUnconfirmedUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sproc_GetUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_GetUser]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_FindUnconfirmedUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_FindUnconfirmedUser]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GUID]  uniqueidentifier ROWGUIDCOL  NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[Email] [varchar] (128) NOT NULL ,
	[Password] [varbinary] (50) NOT NULL ,
	[Created] [datetime] NOT NULL ,
	[Modified] [datetime] NOT NULL ,
	[Confirmed] [bit] NOT NULL ,
	[Salt] [binary] (4) NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User] WITH NOCHECK ADD 
	CONSTRAINT [DF_User_GUID] DEFAULT (newid()) FOR [GUID],
	CONSTRAINT [DF_User_Created] DEFAULT (getdate()) FOR [Created],
	CONSTRAINT [DF_User_Modified] DEFAULT (getdate()) FOR [Modified],
	CONSTRAINT [DF_User_Confirmed] DEFAULT (0) FOR [Confirmed],
	CONSTRAINT [CS_UniqueName] UNIQUE  NONCLUSTERED 
	(
		[Name]
	)  ON [PRIMARY] 
GO

SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

CREATE procedure sproc_ConfirmUser
	@theName As varchar(50),
	@thePassword As varbinary(50),
	@theGUID As uniqueidentifier,
	@theID As int OUTPUT
as
	update 	dbo.[User]
	set
	dbo.[User].Confirmed = 1,
	@theID = dbo.[User].ID
	where 
		dbo.[User].Name = @theName
	and	dbo.[User].Password = @thePassword
	and	dbo.[User].GUID = @theGUID
	and	dbo.[User].Confirmed <> 1
GO

CREATE procedure sproc_CreateUnconfirmedUser
	@theName As varchar(50),
	@thePassword As varbinary(50),
	@theSalt As binary(4),
	@theEmail As varchar(128),
	@theGuid As uniqueidentifier OUTPUT
as
	declare @theID int
	set @theID = 0

	select @theID = dbo.[User].ID from dbo.[User] where dbo.[User].Name = @theName
	if (@theID = 0)
	begin
		insert into dbo.[User]
		(
			Name,
			Email,
			Password,
			Salt
		)
		values
		(
			@theName,
			@theEmail,
			@thePassword,
			@theSalt
		)

		select @theGuid = dbo.[User].GUID from dbo.[User] where dbo.[User].ID = @@identity
	end
GO

CREATE procedure sproc_GetUser
	@theName As varchar(50)
as
	SELECT dbo.[User].[ID], dbo.[User].[Password], dbo.[User].[Salt]
	FROM  dbo.[User]
	WHERE
		dbo.[User].Name = @theName
GO


CREATE PROCEDURE sproc_FindUnconfirmedUser AS
SELECT
	*,
	DateDiff(day, Created, GetDate()) - 7 AS DaysOverdue
FROM
	dbo.[User]
WHERE
	DateDiff(day, Created, GetDate())  > 7
	AND
	Confirmed = 0

GO

