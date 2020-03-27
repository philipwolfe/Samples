Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text

Namespace Microsoft.Samples.Web.DataAccess

    Public Class ProductLogic

        Public Sub New()
        End Sub

        Public Function GetAllProducts() As ProductCollection
            Dim coll As ProductCollection = Nothing
            Dim rdr As SqlDataReader = Nothing
            Dim connectString As String = GetConnectionString
            Dim sqlStatement As String = GetSqlStatement
            Dim cnn As SqlConnection = New SqlConnection(connectString)
            Dim cmd As SqlCommand = New SqlCommand(sqlStatement, cnn)
            Try
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.HasRows Then
                    coll = New ProductCollection
                    While rdr.Read
                        Dim product As Product = New Product
                        product.ListPrice = Convert.ToDecimal(rdr("ListPrice"))
                        product.Name = Convert.ToString(rdr("Name"))
                        product.ProductId = Convert.ToInt32(rdr("ProductID"))
                        product.ProductNumber = Convert.ToString(rdr("ProductNumber"))
                        product.ReorderPoint = Convert.ToInt32(rdr("ReorderPoint"))
                        product.StandardCost = Convert.ToDecimal(rdr("StandardCost"))
                        coll.Add(product)
                    End While
                End If
            Catch ex As SqlException
                Throw
            Finally
                If rdr.IsClosed = False Then
                    rdr.Close()
                End If
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End Try
            Return coll
        End Function

        Private Function GetSqlStatement() As String
            Dim sb As StringBuilder = New StringBuilder
            sb.Append("SELECT [ProductID], [Name], [ProductNumber], [ReorderPoint], [StandardCost], [ListPrice] ")
            sb.Append("FROM [Production].[Product]")
            Return sb.ToString
        End Function

        Private Function GetConnectionString() As String
            Dim connectStringBuilder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder
            connectStringBuilder.DataSource = "(local)\SQLEXPRESS"
            connectStringBuilder.AttachDBFilename = "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"
            connectStringBuilder.IntegratedSecurity = True
            Return connectStringBuilder.ConnectionString
        End Function
    End Class
End Namespace
