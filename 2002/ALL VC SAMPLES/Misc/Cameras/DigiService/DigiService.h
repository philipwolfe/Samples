// DigiService.h : Defines the ATL Server request handler class
//
#pragma once
#include "getAccessories.h"
#include "spSpecials.h"

#include <vector>
using namespace std;

[ export ]
typedef struct _tagSpecials
{
	int nID;
	BSTR bstrName;
	float fPrice;
}Specials;

[ export ]
typedef struct _tagAccessories
{
	BSTR bstrName;
	BSTR bstrDescription;
	float fPrice;
}Accessories;

// IDigiServiceService - web service interface declaration
//
[
	uuid("C1BF3DBE-8070-4AE6-A399-3589950CC67C"), 
	object
]
__interface IDigiServiceService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	[id(1)] HRESULT GetSpecials([in, out] int *count, [out, retval, size_is(*count)] Specials** retSpecials);
	[id(2)] HRESULT GetAccessories([in] int nCameraID, [in, out] int *count, [out, retval, size_is(*count)] Accessories** retAccessories);
				
	// TODO: Add additional web service methods here
};


// DigiServiceService - web service implementation
//
[
	request_handler(name="Default", sdl="GenDigiServiceServiceSDL"),
	soap_handler(
		name="DigiServiceService", 
		namespace="urn:DigiServiceService",
		protocol="soap"
	)
]
class CDigiServiceService :
	public IDigiServiceService
{
public:
	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method
	[ soap_method ]
	HRESULT GetSpecials(int *count, Specials** retSpecials)
	{
		if (count == NULL || retSpecials == NULL)
			return E_INVALIDARG;

		CGetSpecials cmd;
		HRESULT hr = cmd.OpenAll();

		*count = 0;
		if (SUCCEEDED(hr))
		{
			vector<Specials> vSpecials;
			while(cmd.MoveNext() == S_OK)
			{
				Specials spec;
				CComBSTR bstrName(cmd.m_product_name);

				spec.bstrName = bstrName.Detach();
				spec.nID = cmd.m_product_id;
				spec.fPrice = cmd.m_special_price;

				vSpecials.push_back(spec);
				(*count)++;
			}	

			*retSpecials = (Specials *) malloc((*count)*sizeof(Specials));							
			memset(*retSpecials, 0x00, (*count)*sizeof(Specials));

			for (int i = 0; i < (*count); i++)
			{
				(*retSpecials)[i].bstrName = vSpecials[i].bstrName;
				(*retSpecials)[i].nID = vSpecials[i].nID;
			}	
		}
		return hr;
	}

	[ soap_method ]
	HRESULT GetAccessories(int nCameraID, 
		int* count, Accessories** retAccessories)
	{
		if (count == NULL || retAccessories == NULL)
			return E_INVALIDARG;

		CGetAccessories cmd;
		cmd.m_nCameraID = nCameraID;

		HRESULT hr = cmd.OpenAll();
		*count = 0;

		if (SUCCEEDED(hr))
		{
			vector<Accessories> vAccessories;
			while (cmd.MoveNext() == S_OK)
			{
				Accessories acc;
				CComBSTR bstrName(cmd.m_product_name);
				CComBSTR bstrDesc(cmd.m_product_desc);

				acc.bstrName = bstrName.Detach();
				acc.bstrDescription = bstrDesc.Detach();
				acc.fPrice = cmd.m_product_price;

				vAccessories.push_back(acc);
				(*count)++;
			}	

			cmd.CloseAll();

			*retAccessories = (Accessories *) malloc((*count)*sizeof(Accessories));							
			memset(*retAccessories, 0x00, (*count)*sizeof(Accessories));

			for (int i = 0; i < (*count); i++)
			{
				(*retAccessories)[i].bstrName = vAccessories[i].bstrName;
				(*retAccessories)[i].bstrDescription = vAccessories[i].bstrDescription;
				(*retAccessories)[i].fPrice = vAccessories[i].fPrice;
			}	
		}
		
		return hr;
	}
	// TODO: Add additional web service methods here
}; // class CDigiServiceService
