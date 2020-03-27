
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Threading
Imports System.Data
Imports System.Configuration


Public Class asynchronousForm

#Region "Polling Section"

    ''' <summary>
    ''' This event makes a call to the RetrieveByPolling, which returns data
    ''' asynchronously and polls to see if the execute has completed or not
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub pollingAsynchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pollingAsynchButton.Click

        pollingAsynchButton.Text = "Processing..."
        pollingAsynchButton.Enabled = False
        queryStatusStatusBar.Enabled = True
        statusLabel.Enabled = True

        '' Allow other events to continue operating while this executing
        Application.DoEvents()
        '' Clear all the form controls before this runs
        ClearControls()
        '' Get the data
        RetrieveByPolling()

        pollingAsynchButton.Text = "Polling"
        pollingAsynchButton.Enabled = True

    End Sub
    ''' <summary>
    ''' This method retrieves data from a database asynchronously.  Other tasks can continue
    ''' to perform while the data is returned and when the data does return, then it will
    ''' display its contents in the DataGridView
    ''' </summary>
    Private Sub RetrieveByPolling()


        '' Use the new StopWatch class to keep track of the performance
        '' of using this technique
        Dim myWatch As Stopwatch = New Stopwatch()

        '' To allow for asynchronous processing these connection strings have to
        ''include "Asynchronous Processing=true"
        Dim myConnectionString As String = ConfigurationManager.AppSettings("myAsyncConnectionString")

        '' Here we are going to start an asynchronous request 
        myWatch.Start()
        Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)

        Try

            '' Create a Delay in the query to simulate a really large query so we
            '' can do some polling
            Dim myQuery As String = "WAITFOR DELAY '0:0:3';" _
                 & "SELECT * FROM Data1 ORDER BY ID DESC"


            Dim myCount As Integer = 0
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            myConnection.Open()

            '' We use the BeginExecuteReader which returns a IAsyncResult
            '' which can be polled to see if it's complete
            Dim myResult As IAsyncResult = myCommand.BeginExecuteReader()
            While Not myResult.IsCompleted


                myCount = myCount + 1
                '' We are just updating the status bar to
                '' show that we are in process until the result returns with 
                '' finished
                queryStatusStatusBar.Step = 1
                queryStatusStatusBar.Value = myCount
                If myCount = 100 Then
                    myCount = 0
                End If

            End While


            '' After the result finishes, we can end the reader
            Dim myReader As SqlDataReader = myCommand.EndExecuteReader(myResult)
            myWatch.Stop()

            '' We are just finishing up here displaying all the information
            elapsedTime.Text = myWatch.ElapsedMilliseconds.ToString() + " ms"
            messageReturned.Text = "Data Returned by Polling!"
            Dim myTable As DataTable = New DataTable()
            myTable.Load(myReader)
            population1DataGridView.DataSource = myTable
            queryStatusStatusBar.Value = 100


        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Alert")
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message.ToString(), "Alert")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Alert")
        End Try

    End Sub

#End Region

