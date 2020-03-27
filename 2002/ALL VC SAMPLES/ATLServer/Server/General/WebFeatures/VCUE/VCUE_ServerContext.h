// VCUE_ServerContext.h
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

#if !defined(_VCUE_SERVERCONTEXT_H___CF327AE5_EE9E_4652_8F1C_A4B15AB3D701___INCLUDED_)
#define _VCUE_SERVERCONTEXT_H___CF327AE5_EE9E_4652_8F1C_A4B15AB3D701___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "VCUE_Time.h"
#include <atltime.h>

namespace VCUE
{
	inline bool GetServerVariable(IHttpServerContext* pServerContext, LPCSTR szVariable, CStringA &str) throw()
	{
		bool bSuccess = false;

		if (pServerContext)
		{
			DWORD dwSize = 0;
			pServerContext->GetServerVariable(szVariable, NULL, &dwSize);
			
			if (pServerContext->GetServerVariable(szVariable, str.GetBuffer(dwSize), &dwSize))
				bSuccess = true;

			if (dwSize > 0)
				--dwSize;
			str.ReleaseBuffer(dwSize);
		}

		return bSuccess;
	}

	inline bool ContextWriteClient(IHttpServerContext* pServerContext, LPCSTR pvBuffer, DWORD* pdwBytes) throw()
	{
		return pServerContext->WriteClient(const_cast<LPSTR>(pvBuffer), pdwBytes) ? true : false;
	}

	inline bool ContextWriteClient(IHttpServerContext* pServerContext, LPCSTR pvBuffer, DWORD dwBytes) throw()
	{
		return ContextWriteClient(pServerContext, pvBuffer, &dwBytes);
	}

	inline bool ClientHasRecentContent(IHttpServerContext* pServerContext, COleDateTime tCurrent = GmtTime(), COleDateTimeSpan tsSpan = COleDateTimeSpan(0, 0, 5, 0))
	{
		bool bClientHasRecentContent = false;

		CStringA strLastModified;
		if (GetServerVariable(pServerContext, "HTTP_IF_MODIFIED_SINCE", strLastModified))
		{
			SYSTEMTIME st = {0};
			if (ParseHttpDate(strLastModified, st))
			{
				COleDateTime tCached(st);
				if (tCurrent - tCached <= tsSpan)
					bClientHasRecentContent = true;
			}
		}

		return bClientHasRecentContent;
	}

	inline bool ClientHasRecentContent(IHttpServerContext* pServerContext, unsigned int nMinutes)
	{
		COleDateTime tCurrent(GmtTime());
		COleDateTimeSpan tsMinutes(0, 0, nMinutes, 0);
		return ClientHasRecentContent(pServerContext, tCurrent, tsMinutes);
	}

	// TODO - implement request functions in terms of server context?
	// Call this function to retrieve the physical folder of the current script
	// Returns true on success, false on failure
	inline bool GetPhysicalScriptFolder(IHttpServerContext* pServerContext, CStringA& strPhysicalFolder)
	{
		bool bSuccess = false;
		strPhysicalFolder = pServerContext->GetScriptPathTranslated();
		if (strPhysicalFolder.GetLength())
		{
			int nFound = strPhysicalFolder.ReverseFind('\\');
			if (nFound != -1)
				strPhysicalFolder = strPhysicalFolder.Left(nFound + 1);
			else
				strPhysicalFolder += '\\';

			// Success!
			bSuccess = true;
		}
		return bSuccess;
	}

	// Return physical script folder directly (or empty string on failure).
	inline CStringA GetPhysicalScriptFolder(IHttpServerContext* pServerContext)
	{
		CStringA strPhysicalScriptFolder;
		if (!GetPhysicalScriptFolder(pServerContext, strPhysicalScriptFolder))
			strPhysicalScriptFolder = "";
		
		return strPhysicalScriptFolder;
	}

	inline bool SynchronousTransmitFileHeaders(IHttpServerContext* pServerContext, HANDLE hFile, LPCSTR szContentType = "text/html", LPCSTR szStatus = "200 OK", bool bKeepConnection = true) throw()
	{
		bool bSuccess = false;
		LARGE_INTEGER nBytes = {0};
		if (GetFileSizeEx(hFile, &nBytes))
		{
			LPCSTR szKeepAlive = "";
			if (bKeepConnection)
				szKeepAlive = "Connection: Keep-Alive\r\n";

			CStringA strHeaders;
			strHeaders.Format(
				"%s"
				"Content-Length: %I64u\r\n"
				"Content-Type: %s\r\n"
				"\r\n",
				szKeepAlive,
				nBytes.QuadPart,
				szContentType);

			if (pServerContext->SendResponseHeader(strHeaders, szStatus, bKeepConnection))
				bSuccess = true;
		}
		return bSuccess;
	}

	class CServerContextBuffer
	{
	private:
		CStringA m_strContent;
		CComPtr<IHttpServerContext> m_pServerContext;
		DWORD m_dwMaxBufferBytes;
		bool m_bAutoFlush;

	public:
		CServerContextBuffer(
			IHttpServerContext* pServerContext,
			DWORD dwMaxBufferBytes = 4096,
			bool bAutoFlush = true
			) :
			m_pServerContext(pServerContext),
			m_dwMaxBufferBytes(dwMaxBufferBytes),
			m_bAutoFlush(bAutoFlush)
		{
		}
		
		~CServerContextBuffer()
		{
			if (m_bAutoFlush)
				Flush();
		}
		
