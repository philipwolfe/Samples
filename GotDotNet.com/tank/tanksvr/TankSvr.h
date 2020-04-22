// TankSvr.h : Defines the ATL Server request handler class
//
#pragma once

namespace TankSvrService
{
// all struct, enum, and typedefs for your webservice should go inside the namespace
[ export ]
struct PlayerInfo
{
	int		nPlayerId;
	int		x;
	int		y;
	int		nAngle;		// player angle.  0=East, 90=North
	int		nScore;
	int		nKills;
	BSTR	bstrIPAddress;
	BSTR	bstrHostName;
	BSTR	bstrName;
};

[ export ]
struct ProjectileInfo
{
	int nPlayerId;	// player that owns it
	int x;			// x coordinate
	int y;			// y coordinate
	int dx;			// x dir
	int dy;			// y dir
};

[ export ]
struct GameState
{
	[ size_is(nPlayerCount) ] PlayerInfo *Players;
	int nPlayerCount;

	[ size_is(nProjectileCount) ] ProjectileInfo *Projectiles;
	int nProjectileCount;
};

// ITankSvrService - web service interface declaration
//
[
	uuid("A9EC3F3F-4E25-4EB0-9629-5F2C9369F876"), 
	object
]
__interface ITankSvrService
{
	[id(2)] HRESULT Login([in] BSTR strPlayerName, [out, retval] int *nPlayerId);
	[id(3)] HRESULT Logout([in] int nPlayerId);
	[id(4)] HRESULT GetGameState([in] int nPlayerId, [out,retval] GameState *pGameState);
	[id(5)] HRESULT GetMap([out] int *pnWidth, [out] int *pnHeight, [out,retval] ATLSOAP_BLOB *pData);
	[id(6)] HRESULT Move([in] int nPlayerId, [out,retval] GameState *pGameState);
	[id(7)] HRESULT Turn([in] int nPlayerId, [in] int nDir, [out,retval] GameState *pGameState);
	[id(8)] HRESULT Shoot([in] int nPlayerId, [out,retval] GameState *pGameState);
	[id(9)] HTTP_CODE CompleteRequest();
};

#define MAP_WIDTH		15
#define MAP_HEIGHT		15
#define MAX_PLAYER_NAME 32
#define MAX_PLAYERS		10

enum GAME_COMMAND { GAME_COMMAND_NONE=0, 
					GAME_COMMAND_GETSTATE, 
					GAME_COMMAND_MOVE, 
					GAME_COMMAND_TURN, 
					GAME_COMMAND_SHOOT };

BOOL g_bInitialized = FALSE;

struct GameCommand
{
	GAME_COMMAND	cmd;	
	int				nTurnDir;	
	GameState		*pGameState;
	IAtlMemMgr		*pMemMgr;
	ITankSvrService *pHandler;
};

struct InternalPlayerInfo : public PlayerInfo
{
	GameCommand		gameCommand;
	ProjectileInfo	projectile;
};

class CTankService : public IWorkerThreadClient
{
public:
	// internal data structures
	#define	TILE_EMPTY ((BYTE)-2)
	#define TILE_BLOCKED ((BYTE)-1)

	BYTE m_Map[MAP_HEIGHT][MAP_WIDTH];
	CComCriticalSection m_cs;

	InternalPlayerInfo m_Players[MAX_PLAYERS];
	int m_nNumPlayers;

	CWorkerThread<> m_WorkerThread;
	HANDLE m_hTimer;

	CTankService()
	{
		// initialize player data
		for (int i = 0; i < MAX_PLAYERS; i++)
		{
			ZeroMemory(&(m_Players[i]), sizeof(InternalPlayerInfo));
			ZeroMemory(&(m_Players[i].projectile), sizeof(ProjectileInfo));
			ZeroMemory(&(m_Players[i].gameCommand), sizeof(GameCommand));

			m_Players[i].gameCommand.cmd = GAME_COMMAND_NONE;
		}		
	}

