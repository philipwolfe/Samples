// File: MQServer.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef MQSERVER_H_INCLUDED
#define MQSERVER_H_INCLUDED


inline void	dumpErrorCode(HRESULT hRet)
{
	if (FAILED(hRet))
	{
		printf("Return code : 0x%x\n",	hRet);
	}
}

#define		MQ_LABEL_INDEX		1
#define		MQ_BODY_INDEX		3
#define		MQ_RESMQ_INDEX		5


// Server side class that sends a SOAP response on the specified queue

class CMQSoapResponseSender
{
protected:
	CMQQueue						m_msgQueue;

public:
	
	// It is supposed to b called ONLY with a qualified format name, obtained from the client
	// (the PROPID_M_RESP_QUEUE param of the request)
	bool	Initialize(wchar_t*		lpwszResponseQueue)
	{
		HRESULT		hr;
		ATLASSERT(lpwszResponseQueue);
		if( !lpwszResponseQueue)
			return false;

		bool			bRet = true;
		wchar_t			lpwszQueueName[MAX_PATH];
		static	wchar_t	*lpwszLabel	=	L"SOAP Responses Queue";


		wcscpy( lpwszQueueName, lpwszResponseQueue);


		if( bRet )
		{
			hr	=	m_msgQueue.SetFormatName(lpwszQueueName);
			hr = m_msgQueue.Open(/*lpwszQueueName, */MQ_SEND_ACCESS);

			dumpErrorCode( hr );
			bRet	=	SUCCEEDED(hr);
		}
		return bRet;
	}


	bool	SendSOAPResponse( 	CAtlIsapiBuffer<>	&xmlBuff)
	{

		if( ( NULL == m_msgQueue.GetHandle() )||
			( INVALID_HANDLE_VALUE == m_msgQueue.GetHandle() ) )
			return false;
		
		CMQMessageProps props;

		wchar_t		wszLabel[MAX_PATH];
		wcscpy(wszLabel, L"SOAPResponse");

		props.Add(PROPID_M_LABEL, wszLabel);
		props.Add(PROPID_M_BODY, (unsigned char*)(LPCSTR)xmlBuff, xmlBuff.GetLength(), sizeof(UCHAR));

		return SUCCEEDED(m_msgQueue.Send(&props, NULL));
		
	}
};

// Message Queue Thread Worker
template<class TSoapDispatcher>
class CMQTestWorker
{
public:
	typedef CMQQueue* RequestType;

	BOOL Initialize(void * /*pvParam*/)
	{
		return TRUE;
	}

	void Execute(CMQQueue *pQueue, void *pvWorkerParam, OVERLAPPED *pOverlapped)
	{
		CMQOverlapped *pMqOverlapped = (CMQOverlapped *) pOverlapped;
		CMQMessageProps *pProps = pMqOverlapped->m_pProps;

		
		processMessage(pProps);

		delete [] pProps->GetProperty(MQ_LABEL_INDEX).pwszVal;
		delete [] pProps->GetProperty(MQ_BODY_INDEX).caub.pElems;
		delete [] pProps->GetProperty(MQ_RESMQ_INDEX).pwszVal;
		delete pProps;
		delete pMqOverlapped;

		// post another request
		CSoapRequestListener<TSoapDispatcher>::QueueReceiveRequest(pQueue);
	}

	void Terminate(void* /*pvParam*/)
	{
	}


protected:
	bool	getMsgParams(CMQMessageProps *pProps, CAtlIsapiBuffer<>	&xmlReq, CStringA& strURL, CStringA&	strSoapAction, CComBSTR&	bstrResMQ) 
	{
		DWORD					dwSize;
		wchar_t					*lpwszData;
		bool					bContinue	=	true;

		// get the SOAP Action
		dwSize	=	pProps->GetProperty(MQ_LABEL_INDEX - 1).ulVal;
		bContinue	=	dwSize > 0;

		if( bContinue )
		{
			WCHAR	*pwStr	=	pProps->GetProperty(MQ_LABEL_INDEX).pwszVal;
			CW2A		strAction(pwStr);
			CStringA	strTemp	=	strAction;
			int			iEOLPos = strTemp.Find("\n");
			if( iEOLPos > 0 )
			{
				strURL	=	strTemp.Left( iEOLPos);
				strSoapAction	=	strTemp.Right( strTemp.GetLength() - iEOLPos - 1);
			}
			else
				bContinue	=	false;
		}

		// get the body
		if( bContinue )
		{
			dwSize	=	pProps->GetProperty(MQ_BODY_INDEX - 1).ulVal;
			bContinue	=	dwSize	>	0;
		}

		if( bContinue )
		{
			UCHAR	*p	=	pProps->GetProperty(MQ_BODY_INDEX).caub.pElems;
			bContinue	=	TRUE == xmlReq.Append( (LPCSTR)p, dwSize );
		}
		

		// get the response queue
		if( bContinue )
		{
			dwSize	=	pProps->GetProperty(MQ_RESMQ_INDEX - 1).ulVal;
			bContinue	=	dwSize > 0;
		}

		if( bContinue )
		{
			lpwszData	=	pProps->GetProperty(MQ_RESMQ_INDEX).pwszVal;
			bstrResMQ.Append(lpwszData);
		}

		return bContinue;
	}
	
