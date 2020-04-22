// TankClientControl.cpp : Implementation of CTankClientControl
#include "stdafx.h"
#include "TankClientControl.h"

CTankClientControl::CTankClientControl() 
		:	m_state(NotInitialized),
			m_renderThread(NULL),
			m_canShoot(VARIANT_FALSE),
			m_moveRight(VK_RIGHT),
			m_moveLeft(VK_LEFT),
			m_moveForward(VK_UP),
			m_shoot(' ')
{		
	m_bWindowOnly = true;
}

HRESULT CTankClientControl::Stop(void)
{
	// stop the game
	m_tankGame.StopGame();

	// wait for our game thread to stop
	WaitForSingleObject(m_renderThread, INFINITE);

	// reset to initial state
	m_state = NotInitialized;
	m_renderThread.Close();	

	return S_OK;
}

HRESULT CTankClientControl::OnDraw(ATL_DRAWINFO& di)
{		
	switch (m_state)
	{
		case ReadyToStart:
		{			
			// make sure we have values for all of our properties
			if (!m_tankServiceURL.IsEmpty() && !m_userName.IsEmpty())
			{			
				Initialize();							
				InvalidateRect(NULL);
			}

			break;
		}
		
		case Initialized:
		{
			// Draw a message telling the user to click on the screen to start.  This will
			// make sure that we have focus on the control before playing.
			WriteMessage("Please click here to start playing!", di);					

			break;
		}

		case GameStarted:
		{			
			// Display the game map
			HWND hwnd;
			if (SUCCEEDED(GetWindow(&hwnd)))
			{				
				HDC hDC = ::GetDC(hwnd);											
				m_tankGame.RenderMap(hDC);
				::ReleaseDC(hwnd, hDC);							
			}
			else
			{
				m_state    = Error;
				m_errorMsg = "Can't get window to draw into!";
				WriteMessage(m_errorMsg, di);
			}
			break;
		}

		case Error:
		{
			// We are in an error state
			WriteMessage(m_errorMsg, di);
	
			break;
		}		
	}	

	return S_OK;
}

void CTankClientControl::WriteMessage(LPCTSTR pszText, ATL_DRAWINFO& di)
{
	RECT& rc = *(RECT*)di.prcBounds;
	
	// Set Clip region to the rectangle specified by di.prcBounds
	HRGN hRgnOld = NULL;
	if (GetClipRgn(di.hdcDraw, hRgnOld) != 1)
	{
		hRgnOld = NULL;
	}

	bool bSelectOldRgn = false;
	HRGN hRgnNew = CreateRectRgn(rc.left, rc.top, rc.right, rc.bottom);

	if (hRgnNew != NULL)
	{
		bSelectOldRgn = (SelectClipRgn(di.hdcDraw, hRgnNew) != ERROR);
	}
	SetTextAlign(di.hdcDraw, TA_CENTER|TA_BASELINE);
	
	TextOut(di.hdcDraw, (rc.left + rc.right) / 2, (rc.top + rc.bottom) / 2, pszText, lstrlen(pszText));

	if (bSelectOldRgn)
	{
		SelectClipRgn(di.hdcDraw, hRgnOld);
	}
}

