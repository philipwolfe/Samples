-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'TrackingStore')
	DROP DATABASE TrackingStore
GO
CREATE DATABASE TrackingStore
GO

