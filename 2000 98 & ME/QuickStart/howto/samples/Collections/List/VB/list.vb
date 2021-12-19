Imports System
Imports System.Collections

Namespace List
    Public Class listSample
    
        Public Shared Sub  Main()
            Dim fruit As New ArrayList
            fruit.Add("Apple")
            fruit.Add("Pear")
            fruit.Add("Orange")
            fruit.Add("Banana")
            Dim item As String
            For Each item In fruit
                Console.WriteLine(item)
            Next item
        
            Console.WriteLine ()
            Console.WriteLine("Press Return to exit.")
            Console.Read()
        End Sub
    End Class
End Namespace