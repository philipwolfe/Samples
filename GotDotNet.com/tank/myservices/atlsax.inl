#ifndef __ATLSAX_H__
    #error atlsax.inl requires atlsax.h
#endif // __ATLSAX_H__

namespace ATL
{

//=========================================================
// XMLTAG struct
// used for dispatching XML entries
//=========================================================
typedef 
HRESULT 
(CSAXParser::*TAG_DISPATCH_FUNC)(
	const wchar_t *wszNamespaceUri, int cchNamespaceUri,
	const wchar_t *wszLocalName, int cchLocalName,
	const wchar_t *wszQName, int cchQName,
	ISAXAttributes *pAttributes
    );

typedef 
HRESULT 
(CSAXParser::*ATTR_DISPATCH_FUNC)(
	const wchar_t *wszNamespaceUri, int cchNamespaceUri,
	const wchar_t *wszLocalName, int cchLocalName,
	const wchar_t *wszQName, int cchQName,
	const wchar_t *wszValue, int cchValue,
	ISAXAttributes *pAttributes
    );

typedef 
HRESULT 
(*CREATE_TAGCLASS_FUNC)(
    CSAXParser *pParent,
    CSAXParser **ppParser
    );

typedef 
HRESULT 
(*SAX_CONVERT_FUNC)(
    void *pVal, 
    LPCWSTR wsz,
    int cch
    );

typedef 
HRESULT 
(CSAXParser::*SAX_VALIDATE_FUNC)(
    void *pVal,
    LPCWSTR wsz,
    int cch
    );

//
// REVIEW (jasjitg): this is to workaround compiler bug (vs:304892)
//

template <typename T>
inline
SAX_CONVERT_FUNC
_TGetConvertFunc(
    T *pVal
    )
{
    typedef 
    HRESULT 
    (*PFN)(
        T *pVal, 
        LPCWSTR wsz,
        int cch
        );

    PFN pfn = &SAXGetValue<T>;
    return reinterpret_cast<SAX_CONVERT_FUNC>(pfn);
}

struct XMLTAG
{
	LPCWSTR wszElemName;             // the element name
	int cchElemName;                 // the element name length
    ULONG nElemNameHash;             // the element name hash
	
	LPCWSTR wszElemNamespace;        // the element namespace
	int cchElemNamespace;            // the element namespace length
    ULONG nElemNamespaceHash;        // the element namespace hash

	TAG_DISPATCH_FUNC pfnTag;        // function pointer to the tag dispatch
                                     // method

	ATTR_DISPATCH_FUNC pfnAttr;      // function pointer to the attribute 
                                     // dispatch method

	bool bRequired;                  // attribute must be present

    CREATE_TAGCLASS_FUNC pfnCreate;  // function pointer to parser class 
                                     // creation function

    SAX_CONVERT_FUNC pfnConvert;     // function pointer to data conversion
                                     // function (for attributes).

    SAX_VALIDATE_FUNC pfnValidate;   // function pointer to data validation
                                     // function (for attributes).

