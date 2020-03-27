// Draw.h : Declaration of the CDrawCtl

#include <objsafe.h>
#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CDrawCtl
class CDrawCtl : 
    public CComObjectRoot,
    public CComCoClass<CDrawCtl, &__uuidof(CoDrawCtl)>,
    public CComControl<CDrawCtl>,
    public IPersistStreamInitImpl<CDrawCtl>,
    public IPersistStorageImpl<CDrawCtl>,
    public IQuickActivateImpl<CDrawCtl>,
    public IProvideClassInfo2Impl<&__uuidof(CoDrawCtl), NULL, &LIBID_DRAWCTLLib>,
    public IOleControlImpl<CDrawCtl>,
    public IOleObjectImpl<CDrawCtl>,
    public IOleInPlaceActiveObjectImpl<CDrawCtl>,
    public IViewObjectExImpl<CDrawCtl>,
    public IOleInPlaceObjectWindowlessImpl<CDrawCtl>,
    public IDataObjectImpl<CDrawCtl>,
    public ISupportErrorInfo,
    public IDispatchImpl<IDrawCtl, &__uuidof(IDrawCtl), &LIBID_DRAWCTLLib>,
    public IDispatchImpl<IDrawServ, &__uuidof(IDrawServ), &LIBID_DRAWCTLLib>,
    public IObjectSafetyImpl<CDrawCtl, INTERFACESAFE_FOR_UNTRUSTED_CALLER>
{
public:
    CDrawCtl()
    {
        m_bDragging = FALSE;
        m_col = RGB(255, 0, 0);
        m_dwSafety = 0;     // We haven't been asked to be safe yet
    }
    ~CDrawCtl()
    {
        // Disconnect if necessary
        Disconnect();
    }

DECLARE_REGISTRY_RESOURCEID(IDR_DrawCtl)
DECLARE_GET_CONTROLLING_UNKNOWN()

BEGIN_COM_MAP(CDrawCtl)
    COM_INTERFACE_ENTRY(IDrawCtl)
    COM_INTERFACE_ENTRY2(IDispatch,IDrawCtl)
    COM_INTERFACE_ENTRY(IDrawServ)
    COM_INTERFACE_ENTRY_IMPL(IViewObjectEx)
    COM_INTERFACE_ENTRY_IMPL_IID(__uuidof(IViewObject2), IViewObjectEx)
    COM_INTERFACE_ENTRY_IMPL_IID(__uuidof(IViewObject), IViewObjectEx)
    COM_INTERFACE_ENTRY_IMPL(IOleInPlaceObjectWindowless)
    COM_INTERFACE_ENTRY_IMPL_IID(__uuidof(IOleInPlaceObject), IOleInPlaceObjectWindowless)
    COM_INTERFACE_ENTRY_IMPL_IID(__uuidof(IOleWindow), IOleInPlaceObjectWindowless)
    COM_INTERFACE_ENTRY_IMPL(IOleInPlaceActiveObject)
    COM_INTERFACE_ENTRY_IMPL(IOleControl)
    COM_INTERFACE_ENTRY_IMPL(IOleObject)
    COM_INTERFACE_ENTRY_IMPL(IQuickActivate)
    COM_INTERFACE_ENTRY_IMPL(IPersistStorage)
    COM_INTERFACE_ENTRY_IMPL(IPersistStreamInit)
    COM_INTERFACE_ENTRY_IMPL(IDataObject)
    COM_INTERFACE_ENTRY(IObjectSafety)
    COM_INTERFACE_ENTRY(IProvideClassInfo)
    COM_INTERFACE_ENTRY(IProvideClassInfo2)
    COM_INTERFACE_ENTRY(ISupportErrorInfo)
END_COM_MAP()

BEGIN_MSG_MAP(CDrawCtl)
    MESSAGE_HANDLER(WM_PAINT, OnPaint)
    MESSAGE_HANDLER(WM_LBUTTONDOWN, OnLButtonDown)
    MESSAGE_HANDLER(WM_LBUTTONUP, OnLButtonUp)
    MESSAGE_HANDLER(WM_MOUSEMOVE, OnMouseMove)
END_MSG_MAP()

BEGIN_PROPERTY_MAP(CDrawCtl)
END_PROPERTY_MAP()

// ISupportsErrorInfo
    STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid);

