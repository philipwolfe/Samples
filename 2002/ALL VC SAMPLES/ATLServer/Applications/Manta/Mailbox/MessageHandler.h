// CMessageHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "MessageDB.h"
#include "TrashbinDB.h"
#include "ComposeDB.h"

// class CMessageHandler
// This handler is responsible for displaying a mail message to the user
[ request_handler("Message") ]
class CMessageHandler : public CMantaWebBase<CMessageHandler>
{
private:
	CMessageInfo m_messageInfo;		// Message information
	bool m_bAllowReply;				// Boolean if we allow the reply button
	bool m_bAllowForward;			// Boolean if we allow the forward button
	bool m_bAllowDelete;			// Boolean if we allow the delete button
	bool m_bAllowSave;				// Boolean if we allow the save button

public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");
		
		// Validate the session
		if (!ValidateSession())
			return ValidationError();
		
		const CHttpRequestParams& QueryParams = m_HttpRequest.GetQueryParams();
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		// If this is a delete request, delete the message and redirect to the ref
		if (QueryParams.Lookup("delmsg") != NULL && QueryParams.Lookup("ref") != NULL)
			return DeleteMessage();

		// If this is a request to save an updated message, save it
		if (FormFields.Lookup("messageText") != NULL && FormFields.Lookup("message") != NULL)
			return SaveMessage();
		
		// If the message and ref parameters aren't there, bad request
		if (QueryParams.Lookup("message") == NULL || QueryParams.Lookup("ref") == NULL)
			return HTTP_BAD_REQUEST;
		
		HRESULT hr;

		// If the inbox is refering
		if (lstrcmp(QueryParams.Lookup("ref"), "inbox") == 0)
		{
			// Mark the message as read
			CMarkMessageAsRead markAsRead;

			if (QueryParams.Exchange("message", &markAsRead.m_lMessageID) != VALIDATION_S_OK)
				return HTTP_BAD_REQUEST;
			GetUserID(&markAsRead.m_lUserID);

			hr = markAsRead.OpenRowset(m_dataConnection);
			if (hr != S_OK)
				return DatabaseError("CMarkMessageAsRead::OpenRowset()", hr);
		}

		if (QueryParams.Exchange("message", &m_messageInfo.m_lMessageID) != VALIDATION_S_OK)
				return HTTP_BAD_REQUEST;
		GetUserID(&m_messageInfo.m_lUserID);

		// Get the message information
		hr = m_messageInfo.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CMessageInfo::OpenRowset()", hr);

        hr = m_messageInfo.MoveFirst();
		if (hr != S_OK && hr != DB_S_ENDOFROWSET)
			return DatabaseError("CMessageInfo::MoveFirst()", hr);
		
		// Turn off all the buttons
		m_bAllowReply = FALSE;
        m_bAllowForward = FALSE;
		m_bAllowDelete = FALSE;
		m_bAllowSave = FALSE;

