//
// sproxy.exe generated file
// do not modify this file
//
// Created: 10/11/2001@15:47:20
//

#pragma once

#include <atlsoap.h>

namespace TankSvrService
{

struct PlayerInfo
{
	int nPlayerId;
	int x;
	int y;
	int nAngle;
	int nScore;
	int nKills;
	BSTR bstrIPAddress;
	BSTR bstrHostName;
	BSTR bstrName;
};

struct ProjectileInfo
{
	int nPlayerId;
	int x;
	int y;
	int dx;
	int dy;
};

struct GameState
{
	PlayerInfo *Players;
	int nPlayerCount;
	ProjectileInfo *Projectiles;
	int nProjectileCount;
};

template <typename TClient = CSoapSocketClientT<> >
class CTankSvrServiceT : 
	public TClient, 
	public CSoapRootHandler
{
protected:

	const _soapmap ** GetFunctionMap();
	const _soapmap ** GetHeaderMap();
	void * GetHeaderValue();
	const wchar_t * GetNamespaceUri();
	const char * GetServiceName();
	const char * GetNamespaceUriA();
	HRESULT CallFunction(
		void *pvParam, 
		const wchar_t *wszLocalName, int cchLocalName,
		size_t nItem);
	HRESULT GetClientReader(ISAXXMLReader **ppReader);

public:

	HRESULT __stdcall QueryInterface(REFIID riid, void **ppv)
	{
		if (ppv == NULL)
		{
			return E_POINTER;
		}

		*ppv = NULL;

		if (InlineIsEqualGUID(riid, IID_IUnknown) ||
			InlineIsEqualGUID(riid, IID_ISAXContentHandler))
		{
			*ppv = static_cast<ISAXContentHandler *>(this);
			return S_OK;
		}

		return E_NOINTERFACE;
	}

	ULONG __stdcall AddRef()
	{
		return 1;
	}

	ULONG __stdcall Release()
	{
		return 1;
	}

	CTankSvrServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://ericlee-ri1/tanksvr/tanksvr.dll?Handler=Default"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CTankSvrServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT Move(
		int nPlayerId, 
		GameState* __retval
	);

	HRESULT Login(
		BSTR strPlayerName, 
		int* __retval
	);

	HRESULT GetMap(
		ATLSOAP_BLOB* __retval, 
		int* pnWidth, 
		int* pnHeight
	);

	HRESULT Logout(
		int nPlayerId
	);

	HRESULT Shoot(
		int nPlayerId, 
		GameState* __retval
	);

	HRESULT Turn(
		int nPlayerId, 
		int nDir, 
		GameState* __retval
	);

	HRESULT GetGameState(
		int nPlayerId, 
		GameState* __retval
	);
};

typedef CTankSvrServiceT<> CTankSvrService;

__if_not_exists(__PlayerInfo_entries)
{
extern __declspec(selectany) const _soapmapentry __PlayerInfo_entries[] =
{
	{ 
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, nPlayerId),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000078, 
		"x", 
		L"x", 
		sizeof("x")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, x),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000079, 
		"y", 
		L"y", 
		sizeof("y")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, y),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x056DC415, 
		"nAngle", 
		L"nAngle", 
		sizeof("nAngle")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, nAngle),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x06AD97CA, 
		"nScore", 
		L"nScore", 
		sizeof("nScore")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, nScore),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x0620108D, 
		"nKills", 
		L"nKills", 
		sizeof("nKills")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(PlayerInfo, nKills),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x2299361A, 
		"bstrIPAddress", 
		L"bstrIPAddress", 
		sizeof("bstrIPAddress")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(PlayerInfo, bstrIPAddress),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x41A8431A, 
		"bstrHostName", 
		L"bstrHostName", 
		sizeof("bstrHostName")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(PlayerInfo, bstrHostName),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x1C6E8BDC, 
		"bstrName", 
		L"bstrName", 
		sizeof("bstrName")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(PlayerInfo, bstrName),
		NULL, 
		NULL, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __PlayerInfo_map =
{
	0x42D74159,
	"PlayerInfo",
	L"PlayerInfo",
	sizeof("PlayerInfo")-1,
	sizeof("PlayerInfo")-1,
	SOAPMAP_STRUCT,
	__PlayerInfo_entries,
	sizeof(PlayerInfo),
	9,
	-1,
	SOAPFLAG_NONE,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};
}

