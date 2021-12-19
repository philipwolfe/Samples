Imports System
Imports System.IO



Public Class DirectoryLister

    
    Public Shared Sub Main()
    
        Dim dir As Directory 
        dir = new Directory(".")
        PrintFiles (dir)
        
        Console.WriteLine()
        Console.WriteLine ("Press Return to exit.")
        Console.Read()
    End Sub
    
    Public Shared Sub PrintFiles (dir As Directory)
    
        'Dim d As  FileSystemEntry 
        Dim d as Object
        for each d in dir.GetFileSystemEntries () 
            If (TypeOf(d) is File)
                Dim f As File
                f = CType (d, File)
                dim Name as string 
                name = f.FullName
                Dim size as long 
                size = f.Length
                Dim creationTime as DateTime 
                creationTime = f.CreationTime
                Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", size, creationTime, name)
            
            Else 'it must be an directory
            
                PrintFiles (CType(d, Directory))
            End If
            
        Next
    End Sub
End Class


