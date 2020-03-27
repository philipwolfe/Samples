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


Public Class batchUpdateForm

Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")

    Private myDataAdapter As SqlDataAdapter
    Private myDataSet As DataSet
    Private myDataTable As DataTable
    Private myConnection As SqlConnection
    Private myStringBuilder As New StringBuilder()

    Public Sub New()

        Try

            InitializeComponent()

            '' We want to initialize the DataAdapter, add the event handler so we 
            '' provide feedback to the user, and build the insert, update, and delete command for
            '' the DataAdapter.  We also want to display any information that is already stored in the database.
            Dim myQuery As String = "SELECT * FROM SampleData"
            myDataAdapter = New SqlDataAdapter(myQuery, myConnectionString)
            AddHandler myDataAdapter.RowUpdated, AddressOf RowUpdatedHandler

            BuildCommands()

            myDataSet = New DataSet()
            myDataSet.CaseSensitive = True
            myDataAdapter.Fill(myDataSet, "SampleData")

            FillDataGridView()

            FillDataSetSize()

            batchSizeComboBox.SelectedIndex = 0
            dataSetSizeComboBox.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("There was an error in the application: " & ex.Message.ToString(), "Alert")
            insertDataButton.Enabled = False
            batchSizeComboBox.Enabled = False
            dataSetSizeComboBox.Enabled = False
        End Try

    End Sub

    ''' <summary>
    ''' This method creates all the SqlDataAdapter commands to either Insert, Update or Delete.
    ''' For this example, only the insert is leveraged, but the Update and Delete could be
    ''' implemented easily.
    ''' </summary>
    Private Sub BuildCommands()

        '' Get the connection that is used by the SqlDataAdapter
        myConnection = myDataAdapter.SelectCommand.Connection


        '' Here we set the INSERT command and parameter.
        '' This is the command that is used primarily in this example
        '' because only new rows are added to the existing DataSet
        myDataAdapter.InsertCommand = New SqlCommand("INSERT INTO SampleData (value1) VALUES (@value1);", myConnection)
        myDataAdapter.InsertCommand.Parameters.Add("@value1", SqlDbType.Int, 4, "value1")
        myDataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None

        '' Here we set the UPDATE command and parameters.
        '' This is then called if any of the rows in the DataSet
        '' have been altered and must be updated.
        myDataAdapter.UpdateCommand = New SqlCommand("UPDATE SampleData SET value1=@value WHERE value1 > 1;", myConnection)
        myDataAdapter.UpdateCommand.Parameters.Add("@value1", SqlDbType.Int, 4, "value1")
        myDataAdapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None


        '' Here we set the DELETE command and parameter.
        '' Again although this isn't used in this example, 
        '' it would be called if any of the rows in the DataSet
        '' were deleted.
        myDataAdapter.DeleteCommand = New SqlCommand("DELETE FROM SampleData WHERE ID=@ID;", myConnection)
        myDataAdapter.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
        myDataAdapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None
    End Sub


    ''' <summary>
    ''' This event handler is called whenever a batch has completed updating.  This allows us
    ''' to provide feedback to the end-user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub RowUpdatedHandler(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)

        '' Indicate how we are updating the records: Batch or Insert for this example
        myStringBuilder.Append(String.Format("<font size=2 face='Arial'>Update Type: '<b>{0}</b>'</font><br />", args.StatementType.ToString()))

        '' Indicate how many rows were updated
        myStringBuilder.Append(String.Format("<font size=2 face='Arial'>Rows Updated: <b>{0}</b> </font><br />", args.RecordsAffected.ToString()))

        myStringBuilder.Append("<p />")

    End Sub

    ''' <summary>
    ''' This event handler shows how you can insert data first into the dataset
    ''' and then you can commit the changes into the database using the BatchUpdateSize
    ''' property.  If this property is set to 0, it will update all the records in a 
    ''' single batch.  If the property is set to 1, it will update each record individually.
    ''' Otherwise, it will update the records in batches according to the batch size.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub insertDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertDataButton.Click

        '' Create an instance of the new StopWatch class to mark the performance
        '' of changing the batch sizes.
        Dim myWatch As New Stopwatch()

        ' disable the button and change the text
        insertDataButton.Text = "Processing..."
        insertDataButton.Enabled = False


        ClearControls()

        '' Here you set the batch size of the DataAdapter and the records will
        '' be update according this property.
        myDataAdapter.UpdateBatchSize = Convert.ToInt32(batchSizeComboBox.SelectedItem)

        '' We start the timer here so we can record only the time required to insert into
        '' the DataSet and database.
        myWatch.Start()

        '' Create new rows for the DataSet
        Dim i As Integer
        Dim myNumberofRows As Integer = 0

        Try

            myNumberofRows = Convert.ToInt32(dataSetSizeComboBox.SelectedItem.ToString())

            For i = 0 To myNumberofRows - 1


                '' For each record inserted, we have to create a new row
                Dim newRow As DataRow = myDataTable.NewRow()

                '' Give it some value		
                newRow("ID") = i
                newRow("value1") = i * 10

                '' Add the new row to the DataSet
                myDataSet.Tables(0).Rows.Add(newRow)
            Next

            '' After all the new rows have been added to the DataSet, we can update the database.
            '' Since we are inserting, all the rows that have been added, will be updated.
            myDataAdapter.Update(myDataSet, "SampleData")
            '' We want to explicitly show that the changes have been accepted to update the database
            myDataSet.AcceptChanges()

            Application.DoEvents()


            '' If an exception is thrown, we want to reject any changes that were made
            '' and display a message
        Catch ex As SqlException

            myDataSet.RejectChanges()
            MessageBox.Show(ex.Message, "Alert")
        End Try

        '' Now we want to stop the timer and display the results
        myWatch.Stop()
        '' Display the results in milliseconds
        elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
        '' Display the rows inserted
        rowsInsertedLabel.Text = "Rows Inserted: " + myNumberofRows.ToString()
        '' Display how the data was updated in the WebBrowser control
        ' MessageBox.Show("HI " + myStringBuilder.ToString())
        finalResultWebBrowser.DocumentText = myStringBuilder.ToString()
        '' Display the results in the DataGridView
        FillDataGridView()

        ' enable the button and set text back
        insertDataButton.Enabled = True
        insertDataButton.Text = "Insert Data"

    End Sub

#Region "Helper Methods"

    ''' <summary>
    ''' This methods retrieves the data from the dataset and 
    ''' displays it in the DataGridView
    ''' </summary>
    Private Sub FillDataGridView()

        myDataTable = myDataSet.Tables(0)
        sampleDataDataGridView.DataSource = myDataTable

    End Sub

    ''' <summary>
    ''' This method clears all the controls and resets them to their original 
    ''' settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearControls()

        rowsInsertedLabel.Text = ""
        elapsedTimeLabel.Text = ""
        finalResultWebBrowser.DocumentText = ""
        myStringBuilder.Remove(0, myStringBuilder.Length)
        sampleDataDataGridView.DataSource = ""
    End Sub

    ''' <summary>
    ''' This method fills the DataSet Size ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillDataSetSize()

        For i As Integer = 1 To 5
            dataSetSizeComboBox.Items.Add(i * 1000)
        Next
    End Sub
#End Region


End Class
