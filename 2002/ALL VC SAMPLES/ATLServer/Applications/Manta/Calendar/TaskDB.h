// TaskDB.h : Defines the database classes for viewing and deleting individual tasks
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
	db_command("SELECT [Title], [Date], [Priority], [Details] FROM TasksTable WHERE [TaskID]=? AND [UserID]=?")
]
class CTask
{
public:
	[ db_column(1) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_column(2) ] DATE m_DueDate;
	[ db_column(3) ] LONG m_lPriority;
	[ db_column(4) ] TCHAR m_szDetails[DB_MAX_DETAILSLEN + 1];
	[ db_param(1) ] LONG m_lTaskID;
	[ db_param(2) ]  LONG m_lUserID;
};