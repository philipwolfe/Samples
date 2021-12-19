'*****************************************************************************
'Form Inheritance Example - Child Form 1 of 3
'Microsoft VB.Net Beta 1 Resource CD
'02/19/2001
'*****************************************************************************

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class frmWiz1
    Inherits FIWiz.frmWizardForm

    Public Sub New()
        MyBase.New()

        frmWiz1 = Me

        'This call is required by the WinForm Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent call

        'Set enable/disable the buttons appropriately for this page of the wizard
        btncancel.Visible = True
        btnback.Enabled = False
        btnnext.Visible = True
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

    Private WithEvents lblLastName As System.Windows.Forms.Label
    Private WithEvents lblMiddleName As System.Windows.Forms.Label
    Private WithEvents lblFirstName As System.Windows.Forms.Label
    Private WithEvents txtLastName As System.Windows.Forms.TextBox
    Private WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Private WithEvents txtFirstName As System.Windows.Forms.TextBox
    Dim WithEvents frmWiz1 As FIWiz.frmWizardForm

    'NOTE: The following procedure is required by the WinForm Designer
    'It can be modified using the WinForm Designer.  
    'Do not modify it using the code editor.
    Private Shadows Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtMiddleName.Location = New System.Drawing.Point(132, 96)
        txtMiddleName.TabIndex = 5
        txtMiddleName.Size = New System.Drawing.Size(176, 20)

        txtFirstName.Location = New System.Drawing.Point(132, 48)
        txtFirstName.TabIndex = 4
        txtFirstName.Size = New System.Drawing.Size(176, 20)

        txtLastName.Location = New System.Drawing.Point(132, 144)
        txtLastName.TabIndex = 6
        txtLastName.Size = New System.Drawing.Size(176, 20)

        btnNext.Enabled = True

        lblMiddleName.Location = New System.Drawing.Point(132, 80)
        lblMiddleName.Text = "Middle Name"
        lblMiddleName.Size = New System.Drawing.Size(176, 16)
        lblMiddleName.TabIndex = 8

        lblLastName.Location = New System.Drawing.Point(132, 128)
        lblLastName.Text = "Last Name"
        lblLastName.Size = New System.Drawing.Size(176, 16)
        lblLastName.TabIndex = 9

        lblFirstName.Location = New System.Drawing.Point(132, 32)
        lblFirstName.Text = "First Name"
        lblFirstName.Size = New System.Drawing.Size(176, 16)
        lblFirstName.TabIndex = 7

        btnCancel.Enabled = True
        Me.Text = "Step 1 of 3"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.Controls.Add(lblLastName)
        Me.Controls.Add(lblMiddleName)
        Me.Controls.Add(lblFirstName)
        Me.Controls.Add(txtLastName)
        Me.Controls.Add(txtMiddleName)
        Me.Controls.Add(txtFirstName)
    End Sub
#End Region

    'Overide the Click event of the Next button
    Protected Overrides Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'show the next page of the wizard
        Dim Wiz2 As New frmWiz2()
        Wiz2 = New frmWiz2()
        Wiz2.Show()
        Me.Hide()
    End Sub

End Class
