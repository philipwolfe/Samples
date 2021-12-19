Imports System
Imports System.Collections

Module sortExample
        
    Public Sub Main()
        ' Array.Sort works on any object that implements IComparable such as ints, doubles and strings
        
        Dim intArray() As Integer = { 1, 3, 5, 6, 2, 4 }
        Console.Write("The unsorted int array: ")
        PrintArray(CType(intArray, array))
        'Sort and print the array
        Array.Sort(intArray)
        Console.Write("The sorted array: ")
        PrintArray(intArray)
        Console.WriteLine()

        Dim doubleArray() As Double = { 1.5, 4.3, 2.5, 6.9, 2.01, 0.04 }
        Console.Write("The unsorted double array: ")
        PrintArray(doubleArray)
        'Sort and print the array
        Array.Sort(doubleArray)
        Console.Write("The sorted array: ")
        PrintArray(doubleArray)

        Console.WriteLine()
        Dim stringArray() As String = { "red", "yellow", "green", "blue" }
        Console.Write("The unsorted string array: ")
        PrintArray(stringArray)
        'Sort and print the array
        Array.Sort(stringArray)
        Console.Write("The sorted array: ")
        PrintArray(stringArray)

        'And even your own objects, such as MyType

        Console.WriteLine()
        Dim MyTypeArray() As MyType = New MyType () { New MyType(1), New MyType(3), New MyType(5), New MyType(6), New MyType(2), New MyType(4) }
        Console.Write("The unsorted myType array: ")
        PrintArray(myTypeArray)
        'Sort and print the array
        Array.Sort(myTypeArray)
        Console.Write("The sorted array: ")
        PrintArray(myTypeArray)

        'You can even compare objects that don't implement IComparable (or ones you want to custom compare).
        Console.WriteLine()
        Dim guidArray() As Guid = New Guid () { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
        Console.Write("The unsorted guidArray array: ")
        PrintArray(guidArray)
        'Sort the array using guidComparer
        Array.Sort(guidArray, new GuidComparer())
        Console.Write("The sorted array: ")
        PrintArray(guidArray)


        Console.WriteLine()
	Console.WriteLine ("Press Return to exit.")
	Console.Read()
        
    End Sub 'Main

    Public Sub PrintArray(ByVal arr As Array)
        Dim o As Object
        Console.WriteLine ()
        Console.Write("{")
        for Each o in arr
            Console.Write(" {0},", o)
        Next
        Console.WriteLine ("}")
        
    End Sub

End Module 'formatExample


class MyType : 	Implements IComparable

    Private _value As Integer

    Public Sub New(ByVal value As Integer)
        MyBase.New()
        _value = value
    End Sub

    Public Function CompareTo(ByVal o As Object) As Integer Implements IComparable.CompareTo
        If (Not TypeOf o Is MyType) Then
            Throw New ArgumentException("o must be of type 'MyType'")
        End If
        Dim v As MyType = CType(o, MyType)
        return _value - v._value
    End Function

    Overrides Public Function ToString () As String
        Return [String].Format("MyType({0})", _value)
    End Function
End Class

class GuidComparer: Implements IComparer

    Public Function CompareTo(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
         Dim g1 As Guid = CType(x, Guid)
        Dim g2 As Guid = CType(y, Guid)
        
        return g1.ToString().CompareTo (g2.ToString ())
    End Function
End Class
