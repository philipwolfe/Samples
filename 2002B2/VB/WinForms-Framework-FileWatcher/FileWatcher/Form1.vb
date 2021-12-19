Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System

Public Class Form1
    
    Inherits System.Windows.Forms.Form
    
    'Dimension FileSystemWatcher Event Handler
    Dim WithEvents Watcher As FileSystemWatcher
    
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents txtFilter As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents chkSize As System.Windows.Forms.CheckBox
    Private WithEvents chkSecurity As System.Windows.Forms.CheckBox
    Private WithEvents chkDateWritten As System.Windows.Forms.CheckBox

    Private WithEvents chkAttributes As System.Windows.Forms.CheckBox
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtFile As System.Windows.Forms.TextBox
    Private WithEvents cmdStop As System.Windows.Forms.Button
    Private WithEvents cmdStart As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.chkDateWritten = New System.Windows.Forms.CheckBox()
        Me.chkAttributes = New System.Windows.Forms.CheckBox()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.chkSecurity = New System.Windows.Forms.CheckBox()
        Me.chkSize = New System.Windows.Forms.CheckBox()
        Me.cmdStop = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        GroupBox1.Location = New System.Drawing.Point(8, 96)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Watch for..."
        GroupBox1.Size = New System.Drawing.Size(328, 104)

        txtFilter.Location = New System.Drawing.Point(64, 64)
        txtFilter.Text = "*.*"
        txtFilter.TabIndex = 6
        txtFilter.Size = New System.Drawing.Size(56, 20)

        Label2.Location = New System.Drawing.Point(8, 72)
        Label2.Text = "File filter:"
        Label2.Size = New System.Drawing.Size(56, 16)
        Label2.TabIndex = 5

        Label1.Location = New System.Drawing.Point(8, 8)
        Label1.Text = "Enter a folder to watch.  You will be notified when any file which matches the filter in that folder is modified."
        Label1.Size = New System.Drawing.Size(328, 32)
        Label1.TabIndex = 3

        cmdStart.Location = New System.Drawing.Point(120, 208)
        cmdStart.Size = New System.Drawing.Size(104, 32)
        cmdStart.TabIndex = 0
        cmdStart.Text = "Start Watching"

        chkDateWritten.Location = New System.Drawing.Point(8, 32)
        chkDateWritten.Text = "The date that the file or folder last had anything written to it."
        chkDateWritten.Size = New System.Drawing.Size(312, 16)
        chkDateWritten.TabIndex = 2

        chkAttributes.Location = New System.Drawing.Point(8, 16)
        chkAttributes.Text = "The attributes of the file or folder"
        chkAttributes.Size = New System.Drawing.Size(280, 16)
        chkAttributes.TabIndex = 0

        txtFile.Location = New System.Drawing.Point(8, 40)
        txtFile.Text = "c:\"
        txtFile.TabIndex = 2
        txtFile.Size = New System.Drawing.Size(328, 20)

        chkSecurity.Location = New System.Drawing.Point(8, 48)
        chkSecurity.Text = "The security settings of the file or folder."
        chkSecurity.Size = New System.Drawing.Size(280, 16)
        chkSecurity.TabIndex = 3

        chkSize.Location = New System.Drawing.Point(8, 64)
        chkSize.Text = "The size of the file or folder."
        chkSize.Size = New System.Drawing.Size(280, 16)
        chkSize.TabIndex = 4

        cmdStop.Location = New System.Drawing.Point(232, 208)
        cmdStop.Size = New System.Drawing.Size(104, 32)
        cmdStop.TabIndex = 1
        cmdStop.Enabled = False
        cmdStop.Text = "Stop Watching"
        Me.Text = "FileWatcher"
        Me.MaximizeBox = False
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(346, 247)

        GroupBox1.Controls.Add(chkSize)
        GroupBox1.Controls.Add(chkSecurity)
        GroupBox1.Controls.Add(chkDateWritten)
        GroupBox1.Controls.Add(chkAttributes)
        Me.Controls.Add(txtFilter)
        Me.Controls.Add(Label2)
        Me.Controls.Add(GroupBox1)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtFile)
        Me.Controls.Add(cmdStop)
        Me.Controls.Add(cmdStart)
    End Sub

#End Region

    Protected Sub cmdStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStart.Click

        Dim CF As NotifyFilters

        'Check to see which checkboxes are checked
        'Add to Changed Filters Object
        If chkAttributes().Checked Then cf = cf Or System.IO.NotifyFilters.Attributes
        If chkDateWritten().Checked Then cf = cf Or System.IO.NotifyFilters.LastWrite
        If chkSecurity().Checked Then cf = cf Or System.IO.NotifyFilters.Security
        If chkSize().Checked Then cf = cf Or System.IO.NotifyFilters.Size

        'If Add Watch returns true then disable all controls on form
        'Except for cmdStop control
        If AddWatch(txtFile().Text, txtFilter().Text, cf) Then
            Dim ctl As Control
            For Each ctl In Form1().Controls
                If (Not ctl Is Nothing) And (Not (ctl.GetType() Is Label1().GetType())) Then
                    If ctl.Equals(cmdStop()) Then
                        ctl.Enabled = True
                    Else
                        ctl.Enabled = False
                    End If
                End If
            Next
        End If

    End Sub

    Protected Sub cmdStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStop.Click

        Dim ctl As Control
        'Enable all controls on form except for cmdStop control
        For Each ctl In Form1.Controls
            If (Not ctl Is Nothing) Then
                If ctl.Equals(cmdStop) Then
                    ctl.Enabled = False
                Else
                    ctl.Enabled = True
                End If
            End If
        Next

    End Sub

    Private Function AddWatch(ByVal sFolder As String, ByVal sFilter As String, _
                              ByVal Filters As NotifyFilters) As Boolean

        'Error Handling
        'Create fsWatcher Object
        'Set Properties on Object Based on the ChangedFilters the User Selected
        If Watcher Is Nothing Then Watcher = New FileSystemWatcher()
        With Watcher
            .Path = sFolder
            .NotifyFilter = Filters
            .Filter = sFilter
            .EnableRaisingEvents = True
        End With
        Return True

    End Function

    Private Sub Watcher_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles Watcher.Changed
        'Sub Implements Event Handler to tell user when files have changed according to their selections
        MessageBox.Show("'" & e.FullPath & "' has been modified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
