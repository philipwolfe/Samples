Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'WorkflowStore')
	DROP DATABASE WorkflowStore
GO
CREATE DATABASE WorkflowStore
GO


Use WorkflowStore
Go