__if_not_exists(__ProjectileInfo_entries)
{
extern __declspec(selectany) const _soapmapentry __ProjectileInfo_entries[] =
{
	{ 
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(ProjectileInfo, nPlayerId),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000078, 
		"x", 
		L"x", 
		sizeof("x")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(ProjectileInfo, x),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000079, 
		"y", 
		L"y", 
		sizeof("y")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(ProjectileInfo, y),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000D5C, 
		"dx", 
		L"dx", 
		sizeof("dx")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(ProjectileInfo, dx),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x00000D5D, 
		"dy", 
		L"dy", 
		sizeof("dy")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(ProjectileInfo, dy),
		NULL, 
		NULL, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __ProjectileInfo_map =
{
	0x9649D63D,
	"ProjectileInfo",
	L"ProjectileInfo",
	sizeof("ProjectileInfo")-1,
	sizeof("ProjectileInfo")-1,
	SOAPMAP_STRUCT,
	__ProjectileInfo_entries,
	sizeof(ProjectileInfo),
	5,
	-1,
	SOAPFLAG_NONE,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};
}

__if_not_exists(__GameState_entries)
{
extern __declspec(selectany) const _soapmapentry __GameState_entries[] =
{
	{ 
		0x113F7FC0, 
		"Players", 
		L"Players", 
		sizeof("Players")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_FIELD | SOAPFLAG_DYNARR | SOAPFLAG_NULLABLE, 
		offsetof(GameState, Players),
		NULL, 
		&__PlayerInfo_map, 
		1 
	},
	{ 
		0xA5E5C5A4, 
		"nPlayerCount", 
		L"nPlayerCount", 
		sizeof("nPlayerCount")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD | SOAPFLAG_SIZEIS, 
		offsetof(GameState, nPlayerCount),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x1CFB9F24, 
		"Projectiles", 
		L"Projectiles", 
		sizeof("Projectiles")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_FIELD | SOAPFLAG_DYNARR | SOAPFLAG_NULLABLE, 
		offsetof(GameState, Projectiles),
		NULL, 
		&__ProjectileInfo_map, 
		3 
	},
	{ 
		0x9DEF1E08, 
		"nProjectileCount", 
		L"nProjectileCount", 
		sizeof("nProjectileCount")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD | SOAPFLAG_SIZEIS, 
		offsetof(GameState, nProjectileCount),
		NULL, 
		NULL, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __GameState_map =
{
	0x8BB91FFB,
	"GameState",
	L"GameState",
	sizeof("GameState")-1,
	sizeof("GameState")-1,
	SOAPMAP_STRUCT,
	__GameState_entries,
	sizeof(GameState),
	4,
	-1,
	SOAPFLAG_NONE,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};
}

struct __CTankSvrService_Move_struct
{
	int nPlayerId;
	GameState __retval;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_Move_entries[] =
{

	{
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Move_struct, nPlayerId),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Move_struct, __retval),
		NULL,
		&__GameState_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_Move_map =
{
	0x002C20F7,
	"Move",
	L"Move",
	sizeof("Move")-1,
	sizeof("Move")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_Move_entries,
	sizeof(__CTankSvrService_Move_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_Login_struct
{
	BSTR strPlayerName;
	int __retval;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_Login_entries[] =
{

	{
		0x7C1A14A7, 
		"strPlayerName", 
		L"strPlayerName", 
		sizeof("strPlayerName")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CTankSvrService_Login_struct, strPlayerName),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Login_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_Login_map =
{
	0x059DE879,
	"Login",
	L"Login",
	sizeof("Login")-1,
	sizeof("Login")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_Login_entries,
	sizeof(__CTankSvrService_Login_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_GetMap_struct
{
	ATLSOAP_BLOB __retval;
	int pnWidth;
	int pnHeight;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_GetMap_entries[] =
{

	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_BASE64BINARY, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CTankSvrService_GetMap_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{
		0xB473A9FE, 
		"pnWidth", 
		L"pnWidth", 
		sizeof("pnWidth")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_GetMap_struct, pnWidth),
		NULL,
		NULL,
		-1,
	},
	{
		0x1FA5AD57, 
		"pnHeight", 
		L"pnHeight", 
		sizeof("pnHeight")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_GetMap_struct, pnHeight),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_GetMap_map =
{
	0xAD02DFFE,
	"GetMap",
	L"GetMap",
	sizeof("GetMap")-1,
	sizeof("GetMap")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_GetMap_entries,
	sizeof(__CTankSvrService_GetMap_struct),
	3,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_Logout_struct
{
	int nPlayerId;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_Logout_entries[] =
{

	{
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Logout_struct, nPlayerId),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_Logout_map =
{
	0xB95B127A,
	"Logout",
	L"Logout",
	sizeof("Logout")-1,
	sizeof("Logout")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_Logout_entries,
	sizeof(__CTankSvrService_Logout_struct),
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_Shoot_struct
{
	int nPlayerId;
	GameState __retval;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_Shoot_entries[] =
{

	{
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Shoot_struct, nPlayerId),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Shoot_struct, __retval),
		NULL,
		&__GameState_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_Shoot_map =
{
	0x0618E02D,
	"Shoot",
	L"Shoot",
	sizeof("Shoot")-1,
	sizeof("Shoot")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_Shoot_entries,
	sizeof(__CTankSvrService_Shoot_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_Turn_struct
{
	int nPlayerId;
	int nDir;
	GameState __retval;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_Turn_entries[] =
{

	{
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Turn_struct, nPlayerId),
		NULL,
		NULL,
		-1,
	},
	{
		0x003D80ED, 
		"nDir", 
		L"nDir", 
		sizeof("nDir")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Turn_struct, nDir),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_Turn_struct, __retval),
		NULL,
		&__GameState_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_Turn_map =
{
	0x003010A9,
	"Turn",
	L"Turn",
	sizeof("Turn")-1,
	sizeof("Turn")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_Turn_entries,
	sizeof(__CTankSvrService_Turn_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};


struct __CTankSvrService_GetGameState_struct
{
	int nPlayerId;
	GameState __retval;
};

extern __declspec(selectany) const _soapmapentry __CTankSvrService_GetGameState_entries[] =
{

	{
		0x46A80128, 
		"nPlayerId", 
		L"nPlayerId", 
		sizeof("nPlayerId")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_GetGameState_struct, nPlayerId),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CTankSvrService_GetGameState_struct, __retval),
		NULL,
		&__GameState_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CTankSvrService_GetGameState_map =
{
	0x91954B7B,
	"GetGameState",
	L"GetGameState",
	sizeof("GetGameState")-1,
	sizeof("GetGameState")-1,
	SOAPMAP_FUNC,
	__CTankSvrService_GetGameState_entries,
	sizeof(__CTankSvrService_GetGameState_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xDBB6DAE9,
	"urn:TankSvrService",
	L"urn:TankSvrService",
	sizeof("urn:TankSvrService")-1
};

extern __declspec(selectany) const _soapmap * __CTankSvrService_funcs[] =
{
	&__CTankSvrService_Move_map,
	&__CTankSvrService_Login_map,
	&__CTankSvrService_GetMap_map,
	&__CTankSvrService_Logout_map,
	&__CTankSvrService_Shoot_map,
	&__CTankSvrService_Turn_map,
	&__CTankSvrService_GetGameState_map,
	NULL
};

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::Move(
		int nPlayerId, 
		GameState* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_Move_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.nPlayerId = nPlayerId;

	__atlsoap_hr = SetClientStruct(&__params, 0);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#Move\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::Login(
		BSTR strPlayerName, 
		int* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_Login_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.strPlayerName = strPlayerName;

	__atlsoap_hr = SetClientStruct(&__params, 1);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#Login\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::GetMap(
		ATLSOAP_BLOB* __retval, 
		int* pnWidth, 
		int* pnHeight
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_GetMap_struct __params;
	memset(&__params, 0x00, sizeof(__params));

	__atlsoap_hr = SetClientStruct(&__params, 2);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetMap\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	*pnWidth = __params.pnWidth;
	*pnHeight = __params.pnHeight;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::Logout(
		int nPlayerId
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_Logout_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.nPlayerId = nPlayerId;

	__atlsoap_hr = SetClientStruct(&__params, 3);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#Logout\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::Shoot(
		int nPlayerId, 
		GameState* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_Shoot_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.nPlayerId = nPlayerId;

	__atlsoap_hr = SetClientStruct(&__params, 4);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#Shoot\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::Turn(
		int nPlayerId, 
		int nDir, 
		GameState* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_Turn_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.nPlayerId = nPlayerId;
	__params.nDir = nDir;

	__atlsoap_hr = SetClientStruct(&__params, 5);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#Turn\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CTankSvrServiceT<TClient>::GetGameState(
		int nPlayerId, 
		GameState* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CTankSvrService_GetGameState_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.nPlayerId = nPlayerId;

	__atlsoap_hr = SetClientStruct(&__params, 6);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetGameState\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CTankSvrServiceT<TClient>::GetFunctionMap()
{
	return __CTankSvrService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CTankSvrServiceT<TClient>::GetHeaderMap()
{
	static const _soapmapentry __CTankSvrService_Move_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_Move_atlsoapheader_map = 
	{
		0x002C20F7,
		"Move",
		L"Move",
		sizeof("Move")-1,
		sizeof("Move")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_Move_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_Login_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_Login_atlsoapheader_map = 
	{
		0x059DE879,
		"Login",
		L"Login",
		sizeof("Login")-1,
		sizeof("Login")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_Login_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_GetMap_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_GetMap_atlsoapheader_map = 
	{
		0xAD02DFFE,
		"GetMap",
		L"GetMap",
		sizeof("GetMap")-1,
		sizeof("GetMap")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_GetMap_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_Logout_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_Logout_atlsoapheader_map = 
	{
		0xB95B127A,
		"Logout",
		L"Logout",
		sizeof("Logout")-1,
		sizeof("Logout")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_Logout_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_Shoot_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_Shoot_atlsoapheader_map = 
	{
		0x0618E02D,
		"Shoot",
		L"Shoot",
		sizeof("Shoot")-1,
		sizeof("Shoot")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_Shoot_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_Turn_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_Turn_atlsoapheader_map = 
	{
		0x003010A9,
		"Turn",
		L"Turn",
		sizeof("Turn")-1,
		sizeof("Turn")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_Turn_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};

	static const _soapmapentry __CTankSvrService_GetGameState_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CTankSvrService_GetGameState_atlsoapheader_map = 
	{
		0x91954B7B,
		"GetGameState",
		L"GetGameState",
		sizeof("GetGameState")-1,
		sizeof("GetGameState")-1,
		SOAPMAP_HEADER,
		__CTankSvrService_GetGameState_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0xDBB6DAE9,
		"urn:TankSvrService",
		L"urn:TankSvrService",
		sizeof("urn:TankSvrService")-1
	};


	static const _soapmap * __CTankSvrService_headers[] =
	{
		&__CTankSvrService_Move_atlsoapheader_map,
		&__CTankSvrService_Login_atlsoapheader_map,
		&__CTankSvrService_GetMap_atlsoapheader_map,
		&__CTankSvrService_Logout_atlsoapheader_map,
		&__CTankSvrService_Shoot_atlsoapheader_map,
		&__CTankSvrService_Turn_atlsoapheader_map,
		&__CTankSvrService_GetGameState_atlsoapheader_map,
		NULL
	};
	
	return __CTankSvrService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CTankSvrServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CTankSvrServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:TankSvrService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CTankSvrServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CTankSvrServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:TankSvrService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CTankSvrServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CTankSvrServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
{
	if (ppReader == NULL)
	{
		return E_INVALIDARG;
	}
	
	CComPtr<ISAXXMLReader> spReader = GetReader();
	if (spReader.p != NULL)
	{
		*ppReader = spReader.Detach();
		return S_OK;
	}
	return TClient::GetClientReader(ppReader);
}

} // namespace TankSvrService

inline HRESULT AtlCleanupValue<TankSvrService::PlayerInfo>(TankSvrService::PlayerInfo *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->nPlayerId);
	AtlCleanupValue(&pVal->x);
	AtlCleanupValue(&pVal->y);
	AtlCleanupValue(&pVal->nAngle);
	AtlCleanupValue(&pVal->nScore);
	AtlCleanupValue(&pVal->nKills);
	AtlCleanupValue(&pVal->bstrIPAddress);
	AtlCleanupValue(&pVal->bstrHostName);
	AtlCleanupValue(&pVal->bstrName);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<TankSvrService::PlayerInfo>(TankSvrService::PlayerInfo *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->nPlayerId, pMemMgr);
	AtlCleanupValueEx(&pVal->x, pMemMgr);
	AtlCleanupValueEx(&pVal->y, pMemMgr);
	AtlCleanupValueEx(&pVal->nAngle, pMemMgr);
	AtlCleanupValueEx(&pVal->nScore, pMemMgr);
	AtlCleanupValueEx(&pVal->nKills, pMemMgr);
	AtlCleanupValueEx(&pVal->bstrIPAddress, pMemMgr);
	AtlCleanupValueEx(&pVal->bstrHostName, pMemMgr);
	AtlCleanupValueEx(&pVal->bstrName, pMemMgr);
	return S_OK;
}

inline HRESULT AtlCleanupValue<TankSvrService::ProjectileInfo>(TankSvrService::ProjectileInfo *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->nPlayerId);
	AtlCleanupValue(&pVal->x);
	AtlCleanupValue(&pVal->y);
	AtlCleanupValue(&pVal->dx);
	AtlCleanupValue(&pVal->dy);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<TankSvrService::ProjectileInfo>(TankSvrService::ProjectileInfo *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->nPlayerId, pMemMgr);
	AtlCleanupValueEx(&pVal->x, pMemMgr);
	AtlCleanupValueEx(&pVal->y, pMemMgr);
	AtlCleanupValueEx(&pVal->dx, pMemMgr);
	AtlCleanupValueEx(&pVal->dy, pMemMgr);
	return S_OK;
}

inline HRESULT AtlCleanupValue<TankSvrService::GameState>(TankSvrService::GameState *pVal)
{
	pVal;
	AtlCleanupArray(pVal->Players, pVal->nPlayerCount);
	AtlCleanupValue(&pVal->nPlayerCount);
	AtlCleanupArray(pVal->Projectiles, pVal->nProjectileCount);
	AtlCleanupValue(&pVal->nProjectileCount);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<TankSvrService::GameState>(TankSvrService::GameState *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	if (pVal->Players != NULL)
	{
		AtlCleanupArrayEx(pVal->Players, pVal->nPlayerCount, pMemMgr);
		pMemMgr->Free(pVal->Players);
	}
	AtlCleanupValueEx(&pVal->nPlayerCount, pMemMgr);
	if (pVal->Projectiles != NULL)
	{
		AtlCleanupArrayEx(pVal->Projectiles, pVal->nProjectileCount, pMemMgr);
		pMemMgr->Free(pVal->Projectiles);
	}
	AtlCleanupValueEx(&pVal->nProjectileCount, pMemMgr);
	return S_OK;
}
