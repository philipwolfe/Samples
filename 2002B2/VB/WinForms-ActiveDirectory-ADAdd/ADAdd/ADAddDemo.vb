Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
        
#Region " Class initialization code "
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region
    
#Region " Windows Form Designer generated code "
    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents txtBase As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents btnAdd As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form
    
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Specify your Active Directory Server/Domain:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Specify the base container to modify:"
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(12, 80)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(248, 20)
        Me.txtBase.TabIndex = 4
        Me.txtBase.Text = "cn=ContainerName,dc=DomainName,dc=com"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(8, 32)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(252, 20)
        Me.txtServer.TabIndex = 2
        Me.txtServer.Text = "servername.domain.com"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(172, 116)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 24)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add User"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(268, 157)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBase, Me.Label2, Me.txtServer, Me.Label1, Me.btnAdd})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Active Directory Add User"
        Me.ResumeLayout(False)

    End Sub
    
#End Region
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.click
        Dim ADe As DirectoryServices.DirectoryEntry
        Dim ADeNew As DirectoryServices.DirectoryEntry
        Dim ServerName As String
        Dim Base As String
        'The container that ContainerName points to must be one which the
        'code has permission to change.  

        Try
            'grab the values from the text boxes
            ServerName = txtServer.Text
            Base = txtBase.Text

            ADe = New DirectoryServices.DirectoryEntry("LDAP://" & ServerName & "/" & Base)
            'In this case the AD has a class TestUser which has one mandatory attribut: name.
            'In order to use this demo this class must be created or the code changed to 
            'an existing one.
            ADeNew = ADe.Children.Add("CN=Tester Test2", "TestUser")
            'objADeNew.Properties().Item("name") = "username2"
            '... Continue setting the properties required for your class

            'All mandatory attributes must be set before .CommitChanges is called.
            'If you catch an exception make sure that you are setting all mandatory attribs.
            ADeNew.CommitChanges()
        Catch excp As Exception
            MessageBox.Show(excp.Message)
        End Try
    End Sub

End Class
