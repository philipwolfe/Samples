// Friendly.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#pragma once

#include <httpfilt.h>
#include <atlcoll.h>
#include <atlstr.h>
#include <atlrx.h>
#include <atlfile.h>
#include <atlpath.h>
#include <atlutil.h>

class CFriendly
{
public:
    CFriendly() throw()
    {
    }

    ~CFriendly() throw()
    {
    }

    HRESULT Add(LPCSTR szRX, LPCSTR szRepl) throw()
    {
		CAutoPtr<Mapping> spMapping;
		ATLTRY(spMapping.Attach(new Mapping));
		if (spMapping == NULL)
			return E_OUTOFMEMORY;

        spMapping->m_rx.Parse(szRX);

		_ATLTRY
		{
			spMapping->m_strReplacement = szRepl;
			m_aMappings.Add(spMapping);
		}
		_ATLCATCHALL()
		{
			return E_OUTOFMEMORY;
		}

        return S_OK;
    }

    HRESULT Render(LPCSTR szURL, CStringA& strOut) throw()
    {
		ATLASSERT(szURL);
        if (szURL == NULL)
            return E_POINTER;

        for (size_t i = 0; i < m_aMappings.GetCount(); i++)
        {
            Context context;
			Mapping* pMapping = m_aMappings[i];

            BOOL bRet = pMapping->m_rx.Match(szURL, &context);
            if (bRet)
				return RenderMatch(context, pMapping->m_strReplacement, strOut);
        }
        return E_FAIL;
    }

private:
	typedef CAtlRegExp<CAtlRECharTraitsA> RegExp;
	typedef CAtlREMatchContext<CAtlRECharTraitsA> Context;

	struct Mapping
	{
	    RegExp m_rx;
		CStringA m_strReplacement;
	};

	HRESULT RenderMatch(Context& context, CStringA strReplacement, CStringA& strOut) throw()
	{
		LPCSTR szReplacement = strReplacement;
		_ATLTRY
		{
			strOut.Preallocate(strReplacement.GetLength() + (int)(context.m_Match.szEnd - context.m_Match.szStart));
			int nCopied = 0;
			while (nCopied < strReplacement.GetLength())
			{
				// find the next '$'
				int nIndex = strReplacement.Find('$', nCopied);
				if (nIndex == -1)
				{
					// no '$' characters left. append the rest of the replacement text
					strOut.Append(szReplacement+nCopied, strReplacement.GetLength()-nCopied);
					nCopied = strReplacement.GetLength();
				}
				else
				{
					if (nIndex > nCopied)
					{
						// append the static text up to the next '$'
						strOut.Append(szReplacement+nCopied, nIndex-nCopied);
						nCopied = nIndex;
					}

					// get the character after the '$'
					if (++nCopied == strReplacement.GetLength())
						return E_FAIL;

					char ch = strReplacement[nCopied++];
					if (!isdigit(ch))
					{
						// not a regular expression replacement.
						// treat the character after the '$' as a literal character
						// thus '$$' -> '$'
						strOut += ch;
					}
					else
					{
						// replace the $n with the regular expression match
						// specified by the number n
						UINT nWhich = ch - '0';
						if (nWhich >= context.m_uNumGroups)
							return E_FAIL;

						Context::MatchGroup match;
						context.GetMatch(nWhich, &match);
						strOut.Append(match.szStart, (int)(match.szEnd-match.szStart));
					}
				}
			}

			return S_OK;
		}
		_ATLCATCHALL()
		{
			return E_OUTOFMEMORY;
		}
	}

	CAutoPtrArray<Mapping> m_aMappings;
};

class CFriendlyUrlFilter
{
public:
    BOOL GetFilterVersion(HINSTANCE hFilterDll, HTTP_FILTER_VERSION* pVer) throw()
    {
		_ATLTRY
		{
			strcpy(pVer->lpszFilterDesc, "Friendly URL remapping filter");
			pVer->dwFlags =
				SF_NOTIFY_PREPROC_HEADERS |
				SF_NOTIFY_ORDER_DEFAULT |
				SF_NOTIFY_NONSECURE_PORT;

			// load friendly.cfg from the same directory as the filter dll
			CPathA path;

			if (GetModuleFileName(hFilterDll, CStrBufA(path, MAX_PATH), MAX_PATH) == 0)
				return FALSE;

			if (!path.RemoveFileSpec())
				return FALSE;

			path += "\\friendly.cfg";

			if (!path.FileExists())
				return FALSE;

			return GetConfigFromFile(path);
		}
		_ATLCATCHALL()
		{
			return FALSE;
		}
    }

