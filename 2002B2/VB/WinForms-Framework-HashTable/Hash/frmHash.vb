Option Strict Off
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections


Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Hash As New Hashtable()

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call

        'load the Hash Table
        Hash.Add("Jay", "0123")
        Hash.Add("Brad", "0569")
        Hash.Add("Brian", "1254")
        Hash.Add("Seth", "6839")
        Hash.Add("Rajesh", "3948")
        Hash.Add("Lakshan", "1930")
        Hash.Add("Kristian", "9341")

        'load the values of the Hash table into the list box to show the user
        Dim Name As String
        For Each Name In Hash.Keys
            lstHashContents.Items.Add(Name)
        Next

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents lstHashContents As System.Windows.Forms.ListBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtInput As System.Windows.Forms.TextBox
    Private WithEvents btnHash As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lstHashContents = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnHash.Location = New System.Drawing.Point(80, 88)
        btnHash.Size = New System.Drawing.Size(168, 24)
        btnHash.TabIndex = 0
        btnHash.Text = "Search for Employee"

        txtInput.Location = New System.Drawing.Point(136, 32)
        txtInput.Text = "Brad"
        txtInput.TabIndex = 1
        txtInput.Size = New System.Drawing.Size(240, 20)

        lstHashContents.Location = New System.Drawing.Point(8, 160)
        lstHashContents.Size = New System.Drawing.Size(168, 108)
        lstHashContents.TabIndex = 3

        Label1.Location = New System.Drawing.Point(8, 32)
        Label1.Text = "Employee Name"
        Label1.Size = New System.Drawing.Size(96, 16)
        Label1.TabIndex = 2

        Label2.Location = New System.Drawing.Point(8, 136)
        Label2.Text = "Employee Hash Table"
        Label2.Size = New System.Drawing.Size(120, 16)
        Label2.TabIndex = 4

        Me.Text = "Hash Table"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 273)

        Me.Controls.Add(Label2)
        Me.Controls.Add(lstHashContents)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtInput)
        Me.Controls.Add(btnHash)
    End Sub

#End Region

    Protected Sub btnHash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHash.click
        Dim Found As String

        'search the hash Hash for there requested user
        Found = Hash(txtInput.Text)
        If Not Found.Empty Then
            MessageBox.Show("Found in the list: " & Chr(10) & Chr(13) & Found, "Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class
