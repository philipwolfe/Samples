Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Configuration


Public Class StoredProcedureUDFForm

    ''' <summary>
    ''' In the Form1 constructor, we must create the table in the tempdb database so we can execute
    ''' our stored procedure and user defined function.
    ''' </summary>

    Public Sub New()

        Try

        ' This call is required by the Windows Form Designer.
            InitializeComponent()
            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")

            Dim myQuery As String = "IF NOT EXISTS (SELECT * FROM sysobjects where name='GeoCache' and xtype='U') " _
                & " CREATE TABLE GeoCache " _
                & "(" _
                & " ID int IDENTITY(1,1)," _
                & " longitude1 float(53), " _
                & " latitude1 float (53), " _
                & " longitude2 float(53), " _
                & " latitude2 float (53), " _
                & " distance float (53), " _
                & ") "

            Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
            myConnection.Open()
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            myCommand.ExecuteNonQuery()

            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error starting this application. Please start again.", "Alert")
            latitude1TextBox.Enabled = False
            longitude1TextBox.Enabled = False
            latitude2TextBox.Enabled = False
            longitude2TextBox.Enabled = False
            insertNewDataButton.Enabled = False
            retrieveDataButton.Enabled = False

        End Try

    End Sub
    ''' <summary>
    ''' In this button click event, we are taking the user input to calculate the
    ''' distance between the two points Imports a user defined function and then 
    ''' we insert all those values into the table Imports another stored procedure that is 
    ''' defined in the StoredProcedures class.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub insertNewDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertNewDataButton.Click
        Try

            insertNewDataButton.Text = "Processing..."
            insertNewDataButton.Enabled = False

            If Not IsNumeric(longitude1TextBox.Text) Or longitude1TextBox.Text = "" Then
                MessageBox.Show("Please enter a valid longitude 1 value.", "Alert")
            ElseIf Not IsNumeric(latitude1TextBox.Text) Or latitude1TextBox.Text = "" Then
                MessageBox.Show("Please enter a valid latitude 1 value.", "Alert")
            ElseIf Not IsNumeric(longitude2TextBox.Text) Or longitude2TextBox.Text = "" Then
                MessageBox.Show("Please enter a valid longitude 2 value.", "Alert")
            ElseIf Not IsNumeric(latitude2TextBox.Text) Or latitude2TextBox.Text = "" Then
                MessageBox.Show("Please enter a valid latitude 2 value.", "Alert")
            Else

                '' This is the new StopWatch class which allows us 
                '' to keep track of timed events simply
                Dim myWatch As Stopwatch = New Stopwatch()

                Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
                Dim myQuery As String = ""
                Dim myDataSet As DataSet = New DataSet()
                Dim longitude1 As Double = Convert.ToDouble(longitude1TextBox.Text.ToString())
                Dim latitude1 As Double = Convert.ToDouble(latitude1TextBox.Text.ToString())
                Dim longitude2 As Double = Convert.ToDouble(longitude2TextBox.Text.ToString())
                Dim latitude2 As Double = Convert.ToDouble(latitude2TextBox.Text.ToString())
                Dim distance As Double = 0


                myWatch.Start()
                Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
                myConnection.Open()

                '' Here is where we use the User Defined Function to return the distance
                '' between two latitude/longitude pairs
                myQuery = "SELECT dbo.CalculateDistance (" & longitude1 & "," & latitude1 & "," & longitude2 & "," & latitude2 & ") as myDistance"
                Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(myCommand)
                myDataAdapter.Fill(myDataSet)
                distance = Convert.ToDouble(myDataSet.Tables(0).Rows(0).Item("myDistance"))

                '' After the distance is calculated, we want to insert the values into the table
                myQuery = "spInsertData"
                myCommand.CommandText = myQuery
                myCommand.Parameters.AddWithValue("@latitude1", latitude1)
                myCommand.Parameters.AddWithValue("@longitude1", longitude1)
                myCommand.Parameters.AddWithValue("@latitude2", latitude2)
                myCommand.Parameters.AddWithValue("@longitude2", longitude2)
                myCommand.Parameters.AddWithValue("@distance", distance)
                myCommand.CommandType = CommandType.StoredProcedure
                myCommand.ExecuteNonQuery()

                myWatch.Stop()
                myConnection.Close()

                '' We return some user interface feedback here
                elapsedTimeLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
                actionLabel.Text = "Action: Data Inserted!"
                latitude1TextBox.Text = ""
                longitude1TextBox.Text = ""
                latitude2TextBox.Text = ""
                longitude2TextBox.Text = ""
            End If

            
        Catch ex As Exception
            MessageBox.Show("There was an error inserting the data. Please try again.", "Alert")
        End Try

        insertNewDataButton.Text = "Insert New Data"
        insertNewDataButton.Enabled = True

    End Sub
    ''' <summary>
    ''' In this event, we are retrieving the data Imports another stored procedure
    ''' that returns the data that is stored in the table. This stored procedure is one
    ''' of two SqlProcedures in the StoredProcedures class.  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub retrieveDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retrieveDataButton.Click

        '' Here we are just returning the data that is stored in the table
        Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
        Dim myQuery As String = "spGetData"
        Dim myWatch As Stopwatch = New Stopwatch()
        Dim myDataSet As DataSet = New DataSet()

        Try

            retrieveDataButton.Text = "Processing..."
            retrieveDataButton.Enabled = False

            myWatch.Start()
            Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
            myConnection.Open()
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(myCommand)
            myDataAdapter.Fill(myDataSet)

            resultsDataGridView.DataSource = myDataSet.Tables(0)
            myWatch.Stop()
            myConnection.Close()

            elapsedTimeLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
            actionLabel.Text = "Action: Data Retrieved!"


        Catch ex As Exception
            MessageBox.Show("There was an error displaying the data. Please try again.", "Alert")
        End Try

        retrieveDataButton.Text = "Retrieve Data"
        retrieveDataButton.Enabled = True

    End Sub
End Class
