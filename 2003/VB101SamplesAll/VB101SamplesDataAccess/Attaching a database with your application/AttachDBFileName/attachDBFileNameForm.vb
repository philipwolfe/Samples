Imports System.IO
Imports System.Reflection
Imports System.Diagnostics
Public Class attachDBFileNameForm
    Dim execPath As String
    Dim currentDB As String = "DB1"
    Private Sub attachDBFileNameForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()(0).FullyQualifiedName)
    End Sub
    ''' <summary>
    ''' This event, inserts the new rows into the specified database.
    ''' It determines not only which database to insert the data into, but
    ''' which insert method should be used.
    ''' </summary>
    Private Sub runTestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runTestButton.Click
        Try
            runTestButton.Enabled = False
            runTestButton.Text = "Running"
            Me.CleanupForm()
            Application.DoEvents()

            Const SPROC As String = " Sproc"
            Const QUERY As String = " Query"
            If currentDB = "DB1" Then
                Me.TestDataTableAdapter.AttachDB1()
            End If

            ' Stopwatch Class
            ' This is a new class in the 2.0 Framework.  This provides a simple and accurate 
            ' timing mechanism.  Create a new StopWatch object and then you can 
            ' start the stopwatch and the timing begins.
            Dim myWatch As New Stopwatch()
            Dim i As Integer = 0
            myWatch.Start()

            If storedProcedureRadioButton.Checked Then


                insertMethodLabel.Text = "Insert method:  Stored procedure"
                For i = 1 To iterationListBox.Value

                    Me.TestDataTableAdapter.StoredProcedureQueryInsert("spInsertData", currentDB & SPROC & i.ToString(), _
                        currentDB & SPROC & (i * 2).ToString(), System.DateTime.Now)

                Next

                ' insert if it's a plain query
            Else

                insertMethodLabel.Text = "Insert method:  SQL Text"

                For i = 1 To iterationListBox.Value

                    TestDataTableAdapter.QueryInsert( _
                   "INSERT INTO dbo.TestData (firstValue, secondValue, timeStamp)VALUES('" & currentDB & QUERY & "','" _
                    & i.ToString() & "','" _
                   & System.DateTime.Now() & "')")

                Next
                TestDataTableAdapter.Update(PerfTestDataSet)
            End If

            PerfTestDataSet.AcceptChanges()

            ' At this point, you stop the stopwatch and then you can retrieve
            ' the time that calculated from start to finish for display or
            ' other calculations.
            myWatch.Stop()

            ' read the time that elapsed and divide by 1000
            Dim timeSpent As Double = myWatch.ElapsedMilliseconds / 1000
            elapsedTimeLabel.Text = "Elapsed time:  " & FormatNumber(timeSpent, 0) & " sec"
            rowsAddedLabel.Text = "Rows added:  " + iterationListBox.Value.ToString()

            ' This clears all the data before the dataset is filled again

            TestDataTableAdapter.ClearBeforeFill = True
            Me.TestDataTableAdapter.Fill(Me.PerfTestDataSet.TestData)
            TestDataTableAdapter.Connection.Close()

        Catch ex As Exception
            MessageBox.Show("There was an error inserting the data. Please try again." + Environment.NewLine + ex.Message, "Alert")
        Finally
            runTestButton.Enabled = True
            runTestButton.Text = "Run Test"
        End Try
    End Sub
    ''' <summary>
    ''' This event fires when the database 1 radio button is selected.  It will attach the application to
    ''' the first database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub db1RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles db1RadioButton.CheckedChanged
        If db1RadioButton.Checked Then
            TestDataTableAdapter.Connection.Close()
            currentDB = "DB1"
            TestDataTableAdapter.AttachDB1()
            PerfTestDataSet.Clear()
        End If
    End Sub

    ''' <summary>
    ''' This event fires when the second database radio button is selected. It will attach the applicdation to
    ''' the second database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub db2RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles db2RadioButton.CheckedChanged
        If db2RadioButton.Checked Then
            TestDataTableAdapter.Connection.Close()
            currentDB = "DB2"
            TestDataTableAdapter.AttachDB2()
            PerfTestDataSet.Clear()
        End If
    End Sub

    ''' <summary>
    ''' This method resets the application to its original state.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CleanupForm()
        insertMethodLabel.Text = "Insert method:"
        rowsAddedLabel.Text = "Rows added:"
        elapsedTimeLabel.Text = "Elapsed time:"

        PerfTestDataSet.Clear()
    End Sub
End Class

