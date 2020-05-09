-- *****************************************
-- SYSTEM CODE TO MANAGE NOTIFICATIONS
-- *****************************************
-- All goes in master db
use master
go


-- Drop the table if it exists
drop table AspNetSqlChangeNotification
go

-- EXTENDED STORED PROCEDURE USED TO SEND HTTP REQUESTS
sp_dropextendedproc 'xp_ReadURL'
go

-- FUNCTION POST NOTIFY
drop function fn_postnotify
go

-- SUPPORT FUNCTION TO SEND NOTIFICATIONS
-- This is the procedure that needs to be called by the user who wants to receive notifications
drop procedure sp_register_notify
go

-- PROCEDURE SP_POSTS CALLED BY THE USER TRIGGERS
drop procedure sp_posts
go