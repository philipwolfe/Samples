Option Strict On

Public Class frmConnectUser

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
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtUserLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtUserLogin = New System.Windows.Forms.TextBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLogin.Location = New System.Drawing.Point(82, 158)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(154, 49)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "&Login"
        '
        'txtUserLogin
        '
        Me.txtUserLogin.Location = New System.Drawing.Point(20, 109)
        Me.txtUserLogin.Name = "txtUserLogin"
        Me.txtUserLogin.Size = New System.Drawing.Size(287, 22)
        Me.txtUserLogin.TabIndex = 1
        Me.txtUserLogin.Text = ""
        '
        'lblInstructions
        '
        Me.lblInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblInstructions.Location = New System.Drawing.Point(20, 20)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(308, 79)
        Me.lblInstructions.TabIndex = 2
        Me.lblInstructions.Text = "Please enter a unique name to log into the chat utility.  If login name already e" & _
        "xists you will be returned to this dialog to attempt another name."
        '
        'frmConnectUser
        '
        Me.AcceptButton = Me.btnLogin
        Me.AccessibleDescription = "Connect User Form"
        Me.AccessibleName = "Connect User Form"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.CancelButton = Me.btnLogin
        Me.ClientSize = New System.Drawing.Size(348, 223)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions, Me.txtUserLogin, Me.btnLogin})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectUser"
        Me.Text = "Connect User"
        Me.ResumeLayout(False)

    End Sub

#End Region


End Class
