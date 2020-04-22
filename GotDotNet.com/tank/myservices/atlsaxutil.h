#ifndef __ATLSAXUTIL_H__
#define __ATLSAXUTIL_H__

#pragma once

#include <atlstr.h>
#include <fcntl.h>
#include <float.h>
#include <math.h>

namespace ATL
{

#define DECLARE_SAXGETVALUE_PROTO(type) \
    HRESULT \
    SAXGetValue<type>( \
        type *pVal, \
        LPCWSTR wsz, \
        int cch \
        )

//
// the following function template will not compile
// this is by design to catch types that are not handled
// by specializations
//

template <typename T>
inline
HRESULT 
SAXGetValue(
    T * /* pVal */, 
    LPCWSTR /* wsz */, 
    int /* cch */
    )
{
}

DECLARE_SAXGETVALUE_PROTO(bool);
DECLARE_SAXGETVALUE_PROTO(char);
DECLARE_SAXGETVALUE_PROTO(unsigned char);
DECLARE_SAXGETVALUE_PROTO(short);
DECLARE_SAXGETVALUE_PROTO(unsigned short);
DECLARE_SAXGETVALUE_PROTO(int);
DECLARE_SAXGETVALUE_PROTO(unsigned int);
DECLARE_SAXGETVALUE_PROTO(long);
DECLARE_SAXGETVALUE_PROTO(unsigned long);
DECLARE_SAXGETVALUE_PROTO(__int64);
DECLARE_SAXGETVALUE_PROTO(unsigned __int64);
DECLARE_SAXGETVALUE_PROTO(double);
DECLARE_SAXGETVALUE_PROTO(float);
DECLARE_SAXGETVALUE_PROTO(CStringW);

#ifdef _NATIVE_WCHAR_T_DEFINED
DECLARE_SAXGETVALUE_PROTO(wchar_t);
#endif // _NATIVE_WCHAR_T_DEFINED

} // namespace ATL

#include <atlsaxutil.inl>

#endif // __ATLSAXUTIL_H__