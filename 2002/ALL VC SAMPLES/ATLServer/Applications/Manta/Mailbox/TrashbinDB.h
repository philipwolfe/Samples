// TrashbinDB.h : Defines the database classes for the trashbin
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
	db_command("SELECT [To], [From], [Subject], [Date], [MessageID] FROM MailBoxTable WHERE [Box]=2 AND [UserID]=? ORDER BY Date DESC")
]
class CTrashbinInfo
{
public:
	[ db_column(1) ] TCHAR m_szTo[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szFrom[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szSubject[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(5) ] LONG m_lMessageID;
	[ db_param(1) ]  LONG m_lUserID;
};

[
	db_command("SELECT COUNT(*) FROM MailBoxTable WHERE [Box]=2 AND [UserID]=?")
]
class CTrashbinMessageCount
{
	public:
	[ db_column(1) ] LONG m_lMessageCount;
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("UPDATE MailBoxTable SET [Box]=2, [OldBox]=? WHERE [MessageID]=? AND [UserID]=?")
]
class CMarkMessageForDelete
{
public:
	[ db_param(1) ] LONG m_lOldBox;
	[ db_param(2) ] LONG m_lMessageID;
	[ db_param(3) ] LONG m_lUserID;
};

[
	db_command("UPDATE MailBoxTable SET [Box]=[OldBox], [OldBox]=0 WHERE [MessageID]=? AND [UserID]=?")
]
class CRestoreMessage
{
public:
	[ db_param(1) ] LONG m_lMessageID;
	[ db_param(2) ] LONG m_lUserID;
};

// Note: the following SQL statement is MS Access specific (SQL Server statement: "DELETE MailBoxTable WHERE [Box]=2 AND [UserID]=?")
[
	db_command("DELETE * FROM MailBoxTable WHERE [Box]=2 AND [UserID]=?")
]
class CDeleteAllMessages
{
public:
	[ db_param(1) ] LONG m_lUserID;
};