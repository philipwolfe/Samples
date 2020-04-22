#pragma once

#include "resource1.h"
#include <atlstencil.h>
#include <atlcoll.h>

class CXMI : public  ITagReplacerImpl<CXMI>, 
			 public  CComObjectRootEx<CComSingleThreadModel>	
{
private:
	typedef CAtlList<CString>	KEY_LIST;

	IWriteStream	*m_stream;
	KEY_LIST		m_keys;
	POSITION		m_startKey;
	POSITION		m_currentKey;
public:
	CString m_action;
	CString m_rev;
	CString m_to;
	CString m_messageID;
	CString m_service;
	CString m_documentType;
	CString m_method;
	CString m_genResponse;	
	CString m_instance;
	CString m_cluster;
	CString m_puid;
	CString m_request;

public:
	BEGIN_COM_MAP(CXMI)				
		COM_INTERFACE_ENTRY(ITagReplacer)
	END_COM_MAP()

	CXMI() : m_stream(NULL)
	{		
		// generate a message ID
		GUID guid;
		ZeroMemory(&guid, sizeof(GUID));
		HRESULT hr = CoCreateGuid(&guid);

		OLECHAR szGUID[64];
		if (::StringFromGUID2(guid, szGUID, 64))
		{
			m_messageID = szGUID;			
		}		

		// set some defaults
		m_genResponse = "always";
		m_instance	  = "0";
		m_cluster	  = "0";

		// TODO what is this number?
		m_puid		  = "2991";
	}


	virtual ~CXMI(void)
	{
	}

	void SetServer(LPCSTR server)
	{
		m_to = server;
	}

	const CString& GetServer()
	{
		return m_to;
	}

	const CString& GetService()
	{
		return m_service;
	}

	void SetPUID(LPCSTR puid)
	{
		m_puid = puid;
	}

	bool GenerateDocument()
	{
		// need to call SetStream first
		ATLASSERT(m_stream);
		if (!m_stream)
		{
			return false;
		}
				
		// generate the log
		CStencil stencil;

		// see whether we should generate from our default file or from one the user provides
		HTTP_CODE srfLoaded = stencil.LoadFromResource(GetModuleHandle(NULL), IDR_XMI, "SRF");		
		if (srfLoaded != HTTP_SUCCESS)
		{			
			return false;
		}
		
		stencil.Parse(this);
		stencil.Render(this, m_stream);

		return true;
	}

	void AddKey(CString& key)
	{

	}

	HTTP_CODE OnGetPathAction()
	{
		Write(m_action);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPathRev()
	{
		Write(m_rev);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPathTo()
	{
		Write(m_to);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetMessageID()
	{
		Write(m_messageID);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetService()
	{
		Write(m_service);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetDocumentType()
	{
		Write(m_documentType);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetMethod()
	{
		Write(m_method);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetGenResponse()
	{
		Write(m_genResponse);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnHasMoreKeys()
	{
		//m_currentKey = m_keys.OnGetNext(m_currentKey);
		//return m_currentKey ? HTTP_SUCCESS : HTTP_S_FALSE;		
		return HTTP_S_FALSE;
	}

	HTTP_CODE OnGetInstance()
	{
		Write(m_instance);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetCluster()
	{
		Write(m_cluster);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPUID()
	{
		Write(m_puid);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetRequest()
	{
		Write(m_request);
		return HTTP_SUCCESS;
	}

	void SetOutputStream(IWriteStream *stream)
	{	
		m_stream = stream;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXMI)		
			REPLACEMENT_METHOD_ENTRY("GetPathAction",	OnGetPathAction)
			REPLACEMENT_METHOD_ENTRY("GetPathRev",		OnGetPathRev)
			REPLACEMENT_METHOD_ENTRY("GetPathTo",		OnGetPathTo)
			REPLACEMENT_METHOD_ENTRY("GetMessageID",	OnGetMessageID)
			REPLACEMENT_METHOD_ENTRY("GetService",		OnGetService)
			REPLACEMENT_METHOD_ENTRY("GetDocumentType", OnGetDocumentType)
			REPLACEMENT_METHOD_ENTRY("GetMethod",		OnGetMethod)
			REPLACEMENT_METHOD_ENTRY("GetGenResponse",	OnGetGenResponse)
			REPLACEMENT_METHOD_ENTRY("HasMoreKeys",		OnHasMoreKeys)
			REPLACEMENT_METHOD_ENTRY("GetInstance",		OnGetInstance)
			REPLACEMENT_METHOD_ENTRY("GetCluster",		OnGetCluster)
			REPLACEMENT_METHOD_ENTRY("GetPUID",			OnGetPUID)
			REPLACEMENT_METHOD_ENTRY("GetRequest",		OnGetRequest)
	END_REPLACEMENT_METHOD_MAP()

private:
	void Write(const CString& value)
	{
		DWORD bytesWritten(0);
		int	  length(value.GetLength());

		m_stream->WriteStream(value, length, &bytesWritten);		
	}
};


////////////////////////////////////////////////////////////////////////////////
//
// CWriteStreamOnFileA
//
////////////////////////////////////////////////////////////////////////////////
class CWriteStreamOnFileA : public IWriteStream
{
private:

	HANDLE m_hFile;

public:

	CWriteStreamOnFileA()
		:m_hFile(INVALID_HANDLE_VALUE)
	{
	}

	~CWriteStreamOnFileA()
	{
		if (m_hFile != INVALID_HANDLE_VALUE)
		{
			CloseHandle(m_hFile);
		}
	}

	HRESULT Init(LPCSTR szFile, DWORD dwCreationDisposition = CREATE_NEW)
	{
		if (szFile == NULL)
		{
			return E_INVALIDARG;
		}

		m_hFile = CreateFileA(szFile, GENERIC_WRITE, FILE_SHARE_READ, NULL, 
			dwCreationDisposition, FILE_ATTRIBUTE_NORMAL, NULL);

		if (m_hFile == INVALID_HANDLE_VALUE)
		{
			return AtlHresultFromLastError();
		}

		return S_OK;
	}

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		ATLASSERT( szOut != NULL );
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}

		DWORD dwWritten = 0;
		if (WriteFile(m_hFile, szOut, nLen, &dwWritten, NULL) != FALSE)
		{
			if (pdwWritten != NULL)
			{
				*pdwWritten = dwWritten;
			}

			return S_OK;
		}

		return AtlHresultFromLastError();
	}

	HRESULT FlushStream()
	{
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (FlushFileBuffers(m_hFile) != FALSE)
		{
			return S_OK;
		}

		return AtlHresultFromLastError();
	}
}; // class CWriteStreamOnFileA

class CWriteStreamOnString : public IWriteStream, public CString
{
	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		CString temp;
		temp.SetString(szOut, nLen);

		(*this) += temp;

		return S_OK;
	}

	HRESULT FlushStream()
	{
		return S_OK;
	}
};

#ifdef _DEBUG

class CWriteStreamOnStdout : public IWriteStream
{
public:

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		ATLASSERT( szOut != NULL );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}
		
		printf("%.*s", nLen, szOut);
		return S_OK;
	}

	HRESULT FlushStream()
	{
		return S_OK;
	}

}; // class CWriteStreamOnStdout

#endif
