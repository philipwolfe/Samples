Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient


Public Class Form1
    Inherits System.Windows.Forms.Form

    'Sql connection object
    Private Con As New SqlConnection("server=localhost;uid=sa;pwd=;database=northwind")

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
        'Open the connection to the database
        Con.Open()
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        'Make sure the connection has been closed and released
        If Not (Con Is Nothing) Then
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
            Con = Nothing
        End If

        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lblTitle As System.Windows.Forms.Label
    Private WithEvents cmdLoadDSList As System.Windows.Forms.Button

    Private WithEvents cmdLoadDSGrid As System.Windows.Forms.Button
    Private WithEvents lblCustomerListBox As System.Windows.Forms.Label
    Private WithEvents cmdLoadDRList As System.Windows.Forms.Button



    Private WithEvents lstBox As System.Windows.Forms.ListBox
    Private WithEvents grdDataGrid As System.Windows.Forms.DataGrid



















    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdLoadDSList = New System.Windows.Forms.Button()
        Me.cmdLoadDSGrid = New System.Windows.Forms.Button()
        Me.grdDataGrid = New System.Windows.Forms.DataGrid()
        Me.lblCustomerListBox = New System.Windows.Forms.Label()
        Me.lstBox = New System.Windows.Forms.ListBox()
        Me.cmdLoadDRList = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()

        grdDataGrid.BeginInit()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdLoadDSList.Location = New System.Drawing.Point(16, 48)
        cmdLoadDSList.Size = New System.Drawing.Size(224, 23)
        cmdLoadDSList.TabIndex = 11
        cmdLoadDSList.Text = "Load DataSet into List Box"

        cmdLoadDSGrid.Location = New System.Drawing.Point(296, 48)
        cmdLoadDSGrid.Size = New System.Drawing.Size(224, 23)
        cmdLoadDSGrid.TabIndex = 9
        cmdLoadDSGrid.Text = "Load DataSet into Data Grid"

        grdDataGrid.Location = New System.Drawing.Point(296, 144)
        grdDataGrid.Size = New System.Drawing.Size(624, 392)
        grdDataGrid.PreferredColumnWidth = 100
        grdDataGrid.AccessibleName = "Customer Table"
        grdDataGrid.DataMember = ""
        grdDataGrid.CaptionText = "Customer Table"
        grdDataGrid.TabIndex = 6
        grdDataGrid.AccessibleDescription = "Customer Table"

        lblCustomerListBox.Location = New System.Drawing.Point(16, 128)
        lblCustomerListBox.Text = "Company Name from Customer Table"
        lblCustomerListBox.Size = New System.Drawing.Size(208, 16)
        lblCustomerListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold)
        lblCustomerListBox.TabIndex = 8

        lstBox.Location = New System.Drawing.Point(16, 144)
        lstBox.Size = New System.Drawing.Size(256, 394)
        lstBox.TabIndex = 7

        cmdLoadDRList.Location = New System.Drawing.Point(16, 88)
        cmdLoadDRList.Size = New System.Drawing.Size(224, 23)
        cmdLoadDRList.TabIndex = 0
        cmdLoadDRList.Text = "Load DataReader into List Box"

        lblTitle.Location = New System.Drawing.Point(16, 8)
        lblTitle.Text = "Win Form Data Access"
        lblTitle.Size = New System.Drawing.Size(904, 23)
        lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold)
        lblTitle.TabIndex = 12
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Text = "DataSets"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 557)

        Me.Controls.Add(lblTitle)
        Me.Controls.Add(cmdLoadDSList)
        Me.Controls.Add(cmdLoadDSGrid)
        Me.Controls.Add(lblCustomerListBox)
        Me.Controls.Add(cmdLoadDRList)
        Me.Controls.Add(lstBox)
        Me.Controls.Add(grdDataGrid)

        grdDataGrid.EndInit()
    End Sub

#End Region



    Protected Sub cmdLoadDSList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLoadDSList.Click
        Dim Results As DataSet
        Dim Adapter As SqlDataAdapter
        Dim CustomerRow As DataRow
        Dim Command As SqlCommand


        Me.lstBox.Items.Clear()

        Results = New DataSet()

        'Create new command object
        Command = New SqlCommand("Select * from customers")

        'Create New SqlDataAdapter
        Adapter = New SqlDataAdapter(Command)

        'Set the command object connection to the current connection
        Command.Connection = Con

        'Fill Data Set
        Adapter.Fill(Results, "Customers")

        'For every row in Customer Table add it to the list box
        For Each CustomerRow In Results.Tables(0).Rows
            Me.lstBox.Items.Add(CustomerRow.Item("CompanyName").ToString())
        Next
    End Sub

    Protected Sub cmdLoadDSGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLoadDSGrid.Click
        Dim Results As New DataSet()
        Dim Adapter As New SqlDataAdapter()
        Dim Command As New SqlCommand("Select * from customers")

        'Set the command to the current connection
        Command.Connection = Con

        'Specify the sqlcommand object that contains SQL query
        Adapter.SelectCommand = Command

        'Fill Data Set
        Adapter.Fill(Results, "Customers")

        'Set Data Set equal to DataGrid
        Me.grdDataGrid.DataSource = Results.Tables(0)
        Me.grdDataGrid.Visible() = True
        Me.grdDataGrid.AllowSorting = True
    End Sub

    Protected Sub cmdLoadDRList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLoadDRList.Click
        Dim DataReader As SqlDataReader
        Dim Command As New SqlCommand("Select * from customers")
        Command.Connection = Con

        Me.lstBox.Items.Clear()

        'Execute the DataReader Command
        DataReader = Command.ExecuteReader()

        'DataReader is always set to the first row of the data set
        While (DataReader.Read)
            'For each row we add the CompanyName to the DataReader ListBox
            Me.lstBox.Items.Add(DataReader("CompanyName").ToString)
        End While

        'Close the SqlDataReader
        If Not DataReader.IsClosed Then
            DataReader.Close()
        End If
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
