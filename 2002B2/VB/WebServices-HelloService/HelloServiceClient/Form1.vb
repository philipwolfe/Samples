Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnHello As System.Windows.Forms.Button
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents lblName As System.Windows.Forms.Label
    
    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnHello = New System.Windows.Forms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        lblName.Location = New System.Drawing.Point(8, 20)
        lblName.Text = "Enter your name:"
        lblName.Size = New System.Drawing.Size(92, 16)
        lblName.TabIndex = 0
        
        txtName.Location = New System.Drawing.Point(100, 16)
        txtName.Text = "Bob"
        txtName.TabIndex = 1
        txtName.Size = New System.Drawing.Size(100, 20)
        
        btnHello.Location = New System.Drawing.Point(128, 52)
        btnHello.Size = New System.Drawing.Size(75, 23)
        btnHello.TabIndex = 2
        btnHello.Text = "Say Hello!"
        Me.Text = "Hello World Client"
        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(220, 101)
        
        Me.Controls.Add(btnHello)
        Me.Controls.Add(txtName)
        Me.Controls.Add(lblName)
    End Sub
    
#End Region
    
    Protected Sub btnHello_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHello.click
        Dim Greeting As String
        'create an instance of the Hello WebService
        Dim HelloService As New localhost.Service1()

        'call the web service passing in the name provided
        Greeting = HelloService.HelloWorld(txtName.Text)

        'display the results
        MessageBox.Show(Greeting, "Hello Service Result")

    End Sub

End Class
