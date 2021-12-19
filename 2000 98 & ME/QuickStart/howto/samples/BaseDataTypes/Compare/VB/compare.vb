Option Strict Off
Imports System


Public Class compareExample 
    
    Public Shared Sub Main()
        Console.WriteLine ("Our Max method works on any type that implements IComparable....")
       'this example will compare some ints
        Dim a as Integer
        a = 5
        Dim b as Integer
        b = 10
        Console.WriteLine ("ints: Max (5, 10) == {0}", Max (CObj(5), CObj(10)))
        Console.WriteLine ("doubles: Max (4.3, 2.5) == {0}", Max (CObj(4.3), CObj(2.5)))
        Dim d1 As decimal 
        d1 = 1235698
        Dim d2 As decimal
        d2 = -234238
        Console.WriteLine ("decimals: Max ({0}, {1}) == {2}", d1, d2, Max (CObj(d1), CObj(d2)))
        Dim s1 As String 
        s1 = "Mathew"
        Dim s2 As String 
        s2 = "Mark"
        Console.WriteLine ("strings: Max ({0}, {1}) == {2}", s1, s2, Max (CObj(s1), CObj(s2)))
        Dim c1 As Char
        c1 = "t"C
        Dim c2 As Char
        c2 = "a"C
        Console.WriteLine ("chars: Max ({0}, {1}) == {2}", CObj(c1), CObj(c2), Max (CObj (c1), CObj(c2)))
        Dim o1 As MyType
        o1 = new MyType(12)
        Dim o2 As MyType
        o2 = new MyType(17)
        Console.WriteLine ("Custom types: Max ({0}, {1}) == {2}", CObj(o1), CObj(o2), Max (CObj (o1), CObj(o2)))
        Console.WriteLine ()
        Console.WriteLine ("Press Return to exit.")
		Console.Read()

    
    End Sub
    
    Public Shared Function Max (val1 As IComparable , val2 As IComparable) As IComparable
        if (val1.CompareTo(val2) > 0) 
            Return val1 'val1 > val2
        End If
        
        if (val1.CompareTo(val2) < 0) 
           Return val2 'val1 < val2
        End If
        
        if (val1.CompareTo(val2) = 0) 
           Return val1 'val1 = val2, return val1 by definition
        End If
               
        
    End Function
    
End Class
    
    
Public Class MyType : Implements IComparable

    Private _value As Integer
    Public Sub New(value As Integer)
      MyBase.New()
       _value = value
    End Sub
    
    Public Function CompareTo (o As Object) As Integer Implements IComparable.CompareTo
        If (Not (TypeOf(o) is MyType)) 
           Throw New ArgumentException ("o must be of type 'MyType'")
        End If
        Dim v As MyType 
        v = CType (o, MyType)
        Return _value - v._value
    End Function
    
     Overrides Public Function  ToString () As String
        Return [String].Format ("MyType({0})", _value)
    End Function
End Class 'MyType
