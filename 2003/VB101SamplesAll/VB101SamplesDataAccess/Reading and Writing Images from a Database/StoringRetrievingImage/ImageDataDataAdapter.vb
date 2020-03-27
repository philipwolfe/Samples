#Region "Using Statements"

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data

#End Region

Namespace MyImagesDataSetTableAdapters


    Partial Public Class CategoriesTableAdapter


        ''' <summary>
        ''' The insertNewImage method takes all the information about the image and stores it
        ''' in the database.  This method accesses a stored procedure to insert the data and returns
        ''' the success statement or error message.
        ''' </summary>
        ''' <param name="CategoryID"></param>
        ''' <param name="photographName"></param>
        ''' <param name="myBuffer"></param>
        ''' <returns></returns>
        Public Function insertNewImage(ByVal CategoryID As Integer, ByVal photographName As String, ByRef myBuffer() As Byte) As String

            Dim message As String = ""
            Dim myConnection As SqlConnection
            myConnection = Connection()

            Try

                myConnection.Open()

                '' Create a stored procedure command
                Dim myCommand As SqlCommand = New SqlCommand("sp_InsertPhoto", myConnection)
                myCommand.CommandType = CommandType.StoredProcedure

                '' Add the Name parameter and set the photographName as the value
                myCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = photographName
                '' Add the image parameter and set myBuffer as the value.
                myCommand.Parameters.Add("@image", SqlDbType.Image).Value = myBuffer
                '' Add the CategoryID parameter and set the CategoryID as the value
                myCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = CategoryID

                '' Execute the insert
                myCommand.ExecuteNonQuery()

                '' Close the Connection
                myConnection.Close()

                '' Assign the success message
                message = "Inserted Successfully!"

            Catch ex As Exception

                '' Assign the error message
                message = ex.Message.ToString()
            End Try

            Return message
        End Function

        ''' <summary>
        ''' The getCategories method is a general method that returns a DataSet with Category
        ''' information in it.
        ''' </summary>
        ''' <returns></returns>
        Public Function getCategories() As DataSet

            Dim myConnection As SqlConnection
            Dim myCommand As SqlCommand
            Dim myQuery As String = ""
            Dim myDataSet As DataSet = New DataSet()
            Dim myAdapter As SqlDataAdapter
            myConnection = Connection()

            Try

                myConnection.Open()
                myQuery = "SELECT * FROM Categories ORDER BY CategoryName"
                myCommand = New SqlCommand()
                myCommand.CommandText = myQuery
                myCommand.Connection = myConnection
                myAdapter = New SqlDataAdapter(myCommand)
                myAdapter.Fill(myDataSet)
                myConnection.Close()

            Catch ex As Exception

                Throw ex
            End Try

            Return myDataSet
        End Function

        ''' <summary>
        ''' The getImages method accesses the database and return Image information
        ''' based on the CategoryID that is passed in.
        ''' </summary>
        ''' <param name="CategoryID"></param>
        ''' <returns></returns>
        Public Function getImages(ByVal CategoryID As Integer) As DataSet

            Dim myConnection As SqlConnection
            Dim myCommand As SqlCommand
            Dim myQuery As String = ""
            Dim myDataSet As DataSet = New DataSet()
            Dim myAdapter As SqlDataAdapter
            myConnection = Connection()

            Try

                myConnection.Open()
                myQuery = "SELECT * FROM Photographs WHERE CategoryID = " & CategoryID
                myCommand = New SqlCommand()
                myCommand.CommandText = myQuery
                myCommand.Connection = myConnection
                myAdapter = New SqlDataAdapter(myCommand)
                myAdapter.Fill(myDataSet)

            Catch ex As Exception

                Throw ex
            End Try

            Return myDataSet
        End Function


    End Class

End Namespace
