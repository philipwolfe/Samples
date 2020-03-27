// File: Persist.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef PERSIST2_H_INCLUDED
#define PERSIST2_H_INCLUDED

#include <atlsoap.h>	// required for ATLSOAP_BLOB
#include <atlsession.h>	// for generating a new, unique session key


#define DEFAULT_PERSIST_LIFESPAN	300	// 5 minutes



typedef CStringA	storageKey;


typedef enum
{
	eNEW_OBJECT,
	eEXISTING_OBJECT,
	eOBJECT_NOT_FOUND,
}eState;



[
	uuid("A4DD9D01-C5A3-49E8-BE67-582A8D9F6FD9"), 
	object
]
__interface IPersistSoapServer
{
	/* 
		method to return the transport header
		It's up to the implenentation whether the transport token is a cookie or a SOAP header
	*/
	HRESULT		getObjToken(storageKey&	token);
	
	// method to set the transport header
	HRESULT		setObjToken(storageKey&	token);
	
	
	// Loads the object from a blob of data
	HRESULT		persist_load(const ATLSOAP_BLOB	&data);
	
	
	// Saves the object to a blob of data
	HRESULT		persist_dump(ATLSOAP_BLOB	&data);


	// The only public SOAP Methods
	[id(1)]	HRESULT		initPersistSoapServer([in]BSTR bstrUser, [in]BSTR bstrPwd, [out, retval]eState*	state);

	[id(2)]	HRESULT		destroyPersistSoapServer([in]BSTR bstrUser, [in]BSTR bstrPwd);

	[id(3)]	HRESULT		setPersistSoapServerTimeout([in]DWORD	dwTimeoutSecs);
	

};





// interface of the SOAP Server Storage Service to be exposed as an ISAPI service
__interface	__declspec(uuid("F02335E8-167D-4ae4-9A3C-E16ED085EA48"))
ISOAPSrvStorageService : public IUnknown
{
	HRESULT		STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv);
	ULONG		STDMETHODCALLTYPE AddRef();
	ULONG		STDMETHODCALLTYPE Release();

	/*
		if User (and password)
			Checks whether an object with the specified credentials exists
			If YES, fills the pServer object and sets the transport header
			if NO, sets a new transport header, returns
		else
			if NO, sets a new transport header
			
		This is invoked when the client calls InitPersistServer
		
		The object will have the default timeout (10 min for a user/pwd session, 
		5 min for an anonymous session)
			
	*/
	HRESULT		createNewObject(BSTR bstrUserName, BSTR bstrPwd, IPersistSoapServer	*pServer);



	// To be called to remove a persistent server
	HRESULT		deleteObject(IPersistSoapServer	*pServer, BSTR bstrUser, BSTR bstrPwd);
	
	
	
	
	/*
		This is called at the beginning of any method invocation
		It calls getObjToken to get the transport SOAP header
		then fills the object
		
	*/
	HRESULT		loadObjectFromStorage(IPersistSoapServer *pServer);
	
	/*
		This is called at the beginning of any method invocation
		It calls getObjToken to get the transport SOAP header
		then fills the object
		
	*/
	HRESULT		saveObjectToStorage(IPersistSoapServer *pServer);
	
	
	
	/*
		Sets the timeout for a specific object.
		dwTimeoutSecs is in seconds
		0 means forever
	*/
	HRESULT		setObjectTimeout(IPersistSoapServer *pServer, DWORD	dwTimeoutSecs);



	HRESULT		setDefaultLifespan(DWORD	dwLifeSpanInSecs);
};

