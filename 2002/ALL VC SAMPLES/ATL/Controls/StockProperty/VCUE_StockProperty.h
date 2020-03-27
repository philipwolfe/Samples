// VCUE_StockProperty.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
//////////////////////////////////////////////////////////////////////

#if !defined(_VCUE_STOCPROPERTY_H___4D266B0F_1A51_4A55_A98C_BDF64907A6B2___INCLUDED_)
#define _VCUE_STOCPROPERTY_H___4D266B0F_1A51_4A55_A98C_BDF64907A6B2___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE {

// CPropertyNotifySinkImpl implements IPropertyNotifySink and forwards
// the calls to a parent object. The class holds a strong reference to
// the event source and a weak reference to the parent. This allows the
// parent to unadvise from the event source in FinalRelease or the destructor.

template <class T, class ThreadingModel = CComMultiThreadModel>
class ATL_NO_VTABLE CPropertyNotifySinkImpl :
	public CComObjectRootEx<ThreadingModel>,
	public IPropertyNotifySink,
	public IAtlEventSink
{
public:
	// Constructor
	CPropertyNotifySinkImpl() throw() : m_pParent(NULL), m_dwCookie(0){}

BEGIN_COM_MAP(CPropertyNotifySinkImpl)
	COM_INTERFACE_ENTRY(IPropertyNotifySink)
	COM_INTERFACE_ENTRY(IAtlEventSink)
END_COM_MAP()

public:
	// IPropertyNotifySink methods
	STDMETHOD(OnChanged)(DISPID dispid) throw()
	{
		dispid; // eliminate C4100 warning

		HRESULT hr = S_OK;
		__if_exists(T::OnChanged)
		{
			hr = m_pParent->OnChanged(dispid);
		}
		return hr;
	}

	STDMETHOD(OnRequestEdit)(DISPID dispid) throw()
	{
		dispid; // eliminate C4100 warning

		HRESULT hr = S_OK;
		__if_exists(T::OnRequestEdit)
		{
			hr = m_pParent->OnRequestEdit(dispid);
		}
		return hr;
	}
	
	STDMETHOD(Advise)(IUnknown* pSrc) throw()
	{
		if (!pSrc)
			return E_POINTER;
		
		HRESULT hr = AtlAdvise(pSrc, GetUnknown(), __uuidof(IPropertyNotifySink), &m_dwCookie);
		if (SUCCEEDED(hr))
			m_pSrc = pSrc;
		return hr;
	}
	
	STDMETHOD(Unadvise)() throw()
	{
		ATLASSERT(m_pSrc != NULL);
		HRESULT hr = AtlUnadvise(m_pSrc, __uuidof(IPropertyNotifySink), m_dwCookie);
		m_pSrc.Release();
		return hr;
	}

	// Creation method
	static HRESULT Create(T* pParent, IAtlEventSink** pp) throw()
	{
		CComObject<CPropertyNotifySinkImpl>* pObj = NULL;
		HRESULT hr = CComObject<CPropertyNotifySinkImpl>::CreateInstance(&pObj);
		if (SUCCEEDED(hr))
		{
			pObj->AddRef();
			pObj->m_pParent = pParent;
			hr = pObj->QueryInterface(pp);
			ATLASSERT(SUCCEEDED(hr));
			pObj->Release();
		}
		return hr;
	}

	// Data members
	DWORD m_dwCookie;			// cookie for unadvising
	T* m_pParent;				// weak pointer to parent
	CComPtr<IUnknown> m_pSrc;	// strong pointer to event source
};

// Derive from this class to implement the stock Font property
// This class is responsible for holding the m_pFont member and 
// updating the view in response to property change notifications
// from the font object.
template <class T>
class CStockFontImpl
{
public:
	CComPtr<IFontDisp> m_pFont; // Must be called m_pFont
	CComPtr<IAtlEventSink> m_pFontNotify;

	~CStockFontImpl() throw()
	{
		if (m_pFontNotify)
		{
			m_pFontNotify->Unadvise();
			m_pFontNotify.Release();
		}
	}

	void OnFontChanged() throw() // Must be called OnFontChanged
	{
		HRESULT hr = E_UNEXPECTED;

		if (m_pFontNotify)
			hr = m_pFontNotify->Unadvise();
		else
			hr = CPropertyNotifySinkImpl<CStockFontImpl>::Create(this, &m_pFontNotify);
		
		ATLASSERT(SUCCEEDED(hr) && (m_pFontNotify != NULL));
		
		hr = m_pFontNotify->Advise(m_pFont);
		ATLASSERT(SUCCEEDED(hr));
	}

	// Called by Font object when one of its properties changes
	HRESULT OnChanged(DISPID dispid) throw() // Must be called OnChanged
	{
		dispid; // eliminate C4100 warning

		// Update the display
		__if_exists(T::FireViewChange)
		{
			T* pT = static_cast<T*>(this);
			pT->FireViewChange();
		}
		return S_OK;
	}
};

// Simplified creation for COM font objects
template <class Q>
HRESULT AtlOleCreateFont(Q** pp, LPCOLESTR pszFontName = OLESTR("Arial"),
					  UINT nPointSize = 14, SHORT sCharset = ANSI_CHARSET,
					  SHORT sWeight = FW_NORMAL, BOOL bItalic = FALSE,
					  BOOL bUnderline = FALSE, BOOL bStrikethrough = FALSE) throw()
{
	FONTDESC fd;
	fd.cbSizeofstruct = sizeof(FONTDESC); 
	fd.lpstrName = const_cast<LPOLESTR>(pszFontName);
	fd.cySize.Lo = 10000 * nPointSize; // TODO - this matches FONTSIZE macro, but doesn't actually work
	fd.cySize.Hi = 0;
    fd.sWeight = sWeight; 
    fd.sCharset = sCharset; 
    fd.fItalic = bItalic; 
    fd.fUnderline = bUnderline; 
    fd.fStrikethrough = bStrikethrough;
	return OleCreateFontIndirect(&fd, __uuidof(Q), reinterpret_cast<void**>(pp));
}


