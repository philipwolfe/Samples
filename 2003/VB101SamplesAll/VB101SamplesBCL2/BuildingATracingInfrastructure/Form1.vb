Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

' System.Diagnostics contains the Trace and Debug classes.
Imports System.Diagnostics

Partial Public Class Form1
    Inherits Form

#Region " Declarations "

    ' Trace file location.
    Private traceFile As String = Path.GetFullPath("..\..\TraceData\TraceLog.txt")

#End Region

#Region " Constructor "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

#End Region

#Region " Event Procedures "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        serverNamecomboBox.SelectedIndex = 0
    End Sub

    Private Sub serverNamecomboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        databaseButton.Enabled = (serverNamecomboBox.Text.Trim.Length > 0)
    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

#End Region

#Region " Database Procedures "

    Private Sub databaseButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use server name to connect.
        ConnectToDatabase(serverNamecomboBox.Text)
    End Sub

    Private Sub ConnectToDatabase(ByVal serverName As String)
        Try
            ' Try to access a database server. The server may be inaccessible because
            ' the name was changed, or the server is down.
            '
            ' In this demo, access to the "AvailableServer" succeeds, but access to
            ' "UnavailableServer" does not.
            '
            ' If you have SQL Server installed, you can try uncommenting the
            ' lines below for a true test.
            '
            'SqlConnection cn = new SqlConnection();
            'cn.ConnectionString =
            '    "Data Source=" + serverName + ";" +
            '    "Integrated Security=true;" +
            '    "Initial Catalog=Northwind";
            'cn.Open();
            ' Throw an exception if the choice is "UnavailableServer"
            If (serverName = "UnavailableServer") Then
                Throw New DataException("Could not connect to the database")
            End If
            ShowInfoMessage("Database access succeeded.")
        Catch ex As Exception
            ' Instantiate a boolean switch, and process trace statements only
            ' if the main Application-Level switch in web.config is on.
            Dim appSwitch As BooleanSwitch = New BooleanSwitch("ApplicationTracingSwitch", "Application Trace setting")
            If appSwitch.Enabled Then
                ' Create an EventLog TraceListener and add it to the
                ' Trace.Listeners collection.
                Dim eltl As EventLogTraceListener = New EventLogTraceListener("TracingInfrastructureSample")
                Trace.Listeners.Add(eltl)
                ' Initialize a TraceSwitch, referencing the switch configured
                ' in the App.config file. The application will read that switch's
                ' settings and act accordingly.
                '
                ' You can take any action you think is necessary for each trace level. It's
                ' entirely in your hands as to how much data to emit to the trace listeners.
                Dim dataSwitch As TraceSwitch = New TraceSwitch("DataAccessSwitch", "Data access tracing")
                Select Case (dataSwitch.Level)
                    Case TraceLevel.Off
                    Case TraceLevel.Error, TraceLevel.Warning
                        ' The message below will be written to all Listeners
                        ' currently in the Trace.Listeners collection. Note that
                        ' Trace has a Write method which does not include a new
                        ' line at the end, WriteIf and WriteLineIf methods that
                        ' write only if a condition is true, an Assert method that
                        ' writes if a condition is false, and a Fail method that
                        ' lets you write both an error message and a more detailed
                        ' message.
                        '
                        Trace.WriteLine(("Data Access Error: " + ex.Message))
                    Case TraceLevel.Info
                        Trace.WriteLine(("Data Access Error: " + ex.StackTrace))
                    Case TraceLevel.Verbose
                        Trace.WriteLine(("Data Access Error: " + ex.ToString))
                End Select
                ' If you don't want other trace messages written to the Event Log,
                ' remove this listener from the Listeners collection.
                Trace.Listeners.Remove(eltl)
            End If
            ' Now that the tracing has been recorded, handle the error
            ' appropriately with a message box to the user, or however
            ' you choose.
            ShowErrorMessage("Problem accessing database.")
        End Try
    End Sub

#End Region

