'*****************************************************************************
'Form Inheritance Example - Child Form 3 of 3
'*****************************************************************************

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class frmWiz3
    Inherits FIWiz.frmWizardForm

    Public Sub New()
        MyBase.New()

        frmWiz3 = Me

        'This call is required by the WinForm Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent call

        'Enable/Disable the navigation buttons accordingly
        btnNext.Enabled = False

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the WinForm Designer
    Private Shadows components As System.ComponentModel.Container

    Private WithEvents lblEmail As System.Windows.Forms.Label
    Private WithEvents lblPhone As System.Windows.Forms.Label
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents txtPhone As System.Windows.Forms.TextBox
    Dim WithEvents frmWiz3 As FIWiz.frmWizardForm

    'NOTE: The following procedure is required by the WinForm Designer
    'It can be modified using the WinForm Designer.  
    'Do not modify it using the code editor.
    Private Shadows Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnFinish.Enabled = True

        txtEmail.Location = New System.Drawing.Point(148, 108)
        txtEmail.TabIndex = 5
        txtEmail.Size = New System.Drawing.Size(184, 20)

        txtPhone.Location = New System.Drawing.Point(148, 60)
        txtPhone.TabIndex = 4
        txtPhone.Size = New System.Drawing.Size(128, 20)

        btnBack.Enabled = True

        lblPhone.Location = New System.Drawing.Point(148, 44)
        lblPhone.Text = "Phone"
        lblPhone.Size = New System.Drawing.Size(120, 16)
        lblPhone.TabIndex = 6

        btnNext.Enabled = True

        lblEmail.Location = New System.Drawing.Point(148, 92)
        lblEmail.Text = "Email"
        lblEmail.Size = New System.Drawing.Size(184, 16)
        lblEmail.TabIndex = 7

        btnCancel.Enabled = True
        Me.Text = "Step 3 of 3"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.Controls.Add(lblEmail)
        Me.Controls.Add(lblPhone)
        Me.Controls.Add(txtEmail)
        Me.Controls.Add(txtPhone)
    End Sub
#End Region


    'Override the Click event of the Back button to return to Page 2
    Protected Overrides Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Wiz2 As New frmWiz2()
        Wiz2 = New frmWiz2()
        Wiz2.Show()
        Me.Hide()
    End Sub



End Class
