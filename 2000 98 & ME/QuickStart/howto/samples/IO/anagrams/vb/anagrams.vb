Imports System
Imports System.IO
Imports System.Collections

Module Anagrams

    
    Public Sub Main()
    
        Dim din As StreamReader = File.OpenText("words.txt")
        Dim s, str As String
        Dim st As StringTable = New StringTable
        
        Console.WriteLine("Reading data and insterting into a StringTable.")
        Do
            str = din.ReadLine()
            If str <> Nothing Then
                st.Add(str)
            End If
        Loop Until str = Nothing
        Console.WriteLine("Printing out the StringTable.")
        For Each s In st
            Console.WriteLine(s)
        Next
        Console.WriteLine()
        Console.WriteLine("Press Return to exit.")
        Console.Read()
    End Sub
End Module
