if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_DeleteImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_DeleteImage]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_DeleteImagesByOwner]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_DeleteImagesByOwner]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_GetImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_GetImage]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_GetImagesByOwner]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_GetImagesByOwner]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[sproc_InsertImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sproc_InsertImage]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[Format]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Format]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[Image]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Image]
GO

CREATE TABLE [dbo].[Format] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) NOT NULL ,
	[MimeType] [varchar] (50) NOT NULL 
) ON [PRIMARY]
GO

INSERT INTO dbo.Format (Name, MimeType) VALUES (N'Bitmap', 'image/bmp')
INSERT INTO dbo.Format (Name, MimeType) VALUES (N'Portable Network Graphics', 'image/png')
INSERT INTO dbo.Format (Name, MimeType) VALUES (N'Graphics Interchange Format', 'image/gif')
INSERT INTO dbo.Format (Name, MimeType) VALUES (N'JPEG', 'image/jpg')
GO

CREATE TABLE [dbo].[Image] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Data] [image] NOT NULL ,
	[Width] [int] NOT NULL ,
	[Height] [int] NOT NULL ,
	[BitsPerPixel] [int] NOT NULL ,
	[Format] [int] NOT NULL ,
	[Created] [datetime] NOT NULL ,
	[Modified] [datetime] NOT NULL ,
	[Owner] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Image] WITH NOCHECK ADD 
	CONSTRAINT [DF_Image_Created] DEFAULT (getdate()) FOR [Created],
	CONSTRAINT [DF_Image_Modified] DEFAULT (getdate()) FOR [Modified],
	CONSTRAINT [PK_Image] PRIMARY KEY  NONCLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

CREATE PROCEDURE sproc_DeleteImage
	@theID int
AS

DELETE FROM
	[dbo].[Image]

WHERE
	[dbo].[Image].[ID] = @theID
GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

CREATE PROCEDURE sproc_DeleteImagesByOwner
	@theOwnerID int
AS

DELETE FROM
	[dbo].[Image]

WHERE
	[dbo].[Image].[Owner] = @theOwnerID

GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

CREATE PROCEDURE sproc_GetImage
	@theID int
AS
SELECT
	[dbo].[Image].[ID], 
	[dbo].[Image].[Data],
	DATALENGTH([dbo].[Image].[Data]) AS Bytes,
	[dbo].[Image].[Width],
	[dbo].[Image].[Height],
	[dbo].[Image].[BitsPerPixel],
	[dbo].[Format].[MimeType],
	[dbo].[Image].[Created],
	[dbo].[Image].[Modified],
	[dbo].[Image].[Owner]

FROM [dbo].[Image], [dbo].[Format]

WHERE 
	[dbo].[Image].[ID] = @theID
AND	[dbo].[Format].[ID] = [dbo].[Image].[Format]

GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

CREATE PROCEDURE sproc_GetImagesByOwner
	@theOwner int
AS
SELECT
	[dbo].[Image].[ID], 
	[dbo].[Image].[Data],
	DATALENGTH([dbo].[Image].[Data]) AS Bytes,
	[dbo].[Image].[Width],
	[dbo].[Image].[Height],
	[dbo].[Image].[BitsPerPixel],
	[dbo].[Format].[MimeType],
	[dbo].[Image].[Created],
	[dbo].[Image].[Modified],
	[dbo].[Image].[Owner]

FROM [dbo].[Image], [dbo].[Format]

WHERE 
	[dbo].[Image].[Owner] = @theOwner
AND	[dbo].[Format].[ID] = [dbo].[Image].[Format]
GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

SET QUOTED_IDENTIFIER  ON    SET ANSI_NULLS  ON 
GO

CREATE PROCEDURE sproc_InsertImage
	@theData image,
	@theBytes int, /* unused */
	@theWidth int,
	@theHeight int,
	@theBitsPerPixel int,
	@theFormat int,
	@theOwner int,
	@theID int OUTPUT
AS
INSERT INTO [dbo].[Image]
(
	Data,
	Width,
	Height,
	BitsPerPixel,
	Format,
	Owner
)
VALUES
(
	@theData,
	@theWidth,
	@theHeight,
	@theBitsPerPixel,
	@theFormat,
	@theOwner
)

set @theID = @@identity

GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