    size_t nOffset;                  // offset of the data to be converted
                                     // from the base
};

//=========================================================
// public interface
//=========================================================

inline
CSAXParser::CSAXParser() :
    m_dwLevel(0),
    m_dwReset(0)
{
}

inline
CSAXParser::CSAXParser(
    ISAXXMLReader *pReader,
    ISAXContentHandler *pParent,
    DWORD dwLevel
    ) :
    m_spReader(pReader),
    m_spParent(pParent),
    m_dwLevel(dwLevel),
    m_dwReset(0)
{
}

inline
CSAXParser::~CSAXParser(
    )
{
    if ((m_spParent.p != NULL) && (m_spReader.p != NULL))
    {
		m_spReader->putContentHandler(m_spParent);
    }
}

inline
HRESULT 
CSAXParser::Initialize(
    ISAXXMLReader *pReader,
    ISAXContentHandler *pParent,
    DWORD dwLevel
    )
{
    if (pReader == NULL)
    {
        return E_INVALIDARG;
    }

    m_spReader = pReader;
    m_spParent = pParent;
    m_dwLevel = dwLevel;

    return m_spReader->putContentHandler(this);
}

inline
HRESULT 
CSAXParser::GetAttributes(
    ISAXAttributes *pAttributes
    )
{
    if (!pAttributes)
    {
        return E_INVALIDARG;
    }

    const XMLATTR *pAttrMap = GetXMLATTRMap();

    if (pAttrMap != NULL)
    {
        return GetAttributes(pAttrMap, pAttributes);
    }

    return S_OK;
}

inline
HRESULT
CSAXParser::SetParentHandler(
    ISAXContentHandler *pParent,
    ISAXContentHandler **ppOldParent
    )
{
    if (!pParent)
    {
        return E_INVALIDARG;
    }

    if (ppOldParent)
    {
        m_spParent.CopyTo(ppOldParent);
    }

    m_spParent = pParent;

    return S_OK;
}

inline
HRESULT
CSAXParser::GetParentHandler(
    ISAXContentHandler **ppParent
    ) const
{
    return m_spParent.CopyTo(ppParent);
}

inline
HRESULT
CSAXParser::GetReader(
    ISAXXMLReader **ppReader
    ) const
{
    return m_spReader.CopyTo(ppReader);
}

inline
HRESULT
CSAXParser::SetReader(
    ISAXXMLReader *pNewReader,
    ISAXXMLReader **ppOldReader
    )
{
    if (!pNewReader)
    {
        return E_INVALIDARG;
    }

    if (ppOldReader)
    {
        m_spReader.CopyTo(ppOldReader);
    }

    m_spReader = pNewReader;

    return S_OK;
}

inline
HRESULT
CSAXParser::GetLocator(
    ISAXLocator **ppLocator
    ) const
{
    return m_spLocator.CopyTo(ppLocator);
}

inline
HRESULT
CSAXParser::SetLocator(
    ISAXLocator *pNewLocator,
    ISAXLocator **ppOldLocator
    )
{
    if (!pNewLocator)
    {
        return E_INVALIDARG;
    }

    if (ppOldLocator)
    {
        m_spLocator.CopyTo(ppOldLocator);
    }

    m_spLocator = pNewLocator;

    return S_OK;
}

inline
DWORD
CSAXParser::GetLevel(
    ) const
{
    return m_dwLevel;
}

inline
DWORD
CSAXParser::SetLevel(
    DWORD dwLevel
    )
{
    m_dwLevel = dwLevel;
    return m_dwLevel;
}

inline
DWORD 
CSAXParser::DisableReset(
    DWORD dwCnt
    )
{
    m_dwReset = dwCnt;
    return m_dwReset;
}

inline
DWORD
CSAXParser::EnableReset(
    DWORD dwCnt,
    bool bForce
    )
{
    if (bForce)
    {
        m_dwReset = 0;
    }
    else
    {
        if (dwCnt > m_dwReset)
        {
            dwCnt = m_dwReset;
        }
        m_dwReset -= dwCnt;
    }

    return m_dwReset;
}

//=========================================================
// overridable interface
//=========================================================

inline
HRESULT
CSAXParser::OnUnrecognizedTag(
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName,
    LPCWSTR wszQName,
    int cchQName,
    ISAXAttributes *pAttributes
    )
{
    wszNamespaceUri; // unused
    cchNamespaceUri; // unused
    wszLocalName; // unused
    cchLocalName; // unused
    wszQName; // unused
    cchQName; // unused
    pAttributes; // unused

    return E_FAIL;
}

inline
HRESULT
CSAXParser::OnMissingAttribute(
    bool bRequired,
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName
    )
{
    wszNamespaceUri; // unused
    cchNamespaceUri; // unused
    wszLocalName; // unused
    cchLocalName; // unused

    if (bRequired)
    {
        return E_FAIL;
    }

    return S_OK;
}

inline
HRESULT
CSAXParser::ValidateElement(
    )
{
    return S_OK;
}


//=========================================================
// ISAXContentHandler interface
//=========================================================

inline
HRESULT
STDMETHODCALLTYPE
CSAXParser::putDocumentLocator(
    ISAXLocator  *pLocator
    )
{
    if (!pLocator)
    {
        return E_INVALIDARG;
    }

    m_spLocator = pLocator;
    return S_OK;
}

inline
HRESULT
STDMETHODCALLTYPE
CSAXParser::startDocument(
    )
{
    return S_OK;
}

inline
HRESULT
STDMETHODCALLTYPE 
CSAXParser::endDocument(
    )
{
    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE
CSAXParser::startPrefixMapping(
    LPCWSTR wszPrefix,
    int cchPrefix,
    LPCWSTR wszUri,
    int cchUri
    )
{
    wszPrefix; // unused
    cchPrefix; // unused
    wszUri; // unused
    cchUri; // unused

    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE
CSAXParser::endPrefixMapping( 
    LPCWSTR wszPrefix,
    int cchPrefix
    )
{
    wszPrefix; // unused
    cchPrefix; // unused

    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE 
CSAXParser::startElement( 
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName,
    LPCWSTR wszQName,
    int cchQName,
    ISAXAttributes  *pAttributes
    )
{
    return DispatchElement(
        wszNamespaceUri,
        cchNamespaceUri,
        wszLocalName,
        cchLocalName,
        wszQName,
        cchQName,
        pAttributes
        );
}

inline
HRESULT 
STDMETHODCALLTYPE
CSAXParser::endElement( 
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName,
    LPCWSTR wszQName,
    int cchQName
    )
{
    wszQName; // unused
    cchQName; // unused
    wszLocalName; // unused
    cchLocalName; // unused
    cchNamespaceUri; // unused
    wszNamespaceUri; // unused

    HRESULT hr = ValidateElement();	

    //
    // check the reset
    //
    if (m_dwReset > 0)
    {
        EnableReset();
        return hr;
    }

    //
    // no need to check return value here
    //
    CComPtr<ISAXContentHandler> spParentHandler;
    GetParentHandler(&spParentHandler);

    //
    // restore parent handler
    //
    if (spParentHandler.p != NULL)
    {
        ATLASSERT( m_spReader != NULL );
        m_spReader->putContentHandler(spParentHandler);
    }

    return hr;
}

inline
HRESULT 
STDMETHODCALLTYPE 
CSAXParser::characters( 
    LPCWSTR wszChars,
    int cchChars
    )
{
    wszChars; // unused
    cchChars; // unused

    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE
CSAXParser::ignorableWhitespace( 
    LPCWSTR wszChars,
    int cchChars
    )
{
    wszChars; // unused
    cchChars; // unused

    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE 
CSAXParser::processingInstruction( 
    LPCWSTR wszTarget,
    int cchTarget,
    LPCWSTR wszData,
    int cchData
    )
{
    wszTarget; // unused
    cchTarget; // unused
    wszData; // unused
    cchData; // unused

    return S_OK;
}

inline
HRESULT 
STDMETHODCALLTYPE
CSAXParser::skippedEntity( 
    LPCWSTR wszName,
    int cchName
    )
{
    wszName; // unused
    cchName; // unused

    return S_OK;
}

//=========================================================
// inherited interface
//=========================================================

inline const XMLTAG * CSAXParser::GetXMLTAGMap() { return NULL; }
inline const XMLATTR * CSAXParser::GetXMLATTRMap() { return NULL; }\
inline void * CSAXParser::GetAttrValue() { return NULL; }

//=========================================================
// implementation
//=========================================================

inline
HRESULT 
CSAXParser::DispatchElement(
    const wchar_t *wszNamespaceUri, 
    int cchNamespaceUri,
    const wchar_t *wszLocalName, 
    int cchLocalName,
    const wchar_t *wszQName, 
    int cchQName,
	ISAXAttributes *pAttributes
    )
{
    HRESULT hr = S_OK;
    const XMLTAG *pTagMap = GetXMLTAGMap();
    if (pTagMap != NULL)
    {
        hr = DispatchElement(pTagMap, wszNamespaceUri, cchNamespaceUri,
            wszLocalName, cchLocalName, wszQName, cchQName,
            pAttributes);
    }

    return hr;
}

inline
HRESULT 
CSAXParser::DispatchElement(
    const XMLTAG *pMap,
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName,
    LPCWSTR wszQName,
    int cchQName,
    ISAXAttributes *pAttributes
    )
{
    ATLASSERT( pMap != NULL );

    while (pMap->wszElemName)
    {
        //
        // TODO: support hashed entries
        //

        if (CheckTagElement(pMap, wszNamespaceUri, cchNamespaceUri,
                wszLocalName, cchLocalName, wszQName, cchQName))
        {
            HRESULT hr = S_OK;
            if (pMap->pfnCreate != NULL)
            {
                CComPtr<CSAXParser> spChain;
                hr = (pMap->pfnCreate)(this, &spChain);
                if (SUCCEEDED(hr))
                {
                    hr = spChain->GetAttributes(pAttributes);
                }
            }
            else
            {
                hr = GetAttributes(pAttributes);
                if (SUCCEEDED(hr))
                {
                    hr = (this->*pMap->pfnTag)(
                        wszNamespaceUri, cchNamespaceUri, 
                        wszLocalName, cchLocalName, wszQName, cchQName,
                        pAttributes);
                }
            }

            return hr;
        }

        ++pMap;
    }

    //
    // unrecognized tag
    //

    return OnUnrecognizedTag(wszNamespaceUri, cchNamespaceUri, wszLocalName, 
        cchLocalName, wszQName, cchQName, pAttributes);
}

inline
HRESULT 
CSAXParser::GetAttributes(
    const XMLATTR *pMap,
    ISAXAttributes *pAttributes
    )
{
    ATLASSERT( pMap != NULL );

    if (!pAttributes)
    {
        return E_INVALIDARG;
    }

    int nAttrs = 0;
    HRESULT hr = pAttributes->getLength(&nAttrs);
    if (FAILED(hr))
    {
        return hr;
    }

    while ((pMap->wszElemName) && (hr == S_OK))
    {
        int i;
        for (i=0; i<nAttrs && hr==S_OK; i++)
        {
            LPCWSTR wszNamespaceUri = NULL;
            int cchNamespaceUri = 0;
            LPCWSTR wszLocalName = NULL;
            int cchLocalName = 0;
            LPCWSTR wszQName = NULL;
            int cchQName = 0;

            hr = pAttributes->getName(i, &wszNamespaceUri, &cchNamespaceUri,
                &wszLocalName, &cchLocalName, &wszQName, &cchQName);

            if (SUCCEEDED(hr))
            {
                if (CheckTagElement(pMap, wszNamespaceUri, cchNamespaceUri,
                        wszLocalName, cchLocalName, wszQName, cchQName))
                {
                    LPCWSTR wszValue = NULL;
                    int cchValue = 0;

                    hr = pAttributes->getValue(i, &wszValue, &cchValue);
                    if (SUCCEEDED(hr))
                    {
                        if (pMap->pfnConvert != NULL)
                        {
                            void *pVal = GetMemberAddress(pMap);
                            hr = (*pMap->pfnConvert)(pVal, wszValue, cchValue);
                            if (SUCCEEDED(hr))
                            {
                                if (pMap->pfnValidate != NULL)
                                {
                                    hr = (this->*pMap->pfnValidate)(
                                        pVal, wszValue, cchValue);
                                }
                            }
                        }
                        else
                        {
                            hr = (this->*pMap->pfnAttr)(wszNamespaceUri,
                                cchNamespaceUri, wszLocalName, cchLocalName,
                                wszQName, cchQName, wszValue, cchValue, 
                                pAttributes);
                        }
                    }

                    break;
                }
            }
        }

        if (i >= nAttrs)
        {
            //
            // missing attribute
            //

            hr = OnMissingAttribute(pMap->bRequired, pMap->wszElemName,
                pMap->cchElemName, pMap->wszElemNamespace, 
                pMap->cchElemNamespace);
        }

        ++pMap;
    }

    return hr;
}

inline
bool
CSAXParser::CheckTagElement(
    const XMLTAG *pTag,
    LPCWSTR wszNamespaceUri,
    int cchNamespaceUri,
    LPCWSTR wszLocalName,
    int cchLocalName,
    LPCWSTR wszQName,
    int cchQName
    ) const
{
    wszQName; // unused
    cchQName; // unused

    //
    // TODO: support hashed entries
    //

    ATLASSERT( pTag->wszElemName != NULL );

    //
    // if tag name length == passed length AND
    //     (there is no namespace specified OR
    //      the specified namespace length and passed length are zero OR
    //      (tag namespace length == passed length AND
    //       tag namespace == passed namespace)) AND
    //    tag name == passed name
    //

    if ((pTag->cchElemName == cchLocalName) &&
        ((!pTag->wszElemNamespace) || // no namespace is ok
         (!pTag->cchElemNamespace && !cchNamespaceUri) || // no namespace is ok
         ((pTag->cchElemNamespace == cchNamespaceUri) &&
          (!wcsncmp(pTag->wszElemNamespace, 
                    wszNamespaceUri, cchNamespaceUri)))) &&
        (!wcsncmp(pTag->wszElemName, wszLocalName, cchLocalName)))
    {
        //
        // namespace and tag match
        // if the user doesn't care about the namespace (NULL)
        //

        return true;
    }

    return false;
}

inline
void *
CSAXParser::GetMemberAddress(
    const XMLATTR *pEntry
    )
{
    BYTE *pBase = reinterpret_cast<BYTE *>(GetAttrValue());
    pBase += pEntry->nOffset;
    return pBase;
}

//=========================================================
// utility function definitions
//=========================================================

template <class THandler>
inline
HRESULT
_CreateChainHandler(
    CSAXParser *pParent,
    CSAXParser **ppParser
    )
{
    if (!ppParser)
    {
        return E_POINTER;
    }
    
    *ppParser = NULL;

    ATLTRY( *ppParser = new THandler );

    HRESULT hr = S_OK;

    if (*ppParser)
    {
        (*ppParser)->AddRef();

        CComPtr<ISAXXMLReader> spReader;
        CComPtr<ISAXLocator> spLocator;

        hr = pParent->GetReader(&spReader);
        if (SUCCEEDED(hr))
        {
            hr = pParent->GetLocator(&spLocator);
            if (SUCCEEDED(hr))
            {
                hr = (*ppParser)->SetParentHandler(pParent);
                if (SUCCEEDED(hr))
                {
                    hr = (*ppParser)->SetReader(spReader);
                    if (SUCCEEDED(hr))
                    {
                        hr = (*ppParser)->SetLocator(spLocator);
                        if (SUCCEEDED(hr))
                        {
                            (*ppParser)->SetLevel(pParent->GetLevel()+1);
                        }
                    }
                }
            }
        }

        if (SUCCEEDED(hr))
        {
            hr = spReader->putContentHandler(*ppParser);
        }
        if (FAILED(hr))
        {
            (*ppParser)->Release();
            *ppParser = NULL;
        }
    }
    else
    {
        hr = E_OUTOFMEMORY;
    }

    return hr;
}

//=========================================================
// defines for tag/attribute maps
//=========================================================

#define EMPTY_XMLTAG_MAP() \
	virtual const XMLTAG * GetXMLTAGMap() \
	{ \
		return NULL; \
	} 

#define EMPTY_XMLATTR_MAP() \
	virtual const XMLATTR * GetXMLATTRMap() \
	{ \
		return NULL; \
	}

#define BEGIN_XMLTAG_MAP(className) \
	virtual const XMLTAG * GetXMLTAGMap() \
	{ \
		static const XMLTAG map[] = \
		{

#define END_XMLTAG_MAP() \
	{ NULL, NULL } }; \
	return map; \
	}

#define _XMLTAG_ENTRY_EX(elementName, elementNamespace, elementFunc, tagClass)\
	{ L ## elementName, sizeof(elementName)-1, 0, \
	  L ## elementNamespace, sizeof(elementNamespace)-1, 0, \
	  static_cast<TAG_DISPATCH_FUNC>(elementFunc), NULL, false, tagClass, \
      NULL, NULL, 0 },

#define XMLTAG_ENTRY_EX(elementName, elementNamespace, elementFunc) \
    _XMLTAG_ENTRY_EX(elementName, elementNamespace, elementFunc, NULL)

#define XMLTAG_CLASS_EX(elementName, elementNamespace, tagClass) \
    _XMLTAG_ENTRY_EX(elementName, elementNamespace, NULL, \
        _CreateChainHandler< tagClass >)

#define _XMLTAG_ENTRY(elementName, elementFunc, tagClass) \
	{ L ## elementName, sizeof(elementName)-1, 0, \
		NULL, 0, 0, \
	  static_cast<TAG_DISPATCH_FUNC>(elementFunc), NULL, false, tagClass, \
      NULL, NULL, 0 },

#define XMLTAG_ENTRY(elementName, elementFunc) \
    _XMLTAG_ENTRY(elementName, elementFunc, NULL)

#define XMLTAG_CLASS(elementName, tagClass) \
    _XMLTAG_ENTRY(elementName, NULL, _CreateChainHandler< tagClass > )

#define XMLTAG_CLASS_CREATE(elementName, createTagClassFunc) \
    _XMLTAG_ENTRY(elementName, NULL, createTagClassFunc )

#define BEGIN_XMLATTR_MAP(className) \
    typedef className _current_class_attr; \
	virtual const XMLATTR * GetXMLATTRMap() \
	{ \
		static const XMLTAG map[] = \
		{

#define END_XMLATTR_MAP() \
	{ NULL, NULL } }; \
	return map; \
	} \
    virtual void * GetAttrValue() { return this; }

#define \
    _XMLATTR_ENTRY_EX(elementName, elementNamespace, elementFunc, required) \
	{ L ## elementName, sizeof(elementName)-1, 0, \
	  L ## elementNamespace, sizeof(elementNamespace)-1, 0, \
	  NULL, static_cast<ATTR_DISPATCH_FUNC>(elementFunc), required, NULL, \
      NULL, NULL, 0 },

#define XMLATTR_ENTRY_EX(elementName, elementNamespace, elementFunc) \
	_XMLATTR_ENTRY_EX(elementName, elementNamespace, elementFunc, false)

#define \
    XMLATTR_ENTRY_EX2(elementName, elementNamespace, elementFunc, required) \
	_XMLATTR_ENTRY_EX(elementName, elementNamespace, elementFunc, required)

#define _XMLATTR_ENTRY(elementName, elementFunc, required) \
	{ L ## elementName, sizeof(elementName)-1, 0, \
		NULL, 0, 0, \
	  NULL, static_cast<ATTR_DISPATCH_FUNC>(elementFunc), required, NULL, \
      NULL, NULL, 0 },

#define \
    _XMLATTR_CONV_EX(elementName, elementNamespace, \
        memberVar, validateFunc, required) \
	{ L ## elementName, sizeof(elementName)-1, 0, \
	  L ## elementNamespace, sizeof(elementNamespace)-1, 0, \
	  NULL, NULL, required, NULL, \
      _TGetConvertFunc(&((_current_class_attr *)0)->memberVar), \
      reinterpret_cast<SAX_VALIDATE_FUNC>(validateFunc), \
      offsetof(_current_class_attr, memberVar) },

#define \
    XMLATTR_CONV_EX(elementName, elementNamespace, \
        memberVar, validateFunc) \
	_XMLATTR_CONV_EX(elementName, elementNamespace, \
        memberVar, validateFunc, false)

#define \
    XMLATTR_CONV_EX2(elementName, elementNamespace, \
        memberVar, validateFunc, required) \
	_XMLATTR_CONV_EX(elementName, elementNamespace, \
        memberVar, validateFunc, required)

#define \
    _XMLATTR_CONV(elementName, memberVar, validateFunc, required) \
	{ L ## elementName, sizeof(elementName)-1, 0, \
		NULL, 0, 0, \
	  NULL, NULL, required, NULL, \
      _TGetConvertFunc(&((_current_class_attr *)0)->memberVar), \
      reinterpret_cast<SAX_VALIDATE_FUNC>(validateFunc), \
      offsetof(_current_class_attr, memberVar) },

#define XMLATTR_CONV(elementName, memberVar, validateFunc) \
    _XMLATTR_CONV(elementName, memberVar, validateFunc, false)

#define XMLATTR_CONV2(elementName, memberVar, validateFunc, required) \
    _XMLATTR_CONV(elementName, memberVar, validateFunc, required)

#define XMLATTR_ENTRY(elementName, elementFunc) \
    _XMLATTR_ENTRY(elementName, elementFunc, false)

#define XMLATTR_ENTRY2(elementName, elementFunc, required) \
    _XMLATTR_ENTRY(elementName, elementFunc, required)

#define TAG_METHOD_DECL( name ) \
	HRESULT name(LPCWSTR wszNamespaceUri, int cchNamespaceUri, \
		LPCWSTR wszLocalName, int cchLocalName, \
		LPCWSTR wszQName, int cchQName, \
		ISAXAttributes *pAttributes)

#define TAG_METHOD_IMPL( class, name ) \
	HRESULT class ## :: ## name(LPCWSTR wszNamespaceUri, int cchNamespaceUri, \
		LPCWSTR wszLocalName, int cchLocalName, \
		LPCWSTR wszQName, int cchQName, \
		ISAXAttributes *pAttributes)

#define ATTR_METHOD_DECL( name ) \
	HRESULT name(LPCWSTR wszNamespaceUri, int cchNamespaceUri, \
		LPCWSTR wszLocalName, int cchLocalName, \
		LPCWSTR wszQName, int cchQName, \
		LPCWSTR wszValue, int cchValue, \
		ISAXAttributes *pAttributes)

#define ATTR_METHOD_IMPL( class, name ) \
	HRESULT class ## :: ## name(LPCWSTR wszNamespaceUri, int cchNamespaceUri, \
		LPCWSTR wszLocalName, int cchLocalName, \
		LPCWSTR wszQName, int cchQName, \
		LPCWSTR wszValue, int cchValue, \
		ISAXAttributes *pAttributes)

} // namespace ATL