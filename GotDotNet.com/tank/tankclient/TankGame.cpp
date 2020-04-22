#include "StdAfx.h"
#include "tankgame.h"

CTankGame::CTankGame()
			:	m_hWnd(NULL),					
				m_hMapBitmap(NULL),
				m_hBmpFrame(NULL),
				m_hMemDC(NULL),			
				m_nPlayerId(-1),			
				m_nTurnDir(-1),
				m_nWidth(0),
				m_nHeight(0),
				m_nDone(0),
				m_gameCommand(GAME_COMMAND_NONE),
				m_prevGameCommand(GAME_COMMAND_NONE)			
{		
	ZeroMemory(&m_gameState, sizeof(m_gameState));
	AtlCleanupValue(&m_gameState);

	// Set the done event in the set case initially so that we won't hang
	// if someone calls StopGame before calling StartGame.
	HANDLE temp = CreateEvent(NULL, FALSE, TRUE, NULL);
	m_hDoneEvent.Attach(temp);
}

CTankGame::~CTankGame()
{	
	if (m_hMapBitmap)
	{
		DeleteObject(m_hMapBitmap);
		m_hMapBitmap = NULL;
	}

	if (m_hBmpFrame)
	{
		DeleteObject(m_hBmpFrame);
		m_hBmpFrame = NULL;
	}

	if (m_hMemDC)
	{
		DeleteDC(m_hMemDC);
		m_hMemDC = NULL;
	}

	// free the bitmaps
	for (int o = 0; o < NUM_COLORS; o++)
	{
		for (int i = 0; i < NUM_DIRS; i++)
		{
			DeleteObject(m_hBitmaps[o][i]);
		}
	}		
}

void CTankGame::SetTankServerURL(LPCSTR url)
{
	m_tankService.SetUrl(url);
}

bool CTankGame::Initialize(HWND hwnd, LPCSTR url)
{		
	ATLASSERT(hwnd);	
	if (!hwnd)
	{
		MessageBox(NULL, "HWND IS NULL", NULL, NULL);
		return false;
	}
	m_hWnd = hwnd;
	
	// load the tank bitmaps
	UINT uIdResource = IDB_TANK_0;	
	for (int o = 0; o < NUM_COLORS; o++)
	{
		for (int i = 0; i < NUM_DIRS; i++)
		{					
			m_hBitmaps[o][i] = LoadBitmap(GetModuleHandle("TankClient.dll"), MAKEINTRESOURCE(uIdResource));			
			uIdResource++;
		}
	}

	// shorten the time out on our web service
	m_tankService.SetTimeout(SERVICE_TIMEOUT);	

	// point our web service proxy at the specify url
	m_tankService.SetUrl(url);

	// try to get the game map
	HRESULT hr = m_tankService.GetMap(&m_mapData, &m_nWidth, &m_nHeight);
	if (FAILED(hr))
	{
		MessageBox(NULL, "GET MAP FAILED", NULL, NULL);
		return false;
	}

	HDC hDC = GetDC(NULL);
	if (!hDC)
	{
		return false;
	}

	m_hMemDC = CreateCompatibleDC(hDC);
	if (!m_hMemDC)
	{
		return false;
	}

	m_hMapBitmap = CreateCompatibleBitmap(hDC, 
										  m_nWidth  * TILE_WIDTH, 
										  m_nHeight * TILE_HEIGHT);
	if (!m_hMapBitmap)
	{
		m_tankService.Logout(m_nPlayerId);

		return false;
	}

	m_hBmpFrame = CreateCompatibleBitmap(hDC, 
										 m_nWidth  * TILE_WIDTH, 
										 m_nHeight * TILE_HEIGHT);
	if (!m_hBmpFrame)
	{
		m_tankService.Logout(m_nPlayerId);
	
		return false;
	}

	SelectObject(m_hMemDC, m_hMapBitmap);

	RenderMap(m_hMemDC);
	ReleaseDC(NULL, hDC);

	return true;
}

bool CTankGame::Login(LPCSTR userName)
{
	// try to login
	HRESULT hr = m_tankService.Login(CComBSTR(userName), &m_nPlayerId);
	if (FAILED(hr))
	{
		return false;
	}
	
	return true;
}
	
