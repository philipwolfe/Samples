Imports System.Diagnostics
'******************************************************
'* Description: This is an interface which
'*              has one abstract method - WriteLog.
'*              Components that support this interface 
'*              will provide the implementation of this method.
'******************************************************
    Interface ILog
        Sub WriteLog(ByVal strMsg As String, ByVal eLogType As EventLogEntryType)
    End Interface

