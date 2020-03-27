Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Data.SqlClient
Public Class dataReaderDataSetForm
    '' create a dataset
    Dim myDataSet As DataSet

    '' create a sqlDataReader
    Dim myReader As SqlDataReader

    ''' <summary>
    ''' This event checks to see if we are filing a DataSet or a DataReader object. It also
    ''' determines if you are reading strings or integers.
    ''' The DataReader object is fast read-only object to display data.  Conversely, the 
    ''' DataSet object is slower in performance, but is bi-directional and read/write.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub runTestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runTestButton.Click
        Try
            runTestButton.Enabled = False
            Application.DoEvents()


            '' Rows Retrieved
            Dim rowsRetrieved As Integer = 0


            '' Stopwatch Class
            '' This is a new class in the 2.0.  This provides a simple and accurate 
            '' timing mechanism.  Create a new StopWatch object and then you can 
            '' start the stopwatch and the timing begins.
            Dim myWatch As New Stopwatch()
            myWatch.Start()

            rowsRetrieved = Convert.ToInt32(iterationsListBox.Value.ToString())

            '' This decision struture determines if you are using a DataSet to hold the data
            '' or a DataReader to hold the data.  It also determines if you are accesing strings
            '' integers.
            If dataReaderRadioButton.Checked Then

                '' read the strings table
                If stringsRadioButton.Checked Then

                    '' get the string data
                    retrieveMethodLabel.Text = "Retrieve method: Strings"
                    myReader = IntegerDataTableAdapter.retrieveData("strings", rowsRetrieved)
                Else

                    '' get the integer data
                    retrieveMethodLabel.Text = "Retrieve method: Integers"
                    myReader = IntegerDataTableAdapter.retrieveData("integer", rowsRetrieved)

                End If
                '' Since the DataReader object cannot be displayed directly in the DataGridView,
                '' you can use the new method Load of a DataTable to fill a DataTable and then 
                '' display the results in the DataGridView.  This method is still faster
                '' than filling a DataSet.
                Dim myTable As DataTable = New DataTable()
                myTable.Load(myReader)

                '' set the datasource
                testDataDataGridView.DataSource = myTable
                '' close the datareader
                myReader.Close()
                myReader.Dispose()


            Else

                '' By being in the else clause of the structure, you assume that you are filling
                '' a DataSet and then binding that to the DataGridView.
                If stringsRadioButton.Checked Then
                    '' get the strings dataset
                    myDataSet = IntegerDataTableAdapter.retrieveDataSet("strings", rowsRetrieved)
                Else
                    '' get the integer dataset
                    myDataSet = IntegerDataTableAdapter.retrieveDataSet("integers", rowsRetrieved)


                End If

                '' set the datasource
                testDataDataGridView.DataSource = myDataSet.Tables(0)
            End If

            '' At this point, you stop the stopwatch and then you can retrieve
            '' the time that calculated from start to finish for display or
            '' other calculations.
            myWatch.Stop()
            '' display the time
            elapsedTimeLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
            '' display the rows queried
            rowsQueriedLabel.Text = "Rows Queried: " & rowsRetrieved.ToString()
        Catch ex As Exception
            MessageBox.Show("There was an error running the test.  Please try again.", "Alert")

        Finally
            runTestButton.Enabled = True
        End Try
    End Sub

End Class
