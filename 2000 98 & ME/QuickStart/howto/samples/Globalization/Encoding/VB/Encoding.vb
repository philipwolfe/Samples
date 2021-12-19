Imports System
Imports System.IO
Imports System.Text
 
Class CultureAndRegion
 
Public shared Sub Main() 
 
    ' Create a text file for this example
    Console.WriteLine ("Creating text.txt")
    Dim fs As FileStream
    fs = new FileStream("text.txt", FileMode.OpenOrCreate)
    
    Console.WriteLine ("Writing UTF8")
    Dim t As StreamWriter
    t = new StreamWriter (fs, Encoding.UTF8)
    t.Write("This is in UTF8")
    t.Flush()
    
    Console.WriteLine ("Writing Unicode")
    Dim t2 As StreamWriter
    t2 = new StreamWriter (fs, Encoding.Unicode)
    t2.Write("This is in Unicode")
    t2.Flush()  
 
    Console.WriteLine ("Writing Ascii")
    Dim t3 as StreamWriter
    t3 = new StreamWriter (fs, Encoding.ASCII)
    t3.Write("This is in ASCII")
    t3.Flush()
    
    fs.Close()
End Sub
    
End Class
 