template<class MonitorClass>
class CSOAPSrvStorageService : 
	public ISOAPSrvStorageService,
	public IWorkerThreadClient
{
protected:
	// default lifespan
	DWORD			m_dwDefaultLifespan;

	struct	storageEntry
	{
		ATLSOAP_BLOB	data;
		DWORD			dwTimeout;
		CStringA		strUserPassword;
		CFileTime		cftExpireTime;
	};
	
	// pItem->cftExpireTime = CFileTime(CFileTime::GetCurrentTime().GetTime() + pItem->nLifes
	
	// these are only for a memory backed service. It can be changed for a DB service
	// map of the storage entries identified by  unique tokens
	CAtlMap<storageKey, storageEntry, CStringElementTraits<storageKey> >	_mapStorage;

	// map of unique tokens identified by user/password pairs
	CAtlMap<CStringA, storageKey, 
		CStringElementTraits<CStringA>, CStringElementTraits<storageKey> >	_mapTokens;


	CComCriticalSection					_critSec;



    MonitorClass			m_Monitor;
    HANDLE					m_hTimer;



protected:
	storageKey		renderNewKey()
	{
		CSessionNameGenerator	nameGen;
		DWORD					dwSize	=	MAX_SESSION_KEY_LEN - 1;
		char					buffChar[MAX_SESSION_KEY_LEN - 1];
		storageKey				ret;
		if( SUCCEEDED(nameGen.GetNewSessionName(buffChar, &dwSize) ) ) 
		{
			ATLASSERT(dwSize	<MAX_SESSION_KEY_LEN);
			buffChar[dwSize]	=	0;
			ret	=	buffChar;
		}
			
		return ret;
	}


	CStringA		userPwd(BSTR bstrUser, BSTR bstrPwd)
	{
		CStringA	strRet;
		CW2A		strUser(bstrUser);
		CW2A		strPwd(bstrPwd);

		if( strlen(strUser) + strlen(strPwd) > 0 )
		{
			strRet	+=	strUser;
			strRet	+=	_T("-");
			strRet	+=	strPwd;
		}

		return strRet;
	}


	bool	IsNullUserPwd(CStringA& strUserPwd)
	{
		return strUserPwd.IsEmpty();		
	}
public:
	CSOAPSrvStorageService()
	{
		m_dwDefaultLifespan	= DEFAULT_PERSIST_LIFESPAN;
		_critSec.Init();
	}

	~CSOAPSrvStorageService()
	{
		_critSec.Term();
		if( m_hTimer)
			m_Monitor.RemoveHandle(m_hTimer);
	}

	HRESULT		Initialize()
	{
        HRESULT	hr;
		hr = m_Monitor.Initialize();
        if (FAILED(hr))
            return hr;
        // refresh every minute
		return m_Monitor.AddTimer(60*1000, this, (DWORD_PTR) this, &m_hTimer);
	}


	void	FlushEntries()
	{
		// do nothing yet
		CFileTime	timeNow(CFileTime::GetCurrentTime().GetTime());

		_critSec.Lock();
		POSITION		pos;
		storageKey		token;
		storageEntry	entry;

		try
		{

			pos		=	_mapStorage.GetStartPosition();

			while( pos != NULL )
			{
				_mapStorage.GetNextAssoc( pos, token, entry);

				if( (entry.cftExpireTime	<	timeNow) && entry.dwTimeout)
				{
					_mapTokens.RemoveKey( entry.strUserPassword );

					delete	entry.data.data;
					_mapStorage.RemoveKey( token );

				}
			}
		}
		catch(...)
		{
		}

		_critSec.Unlock();

	}



	// IWorkerThreadCLient implementation
    HRESULT Execute(DWORD_PTR dwParam, HANDLE /*hObject*/) throw()
    {
        CSOAPSrvStorageService* pThis= (CSOAPSrvStorageService*)dwParam;

		pThis->FlushEntries();

        return S_OK;
    }

    HRESULT CloseHandle(HANDLE hObject) throw()
    {
        ATLASSERT(m_hTimer == hObject);
        m_hTimer = NULL;
        ::CloseHandle(hObject);
        return S_OK;
    }


	// IUnknown methods
	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (!ppv)
			return E_POINTER;

		if( InlineIsEqualGUID(riid, __uuidof(ISOAPSrvStorageService) ) )
		{
			*ppv = static_cast<IUnknown*>(this);
			AddRef();
			return S_OK;
		}
		return E_NOINTERFACE;
	}

	ULONG STDMETHODCALLTYPE AddRef() throw()
	{
		return 1;
	}
	
	ULONG STDMETHODCALLTYPE Release() throw()
	{
		return 1;
	}



	/*
		if User (and password)
			Checks whether an object with the specified credentials exists
			If YES, fills the pServer object and sets the transport header
			if NO, sets a new transporrt header
		else
			if NO, sets a new transport header
			
		This is invoked when the client calls InitPersistServer
		
		The object will have the default timeout (10 min for a user/pwd session, 
		5 min for an anonymous session)
			
	*/
	HRESULT		createNewObject(BSTR bstrUserName, BSTR bstrPwd, IPersistSoapServer	*pServer)
	{
		HRESULT	hRet;

		CStringA	strUserPwd;
		storageKey	token;

		ATLASSERT( pServer != NULL );
		if( !pServer )
			return E_POINTER;

		_critSec.Lock();
		try
		{
			bool	bNewObject	=	false;
			
			strUserPwd	=	userPwd(bstrUserName, bstrPwd);

			
			if( !IsNullUserPwd( strUserPwd ) )
			{
				// create a new object if not found in Tokens map
				bNewObject	=	!_mapTokens.Lookup( strUserPwd, token);
			}
			else
				// create new object for a null user/pwd
				bNewObject	=	true;

			if( !bNewObject )
			{
				// a session for the specified user/pwd already exists
				storageEntry	entry;
				BOOL			bFound	= FALSE;
				bFound	= _mapStorage.Lookup( token, entry);
				
				if( !bFound )
				{
					// error - the object has an invalid token
					hRet	=	MAKE_HRESULT(11, FACILITY_STORAGE, eOBJECT_NOT_FOUND);
				}
				else
				{
					// set the entry's communication token
					pServer->setObjToken( token );

					// 'touch' the entry, update the expiration time
					entry.cftExpireTime		=	CFileTime(CFileTime::GetCurrentTime().GetTime() + CFileTime::Second*entry.dwTimeout);
					_mapStorage.SetAt( token, entry);
					
					hRet	=	pServer->persist_load( entry.data);
					hRet	=	MAKE_HRESULT(0, FACILITY_STORAGE, eEXISTING_OBJECT);
				}
			}
			else
			{
				// no user/pwd entry. Add a new one
				token				=	renderNewKey();
				storageEntry	entry;
				entry.data.data			=	NULL;
				entry.data.size			=	0;
				entry.dwTimeout			=	m_dwDefaultLifespan;
				entry.strUserPassword	=	strUserPwd;
				entry.cftExpireTime		=	CFileTime(CFileTime::GetCurrentTime().GetTime() + CFileTime::Second*entry.dwTimeout);
			
				_mapTokens.SetAt( strUserPwd, token);
				_mapStorage.SetAt( token, entry );

				pServer->setObjToken( token );

				hRet	=	MAKE_HRESULT(0, FACILITY_STORAGE, eNEW_OBJECT);
			}
		}
		catch(...)
		{
			hRet	=	E_FAIL;
		}

		_critSec.Unlock();

		return hRet;
	}



	// To be called to remove a persistent server
	HRESULT		deleteObject(IPersistSoapServer	*pServer, BSTR bstrUser, BSTR bstrPwd)
	{
		storageKey	token;
		HRESULT		hRet	=	S_OK;

		ATLASSERT( pServer != NULL );
		if( !pServer )
			return E_POINTER;

		_critSec.Lock();
		try
		{
			if( SUCCEEDED(pServer->getObjToken(token)) )
			{
				CStringA		strUserPwd;
				storageKey		oldToken;
				storageEntry	entry;
				strUserPwd	=	userPwd(bstrUser, bstrPwd);

				if( _mapTokens.Lookup( strUserPwd, oldToken) )
					_mapTokens.RemoveKey( strUserPwd );

				if( _mapStorage.Lookup( token, entry) )
				{
					delete entry.data.data;
					_mapStorage.RemoveKey( token );
				}
			}

		}
		catch(...)
		{
			hRet	=	E_FAIL;
		}
		_critSec.Unlock();

		return S_OK;
	}
	
	
	
	
	/*
		This is called at the beginning of any method invocation
		It calls getObjToken to get the transport SOAP header
		then fills the object
		
	*/
	HRESULT		loadObjectFromStorage(IPersistSoapServer *pServer)
	{
		storageKey	token;
		HRESULT		hRet	=	S_OK;

		ATLASSERT( pServer != NULL );
		if( !pServer )
			return E_POINTER;

		_critSec.Lock();

		try
		{
			hRet	=	pServer->getObjToken( token );

			if( SUCCEEDED(hRet) )
			{
				storageEntry	entry;

				if( _mapStorage.Lookup( token, entry ) )
				{
					hRet	=	pServer->persist_load( entry.data );
					if( SUCCEEDED(hRet) )
					{
						// update the timeout
						entry.cftExpireTime	=	CFileTime(CFileTime::GetCurrentTime().GetTime() + CFileTime::Second*entry.dwTimeout);
						_mapStorage.SetAt( token, entry);
					}
				}
				else
					hRet	=	MAKE_HRESULT(11, FACILITY_STORAGE, eOBJECT_NOT_FOUND);
			}
		}
		catch(...)
		{
			hRet	=	E_FAIL;
		}
		
		_critSec.Unlock();

		return hRet;
	}
	
	/*
		This is called at the beginning of any method invocation
		It calls getObjToken to get the transport SOAP header
		then fills the object
		
	*/
	HRESULT		saveObjectToStorage(IPersistSoapServer *pServer)
	{
		storageKey	token;
		HRESULT		hRet	=	S_OK;

		ATLASSERT( pServer != NULL );
		if( !pServer )
			return E_POINTER;

		
		_critSec.Lock();
		try
		{
			hRet	=	pServer->getObjToken( token );

			if( SUCCEEDED(hRet) )
			{
				storageEntry	entry;
				ATLSOAP_BLOB	newBlob;

				hRet	=	pServer->persist_dump( newBlob );

				if( SUCCEEDED(hRet) )
				{
					// remove the old entry, if any
					if( _mapStorage.Lookup( token, entry ) )
					{
						ATLASSERT( entry.data.data !=	newBlob.data);
						delete	entry.data.data;
					}
					else
					{
						entry.dwTimeout	=	m_dwDefaultLifespan;
					}
					entry.data			=	newBlob;
					entry.cftExpireTime	=	CFileTime(CFileTime::GetCurrentTime().GetTime() + CFileTime::Second*entry.dwTimeout);
					_mapStorage.SetAt( token, entry);
					hRet	=	S_OK;
				}
			}
		}
		catch(...)
		{
			hRet	=	E_FAIL;
		}
		_critSec.Unlock();

		return hRet;
	}
	
	
	
	/*
		Sets the timeout for a specific object.
		dwTimeoutSecs is in seconds
		0 means forever
	*/
	HRESULT		setObjectTimeout(IPersistSoapServer *pServer, DWORD	dwTimeoutSecs)
	{
		storageKey	token;
		HRESULT		hRet	=	S_OK;
		
		ATLASSERT( pServer != NULL );
		if( !pServer )
			return E_POINTER;

		_critSec.Lock();
		
		
		
		try
		{
			hRet	=	pServer->getObjToken( token );

			if( SUCCEEDED(hRet) )
			{
				storageEntry	entry;
				if( _mapStorage.Lookup( token, entry ) )
				{
					entry.dwTimeout	=	dwTimeoutSecs;
					entry.cftExpireTime	=	CFileTime(CFileTime::GetCurrentTime().GetTime() + CFileTime::Second*entry.dwTimeout);
					_mapStorage.SetAt( token, entry);
					hRet	=	S_OK;
				}
				else
					hRet	=	MAKE_HRESULT(11, FACILITY_STORAGE, eOBJECT_NOT_FOUND);
			}
		}
		catch(...)
		{
			hRet	=	E_FAIL;
		}

		_critSec.Unlock();

		return hRet;

	}



	HRESULT		setDefaultLifespan(DWORD	dwLifeSpanInSecs)
	{
		m_dwDefaultLifespan	=	dwLifeSpanInSecs;
		return S_OK;
	}

};


