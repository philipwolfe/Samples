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


Public Class UserDefinedTypesForm
    ''' <summary>
    ''' Since we are using the tempdb, we need to create the database that we will use for this example
    ''' Because of the User Defined Type, we need ot make sure the UDT project is built and deployed before
    ''' running this form.
    ''' </summary>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Try

        '' get the connection string
            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")

            '' create a table with an ID, Geocache location, city
            Dim myQuery As String = "IF NOT EXISTS (SELECT * FROM sysobjects where name='MyData' and xtype='U') " _
                    & "CREATE TABLE dbo.MyData ( " _
                    & "ID int IDENTITY(1,1) PRIMARY KEY, " _
                    & "GC GeoCache,City varchar(255))"

            Dim myConnection As SqlConnection = New SqlConnection(connectionString)
            myConnection.Open()
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error starting this application.", "Alert")
            enterNewLocationButton.Enabled = False
            longitudeTextBox.Enabled = False
            latitudeTextBox.Enabled = False
            cityTextBox.Enabled = False
        End Try

    End Sub

    ''' <summary>
    ''' In this event, data is inserted from user input into the database.
    ''' The longitude and latitude values are contained in the GeoCache 
    ''' user defined type.  User defined types allow us to group common data
    ''' together and stored in one type in a table.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub enterNewLocationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enterNewLocationButton.Click
        Dim longitude As Double = 0
        Dim latitude As Double = 0
        Dim city As String = ""
        Dim myQuery As String = ""
        Try

            enterNewLocationButton.Text = "Processing..."
            enterNewLocationButton.Enabled = False

        If Not IsNumeric(longitudeTextBox.Text) Or longitudeTextBox.Text = "" Then
                MessageBox.Show("Please enter a valid longitude.", "Alert")
            ElseIf Not IsNumeric(latitudeTextBox.Text) Or latitudeTextBox.Text = "" Then
                MessageBox.Show("Please enter a valid latitude.", "Alert")
            ElseIf cityTextBox.Text = "" Then
                MessageBox.Show("Please enter a city.", "Alert")

            Else

                Dim myWatch As Stopwatch = New Stopwatch()
                Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
                longitude = Convert.ToDouble(longitudeTextBox.Text.ToString())
                latitude = Convert.ToDouble(latitudeTextBox.Text.ToString())
                city = cityTextBox.Text.ToString()

                myWatch.Start()
                Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
                myConnection.Open()

                '' We have to convert the data collected into the user defined type so that it can be stored properly.
                '' It will call the Parse method of the User defined class to insert this data.			
                myQuery = "INSERT INTO MyData (GC,City) VALUES(CONVERT(GeoCache,'" & longitude & "," & latitude & "'),'" & city & "')"

                Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
                myCommand.ExecuteNonQuery()

                ShowData()
                myWatch.Stop()
                timeElapsedLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
                myConnection.Close()
                longitudeTextBox.Text = ""
                latitudeTextBox.Text = ""
                cityTextBox.Text = ""
            End If

            enterNewLocationButton.Text = "Enter a New Geocache Location"
            enterNewLocationButton.Enabled = True

        Catch ex As Exception
            MessageBox.Show("There was an error inserting data.", "Alert")
        End Try

    End Sub

    ''' <summary>
    ''' This method retrieves the data from the table including the user defined type.  
    ''' In the select list, it calls the overloaded ToString() method of the user defined
    ''' type class to display the data stored.
    ''' </summary>
    Private Sub ShowData()


        '' We retrieve the data from the table and use the ToString method of the User Defined Type
        '' to return the values stored in that type.
        Dim myQuery As String = "SELECT ID,GC.ToString() as myGC, City FROM MyData"
        Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
        Dim myResults As String = ""
        Dim myDataSet As DataSet = New DataSet()
        Try

        Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
            myConnection.Open()
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            Dim myDataAdpater As SqlDataAdapter = New SqlDataAdapter(myCommand)
            myDataAdpater.Fill(myDataSet)

            For i As Integer = 0 To myDataSet.Tables(0).Rows.Count - 1

                myResults = myResults + "ID: " & myDataSet.Tables(0).Rows(i).Item("ID").ToString() & vbCrLf & "GeoCache Location: " + myDataSet.Tables(0).Rows(i).Item("myGC").ToString() & vbCrLf & "City:" & myDataSet.Tables(0).Rows(i).Item("City").ToString() & vbCrLf & vbCrLf

            Next
            displayRichTextBox.Text = myResults
            rowsAffectedLabel.Text = "Rows Affected: " & myDataSet.Tables(0).Rows.Count.ToString()

            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error displaying the data.", "Alert")
        End Try

    End Sub


End Class