#Region "Fill Data Section"

    ''' <summary>
    ''' In this method, we are just filling the database with some values.
    ''' </summary>
    Private Sub FillData()

        Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")


        Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
        myConnection.Open()
        Dim i As Integer
        Dim myRandom As New Random()
        Dim myMultiplier As Integer

        For i = 0 To 100
            myMultiplier = myRandom.Next(1, 100)
            Dim myQuery As String = "INSERT INTO Data1 (value1) VALUES(" & i * myMultiplier & ")"
            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            myCommand.ExecuteNonQuery()

            myMultiplier = myRandom.Next(1, 50)
            Dim myQuery2 As String = "INSERT INTO Data2 (value1) VALUES(" & i * myMultiplier & ")"
            Dim myCommand2 As SqlCommand = New SqlCommand(myQuery2, myConnection)
            myCommand2.ExecuteNonQuery()

        Next
        myConnection.Close()

    End Sub
    Private Sub fillTablesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fillTablesButton.Click
        Try
            Me.fillTablesButton.Text = "Filling..."
            Me.fillTablesButton.Enabled = False
            Application.DoEvents()
            ClearControls()
            FillData()
            messageReturned.Text = "Population Data has been added!"
            Me.fillTablesButton.Text = "Fill Tables"
            Me.fillTablesButton.Enabled = True
        Catch ex As Exception
            MessageBox.Show("There was an error filling the tables.  Please try again.", "Alert")
        End Try

    End Sub


#End Region

#Region "CallBack Section"

    '' Create these delegates so that you can display user messages, timing messages,
    '' the dataGridView data.
    Private Delegate Sub DisplayInfoDelegate(ByVal Text As String)

    Private Delegate Sub DisplayTimeInfoDelegate(ByVal Text As String)

    Private Delegate Sub DisplayDataGridViewDelegate(ByVal myTable As DataTable)

    '' This example maintains the connection object 
    '' externally, so that it's available for closing.
    Private myCallbackConnection As SqlConnection

    '' Create the StopWatch externally, so we can access it when the threads are done processing
    '' This new class allows us to keep track of time as we perform the callbacks
    Private myCallBackWatch As Stopwatch = New Stopwatch()

    ''' <summary>
    ''' This event calls the RetrieveByCallBack method so that we
    ''' can see an example of using CallBacks to retrieve data
    ''' asynchronously
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub callBackAsynchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles callBackAsynchButton.Click
        callBackAsynchButton.Text = "Processing..."
        callBackAsynchButton.Enabled = False
        queryStatusStatusBar.Enabled = False
        statusLabel.Enabled = False

        Application.DoEvents()
        ClearControls()

        RetrieveByCallBack()

        callBackAsynchButton.Text = "Callback"
        callBackAsynchButton.Enabled = True

    End Sub
    Private Sub RetrieveByCallBack()

        Dim myConnectionString As String = ConfigurationManager.AppSettings("myAsyncConnectionString")

        Dim myCommand As SqlCommand
        Try

            DisplayResults("")

            '' We use the using statement when calling this connection to ensure that it will 
            '' be closed when all the processing is done
            myCallbackConnection = New SqlConnection(myConnectionString)


            '' We are adding in a Delay so that we can simulate a long running
            '' query.
            Dim myQuery As String = "WAITFOR DELAY '0:0:05';" _
                        & "SELECT * FROM Data1 ORDER BY ID DESC "

            '' Create a new command
            myCommand = New SqlCommand(myQuery, myCallbackConnection)

            '' Open the connetion
            myCallbackConnection.Open()

            '' Provide user interface feedback before we start the processing
            DisplayResults("Executing...")

            '' We start the stop watch now
            myCallBackWatch.Start()

            '' We create a new AsyncCallBack object passing the HandleCallback
            Dim myCallBack As AsyncCallback = New AsyncCallback(AddressOf HandleCallback)
            '' Now we can start the asynchronous retrieval of data
            myCommand.BeginExecuteReader(myCallBack, myCommand)

        Catch ex As Exception

            DisplayResults(String.Format(ex.Message.ToString()))
            myCallbackConnection.Close()

        End Try
    End Sub
    ''' <summary>
    ''' This method displays the user message text that occurs during processing
    ''' and after processing completes
    ''' </summary>
    ''' <param name="Text"></param>
    Private Sub DisplayResults(ByVal Text As String)

        Me.messageReturned.Text = Text

    End Sub

    ''' <summary>
    ''' This method displays the time message to the user interface
    ''' after the callbacks are complete
    ''' </summary>
    ''' <param name="Text"></param>
    Private Sub DisplayTimeResults(ByVal Text As String)

        Me.elapsedTime.Text = Text
    End Sub

    ''' <summary>
    ''' This method binds the DataTable to the DataGridView after
    ''' the processing is complete and the Callbacks are done
    ''' </summary>
    ''' <param name="myTable"></param>
    Private Sub DisplayDataResults(ByVal myTable As DataTable)

        Me.population1DataGridView.DataSource = myTable
    End Sub

    ''' <summary>
    ''' This method is what is called when the callbacks are complete.  This handles all the callbacks
    ''' and finishes processing the results.
    ''' </summary>
    ''' <param name="myResult">
    ''' </param>
    Private Sub HandleCallback(ByVal myResult As IAsyncResult)

        Try

            '' We will get the original command object here in this
            '' method by accessing the AsyncState property
            '' of the IAsyncResult parameter.
            Dim myCommand As SqlCommand = myResult.AsyncState
            '' We complete the retrieval of data
            Dim myReader As SqlDataReader = myCommand.EndExecuteReader(myResult)

            '' We Stop the stopwatch so we can see how long it took to process
            myCallBackWatch.Stop()

            '' We create all the messages that are to be display in the form here
            Dim userMessage As String = "Data Returned by Callback!"
            Dim myCallBackTime As String = myCallBackWatch.ElapsedMilliseconds.ToString() & " ms"
            Dim myTable As DataTable = New DataTable()
            myTable.Load(myReader)


            '' Since we can't interact directly with the form, we have to create a new instance of each delegate
            '' and invoke the method of each delegate so we can display user messages, time messages, and bind
            '' the DataTable to the DataGridView
            Dim myUserDelegate As DisplayInfoDelegate = New DisplayInfoDelegate(AddressOf DisplayResults)
            Me.Invoke(myUserDelegate, userMessage)

            Dim myTimeDelegate As DisplayTimeInfoDelegate = New DisplayTimeInfoDelegate(AddressOf DisplayTimeResults)
            Me.Invoke(myTimeDelegate, myCallBackTime)

            Dim myDataDelegate As DisplayDataGridViewDelegate = New DisplayDataGridViewDelegate(AddressOf DisplayDataResults)
            Me.Invoke(myDataDelegate, myTable)


        Catch ex As Exception

            '' You have to handle exceptions here because there isn't any
            '' additional exception handling higher up.  To display the message, you have to 
            '' once again create an instance of a delegate and passed the method that you want 
            '' to use to display the message.

            Me.Invoke(New DisplayInfoDelegate(AddressOf DisplayResults), String.Format(ex.Message))

        Finally

            myCallbackConnection.Close()

        End Try

    End Sub

