'Copyright (C) 2002 btncrosoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIbtnTED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET 
'   Professional (or greater).

Option Strict On

' Don't forget to add a reference to the "System.ServiceProcess.dll"
'   Right click the References section to add the reference.
Imports System.ServiceProcess


Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Stores the selected Service
    Dim m_SelectedService As ServiceController
    ' Stores the name of the Selected Service
    Dim m_SelectedServiceName As String = "No Service Selected"
    ' Since the X at the top of the form is used to Minimize
    '   the form, to prevent accidental closing, this flag is used to 
    '   to notify the application that the BUTTON closing the application
    '   was used.
    Dim m_isCloseButtonPushed As Boolean = False


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents sbrServiceStatus As System.Windows.Forms.StatusBar
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents grdServices As System.Windows.Forms.DataGrid
    Friend WithEvents txtSelectedService As System.Windows.Forms.TextBox
    Friend WithEvents tmrCheckStatus As System.Windows.Forms.Timer
    Friend WithEvents btnRefreshServices As System.Windows.Forms.Button
    Friend WithEvents cmnuServiceStatus As System.Windows.Forms.ContextMenu
    Friend WithEvents nicoSvcMgrApp As System.Windows.Forms.NotifyIcon
    Friend WithEvents miServiceName As System.Windows.Forms.MenuItem
    Friend WithEvents miLineBreak1 As System.Windows.Forms.MenuItem
    Friend WithEvents miStart As System.Windows.Forms.MenuItem
    Friend WithEvents miPause As System.Windows.Forms.MenuItem
    Friend WithEvents miContinue As System.Windows.Forms.MenuItem
    Friend WithEvents miStop As System.Windows.Forms.MenuItem
    Friend WithEvents miLineBreak2 As System.Windows.Forms.MenuItem
    Friend WithEvents miSelectService As System.Windows.Forms.MenuItem
    Friend WithEvents btnCloseApp As System.Windows.Forms.Button
    Friend WithEvents btnMinimizeApp As System.Windows.Forms.Button
    Friend WithEvents lblSelectedService As System.Windows.Forms.Label
    Friend WithEvents mnuExitApp As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnRefreshServices = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.sbrServiceStatus = New System.Windows.Forms.StatusBar()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.grdServices = New System.Windows.Forms.DataGrid()
        Me.lblSelectedService = New System.Windows.Forms.Label()
        Me.txtSelectedService = New System.Windows.Forms.TextBox()
        Me.tmrCheckStatus = New System.Windows.Forms.Timer(Me.components)
        Me.cmnuServiceStatus = New System.Windows.Forms.ContextMenu()
        Me.miServiceName = New System.Windows.Forms.MenuItem()
        Me.miLineBreak1 = New System.Windows.Forms.MenuItem()
        Me.miStart = New System.Windows.Forms.MenuItem()
        Me.miPause = New System.Windows.Forms.MenuItem()
        Me.miContinue = New System.Windows.Forms.MenuItem()
        Me.miStop = New System.Windows.Forms.MenuItem()
        Me.miLineBreak2 = New System.Windows.Forms.MenuItem()
        Me.miSelectService = New System.Windows.Forms.MenuItem()
        Me.mnuExitApp = New System.Windows.Forms.MenuItem()
        Me.nicoSvcMgrApp = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btnCloseApp = New System.Windows.Forms.Button()
        Me.btnMinimizeApp = New System.Windows.Forms.Button()
        CType(Me.grdServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'btnRefreshServices
        '
        Me.btnRefreshServices.AccessibleDescription = "Button used to Verify the Install of the Windows Service."
        Me.btnRefreshServices.AccessibleName = "Verify Install Button"
        Me.btnRefreshServices.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnRefreshServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshServices.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshServices.Location = New System.Drawing.Point(376, 296)
        Me.btnRefreshServices.Name = "btnRefreshServices"
        Me.btnRefreshServices.Size = New System.Drawing.Size(96, 40)
        Me.btnRefreshServices.TabIndex = 13
        Me.btnRefreshServices.Text = "&Refresh Services"
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = "Button used to Stop the Windows Service."
        Me.btnStop.AccessibleName = "Stop Button"
        Me.btnStop.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnStop.Enabled = False
        Me.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStop.Location = New System.Drawing.Point(280, 304)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.TabIndex = 12
        Me.btnStop.Text = "Sto&p"
        '
        'btnContinue
        '
        Me.btnContinue.AccessibleDescription = "Button used to Continue the Windows Service."
        Me.btnContinue.AccessibleName = "Continue Button"
        Me.btnContinue.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnContinue.Enabled = False
        Me.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnContinue.Location = New System.Drawing.Point(192, 304)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.TabIndex = 11
        Me.btnContinue.Text = "&Continue"
        '
        'btnPause
        '
        Me.btnPause.AccessibleDescription = "Button used to Pause the Windows Service."
        Me.btnPause.AccessibleName = "Pause Button"
        Me.btnPause.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnPause.Enabled = False
        Me.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPause.Location = New System.Drawing.Point(104, 304)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.TabIndex = 10
        Me.btnPause.Text = "&Pause"
        '
        'sbrServiceStatus
        '
        Me.sbrServiceStatus.AccessibleDescription = "Status Bar showing status of the windows service."
        Me.sbrServiceStatus.AccessibleName = "Service Status Status Bar"
        Me.sbrServiceStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.sbrServiceStatus.Location = New System.Drawing.Point(0, 349)
        Me.sbrServiceStatus.Name = "sbrServiceStatus"
        Me.sbrServiceStatus.Size = New System.Drawing.Size(594, 22)
        Me.sbrServiceStatus.TabIndex = 9
        '
        'btnStart
        '
        Me.btnStart.AccessibleDescription = "Button used to Start the Windows Service."
        Me.btnStart.AccessibleName = "Start Button"
        Me.btnStart.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnStart.Enabled = False
        Me.btnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStart.Location = New System.Drawing.Point(16, 304)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.TabIndex = 8
        Me.btnStart.Text = "&Start"
        '
        'grdServices
        '
        Me.grdServices.AccessibleDescription = "DataGrid displaying all the installed Windows Services"
        Me.grdServices.AccessibleName = "Services Data Grid"
        Me.grdServices.DataMember = ""
        Me.grdServices.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdServices.Location = New System.Drawing.Point(16, 8)
        Me.grdServices.Name = "grdServices"
        Me.grdServices.ReadOnly = True
        Me.grdServices.Size = New System.Drawing.Size(560, 232)
        Me.grdServices.TabIndex = 14
        '
        'lblSelectedService
        '
        Me.lblSelectedService.AccessibleDescription = "Label containing text reading ""Selected Service"""
        Me.lblSelectedService.AccessibleName = "Selected Service Label"
        Me.lblSelectedService.Location = New System.Drawing.Point(16, 256)
        Me.lblSelectedService.Name = "lblSelectedService"
        Me.lblSelectedService.Size = New System.Drawing.Size(112, 23)
        Me.lblSelectedService.TabIndex = 15
        Me.lblSelectedService.Text = "Selected Service: "
        '
        'txtSelectedService
        '
        Me.txtSelectedService.AccessibleDescription = "Textbox containing the name of the selected service"
        Me.txtSelectedService.AccessibleName = "Selected Service TextBox"
        Me.txtSelectedService.Location = New System.Drawing.Point(144, 256)
        Me.txtSelectedService.Name = "txtSelectedService"
        Me.txtSelectedService.ReadOnly = True
        Me.txtSelectedService.Size = New System.Drawing.Size(328, 23)
        Me.txtSelectedService.TabIndex = 16
        Me.txtSelectedService.TabStop = False
        Me.txtSelectedService.Text = ""
        '
        'tmrCheckStatus
        '
        Me.tmrCheckStatus.Interval = 500
        '
        'cmnuServiceStatus
        '
        Me.cmnuServiceStatus.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miServiceName, Me.miLineBreak1, Me.miStart, Me.miPause, Me.miContinue, Me.miStop, Me.miLineBreak2, Me.miSelectService, Me.mnuExitApp})
        '
        'miServiceName
        '
        Me.miServiceName.Index = 0
        Me.miServiceName.Text = "No Service Selected"
        '
        'miLineBreak1
        '
        Me.miLineBreak1.Index = 1
        Me.miLineBreak1.Text = "-"
        '
        'miStart
        '
        Me.miStart.Index = 2
        Me.miStart.Text = "Start"
        '
        'miPause
        '
        Me.miPause.Index = 3
        Me.miPause.Text = "Pause"
        '
        'miContinue
        '
        Me.miContinue.Index = 4
        Me.miContinue.Text = "Continue"
        '
        'miStop
        '
        Me.miStop.Index = 5
        Me.miStop.Text = "Stop"
        '
        'miLineBreak2
        '
        Me.miLineBreak2.Index = 6
        Me.miLineBreak2.Text = "-"
        '
        'miSelectService
        '
        Me.miSelectService.Index = 7
        Me.miSelectService.Text = "Select New Service"
        '
        'mnuExitApp
        '
        Me.mnuExitApp.Index = 8
        Me.mnuExitApp.Text = "&Exit Application"
        '
        'nicoSvcMgrApp
        '
        Me.nicoSvcMgrApp.ContextMenu = Me.cmnuServiceStatus
        Me.nicoSvcMgrApp.Icon = CType(resources.GetObject("nicoSvcMgrApp.Icon"), System.Drawing.Icon)
        Me.nicoSvcMgrApp.Text = "SvcMgr"
        Me.nicoSvcMgrApp.Visible = True
        '
        'btnCloseApp
        '
        Me.btnCloseApp.AccessibleDescription = "Button to Close the Application"
        Me.btnCloseApp.AccessibleName = "Close App Button"
        Me.btnCloseApp.Location = New System.Drawing.Point(496, 248)
        Me.btnCloseApp.Name = "btnCloseApp"
        Me.btnCloseApp.Size = New System.Drawing.Size(80, 40)
        Me.btnCloseApp.TabIndex = 17
        Me.btnCloseApp.Text = "&Close Application"
        '
        'btnMinimizeApp
        '
        Me.btnMinimizeApp.AccessibleDescription = "Button to Minimize the Application"
        Me.btnMinimizeApp.AccessibleName = "Minimize App Button"
        Me.btnMinimizeApp.Location = New System.Drawing.Point(496, 296)
        Me.btnMinimizeApp.Name = "btnMinimizeApp"
        Me.btnMinimizeApp.Size = New System.Drawing.Size(80, 40)
        Me.btnMinimizeApp.TabIndex = 18
        Me.btnMinimizeApp.Text = "&Minimize Application"
        '
        'frmMain
        '
        Me.AccessibleDescription = "Main User Interface Form"
        Me.AccessibleName = "Main Form"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(594, 371)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnMinimizeApp, Me.btnCloseApp, Me.txtSelectedService, Me.lblSelectedService, Me.grdServices, Me.btnRefreshServices, Me.btnStop, Me.btnContinue, Me.btnPause, Me.sbrServiceStatus, Me.btnStart})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        CType(Me.grdServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub
#End Region

#Region "CloseApp Button"
    ' This sub is used to Close the application when the Close button is pushed.
    Private Sub btnCloseApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseApp.Click
        m_isCloseButtonPushed = True
        Me.Close()
    End Sub
#End Region

    ' This sub forces the service to Continue
    ' Notice this event handles both the Button and the MenuItem
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click, miContinue.Click
        m_SelectedService.Continue()
        UpdateServiceStatus()
    End Sub

#Region "MinimizeApp Button"
    ' This sub causes the application to be minimized
    Private Sub btnMinimizeApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimizeApp.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

    ' This sub forces the service to Pause
    ' Notice this event handles both the Button and the MenuItem
    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click, miPause.Click
        m_SelectedService.Pause()
        UpdateServiceStatus()
    End Sub

    ' This sub forces the service to Stop
    ' Notice this event handles both the Button and the MenuItem
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click, miStop.Click
        m_SelectedService.Stop()
        UpdateServiceStatus()
    End Sub

    ' This sub forces the service to Start
    ' Notice this event handles both the Button and the MenuItem
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click, miStart.Click
        m_SelectedService.Start()
        UpdateServiceStatus()
    End Sub

    ' This sub is used to find if the Service is currently installed, and to
    '   force the DataGrid to refresh itself
    Private Sub btnRefreshServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshServices.Click
        grdServices.DataSource = GetServicesTable()
        grdServices.Refresh()
    End Sub

#Region "Context Menu Creation"
    ' This sub ensures that the first MenuItem is the name of the selected Service
    Private Sub cmnuServiceStatus_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuServiceStatus.Popup
        'Build the menu
        Me.cmnuServiceStatus.MenuItems(0).Text = Me.m_SelectedServiceName
    End Sub
#End Region

#Region "Closing application event handler"
    ' This sub handles the Closing event
    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not m_isCloseButtonPushed Then
            Me.WindowState = FormWindowState.Minimized
            e.Cancel = True
        End If
    End Sub
#End Region

    ' This sub causes the data to be loaded into the DataGrid, so it 
    '   can properly display all of the current Windows Services
    '   on the local machine.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Fix the column widths 
        grdServices.PreferredColumnWidth = grdServices.Width \ 4

        ' Get the Windows Services and display them in the DataGrid
        grdServices.DataSource = GetServicesTable()
        grdServices.Refresh()

        ' Enable the timer so that the interface is refreshed.
        tmrCheckStatus.Enabled = True
    End Sub


    ' This sub locates the user selected Service and sets it as the 
    '   selected Service
    Private Sub grdServices_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdServices.MouseDown

        ' Create a hit test info variable to determine selected row
        Dim hit As System.Windows.Forms.DataGrid.HitTestInfo = _
            grdServices.HitTest(e.X, e.Y)

        ' Find the Service based on the selected row
        If hit.Row >= 0 Then
            Me.grdServices.Select(hit.Row)
            m_SelectedServiceName = Me.grdServices.Item(hit.Row, 0).ToString()
            RefreshSelectedService()
            UpdateServiceStatus()
        End If
    End Sub

#Region "Context Menu and Notify Icon events"
    ' This sub shows the window when the user selects it from the context menu
    Private Sub miSelectService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSelectService.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    ' This sub shows the window when the user double clicks the NotifyIcon
    Private Sub nicoSvcMgrApp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nicoSvcMgrApp.DoubleClick
        Me.WindowState = FormWindowState.Normal
    End Sub
#End Region

    ' This sub refreshes the User Interface every 1/2 second
    Private Sub tmrCheckStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheckStatus.Tick
        RefreshSelectedService()
        UpdateServiceStatus()
    End Sub

    Private Sub mnuExitApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExitApp.Click
        Application.Exit()
    End Sub


#Region "CreateDataTable routine to define necessary DataTable"
    ' This method creates the DataTable that will store all of the 
    '   Windows Services on the local machine.
    Private Function CreateDataTable() As DataTable

        Dim myTable As New DataTable("WindowsServiceTable")
        Dim myColumn As DataColumn
        Dim typeString As Type = "".GetType()

        ' Create the necessary columns
        myTable.Columns.Add("Service Name", typeString)
        myTable.Columns.Add("Display Name", typeString)
        myTable.Columns.Add("Status", typeString)

        Return myTable

    End Function
#End Region

    ' This function returns a DataTable filled with all of the services
    '   that are currently installed on the local machine.
    Private Function GetServicesTable() As DataTable

        Dim myTable As DataTable ' Temporarily stores the services
        Dim myServicesArray() As ServiceController
        Dim myService As ServiceController
        Dim myRow As DataRow ' Used to add rows to the DataTable

        ' Create a DataTable with the proper columns
        myTable = CreateDataTable()
        ' Gets an array of all Services (except Device Drivers) that are 
        '   installed on the local machine.
        myServicesArray = ServiceController.GetServices()

        ' For each Windows Service, add useful information to the DataGrid
        For Each myService In myServicesArray
            myRow = myTable.NewRow() ' Creates a new Row from the DataTable
            myRow.Item("Service Name") = myService.ServiceName
            myRow.Item("Display Name") = myService.DisplayName
            myRow.Item("Status") = myService.Status.ToString()

            myTable.Rows.Add(myRow) ' Adds the new Row to the DataTable
        Next

        ' Return the filled table
        Return myTable

    End Function

    ' RefreshSelectedService verifies that the service is actually
    '   installed on the system. It also assigns the service
    '   to the myService class variable if it is. 
    ' The assignment to m_SelectedService is important and must be refreshed, 
    '   since unlike most objects, the myService doesn't get changes to the
    '   status of the actual service. So it must be continually reassigned.
    Private Sub RefreshSelectedService()

        Dim installedServices() As ServiceController
        Dim tmpService As ServiceController
        Dim isServiceInstalled As Boolean = False
        Dim i As Integer = 0

        ' Shut off the timer so it doesn't raise events while were
        '   in this code
        Me.tmrCheckStatus.Enabled = False

        ' Get a list of all Running Services
        installedServices = ServiceController.GetServices()

        ' Got through each service to see ensure it is installed, and if it
        '   is, then assign it to m_SelectedService
        For Each tmpService In installedServices
            If tmpService.ServiceName = m_SelectedServiceName Then
                isServiceInstalled = True
                ' Assign the service to myService, so we can use it later.
                m_SelectedService = tmpService
            End If
        Next tmpService

        ' Re-enable the timer
        Me.tmrCheckStatus.Enabled = True

    End Sub

    ' This sub refreshes most of the UI (except for the DataGrid) to show the
    '   latest status of the Windows Service.
    Private Sub UpdateServiceStatus()

        ' Shut off the timer so it doesn't raise events while were
        '   in this code
        Me.tmrCheckStatus.Enabled = False

        If Not (m_SelectedService Is Nothing) Then

            ' Recreate mySelectedServer, otherwise the status for myServer never
            '   changes, despite changes in the status of the 
            '   windows service
            RefreshSelectedService()

            ' Rebuild the UI, enabling and disabling buttons and menu items
            '   as necessary.
            Select Case m_SelectedService.Status
                Case ServiceControllerStatus.Stopped
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = True
                    Me.btnStop.Enabled = False

                    Me.miContinue.Enabled = False
                    Me.miPause.Enabled = False
                    Me.miStart.Enabled = True
                    Me.miStop.Enabled = False

                Case ServiceControllerStatus.Running
                    Me.btnContinue.Enabled = False
                    If m_SelectedService.CanPauseAndContinue Then
                        Me.btnPause.Enabled = True
                    End If
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True

                    Me.miContinue.Enabled = False
                    If m_SelectedService.CanPauseAndContinue Then
                        Me.miPause.Enabled = True
                    End If
                    Me.miStart.Enabled = False
                    Me.miStop.Enabled = True

                Case ServiceControllerStatus.Paused
                    If m_SelectedService.CanPauseAndContinue Then
                        Me.btnContinue.Enabled = True
                    End If
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True

                    If m_SelectedService.CanPauseAndContinue Then
                        Me.miContinue.Enabled = True
                    End If
                    Me.miPause.Enabled = False
                    Me.miStart.Enabled = False
                    Me.miStop.Enabled = True

                Case Else
                    ' This can occur when an action is pending. In this case
                    '   don't allow the user to push any buttons.
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = False

                    Me.miContinue.Enabled = False
                    Me.miPause.Enabled = False
                    Me.miStart.Enabled = False
                    Me.miStop.Enabled = False

            End Select

            ' Output the status to the Status Bar
            Me.sbrServiceStatus.Text = "Service Status: " + _
                    m_SelectedService.Status.ToString()
        Else
            ' The service isn't running so disable everything but refresh.
            Me.btnContinue.Enabled = False
            Me.btnPause.Enabled = False
            Me.btnStart.Enabled = False
            Me.btnStop.Enabled = False

            Me.miContinue.Enabled = False
            Me.miPause.Enabled = False
            Me.miStart.Enabled = False
            Me.miStop.Enabled = False

        End If

        ' Set the selected service name to the text box
        Me.txtSelectedService.Text = m_SelectedServiceName

        ' Re-enable the timer.
        Me.tmrCheckStatus.Enabled = True

    End Sub


End Class