		// If this the inbox refering, turn on reply, forward, and delete
		if (lstrcmp(QueryParams.Lookup("ref"), "inbox") == 0)
		{
			m_bAllowReply = TRUE;
            m_bAllowForward = TRUE;
			m_bAllowDelete = TRUE;
		}
		// If this is the outbox refering, turn on delete and save
		else if (lstrcmp(QueryParams.Lookup("ref"), "outbox") == 0)
		{
			m_bAllowDelete = TRUE;
			m_bAllowSave = TRUE;
		}
		// If this is the sent mail box refering, turn on delete
		else if (lstrcmp(QueryParams.Lookup("ref"), "sentmail") == 0)
		{
			m_bAllowDelete = TRUE;
		}
		return HTTP_SUCCESS;
	}

	[ tag_name("From") ]
	HTTP_CODE OnFrom()
	{
		// Respond with the message from field
		m_HttpResponse << m_messageInfo.m_szFrom;
		return HTTP_SUCCESS;
	}

	[ tag_name("To") ]
	HTTP_CODE OnTo()
	{
		// Respond with the message to field
		m_HttpResponse << m_messageInfo.m_szTo;
		return HTTP_SUCCESS;
	}

	[ tag_name("Subject") ]
	HTTP_CODE OnSubject()
	{
		// Respond with the message subject
		m_HttpResponse << m_messageInfo.m_szSubject;
		return HTTP_SUCCESS;
	}

	[ tag_name("Date") ]
	HTTP_CODE OnDate()
	{
		// Respond with the message date
		m_HttpResponse << m_messageInfo.m_szDate;
		return HTTP_SUCCESS;
	}
	
	[ tag_name("MessageID") ]
	HTTP_CODE OnMessageID()
	{
		// Respond with the message id
		m_HttpResponse << m_messageInfo.m_lMessageID;
		return HTTP_SUCCESS;
	}

	[ tag_name("Ref") ]
	HTTP_CODE OnRef()
	{
		// Respond with the refering box
		m_HttpResponse << m_HttpRequest.GetQueryParams().Lookup("ref");
		return HTTP_SUCCESS;
	}

	[ tag_name("Message") ]
	HTTP_CODE OnMessage()
	{
		// Respond with the message text
		m_HttpResponse << m_messageInfo.m_szMessage;
		return HTTP_SUCCESS;
	}

	[ tag_name("ReplyButton") ]
	HTTP_CODE OnReplyButton()
	{
		// Return HTTP_SUCCESS if the reply button is allowed
		return (m_bAllowReply) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("ForwardButton") ]
	HTTP_CODE OnForwardButton()
	{
		// Return HTTP_SUCCESS if the forward button is allowed
		return (m_bAllowForward) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("DeleteButton") ]
	HTTP_CODE OnDeleteButton()
	{
		// Return HTTP_SUCCESS if the delete button is allowed
		return (m_bAllowDelete) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("SaveButton") ]
	HTTP_CODE OnSaveButton()
	{
		// Return HTTP_SUCCESS if the save button is allowed
		return (m_bAllowSave) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

protected:
	HTTP_CODE DeleteMessage()
	{
		CMarkMessageForDelete markMsg;
		HRESULT hr;
	
		GetUserID(&markMsg.m_lUserID);
		if (m_HttpRequest.GetQueryParams().Exchange("delmsg", &markMsg.m_lMessageID) != VALIDATION_S_OK)
			return HTTP_FAIL;

		// Set the old box to the refering box
		if (lstrcmp(m_HttpRequest.GetQueryParams().Lookup("ref"), "inbox") == 0)
			markMsg.m_lOldBox = 0;
		else if (lstrcmp(m_HttpRequest.GetQueryParams().Lookup("ref"), "outbox") == 0)
			markMsg.m_lOldBox = 1;
		else if (lstrcmp(m_HttpRequest.GetQueryParams().Lookup("ref"), "sentmail") == 0)
			markMsg.m_lOldBox = 3;
        
		// Mark the message for deletion (move to trashbin)
		hr = markMsg.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CMarkMessageForDelete::OpenRowset()", hr);

		// Redirect the browser to the refering box
		CString redirect;
		redirect.Format("%s.srf", m_HttpRequest.GetQueryParams().Lookup("ref"));
		m_HttpResponse.Redirect(redirect);
		return HTTP_SUCCESS_NO_PROCESS;
	}

	HTTP_CODE SaveMessage()
	{
		CUpdateMessage updateMsg;
		HRESULT hr;

		GetUserID(&updateMsg.m_lUserID);
		if (m_HttpRequest.GetQueryParams().Exchange("message", &updateMsg.m_lMessageID) != VALIDATION_S_OK)
			return HTTP_FAIL;

		// Copy the new message text
		lstrcpyn(updateMsg.m_szMessage, m_HttpRequest.GetFormVars().Lookup("messageText"), MAX_MSG_LENGTH);
		// Save the message
		hr = updateMsg.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CUpdateMessage::OpenRowset()", hr);

		// Redirect to outbox
		m_HttpResponse.Redirect("outbox.srf");
		return HTTP_SUCCESS_NO_PROCESS;
	}
}; // class CMessageHandler
