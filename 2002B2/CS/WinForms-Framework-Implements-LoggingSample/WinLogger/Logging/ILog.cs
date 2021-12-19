using System.Diagnostics;

//******************************************************
//* Description: This is an interface which
//*              has one abstract method - WriteLog.
//*              Components that support this interface 
//*              will provide the implementation of this method.
//******************************************************
public interface ILog
{
	void WriteLog(string strMsg, System.Diagnostics.EventLogEntryType eLogType);
}

