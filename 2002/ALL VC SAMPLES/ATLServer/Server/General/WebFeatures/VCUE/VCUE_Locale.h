// VCUE_Locale.h
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

#if !defined(_VCUE_LOCALE_H___23343755_6CE2_4026_BE11_4488555CD8B3___INCLUDED_)
#define _VCUE_LOCALE_H___23343755_6CE2_4026_BE11_4488555CD8B3___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "VCUE_Accept.h"
#include "VCUE_ServerContext.h"

namespace VCUE
{
	// Exact matching
	//			"en"	"en-gb"		"en-us"
	//	"en"	  1		   0		   0
	//	"en-gb"	  0		   1		   0
	//	"en-us"	  0		   0		   1
	//
	// Asymmetric matching
	//			"en"	"en-gb"		"en-us"
	//	"en"	  1		   0		   0
	//	"en-gb"	  1		   1		   0
	//	"en-us"	  1		   0		   1
	//
	// Symmetric matching
	//			"en"	"en-gb"		"en-us"
	//	"en"	  1		   1		   1
	//	"en-gb"	  1		   1		   0
	//	"en-us"	  1		   0		   1
	//
	// Primary matching
	//			"en"	"en-gb"		"en-us"
	//	"en"	  1		   1		   1
	//	"en-gb"	  1		   1		   1
	//	"en-us"	  1		   1		   1

	// LanguageMatch
	//			"en"	"en-gb"		"en-us"		*
	//	"en"	  e		   s		   s		p
	//	"en-gb"	  a		   e		   p		p
	//	"en-us"	  a		   p		   e		p

	enum LanguageMatchType { lmNoMatch = 0, lmPrimary, lmSymmetric, lmAsymmetric, lmExact};

	// Use this function to determine whether HTTP language tags match.
	inline LanguageMatchType LanguageMatch(const char* pszLanguage1, const char* pszLanguage2) throw()
	{
		ATLASSERT(pszLanguage1);
		ATLASSERT(pszLanguage2);

		if (*pszLanguage1 == '*' || *pszLanguage2 == '*')
			return lmPrimary;

		while (*pszLanguage1 && *pszLanguage2 && *pszLanguage1 != '-' && *pszLanguage2 != '-')
		{
			if (*pszLanguage1 != *pszLanguage2)
				return lmNoMatch;
			++pszLanguage1;
			++pszLanguage2;
		}

		if ((*pszLanguage1 == '\0') && (*pszLanguage2 == '\0'))
			return lmExact;

		if ((*pszLanguage1 == '\0') && (*pszLanguage2 == '-'))
			return lmAsymmetric;

		if ((*pszLanguage1 == '-') && (*pszLanguage2 == '\0'))
			return lmSymmetric;

		while (*pszLanguage1 && *pszLanguage2)
		{
			if (*pszLanguage1 != *pszLanguage2)
				return lmPrimary;

			++pszLanguage1;
			++pszLanguage2;
		}

		if ((*pszLanguage1 == '\0') && (*pszLanguage2 == '\0'))
			return lmExact;

		return lmNoMatch;
	}

	class CUserLocale
	{
	private:
		// This is the closest locale supported by the server that matches one of the 
		// languages specified by the client's Accept-Language request header.
		// Use this locale for keying into predefined content.
		LCID m_lcidServer;

		// This is the locale specified by the client's Accept-Language request header
		// that corresponds to the locale in lcidServer.
		// Use this locale for dynamically generated content (formatting dates, times, currencies, etc.)
		LCID m_lcidClient;

		// In many cases, lcidServer and lcidClient will be identical.
		// In some cases, one locale may be more generic than the other
		// (e.g. lcidServer could be the default English locale, lcidClient could be US English)
		// Be careful mixing predefined content with dynamically generated content if you decide
		// to use different locales.
	public:
		CUserLocale(LCID lcidServer = MAKELCID(MAKELANGID(LANG_ENGLISH, SUBLANG_NEUTRAL), SORT_DEFAULT))
			: m_lcidServer(lcidServer), m_lcidClient(lcidServer) {}

		CUserLocale(LCID lcidServer, LCID lcidClient)
			: m_lcidServer(lcidServer), m_lcidClient(lcidClient) {}

		LCID GetServerLocale() const throw()
		{
			return m_lcidServer;
		}

		bool SetServerLocale(LCID lcid) throw()
		{
			m_lcidServer = lcid;
			return true;
		}

		LCID GetClientLocale() const throw()
		{
			return m_lcidClient;
		}

		bool SetClientLocale(LCID lcid) throw()
		{
			m_lcidClient = lcid;
			return true;
		}

		LCID GetLocale() const throw()
		{
			return m_lcidServer;
		}

		bool SetLocale(LCID lcid) throw()
		{
			m_lcidServer = lcid;
			m_lcidClient = lcid;
			return true;
		}

