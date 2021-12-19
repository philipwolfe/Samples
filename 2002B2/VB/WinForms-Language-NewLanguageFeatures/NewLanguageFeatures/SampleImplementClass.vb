Public Class SampleImplementClass
    'This class will implement the two interfaces defined in 
    'SampleInterface as well as a default interface.
    Implements SampleInterface.IFirst
    Implements SampleInterface.ISecond
    'The function is defined to provide the implementation for IFirst.Foo1
    Public Function Foo1() As String Implements SampleInterface.IFirst.Foo1
        'Return has the same effect as setting the string equal to the function name
        Return "SampleImplementClass Implementation of Foo1 for IFirst"
    End Function
    'The function is defined to provide the implementation for IFirst.Foo and ISecond.Foo
    Public Function Foo() As String Implements SampleInterface.IFirst.Foo, SampleInterface.ISecond.Foo
        Return "SampleImplementClass Implementation of Foo for IFirst and ISecond"
    End Function
    'The function is defined to provide the implementation for ISecond.Foo2
    Public Function Foo2() As String Implements SampleInterface.ISecond.Foo2
        Return "SampleImplementClass Implementation of Foo2 for ISecond"
    End Function
    'The function is exposed through the default interface
    Public Function GetInfo() As String
        Return "SampleImplementClass Default interface GetInfo method."
    End Function
End Class
