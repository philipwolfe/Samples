USE master
GO
CREATE DATABASE Guest
ON 
( NAME = prods_dat,
   FILENAME = 'c:\program files\microsoft sql server\mssql\data\Guest.mdf',
   SIZE = 4,
   MAXSIZE = 10,
   FILEGROWTH = 1 )
GO

