-- Copyright (c) Microsoft Corporation.  All rights reserved.
USE DefaultSampleStore
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'System.ServiceModel.Persistence')
	EXEC ('CREATE SCHEMA [System.ServiceModel.Persistence]')
GO

IF NOT EXISTS( SELECT 1 FROM [dbo].[sysusers] WHERE name=N'System.ServiceModel.Persistence.PersistenceUsers' and issqlrole=1 )
 BEGIN

	exec sp_addrole N'System.ServiceModel.Persistence.PersistenceUsers'

END
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[Instances]') AND type in (N'U'))
	DROP TABLE [System.ServiceModel.Persistence].[Instances]
GO

 CREATE TABLE [System.ServiceModel.Persistence].[Instances](
	[Id] [uniqueidentifier] NOT NULL,
	[InstanceType] [uniqueidentifier] NULL,
	[Data] varbinary(max) NULL,
	[XmlData] [xml] NULL,
	[Status] tinyint NOT NULL,
	[BlockingBookmarks] nvarchar(max) NULL,
	[StatusReason] nvarchar(max) NULL,
	[MachineName] nvarchar(max) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[ModificationTime] [datetime] NOT NULL,
	[LockOwner] [uniqueidentifier] NULL
) 
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[Keys]') AND type in (N'U'))
	DROP TABLE [System.ServiceModel.Persistence].[Keys]
GO


CREATE TABLE [System.ServiceModel.Persistence].[Keys](
	[Id] [uniqueidentifier] NOT NULL,	
	[InstanceId] [uniqueidentifier] NULL,	
	[ScopeName] nvarchar(256) NULL,
	[KeyData] nvarchar(max) NULL
) 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[LeaseHolders]') AND type in (N'U'))
	DROP TABLE [System.ServiceModel.Persistence].[LeaseHolders]
GO

CREATE TABLE [System.ServiceModel.Persistence].[LeaseHolders]
(
  [Id] [uniqueidentifier] not null,
  [LeaseExpiration] [datetime] not null,    
  [LeaseHolderInfo] varbinary(max)  null
)
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[DBVersion]') AND type in (N'U'))
	DROP TABLE [System.ServiceModel.Persistence].[DBVersion]
GO

CREATE TABLE [System.ServiceModel.Persistence].[DBVersion]
(
	[Version] nvarchar(max)
)
GO
insert into [System.ServiceModel.Persistence].[DBVersion] values(N'4.0')

GO


CREATE UNIQUE CLUSTERED INDEX CIX_LeaseHolderId
	ON [System.ServiceModel.Persistence].[LeaseHolders] ([Id])
	WITH IGNORE_DUP_KEY
GO


CREATE UNIQUE CLUSTERED INDEX CIX_InstanceID
	ON [System.ServiceModel.Persistence].[Instances] ([Id])
	WITH IGNORE_DUP_KEY
GO

CREATE NONCLUSTERED INDEX NCIX_InstanceType
	ON [System.ServiceModel.Persistence].[Instances] ([InstanceType])
GO

CREATE UNIQUE CLUSTERED INDEX CIX_KeyId
	ON [System.ServiceModel.Persistence].[Keys] ([Id] )	
	WITH IGNORE_DUP_KEY
GO

CREATE NONCLUSTERED INDEX NCIX_KeyInstanceId
	ON [System.ServiceModel.Persistence].[Keys] ([InstanceId])	
GO


