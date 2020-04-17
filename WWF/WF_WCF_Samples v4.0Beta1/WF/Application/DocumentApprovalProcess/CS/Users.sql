Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'DocApprovalSampleUsers')
	DROP DATABASE DocApprovalSampleUsers
GO
CREATE DATABASE DocApprovalSampleUsers
GO
USE DocApprovalSampleUsers
GO

 
CREATE TABLE [dbo].[users]
(
	[username]	varchar(255) NOT NULL,
	[usertype]	varchar(255) NOT NULL,
	[addressrequest]	varchar(255) NOT NULL,
	[guid]		varchar(255) NOT NULL,
	[addressresponse] varchar(255) NOT NULL,
)
GO
