USE master

/* If a database already exists, remove it */
IF EXISTS (SELECT * FROM sysdatabases WHERE name='TXDemoDB')

BEGIN
  raiserror('Dropping existing TXDemoDB database ....',0,1)
  DROP database TXDemoDB
END
GO

/* Create the database */
CREATE DATABASE TXDemoDB
GO

/* Select the just created database */
use TXDemoDB
GO

/* Create the table */
CREATE TABLE currentValue (
	currentValue int NOT NULL 
)
GO

/* insert the default value 10 into the table */
INSERT INTO currentValue(currentValue) VALUES(10)
GO