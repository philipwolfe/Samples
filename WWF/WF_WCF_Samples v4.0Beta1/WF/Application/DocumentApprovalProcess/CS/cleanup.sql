Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'DocApprovalSampleUsers')
	DROP DATABASE DocApprovalSampleUsers
GO
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'SampleInstanceStore')
	DROP DATABASE SampleInstanceStore
GO
