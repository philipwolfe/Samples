-- Copyright (c) Microsoft Corporation.  All rights reserved.
USE DefaultSampleStore
GO

SET QUOTED_IDENTIFIER ON
GO
SET NOCOUNT ON
GO
--TODO, 28699: Durable Timer Support: Security Model
--
-- ROLE DurableTimerUsers
--
-- declare @localized_string_AddRole_Failed nvarchar(256)
-- set @localized_string_AddRole_Failed = N'Failed adding the ''DurableTimerUsers'' role'

-- DECLARE @ret int, @Error int
-- IF NOT EXISTS( SELECT 1 FROM [dbo].[sysusers] WHERE name=N'DurableTimerUsers' and issqlrole=1 )
-- BEGIN

--	EXEC @ret = sp_addrole N'DurableTimerUsers'

--	SELECT @Error = @@ERROR

--	IF @ret <> 0 or @Error <> 0
--		RAISERROR( @localized_string_AddRole_Failed, 16, -1 )
-- END
-- GO

-- TODO, 30043, Durable Timer Support : Code Review Comments - Todo  after M2C
-- TABLE DurableTimerInfo
--
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DurableTimerInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DurableTimerInfo]
GO
CREATE TABLE [dbo].[DurableTimerInfo] (
	[uidTimerID] [uniqueidentifier] DEFAULT NewSequentialID() NOT NULL,
	[vbCallbackAddress] [varbinary] (1024) NOT NULL,
	[dtExpirationTime] [datetime] NOT NULL ,
	[iNumOfAttempts] [int] NOT NULL 
) ON [PRIMARY] 
GO
CREATE  UNIQUE CLUSTERED  INDEX [CIX_DurableTimerInfo] ON [dbo].[DurableTimerInfo]([uidTimerID]) WITH IGNORE_DUP_KEY ON [PRIMARY] 
GO
CREATE  NONCLUSTERED  INDEX [IX_DurableTimerInfo_dtExpirationTime] ON [dbo].[DurableTimerInfo]([dtExpirationTime]) ON [PRIMARY]
GO