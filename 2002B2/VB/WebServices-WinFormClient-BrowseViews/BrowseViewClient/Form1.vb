Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form
    
    Private browseService As New localhost.Service1()
    
    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Result As System.Windows.Forms.DataGrid
    Private WithEvents Query As System.Windows.Forms.Button
    Private WithEvents Views As System.Windows.Forms.ComboBox

    Private WithEvents LogIn As System.Windows.Forms.Button
    Private WithEvents Password As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents userID As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents dbName As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents serverName As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LogIn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Views = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.serverName = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.dbName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.userID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Query = New System.Windows.Forms.Button()
        Me.Result = New System.Windows.Forms.DataGrid()

        Result.BeginInit()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        LogIn.Location = New System.Drawing.Point(12, 80)
        LogIn.Size = New System.Drawing.Size(100, 23)
        LogIn.TabIndex = 8
        LogIn.Text = "Get Views"

        GroupBox1.Location = New System.Drawing.Point(8, 8)
        GroupBox1.TabIndex = 0
        GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top.Left.Right
        GroupBox1.TabStop = False
        GroupBox1.Text = "Database Connection"
        GroupBox1.Size = New System.Drawing.Size(456, 120)

        Views.Location = New System.Drawing.Point(120, 80)
        Views.Size = New System.Drawing.Size(200, 21)
        Views.TabIndex = 9

        Label2.Location = New System.Drawing.Point(24, 50)
        Label2.Text = "Database Name:"
        Label2.Size = New System.Drawing.Size(88, 16)
        Label2.TabIndex = 2
        Label2.TextAlign = ContentAlignment.MiddleRight

        Label1.Location = New System.Drawing.Point(16, 24)
        Label1.Text = "SQL Server Name:"
        Label1.Size = New System.Drawing.Size(100, 16)
        Label1.TabIndex = 0
        Label1.TextAlign = ContentAlignment.MiddleRight

        serverName.Location = New System.Drawing.Point(120, 22)
        serverName.Text = "(local)"
        serverName.TabIndex = 1
        serverName.Size = New System.Drawing.Size(100, 20)

        Password.Location = New System.Drawing.Point(328, 48)
        Password.TabIndex = 7
        Password.Size = New System.Drawing.Size(100, 20)

        dbName.Location = New System.Drawing.Point(120, 48)
        dbName.Text = "Northwind"
        dbName.TabIndex = 3
        dbName.Size = New System.Drawing.Size(100, 20)

        Label3.Location = New System.Drawing.Point(240, 24)
        Label3.Text = "User ID:"
        Label3.Size = New System.Drawing.Size(80, 16)
        Label3.TabIndex = 4
        Label3.TextAlign = ContentAlignment.MiddleRight

        userID.Location = New System.Drawing.Point(328, 22)
        userID.Text = "sa"
        userID.TabIndex = 5
        userID.Size = New System.Drawing.Size(100, 20)

        Label4.Location = New System.Drawing.Point(240, 50)
        Label4.Text = "Password:"
        Label4.Size = New System.Drawing.Size(80, 16)
        Label4.TabIndex = 6
        Label4.TextAlign = ContentAlignment.MiddleRight

        Query.Location = New System.Drawing.Point(328, 80)
        Query.Size = New System.Drawing.Size(100, 23)
        Query.TabIndex = 10
        Query.Text = "Query View"

        Result.Location = New System.Drawing.Point(8, 136)
        Result.ReadOnly = True
        Result.Size = New System.Drawing.Size(456, 136)
        Result.DataMember = ""
        Result.TabIndex = 1
        Result.Anchor = System.Windows.Forms.AnchorStyles.Top.Bottom.Left.Right
        Me.Text = "Browse Views"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 277)

        GroupBox1.Controls.Add(Query)
        GroupBox1.Controls.Add(Views)
        GroupBox1.Controls.Add(LogIn)
        GroupBox1.Controls.Add(Password)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(userID)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(dbName)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(serverName)
        GroupBox1.Controls.Add(Label1)
        Me.Controls.Add(Result)
        Me.Controls.Add(GroupBox1)

        Result.EndInit()
    End Sub

#End Region

    Protected Sub Query_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Query.click
        If Views.SelectedIndex <> (-1) Then
            Dim ViewsSet As System.Data.DataSet
            'Prepare parameters for web service
            Dim Conn As New localhost.DBConnData()
            Conn.serverName = serverName.Text.ToString
            Conn.dbName = dbName.Text.ToString
            Conn.userName = userID.Text.ToString
            Conn.pwd = Password.Text.ToString
            'Call web service
            ViewsSet = browseService.QueryView(Conn, Views.Text.ToString)
            Result.SetDataBinding(viewsSet, "Result")
        End If
    End Sub

    Protected Sub LogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogIn.click
        Dim ViewsSet As System.Data.DataSet
        Dim ViewRow As System.Data.DataRow
        'Prepare parameters for web service
        Dim Conn As New localhost.DBConnData()
        Conn.serverName = serverName.Text.ToString
        Conn.dbName = dbName.Text.ToString
        Conn.userName = userID.Text.ToString
        Conn.pwd = Password.Text.ToString
        'Call web service
        ViewsSet = browseService.GetAllViews(Conn)

        'Fill combo box with view names
        Views.Items.Clear()
        For Each viewRow In viewsSet.Tables(0).Rows
            Views.Items.Add("[" & viewRow(0).ToString() & "].[" & viewRow(1).ToString() & "]")
        Next
        Views.SelectedIndex = 0
    End Sub

End Class
