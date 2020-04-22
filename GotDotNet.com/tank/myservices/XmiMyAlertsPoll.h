#pragma once

#include "xmibase.h"

class CXmiMyAlertsPoll 
	: public CXmiBase<CXmiMyAlertsPoll>	
{
public:

	CXmiMyAlertsPoll(void)
	{
	}

	virtual ~CXmiMyAlertsPoll(void)
	{
	}

	virtual const char* GetSRF()
	{
		return IDR_POLL;
	}
};