// IDrawCtl
public:

// Implementation
    // We currently don't repaint so do nothing
    HRESULT OnDraw(ATL_DRAWINFO& di)
    {
        return 0;
    }

    // Needed to resolve ambiguity with Draw method on IDrawServ interface
    STDMETHOD(Draw)(DWORD dwDrawAspect, LONG lindex, void  *pvAspect,
                    DVTARGETDEVICE  *ptd, HDC hicTargetDev, HDC hdcDraw,
                    LPCRECTL prcBounds, LPCRECTL prcWBounds,
                    BOOL (__stdcall  *pfnContinue)(DWORD dwContinue),
                    DWORD dwContinue)
    {
        return IViewObjectExImpl<CDrawCtl>::Draw(dwDrawAspect, lindex, pvAspect,
                    ptd, hicTargetDev, hdcDraw,
                    prcBounds, prcWBounds,
                    pfnContinue,
                    dwContinue);
    }

    // IDrawServ
    STDMETHOD(Draw)(long x1, long y1, long x2, long y2, unsigned long col)
    {
        HRESULT hr;
        HDC  hDC;
        HPEN hOldPen;
        POINT ptOld;

        // If we're not in place active then we don't necessarily have a window,
        // so we can't draw.
        if (!m_bInPlaceActive)
            return S_OK;
        if (m_bWndLess)
        {
            // We're windowless so we need the DC from the client
            hr = m_spInPlaceSite->GetDC(NULL, 0, &hDC);
            _ASSERTE(SUCCEEDED(hr));
            // We need to reset the origin if we are drawing in client coordinates
            ::SetWindowOrgEx(hDC, -m_rcPos.left, -m_rcPos.top, &ptOld);
        }
        else
            hDC  = ::GetDC(m_hWnd);

        HPEN hPen = ::CreatePen(PS_SOLID, 2, (COLORREF)col);
        hOldPen = (HPEN)::SelectObject(hDC, hPen);
        ::MoveToEx(hDC, x1, y1, NULL);
        ::LineTo(hDC, x2, y2);
        ::SelectObject(hDC, hOldPen);
        ::DeleteObject(hPen);

        if (m_bWndLess)
        {
            ::SetWindowOrgEx(hDC, ptOld.x, ptOld.y, NULL);
            hr = m_spInPlaceSite->ReleaseDC(hDC);
        }
        else
            ::ReleaseDC(m_hWnd, hDC);

        return S_OK;
    }

    // IDrawCtl
    STDMETHOD(Connect)(BSTR pFileName) 
    {
        HRESULT hr;

        // Everyone can connect
        CoInitializeSecurity(NULL, -1, NULL, NULL,
            RPC_C_AUTHN_LEVEL_NONE, RPC_C_IMP_LEVEL_IDENTIFY, NULL, EOAC_NONE, NULL);
        
        COSERVERINFO si;
        MULTI_QI     qi;

        si.dwReserved1 = 0;
        si.pwszName = OLE2W(pFileName);
        si.pAuthInfo = NULL;
        si.dwReserved2 = 0;

        qi.pIID = &__uuidof(IDrawServ);     
        qi.pItf = NULL;

        hr = CoCreateInstanceEx(CLSID_CDrawServ, NULL, CLSCTX_SERVER, &si, 1, &qi);
        if (FAILED(hr))
        {
            ATLTRACE(_T("CoCreateInstanceEx failed"));
            return hr;
        }
        if (FAILED(qi.hr))
        {
            ATLTRACE(_T("Failed to connect to server"));
            return qi.hr;
        }
        m_pDrawServ = (IDrawServ*) qi.pItf;

        IConnectionPointContainerPtr pCPC;
        IConnectionPointPtr pCP;

        try {
        pCPC = m_pDrawServ;
        } catch(...) {
        hr = E_FAIL;
        }

        if (SUCCEEDED(hr))
            hr = pCPC->FindConnectionPoint(__uuidof(IDrawServ), &pCP);
        if (SUCCEEDED(hr))
            hr = pCP->Advise(GetUnknown(), &m_dwDrawServ);
        
        if (FAILED(hr))
        {
            ATLTRACE(_T("Connect failed!"));
            m_pDrawServ = 0;
            hr = E_FAIL;
        }
        return hr;
    }

    // IDrawCtl
    STDMETHOD(Disconnect)() 
    {
        HRESULT hr = S_OK;
        if ((bool) m_pDrawServ)
        {
            IConnectionPointContainerPtr pCPC;
            IConnectionPointPtr pCP;

            try {
            pCPC = m_pDrawServ;
            } catch(...) {
            hr = E_FAIL;
            }

            if (SUCCEEDED(hr))
                hr = pCPC->FindConnectionPoint(__uuidof(IDrawServ), &pCP);
            if (SUCCEEDED(hr))
                hr = pCP->Unadvise(m_dwDrawServ);
        
            if (FAILED(hr))
            {
                ATLTRACE(_T("Disconnect failed!"));
                hr = E_FAIL;
            }
            m_pDrawServ = 0;
        }
        return hr;
    }