LRESULT CTankClientControl::OnMouseDown(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{	
	// put the focus on this control
	if (!SetFocus())
	{
		m_state    = Error;
		m_errorMsg = "Can't get focus!";				
		InvalidateRect(NULL);
	}

	// Start the game when the user clicks on the control; this ensures that they h
	// put focus on the control.
	if (m_state != GameStarted)
	{				
		StartGameThread();
	}			

	bHandled = TRUE;
	return 0;
}

void CTankClientControl::StartGameThread()
{
	// only go to GameStarted if we have already been initialized
	if (m_state == Initialized)
	{
		// start our game loop
		DWORD threadID(0);
		HANDLE temp = CreateThread( NULL, 
									NULL, 
									(LPTHREAD_START_ROUTINE)CTankClientControl::RenderFrameThreadProc, 
									this, 
									NULL, 
									&threadID);
				
		if (!temp)
		{
			m_state = Error;
			m_errorMsg = "Error, can't start game loop";

			// fire our error event
			return;
		}
		
		// keep track of this thread handle
		m_renderThread.Attach(temp);

		// We are now initialized. When the user clicks on this control to give it focus, we 
		// will be ready to play.
		m_state = GameStarted;		

		// update our display
		InvalidateRect(NULL);
	}
}

CTankClientControl::~CTankClientControl()
{
	Stop();
}		

STDMETHODIMP CTankClientControl::TranslateAccelerator(LPMSG lpmsg)
{
	bool bHandled(false);
	if (m_state == GameStarted)
	{	
		switch (lpmsg->message)
		{		
			case WM_KEYDOWN:
			{			
				WPARAM wParam = lpmsg->wParam;
							
				if (wParam == VkKeyScan(m_moveForward) || wParam == m_moveForward)
				{
					bHandled = true;
					m_tankGame.MoveForward();				
				}        
				else if (wParam == VkKeyScan(m_moveLeft) || wParam == m_moveLeft)
				{
					bHandled = true;
					m_tankGame.MoveLeft();					
				}
				else if (wParam == VkKeyScan(m_moveRight) || wParam == m_moveRight)
				{
					bHandled = true;
					m_tankGame.MoveRight();
				}
				else if (wParam == VkKeyScan(m_shoot) || wParam == m_shoot)
				{					
					bHandled = true;

					// only shoot if we are allowed to
					if (m_canShoot == VARIANT_TRUE)
					{
						m_tankGame.Shoot();
					}
					else
					{
						MessageBox("You can only shoot after you purchase a license");
					}				
				}
			}	
		}		
	}

	return bHandled ? S_OK : __super::TranslateAccelerator(lpmsg);	
}

STDMETHODIMP CTankClientControl::FinalConstruct()
{
	return S_OK;
}

void CTankClientControl::FinalRelease() 
{
}

STDMETHODIMP CTankClientControl::get_TankServiceURL(BSTR* pVal)
{
	*pVal = m_tankServiceURL.AllocSysString();
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_TankServiceURL(BSTR newVal)
{
	m_tankServiceURL = newVal;
	return S_OK;
}

STDMETHODIMP CTankClientControl::get_UserName(BSTR* pVal)
{
	*pVal = m_userName.AllocSysString();
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_UserName(BSTR newVal)
{
	m_userName = newVal;
	return S_OK;
}

STDMETHODIMP CTankClientControl::get_CanShoot(VARIANT_BOOL* pVal)
{
	*pVal = m_canShoot;
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_CanShoot(VARIANT_BOOL newVal)
{
	m_canShoot = newVal;
	return S_OK;
}

void CTankClientControl::RenderFrameThreadProc(LPVOID lpParam)
{
	CTankClientControl *parent = (CTankClientControl*) lpParam;
	parent->m_tankGame.StartGame();
}

bool CTankClientControl::Initialize()
{
	HWND	hwnd;	
	if (FAILED(GetWindow(&hwnd)))
	{
		m_errorMsg = "Can't get window to draw into!";
		m_state = Error;
		
		return false;						
	}

	if (!m_tankGame.Initialize(hwnd, m_tankServiceURL))
	{
		m_state		= Error;
		m_errorMsg	= "Error, can't connect to Tank Service";
		
		return false;
	}

	if (!m_tankGame.Login(m_userName))
	{
		m_state = Error;
		m_errorMsg.Format("Error, can't login as %s", m_userName);
		
		return false;
	}					

	m_state = Initialized;		
	return true;
}
STDMETHODIMP CTankClientControl::get_Score(SHORT* pVal)
{
	// TODO: Add your implementation code here

	return S_OK;
}

STDMETHODIMP CTankClientControl::GetPlayers(BSTR *playerName, BSTR *playerScore, BSTR *playerIP)
{		
	if (m_state == GameStarted)
	{
		// get our player information
		PlayerInfo *playerInfo(NULL);
		int size(0);
		size = m_tankGame.GetPlayerInfo(&playerInfo);
		if (!size || !playerInfo)
		{
			return S_OK;
		}
	
		CComBSTR names;
		CComBSTR scores;
		CComBSTR ips;
		for (int i = 0; i < size; i++)
		{
			CString temp;
			temp.Format("%i", playerInfo[i].nScore);
			CComBSTR bstrScore(temp);

			names   += SysAllocString(playerInfo[i].bstrName);
			scores  += bstrScore.Detach();
			ips		+= SysAllocString(playerInfo[i].bstrIPAddress);
	
			if ((i + 1) < size)
			{
				names	+= ",";
				scores	+= ",";
				ips		+= ",";
			}

			// clean up
			SysFreeString(playerInfo[i].bstrName);
			SysFreeString(playerInfo[i].bstrIPAddress);
		}	
		delete[] playerInfo;
		playerInfo = NULL;
		
		*playerName  = names.Detach();
		*playerScore = scores.Detach();
		*playerIP	 = ips.Detach();
	}

	return S_OK;
}

STDMETHODIMP CTankClientControl::get_GameStarted(VARIANT_BOOL* pVal)
{
	if (m_state == GameStarted)
	{
		*pVal = VARIANT_TRUE;
	}
	else
	{
		*pVal = VARIANT_FALSE;
	}

	return S_OK;
}

// return a string in the form
// name,score,ip;name,score,ip,hostname
STDMETHODIMP CTankClientControl::GetGameState(BSTR* gameState)
{
	if (m_state == GameStarted)
	{
		// get our player information
		PlayerInfo *playerInfo(NULL);
		int size(0);
		size = m_tankGame.GetPlayerInfo(&playerInfo);
		if (!size || !playerInfo)
		{
			return S_OK;
		}
	
		CComBSTR buffer;		
		for (int i = 0; i < size; i++)
		{
			CString temp;
			temp.Format("%i", playerInfo[i].nScore);
			CComBSTR bstrScore(temp);

			buffer  += SysAllocString(playerInfo[i].bstrName);
			buffer  += ",";
			buffer	+= (const char*)temp;
			buffer	+= ",";
			buffer	+= SysAllocString(playerInfo[i].bstrIPAddress);
			buffer	+= ",";				
			buffer	+= SysAllocString(playerInfo[i].bstrHostName);

			if ((i + 1) < size)
			{
				buffer += ";";
			}

			// clean up
			SysFreeString(playerInfo[i].bstrName);
			SysFreeString(playerInfo[i].bstrIPAddress);
			SysFreeString(playerInfo[i].bstrHostName);
		}	
		delete[] playerInfo;
		playerInfo = NULL;
		
		*gameState = buffer.Detach();
	}

	return S_OK;
}

STDMETHODIMP CTankClientControl::GetPlayerID(SHORT* playerID)
{
	if (m_state == GameStarted)
	{
		*playerID = m_tankGame.m_nPlayerId;
	}
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_MoveRight(BSTR newVal)
{
	USES_CONVERSION;
	CString temp(OLE2T(newVal));
	m_moveRight = String2CommandChar(temp);
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_MoveLeft(BSTR newVal)
{
	USES_CONVERSION;
	CString temp(OLE2T(newVal));
	m_moveLeft = String2CommandChar(temp);
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_MoveForward(BSTR newVal)
{
	USES_CONVERSION;
	CString temp(OLE2T(newVal));
	m_moveForward = String2CommandChar(temp);
	return S_OK;
}

STDMETHODIMP CTankClientControl::put_Shoot(BSTR newVal)
{
	USES_CONVERSION;
	CString temp(OLE2T(newVal));
	m_shoot = String2CommandChar(temp);
	return S_OK;
}

char CTankClientControl::String2CommandChar(const CString& str)
{
	if (str == "UP")
	{
		return VK_UP;
	}
	else if (str == "LEFT")
	{
		return VK_LEFT;
	}
	else if (str == "RIGHT")
	{
		return VK_RIGHT;
	}
	else if (str == "SPACE")
	{
		return ' ';
	}
	else
	{
		return (char)str[0];
	}
}

STDMETHODIMP CTankClientControl::Start(void)
{	
	m_state = ReadyToStart;
	return S_OK;
}
