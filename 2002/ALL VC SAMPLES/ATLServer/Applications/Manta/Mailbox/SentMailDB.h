// SentMailDB.h : Defines the database classes for the sent mail page
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
	db_command("SELECT [To], [Subject], [Date], [MessageID] FROM [MailBoxTable] WHERE [Box]=3 AND [UserID]=? ORDER BY Date DESC")
]
class CSentMailInfo
{
public:
	[ db_column(1) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(4) ] LONG m_lMessageID;
	[ db_param(1) ]  LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=3 AND [UserID]=?")
]
class CSentMailMessageCount
{
	public:
	[ db_column(1) ] LONG m_lMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};