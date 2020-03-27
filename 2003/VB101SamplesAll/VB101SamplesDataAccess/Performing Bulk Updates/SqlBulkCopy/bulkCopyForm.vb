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


Public Class bulkCopyForm

    Dim myDataSet As New DataSet
    Public NOTIFICATION_TOLERANCE As Integer = 10
    Public PROGRESS_STEP As Integer = 10
    Private progressCount As Integer = 0
    Private progressIterator As Integer = 1

    ''' <summary>
    ''' This event fires when the form is first loaded.  It initializes the datagridview 
    ''' with data and initializes the progress bar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bulkCopyForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillNumberofRows()
        copyProgressProgressBar.Step = PROGRESS_STEP
        numberOfRowsComboBox.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' In this event, the first data table is filled with integers so that it
    ''' can be queried and copied later using SqlBulkCopy
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fillTableButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fillTableButton.Click
        Try
            fillTableButton.Enabled = False
            fillTableButton.Text = "Filling..."
            Application.DoEvents()

            '' We want to keep track of time required to insert all these values.
            Dim myWatch As Stopwatch = New Stopwatch()

            '' This is where we are inserted all the values
            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myConnection As SqlConnection = New SqlConnection(connectionString)

            myConnection.Open()
            myWatch.Start()
            Dim myCount As Integer = Convert.ToInt32(numberOfRowsComboBox.SelectedItem)
            Dim i As Integer
            For i = 0 To myCount

                Dim queryString As String = "INSERT INTO Data(value1) VALUES(" & i & ")"
                Dim myCommand As SqlCommand = New SqlCommand(queryString, myConnection)
                myCommand.ExecuteNonQuery()
            Next

            '' stop timing the event and display the results
            myWatch.Stop()
            If (Convert.ToBoolean(Convert.ToInt32(myWatch.ElapsedMilliseconds) > 1000)) Then

                elapsedTimeLabel.Text = Convert.ToString(myWatch.ElapsedMilliseconds / 1000) & " sec"

            Else
                elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
            End If

            '' Display how many rows were copied
            rowsCopiedTextLabel.Text = "Rows Inserted: "
            rowsCopiedLabel.Text = myCount.ToString()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error filling the tables.  Please try again.", "Alert")
        Finally
            fillTableButton.Text = "Fill Data"
            fillTableButton.Enabled = True
        End Try
    End Sub

    ''' <summary>
    ''' This method simulates copying data from the dataset into another table.
    ''' This table can exist on the current server or on a remote server depending on the
    ''' the location specified in the connection string.  Performance is shown in this method as well.
    ''' The SqlRowsCopiedEventHandler is also added so that constant feedback can be provided to the user
    ''' as copying occurs.
    ''' </summary>
    Private Sub CopyUsingSqlBulkCopy()

        copyDataButton.Enabled = False
        copyDataButton.Text = "Copying..."
        Application.DoEvents()

        rowsCopiedLabel.Text = "0"
        progressIterator = 1
        Dim myWatch As Stopwatch = New Stopwatch()
        Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
        '' Create a connection to where the data is to be copied to
        Dim myConnection As SqlConnection = New SqlConnection(connectionString)

        '' start the timer
        myWatch.Start()

        '' create a new SqlBulkCopy object
        Dim myBulkCopy As SqlClient.SqlBulkCopy = New SqlClient.SqlBulkCopy(myConnection)

        '' Add the SqlRowsCopiedEventHandler so that progress can be shown
        AddHandler myBulkCopy.SqlRowsCopied, AddressOf onSqlRowsCopied


        '' You want to indicate when you want the event to fire
        myBulkCopy.NotifyAfter = NOTIFICATION_TOLERANCE

        '' Specify the name of the table to where the data will be copied
        myBulkCopy.DestinationTableName = "Data2"

        Try

            ''Open the connection
            myConnection.Open()
            '' Here is where you are executing the command to copy the contents of the dataset
            '' into the specified table
            myBulkCopy.WriteToServer(myDataSet.Tables("MyTable"))
            '' Close the SqlBulkCopy object
            myBulkCopy.Close()
            '' Stop the timing so we can see how long it took to copy the data
            myWatch.Stop()
            '' Display the time	
            If (Convert.ToBoolean(Convert.ToInt32(myWatch.ElapsedMilliseconds) > 1000)) Then

                elapsedTimeLabel.Text = Convert.ToString(myWatch.ElapsedMilliseconds / 1000) & " sec"

            Else
                elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
            End If
            '' Display the data that was moved
            resultsDataGridView.DataSource = myDataSet.Tables("MyTable")
            '' Display how many rows were copied
            rowsCopiedTextLabel.Text = "Rows Copied: "
            rowsCopiedLabel.Text = numberOfRowsComboBox.SelectedItem.ToString()

            '' set the progress bar to complete
            copyProgressProgressBar.Value = 100
            '' Close the connection
            myConnection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Alert")
        Finally
            copyDataButton.Text = "Copy Data"
            copyDataButton.Enabled = True
        End Try
    End Sub

    ''' <summary>
    ''' This is the event that is handled every time the notification criteria is met. 
    ''' The progress bar is updated based on the number of rows that are being copied.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OnSqlRowsCopied(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs)

        Dim updateTolerance As Integer = 0
        updateTolerance = Convert.ToInt32((Convert.ToDouble(numberOfRowsComboBox.SelectedItem) * 0.1))

        progressCount = progressCount + NOTIFICATION_TOLERANCE

        If progressCount = updateTolerance Then

            progressCount = 0
            copyProgressProgressBar.Value = progressIterator * PROGRESS_STEP
            progressIterator = progressIterator + 1
        End If


    End Sub

    ''' <summary>
    ''' The method retrieves the specified data from the database and fills the dataset that is used
    ''' in the SqlBulkCopy operation. 
    ''' </summary>
    Private Sub RetrieveDataSet()

        Try

            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myConnection As SqlConnection = New SqlConnection(connectionString)
            myConnection.Open()
            Dim queryString As String = "SELECT TOP " & numberOfRowsComboBox.SelectedItem.ToString() & " * FROM Data"
            Dim myCommand As SqlCommand = New SqlCommand(queryString, myConnection)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(myCommand)
            myDataAdapter.Fill(myDataSet, "MyTable")
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Please click the 'Fill Data' button first.", "Alert")
        End Try

    End Sub

#Region "Helper Functions"

    ''' <summary>
    ''' This method adds the number of rows choice to the 
    ''' combobox in a power of ten.
    ''' </summary>
    Private Sub FillNumberofRows()
        Dim i As Integer
        For i = 2 To 7

            numberOfRowsComboBox.Items.Add(System.Math.Pow(10, i))
        Next
    End Sub

    ''' <summary>
    ''' This event gets the data that is stored in the database and 
    ''' then copies it to another data source.  in this case, it copies it
    ''' into the same database, but it could another data source.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub getDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyDataButton.Click

        Application.DoEvents()
        myDataSet.Clear()
        ClearControls()
        RetrieveDataSet()
        CopyUsingSqlBulkCopy()
    End Sub

    ''' <summary>
    ''' This reinstates the original state of all the controls.
    ''' </summary>
    Private Sub ClearControls()

        copyProgressProgressBar.Value = 0
        rowsCopiedLabel.Text = ""
        elapsedTimeLabel.Text = ""
        progressIterator = 1
    End Sub

    ''' <summary>
    ''' This event clears all the controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub numberOfRowsComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numberOfRowsComboBox.SelectedIndexChanged
        ClearControls()
    End Sub

#End Region

End Class
