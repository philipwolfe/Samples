// AddUserDB.h : Defines the database classes for the AddUser handler
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
	db_command("INSERT INTO UserInfoTable ([FirstName], [LastName], [Email], [Login], [Password], [Salt], [Hint]) VALUES (?,?,?,?,?,?,?)")
]
class CAddUser
{
public:
	[ db_param(1) ] TCHAR m_szFirstName[DB_MAX_STRLEN + 1];
	[ db_param(2) ] TCHAR m_szLastName[DB_MAX_STRLEN + 1];
	[ db_param(3) ] TCHAR m_szEmail[DB_MAX_STRLEN + 1];
	[ db_param(4) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
	[ db_param(5) ] TCHAR m_szPassword[DB_MAX_STRLEN + 1];
	[ db_param(6) ] TCHAR m_szSalt[DB_MAX_STRLEN + 1];
	[ db_param(7) ] TCHAR m_szHint[DB_MAX_STRLEN + 1];
};

[ 
	db_command("UPDATE UserInfoTable SET [Confirmed]=Yes WHERE [Login]=?")
]
class CConfirmUser
{
public:
	[ db_param(1) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};

[ 
	db_command("SELECT [UserID] FROM UserInfoTable WHERE [Login]=?")
]
class CFindUserID
{
public:
	[ db_column(1) ] LONG m_lUserID;
	[ db_param(1) ] TCHAR m_szLogin[DB_MAX_STRLEN + 1];
};
