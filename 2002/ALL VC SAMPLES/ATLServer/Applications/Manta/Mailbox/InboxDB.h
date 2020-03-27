// InboxDB.h : Defines the database classes for the Inbox
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
	db_command("SELECT [From], [Date], [Subject], [MessageID], [MarkedRead] FROM MailBoxTable WHERE [Box]=0 AND [UserID]=? ORDER BY Date DESC")
]
class CInboxInfo
{
public:
	[ db_column(1) ] TCHAR m_szFrom[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] LONG m_lMessageID;
	[ db_column(5) ] BOOL m_bMarkedRead;
	[ db_param(1) ]  LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=0 AND [UserID]=? AND MarkedRead=No")
]
class CUnreadMessageCount
{
	public:
	[ db_column(1) ] LONG m_lNewMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=0 AND [UserID]=?")
]
class CInboxMessageCount
{
	public:
	[ db_column(1) ] LONG m_lMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("SELECT [PopServer], [PopServerPort], [PopUserName], [PopPassword] FROM UserInfoTable WHERE [UserID]=?")
]
class CPOPInfo
{
public:
	[ db_column(1) ] TCHAR m_szPopServer[DB_MAX_STRLEN + 1];
	[ db_column(2) ] LONG m_lPopPort;
	[ db_column(3) ] TCHAR m_szPopUserName[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szPopPassword[DB_MAX_STRLEN + 1];
	[ db_param(1) ] LONG m_lUserID;
};
