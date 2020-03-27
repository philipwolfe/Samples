// File: SimpleUserPwdValidate.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#ifndef SIMPLEUSERPWDVALIDATE_H_INCLUDED
#define	SIMPLEUSERPWDVALIDATE_H_INCLUDED


/* 
	This is a very simple User/Pwd validation class
	It will reject a user only if the user name is empty
	The purpose is to use the same code in both the request handler and the soap handler
*/

class CSimpleUserPwdValidator
{
protected:
	CString		m_strUserName;
	CString		m_strPassword;

	bool		m_bValid;
	CString		m_strErrorString;

	void		validate()
	{
		// add your own validation code here
		m_bValid	=	!m_strUserName.IsEmpty();

		if( m_bValid )
		{
			m_strErrorString.Format(_T("Congratulations, %s, you have been validated"), m_strUserName);
		}
		else
		{
			m_strErrorString = _T("Sorry, you were not validated. Try again!");
		}
	}

public:
	CSimpleUserPwdValidator():  m_bValid(false){}

	void	setUserNameAndPassword(LPCSTR	szUserName, LPCSTR	strPwd)
	{
		m_strUserName	=	szUserName;
		m_strPassword	=	strPwd;

		validate();
	}

	bool	isValid()
	{
		return	m_bValid;	
	}

	LPCTSTR	errorString()
	{
		return m_strErrorString;
	}

};
#endif	//SIMPLEUSERPWDVALIDATE_H_INCLUDED