Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Threading
Imports System.Configuration


Public Class NotificationForm

    '' Notification SqlDependency
    Shared myDependency As SqlDependency
    '' Connection to the data source.
    Shared myConnection As SqlConnection
    '' Database table query.
    Shared myCommand As SqlCommand
    '' Local DataTable bound to the DataGrid.
    Shared myTable As DataTable
    '' DataAdapter to fill the DataTable.
    Shared myDataAdapter As SqlDataAdapter

    Private Delegate Sub DisplayInfoDelegate(ByVal Text As String)
    ''' <summary>
    ''' Initialize the form
    ''' </summary>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' In this method, called from Form_Load, we are initializing the table and the preliminary data. As well, we initialize the preliminary static
    ''' objects so that we can register and receive query notifications when data changes.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeData()
        Try

            '' get the connection string
            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            '' create a table with an ID, Geocache location, city
            Dim myQuery As String
            Dim localConnection As SqlConnection = New SqlConnection(connectionString)
            localConnection.Open()

            myQuery = "IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS " _
             & " WHERE TABLE_NAME = 'SampleView') " _
                    & " DROP VIEW SampleView"
            Dim localCommand As SqlCommand = New SqlCommand(myQuery, localConnection)
            localCommand.ExecuteNonQuery()

            myQuery = "IF EXISTS (SELECT * FROM sysobjects where name='SampleData' and xtype='U') " _
                & "DROP TABLE dbo.SampleData "

            localCommand.CommandText = myQuery
            localCommand.ExecuteNonQuery()

            myQuery = "CREATE TABLE dbo.SampleData ( " _
                   & "ID int IDENTITY(1,1) PRIMARY KEY, " _
                   & "Value1 float(53))"

            localCommand.CommandText = myQuery
            localCommand.ExecuteNonQuery()

            For i As Integer = 0 To 4

                myQuery = "INSERT INTO SampleData (Value1) VALUES(" & i & ")"
                localCommand.CommandText = myQuery
                localCommand.ExecuteNonQuery()
            Next

            myQuery = "CREATE VIEW SampleView " _
                    & " WITH SCHEMABINDING " _
                    & " AS " _
                    & " SELECT ID, Value1 FROM dbo.SampleData WHERE Value1 IN (0,1,2,3) "
            localCommand.CommandText = myQuery
            localCommand.ExecuteNonQuery()

            localConnection.Close()

            myConnection = New SqlConnection(ConfigurationManager.AppSettings("myConnectionString"))
            myCommand = New SqlCommand("SELECT ID, Value1 FROM SampleData ORDER BY Value1", myConnection)
            myDataAdapter = New SqlDataAdapter(myCommand)
            myTable = New DataTable("Values")
            DisplayData()

            ' Add any initialization after the InitializeComponent() call.
        Catch ex As Exception
            MessageBox.Show("There was an error starting this application.", "Alert")
            value1TextBox.Enabled = False
            insertButton.Enabled = False
            updateComboBox.Enabled = False
            updateButton.Enabled = False

        End Try

    End Sub
    ''' <summary>
    ''' This event inserts new data into the table to altering the dataset that woudl be returned 
    ''' providing a notification that will be sent back to the user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub insertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertButton.Click

        Try

            insertButton.Text = "Processing..."
            insertButton.Enabled = False

            If Not IsNumeric(value1TextBox.Text) Or value1TextBox.Text = "" Then
                MessageBox.Show("Please enter a valid number.", "Alert")
            Else

                Dim myWatch As Stopwatch = New Stopwatch()
                myWatch.Start()
                Dim myValue As Double = Convert.ToDouble(value1TextBox.Text.ToString())
                myConnection.Open()
                Dim myQuery As String = "INSERT INTO SampleData (Value1) VALUES(" & myValue & ")"
                Dim localCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
                localCommand.ExecuteNonQuery()
                myConnection.Close()
                myWatch.Stop()
                elapsedTimeLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
                actionLabel.Text = "Action: Data Inserted."
                value1TextBox.Text = ""

                DisplayData()

            End If

            insertButton.Text = "Insert Data"
            insertButton.Enabled = True

        Catch ex As Exception
            MessageBox.Show("There was an error inserting data.", "Alert")
        End Try

    End Sub

    ''' <summary>
    ''' This event updates data based on the ID that is chosen from the combobox.  Once the data
    ''' is altered, a notification should arise telling you that data has been altered.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub updateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click

        Dim myWatch As Stopwatch = New Stopwatch()
        Try
            updateButton.Text = "Processing..."
            updateButton.Enabled = False

            myWatch.Start()
            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim localConnection As SqlConnection = New SqlConnection(connectionString)
            localConnection.Open()
            Dim myQuery As String = "UPDATE SampleData SET Value1 = 111 WHERE ID=" & updateComboBox.SelectedItem.ToString()
            Dim localCommand As SqlCommand = New SqlCommand(myQuery, localConnection)
            localCommand.ExecuteNonQuery()
            localConnection.Close()
            myWatch.Stop()
            elapsedTimeLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
            actionLabel.Text = "Action: Data Updated"

            DisplayData()

            updateButton.Text = "Update Data"
            updateButton.Enabled = True

        Catch ex As Exception
            MessageBox.Show("There was an error updating.", "Alert")
        End Try


    End Sub
    ''' <summary>
    ''' This method displays the user message text that occurs during processing
    ''' and after processing completes
    ''' </summary>
    ''' <param name="Text"></param>
    Private Sub DisplayResults(ByVal Text As String)

        MessageBox.Show(Text, "Information")

    End Sub

    ''' <summary>
    ''' This event is called whenever a notification that the data has changed occurs.  This indicates
    ''' that the data has changed and the information surrounding that change.
    ''' </summary>
    ''' <param name="caller"></param>
    ''' <param name="args"></param>
    Private Sub MySqlDependencyChange(ByVal caller As Object, ByVal args As SqlNotificationEventArgs)
        Try

        ' MessageBox.Show("Source data has changed. Data is being refreshed.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim userMessage As String = "Source data has changed. Data is being refreshed."
            Dim myUserDelegate As DisplayInfoDelegate = New DisplayInfoDelegate(AddressOf DisplayResults)
            Me.Invoke(myUserDelegate, userMessage)
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' This method sets the creates the SqlDependency that is associated to the 
    ''' command object.  This adds a new event handler that calls the MySqlDependencyChange method
    ''' whenever a changed in the data is detected.
    ''' </summary>
    ''' <param name="cmd"></param>
    Private Sub SetupDependency(ByVal cmd As SqlCommand)


        ' Unregister any previous event handlers.
        If Not myDependency Is Nothing Then
            RemoveHandler myDependency.OnChange, AddressOf MySqlDependencyChange
        End If

        ' Clear out any existing notification information from the command.
        cmd.Notification = Nothing

        ' Create the SqlDependency and associate it with the query command.
        myDependency = New SqlDependency(cmd)
        AddHandler myDependency.OnChange, New OnChangeEventHandler(AddressOf MySqlDependencyChange)

        SqlDependency.Start(cmd.Connection.ConnectionString)
    End Sub

    ''' <summary>
    ''' This method simply calls the SetupDependency method passing the command object as a parameter
    ''' and then gets the most recent verion of the data to display.
    ''' </summary>
    Private Sub DisplayData()
        Try

            myDataAdapter.SelectCommand.CommandText = "SELECT ID, Value1 FROM SampleData ORDER BY Value1"
            myTable.Clear()
            SetupDependency(myDataAdapter.SelectCommand)
            myDataAdapter.Fill(myTable)
            resultsDataGridView.DataSource = myTable
            FillComboBox()
        Catch ex As Exception
            MessageBox.Show("There was an error displaying the data.", "Alert")
        End Try

    End Sub


    ''' <summary>
    ''' This event is fired when the form is loaded and initializes data, then fills the combobox for the update event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub NotificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeData()
        FillComboBox()
    End Sub

    ''' <summary>
    ''' This method fills the combobox with the data from the table.
    ''' </summary>
    Private Sub FillComboBox()

        Try

            updateComboBox.Items.Clear()
            myConnection.Open()
            myCommand.CommandText = "SELECT * FROM dbo.SampleData"
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            '' process DataReader
            While (myReader.Read())
                updateComboBox.Items.Add(myReader(0).ToString())
            End While
            myReader.Close()
            myConnection.Close()

            updateComboBox.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("There was an error Filling the ComboBox.", "Alert")
        End Try

    End Sub


End Class
