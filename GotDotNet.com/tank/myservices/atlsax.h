#ifndef __ATLSAX_H__
#define __ATLSAX_H__

#pragma once

#include <atlbase.h>
#include <msxml2.h>
#include <atlsaxutil.h>

namespace ATL
{

//=========================================================
// forward declarations
//=========================================================

struct XMLTAG;
typedef XMLTAG XMLATTR;

//=========================================================
// dummy classes for multiple inheritance
// (tell compiler to use big pointers for CParserBase 
// member function pointers)
//=========================================================

class _CDummy1 {};
class _CDummy2 {};

//=========================================================
// CSAXParser class
//=========================================================

class CSAXParser : 
    public _CDummy1, 
    public _CDummy2,
    public ISAXContentHandler
{
public:

    //=====================================================
    // public interface
    //=====================================================

    CSAXParser();

    CSAXParser(
        ISAXXMLReader *pReader,
        ISAXContentHandler *pParent,
        DWORD dwLevel
        );

    virtual ~CSAXParser(
        );

    HRESULT 
    Initialize(
        ISAXXMLReader *pReader,
        ISAXContentHandler *pParent,
        DWORD dwLevel
        );

    HRESULT 
    GetAttributes(
        ISAXAttributes *pAttributes
        );

    HRESULT
    SetParentHandler(
        ISAXContentHandler *pParent,
        ISAXContentHandler **ppOldParent = NULL
        );

    HRESULT
    GetParentHandler(
        ISAXContentHandler **ppParent
        ) const;

    HRESULT
    GetReader(
        ISAXXMLReader **ppReader
        ) const;

    HRESULT
    SetReader(
        ISAXXMLReader *pNewReader,
        ISAXXMLReader **ppOldReader = NULL
        );

    HRESULT
    GetLocator(
        ISAXLocator **ppLocator
        ) const;

    HRESULT
    SetLocator(
        ISAXLocator *pNewLocator,
        ISAXLocator **ppOldLocator = NULL
        );

    DWORD
    GetLevel(
        ) const;

    DWORD
    SetLevel(
        DWORD dwLevel
        );

    DWORD 
    DisableReset(
        DWORD dwCnt = 1
        );

    DWORD
    EnableReset(
        DWORD dwCnt = 1,
        bool bForce = false
        );

public:

    //=====================================================
    // overridable interface
    //=====================================================

    virtual
    HRESULT
    OnUnrecognizedTag(
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName,
        ISAXAttributes *pAttributes
        );

    virtual
    HRESULT
    OnMissingAttribute(
        bool bRequired,
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName
        );

    virtual
    HRESULT
    ValidateElement(
        );

public:

    //=====================================================
    // ISAXContentHandler interface
    //=====================================================

    HRESULT
    STDMETHODCALLTYPE
    putDocumentLocator(
        ISAXLocator  *pLocator
        );

	HRESULT
    STDMETHODCALLTYPE
    startDocument(
        );

    HRESULT
    STDMETHODCALLTYPE 
    endDocument(
        );

    HRESULT 
    STDMETHODCALLTYPE
    startPrefixMapping(
        LPCWSTR wszPrefix,
        int cchPrefix,
        LPCWSTR wszUri,
        int cchUri
        );

    HRESULT 
    STDMETHODCALLTYPE
    endPrefixMapping( 
        LPCWSTR wszPrefix,
        int cchPrefix
        );

    HRESULT 
    STDMETHODCALLTYPE 
    startElement( 
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName,
        ISAXAttributes  *pAttributes
        );

    HRESULT 
    STDMETHODCALLTYPE
    endElement( 
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName
        );

    HRESULT 
    STDMETHODCALLTYPE 
    characters( 
        LPCWSTR wszChars,
        int cchChars
        );

    HRESULT 
    STDMETHODCALLTYPE
    ignorableWhitespace( 
        LPCWSTR wszChars,
        int cchChars
        );

    HRESULT 
    STDMETHODCALLTYPE 
    processingInstruction( 
        LPCWSTR wszTarget,
        int cchTarget,
        LPCWSTR wszData,
        int cchData
        );

    HRESULT 
    STDMETHODCALLTYPE
    skippedEntity( 
        LPCWSTR wszName,
        int cchName
        );

protected:

    //=====================================================
    // inherited interface
    //=====================================================

    virtual const XMLTAG * GetXMLTAGMap();
    virtual const XMLATTR * GetXMLATTRMap();
    virtual void * GetAttrValue();

	void UnChain()
	{
		if ((m_spParent.p != NULL) && (m_spReader.p != NULL))
		{
			m_spReader->putContentHandler(m_spParent);
	    }
	}
private:

    //=====================================================
    // member variables
    //=====================================================

    mutable CComPtr<ISAXContentHandler> m_spParent;
    mutable CComPtr<ISAXXMLReader> m_spReader;
    mutable CComPtr<ISAXLocator> m_spLocator;

    DWORD m_dwLevel;
    DWORD m_dwReset;

private:

    //=====================================================
    // implementation
    //=====================================================

    HRESULT 
    DispatchElement(
        const wchar_t *wszNamespaceUri, 
        int cchNamespaceUri,
        const wchar_t *wszLocalName, 
        int cchLocalName,
        const wchar_t *wszQName, 
        int cchQName,
		ISAXAttributes *pAttributes
        );

    HRESULT 
    DispatchElement(
        const XMLTAG *pMap,
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName,
        ISAXAttributes *pAttributes
        );

    HRESULT 
    GetAttributes(
        const XMLATTR *pMap,
        ISAXAttributes *pAttributes
        );

    bool
    CheckTagElement(
        const XMLTAG *pTag,
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName
        ) const;

    void *
    GetMemberAddress(
        const XMLATTR *pEntry
        );
}; // class CSAXParser

//=========================================================
// include the INL file
//=========================================================

} // namespace ATL

#include <atlsax.inl>

#endif // __ATLSAX_H__