// Note, it is the caller's responsibility to make sure that we are being hosted
// in a properly initialized window environment.
void CTankGame::StartGame()
{
	// set the done event to be not done
	if (!ResetEvent(m_hDoneEvent))
	{
		// if we can't set the done event, get out now because we won't 
		// be able to exit the game
		return;
	}

	// start our frame timer
	m_frameTimer.Start();

	// InterlockedCompareExchange will return 0 as long as m_nDone == 0, which means
	// we are not done playing yet.
	m_gameCommand = GAME_COMMAND_NONE;	
	while (!InterlockedCompareExchange(&m_nDone, 0, 0))
	{			
		m_commandCS.Lock();
		if (m_nPlayerId < 0)
		{
			continue;
		}

		// Initialize game state to be empty, we'll get a value 
		// for it from our tank service.		
		AtlCleanupValue(&m_gameState);
	
		HRESULT hr(E_FAIL);
		switch (m_gameCommand)
		{
			case GAME_COMMAND_NONE:
			{
				hr = m_tankService.GetGameState(m_nPlayerId, &m_gameState);						
				break;
			}

			case GAME_COMMAND_MOVE:
			{
				hr = m_tankService.Move(m_nPlayerId, &m_gameState);						
				m_prevGameCommand = m_gameCommand;
				break;
			}

			case GAME_COMMAND_TURN:
			{
				hr = m_tankService.Turn(m_nPlayerId, m_nTurnDir, &m_gameState);			
				m_prevGameCommand = m_gameCommand;
				break;
			}

			case GAME_COMMAND_SHOOT:
			{				
				hr = m_tankService.Shoot(m_nPlayerId, &m_gameState);					
				m_prevGameCommand = m_gameCommand;
				break;
			}
		}		
#if 0
		// See if the user is trying to move or shoot in addition to the 
		// game command that we just processed
		if (m_prevGameCommand != GAME_COMMAND_MOVE)
		{
			if ((GetKeyState(VK_UP) & 32768))
			{					
				hr = m_tankService.Move(m_nPlayerId, &m_gameState);
			}					
		}

		if (m_prevGameCommand != GAME_COMMAND_SHOOT)	
		{
			if ((GetKeyState(' ') & 32768))
			{	
				hr = m_tankService.Shoot(m_nPlayerId, &m_gameState);
			}	
		}
#endif
		m_gameCommand = GAME_COMMAND_NONE;
		m_commandCS.Unlock();

		if (m_frameTimer.NextFrame())
		{
			if (m_hMapBitmap)
			{
				HDC hDC = ::GetDC(m_hWnd);				
				if (hDC)
				{
					RenderFrame(hDC);	
					ReleaseDC(m_hWnd, hDC);
				}
			}
		}				
	}

	// signal that we're done!
	SetEvent(m_hDoneEvent);
}

void CTankGame::StopGame()
{
	// flip the done flag so that the loop in
	// startGame will exit
	InterlockedIncrement(&m_nDone);

	// wait for that loop to finish
	WaitForSingleObject(m_hDoneEvent, INFINITE);
		
	// log out
	Logout();
}

void CTankGame::Logout()
{		
	if (m_nPlayerId >= 0)
	{
		m_tankService.Logout(m_nPlayerId);
		m_nPlayerId = -1;
	}
}

void CTankGame::RenderFrame(HDC hDC)
{	
	RECT rctClient;	
	GetClientRect(m_hWnd, &rctClient);

	HDC hMemDC		= CreateCompatibleDC(hDC);
	HDC hMemDCFrame = CreateCompatibleDC(hDC);
	
	ATLASSERT(hMemDC != NULL);
	ATLASSERT(hMemDCFrame != NULL);
	
	if (!hMemDC || !hMemDCFrame)
	{
		return;
	}
	
	SelectObject(hMemDCFrame, m_hBmpFrame);

	ATLASSERT(m_hBmpFrame);

	if (m_hMapBitmap)
	{
		BitBlt(	hMemDCFrame, 
				0, 
				0, 
				m_nWidth  * TILE_WIDTH, 
				m_nHeight * TILE_HEIGHT, 
				m_hMemDC, 
				0, 
				0, 
				SRCCOPY);
	}
	
	// draw the players	
	// CFixedStringT<CString, 256> strPlayers;
	for (int i = 0; i < m_gameState.nPlayerCount; i++)
	{
		// select the appropriate bitmap
		int nBmpIndex    = m_gameState.Players[i].nAngle/45;
		int nPlayerIndex = 1;

		if (m_gameState.Players[i].nPlayerId == m_nPlayerId)
		{
			nPlayerIndex = 0;
		}

		HBITMAP hOldBmp = (HBITMAP) SelectObject(hMemDC, m_hBitmaps[nPlayerIndex][nBmpIndex]);			

		BitBlt(	hMemDCFrame, 
				m_gameState.Players[i].x * TILE_WIDTH, 
				m_gameState.Players[i].y * TILE_HEIGHT,
				TILE_WIDTH, 
				TILE_HEIGHT, 
				hMemDC, 
				0,
				0, 
				SRCCOPY);

		SelectObject(hMemDC, hOldBmp);
#if 0
		char szTmp[100];
		szTmp[0] = 0;

		strPlayers.Append(CW2A(m_gameState.Players[i].bstrName));
		strPlayers.AppendChar(' ');
		
		itoa(m_gameState.Players[i].nScore, szTmp, 10);
		szTmp[99] = 0;

		strPlayers.Append(szTmp);
		szTmp[0] = 0;

		strPlayers.AppendChar('/');
		itoa(m_gameState.Players[i].nKills, szTmp, 10);
		szTmp[99] = 0;

		strPlayers.Append(szTmp);
		szTmp[0] = 0;

		strPlayers.AppendChar('\n');
#endif
	}

	// draw the projectiles
	for (int i = 0; i < m_gameState.nProjectileCount; i++)
	{
		RECT rct;
		rct.left   = m_gameState.Projectiles[i].x*TILE_WIDTH+TILE_WIDTH/2-2;
		rct.top    = m_gameState.Projectiles[i].y*TILE_HEIGHT+TILE_HEIGHT/2-2;
		rct.right  = rct.left + 4;
		rct.bottom = rct.top  + 4;

		FillRect(hMemDCFrame, &rct, (HBRUSH) GetStockObject(BLACK_BRUSH));
	}

	BitBlt(	hDC, 
			0, 
			0, 
			m_nWidth  * TILE_WIDTH, 
			m_nHeight * TILE_HEIGHT, 
			hMemDCFrame, 
			0, 
			0, 
			SRCCOPY);
#if 0
	// draw the player scores
	RECT rctText;
	
	rctText		 = rctClient;
	rctText.left = m_nWidth * TILE_WIDTH;
	
	DrawText(hDC, strPlayers, -1, &rctText, DT_LEFT|DT_CALCRECT);
	DrawText(hDC, strPlayers, -1, &rctText, DT_LEFT);
	
	rctText.top    = rctText.bottom;
	rctText.bottom = rctClient.bottom;

	FillRect(hDC, &rctText, (HBRUSH) GetStockObject(WHITE_BRUSH));
#endif
	DeleteDC(hMemDC);
	DeleteDC(hMemDCFrame);
}

