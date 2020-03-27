// SStateIsapi.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"

// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "..\Include\persist.h"
[ module(name="SState", type="dll") ];
[ emitidl(restricted) ];



class CSOAPStateExtension : public CIsapiExtension<>
{
protected:
	CSOAPSrvStorageService<CIsapiExtension<>::extWorkerType>		m_soapStorageSvc;
	
public:
    virtual HRESULT STDMETHODCALLTYPE QueryService(
        REFGUID guidService,
        REFIID riid,
        void **ppvObject) throw()
    {
        if (!ppvObject)
            return E_POINTER;

        if (InlineIsEqualGUID(guidService, __uuidof(ISOAPSrvStorageService)))
		{
			return m_soapStorageSvc.QueryInterface(riid, ppvObject);
		}
        else 
			return CIsapiExtension<>::QueryService(guidService, riid, ppvObject);
    }

	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer) throw()
	{
		BOOL	bRet;

		/*char b[24];
		sprintf(b, "%d", GetCurrentProcessId() );
		MessageBox( NULL, b, b, MB_OK | MB_SERVICE_NOTIFICATION);*/
		bRet	=	CIsapiExtension<>::GetExtensionVersion( pVer );

		if( bRet )
			m_soapStorageSvc.Initialize();

		return bRet;
	}



};


// The ATL Server ISAPI extension containing the SOAP Server Storage Service
CSOAPStateExtension		theExtension;



// Delegate ISAPI exports to theExtension
//
extern "C" DWORD WINAPI HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
{
	return theExtension.HttpExtensionProc(lpECB);
}

extern "C" BOOL WINAPI GetExtensionVersion(HSE_VERSION_INFO* pVer)
{
	return theExtension.GetExtensionVersion(pVer);
}

extern "C" BOOL WINAPI TerminateExtension(DWORD dwFlags)
{
	return theExtension.TerminateExtension(dwFlags);
}
