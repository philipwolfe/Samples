// ShowLocalized.cpp : Defines the entry point for the DLL application.
// (c) 2000 Microsoft Corporation
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"

#include <mlang.h>

#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Accept.h"
#include "..\VCUE\VCUE_Locale.h"
#include "..\VCUE\VCUE_API.h"
#include "..\VCUE\VCUE_AtlServerSample.h"
using namespace VCUE;

#include "resource.h"

VCUE::CModule _Module;

// For custom assert and trace handling with WebDbg
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _Module.DllMain(dwReason, lpReserved); 
}

	// Use lowercase strings
	// Order doesn't matter much, but put frequently used languages near top for performance
	static const char* SupportedLanguages[] = 
	{
		"zh-cn",	// Chinese (Simplified - PR China)
		"zh-tw",	// Traditonal Chinese (Taiwan)
		"da",		// Danish
		"nl",		// Dutch
		"en-us",	// English (US)
		"en-gb",	// English (GB)
		"fi",		// Finish
		"fr",		// French
		"de",		// German
		"it",		// Italian
		"ja",		// Japanese
		"ko",		// Korean
		"no",		// Norwegian (Bokmal)
		"pt-br",	// Portugese (Brazil)
		"pt",		// Portugese (Portugal)
		"ro",		// Romanian
		"ru",		// Russian
		"sl",		// Slovenian
		"es",		// Spanish
		"sv",		// Swedish
		NULL		// terminator
	};




class CShowLocalized : 
	public CCustomRequestHandler<CShowLocalized>
{
public:

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	CComPtr<IMultiLanguage> m_spMultiLanguage;
	CAcceptCollection m_Languages;
	CUserLocale m_UserLocale;
	LanguageMatchType m_matchBest;

	HTTP_CODE ValidateAndExchange()
	{
		// Create instance of multilanguage object
		HRESULT hr = m_spMultiLanguage.CoCreateInstance(__uuidof(CMultiLanguage));
		if (FAILED(hr))
			return ServerError();

		// Default to English locale
		m_UserLocale.SetDefaultEnglishLocale();

		m_matchBest = GetUserLocale(m_spMultiLanguage, SupportedLanguages, m_spServerContext, m_Languages, m_UserLocale);

		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	bool WriteLocaleInfo(const char* szTitle, LCID lcid)
	{
		m_HttpResponse << "<h2>" << szTitle << "</h2>\n";
		m_HttpResponse << "<table>\n<tr><th>Locale ID</th><th>RFC 1766</th><th>Locale Name</th></tr>\n";

		WriteLocaleInfo(lcid);

		m_HttpResponse << "</table>\n";

		return true;
	}

	bool WriteLocaleInfo(LCID lcid)
	{
		USES_CONVERSION;
		RFC1766INFO info = {0};
		
		HRESULT hr = m_spMultiLanguage->GetRfc1766Info(lcid, &info);
		if (SUCCEEDED(hr))
			m_HttpResponse << "<tr><td>" << info.lcid << "</td><td>" << W2CA(info.wszRfc1766) << "</td><td>" << W2CA(info.wszLocaleName) << "</td></tr>\n";
		else
			m_HttpResponse << "<tr><td>" << lcid << "</td><td>Unknown</td><td>Unknown</td></tr>\n";

		return true;
	}

	bool WriteSupportedLocales(const char* arrSupportedLocales[])
	{
		m_HttpResponse << "<h2>The following locales are supported by the server:</h2>\n";
		m_HttpResponse << "<table>\n<tr><th>Locale ID</th><th>RFC 1766</th><th>Locale Name</th></tr>\n";

		LCID lcid = 0;
		const char** ppsz = arrSupportedLocales;
		while (*ppsz)
		{
			if (SUCCEEDED(m_spMultiLanguage->GetLcidFromRfc1766(&lcid, CComBSTR(*ppsz))))
				WriteLocaleInfo(lcid);

			++ppsz;
		}

		m_HttpResponse << "</table>\n";

		return true;
	}

	HTTP_CODE OnShowLocalizedText()
	{
		CStringA str;
		if (LoadUtf8FromUnicodeResource(_AtlBaseModule.GetModuleInstance(), IDS_FOOTER, m_UserLocale.GetLocale(), str))
			m_HttpResponse << "<p>" << str << "</p>\n";
		else
			m_HttpResponse << "<p>Failed to load localized string from resource.</p>\n";

		if (SUCCEEDED(GetUtf8SystemTime(m_UserLocale.GetLocale(), str)))
			m_HttpResponse << "<p>" << str << "</p>\n";
		else
			m_HttpResponse << "<p>Failed to get localized system time.</p>\n";
		
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowLocales()
	{
		if (m_matchBest == lmNoMatch)
			m_HttpResponse << 
			"<p>The language preference of the client "
			"could not be matched by the server. "
			"The languages displayed here are the server's default settings.</p>";

		WriteLocaleInfo("This locale was chosen by the server:", m_UserLocale.GetServerLocale());
		WriteLocaleInfo("This locale was specified by the client and matches the language of the locale above:", m_UserLocale.GetClientLocale());

		WriteSupportedLocales(SupportedLanguages);
		
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowLocalized Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowLocalized)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowLocalizedText", OnShowLocalizedText)
		REPLACEMENT_METHOD_ENTRY("ShowLocales", OnShowLocales)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowLocalized)
END_HANDLER_MAP()
