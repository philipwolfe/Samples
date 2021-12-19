using System;
using System.Diagnostics;

namespace Logging
{
	/// <summary>
	/// Summary description for cEventLogger.
	/// </summary>
	
//	******************************************************
//	* Description: This Class demostrates an Event writer 
//	*              utility class that uses the System.diagnostics 
//	*              library to write to the Event Log.
//	*              It also implements the ILog interface.
//	*              Clients can then use either logger class 
//	*              interchangeably.
//	******************************************************
	public class EventLogger : ILog
	{
		//constants
		const string EVENT_LOG = "Application";
		const string DEFAULT_SOURCE = "Custom Application";
    
		//class-level variables
		string m_strSource = DEFAULT_SOURCE;
    
    
		//********************************************************
		//* Constructors
		//********************************************************
		//default constructor
		public EventLogger()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		//this constructor allows client to specify an event source
		public EventLogger(string strSource)
		{
			m_strSource = strSource;
		}

		//********************************************************
		//* Methods
		//********************************************************
    
		//WriteLog is derived from the ILog interface
		//It must be defined in all classes that implement the ILog Interface
		public void WriteLog(string strInfo, EventLogEntryType eLogType)
		{
			try
			{
				//if it doesn't already exist create a source for the event to be logged to
				if (!EventLog.SourceExists(m_strSource))  
				{
					EventLog.CreateEventSource(m_strSource, EVENT_LOG);
				}
				//Create a new event log object
				EventLog aLog= new EventLog();
				//set the source property
				aLog.Source = m_strSource;
				//log the entry
				aLog.WriteEntry(strInfo, eLogType);
			}
			catch (Exception ex)
			{
				//catch a general exception and pass back to caller
				throw ex;
			}

		}
	}
}
