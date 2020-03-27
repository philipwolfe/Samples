// File: commonPool.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef _COMMONPOOL_H_INCLUDED
#define _COMMONPOOL_H_INCLUDED




typedef enum{
	eSTATUS_ERROR,			// job not found in map
	eSTATUS_NOT_STARTED,	// job in map, but haven't started to Execute
	eSTATUS_STARTED,		// job started to Execute but it is not done yet
	eSTATUS_DONE			// job is done
}eJobStatus;


__interface IThreadPoolService;



// Interface to be implemented by any Async SOAP handler
__interface	IAsyncSoapHandler
{
	void	processRequest() = 0;
};



class CSoapPoolWorker
{
public:
#ifndef ATL_NO_SOAP
	CComPtr<ISAXXMLReader> _spReader;
#endif

public:
    typedef IAsyncSoapHandler* 	RequestType;

	CSoapPoolWorker(){}

    virtual BOOL Initialize(void* pvParam);
	
	virtual void Terminate(void* pvParam);

    void Execute(RequestType	 dw, void*	pvParam, OVERLAPPED *pOverlapped) throw();

    virtual BOOL GetWorkerData(DWORD /*dwParam*/, void** /*ppvData*/)
    {
        return FALSE;
    }
}; // CSoapPoolWorker








// Service interface to wrap a thread pool
// This needs a uuid, because is to be a parameter for QueryService
__interface ATL_NO_VTABLE __declspec(uuid("746a6287-2fad-45e9-91e7-7c35e3d97804")) 
	IThreadPoolService	: public IUnknown
{
	HRESULT  STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv);
	ULONG STDMETHODCALLTYPE AddRef();
	ULONG STDMETHODCALLTYPE Release();

	HRESULT			Initialize(int	iNumThreads);
	BOOL			QueueRequest(const CSoapPoolWorker::RequestType& request, BOOL bTrackForPolling);
	eJobStatus		PollJobStatus(CSoapPoolWorker::RequestType request, BOOL bRemoveIfDone);
	void			Shutdown(DWORD dwMaxWait);
};




class CThreadPoolService : public IThreadPoolService
{
protected:
	CThreadPool<CSoapPoolWorker>						_threadPool;
	CAtlMap<CSoapPoolWorker::RequestType, eJobStatus>	_mapTrackJobStatus;
	CComCriticalSection									_critSec;
	DWORD												_dwTlsIndex;
	BOOL												_bInitialized;

public:
	CThreadPoolService()
	{
		_critSec.Init();
		_bInitialized	=	FALSE;
		_dwTlsIndex	=	TlsAlloc();
	}

	~CThreadPoolService()
	{
		_threadPool.Shutdown();
		_critSec.Term();
		TlsFree(_dwTlsIndex);
	}


	// IUnknown methods
	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (!ppv)
			return E_POINTER;

