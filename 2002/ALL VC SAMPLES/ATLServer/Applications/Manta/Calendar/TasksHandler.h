// TasksHandler.h : Defines the ATL Server request handler class
// This handler class is for the viewing, deleting and adding individual tasks.
// Do not confuse with TaskHandler.h, which handles viewing and deleting of a single task.
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

// class CTasksHandler
// This handler is responsible for displaying all tasks, deleting marked tasks, and adding new tasks.
class CTasksHandler
	: public CRequestHandlerT<CTasksHandler>,
	  public CMantaWebBase<CTasksHandler>
{
private:
	HRESULT			m_hRes;				// HRESULT for task list db calls
	HRESULT			m_hResToday;		// HRESULT for today's task list db calls
	CTasksList		m_taskList;			// List of all tasks
	CTodaysTasks	m_todaysTasks;		// List of today's tasks
	COleDateTime	m_date;				// Date of schedule being viewed or added
	bool			m_bHasTasks;		// Boolean to specify if the user had tasks
	int				m_iPriority;		// Priority of new task
	CStringA		m_strTaskTitle;		// Title of new task
	CStringA		m_strTaskDetails;	// Details of new task
	bool			m_bFailed;			// Boolean to specify if adding a new task failed
	
public:
	CTasksHandler() : m_iPriority(1), m_bFailed(false)
	{
		m_date.SetStatus(COleDateTime::invalid);
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html		
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		// Check if we're adding a task, or deleting tasks
		if (FormFields.Lookup("addform") != NULL)			// Adding task
		{
			if (ValidateFormData(FormFields))	// Validate member data
			{
				if (AddTask() != HTTP_SUCCESS)			// Add the task
					return HTTP_SUCCESS_NO_PROCESS;
			}
			else
				m_bFailed = true;
		}
		else if (FormFields.Lookup("deleteform") != NULL)	// Deleting tasks
		{
			if (DeleteMarkedTasks() != HTTP_SUCCESS)	// Delete the tasks
				return HTTP_SUCCESS_NO_PROCESS;
		}

		// Reset the date if its invalid and unspecified
		if (m_date.GetStatus() != COleDateTime::valid)
		{
			m_date = COleDateTime::GetCurrentTime();
			m_date.SetDateTime(m_date.GetYear(), m_date.GetMonth(), m_date.GetDay(), 0, 0, 0);
		}

		// Open up the task list for this user
		GetUserID(&m_taskList.m_lUserID);
		m_hRes = m_taskList.OpenRowset(m_dataConnection, NULL);
		if (m_hRes != S_OK)
			return DatabaseError("CTasksList::OpenRowset()", m_hRes);

		m_hRes = m_taskList.MoveFirst();
		if (m_hRes != S_OK && m_hRes != DB_S_ENDOFROWSET)
			return DatabaseError("CTasksList::MoveFirst()", m_hRes);

		// Check to see if there were rows (user had tasks)
		if (m_hRes != DB_S_ENDOFROWSET)
			m_bHasTasks = true;
		else
			m_bHasTasks = false;

		// Open up today's tasks for the user
		m_todaysTasks.m_lUserID = m_taskList.m_lUserID;
		m_hResToday = m_todaysTasks.OpenRowset(m_dataConnection, NULL);
		if (m_hResToday != S_OK)
			return DatabaseError("CTodaysTasks::OpenRowset()", m_hResToday);

		m_hResToday = m_todaysTasks.MoveFirst();
		if (m_hResToday != S_OK && m_hResToday != DB_S_ENDOFROWSET)
			return DatabaseError("CTodaysTasks::MoveFirst()", m_hResToday);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTaskTitle()
	{
		bool bOverdue = false;
		COleDateTime taskDate;

		// Parse the date time from the string
		taskDate.ParseDateTime(m_taskList.m_szDate, VAR_DATEVALUEONLY);
		
		// Check to see if the task is overdue
		if (m_date > taskDate)
			bOverdue = true;

		// Set the font to red if overdue
		if (bOverdue)
			m_HttpResponse << "<font color=\"#FF0000\">";

		// Respond with the title
		m_HttpResponse << m_taskList.m_szTitle;
		
		// Close the font tag
		if (bOverdue)
			m_HttpResponse << "</font>";

		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnTaskID()
	{
		// Respond with the task id
		m_HttpResponse << m_taskList.m_lTaskID;
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnPriorityImage()
	{
		// Respond with the priority image
		switch (m_taskList.m_lPriority)
		{
			case 0:
			m_HttpResponse << "<img border=\"0\" src=\"images\\low_priority.gif\" width=\"16\" height=\"16\" alt=\
							  \"This task is marked low priority.\">";
			break;

			case 1:
			// Respond so the cell's not completely empty
			m_HttpResponse << "&nbsp;&nbsp;";
			break;

			case 2:
			m_HttpResponse << "<img border=\"0\" src=\"images\\high_priority.gif\" width=\"16\" height=\"16\" alt=\
							  \"This task is marked high priority.\">";
			break;
		}
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnTaskDate()
	{
		// Respond with the task date
		m_HttpResponse << m_taskList.m_szDate;
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnTasksLeft()
	{
		// Return HTTP_SUCCESS if there are tasks still left
		return (m_hRes != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}
	
	HTTP_CODE OnNextTask()
	{
		// Get next task
		m_hRes = m_taskList.MoveNext();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDisableButtons()
	{
		// If there are no tasks, disable the button
		if (!m_bHasTasks)
			m_HttpResponse << "disabled";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTasksLeftToday()
	{
		return (m_hResToday != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}
	
	HTTP_CODE OnPriorityImageToday()
	{
		// Set the priority image for the today list
		switch (m_todaysTasks.m_lPriority)
		{
			case 0:
			m_HttpResponse << "<img border=\"0\" src=\"images\\low_priority.gif\" width=\"16\" height=\"16\" alt=\
							  \"This task is marked low priority.\">";
			break;

			case 1:
			m_HttpResponse << "&nbsp;";
			break;

			case 2:
			m_HttpResponse << "<img border=\"0\" src=\"images\\high_priority.gif\" width=\"16\" height=\"16\" alt=\
							  \"This task is marked high priority.\">";
			break;
		}
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnTaskTitleToday()
	{
		// Respond with the task title for the today list
		m_HttpResponse << m_todaysTasks.m_szTitle;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTaskIDToday()
	{
		// Respond with the task id for the today list
		m_HttpResponse << m_todaysTasks.m_lTaskID;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextTaskToday()
	{
		// Get next task due today
		m_hResToday = m_todaysTasks.MoveNext();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSelectedMonth(int *pMonth)
	{
		ATLASSERT(pMonth != NULL);

		// If this is the selected month, respond with "selected"
		if (*pMonth == m_date.GetMonth())
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSelectedDay(int *pDay)
	{
		ATLASSERT(pDay != NULL);

		// If this is the selected day, respond with "selected"
		if (*pDay == m_date.GetDay())
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSelectedYear(int *pYear)
	{
		ATLASSERT(pYear != NULL);

		// If this is the selected year, respond with "selected"
		if (*pYear == m_date.GetYear())
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSelectedPriority(int *pPriority)
	{
		ATLASSERT(pPriority != NULL);

		// If this is the selected priority level, respond with "selected"
		if (*pPriority == m_iPriority)
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTaskTitleInput()
	{
		// Respond with the task title input
		m_HttpResponse << m_strTaskTitle;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTaskDetailsInput()
	{
		// Respond with the task details input
		m_HttpResponse << m_strTaskDetails;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnFailure()
	{
		// Return HTTP_SUCCESS if there was a failure
		return (m_bFailed) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	HTTP_CODE OnMaxStringLen()
	{
		// Respond with the max string len
		m_HttpResponse << DB_MAX_STRLEN;
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnMaxDetailsLen()
	{
		// Respond with the max details len
		m_HttpResponse << DB_MAX_DETAILSLEN;
		return HTTP_SUCCESS;
	}

	// Replacement method map
	BEGIN_REPLACEMENT_METHOD_MAP(CTasksHandler)
		REPLACEMENT_METHOD_ENTRY("TaskTitle", OnTaskTitle)
		REPLACEMENT_METHOD_ENTRY("TaskID", OnTaskID)
		REPLACEMENT_METHOD_ENTRY("PriorityImage", OnPriorityImage)
		REPLACEMENT_METHOD_ENTRY("TaskDate", OnTaskDate)
		REPLACEMENT_METHOD_ENTRY("TasksLeft", OnTasksLeft)
		REPLACEMENT_METHOD_ENTRY("NextTask", OnNextTask)
		REPLACEMENT_METHOD_ENTRY("DisableButtons", OnDisableButtons)
		REPLACEMENT_METHOD_ENTRY("TasksLeftToday", OnTasksLeftToday)
		REPLACEMENT_METHOD_ENTRY("PriorityImageToday", OnPriorityImageToday)
		REPLACEMENT_METHOD_ENTRY("TaskTitleToday", OnTaskTitleToday)
		REPLACEMENT_METHOD_ENTRY("TaskIDToday", OnTaskIDToday)
		REPLACEMENT_METHOD_ENTRY("NextTaskToday", OnNextTaskToday)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedMonth", OnSelectedMonth, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedDay", OnSelectedDay, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedYear", OnSelectedYear, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedPriority", OnSelectedPriority, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY("TaskTitleInput", OnTaskTitleInput)
		REPLACEMENT_METHOD_ENTRY("TaskDetailsInput", OnTaskDetailsInput)
		REPLACEMENT_METHOD_ENTRY("Failure", OnFailure)
		REPLACEMENT_METHOD_ENTRY("MaxStringLen", OnMaxStringLen)
		REPLACEMENT_METHOD_ENTRY("MaxDetailsLen", OnMaxDetailsLen)
	END_REPLACEMENT_METHOD_MAP()

private:

	bool ValidateFormData(const CHttpRequestParams& FormFields)
	{
		// Validate all the add form data
		if (FormFields.Validate("priority", &m_iPriority, 0, 3) != VALIDATION_S_OK)
			return false;

		if (FormFields.Validate("title", &m_strTaskTitle, 1, DB_MAX_STRLEN) != VALIDATION_S_OK)
			return false;
		
		// Prepare for HTML
		HTMLPrepareString(m_strTaskTitle);
		if (m_strTaskTitle.GetLength() > DB_MAX_STRLEN)
			return false;

		DWORD dwRet = FormFields.Validate("details", &m_strTaskDetails, 0, DB_MAX_DETAILSLEN);
		if (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY)
			return false;

		// Prepare for HTML
		HTMLPrepareString(m_strTaskDetails);
		if (m_strTaskDetails.GetLength() > DB_MAX_DETAILSLEN)
			return false;

		// Validate the due date
		int year, month, day;
        if (FormFields.Validate("dueyear", &year, 1582, 10000) != VALIDATION_S_OK)
			return false;
		if (FormFields.Validate("duemonth", &month, 1, 12) != VALIDATION_S_OK)
			return false;
		if (FormFields.Validate("dueday", &day, 1, 31) != VALIDATION_S_OK)
			return false;
		
		m_date.SetDate(year, month, day);
		if (m_date.GetStatus() != COleDateTime::valid)
			return false;
		
		return true;
	}

	HTTP_CODE AddTask()
	{
		CNewTask newTask;

		// Copy the task data
		lstrcpy(newTask.m_szTitle, m_strTaskTitle); 
		newTask.m_dueDate = (DATE) m_date;
		newTask.m_lPriority = m_iPriority;
		lstrcpy(newTask.m_szDetails, m_strTaskDetails);
		GetUserID(&newTask.m_lUserID);

		// Add the task into the database
		HRESULT hr = newTask.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CNewTask::OpenRowset()", hr);

		// Reset the member data
		m_strTaskTitle = "";
		m_date.SetStatus(COleDateTime::invalid);
		m_iPriority = 1;
		m_strTaskDetails = "";

		return HTTP_SUCCESS;
	}

	HTTP_CODE DeleteMarkedTasks()
	{
		HRESULT hr;
		POSITION pos;
		LPCSTR varname;
		LPCSTR varvalue;
		CDeleteTask deleteTask;

		GetUserID(&deleteTask.m_lUserID);
		
		// While there are form vars left
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			// If this is a delete task id name
			if (sscanf(varname, "taskid%d", &deleteTask.m_lTaskID) != 0)
			{
				// Delete the specified task given the id
				hr = deleteTask.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CDeleteTask::OpenRowset()", hr);
				deleteTask.Close();
		    }
			// Get the next form var
			pos = m_HttpRequest.GetNextFormVar(pos, &varname, &varvalue);
		}
		return HTTP_SUCCESS;
	}

}; // class CTasksHandler
