'*****************************************************************************
'VB.NET Beta 1
'ADO 2.6 Interop Sample Application - User Interface
'02/19/2001
'*****************************************************************************
' Note: The application uses an Access Database located in the bin directory 
'of the project files.
'*****************************************************************************

Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmADOInterOp
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
        
        'load the list of names in the combo box
        loadNames()
        
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lblPhone As System.Windows.Forms.Label
    Private WithEvents lblZip As System.Windows.Forms.Label

    Private WithEvents lblState As System.Windows.Forms.Label
    Private WithEvents lblCity As System.Windows.Forms.Label
    Private WithEvents lblStreet As System.Windows.Forms.Label
    Private WithEvents txtPhone As System.Windows.Forms.TextBox
    Private WithEvents txtZip As System.Windows.Forms.TextBox
    Private WithEvents txtState As System.Windows.Forms.TextBox
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents txtStreet As System.Windows.Forms.TextBox

    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents cmbName As System.Windows.Forms.ComboBox

    Dim WithEvents frmADOInterOp As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmbName.Location = New System.Drawing.Point(8, 24)
        cmbName.Size = New System.Drawing.Size(256, 21)
        cmbName.TabIndex = 0

        txtStreet.Location = New System.Drawing.Point(8, 72)
        txtStreet.TabIndex = 3
        txtStreet.Size = New System.Drawing.Size(256, 20)

        txtCity.Location = New System.Drawing.Point(8, 120)
        txtCity.TabIndex = 4
        txtCity.Size = New System.Drawing.Size(100, 20)

        lblZip.Location = New System.Drawing.Point(160, 104)
        lblZip.Text = "Zip"
        lblZip.Size = New System.Drawing.Size(100, 16)
        lblZip.TabIndex = 11

        txtState.Location = New System.Drawing.Point(120, 120)
        txtState.TabIndex = 5
        txtState.Size = New System.Drawing.Size(32, 20)

        txtPhone.Location = New System.Drawing.Point(8, 168)
        txtPhone.TabIndex = 7
        txtPhone.Size = New System.Drawing.Size(100, 20)

        lblCity.Location = New System.Drawing.Point(8, 104)
        lblCity.Text = "City"
        lblCity.Size = New System.Drawing.Size(100, 16)
        lblCity.TabIndex = 9

        lblPhone.Location = New System.Drawing.Point(8, 152)
        lblPhone.Text = "Phone"
        lblPhone.Size = New System.Drawing.Size(100, 16)
        lblPhone.TabIndex = 12

        lblState.Location = New System.Drawing.Point(120, 104)
        lblState.Text = "State"
        lblState.Size = New System.Drawing.Size(32, 16)
        lblState.TabIndex = 10

        lblStreet.Location = New System.Drawing.Point(8, 56)
        lblStreet.Text = "Street"
        lblStreet.Size = New System.Drawing.Size(100, 16)
        lblStreet.TabIndex = 8

        lblName.Location = New System.Drawing.Point(8, 8)
        lblName.Text = "Name"
        lblName.Size = New System.Drawing.Size(272, 16)
        lblName.TabIndex = 1

        txtZip.Location = New System.Drawing.Point(160, 120)
        txtZip.TabIndex = 6
        txtZip.Size = New System.Drawing.Size(100, 20)
        Me.Text = "ADO 2.6 InterOp Address Book"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(272, 229)

        Me.Controls.Add(lblPhone)
        Me.Controls.Add(lblZip)
        Me.Controls.Add(lblState)
        Me.Controls.Add(lblCity)
        Me.Controls.Add(lblStreet)
        Me.Controls.Add(txtPhone)
        Me.Controls.Add(txtZip)
        Me.Controls.Add(txtState)
        Me.Controls.Add(txtCity)
        Me.Controls.Add(txtStreet)
        Me.Controls.Add(lblName)
        Me.Controls.Add(cmbName)
    End Sub

#End Region

    Private Sub LoadNames()
        Dim Names As New ADODB.Recordset()
        Dim Address As New Address()

        'Call the GetName Methods from clsAddress to get a list of names from the database.
        Names = Address.GetName

        'Populate the Name Combo Box
        With Me.cmbName
            Do Until Names.EOF = True
                .Items.Add(Names.Fields("Name").Value)
                Names.MoveNext()
            Loop
        End With

        'Set the default textbox values.
        Me.txtStreet.Text = ""
        Me.txtCity.Text = ""
        Me.txtState.Text = ""
        Me.txtZip.Text = ""
        Me.txtPhone.Text = ""

        'Release object reference.
        Names = Nothing
        Address = Nothing

    End Sub

    'When name combo box changes value retrieve new adress data
    Protected Sub cmbName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbName.SelectedIndexChanged
        Dim Addresses As New ADODB.Recordset()
        Dim Address As New Address()
        'Call GetAddress method and using selected combo box name as Name parameter of method
        Addresses = Address.GetAddress(cmbName.Text)

        'Set the textbox values to the reAddress values
        Me.txtStreet.Text = CStr(Addresses.Fields("Street").Value)
        Me.txtCity.Text = CStr(Addresses.Fields("City").Value)
        Me.txtState.Text = CStr(Addresses.Fields("State").Value)
        Me.txtZip.Text = CStr(Addresses.Fields("Zip").Value)
        Me.txtPhone.Text = CStr(Addresses.Fields("Phone").Value)

        'Release object reference.
        Addresses = Nothing
        Address = Nothing

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class