void CTankGame::RenderMap(HDC hDC)
{
	if (!hDC)
	{
		ATLASSERT(m_hMemDC);
		if (!m_hMemDC)
		{
			return;
		}

		hDC = m_hMemDC;
	}
	
	BYTE *pb = m_mapData.data;

	RECT rct;
	rct.left = 0;
	rct.top = 0;
	rct.right = TILE_WIDTH;
	rct.bottom = TILE_HEIGHT;

	RECT rctAll;
	rctAll.left = 0;
	rctAll.top = 0;
	rctAll.right = TILE_WIDTH * m_nWidth;
	rctAll.bottom = TILE_WIDTH * m_nHeight;

	FillRect(hDC, &rctAll, (HBRUSH) GetStockObject(WHITE_BRUSH));

	// draw the map if we have it
	for (int y = 0; y < m_nHeight; y++)
	{	
		for (int x = 0; x < m_nWidth; x++)
		{
			if (*pb == (BYTE) -1)
			{
				// the tile is blocked
				FillRect(hDC, &rct, (HBRUSH) GetStockObject(BLACK_BRUSH));
			}
			pb++;
			rct.left += TILE_WIDTH;
			rct.right += TILE_WIDTH;
		}

		rct.left	= 0;
		rct.right	= TILE_WIDTH;
		rct.top		+= TILE_HEIGHT;
		rct.bottom	+= TILE_HEIGHT;
	}
}

void CTankGame::MoveLeft()
{
	m_commandCS.Lock();
	m_nTurnDir = 1;
	m_gameCommand = GAME_COMMAND_TURN;
	m_commandCS.Unlock();
}

void CTankGame::MoveRight()
{
	m_commandCS.Lock();
	m_nTurnDir = -1;
	m_gameCommand = GAME_COMMAND_TURN;
	m_commandCS.Unlock();
}

void CTankGame::MoveForward()
{	
	m_commandCS.Lock();
	m_gameCommand = GAME_COMMAND_MOVE;
	m_commandCS.Unlock();
}

void CTankGame::Shoot()
{
	m_commandCS.Lock();
	m_gameCommand = GAME_COMMAND_SHOOT;
	m_commandCS.Unlock();
}

int CTankGame::GetPlayerScore()
{
	return m_gameState.Players[m_nPlayerId].nScore;
}	

int CTankGame::GetPlayerInfo(PlayerInfo **players)
{
	// lock the game state
	m_commandCS.Lock();

	int numPlayers(0);
	numPlayers = m_gameState.nPlayerCount;

	if (numPlayers)
	{		
		// make a copy of the game state
		*players = (PlayerInfo*) malloc(sizeof(PlayerInfo) * numPlayers);
	
		for (int i = 0; i < numPlayers; i++)
		{
			(*players)[i].bstrName		= SysAllocString(m_gameState.Players[i].bstrName);
			(*players)[i].bstrIPAddress = SysAllocString(m_gameState.Players[i].bstrIPAddress);
			(*players)[i].bstrHostName  = SysAllocString(m_gameState.Players[i].bstrHostName);

			(*players)[i].nAngle		= m_gameState.Players[i].nAngle;
			(*players)[i].nKills		= m_gameState.Players[i].nKills;
			(*players)[i].nPlayerId		= m_gameState.Players[i].nPlayerId;
			(*players)[i].nScore		= m_gameState.Players[i].nScore;
		}	
		m_commandCS.Unlock();	
	}

	return numPlayers;
}	