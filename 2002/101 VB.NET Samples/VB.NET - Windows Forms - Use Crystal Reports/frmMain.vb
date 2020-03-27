Option Strict On
Option Explicit On 

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Protected Const MSDE_SERVER As String = "(local)\VSdotNET"

    Protected Const SQL_CONNECTION_STRING As String = _
            "Server=localhost;" & _
            "DataBase=Northwind;" & _
            "Integrated Security=SSPI;Connect Timeout=5"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=" & MSDE_SERVER & ";" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI;Connect Timeout=5"

    Private ConnectionString As String = SQL_CONNECTION_STRING
    Private HasConnected As Boolean = False
    Private ServerName As String = "localhost"
    

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

        crvBasic.DisplayToolbar = True
        crvParameter.DisplayToolbar = True
        crvDynamicFormat.DisplayToolbar = True
        crvGraphDrillDown.DisplayToolbar = True


        ' Here we need to populate the combo box with the customer names found in the
        ' customers table in the northwind databse.
        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        ' Create a datareader object to read the data from the command object.
        Dim drSQL As SqlDataReader

        ' Display a status message box saying that we are attempting to connect.
        ' This only needs to be done the first time a connection is attempted.
        ' After we have determined that MSDE or SQL Server is installed, this 
        ' message no longer needs to be displayed
        Dim frmStatusMessage As New frmStatus()
        If Not HasConnected Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to SQL server or MSDE
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try
                ' Define connection string.
                ' You may need to change this for your environment.
                cnSQL = New SqlConnection(ConnectionString)
                cnSQL.Open()

                ' Instantiate Command Object to execute SQL Statements
                cmSQL = New SqlCommand()

                ' Attach the command to the connection
                cmSQL.Connection = cnSQL

                ' Set the command type to Text
                cmSQL.CommandType = CommandType.Text

                ' START: Commands are for this How-To only.
                ' Drop GetAllCustomerOrders Store Procedure if it exists.
                cmSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GetAllCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " & _
                                                        "DROP PROCEDURE [dbo].[GetAllCustomerOrders] "

                ' Execute the statement
                cmSQL.ExecuteNonQuery()

                ' Create GetAllCustomerOrders Stored Procedure
                cmSQL.CommandText = "CREATE PROCEDURE dbo.GetAllCustomerOrders " & _
                                        "AS " & _
                                    "SELECT CUST.CompanyName, " & _
                                        "ORD.OrderID, " & _
                                        "ORD.OrderDate, " & _
                                        "ORD.ShippedDate, " & _
                                        "PROD.ProductName, " & _
                                        "ORD_D.UnitPrice, " & _
                                        "ORD_D.Quantity " & _
                                    "FROM Customers CUST " & _
                                        "INNER JOIN Orders ORD " & _
                                        "ON CUST.CustomerID = ORD.CustomerID " & _
                                        "INNER JOIN [Order Details] ORD_D " & _
                                        "ON ORD.OrderID = ORD_D.OrderID " & _
                                        "INNER JOIN Products PROD " & _
                                        "ON ORD_D.ProductID = PROD.ProductID " & _
                                        "ORDER BY ORD.OrderDate	" & _
                                    "Return"

                ' Execute the statement
                cmSQL.ExecuteNonQuery()

                ' Drop GetCustomerOrders Store Procedure if it exists.  This How-To Only
                cmSQL.CommandText = "IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " & _
                                                        "DROP PROCEDURE [dbo].[GetCustomerOrders] "

                ' Execute the statement
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "CREATE PROCEDURE dbo.GetCustomerOrders " & _
                                        "@CustomerName nvarchar(50) " & _
                                        "AS " & _
                                    "SELECT ORD.OrderID, " & _
                                        "ORD.ShippedDate, " & _
                                        "ORD.OrderDate, " & _
                                        "PROD.ProductName, " & _
                                        "ORD_D.UnitPrice, " & _
                                        "ORD_D.Quantity " & _
                                    "FROM Customers CUST " & _
                                        "INNER JOIN Orders ORD " & _
                                        "ON CUST.CustomerID = ORD.CustomerID " & _
                                        "INNER JOIN [Order Details] ORD_D " & _
                                        "ON ORD.OrderID = ORD_D.OrderID " & _
                                        "INNER JOIN Products PROD " & _
                                        "ON ORD_D.ProductID = PROD.ProductID " & _
                                    "WHERE CUST.CompanyName = @CustomerName " & _
                                    "ORDER BY ORD.OrderDate	" & _
                                    "RETURN"

                ' Execute the statement
                cmSQL.ExecuteNonQuery()
                ' END: Commands for this How-To only.             

                ' Select statement to pull all the customers from
                ' the customer table in the northwind databse.
                cmSQL.CommandText = "SELECT CompanyName " & _
                                    "FROM Customers"

                ' Execute the query we defined in the command object.
                drSQL = cmSQL.ExecuteReader()

                ' Loop through the records while there is still records to 
                ' retrieve.
                Do While drSQL.Read()
                    ' Add the Customers Company Name to the combo box.
                    cbCustomers.Items.Add(drSQL("CompanyName").ToString())
                Loop

                ' Set the combo box to the first item.
                cbCustomers.SelectedIndex = 0

                IsConnecting = False
                HasConnected = True

                ' Close Connection.
                drSQL.Close()
                cnSQL.Close()

                ' Clean up.
                cnSQL.Dispose()
                cmSQL.Dispose()

            Catch Err As SqlException
                If ConnectionString = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL server. Now try MSDE
                    ConnectionString = MSDE_CONNECTION_STRING
                    ServerNAme = MSDE_SERVER
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MsgBox("To run this sample you must have SQL Server ot MSDE with " & _
                           "the Northwind database installed.  For instructions on " & _
                           "installing MSDE, view the Readme file.", MsgBoxStyle.Critical, _
                           "SQL Server/MSDE not found")
                    ' Quit program if neither connection method was successful.
                    End

                End If
            Catch Err As Exception
                ' Report Non SQL Error to the user.
                MsgBox(Err.ToString(), MsgBoxStyle.Critical, "General Error")
            End Try
        End While
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
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpReportBasic As System.Windows.Forms.TabPage
    Friend WithEvents crvBasic As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents tpParameterReport As System.Windows.Forms.TabPage
    Friend WithEvents crvParameter As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents cbCustomers As System.Windows.Forms.ComboBox
    Friend WithEvents btnPreviewCustomerReport As System.Windows.Forms.Button
    Friend WithEvents tpDynamicFormatReport As System.Windows.Forms.TabPage
    Friend WithEvents tpGraphDrillDownReport As System.Windows.Forms.TabPage
    Friend WithEvents crvDynamicFormat As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crvGraphDrillDown As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtUnitsToHighlight As System.Windows.Forms.TextBox
    Friend WithEvents cbHighlightColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPreviewDrillDownReport As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPreviewBasicReport As System.Windows.Forms.Button
    Friend WithEvents btnPreviewDynamicReport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpReportBasic = New System.Windows.Forms.TabPage()
        Me.btnPreviewBasicReport = New System.Windows.Forms.Button()
        Me.crvBasic = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tpDynamicFormatReport = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPreviewDynamicReport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbHighlightColor = New System.Windows.Forms.ComboBox()
        Me.txtUnitsToHighlight = New System.Windows.Forms.TextBox()
        Me.crvDynamicFormat = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tpParameterReport = New System.Windows.Forms.TabPage()
        Me.btnPreviewCustomerReport = New System.Windows.Forms.Button()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cbCustomers = New System.Windows.Forms.ComboBox()
        Me.crvParameter = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tpGraphDrillDownReport = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPreviewDrillDownReport = New System.Windows.Forms.Button()
        Me.crvGraphDrillDown = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.tpReportBasic.SuspendLayout()
        Me.tpDynamicFormatReport.SuspendLayout()
        Me.tpParameterReport.SuspendLayout()
        Me.tpGraphDrillDownReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'MenuItem1
        '
        Me.MenuItem1.Enabled = CType(resources.GetObject("MenuItem1.Enabled"), Boolean)
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.MenuItem1.Shortcut = CType(resources.GetObject("MenuItem1.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem1.ShowShortcut = CType(resources.GetObject("MenuItem1.ShowShortcut"), Boolean)
        Me.MenuItem1.Text = resources.GetString("MenuItem1.Text")
        Me.MenuItem1.Visible = CType(resources.GetObject("MenuItem1.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'MenuItem2
        '
        Me.MenuItem2.Enabled = CType(resources.GetObject("MenuItem2.Enabled"), Boolean)
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.MenuItem2.Shortcut = CType(resources.GetObject("MenuItem2.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem2.ShowShortcut = CType(resources.GetObject("MenuItem2.ShowShortcut"), Boolean)
        Me.MenuItem2.Text = resources.GetString("MenuItem2.Text")
        Me.MenuItem2.Visible = CType(resources.GetObject("MenuItem2.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = CType(resources.GetObject("TabControl1.AccessibleDescription"), String)
        Me.TabControl1.AccessibleName = CType(resources.GetObject("TabControl1.AccessibleName"), String)
        Me.TabControl1.Alignment = CType(resources.GetObject("TabControl1.Alignment"), System.Windows.Forms.TabAlignment)
        Me.TabControl1.Anchor = CType(resources.GetObject("TabControl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = CType(resources.GetObject("TabControl1.Appearance"), System.Windows.Forms.TabAppearance)
        Me.TabControl1.BackgroundImage = CType(resources.GetObject("TabControl1.BackgroundImage"), System.Drawing.Image)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpReportBasic, Me.tpDynamicFormatReport, Me.tpParameterReport, Me.tpGraphDrillDownReport})
        Me.TabControl1.Dock = CType(resources.GetObject("TabControl1.Dock"), System.Windows.Forms.DockStyle)
        Me.TabControl1.Enabled = CType(resources.GetObject("TabControl1.Enabled"), Boolean)
        Me.TabControl1.Font = CType(resources.GetObject("TabControl1.Font"), System.Drawing.Font)
        Me.TabControl1.ImeMode = CType(resources.GetObject("TabControl1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabControl1.ItemSize = CType(resources.GetObject("TabControl1.ItemSize"), System.Drawing.Size)
        Me.TabControl1.Location = CType(resources.GetObject("TabControl1.Location"), System.Drawing.Point)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = CType(resources.GetObject("TabControl1.Padding"), System.Drawing.Point)
        Me.TabControl1.RightToLeft = CType(resources.GetObject("TabControl1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = CType(resources.GetObject("TabControl1.ShowToolTips"), Boolean)
        Me.TabControl1.Size = CType(resources.GetObject("TabControl1.Size"), System.Drawing.Size)
        Me.TabControl1.TabIndex = CType(resources.GetObject("TabControl1.TabIndex"), Integer)
        Me.TabControl1.Text = resources.GetString("TabControl1.Text")
        Me.TabControl1.Visible = CType(resources.GetObject("TabControl1.Visible"), Boolean)
        '
        'tpReportBasic
        '
        Me.tpReportBasic.AccessibleDescription = CType(resources.GetObject("tpReportBasic.AccessibleDescription"), String)
        Me.tpReportBasic.AccessibleName = CType(resources.GetObject("tpReportBasic.AccessibleName"), String)
        Me.tpReportBasic.Anchor = CType(resources.GetObject("tpReportBasic.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpReportBasic.AutoScroll = CType(resources.GetObject("tpReportBasic.AutoScroll"), Boolean)
        Me.tpReportBasic.AutoScrollMargin = CType(resources.GetObject("tpReportBasic.AutoScrollMargin"), System.Drawing.Size)
        Me.tpReportBasic.AutoScrollMinSize = CType(resources.GetObject("tpReportBasic.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpReportBasic.BackgroundImage = CType(resources.GetObject("tpReportBasic.BackgroundImage"), System.Drawing.Image)
        Me.tpReportBasic.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPreviewBasicReport, Me.crvBasic})
        Me.tpReportBasic.Dock = CType(resources.GetObject("tpReportBasic.Dock"), System.Windows.Forms.DockStyle)
        Me.tpReportBasic.Enabled = CType(resources.GetObject("tpReportBasic.Enabled"), Boolean)
        Me.tpReportBasic.Font = CType(resources.GetObject("tpReportBasic.Font"), System.Drawing.Font)
        Me.tpReportBasic.ImageIndex = CType(resources.GetObject("tpReportBasic.ImageIndex"), Integer)
        Me.tpReportBasic.ImeMode = CType(resources.GetObject("tpReportBasic.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpReportBasic.Location = CType(resources.GetObject("tpReportBasic.Location"), System.Drawing.Point)
        Me.tpReportBasic.Name = "tpReportBasic"
        Me.tpReportBasic.RightToLeft = CType(resources.GetObject("tpReportBasic.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpReportBasic.Size = CType(resources.GetObject("tpReportBasic.Size"), System.Drawing.Size)
        Me.tpReportBasic.TabIndex = CType(resources.GetObject("tpReportBasic.TabIndex"), Integer)
        Me.tpReportBasic.Text = resources.GetString("tpReportBasic.Text")
        Me.tpReportBasic.ToolTipText = resources.GetString("tpReportBasic.ToolTipText")
        Me.tpReportBasic.Visible = CType(resources.GetObject("tpReportBasic.Visible"), Boolean)
        '
        'btnPreviewBasicReport
        '
        Me.btnPreviewBasicReport.AccessibleDescription = resources.GetString("btnPreviewBasicReport.AccessibleDescription")
        Me.btnPreviewBasicReport.AccessibleName = resources.GetString("btnPreviewBasicReport.AccessibleName")
        Me.btnPreviewBasicReport.Anchor = CType(resources.GetObject("btnPreviewBasicReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPreviewBasicReport.BackgroundImage = CType(resources.GetObject("btnPreviewBasicReport.BackgroundImage"), System.Drawing.Image)
        Me.btnPreviewBasicReport.Dock = CType(resources.GetObject("btnPreviewBasicReport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPreviewBasicReport.Enabled = CType(resources.GetObject("btnPreviewBasicReport.Enabled"), Boolean)
        Me.btnPreviewBasicReport.FlatStyle = CType(resources.GetObject("btnPreviewBasicReport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPreviewBasicReport.Font = CType(resources.GetObject("btnPreviewBasicReport.Font"), System.Drawing.Font)
        Me.btnPreviewBasicReport.Image = CType(resources.GetObject("btnPreviewBasicReport.Image"), System.Drawing.Image)
        Me.btnPreviewBasicReport.ImageAlign = CType(resources.GetObject("btnPreviewBasicReport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewBasicReport.ImageIndex = CType(resources.GetObject("btnPreviewBasicReport.ImageIndex"), Integer)
        Me.btnPreviewBasicReport.ImeMode = CType(resources.GetObject("btnPreviewBasicReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPreviewBasicReport.Location = CType(resources.GetObject("btnPreviewBasicReport.Location"), System.Drawing.Point)
        Me.btnPreviewBasicReport.Name = "btnPreviewBasicReport"
        Me.btnPreviewBasicReport.RightToLeft = CType(resources.GetObject("btnPreviewBasicReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPreviewBasicReport.Size = CType(resources.GetObject("btnPreviewBasicReport.Size"), System.Drawing.Size)
        Me.btnPreviewBasicReport.TabIndex = CType(resources.GetObject("btnPreviewBasicReport.TabIndex"), Integer)
        Me.btnPreviewBasicReport.Text = resources.GetString("btnPreviewBasicReport.Text")
        Me.btnPreviewBasicReport.TextAlign = CType(resources.GetObject("btnPreviewBasicReport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewBasicReport.Visible = CType(resources.GetObject("btnPreviewBasicReport.Visible"), Boolean)
        '
        'crvBasic
        '
        Me.crvBasic.AccessibleDescription = CType(resources.GetObject("crvBasic.AccessibleDescription"), String)
        Me.crvBasic.AccessibleName = CType(resources.GetObject("crvBasic.AccessibleName"), String)
        Me.crvBasic.ActiveViewIndex = -1
        Me.crvBasic.Anchor = CType(resources.GetObject("crvBasic.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.crvBasic.AutoScroll = CType(resources.GetObject("crvBasic.AutoScroll"), Boolean)
        Me.crvBasic.AutoScrollMargin = CType(resources.GetObject("crvBasic.AutoScrollMargin"), System.Drawing.Size)
        Me.crvBasic.AutoScrollMinSize = CType(resources.GetObject("crvBasic.AutoScrollMinSize"), System.Drawing.Size)
        Me.crvBasic.BackgroundImage = CType(resources.GetObject("crvBasic.BackgroundImage"), System.Drawing.Image)
        Me.crvBasic.DisplayBackgroundEdge = CType(resources.GetObject("crvBasic.DisplayBackgroundEdge"), Boolean)
        Me.crvBasic.DisplayGroupTree = CType(resources.GetObject("crvBasic.DisplayGroupTree"), Boolean)
        Me.crvBasic.DisplayToolbar = CType(resources.GetObject("crvBasic.DisplayToolbar"), Boolean)
        Me.crvBasic.Dock = CType(resources.GetObject("crvBasic.Dock"), System.Windows.Forms.DockStyle)
        Me.crvBasic.Enabled = CType(resources.GetObject("crvBasic.Enabled"), Boolean)
        Me.crvBasic.EnableDrillDown = CType(resources.GetObject("crvBasic.EnableDrillDown"), Boolean)
        Me.crvBasic.Font = CType(resources.GetObject("crvBasic.Font"), System.Drawing.Font)
        Me.crvBasic.ImeMode = CType(resources.GetObject("crvBasic.ImeMode"), System.Windows.Forms.ImeMode)
        Me.crvBasic.Location = CType(resources.GetObject("crvBasic.Location"), System.Drawing.Point)
        Me.crvBasic.Name = "crvBasic"
        Me.crvBasic.ReportSource = Nothing
        Me.crvBasic.RightToLeft = CType(resources.GetObject("crvBasic.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.crvBasic.ShowCloseButton = CType(resources.GetObject("crvBasic.ShowCloseButton"), Boolean)
        Me.crvBasic.ShowExportButton = CType(resources.GetObject("crvBasic.ShowExportButton"), Boolean)
        Me.crvBasic.ShowGotoPageButton = CType(resources.GetObject("crvBasic.ShowGotoPageButton"), Boolean)
        Me.crvBasic.ShowGroupTreeButton = CType(resources.GetObject("crvBasic.ShowGroupTreeButton"), Boolean)
        Me.crvBasic.ShowPageNavigateButtons = CType(resources.GetObject("crvBasic.ShowPageNavigateButtons"), Boolean)
        Me.crvBasic.ShowPrintButton = CType(resources.GetObject("crvBasic.ShowPrintButton"), Boolean)
        Me.crvBasic.ShowRefreshButton = CType(resources.GetObject("crvBasic.ShowRefreshButton"), Boolean)
        Me.crvBasic.ShowTextSearchButton = CType(resources.GetObject("crvBasic.ShowTextSearchButton"), Boolean)
        Me.crvBasic.ShowZoomButton = CType(resources.GetObject("crvBasic.ShowZoomButton"), Boolean)
        Me.crvBasic.Size = CType(resources.GetObject("crvBasic.Size"), System.Drawing.Size)
        Me.crvBasic.TabIndex = CType(resources.GetObject("crvBasic.TabIndex"), Integer)
        Me.crvBasic.Visible = CType(resources.GetObject("crvBasic.Visible"), Boolean)
        '
        'tpDynamicFormatReport
        '
        Me.tpDynamicFormatReport.AccessibleDescription = CType(resources.GetObject("tpDynamicFormatReport.AccessibleDescription"), String)
        Me.tpDynamicFormatReport.AccessibleName = CType(resources.GetObject("tpDynamicFormatReport.AccessibleName"), String)
        Me.tpDynamicFormatReport.Anchor = CType(resources.GetObject("tpDynamicFormatReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpDynamicFormatReport.AutoScroll = CType(resources.GetObject("tpDynamicFormatReport.AutoScroll"), Boolean)
        Me.tpDynamicFormatReport.AutoScrollMargin = CType(resources.GetObject("tpDynamicFormatReport.AutoScrollMargin"), System.Drawing.Size)
        Me.tpDynamicFormatReport.AutoScrollMinSize = CType(resources.GetObject("tpDynamicFormatReport.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpDynamicFormatReport.BackgroundImage = CType(resources.GetObject("tpDynamicFormatReport.BackgroundImage"), System.Drawing.Image)
        Me.tpDynamicFormatReport.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.btnPreviewDynamicReport, Me.Label2, Me.Label1, Me.cbHighlightColor, Me.txtUnitsToHighlight, Me.crvDynamicFormat})
        Me.tpDynamicFormatReport.Dock = CType(resources.GetObject("tpDynamicFormatReport.Dock"), System.Windows.Forms.DockStyle)
        Me.tpDynamicFormatReport.Enabled = CType(resources.GetObject("tpDynamicFormatReport.Enabled"), Boolean)
        Me.tpDynamicFormatReport.Font = CType(resources.GetObject("tpDynamicFormatReport.Font"), System.Drawing.Font)
        Me.tpDynamicFormatReport.ImageIndex = CType(resources.GetObject("tpDynamicFormatReport.ImageIndex"), Integer)
        Me.tpDynamicFormatReport.ImeMode = CType(resources.GetObject("tpDynamicFormatReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpDynamicFormatReport.Location = CType(resources.GetObject("tpDynamicFormatReport.Location"), System.Drawing.Point)
        Me.tpDynamicFormatReport.Name = "tpDynamicFormatReport"
        Me.tpDynamicFormatReport.RightToLeft = CType(resources.GetObject("tpDynamicFormatReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpDynamicFormatReport.Size = CType(resources.GetObject("tpDynamicFormatReport.Size"), System.Drawing.Size)
        Me.tpDynamicFormatReport.TabIndex = CType(resources.GetObject("tpDynamicFormatReport.TabIndex"), Integer)
        Me.tpDynamicFormatReport.Text = resources.GetString("tpDynamicFormatReport.Text")
        Me.tpDynamicFormatReport.ToolTipText = resources.GetString("tpDynamicFormatReport.ToolTipText")
        Me.tpDynamicFormatReport.Visible = CType(resources.GetObject("tpDynamicFormatReport.Visible"), Boolean)
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = CType(resources.GetObject("Label4.AccessibleDescription"), String)
        Me.Label4.AccessibleName = CType(resources.GetObject("Label4.AccessibleName"), String)
        Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
        Me.Label4.Dock = CType(resources.GetObject("Label4.Dock"), System.Windows.Forms.DockStyle)
        Me.Label4.Enabled = CType(resources.GetObject("Label4.Enabled"), Boolean)
        Me.Label4.Font = CType(resources.GetObject("Label4.Font"), System.Drawing.Font)
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = CType(resources.GetObject("Label4.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label4.ImageIndex = CType(resources.GetObject("Label4.ImageIndex"), Integer)
        Me.Label4.ImeMode = CType(resources.GetObject("Label4.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.Point)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = CType(resources.GetObject("Label4.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label4.Size = CType(resources.GetObject("Label4.Size"), System.Drawing.Size)
        Me.Label4.TabIndex = CType(resources.GetObject("Label4.TabIndex"), Integer)
        Me.Label4.Text = resources.GetString("Label4.Text")
        Me.Label4.TextAlign = CType(resources.GetObject("Label4.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label4.Visible = CType(resources.GetObject("Label4.Visible"), Boolean)
        '
        'btnPreviewDynamicReport
        '
        Me.btnPreviewDynamicReport.AccessibleDescription = resources.GetString("btnPreviewDynamicReport.AccessibleDescription")
        Me.btnPreviewDynamicReport.AccessibleName = resources.GetString("btnPreviewDynamicReport.AccessibleName")
        Me.btnPreviewDynamicReport.Anchor = CType(resources.GetObject("btnPreviewDynamicReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPreviewDynamicReport.BackgroundImage = CType(resources.GetObject("btnPreviewDynamicReport.BackgroundImage"), System.Drawing.Image)
        Me.btnPreviewDynamicReport.Dock = CType(resources.GetObject("btnPreviewDynamicReport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPreviewDynamicReport.Enabled = CType(resources.GetObject("btnPreviewDynamicReport.Enabled"), Boolean)
        Me.btnPreviewDynamicReport.FlatStyle = CType(resources.GetObject("btnPreviewDynamicReport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPreviewDynamicReport.Font = CType(resources.GetObject("btnPreviewDynamicReport.Font"), System.Drawing.Font)
        Me.btnPreviewDynamicReport.Image = CType(resources.GetObject("btnPreviewDynamicReport.Image"), System.Drawing.Image)
        Me.btnPreviewDynamicReport.ImageAlign = CType(resources.GetObject("btnPreviewDynamicReport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewDynamicReport.ImageIndex = CType(resources.GetObject("btnPreviewDynamicReport.ImageIndex"), Integer)
        Me.btnPreviewDynamicReport.ImeMode = CType(resources.GetObject("btnPreviewDynamicReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPreviewDynamicReport.Location = CType(resources.GetObject("btnPreviewDynamicReport.Location"), System.Drawing.Point)
        Me.btnPreviewDynamicReport.Name = "btnPreviewDynamicReport"
        Me.btnPreviewDynamicReport.RightToLeft = CType(resources.GetObject("btnPreviewDynamicReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPreviewDynamicReport.Size = CType(resources.GetObject("btnPreviewDynamicReport.Size"), System.Drawing.Size)
        Me.btnPreviewDynamicReport.TabIndex = CType(resources.GetObject("btnPreviewDynamicReport.TabIndex"), Integer)
        Me.btnPreviewDynamicReport.Text = resources.GetString("btnPreviewDynamicReport.Text")
        Me.btnPreviewDynamicReport.TextAlign = CType(resources.GetObject("btnPreviewDynamicReport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewDynamicReport.Visible = CType(resources.GetObject("btnPreviewDynamicReport.Visible"), Boolean)
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = CType(resources.GetObject("Label2.AccessibleDescription"), String)
        Me.Label2.AccessibleName = CType(resources.GetObject("Label2.AccessibleName"), String)
        Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
        Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
        Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
        Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
        Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
        Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'cbHighlightColor
        '
        Me.cbHighlightColor.AccessibleDescription = resources.GetString("cbHighlightColor.AccessibleDescription")
        Me.cbHighlightColor.AccessibleName = resources.GetString("cbHighlightColor.AccessibleName")
        Me.cbHighlightColor.Anchor = CType(resources.GetObject("cbHighlightColor.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbHighlightColor.BackgroundImage = CType(resources.GetObject("cbHighlightColor.BackgroundImage"), System.Drawing.Image)
        Me.cbHighlightColor.Dock = CType(resources.GetObject("cbHighlightColor.Dock"), System.Windows.Forms.DockStyle)
        Me.cbHighlightColor.Enabled = CType(resources.GetObject("cbHighlightColor.Enabled"), Boolean)
        Me.cbHighlightColor.Font = CType(resources.GetObject("cbHighlightColor.Font"), System.Drawing.Font)
        Me.cbHighlightColor.ImeMode = CType(resources.GetObject("cbHighlightColor.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbHighlightColor.IntegralHeight = CType(resources.GetObject("cbHighlightColor.IntegralHeight"), Boolean)
        Me.cbHighlightColor.ItemHeight = CType(resources.GetObject("cbHighlightColor.ItemHeight"), Integer)
        Me.cbHighlightColor.Items.AddRange(New Object() {resources.GetString("cbHighlightColor.Items.Items"), resources.GetString("cbHighlightColor.Items.Items1"), resources.GetString("cbHighlightColor.Items.Items2")})
        Me.cbHighlightColor.Location = CType(resources.GetObject("cbHighlightColor.Location"), System.Drawing.Point)
        Me.cbHighlightColor.MaxDropDownItems = CType(resources.GetObject("cbHighlightColor.MaxDropDownItems"), Integer)
        Me.cbHighlightColor.MaxLength = CType(resources.GetObject("cbHighlightColor.MaxLength"), Integer)
        Me.cbHighlightColor.Name = "cbHighlightColor"
        Me.cbHighlightColor.RightToLeft = CType(resources.GetObject("cbHighlightColor.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbHighlightColor.Size = CType(resources.GetObject("cbHighlightColor.Size"), System.Drawing.Size)
        Me.cbHighlightColor.TabIndex = CType(resources.GetObject("cbHighlightColor.TabIndex"), Integer)
        Me.cbHighlightColor.Text = resources.GetString("cbHighlightColor.Text")
        Me.cbHighlightColor.Visible = CType(resources.GetObject("cbHighlightColor.Visible"), Boolean)
        '
        'txtUnitsToHighlight
        '
        Me.txtUnitsToHighlight.AccessibleDescription = resources.GetString("txtUnitsToHighlight.AccessibleDescription")
        Me.txtUnitsToHighlight.AccessibleName = resources.GetString("txtUnitsToHighlight.AccessibleName")
        Me.txtUnitsToHighlight.Anchor = CType(resources.GetObject("txtUnitsToHighlight.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUnitsToHighlight.AutoSize = CType(resources.GetObject("txtUnitsToHighlight.AutoSize"), Boolean)
        Me.txtUnitsToHighlight.BackgroundImage = CType(resources.GetObject("txtUnitsToHighlight.BackgroundImage"), System.Drawing.Image)
        Me.txtUnitsToHighlight.Dock = CType(resources.GetObject("txtUnitsToHighlight.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUnitsToHighlight.Enabled = CType(resources.GetObject("txtUnitsToHighlight.Enabled"), Boolean)
        Me.txtUnitsToHighlight.Font = CType(resources.GetObject("txtUnitsToHighlight.Font"), System.Drawing.Font)
        Me.txtUnitsToHighlight.ImeMode = CType(resources.GetObject("txtUnitsToHighlight.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUnitsToHighlight.Location = CType(resources.GetObject("txtUnitsToHighlight.Location"), System.Drawing.Point)
        Me.txtUnitsToHighlight.MaxLength = CType(resources.GetObject("txtUnitsToHighlight.MaxLength"), Integer)
        Me.txtUnitsToHighlight.Multiline = CType(resources.GetObject("txtUnitsToHighlight.Multiline"), Boolean)
        Me.txtUnitsToHighlight.Name = "txtUnitsToHighlight"
        Me.txtUnitsToHighlight.PasswordChar = CType(resources.GetObject("txtUnitsToHighlight.PasswordChar"), Char)
        Me.txtUnitsToHighlight.RightToLeft = CType(resources.GetObject("txtUnitsToHighlight.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitsToHighlight.ScrollBars = CType(resources.GetObject("txtUnitsToHighlight.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitsToHighlight.Size = CType(resources.GetObject("txtUnitsToHighlight.Size"), System.Drawing.Size)
        Me.txtUnitsToHighlight.TabIndex = CType(resources.GetObject("txtUnitsToHighlight.TabIndex"), Integer)
        Me.txtUnitsToHighlight.Text = resources.GetString("txtUnitsToHighlight.Text")
        Me.txtUnitsToHighlight.TextAlign = CType(resources.GetObject("txtUnitsToHighlight.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitsToHighlight.Visible = CType(resources.GetObject("txtUnitsToHighlight.Visible"), Boolean)
        Me.txtUnitsToHighlight.WordWrap = CType(resources.GetObject("txtUnitsToHighlight.WordWrap"), Boolean)
        '
        'crvDynamicFormat
        '
        Me.crvDynamicFormat.AccessibleDescription = CType(resources.GetObject("crvDynamicFormat.AccessibleDescription"), String)
        Me.crvDynamicFormat.AccessibleName = CType(resources.GetObject("crvDynamicFormat.AccessibleName"), String)
        Me.crvDynamicFormat.ActiveViewIndex = -1
        Me.crvDynamicFormat.Anchor = CType(resources.GetObject("crvDynamicFormat.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.crvDynamicFormat.AutoScroll = CType(resources.GetObject("crvDynamicFormat.AutoScroll"), Boolean)
        Me.crvDynamicFormat.AutoScrollMargin = CType(resources.GetObject("crvDynamicFormat.AutoScrollMargin"), System.Drawing.Size)
        Me.crvDynamicFormat.AutoScrollMinSize = CType(resources.GetObject("crvDynamicFormat.AutoScrollMinSize"), System.Drawing.Size)
        Me.crvDynamicFormat.BackgroundImage = CType(resources.GetObject("crvDynamicFormat.BackgroundImage"), System.Drawing.Image)
        Me.crvDynamicFormat.DisplayBackgroundEdge = CType(resources.GetObject("crvDynamicFormat.DisplayBackgroundEdge"), Boolean)
        Me.crvDynamicFormat.DisplayGroupTree = CType(resources.GetObject("crvDynamicFormat.DisplayGroupTree"), Boolean)
        Me.crvDynamicFormat.DisplayToolbar = CType(resources.GetObject("crvDynamicFormat.DisplayToolbar"), Boolean)
        Me.crvDynamicFormat.Dock = CType(resources.GetObject("crvDynamicFormat.Dock"), System.Windows.Forms.DockStyle)
        Me.crvDynamicFormat.Enabled = CType(resources.GetObject("crvDynamicFormat.Enabled"), Boolean)
        Me.crvDynamicFormat.EnableDrillDown = CType(resources.GetObject("crvDynamicFormat.EnableDrillDown"), Boolean)
        Me.crvDynamicFormat.Font = CType(resources.GetObject("crvDynamicFormat.Font"), System.Drawing.Font)
        Me.crvDynamicFormat.ImeMode = CType(resources.GetObject("crvDynamicFormat.ImeMode"), System.Windows.Forms.ImeMode)
        Me.crvDynamicFormat.Location = CType(resources.GetObject("crvDynamicFormat.Location"), System.Drawing.Point)
        Me.crvDynamicFormat.Name = "crvDynamicFormat"
        Me.crvDynamicFormat.ReportSource = Nothing
        Me.crvDynamicFormat.RightToLeft = CType(resources.GetObject("crvDynamicFormat.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.crvDynamicFormat.ShowCloseButton = CType(resources.GetObject("crvDynamicFormat.ShowCloseButton"), Boolean)
        Me.crvDynamicFormat.ShowExportButton = CType(resources.GetObject("crvDynamicFormat.ShowExportButton"), Boolean)
        Me.crvDynamicFormat.ShowGotoPageButton = CType(resources.GetObject("crvDynamicFormat.ShowGotoPageButton"), Boolean)
        Me.crvDynamicFormat.ShowGroupTreeButton = CType(resources.GetObject("crvDynamicFormat.ShowGroupTreeButton"), Boolean)
        Me.crvDynamicFormat.ShowPageNavigateButtons = CType(resources.GetObject("crvDynamicFormat.ShowPageNavigateButtons"), Boolean)
        Me.crvDynamicFormat.ShowPrintButton = CType(resources.GetObject("crvDynamicFormat.ShowPrintButton"), Boolean)
        Me.crvDynamicFormat.ShowRefreshButton = CType(resources.GetObject("crvDynamicFormat.ShowRefreshButton"), Boolean)
        Me.crvDynamicFormat.ShowTextSearchButton = CType(resources.GetObject("crvDynamicFormat.ShowTextSearchButton"), Boolean)
        Me.crvDynamicFormat.ShowZoomButton = CType(resources.GetObject("crvDynamicFormat.ShowZoomButton"), Boolean)
        Me.crvDynamicFormat.Size = CType(resources.GetObject("crvDynamicFormat.Size"), System.Drawing.Size)
        Me.crvDynamicFormat.TabIndex = CType(resources.GetObject("crvDynamicFormat.TabIndex"), Integer)
        Me.crvDynamicFormat.Visible = CType(resources.GetObject("crvDynamicFormat.Visible"), Boolean)
        '
        'tpParameterReport
        '
        Me.tpParameterReport.AccessibleDescription = CType(resources.GetObject("tpParameterReport.AccessibleDescription"), String)
        Me.tpParameterReport.AccessibleName = CType(resources.GetObject("tpParameterReport.AccessibleName"), String)
        Me.tpParameterReport.Anchor = CType(resources.GetObject("tpParameterReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpParameterReport.AutoScroll = CType(resources.GetObject("tpParameterReport.AutoScroll"), Boolean)
        Me.tpParameterReport.AutoScrollMargin = CType(resources.GetObject("tpParameterReport.AutoScrollMargin"), System.Drawing.Size)
        Me.tpParameterReport.AutoScrollMinSize = CType(resources.GetObject("tpParameterReport.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpParameterReport.BackgroundImage = CType(resources.GetObject("tpParameterReport.BackgroundImage"), System.Drawing.Image)
        Me.tpParameterReport.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPreviewCustomerReport, Me.lblCustomer, Me.cbCustomers, Me.crvParameter})
        Me.tpParameterReport.Dock = CType(resources.GetObject("tpParameterReport.Dock"), System.Windows.Forms.DockStyle)
        Me.tpParameterReport.Enabled = CType(resources.GetObject("tpParameterReport.Enabled"), Boolean)
        Me.tpParameterReport.Font = CType(resources.GetObject("tpParameterReport.Font"), System.Drawing.Font)
        Me.tpParameterReport.ImageIndex = CType(resources.GetObject("tpParameterReport.ImageIndex"), Integer)
        Me.tpParameterReport.ImeMode = CType(resources.GetObject("tpParameterReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpParameterReport.Location = CType(resources.GetObject("tpParameterReport.Location"), System.Drawing.Point)
        Me.tpParameterReport.Name = "tpParameterReport"
        Me.tpParameterReport.RightToLeft = CType(resources.GetObject("tpParameterReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpParameterReport.Size = CType(resources.GetObject("tpParameterReport.Size"), System.Drawing.Size)
        Me.tpParameterReport.TabIndex = CType(resources.GetObject("tpParameterReport.TabIndex"), Integer)
        Me.tpParameterReport.Text = resources.GetString("tpParameterReport.Text")
        Me.tpParameterReport.ToolTipText = resources.GetString("tpParameterReport.ToolTipText")
        Me.tpParameterReport.Visible = CType(resources.GetObject("tpParameterReport.Visible"), Boolean)
        '
        'btnPreviewCustomerReport
        '
        Me.btnPreviewCustomerReport.AccessibleDescription = resources.GetString("btnPreviewCustomerReport.AccessibleDescription")
        Me.btnPreviewCustomerReport.AccessibleName = resources.GetString("btnPreviewCustomerReport.AccessibleName")
        Me.btnPreviewCustomerReport.Anchor = CType(resources.GetObject("btnPreviewCustomerReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPreviewCustomerReport.BackgroundImage = CType(resources.GetObject("btnPreviewCustomerReport.BackgroundImage"), System.Drawing.Image)
        Me.btnPreviewCustomerReport.Dock = CType(resources.GetObject("btnPreviewCustomerReport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPreviewCustomerReport.Enabled = CType(resources.GetObject("btnPreviewCustomerReport.Enabled"), Boolean)
        Me.btnPreviewCustomerReport.FlatStyle = CType(resources.GetObject("btnPreviewCustomerReport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPreviewCustomerReport.Font = CType(resources.GetObject("btnPreviewCustomerReport.Font"), System.Drawing.Font)
        Me.btnPreviewCustomerReport.Image = CType(resources.GetObject("btnPreviewCustomerReport.Image"), System.Drawing.Image)
        Me.btnPreviewCustomerReport.ImageAlign = CType(resources.GetObject("btnPreviewCustomerReport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewCustomerReport.ImageIndex = CType(resources.GetObject("btnPreviewCustomerReport.ImageIndex"), Integer)
        Me.btnPreviewCustomerReport.ImeMode = CType(resources.GetObject("btnPreviewCustomerReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPreviewCustomerReport.Location = CType(resources.GetObject("btnPreviewCustomerReport.Location"), System.Drawing.Point)
        Me.btnPreviewCustomerReport.Name = "btnPreviewCustomerReport"
        Me.btnPreviewCustomerReport.RightToLeft = CType(resources.GetObject("btnPreviewCustomerReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPreviewCustomerReport.Size = CType(resources.GetObject("btnPreviewCustomerReport.Size"), System.Drawing.Size)
        Me.btnPreviewCustomerReport.TabIndex = CType(resources.GetObject("btnPreviewCustomerReport.TabIndex"), Integer)
        Me.btnPreviewCustomerReport.Text = resources.GetString("btnPreviewCustomerReport.Text")
        Me.btnPreviewCustomerReport.TextAlign = CType(resources.GetObject("btnPreviewCustomerReport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewCustomerReport.Visible = CType(resources.GetObject("btnPreviewCustomerReport.Visible"), Boolean)
        '
        'lblCustomer
        '
        Me.lblCustomer.AccessibleDescription = CType(resources.GetObject("lblCustomer.AccessibleDescription"), String)
        Me.lblCustomer.AccessibleName = CType(resources.GetObject("lblCustomer.AccessibleName"), String)
        Me.lblCustomer.Anchor = CType(resources.GetObject("lblCustomer.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCustomer.AutoSize = CType(resources.GetObject("lblCustomer.AutoSize"), Boolean)
        Me.lblCustomer.Dock = CType(resources.GetObject("lblCustomer.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCustomer.Enabled = CType(resources.GetObject("lblCustomer.Enabled"), Boolean)
        Me.lblCustomer.Font = CType(resources.GetObject("lblCustomer.Font"), System.Drawing.Font)
        Me.lblCustomer.Image = CType(resources.GetObject("lblCustomer.Image"), System.Drawing.Image)
        Me.lblCustomer.ImageAlign = CType(resources.GetObject("lblCustomer.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCustomer.ImageIndex = CType(resources.GetObject("lblCustomer.ImageIndex"), Integer)
        Me.lblCustomer.ImeMode = CType(resources.GetObject("lblCustomer.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCustomer.Location = CType(resources.GetObject("lblCustomer.Location"), System.Drawing.Point)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.RightToLeft = CType(resources.GetObject("lblCustomer.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCustomer.Size = CType(resources.GetObject("lblCustomer.Size"), System.Drawing.Size)
        Me.lblCustomer.TabIndex = CType(resources.GetObject("lblCustomer.TabIndex"), Integer)
        Me.lblCustomer.Text = resources.GetString("lblCustomer.Text")
        Me.lblCustomer.TextAlign = CType(resources.GetObject("lblCustomer.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCustomer.Visible = CType(resources.GetObject("lblCustomer.Visible"), Boolean)
        '
        'cbCustomers
        '
        Me.cbCustomers.AccessibleDescription = resources.GetString("cbCustomers.AccessibleDescription")
        Me.cbCustomers.AccessibleName = resources.GetString("cbCustomers.AccessibleName")
        Me.cbCustomers.Anchor = CType(resources.GetObject("cbCustomers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbCustomers.BackgroundImage = CType(resources.GetObject("cbCustomers.BackgroundImage"), System.Drawing.Image)
        Me.cbCustomers.Dock = CType(resources.GetObject("cbCustomers.Dock"), System.Windows.Forms.DockStyle)
        Me.cbCustomers.Enabled = CType(resources.GetObject("cbCustomers.Enabled"), Boolean)
        Me.cbCustomers.Font = CType(resources.GetObject("cbCustomers.Font"), System.Drawing.Font)
        Me.cbCustomers.ImeMode = CType(resources.GetObject("cbCustomers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbCustomers.IntegralHeight = CType(resources.GetObject("cbCustomers.IntegralHeight"), Boolean)
        Me.cbCustomers.ItemHeight = CType(resources.GetObject("cbCustomers.ItemHeight"), Integer)
        Me.cbCustomers.Location = CType(resources.GetObject("cbCustomers.Location"), System.Drawing.Point)
        Me.cbCustomers.MaxDropDownItems = CType(resources.GetObject("cbCustomers.MaxDropDownItems"), Integer)
        Me.cbCustomers.MaxLength = CType(resources.GetObject("cbCustomers.MaxLength"), Integer)
        Me.cbCustomers.Name = "cbCustomers"
        Me.cbCustomers.RightToLeft = CType(resources.GetObject("cbCustomers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbCustomers.Size = CType(resources.GetObject("cbCustomers.Size"), System.Drawing.Size)
        Me.cbCustomers.TabIndex = CType(resources.GetObject("cbCustomers.TabIndex"), Integer)
        Me.cbCustomers.Text = resources.GetString("cbCustomers.Text")
        Me.cbCustomers.Visible = CType(resources.GetObject("cbCustomers.Visible"), Boolean)
        '
        'crvParameter
        '
        Me.crvParameter.AccessibleDescription = CType(resources.GetObject("crvParameter.AccessibleDescription"), String)
        Me.crvParameter.AccessibleName = CType(resources.GetObject("crvParameter.AccessibleName"), String)
        Me.crvParameter.ActiveViewIndex = -1
        Me.crvParameter.Anchor = CType(resources.GetObject("crvParameter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.crvParameter.AutoScroll = CType(resources.GetObject("crvParameter.AutoScroll"), Boolean)
        Me.crvParameter.AutoScrollMargin = CType(resources.GetObject("crvParameter.AutoScrollMargin"), System.Drawing.Size)
        Me.crvParameter.AutoScrollMinSize = CType(resources.GetObject("crvParameter.AutoScrollMinSize"), System.Drawing.Size)
        Me.crvParameter.BackgroundImage = CType(resources.GetObject("crvParameter.BackgroundImage"), System.Drawing.Image)
        Me.crvParameter.DisplayBackgroundEdge = CType(resources.GetObject("crvParameter.DisplayBackgroundEdge"), Boolean)
        Me.crvParameter.DisplayGroupTree = CType(resources.GetObject("crvParameter.DisplayGroupTree"), Boolean)
        Me.crvParameter.DisplayToolbar = CType(resources.GetObject("crvParameter.DisplayToolbar"), Boolean)
        Me.crvParameter.Dock = CType(resources.GetObject("crvParameter.Dock"), System.Windows.Forms.DockStyle)
        Me.crvParameter.Enabled = CType(resources.GetObject("crvParameter.Enabled"), Boolean)
        Me.crvParameter.EnableDrillDown = CType(resources.GetObject("crvParameter.EnableDrillDown"), Boolean)
        Me.crvParameter.Font = CType(resources.GetObject("crvParameter.Font"), System.Drawing.Font)
        Me.crvParameter.ImeMode = CType(resources.GetObject("crvParameter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.crvParameter.Location = CType(resources.GetObject("crvParameter.Location"), System.Drawing.Point)
        Me.crvParameter.Name = "crvParameter"
        Me.crvParameter.ReportSource = Nothing
        Me.crvParameter.RightToLeft = CType(resources.GetObject("crvParameter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.crvParameter.ShowCloseButton = CType(resources.GetObject("crvParameter.ShowCloseButton"), Boolean)
        Me.crvParameter.ShowExportButton = CType(resources.GetObject("crvParameter.ShowExportButton"), Boolean)
        Me.crvParameter.ShowGotoPageButton = CType(resources.GetObject("crvParameter.ShowGotoPageButton"), Boolean)
        Me.crvParameter.ShowGroupTreeButton = CType(resources.GetObject("crvParameter.ShowGroupTreeButton"), Boolean)
        Me.crvParameter.ShowPageNavigateButtons = CType(resources.GetObject("crvParameter.ShowPageNavigateButtons"), Boolean)
        Me.crvParameter.ShowPrintButton = CType(resources.GetObject("crvParameter.ShowPrintButton"), Boolean)
        Me.crvParameter.ShowRefreshButton = CType(resources.GetObject("crvParameter.ShowRefreshButton"), Boolean)
        Me.crvParameter.ShowTextSearchButton = CType(resources.GetObject("crvParameter.ShowTextSearchButton"), Boolean)
        Me.crvParameter.ShowZoomButton = CType(resources.GetObject("crvParameter.ShowZoomButton"), Boolean)
        Me.crvParameter.Size = CType(resources.GetObject("crvParameter.Size"), System.Drawing.Size)
        Me.crvParameter.TabIndex = CType(resources.GetObject("crvParameter.TabIndex"), Integer)
        Me.crvParameter.Visible = CType(resources.GetObject("crvParameter.Visible"), Boolean)
        '
        'tpGraphDrillDownReport
        '
        Me.tpGraphDrillDownReport.AccessibleDescription = CType(resources.GetObject("tpGraphDrillDownReport.AccessibleDescription"), String)
        Me.tpGraphDrillDownReport.AccessibleName = CType(resources.GetObject("tpGraphDrillDownReport.AccessibleName"), String)
        Me.tpGraphDrillDownReport.Anchor = CType(resources.GetObject("tpGraphDrillDownReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpGraphDrillDownReport.AutoScroll = CType(resources.GetObject("tpGraphDrillDownReport.AutoScroll"), Boolean)
        Me.tpGraphDrillDownReport.AutoScrollMargin = CType(resources.GetObject("tpGraphDrillDownReport.AutoScrollMargin"), System.Drawing.Size)
        Me.tpGraphDrillDownReport.AutoScrollMinSize = CType(resources.GetObject("tpGraphDrillDownReport.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpGraphDrillDownReport.BackgroundImage = CType(resources.GetObject("tpGraphDrillDownReport.BackgroundImage"), System.Drawing.Image)
        Me.tpGraphDrillDownReport.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnPreviewDrillDownReport, Me.crvGraphDrillDown})
        Me.tpGraphDrillDownReport.Dock = CType(resources.GetObject("tpGraphDrillDownReport.Dock"), System.Windows.Forms.DockStyle)
        Me.tpGraphDrillDownReport.Enabled = CType(resources.GetObject("tpGraphDrillDownReport.Enabled"), Boolean)
        Me.tpGraphDrillDownReport.Font = CType(resources.GetObject("tpGraphDrillDownReport.Font"), System.Drawing.Font)
        Me.tpGraphDrillDownReport.ImageIndex = CType(resources.GetObject("tpGraphDrillDownReport.ImageIndex"), Integer)
        Me.tpGraphDrillDownReport.ImeMode = CType(resources.GetObject("tpGraphDrillDownReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpGraphDrillDownReport.Location = CType(resources.GetObject("tpGraphDrillDownReport.Location"), System.Drawing.Point)
        Me.tpGraphDrillDownReport.Name = "tpGraphDrillDownReport"
        Me.tpGraphDrillDownReport.RightToLeft = CType(resources.GetObject("tpGraphDrillDownReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpGraphDrillDownReport.Size = CType(resources.GetObject("tpGraphDrillDownReport.Size"), System.Drawing.Size)
        Me.tpGraphDrillDownReport.TabIndex = CType(resources.GetObject("tpGraphDrillDownReport.TabIndex"), Integer)
        Me.tpGraphDrillDownReport.Text = resources.GetString("tpGraphDrillDownReport.Text")
        Me.tpGraphDrillDownReport.ToolTipText = resources.GetString("tpGraphDrillDownReport.ToolTipText")
        Me.tpGraphDrillDownReport.Visible = CType(resources.GetObject("tpGraphDrillDownReport.Visible"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = CType(resources.GetObject("Label3.AccessibleDescription"), String)
        Me.Label3.AccessibleName = CType(resources.GetObject("Label3.AccessibleName"), String)
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = CType(resources.GetObject("Label3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label3.ImageIndex = CType(resources.GetObject("Label3.ImageIndex"), Integer)
        Me.Label3.ImeMode = CType(resources.GetObject("Label3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.Point)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = CType(resources.GetObject("Label3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label3.Size = CType(resources.GetObject("Label3.Size"), System.Drawing.Size)
        Me.Label3.TabIndex = CType(resources.GetObject("Label3.TabIndex"), Integer)
        Me.Label3.Text = resources.GetString("Label3.Text")
        Me.Label3.TextAlign = CType(resources.GetObject("Label3.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label3.Visible = CType(resources.GetObject("Label3.Visible"), Boolean)
        '
        'btnPreviewDrillDownReport
        '
        Me.btnPreviewDrillDownReport.AccessibleDescription = resources.GetString("btnPreviewDrillDownReport.AccessibleDescription")
        Me.btnPreviewDrillDownReport.AccessibleName = resources.GetString("btnPreviewDrillDownReport.AccessibleName")
        Me.btnPreviewDrillDownReport.Anchor = CType(resources.GetObject("btnPreviewDrillDownReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPreviewDrillDownReport.BackgroundImage = CType(resources.GetObject("btnPreviewDrillDownReport.BackgroundImage"), System.Drawing.Image)
        Me.btnPreviewDrillDownReport.Dock = CType(resources.GetObject("btnPreviewDrillDownReport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPreviewDrillDownReport.Enabled = CType(resources.GetObject("btnPreviewDrillDownReport.Enabled"), Boolean)
        Me.btnPreviewDrillDownReport.FlatStyle = CType(resources.GetObject("btnPreviewDrillDownReport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPreviewDrillDownReport.Font = CType(resources.GetObject("btnPreviewDrillDownReport.Font"), System.Drawing.Font)
        Me.btnPreviewDrillDownReport.Image = CType(resources.GetObject("btnPreviewDrillDownReport.Image"), System.Drawing.Image)
        Me.btnPreviewDrillDownReport.ImageAlign = CType(resources.GetObject("btnPreviewDrillDownReport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewDrillDownReport.ImageIndex = CType(resources.GetObject("btnPreviewDrillDownReport.ImageIndex"), Integer)
        Me.btnPreviewDrillDownReport.ImeMode = CType(resources.GetObject("btnPreviewDrillDownReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPreviewDrillDownReport.Location = CType(resources.GetObject("btnPreviewDrillDownReport.Location"), System.Drawing.Point)
        Me.btnPreviewDrillDownReport.Name = "btnPreviewDrillDownReport"
        Me.btnPreviewDrillDownReport.RightToLeft = CType(resources.GetObject("btnPreviewDrillDownReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPreviewDrillDownReport.Size = CType(resources.GetObject("btnPreviewDrillDownReport.Size"), System.Drawing.Size)
        Me.btnPreviewDrillDownReport.TabIndex = CType(resources.GetObject("btnPreviewDrillDownReport.TabIndex"), Integer)
        Me.btnPreviewDrillDownReport.Text = resources.GetString("btnPreviewDrillDownReport.Text")
        Me.btnPreviewDrillDownReport.TextAlign = CType(resources.GetObject("btnPreviewDrillDownReport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPreviewDrillDownReport.Visible = CType(resources.GetObject("btnPreviewDrillDownReport.Visible"), Boolean)
        '
        'crvGraphDrillDown
        '
        Me.crvGraphDrillDown.AccessibleDescription = CType(resources.GetObject("crvGraphDrillDown.AccessibleDescription"), String)
        Me.crvGraphDrillDown.AccessibleName = CType(resources.GetObject("crvGraphDrillDown.AccessibleName"), String)
        Me.crvGraphDrillDown.ActiveViewIndex = -1
        Me.crvGraphDrillDown.Anchor = CType(resources.GetObject("crvGraphDrillDown.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.crvGraphDrillDown.AutoScroll = CType(resources.GetObject("crvGraphDrillDown.AutoScroll"), Boolean)
        Me.crvGraphDrillDown.AutoScrollMargin = CType(resources.GetObject("crvGraphDrillDown.AutoScrollMargin"), System.Drawing.Size)
        Me.crvGraphDrillDown.AutoScrollMinSize = CType(resources.GetObject("crvGraphDrillDown.AutoScrollMinSize"), System.Drawing.Size)
        Me.crvGraphDrillDown.BackgroundImage = CType(resources.GetObject("crvGraphDrillDown.BackgroundImage"), System.Drawing.Image)
        Me.crvGraphDrillDown.DisplayBackgroundEdge = CType(resources.GetObject("crvGraphDrillDown.DisplayBackgroundEdge"), Boolean)
        Me.crvGraphDrillDown.DisplayGroupTree = CType(resources.GetObject("crvGraphDrillDown.DisplayGroupTree"), Boolean)
        Me.crvGraphDrillDown.DisplayToolbar = CType(resources.GetObject("crvGraphDrillDown.DisplayToolbar"), Boolean)
        Me.crvGraphDrillDown.Dock = CType(resources.GetObject("crvGraphDrillDown.Dock"), System.Windows.Forms.DockStyle)
        Me.crvGraphDrillDown.Enabled = CType(resources.GetObject("crvGraphDrillDown.Enabled"), Boolean)
        Me.crvGraphDrillDown.EnableDrillDown = CType(resources.GetObject("crvGraphDrillDown.EnableDrillDown"), Boolean)
        Me.crvGraphDrillDown.Font = CType(resources.GetObject("crvGraphDrillDown.Font"), System.Drawing.Font)
        Me.crvGraphDrillDown.ImeMode = CType(resources.GetObject("crvGraphDrillDown.ImeMode"), System.Windows.Forms.ImeMode)
        Me.crvGraphDrillDown.Location = CType(resources.GetObject("crvGraphDrillDown.Location"), System.Drawing.Point)
        Me.crvGraphDrillDown.Name = "crvGraphDrillDown"
        Me.crvGraphDrillDown.ReportSource = Nothing
        Me.crvGraphDrillDown.RightToLeft = CType(resources.GetObject("crvGraphDrillDown.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.crvGraphDrillDown.ShowCloseButton = CType(resources.GetObject("crvGraphDrillDown.ShowCloseButton"), Boolean)
        Me.crvGraphDrillDown.ShowExportButton = CType(resources.GetObject("crvGraphDrillDown.ShowExportButton"), Boolean)
        Me.crvGraphDrillDown.ShowGotoPageButton = CType(resources.GetObject("crvGraphDrillDown.ShowGotoPageButton"), Boolean)
        Me.crvGraphDrillDown.ShowGroupTreeButton = CType(resources.GetObject("crvGraphDrillDown.ShowGroupTreeButton"), Boolean)
        Me.crvGraphDrillDown.ShowPageNavigateButtons = CType(resources.GetObject("crvGraphDrillDown.ShowPageNavigateButtons"), Boolean)
        Me.crvGraphDrillDown.ShowPrintButton = CType(resources.GetObject("crvGraphDrillDown.ShowPrintButton"), Boolean)
        Me.crvGraphDrillDown.ShowRefreshButton = CType(resources.GetObject("crvGraphDrillDown.ShowRefreshButton"), Boolean)
        Me.crvGraphDrillDown.ShowTextSearchButton = CType(resources.GetObject("crvGraphDrillDown.ShowTextSearchButton"), Boolean)
        Me.crvGraphDrillDown.ShowZoomButton = CType(resources.GetObject("crvGraphDrillDown.ShowZoomButton"), Boolean)
        Me.crvGraphDrillDown.Size = CType(resources.GetObject("crvGraphDrillDown.Size"), System.Drawing.Size)
        Me.crvGraphDrillDown.TabIndex = CType(resources.GetObject("crvGraphDrillDown.TabIndex"), Integer)
        Me.crvGraphDrillDown.Visible = CType(resources.GetObject("crvGraphDrillDown.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.tpReportBasic.ResumeLayout(False)
        Me.tpDynamicFormatReport.ResumeLayout(False)
        Me.tpParameterReport.ResumeLayout(False)
        Me.tpGraphDrillDownReport.ResumeLayout(False)
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

    Private Sub btnPreviewBasicReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewBasicReport.Click
        ' In this event the Ten Most Expensive Products Report is loaded 
        ' and displayed in the crystal reports viewer.

        ' Objects used to set the proper database connection information
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        ' Create a report document instance to hold the report
        Dim rptExpensiveProducts As New ReportDocument()

        Try
            ' Load the report
            rptExpensiveProducts.Load("..\TenMostExpensiveProducts.rpt")

            ' Set the connection information for all the tables used in the report
            ' Leave UserID and Password blank for trusted connection
            For Each tbCurrent In rptExpensiveProducts.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = ServerName
                    .UserID = ""
                    .Password = ""
                    .DatabaseName = "Northwind"
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            ' Set the report source for the crystal reports 
            ' viewer to the report instance.
            crvBasic.ReportSource = rptExpensiveProducts

            ' Zoom viewer to fit to the whole page so the user can see the report
            crvBasic.Zoom(2)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub btnPreviewCustomerReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewCustomerReport.Click
        ' In this event the Customer Orders Report is loaded 
        ' and displayed in the crystal reports viewer.
        ' This report calls for a parameter which is pulled
        ' from the customer name combo box (cbCustomers).

        ' Objects used to set the parameters in the report
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()

        ' Objects used to set the proper database connection information
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        ' Create a report document instance to hold the report
        Dim rptCustomersOrders As New ReportDocument()

        Try
            ' Load the report
            rptCustomersOrders.Load("..\CustomerOrders.rpt")

            ' Set the connection information for all the tables used in the report
            ' Leave UserID and Password blank for trusted connection
            For Each tbCurrent In rptCustomersOrders.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = ServerName
                    .UserID = ""
                    .Password = ""
                    .DatabaseName = "Northwind"
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            ' Set the discreet value to the customers name.
            pdvCustomerName.Value = cbCustomers.Text

            ' Add it to the parameter collection.
            pvCollection.Add(pdvCustomerName)

            ' Apply the current parameter values.
            rptCustomersOrders.DataDefinition.ParameterFields("@CustomerName").ApplyCurrentValues(pvCollection)

            ' Hide group tree for this report
            crvParameter.DisplayGroupTree = False

            ' Set the report source for the crystal reports viewer to the 
            ' report instance.
            crvParameter.ReportSource = rptCustomersOrders

            ' Zoom viewer to fit to the whole page so the user can see the report
            crvParameter.Zoom(2)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub btnPreviewDrillDownReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewDrillDownReport.Click
        ' In this event the Top 5 Products Sold Report is loaded 
        ' and displayed in the crystal reports viewer.
        ' This Report has a graph which can be used to drill down to the detail
        ' of the report.

        ' Create a report document instance to hold the report
        Dim rptDrillDown As New ReportDocument()

        ' Objects used to set the proper database connection information
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        Try
            ' Load the report
            rptDrillDown.Load("..\Top5ProductsSold.rpt")

            ' Set the connection information for all the tables used in the report
            ' Leave UserID and Password blank for trusted connection
            For Each tbCurrent In rptDrillDown.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = ServerName
                    .UserID = ""
                    .Password = ""
                    .DatabaseName = "Northwind"
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            ' Set the report source for the crystal reports viewer to 
            ' the report instance.
            crvGraphDrillDown.ReportSource = rptDrillDown

            ' Hide group tree for this report
            crvParameter.DisplayGroupTree = False

            ' Zoom viewer to fit to the whole page so the user can see the report
            crvGraphDrillDown.Zoom(2)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnPreviewDynamicReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewDynamicReport.Click
        ' In this event the All Customers Orders Report is loaded 
        ' and displayed in the crystal reports viewer.  On this report
        ' the user can set a unit price and a color.  These parameters
        ' are passed into the report to determine if a row is highlighted
        ' in the selected color.  During the design of the report
        ' a formula was added to the details section which controls
        ' background color.  The formula says that if the unit price is
        ' greater than the value passed in then that detail lines background
        ' color will be the color passed in else no color.

        ' This report is also a landscape report.  Inorder to display and print 
        ' a landscape report correctly a report document object must be created at 
        ' runtime and the report then needs to be assigned to
        ' it.  This is an error in Crystal and more information can be
        ' found at:  
        ' http://support.crystaldecisions/library/kbase/articles/c2011099.asp

        ' Create a report document instance to hold the report
        Dim rptAllCustomersOrders As New ReportDocument()

        ' Objects used to set the parameters in the report
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvColor As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvUnitPrice As New CrystalDecisions.Shared.ParameterDiscreteValue()

        ' Objects used to set the proper database connection information
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        ' Set the proper values for the colors
        Dim red As Integer = RGB(255, 0, 0)
        Dim green As Integer = RGB(0, 255, 0)
        Dim blue As Integer = RGB(0, 0, 255)

        If Not IsNumeric(txtUnitsToHighlight.Text) Then
            MsgBox("Please enter a number into the unit price text box.", _
                    MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Try
            ' Load the report
            rptAllCustomersOrders.Load("..\AllCustomersOrders.rpt")

            ' Set the connection information for all the tables used in the report
            ' Leave UserID and Password blank for trusted connection
            For Each tbCurrent In rptAllCustomersOrders.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = ServerName
                    .UserID = ""
                    .Password = ""
                    .DatabaseName = "Northwind"
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            ' Set the discreet value to the selected color.
            Select Case cbHighlightColor.Text
                Case "Red"
                    pdvColor.Value = red
                Case "Green"
                    pdvColor.Value = green
                Case "Blue"
                    pdvColor.Value = blue
            End Select

            ' Set the discreet value to the Unit Price.
            pdvUnitPrice.Value = CInt(txtUnitsToHighlight.Text)

            ' Add the color value to the parameter collection.
            pvCollection.Add(pdvColor)

            ' Apply the color parameter value.
            rptAllCustomersOrders.DataDefinition.ParameterFields("ColorToHighlight").ApplyCurrentValues(pvCollection)

            ' Clear for next parameter
            pvCollection.Clear()

            ' Add the unit price value to the parameter collection.
            pvCollection.Add(pdvUnitPrice)

            ' Apply the unit price parameter value.
            rptAllCustomersOrders.DataDefinition.ParameterFields("PriceToCheck").ApplyCurrentValues(pvCollection)

            ' Show group tree for this report
            crvDynamicFormat.DisplayGroupTree = True

            ' Set the report source for the crystal reports viewer to 
            ' the report instance.
            crvDynamicFormat.ReportSource = rptAllCustomersOrders

            ' Zoom viewer to fit whole page so the user can see the report
            crvDynamicFormat.Zoom(2)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
End Class
