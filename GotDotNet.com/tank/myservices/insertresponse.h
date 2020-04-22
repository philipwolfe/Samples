#pragma once

#include "xmibase.h"	
#include "cat.h"
#include "address.h"
#include "localizedstring.h"
#include "currency.h"

// see contacts.h for an example of a non-MACRO declaration
BEGIN_HS_DOC_CLASS(CInsertResponse)
	ELEMENT(newBlueId)
    	
	BEGIN_SET_FROM(CInsertResponse)	
		FROM_ELEMENT(newBlueId)		
	END_SET_FROM()
END_HS_DOC_CLASS(IDR_CONNECTION)

class CNoInsertResponseParent :
	public CBaseElement<CNoInsertResponseParent>
{
public:
	void OnDoneChain(CInsertResponse<CNoInsertResponseParent> *response)
	{}
};



