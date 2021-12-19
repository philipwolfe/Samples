'Create a custom exception type called InsufficientFundsException. What makes
' it an exception is that it Inherits from System.ApplicationException
Public Class InsufficientFundsException
    Inherits System.ApplicationException

    'Define the three standard constructors for an ApplicationException
    Public Overloads Sub InsufficientFundsException()

    End Sub

    Public Overloads Sub InsufficientFundsException(ByVal Message As String)

    End Sub

    Public Overloads Sub InsufficientFundsException(ByVal Message As String, ByVal Inner As Exception)

    End Sub
End Class
