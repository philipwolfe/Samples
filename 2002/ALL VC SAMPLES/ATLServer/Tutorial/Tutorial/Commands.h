// File: Commands.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[
	db_command("SELECT [SiteUser].[Email] FROM [SiteUser] WHERE [SiteUser].[UserName] = ?")
]
class CGetEmail
{
public:
	[db_param(1, status = m_dwUserNameStatus, length = m_dwUserNameLength)]
	char m_UserName[51];

	[db_column(1, status = m_dwEmailStatus, length = m_dwEmailLength)]
	char m_Email[256];

	DBSTATUS m_dwUserNameStatus;
	DBSTATUS m_dwEmailStatus;

	DBLENGTH m_dwUserNameLength;
	DBLENGTH m_dwEmailLength;
};

class CCommandGetEmail : public CGetEmail
{
public:
	CCommandGetEmail();
	void Clear();
	HRESULT SetUserName(LPCSTR szUserName);
};

[ 
	db_command("INSERT INTO [Order] ( [UserName], [Order] ) VALUES(?, ?)")
]
class CCreateOrder
{
public:
	[db_param(1, status = m_dwUserNameStatus, length = m_dwUserNameLength)]
	char m_UserName[51];

	[db_param(2, status = m_dwOrderStatus, length = m_dwOrderLength)]
	char m_Order[101];

	DBSTATUS m_dwUserNameStatus;
	DBSTATUS m_dwOrderStatus;

	DBLENGTH m_dwUserNameLength;
	DBLENGTH m_dwOrderLength;

	void GetRowsetProperties(CDBPropSet* pPropSet)
	{
		pPropSet->AddProperty(DBPROP_IRowsetChange, true);
	}
};

class CCommandCreateOrder : public CCreateOrder
{
public:
	CCommandCreateOrder();
	void Clear();
	HRESULT SetUserName(LPCSTR szUserName);
	HRESULT SetOrder(LPCSTR szOrder);
};

[
	db_command("SELECT [Stock].[Name], [Stock].[Description], [Stock].[Price], [Stock].[Id] FROM [Stock]")
]
class CGetStock
{
public:
	[db_column(1, status = m_dwNameStatus, length = m_dwNameLength)]
	char m_Name[51];

	[db_column(2, status = m_dwDescriptionStatus, length = m_dwDescriptionLength)]
	char m_Description[300];

	[db_column(3, status = m_dwPriceStatus)]
	long m_Price;

	[db_column(4, status = m_dwIdStatus)]
	long m_Id;

	DBSTATUS m_dwNameStatus;
	DBSTATUS m_dwDescriptionStatus;
	DBSTATUS m_dwPriceStatus;
	DBSTATUS m_dwIdStatus;

	DBLENGTH m_dwNameLength;
	DBLENGTH m_dwDescriptionLength;
};

class CCommandGetStock : public CGetStock
{
public:
	CCommandGetStock();
	void Clear();

	bool AllMembersOk();
};

[
	db_command(L"SELECT [SiteUser].[Password], [SiteUser].[Salt] FROM [SiteUser] WHERE [SiteUser].[UserName] = ?")
]
class CSiteUser
{
public:
	[ db_param(1, status = m_dwUserNameStatus, length = m_dwUserNameLength) ]
	char m_UserName[51];

	[ db_column(1, status = m_dwPasswordStatus, length = m_dwPasswordLength) ]
	BYTE m_Password[51];

	[ db_column(2, status = m_dwSaltStatus, length = m_dwSaltLength) ]
	BYTE m_Salt[4];

	DBSTATUS m_dwUserNameStatus;
	DBSTATUS m_dwPasswordStatus;
	DBSTATUS m_dwSaltStatus;

	DBLENGTH m_dwUserNameLength;
	DBLENGTH m_dwPasswordLength;
	DBLENGTH m_dwSaltLength;
};

class CCommandSiteUser : public CSiteUser
{
public:
	CCommandSiteUser();
	void Clear();
	HRESULT SetUserName(LPCSTR szUserName);
	HRESULT ComparePassword(LPCSTR szPassword);
};

[ 
	db_command("INSERT INTO [SiteUser] ( [Password], [Salt], [UserName], [Email] ) VALUES(?, ?, ?, ?)")
]
class CCreateUser
{
public:
	[ db_param(1, status = m_dwPasswordStatus, length = m_dwPasswordLength) ]
	BYTE m_Password[51];

	[ db_param(2, status = m_dwSaltStatus, length = m_dwSaltLength) ]
	BYTE m_Salt[4];

	[ db_param(3, status = m_dwUserNameStatus, length = m_dwUserNameLength) ]
	char m_UserName[51];

	[db_param(4, status = m_dwEmailStatus, length = m_dwEmailLength)]
	char m_Email[256];

	DBSTATUS m_dwPasswordStatus;
	DBSTATUS m_dwSaltStatus;
	DBSTATUS m_dwUserNameStatus;
	DBSTATUS m_dwEmailStatus;

	DBLENGTH m_dwPasswordLength;
	DBLENGTH m_dwSaltLength;
	DBLENGTH m_dwUserNameLength;
	DBLENGTH m_dwEmailLength;

	void GetRowsetProperties(CDBPropSet* pPropSet)
	{
		pPropSet->AddProperty(DBPROP_IRowsetChange, true);
	}
};

class CCommandCreateUser : public CCreateUser
{
public:
	CCommandCreateUser();
	void Clear();
	HRESULT SetUserName(LPCSTR szUserName);
	HRESULT SetPassword(LPCSTR szPassword);
	HRESULT SetEmail(LPCSTR szEmail);
};