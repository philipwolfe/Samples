//
// sproxy.exe generated file
// do not modify this file
//
// Created: 07/24/2001@12:08:28
//

#pragma once

#include <atlsoap.h>

namespace WeatherService
{

enum WeatherConditions { Sunny = 0, Showers = 1, Rainy = 2, Fair = 3, Cloudy = 4, };

struct Forecast
{
	int hiTemp;
	int loTemp;
	WeatherConditions description;
};

struct Conditions
{
	int temperature;
	WeatherConditions description;
	BSTR date;
};

template <typename TClient = CSoapSocketClientT<> >
class CWeatherServiceT : 
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

	CWeatherServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://localhost/WeatherService/WeatherService.dll?Handler=Default"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CWeatherServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT GetCurrentConditions(
		BSTR cityname, 
		Conditions* __retval
	);

	HRESULT GetCityLocation(
		BSTR cityname, 
		double* longitude, 
		double* latitude
	);

	HRESULT GetForecast(
		BSTR cityname, 
		Forecast __retval[5]
	);

	HRESULT GetAvailableCities(
		BSTR** cities, int* cities_nSizeIs
	);
};

typedef CWeatherServiceT<> CWeatherService;

__if_not_exists(__WeatherConditions_entries)
{
extern __declspec(selectany) const _soapmapentry __WeatherConditions_entries[] =
{
	{ 0x061FFCBD, "Sunny", L"Sunny", sizeof("Sunny")-1, 0, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0xEFD5D1CB, "Showers", L"Showers", sizeof("Showers")-1, 1, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0x0602D763, "Rainy", L"Rainy", sizeof("Rainy")-1, 2, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0x00280D22, "Fair", L"Fair", sizeof("Fair")-1, 3, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0xA42AD5B0, "Cloudy", L"Cloudy", sizeof("Cloudy")-1, 4, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __WeatherConditions_map =
{
	0x86354C0A,
	"WeatherConditions",
	L"WeatherConditions",
	sizeof("WeatherConditions")-1,
	sizeof("WeatherConditions")-1,
	SOAPMAP_ENUM,
	__WeatherConditions_entries,
	sizeof(WeatherConditions),
	1,
	-1,
	SOAPFLAG_NONE,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};
}

__if_not_exists(__Forecast_entries)
{
extern __declspec(selectany) const _soapmapentry __Forecast_entries[] =
{
	{ 
		0xFA345A47, 
		"hiTemp", 
		L"hiTemp", 
		sizeof("hiTemp")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(Forecast, hiTemp),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x03F58FD1, 
		"loTemp", 
		L"loTemp", 
		sizeof("loTemp")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(Forecast, loTemp),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0xA646FFA4, 
		"description", 
		L"description", 
		sizeof("description")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_FIELD, 
		offsetof(Forecast, description),
		NULL, 
		&__WeatherConditions_map, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __Forecast_map =
{
	0x0BC84537,
	"Forecast",
	L"Forecast",
	sizeof("Forecast")-1,
	sizeof("Forecast")-1,
	SOAPMAP_STRUCT,
	__Forecast_entries,
	sizeof(Forecast),
	3,
	-1,
	SOAPFLAG_NONE,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};
}

__if_not_exists(__Conditions_entries)
{
extern __declspec(selectany) const _soapmapentry __Conditions_entries[] =
{
	{ 
		0x6BB998CE, 
		"temperature", 
		L"temperature", 
		sizeof("temperature")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(Conditions, temperature),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0xA646FFA4, 
		"description", 
		L"description", 
		sizeof("description")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_FIELD, 
		offsetof(Conditions, description),
		NULL, 
		&__WeatherConditions_map, 
		-1 
	},
	{ 
		0x003881DE, 
		"date", 
		L"date", 
		sizeof("date")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(Conditions, date),
		NULL, 
		NULL, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __Conditions_map =
{
	0x241E6E3A,
	"Conditions",
	L"Conditions",
	sizeof("Conditions")-1,
	sizeof("Conditions")-1,
	SOAPMAP_STRUCT,
	__Conditions_entries,
	sizeof(Conditions),
	3,
	-1,
	SOAPFLAG_NONE,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};
}

struct __CWeatherService_GetCurrentConditions_struct
{
	BSTR cityname;
	Conditions __retval;
};

extern __declspec(selectany) const _soapmapentry __CWeatherService_GetCurrentConditions_entries[] =
{

	{
		0x077A38DA, 
		"cityname", 
		L"cityname", 
		sizeof("cityname")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CWeatherService_GetCurrentConditions_struct, cityname),
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
		offsetof(__CWeatherService_GetCurrentConditions_struct, __retval),
		NULL,
		&__Conditions_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CWeatherService_GetCurrentConditions_map =
{
	0x4DFA1A7D,
	"GetCurrentConditions",
	L"GetCurrentConditions",
	sizeof("GetCurrentConditions")-1,
	sizeof("GetCurrentConditions")-1,
	SOAPMAP_FUNC,
	__CWeatherService_GetCurrentConditions_entries,
	sizeof(__CWeatherService_GetCurrentConditions_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};


struct __CWeatherService_GetCityLocation_struct
{
	BSTR cityname;
	double longitude;
	double latitude;
};

extern __declspec(selectany) const _soapmapentry __CWeatherService_GetCityLocation_entries[] =
{

	{
		0x077A38DA, 
		"cityname", 
		L"cityname", 
		sizeof("cityname")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CWeatherService_GetCityLocation_struct, cityname),
		NULL,
		NULL,
		-1,
	},
	{
		0xA082158B, 
		"longitude", 
		L"longitude", 
		sizeof("longitude")-1, 
		SOAPTYPE_DOUBLE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CWeatherService_GetCityLocation_struct, longitude),
		NULL,
		NULL,
		-1,
	},
	{
		0xECDAE4DC, 
		"latitude", 
		L"latitude", 
		sizeof("latitude")-1, 
		SOAPTYPE_DOUBLE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CWeatherService_GetCityLocation_struct, latitude),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CWeatherService_GetCityLocation_map =
{
	0x78A062F2,
	"GetCityLocation",
	L"GetCityLocation",
	sizeof("GetCityLocation")-1,
	sizeof("GetCityLocation")-1,
	SOAPMAP_FUNC,
	__CWeatherService_GetCityLocation_entries,
	sizeof(__CWeatherService_GetCityLocation_struct),
	2,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};


extern __declspec(selectany) const int __CWeatherService_GetForecast___retval_dims[] = {1, 5, };

struct __CWeatherService_GetForecast_struct
{
	BSTR cityname;
	Forecast __retval[5];
};

extern __declspec(selectany) const _soapmapentry __CWeatherService_GetForecast_entries[] =
{

	{
		0x077A38DA, 
		"cityname", 
		L"cityname", 
		sizeof("cityname")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CWeatherService_GetForecast_struct, cityname),
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
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_FIXEDARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CWeatherService_GetForecast_struct, __retval),
		__CWeatherService_GetForecast___retval_dims,
		&__Forecast_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CWeatherService_GetForecast_map =
{
	0x690D00B7,
	"GetForecast",
	L"GetForecast",
	sizeof("GetForecast")-1,
	sizeof("GetForecast")-1,
	SOAPMAP_FUNC,
	__CWeatherService_GetForecast_entries,
	sizeof(__CWeatherService_GetForecast_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};


struct __CWeatherService_GetAvailableCities_struct
{
	BSTR *cities;
	int __cities_nSizeIs;
};

extern __declspec(selectany) const _soapmapentry __CWeatherService_GetAvailableCities_entries[] =
{

	{
		0xEE9C2B41, 
		"cities", 
		L"cities", 
		sizeof("cities")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_DYNARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CWeatherService_GetAvailableCities_struct, cities),
		NULL,
		NULL,
		0+1,
	},
	{
		0xEE9C2B41,
		"__cities_nSizeIs",
		L"__cities_nSizeIs",
		sizeof("__cities_nSizeIs")-1,
		SOAPTYPE_INT,
		SOAPFLAG_NOMARSHAL,
		offsetof(__CWeatherService_GetAvailableCities_struct, __cities_nSizeIs),
		NULL,
		NULL,
		-1
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CWeatherService_GetAvailableCities_map =
{
	0x7CF7B5E2,
	"GetAvailableCities",
	L"GetAvailableCities",
	sizeof("GetAvailableCities")-1,
	sizeof("GetAvailableCities")-1,
	SOAPMAP_FUNC,
	__CWeatherService_GetAvailableCities_entries,
	sizeof(__CWeatherService_GetAvailableCities_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9852AD33,
	"urn:CWeatherService",
	L"urn:CWeatherService",
	sizeof("urn:CWeatherService")-1
};

extern __declspec(selectany) const _soapmap * __CWeatherService_funcs[] =
{
	&__CWeatherService_GetCurrentConditions_map,
	&__CWeatherService_GetCityLocation_map,
	&__CWeatherService_GetForecast_map,
	&__CWeatherService_GetAvailableCities_map,
	NULL
};

template <typename TClient>
inline HRESULT CWeatherServiceT<TClient>::GetCurrentConditions(
		BSTR cityname, 
		Conditions* __retval
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
	__CWeatherService_GetCurrentConditions_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.cityname = cityname;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetCurrentConditions\"\r\n"));
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
inline HRESULT CWeatherServiceT<TClient>::GetCityLocation(
		BSTR cityname, 
		double* longitude, 
		double* latitude
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
	__CWeatherService_GetCityLocation_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.cityname = cityname;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetCityLocation\"\r\n"));
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

	*longitude = __params.longitude;
	*latitude = __params.latitude;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CWeatherServiceT<TClient>::GetForecast(
		BSTR cityname, 
		Forecast __retval[5]
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
	__CWeatherService_GetForecast_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.cityname = cityname;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetForecast\"\r\n"));
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

	memcpy(__retval, __params.__retval, 5*sizeof(Forecast));
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CWeatherServiceT<TClient>::GetAvailableCities(
		BSTR** cities, int* __cities_nSizeIs
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
	__CWeatherService_GetAvailableCities_struct __params;
	memset(&__params, 0x00, sizeof(__params));

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#GetAvailableCities\"\r\n"));
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

	*cities = __params.cities;
	*__cities_nSizeIs = __params.__cities_nSizeIs;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CWeatherServiceT<TClient>::GetFunctionMap()
{
	return __CWeatherService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CWeatherServiceT<TClient>::GetHeaderMap()
{
	static const _soapmapentry __CWeatherService_GetCurrentConditions_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CWeatherService_GetCurrentConditions_atlsoapheader_map = 
	{
		0x4DFA1A7D,
		"GetCurrentConditions",
		L"GetCurrentConditions",
		sizeof("GetCurrentConditions")-1,
		sizeof("GetCurrentConditions")-1,
		SOAPMAP_HEADER,
		__CWeatherService_GetCurrentConditions_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0x9852AD33,
		"urn:CWeatherService",
		L"urn:CWeatherService",
		sizeof("urn:CWeatherService")-1
	};

	static const _soapmapentry __CWeatherService_GetCityLocation_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CWeatherService_GetCityLocation_atlsoapheader_map = 
	{
		0x78A062F2,
		"GetCityLocation",
		L"GetCityLocation",
		sizeof("GetCityLocation")-1,
		sizeof("GetCityLocation")-1,
		SOAPMAP_HEADER,
		__CWeatherService_GetCityLocation_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0x9852AD33,
		"urn:CWeatherService",
		L"urn:CWeatherService",
		sizeof("urn:CWeatherService")-1
	};

	static const _soapmapentry __CWeatherService_GetForecast_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CWeatherService_GetForecast_atlsoapheader_map = 
	{
		0x690D00B7,
		"GetForecast",
		L"GetForecast",
		sizeof("GetForecast")-1,
		sizeof("GetForecast")-1,
		SOAPMAP_HEADER,
		__CWeatherService_GetForecast_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0x9852AD33,
		"urn:CWeatherService",
		L"urn:CWeatherService",
		sizeof("urn:CWeatherService")-1
	};

	static const _soapmapentry __CWeatherService_GetAvailableCities_atlsoapheader_entries[] =
	{
		{ 0x00000000 }
	};

	static const _soapmap __CWeatherService_GetAvailableCities_atlsoapheader_map = 
	{
		0x7CF7B5E2,
		"GetAvailableCities",
		L"GetAvailableCities",
		sizeof("GetAvailableCities")-1,
		sizeof("GetAvailableCities")-1,
		SOAPMAP_HEADER,
		__CWeatherService_GetAvailableCities_atlsoapheader_entries,
		0,
		0,
		-1,
		SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		0x9852AD33,
		"urn:CWeatherService",
		L"urn:CWeatherService",
		sizeof("urn:CWeatherService")-1
	};


	static const _soapmap * __CWeatherService_headers[] =
	{
		&__CWeatherService_GetCurrentConditions_atlsoapheader_map,
		&__CWeatherService_GetCityLocation_atlsoapheader_map,
		&__CWeatherService_GetForecast_atlsoapheader_map,
		&__CWeatherService_GetAvailableCities_atlsoapheader_map,
		NULL
	};
	
	return __CWeatherService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CWeatherServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CWeatherServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:CWeatherService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CWeatherServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CWeatherServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:CWeatherService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CWeatherServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CWeatherServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
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

} // namespace WeatherService

inline HRESULT AtlCleanupValue<WeatherService::Forecast>(WeatherService::Forecast *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->hiTemp);
	AtlCleanupValue(&pVal->loTemp);
	AtlCleanupValue(&pVal->description);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<WeatherService::Forecast>(WeatherService::Forecast *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->hiTemp, pMemMgr);
	AtlCleanupValueEx(&pVal->loTemp, pMemMgr);
	AtlCleanupValueEx(&pVal->description, pMemMgr);
	return S_OK;
}

inline HRESULT AtlCleanupValue<WeatherService::Conditions>(WeatherService::Conditions *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->temperature);
	AtlCleanupValue(&pVal->description);
	AtlCleanupValue(&pVal->date);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<WeatherService::Conditions>(WeatherService::Conditions *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->temperature, pMemMgr);
	AtlCleanupValueEx(&pVal->description, pMemMgr);
	AtlCleanupValueEx(&pVal->date, pMemMgr);
	return S_OK;
}
