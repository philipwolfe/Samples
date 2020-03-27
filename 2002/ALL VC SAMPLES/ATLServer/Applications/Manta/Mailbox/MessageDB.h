// MessageDB.h : Defines the database classes for message viewing
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
	db_command("SELECT [To], [From], [Subject], [Date], [Message] FROM MailBoxTable WHERE [MessageID]=? AND [UserID]=?")
]
class CMessageInfo
{
public:
	[ db_column(1) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szFrom[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(5) ] TCHAR m_szMessage[MAX_MSG_LENGTH + 1];
	[ db_param(1) ] LONG m_lMessageID;
	[ db_param(2) ] LONG m_lUserID;
};

[
	db_command("UPDATE MailBoxTable SET [MarkedRead]=Yes WHERE [MessageID]=? AND [UserID]=?")
]
class CMarkMessageAsRead
{
public:
	[ db_param(1) ] LONG m_lMessageID;
	[ db_param(2) ] LONG m_lUserID;
};