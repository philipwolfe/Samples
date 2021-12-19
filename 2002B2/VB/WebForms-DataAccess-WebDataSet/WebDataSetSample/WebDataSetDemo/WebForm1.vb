Imports System
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ListBox As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnLoadDSGrid As System.Web.UI.WebControls.Button
    Protected WithEvents btnLoadDRList As System.Web.UI.WebControls.Button
    Protected WithEvents btnLoadDSList As System.Web.UI.WebControls.Button
    
    
    
#Region " Web Forms Designer Generated Code "

    Dim WithEvents WebForm1 As System.Web.UI.Page
    
    Sub New()
        WebForm1 = Me
    End Sub

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        
        
        
        
        
        
    End Sub
    
#End Region
    
    Public Sub btnLoadDSGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadDSGrid.click
        Dim Data As DataSet
        Dim DSCommand As SqlDataAdapter

        Data = New DataSet()
        'Create New DataSet Command Object
        DSCommand = New SqlDataAdapter("Select * from customers", _
           "server=localhost;uid=sa;pwd=;database=northwind")

        'Fill Data Set
        DSCommand.Fill(Data, "Customers")

        'Set Data Set equal to DataGrid
        Me.DataGrid.DataSource = New DataView(Data.Tables(0))
        'Bind DataGrid
        DataGrid.DataBind()
        'Set DataGrid to be Visible
        DataGrid.Visible() = True
    End Sub

    Public Sub btnLoadDSList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadDSList.click
        Dim Data As DataSet
        Dim DSCommand As SqlDataAdapter
        Dim DRCustomer As DataRow

        Me.ListBox.Items.Clear()

        Data = New DataSet()
        'Create New DataSet Command Object
        DSCommand = New SqlDataAdapter("Select * from customers", _
           "server=localhost;uid=sa;pwd=;database=northwind")

        'Fill Data Set
        DSCommand.Fill(Data, "Customers")

        'For every row in Customer Table add it to the list box
        For Each DRCustomer In Data.Tables(0).Rows
            Me.ListBox.Items.Add(DRCustomer.Item("CompanyName").ToString())
        Next
    End Sub

    Public Sub btnLoadDRList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadDRList.click
        Dim Reader As SqlDataReader = Nothing
        Dim Connection As New SqlConnection("Password=;User ID=sa; Initial Catalog=Northwind;Data Source=localhost")
        Dim Command As New SqlCommand("Select * from customers", Connection)

        Me.ListBox.Items.Clear()
        'Open the Connection to the Database
        Connection.Open()
        'Execute the DataReader Command
        Reader = Command.ExecuteReader()
        'DataReader is always set to the first row of the data set
        While (Reader.Read)
            'For each row we add the CompanyName to the DataReader ListBox
            Me.ListBox.Items.Add(Reader("CompanyName").ToString)

        End While

        'Check on SQLConnection Object, Close it
        If Not (Connection.State = ConnectionState.Closed) Then
            Connection.Close()
        End If
    End Sub

    Protected Sub WebForm1_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles WebForm1.load
        If Not IsPostBack Then   ' Evals true first time browser hits the page	

        End If
    End Sub

    Protected Sub WebForm1_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles WebForm1.init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

End Class
