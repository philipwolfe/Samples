#pragma once

#define _WIN32_WINNT 0x0403

#include <atlsoap.h>
#include <atlhttp.h>
#include <atlsax.h>
#include <atlcoll.h>

#include "xmimessage.h"
#include "xmiquery.h"
#include "xmiinsert.h"
#include "xmidelete.h"
#include "xmireplace.h"

#include "response.h"
#include "insertresponse.h"

template <	typename TQueryResponseType,
			typename TInsertType,
			typename TInsertResponseType  = TQueryResponseType,
			typename TDeleteResponseType  = TQueryResponseType,
			typename TReplaceResponseType = TQueryResponseType,
			typename TReplaceType		  = TInsertType>

class CBaseHailstormService
{
protected:
	CXmiMessage m_xmiMessage;

public:

	void SetServer(const CString& server)
	{
		m_xmiMessage.m_to = server;
	}

	void SetPUID(const CString& puid)
	{
		m_xmiMessage.m_puid = puid;
	}

	virtual bool Replace(	TReplaceResponseType& response, 
							TReplaceType& type, 
							const CString& query = "*",
							const CString& itemNamespace = "")
	{
		// build the replace request
		CXmiReplace<TReplaceType> xmiReplace;
		
		// put this new contact into our insert request
		xmiReplace.SetBody(&type);
		xmiReplace.SetQuery(query);
		xmiReplace.SetItemNamespace(itemNamespace);

		// generate an XML packet for our new contact insert request
		CWriteStreamOnString replaceRequest;

		xmiReplace.SetService(m_xmiMessage.m_service);
		xmiReplace.SetOutputStream(&replaceRequest);

		if (xmiReplace.Generate())
		{
			m_xmiMessage.m_action		= "http://schemas.microsoft.com/hs/2001/10/core#request";
			m_xmiMessage.m_documentType	= "content";
			m_xmiMessage.m_method		= "replace";
			m_xmiMessage.m_body			= replaceRequest;
			
			printf("INSERT: %s\n", (const char*) replaceRequest);

			return InvokeService(m_xmiMessage, response);		
		}
		else
		{
			return false;
		}
	}

	virtual bool Insert(TInsertResponseType& response, TInsertType& type)
	{
		// build the insert request
		CXmiInsert<TInsertType> xmiInsert;

		// put this new contact into our insert request
		xmiInsert.SetInsertBody(&type);

		// generate an XML packet for our new contact insert request
		CWriteStreamOnString insertRequest;

		xmiInsert.SetService(m_xmiMessage.m_service);
		xmiInsert.SetOutputStream(&insertRequest);

		if (xmiInsert.Generate())
		{
			m_xmiMessage.m_action		= "http://schemas.microsoft.com/hs/2001/10/core#request";
			m_xmiMessage.m_documentType	= "content";
			m_xmiMessage.m_method		= "insert";
			m_xmiMessage.m_body			= insertRequest;
			
			printf("INSERT: %s\n", (const char*) insertRequest);

			return InvokeService(m_xmiMessage, response);		
		}
		else
		{
			return false;
		}
	}

	virtual bool Delete(TDeleteResponseType& response, const CString& xpQueryClause = "*")
	{
		CXmiDelete xmiDelete(xpQueryClause);

		m_xmiMessage.m_action		= "http://schemas.microsoft.com/hs/2001/10/core#request";
		m_xmiMessage.m_documentType	= "content";
		m_xmiMessage.m_method		= "delete";

		CWriteStreamOnString stream;
		xmiDelete.SetOutputStream(&stream);		
		xmiDelete.SetService(m_xmiMessage.m_service);

		if (xmiDelete.Generate())
		{	
			m_xmiMessage.m_body = stream;				
			return InvokeService(m_xmiMessage, response);		
		}
		else
		{
			return false;
		}
	}

	virtual bool Query(TQueryResponseType& response, const CString& xpQueryClause = "*")
	{
		CXmiQuery xmiQuery;

		m_xmiMessage.m_action		= "http://schemas.microsoft.com/hs/2001/10/core#request";
		m_xmiMessage.m_documentType	= "content";
		m_xmiMessage.m_method		= "query";

		CWriteStreamOnString stream;
		xmiQuery.SetOutputStream(&stream);
		xmiQuery.SetXpQuery(xpQueryClause);
		xmiQuery.SetService(m_xmiMessage.m_service);

		if (xmiQuery.Generate())
		{	
			m_xmiMessage.m_body = stream;				
			return InvokeService(m_xmiMessage, response);		
		}
		else
		{
			return false;
		}
	}

protected:
	bool InvokeService(CXmiMessage& xmiMessage, TQueryResponseType& response)
	{
		CWriteStreamOnString contents;
		xmiMessage.SetOutputStream(&contents);
		xmiMessage.Generate();
		
		printf("--->%s\n", (const char*)contents);

		// create extra headers to send with request			
		CAtlNavigateData navData;
		navData.SetMethod(ATL_HTTP_METHOD_POST);	
		navData.SetPostData((BYTE*)(const char*)contents, contents.GetLength(), "text/xml");

		try
		{
			CString endPoint;
			endPoint.Format("%s/%s", xmiMessage.GetServer(), xmiMessage.GetService());
			CAtlHttpClientT<ZEvtSyncSocket> httpClient;

			if (httpClient.Navigate(endPoint, &navData))
			{							
				CComPtr<ISAXXMLReader> spReader;
				HRESULT hr = CoCreateInstance(__uuidof(SAXXMLReader30), 
											  NULL, 
											  CLSCTX_ALL,
											  __uuidof(ISAXXMLReader), 
											(void **)&spReader);
				if (FAILED(hr))
				{
					return false;
				}				
				response.SetReader(spReader);				
				response.SetParentHandler(NULL);
					 
				hr = spReader->putContentHandler(&response);				
				if (FAILED(hr))
				{
					spReader->putContentHandler(NULL);            
					return false;
				}

				CComBSTR temp((LPCSTR) httpClient.GetBody());
				CComVariant input(temp);
				
				hr = spReader->parse(input);
				if (FAILED(hr))
				{
					spReader->putContentHandler(NULL);
					return false;
				}
				spReader->putContentHandler(NULL); 

				printf("PASS --> %s\n", (LPCSTR) httpClient.GetBody());

				return true;
			}		
			else
			{
				CString s((LPCSTR) httpClient.GetBody());				
				return false;
			}
		}
		catch(...)
		{}

		return false;
	}
};

class CInsertResponseResponse : 
	public CResponse<CInsertResponse<CInsertResponseResponse> >
{
public:
	BEGIN_XMLTAG_MAP(CInsertResponseResponse)		
		XMLTAG_CLASS("insertResponse",	CInsertResponse<CInsertResponseResponse>)		
	END_XMLTAG_MAP()
};