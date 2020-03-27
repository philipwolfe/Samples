// TaskHandler.h : Defines the ATL Server request handler class
// This handler class is for the viewing and deleting of individual tasks and details.
// Do not confuse with TasksHandler.h, which handles viewing of all tasks and adding of tasks.
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "TasksDB.h"
#include "TaskDB.h"

// class CTaskHandler
// This handler is responsible for displaying the task data to the user
class CTaskHandler
	: public CRequestHandlerT<CTaskHandler>,
	  public CMantaWebBase<CTaskHandler>
{
private:
	CTask m_task;	// Task data
	
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		const CHttpRequestParams& QueryParams = m_HttpRequest.GetQueryParams();

		// If the task id is missing or invalid, bad request
		if (QueryParams.Lookup("taskid") == NULL)
			return HTTP_BAD_REQUEST;
		
		LONG lTaskID;
		if (QueryParams.Exchange("taskid", &lTaskID) != VALIDATION_S_OK)
			return HTTP_BAD_REQUEST;

		HRESULT hr;
		if (QueryParams.Lookup("delete") != NULL)	// Delete operation
		{
			// Delete the task from the database
			CDeleteTask deleteTask;
			deleteTask.m_lTaskID = lTaskID;
			GetUserID(&deleteTask.m_lUserID);
			hr = deleteTask.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CDeleteTask::OpenRowset()", hr);

			// Redirect them to the tasks page
			m_HttpResponse.Redirect("tasks.srf");
			return HTTP_SUCCESS_NO_PROCESS;
		}
		else if (QueryParams.Lookup("view") != NULL)
		{
			// Get the task details from the database
			m_task.m_lTaskID = lTaskID;
			GetUserID(&m_task.m_lUserID);

			hr = m_task.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CTask::OpenRowset()", hr);

			hr = m_task.MoveFirst();
			if (hr != S_OK)
				return DatabaseError("CTask::MoveFirst()", hr);
		}
		else
			return HTTP_BAD_REQUEST;

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnID()
	{
		// Respond with the task id
		m_HttpResponse << m_task.m_lTaskID;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		// Respond with the task title
		m_HttpResponse << m_task.m_szTitle;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDate()
	{
		COleDateTime date(m_task.m_DueDate);

		if (date.GetStatus() == COleDateTime::valid)
		{
			m_HttpResponse << date.Format("%A, %B %d, %Y");
		
			// Respond with the task date
			COleDateTime today = COleDateTime::GetCurrentTime();
			today.SetDateTime(today.GetYear(), today.GetMonth(), today.GetDay(), 0, 0, 0);
		
			// If the task is over due, report how many days over due
			if (date < today)
			{
				COleDateTimeSpan span = today - date;
				m_HttpResponse << " <font color=\"#FF0000\">(this task is "
							   << int(span.GetTotalDays()) << " day(s) over due)</font>";
			}
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnPriority()
	{
		// Respond with the task priority
		switch (m_task.m_lPriority)
		{
			case 0:
			m_HttpResponse << "Low Priority";
			break;

			case 1:
			m_HttpResponse << "Normal Priority";
			break;

			case 2:
			m_HttpResponse << "High Priority";
			break;

			default:
			m_HttpResponse << "Unknown Priority";
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDetails()
	{
		// Respond with the task details
		m_HttpResponse << m_task.m_szDetails;
		return HTTP_SUCCESS;
	}

	// Replacement method map
	BEGIN_REPLACEMENT_METHOD_MAP(CTaskHandler)
		REPLACEMENT_METHOD_ENTRY("ID", OnID)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("Date", OnDate)
		REPLACEMENT_METHOD_ENTRY("Priority", OnPriority)
		REPLACEMENT_METHOD_ENTRY("Details", OnDetails)
	END_REPLACEMENT_METHOD_MAP()

}; // class CTaskHandler
