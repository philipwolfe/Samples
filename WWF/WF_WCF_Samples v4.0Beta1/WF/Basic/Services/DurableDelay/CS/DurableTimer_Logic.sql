-- Copyright (c) Microsoft Corporation.  All rights reserved.
USE DefaultSampleStore
GO

SET QUOTED_IDENTIFIER ON
GO

SET NOCOUNT ON
GO

--
-- PROCEDURE DeleteTimer
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DeleteTimer]') AND (OBJECTPROPERTY(id, N'IsProcedure') = 1))
	DROP PROCEDURE [dbo].[DeleteTimer]
GO
CREATE PROCEDURE [dbo].[DeleteTimer]
	@uidTimerID uniqueIdentifier,
	@result int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;

	DELETE FROM [dbo].[DurableTimerInfo]
	FROM [dbo].[DurableTimerInfo] WITH (ROWLOCK)
		WHERE (uidTimerID = @uidTimerID);

	IF @@rowcount > 0
		SET @result = 0; -- Success
	ELSE
		SET @result = 2; -- Could not delete (didn't exist or could not acquire lock)
END
GO

--
-- PROCEDURE InsertTimer
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[InsertTimer]') AND (OBJECTPROPERTY(id, N'IsProcedure') = 1))
	DROP PROCEDURE [dbo].[InsertTimer]
GO
CREATE PROCEDURE [dbo].[InsertTimer]
	@vbCallbackAddress varbinary (1024),
	@dtExpirationTime datetime,
	@result int OUTPUT,
	@uidTimerID uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;
	DECLARE @rows_affected int;
	DECLARE @MyTableVar table(uidTimerID uniqueidentifier NOT NULL)

	SET @result = 0;
	
	INSERT INTO [dbo].[DurableTimerInfo] (vbCallbackAddress, dtExpirationTime, iNumOfAttempts)	
	OUTPUT INSERTED.uidTimerID INTO @MyTableVar
	VALUES (@vbCallbackAddress, @dtExpirationTime, 0)
	
	SET @rows_affected = @@ROWCOUNT;
	
	IF @rows_affected = 0
		SET @result = 1;
	ELSE
		SELECT @uidTimerID = uidTimerID from @MyTableVar;	
	
	
END
GO
--TODO, 28699: Durable Timer Support: Security Model
--GRANT EXECUTE ON [dbo].[InsertTimer] TO DurableTimerUsers
--GO

--
-- PROCEDURE GetExpiredTimerIds
--
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = OBJECT_ID(N'[dbo].[GetExpiredTimerIds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GetExpiredTimerIds]
GO
CREATE PROCEDURE [dbo].[GetExpiredTimerIds]
@now datetime,
@timerCount int
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;
	SET deadlock_priority LOW;
	
	SELECT TOP (@timerCount) vbCallbackAddress, uidTimerID, dtExpirationTime, iNumOfAttempts
	FROM [dbo].[DurableTimerInfo] WITH (ROWLOCK, READPAST)
    WHERE (dtExpirationTime<=@now)
    ORDER BY dtExpirationTime ASC;

 END
GO
--TODO, 28699: Durable Timer Support: Security Model
--GRANT EXECUTE ON [dbo].[GetExpiredTimerIds] TO DurableTimerUsers
--GO


--
-- PROCEDURE DeleteExpiredTimers
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DeleteExpiredTimers]') AND (OBJECTPROPERTY(id, N'IsProcedure') = 1))
	DROP PROCEDURE [dbo].[DeleteExpiredTimers]
GO
CREATE PROCEDURE [dbo].[DeleteExpiredTimers]
	@maximumAttempts int,
	@result int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;

	DELETE FROM [dbo].[DurableTimerInfo] WITH (ROWLOCK)	
	WHERE (iNumOfAttempts >= @maximumAttempts);

	SET @result = @@rowcount 
END
GO
--TODO, 28699: Durable Timer Support: Security Model
--GRANT EXECUTE ON [dbo].[DeleteExpiredTimers] TO DurableTimerUsers
--GO


--
-- PROCEDURE UpdateTimer
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UpdateTimer]') AND (OBJECTPROPERTY(id, N'IsProcedure') = 1))
	DROP PROCEDURE [dbo].[UpdateTimer]
GO
CREATE PROCEDURE [dbo].[UpdateTimer]
	@uidTimerID uniqueidentifier,
	@dtExpirationTime datetime,
	@iNumOfAttempts int
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;

	UPDATE [dbo].[DurableTimerInfo]WITH (ROWLOCK)
	SET dtExpirationTime = @dtExpirationTime,
		iNumOfAttempts = @iNumOfAttempts
	WHERE uidTimerID = @uidTimerID
END
GO
--TODO, 28699: Durable Timer Support: Security Model
--GRANT EXECUTE ON [dbo].[DeleteExpiredTimers] TO DurableTimerUsers
--GO

--
-- FUNCTION ParseTimerIds
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ParseTimerIds]') AND (OBJECTPROPERTY(id, N'IsTableFunction') = 1))
	DROP FUNCTION [dbo].[ParseTimerIds]
GO
CREATE FUNCTION ParseTimerIds
(
@TimerIdsCSV varchar(8000)
)
RETURNS
@TimerIds table
(
TimerId uniqueidentifier
)
AS
BEGIN

DECLARE @TimerId varchar(36), @Pos int

SET @TimerIdsCSV = LTRIM(RTRIM(@TimerIdsCSV))
SET @Pos = CHARINDEX(',', @TimerIdsCSV, 1)

IF REPLACE(@TimerIdsCSV, ',', '') <> ''
BEGIN
	WHILE @Pos > 0
	BEGIN
		SET @TimerId = LTRIM(RTRIM(LEFT(@TimerIdsCSV, @Pos - 1)))
		IF @TimerId <> ''
		BEGIN
			INSERT INTO @TimerIds (TimerId)
			ValueS (CAST(@TimerId AS uniqueidentifier)) 
		END
		SET @TimerIdsCSV = RIGHT(@TimerIdsCSV, LEN(@TimerIdsCSV) - @Pos)
		SET @Pos = CHARINDEX(',', @TimerIdsCSV, 1)
	END
END
RETURN
END
GO
--TODO, 28699: Durable Timer Support: Security Model
--GRANT EXECUTE ON [dbo].[ParseTimerIds] TO DurableTimerUsers
--GO

--
-- PROCEDURE DeleteTimers
--
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DeleteTimers]') AND (OBJECTPROPERTY(id, N'IsProcedure') = 1))
	DROP PROCEDURE [dbo].[DeleteTimers]
GO
CREATE PROCEDURE [dbo].[DeleteTimers]
	@varTimerIDList varchar(8000),
	@result int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
	SET XACT_ABORT ON;
	
	DELETE FROM [dbo].[DurableTimerInfo]
	FROM [dbo].[DurableTimerInfo] WITH (ROWLOCK)
	WHERE uidTimerID IN (SELECT TimerId FROM ParseTimerIds(@varTimerIDList))			

	SET @result = @@rowcount;

END
GO