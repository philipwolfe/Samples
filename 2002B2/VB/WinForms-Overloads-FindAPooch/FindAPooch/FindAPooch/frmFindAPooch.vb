Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports PoochObjects.Pooch

Public Class frmFindAPooch
    Inherits System.Windows.Forms.Form
    Private Const ALL_BREEDS As Long = 0
    Public Sub New()
        MyBase.New()
        
        frmFindAPooch = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
        
        Dim objPooch As New clsPoochData()
        Dim ds As New DataSet()
        Dim dt As New DataTable()

        'We're setting the datasource for the Breed combo box to a datatable
        'returned by the GetBreedList method on the objPooch(clsPoochLogic)
        'object and then setting the member of the datasource(table) we want 
        'to display.
        With Me.cboBreed
            ds = objPooch.BrowseByBreed()
            dt = ds.Tables("breeds")
            .DataSource = dt
            
            .DisplayMember = "breeddesc"
        End With
        
        'Set the default control values.
        Me.txtCity.Text = ""
        Me.txtState.Text = ""
        Me.cboBreed.SelectedIndex = 0
        
        'Release object reference.
        objPooch = Nothing
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cboBreed As System.Windows.Forms.ComboBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtState As System.Windows.Forms.TextBox
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents cmdSearch As System.Windows.Forms.Button
    Private WithEvents cmdAdopt As System.Windows.Forms.Button
    Dim WithEvents frmFindAPooch As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBreed = New System.Windows.Forms.ComboBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAdopt = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtCity = New System.Windows.Forms.TextBox()

        DataGrid1.BeginInit()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtState.Location = New System.Drawing.Point(288, 32)
        txtState.TabIndex = 3
        txtState.Size = New System.Drawing.Size(48, 20)

        GroupBox1.Location = New System.Drawing.Point(32, 8)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        GroupBox1.Size = New System.Drawing.Size(328, 88)

        Label2.Location = New System.Drawing.Point(240, 32)
        Label2.Text = "State:"
        Label2.Size = New System.Drawing.Size(40, 16)
        Label2.TabIndex = 6
        Label2.TextAlign = ContentAlignment.MiddleRight

        Label1.Location = New System.Drawing.Point(48, 32)
        Label1.Text = "City:"
        Label1.Size = New System.Drawing.Size(40, 16)
        Label1.TabIndex = 5
        Label1.TextAlign = ContentAlignment.MiddleRight

        cboBreed.Location = New System.Drawing.Point(96, 64)
        cboBreed.Size = New System.Drawing.Size(136, 21)
        cboBreed.TabIndex = 8

        DataGrid1.Location = New System.Drawing.Point(8, 112)
        DataGrid1.ReadOnly = True
        DataGrid1.Size = New System.Drawing.Size(376, 216)
        DataGrid1.DataMember = ""
        DataGrid1.CaptionText = "Available Pooches:"
        DataGrid1.TabIndex = 10

        Label3.Location = New System.Drawing.Point(48, 64)
        Label3.Text = "Breed:"
        Label3.Size = New System.Drawing.Size(40, 16)
        Label3.TabIndex = 7
        Label3.TextAlign = ContentAlignment.MiddleRight

        cmdAdopt.Location = New System.Drawing.Point(157, 344)
        cmdAdopt.Size = New System.Drawing.Size(75, 23)
        cmdAdopt.TabIndex = 0
        cmdAdopt.Text = "Adopt"

        cmdSearch.Location = New System.Drawing.Point(264, 64)
        cmdSearch.Size = New System.Drawing.Size(75, 23)
        cmdSearch.TabIndex = 1
        cmdSearch.Text = "Search"

        txtCity.Location = New System.Drawing.Point(96, 32)
        txtCity.TabIndex = 2
        txtCity.Size = New System.Drawing.Size(136, 20)
        Me.Text = "Find A Pooch"
        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.ClientSize = New System.Drawing.Size(390, 379)

        Me.Controls.Add(DataGrid1)
        Me.Controls.Add(cboBreed)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtState)
        Me.Controls.Add(txtCity)
        Me.Controls.Add(cmdSearch)
        Me.Controls.Add(cmdAdopt)
        Me.Controls.Add(GroupBox1)

        DataGrid1.EndInit()
    End Sub

#End Region

    Protected Sub cmdAdopt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdopt.Click
        Dim intAnsr As Microsoft.VisualBasic.MsgBoxResult
        Dim strMsg As String

        'Display a messagebox containing the name of the
        'pooch that was selected in the datagrid.
        strMsg = "Your new best friend is " & Me.DataGrid1(Me.DataGrid1.CurrentCell.RowNumber, 0).ToString & "!"
        intAnsr = MsgBox(strMsg, Microsoft.VisualBasic.MsgBoxStyle.Information, "Adopt")
    End Sub

    Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim ds As DataSet
        Dim dt As DataTable

        Dim row As DataRow
        Dim objPooch As clsPoochData
        Dim strBreed As String

        'Call a method in the PoochData Class to return data
        objPooch = New clsPoochData()

        'Here we're determining which parameters are valid,
        'sending them to the corresponding overloaded
        'Browse method on the objPooch(clsPoochData) object,
        'and then assigning the returned dataset to GetPooches.

        If txtCity.Text = "" And txtState.Text <> "" And CLng(Me.cboBreed.SelectedIndex) <= 0 Then
            'Get pooches by state.
            ds = objPooch.BrowseByState(txtState.Text)
        ElseIf txtCity.Text <> "" And txtState.Text <> "" And CLng(Me.cboBreed.SelectedIndex) <= 0 Then
            'Get pooches by state and city.
            ds = objPooch.BrowseByState(txtState.Text, txtCity.Text)
        ElseIf txtCity.Text = "" And txtState.Text <> "" And CLng(Me.cboBreed.SelectedIndex) > 0 Then
            'Get pooches by breed and state
            ds = objPooch.BrowseByState(txtState.Text, CLng(Me.cboBreed.SelectedIndex))
        ElseIf txtCity.Text <> "" And txtState.Text <> "" And CLng(Me.cboBreed.SelectedIndex) > 0 Then
            'Get pooches by breed, state, and city
            ds = objPooch.BrowseByState(txtState.Text, txtCity.Text, CLng(Me.cboBreed.SelectedIndex))
        ElseIf txtCity.Text <> "" And txtState.Text = "" And CLng(Me.cboBreed.SelectedIndex) <= 0 Then
            'Get pooches by city.
            ds = objPooch.BrowseByCity(txtCity.Text)
        ElseIf txtCity.Text <> "" And txtState.Text = "" And CLng(Me.cboBreed.SelectedIndex) > 0 Then
            'Get pooches by breed and city
            ds = objPooch.BrowseByCity(Me.txtCity.Text, CLng(Me.cboBreed.SelectedIndex))
        ElseIf txtCity.Text = "" And txtState.Text = "" And CLng(Me.cboBreed.SelectedIndex) > 0 Then
            'Get pooches by breed.
            ds = objPooch.BrowseByBreed(CLng(Me.cboBreed.SelectedIndex))
        Else
            'Get all of the pooches.
            ds = objPooch.BrowseByBreed(ALL_BREEDS)
        End If

        objPooch = Nothing

        'Set the datasource of the data grid control
        'to the dataset we just retrieved. Set the 
        'datamember(table) to the "dogs" table.

        Me.DataGrid1.DataSource = ds.Tables(0)


    End Sub



End Class