		bool SetDefaultEnglishLocale() throw()
		{
			return SetLocale(MAKELCID(MAKELANGID(LANG_ENGLISH, SUBLANG_NEUTRAL), SORT_DEFAULT));
		}
	};

	
	inline LanguageMatchType GetUserLocale(IMultiLanguage* pMultiLanguage, const char* arrSupportedLanguages[], const char* pszClientLanguage, CUserLocale& theLocale) throw()
	{
		ATLASSERT(pMultiLanguage);

		// These vars ensure that we don't change theLocale unless everything succeeds.
		LCID lcidClient = 0;
		LCID lcidServer = 0;

		// Get the client locale from the multi-language object
		HRESULT hr = pMultiLanguage->GetLcidFromRfc1766(&lcidClient, CComBSTR(pszClientLanguage));
		if (SUCCEEDED(hr))
		{
			const char** ppsz = arrSupportedLanguages;
			
			const char* pszBestMatch = NULL;
			LanguageMatchType matchBest = lmNoMatch;

			while (*ppsz)
			{
				LanguageMatchType matchCurrent = LanguageMatch(pszClientLanguage, *ppsz);
				if (matchCurrent > matchBest)	// Update match if better than current
				{
					matchBest = matchCurrent;
					pszBestMatch = *ppsz;
				}

				if (lmExact == matchBest)		// Stop now if we have exact match
				{
					if (SUCCEEDED(pMultiLanguage->GetLcidFromRfc1766(&lcidServer, CComBSTR(pszBestMatch))))
					{
						theLocale.SetClientLocale(lcidClient);
						theLocale.SetServerLocale(lcidServer);
						return matchBest;
					}
				}

				++ppsz;
			}

			if (lmNoMatch != matchBest)
			{
				if (SUCCEEDED(pMultiLanguage->GetLcidFromRfc1766(&lcidServer, CComBSTR(pszBestMatch))))
				{
					theLocale.SetClientLocale(lcidClient);
					theLocale.SetServerLocale(lcidServer);
					return matchBest;
				}
			}
		}

		return lmNoMatch;
	}

	inline LanguageMatchType GetUserLocale(IMultiLanguage* pMultiLanguage, const char* arrSupportedLanguages[], IHttpServerContext* pServerContext, CAcceptCollection& languages, CUserLocale& theLocale /*, LanguageMatchType matchTerminator = lmAsymmetric*/) throw()
	{
		LanguageMatchType matchBest = lmNoMatch;
		CUserLocale localeBest;

		CStringA strAccept;
		BOOL bSuccess = GetServerVariable(pServerContext, "HTTP_ACCEPT_LANGUAGE", strAccept);
		if (bSuccess && strAccept.GetLength())
		{
			languages.Parse(strAccept);

			// Languages are ordered with user's favorites first
			// Languages with a priority of zero are disallowed
			if (languages.GetCount())
			{
				POSITION pos = languages.GetHeadPosition();
				while (pos)
				{
					const CAcceptItem& item = languages.GetNext(pos);
					if (!item.GetPriority())
						break;

					LanguageMatchType matchCurrent = GetUserLocale(pMultiLanguage, arrSupportedLanguages, item.GetValue(), theLocale);
					if (matchCurrent >= lmPrimary) // TODO - consider comparing against lmAsymmetric or exposing termination condition as a parameter
						return matchCurrent;

					if (matchCurrent > matchBest)
					{
						matchBest = matchCurrent;
						localeBest = theLocale;
					}
				}
			}
		}

		if (lmNoMatch != matchBest)
		{
			theLocale = localeBest;
		}

		return matchBest;
	}

	inline LanguageMatchType GetUserLocale(const char* arrSupportedLanguages[], IHttpServerContext* pServerContext, CUserLocale& theLocale /*, LanguageMatchType matchTerminator = lmAsymmetric*/) throw()
	{
		// Consider calling a different overload if you need to reuse the multilanguage
		// object or the collection of languages from the Accept-Language request header.
		CComPtr<IMultiLanguage> spMultiLanguage;
		HRESULT hr = spMultiLanguage.CoCreateInstance(__uuidof(CMultiLanguage));
		if (FAILED(hr))
			return lmNoMatch;

		CAcceptCollection languages;
		return GetUserLocale(spMultiLanguage, arrSupportedLanguages, pServerContext, languages, theLocale/*, matchTerminator*/);
	}

	inline int UnicodeToUtf8(const CStringW& strUnicode, CStringA& strUtf8)
	{
		int nCharacters = AtlUnicodeToUTF8(strUnicode, strUnicode.GetLength(), NULL, 0);
		char* szBuffer = strUtf8.GetBufferSetLength(nCharacters + 1);
		nCharacters = AtlUnicodeToUTF8(strUnicode, strUnicode.GetLength(), szBuffer, nCharacters);
		strUtf8.ReleaseBuffer(nCharacters);
		return nCharacters;
	}

	inline bool LoadUtf8FromUnicodeResource(HINSTANCE hInst, UINT nID, LCID lcid, CStringA& str) throw()
	{
		bool bSuccess = false;

		CStringW strUnicode;
		if (strUnicode.LoadString(hInst, nID, LANGIDFROMLCID(lcid)))
		{
			if (strUnicode.GetLength() == 0)
			{
				str = "";
				bSuccess = true;
			}
			else if (UnicodeToUtf8(strUnicode, str))
				bSuccess = true;
		}

		return bSuccess;
	}

	inline HRESULT GetUtf8SystemTime(LCID lcid, CStringA& strTime)
	{
		HRESULT hr = E_UNEXPECTED;
		SYSTEMTIME st = {0};
		GetSystemTime(&st);

		DATE date = 0;
		if (SystemTimeToVariantTime(&st, &date))
		{
			CComBSTR bstr;
			hr = VarBstrFromDate(date, lcid, 0, &bstr);
			if (SUCCEEDED(hr))
			{
				if (UnicodeToUtf8(static_cast<BSTR>(bstr), strTime))
					hr = S_OK;
				else
					hr = E_FAIL;
			}
		}
		return hr;
	}

}; // namespace VCUE

#endif // !defined(_VCUE_LOCALE_H___23343755_6CE2_4026_BE11_4488555CD8B3___INCLUDED_)
