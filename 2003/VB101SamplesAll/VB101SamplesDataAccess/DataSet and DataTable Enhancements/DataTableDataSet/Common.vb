Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Public Class Common

    '''<summary>
    ''' This method creates the DataSet table if it doesn't exist.
    ''' If it does exist, it clears the data that is stored in the table
    ''' </summary>
    ''' <param name="myDataSet"></param>
    ''' <returns></returns>
    Public Function CreateMyTable(ByVal myDataSet As DataSet) As DataSet

        Dim i As Integer = 0
        For i = 0 To myDataSet.Tables.Count - 1
            Try

                If myDataSet.Tables(i).TableName = "MyTable" Then
                    ' remove this table to reset to original state
                    myDataSet.Tables.Remove("MyTable")
                    myDataSet.Clear()
                    Exit For
                End If
            Catch ex As Exception
                MessageBox.Show("There was an error creating the table. Please try again." & ex.Message.ToString(), "Alert")
            End Try

        Next

        
        myDataSet.Tables.Add("MyTable")
        myDataSet.Tables("MyTable").Columns.Add("ID", Type.GetType("System.Int32"))
        myDataSet.Tables("MyTable").Columns("ID").Unique = True
        myDataSet.Tables("MyTable").Columns.Add("IntegerValue1", Type.GetType("System.Int32"))


        Return myDataSet

    End Function

    ''' <summary>
    ''' This method creates a table that is used in the DataView example.
    ''' It checks to see if the table exists.  If it does exist, it just 
    ''' clears the data from the table.
    ''' </summary>
    ''' <param name="myDataSet"></param>
    ''' <returns></returns>

    Public Function CreateMyDataViewTable(ByVal myDataSet As DataSet) As DataSet

        Dim tableExists As Boolean = False
        Dim i As Integer = 0
        For i = 0 To myDataSet.Tables.Count - 1

            If myDataSet.Tables(i).TableName = "MyDataViewTable" Then
                ' remove this table to reset to original state
                myDataSet.Tables.Remove("MyDataViewTable")
                myDataSet.Clear()
                Exit For
            End If
        Next

        
        myDataSet.Tables.Add("MyDataViewTable")
        myDataSet.Tables("MyDataViewTable").Columns.Add("ID", Type.GetType("System.Int32"))
        myDataSet.Tables("MyDataViewTable").Columns("ID").Unique = True
        myDataSet.Tables("MyDataViewTable").Columns.Add("IntegerValue1", Type.GetType("System.Int32"))
        myDataSet.Tables("MyDataViewTable").Columns.Add("IntegerValue2", Type.GetType("System.Int32"))
        myDataSet.Tables("MyDataViewTable").Columns.Add("IntegerValue3", Type.GetType("System.Int32"))
        
        Return myDataSet

    End Function
End Class
