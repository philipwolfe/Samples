
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Data

Namespace TestDataDataSetTableAdapters

    Partial Public Class IntegerDataTableAdapter

        ''' <summary>
        ''' This method retrieves the data and puts it into the DataReader object, the DataReader
        ''' object is then returned.  The DataReader is created using the CloseConnection option 
        ''' otherwise, the Connection must remain open while the data is being accessed from a 
        ''' DataReader
        ''' </summary>
        ''' <param name="dataType"></param>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        Public Function retrieveData(ByVal dataType As String, ByVal rows As Integer) As SqlDataReader

            '' create the SqlDataReader
            Dim myReader As SqlDataReader
            '' create the SqlCommand
            Dim command As SqlCommand = New SqlCommand()

            Dim myQuery As String = ""

            '' create the query strings
            If dataType = "strings" Then
                myQuery = "SELECT TOP " & rows & " * FROM StringData ORDER BY value1"
            Else
                myQuery = "SELECT TOP " & rows & " * FROM IntegerData ORDER BY value1"
            End If
            Try

                '' set the command text
                command.CommandText = myQuery
                '' set the connection
                command.Connection = Connection()
                '' open the connection
                command.Connection.Open()
                '' set the data reader
                myReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            Catch ex As Exception
                Throw ex
            End Try

            Return myReader

        End Function

        ''' <summary>
        ''' This method retrieves the data and puts it into the dataset object. The result of this method
        ''' is a bi-directional, read/write DataSet object.  Although its performance is lower than the DataReader,
        ''' it still provides a number of functions that are unavailable to the DataReader object.
        ''' </summary>
        ''' <param name="dataType"></param>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        Public Function retrieveDataSet(ByVal dataType As String, ByVal rows As Integer) As DataSet

            '' create the query string
            Dim myQuery As String = ""
            '' create the dataset object
            Dim myDataSet As New DataSet
            '' create the DataAdapter
            Dim myDataAdapter As SqlDataAdapter
            '' create the SqlCommand
            Dim command As SqlCommand = New SqlCommand()
            '' set the connection 
            command.Connection = Connection()
            '' open the connection
            command.Connection.Open()

            '' set the query string
            If dataType = "strings" Then
                myQuery = "SELECT TOP " & rows & " * FROM StringData ORDER BY value1"
            Else
                myQuery = "SELECT TOP " & rows & " * FROM IntegerData ORDER BY value1"
            End If
            Try

                '' set the command text
                command.CommandText = myQuery
                '' set the data adapter
                myDataAdapter = New SqlDataAdapter(command)
                '' fill the dataset
                myDataAdapter.Fill(myDataSet)

            Catch ex As Exception
                Throw ex
            Finally
                '' close the connection
                command.Connection.Close()
            End Try

            Return myDataSet

        End Function

    End Class

End Namespace