// This class selects a standard COM font object into
// a device context, and deselects the font on destruction
class CSelectFont
{
public: 
	HFONT m_hFont;
	CSelectFont(HDC hDC, IUnknown* pFont) throw()
	{
		// Initialization
		m_hDC = hDC;
		m_hOldFont = NULL;
		m_hFont = NULL;

		if (pFont)
		{
			// Get the vtable interface
			HRESULT hr = pFont->QueryInterface(&m_pFont);
			ATLASSERT(SUCCEEDED(hr));

			// Get the Windows font handle
			if (SUCCEEDED(hr))
				hr = m_pFont->get_hFont(&m_hFont);

			// Lock the font handle
			if (SUCCEEDED(hr))
				hr = m_pFont->AddRefHfont(m_hFont);

			ATLASSERT(SUCCEEDED(hr));
		}

		// Select the font
		if (NULL != m_hFont)
			m_hOldFont = static_cast<HFONT>(SelectObject(hDC, m_hFont));
	}

	~CSelectFont() throw()
	{
		// Reset the font
		if (NULL != m_hFont)
		{
			SelectObject(m_hDC, m_hOldFont);
			HRESULT hr = m_pFont->ReleaseHfont(m_hFont);
			hr; // remove warning C4189
			ATLASSERT(SUCCEEDED(hr));
		}
	}

private:
	CComPtr<IFont> m_pFont;
	HFONT m_hOldFont;
	HDC m_hDC;
};

// CColorBrush - it's a color and a brush!
class CColorBrush
{
public:
	OLE_COLOR m_clrColor;
	HBRUSH m_brColor;

	CColorBrush(OLE_COLOR clr = RGB(255, 255, 255)) throw() : m_brColor(NULL)
	{
		*this = clr;
	}

	CColorBrush& operator = (OLE_COLOR clr) throw()
	{
		m_clrColor = clr;

		// Delete the current brush
		if (m_brColor != NULL)
		{
			BOOL bSuccess = ::DeleteObject(m_brColor);
			bSuccess; // remove warning C4189
			ATLASSERT(bSuccess);
			m_brColor = NULL;
		}

		// Recreate the brush using the new color
		COLORREF clrColor;
		HRESULT hr = ::OleTranslateColor(m_clrColor, NULL, &clrColor);
		hr; // remove warning C4189
		ATLASSERT(SUCCEEDED(hr));

		m_brColor = ::CreateSolidBrush(clrColor);
		ATLASSERT(NULL != m_brColor);
		return *this;
	}

	operator OLE_COLOR() const throw()
	{
		return m_clrColor;
	}

	void Fill(HDC hDC, _U_RECT rect) throw()
	{
		// Make sure we have a brush
		ATLASSERT(NULL != m_brColor);

		// Fill the rectangle
        int bSuccess = ::FillRect(hDC, rect.m_lpRect, m_brColor);
		bSuccess; // remove warning C4189
		ATLASSERT(bSuccess);
	}
};

// This class creates and selects a rectangular region into
// a device context, and deselects and destroys the region on destruction
class CSelectClipRegion
{
private:
	HRGN m_hPreviousClipRgn;
	HRGN m_hClipRgn;
	HDC m_hDC;

public:
	CSelectClipRegion(HDC hDC, _U_RECT rect) throw()
	{
		ATLASSERT(NULL != hDC);
		ATLASSERT(NULL != rect.m_lpRect);

		// Initialization
		m_hDC = hDC;
		m_hPreviousClipRgn = NULL;
		m_hClipRgn = NULL;

		// Get the old region so that we can replace it
		if (GetClipRgn(m_hDC, m_hPreviousClipRgn) != 1)
			m_hPreviousClipRgn = NULL;

		// Create a new rectangular region
		m_hClipRgn = CreateRectRgn(rect.m_lpRect->left, rect.m_lpRect->top, rect.m_lpRect->right, rect.m_lpRect->bottom);

		if (m_hClipRgn)
		{
			// Select the region into the device context
			if (ERROR == SelectClipRgn(m_hDC, m_hClipRgn))
			{
				DeleteObject(m_hClipRgn);
				m_hClipRgn = NULL;
			}
			else
				return;
		}

		// Creating or selecting the region failed, so clear data members
		m_hPreviousClipRgn = NULL;
		m_hDC = NULL;
	}

	~CSelectClipRegion() throw()
	{
		if (m_hPreviousClipRgn)
			SelectClipRgn(m_hDC, m_hPreviousClipRgn);

		if (m_hClipRgn)
			DeleteObject(m_hClipRgn);
	}
};

// Simple wrapper for OleTranslateColor and SetTextColor
void SetTextColor(HDC hDC, OLE_COLOR clr)
{
	COLORREF clrColor;
	HRESULT hr = ::OleTranslateColor(clr, NULL, &clrColor);
	hr; // remove warning C4189
	ATLASSERT(SUCCEEDED(hr));

	/* COLORREF clrPreviousTextColor = */ ::SetTextColor(hDC, clrColor);
}

} // namespace VCUE

#endif // !defined(_VCUE_STOCPROPERTY_H___4D266B0F_1A51_4A55_A98C_BDF64907A6B2___INCLUDED_)
