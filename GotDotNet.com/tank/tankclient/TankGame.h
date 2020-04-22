#pragma once

#include "stdafx.h"
#include "resource.h"
#include "frametimer.h"
#include <windows.h>
#include <atlcore.h>

#include "TankGameService.h"

using namespace TankSvrService;

static const int	SERVICE_TIMEOUT  = 10000;
static const int	NUM_DIRS		 = 8;
static const int	NUM_COLORS		 = 2;
static const int	TILE_WIDTH		 = 20;
static const int	TILE_HEIGHT		 = 20;
static const CHAR*	TANK_SERVICE_URL = "http://localhost/tanksvr/tanksvr.dll?Handler=Default";

enum GAME_COMMAND 
{ 
	GAME_COMMAND_NONE, 
	GAME_COMMAND_MOVE, 
	GAME_COMMAND_TURN,
	GAME_COMMAND_SHOOT 
};

class CTankGame
{
private:
	HWND			m_hWnd;	
	HBITMAP			m_hBitmaps[NUM_COLORS][NUM_DIRS];
	HBITMAP			m_hMapBitmap;
	HBITMAP			m_hBmpFrame;
	HDC				m_hMemDC;
	GAME_COMMAND	m_gameCommand;
	GAME_COMMAND	m_prevGameCommand;

	int				m_nTurnDir;
	int				m_nWidth;
	int				m_nHeight;
	long			m_nDone;

	IOleInPlaceSite*				m_site;
	CHandle							m_hDoneEvent;
	ATL::CComAutoCriticalSection	m_commandCS;
	TankSvrService::CTankSvrService m_tankService;
	CFrameTimer						m_frameTimer;	
	ATLSOAP_BLOB					m_mapData;
	TankSvrService::GameState		m_gameState;

public:
	int	m_nPlayerId;	

public:
	CTankGame();
	~CTankGame();

	void SetTankServerURL(LPCSTR url);		
	bool Initialize(HWND hwnd, LPCSTR url = TANK_SERVICE_URL);	
	bool Login(LPCSTR userName);
	void StartGame();
	void StopGame();
	
	int GetPlayerInfo(PlayerInfo **players);

	int	 GetPlayerScore();

	void RenderFrame(HDC hDC);
	void RenderMap(HDC hDC);
	void MoveLeft();
	void MoveRight();
	void MoveForward();
	void Move();
	void Shoot();	

private:
	void Logout();
};