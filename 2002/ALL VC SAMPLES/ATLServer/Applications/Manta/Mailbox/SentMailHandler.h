// SentMailHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "SentMailDB.h"
#include "TrashbinDB.h"

// class CSentMailHandler
// This handler is responsible for displaying sent messages.
[ request_handler("Sentmail") ]
class CSentMailHandler : public CMantaWebBase<CSentMailHandler>
{
private:
	CSentMailInfo m_sentMailInfo;	// Sent mail message info
	LONG m_lMessageCount;			// Total count of messages in the sent mail folder
	HRESULT m_hRes;					// HRESULT for sent mail folder database operations

public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");
		
		// Validate the session
 		if (!ValidateSession())
			return ValidationError();

		// If this is a delete request, delete the marked messages
		if (m_HttpRequest.GetFormVars().Lookup("deletemsgs") != NULL)
		{
			if (DeleteMarkedMessages() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}

		// Get the total sentmail message count
		CSentMailMessageCount msgCount;
		GetUserID(&msgCount.m_lUserID);
		HRESULT hr = msgCount.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			m_lMessageCount = -1;
		else
		{
			msgCount.MoveFirst();
			m_lMessageCount = msgCount.m_lMessageCount;
		}
		msgCount.Close();

		// Get the sentmail messages information
		m_sentMailInfo.m_lUserID = msgCount.m_lUserID;
		m_hRes = m_sentMailInfo.OpenRowset(m_dataConnection, NULL);
		if (m_hRes != S_OK)
			return DatabaseError("CSentMailInfo::OpenRowset()", m_hRes);
		m_hRes = m_sentMailInfo.MoveFirst();
	
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageCount") ]
	HTTP_CODE OnMessageCount()
	{
		// Respond with the message count
		if (m_lMessageCount == -1)
			m_HttpResponse << "unknown";
		else
			m_HttpResponse << m_lMessageCount;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessagesLeft") ]
	HTTP_CODE OnMessagesLeft()
	{
		// Return HTTP_SUCCESS if there are still messages left
		return (m_hRes != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	[ tag_name("MessageID") ]
	HTTP_CODE OnMessageID()
	{
		// Respond with the message id
		m_HttpResponse << m_sentMailInfo.m_lMessageID;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageTo") ]
	HTTP_CODE OnMessageFrom()
	{
		// Respond with the message to field
		m_HttpResponse << m_sentMailInfo.m_szTo;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageSubject") ]
	HTTP_CODE OnMessageSubject()
	{
		// Respond with the message subject field
		m_HttpResponse << m_sentMailInfo.m_szSubject;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageDate") ]
	HTTP_CODE OnMessageDate()
	{
		// Respond with the message date
		m_HttpResponse << m_sentMailInfo.m_szDate;
		return HTTP_SUCCESS;
	}

	[ tag_name("NextMessage") ]
	HTTP_CODE OnNextMessage()
	{
		// Move to the next message
		m_hRes = m_sentMailInfo.MoveNext();
		return HTTP_SUCCESS;
	}

	[ tag_name("DisableButtons") ]
	HTTP_CODE OnDisableButtons()
	{
		// Return HTTP_SUCCESS if there are no messages to disable the buttons
		return (m_lMessageCount <= 0 ? HTTP_SUCCESS : HTTP_S_FALSE);
	}

protected:
	HTTP_CODE DeleteMarkedMessages()
	{
		HRESULT hr;
		POSITION pos;
		LPCSTR varname;
		LPCSTR varvalue;
		CMarkMessageForDelete markMsg;

		GetUserID(&markMsg.m_lUserID);
		markMsg.m_lOldBox = 3;

		// Get the first form var
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			// If this is a checked mark checkbox
			if (sscanf(varname, "id%d", &markMsg.m_lMessageID) != 0)
			{
				// Mark the message for deletion (move to trashbin)
				hr = markMsg.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CMarkMessageForDelete::OpenRowset()", hr);
				markMsg.Close();
		    }
			// Get the next form var
			pos = m_HttpRequest.GetNextFormVar(pos, &varname, &varvalue);
		}
		return HTTP_SUCCESS;
	}
	
}; // class CSentMailHandler
