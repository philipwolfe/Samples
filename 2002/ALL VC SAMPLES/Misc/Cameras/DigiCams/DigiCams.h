// DigiCams.h : Defines the ATL Server request handler class
//
#pragma once

#include "GetCameras.h"
#include "DigiService.h"

[ request_handler("Default") ]
class CDigiCamsHandler
{
private:
	// Put private members here

protected:
	// Put protected members here
	bool m_bAccessoryFetched;
	int m_nAccessoryCount;
	int m_nCurrentAccessory;
	_tagAccessories* m_pAccessories;

public:
	// Put public members here
	CGetCameras m_cameras;
	CDigiServiceService m_service;

	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		HRESULT hr = m_cameras.OpenAll();
		if (hr != S_OK)
			return HTTP_S_FALSE;		

		// Setup some initial variables
		m_bAccessoryFetched = false;
		m_nAccessoryCount = 0;
		m_pAccessories = NULL;

		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		
		return HTTP_SUCCESS;
	}
 
	[ tag_name(name = "GetNextCamera") ]
	HTTP_CODE OnGetNextCamera(void)
	{
		HRESULT hr;
		hr = m_cameras.MoveNext();
		if (hr != S_OK)
			return HTTP_S_FALSE;
		else
			return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetCameraName") ]
	HTTP_CODE OnGetCameraName(void)
	{
		m_HttpResponse << m_cameras.m_product_name;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetCameraDescription") ]
	HTTP_CODE OnGetCameraDescription(void)
	{
		m_HttpResponse << m_cameras.m_product_desc;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetCameraImageUrl") ]
	HTTP_CODE OnGetCameraImageUrl(void)
	{
		m_HttpResponse << m_cameras.m_product_url;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetCameraID") ]
	HTTP_CODE OnGetCameraID(void)
	{
		m_HttpResponse << m_cameras.m_product_id;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetCameraPrice") ]
	HTTP_CODE OnGetCameraPrice(void)
	{
		m_HttpResponse << m_cameras.m_product_price;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetNextAccessory") ]
	HTTP_CODE OnGetNextAccessory(void)
	{
		if (m_bAccessoryFetched != true)
		{
			LPCSTR szValue;
			// Get the ID from the query params
			// first try GET
			szValue = this->m_HttpRequest.m_QueryParams.Lookup("id");
			if (!szValue)
			{
				// try POST if GET fails
				szValue = this->m_HttpRequest.m_pFormVars->Lookup("id");
			}		

			// Call the service to get the list of accessories
			int nCameraId = atoi(szValue);
			HRESULT hr = m_service.GetAccessories(nCameraId, &m_nAccessoryCount,
				&m_pAccessories);

			if (m_nAccessoryCount != 0 && m_pAccessories != NULL)
				m_bAccessoryFetched = true;
		}
		else
		{
			m_nCurrentAccessory++;

			// Cleanup if we've reached the end of the list
			if (m_nCurrentAccessory == m_nAccessoryCount)
			{
				m_bAccessoryFetched = false;
				m_nAccessoryCount = 0;
				m_nCurrentAccessory = 0;
	
				m_service.Cleanup();
				delete m_pAccessories;
				m_pAccessories = NULL;

				return HTTP_S_FALSE;
			}
		}	

		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetAccessoryName") ]
	HTTP_CODE OnGetAccessoryName(void)
	{
		if (m_pAccessories == NULL)
			return HTTP_SUCCESS;

		m_HttpResponse << m_pAccessories[m_nCurrentAccessory].bstrName;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetAccessoryDescription") ]
	HTTP_CODE OnGetAccessoryDescription(void)
	{
		if (m_pAccessories == NULL)
			return HTTP_SUCCESS;

		m_HttpResponse << m_pAccessories[m_nCurrentAccessory].bstrDescription;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "GetAccessoryPrice") ]
	HTTP_CODE OnGetAccessoryPrice(void)
	{
		if (m_pAccessories == NULL)
			return HTTP_SUCCESS;

		m_HttpResponse << m_pAccessories[m_nCurrentAccessory].fPrice;
		return HTTP_SUCCESS;
	}
}; // class CDigiCamsHandler
