
Imports System
Imports System.Drawing
Imports system.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits System.Windows.Forms.Form
    Public objGrap As System.Drawing.Graphics

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
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
    Private components As System.ComponentModel.Container
    Private WithEvents LaserButton As System.Windows.Forms.Button
        Private WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Private MainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Private WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
        Private WithEvents TextBox7 As System.Windows.Forms.TextBox
    Private WithEvents TextBox3 As System.Windows.Forms.TextBox
        Private WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Private WithEvents DataSet2 As System.Data.DataSet
    Private WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Private WithEvents DataSet1 As System.Data.DataSet
    Private WithEvents ComboBox1 As System.Windows.Forms.ComboBox
        Private WithEvents TextBox6 As System.Windows.Forms.TextBox
    Private WithEvents TextBox5 As System.Windows.Forms.TextBox
    Private WithEvents TextBox4 As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
        Private WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents TabPage1 As System.Windows.Forms.TabPage
        Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents FindButton As System.Windows.Forms.Button
    Private WithEvents DisplayButton As System.Windows.Forms.Button
    Private WithEvents CloseButton As System.Windows.Forms.Button
    Private WithEvents CensusFindButton As System.Windows.Forms.Button
    Private WithEvents SatellitePictureBox As System.Windows.Forms.PictureBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DisplayButton = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.DataGrid2 = New System.Windows.Forms.DataGrid()
        Me.DataSet2 = New System.Data.DataSet()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataSet1 = New System.Data.DataSet()
        Me.SatellitePictureBox = New System.Windows.Forms.PictureBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CensusFindButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.LaserButton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FindButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox3
        '
        Me.ComboBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBox3.DropDownWidth = 144
        Me.ComboBox3.Items.AddRange(New Object() {"Scale 1m", "Scale 2m", "Scale 4m", "Scale 8m", "Scale 16m", "Scale 32m", "Scale 64m", "Scale 128m"})
        Me.ComboBox3.Location = New System.Drawing.Point(384, 286)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(144, 28)
        Me.ComboBox3.TabIndex = 6
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBox2.DropDownWidth = 144
        Me.ComboBox2.Items.AddRange(New Object() {"Satellite Photo", "Topographical Map", "Relief Map"})
        Me.ComboBox2.Location = New System.Drawing.Point(384, 246)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(144, 28)
        Me.ComboBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownWidth = 160
        Me.ComboBox1.Items.AddRange(New Object() {"CensusTract", "City", "County", "State", "Unknown"})
        Me.ComboBox1.Location = New System.Drawing.Point(144, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 28)
        Me.ComboBox1.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.CheckBox1.Location = New System.Drawing.Point(232, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 40)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Image Presence"
        '
        'DisplayButton
        '
        Me.DisplayButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DisplayButton.Location = New System.Drawing.Point(552, 246)
        Me.DisplayButton.Name = "DisplayButton"
        Me.DisplayButton.Size = New System.Drawing.Size(75, 32)
        Me.DisplayButton.TabIndex = 7
        Me.DisplayButton.Text = "Display"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.TextBox2.Location = New System.Drawing.Point(120, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(96, 26)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox3.Location = New System.Drawing.Point(112, 246)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(256, 26)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.TextBox1.Location = New System.Drawing.Point(120, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(432, 26)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(144, 104)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(160, 26)
        Me.TextBox6.TabIndex = 7
        Me.TextBox6.Text = ""
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox7.Location = New System.Drawing.Point(112, 286)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(256, 26)
        Me.TextBox7.TabIndex = 4
        Me.TextBox7.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(144, 40)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(160, 26)
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(144, 72)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(160, 26)
        Me.TextBox5.TabIndex = 5
        Me.TextBox5.Text = ""
        '
        'DataGrid2
        '
        Me.DataGrid2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.DataSource = Me.DataSet2
        Me.DataGrid2.Location = New System.Drawing.Point(312, -5)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(336, 336)
        Me.DataGrid2.TabIndex = 10
        Me.DataGrid2.Visible = False
        '
        'DataSet2
        '
        Me.DataSet2.DataSetName = "NewDataSet"
        Me.DataSet2.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.DataSource = Me.DataSet1
        Me.DataGrid1.Location = New System.Drawing.Point(8, 96)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 150
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(640, 248)
        Me.DataGrid1.TabIndex = 6
        Me.DataGrid1.Visible = False
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'SatellitePictureBox
        '
        Me.SatellitePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SatellitePictureBox.Location = New System.Drawing.Point(8, -18)
        Me.SatellitePictureBox.Name = "SatellitePictureBox"
        Me.SatellitePictureBox.Size = New System.Drawing.Size(640, 248)
        Me.SatellitePictureBox.TabIndex = 0
        Me.SatellitePictureBox.TabStop = False
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.CloseButton.Location = New System.Drawing.Point(592, 400)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(80, 32)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "Close"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.Location = New System.Drawing.Point(24, 286)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Longitude:"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem1.Text = "&File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "E&xit"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Name:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Parent Name:"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Year:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid2, Me.ComboBox1, Me.CensusFindButton, Me.TextBox6, Me.TextBox5, Me.TextBox4, Me.Label6, Me.Label5, Me.Label4, Me.Label3})
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(656, 376)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Census"
        '
        'CensusFindButton
        '
        Me.CensusFindButton.Location = New System.Drawing.Point(184, 144)
        Me.CensusFindButton.Name = "CensusFindButton"
        Me.CensusFindButton.Size = New System.Drawing.Size(80, 32)
        Me.CensusFindButton.TabIndex = 9
        Me.CensusFindButton.Text = "Find"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Political Unit:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.LaserButton, Me.ComboBox3, Me.ComboBox2, Me.Label8, Me.Label7, Me.DisplayButton, Me.TextBox7, Me.TextBox3, Me.SatellitePictureBox})
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(656, 351)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Images"
        '
        'LaserButton
        '
        Me.LaserButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LaserButton.Location = New System.Drawing.Point(536, 286)
        Me.LaserButton.Name = "LaserButton"
        Me.LaserButton.Size = New System.Drawing.Size(112, 32)
        Me.LaserButton.TabIndex = 8
        Me.LaserButton.Text = "Fire ""Laser"""
        Me.LaserButton.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.Location = New System.Drawing.Point(40, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 23)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Latitude:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Place Name:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1, Me.FindButton, Me.CheckBox1, Me.TextBox2, Me.TextBox1, Me.Label2, Me.Label1})
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(656, 351)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Places"
        '
        'FindButton
        '
        Me.FindButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FindButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.FindButton.Location = New System.Drawing.Point(568, 16)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(80, 32)
        Me.FindButton.TabIndex = 5
        Me.FindButton.Text = "Find"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Max Items:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage3, Me.TabPage2})
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(664, 384)
        Me.TabControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AcceptButton = Me.FindButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(680, 441)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CloseButton, Me.TabControl1})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "TerraService Web Service Demo"
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LaserButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LaserButton.Click
        SatellitePictureBox.Cursor = New Cursor("BULLSEYE.CUR")
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        'MenuBar File | Exit clicked
        Me.Close()
    End Sub

    Private Sub CensusFindButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CensusFindButton.Click
        Try
            Dim objCensusService As New CensusService.CensusService()
            Dim objFacts As CensusService.CensusFacts
            Dim enuPU As CensusService.PoliticalUnit

            'Determine Political Unit Setting
            Select Case ComboBox1.Text
                Case "CensusTract"
                    enuPU = CensusService.PoliticalUnit.CensusTract
                Case "City"
                    enuPU = CensusService.PoliticalUnit.City
                Case "County"
                    enuPU = CensusService.PoliticalUnit.County
                Case "State"
                    enuPU = CensusService.PoliticalUnit.State
                Case Else
                    enuPU = CensusService.PoliticalUnit.Unknown
            End Select

            'Get data from CensusService Web Service
            objFacts = objCensusService.GetPoliticalUnitFactsByName(enuPU, TextBox4.Text, TextBox5.Text, CInt(Val(TextBox6.Text)))

            'Create a DataSet to display received data
            Dim DataSet2 As DataSet = New DataSet("CensusData")
            Dim tbCensus As DataTable = New DataTable("CData")  'Creates a Table to be put in DataSet
            DataSet2.Tables.Add(tbCensus)  'Adds Table to DataSet
            Dim dcProp As DataColumn = New DataColumn("Property")  'Creates a DataColumn to be put in Table
            Dim dcPValue As DataColumn = New DataColumn("Value")
            DataSet2.Tables("CData").Columns.Add(dcProp)  'Adds column to table
            DataSet2.Tables("CData").Columns.Add(dcPValue)

            'Add DataRows to table
            Dim NewRow As DataRow

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Political Unit"
            Select Case objFacts.Pu
                Case CensusService.PoliticalUnit.CensusTract
                    NewRow("Value") = "CensusTract"
                Case CensusService.PoliticalUnit.City
                    NewRow("Value") = "City"
                Case CensusService.PoliticalUnit.County
                    NewRow("Value") = "County"
                Case CensusService.PoliticalUnit.State
                    NewRow("Value") = "State"
                Case Else
                    NewRow("Value") = "Unknown"
            End Select
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Fips"
            NewRow("Value") = objFacts.Fips
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "State Fips"
            NewRow("Value") = objFacts.StateFips
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "County Fips"
            NewRow("Value") = objFacts.CountyFips
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Name"
            NewRow("Value") = objFacts.Name
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "SecondaryName"
            NewRow("Value") = objFacts.SecondaryName
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Area"
            NewRow("Value") = objFacts.Area
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Year"
            NewRow("Value") = objFacts.Year
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Population 1990"
            NewRow("Value") = objFacts.Population1990
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Population 1999"
            NewRow("Value") = objFacts.Population1999
            tbCensus.Rows.Add(NewRow)

            NewRow = tbCensus.NewRow
            NewRow("Property") = "Population 1999 per Sq. Mile"
            NewRow("Value") = objFacts.Population1990_PerSquareMile
            tbCensus.Rows.Add(NewRow)

            'Bind created dataset to DataGrid
            DataGrid2.DataSource = DataSet2
            DataGrid2.DataMember = "CData"
            DataGrid2.Visible = True

        Catch err As System.Exception
            Dim strMsg As String
            strMsg = err.Message + vbCrLf + vbCrLf + err.StackTrace
            MsgBox(strMsg)
        End Try
    End Sub

    Private Sub FindButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindButton.Click
        ' Set wait cursor
        Me.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'Create a DataSet to display received data
        Dim DataSet1 As DataSet = New DataSet("PlaceFacts")
        Dim tbPlace As DataTable = New DataTable("Place")  'Creates a Table to be put in DataSet
        DataSet1.Tables.Add(tbPlace)  'Adds Table to DataSet
        Dim dcCity As DataColumn = New DataColumn("City")  'Creates a DataColumn to be put in Table
        Dim dcState As DataColumn = New DataColumn("State")
        Dim dcCountry As DataColumn = New DataColumn("Country")
        Dim dcLat As DataColumn = New DataColumn("Latitude")
        Dim dcLon As DataColumn = New DataColumn("Longitude")
        DataSet1.Tables("Place").Columns.Add(dcCity)  'Adds column to table
        DataSet1.Tables("Place").Columns.Add(dcState)
        DataSet1.Tables("Place").Columns.Add(dcCountry)
        DataSet1.Tables("Place").Columns.Add(dcLat)
        DataSet1.Tables("Place").Columns.Add(dcLon)
        Dim NewRow As DataRow

        If LCase(Trim(TextBox1.Text)) = "oracle" Then
            NewRow = tbPlace.NewRow
            NewRow("City") = "Redwood Shores"
            NewRow("State") = "California"
            NewRow("Country") = "United States"
            NewRow("Latitude") = CDbl(37.5309)
            NewRow("Longitude") = CDbl(-122.264)
            tbPlace.Rows.Add(NewRow)
        ElseIf LCase(Trim(TextBox1.Text)) = "sun" Then
            NewRow = tbPlace.NewRow
            NewRow("City") = "Palo Alto"
            NewRow("State") = "California"
            NewRow("Country") = "United States"
            NewRow("Latitude") = CDbl(37.4257)
            NewRow("Longitude") = CDbl(-122.103)
            tbPlace.Rows.Add(NewRow)
        Else
            Try
                Dim objTerraService As New TerraService.TerraService()
                Dim aryPlaces() As TerraService.PlaceFacts
                Dim objPlace As TerraService.PlaceFacts

                'Get data from TerraService Web Service
                aryPlaces = objTerraService.GetPlaceList(TextBox1.Text, CInt(Val(TextBox2.Text)), CheckBox1.Checked)
                If aryPlaces Is Nothing Then
                    MsgBox("No data returned for current parameters.")
                    Exit Sub
                End If

                'Add DataRows to table
                For Each objPlace In aryPlaces
                    NewRow = tbPlace.NewRow
                    NewRow("City") = objPlace.Place.City
                    NewRow("State") = objPlace.Place.State
                    NewRow("Country") = objPlace.Place.Country
                    NewRow("Latitude") = CDbl(objPlace.Center.Lat)
                    NewRow("Longitude") = CDbl(objPlace.Center.Lon)
                    tbPlace.Rows.Add(NewRow)
                Next

            Catch err As System.Exception
                Dim strMsg As String
                strMsg = err.Message + vbCrLf + vbCrLf + err.StackTrace
                MsgBox(strMsg)
            End Try

        End If

        'Bind created dataset to DataGrid
        DataGrid1.DataSource = DataSet1
        DataGrid1.DataMember = "Place"
        DataGrid1.Visible = True

        Me.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        'Close Button pressed
        Me.Close()
    End Sub

    Private Function GetTheme(ByVal x As Integer) As TerraService.Theme
        Select Case x
            Case 0
                GetTheme = TerraService.Theme.Photo
            Case 1
                GetTheme = TerraService.Theme.Topo
            Case 2
                GetTheme = TerraService.Theme.Relief
            Case Else
                MsgBox("Unexpected error in function GetTheme")
        End Select
    End Function

    Private Function GetScale(ByVal x As Integer) As TerraService.Scale
        Select Case x
            Case 0
                GetScale = TerraService.Scale.Scale1m '0
            Case 1
                GetScale = TerraService.Scale.Scale2m '1
            Case 2
                GetScale = TerraService.Scale.Scale4m '2
            Case 3
                GetScale = TerraService.Scale.Scale8m '3
            Case 4
                GetScale = TerraService.Scale.Scale16m '4
            Case 5
                GetScale = TerraService.Scale.Scale32m '5
            Case 6
                GetScale = TerraService.Scale.Scale64m '6
            Case 7
                GetScale = TerraService.Scale.Scale128m '7
            Case Else
                MsgBox("Unexpected error in function GetScale")
        End Select
    End Function

    Public Sub SatellitePictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SatellitePictureBox.Click
        Dim g As Graphics
        Dim b As Brush
        Dim i As Integer
        g = SatellitePictureBox.CreateGraphics
        For i = 1 To 20
            b = New SolidBrush(Color.FromArgb(i, Color.Red))
            g.FillRectangle(b, ClientRectangle)
        Next
        SatellitePictureBox.Cursor = Nothing
    End Sub

    Public Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Me.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        TextBox3.Text = CStr(CType(DataGrid1.DataSource, DataSet).Tables("Place").Rows(CType(sender, DataGrid).CurrentCell.RowNumber).Item("Latitude"))
        ComboBox2.SelectedIndex = 0
        TextBox7.Text = CStr(CType(DataGrid1.DataSource, DataSet).Tables("Place").Rows(CType(sender, DataGrid).CurrentCell.RowNumber).Item("Longitude"))
        ComboBox3.SelectedIndex = 0
        LaserButton.Visible = True
        TabControl1.SelectedTab = TabControl1.TabPages(1)
        Me.Update()
        DisplayButton.PerformClick()
        Me.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub DisplayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayButton.Click
        Me.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If TextBox3.Text = "" Or TextBox7.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Invalid Data supplied.")
            Exit Sub
        End If
        Try
            Dim objCenter As New TerraService.LonLatPt()
            Dim intTheme As Integer
            Dim intScale As Integer
            Dim objTS As New TerraService.TerraService()
            Dim objABB As TerraService.AreaBoundingBox
            Dim tileImage As Image
            Dim intWidth As Integer
            Dim intHeight As Integer

            'Get parameter settings
            objCenter.Lat = CDbl(TextBox3.Text)
            objCenter.Lon = CDbl(TextBox7.Text)
            intWidth = SatellitePictureBox.Width
            intHeight = SatellitePictureBox.Height
            intTheme = ComboBox2.SelectedIndex
            intScale = ComboBox3.SelectedIndex

            'Get basic AreaBoundingBox from terraservice.net
            objABB = objTS.GetAreaFromPt(objCenter, GetTheme(intTheme), GetScale(intScale), intWidth, intHeight)

            Dim xStart As Integer
            Dim yStart As Integer
            Dim x As Integer
            Dim y As Integer
            objGrap = SatellitePictureBox.CreateGraphics()
            xStart = objABB.NorthWest.TileMeta.Id.X
            yStart = objABB.NorthWest.TileMeta.Id.Y

            'Get and Compose image tiles
            For x = xStart To objABB.NorthEast.TileMeta.Id.X
                For y = yStart To objABB.SouthWest.TileMeta.Id.Y Step -1
                    Dim tid As New TerraService.TileId()
                    tid = objABB.NorthWest.TileMeta.Id
                    tid.X = x
                    tid.Y = y
                    tileImage = Image.FromStream(New MemoryStream(objTS.GetTile(tid)))
                    objGrap.DrawImage(tileImage, (x - xStart) * tileImage.Width - CInt(objABB.NorthWest.Offset.XOffset), (yStart - y) * tileImage.Height - CInt(objABB.NorthWest.Offset.YOffset), tileImage.Width, tileImage.Height)
                    tileImage.Dispose()
                Next
            Next
            SatellitePictureBox.Update()

        Catch err As System.Exception
            Dim strMsg As String
            strMsg = err.Message + vbCrLf + vbCrLf + err.StackTrace
            MsgBox(strMsg)
        End Try
        Me.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set default values for TerraService Tab fields
        TextBox1.Text = "Space Needle"
        TextBox2.Text = "10"
        CheckBox1.Checked = True

        'Set default values for CensusService Tab fields
        ComboBox1.SelectedIndex = 2
        TextBox4.Text = "King"
        TextBox5.Text = "Washington"
        TextBox6.Text = "1990"

        'Set default values for Maps Tab fields

    End Sub



End Class
