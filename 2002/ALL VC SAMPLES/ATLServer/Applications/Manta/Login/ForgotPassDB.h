// ForgotPassDB.h : Defines the database classes for the ForgotPass handler
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
	db_command("SELECT [Email] FROM UserInfoTable WHERE [Login]=?")
]
class CFindEmail
{
public:
	[ db_column(1) ] TCHAR m_szEmail[DB_MAX_STRLEN + 1];
	[ db_param(1) ]  TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};

[
	db_command("SELECT [FirstName], [LastName], [Hint] FROM UserInfoTable WHERE [Email]=?")
]
class CUserInfo
{
public:
	[ db_column(1) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szHint[DB_MAX_STRLEN + 1];
	[ db_param(1) ]  TCHAR m_szEmail[DB_MAX_STRLEN + 1];
};