	~CTankService()
	{
		HRESULT hr = m_cs.Term();
		ATLASSERT(SUCCEEDED(hr));

		hr = m_WorkerThread.Shutdown();

		if (FAILED(hr))
		{
			// try a couple of times to shut this thread down
			for (int i = 0; i < 5 && FAILED(hr); i++)			
			{
				hr = m_WorkerThread.Shutdown();
			}
		}
		ATLASSERT(SUCCEEDED(hr));
	}

	HRESULT Execute(DWORD dwParam, HANDLE hObject)
	{
		ATLASSERT(hObject);
		if (!hObject)
		{
			return E_INVALIDARG;
		}

		// run the game
		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		// walk the player struct and see if they have any
		// requests pending
		int i;
		for (i = 0; i < MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName == NULL)
				continue;

			// execute the request
			switch (m_Players[i].gameCommand.cmd)
			{
				case GAME_COMMAND_NONE:
					break;

				case GAME_COMMAND_GETSTATE:
					// we get this later
					break;

				case GAME_COMMAND_MOVE:
					RealMove(i);
					break;
				
				case GAME_COMMAND_TURN:
					RealTurn(i);
					break;

				case GAME_COMMAND_SHOOT:
					RealShoot(i);
					break;
			}
		}

		ProjectileInfo projectiles[MAX_PLAYERS];
		int nProjectileCount = 0;

		// process projectiles
		for (i = 0; i < MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName == NULL)
				continue;

			if (!m_Players[i].projectile.dx && !m_Players[i].projectile.dy)
				continue;

			// check for a kill or a collision
			BYTE bTile = m_Map[m_Players[i].projectile.y][m_Players[i].projectile.x];
			if (bTile != (BYTE) TILE_EMPTY)
			{
				// we hit something
				if (bTile != TILE_BLOCKED)
				{
					// kill the other player
					m_Players[bTile].nKills++;
					m_Map[m_Players[i].projectile.y][m_Players[i].projectile.x] = TILE_EMPTY;
					FindEmptyMapTile(&m_Players[bTile].x, &m_Players[bTile].y);

					m_Map[m_Players[bTile].y][m_Players[bTile].x] = bTile;

					// add to the score of the current player
					m_Players[i].nScore++;
				}
				m_Players[i].projectile.dx = 0;
				m_Players[i].projectile.dy = 0;
			}
			if (m_Players[i].projectile.dx || m_Players[i].projectile.dy)
			{
				memcpy(&projectiles[nProjectileCount], &m_Players[i].projectile, sizeof(ProjectileInfo));
				nProjectileCount++;
			}
		}

		// now send out all the responses to the clients
		for (i = 0; i < MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName == NULL)
				continue;

			if (m_Players[i].gameCommand.cmd != GAME_COMMAND_NONE)
			{
				RealGetGameState(i, projectiles, nProjectileCount);
				m_Players[i].gameCommand.pHandler->CompleteRequest();
			}

