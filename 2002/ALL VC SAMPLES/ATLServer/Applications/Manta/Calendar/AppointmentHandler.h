// AppointmentHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "AppointmentDB.h"

// class CAppointmentHandler
// This handler is responsible for displaying the appointment data to the user
class CAppointmentHandler
	: public CRequestHandlerT<CAppointmentHandler>,
	  public CMantaWebBase<CAppointmentHandler>
{
private:
	CAppointment m_appointment;		// Appointment data
	
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		const CHttpRequestParams& QueryParams = m_HttpRequest.GetQueryParams();
	
		// Get the appointment id
		LONG lAppID;
		if (QueryParams.Exchange("appid", &lAppID) != VALIDATION_S_OK)
			return HTTP_BAD_REQUEST;
		
		HRESULT hr;
		// If this is a delete operation
		if (QueryParams.Lookup("delete") != NULL)
		{
			// Delete the appointment
			CDeleteAppointment deleteAppointment;
			deleteAppointment.m_lAppointmentID = lAppID;
			GetUserID(&deleteAppointment.m_lUserID);
			hr = deleteAppointment.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CDeleteAppointment::OpenRowset()", hr);
			deleteAppointment.Close();

			COleDateTime date;
			CString redirect;

			// Redirect to the schedule of the same day as the deleted appointment
			date.ParseDateTime(QueryParams.Lookup("date"), VAR_DATEVALUEONLY); 
			redirect.Format("schedule.srf?day=%d&month=%d&year=%d", date.GetDay(), date.GetMonth(), date.GetYear());
			m_HttpResponse.Redirect(redirect);
		}
		else if (QueryParams.Lookup("view") != NULL)	// View operation
		{
			// Open up the appointment
			m_appointment.m_lAppointmentID = lAppID;
			GetUserID(&m_appointment.m_lUserID);

			hr = m_appointment.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CAppointment::OpenRowset()", hr);

			hr = m_appointment.MoveFirst();
			if (hr != S_OK)
				return DatabaseError("CAppointment::MoveFirst()", hr);
		}
		else
			return HTTP_BAD_REQUEST;

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		// Respond with the appointment title
		m_HttpResponse << m_appointment.m_szTitle;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTime()
	{
		// Respond with the appointment time
		m_HttpResponse << ((m_appointment.m_lTime > 12) ? m_appointment.m_lTime - 12 : m_appointment.m_lTime)
					   << ((m_appointment.m_lTime > 12) ? " PM" : " AM")
					   << " to "
					   << (((m_appointment.m_lTime + 1) > 12) ? m_appointment.m_lTime - 11 : m_appointment.m_lTime + 1)
					   << (((m_appointment.m_lTime + 1) > 12) ? " PM" : " AM");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDate()
	{
		// Respond with the appointment time
		COleDateTime date;
		date.ParseDateTime(m_appointment.m_szDate, VAR_DATEVALUEONLY);
		m_HttpResponse << date.Format("%A, %B %d, %Y");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnLocation()
	{
		// Respond with the location if one is set
		if (m_appointment.m_szLocation[0] == '\0')
			m_HttpResponse << "&nbsp;";
		else
			m_HttpResponse << m_appointment.m_szLocation;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDetails()
	{
		// Respond with the details of the appointment
		m_HttpResponse << m_appointment.m_szDetails;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnID()
	{
		// Respond with the appointment id
		m_HttpResponse << m_appointment.m_lAppointmentID;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShortDate()
	{
		// Respond with the short date (i.e. MM/DD/YYYY)
		m_HttpResponse << m_appointment.m_szDate;
		return HTTP_SUCCESS;
	}

	// Replacement method map
	BEGIN_REPLACEMENT_METHOD_MAP(CAppointmentHandler)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("Time", OnTime)
		REPLACEMENT_METHOD_ENTRY("Date", OnDate)
		REPLACEMENT_METHOD_ENTRY("Location", OnLocation)
		REPLACEMENT_METHOD_ENTRY("Details", OnDetails)
		REPLACEMENT_METHOD_ENTRY("ID", OnID)
		REPLACEMENT_METHOD_ENTRY("ShortDate", OnShortDate)
	END_REPLACEMENT_METHOD_MAP()


}; // class CAppointmentHandler
