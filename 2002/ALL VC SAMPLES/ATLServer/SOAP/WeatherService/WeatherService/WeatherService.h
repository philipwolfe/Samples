// WeatherService.h : Defines the ATL Server request handler class
//
#pragma once

namespace WeatherServiceService
{
// all struct, enum, and typedefs for your webservice should go inside the namespace

[ export ]
enum WeatherConditions
{
	Cloudy,
	Fair,
	Rainy,
	Showers,
	Sunny,
};

[ export ] 
struct Conditions
{
	int temperature;
	WeatherConditions description;
	BSTR date;
};

[ export ]
struct Forecast
{
	int hiTemp;
	int loTemp;
	WeatherConditions description;
};

[ uuid("BA826A2E-B327-453b-9B44-E39BFBF610E3") ]
__interface IWeatherService
{
	HRESULT GetCurrentConditions([in] BSTR cityname, [out,retval] Conditions* conditions);
	HRESULT GetAvailableCities([in, out] int *count, [out,size_is(*count)] BSTR **cities);
	HRESULT GetForecast([in] BSTR cityname, [out,retval] Forecast forecast[5]);
	HRESULT GetCityLocation([in] BSTR cityname, [out] double *longitude, [out] double *latitude);
};


struct SampleWeatherData
{
	LPCWSTR szCityName;
	int temperature; 
	WeatherConditions description; 
	double longitude;
	double latitude;
};


SampleWeatherData g_SampleData[] = {
	{ L"Seattle", 55, Rainy, 122.313611, 47.444722 },
	{ L"San Francisco", 75, Fair, 122.364722, 37.619722  },
	{ L"Los Angeles", 95, Sunny, 118.388889, 33.938056 },
	{ L"New York", 45, Cloudy, 73.762222, 40.638611 },
	{ L"Austin", 85, Showers, 97.680556, 30.179444 },
};

[	soap_handler(name="WeatherService"),
	request_handler(sdl="getWSDL", name="Default")	] 
class CWeatherService : public IWeatherService
{
protected:
	int FindCity(BSTR cityname)
	{
		int i;
		for (i=0;i<sizeof(g_SampleData)/sizeof(g_SampleData[0]);i++)
		{
			if (!wcsicmp(cityname,g_SampleData[i].szCityName))
				return i;
		}
		return -1;
	}

public:

	[ soap_method ]
	HRESULT GetCurrentConditions( BSTR cityname, Conditions* conditions )
	{
		memset(conditions, 0x00, sizeof(Conditions));

		int nIndex = FindCity(cityname);
		if (nIndex < 0)
			return E_FAIL;

		conditions->temperature = g_SampleData[nIndex].temperature;
		conditions->description = g_SampleData[nIndex].description;
		conditions->date = NULL;
			
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetAvailableCities(int *count, BSTR **cities)
	{
		*count = sizeof(g_SampleData)/sizeof(g_SampleData[0]);
		*cities = (BSTR *) GetMemMgr()->Allocate(sizeof(BSTR *)*(*count));
		if (!*cities)
			return E_FAIL;
		for (int i=0; i<*count; i++)
		{
			(*cities)[i] = SysAllocString(g_SampleData[i].szCityName);
		}
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetForecast(BSTR cityname, Forecast forecast[5])
	{
		int nIndex = FindCity(cityname);
		if (nIndex < 0)
			return E_FAIL;

		int nTemp = g_SampleData[nIndex].temperature;
		
		for (int i=0; i<5; i++)
		{
			forecast[i].hiTemp = nTemp + 5;
			forecast[i].loTemp = nTemp - 5;
			forecast[i].description = (WeatherConditions) (rand()%(int)(Sunny+1));
			nTemp -= 2;
		}
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetCityLocation(BSTR cityname, double *longitude, double *latitude)
	{
		int nIndex = FindCity(cityname);
		if (nIndex < 0)
			return E_FAIL;

		*longitude = g_SampleData[nIndex].longitude;
		*latitude = g_SampleData[nIndex].latitude;
		return S_OK;
	}
};

} // namespace WeatherServiceService
