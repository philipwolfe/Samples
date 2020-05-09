-- *****************************************
-- SYSTEM CODE TO MANAGE NOTIFICATIONS
-- *****************************************
-- All goes in master db
use master
go


-- Drop the table if it exists
drop table AspNetSqlChangeNotification
go

-- Create the notification table
create table AspNetSqlChangeNotification ( 
              trigger_table varchar(100), 
              callback_url varchar(100), 
              cachekey varchar(100),
              unique(callback_url, cachekey) 
)
go

create clustered index notification_table on AspNetSqlChangeNotification(trigger_table)
go

-- EXTENDED STORED PROCEDURE USED TO SEND HTTP REQUESTS
sp_dropextendedproc 'xp_ReadURL'
go

sp_addextendedproc 'xp_ReadURL', 'C:\Inetpub\code\Caching\SQLDependency\src\T-SQLScript\xp_postnotify.dll'
go

-- FUNCTION POST NOTIFY
drop function fn_postnotify
go

create function fn_postnotify (@callback_url varchar(1000), @cachekey varchar(1000)) returns varchar(1000)
as
begin
declare @ret varchar(1000)
set @callback_url = @callback_url + '?' + 'CacheKey=' + @cachekey
exec master.dbo.xp_ReadURL @callback_url, @ret output
return @ret
end
go


-- SUPPORT FUNCTION TO SEND NOTIFICATIONS
-- This is the procedure that needs to be called by the user who wants to receive notifications
drop procedure sp_register_notify
go
create procedure sp_register_notify @trigger_table varchar(100), @callback_url varchar(100), @cachekey varchar(100)
as
begin
	if not exists (select callback_url from AspNetSqlChangeNotification where callback_url = @callback_url and cachekey = @cachekey)
		insert into AspNetSqlChangeNotification values (@trigger_table, @callback_url, @cachekey )
	return
end
go


-- PROCEDURE SP_POSTS CALLED BY THE USER TRIGGERS
drop procedure sp_posts
go

create procedure sp_posts @tname varchar(1000)
as
begin
	declare @callback_url varchar(1000)
	declare @res varchar(1000)
	select @res = master.dbo.fn_postnotify ( b.callback_url, b.cachekey ) from AspNetSqlChangeNotification b where trigger_table = @tname
	delete from AspNetSqlChangeNotification where trigger_table = @tname
	return 0
end
go
