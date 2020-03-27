Imports System
Imports System.Collections.Generic
Imports System.Text

' This class simulates a web service.
Class WebServiceSimulator

    Public Function GetEmployeeNames(ByVal delayLength As Integer) As String
        ' Retrieve a list of employees.
        ' Simulate a web service responding slowly.
        If (delayLength > 0) Then
            System.Threading.Thread.Sleep(delayLength)
        End If
        ' Return the list if the delay is less than three seconds, otherwise 
        ' return an error string.
        If (delayLength < 4000) Then
            ' Access a database for the information.
            Return ("Nancy Davolio, Andrew Fuller, Janet Leverling, " + "Margaret Peacock, Steven Buchanan")
        Else
            Return "Error"
        End If
    End Function
End Class

