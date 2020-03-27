// File: Commands.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "Commands.h"
#include "Encrypt.h"
#include "Helpers.h"

// Initialization.
CCommandGetEmail::CCommandGetEmail()
{
	Clear();
}

// Initialization.
void CCommandGetEmail::Clear()
{
	m_dwUserNameStatus = DBSTATUS_S_ISNULL;
	m_dwEmailStatus = DBSTATUS_S_ISNULL;

	m_dwUserNameLength = 0;
	m_dwEmailLength = 0;

	m_UserName[0] = _T('\0');
	m_Email[0] = _T('\0');
}

HRESULT CCommandGetEmail::SetUserName(LPCSTR szUserName)
{
	return VCUE::SetOleDbStringMember(m_UserName, m_dwUserNameStatus, m_dwUserNameLength, szUserName);
}

// Initialization.
CCommandCreateOrder::CCommandCreateOrder()
{
	Clear();
}

// Initialization.
void CCommandCreateOrder::Clear()
{
	m_dwUserNameStatus = DBSTATUS_S_ISNULL;
	m_dwOrderStatus = DBSTATUS_S_ISNULL;

	m_dwUserNameLength = 0;
	m_dwOrderLength = 0;

	m_UserName[0] = _T('\0');
	m_Order[0] = _T('\0');
}

HRESULT CCommandCreateOrder::SetUserName(LPCSTR szUserName)
{
	return VCUE::SetOleDbStringMember(m_UserName, m_dwUserNameStatus, m_dwUserNameLength, szUserName);
}

HRESULT CCommandCreateOrder::SetOrder(LPCSTR szOrder)
{
	return VCUE::SetOleDbStringMember(m_Order, m_dwOrderStatus, m_dwOrderLength, szOrder);
}

// Initialization.
CCommandGetStock::CCommandGetStock()
{
	Clear();
}

// Initialization.
void CCommandGetStock::Clear()
{
	m_dwNameStatus = DBSTATUS_S_ISNULL;
	m_dwDescriptionStatus = DBSTATUS_S_ISNULL;
	m_dwPriceStatus = DBSTATUS_S_ISNULL;
	m_dwIdStatus = DBSTATUS_S_ISNULL;

	m_dwNameLength = 0;
	m_dwDescriptionLength = 0;

	m_Name[0] = _T('\0');
	m_Description[0] = _T('\0');
	m_Price = 0;
	m_Id = 0;
}

// Returns true if all status members are equal to DBSTATUS_S_OK.
// Returs false otherwise.
bool CCommandGetStock::AllMembersOk()
{
	if (m_dwNameStatus != DBSTATUS_S_OK)
		return false;

	if (m_dwDescriptionStatus != DBSTATUS_S_OK)
		return false;

	if (m_dwPriceStatus != DBSTATUS_S_OK)
		return false;

	if (m_dwIdStatus != DBSTATUS_S_OK)
		return false;

	return true;
}

// Initialization.
CCommandSiteUser::CCommandSiteUser()
{
	Clear();
}

// Initialization.
void CCommandSiteUser::Clear()
{
	m_dwPasswordStatus = DBSTATUS_S_ISNULL;
	m_dwSaltStatus = DBSTATUS_S_ISNULL;
	m_dwUserNameStatus = DBSTATUS_S_ISNULL;

	m_dwPasswordLength = 0;
	m_dwSaltLength = 0;
	m_dwUserNameLength = 0;

	m_Password[0] = 0;
	m_Salt[0] = 0;
	m_UserName[0] = 0;
}

HRESULT CCommandSiteUser::SetUserName(LPCSTR szUserName)
{
	return VCUE::SetOleDbStringMember(m_UserName, m_dwUserNameStatus, m_dwUserNameLength, szUserName);
}

