// File: HTTPListenerWSDLGen.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef HTTPLISTENERWSDLGEN_H_INCLUDED
#define HTTPLISTENERWSDLGEN_H_INCLUDED


_ATLSOAP_DECLARE_WSDL_SRF();

template <class THandler>
class CHttpListenerSDLGenerator :
	public _CSDLGenerator,
	public	IHttpServerContext,
	public CComObjectRootEx<CComSingleThreadModel>
{
private:

public:
	typedef CHttpListenerSDLGenerator<THandler> _sdlGenerator;

	unsigned	int						m_nListeningPort;


#ifndef _DEBUG
	inline BOOL CachePage()
	{
		// cache the page since it's never going to change until the DLL is unloaded
		return TRUE;
	}
#endif // _DEBUG
    HRESULT STDMETHODCALLTYPE QueryInterface( 
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject)
	{
		return E_NOTIMPL;
	}
    
    ULONG STDMETHODCALLTYPE AddRef( void)
	{
		return 1;
	}
    
    ULONG STDMETHODCALLTYPE Release( void)
	{
		return 1;
	}


	HTTP_CODE renderWSDL(IWriteStream*	pWriteStream)
	{
		CComObjectStack<THandler> handler;
		if (FAILED(InitializeSDL(&handler)))
		{
			return HTTP_FAIL;
		}

		CStencil s;
		HTTP_CODE hcErr = s.LoadFromString(s_szAtlsWSDLSrf, (DWORD) strlen(s_szAtlsWSDLSrf));
		if (hcErr == HTTP_SUCCESS)
		{
			hcErr = HTTP_FAIL;
			if (s.ParseReplacements(this) != false)
			{

				s.FinishParseReplacements();

				SetStream(pWriteStream);
				SetWriteStream(pWriteStream);
				SetHttpServerContext(this);

				ATLASSERT( s.ParseSuccessful() != false );

				hcErr = s.Render(this, pWriteStream);
			}
		}

		return hcErr;
	}

	const char * GetHandlerName()
	{
		return THandler::ServiceName();
	}

// IHttpServerContext pseudo-implementation
	LPCSTR GetRequestMethod(){return NULL;}
	LPCSTR GetQueryString(){return NULL;}
	LPCSTR GetPathInfo(){return NULL;}
	LPCSTR GetPathTranslated(){return NULL;}
	LPCSTR GetScriptPathTranslated(){return NULL;}
	DWORD GetTotalBytes(){return NULL;}
	DWORD GetAvailableBytes(){return NULL;}
	BYTE *GetAvailableData(){return NULL;}
	LPCSTR GetContentType(){return NULL;}
	BOOL GetServerVariable(LPCSTR pszVariableName,
									LPSTR pvBuffer, DWORD *pdwSize)
	{
		LPCSTR		szVal = NULL;
		char		hostName[MAX_PATH];
		CStringA	szFullHostPrefix;
		ATLASSERT( pdwSize );

		::gethostname( hostName, MAX_PATH);

		// Hack to make it behave like a regular HTTP app
		szFullHostPrefix.Format("%s:%d/", hostName, m_nListeningPort);

		if( strcmp(pszVariableName, "URL") == 0)
			szVal	=	"Invoke";
		else if( strcmp(pszVariableName, "SERVER_NAME") == 0)
			szVal	=	szFullHostPrefix;
		else if( strcmp(pszVariableName, "PROTOCOL")== 0)
			szVal	=	"http";

		if( szVal )
		{
			if( strlen(szVal) < *pdwSize )
			{
				strcpy( pvBuffer, szVal );
				return TRUE;
			}
			*pdwSize	=	(DWORD)strlen(szVal) + 1;
		}

		return FALSE;
	}
	BOOL GetImpersonationToken(HANDLE * ){return FALSE;}
	BOOL WriteClient(void *, DWORD *){return FALSE;}
	BOOL AsyncWriteClient(void *, DWORD *){	return FALSE;}
	BOOL ReadClient(void *, DWORD *){return FALSE;}
	BOOL AsyncReadClient(void *, DWORD *){return FALSE;}
	BOOL SendRedirectResponse(LPCSTR ){return FALSE;}
	BOOL SendResponseHeader(LPCSTR , LPCSTR , BOOL ){return FALSE;}
	BOOL DoneWithSession(DWORD ){return FALSE;}
	BOOL RequestIOCompletion(PFN_HSE_IO_COMPLETION , DWORD *){return FALSE;}
	BOOL TransmitFile(HANDLE , PFN_HSE_IO_COMPLETION , void *, 
		LPCSTR , DWORD , DWORD ,void *, DWORD , void *,DWORD , DWORD ){return FALSE;}
    BOOL AppendToLog(LPCSTR , DWORD* ){return FALSE;}
	BOOL MapUrlToPathEx(LPCSTR , DWORD , HSE_URL_MAPEX_INFO *){return FALSE;}





}; // class CSDLGenerator



#endif // HTTPLISTENERWSDLGEN_H_INCLUDED
