Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Namespace ClassLibrary1
    Public Class SerializeTest
        Public Shared Sub Main()
            Console.WriteLine("Create object graph")
            Dim l As New ArrayList
            Dim x As Integer
            For x = 0 To 9
                Console.WriteLine(x)
                l.Add(x)
            Next x
            Console.Write("Serializing object graph to disk..")
            Dim s As Stream = (New File("foo.bin")).Open(FileMode.Create)
            Dim b As BinaryFormatter = New BinaryFormatter
            b.Serialize(s, l)
            s.Close()
            Console.WriteLine("Complete.")
        
            Console.Write("Deserializing object graph from disk..")
            Dim r As Stream = (New File("foo.bin")).Open(FileMode.Open)
            Dim c As New BinaryFormatter
            Dim p As ArrayList = CType(c.Deserialize(r), ArrayList)
            Console.WriteLine("Complete.")
            Dim i As Object
            For Each i In p
                Console.WriteLine(i)
            Next i
		
            r.Close()
        
            Console.WriteLine(Microsoft.VisualBasic.ControlChars.CrLf & "Press Return to exit.")
            Console.Read()
        End Sub
    End Class
End Namespace
