#pragma once
#include "stdafx.h"

[export]
struct queryRequest
{

};

[
	uuid("CFEC88D9-7159-4139-82AF-F99EAAD7FFE0"),
	object
]
__interface IMyContactsService
{
	HRESULT query();
};
