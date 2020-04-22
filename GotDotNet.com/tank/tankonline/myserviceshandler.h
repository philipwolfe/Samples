#include "stdafx.h"

#include "mycontacts.h"

[request_handler("MyServices")]
class CMyServicesHandler : 	
	public CTankHandlerBaseT<CMyServicesHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{		
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode == HTTP_SUCCESS)
		{
			m_HttpResponse.Redirect("tankonline.srf");
		}
		else
		{
			if (m_isPostBack)
			{
				m_HttpResponse << "Please ensure that 'server' and 'puid' both have valid values";
			}
		}
		
		// always return success, we're not leaving this page until the user
		// fills out a valid server name and puid
		return HTTP_SUCCESS;
	}
};