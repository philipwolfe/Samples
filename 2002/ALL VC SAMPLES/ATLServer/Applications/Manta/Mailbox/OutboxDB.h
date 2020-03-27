// OutboxDB.h : Defines the database classes for the Outbox
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
	db_command("SELECT [To], [Date], [Subject], [MessageID] FROM MailBoxTable WHERE [Box]=1 AND [UserID]=? ORDER BY Date DESC")
]
class COutboxInfo
{
public:
	[ db_column(1) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] LONG m_lMessageID;
	[ db_param(1) ]  LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=1 AND [UserID]=?")
]
class COutboxMessageCount
{
	public:
	[ db_column(1) ] LONG m_lMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};

// Note: the following SQL statement is MS Access specific (use of access function Date())
[
	db_command("UPDATE MailBoxTable SET [Box]=3, [Date]=Date() WHERE [MessageID]=? AND [UserID]=?")
]
class CMoveMessageToSentMail
{
public:
	[ db_param(1) ] LONG m_lMessageID;
	[ db_param(2) ] LONG m_lUserID;
};

[
	db_command("SELECT [To], [From], [Subject], [Date], [Message], [MessageID] FROM MailBoxTable WHERE [Box]=1 AND [UserID]=?")
]
class COutboxMessages
{
	public:
	[ db_column(1) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szFrom[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(5) ] TCHAR m_szMessage[MAX_MSG_LENGTH + 1];
	[ db_column(6) ] LONG m_lMessageID;
	[ db_param(1) ]	LONG m_lUserID;
};

