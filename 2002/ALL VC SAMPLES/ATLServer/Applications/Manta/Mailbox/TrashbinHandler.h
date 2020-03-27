// TrashbinHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "TrashbinDB.h"

// class CTrashbinHandler
// This handler is responsible for displaying messages in the user's trashbin.
// Users can restore marked messages and perm. delete all.
[ request_handler("Trashbin") ]
class CTrashbinHandler : public CMantaWebBase<CTrashbinHandler>
{
private:
	CTrashbinInfo m_trashbinInfo;	// Trashbin information
	LONG m_lMessageCount;			// Total count of messages in the trashbin
	HRESULT m_hRes;					// HRESULT for trashbin database operations

public:

	HTTP_CODE ValidateAndExchange()
	{
     	// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		// If this is a delete all request, delete all the messages marked for deletion
		if (m_HttpRequest.GetFormVars().Lookup("deleteall") != NULL)
		{
			if (DeleteAllMessages() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}
		// Otherwise if this is a restore request, restore all marked messages
		else if (m_HttpRequest.GetFormVars().Lookup("restoremsgs") != NULL)
		{
			if (RestoreMarkedMessages() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}

		// Get the total trashbin message count
		CTrashbinMessageCount msgCount;
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

		// Get the trashbin messages information
		m_trashbinInfo.m_lUserID = msgCount.m_lUserID;
		m_hRes = m_trashbinInfo.OpenRowset(m_dataConnection);
		if (m_hRes != S_OK)
			return DatabaseError("CTrashbinInfo::OpenRowset()", m_hRes);
		m_hRes = m_trashbinInfo.MoveFirst();

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
		// Return HTTP_SUCCESS if there are messages still left to process
		return (m_hRes != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	[ tag_name("MessageID") ]
	HTTP_CODE OnMessageID()
	{
		// Respond with the message id
		m_HttpResponse << m_trashbinInfo.m_lMessageID;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageTo") ]
	HTTP_CODE OnMessageTo()
	{
		// Respond with the message to field
		m_HttpResponse << m_trashbinInfo.m_szTo;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageFrom") ]
	HTTP_CODE OnMessageFrom()
	{
		// Respond with the message from field
		m_HttpResponse << m_trashbinInfo.m_szFrom;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageSubject") ]
	HTTP_CODE OnMessageSubject()
	{
		// Respond with the message subject
		m_HttpResponse << m_trashbinInfo.m_szSubject;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageDate") ]
	HTTP_CODE OnMessageDate()
	{
		// Respond with the message date
		m_HttpResponse << m_trashbinInfo.m_szDate;
		return HTTP_SUCCESS;
	}

	[ tag_name("NextMessage") ]
	HTTP_CODE OnNextMessage()
	{
		// Move to the next message
		m_hRes = m_trashbinInfo.MoveNext();
		return HTTP_SUCCESS;
	}

	[ tag_name("DisableButtons") ]
	HTTP_CODE OnDisableButtons()
	{
		// Return HTTP_SUCCESS if there are no messages in the trashbin, disable the buttons
		return (m_lMessageCount <= 0 ? HTTP_SUCCESS : HTTP_S_FALSE);
	}

protected:
	HTTP_CODE DeleteAllMessages()
	{
		CDeleteAllMessages deleteAll;
		HRESULT hr;

		// Delete all the messages in the trashbin
		GetUserID(&deleteAll.m_lUserID);
		hr = deleteAll.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CDeleteAllMessages::OpenRowset()", hr);
		deleteAll.Close();
		return HTTP_SUCCESS;
	}

	HTTP_CODE RestoreMarkedMessages()
	{
		HRESULT hr;
		POSITION pos;
		LPCSTR varname;
		LPCSTR varvalue;
		CRestoreMessage restoreMsg;

		GetUserID(&restoreMsg.m_lUserID);

		// Get the first form var
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			// If this is a checked mark checkbox
			if (sscanf(varname, "id%d", &restoreMsg.m_lMessageID) != 0)
			{
				// Restore the message to its previous box
				hr = restoreMsg.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CRestoreMessage::OpenRowset()", hr);
				restoreMsg.Close();
		    }
			// Get the next form var
			pos = m_HttpRequest.GetNextFormVar(pos, &varname, &varvalue);
		}
		return HTTP_SUCCESS;
	}
	
}; // class CTrashbinHandler