#define PERSIST_SOAP_LOAD	0x00000001
#define PERSIST_SOAP_SAVE	0x00000002
class CPersistentHandler
{
protected:
	DWORD				m_dwFlags;
	IPersistSoapServer	*_pServer;
	bool				m_bLoaded;
	IServiceProvider	*m_pProvider;
public:
	inline bool		loaded(){ return m_bLoaded;}

	CPersistentHandler(IPersistSoapServer	*pServer, IServiceProvider	*pProvider, DWORD	dwFlags	=	PERSIST_SOAP_LOAD|PERSIST_SOAP_SAVE)
	{
		m_bLoaded	=	false;
		_pServer	=	pServer;
		m_pProvider	=	pProvider;
		m_dwFlags	=	dwFlags;

		if( _pServer && (m_dwFlags & PERSIST_SOAP_LOAD) )
		{
			// load from storage
			CComPtr<ISOAPSrvStorageService>	storageSrv;
			if( pProvider != NULL )
			{
				HRESULT	hr = pProvider->QueryService(__uuidof(ISOAPSrvStorageService), 
								__uuidof(ISOAPSrvStorageService), (void **)&storageSrv);
				if (SUCCEEDED(hr) && storageSrv != NULL)
				{
					hr	=	storageSrv->loadObjectFromStorage( pServer );

					m_bLoaded	=	SUCCEEDED(hr);
				}
			}
		}
	}
	
	
	~CPersistentHandler()
	{
		//get the service pointer then dump the object
		if( _pServer && (m_dwFlags & PERSIST_SOAP_SAVE) )
		{
			CComPtr<ISOAPSrvStorageService>	storageSrv;
			if( m_pProvider != NULL )
			{
				HRESULT	hr = m_pProvider->QueryService(__uuidof(ISOAPSrvStorageService), 
								__uuidof(ISOAPSrvStorageService), (void **)&storageSrv);
				if (SUCCEEDED(hr) && storageSrv != NULL)
				{
					hr	=	storageSrv->saveObjectToStorage( _pServer );

				}
			}
		}

	}
	
};





#endif //PERSIST2_H_INCLUDED