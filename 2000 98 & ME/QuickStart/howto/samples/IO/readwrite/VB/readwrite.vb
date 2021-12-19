
Imports System.IO
Imports System

Public Class ReadWrite
    
    Public Shared Sub Main()
    
        Dim fs As FileStream 
        fs = new FileStream("data.txt", FileMode.OpenOrCreate)	
        Dim w As BinaryWriter 
        w = new BinaryWriter(fs)
        Dim r As BinaryReader 
        r = new BinaryReader(fs)
        Dim I as Integer
        for I = 0 to 11 
            w.Write( CInt ( i))
        Next I
        
        w.BaseStream.Seek(0,SeekOrigin.Begin)	'set the file pointer to the beginning
        for I = 0 to 11
            Console.WriteLine( r.ReadInt32() )
        Next I
        fs.Close()

		Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
    End Sub
    
End Class
