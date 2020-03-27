Public Class frmCreateDelete
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lblLogFileToDelete As System.Windows.Forms.Label
    Friend WithEvents lblLogFileToCreate As System.Windows.Forms.Label
    Friend WithEvents txtLogNameToDelete As System.Windows.Forms.TextBox
    Friend WithEvents txtLogNameToCreate As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteLog As System.Windows.Forms.Button
    Friend WithEvents btnCreateLog As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblLogFileToDelete = New System.Windows.Forms.Label()
        Me.lblLogFileToCreate = New System.Windows.Forms.Label()
        Me.txtLogNameToDelete = New System.Windows.Forms.TextBox()
        Me.txtLogNameToCreate = New System.Windows.Forms.TextBox()
        Me.btnDeleteLog = New System.Windows.Forms.Button()
        Me.btnCreateLog = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLogFileToDelete
        '
        Me.lblLogFileToDelete.AccessibleDescription = "Name of log to delete label"
        Me.lblLogFileToDelete.AccessibleName = "Delete Log Label"
        Me.lblLogFileToDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLogFileToDelete.Location = New System.Drawing.Point(240, 32)
        Me.lblLogFileToDelete.Name = "lblLogFileToDelete"
        Me.lblLogFileToDelete.Size = New System.Drawing.Size(168, 23)
        Me.lblLogFileToDelete.TabIndex = 4
        Me.lblLogFileToDelete.Text = "Name of Log to D&elete:"
        '
        'lblLogFileToCreate
        '
        Me.lblLogFileToCreate.AccessibleDescription = "Name of log to create label"
        Me.lblLogFileToCreate.AccessibleName = "Create Log Label"
        Me.lblLogFileToCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLogFileToCreate.Location = New System.Drawing.Point(32, 32)
        Me.lblLogFileToCreate.Name = "lblLogFileToCreate"
        Me.lblLogFileToCreate.Size = New System.Drawing.Size(160, 23)
        Me.lblLogFileToCreate.TabIndex = 1
        Me.lblLogFileToCreate.Text = "Name of Log to C&reate:"
        '
        'txtLogNameToDelete
        '
        Me.txtLogNameToDelete.AccessibleDescription = "Name of log to delete"
        Me.txtLogNameToDelete.AccessibleName = "Delete Log Name"
        Me.txtLogNameToDelete.Location = New System.Drawing.Point(240, 56)
        Me.txtLogNameToDelete.Name = "txtLogNameToDelete"
        Me.txtLogNameToDelete.Size = New System.Drawing.Size(176, 20)
        Me.txtLogNameToDelete.TabIndex = 5
        Me.txtLogNameToDelete.Text = ""
        '
        'txtLogNameToCreate
        '
        Me.txtLogNameToCreate.AccessibleDescription = "Name of Log to Create"
        Me.txtLogNameToCreate.AccessibleName = "Create Log Name"
        Me.txtLogNameToCreate.Location = New System.Drawing.Point(32, 56)
        Me.txtLogNameToCreate.Name = "txtLogNameToCreate"
        Me.txtLogNameToCreate.Size = New System.Drawing.Size(168, 20)
        Me.txtLogNameToCreate.TabIndex = 2
        Me.txtLogNameToCreate.Text = ""
        '
        'btnDeleteLog
        '
        Me.btnDeleteLog.AccessibleDescription = "Click to delete the log"
        Me.btnDeleteLog.AccessibleName = "Delete Log Button"
        Me.btnDeleteLog.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDeleteLog.Location = New System.Drawing.Point(240, 96)
        Me.btnDeleteLog.Name = "btnDeleteLog"
        Me.btnDeleteLog.Size = New System.Drawing.Size(176, 23)
        Me.btnDeleteLog.TabIndex = 6
        Me.btnDeleteLog.Text = "&Delete an Event Log"
        '
        'btnCreateLog
        '
        Me.btnCreateLog.AccessibleDescription = "Click to create the log"
        Me.btnCreateLog.AccessibleName = "Create Log Button"
        Me.btnCreateLog.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCreateLog.Location = New System.Drawing.Point(32, 96)
        Me.btnCreateLog.Name = "btnCreateLog"
        Me.btnCreateLog.Size = New System.Drawing.Size(168, 23)
        Me.btnCreateLog.TabIndex = 3
        Me.btnCreateLog.Text = "&Create an Event Log"
        '
        'frmCreateDelete
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 158)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLogFileToDelete, Me.lblLogFileToCreate, Me.txtLogNameToDelete, Me.txtLogNameToCreate, Me.btnDeleteLog, Me.btnCreateLog})
        Me.Name = "frmCreateDelete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create and Delete a Custom Log"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCreateLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateLog.Click
        Dim ev As New EventLog()
        Try
            'Next check for the existence of the log that the user wants to create.
            If Not ev.Exists(txtLogNameToCreate.Text) Then
                ' If the event source is already registered we want to delete it 
                ' before recreating it on the call to CreateEventSource
                If ev.SourceExists("How-To Use the EventLog") Then
                    ev.DeleteEventSource("How-To Use the EventLog")
                End If
                ev.CreateEventSource("How-To Use the EventLog", txtLogNameToCreate.Text)
            Else
                MessageBox.Show("Log :" & txtLogNameToCreate.Text + " already exists.", _
                    "Log Exists", _
                    MessageBoxButtons.OK, _
                    MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to Create Event Log, the message was: " & ex.Message & " This may be due to a lack of appropriate permissions.", _
                "An Exception was thrown", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        Finally
            'Close the log.
            ev.Close()
        End Try

        'You can also create an event log using the code below.
        'Once you create an event log object that is passed your custom log name the 
        'first time you write an entry to the log the log is created.  One benefit of this
        'approach is that the need for the existence check is not necessary.
        'If the log exists the code will write to the log and if a log by that name 
        'does not exist the log is created automatically prior to the write. 
        'The downside of this approach is that it is not as clear that the log will 
        'will be created if necessary as in the above code.

        'Dim ev2 As New EventLog(txtLogNameToCreate.Text, System.Environment.MachineName, _
        '"How-To Use the EventLog")
        'ev2.WriteEntry("test message")
        'ev2.Close()

    End Sub

    Private Sub cmdDeleteLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLog.Click
        Dim ev As New System.Diagnostics.EventLog()
        Try
            If ev.Exists(txtLogNameToDelete.Text) Then
                'Next call the delete method of the log that the user wants to delete.
                ev.Delete(txtLogNameToDelete.Text)
            Else
                MessageBox.Show("Log " + txtLogNameToDelete.Text + " does not exist, therefore it cannot be deleted.", _
                    "Log Does not Exist", _
                    MessageBoxButtons.OK, _
                    MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to delete event log, the message was: " & ex.Message & " this may be due to a lack of appropriate permissions.", _
                "An Exception was thrown", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        Finally
            ev.Close()
        End Try
    End Sub
End Class
