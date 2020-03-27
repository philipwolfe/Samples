// AppointmentDB.h : Defines the database classes for the appointments
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
	db_command("SELECT [Title], [Location], [Details], [Time], [Date] FROM AppointmentTable WHERE [AppointmentID]=? AND [UserID]=?")
]
class CAppointment
{
public:
	[ db_column(1) ] TCHAR m_szTitle[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szLocation[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szDetails[DB_MAX_DETAILSLEN + 1];
	[ db_column(4) ] LONG m_lTime;
	[ db_column(5) ]  TCHAR m_szDate[DB_MAX_STRLEN + 1];
	[ db_param(1) ]  LONG m_lAppointmentID;
	[ db_param(2) ]  LONG m_lUserID;
};

// Note: the following SQL statement is MS Access specific (SQL Server statement: "DELETE AppointmentTable WHERE [AppointmentID]=?")
[
	db_command("DELETE * FROM AppointmentTable WHERE [AppointmentID]=? AND [UserID]=?")
]
class CDeleteAppointment
{
public:
	[ db_param(1) ] LONG m_lAppointmentID;
	[ db_param(2) ] LONG m_lUserID;
};