// Test.h : Declaration of the CTest
// Copyright (c) Microsoft Corporation.  All rights reserved.
#pragma once
#include "resource.h"       // main symbols
#include <atlctl.h>
#include "VCUE_StockProperty.h"




// CTest
class ATL_NO_VTABLE CTest : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CStockPropImpl<CTest, ITest>,
	public VCUE::CStockFontImpl<CTest>, // handle notifications for the Font
	public IPersistStreamInitImpl<CTest>,
	public IOleControlImpl<CTest>,
	public IOleObjectImpl<CTest>,
	public IOleInPlaceActiveObjectImpl<CTest>,
	public IViewObjectExImpl<CTest>,
	public IOleInPlaceObjectWindowlessImpl<CTest>,
	public ISupportErrorInfo,
	public IPersistStorageImpl<CTest>,
	public ISpecifyPropertyPagesImpl<CTest>,
	public IQuickActivateImpl<CTest>,
	public IDataObjectImpl<CTest>,
	public IProvideClassInfo2Impl<&CLSID_Test, NULL, &LIBID_StockPropertyLib>,
	public CComCoClass<CTest, &CLSID_Test>,
	public CComControl<CTest>
{
public:

	CTest()
	{
		m_clrForeColor = RGB(0,0,0);

		
		// Example initialization
		// Initialize the font
		HRESULT hr = VCUE::AtlOleCreateFont(&m_pFont, OLESTR("Comic Sans MS"), 24);
		if (FAILED(hr))
			ATLTRACE(_T("Failed to initialize font\n"));
		OnFontChanged();
		
	}

DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)

DECLARE_REGISTRY_RESOURCEID(IDR_TEST)

BEGIN_COM_MAP(CTest)
	COM_INTERFACE_ENTRY(ITest)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IViewObjectEx)
	COM_INTERFACE_ENTRY(IViewObject2)
	COM_INTERFACE_ENTRY(IViewObject)
	COM_INTERFACE_ENTRY(IOleInPlaceObjectWindowless)
	COM_INTERFACE_ENTRY(IOleInPlaceObject)
	COM_INTERFACE_ENTRY2(IOleWindow, IOleInPlaceObjectWindowless)
	COM_INTERFACE_ENTRY(IOleInPlaceActiveObject)
	COM_INTERFACE_ENTRY(IOleControl)
	COM_INTERFACE_ENTRY(IOleObject)
	COM_INTERFACE_ENTRY(IPersistStreamInit)
	COM_INTERFACE_ENTRY2(IPersist, IPersistStreamInit)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(ISpecifyPropertyPages)
	COM_INTERFACE_ENTRY(IQuickActivate)
	COM_INTERFACE_ENTRY(IPersistStorage)
	COM_INTERFACE_ENTRY(IDataObject)
	COM_INTERFACE_ENTRY(IProvideClassInfo)
	COM_INTERFACE_ENTRY(IProvideClassInfo2)
END_COM_MAP()

BEGIN_PROP_MAP(CTest)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
	PROP_ENTRY("BackColor", DISPID_BACKCOLOR, CLSID_StockColorPage)
	PROP_ENTRY("Font", DISPID_FONT, CLSID_StockFontPage)
	PROP_ENTRY("ForeColor", DISPID_FORECOLOR, CLSID_StockColorPage)
	// Example entries
	// PROP_ENTRY("Property Description", dispid, clsid)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()


BEGIN_MSG_MAP(CTest)
	CHAIN_MSG_MAP(CComControl<CTest>)
	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()
// Handler prototypes:
//  LRESULT MessageHandler(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
//  LRESULT CommandHandler(WORD wNotifyCode, WORD wID, HWND hWndCtl, BOOL& bHandled);
//  LRESULT NotifyHandler(int idCtrl, LPNMHDR pnmh, BOOL& bHandled);

// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid)
	{
		static const IID* arr[] = 
		{
			&IID_ITest,
		};

		for (int i = 0; i < sizeof(arr)/sizeof(arr[0]); i++)
		{
			if (InlineIsEqualGUID(*arr[i], riid))
				return S_OK;
		}
		return S_FALSE;
	}

// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

// ITest
public:
		HRESULT OnDraw(ATL_DRAWINFO& di)
		{
			// Get the device context and rectangle
			HDC hDC = di.hdcDraw;
			RECT& rc = *(RECT*)di.prcBounds;

			// Select the rectangular clipping region
			// The destructor deselects the region
			VCUE::CSelectClipRegion theClipRegion(hDC, rc);

			// Fill the background
			m_clrBackColor.Fill(hDC, rc);
			
			// Select the stock font into the device context
			// The destructor deselects the font
			VCUE::CSelectFont theSelector(hDC, m_pFont);

			// Prepare to output the text in the center
			/* UINT nPreviousTextAlign = */ SetTextAlign(hDC, TA_CENTER | TA_BASELINE);

			// Prepare to output the text with transparent background
			/* int nPreviousBkMode = */ SetBkMode(hDC, TRANSPARENT); 

			// Prepare to output the text using the ForeColor
			VCUE::SetTextColor(hDC, m_clrForeColor);

			LPCTSTR pszText = _T("Stock Property Sample: BackColor, ForeColor, Font");
			TextOut(di.hdcDraw, 
				(rc.left + rc.right) / 2, 
				(rc.top + rc.bottom) / 2, 
				pszText, 
				lstrlen(pszText));

		return S_OK;
	}

	VCUE::CColorBrush m_clrBackColor;
	OLE_COLOR m_clrForeColor;

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

	private:
		CTest& operator = (const CTest&) { return *this; }
};

OBJECT_ENTRY_AUTO(__uuidof(Test), CTest)
