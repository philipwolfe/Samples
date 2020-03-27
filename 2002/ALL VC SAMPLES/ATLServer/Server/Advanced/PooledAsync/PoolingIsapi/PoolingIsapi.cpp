// PoolingIsapi.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include <commonPool.h>
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif
[ module(name="PoolingIsapi", type="dll") ];
[ emitidl(restricted) ];

typedef CIsapiExtension<> ExtensionType;

// The ATL Server ISAPI extension


class CSoapPoolingExtension : public CIsapiExtension<>
{
protected:
	CThreadPoolService			m_soapPoolSvc;
	
public:
	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer) throw()
	{
		BOOL	bRet	=	CIsapiExtension<>::GetExtensionVersion( pVer );

		if( bRet )
			m_soapPoolSvc.Initialize(4);

		return bRet;
	}
    virtual HRESULT STDMETHODCALLTYPE QueryService(
        REFGUID guidService,
        REFIID riid,
        void **ppvObject) throw()
    {
        if (!ppvObject)
            return E_POINTER;

        if (InlineIsEqualGUID(guidService, __uuidof(IThreadPoolService)))
		{
			return m_soapPoolSvc.QueryInterface(riid, ppvObject);
		}
        else 
			return CIsapiExtension<>::QueryService(guidService, riid, ppvObject);
    }

};


CSoapPoolingExtension		theExtension;
// Delegate ISAPI exports to theExtension
//
extern "C" DWORD WINAPI HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
{
	ATLTRACE("HttpExtensionProc\n");
	
	return theExtension.HttpExtensionProc(lpECB);
}

extern "C" BOOL WINAPI GetExtensionVersion(HSE_VERSION_INFO* pVer)
{
	ATLTRACE("GetExtensionVersion\n");
	return theExtension.GetExtensionVersion(pVer);
}

extern "C" BOOL WINAPI TerminateExtension(DWORD dwFlags)
{
	ATLTRACE("TerminateExtension\n");
	return theExtension.TerminateExtension(dwFlags);
}
