// Created by Microsoft (R) C/C++ Compiler Version 13.00.9360
//
// d:\sourcedepot\vcqalibs\test sources\work in progress\hps\hailstorm\pdc\tankonline\settings.mrg.h
// compiler-generated file created 10/19/01 at 11:51:29
//
// This C++ source file is intended to be a representation of the
// source code injected by the compiler.  It may not compile or
// run exactly as the original source file.
//


//+++ Start Injected Code
[no_injected_text(true)];      // Suppress injected text, it has already been injected
#pragma warning(disable: 4543) // Suppress warnings about skipping injected text
#pragma warning(disable: 4199) // Suppress warnings from attribute providers

#pragma message("\n\nNOTE: This merged source file should be visually inspected for correctness.\n\n")
//--- End Injected Code

#pragma once

#include "stdafx.h"
#include "tankhandlerbase.h"
#include "myapplicationsettings.h"

#define MOVE_NAMESPACE			"http://schemas.microsoft.com/hs/2001/10/"

#define TANK_SERVICE_NAMESPACE	"http://schemas.microsoft.com/hs/2001/10/TankService"
#define TANK_SERVICE_SETTING	"TankService"
#define TANK_SERVICE_DEFAULT	"http://localhost/tanksvr/tanksvr.dll?Handler=Default"

#define MOVE_RIGHT_NAMESPACE	"http://schemas.microsoft.com/hs/2001/10/TankMoveRight"
#define MOVE_RIGHT_SETTING		"TankMoveRight"
#define MOVE_RIGHT_DEFAULT		"RIGHT"

#define MOVE_LEFT_NAMESPACE		"http://schemas.microsoft.com/hs/2001/10/TankMoveLeft"
#define MOVE_LEFT_SETTING		"TankMoveLeft"
#define MOVE_LEFT_DEFAULT		"LEFT"

#define MOVE_FORWARD_NAMESPACE	"http://schemas.microsoft.com/hs/2001/10/TankMoveForward"
#define MOVE_FORWARD_SETTING	"TankMoveForward"
#define MOVE_FORWARD_DEFAULT	"UP"

#define SHOOT_NAMESPACE			"http://schemas.microsoft.com/hs/2001/10/TankShoot"
#define SHOOT_SETTING			"TankShoot"
#define SHOOT_DEFAULT			"SPACE"

