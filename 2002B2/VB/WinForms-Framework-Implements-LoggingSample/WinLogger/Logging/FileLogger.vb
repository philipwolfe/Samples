Imports System.Diagnostics
Imports System.IO
Imports System
'******************************************************
'* Description: This Class demostrates a file writer 
'*              utility class that uses the System.IO 
'*              library to write to the filesystem.
'*              It also implements the ILog interface.
'*              Clients can then use either logger class 
'*              interchangeably.
'******************************************************
Public Class FileLogger
    'We use implements statement to implement the iLog interface.
    'Note the use of the fully qualified interface name <namespace>.<interfacename>
    Implements Logging.ILog

    'Constants
    Const DEFAULT_FILE_NAME As String = "Debug.txt"
    Const SEVERITY_HEADER As String = " SEVERITY: "
    Const MESSAGE_HEADER As String = " MESSAGE: "

    'Class level variables
    Dim mFileName As String = DEFAULT_FILE_NAME
    Dim mPath As String = Environment.CurrentDirectory


    '********************************************************
    '* Constructors
    '********************************************************

    'Default constructor
    Public Sub New()

    End Sub

    'Constructor to specify filename
    Public Sub New(ByVal FileName As String)

        mFileName = FileName

    End Sub

    'Constructor to specify filename and path
    Public Sub New(ByVal FileName As String, ByVal Path As String)

        mFileName = FileName
        mPath = Path
    End Sub

    '********************************************************
    '* Methods
    '********************************************************

    'This is the implementation of the ILog.WriteLog method
    Public Sub WriteLog(ByVal OutStream As String, ByVal LogType As EventLogEntryType) _
        Implements Logging.ILog.WriteLog

        Dim OutputStream As StreamWriter
        Try
            'create the StreamWriter class which is part of the System.IO namespace
            OutputStream = New StreamWriter(mPath + Path.DirectorySeparatorChar + mFileName, True)
            OutputStream.WriteLine(DateTime.Now & SEVERITY_HEADER & LogType.ToString() & MESSAGE_HEADER & OutStream)
        Catch ex As Exception
            'catch a general exception and pass back to caller
            Throw ex
        Finally
            'regardless of what happens we want to close the stream
            OutputStream.Close()
        End Try
    End Sub
End Class
