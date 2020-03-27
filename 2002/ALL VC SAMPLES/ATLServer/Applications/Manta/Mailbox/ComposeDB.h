// ComposeDB.h : Defines the database classes for message composing
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
	db_command("SELECT [UserID] FROM UserInfoTable WHERE [Login]=?")
]
class CFindUserID
{
public:
	[ db_column(1) ] LONG m_lUserID;
	[ db_param(1) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};

[
	db_command("INSERT INTO MailBoxTable ([UserID], [To], [From], [Subject], [Message], [Box]) VALUES (?,?,?,?,?,?)")
]
class CAddNewMessage
{
	public:
	[ db_param(1) ] LONG  m_lUserID;
	[ db_param(2) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_param(3) ] TCHAR m_szFrom[DB_MAX_STRLEN + 1];
	[ db_param(4) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_param(5) ] TCHAR m_szMessage[MAX_MSG_LENGTH + 1];
	[ db_param(6) ] LONG  m_lBox;
};

[
	db_command("UPDATE MailBoxTable SET [Message]=? WHERE [MessageID]=? AND [UserID]=?")
]
class CUpdateMessage
{
public:
	[ db_param(1) ] TCHAR m_szMessage[MAX_MSG_LENGTH + 1];
	[ db_param(2) ] LONG m_lMessageID;
	[ db_param(3) ] LONG m_lUserID;
};