#End Region

#Region "Wait Section"

    ''' <summary>
    ''' This event calls the RetrieveByWait to examine asynchronous data retrieval by using the
    ''' wait commands.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>


    Private Sub waitAsynchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles waitAsynchButton.Click

        waitAsynchButton.Text = "Processing..."
        waitAsynchButton.Enabled = False
        queryStatusStatusBar.Enabled = False
        statusLabel.Enabled = False

        ClearControls()
        Application.DoEvents()
        RetrieveByWait()

        waitAsynchButton.Text = "Wait"
        waitAsynchButton.Enabled = True
    End Sub
    ''' <summary>
    ''' In this method, you can create a number of different connections to simulate connecting to a different databases, 
    ''' even those on different servers.  In this example, we are only connecting to one database.
    ''' </summary>
    Private Sub RetrieveByWait()

        '' Create two different stop watches
        Dim myWatch As New Stopwatch()
        Dim mySecondWatch As New Stopwatch()

        '' Set the connection string
        Dim myConnectionString As String = ConfigurationManager.AppSettings("myAsyncConnectionString")

        '' Create two different connection objects for the simlation
        Dim myConnection1 As SqlConnection = New SqlConnection(myConnectionString)
        Dim myConnection2 As SqlConnection = New SqlConnection(myConnectionString)

        '' We create two different query strings simulating two different running times of queries to 
        '' use for this example
        Dim myQuery1 As String = "WAITFOR DELAY '0:0:01';" _
          & "SELECT * FROM Data1 ORDER BY ID DESC"

        Dim myQuery2 As String = "WAITFOR DELAY '0:0:03';" _
          & "SELECT * FROM Data2 ORDER BY ID DESC "

        Try

            '' Start the two stopwatches
            myWatch.Start()
            mySecondWatch.Start()

            ''  We are going to open a connection for each query and begin 
            ''  execution. Using the IAsyncResult object returned by 
            ''  each BeginExecuteReader we can add a WaitHandle for each 
            ''  to the array.

            myConnection1.Open()
            Dim myCommand1 As SqlCommand = New SqlCommand(myQuery1, myConnection1)
            Dim myResult1 As IAsyncResult = myCommand1.BeginExecuteReader()
            Dim myWaitHandle1 As WaitHandle = myResult1.AsyncWaitHandle

            myConnection2.Open()
            Dim myCommand2 As SqlCommand = New SqlCommand(myQuery2, myConnection2)
            Dim myResult2 As IAsyncResult = myCommand2.BeginExecuteReader()
            Dim myWaitHandle2 As WaitHandle = myResult2.AsyncWaitHandle

            '' Add the wait handles to the WaitHandle Array so we can check for
            '' all the Wait handles as they come in
            Dim myWaitHandles As WaitHandle() = {myWaitHandle1, myWaitHandle2}

            Dim index As Integer
            Dim countWaits As Integer

            For countWaits = 0 To 2

                ''  We are going to se the WaitHandle to WaitAny.
                ''  This means that it is looking for any of the WaitHandles to
                '' complete.  The value that gets returned is the index of the array element 
                '' of the particular WaitHandle or it's the Timeout value
                index = WaitHandle.WaitAny(myWaitHandles, 5000, False)

                ''  Depending on which process returns, we display it's values in the
                '' DataGridView.  You could do additional processing here.  Since this is 
                '' happening asynchronously, we do not know which one will complete processing first.
                Select Case index

                    Case 0

                        Dim myReader1 As SqlDataReader = myCommand1.EndExecuteReader(myResult1)
                        '' Display information in the first DataGridView
                        If myReader1.Read() Then
                            myWatch.Stop()
                            elapsedTime.Text = "County 1: " _
                            & myWatch.ElapsedMilliseconds.ToString() & " ms"
                            Dim myTable As DataTable = New DataTable
                            myTable.Load(myReader1)
                            population1DataGridView.DataSource = myTable
                        End If
                        myReader1.Close()
                        Exit Select
                    Case 1
                        Dim myReader2 As SqlDataReader = myCommand2.EndExecuteReader(myResult2)
                        '' Display information in the second DataGridView
                        If myReader2.Read() Then
                            mySecondWatch.Stop()
                            elapsedTime2.Text = "County 2: " _
                            & mySecondWatch.ElapsedMilliseconds.ToString() & " ms"
                            Dim myTable As DataTable = New DataTable()
                            myTable.Load(myReader2)
                            population2DataGridView.DataSource = myTable
                        End If
                        myReader2.Close()
                        Exit Select
                    Case WaitHandle.WaitTimeout
                        Exit Select
                End Select
            Next

        Catch ex As Exception

            MessageBox.Show("There was an error with returning data using WaitHandles. Please try again.", "Alert")

        End Try

        myConnection1.Close()
        myConnection2.Close()
        messageReturned.Text = "Data Returned by WaitHandles!"

    End Sub
#End Region

    ''' <summary>
    ''' This method resets all the controls to their original state.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearControls()

        population1DataGridView.DataSource = ""
        population2DataGridView.DataSource = ""
        messageReturned.Text = ""
        elapsedTime.Text = ""
        elapsedTime2.Text = ""
        queryStatusStatusBar.Value = 0

    End Sub




End Class