[request_handler("Settings")]
class CSettingsHandler : 	
	public CTankHandlerBaseT<CSettingsHandler>
{
private:	
	CString	m_moveRight;
	CString	m_moveLeft;
	CString	m_moveForward;
	CString	m_shoot;
	CString m_tankService;

	CString m_moveRightID;
	CString	m_moveLeftID;
	CString	m_moveForwardID;
	CString	m_shootID;
	CString m_tankServiceID;

public:

	HTTP_CODE ValidateAndExchange()
	{
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}

		// see if we are in a post back
		GetSettings();
		if (m_isPostBack)
		{			
			SetSettings();
		} 

		return httpCode;
	}

	[tag_name("GetMoveRight")]
	HTTP_CODE MoveRight()
	{
		m_HttpResponse << m_moveRight;
		return HTTP_SUCCESS;
	}

	[tag_name("GetMoveLeft")]
	HTTP_CODE MoveLeft()
	{
		m_HttpResponse << m_moveLeft;
		return HTTP_SUCCESS;
	}

	[tag_name("GetMoveForward")]
	HTTP_CODE MoveForward()
	{
		m_HttpResponse << m_moveForward;
		return HTTP_SUCCESS;
	}

	[tag_name("GetShoot")]
	HTTP_CODE Shoot()
	{
		m_HttpResponse << m_shoot;
		return HTTP_SUCCESS;
	}

	[tag_name("GetTankService")]
	HTTP_CODE TankService()
	{
		m_HttpResponse << m_tankService;
		return HTTP_SUCCESS;
	}

	void SetSettings()
	{		
		// get the values of our new settings
		const CHttpRequestParams& formParams = m_HttpRequest.GetFormVars();		

		LPCSTR moveRight	= formParams.Lookup("MoveRight");
		LPCSTR moveLeft		= formParams.Lookup("MoveLeft");
		LPCSTR moveForward	= formParams.Lookup("MoveForward");
		LPCSTR shoot		= formParams.Lookup("Shoot");
		LPCSTR tankService	= formParams.Lookup("TankService");

		// only set values for the ones that we got values for, leave the rest alone
		if (moveRight)
		{
			if (SetSetting(	MOVE_RIGHT_SETTING, 
							moveRight,
							m_moveRightID))
			{
				m_moveRight = moveRight;
			}
		}

		if (moveLeft)
		{
			if (SetSetting(	MOVE_LEFT_SETTING, 
							moveLeft,
							m_moveLeftID))
			{
				m_moveLeft = moveLeft;
			}
		}

		if (moveForward)
		{
			if (SetSetting(	MOVE_FORWARD_SETTING, 
							moveForward,
							m_moveForwardID))
			{
				m_moveForward = moveForward;
			}
		}

		if (shoot)
		{
			if (SetSetting(	SHOOT_SETTING, 
							shoot,
							m_shootID))
			{
				m_shoot = shoot;
			}
		}

		if (tankService)
		{
			if (SetSetting( TANK_SERVICE_SETTING,
							tankService,
							m_tankServiceID))
			{
				m_tankService = tankService;
			}
		}
	}

	bool SetSetting(const CString&	settingName, 
					const CString&	settingValue,
					const CString&  settingID)
	{
		ATLASSERT(m_server);
		ATLASSERT(m_puid);

		CMyApplicationSettings myApplicationSettings;

		myApplicationSettings.SetServer(m_server);
		myApplicationSettings.SetPUID(m_puid);

		CMyApplicationSettingsResponse insertResponse;
		CApplicationSetting<CMyApplicationSettingsResponse> newSetting;	

		CString settingNamespace;
		settingNamespace.Format("%s%s", MOVE_NAMESPACE, settingName);

		newSetting.name			 = settingNamespace;
		newSetting.settingprefix = settingName;
		newSetting.AddSetting("keyboardmapping", settingValue);
		
		if (!settingID.IsEmpty())
		{
			CString itemNamespace;			
			itemNamespace.Format(" xmlns:%s=\"%s\"", settingName, settingNamespace);
			return myApplicationSettings.Replace(newSetting, settingID, itemNamespace);
		}
		else
		{
			return myApplicationSettings.Insert(insertResponse, newSetting);
		}
	}

	void GetSettings()
	{
		ATLASSERT(m_server);
		ATLASSERT(m_puid);

		CMyApplicationSettings myApplicationSettings;

		myApplicationSettings.SetServer(m_server);
		myApplicationSettings.SetPUID(m_puid);

		// get the tank settings
		CString query;

		query.Format("//m:applicationSetting[m:name='%s']", MOVE_RIGHT_NAMESPACE);
		if (!QueryForSetting(myApplicationSettings, 
							 query, 							 
							 m_moveRight,
							 m_moveRightID))
		{
			m_moveRight = MOVE_RIGHT_DEFAULT;
		}
		query.Empty();

		query.Format("//m:applicationSetting[m:name='%s']", MOVE_LEFT_NAMESPACE);
		if (!QueryForSetting(myApplicationSettings, 
							 query, 							 
							 m_moveLeft,
							 m_moveLeftID))
		{
			m_moveLeft = MOVE_LEFT_DEFAULT;
		}
		query.Empty();

		query.Format("//m:applicationSetting[m:name='%s']", MOVE_FORWARD_NAMESPACE);
		if (!QueryForSetting(myApplicationSettings, 
							 query, 							 
							 m_moveForward,
							 m_moveForwardID))
		{
			m_moveForward = MOVE_FORWARD_DEFAULT;
		}
		query.Empty();

		query.Format("//m:applicationSetting[m:name='%s']", SHOOT_NAMESPACE);
		if (!QueryForSetting(myApplicationSettings, 
							 query, 							 
							 m_shoot,
							 m_shootID))
		{
			m_shoot = SHOOT_DEFAULT;
		}		
		query.Empty();

		query.Format("//m:applicationSetting[m:name='%s']", TANK_SERVICE_NAMESPACE);
		if (!QueryForSetting(myApplicationSettings, 
							 query, 							 
							 m_tankService,
							 m_tankServiceID))
		{
			m_tankService = TANK_SERVICE_DEFAULT;
		}		
	}

	bool QueryForSetting(CMyApplicationSettings& myApplicationSettings,						 
						 const  CString&		 query,						 
						 CString&				 settingToSet,
						 CString&				 settingID)
	{
		CMyApplicationSettingsResponse response;
		if (myApplicationSettings.Query(response, query))
		{
			CString setting;
			if (response.HasMoreResponses())
			{
				settingID = response.GetResponse()->id;
				if (response.GetResponse()->m_settings.Lookup("keyboardmapping", setting))
				{
					settingToSet = setting;
					return true;
				}
			}
		}
		return false;		
	}

	//+++ Start Injected Code For Attribute 'tag_name'
    #injected_line 31 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"
BEGIN_ATTR_REPLACEMENT_METHOD_MAP(CSettingsHandler)
REPLACEMENT_METHOD_ENTRY("GetMoveRight", MoveRight)
REPLACEMENT_METHOD_ENTRY("GetMoveLeft", MoveLeft)
REPLACEMENT_METHOD_ENTRY("GetMoveForward", MoveForward)
REPLACEMENT_METHOD_ENTRY("GetShoot", Shoot)
REPLACEMENT_METHOD_ENTRY("GetTankService", TankService)
END_ATTR_REPLACEMENT_METHOD_MAP()
	//--- End Injected Code For Attribute 'tag_name'
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 29 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\settings.h"

				
DECLARE_REQUEST_HANDLER("Settings", CSettingsHandler, ::CSettingsHandler)

			
//--- End Injected Code For Attribute 'request_handler'

