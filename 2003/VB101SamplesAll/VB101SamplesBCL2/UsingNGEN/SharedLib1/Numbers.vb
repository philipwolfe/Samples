Public Class Numbers
    Public Function CalculateMean(ByVal start As Long, ByVal count As Long, ByVal stepVal As Long) As Long
        Dim total As Long = start
        Dim mean As Long = 0

        Try
            Dim i As Long
            For i = start To count - 1 Step i + stepVal

                total += i
            Next

            mean = total / count
        Catch
            mean = -1
        End Try

        Return mean
    End Function
End Class



