// InboxHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "InboxDB.h"
#include "TrashbinDB.h"

// class CInboxHandler
// This handler is responsible for displaying the messages in the user's inbox.
// Users can also delete marked messages and check POP mail.
// Note: the ability to check POP mail has not been included in this sample.
[ request_handler("Inbox") ]
class CInboxHandler : public CMantaWebBase<CInboxHandler>
{
private:
	CInboxInfo m_inboxInfo;			// Inbox message information
	LONG m_lUnreadMessageCount;		// Count of unread messages in the inbox
	LONG m_lMessageCount;			// Total count of messages in the inbox
	HRESULT m_hRes;					// HRESULT for inbox database calls

public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		
		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		// Check if this is a deletion operation
		if (m_HttpRequest.GetFormVars().Lookup("deletemsgs") != NULL)
		{
			if (DeleteMarkedMessages() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}
		// Check to see if this is a POP check operation
		else if (m_HttpRequest.GetQueryParams().Lookup("checkpopmail") != NULL)
		{
			if (CheckPOPMail() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}

		// Get the unread message count
        CUnreadMessageCount unreadMsgCount;
		GetUserID(&unreadMsgCount.m_lUserID);
		HRESULT hr = unreadMsgCount.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			m_lUnreadMessageCount = -1;
		else
		{
			unreadMsgCount.MoveFirst();
			m_lUnreadMessageCount = unreadMsgCount.m_lNewMessageCount;
		}
		unreadMsgCount.Close();

		// Get the total message count
		CInboxMessageCount msgCount;
		msgCount.m_lUserID = unreadMsgCount.m_lUserID;
		hr = msgCount.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			m_lMessageCount = -1;
		else
		{
			msgCount.MoveFirst();
			m_lMessageCount = msgCount.m_lMessageCount;
		}
		msgCount.Close();

		// Get the inbox messages info
		m_inboxInfo.m_lUserID = unreadMsgCount.m_lUserID;
		m_hRes = m_inboxInfo.OpenRowset(m_dataConnection);
		if (m_hRes != S_OK)
			return DatabaseError("CInboxInfo::OpenRowset()", m_hRes);
		m_hRes = m_inboxInfo.MoveFirst();
		
		return HTTP_SUCCESS;
	}

	[ tag_name("UnreadMessageCount") ]
	HTTP_CODE OnUnreadMessageCount()
	{
		// Respond with the unread message count
		if (m_lUnreadMessageCount >= 0) 
			m_HttpResponse << m_lUnreadMessageCount;
		else
			m_HttpResponse << "unknown";
		return HTTP_SUCCESS;
	}

	[ tag_name("HasUnreadMail")]
	HTTP_CODE OnHasUnreadMail()
	{
		// Return HTTP_SUCCESS if there are unread messages
		return (m_lUnreadMessageCount > 0) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("MessageCount") ]
	HTTP_CODE OnMessageCount()
	{
		// Respond with the total message count
		if (m_lMessageCount >= 0) 
			m_HttpResponse << m_lMessageCount;
		else
			m_HttpResponse << "unknown";
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
		m_HttpResponse << m_inboxInfo.m_lMessageID;
		return HTTP_SUCCESS;
	}

	[ tag_name("MarkedRead") ]
	HTTP_CODE OnMarkedRead()
	{
		// return HTTP_SUCCESS if this message has been read
		return (m_inboxInfo.m_bMarkedRead) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("MessageFrom") ]
	HTTP_CODE OnMessageFrom()
	{
		// Respond with the message's from field
		m_HttpResponse << m_inboxInfo.m_szFrom;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageSubject") ]
	HTTP_CODE OnMessageSubject()
	{
		// Respond with the message's subject
		m_HttpResponse << m_inboxInfo.m_szSubject;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageDate") ]
	HTTP_CODE OnMessageDate()
	{
		// Respond with the message's date
		m_HttpResponse << m_inboxInfo.m_szDate;
		return HTTP_SUCCESS;
	}

	[ tag_name("NextMessage") ]
	HTTP_CODE OnNextMessage()
	{
		// Move to the next message
		m_hRes = m_inboxInfo.MoveNext();
		return HTTP_SUCCESS;
	}

	[ tag_name("DisableButtons") ]
	HTTP_CODE OnDisableButtons()
	{
		// Respond HTTP_SUCCESS if there are no messages in the inbox (disables the buttons)
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
		markMsg.m_lOldBox = 0;

		// Get the first form var
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			// If this is a checked mark check box
			if (sscanf(varname, "id%d", &markMsg.m_lMessageID) != 0)
			{
				// Mark the message for deletion (move to trash bin)
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

	HTTP_CODE CheckPOPMail()
	{
		//TODO: Insert code to check POP mail here.
		//      Check with the POP RFC's to see how to do this.
		return HTTP_SUCCESS;
	}

}; // class CInboxHandler
