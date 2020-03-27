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

Public Class MultipleActiveResultSetsForm


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        withoutMARSRadioButton.Checked = True

    End Sub
    ''' <summary>
    ''' This event calls methods depending on which radio button is selected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub retrieveDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retrieveDataButton.Click

        Try

            retrieveDataButton.Text = "Processing..."
            retrieveDataButton.Enabled = False

            If withMARSRadioButton.Checked Then
                FillUserAddressesWithMARS()
            Else
                FillUserAddressesWithoutMARS()
            End If

            retrieveDataButton.Enabled = True
            retrieveDataButton.Text = "Retrieve Data"

        Catch ex As Exception
            MessageBox.Show("There was an error retrieving the data.", "Alert")
        End Try

    End Sub

    ''' <summary>
    ''' This method fills employee and address information using Multiple Active Result Sets
    ''' This is set in the connection string by setting the MultipleActiveResultSets to true
    ''' by default it is set to true if ommitted.  
    ''' By setting Multiple Active Results Sets, multiple data readers can be opened
    ''' by using the same connection without any blocking from occurring.
    ''' </summary>
    Private Sub FillUserAddressesWithMARS()

        Dim myEmployeeID As Integer = 0
        Dim myAddressReader As SqlDataReader
        Dim myWatch As Stopwatch = New Stopwatch()
        Dim myFinalString As String = ""
        Dim myConnectionCount As Integer = 0

        Try

        '' explicitly set the connection string to support Multiple Active Result Sets.
            Dim connectionString As String = ConfigurationManager.AppSettings("myMarsConnectionString")


            '' Set the query strings
            Dim myEmployeeQuery As String = "SELECT * FROM Employees ORDER BY LastName"
            Dim myAddressQuery As String = "SELECT * FROM Addresses WHERE EmployeeID = @EmployeeID"

            '' Use the new StopWatch class to time the retrieval and display of data
            myWatch.Start()

            '' Encapsulate the retrieval with this one connection
            Using myConnection As SqlConnection = New SqlConnection(connectionString)

                '' Open the connection and incrase the count
                myConnection.Open()
                myConnectionCount = myConnectionCount + 1

                '' We create both SqlCommand objects using the same connection
                Dim myEmployeeCommand As SqlCommand = New SqlCommand(myEmployeeQuery, myConnection)
                Dim myAddressCommand As SqlCommand = New SqlCommand(myAddressQuery, myConnection)

                '' Add the parameter to the address command, this will allow us
                '' to get all the addresses for each employee id
                myAddressCommand.Parameters.AddWithValue("@EmployeeID", SqlDbType.Int)

                '' We are going to go through all the Employee records
                Using myEmployeeReader As SqlDataReader = myEmployeeCommand.ExecuteReader()

                    While myEmployeeReader.Read()

                        '' We want to display the name of the employee in the final text box
                        Dim myName As String = myEmployeeReader("FirstName").ToString() & " " & myEmployeeReader("LastName").ToString()
                        myFinalString = myFinalString & myName & vbCrLf

                        '' Retrieve the EmployeeID for getting all the addresses
                        myEmployeeID = Convert.ToInt32(myEmployeeReader("EmployeeID"))

                        myAddressCommand.Parameters("@EmployeeID").Value = myEmployeeID


                        '' get the address information
                        myAddressReader = myAddressCommand.ExecuteReader()
                        Using myAddressReader
                            If myAddressReader.HasRows Then

                                '' retrieve all the addresses in the DataReader object
                                While myAddressReader.Read()

                                    Dim myAddress As String = myAddressReader("Address").ToString()
                                    Dim myCity As String = myAddressReader("City").ToString()
                                    Dim myState As String = myAddressReader("State").ToString()
                                    Dim myZipCode As String = myAddressReader("ZipCode").ToString()
                                    Dim myAddressType As String = myAddressReader("AddressType").ToString()

                                    myFinalString = myFinalString & myAddress + vbCrLf _
                                     & myCity & ", " & myState & " " & myZipCode & vbCrLf _
                                     & "Address Type: " & myAddressType & vbCrLf & vbCrLf
                                End While

                            Else
                                myFinalString = myFinalString & "No Address " & vbCrLf & vbCrLf
                            End If
                        End Using
                    End While
                End Using
                '' Close the connection
                myConnection.Close()
            End Using
            '' Stop the StopWatch so that we can display the time
            myWatch.Stop()
            '' Display the time elapsed
            elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
            '' Display how many connections were created
            connectionNumberLabel.Text = myConnectionCount.ToString()
            '' set some properties for the RichTextBox
            displayedDataRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical
            displayedDataRichTextBox.WordWrap = True
            '' Assign the final data
            displayedDataRichTextBox.Text = myFinalString

        Catch ex As Exception
            MessageBox.Show("There was an error retrieving data using MARS", "Alert")
        End Try

    End Sub

    ''' <summary>
    ''' This method creates and displays information using the previous method
    ''' in which multiple connections are required to interleave Employee data
    ''' and Address data
    ''' </summary>
    Private Sub FillUserAddressesWithoutMARS()

        Dim myEmployeeID As Integer = 0
        Dim myAddressReader As SqlDataReader
        Dim myWatch As Stopwatch = New Stopwatch()
        Dim myFinalString As String = ""
        Dim myConnectionCount As Integer = 0

        Try

        '' Create connection string with the MultipleActiveResultSet is set to false
            Dim connectionString As String = ConfigurationManager.AppSettings("myNonMarsConnectionString")

            '' set the query strings here
            Dim myEmployeeQuery As String = "SELECT * FROM Employees ORDER BY LastName"
            Dim myAddressQuery As String = "SELECT * FROM Addresses WHERE EmployeeID = @EmployeeID"

            '' Using the new StopWatch class, you can start the stop watch
            '' so we can time how long it takes to display Employee and Address
            '' data
            myWatch.Start()

            '' Use the first connection to retrieve Employee data
            Dim myConnection As SqlConnection = New SqlConnection(connectionString)

            myConnection.Open()
            myConnectionCount = myConnectionCount + 1

            Dim myEmployeeCommand As SqlCommand = New SqlCommand(myEmployeeQuery, myConnection)

            Dim myEmployeeReader As SqlDataReader = myEmployeeCommand.ExecuteReader()

            '' Iterate through the Employee data 
            While myEmployeeReader.Read()


                Dim myName As String = myEmployeeReader("FirstName").ToString() & " " & myEmployeeReader("LastName").ToString()
                myFinalString = myFinalString & myName & vbCrLf

                myEmployeeID = Convert.ToInt32(myEmployeeReader("EmployeeID"))

                '' Each time we iterate through the Employee data, we have to 
                '' open a second connection so that we can retrieve the 
                '' address data
                Dim mySecondConnection As SqlConnection = New SqlConnection(connectionString)

                mySecondConnection.Open()
                myConnectionCount = myConnectionCount + 1

                '' Create an Address Command object
                Dim myAddressCommand As SqlCommand = New SqlCommand(myAddressQuery, mySecondConnection)
                myAddressCommand.Parameters.AddWithValue("@EmployeeID", SqlDbType.Int)

                myAddressCommand.Parameters("@EmployeeID").Value = myEmployeeID

                '' Get the Address data based on the EmployeeID
                myAddressReader = myAddressCommand.ExecuteReader()

                If myAddressReader.HasRows Then

                    While myAddressReader.Read()

                        '' Retrieve the address information
                        Dim myAddress As String = myAddressReader("Address").ToString()
                        Dim myCity As String = myAddressReader("City").ToString()
                        Dim myState As String = myAddressReader("State").ToString()
                        Dim myZipCode As String = myAddressReader("ZipCode").ToString()
                        Dim myAddressType As String = myAddressReader("AddressType").ToString()

                        myFinalString = myFinalString & myAddress & vbCrLf _
                            & myCity & ", " & myState & " " & myZipCode & vbCrLf _
                            & "Address Type: " & myAddressType & vbCrLf & vbCrLf
                    End While

                Else
                    myFinalString = myFinalString + "No Address " & vbCrLf

                    '' Close the second connection so that we can open another the next time
                    '' through the list
                    mySecondConnection.Close()
                End If
            End While
            '' Stop the StopWatch so that we can display the time
            myWatch.Stop()
            '' Assign the time for display
            elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
            '' Display the connection count
            connectionNumberLabel.Text = myConnectionCount.ToString()
            '' Set the RichTextBox properties
            displayedDataRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical
            displayedDataRichTextBox.WordWrap = True
            displayedDataRichTextBox.Text = myFinalString


            myConnection.Close()

        Catch ex As Exception

            MessageBox.Show("There was an error retrieving the data without MARS.", "Alert")
        End Try

    End Sub

End Class
