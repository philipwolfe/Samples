#ifndef __ATLSAXUTIL_H__
#error atlsaxutil.inl requires atlsaxutil.h
#endif // __ATLSAXUTIL_H__

namespace ATL
{

template <>
inline
HRESULT 
SAXGetValue(
    bool *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    HRESULT hr = E_FAIL;
    switch (wsz[0])
    {
        case L'1':
        {
            if (cch==1)
            {
                *pVal = true;
                hr = S_OK;
            }
            break;
        }
        case L'0':
        {
            if (cch==1)
            {
                *pVal = false;
                hr = S_OK;
            }
            break;
        }
        case L't':
        {
            if (cch==sizeof("true")-1 && !wcsncmp(wsz, L"true", cch))
            {
                *pVal = true;
                hr = S_OK;
            }
            break;
        }
        case L'f':
        {
            if (cch==sizeof("false")-1 && !wcsncmp(wsz, L"false", cch))
            {
                *pVal = false;
                hr = S_OK;
            }
            break;
        }
    }

	return hr;
}

//
// TODO (jasjitg): for conversion routines, determine if it is more efficient
//                 to convert to ANSI first, and then do the data conversion,
//                 or whether it's better to just call the wide version.
//

template <>
inline
HRESULT 
SAXGetValue(
    char *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = (char) atoi(psz);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

	return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    unsigned char *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = (unsigned char) strtoul(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

	return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    short *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = (short) atoi(psz);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    unsigned short *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = (unsigned short) strtoul(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}


template <>
inline
HRESULT 
SAXGetValue(
    int *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = atoi(psz);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    unsigned int *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = strtoul(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    long *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = atoi(psz);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    unsigned long *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = strtoul(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    __int64 *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = _strtoi64(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    unsigned __int64 *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        char *p;
        CFixedStringT<CStringW, 1024> wstrData(wsz, cch);
        CW2A psz( static_cast<LPCWSTR>(wstrData) );
        *pVal = _strtoui64(psz, &p, 10);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    double *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    if ((cch == 3) && (wsz[0]==L'I') && (!wcsncmp(wsz, L"INF", cch)))
    {
        *(((int *) pVal)+0) = 0x0000000;
        *(((int *) pVal)+1) = 0x7FF00000;
    }
    else if ((cch == 3) && (wsz[0]==L'N') && (!wcsncmp(wsz, L"NaN", cch)))
    {
        *(((int *) pVal)+0) = 0x0000000;
        *(((int *) pVal)+1) = 0xFFF80000;
    }
    else if ((cch == 4) && (wsz[1]==L'I') && (!wcsncmp(wsz, L"-INF", cch)))
    {
        *(((int *) pVal)+0) = 0x0000000;
        *(((int *) pVal)+1) = 0xFFF00000;
    }
    else
    {
        _ATLTRY
        {
            char *p;
            CFixedStringT<CStringW, 1024> wstrData(wsz, cch);                  
            CW2A psz( static_cast<LPCWSTR>(wstrData) );
            *pVal = strtod(psz, &p);
        }
        _ATLCATCHALL()
        {
            return E_OUTOFMEMORY;
        }

        if ((*pVal == -HUGE_VAL) || (*pVal == HUGE_VAL) || (errno == ERANGE))
        {
            errno = 0;
            return E_FAIL;
        }
    }

    return S_OK;
}

template <>
inline
HRESULT 
SAXGetValue(
    float *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    double d = *pVal;
    if (SUCCEEDED(SAXGetValue(&d, wsz, cch)) &&
        (d <= FLT_MAX) && (d >= FLT_MIN))
    {
        *pVal = (float) d;
        return S_OK;
    }

    return E_FAIL;
}

template <>
inline
HRESULT 
SAXGetValue(
    CStringW *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    ATLASSERT( wsz != NULL );

    if (wsz == NULL)
    {
        return E_INVALIDARG;
    }

    if (!pVal)
    {
        return E_POINTER;
    }

    _ATLTRY
    {
        pVal->SetString(wsz, cch);
    }
    _ATLCATCHALL()
    {
        return E_OUTOFMEMORY;
    }

    return S_OK;
}

#ifdef _NATIVE_WCHAR_T_DEFINED

template <>
inline
HRESULT 
SAXGetValue(
    wchar_t *pVal, 
    LPCWSTR wsz, 
    int cch
    )
{
    return SAXGetValue(reinterpret_cast<unsigned short *>(pVal), wsz, cch);
}

#endif // _NATIVE_WCHAR_T_DEFINED

} // namespace ATL