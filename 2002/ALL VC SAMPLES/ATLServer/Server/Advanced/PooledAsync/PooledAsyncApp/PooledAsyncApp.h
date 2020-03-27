// PooledAsyncApp.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <commonPool.h>

class CMyPoolWorker : public CSoapPoolWorker
{
public:

public:
	CMyPoolWorker(){}

    void Execute(RequestType dw, void*	pvParam, OVERLAPPED *pOverlapped) throw()
	{
		Sleep(2000);
		return;
	}

#if 0
    virtual BOOL Initialize(void* pvParam);
	virtual void Terminate(void* pvParam);
    virtual BOOL GetWorkerData(DWORD /*dwParam*/, void** /*ppvData*/)
    {
        return FALSE;
    }
#endif
}; // CMyPoolWorker


[ request_handler("Default") ]
class CPooledAsyncAppHandler : public IAsyncSoapHandler
{
private:
	CComPtr<IThreadPoolService> m_spThreadPool;
	DWORD m_dwHits;
	enum ASYNC_STATE {init, queued, done} m_eState;

protected:
public:
	// TODO: comments here re: DECLARE_ASYNC_HANDLER
	DECLARE_ASYNC_HANDLER();

	CPooledAsyncAppHandler() : m_eState( init ), m_dwHits( 0 ) {}

	HTTP_CODE ValidateAndExchange()
	{
		m_dwHits = 0;
		m_eState = init;

		if ( FAILED( m_spServiceProvider->QueryService( __uuidof(IThreadPoolService), __uuidof(IThreadPoolService), (void**) &m_spThreadPool ) ) )
			return HTTP_FAIL;

		m_HttpResponse.SetContentType("text/html");
		// TODO: comments here re: AsyncPrep
		if ( !m_HttpResponse.AsyncPrep())
			return HTTP_FAIL;
		
		return HTTP_SUCCESS;
	}

	// IAsyncProcessRequest
	// TODO: comments here re: the intent of processRequest
	void	processRequest()
	{

		// Sleep some arbitrary amount of time between 1/4 and 2 seconds.
		DWORD dwSleep = 0;
		while ( dwSleep < 500 )
			dwSleep = rand() % 2000;
		ATLTRACE( "*** CPooledAsyncAppHandler::processRequest, sleep for %d milliseconds ***\n", dwSleep );
		Sleep( dwSleep );

		// Set the state to done so the primary thread will recognize that the work on this thread is complete.
		m_eState = done;
	}

protected:
	// TODO: comments here re: what SimpleAsyncHello does
	[ tag_name(name="SimpleAsyncHello") ]
	HTTP_CODE OnSimpleAsyncHello(void)
	{
		HTTP_CODE hc = HTTP_SUCCESS_ASYNC;

		if ( m_dwHits++ ) {
			m_HttpResponse << "World!";
			hc = HTTP_SUCCESS_ASYNC_DONE;
		}
		else {
			m_HttpResponse << "Hello<br>";
		}
		return hc;
	}

	// TODO: comments here re: what AsyncHello does
	[ tag_name(name="AsyncHello") ]
	HTTP_CODE OnAsyncHello(void)
	{
		HTTP_CODE hc = HTTP_SUCCESS_ASYNC;

		switch ( m_eState ) {
		case init:
			ATLTRACE( "AsyncHello, init\n" );
			// Set state to queued before actually queueing; avoids race condition
			m_eState = queued;
			m_dwHits = 0;
			if ( !m_spThreadPool->QueueRequest( static_cast<IAsyncSoapHandler*>(this), FALSE ) ) {
				hc = HTTP_FAIL;
				break;
			}

		case queued:
			ATLTRACE( "AsyncHello, queued\n" );
			m_HttpResponse << "Hello, ";
			break;

		case done:
			ATLTRACE( "AsyncHello, done\n" );
			m_HttpResponse << "World!";
			hc = HTTP_SUCCESS_ASYNC_DONE;
		}
		m_dwHits++;

		return hc;
	}

	// TODO: comments here re: Hello being a sync method
	[ tag_name(name="SyncHello") ]
	HTTP_CODE OnSyncHello(void)
	{
		m_HttpResponse << "Hello World!";
		m_dwHits++;
		return HTTP_SUCCESS;
	}

	[ tag_name(name="GetHitCount") ]
	HTTP_CODE OnGetHitCount(void)
	{
		m_HttpResponse << m_dwHits;
		return HTTP_SUCCESS;
	}

}; // class CPooledAsyncAppHandler