		if( InlineIsEqualGUID(riid, __uuidof(IThreadPoolService) ) )
		{
			*ppv = static_cast<IUnknown*>(this);
			AddRef();
			return S_OK;
		}
#ifndef ATL_NO_SOAP
		else if (InlineIsEqualGUID(riid, __uuidof(ISAXXMLReader)))
		{
			CSoapPoolWorker *p = GetThreadWorker();
			ATLASSERT( p != NULL );
			return p->_spReader->QueryInterface(riid, ppv);
		}
#endif
		else
			return 	_threadPool.QueryInterface(riid, ppv);
	}

	ULONG STDMETHODCALLTYPE AddRef() throw()
	{
		return 1;
	}
	
	ULONG STDMETHODCALLTYPE Release() throw()
	{
		return 1;
	}


	HRESULT Initialize(int	iNumThreads)
	{
		IThreadPoolService		*pIFace	=	static_cast<IThreadPoolService*>(this);
		HRESULT		hRet	=	S_OK;
		if( !_bInitialized )
		{
			hRet	=	_threadPool.Initialize((LPVOID)pIFace, iNumThreads);
			_bInitialized		=	SUCCEEDED(hRet );
		}
		

		return hRet;

	}

	// HRESULT Initialize(void *pvWorkerParam=NULL, int nNumThreads=0, DWORD dwStackSize=0, HANDLE hCompletion=INVALID_HANDLE_VALUE);
	BOOL QueueRequest(const CSoapPoolWorker::RequestType& request, BOOL bTrackForPolling)
	{
		BOOL	bRet;
		_critSec.Lock();
		if( bTrackForPolling )
			_mapTrackJobStatus.SetAt(request, eSTATUS_NOT_STARTED);

		bRet	=	_threadPool.QueueRequest( request );

		if( bTrackForPolling && !bRet )
			_mapTrackJobStatus.RemoveKey( request );
		
		_critSec.Unlock();

		return bRet;
	}


	eJobStatus		PollJobStatus(CSoapPoolWorker::RequestType request, BOOL bRemoveIfDone)
	{
		eJobStatus		jobStatus;

		bool	bRet	=	_mapTrackJobStatus.Lookup(request, jobStatus);
		if( !bRet )
			jobStatus	=	eSTATUS_ERROR;

		return jobStatus;
	}


	void Shutdown(DWORD dwMaxWait)
	{
		_threadPool.Shutdown( dwMaxWait );
	}

	void setJobStatus(CSoapPoolWorker::RequestType request, eJobStatus status)
	{
		_critSec.Lock();
		ATLASSERT((status == eSTATUS_STARTED) || (status == eSTATUS_DONE));
		eJobStatus	oldStatus;
		if( _mapTrackJobStatus.Lookup(request, oldStatus ) )
			// change only if already exists
			_mapTrackJobStatus.SetAt( request, status);
		_critSec.Unlock();
	}


	BOOL SetThreadWorker(CSoapPoolWorker *pWorker) throw()
    {
        return TlsSetValue(_dwTlsIndex, (void*)pWorker);
    }

protected:
    CSoapPoolWorker *GetThreadWorker() throw()
    {
        return (CSoapPoolWorker *) TlsGetValue(_dwTlsIndex);
    }



};


inline   void CSoapPoolWorker::Execute(RequestType	 dw, void 	*pvParam, OVERLAPPED * /*pOverlapped*/) throw()
{
    ATLASSERT(dw	!= NULL);

	CThreadPoolService		*pThreadPool = NULL;
	if( pvParam )
		pThreadPool	=	reinterpret_cast<CThreadPoolService*>(pvParam);

	if( pThreadPool )
		pThreadPool->setJobStatus( dw, eSTATUS_STARTED);
    
	IAsyncSoapHandler	*pHandler	=	reinterpret_cast<IAsyncSoapHandler*>(dw);

	pHandler->processRequest();

	if( pThreadPool )
		pThreadPool->setJobStatus( dw, eSTATUS_DONE);

}

inline BOOL CSoapPoolWorker::Initialize(void *pvParam)
{
	HRESULT					hRet		=	S_OK;

	CThreadPoolService		*pThreadPool = NULL;
	ATLASSERT( pvParam != NULL);

	pThreadPool	=	reinterpret_cast<CThreadPoolService*>(pvParam);
	

#ifndef ATL_NO_SOAP
	// Initialize COM for this thread
	hRet	=	CoInitialize(NULL);

	if( SUCCEEDED(hRet )) 
		hRet	=	_spReader.CoCreateInstance(__uuidof(SAXXMLReader30));
	
	if (FAILED(hRet))
		return FALSE;
#endif
    return pThreadPool->SetThreadWorker(this);
}


inline void CSoapPoolWorker::Terminate(void* /*pvParam*/)
{
	CoUninitialize();
	#ifndef ATL_NO_SOAP
			_spReader.Release();
	#endif
}



#endif //_COMMONPOOL_H_INCLUDED
