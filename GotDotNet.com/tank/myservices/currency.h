#pragma once
#include "xmibase.h"	

// see contacts.h for an example of a non-MACRO declaration
BEGIN_HS_DOC_CLASS(CCurrency)
	
	CCurrency()
	{
		localname ="currency";
	}

	ELEMENT(currencycode)

	BEGIN_SET_FROM(CCurrency)
		FROM_ELEMENT(currencycode)
	END_SET_FROM()

	BEGIN_REPLACEMENT_METHOD_MAP(CCurrency)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix", set_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_currencycode",  get_currencycode)		
	END_REPLACEMENT_METHOD_MAP()
		
	BEGIN_XMLTAG_MAP(CCurrency)
		XMLTAG_ENTRY("currencycode", set_currencycode)		
	END_XMLTAG_MAP()

END_HS_DOC_CLASS(IDR_CURRENCY)