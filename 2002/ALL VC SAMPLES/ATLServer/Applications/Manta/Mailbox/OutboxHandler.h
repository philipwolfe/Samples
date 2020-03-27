// OutboxHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "OutboxDB.h"
#include "TrashbinDB.h"
#include "ComposeDB.h"
#include "ATLSMTPConnection.h"

// class COutboxHandler
// This handler is responsible for displaying all the messages in the user's outbox.
// The user can delete marked messages, and send all the mail in the outbox.
[ request_handler("Outbox") ]
class COutboxHandler : public CMantaWebBase<COutboxHandler>
{
private:
	COutboxInfo m_outboxInfo;		// Outbox information
	LONG m_lMessageCount;			// Total message count in the outbox
	HRESULT m_hRes;					// HRESULT for outbox database operations

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
		// Otherwise if this is a send mail request, send all the outgoing messages
		else if (m_HttpRequest.GetQueryParams().Lookup("sendmsgs") != NULL)
		{
			if (SendMail() == HTTP_SUCCESS_NO_PROCESS)
				return HTTP_SUCCESS_NO_PROCESS;
		}

		// Get the outbox total message count
		COutboxMessageCount msgCount;
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

		// Get the outbox message information
		m_outboxInfo.m_lUserID = msgCount.m_lUserID;
		m_hRes = m_outboxInfo.OpenRowset(m_dataConnection, NULL);
		if (m_hRes != S_OK)
			return DatabaseError("COutboxInfo::OpenRowset()", m_hRes);
		m_hRes = m_outboxInfo.MoveFirst();
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
		// Return HTTP_SUCCESS if there are messages still left
		return (m_hRes != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	[ tag_name("MessageID") ]
	HTTP_CODE OnMessageID()
	{
		// Respond with the message id
		m_HttpResponse << m_outboxInfo.m_lMessageID;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageTo") ]
	HTTP_CODE OnMessageTo()
	{
		// Respond with the message to field
		m_HttpResponse << m_outboxInfo.m_szTo;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageSubject") ]
	HTTP_CODE OnMessageSubject()
	{
		// Respond with the message subject
		m_HttpResponse << m_outboxInfo.m_szSubject;
		return HTTP_SUCCESS;
	}

	[ tag_name("MessageDate") ]
	HTTP_CODE OnMessageDate()
	{
		// Respond with the message date
		m_HttpResponse << m_outboxInfo.m_szDate;
		return HTTP_SUCCESS;
	}

	[ tag_name("NextMessage") ]
	HTTP_CODE OnNextMessage()
	{
		// Move to the next message
		m_hRes = m_outboxInfo.MoveNext();
		return HTTP_SUCCESS;
	}

	[ tag_name("DisableButtons") ]
	HTTP_CODE OnDisableButtons()
	{
		// If there are no messages, return HTTP_SUCCESS to disable the buttons
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
		markMsg.m_lOldBox = 1;

		// Get the first form var
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			// If this is checked mark check box
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

	HTTP_CODE SendMail()
	{
		COutboxMessages outboxMsgs;
		HRESULT hr;

		// Get all the out box messages
		GetUserID(&outboxMsgs.m_lUserID);
		hr = outboxMsgs.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("COutboxMessages::OpenRowset()", hr);

		hr = outboxMsgs.MoveFirst();
		if (hr != S_OK && hr != DB_S_ENDOFROWSET)
			return DatabaseError("COutboxMessages::MoveFirst()", hr);

		// While there are still messages to send
		while (hr == S_OK)
		{
			// If there is no @, send internally
			if (strstr(outboxMsgs.m_szTo, "@") == NULL)
			{
				if (SendInternalMessage(outboxMsgs) == HTTP_SUCCESS_NO_PROCESS)
					return HTTP_SUCCESS_NO_PROCESS;
			}
			else	// Send externally (through SMTP)
			{
				if (SendExternalMessage(outboxMsgs) == HTTP_SUCCESS_NO_PROCESS)
					return HTTP_SUCCESS_NO_PROCESS;
			}

			// Move the message in the outbox to the sent mail folder
			CMoveMessageToSentMail moveMsg;
			moveMsg.m_lUserID = outboxMsgs.m_lUserID;
			moveMsg.m_lMessageID = outboxMsgs.m_lMessageID;
			hr = moveMsg.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CMoveMessageToSentMail::OpenRowset()", hr);
			moveMsg.Close();

			// Move to the next message
			hr = outboxMsgs.MoveNext();
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE SendInternalMessage(const COutboxMessages& outboxMsg)
	{
		HRESULT		hr;
		CFindUserID findUserID;

		// Find the user id of the matching login
		lstrcpyn(findUserID.m_szLogin, outboxMsg.m_szTo, DB_MAX_STRLEN);
		hr = findUserID.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CFindUserID::OpenRowset()", hr);
		hr = findUserID.MoveFirst();
		if (hr != S_OK)
			return DatabaseError("CFindUserID::MoveFirst()", hr);
		findUserID.Close();

		// Add the message to the specified user's inbox
		CAddNewMessage addMessage;
		addMessage.m_lBox = 0;
		addMessage.m_lUserID = findUserID.m_lUserID;
		lstrcpyn(addMessage.m_szTo, outboxMsg.m_szTo, DB_MAX_STRLEN);
		lstrcpyn(addMessage.m_szSubject, outboxMsg.m_szSubject, DB_MAX_STRLEN);
		lstrcpyn(addMessage.m_szFrom, outboxMsg.m_szFrom, DB_MAX_STRLEN);
		lstrcpyn(addMessage.m_szMessage, outboxMsg.m_szMessage, MAX_MSG_LENGTH);
		hr = addMessage.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CAddNewMessage::OpenRowset()", hr);
		addMessage.Close();

		return HTTP_SUCCESS;
	}

	HTTP_CODE SendExternalMessage(const COutboxMessages& outboxMsg)
	{
		HRESULT hr;
        CMimeMessage msg;
		CStringA strSender;

		// Create the mime message
		strSender.Format("%s@MantaWeb.com",  GetLogin());
        msg.SetSender(strSender);
		msg.SetSenderName(outboxMsg.m_szFrom);
		msg.SetSubject(outboxMsg.m_szSubject);
		msg.AddRecipient(outboxMsg.m_szTo);
		msg.AddText(outboxMsg.m_szMessage);

		// Connect to the SMTP server and send the message
		CSMTPConnection connection;
		if (!connection.Connect("localhost"))
			return SMTPError();
		if (!connection.SendMessage(msg))
			return SMTPError();

		return HTTP_SUCCESS;
	}

}; // class COutboxHandler
