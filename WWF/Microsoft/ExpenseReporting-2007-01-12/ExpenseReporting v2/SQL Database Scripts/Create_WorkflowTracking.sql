-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'WorkflowTracking')
	DROP DATABASE WorkflowTracking
GO
CREATE DATABASE WorkflowTracking
GO