	// Custom message treating routine
	void processMessage(CMQMessageProps *pProps)
	{
		TSoapDispatcher			theSOAPDispatcher;
		CAtlIsapiBuffer<>		xmlReq;
		CAtlIsapiBuffer<>		xmlRes;
		CStringA				strSoapAction;
		CStringA				strURL;
		CComBSTR				bstrResponseMQ;

		bool					bContinue	=	true;
		bool					bSoapResult	=	true;

		

		try
		{
			bContinue	=	getMsgParams(pProps, xmlReq, strURL, strSoapAction, bstrResponseMQ) ;
		}
		catch(...)
		{
			bContinue	=	false;
		}

		
		if( bContinue )
		{
			//theSOAPDispatcher.setXMLReader(pXMLReader);
			bSoapResult	=	theSOAPDispatcher.DispatchCall(strURL, strSoapAction, xmlReq, xmlRes);

		}

		if( bContinue )
		{
			// send the response
			if( !bSoapResult )
				xmlRes.Empty();

			CMQSoapResponseSender		sender;
			if( sender.Initialize( bstrResponseMQ ) )
			{
				sender.SendSOAPResponse( xmlRes );
			}
		}
	}

};





template<class TSoapDispatcher>
class CSoapRequestListener
{
protected:	
	typedef CMQTestWorker<TSoapDispatcher>		mqWorkerType;
	CThreadPool<mqWorkerType>					m_threadPool;
	CMQQueue									m_msgQueue;


public:
	// this method creates/opens the requests message queue
	bool	Initialize(wchar_t*	lpwszQueuePath)
	{
		bool		bRet = true;
		static		wchar_t	*lpwszLabel	=	L"SOAP Requests Queue";
		wchar_t		lpwszQueueName[MAX_PATH];

		wcscpy( lpwszQueueName, lpwszQueuePath);
		
		HRESULT hr;

		hr = m_msgQueue.Create(lpwszQueueName, lpwszLabel);
		if (hr == MQ_ERROR_QUEUE_EXISTS)
		{
			
			hr = m_msgQueue.PathNameToFormatName(lpwszQueueName);
			if (FAILED(hr))
			{
				dumpErrorCode( hr );
				bRet	=	false;
			}

		}
		else if (FAILED(hr))
		{
			printf("Failed creating the queue %08x\n", hr);
			bRet	=	false;
		}	

		if( bRet )
		{
			HRESULT	hr;
			printf("Queue was created.\n");

			hr = m_msgQueue.Open();
			
			if (FAILED(hr))
			{
				printf("Failed m_msgQueue.Open() %08x\n", hr);
				bRet	=	false;
			}
		}
		return bRet;
	}


	void	ListenToSoapCalls()
	{
		m_threadPool.Initialize();

		HRESULT	hr;
		hr = m_msgQueue.AssociateCompletionPort(m_threadPool.GetQueueHandle(), m_threadPool.GetNumThreads());
		if (FAILED(hr))
		{
			printf("Failed q.AssociateCompletionPort %08x\n", hr);
		}

		// prime the thread pool
		for (int i=0; i<	m_threadPool.GetNumThreads(); i++)
		{
			QueueReceiveRequest(&m_msgQueue);
		}


		// make sure we got all the messages
		DWORD dwStart = GetTickCount();
		while (true)
		{
			Sleep(500);
		}
	}

	static void QueueReceiveRequest(CMQQueue *pQueue)
	{
		
		CMQMessageProps	msgProps;
		int	iBodySizeIndex, iLabelSizeIndex, iDestQueueIndex;

		// Get the properties of the message in QUEUE
		// For this implementation, we only care about the the body size and the Label length, 
		// as these are the only fields  involve in SOAP
		
		iLabelSizeIndex	= msgProps.Add(PROPID_M_LABEL_LEN);

		iBodySizeIndex	=	msgProps.Add(PROPID_M_BODY_SIZE);

		iDestQueueIndex = msgProps.Add(PROPID_M_RESP_QUEUE_LEN);


		HRESULT	hPeekRet;
		do
		{
			hPeekRet	=	pQueue->Peek(&msgProps, NULL);
			if( hPeekRet == MQ_ERROR_IO_TIMEOUT )
			{
				// No message. Sleeping...
				Sleep(500);
			}
		}
		while(hPeekRet != S_OK );
		
		
		if( SUCCEEDED(hPeekRet) )
		{
			CMQMessageProps *pProps = new CMQMessageProps;
			DWORD			dwSize	=	0;
			int				iIndex	=	0;

			iIndex	=	pProps->Add(PROPID_M_LABEL_LEN);
			dwSize	=	msgProps.GetProperty(iLabelSizeIndex).ulVal;
			pProps->m_rgProps[iIndex].ulVal = dwSize;
			
			WCHAR *wszLabel = new WCHAR[dwSize];
			iIndex	=	pProps->Add(PROPID_M_LABEL, wszLabel);
			

			iIndex  = pProps->Add(PROPID_M_BODY_SIZE);
			dwSize	=	msgProps.GetProperty(iBodySizeIndex).ulVal;
			pProps->m_rgProps[iIndex].ulVal = dwSize;

			UCHAR *szBody = new UCHAR[dwSize];
			pProps->Add(PROPID_M_BODY, szBody, dwSize, sizeof(UCHAR));

			iIndex = pProps->Add(PROPID_M_RESP_QUEUE_LEN);
			dwSize	=	msgProps.GetProperty(iDestQueueIndex).ulVal;
			pProps->m_rgProps[iIndex].ulVal = dwSize;
			WCHAR *wszDestQueue = new WCHAR[dwSize];
			pProps->Add(PROPID_M_RESP_QUEUE, wszDestQueue);


			HRESULT	hRet	=	pQueue->ReceiveWithIoCompletion(pProps);
			dumpErrorCode( hRet );
		}
	}
};

#endif // MQSERVER_H_INCLUDED