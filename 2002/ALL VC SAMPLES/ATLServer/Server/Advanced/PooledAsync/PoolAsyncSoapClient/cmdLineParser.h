// File: cmdLineParser.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef CMDLINEPARSER_H_INCLUDED
#define CMDLINEPARSER_H_INCLUDED


class CCmdLineParser
{
	struct	stData
	{
		LPTSTR	szVerb;
		LPTSTR	szValue;
	};
	
public:
	CCmdLineParser()
	{
		m_iParamsAllocatedSize	=	0;
		m_iParamsSize			=	0;
		m_arParams = NULL;
	}

	
	~CCmdLineParser()
	{
		int	iIndex = 0;
		
		for( iIndex = 0; iIndex < m_iParamsSize; iIndex ++ )
		{
			stData	data	=	m_arParams[iIndex];
			free( data.szVerb );
			free( data.szValue );
		}
		free(m_arParams);
	}
	
	LPCTSTR	lookup(LPCTSTR	szVerb)
	{
		
		for( int iIndex = 0; iIndex < m_iParamsSize; iIndex ++ )
		{
			stData	data	=	m_arParams[iIndex];
			if( _tcsicmp(data.szVerb, szVerb) == 0 )
				return data.szValue;
		}
		
		return NULL;
		
	}
	
	
	void	dump()
	{
		for( int iIndex = 0; iIndex < m_iParamsSize; iIndex ++ )
		{
			stData	data	=	m_arParams[iIndex];
			_tprintf(_T("Verb : %s "), data.szVerb);
			_tprintf(_T(" -- Value : %s \n"), data.szValue ? data.szValue : _T("NULL"));
		}
	}


	void parse(char argc, TCHAR**	argv)
	{
		
		for( int iIndex = 1; iIndex < argc; iIndex ++ )
		{
			LPCTSTR		szVerb		=	argv[iIndex];
			LPCTSTR		szValue	=	NULL;
			
			szValue	=	_tcschr( szVerb, (TCHAR)(':') );
			
			if( szValue )
				szValue	++;
			
			addMap( szVerb, szValue );
			
		}
		
	}

protected:
	stData				*m_arParams;
	int					m_iParamsAllocatedSize;
	int					m_iParamsSize;
	
	bool	addMap(LPCTSTR	szVerb, LPCTSTR szValue)
	{
		
		if( !szVerb )
			return false;
		stData	newData;

		if( ( *szVerb == '-' ) || ( *szVerb == '/' ))
			szVerb ++;

		if( szValue )
		{
			int		iSize	=	(int)(szValue - szVerb);
			
			newData.szVerb		=	(LPTSTR)malloc( iSize*sizeof(TCHAR));
			newData.szVerb[iSize - 1] =  0;
			_tcsncpy( newData.szVerb, szVerb, iSize  - 1);
			
			
			newData.szValue	=	(LPTSTR)malloc( (1 + _tcslen(szValue))*sizeof(TCHAR));
			_tcscpy( newData.szValue, szValue);
		}
		else
		{		
			unsigned int		iSize	=	(unsigned int)_tcslen( szVerb ) + 1;
			newData.szVerb		=	(LPTSTR)malloc( iSize*sizeof(TCHAR));
			_tcscpy( newData.szVerb, szVerb);

			newData.szValue	=	NULL;
		}
		
		
		
		if( m_iParamsSize == m_iParamsAllocatedSize )
		{
			const int	sizeIncrement	=	4;
			m_arParams	=	(stData*)realloc( m_arParams, (m_iParamsAllocatedSize + sizeIncrement)*sizeof(stData) );
			if( m_arParams != NULL )
			{
				m_iParamsAllocatedSize	+=	sizeIncrement;
			}
		}
		
		if( m_arParams )
		{
			m_arParams[ m_iParamsSize ++]	=	newData;
		}
		else
			return false;
			
		return true;
	}

};
#endif //CMDLINEPARSER_H_INCLUDED