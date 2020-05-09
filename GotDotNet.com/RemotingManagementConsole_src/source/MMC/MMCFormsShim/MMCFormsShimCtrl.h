// MMCFormsShimCtrl.h : Declaration of the CMMCFormsShimCtrl
#pragma once
#include "resource.h"       // main symbols
#include <atlctl.h>


// CMMCFormsShimCtrl
class ATL_NO_VTABLE CMMCFormsShimCtrl : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public IDispatchImpl<IMMCFormsShimCtrl, &IID_IMMCFormsShimCtrl, &LIBID_MMCFormsShimLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,	
	public IPersistStreamInitImpl<CMMCFormsShimCtrl>,
	public IOleControlImpl<CMMCFormsShimCtrl>,
	public IOleObjectImpl<CMMCFormsShimCtrl>,
	public IOleInPlaceActiveObjectImpl<CMMCFormsShimCtrl>,
	public IViewObjectExImpl<CMMCFormsShimCtrl>,
	public IOleInPlaceObjectWindowlessImpl<CMMCFormsShimCtrl>,
	public ISupportErrorInfo,
	public IPersistStorageImpl<CMMCFormsShimCtrl>,
	public ISpecifyPropertyPagesImpl<CMMCFormsShimCtrl>,
	public IQuickActivateImpl<CMMCFormsShimCtrl>,
	public IDataObjectImpl<CMMCFormsShimCtrl>,
	public IProvideClassInfo2Impl<&CLSID_MMCFormsShimCtrl, NULL, &LIBID_MMCFormsShimLib>,
	public CComCoClass<CMMCFormsShimCtrl, &CLSID_MMCFormsShimCtrl>,
	public CComCompositeControl<CMMCFormsShimCtrl>,
   public IMMCFormsShim
{
public:

	CMMCFormsShimCtrl()
	{
		m_bWindowOnly = TRUE;
		CalcExtent(m_sizeExtent);
	}

DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)

DECLARE_REGISTRY_RESOURCEID(IDR_MMCFORMSSHIMCTRL)

BEGIN_COM_MAP(CMMCFormsShimCtrl)
	COM_INTERFACE_ENTRY(IMMCFormsShimCtrl)
   COM_INTERFACE_ENTRY(IMMCFormsShim)
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

BEGIN_PROP_MAP(CMMCFormsShimCtrl)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
	PROP_ENTRY("AssemblyPath", 2, CLSID_NULL)
	PROP_ENTRY("ClassName", 3, CLSID_NULL)
	// Example entries
	// PROP_ENTRY("Property Description", dispid, clsid)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()


BEGIN_MSG_MAP(CMMCFormsShimCtrl)
	MESSAGE_HANDLER(WM_SIZE, OnSize)
	MESSAGE_HANDLER(WM_SHOWWINDOW, OnShowWindow)
	CHAIN_MSG_MAP(CComCompositeControl<CMMCFormsShimCtrl>)
	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()

	LRESULT OnSize(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnShowWindow(UINT, WPARAM, LPARAM, BOOL&);

BEGIN_SINK_MAP(CMMCFormsShimCtrl)
	//Make sure the Event Handlers have __stdcall calling convention
END_SINK_MAP()

	STDMETHOD(OnAmbientPropertyChange)(DISPID dispid)
	{
		if (dispid == DISPID_AMBIENT_BACKCOLOR)
		{
			SetBackgroundColorFromAmbient();
			FireViewChange();
		}
		return IOleControlImpl<CMMCFormsShimCtrl>::OnAmbientPropertyChange(dispid);
	}

// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid)
	{
		static const IID* arr[] = 
		{
			&IID_IMMCFormsShimCtrl,
		};

		for (int i=0; i<sizeof(arr)/sizeof(arr[0]); i++)
		{
			if (InlineIsEqualGUID(*arr[i], riid))
				return S_OK;
		}
		return S_FALSE;
	}

// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

// IMMCFormsShimCtrl
public:
	enum { IDD = IDD_MMCFORMSSHIMCTRL };

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();

	void FinalRelease() 
	{
	}

	void Reset();

	STDMETHOD(HostUserControl)(BSTR AssemblyName, BSTR Class, IUnknown **ppControlObject);


protected:

	CComPtr<ICorRuntimeHost>			m_pHost;
	CComPtr<mscorlib::_AppDomain>		m_pDefaultDomain;
	CComVariant							   m_varFormDisp;
	HWND								      m_hWndForm;

	CComBSTR							m_bstrAssemblyName;		// path to the assemply to load
	CComBSTR							m_bstrClass;	// class name of the form

public:
	STDMETHOD(get_FormClassName)(BSTR* pVal);
	STDMETHOD(put_FormClassName)(BSTR newVal);
	STDMETHOD(get_AssemblyName)(BSTR* pVal);
	STDMETHOD(put_AssemblyName)(BSTR newVal);
};

OBJECT_ENTRY_AUTO(__uuidof(MMCFormsShimCtrl), CMMCFormsShimCtrl)
