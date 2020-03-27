// VCUE_Response.h
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

#if !defined(_VCUE_RESPONSE_H___9059CACB_EB85_4E53_91D5_8A9C941141DD___INCLUDED_)
#define _VCUE_RESPONSE_H___9059CACB_EB85_4E53_91D5_8A9C941141DD___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "VCUE_ServerContext.h"

namespace VCUE
{
	inline bool SynchronousTransmitFileBody(CHttpResponse& theResponse, HANDLE hFile) throw()
	{
		DWORD dwBytesRead = 0;
		DWORD dwTotalBytesRead = 0;
		DWORD dwBytesWritten = 0;
		char szChunk[4096]; // TODO - allow configuration of chunk size?
		do
		{
			if (ReadFile(hFile, szChunk, sizeof(szChunk), &dwBytesRead, NULL))
			{
				if (dwBytesRead)
				{
					theResponse.WriteStream(szChunk, dwBytesRead, &dwBytesWritten);
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

		return true;
	}
	
	// Takes absolute or relative path
	inline bool SynchronousTransmitFile(CHttpResponse& theResponse, LPCSTR szFile) throw()
	{
		bool bSuccess = false;
		CStringA strFile = szFile;
		if (!IsFullPathA(strFile))
		{
			IHttpServerContext	*pServerContext = NULL;
			if( SUCCEEDED( theResponse.GetServerContext( &pServerContext ) ) )
			{
				if (GetPhysicalScriptFolder(pServerContext, strFile))
					strFile += szFile;
				pServerContext->Release();
			}

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
				// TODO - get Content-Type from file and set header
				bSuccess = SynchronousTransmitFileBody(theResponse, file);
			}
		}
		return bSuccess;
	}

} // namespace VCUE

#endif // !defined(_VCUE_RESPONSE_H___9059CACB_EB85_4E53_91D5_8A9C941141DD___INCLUDED_)