// IDrawCtl
    STDMETHOD(Clear)() 
    {
        return Invalidate() ? S_OK : E_FAIL;
    }

private:
    LRESULT OnLButtonDown(UINT, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
    {
        if (m_bWndLess)
            m_spInPlaceSite->SetCapture(TRUE);
        else
            ::SetCapture(m_hWnd);

        m_xPos = LOWORD(lParam);  // horizontal position of cursor 
        m_yPos = HIWORD(lParam);  // vertical position of cursor 
        m_bDragging = TRUE;
        {
            TCHAR aMsg[80];
            wsprintf(aMsg,_T("%d,%d\n"),m_xPos,m_yPos);
            ATLTRACE(aMsg);
        }
        return 0;
    }
    
    LRESULT OnLButtonUp(UINT, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
    {
        if (m_bWndLess)
            m_spInPlaceSite->SetCapture(FALSE);
        else
            ::ReleaseCapture();
        m_bDragging = FALSE;
        return 0;
    }

    LRESULT OnMouseMove(UINT, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
    {
        if (m_bDragging && (bool) m_pDrawServ)
        {
            HRESULT hr;
            RECT rcObject;
            POINT pt;
            WORD xPos = LOWORD(lParam);
            WORD yPos = HIWORD(lParam);
            pt.x = xPos;
            pt.y = yPos;

            // If we are windowless then we use the client's coordinates,
            // otherwise we are offset from 0,0.
            rcObject = m_rcPos;
            if (!m_bWndLess)
            {
                OffsetRect(&rcObject, -rcObject.left, -rcObject.top);
            }

            if (PtInRect(&rcObject,pt))
            {
                hr = m_pDrawServ->Draw(
                    m_xPos - rcObject.left, m_yPos - rcObject.top,
                    xPos - rcObject.left, yPos - rcObject.top,
                    m_col);
                if (FAILED(hr))
                {
                    TCHAR buf[32];
                    // There's an error so we might as well disconnect to stop multiple errors
                    Disconnect();
                    wsprintf(buf, _T("Error calling server's Draw(%x)"), hr);
                    ::MessageBox(NULL,buf,_T(""),0);
                }
                m_xPos = xPos;
                m_yPos = yPos;
            }
        }
        return 0;
    }

    IDrawServPtr m_pDrawServ;
    DWORD        m_dwDrawServ;  // Connection cookie
    WORD         m_xPos;            // Current position
    WORD         m_yPos;            // when drawing.
    BOOL         m_bDragging;   // Are we drawing? (left mouse button down)
    COLORREF     m_col;
    DWORD        m_dwSafety;        // Code safety level
};
