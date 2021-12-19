Public Class SampleInterface
    'This class defines two interfaces to be implemented 
    'by another class.
    Interface IFirst
        Function Foo() As String
        Function Foo1() As String
    End Interface
    Interface ISecond
        Function Foo() As String
        Function Foo2() As String
    End Interface
End Class
