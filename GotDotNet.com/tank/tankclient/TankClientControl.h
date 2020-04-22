// TankClientControl.h : Declaration of the CTankClientControl
#pragma once
#include "resource.h"       // main symbols
#include <atlctl.h>
#include <oleidl.h>
#include "tankgame.h"

// Game information
[export]
struct Player
{
	BSTR name;
	BSTR ipAddress;
	BSTR hostName;
	int	 score;	
};

// ITankClientControl
[
	object,
	uuid(C9522C1B-E179-4FDE-B834-D6A581FB327F),
	dual,
	helpstring("ITankClientControl Interface"),
	pointer_default(unique)
]
__interface ITankClientControl : public IDispatch
{	
	[propget, id(1), helpstring("property TankServiceURL")] HRESULT TankServiceURL([out, retval] BSTR* pVal);
	[propput, id(1), helpstring("property TankServiceURL")] HRESULT TankServiceURL([in] BSTR newVal);
	[propget, id(2), helpstring("property UserName")]		HRESULT UserName([out, retval] BSTR* pVal);
	[propput, id(2), helpstring("property UserName")]		HRESULT UserName([in] BSTR newVal);
	[propget, id(3), helpstring("property CanShoot")]		HRESULT CanShoot([out, retval] VARIANT_BOOL* pVal);
	[propput, id(3), helpstring("property CanShoot")]		HRESULT CanShoot([in] VARIANT_BOOL newVal);	
	[id(4),			 helpstring("method Stop")]				HRESULT Stop(void);
	[propget, id(5), helpstring("property Score")]			HRESULT Score([out, retval] SHORT* pVal);
	[id(6),			 helpstring("method GetPlayers")]		HRESULT GetPlayers([in, out] BSTR *playersName, [in, out] BSTR *playerScore, [in, out] BSTR *playerIP);
	[propget, id(7), helpstring("property GameStarted")]	HRESULT GameStarted([out, retval] VARIANT_BOOL* pVal);
	[id(8),			 helpstring("method GetGameState")]		HRESULT GetGameState([out,retval] BSTR *gameState);
	[id(9),			 helpstring("method GetPlayerID")]		HRESULT GetPlayerID([out,retval] SHORT* playerID);	
	[propput, id(10),helpstring("property MoveRight")]		HRESULT MoveRight([in] BSTR newVal);
	[propput, id(11),helpstring("property MoveLeft")]		HRESULT MoveLeft([in] BSTR newVal);	
	[propput, id(12),helpstring("property MoveForward")]	HRESULT MoveForward([in] BSTR newVal);
	[propput, id(13),helpstring("property Shoot")]			HRESULT Shoot([in] BSTR newVal);
	[id(14), helpstring("method Start")] HRESULT Start(void);
};	

// CTankClientControl
[
	coclass,
	threading("apartment"),
	vi_progid("TankClient.TankClientControl"),
	progid("TankClient.TankClientControl.1"),
	version(1.0),
	uuid("858A114C-5BAD-4DFD-9748-97830E14CDEC"),
	helpstring("TankClientControl Class"),
	support_error_info(ITankClientControl),
	registration_script("control.rgs")
]
class ATL_NO_VTABLE CTankClientControl : 
	public ITankClientControl,
	public IPersistStreamInitImpl<CTankClientControl>,
	public IOleControlImpl<CTankClientControl>,
	public IOleObjectImpl<CTankClientControl>,
	public IOleInPlaceActiveObjectImpl<CTankClientControl>,
	public IViewObjectExImpl<CTankClientControl>,
	public IOleInPlaceObjectWindowlessImpl<CTankClientControl>,
	public IPersistStorageImpl<CTankClientControl>,
	public ISpecifyPropertyPagesImpl<CTankClientControl>,
	public IQuickActivateImpl<CTankClientControl>,
	public IDataObjectImpl<CTankClientControl>,
	public IProvideClassInfo2Impl<&__uuidof(CTankClientControl), NULL>,
	public CComControl<CTankClientControl>,	
	public IObjectSafetyImpl<CTankClientControl, INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA>,
	public IPersistPropertyBagImpl<CTankClientControl>	
{
	using IOleInPlaceObjectWindowlessImpl<CTankClientControl>::GetWindow;
// 	using IOleWindow::GetWindow;
private:
	enum GameState
	{
		NotInitialized,
		ReadyToStart,
		Initialized,
		Connected,
		GameStarted,
		Error
	};	

	GameState	 m_state;	
	CTankGame	 m_tankGame;	
	CHandle		 m_renderThread;
	CString		 m_tankServiceURL;
	CString		 m_userName;
	CString		 m_errorMsg;
	VARIANT_BOOL m_canShoot;

	char		 m_moveRight;
	char		 m_moveLeft;
	char		 m_moveForward;
	char		 m_shoot;

public:		
DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)

BEGIN_PROP_MAP(CTankClientControl)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)	
	// Example entries
	// PROP_ENTRY("Property Description", dispid, clsid)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()

BEGIN_MSG_MAP(CTankClientControl)		
	CHAIN_MSG_MAP(CComControl<CTankClientControl>)			
	MESSAGE_HANDLER(WM_LBUTTONDOWN,	OnMouseDown)		
	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()
	
// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

public:		
	CTankClientControl();
	~CTankClientControl();

	// ITankClientControl
	STDMETHOD(get_TankServiceURL)(BSTR* pVal);
	STDMETHOD(put_TankServiceURL)(BSTR newVal);
	STDMETHOD(get_UserName)(BSTR* pVal);
	STDMETHOD(put_UserName)(BSTR newVal);
	STDMETHOD(get_CanShoot)(VARIANT_BOOL* pVal);
	STDMETHOD(put_CanShoot)(VARIANT_BOOL newVal);	
	STDMETHOD(Stop)(void);
		
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	STDMETHOD(FinalConstruct)();
	void FinalRelease();
	
protected:	
	char String2CommandChar(const CString& str);
	
	void StartGameThread(void);	
	void WriteMessage(LPCTSTR pszText, ATL_DRAWINFO& di);

	bool	Initialize();
	HRESULT OnDraw(ATL_DRAWINFO& di);
	LRESULT OnMouseDown(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);	
	STDMETHOD(TranslateAccelerator)(LPMSG lpmsg);

	static void RenderFrameThreadProc(LPVOID lpParam);		

public:	
	STDMETHOD(GetPlayers)(BSTR *playersName, BSTR *playerScore, BSTR *playerIP);
	STDMETHOD(get_GameStarted)(VARIANT_BOOL* pVal);
	STDMETHOD(GetGameState)(BSTR* gameState);
	STDMETHOD(GetPlayerID)(SHORT* playerID);
	
	STDMETHOD(get_Score)(SHORT* pVal);

	STDMETHOD(put_MoveRight)(BSTR newVal);	
	STDMETHOD(put_MoveLeft)(BSTR newVal);
	STDMETHOD(put_MoveForward)(BSTR newVal);	

	STDMETHOD(put_Shoot)(BSTR newVal);
	STDMETHOD(Start)(void);
};
