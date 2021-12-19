'*****************************************************************************
'Form Inheritance Example - Child Form 2 of 3
'*****************************************************************************

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms



Public Class frmWiz2
    Inherits FIWiz.frmWizardForm

    Public Sub New()
        MyBase.New()

        frmWiz2 = Me

        'This call is required by the WinForm Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent call

        'Enable/Disable the navigation buttons according for this page
        btnCancel.Enabled = True
        btnBack.Enabled = True
        btnNext.Enabled = True
        btnFinish.Enabled = False
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the WinForm Designer
    Private Shadows components As System.ComponentModel.Container
    Private WithEvents lblZip As System.Windows.Forms.Label
    Private WithEvents lblState As System.Windows.Forms.Label
    Private WithEvents lblCity As System.Windows.Forms.Label
    Private WithEvents lblStreet As System.Windows.Forms.Label
    Private WithEvents txtZip As System.Windows.Forms.TextBox
    Private WithEvents txtState As System.Windows.Forms.TextBox
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents txtStreet As System.Windows.Forms.TextBox

    Dim WithEvents frmWiz2 As FIWiz.frmWizardForm

    'NOTE: The following procedure is required by the WinForm Designer
    'It can be modified using the WinForm Designer.  
    'Do not modify it using the code editor.
    Private Shadows Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        lblZip.Location = New System.Drawing.Point(252, 92)
        lblZip.Text = "Zip"
        lblZip.Size = New System.Drawing.Size(100, 16)
        lblZip.TabIndex = 11

        txtState.Location = New System.Drawing.Point(204, 108)
        txtState.TabIndex = 6
        txtState.Size = New System.Drawing.Size(32, 20)

        txtZip.Location = New System.Drawing.Point(252, 108)
        txtZip.TabIndex = 7
        txtZip.Size = New System.Drawing.Size(100, 20)

        txtCity.Location = New System.Drawing.Point(92, 108)
        txtCity.TabIndex = 5
        txtCity.Size = New System.Drawing.Size(100, 20)

        txtStreet.Location = New System.Drawing.Point(92, 60)
        txtStreet.TabIndex = 4
        txtStreet.Size = New System.Drawing.Size(256, 20)

        btnBack.Enabled = True

        lblStreet.Location = New System.Drawing.Point(92, 44)
        lblStreet.Text = "Street"
        lblStreet.Size = New System.Drawing.Size(256, 16)
        lblStreet.TabIndex = 8

        btnCancel.Enabled = True

        btnNext.Enabled = True

        lblState.Location = New System.Drawing.Point(204, 92)
        lblState.Text = "State"
        lblState.Size = New System.Drawing.Size(32, 16)
        lblState.TabIndex = 10

        lblCity.Location = New System.Drawing.Point(92, 92)
        lblCity.Text = "City"
        lblCity.Size = New System.Drawing.Size(100, 16)
        lblCity.TabIndex = 9
        Me.Text = "Step 2 of 3"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.Controls.Add(lblZip)
        Me.Controls.Add(lblState)
        Me.Controls.Add(lblCity)
        Me.Controls.Add(lblStreet)
        Me.Controls.Add(txtZip)
        Me.Controls.Add(txtState)
        Me.Controls.Add(txtCity)
        Me.Controls.Add(txtStreet)
    End Sub
#End Region

    'Override the Click event of the Back button to return to Page 1
    Protected Overrides Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Return to Page 1 of the wizard
        Dim Wiz1 As New frmWiz1()
        Wiz1 = New frmWiz1()
        Wiz1.Show()
        Me.Hide()
    End Sub

    'Override the Click event of the Next button to display Page 3
    Protected Overrides Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Show page 3 of the wizard
        Dim Wiz3 As New frmWiz3()
        Wiz3 = New frmWiz3()
        Wiz3.Show()
        Me.Hide()
    End Sub

End Class
