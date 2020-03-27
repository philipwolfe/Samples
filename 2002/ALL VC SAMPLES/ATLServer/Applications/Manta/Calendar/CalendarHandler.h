// CalendarHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "CalendarDB.h"

// class CCalendarHandler
// This handler is responsible for displaying the user's calendar (with schedule details)
class CCalendarHandler
	: public CRequestHandlerT<CCalendarHandler>,
	  public CMantaWebBase<CCalendarHandler>
{
private:
	COleDateTime			m_cellDate;		// Cell date
	COleDateTime			m_today;		// Today's date
	int						m_iCurMonth;	// Current month (month currently viewed)
	int						m_iCurYear;		// Current year (year currently viewed)
	CCalendarAppointments	m_appointments;	// Schedule DB object
	
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		// Get the current date/time
		m_today = COleDateTime::GetCurrentTime();
		m_today.SetDate(m_today.GetYear(), m_today.GetMonth(), m_today.GetDay());

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		int iYear, iMonth;
			
		// Get the year specified
		if (FormFields.Exchange("year", &iYear) != VALIDATION_S_OK)
			iYear = m_today.GetYear();
		
		// Get the month specified
		if (FormFields.Exchange("month", &iMonth) != VALIDATION_S_OK)
			iMonth = m_today.GetMonth();

		// Set the date to the one specified (set to first day of month)
		m_cellDate.SetDate(iYear, iMonth, 1);

		m_iCurMonth = m_cellDate.GetMonth();
		m_iCurYear = m_cellDate.GetYear();
		
		// Offset the date to fit in the calendar
		if (m_cellDate.GetDayOfWeek() < 3)
			m_cellDate -= COleDateTimeSpan((m_cellDate.GetDayOfWeek() - 1) + 7, 0, 0, 0);
		else
			m_cellDate -= COleDateTimeSpan((m_cellDate.GetDayOfWeek() - 1), 0, 0, 0);

		// Add 42 (number of cells) to get the last cell date
		COleDateTime lastCell = m_cellDate + COleDateTimeSpan(42, 0, 0, 0);
		CStringW strSQL;
		// Create the SQL command (Note: the #'s around the date mark a date literal in Access)
		strSQL.Format(L"SELECT [AppointmentID], [Title], [Date] FROM AppointmentTable WHERE [UserID]=? AND "
			          L"[Date] BETWEEN #%d/%d/%d# AND #%d/%d/%d# ORDER BY [Date], [Time]", m_cellDate.GetMonth(), m_cellDate.GetDay(),
					  m_cellDate.GetYear(), lastCell.GetMonth(), lastCell.GetDay(), lastCell.GetYear());
		GetUserID(&m_appointments.m_lUserID);
		// Open the rowset for the given dates
		HRESULT hr = m_appointments.OpenRowset(m_dataConnection, strSQL);
		if (hr != S_OK)
			return DatabaseError("CCalendarAppointments::OpenRowset()", hr);

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextCell()
	{
		// Increment the cell date
		m_cellDate += COleDateTimeSpan(1, 0, 0, 0);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDay()
	{
		// Respond with the day for the current cell
		m_HttpResponse << m_cellDate.GetDay();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnMonth()
	{
		// Respond with the month for the current cell
		m_HttpResponse << m_cellDate.GetMonth();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnYear()
	{
		// Respond with the year for the current cell
		m_HttpResponse << m_cellDate.GetYear();
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnCellColor()
	{
		// Respond with the color for the current cell
		// blueish - today, white - in current month, yellowish - prev or next month
		
		if (m_cellDate == m_today)
			m_HttpResponse << "#99CCFF";
		else if (m_cellDate.GetMonth() == m_iCurMonth)
			m_HttpResponse << "#FFFFFF";
		else
			m_HttpResponse << "#FFFFCC";
		return HTTP_SUCCESS;
	}	

	HTTP_CODE OnSelectedMonth(int* pMonth)
	{
		ATLASSERT(pMonth != NULL);

		// Output selected if this is the selected month
		if (*pMonth == m_iCurMonth)
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnSelectedYear(int* pYear)
	{
		ATLASSERT(pYear != NULL);

		// Output selected if this is the selected year
		if (*pYear == m_iCurYear)
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDate()
	{
		// Respond with the date in long format
		COleDateTime date = COleDateTime::GetCurrentTime();
		m_HttpResponse << date.Format("%A, %B %d, %Y");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnCellData()
	{
		HRESULT hr = S_OK;
		int i=0;

		while ( (COleDateTime(m_appointments.m_Date) < m_cellDate) && (hr == S_OK) )
			hr = m_appointments.MoveNext();
		
		if (COleDateTime(m_appointments.m_Date) == m_cellDate)
		{
			// Output at most 3 short previews
			for (i = 0; i < 3 && hr == S_OK && COleDateTime(m_appointments.m_Date) == m_cellDate; i++)
			{
				// Cut the string off with a trailing "..." if too long
				m_appointments.m_szTitle[14] = '.';
				m_appointments.m_szTitle[15] = '.';
				m_appointments.m_szTitle[16] = '.';
				m_appointments.m_szTitle[17] = '\0';
				// Respond with the link to the appointment
				m_HttpResponse << "<a href=\"appointment.srf?view=1&appid=" << m_appointments.m_lAppointmentID 
							   << "\">" << m_appointments.m_szTitle << "</a>";
				if (i != 2)
					m_HttpResponse << "<br>";
				hr = m_appointments.MoveNext();
			}
		}
		// If there are more appointments, link to the schedule for that day
		if (i == 3 && hr == S_OK && COleDateTime(m_appointments.m_Date) == m_cellDate)
		{
			m_HttpResponse << "<br><a href=\"schedule.srf?day=" << m_cellDate.GetDay()
				           << "&month=" << m_cellDate.GetMonth()
						   << "&year=" << m_cellDate.GetYear() << "\">More...</a>";
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnViewMonth()
	{
		// Output the month
		COleDateTime date;
		date.SetDate(2000, m_iCurMonth, 1);
		m_HttpResponse << date.Format("%B");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnViewYear()
	{
		// Output the year
		m_HttpResponse << m_iCurYear;
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CCalendarHandler)
		REPLACEMENT_METHOD_ENTRY("NextCell", OnNextCell)
		REPLACEMENT_METHOD_ENTRY("Day", OnDay)
		REPLACEMENT_METHOD_ENTRY("Month", OnMonth)
		REPLACEMENT_METHOD_ENTRY("Year", OnYear)
		REPLACEMENT_METHOD_ENTRY("CellColor", OnCellColor)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedMonth", OnSelectedMonth, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY_EX("SelectedYear", OnSelectedYear, int, DefaultParseInt)
		REPLACEMENT_METHOD_ENTRY("Date", OnDate)
		REPLACEMENT_METHOD_ENTRY("CellData", OnCellData)
		REPLACEMENT_METHOD_ENTRY("ViewMonth", OnViewMonth)
		REPLACEMENT_METHOD_ENTRY("ViewYear", OnViewYear)
	END_REPLACEMENT_METHOD_MAP()

}; // class CCalendarHandler
