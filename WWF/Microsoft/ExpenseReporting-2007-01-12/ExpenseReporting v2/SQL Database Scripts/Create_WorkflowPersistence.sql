-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'WorkflowPersistence')
	DROP DATABASE WorkflowPersistence
GO
CREATE DATABASE WorkflowPersistence 
GO

