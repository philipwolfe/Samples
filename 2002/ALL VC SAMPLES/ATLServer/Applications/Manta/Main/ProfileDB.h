// ProfileDB.h : Defines the database classes for the Outbox
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
	db_command("SELECT [FirstName], [LastName], [Email], [PopServer], [PopServerPort], [PopUserName], [PopPassword] FROM UserInfoTable WHERE [UserID]=?")
]
class CUserProfile
{
public:
	[ db_column(1) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_column(2) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_column(3) ] TCHAR m_szEmail[DB_MAX_STRLEN + 1];
	[ db_column(4) ] TCHAR m_szPopServer[DB_MAX_STRLEN + 1];
	[ db_column(5) ] LONG m_lPopServerPort;
	[ db_column(6) ] TCHAR m_szPopUserName[DB_MAX_STRLEN + 1];
	[ db_column(7) ] TCHAR m_szPopPassword[DB_MAX_STRLEN + 1];
	[ db_param(1) ] LONG m_lUserID;
};

[
	db_command("UPDATE UserInfoTable SET [FirstName]=?, [LastName]=?, [Email]=?, [PopServer]=?, [PopServerPort]=?, [PopUserName]=?, [PopPassword]=? WHERE [UserID]=?")
]
class CUpdateProfile
{
public:
	[ db_param(1) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_param(2) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_param(3) ] TCHAR m_szEmail[DB_MAX_STRLEN + 1];
	[ db_param(4) ] TCHAR m_szPopServer[DB_MAX_STRLEN + 1];
	[ db_param(5) ] LONG m_lPopServerPort;
	[ db_param(6) ] TCHAR m_szPopUserName[DB_MAX_STRLEN + 1];
	[ db_param(7) ] TCHAR m_szPopPassword[DB_MAX_STRLEN + 1];
	[ db_param(8) ] LONG m_lUserID;
};

[
	db_command("UPDATE UserInfoTable SET [Password]=? WHERE [UserID]=?")
]
class CUpdatePassword
{
public:
	[ db_param(1) ] TCHAR m_szPassword[DB_MAX_STRLEN + 1];
	[ db_param(2) ] LONG m_lUserID;
};