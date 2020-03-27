// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers

// turns off ATL's hiding of some common and often safely ignored warning messages
#define _ATL_ALL_WARNINGS

#define _ATL_APARTMENT_THREADED
#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0500
#endif


//Modify the following line so that it points to the datasource you want to use in the application
//#define MYDATASOURCE L"Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=OnlineAddressBook;Data Source=MANTA;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False"  
	// Our database connection string (connects to access database "C:\OnlineAddressBookWS.mdb")

#define DB_MAX_STRLEN 50
#define DB_MAX_CONTACT_FIELDLEN 255

// TODO: this disables support for registering COM objects
// exported by this project since the project contains no
// COM objects or typelib. If you wish to export COM objects
// from this project, add a typelib and remove this line
#define _ATL_NO_COM_SUPPORT
#include <atlstencil.h>
#include <atlsoap.h>
#include <atlsession.h>
#include <atldbcli.h>
#include "Contacts.h"
#include "Users.h"
#include "crypt.h"
#define _ATL_STENCILCACHE_MANAGEMENT
#define _ATL_THREADPOOL_MANAGEMENT
#define _ATL_DLLCACHE_MANAGEMENT
//#include <atlextmgmt.h>
// TODO: reference additional headers your program requires here
