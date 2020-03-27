// MailServiceDB.h : Defines the database classes for the mail service
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
[
	db_command("SELECT [Password], [Salt], [FirstName], [LastName], [UserID] FROM UserInfoTable WHERE [Login]=? AND [Confirmed]=Yes")
]
class CLoginUser
{
public:
	[ db_column(1) ] TCHAR m_szPassword[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szSalt[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_column(5) ] LONG m_lUserID;
	[ db_param(1) ]  TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=0 AND [UserID]=? AND [MarkedRead]=No")
]
class CUnreadCount
{
	public:
	[ db_column(1) ] LONG m_lUnreadCount;
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=0 AND [UserID]=?")
]
class CMessageCount
{
	public:
	[ db_column(1) ] LONG m_lMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("SELECT [From], [Date], [Subject], [MessageID], [MarkedRead] FROM [MailBoxTable] WHERE [Box]=0 AND [UserID]=? ORDER BY [Date] DESC")
]
class CMessages
{
public:
	[ db_column(1) ] WCHAR m_wszFrom[DB_MAX_STRLEN + 1];
	[ db_column(2) ] DATE m_DateSent;
	[ db_column(3) ] WCHAR m_wszSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] LONG m_lMessageID;
	[ db_column(5) ] BOOL m_bMarkedRead;
	[ db_param(1) ]  LONG m_lUserID;
};