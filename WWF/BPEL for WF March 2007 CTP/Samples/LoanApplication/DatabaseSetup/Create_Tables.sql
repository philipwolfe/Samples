
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreditDetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CreditDetail]
GO
CREATE TABLE [dbo].[CreditDetail]
(
	[SSN] [nvarchar](50) NOT NULL,
	[RiskProfile] [nvarchar](50) NOT NULL,
	[CreditStatus] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_CreditDetail] PRIMARY KEY CLUSTERED 
	(
		[SSN] ASC
	)
)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoanRequest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LoanRequest]
GO
CREATE TABLE [dbo].[LoanRequest]
(
	[RequestId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_LoanRequest] PRIMARY KEY CLUSTERED 
	(
		[RequestId] ASC
	)
)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreditReport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CreditReport]
GO
CREATE TABLE [dbo].[CreditReport]
(
	[CreditReportId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [uniqueidentifier] NOT NULL,
	[CreditRating] [nvarchar](50) NOT NULL
)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoanQuote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LoanQuote]
GO
CREATE TABLE [dbo].[LoanQuote]
(
	[LoanQuoteId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [uniqueidentifier] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[TimePeriod] [int] NOT NULL,
	[AmountSanctioned] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	CONSTRAINT [PK_LoanQuote] PRIMARY KEY CLUSTERED 
	(
		[LoanQuoteId] ASC
	)
)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetCreditReportDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetCreditReportDetails]
GO
CREATE PROCEDURE [dbo].[usp_GetCreditReportDetails]
	@RequestId		 AS UNIQUEIDENTIFIER,
	@CreditReportId	 AS INT
AS
BEGIN

	SELECT 
		CR.CreditRating, 
		LR.Amount
	FROM [dbo].[LoanRequest] AS LR
	INNER JOIN [dbo].[CreditReport] AS CR 
		ON LR.RequestId = @RequestId AND CR.CreditReportId = @CreditReportId		
	
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error getting credit detail of user',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GenerateCreditReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GenerateCreditReport]
GO
CREATE PROCEDURE [usp_GenerateCreditReport]
	@RequestId		AS UNIQUEIDENTIFIER,
	@CreditRating	AS NVARCHAR(50)
AS
BEGIN
	
	INSERT INTO
		CreditReport (RequestId,CreditRating) 
	VALUES 
		(@RequestId,@CreditRating)

	SELECT SCOPE_IDENTITY() as CreditReportId
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error generating credit report',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_InsertLoanQuote]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_InsertLoanQuote]
GO
CREATE PROCEDURE [usp_InsertLoanQuote]
	@RequestId		  AS UNIQUEIDENTIFIER,
	@InterestRate	  AS FLOAT,
	@TimePeriod		  AS INT,
	@AmountSanctioned AS INT,
	@StartDate		  AS DATETIME	
AS
BEGIN

	INSERT INTO
		dbo.[LoanQuote]
		(RequestId,InterestRate, TimePeriod, AmountSanctioned,StartDate)	    
	VALUES 
		(@RequestId,@InterestRate, @TimePeriod, @AmountSanctioned,@StartDate)	
	
	
	-- Get the newly added loan quote id
	SELECT SCOPE_IDENTITY() as LoanQuoteId
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error inserting loan quote',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetLoanQuotes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetLoanQuotes]
GO
CREATE PROCEDURE [usp_GetLoanQuotes]
	@RequestId		AS UNIQUEIDENTIFIER
AS
BEGIN

	SELECT 
		InterestRate 
		,TimePeriod
		,AmountSanctioned
		,StartDate 
	FROM  dbo.LoanQuote
	WHERE
		RequestId = @RequestId
		
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error getting loan quotes',16,1)
			RETURN -1
		END	

END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetUserCreditDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetUserCreditDetails]
GO
CREATE PROCEDURE [usp_GetUserCreditDetails]
	@RequestId		AS UNIQUEIDENTIFIER
AS
BEGIN

	SELECT CD.CreditStatus, CD.RiskProfile, LR.Amount
	FROM  LoanRequest as LR
	INNER JOIN dbo.CreditDetail as CD ON LR.SSN = CD.SSN AND LR.RequestId = @RequestId
		
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error getting credit detail of user',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_UpdateLoanRequestStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_UpdateLoanRequestStatus]
GO
CREATE PROCEDURE [usp_UpdateLoanRequestStatus]
 	@RequestId		AS UNIQUEIDENTIFIER,
	@Status		    AS nvarchar(50)
AS
BEGIN
	
	UPDATE [LoanRequest]
		SET Status = @Status
		WHERE RequestId = @RequestId
			
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error updating loan details',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_InsertLoanRequestDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_InsertLoanRequestDetails]
GO
CREATE PROCEDURE [usp_InsertLoanRequestDetails]
	@RequestId		AS UNIQUEIDENTIFIER,
	@UserName		AS nvarchar(50),
	@Address		AS nvarchar(200),
	@SSN		    AS nvarchar(50),
	@Amount		    AS int,
	@Status		    AS nvarchar(50)
	
AS
BEGIN

	INSERT INTO
		[LoanRequest]
		(RequestId,UserName, Address, SSN ,Amount,Status)	    
	VALUES 
		(@RequestId,@UserName, @Address, @SSN ,@Amount,@Status)	
	
	IF @@ERROR<>0
		BEGIN
			RAISERROR ('Error inserting loan request',16,1)
			RETURN -1
		END	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetLoanRequestStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetLoanRequestStatus]
GO
CREATE PROCEDURE [usp_GetLoanRequestStatus]
	@RequestId		AS UNIQUEIDENTIFIER
AS
BEGIN

	SELECT 
		Status AS Status
	FROM  dbo.LoanRequest
	WHERE
		RequestId = @RequestId
		
	
	IF @@ERROR<>0	
		BEGIN
			RAISERROR ('Error getting loan status',16,1)
			RETURN -1
		END	
END
GO

INSERT INTO CreditDetail (SSN,RiskProfile,CreditStatus) VALUES ('111-11-1111','LOW','VALID')
GO
INSERT INTO CreditDetail (SSN,RiskProfile,CreditStatus) VALUES ('222-22-2222','LOW','VALID')
GO
INSERT INTO CreditDetail (SSN,RiskProfile,CreditStatus) VALUES ('333-33-3333','LOW','INVALID')
GO
INSERT INTO CreditDetail (SSN,RiskProfile,CreditStatus) VALUES ('444-44-4444','HIGH','VALID')
GO
INSERT INTO CreditDetail (SSN,RiskProfile,CreditStatus) VALUES ('555-55-5555','HIGH','INVALID')
GO
