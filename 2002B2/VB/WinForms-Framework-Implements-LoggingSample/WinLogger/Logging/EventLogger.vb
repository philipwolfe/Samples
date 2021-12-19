Imports System.Diagnostics
Imports System

'******************************************************
'* Description: This Class demostrates an Event writer 
'*              utility class that uses the System.diagnostics 
'*              library to write to the Event Log.
'*              It also implements the ILog interface.
'*              Clients can then use either logger class 
'*              interchangeably.
'******************************************************
Public Class EventLogger
    'We use implements statement to implement the iLog interface.
    'Note the use of the fully qualified interface name <namespace>.<interfacename>
    Implements Logging.ILog

    'constants
    Const EVENT_LOG As String = "Application"
    Const DEFAULT_SOURCE As String = "Custom Application"

    'class-level variables
    Dim mSource As String = DEFAULT_SOURCE


    '********************************************************
    '* Constructors
    '********************************************************
    'default constructor
    Public Sub New()

    End Sub

    'this constructor allows client to specify an event source
    Public Sub New(ByVal Source As String)
        mSource = Source
    End Sub

    '********************************************************
    '* Methods
    '********************************************************
    'WriteLog is derived from the ILog interface
    'It must be defined in all classes that implement the ILog Interface
    Public Sub WriteLog(ByVal Info As String, ByVal LogType As EventLogEntryType) _
        Implements Logging.ILog.WriteLog

        Try
            'if it doesn't already exist create a source for the event to be logged to
            If Not (EventLog.SourceExists(mSource)) Then
                EventLog.CreateEventSource(mSource, EVENT_LOG)
            End If
            'Create a new event log object
            Dim Log As EventLog = New EventLog()
            'set the source property
            Log.Source = mSource
            'log the entry
            Log.WriteEntry(Info, LogType)
        Catch ex As Exception
            'catch a general exception and pass back to caller
            Throw ex
        End Try
    End Sub


End Class