			// clear out all the command information
			memset(&m_Players[i].gameCommand, 0x00, sizeof(GameCommand));
			
		}

		// process projectiles
		for (i = 0; i < MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName == NULL)
				continue;

			if (!m_Players[i].projectile.dx && !m_Players[i].projectile.dy)
				continue;

			// move the projectile
			m_Players[i].projectile.x += m_Players[i].projectile.dx;
			m_Players[i].projectile.y += m_Players[i].projectile.dy;

			if (m_Players[i].projectile.x < 0 || m_Players[i].projectile.x >= MAP_WIDTH ||
				m_Players[i].projectile.y < 0 || m_Players[i].projectile.y >= MAP_HEIGHT)
			{
				m_Players[i].projectile.dx = m_Players[i].projectile.dy = 0;
			}
		}
		
		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;
	}

	void RealMove(int nPlayerId)
	{
		int x = m_Players[nPlayerId].x;
		int y = m_Players[nPlayerId].y;
		
		switch (m_Players[nPlayerId].nAngle)
		{
			case 0:
				x++;
				break;
			case 45:
				x++;
				y--;
				break;
			case 90:
				y--;
				break;
			case 135:
				x--;
				y--;
				break;
			case 180:
				x--;
				break;
			case 225:
				x--;
				y++;
				break;
			case 270:
				y++;
				break;
			case 315:
				x++;
				y++;
				break;
		}

		// check for collisions
		if (x < 0)
			x = 0;
		else if (x >= MAP_WIDTH)
			x = MAP_WIDTH-1;
		if (y < 0)
			y = 0;
		else if (y >= MAP_HEIGHT)
			y = MAP_HEIGHT-1;

		if (m_Map[y][x] != TILE_EMPTY)
			return;

		m_Map[m_Players[nPlayerId].y][m_Players[nPlayerId].x] = TILE_EMPTY;
		m_Players[nPlayerId].x = x;
		m_Players[nPlayerId].y = y;
		m_Map[y][x] = (BYTE) nPlayerId;
	}

	void RealTurn(int nPlayerId)
	{
		InternalPlayerInfo *pInfo = &m_Players[nPlayerId];
		int nDir = pInfo->gameCommand.nTurnDir;
		pInfo->nAngle += 45*nDir;
		if (pInfo->nAngle < 0)
			pInfo->nAngle = 315;
		else if (pInfo->nAngle == 360)
			pInfo->nAngle = 0;
	}

	void RealShoot(int nPlayerId)
	{
		// check if the player already has a projectile
		if (m_Players[nPlayerId].projectile.dx || m_Players[nPlayerId].projectile.dy)
		{
			return;
		}
		int x = m_Players[nPlayerId].x;
		int y = m_Players[nPlayerId].y;
		int dx = 0;
		int dy = 0;

		switch (m_Players[nPlayerId].nAngle)
		{
			case 0:
				dx = 1;
				break;
			case 45:
				dx = 1;
				dy = -1;
				break;
			case 90:
				dy = -1;
				break;
			case 135:
				dx = -1;
				dy = -1;
				break;
			case 180:
				dx = -1;
				break;
			case 225:
				dx = -1;
				dy = 1;
				break;
			case 270:
				dy = 1;
				break;
			case 315:
				dx = 1;
				dy = 1;
				break;
		}

		x += dx;
		y += dy;

		// check if it is out of bounds
		if (x < 0 || x >= MAP_WIDTH || y < 0 || y >= MAP_HEIGHT)
		{
			dx = 0;
			dy = 0;
		}
		m_Players[nPlayerId].projectile.x = x;
		m_Players[nPlayerId].projectile.y = y;
		m_Players[nPlayerId].projectile.dx = dx;
		m_Players[nPlayerId].projectile.dy = dy;
	}

	void RealGetGameState(int nPlayerId, ProjectileInfo *pProjectileInfo, int nProjectileCount)
	{
		IAtlMemMgr	*pMemMgr	= m_Players[nPlayerId].gameCommand.pMemMgr;
		GameState	*pGameState = m_Players[nPlayerId].gameCommand.pGameState;

		ATLASSERT(pMemMgr);
		ATLASSERT(pGameState);

		if (!pMemMgr || !pGameState)
		{
			return;
		}

		pGameState->nPlayerCount = m_nNumPlayers;
		pGameState->Players = (PlayerInfo *) pMemMgr->Allocate(sizeof(PlayerInfo)*m_nNumPlayers);

		if (nProjectileCount > 0)
		{
			pGameState->Projectiles = (ProjectileInfo *) pMemMgr->Allocate(sizeof(ProjectileInfo)*nProjectileCount);
			memcpy(pGameState->Projectiles, pProjectileInfo, nProjectileCount*sizeof(ProjectileInfo));
			pGameState->nProjectileCount = nProjectileCount;
		}

		if (!pGameState->Players)
			return;

		memset(pGameState->Players, 0x00, sizeof(PlayerInfo)*m_nNumPlayers);

		// now loop through and copy the valid players
		PlayerInfo *pPlayer = pGameState->Players;
		for (int i=0; i<MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName)
			{
				pPlayer->bstrName		= SysAllocString(m_Players[i].bstrName);
				pPlayer->bstrIPAddress	= SysAllocString(m_Players[i].bstrIPAddress);
				pPlayer->bstrHostName   = SysAllocString(m_Players[i].bstrHostName);

				pPlayer->nPlayerId = i;
				pPlayer->x = m_Players[i].x;
				pPlayer->y = m_Players[i].y;
				pPlayer->nAngle = m_Players[i].nAngle;
				pPlayer->nScore = m_Players[i].nScore;
				pPlayer->nKills = m_Players[i].nKills;
				pPlayer++;
			}
		}
	}

	HRESULT CloseHandle(HANDLE hHandle)
	{
		if (hHandle)
		{
			::CloseHandle(hHandle);	
		}
#if 0
		if (m_hTimer)
		{
			::CloseHandle(m_hTimer);
			m_hTimer = NULL;
		}
#endif
		return S_OK;
	}

	HRESULT InitGame()
	{
		for (int y = 0; y < MAP_HEIGHT; y++)
		{
			for (int x = 0; x < MAP_WIDTH; x++)
			{
				if (rand()%100 < 20)
					m_Map[y][x] = TILE_BLOCKED;
				else
					m_Map[y][x] = TILE_EMPTY;
			}
		}
		memset(m_Players, 0x00, sizeof(m_Players));
		m_nNumPlayers = 0;

		HRESULT hr = m_cs.Init();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		hr = m_WorkerThread.Initialize();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		hr = m_WorkerThread.AddTimer(30, this, 0, &m_hTimer);
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}		

		g_bInitialized = TRUE;
		return S_OK;
	}

	int FindEmptyPlayerSlot()
	{
		for (int i = 0; i < MAX_PLAYERS; i++)
		{
			if (m_Players[i].bstrName == NULL)
				return i;
		}
		return -1;
	}

	void FindEmptyMapTile(int *px, int *py)
	{
		int x;
		int y;

		for (y = rand()%MAP_HEIGHT; y < MAP_HEIGHT; y++)
		{
			for (x = rand()%MAP_WIDTH; x < MAP_WIDTH; x++)
			{
				if (m_Map[y][x] == TILE_EMPTY)
				{
					*px = x;
					*py = y;
					return;
				}
			}
		}
		for (y = 0; y < MAP_HEIGHT; y++)
		{
			for (x = 0; x < MAP_WIDTH; x++)
			{
				if (m_Map[y][x] == TILE_EMPTY)
				{
					*px = x;
					*py = y;
					return;
				}
			}
		}
	}

	bool IsValidPlayer(int nPlayerId)
	{
		if (nPlayerId < 0 || nPlayerId >= MAX_PLAYERS || m_Players[nPlayerId].bstrName == NULL)		
			return false;

		return true;
	}

	HRESULT Login(BSTR strPlayerName, BSTR strPlayerIPAddress, BSTR strPlayerHostName, int *nPlayerId)
	{
		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));

		if (FAILED(hr))
		{
			return hr;
		}

		if (!strPlayerName || strPlayerName[0] == '\0')
		{
			m_cs.Unlock();
			return E_FAIL;
		}

		int nIndex = FindEmptyPlayerSlot();
		if (nIndex < 0)
		{
			m_cs.Unlock();
			return E_FAIL;
		}

		InternalPlayerInfo *pInfo = &m_Players[nIndex];
		
		// store the player's name
		if (pInfo->bstrName)
		{
			SysFreeString(pInfo->bstrName);
			pInfo->bstrName = NULL;
		}
		pInfo->bstrName = SysAllocString(strPlayerName);

		// store the player's IP address
		if (pInfo->bstrIPAddress)
		{
			SysFreeString(pInfo->bstrIPAddress);
			pInfo->bstrIPAddress = NULL;
		}
		pInfo->bstrIPAddress = SysAllocString(strPlayerIPAddress);

		// store the player's host name
		if (pInfo->bstrHostName)
		{
			SysFreeString(pInfo->bstrHostName);
			pInfo->bstrHostName = NULL;
		}
		pInfo->bstrHostName = SysAllocString(strPlayerHostName);

		pInfo->nPlayerId = nIndex;
		m_nNumPlayers++;

		FindEmptyMapTile(&pInfo->x, &pInfo->y);
		m_Map[pInfo->y][pInfo->x] = (BYTE) pInfo->nPlayerId;
		pInfo->nAngle = 0;
		pInfo->nScore = 0;
		pInfo->nKills = 0;
		
		*nPlayerId = nIndex;

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;		
	}

	HRESULT Logout(int nPlayerId)
	{
		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}	

		if (!IsValidPlayer(nPlayerId))
		{
			m_cs.Unlock();
			return E_INVALIDARG;
		}

		// remove the player from the map
		m_Map[m_Players[nPlayerId].y][m_Players[nPlayerId].x] = TILE_EMPTY;
		if (m_Players[nPlayerId].bstrName != NULL)
		{
			SysFreeString(m_Players[nPlayerId].bstrName);
			m_Players[nPlayerId].bstrName = NULL;
		}
		m_nNumPlayers--;

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;
	}

	HRESULT GetGameState(int			 nPlayerId, 
						 GameState		 *pGameState, 
						 IAtlMemMgr		 *pMemMgr, 
						 ITankSvrService *pHandler)
	{
		ATLASSERT(nPlayerId >= 0);
		ATLASSERT(pGameState);
		ATLASSERT(pMemMgr);
		ATLASSERT(pHandler);

		if (nPlayerId < 0 || !pGameState || !pMemMgr || !pHandler)
		{
			return E_FAIL;
		}

		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		if (!IsValidPlayer(nPlayerId))
		{
			m_cs.Unlock();
			return E_INVALIDARG;
		}
		
		if (m_Players[nPlayerId].gameCommand.cmd != GAME_COMMAND_NONE)
		{
			m_cs.Unlock();
			return E_FAIL;
		}

		m_Players[nPlayerId].gameCommand.cmd		= GAME_COMMAND_GETSTATE;
		m_Players[nPlayerId].gameCommand.pGameState = pGameState;
		m_Players[nPlayerId].gameCommand.pMemMgr	= pMemMgr;
		m_Players[nPlayerId].gameCommand.pHandler	= pHandler;


		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;		
	}

	HRESULT GetMap(	int			 *pnWidth, 
					int			 *pnHeight, 
					ATLSOAP_BLOB *pData, 
					IAtlMemMgr	 *pMemMgr)
	{
		ATLASSERT(pnWidth);
		ATLASSERT(pnHeight);
		ATLASSERT(pData);
		ATLASSERT(pMemMgr);

		if (!pnWidth || !pnHeight || !pData || !pMemMgr)
		{
			return E_FAIL;
		}

		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		*pnWidth  = MAP_WIDTH;
		*pnHeight = MAP_HEIGHT;

		pData->data = (unsigned char *) pMemMgr->Allocate(MAP_WIDTH*MAP_HEIGHT);

		ATLASSERT(pData->data);		
		if (!pData->data)
		{
			m_cs.Unlock();
			return E_OUTOFMEMORY;
		}

		pData->size = MAP_WIDTH*MAP_HEIGHT;

		void *errorCheck(NULL);
		errorCheck = memcpy(pData->data, m_Map, MAP_WIDTH*MAP_HEIGHT);

		ATLASSERT(errorCheck);
		if (!errorCheck)
		{
			return E_FAIL;
		}

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;		
	}

	// nDir, positive means move forward, negative mean move backwards
	HRESULT Move(int			 nPlayerId, 
				 GameState		 *pGameState, 
				 IAtlMemMgr		 *pMemMgr,
				 ITankSvrService *pHandler)
	{
		ATLASSERT(nPlayerId >= 0);
		ATLASSERT(pGameState);
		ATLASSERT(pMemMgr);
		ATLASSERT(pHandler);
		
		if (nPlayerId < 0 || !pGameState || !pMemMgr || !pHandler)
		{
			return E_INVALIDARG;
		}
		
		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		if (!IsValidPlayer(nPlayerId))
		{
			m_cs.Unlock();
			return E_INVALIDARG;
		}

		if (m_Players[nPlayerId].gameCommand.cmd != GAME_COMMAND_NONE)
		{
			m_cs.Unlock();
			return E_FAIL;
		}

		m_Players[nPlayerId].gameCommand.cmd		= GAME_COMMAND_MOVE;		
		m_Players[nPlayerId].gameCommand.pGameState = pGameState;		
		m_Players[nPlayerId].gameCommand.pMemMgr	= pMemMgr;
		m_Players[nPlayerId].gameCommand.pHandler	= pHandler;

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;
	}

	// nDir, positive means counter-clockwise, negative means clockwise
	HRESULT Turn(int			 nPlayerId, 
				 int			 nDir, 
				 GameState		 *pGameState, 
				 IAtlMemMgr		 *pMemMgr,
				 ITankSvrService *pHandler)
	{
		ATLASSERT(nPlayerId >= 0);
		ATLASSERT(pGameState);
		ATLASSERT(pMemMgr);
		ATLASSERT(pHandler);

		if (nPlayerId < 0 || !pGameState || !pMemMgr || !pHandler)
		{
			return E_INVALIDARG;
		}

		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		if (!IsValidPlayer(nPlayerId))
		{
			m_cs.Unlock();
			return E_INVALIDARG;
		}

		if (m_Players[nPlayerId].gameCommand.cmd != GAME_COMMAND_NONE)
		{
			m_cs.Unlock();
			return E_FAIL;
		}

		if (nDir == 0)
		{
			m_cs.Unlock();
			return S_OK;
		}

		if (nDir > 0)
		{
			nDir = 1;
		}
		else
		{
			nDir = -1;
		}

		m_Players[nPlayerId].gameCommand.cmd		= GAME_COMMAND_TURN;
		m_Players[nPlayerId].gameCommand.nTurnDir	= nDir;
		m_Players[nPlayerId].gameCommand.pGameState = pGameState;
		m_Players[nPlayerId].gameCommand.pMemMgr	= pMemMgr;
		m_Players[nPlayerId].gameCommand.pHandler	= pHandler;

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;
	}

	HRESULT Shoot(int				nPlayerId, 
				  GameState			*pGameState, 
				  IAtlMemMgr		*pMemMgr,
				  ITankSvrService	*pHandler)
	{
		ATLASSERT(nPlayerId >= 0);
		ATLASSERT(pGameState);
		ATLASSERT(pMemMgr);
		ATLASSERT(pHandler);

		if (nPlayerId < 0 || !pGameState || !pMemMgr || !pHandler)
		{
			return E_INVALIDARG;
		}

		HRESULT hr = m_cs.Lock();
		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			return hr;
		}

		if (!IsValidPlayer(nPlayerId))
		{
			m_cs.Unlock();
			return E_INVALIDARG;
		}

		if (m_Players[nPlayerId].gameCommand.cmd != GAME_COMMAND_NONE)
		{
			m_cs.Unlock();
			return E_FAIL;
		}
		
		m_Players[nPlayerId].gameCommand.cmd		= GAME_COMMAND_SHOOT;
		m_Players[nPlayerId].gameCommand.pGameState = pGameState;
		m_Players[nPlayerId].gameCommand.pMemMgr	= pMemMgr;
		m_Players[nPlayerId].gameCommand.pHandler	= pHandler;

		hr = m_cs.Unlock();
		ATLASSERT(SUCCEEDED(hr));

		return hr;
	}

};

