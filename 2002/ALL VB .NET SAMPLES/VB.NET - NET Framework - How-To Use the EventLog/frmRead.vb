Imports System.Security

Public Class frmRead
    Inherits System.Windows.Forms.Form

    ' Stores the name of the log that the user wants to view.
    Private logType As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lstEntryType As System.Windows.Forms.ListBox
    Friend WithEvents btnViewLogEntries As System.Windows.Forms.Button
    Friend WithEvents lblEntryType As System.Windows.Forms.Label
    Friend WithEvents rchEventLogOutput As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstEntryType = New System.Windows.Forms.ListBox()
        Me.btnViewLogEntries = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.rchEventLogOutput = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lstEntryType
        '
        Me.lstEntryType.AccessibleDescription = "List of logs"
        Me.lstEntryType.AccessibleName = "Log List"
        Me.lstEntryType.Location = New System.Drawing.Point(16, 40)
        Me.lstEntryType.Name = "lstEntryType"
        Me.lstEntryType.Size = New System.Drawing.Size(184, 43)
        Me.lstEntryType.TabIndex = 2
        '
        'btnViewLogEntries
        '
        Me.btnViewLogEntries.AccessibleDescription = "View Button"
        Me.btnViewLogEntries.AccessibleName = "View Button"
        Me.btnViewLogEntries.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnViewLogEntries.Location = New System.Drawing.Point(16, 96)
        Me.btnViewLogEntries.Name = "btnViewLogEntries"
        Me.btnViewLogEntries.Size = New System.Drawing.Size(184, 23)
        Me.btnViewLogEntries.TabIndex = 3
        Me.btnViewLogEntries.Text = "&View Log Entries"
        '
        'lblEntryType
        '
        Me.lblEntryType.AccessibleDescription = "Choose a log label"
        Me.lblEntryType.AccessibleName = "log label"
        Me.lblEntryType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEntryType.Location = New System.Drawing.Point(16, 16)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(184, 23)
        Me.lblEntryType.TabIndex = 1
        Me.lblEntryType.Text = "&Choose a Log:"
        '
        'rchEventLogOutput
        '
        Me.rchEventLogOutput.AccessibleDescription = "Contents of log"
        Me.rchEventLogOutput.AccessibleName = "Log Contents"
        Me.rchEventLogOutput.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.rchEventLogOutput.Location = New System.Drawing.Point(216, 40)
        Me.rchEventLogOutput.Name = "rchEventLogOutput"
        Me.rchEventLogOutput.ReadOnly = True
        Me.rchEventLogOutput.Size = New System.Drawing.Size(488, 392)
        Me.rchEventLogOutput.TabIndex = 4
        Me.rchEventLogOutput.Text = ""
        '
        'frmRead
        '
        Me.AccessibleDescription = "Form for reading the event log"
        Me.AccessibleName = "Form Read"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 446)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstEntryType, Me.btnViewLogEntries, Me.lblEntryType, Me.rchEventLogOutput})
        Me.Name = "frmRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Read from the Event Log"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdViewLogEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewLogEntries.Click
        Try
            Const ENTRIES_TO_DISPLAY As Integer = 10

            ' In this case the EventLog constructor is passed a string variable for the log name.
            ' This is because the user of the application can choose which log they wish to view 
            ' from the listbox on the form.
            Dim ev As New EventLog(logType, System.Environment.MachineName, _
                "How-To Use the EventLog")
            Dim entry As EventLogEntry

            rchEventLogOutput.Text = "Event log entries (maximum of 10), newest to oldest" & vbCrLf & vbCrLf

            Dim LastLogToShow As Integer = ev.Entries.Count - ENTRIES_TO_DISPLAY
            If LastLogToShow < 0 Then
                LastLogToShow = 0
            End If

            ' Display the last 10 records in the chosen log 
            Dim i As Integer
            For i = ev.Entries.Count - 1 To LastLogToShow Step -1
                Dim CurrentEntry As EventLogEntry = ev.Entries(i)
                rchEventLogOutput.Text &= "Event ID : " & _
                    CurrentEntry.EventID & vbCrLf
                rchEventLogOutput.Text &= "Entry Type : " & _
                    CurrentEntry.EntryType.ToString() & vbCrLf
                rchEventLogOutput.Text &= "Message : " & _
                    CurrentEntry.Message & vbCrLf & vbCrLf
            Next

            ' You could also simply loop through all of the entries in the log using
            ' the entries collection and the code below.
            ' For Each entry In ev.Entries

            ' Next
        Catch secEx As SecurityException
            MessageBox.Show("Error reading an event log: this may be due to a lack of appropriate permissions." & vbCrLf & secEx.Message, _
                "Lack of Permissions", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error accessing logs on the local machine." & vbCrLf & ex.Message, _
               "Error accessing logs.", _
               MessageBoxButtons.OK, _
               MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lstEntryType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles lstEntryType.SelectedIndexChanged
        ' Store the log that the user selected in the ListBox
        logType = CType(lstEntryType.Items(lstEntryType.SelectedIndex()), String)
    End Sub

    Private Sub frmRead_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim CurrentLog As EventLog
            For Each CurrentLog In EventLog.GetEventLogs()
                lstEntryType.Items.Add(CurrentLog.LogDisplayName)
            Next
            lstEntryType.SelectedIndex = 0
        Catch secEx As SecurityException
            MessageBox.Show("Error reading an event log: this may be due to a lack of appropriate permissions." & vbCrLf & secEx.Message, _
                "Lack of Permissions", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error accessing logs on the local machine." & vbCrLf & ex.Message, _
               "Error accessing logs.", _
               MessageBoxButtons.OK, _
               MessageBoxIcon.Error)
        End Try
    End Sub
End Class

