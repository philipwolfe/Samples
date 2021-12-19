Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form
    
#Region " Initialization Code "
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
#End Region
    
#Region " Windows Form Designer generated code "
    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    
    Private WithEvents txtResult As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtBaseDN As System.Windows.Forms.TextBox
    Private WithEvents txtFilter As System.Windows.Forms.TextBox
    
    
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtServerName As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtProperties As System.Windows.Forms.TextBox
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    
    
    
    
    Private WithEvents btnSearch As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form
    
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.txtBaseDN = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.txtProperties = New System.Windows.Forms.TextBox()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Label5.Location = New System.Drawing.Point(24, 204)
        Label5.Text = "Result"
        Label5.Size = New System.Drawing.Size(48, 16)
        Label5.TabIndex = 6
        
        Label4.Location = New System.Drawing.Point(32, 120)
        Label4.Text = "BaseDN"
        Label4.Size = New System.Drawing.Size(48, 16)
        Label4.TabIndex = 5
        
        Label2.Location = New System.Drawing.Point(8, 56)
        Label2.Text = "Server Name"
        Label2.Size = New System.Drawing.Size(80, 16)
        Label2.TabIndex = 3
        
        Label1.Location = New System.Drawing.Point(24, 24)
        Label1.Text = "Properties"
        Label1.Size = New System.Drawing.Size(64, 16)
        Label1.TabIndex = 1
        
        Label3.Location = New System.Drawing.Point(48, 88)
        Label3.Text = "Filter"
        Label3.Size = New System.Drawing.Size(32, 16)
        Label3.TabIndex = 4
        
        txtFilter.Location = New System.Drawing.Point(88, 84)
        txtFilter.Text = "cn=user@domain.com"
        txtFilter.TabIndex = 6
        txtFilter.Size = New System.Drawing.Size(160, 20)
        
        txtBaseDN.Location = New System.Drawing.Point(88, 116)
        txtBaseDN.Text = "cn=Container,dc=domain,dc=com"
        txtBaseDN.TabIndex = 7
        txtBaseDN.Size = New System.Drawing.Size(160, 20)
        
        btnSearch.Location = New System.Drawing.Point(120, 168)
        btnSearch.Size = New System.Drawing.Size(76, 24)
        btnSearch.TabIndex = 0
        btnSearch.Text = "Search"
        
        txtResult.Location = New System.Drawing.Point(72, 200)
        txtResult.TabIndex = 7
        txtResult.Size = New System.Drawing.Size(208, 20)
        
        GroupBox1.Location = New System.Drawing.Point(8, 8)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "Specify Search Parameters:"
        GroupBox1.Size = New System.Drawing.Size(280, 152)
        
        txtServerName.Location = New System.Drawing.Point(88, 52)
        txtServerName.Text = "ServerName"
        txtServerName.TabIndex = 2
        txtServerName.Size = New System.Drawing.Size(160, 20)
        
        txtProperties.Location = New System.Drawing.Point(88, 20)
        txtProperties.Text = "mail"
        txtProperties.TabIndex = 0
        txtProperties.Size = New System.Drawing.Size(160, 20)
        Me.Text = "Active Directory Search"
        Me.MaximizeBox = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(292, 237)
        
        GroupBox1.Controls.Add(txtBaseDN)
        GroupBox1.Controls.Add(txtFilter)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtServerName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtProperties)
        Me.Controls.Add(txtResult)
        Me.Controls.Add(Label5)
        Me.Controls.Add(GroupBox1)
        Me.Controls.Add(btnSearch)
    End Sub
    
#End Region
    
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.click
        Dim DS As System.DirectoryServices.DirectorySearcher
        Dim DE As DirectoryServices.DirectoryEntry
        Dim Results As DirectoryServices.SearchResultCollection
        Dim ResultsEntry As DirectoryServices.SearchResult
        Dim PropertiesToLoad(1) As String
        Dim ServerName As String
        Dim Filter As String
        Dim Base As String

        'Store values from form in local variables
        PropertiesToLoad(0) = txtProperties.Text
        ServerName = txtServerName.Text
        Filter = txtFilter.Text
        Base = txtBaseDN.Text

        Try
            'Create a Directory Entry object.  This stores the path
            'to our server and the baseDN.  There are multiple overloads to 
            'accomodate secure logon as well.
            DE = New DirectoryServices.DirectoryEntry("LDAP://" & ServerName & "/" & Base)

            'Create a DirectorySearcher object.  In this case we pass a DirectoryEntry
            'object as the search root, a string for the filter and an array of properties
            'which we want the search to return.
            DS = New DirectoryServices.DirectorySearcher(DE, Filter, PropertiesToLoad)

            'DirectorySearcher.FindAll returns a SearchResult collection of 
            'SearchResultsEntrys
            For Each ResultsEntry In DS.FindAll()
                txtResult.Text = CStr(ResultsEntry.Properties().Item(PropertiesToLoad(0)).ToString)
            Next
        Catch excp As Exception
            MessageBox.Show(excp.Message, "Exception Caught")
        End Try
    End Sub

End Class
