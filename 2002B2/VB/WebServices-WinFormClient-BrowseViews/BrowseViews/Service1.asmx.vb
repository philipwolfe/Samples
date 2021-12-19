Imports System.ComponentModel
Imports System.Configuration
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Data.SqlClient

'DBConnData - used to put all connection parameters together
'Wouldn't do this in a production environment, but it's a
'Good test for marshalling user defined classes with web services
Public Class DBConnData
    Public ServerName As String                        'Name of the SQL server
    Public DBName As String                            'Name of the database
    Public UserName As String                          'Name of the db-user (using sql authentication)
    Public Pwd As String                               'Pwd of the db-user (see name)
End Class


Public Class Service1
    Inherits System.Web.Services.WebService

    Private Const AppName As String = "BrowseViewWS"
#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Overloads Overrides Sub Dispose()
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> Public Function HelloWorld() As String
        '	HelloWorld = "Hello World"
    'End Function

    'Internal helper that is able to execute a SQL statement agains a SQL server db;
    'returns result as a data set. In case of an error data set with an error row
    'is returned.
    Protected Function ExecSQL(ByVal ConnInfo As DBConnData, ByRef SQLStmt As String, _
            ByRef TabName As String) _
            As System.Data.DataSet
        Dim DBConn As New SqlConnection()
        'Define db connection        
        DBConn.ConnectionString = "Application Name=" & Me.AppName & ";Server=" & ConnInfo.ServerName & _
            ";Initial Catalog=" & ConnInfo.DBName & ";User ID=" & ConnInfo.UserName & ";Pwd=" & ConnInfo.Pwd
        'select all view names from db's system views
        Dim Cmd As New SqlDataAdapter(SQLStmt, DBConn)
        'load views in a data set
        Dim DataSet As New System.Data.DataSet()
        Try
            Cmd.Fill(DataSet, TabName)
        Catch adoEx As SqlException
            'In case of an error generate data set with one error row in it.
            Dim ErrTable As DataTable = New DataTable(TabName)
            Dim ErrColumn As DataColumn
            Dim ErrRow As DataRow
            If tabName = "views" Then
                'If we are returning list of views error row must contain two columns
                'with special names; could be done better; just a quick solution
                ErrColumn = New DataColumn()
                ErrColumn.DataType = System.Type.GetType("System.String")
                ErrColumn.ColumnName = "table_schema"
                ErrTable.Columns.Add(ErrColumn)
            End If
            ErrColumn = New DataColumn()
            ErrColumn.DataType = System.Type.GetType("System.String")
            If tabName = "views" Then
                ErrColumn.ColumnName = "table_name"
            Else
                ErrColumn.ColumnName = "ResultColumn"
            End If
            ErrTable.Columns.Add(ErrColumn)
            DataSet.Tables.Add(ErrTable)
            ErrRow = ErrTable.NewRow()
            If TabName = "views" Then
                ErrRow("table_schema") = ""
                ErrRow("table_name") = "Error during execution!"
            Else
                ErrRow("ResultColumn") = "Error during execution!"
            End If
            ErrTable.Rows.Add(ErrRow)
        End Try
        ExecSQL = dataSet
    End Function

    'This function returns the names of all views of a database as a data set.
    <WebMethod()> Public Function GetAllViews(ByVal dbConnInfo As DBConnData) As System.Data.DataSet
        GetAllViews = ExecSQL(dbConnInfo, _
            "select table_schema, table_name from information_schema.views as views", _
            "views")
    End Function

    'This function returns all rows of a view a a data set.
    <WebMethod()> Public Function QueryView(ByVal dbConnInfo As DBConnData, _
            ByRef ViewName As String) As System.Data.DataSet
        QueryView = ExecSQL(dbConnInfo, "select * from " & ViewName, "Result")
    End Function


End Class
