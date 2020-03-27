Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

'''Defining stored procedures in this manner is advantageous because you can debug your code here
''' as well as perform actions here that were previously unavailable.
''' You also see that by using the SqlPipe, you can leverage the ExecuteAndSend method for Non-data returning and
''' data returning queries alike.

Partial Public Class StoredProcedures

    ''' <summary>
    ''' This stored procedure inserts the data passed in as parameters into the user table.
    ''' You create a SqlPipe to execute and send all queries that are executed in the stored procedure.
    ''' </summary>
    ''' <param name="longitude1"></param>
    ''' <param name="latitude1"></param>
    ''' <param name="longitude2"></param>
    ''' <param name="latitude2"></param>
    ''' <param name="distance"></param>
    <Microsoft.SqlServer.Server.SqlProcedure()> _
    Public Shared Sub spInsertData(ByVal longitude1 As Double, ByVal latitude1 As Double, ByVal longitude2 As Double, ByVal latitude2 As Double, ByVal distance As Double)

        Dim myQuery As String = ""

        myQuery = "INSERT INTO GeoCache (longitude1,latitude1,longitude2,latitude2,distance) VALUES(" & longitude1 & "," & latitude1 & "," & longitude2 & "," & latitude2 & "," & distance & ")"

        Dim myCommand As SqlCommand = New SqlCommand()
        myCommand.CommandText = myQuery
        Dim myPipe As SqlPipe = SqlContext.Pipe

        myPipe.ExecuteAndSend(myCommand)

    End Sub

    ''' <summary>
    ''' This stored procedure simply returns all the values that are stored
    ''' in the user table.  
    ''' </summary>
    <Microsoft.SqlServer.Server.SqlProcedure()> _
           Public Shared Sub spGetData()

        Dim myQuery As String = "SELECT * FROM GeoCache"

        Dim myCommand As SqlCommand = New SqlCommand()
        myCommand.CommandText = myQuery
        Dim myPipe As SqlPipe = SqlContext.Pipe

        myPipe.ExecuteAndSend(myCommand)

    End Sub


End Class
