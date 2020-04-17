-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'LoanApprovalProcess')
	DROP DATABASE LoanApprovalProcess
GO
CREATE DATABASE LoanApprovalProcess
GO

