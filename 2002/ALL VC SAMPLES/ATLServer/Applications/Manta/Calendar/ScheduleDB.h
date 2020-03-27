// ScheduleDB.h : Defines the database classes for the schedule
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
	db_command("SELECT [AppointmentID], [Title], [Location], [Time] FROM AppointmentTable WHERE [Date]=? AND [UserID]=? ORDER BY Time")
]
class CAppointmentList
{
public:
	[ db_column(1) ] LONG m_lAppointmentID;
	[ db_column(2) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szLocation[DB_MAX_STRLEN + 1];
	[ db_column(4) ] LONG m_lTime;
	[ db_param(1) ]  TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_param(2) ]  LONG m_lUserID;
};

[
	db_command("SELECT [AppointmentID] FROM AppointmentTable WHERE [Date]=? AND [Time]=? AND [UserID]=?")
]
class CFindAppointment
{
public:
	[ db_column(1) ] LONG m_lAppointmentID;
	[ db_param(1) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_param(2) ] LONG m_lTime;
	[ db_param(3) ] LONG m_lUserID;
};

[
	db_command("INSERT INTO AppointmentTable ([Date], [Title], [Location], [Details], [Time], [UserID]) VALUES (?,?,?,?,?,?)")
]
class CNewAppointment
{
public:
	[ db_param(1) ] TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_param(2) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_param(3) ] TCHAR m_szLocation[DB_MAX_STRLEN + 1];
	[ db_param(4) ] TCHAR m_szDetails[DB_MAX_DETAILSLEN + 1];
	[ db_param(5) ] LONG m_lTime;
	[ db_param(6) ] LONG m_lUserID;
};