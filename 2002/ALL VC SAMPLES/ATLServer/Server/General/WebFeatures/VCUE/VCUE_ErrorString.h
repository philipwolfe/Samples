// VCUE_ErrorString.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_ERRORSTRING_H___9A994A09_C94B_11D3_BACC_00C04F8EC847___INCLUDED_)
#define _VCUE_ERRORSTRING_H___9A994A09_C94B_11D3_BACC_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	class GetErrorString
	{
	private:
		TCHAR* m_szBuffer;

	public:
		GetErrorString(DWORD dwError = GetLastError()) : m_szBuffer(NULL)
		{
			FormatMessage( 
				FORMAT_MESSAGE_ALLOCATE_BUFFER | 
				FORMAT_MESSAGE_FROM_SYSTEM | 
				FORMAT_MESSAGE_IGNORE_INSERTS,
				NULL,
				dwError,
				MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), // Default language
				(LPTSTR) &m_szBuffer,
				0,
				NULL 
			);

			// Remove CR/LF if necessary
			if (m_szBuffer != NULL)
			{
				int nLen = lstrlen(m_szBuffer);
				if (nLen > 1 && m_szBuffer[nLen - 1] == '\n')
				{
					m_szBuffer[nLen - 1] = 0;
					if (m_szBuffer[nLen - 2] == '\r')
							m_szBuffer[nLen - 2] = 0;
				}
			} 
		}

		operator const TCHAR* () const
		{
			return m_szBuffer;
		}

		const TCHAR* operator()() const
		{
			return m_szBuffer;
		}

		~GetErrorString()
		{
			// Free the buffer.
			if (m_szBuffer != NULL)
				LocalFree(m_szBuffer);
		}
	};

} // namespace VCUE

#endif // !defined(_VCUE_ERRORSTRING_H___9A994A09_C94B_11D3_BACC_00C04F8EC847___INCLUDED_)
