// LoginDB.h : Defines the database classes for the login handler
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
	db_command("SELECT [Password], [Salt], [FirstName], [LastName], [UserID] FROM UserInfoTable WHERE [Login]=? AND [Confirmed]=Yes")
]
class CLoginUser
{
public:
	[ db_column(1) ] TCHAR m_szPassword[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szSalt[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_column(5) ] LONG m_lUserID;
	[ db_param(1) ]  TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};

[
	db_command("SELECT [FirstName], [LastName], [Login] FROM UserInfoTable WHERE [UserID]=?")
]
class CUserSessionData
{
public:
	[ db_column(1) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
	[ db_param(1) ] LONG m_lUserID;
	
};

[
	db_command("SELECT [Password], [Salt] FROM UserInfoTable WHERE [Login]=?")
]
class CFindPassword
{
public:
	[ db_column(1) ] TCHAR m_szPassword[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szSalt[DB_MAX_STRLEN + 1];
	[ db_param(1) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};
