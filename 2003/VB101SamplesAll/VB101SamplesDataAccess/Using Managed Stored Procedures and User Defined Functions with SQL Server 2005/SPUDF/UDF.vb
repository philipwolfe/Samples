Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

Partial Public Class UserDefinedFunctions
    
    ''' <summary>
    ''' Here you can define functions that perform manipulations on data and returns a result from SQL Server.
    ''' By creating user defined functions here, you can debug within the same IDE and you can deploy to SQL Server
    ''' from the IDE without having to execute any command line actions.
    ''' </summary>
    ''' <param name="longitude1"></param>
    ''' <param name="latitude1"></param>
    ''' <param name="longitude2"></param>
    ''' <param name="latitude2"></param>
    ''' <returns></returns>
    <Microsoft.SqlServer.Server.SqlFunction()> _
    Public Shared Function CalculateDistance(ByVal longitude1 As Double, ByVal latitude1 As Double, ByVal longitude2 As Double, ByVal latitude2 As Double) As Double

        '' calculate the distance
        Dim x As Double = 69.1 * (latitude2 - latitude1)
        Dim y As Double = 53.0 * (longitude2 - longitude1)


        Return (x * x + y * y)
    End Function

End Class