CTankService g_TankService;

// TankSvrService - web service implementation
//
[
	request_handler(name="Default", sdl="GenTankSvrServiceWSDL"),
	soap_handler(name="TankSvrService", 
				 namespace="urn:TankSvrService",
				 protocol="soap")
]
class CTankSvrService :
	public ITankSvrService
{
public:
	BOOL				m_bAsyncRequest;
	AtlServerRequest	*m_pRequestInfo;

	CTankSvrService() : 
		m_bAsyncRequest(FALSE),
		m_pRequestInfo(NULL)
	{
	}
	
	DECLARE_ASYNC_HANDLER_EX()

	HTTP_CODE HandleRequest(AtlServerRequest *pRequestInfo, IServiceProvider *pProvider)
	{
		ATLASSERT(pRequestInfo);
		ATLASSERT(pProvider);

		if (!g_bInitialized)
		{
			HRESULT hr = g_TankService.InitGame();
			ATLASSERT(SUCCEEDED(hr));
			if (FAILED(hr))
			{
				SoapFault(SOAP_E_SERVER, NULL, 0);
				g_bInitialized = FALSE;
				return HTTP_FAIL;
			}
		}

		m_bAsyncRequest		= FALSE;
		m_pRequestInfo		= pRequestInfo;
		m_hcErr				= HTTP_SUCCESS;
		m_spServiceProvider = pProvider;

		CHttpResponse HttpResponse(pRequestInfo->pServerContext);
		m_pHttpResponse = &HttpResponse;
		
		HRESULT hr = InitializeSOAP(m_spServiceProvider);

		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			SoapFault(SOAP_E_SERVER, NULL, 0);
			return m_hcErr;
		}

		CStreamOnServerContext s(pRequestInfo->pServerContext);

#ifdef _DEBUG

//		CSAXSoapErrorHandler err;
		///GetReader()->putErrorHandler(&err);

#endif // _DEBUG

		hr = BeginParse(&s);

		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			Cleanup();
			if (m_hcErr == HTTP_SUCCESS)
			{
				SoapFault(SOAP_E_CLIENT, NULL, NULL);
			}

			return m_hcErr;
		}

		_ATLTRY
		{
			hr = CallFunctionInternal();
		}
		_ATLCATCHALL()
		{
			// cleanup before propagating user exception
			Cleanup();
			_ATLRETHROW;
		}

		if (FAILED(hr))
		{
			Cleanup();
			HttpResponse.ClearHeaders();
			HttpResponse.ClearContent();
			if (m_hcErr != HTTP_SUCCESS)
			{
				HttpResponse.SetStatusCode(HTTP_ERROR_CODE(m_hcErr));
				return HTTP_SUCCESS_NO_PROCESS;
			}
			HttpResponse.SetStatusCode(500);
			GenerateAppError(&HttpResponse, hr);
			return AtlsHttpError(500, SUBERR_NO_PROCESS);
		}

		HttpResponse.Detach();

		if (!m_bAsyncRequest)
		{
			CompleteRequest();
			return HTTP_SUCCESS;
		}

		UninitializeSOAP();
		return HTTP_SUCCESS_ASYNC_NOFLUSH_DONE;
	}

	HTTP_CODE CompleteRequest()
	{
		CHttpResponse HttpResponse(m_spServerContext);
		m_pHttpResponse = &HttpResponse;

		HttpResponse.SetContentType("text/xml");

		HRESULT hr = GenerateResponse(&HttpResponse);
		
		HttpResponse.Flush(TRUE);
		Cleanup();

		ATLASSERT(SUCCEEDED(hr));
		if (FAILED(hr))
		{
			SoapFault(SOAP_E_SERVER, NULL, 0);
			return m_hcErr;
		}

		if (m_bAsyncRequest)
		{
			m_pRequestInfo->pExtension->RequestComplete(m_pRequestInfo, 
														HTTP_ERROR_CODE(HTTP_SUCCESS), 
														0);
		}

		return HTTP_SUCCESS;
	}

	[ soap_method ]
	HRESULT Login(BSTR strPlayerName, int *nPlayerId)
	{
		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		// call first to get the size of the caller's IP address
		DWORD size(0);
		m_pRequestInfo->pServerContext->GetServerVariable("REMOTE_ADDR", NULL, &size);
		if (!size)
		{
			return E_FAIL;
		}
	
		// allocate enough room for the IP address
		CHAR *ipBuffer = (CHAR*) GetMemMgr()->Allocate(size + 1);
		if (!ipBuffer)
		{
			return E_OUTOFMEMORY;
		}	

		// call again to get the actual value
		if (!m_pRequestInfo->pServerContext->GetServerVariable("REMOTE_ADDR", ipBuffer, &size))
		{
			// something went wrong, free our memory and get out of here
			GetMemMgr()->Free(ipBuffer);
			ipBuffer = NULL;

			return E_FAIL;
		}

		// null terminate
		ipBuffer[size] = 0;

		// get the size of the host name
		size = 0;
		size = m_pRequestInfo->pServerContext->GetServerVariable("REMOTE_HOST", NULL, &size);
				
		// allocate enough room for the IP address
		CHAR *hostNameBuffer = (CHAR*) GetMemMgr()->Allocate(size + 1);
		if (!hostNameBuffer)
		{
			return E_OUTOFMEMORY;
		}	

		if (size > 0)
		{
			// call again to get the actual value
			if (!m_pRequestInfo->pServerContext->GetServerVariable("REMOTE_HOST", hostNameBuffer, &size))
			{
				// something went wrong, free our memory and get out of here
				GetMemMgr()->Free(hostNameBuffer);
				hostNameBuffer = NULL;
	
				return E_FAIL;
			}
		}

		// null terminate
		hostNameBuffer[size] = 0;

		// login for real
		USES_CONVERSION;
		HRESULT hr = g_TankService.Login(strPlayerName, T2OLE(ipBuffer), T2OLE(hostNameBuffer), nPlayerId);

		GetMemMgr()->Free(ipBuffer);
		ipBuffer = NULL;

		GetMemMgr()->Free(hostNameBuffer);
		hostNameBuffer = NULL;

		return hr;
	}

	[ soap_method ]
	HRESULT Logout(int nPlayerId)
	{
		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		return g_TankService.Logout(nPlayerId);
	}

	[ soap_method ]
	HRESULT GetGameState(int nPlayerId, GameState *pGameState)
	{
		ATLASSERT(pGameState);
		if (!pGameState)
		{
			return E_INVALIDARG;
		}

		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		m_bAsyncRequest					= TRUE;
        m_pRequestInfo->dwRequestState	= ATLSRV_STATE_DONE;

		return g_TankService.GetGameState(nPlayerId, pGameState, GetMemMgr(), this);
	}

	[ soap_method ]
	HRESULT GetMap(int *pnWidth, int *pnHeight, ATLSOAP_BLOB *pData)
	{
		ATLASSERT(pnWidth);
		ATLASSERT(pnHeight);
		ATLASSERT(pData);

		if (!pnWidth || !pnHeight || !pData)
		{
			return E_INVALIDARG;
		}

		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		return g_TankService.GetMap(pnWidth, pnHeight, pData, GetMemMgr());
	}

	[ soap_method ]
	HRESULT Move(int nPlayerId, GameState *pGameState)
	{
		ATLASSERT(pGameState);
		if (!pGameState)
		{
			return E_INVALIDARG;
		}

		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		m_bAsyncRequest					= TRUE;
        m_pRequestInfo->dwRequestState	= ATLSRV_STATE_DONE;

		return g_TankService.Move(nPlayerId, pGameState, GetMemMgr(), this);
	}

	[ soap_method ]
	HRESULT Turn(int nPlayerId, int nDir, GameState *pGameState)
	{
		ATLASSERT(pGameState);
		if (!pGameState)
		{
			return E_INVALIDARG;
		}

		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		m_bAsyncRequest					= TRUE;
        m_pRequestInfo->dwRequestState  = ATLSRV_STATE_DONE;

		return g_TankService.Turn(nPlayerId, nDir, pGameState, GetMemMgr(), this);
	}

	[ soap_method ]
	HRESULT Shoot(int nPlayerId, GameState *pGameState)
	{
		ATLASSERT(pGameState);
		if (!pGameState)
		{
			return E_INVALIDARG;
		}

		// make sure we are initialized
		ATLASSERT(g_bInitialized);
		if (!g_bInitialized)
		{
			return E_FAIL;
		}

		m_bAsyncRequest					= TRUE;
        m_pRequestInfo->dwRequestState	= ATLSRV_STATE_DONE;
		return g_TankService.Shoot(nPlayerId, pGameState, GetMemMgr(), this);
	}

}; // class CTankSvrService

} // namespace TankSvrService
