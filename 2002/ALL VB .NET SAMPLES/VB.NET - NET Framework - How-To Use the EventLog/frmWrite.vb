Imports System.Security

Public Class frmWrite
    Inherits System.Windows.Forms.Form
    Private entryType As System.Diagnostics.EventLogEntryType = EventLogEntryType.Information

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
    Friend WithEvents lblEventID As System.Windows.Forms.Label
    Friend WithEvents txtEventID As System.Windows.Forms.TextBox
    Friend WithEvents btnWriteEntry As System.Windows.Forms.Button
    Friend WithEvents groEventEntry As System.Windows.Forms.GroupBox
    Friend WithEvents rdoError As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWarning As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInfo As System.Windows.Forms.RadioButton
    Friend WithEvents txtEntry As System.Windows.Forms.TextBox
    Friend WithEvents lblEntryText As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblEventID = New System.Windows.Forms.Label()
        Me.txtEventID = New System.Windows.Forms.TextBox()
        Me.btnWriteEntry = New System.Windows.Forms.Button()
        Me.groEventEntry = New System.Windows.Forms.GroupBox()
        Me.rdoError = New System.Windows.Forms.RadioButton()
        Me.rdoWarning = New System.Windows.Forms.RadioButton()
        Me.rdoInfo = New System.Windows.Forms.RadioButton()
        Me.txtEntry = New System.Windows.Forms.TextBox()
        Me.lblEntryText = New System.Windows.Forms.Label()
        Me.groEventEntry.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEventID
        '
        Me.lblEventID.AccessibleDescription = "Label for Event ID"
        Me.lblEventID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEventID.Location = New System.Drawing.Point(16, 80)
        Me.lblEventID.Name = "lblEventID"
        Me.lblEventID.Size = New System.Drawing.Size(176, 16)
        Me.lblEventID.TabIndex = 3
        Me.lblEventID.Text = "E&vent ID:"
        '
        'txtEventID
        '
        Me.txtEventID.AccessibleDescription = "Type the event ID"
        Me.txtEventID.AccessibleName = "Event ID"
        Me.txtEventID.Location = New System.Drawing.Point(16, 96)
        Me.txtEventID.Name = "txtEventID"
        Me.txtEventID.Size = New System.Drawing.Size(176, 20)
        Me.txtEventID.TabIndex = 4
        Me.txtEventID.Text = ""
        '
        'btnWriteEntry
        '
        Me.btnWriteEntry.AccessibleDescription = "Click to write the entery to the application event log"
        Me.btnWriteEntry.AccessibleName = "Write Button"
        Me.btnWriteEntry.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnWriteEntry.Location = New System.Drawing.Point(168, 152)
        Me.btnWriteEntry.Name = "btnWriteEntry"
        Me.btnWriteEntry.Size = New System.Drawing.Size(232, 23)
        Me.btnWriteEntry.TabIndex = 6
        Me.btnWriteEntry.Text = "&Write an Entry to the Application Event Log"
        '
        'groEventEntry
        '
        Me.groEventEntry.AccessibleDescription = "Event Log Entry type option box"
        Me.groEventEntry.AccessibleName = "Log type Option Box"
        Me.groEventEntry.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoError, Me.rdoWarning, Me.rdoInfo})
        Me.groEventEntry.Location = New System.Drawing.Point(224, 16)
        Me.groEventEntry.Name = "groEventEntry"
        Me.groEventEntry.Size = New System.Drawing.Size(176, 120)
        Me.groEventEntry.TabIndex = 5
        Me.groEventEntry.TabStop = False
        Me.groEventEntry.Text = "Eve&nt Log Entry Type:"
        '
        'rdoError
        '
        Me.rdoError.AccessibleDescription = "Error event option"
        Me.rdoError.AccessibleName = "Error Event Option"
        Me.rdoError.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoError.Location = New System.Drawing.Point(16, 88)
        Me.rdoError.Name = "rdoError"
        Me.rdoError.Size = New System.Drawing.Size(152, 24)
        Me.rdoError.TabIndex = 2
        Me.rdoError.Text = "E&rror"
        '
        'rdoWarning
        '
        Me.rdoWarning.AccessibleDescription = "Warning event option"
        Me.rdoWarning.AccessibleName = "Warning Event Option"
        Me.rdoWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoWarning.Location = New System.Drawing.Point(16, 56)
        Me.rdoWarning.Name = "rdoWarning"
        Me.rdoWarning.Size = New System.Drawing.Size(152, 24)
        Me.rdoWarning.TabIndex = 1
        Me.rdoWarning.Text = "W&arning"
        '
        'rdoInfo
        '
        Me.rdoInfo.AccessibleDescription = "Informational event option"
        Me.rdoInfo.AccessibleName = "Informational Event Option"
        Me.rdoInfo.Checked = True
        Me.rdoInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoInfo.Location = New System.Drawing.Point(16, 24)
        Me.rdoInfo.Name = "rdoInfo"
        Me.rdoInfo.Size = New System.Drawing.Size(152, 24)
        Me.rdoInfo.TabIndex = 0
        Me.rdoInfo.TabStop = True
        Me.rdoInfo.Text = "&Informational"
        '
        'txtEntry
        '
        Me.txtEntry.AccessibleDescription = "Type the Entry Text"
        Me.txtEntry.AccessibleName = "Entry Text"
        Me.txtEntry.Location = New System.Drawing.Point(16, 32)
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.Size = New System.Drawing.Size(176, 20)
        Me.txtEntry.TabIndex = 2
        Me.txtEntry.Text = ""
        '
        'lblEntryText
        '
        Me.lblEntryText.AccessibleDescription = "Label for Entry Text"
        Me.lblEntryText.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEntryText.Location = New System.Drawing.Point(16, 16)
        Me.lblEntryText.Name = "lblEntryText"
        Me.lblEntryText.Size = New System.Drawing.Size(176, 23)
        Me.lblEntryText.TabIndex = 1
        Me.lblEntryText.Text = "&Entry Text:"
        '
        'frmWrite
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 198)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEventID, Me.txtEventID, Me.btnWriteEntry, Me.groEventEntry, Me.txtEntry, Me.lblEntryText})
        Me.Name = "frmWrite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Write to the Event Log"
        Me.groEventEntry.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdWriteEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnWriteEntry.Click

        Try
            If IsNumeric(txtEventID.Text) Then

                ' When writing to an event log you need to pass the machine name where 
                ' the log resides.  Here the MachineName Property of the Environment class 
                ' is used to determine the name of the local machine.  Assuming you have 
                ' the appropriate permissions it is also easy to write to event logs on 
                ' other machines.

                ' The first entry is the name of the log you want to write to.  The second 
                ' parameter is the machine name.  In this case it is the local machine name.
                ' The third parameter is the source of the event.  Commonly this is set equal
                ' to the name of the application that is writing the event.

                Dim ev As New EventLog("Application", System.Environment.MachineName, _
                "How-To Use the Event Log")

                ' The first argument to WriteEntry is the text of the message.  The second 
                ' argument is the type of entry you want to create (Warning, Information, etc.)
                ' The third is the eventID of the event.  The user could use this to look up 
                ' further information in a help file.

                ev.WriteEntry(txtEntry.Text, entryType, CInt(txtEventID.Text))

                ev.Close()

                MessageBox.Show("Entry written to the event log", _
                    "frmWrite", _
                    MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)
            Else
                ' The EventID was not numeric
                MessageBox.Show("Value entered into EventID textbox must be numeric", _
                    "Event ID Entry Error", _
                    MessageBoxButtons.OK, _
                    MessageBoxIcon.Exclamation)
            End If

        Catch secEx As SecurityException
            MessageBox.Show("Error writing to the event log: this may be due to a lack of appropriate permissions." & vbCrLf & secEx.Message, _
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

    Private Sub rdo_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles rdoError.Click, rdoInfo.Click, rdoWarning.Click

        ' This event procedure handles the click event for all the radio buttons in 
        ' the group box on the form.  In the event handler, we know which radio 
        ' button was clicked because it is passed in as the "sender" argument.
        ' This comes in as a generic object, however, and must be cast back to a
        ' radio button so that you can access the name property.

        Dim rdo As RadioButton = CType(sender, RadioButton)
        Select Case rdo.Name
            Case "rdoError"
                entryType = EventLogEntryType.Error
            Case "rdoWarning"
                entryType = EventLogEntryType.Warning
            Case "rdoInfo"
                entryType = EventLogEntryType.Information
            Case Else
                'If a radio button is not clicked an assertion is raised.
                Debug.Assert(False, "User selected an event log type that is not currently handled")
        End Select

    End Sub

End Class
