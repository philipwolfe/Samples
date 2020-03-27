// ScheduleHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "ScheduleDB.h"

#define START_TIME	8	// Start the schedule at 08:00 (8 A.M.)
#define END_TIME	20	// End the schedule at 19:00 (8 P.M.)

inline HRESULT AddNewAppointment(
		CDataConnection& DataConnection,
		long nMonth,
		long nDay,
		long nYear,
		long nTime,
		long nUserID,
		LPCTSTR szTitle,
		LPCTSTR szLocation,
		LPCTSTR szDetails)
	{
		CNewAppointment newAppointment;

		// Copy the data into the appointment
		sprintf(newAppointment.m_szDate, "%d/%d/%d", nMonth, nDay, nYear);
		lstrcpy(newAppointment.m_szTitle, szTitle);
        lstrcpy(newAppointment.m_szLocation, szLocation);
        lstrcpy(newAppointment.m_szDetails, szDetails);
		newAppointment.m_lTime = nTime;
		newAppointment.m_lUserID = nUserID;

		// Add the appointment into the database
		return newAppointment.OpenRowset(DataConnection, NULL);
	}


// class CScheduleHandler
// This handler is responsible for displaying the entire schedule grid for a given day
// Note: There is a tag {{SetTodays}} used by welcome.srf which switches a boolean on.
//       This boolean ignores the current hour member to display the entire schedule 
//       for the day in sequence, without attempting to fit the appointments in a grid
//       like in schedule.srf.
class CScheduleHandler
	: public CRequestHandlerT<CScheduleHandler>,
	  public CMantaWebBase<CScheduleHandler>
{
private:
	HRESULT				m_hRes;				// Member HRESULT for DB calls			
	COleDateTime		m_date;				// The date viewed by the schedule
	COleDateTime		m_datePrev;			// The previous day's date
	COleDateTime		m_dateNext;			// The next day's date
	CAppointmentList	m_appointmentList;	// Schedule DB object
	bool				m_bFailed;			// Boolean to determine failure
	int					m_iCurHour;			// Current hour viewed
	bool				m_bTodays;			// Boolean to determine if we're listing today's schedule (from welcome screen)
	CStringA			m_strTitle;			// Title of the new appointment
	CStringA			m_strLocation;		// Location of the new appointment
	CStringA			m_strDetails;		// Details of the new appointment
	LONG				m_lStart;			// Start of new appointment (in 24 hour format, duration is assumed to be 1 hour)
	
public:
	CScheduleHandler() : m_bFailed(false),
		                 m_iCurHour(START_TIME),
						 m_bTodays(false)
	{
		// Set the status to invalid
		m_date.SetStatus(COleDateTime::invalid);
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();
			
		const CHttpRequestParams& QueryParams = m_HttpRequest.GetQueryParams();
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		
		// Set the internal date to the one specified by query params
		// If its invalid, reset to today
		int year, month, day;
        QueryParams.Exchange("year", &year);
		QueryParams.Exchange("month", &month);
		QueryParams.Exchange("day", &day);
		m_date.SetDate(year, month, day);
		if (m_date.GetStatus() != COleDateTime::valid)
			m_date = COleDateTime::GetCurrentTime();

		// If this is a valid form submition
		if (FormFields.Lookup("title") != NULL &&
			FormFields.Lookup("start") != NULL &&
			FormFields.Lookup("duration") != NULL)
		{
			// Validate and add new appointment
			if (ValidateFormData(FormFields))
			{
				if (AddNewAppointment() != HTTP_SUCCESS)
					return HTTP_SUCCESS_NO_PROCESS;
			}
			else
				m_bFailed = true;	// Data was invalid
		}
		else
		{
			// Set the default values
			m_lStart = 8;
		}
		
		// Set the next and previous days
		m_datePrev = m_date - COleDateTimeSpan(1, 0, 0, 0);
		m_dateNext = m_date + COleDateTimeSpan(1, 0, 0, 0);

		// Open up the schedule for the internal date
		GetUserID(&m_appointmentList.m_lUserID);
		sprintf(m_appointmentList.m_szDate, "%d/%d/%d", m_date.GetMonth(), m_date.GetDay(), m_date.GetYear());

		m_hRes = m_appointmentList.OpenRowset(m_dataConnection, NULL);
		if (m_hRes != S_OK)
			return DatabaseError("CSchedule::OpenRowset()", m_hRes);
	
		m_hRes = m_appointmentList.MoveFirst();
		if (m_hRes != S_OK && m_hRes != DB_S_ENDOFROWSET)
			return DatabaseError("CSchedule::MoveFirst()", m_hRes);
	
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextDay()
	{
		// Respond with the next day's day
		m_HttpResponse << m_dateNext.GetDay();
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnNextMonth()
	{
		// Respond with the next day's month
		m_HttpResponse << m_dateNext.GetMonth();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextYear()
	{
		// Respond with the next day's year
		m_HttpResponse << m_dateNext.GetYear();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnPrevDay()
	{
		// Respond with the previous day's day
		m_HttpResponse << m_datePrev.GetDay();
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnPrevMonth()
	{
		// Respond with the previous day's month
		m_HttpResponse << m_datePrev.GetMonth();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnPrevYear()
	{
		// Respond with the previous day's year	
		m_HttpResponse << m_datePrev.GetYear();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDate()
	{
		// Respond with the long date
		m_HttpResponse << m_date.Format("%A, %B %d, %Y");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSetTodays()
	{
		// Note: this is used in the welcome.srf to let us know that we want to ignore m_iCurHour
		// and list all the appoinments for today in order
		m_bTodays = true;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnRowsLeft()
	{
		// Used in schedule.srf to run through all the rows
		ATLASSERT(m_iCurHour >= START_TIME && m_iCurHour <= END_TIME);
		return (m_iCurHour < END_TIME) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	HTTP_CODE OnNextRow()
	{
		// Used in schedule.srf to increment to the next row
		ATLASSERT(m_iCurHour >= START_TIME && m_iCurHour < END_TIME);
		if (m_appointmentList.m_lTime == m_iCurHour)
			m_appointmentList.MoveNext();
		m_iCurHour++;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnCellColor()
	{
		// Respond with the cell color
		// white - scheduled, yellowish - not scheduled
		if (m_appointmentList.m_lTime == m_iCurHour)
			m_HttpResponse << "#FFFFFF";
		else
			m_HttpResponse << "#FFFFCC";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnStartTime()
	{
		// If listing today's, just output the appointment start time
		// Otherwise, use the current hour
		if (m_bTodays)
			m_HttpResponse << ((m_appointmentList.m_lTime > 12) ? (m_appointmentList.m_lTime - 12) : m_appointmentList.m_lTime);
		else
			m_HttpResponse << ((m_iCurHour > 12) ? (m_iCurHour - 12) : m_iCurHour);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnStartAM()
	{
		// If listing today's, return HTTP_SUCCESS if the appointment start time is AM
		// Otherwise, use the current hour
		if (m_bTodays)
			return (m_appointmentList.m_lTime >= 12) ? HTTP_S_FALSE : HTTP_SUCCESS;
		else
			return (m_iCurHour >= 12) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	HTTP_CODE OnEndTime()
	{
		// If listing today's, just output the appointment end time
		// Otherwise, use the current hour
		if (m_bTodays)
			m_HttpResponse << ((m_appointmentList.m_lTime > 11) ? (m_appointmentList.m_lTime - 11) : (m_appointmentList.m_lTime + 1));
		else
			m_HttpResponse << ((m_iCurHour > 11) ? (m_iCurHour - 11) : (m_iCurHour + 1));
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnEndAM()
	{
		// If listing today's, return HTTP_SUCCESS if the appointment end time is AM
		// Otherwise, use the current hour
		if (m_bTodays)
			return (m_appointmentList.m_lTime >= 11) ? HTTP_S_FALSE : HTTP_SUCCESS;
		else
			return (m_iCurHour >= 11) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	HTTP_CODE OnAppointmentsLeft()
	{
		// Return HTTP_SUCCESS if there are appointments still left
		return (m_hRes != S_OK) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	HTTP_CODE OnAppointmentID()
	{
		// Respond with the appointment id
		if ( (!m_bTodays && m_appointmentList.m_lTime == m_iCurHour) || m_bTodays)
			m_HttpResponse << m_appointmentList.m_lAppointmentID;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnAppointmentTitle()
	{
		// Respond with the appointment title
		if ( (!m_bTodays && m_appointmentList.m_lTime == m_iCurHour) || m_bTodays)
		{
			m_HttpResponse << m_appointmentList.m_szTitle;
			if (lstrlen(m_appointmentList.m_szLocation) > 0)
				m_HttpResponse << " (" << m_appointmentList.m_szLocation << ")";
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextAppointment()
	{
		// Used in welcome.srf to get the next appointment
		m_hRes = m_appointmentList.MoveNext();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnFailure()
	{
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
		
	HTTP_CODE OnTitleInput()
	{
		// Respond with the appointment title
		m_HttpResponse << m_strTitle;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnLocationInput()
	{
		// Respond with the appointment location
		m_HttpResponse << m_strLocation;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDetailsInput()
	{
		// Respond with the appointment details
		m_HttpResponse << m_strDetails;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTimeSelected(int *pTime)
	{
		ATLASSERT(pTime != NULL);

		// Respond with the selected time if it matches the start time
		if (*pTime == m_lStart)
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	// Replacement method map
	BEGIN_REPLACEMENT_METHOD_MAP(CScheduleHandler)
		REPLACEMENT_METHOD_ENTRY("NextDay", OnNextDay)
		REPLACEMENT_METHOD_ENTRY("NextMonth", OnNextMonth)
		REPLACEMENT_METHOD_ENTRY("NextYear", OnNextYear)
		REPLACEMENT_METHOD_ENTRY("PrevDay", OnPrevDay)
		REPLACEMENT_METHOD_ENTRY("PrevMonth", OnPrevMonth)
		REPLACEMENT_METHOD_ENTRY("PrevYear", OnPrevYear)
		REPLACEMENT_METHOD_ENTRY("SetTodays", OnSetTodays)
		REPLACEMENT_METHOD_ENTRY("RowsLeft", OnRowsLeft)
		REPLACEMENT_METHOD_ENTRY("NextRow", OnNextRow)
		REPLACEMENT_METHOD_ENTRY("CellColor", OnCellColor)
		REPLACEMENT_METHOD_ENTRY("StartTime", OnStartTime)
		REPLACEMENT_METHOD_ENTRY("StartAM", OnStartAM)
		REPLACEMENT_METHOD_ENTRY("EndTime", OnEndTime)
		REPLACEMENT_METHOD_ENTRY("EndAM", OnEndAM)
		REPLACEMENT_METHOD_ENTRY("AppointmentsLeft", OnAppointmentsLeft)
		REPLACEMENT_METHOD_ENTRY("AppointmentID", OnAppointmentID)
		REPLACEMENT_METHOD_ENTRY("AppointmentTitle", OnAppointmentTitle)
		REPLACEMENT_METHOD_ENTRY("NextAppointment", OnNextAppointment)
		REPLACEMENT_METHOD_ENTRY("Date", OnDate)
		REPLACEMENT_METHOD_ENTRY("Failure", OnFailure)
		REPLACEMENT_METHOD_ENTRY("MaxStringLen", OnMaxStringLen)
		REPLACEMENT_METHOD_ENTRY("MaxDetailsLen", OnMaxDetailsLen)
		REPLACEMENT_METHOD_ENTRY("TitleInput", OnTitleInput)
		REPLACEMENT_METHOD_ENTRY("LocationInput", OnLocationInput)
		REPLACEMENT_METHOD_ENTRY("DetailsInput", OnDetailsInput)
		REPLACEMENT_METHOD_ENTRY_EX("TimeSelected", OnTimeSelected, int, DefaultParseInt)
	END_REPLACEMENT_METHOD_MAP()

private:
	bool ValidateFormData(const CHttpRequestParams& FormFields)
	{
		DWORD dwRet;
		// Validate the form data
		if (FormFields.Validate("title", &m_strTitle, 1, DB_MAX_STRLEN) != VALIDATION_S_OK)
			return false;

		// Prepare for HTML
		HTMLPrepareString(m_strTitle);
		if (m_strTitle.GetLength() > DB_MAX_STRLEN)
			return false;
		
		dwRet = FormFields.Validate("location", &m_strLocation, 0, DB_MAX_STRLEN);
		if (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY)
			return false;

		// Prepare for HTML
		HTMLPrepareString(m_strLocation);
		if (m_strLocation.GetLength() > DB_MAX_STRLEN)
			return false;
		
		dwRet = FormFields.Validate("details", &m_strDetails, 0, DB_MAX_DETAILSLEN);
		if (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY)
			return false;

		// Prepare for HTML
		HTMLPrepareString(m_strDetails);
		if (m_strDetails.GetLength() > DB_MAX_DETAILSLEN)
			return false;

		if (FormFields.Validate("start", &m_lStart, START_TIME, END_TIME) != VALIDATION_S_OK)
			return false;

		// Find the appoinment in the database to ensure no duplicates
		CFindAppointment findAppointment;

		sprintf(findAppointment.m_szDate, "%d/%d/%d", m_date.GetMonth(), m_date.GetDay(), m_date.GetYear());
		findAppointment.m_lTime = m_lStart;
		GetUserID(&findAppointment.m_lUserID);
		
		if (findAppointment.OpenRowset(m_dataConnection, NULL) != S_OK)
			return false;

		HRESULT hr = findAppointment.MoveFirst();
		if (hr == DB_S_ENDOFROWSET)
			return true;	// Return true, no duplicate appointment

		// Duplicate found
		return false;
	}

	HTTP_CODE AddNewAppointment()
	{
		long lUserID = 0;
		GetUserID(&lUserID);

		// Add the appointment into the database
		HRESULT hr = ::AddNewAppointment(m_dataConnection,
									m_date.GetMonth(),
									m_date.GetDay(),
									m_date.GetYear(),
									m_lStart,
									lUserID,
									m_strTitle,
									m_strLocation,
									m_strDetails);

		if (hr != S_OK)
			return DatabaseError("CNewAppointment::OpenRowset()", hr);

		// Reset the member variables
		m_strTitle = "";
		m_strLocation = "";
		m_strDetails = "";
		m_lStart = 8;
		return HTTP_SUCCESS;
	}

}; // class CScheduleHandler