		bool WriteClient(LPCSTR pvBuffer, DWORD* pdwBytes) throw()
		{
			bool bSuccess = true;

			// If old + new content is too big for buffer, flush buffer
			if (GetBufferedBytes() + *pdwBytes >= m_dwMaxBufferBytes)
				bSuccess = Flush();

			if (bSuccess)
			{
				// If new content is small enough for buffer, append to buffer
				if (*pdwBytes <= m_dwMaxBufferBytes)
					m_strContent.Append(pvBuffer, *pdwBytes);
				// Otherwise write directly to client
				else
					bSuccess = ContextWriteClient(m_pServerContext, pvBuffer, pdwBytes);
			}

			return bSuccess;
		}

		bool Flush() throw()
		{
			bool bSuccess = false;
			if (ContextWriteClient(m_pServerContext, GetBuffer(), GetBufferedBytes()))
			{
				m_strContent.Empty();
				bSuccess = true;
			}
			return bSuccess;
		}

		bool Empty() throw()
		{
			m_strContent.Empty();
			return true;
		}

		DWORD GetBufferedBytes() const throw()
		{
			return m_strContent.GetLength();
		}

		DWORD GetMaxBufferBytes() const throw()
		{
			return m_dwMaxBufferBytes;
		}

		bool SetMaxBufferBytes(DWORD dwMaxBufferBytes) throw()
		{
			bool bSuccess = true;
			if (dwMaxBufferBytes < GetBufferedBytes())
				bSuccess = Flush();
			
			m_dwMaxBufferBytes = dwMaxBufferBytes;
			return bSuccess;
		}

		bool GetAutoFlush() const throw()
		{
			return m_bAutoFlush;
		}

		bool SetAutoFlush(bool bAutoFlush = true) throw()
		{
			m_bAutoFlush = bAutoFlush;
			return true;
		}

		LPCSTR GetBuffer() throw()
		{
			return static_cast<LPCSTR>(m_strContent);
		}

	};

	class GetHttpStatusString
	{
	private:
		CHAR m_szStatus[70];

	public:

		GetHttpStatusString(DWORD dwHttpStatus) throw()
		{
			LPCSTR szStatusText = NULL;
			CDefaultErrorProvider::GetErrorText(dwHttpStatus, SUBERR_NONE, &szStatusText, NULL);
			if (szStatusText)
				sprintf(m_szStatus, "%d %s", dwHttpStatus, szStatusText);
		}

		operator LPCSTR() const throw()
		{
			return m_szStatus;
		}
	};

	inline bool SynchronousTransmitFileBody(IHttpServerContext* pServerContext, HANDLE hFile, DWORD dwMaxBufferBytes = 4096) throw()
	{
		DWORD dwBytesRead = 0;
		DWORD dwTotalBytesRead = 0;
		DWORD dwBytesWritten = 0;
		CServerContextBuffer buffer(pServerContext, dwMaxBufferBytes, false); // Don't autoflush
		char szChunk[4096]; // TODO - allow configuration of chunk size?
		do
		{
			if (ReadFile(hFile, szChunk, sizeof(szChunk), &dwBytesRead, NULL))
			{
				if (dwBytesRead)
				{
					dwBytesWritten = dwBytesRead;
					buffer.WriteClient(szChunk, &dwBytesWritten);
					if (dwBytesWritten != dwBytesRead)
						return false;

					dwTotalBytesRead += dwBytesRead;
				}
			}
			else
			{
				return false;
			}

		} while (sizeof(szChunk) == dwBytesRead);

		buffer.Flush();
		return true;
	}
	
	// Synchronous - takes absolute or relative path
	inline bool SynchronousTransmitFile(IHttpServerContext* pServerContext, LPCSTR szFile, LPCSTR szStatus = "200 OK", bool bKeepConnection = true, DWORD dwMaxBufferBytes = 4096) throw()
	{
		bool bSuccess = false;
		CStringA strFile = szFile;
		if (!IsFullPathA(strFile))
		{
			if (GetPhysicalScriptFolder(pServerContext, strFile))
				strFile += szFile;

			// TODO - call PathCanonicalize?
		}

		if (strFile.GetLength())
		{
			HANDLE hFile = ::CreateFileA(
								strFile,
								GENERIC_READ,
								FILE_SHARE_READ,
								NULL,
								OPEN_EXISTING,
								FILE_FLAG_SEQUENTIAL_SCAN,
								NULL);

			if (hFile != INVALID_HANDLE_VALUE)
			{
				CAtlFile file(hFile);
				// TODO - get Content-Type from file
				if (SynchronousTransmitFileHeaders(pServerContext, file, "text/html", szStatus, bKeepConnection))
					bSuccess = SynchronousTransmitFileBody(pServerContext, file, dwMaxBufferBytes);
			}
		}
		return bSuccess;
	}

	inline bool SynchronousTransmitFile(IHttpServerContext* pServerContext, LPCSTR szFile, DWORD dwHttpStatus = HTTP_OK, bool bKeepConnection = true, DWORD dwMaxBufferBytes = 4096) throw()
	{
		return SynchronousTransmitFile(pServerContext, szFile, GetHttpStatusString(dwHttpStatus), bKeepConnection, dwMaxBufferBytes);
	}




}; // namespace VCUE

#endif // !defined(_VCUE_SERVERCONTEXT_H___CF327AE5_EE9E_4652_8F1C_A4B15AB3D701___INCLUDED_)
