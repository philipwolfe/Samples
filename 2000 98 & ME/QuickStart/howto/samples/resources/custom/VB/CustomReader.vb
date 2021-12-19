' CustomReader: Implement the interface IResourceReader.
' CustomManager: Sub-class ResourceManager and create
' ResourceSets using the CustomReader class.


Imports System
Imports System.Collections
Imports System.Globalization
Imports System.Resources

Imports Microsoft.VisualBasic



Class CustomReader 
Implements IResourceReader 

    Public Sub Close() Implements IResourceReader.Close
        ' Close any open files, DB connections, etc here.
    End Sub

    Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        IEnumerable_GetEnumerator = Me.GetEnumerator()
    End Function

    Public Function GetEnumerator() As IDictionaryEnumerator Implements IResourceReader.GetEnumerator

        Dim dict As Dictionary = new Dictionary()
  
        dict("key1") = "value 1"
        dict("key2") = "value 2"
        dict("key3") = "value 3"
  
        GetEnumerator = dict.GetEnumerator()
    End Function

End Class



Public Class CustomManager 
Inherits ResourceManager 


    Protected Overrides Function InternalGetResourceSet( _
        culture As CultureInfo, _
        createIfNotExists As Boolean, _
        tryParents As Boolean ) As ResourceSet 

        InternalGetResourceSet = new ResourceSet( new CustomReader() )
    End Function


        
    Public shared Sub Main()
        Dim my_resourceManager As ResourceManager = new CustomManager()
        Console.WriteLine( "Lookup for key1 yields: " + my_resourceManager.GetString("key1") )
    
        Console.WriteLine (ControlChars.CrLf + "Press Return to exit.")
        Console.Read()
    End Sub
        
End Class

