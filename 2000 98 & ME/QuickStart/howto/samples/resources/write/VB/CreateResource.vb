' CreateResources writes a .resources file containing
' one name/value pair.

' Resource should be merged into an assembly, but
' can also be used as standalone files, as demonstrated
' below.

Imports System
Imports System.Resources

Imports Microsoft.VisualBasic
Imports System.Diagnostics



Public Class MakeResources

    Public Shared Sub Main()
        Dim resourceWriter As ResourceWriter
                
        ' Create a .resources file and add one string.
        resourceWriter = new ResourceWriter("Greeting.resources")
        resourceWriter.AddResource("Greeting", "Welcome to Microsoft .Net Framework !")
        resourceWriter.Write()
        resourceWriter.Close()
        
        ' Testing the resource file.
        Dim rm As ResourceManager
        rm = new ResourceManager("Greeting", ".", Nothing)
        
        ' Query resource for object.
        Console.WriteLine("-->{0}<--", rm.GetString("Greeting"))
        
        Console.WriteLine(ControlChars.CrLf + "Press Return to exit.")
        Console.Read()
    End Sub

End Class
