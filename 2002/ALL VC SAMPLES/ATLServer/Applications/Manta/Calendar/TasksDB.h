// TasksDB.h : Defines the database classes for the tasks list
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
	db_command("SELECT [Title], [Date], [Priority], [TaskID] FROM TasksTable WHERE [UserID]=? ORDER BY [Date], [Priority] DESC")
]
class CTasksList
{
public:
	[ db_column(1) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_column(3) ] LONG m_lPriority;
	[ db_column(4) ] LONG m_lTaskID;
	[ db_param(1) ]  LONG m_lUserID;
};

// Note: the following SQL statement is MS Access specific (use of access function Date())
[
	db_command("SELECT [Title], [Priority], [TaskID] FROM TasksTable WHERE [Date]=Date() AND [UserID]=? ORDER BY [Priority] DESC")
]
class CTodaysTasks
{
public:
	[ db_column(1) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_column(2) ] LONG m_lPriority;
	[ db_column(3) ] LONG m_lTaskID;
	[ db_param(1) ]  LONG m_lUserID;
};

[
	db_command("INSERT INTO TasksTable ([Title], [Date], [Priority], [Details], [UserID]) VALUES (?,?,?,?,?)")
]
class CNewTask
{
public:
	[ db_param(1) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_param(2) ] DATE m_dueDate;
	[ db_param(3) ] LONG m_lPriority;
	[ db_param(4) ] TCHAR m_szDetails[DB_MAX_DETAILSLEN + 1];
	[ db_param(5) ] LONG m_lUserID;
};

// Note: the following SQL statement is MS Access specific (SQL Server statement: "DELETE TasksTable WHERE [UserID]=? AND [TaskID]=?")
[
	db_command("DELETE * FROM TasksTable WHERE [UserID]=? AND [TaskID]=?")
]
class CDeleteTask
{
public:
	[ db_param(1) ] LONG m_lUserID;
	[ db_param(2) ] LONG m_lTaskID;
};