Imports System.Threading
Imports System.Security.Principal

Public Class frmLogin
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkAdministratorAccount As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkAdministratorAccount = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
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
        'txtUserName
        '
        Me.txtUserName.AccessibleDescription = resources.GetString("txtUserName.AccessibleDescription")
        Me.txtUserName.AccessibleName = resources.GetString("txtUserName.AccessibleName")
        Me.txtUserName.Anchor = CType(resources.GetObject("txtUserName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.AutoSize = CType(resources.GetObject("txtUserName.AutoSize"), Boolean)
        Me.txtUserName.BackgroundImage = CType(resources.GetObject("txtUserName.BackgroundImage"), System.Drawing.Image)
        Me.txtUserName.Dock = CType(resources.GetObject("txtUserName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUserName.Enabled = CType(resources.GetObject("txtUserName.Enabled"), Boolean)
        Me.txtUserName.Font = CType(resources.GetObject("txtUserName.Font"), System.Drawing.Font)
        Me.txtUserName.ImeMode = CType(resources.GetObject("txtUserName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUserName.Location = CType(resources.GetObject("txtUserName.Location"), System.Drawing.Point)
        Me.txtUserName.MaxLength = CType(resources.GetObject("txtUserName.MaxLength"), Integer)
        Me.txtUserName.Multiline = CType(resources.GetObject("txtUserName.Multiline"), Boolean)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.PasswordChar = CType(resources.GetObject("txtUserName.PasswordChar"), Char)
        Me.txtUserName.RightToLeft = CType(resources.GetObject("txtUserName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUserName.ScrollBars = CType(resources.GetObject("txtUserName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUserName.Size = CType(resources.GetObject("txtUserName.Size"), System.Drawing.Size)
        Me.txtUserName.TabIndex = CType(resources.GetObject("txtUserName.TabIndex"), Integer)
        Me.txtUserName.Text = resources.GetString("txtUserName.Text")
        Me.txtUserName.TextAlign = CType(resources.GetObject("txtUserName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUserName.Visible = CType(resources.GetObject("txtUserName.Visible"), Boolean)
        Me.txtUserName.WordWrap = CType(resources.GetObject("txtUserName.WordWrap"), Boolean)
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = resources.GetString("txtPassword.AccessibleDescription")
        Me.txtPassword.AccessibleName = resources.GetString("txtPassword.AccessibleName")
        Me.txtPassword.Anchor = CType(resources.GetObject("txtPassword.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.AutoSize = CType(resources.GetObject("txtPassword.AutoSize"), Boolean)
        Me.txtPassword.BackgroundImage = CType(resources.GetObject("txtPassword.BackgroundImage"), System.Drawing.Image)
        Me.txtPassword.Dock = CType(resources.GetObject("txtPassword.Dock"), System.Windows.Forms.DockStyle)
        Me.txtPassword.Enabled = CType(resources.GetObject("txtPassword.Enabled"), Boolean)
        Me.txtPassword.Font = CType(resources.GetObject("txtPassword.Font"), System.Drawing.Font)
        Me.txtPassword.ImeMode = CType(resources.GetObject("txtPassword.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtPassword.Location = CType(resources.GetObject("txtPassword.Location"), System.Drawing.Point)
        Me.txtPassword.MaxLength = CType(resources.GetObject("txtPassword.MaxLength"), Integer)
        Me.txtPassword.Multiline = CType(resources.GetObject("txtPassword.Multiline"), Boolean)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = CType(resources.GetObject("txtPassword.PasswordChar"), Char)
        Me.txtPassword.RightToLeft = CType(resources.GetObject("txtPassword.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtPassword.ScrollBars = CType(resources.GetObject("txtPassword.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtPassword.Size = CType(resources.GetObject("txtPassword.Size"), System.Drawing.Size)
        Me.txtPassword.TabIndex = CType(resources.GetObject("txtPassword.TabIndex"), Integer)
        Me.txtPassword.Text = resources.GetString("txtPassword.Text")
        Me.txtPassword.TextAlign = CType(resources.GetObject("txtPassword.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtPassword.Visible = CType(resources.GetObject("txtPassword.Visible"), Boolean)
        Me.txtPassword.WordWrap = CType(resources.GetObject("txtPassword.WordWrap"), Boolean)
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = resources.GetString("btnOK.AccessibleDescription")
        Me.btnOK.AccessibleName = resources.GetString("btnOK.AccessibleName")
        Me.btnOK.Anchor = CType(resources.GetObject("btnOK.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.Dock = CType(resources.GetObject("btnOK.Dock"), System.Windows.Forms.DockStyle)
        Me.btnOK.Enabled = CType(resources.GetObject("btnOK.Enabled"), Boolean)
        Me.btnOK.FlatStyle = CType(resources.GetObject("btnOK.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnOK.Font = CType(resources.GetObject("btnOK.Font"), System.Drawing.Font)
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = CType(resources.GetObject("btnOK.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnOK.ImageIndex = CType(resources.GetObject("btnOK.ImageIndex"), Integer)
        Me.btnOK.ImeMode = CType(resources.GetObject("btnOK.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnOK.Location = CType(resources.GetObject("btnOK.Location"), System.Drawing.Point)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = CType(resources.GetObject("btnOK.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnOK.Size = CType(resources.GetObject("btnOK.Size"), System.Drawing.Size)
        Me.btnOK.TabIndex = CType(resources.GetObject("btnOK.TabIndex"), Integer)
        Me.btnOK.Text = resources.GetString("btnOK.Text")
        Me.btnOK.TextAlign = CType(resources.GetObject("btnOK.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnOK.Visible = CType(resources.GetObject("btnOK.Visible"), Boolean)
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = resources.GetString("btnCancel.AccessibleDescription")
        Me.btnCancel.AccessibleName = resources.GetString("btnCancel.AccessibleName")
        Me.btnCancel.Anchor = CType(resources.GetObject("btnCancel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.Dock = CType(resources.GetObject("btnCancel.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCancel.Enabled = CType(resources.GetObject("btnCancel.Enabled"), Boolean)
        Me.btnCancel.FlatStyle = CType(resources.GetObject("btnCancel.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCancel.Font = CType(resources.GetObject("btnCancel.Font"), System.Drawing.Font)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = CType(resources.GetObject("btnCancel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCancel.ImageIndex = CType(resources.GetObject("btnCancel.ImageIndex"), Integer)
        Me.btnCancel.ImeMode = CType(resources.GetObject("btnCancel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCancel.Location = CType(resources.GetObject("btnCancel.Location"), System.Drawing.Point)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = CType(resources.GetObject("btnCancel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCancel.Size = CType(resources.GetObject("btnCancel.Size"), System.Drawing.Size)
        Me.btnCancel.TabIndex = CType(resources.GetObject("btnCancel.TabIndex"), Integer)
        Me.btnCancel.Text = resources.GetString("btnCancel.Text")
        Me.btnCancel.TextAlign = CType(resources.GetObject("btnCancel.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCancel.Visible = CType(resources.GetObject("btnCancel.Visible"), Boolean)
        '
        'chkAdministratorAccount
        '
        Me.chkAdministratorAccount.AccessibleDescription = resources.GetString("chkAdministratorAccount.AccessibleDescription")
        Me.chkAdministratorAccount.AccessibleName = resources.GetString("chkAdministratorAccount.AccessibleName")
        Me.chkAdministratorAccount.Anchor = CType(resources.GetObject("chkAdministratorAccount.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkAdministratorAccount.Appearance = CType(resources.GetObject("chkAdministratorAccount.Appearance"), System.Windows.Forms.Appearance)
        Me.chkAdministratorAccount.BackgroundImage = CType(resources.GetObject("chkAdministratorAccount.BackgroundImage"), System.Drawing.Image)
        Me.chkAdministratorAccount.CheckAlign = CType(resources.GetObject("chkAdministratorAccount.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkAdministratorAccount.Dock = CType(resources.GetObject("chkAdministratorAccount.Dock"), System.Windows.Forms.DockStyle)
        Me.chkAdministratorAccount.Enabled = CType(resources.GetObject("chkAdministratorAccount.Enabled"), Boolean)
        Me.chkAdministratorAccount.FlatStyle = CType(resources.GetObject("chkAdministratorAccount.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkAdministratorAccount.Font = CType(resources.GetObject("chkAdministratorAccount.Font"), System.Drawing.Font)
        Me.chkAdministratorAccount.Image = CType(resources.GetObject("chkAdministratorAccount.Image"), System.Drawing.Image)
        Me.chkAdministratorAccount.ImageAlign = CType(resources.GetObject("chkAdministratorAccount.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkAdministratorAccount.ImageIndex = CType(resources.GetObject("chkAdministratorAccount.ImageIndex"), Integer)
        Me.chkAdministratorAccount.ImeMode = CType(resources.GetObject("chkAdministratorAccount.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkAdministratorAccount.Location = CType(resources.GetObject("chkAdministratorAccount.Location"), System.Drawing.Point)
        Me.chkAdministratorAccount.Name = "chkAdministratorAccount"
        Me.chkAdministratorAccount.RightToLeft = CType(resources.GetObject("chkAdministratorAccount.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkAdministratorAccount.Size = CType(resources.GetObject("chkAdministratorAccount.Size"), System.Drawing.Size)
        Me.chkAdministratorAccount.TabIndex = CType(resources.GetObject("chkAdministratorAccount.TabIndex"), Integer)
        Me.chkAdministratorAccount.Text = resources.GetString("chkAdministratorAccount.Text")
        Me.chkAdministratorAccount.TextAlign = CType(resources.GetObject("chkAdministratorAccount.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkAdministratorAccount.Visible = CType(resources.GetObject("chkAdministratorAccount.Visible"), Boolean)
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnOK
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAdministratorAccount, Me.btnCancel, Me.btnOK, Me.txtPassword, Me.txtUserName, Me.Label2, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmLogin"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim intLoginAttempts As Integer

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ' Instantiate a custom Users class
        Dim objUser As New Users()
        Dim GenPrincipal As GenericPrincipal


        Dim strName As String = txtUserName.Text
        Dim strPassword As String = txtPassword.Text

        ' Check for Windows Administrator.  Administrator can bypass
        ' custom security system.
        If chkAdministratorAccount.Checked Then
            If objUser.IsAdministrator Then
                ' Display the Users Name (Windows or Generic)
                MsgBox(Thread.CurrentPrincipal.Identity.Name & " has logged in successfully!", MsgBoxStyle.Information, "Login Successful")


                ' Show Main Form
                Dim Main As New frmMain()
                Main.ShowDialog()

                ' Hide the Login Form
                Me.Close()
            Else
                ' Increment login attempts
                intLoginAttempts += 1
                MsgBox("User not an Administrator.  Please provide a User Name and Password.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        Else
            ' Check that the login exists
            If objUser.IsLogin(strName, strPassword) Then
                GenPrincipal = objUser.GetLogin(strName, strPassword)
                Thread.CurrentPrincipal = GenPrincipal

                ' Display the Users Name (Windows or Generic)
                MsgBox(Thread.CurrentPrincipal.Identity.Name & " has logged in successfully!", MsgBoxStyle.Information, "Login Successful")

                ' Show Main Form
                Dim Main As New frmMain()
                Main.ShowDialog()

                ' Hide the Login Form
                Me.Close()
            Else
                ' Increment login attempts
                intLoginAttempts += 1

                ' After the 3 attempts quit the application
                If intLoginAttempts >= 3 Then
                    MsgBox("Too many failed login attempts", MsgBoxStyle.Exclamation, Me.Text)
                    End
                Else
                    MsgBox("User Name not found.  Please try again", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If
        End If


    End Sub
End Class