#Region " Long Process Procedures "

    Private Sub longProcessButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get execution time for long running process.
        Dim executionTime As Integer = GetNumberFromTextBox(longProcessDelayTextBox.Text)
        If (executionTime < 1) Then
            Return
        End If
        ' Execute the long process.
        Me.Cursor = Cursors.WaitCursor
        RunLongProcess(executionTime)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RunLongProcess(ByVal executionTime As Integer)
        ' Simulate running a long process.
        ' Delay for as many seconds as indicated.
        Thread.Sleep((executionTime * 1000))
        If (executionTime < 4) Then
            ShowInfoMessage("Process completed.")
        Else
            ShowErrorMessage("Process timed out.")
            ' Instantiate a boolean switch.
            Dim appSwitch As BooleanSwitch = New BooleanSwitch("ApplicationTracingSwitch", "Application Trace setting")
            ' Process trace statements only if the main Application-Level switch is on.
            If appSwitch.Enabled Then
                ' Add a Trace Listener that's directed to a file.
                ' When a trace listener is added, Trace message are written to it
                ' as well as to all the other listeners in the Listeners collection.
                Dim traceWriter As StreamWriter = New StreamWriter(traceFile, True)
                Dim twtl As TextWriterTraceListener = New TextWriterTraceListener(traceWriter)
                Trace.Listeners.Add(twtl)
                ' This trace message will be written both to the output window
                ' (if you're debugging) and to the text file.
                Trace.WriteLine("Process Error", ("The process has timed out. " + "Please investigate possible causes for process delay."))
                ' You can write trace information to a single listener by using
                ' one of its Write methods. For example, when writing to a text
                ' file, you may want to record the date and time of the error.
                '
                ' This would not be necessary with the Event Log, for example,
                ' since it already records such information.
                '
                ' The message below is written only to the text file.
                twtl.WriteLine(DateTime.Now)
                ' Flush the output buffer, forcing any remaining data to be written.
                Trace.Flush()
                ' When a listener is no longer needed, you can remove it from
                ' the collection. Remember to close the listener first so it will 
                ' release any non-memory resources, such as file handles.
                twtl.Close()
                Trace.Listeners.Remove(twtl)
            End If
        End If
    End Sub

#End Region

#Region " Web Service Procedures "

    Private Sub webServiceButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get delay time for simulating slow web server response.
        Dim delayTime As Integer = GetNumberFromTextBox(webServiceDelayTextBox.Text)
        If (delayTime < 1) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        AccessWebService(delayTime)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AccessWebService(ByVal delayLength As Integer)
        Dim dws As WebServiceSimulator = New WebServiceSimulator
        Dim employees As String = dws.GetEmployeeNames((delayLength * 1000))
        If (employees <> "Error") Then
            ShowInfoMessage(String.Format("Employees successfully retrieved.{0}{0}{1}", Environment.NewLine, employees))
        Else
            ' Check app.config to see if the switch is enabled.
            Dim wsSwitch As BooleanSwitch = New BooleanSwitch("WebServiceSwitch", "Web service access")
            If wsSwitch.Enabled Then
                ' Create an EventLog TraceListener, and set a custom Event Log
                ' source for it.
                Dim eltl As EventLogTraceListener = New EventLogTraceListener("TracingInfrastructureSample")
                Trace.Listeners.Add(eltl)
                Trace.WriteLine("Problem accessing web service")
                ' Remove this listener so it won't be used for other
                ' trace messages.
                Trace.Listeners.Remove(eltl)
            End If
            ' If you have a simple, one-line message to write you can use the
            ' WriteLineIf method, like this:
            '
            ' Trace.WriteLineIf(wsSwitch.Enabled, "Problem accessing web service");
            '
            ' In this case, the second argument, "Problem..." is a simple
            ' string, but it could easily have been an expression. WriteLineIf
            ' always evaluates both arguments even if the first is false, so your
            ' code would have to ensure that the expression is valid and
            ' resolvable.
            '
            ' The bottom line: You'll get better performance with a simple "if"
            ' statement. It also lets you handle a situation like the one above,
            ' where multiple trace statements depend on the "if" condition.
            ShowErrorMessage("Problem accessing web service")
        End If
    End Sub

#End Region

#Region " Utility Functions "

    Private Function GetNumberFromTextBox(ByVal timeString As String) As Integer
        Dim delayTime As Integer = 0
        Try
            delayTime = Convert.ToInt32(timeString)
            If (delayTime < 1) Then
                ShowErrorMessage("Positive numbers only.")
            End If
            Return delayTime
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            Return 0
        End Try
    End Function

    Private Sub ShowErrorMessage(ByVal msg As String)
        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowInfoMessage(ByVal msg As String)
        MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

End Class

