// stdafx.cpp : source file that includes just the standard includes
// AddIn.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"


#ifdef _ATL_STATIC_REGISTRY
#include <statreg.h>
#include <statreg.cpp>
#endif

#include <atlimpl.cpp>
#include "AddIn_h.h"

class DECLSPEC_UUID("$LIBID$") $SAFEOBJNAME$Lib;

const CLSID CLSID_$SAFEOBJNAME$ = __uuidof($SAFEOBJNAME$);
const IID LIBID_$SAFEOBJNAME$Lib = __uuidof($SAFEOBJNAME$Lib);
