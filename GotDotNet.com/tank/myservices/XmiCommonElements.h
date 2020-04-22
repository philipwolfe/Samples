#pragma once

#include "localizedstring.h"
#include "contact.h"

template <typename TContentType> class CResponseBase2
{
protected:
	typedef CAutoPtrList<TContentType> MyInfoList;

	MyInfoList				m_infos;
	POSITION				m_currentInfoPOS;
	TContentType*			m_currentInfo;	

public:
	CResponseBase2(void) :
		m_currentInfoPOS(0),
		m_currentInfo(NULL)
	{}

	virtual ~CResponseBase2(void)
	{}

	bool HasMoreContentInfo()
	{
		if (!m_currentInfoPOS)
		{
			return false;
		}
		
		// update our position
		m_infos.GetNext(m_currentInfoPOS);

		return m_currentInfoPOS != NULL ? true : false;
	}	

	const TContentType* GetCurrentContentInfo()
	{
		ATLASSERT(m_currentInfoPOS != NULL);
		
		return (TContentType*) m_infos.GetAt(m_currentInfoPOS);
	}

	bool CreateNewContentInfo()
	{
		CAutoPtr<TContentType> newInfo;
		newInfo.Attach(new CComObjectStack<TContentType()>);
		
		POSITION pos = m_infos.AddTail(newInfo);
		m_currentInfo = (TContentType*) m_infos.GetAt(pos);
		
		if (!m_currentInfoPOS)
		{
			m_currentInfoPOS = m_infos.GetHeadPosition();
		}

		return true;
	}	
};
#if 0
class CMyContactResponse2 :
	public CBaseElement,
	public CResponseBase2<CMyContact2>
{
public:
	TAG_METHOD_DECL(new_contact)
	{
		CreateNewContentInfo();
		ChainHandler((CSAXParser*)GetCurrentContentInfo());

		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CMyContactResponse2)		
		XMLTAG_ENTRY("contact", new_contact)		
	END_XMLTAG_MAP()	
};
#endif