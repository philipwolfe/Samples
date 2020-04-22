#pragma once

#include "stdafx.h"
#include "srf.h"

#define ELEMENT(elementName) \
CString elementName;\
TAG_METHOD_DECL(set_##elementName)\
{\
	m_characters = &##elementName;\
	return S_OK;\
}\
HTTP_CODE get_##elementName()\
{\
	Write(##elementName);\
	return S_OK;\
}

#define CLASS_ELEMENT_REPEAT_TYPE(elementType, elementName) \
elementType elementName;\
HTTP_CODE get_##elementName()\
{\
	elementName.prefix = prefix;\
	elementName.SetOutputStream(m_stream);\
	elementName.Generate();\
	return HTTP_SUCCESS;\
}

#define CLASS_ELEMENT(elementType, elementName) \
elementType elementName;\
HTTP_CODE get_##elementName()\
{\
	elementName.prefix = prefix;\
	elementName.SetOutputStream(m_stream);\
	elementName.Generate();\
	return HTTP_SUCCESS;\
}\
void OnDoneChain(##elementType *c)\
{\
	elementName.SetFrom(c);\
}

#define BEGIN_CLASS_ELEMENT_TYPE_MAP(type) \
void OnDoneChain(##type *c) {
#define CLASS_ELEMENT_ENTRY(name) if (c->localname == #name) {name.SetFrom(c);}	
#define END_CLASS_ELEMENT_TYPE_MAP() }

#define BEGIN_SET_FROM(type) void SetFrom(##type<TParentClass> *from) {
#define FROM_ELEMENT(element) element = from->##element;
#define FROM_CLASS_ELEMENT(element) element.SetFrom(&from->##element);
#define END_SET_FROM() }

#define BEGIN_HS_COMPOSITE_DOC_CLASS(className, childName) template <typename TParentClass> class className : public CCompositeBaseElement<className, childName>\
\
{\
\
public:

#define BEGIN_HS_DOC_CLASS(className) template <typename TParentClass> class className : public CBaseElement<className>\
\
{\
\
public:

#define END_HS_DOC_CLASS_NO_END_ELEMENT(idr) \
protected:\
	virtual const char* GetSRF()\
	{\
		return idr;\
	}\
};

#define END_HS_DOC_CLASS(idr) \
public:\
HRESULT STDMETHODCALLTYPE endElement(LPCWSTR wszNamespaceUri,\
									 int cchNamespaceUri,\
									 LPCWSTR wszLocalName,\
									 int cchLocalName,\
									 LPCWSTR wszQName,\
									 int cchQName)\
{\
	USES_CONVERSION;\
	qname.SetString(W2A(wszQName), cchQName);\
	CString temp;\
	temp.SetString(W2A(wszLocalName), cchLocalName);\
	if (temp == localname)\
	{\
		ISAXContentHandler *pParent(NULL); \
		if (SUCCEEDED(this->GetParentHandler(&pParent)) && pParent)\
		{\
			TParentClass* parent = static_cast<TParentClass*>(pParent);\
			if (parent)\
			{\
				parent->OnDoneChain(this);\
				pParent->Release();\
			}\
		}\
		return __super::endElement(	wszNamespaceUri,\
									cchNamespaceUri,\
									wszLocalName,\
									cchLocalName,\
									wszQName,\
									cchQName);\
	}\
	return S_OK;\
}\
protected:\
	virtual const char* GetSRF()\
	{\
		return idr;\
	}\
};

template <typename T> class CBaseElement :
		public	CSAXParser,
		public  ITagReplacerImpl<T>
{	
protected:
	CString			*m_characters;		
	IWriteStream	*m_stream;

public:
	CString			qname;
	CString			value;
	CString			localname;	
	CString			prefix;
	long			m_ref;	

public:	
	CBaseElement() :
		m_characters(NULL),
		m_ref(0)
	{	
		m_characters = &value;
	}

	void SetOutputStream(IWriteStream *stream)
	{
		m_stream = stream;
	}

	bool Generate()
	{
		// need to call SetStream first
		ATLASSERT(m_stream);
		if (!m_stream)
		{
			return false;
		}
				
		// generate the log
		CStencil stencil;

		// see whether we should generate from our default file or from one the user provides
		HTTP_CODE srfLoaded = stencil.LoadFromString(GetSRF(), (DWORD)strlen(GetSRF()));
		if (srfLoaded != HTTP_SUCCESS)
		{			
			return false;
		}
		
		stencil.Parse(this);
		stencil.Render(this, m_stream);

		return true;
	}

	HRESULT STDMETHODCALLTYPE characters(LPCWSTR wszChars, int cchChars)
	{		
		USES_CONVERSION;

		CString temp;
		temp.SetString(W2A(wszChars), cchChars);
		temp.Trim();
		if (!temp.IsEmpty() && m_characters)
		{			
			m_characters->SetString(temp);
		}

		return S_OK;
	}

	HRESULT 
	OnUnrecognizedTag(
	LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
	LPCWSTR wszLocalName,		int cchLocalName,
	LPCWSTR wszQName,			int cchQName,
	ISAXAttributes *pAttributes)
	{
		// don't care about the ones we don't recognize
		return S_OK;
	}

	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv)
	{
		if (!ppv)
			return E_POINTER;

		if (InlineIsEqualGUID(riid, __uuidof(ISAXContentHandler)))
		{
			*ppv = static_cast<IUnknown*>(static_cast<ISAXContentHandler*>(this));
			AddRef();
			return S_OK;
		}		
		else if (InlineIsEqualGUID(riid, __uuidof(ITagReplacer)))
		{
			*ppv = static_cast<IUnknown*>(static_cast<ITagReplacer*>(this));
			AddRef();
			return S_OK;
		}		

		return E_NOINTERFACE;
	}

	ULONG STDMETHODCALLTYPE AddRef()
	{
		return InterlockedIncrement(&m_ref);		
	}

	ULONG STDMETHODCALLTYPE Release()
	{
		return InterlockedDecrement(&m_ref);		
	}

	HTTP_CODE get_prefix()
	{
		Write(prefix);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_localname()
	{
		Write(this->localname);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_value()
	{
		Write(value);
		return HTTP_SUCCESS;
	}	

	HTTP_CODE set_prefix(TCHAR *prefix)
	{
		this->prefix = CString(prefix);
		return HTTP_SUCCESS;
	}

protected:
	
	void Write(const CString& value)
	{
		DWORD bytesWritten(0);
		int	  length(value.GetLength());

		m_stream->WriteStream(value, length, &bytesWritten);		
	}

	virtual const char* GetSRF()
	{
		return IDR_CONTACT;
	}
};

class CWriteStreamOnFileA : public IWriteStream
{
private:

	HANDLE m_hFile;

public:

	CWriteStreamOnFileA()
		:m_hFile(INVALID_HANDLE_VALUE)
	{
	}

	~CWriteStreamOnFileA()
	{
		if (m_hFile != INVALID_HANDLE_VALUE)
		{
			CloseHandle(m_hFile);
		}
	}

	HRESULT Init(LPCSTR szFile, DWORD dwCreationDisposition = CREATE_NEW)
	{
		if (szFile == NULL)
		{
			return E_INVALIDARG;
		}

		m_hFile = CreateFileA(szFile, GENERIC_WRITE, FILE_SHARE_READ, NULL, 
			dwCreationDisposition, FILE_ATTRIBUTE_NORMAL, NULL);

		if (m_hFile == INVALID_HANDLE_VALUE)
		{
			return AtlHresultFromLastError();
		}

		return S_OK;
	}

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		ATLASSERT( szOut != NULL );
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}

		DWORD dwWritten = 0;
		if (WriteFile(m_hFile, szOut, nLen, &dwWritten, NULL) != FALSE)
		{
			if (pdwWritten != NULL)
			{
				*pdwWritten = dwWritten;
			}

			return S_OK;
		}

		return AtlHresultFromLastError();
	}

	HRESULT FlushStream()
	{
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (FlushFileBuffers(m_hFile) != FALSE)
		{
			return S_OK;
		}

		return AtlHresultFromLastError();
	}
}; // class CWriteStreamOnFileA

class CWriteStreamOnString : public IWriteStream, public CString
{
	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		CString temp;
		temp.SetString(szOut, nLen);

		(*this) += temp;

		return S_OK;
	}

	HRESULT FlushStream()
	{
		return S_OK;
	}
};

template <typename T, typename ChildElementType> class CCompositeBaseElement : 
	public CBaseElement<T>
{
protected:
	typedef CAutoPtrList<ChildElementType> ChildList;

	ChildList			m_list;
	POSITION			m_pos;
	ChildElementType*	m_item;	

public:
	CCompositeBaseElement(void) :
		m_pos(0), 
		m_item(NULL)
	{}

	bool HasMoreChildren()
	{
		if (!m_pos)
		{
			return false;
		}
		
		// update our position
		m_list.GetNext(m_pos);

		return m_pos != NULL ? true : false;
	}	

	ChildElementType* GetChild()
	{
		ATLASSERT(m_pos != NULL);		
		return (ChildElementType*) m_list.GetAt(m_pos);
	}
	
	void AddChild(ChildElementType *child)
	{
		CAutoPtr<ChildElementType> newInfo;
		newInfo.Attach(child);
		
		POSITION pos = m_list.AddTail(newInfo);
		m_item = (ResponseType*) m_list.GetAt(pos);
		
		if (!m_pos)
		{
			m_pos = m_list.GetHeadPosition();
		}
	}
};