    DWORD HttpFilterProc(HTTP_FILTER_CONTEXT* pfc, DWORD notificationType, LPVOID pvNotification) throw()
    {
        switch (notificationType)
        {
        case SF_NOTIFY_PREPROC_HEADERS:
            return PreprocHeaders(pfc, (HTTP_FILTER_PREPROC_HEADERS *) pvNotification);
            break;
        default:
            break;
        }

        return SF_STATUS_REQ_NEXT_NOTIFICATION;
    }

    BOOL TerminateFilter(DWORD dwFlags) throw()
    {
        return TRUE;
    }

private:
    BOOL GetConfigFromFile(LPCSTR szPath) throw()
    {
        CAtlFile file;

		if (FAILED(file.Create(szPath, GENERIC_READ, FILE_SHARE_READ, OPEN_EXISTING)))
            return FALSE;

        ULONGLONG nLen;
        file.GetSize(nLen);
        if (nLen > (DWORD)-1)
            return FALSE;

        DWORD dwLen = (DWORD)nLen;
		CHeapPtr<char> szBuf;
		if (!szBuf.Allocate(dwLen+1))
			return FALSE;

        if (FAILED(file.Read(szBuf, dwLen)))
			return FALSE;

        szBuf[dwLen] = '\0';
        LPSTR szCur = szBuf;

		do
		{
			LPCSTR szRX = GetNextLine(szCur);
			if (!szRX)
				return TRUE;

			LPCSTR szRepl = GetNextLine(szCur);
			if (!szRepl)
				return FALSE;

			m_friend.Add(szRX, szRepl);
		} while (szCur);

        return TRUE;
    }

	LPCSTR GetNextLine(LPSTR& szCur) throw()
	{
		if (szCur == NULL || *szCur == 0)
			return NULL;

		LPSTR szStart = NULL;

		do
		{
			// ignore comments (single-line C++ style. no whitespace allowed though)
			if (szCur[0] != '/' || szCur[1] != '/')
				szStart = szCur;

			// look for end of line
	        szCur = strpbrk(szCur,"\r\n");
			if (szCur == NULL)
			{
				// last line. return what we have, if anything
				return szStart;
			}

			// eat all the end-of line characters and blank lines,
			// positioning at the beginning of the next non-empty line
			// for the next call
			while (*szCur == '\r' || *szCur == '\n')
				*szCur++ = 0;

			if (*szCur == 0)
				szCur = NULL;
		} while (!szStart);

		return szStart;
	}

    DWORD PreprocHeaders(HTTP_FILTER_CONTEXT* pfc, HTTP_FILTER_PREPROC_HEADERS* pfph) throw()
    {
        CString strUrl;
        if (GetHeader(pfc, pfph, "URL", strUrl))
		{
			CStringA strNewUrl;
			if (SUCCEEDED(m_friend.Render(strUrl, strNewUrl)))
				pfph->SetHeader(pfc, "URL", const_cast<LPSTR>(static_cast<LPCSTR>(strNewUrl)));
		}

        return SF_STATUS_REQ_NEXT_NOTIFICATION;
    }

	BOOL GetHeader(HTTP_FILTER_CONTEXT* pfc, HTTP_FILTER_PREPROC_HEADERS* pfph, LPSTR szName, CStringA& strValue)
	{
		_ATLTRY
		{
			DWORD dwLen = 0;
			pfph->GetHeader(pfc, szName, NULL, &dwLen);

			if (dwLen == 0)
				return FALSE;

			CStrBufA buf(strValue, dwLen, CStrBufA::SET_LENGTH);
			return pfph->GetHeader(pfc, szName, buf, &dwLen);
		}
		_ATLCATCHALL()
		{
			return FALSE;
		}
	}

    CFriendly m_friend;
};
