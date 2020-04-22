#pragma once

#include "xmibase.h"	
#include "cat.h"
#include "address.h"
#include "localizedstring.h"
#include "currency.h"

// see contacts.h for an example of a non-MACRO declaration
BEGIN_HS_DOC_CLASS(CConnection)	
	ELEMENT(Class)
    ELEMENT(status)
    ELEMENT(characteristics)
    ELEMENT(expiration)
    ELEMENT(argotQuery)    
    	
	BEGIN_SET_FROM(CConnection)			
		FROM_ELEMENT(Class)
		FROM_ELEMENT(status)
		FROM_ELEMENT(characteristics)
		FROM_ELEMENT(expiration)
	    FROM_ELEMENT(argotQuery)    
	END_SET_FROM()

public:
	BEGIN_XMLTAG_MAP(CConnection)		
		XMLTAG_ENTRY("class",			set_Class)
		XMLTAG_ENTRY("status",			set_status)
		XMLTAG_ENTRY("characteristics", set_characteristics)
		XMLTAG_ENTRY("expiration",		set_expiration)
	    XMLTAG_ENTRY("argotQuery",		set_argotQuery)  
	END_XMLTAG_MAP()

	BEGIN_REPLACEMENT_METHOD_MAP(CConnection)		
		REPLACEMENT_METHOD_ENTRY("get_class",			get_Class)
		REPLACEMENT_METHOD_ENTRY("get_status",			get_status)
		REPLACEMENT_METHOD_ENTRY("get_characteristics", get_characteristics)
		REPLACEMENT_METHOD_ENTRY("get_expiration",		get_expiration)
	    REPLACEMENT_METHOD_ENTRY("get_argotQuery",		get_argotQuery)  
	END_REPLACEMENT_METHOD_MAP()

END_HS_DOC_CLASS(IDR_CONNECTION)

class CNoConnectionParent :
	public CBaseElement<CNoConnectionParent>
{
public:
	void OnDoneChain(CConnection<CNoConnectionParent> *response)
	{}
};


