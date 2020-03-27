Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection


Public Class dataSetDataTableForm

    Dim myMainDataset As New DataSet()

    ''' <summary>
    ''' In this event, we are going to load a million rows into a DataTable.  This is done 
    ''' in a reasonable time frame because of new performance enhancements with DataSets
    ''' and DataTable.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub performanceAddRowsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles performanceAddRowsButton.Click

        Dim i As Integer
        Dim myDataRow As DataRow
        Dim myTime As Long
        clearLabels()
        performanceAddRowsButton.Text = "Processing..."
        performanceAddRowsButton.Enabled = False

        '' We are leveraging the new StopWatch class which gives us better
        '' control over timing events and a simpler, more accurate way to display
        '' the performance of inserting these rows
        Dim myWatch As New Stopwatch()

        Dim myCommon As New Common

        '' First, we must generate the DataSet with the 
        '' proper number of columns and their respective data types
        myCommon.CreateMyTable(myMainDataset)

        '' You start the StopWatch where you want to start the timing from
        myWatch.Start()

        '' Here, we are loading the DataTable of the DataSet with a large number of
        '' rows filled with random numbers.
        '' With ADO.NET 1.1, this was possible, but the time required made it not practical

        Dim myRandom As New Random()
        Dim myRandomValue As Integer
        For i = 1 To 10000

            Try

                myRandomValue = myRandom.Next()
                myDataRow = myMainDataset.Tables("MyTable").NewRow()
                myDataRow("ID") = i
                myDataRow("IntegerValue1") = myRandomValue
                myMainDataset.Tables("MyTable").Rows.Add(myDataRow)


            Catch ex As Exception

                MessageBox.Show(ex.Message.ToString(), "Alert")
            End Try
        Next

        '' Stop the stopwatch at this point, so we can calculate how much time elapsed
        '' while we were adding the new rows into the DataTable.
        myWatch.Stop()
        myTime = myWatch.ElapsedMilliseconds


        '' Display the time required to add the rows
        elapsedTimeLabel.Text = "Elapsed time: " & myTime.ToString() & " ms"

        '' Display the number of rows that were inserted
        rowsInsertedLabel.Text = "Rows Inserted: " & myMainDataset.Tables("MyTable").Rows.Count

        performanceAddRowsButton.Text = "Add Rows"
        performanceAddRowsButton.Enabled = True
    End Sub


    ''' <summary>
    ''' In this event, we are just showing the rows that were inserted and 
    ''' displaying how long it takes to bind this data to a datagridview.
    ''' This event acts as a verification that the rows we meant to insert
    ''' were actually inserted.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub performanceShowRowsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles performanceShowRowsButton.Click

        Dim myWatch As New Stopwatch()
        clearLabels()
        myWatch.Start()

        performanceShowRowsButton.Text = "Processing..."
        performanceShowRowsButton.Enabled = False

        Try
            If myMainDataset.Tables("MyTable").Rows.Count > 0 Then

                resultsDataGridView.DataSource = myMainDataset.Tables("MyTable")
            Else
                MessageBox.Show("Please click the 'Add Rows' button first.")
            End If
            myWatch.Stop()

            elapsedTimeLabel.Text = "Elapsed time: " & myWatch.ElapsedMilliseconds & " ms"
            rowsInsertedLabel.Text = "Rows Displayed: " & myMainDataset.Tables("MyTable").Rows.Count.ToString()

        Catch ex As Exception
            MessageBox.Show("Please click the 'Add Rows' button first.", "Alert")
        End Try

        performanceShowRowsButton.Text = "Show Rows"
        performanceShowRowsButton.Enabled = True

    End Sub

    ''' <summary>
    ''' This event first creates a number of rows and inserts them into a DataTable
    ''' in a DataSet.  With ADO 2.0, you can now write this data and schema directly 
    ''' to an XML file. The file is stored in the bin directory of this sample.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub xmlWriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xmlWriteButton.Click

        Dim myTable As DataTable
        Dim myDataRow As DataRow
        Dim myPath As String = ""
        Dim myTime As Long = 0
        Dim i As Integer = 0
        clearLabels()

        '' Again use the new StopWatch class to handle all the timing events.			
        Dim myWatch As New Stopwatch()

        Dim myCommon As New Common

        xmlWriteButton.Text = "Processing..."
        xmlWriteButton.Enabled = False

        '' start the timing
        myWatch.Start()


        '' We are putting getting the file path to the bin directory, so that we keep all 
        '' the files contained in one area.
        myPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()(0).FullyQualifiedName)

        myCommon.CreateMyTable(myMainDataset)

        '' We want to add some values to the DataTable before we write them to the XML file
        Dim myRandom As New Random()
        Dim myRandomValue As Integer

        For i = 1 To 101 - 1

            Try

                myRandomValue = myRandom.Next()
                myDataRow = myMainDataset.Tables("MyTable").NewRow()
                myDataRow("ID") = i
                myDataRow("IntegerValue1") = myRandomValue
                myMainDataset.Tables("MyTable").Rows.Add(myDataRow)


            Catch ex As Exception

                MessageBox.Show(ex.Message.ToString(), "Alert")
            End Try

        Next
        '' retrieve the DataTable
        myTable = myMainDataset.Tables("MyTable")
        Try

            '' Here we are writing all the data that was stored in the DataTable using
            '' one statement.
            myTable.WriteXml(myPath + "\\myXML.xml")
            '' We also write the XML schema so that it can be read correctly.
            myTable.WriteXmlSchema(myPath + "\\myXMLSchema.xml")

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Alert")
        End Try

        '' End Timing now that the Write has completed.
        myWatch.Stop()

        myTime = myWatch.ElapsedMilliseconds

        '' display the amount of time it took to write the XML
        readWriteTimeLabel.Text = "Elapsed time: " & myTime.ToString() & " ms"

        '' display the number of rows that were written to the XML file.
        rowsReadWrittenLabel.Text = "Rows written: " & myTable.Rows.Count

        xmlWriteButton.Text = "Write XML"
        xmlWriteButton.Enabled = True


    End Sub

    ''' <summary>
    ''' Now that we have added data to an XML file, we can read the XML file,
    ''' load the data into a DataTable, and display the results in a DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub xmlReadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xmlReadButton.Click

        '' Use the StopWatch class to time the reading events.
        Dim myWatch As New Stopwatch()
        Dim myDataTable As New DataTable()
        Dim myFile As String = ""
        clearLabels()

        xmlReadButton.Text = "Processing..."
        xmlReadButton.Enabled = False
        '' start timing right before we start reading the file
        myWatch.Start()

        Try

        '' have to look in the bin directory since that's where we wrote the file.
            myFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()(0).FullyQualifiedName)

            '' make sure the file exists before we try to read it
            If File.Exists(myFile + "\\myXML.xml") Then

                '' read the XML schema first to make sure we know how to generate the resulting DataTable
                myDataTable.ReadXmlSchema(myFile + "\\myXMLSchema.xml")
                '' fill the DataTable with the actual values that exist in the XML file.
                myDataTable.ReadXml(myFile + "\\myXML.xml")
                '' bind the resulting DataTable to the DataGridView
                xmlResultsDataGridView.DataSource = myDataTable
                '' display the results
                rowsReadWrittenLabel.Text = "Rows read: " & myDataTable.Rows.Count.ToString()

            Else
                rowsReadWrittenLabel.Text = "Rows read: 0"
            End If

            '' stop the StopWatch
            myWatch.Stop()
            readWriteTimeLabel.Text = "Elapsed time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
        Catch ex As Exception
            MessageBox.Show("Please click the 'Write XML' button first.", "Alert")

        End Try

        xmlReadButton.Text = "Read XML"
        xmlReadButton.Enabled = True

    End Sub

    ''' <summary>
    ''' This event shows a full DataTable bound to a DataGridView.  It first generates the values to be displayed 
    ''' and inserts them into a DataTable.  Then, the DataTable is bound to the DataGridView displaying all of its 
    ''' columns.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataViewShowDataSetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataViewShowDataSetButton.Click

        Dim i As Integer
        Dim myDataRow As DataRow
        Dim myTime As Long

        '' Use the new StopWatch class to track the time required to generate and display the 
        Dim myWatch As New Stopwatch()
        Dim myCommon As New Common()
        clearLabels()
        dataViewShowDataSetButton.Text = "Processing..."
        dataViewShowDataSetButton.Enabled = False

        Try

        myCommon.CreateMyDataViewTable(myMainDataset)

            '' catch start time
            myWatch.Start()

            '' Add a few data items just for example
            Dim myRandom = New Random()
            Dim myRandomValue As Integer
            For i = 1 To 11

                Try

                    myRandomValue = myRandom.Next()
                    myDataRow = myMainDataset.Tables("MyDataViewTable").NewRow()
                    myDataRow("ID") = i
                    myDataRow("IntegerValue1") = myRandomValue
                    myDataRow("IntegerValue2") = myRandomValue + 1
                    myDataRow("IntegerValue3") = myRandomValue + 2
                    myMainDataset.Tables("MyDataViewTable").Rows.Add(myDataRow)


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Alert")
                End Try

            Next
            '' Show elapsed time in milliseconds because the datatable is so small)
            myWatch.Stop()
            myTime = myWatch.ElapsedMilliseconds

            rowsReturnedTimeLabel.Text = "Elapsed time: " & myTime.ToString() & " ms"


            ''verify number of rows in the table
            rowsReturnedLabel.Text = "Rows returned: " & myMainDataset.Tables("MyDataViewTable").Rows.Count
            '' bind this new DataTable to the DataGridView
            dataViewDataGridView.DataSource = myMainDataset.Tables("MyDataViewTable")

        Catch ex As Exception
            MessageBox.Show("There was an error displaying the DataSet data. Please try again.", "Alert")
        End Try

        dataViewShowDataSetButton.Text = "DataSet"
        dataViewShowDataSetButton.Enabled = True

    End Sub

    ''' <summary>
    ''' This event takes an existing DataTable and tailors the display columns to 
    ''' show only the columns you are interested in.  This is done using only one 
    ''' line of code.  The DefaultView.ToTable creates the new table that is bound
    ''' to the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataViewShowDataViewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataViewShowDataViewButton.Click


        Dim columns() As String = {"ID", "IntegerValue2"}
        clearLabels()
        dataViewShowDataViewButton.Text = "Processing..."
        dataViewShowDataViewButton.Enabled = False

        '' Use the new StopWatch class to measure timing
        Dim myWatch As New Stopwatch()
        Try

            myWatch.Start()
            If myMainDataset.Tables("MyDataViewTable").Rows.Count > 0 Then

            '' This is where you create the new table by accessing the DefaultView.ToTable method and pass in the 
                '' columns you want to display.
                Dim myDataTable As DataTable = myMainDataset.Tables("MyDataViewTable").DefaultView.ToTable("MySmallTable", True, columns)

                '' bind the new DataTable to the DataGridView showing only two columns
                dataViewDataGridView.DataSource = myDataTable
                '' stop the StopWatch
                myWatch.Stop()

                '' Display the results
                rowsReturnedLabel.Text = "Rows returned: " & myDataTable.Rows.Count
                rowsReturnedTimeLabel.Text = "Elapsed time: " & myWatch.ElapsedMilliseconds.ToString() + " ms"
            Else
                MessageBox.Show("Please click the 'DataSet' button first.")
            End If

        Catch ex As Exception
            MessageBox.Show("Please click the 'DataSet' button first.", "Alert")
        End Try

        dataViewShowDataViewButton.Text = "DataView"
        dataViewShowDataViewButton.Enabled = True

    End Sub

    ''' <summary>
    ''' This method clears all the lables and the
    ''' DataGridViews of data.
    ''' </summary>
    Private Sub clearLabels()

        rowsInsertedLabel.Text = ""
        elapsedTimeLabel.Text = ""
        rowsReadWrittenLabel.Text = ""
        readWriteTimeLabel.Text = ""
        rowsReturnedLabel.Text = ""
        rowsReturnedTimeLabel.Text = ""
        dataViewDataGridView.DataSource = ""
        resultsDataGridView.DataSource = ""
        xmlResultsDataGridView.DataSource = ""

    End Sub

End Class
