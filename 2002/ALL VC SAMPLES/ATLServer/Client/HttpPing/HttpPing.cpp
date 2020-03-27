// File: HttpPing.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"


const TCHAR* HTTP_PING_INI = _T(".\\HttpPing.ini");


bool use_proxy = 0;
TCHAR proxyName[128];
int proxyPort = 80;


using namespace std;

#ifdef UNICODE
#define _tcout wcout
#else
#define _tcout cout
#endif

void LoadSettings()
{
	CAtlFile inifile;
	if (FAILED(inifile.Create( HTTP_PING_INI, STANDARD_RIGHTS_READ, FILE_SHARE_READ, OPEN_EXISTING )))
	{
		// create a default INI file if none is found
		if (SUCCEEDED(inifile.Create( HTTP_PING_INI, GENERIC_WRITE, FILE_SHARE_WRITE, CREATE_NEW )))
		{
			char default_ini[] = "[settings]\r\nproxy=proxyserver\r\nproxyport=80\r\nuse_proxy=false";
			inifile.Write( default_ini, sizeof(default_ini) );
			inifile.Close();
		}
	}

	TCHAR str[128];

	GetPrivateProfileString( _T("settings"), _T("use_proxy"), _T("false"), str, 128, HTTP_PING_INI );
	if (lstrcmpi( str, _T("true") ) == 0)
		use_proxy = TRUE;
	else
		use_proxy = FALSE;

	GetPrivateProfileString( _T("settings"), _T("proxy"), _T(""), proxyName, 128, HTTP_PING_INI );

	GetPrivateProfileString( _T("settings"), _T("proxyport"), _T("80"), str, 128, HTTP_PING_INI );
	proxyPort = _ttoi(str);
}


int _tmain(int argc, TCHAR* argv[])
{
	LoadSettings();

	if (argc < 2)
	{
		_tcout << endl << endl << _T("USAGE : HttpPing <URL>") << endl << endl;
		_tcout << _T("  (See HttpPing.ini for advanced settings)") << endl << endl;
		return 0;
	}

	CString url = argv[1];

	int doubleSlash = url.Find( _T("//") );
	if (doubleSlash > 0)
	{
		if (url.Left(7).CompareNoCase( _T("http://") ) != 0)
		{
			url = url.Mid( doubleSlash, url.GetLength() - doubleSlash );
			url = _T("http:") + url;
		}
	}
	else
		url = _T("http://") + url;

	CAtlHttpClient client;

	_tcout << endl;
	_tcout << _T("url = '") << static_cast<LPCTSTR>(url) << _T("'") << endl;
	if (use_proxy)
	{
		_tcout << _T("proxy server: ") << proxyName << _T(" : ") << proxyPort << endl;
		client.SetProxy( proxyName, proxyPort );
	}

	_tcout << endl;

	DWORD timeStart = timeGetTime();
	if (client.Navigate( url ))
	{
		DWORD timeEnd = timeGetTime();

		DWORD size;
		client.GetRawResponseHeader( 0, &size );
		BYTE* buf = new BYTE[size];
		memset( buf, 0, size );

		if (client.GetRawResponseHeader( buf, &size ))
		{
			_tcout << _T("------- HTTP response headers  ----------") << endl;

			// we use 'cout' instead of '_tcout' here because the headers are ANSI
			cout << buf << endl;

			_tcout << _T("-----------------------------------------") << endl;
		}

		delete [] buf;

		float timeElapsed = (float)(timeEnd - timeStart) / 1000.0f;
		_tcout << _T("elapsed time: ") << timeElapsed << _T(" seconds") << endl;
	}
	else
	{
		_tcout << _T("request failed - status code ") << client.GetStatus() << endl;
		_tcout << _T("(See HttpPing.ini for advanced options)") << endl;
	}


	return 0;
}