// Returns S_OK if password matches.
// Returns S_FALSE if password doesn't match.
// Returns an error HRESULT if an error occurs.
// Pass in a plain text password and this function will add the
// salt stored in m_Salt to the password and hash it. The resulting
// has will then be compared with the hash in m_Password.
// This is the means by which a previously hashed password can be compared
// with a plain text password.
HRESULT CCommandSiteUser::ComparePassword(LPCSTR szPassword)
{
	ATLASSERT(szPassword != NULL);

	HRESULT hr = E_FAIL;

	if (
		(m_dwSaltStatus == DBSTATUS_S_OK) &&
		(m_dwPasswordStatus == DBSTATUS_S_OK) &&
		(m_dwSaltLength != 0) &&
		(m_dwPasswordLength != 0)
		)
	{
		#pragma warning(push)
		#pragma warning(disable : 4267) // conversion from 'size_t' to 'DWORD', possible loss of data

		hr = VCUE::CompareSecret(
					reinterpret_cast<const BYTE*>(szPassword), strlen(szPassword),
					m_Salt, m_dwSaltLength,
					m_Password, m_dwPasswordLength);

		#pragma warning(pop)
	}

	return hr;
}

HRESULT CCommandCreateUser::SetUserName(LPCSTR szUserName)
{
	return VCUE::SetOleDbStringMember(m_UserName, m_dwUserNameStatus, m_dwUserNameLength, szUserName);
}

HRESULT CCommandCreateUser::SetEmail(LPCSTR szEmail)
{
	return VCUE::SetOleDbStringMember(m_Email, m_dwEmailStatus, m_dwEmailLength, szEmail);
}

// Pass in a plain text password and this method will create
// a salt (random number) and put it in m_Salt, and hash the
// salt and the password and put the hash in m_Password.
// The salt and the hash can then be stored in the database
// and compared to a password in the future. This allows passwords
// to be validated without having to store the password itself.
HRESULT CCommandCreateUser::SetPassword(LPCSTR szPassword)
{
	ATLASSERT(szPassword != NULL);

	HRESULT hr = E_FAIL;
	m_dwPasswordLength = sizeof(m_Password);
	m_dwSaltLength = sizeof(m_Salt);
	
	#pragma warning(push)
	#pragma warning(disable : 4267) // conversion from 'size_t' to 'DWORD', possible loss of data

	hr = VCUE::HashSecret(reinterpret_cast<const BYTE*>(szPassword), strlen(szPassword),
				m_Salt, m_dwSaltLength,
				m_Password, m_dwPasswordLength);

	#pragma warning(pop)

	if (FAILED(hr))
	{
		m_dwPasswordLength = 0;
		m_dwSaltLength = 0;

		m_dwPasswordStatus = DBSTATUS_S_ISNULL;
		m_dwSaltStatus = DBSTATUS_S_ISNULL;
	}
	else
	{
		m_dwPasswordStatus = DBSTATUS_S_OK;
		m_dwSaltStatus = DBSTATUS_S_OK;
	}

	ATLASSERT(m_dwPasswordLength <= sizeof(m_Password));
	ATLASSERT(m_dwSaltLength <= sizeof(m_Salt));
	ATLASSERT( (FAILED(hr) && (0 == m_dwPasswordLength) && (DBSTATUS_S_ISNULL == m_dwPasswordStatus)) || (SUCCEEDED(hr) && (0 != m_dwPasswordLength) && (DBSTATUS_S_OK == m_dwPasswordStatus)) );
	ATLASSERT( (FAILED(hr) && (0 == m_dwSaltLength) && (DBSTATUS_S_ISNULL == m_dwSaltStatus)) || (SUCCEEDED(hr) && (0 != m_dwSaltLength) && (DBSTATUS_S_OK == m_dwSaltStatus)) );

	return hr;
}

// Initialization.
CCommandCreateUser::CCommandCreateUser()
{
	Clear();
}

// Initialization.
void CCommandCreateUser::Clear()
{
	m_dwPasswordStatus = DBSTATUS_S_ISNULL;
	m_dwSaltStatus = DBSTATUS_S_ISNULL;
	m_dwUserNameStatus = DBSTATUS_S_ISNULL;
	m_dwEmailStatus = DBSTATUS_S_ISNULL;

	m_dwPasswordLength = 0;
	m_dwSaltLength = 0;
	m_dwUserNameLength = 0;
	m_dwEmailLength = 0;

	m_Password[0] = 0;
	m_Salt[0] = 0;
	m_UserName[0] = 0;
	m_Email[0] = 0;
}