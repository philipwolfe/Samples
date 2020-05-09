-- EXTENDED STORED PROCEDURE USED TO SEND HTTP REQUESTS
...
sp_addextendedproc 'xp_ReadURL', 'C:\Demo\Caching\SQLonChange\T-SQLScript\xp_postnotify.dll'
...

Change the path to reflect the path to the xp_postnotify.dll

Run build.bat in ...\SQLOnChange\T-SQLScript\ this will create the necessary tables, stored procedures, and create the extended stored procedure.

Open AddItemsToCache.aspx in ...\SQLOnChange\ modify member variables of Page_Load():

string DSN = "server=localhost;uid=sa;pwd=;database=pubs";
string AppPath = "http://localhost/demo/Caching/SQLonChange/";
string CacheKey = "Authors-Table";
string TableToMonitor = "authors";

AppPath is the application path that the ASP.NET application on which SQL Change notification events are raised to.
CacheKey is the key name to invalidate in the ASP.NET application's cache
TableToMonitor is the SQL table a trigger is added to that can notify the ASP.NET application to flush the cache

The application is configured to monitor to the pubs database's authors table.

To Use:
1. Open a browser and navigate to http://localhost/SQLOnChange/AddItemsToCahce.aspx
2. On first request you should see: Cache invalid, getting DataSet from SQL. Created SQL entry: (True) 
3. On subseqent requests you should see: Getting DataSet from Cache... 
4. To invalidate the cache either:

Change a row in the SQL database pubs authors table, e.g. O'Leary -> O'Leari
...or Request http://localhost/SQLOnChange/CacheChangeNotification.axd?CacheKey=Authors-Table

5. When a change is made to the SQL table (or if the handler is called directly) the application's cache is flushed
6. We are now back at step 2. 

Extensibility:
The invalidation is done by SQL Server using an extended stored procedure to call an ASP.NET Http Handler: The CacheChangeNotification.axd. Other applications can be designed to call this handler as well.