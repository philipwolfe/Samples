select master.dbo.fn_postnotify ( b.callback_url, b.cachekey ) from AspNetSqlChangeNotification b where trigger_table = 'authors'
select * from master.dbo.AspNetSqlChangeNotification

declare @ret varchar(1000)
exec master.dbo.xp_ReadURL 'http://localhost/code/Caching/SQLDependency/NotificationHandler.axd?CacheKey=Authors-Table', @ret output
