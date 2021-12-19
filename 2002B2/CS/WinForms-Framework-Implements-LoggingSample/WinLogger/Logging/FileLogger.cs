using System;
using System.Diagnostics;
using System.IO;

namespace Logging
{
	/// <summary>
	/// Summary description for cFileLogger.
	/// </summary>
//	******************************************************
//	* Description: This Class demostrates a file writer 
//	*              utility class that uses the System.IO 
//	*              library to write to the filesystem.
//	*              It also implements the ILog interface.
//	*              Clients can then use either logger class 
//	*              interchangeably.
//	******************************************************
//
	public class FileLogger : ILog
	{
		//Constants
		const string DEFAULT_FILE_NAME= "Debug.txt";
		const string SEVERITY_HEADER  = " SEVERITY: ";
		const string MESSAGE_HEADER = " MESSAGE: ";
    
		//Class level variables
		string  m_strFileName = DEFAULT_FILE_NAME;
		string m_strPath = Environment.CurrentDirectory;

		//********************************************************
		//* Constructors
		//********************************************************
    
		//Default constructor
		public FileLogger()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		//Constructor to specify filename
		public FileLogger(string strFileName)
		{
			m_strFileName = strFileName;
		}

		//Constructor to specify filename and path
		public FileLogger(string strFileName, string strPath)
		{
			m_strFileName = strFileName;
			m_strPath = strPath;
		}

		//********************************************************
		//* Methods
		//********************************************************
    
		//This is the implementation of the ILog.WriteLog method
		public void WriteLog(string strMsg, EventLogEntryType eLogType)
		{
			
			StreamWriter strm;
			//create the StreamWriter class which is part of the System.IO namespace
			strm = new StreamWriter(m_strPath + Path.DirectorySeparatorChar + m_strFileName, true);
			try
			{				
				strm.WriteLine(DateTime.Now + SEVERITY_HEADER + eLogType.ToString() + MESSAGE_HEADER + strMsg);
			}
			catch (Exception ex)
			{
				//catch a general exception and pass back to caller

			throw ex;
			}
			finally
			{
				//regardless of what happens we want to close the stream
				strm.Close();
			}
		}
	}
}
