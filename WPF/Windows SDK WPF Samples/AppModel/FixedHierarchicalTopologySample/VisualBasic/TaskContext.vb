Imports System

Public Class TaskContext

    Public Sub New(ByVal result As TaskResult, ByVal data As Object)
        Me.Result = result
        Me.Data = data
    End Sub

    Public Property Data() As Object
        Get
            Return Me._data
        End Get
        Set(ByVal value As Object)
            Me._data = value
        End Set
    End Property

    Public Property Result() As TaskResult
        Get
            Return Me._result
        End Get
        Set(ByVal value As TaskResult)
            Me._result = value
        End Set
    End Property

    Private _data As Object
    Private _result As TaskResult

End Class

