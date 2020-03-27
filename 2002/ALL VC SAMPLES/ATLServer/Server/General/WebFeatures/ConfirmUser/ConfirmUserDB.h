// ConfirmUserDB.h
// (c) 2000 Microsoft Corporation
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_CONFIRMUSERDB_H___EB010A9D_3D2A_433D_B774_97CE1E254E11___INCLUDED_)
#define _CONFIRMUSERDB_H___EB010A9D_3D2A_433D_B774_97CE1E254E11___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "..\VCUE\VCUE_Encrypt.h"

class CTableUser
{
public:
	LONG m_ID;
	GUID m_GUID;
	char m_Name[50 + 1];
	char m_Email[128 + 1];
	BYTE m_Password[50];
	DBTIMESTAMP m_Created;
	DBTIMESTAMP m_Modified;
	BYTE m_Salt[4];

	DBLENGTH m_dwPasswordLength;
	DBLENGTH m_dwSaltLength;

	CTableUser()
	{
		Clear();
	}

	void Clear()
	{
		m_ID = 0;
		ZeroMemory(&m_GUID, sizeof(m_GUID));	
		m_Name[0] = 0;
		m_Email[0] = 0;
		ZeroMemory(&m_Password, sizeof(m_Password));
		ZeroMemory(&m_Created, sizeof(m_Created));
		ZeroMemory(&m_Modified, sizeof(m_Modified));
		ZeroMemory(&m_Salt, sizeof(m_Salt));
		m_dwPasswordLength = 0;
		m_dwSaltLength = 0;
	}

	bool SetName(const CStringA& str) throw()
	{
		DWORD dwBytes = sizeof(m_Name);
		if (CopyCString(str, m_Name, &dwBytes))
			return true;
		return false;
	}

	bool SetEmail(const CStringA& str) throw()
	{
		DWORD dwBytes = sizeof(m_Email);
		if (CopyCString(str, m_Email, &dwBytes))
			return true;
		return false;
	}

	bool SetPassword(const CStringA& str) throw()
	{
		m_dwPasswordLength = sizeof(m_Password);
		m_dwSaltLength = sizeof(m_Salt);
		
		HRESULT hr = HashSecret(cstring_cast<BYTE>(str), str.GetLength() * sizeof(CString::XCHAR),
					m_Salt, m_dwSaltLength,
					m_Password, m_dwPasswordLength);

		if (SUCCEEDED(hr))
			return true;

		m_dwPasswordLength = 0;
		m_dwSaltLength = 0;

		return false;
	}

	bool CopyPasswordFrom(const CTableUser& Source)
	{
		if (Source.m_dwPasswordLength > sizeof(m_Password))
			return false;

		memcpy(m_Password, Source.m_Password, Source.m_dwPasswordLength);
		m_dwPasswordLength = Source.m_dwPasswordLength;
		return true;
	}
	

	bool SetGuid(const GUID& guid) throw()
	{
		memcpy(&m_GUID, &guid, sizeof(GUID));
		return true;
	}
};

class CUserConfirmer : public CTableUser
{
public:

BEGIN_PARAM_MAP(CUserConfirmer)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY(1, m_Name)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY_LENGTH(2, m_Password, m_dwPasswordLength)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY(3, m_GUID)
	SET_PARAM_TYPE(DBPARAMIO_OUTPUT)
	COLUMN_ENTRY(4, m_ID)
END_PARAM_MAP()

};

class CUserAdder : public CTableUser
{
public:

BEGIN_PARAM_MAP(CUserAdder)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY(1, m_Name)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY_LENGTH(2, m_Password, m_dwPasswordLength)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY_LENGTH(3, m_Salt, m_dwSaltLength)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY(4, m_Email)
	SET_PARAM_TYPE(DBPARAMIO_OUTPUT)
	COLUMN_ENTRY(5, m_GUID)
END_PARAM_MAP()

};

class CUserGetter : public CTableUser
{
public:

BEGIN_PARAM_MAP(CUserGetter)
	SET_PARAM_TYPE(DBPARAMIO_INPUT)
	COLUMN_ENTRY(1, m_Name)
END_PARAM_MAP()

BEGIN_COLUMN_MAP(CUserGetter)
	COLUMN_ENTRY(1, m_ID)
	COLUMN_ENTRY_LENGTH(2, m_Password, m_dwPasswordLength)
	COLUMN_ENTRY_LENGTH(3, m_Salt, m_dwSaltLength)
END_COLUMN_MAP()

};


class CSprocAddUser : public CCommand< CAccessor< CUserAdder >, CRowset, CMultipleResults >
{
public:
	HRESULT Execute(CSession& theSession, const CStringA& strName, const CStringA& strPassword, const CStringA& strEmail) throw()
	{
		SetGuid(GUID_NULL);
		HRESULT hr = E_UNEXPECTED;
		if (SetName(strName))
		{
			if (SetPassword(strPassword))
			{
				if (SetEmail(strEmail))
				{
					hr = Open(theSession, "{ CALL sproc_CreateUnconfirmedUser(?, ?, ?, ?, ?) }");
					if (OleDbSucceeded(hr))
					{
						// Get to the end of the results in order to get the out parameter
						DBROWCOUNT pulRowsAffected = 0;
						while (GetNextResult(&pulRowsAffected) == S_OK);
					}
				}
			}
		}
		return hr;
	}
};

class CSprocGetUser : public CCommand< CAccessor< CUserGetter >, CRowset, CMultipleResults >
{
public:
	HRESULT Execute(CSession& theSession, const CStringA& strName, const CStringA& strPassword) throw()
	{
		HRESULT hr = E_UNEXPECTED;
		Clear();
		if (SetName(strName))
		{
			hr = Open(theSession, "{ CALL sproc_GetUser(?) }");
			if (OleDbSucceeded(hr))
			{
				hr = MoveFirst();
				if (S_OK == hr)
				{
					hr = CompareSecret(
						cstring_cast<BYTE>(strPassword), strPassword.GetLength() * sizeof(CString::XCHAR),
						m_Salt, m_dwSaltLength,
						m_Password, m_dwPasswordLength);
				}
			}
			
		}
		return hr;
	}
};
class CSprocConfirmUser : public CCommand< CAccessor< CUserConfirmer >, CRowset, CMultipleResults >
{
public:
	HRESULT Execute(CSession& theSession, const CStringA& strName, const CStringA& strPassword, const GUID& guid, LONG& lID) throw()
	{
		HRESULT hr = E_UNEXPECTED;
		m_ID = 0;

		CSprocGetUser getter;
		hr = getter.Execute(theSession, strName, strPassword);
		if (S_OK == hr)
		{
			hr = E_UNEXPECTED;
			if (SetName(strName))
			{
				if (CopyPasswordFrom(getter))
				{
					if (SetGuid(guid))
					{
						hr = Open(theSession, "{ CALL sproc_ConfirmUser(?, ?, ?, ?) }");
						if (OleDbSucceeded(hr))
						{
							// Get to the end of the results in order to get the out parameter
							DBROWCOUNT pulRowsAffected = 0;
							while (GetNextResult(&pulRowsAffected) == S_OK);
							lID = m_ID;
						}
					}
				}
			}
		}
		return hr;
	}
};


#endif // !defined(_CONFIRMUSERDB_H___EB010A9D_3D2A_433D_B774_97CE1E254E11___INCLUDED_)
