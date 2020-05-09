Option Strict Off
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System

Public Class BoolValueChangedEventArgs
    Inherits EventArgs
    Private _column As Integer
    Private _row As Integer
    Private _value As Boolean
    'Fields
    'Constructors
    'Methods
    Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal val As Boolean)
        MyBase.New()
        _row = row
        _column = col
        _value = val

    End Sub
    Public Property Column() As Integer
        Get

            Return _column

        End Get
        Set(ByVal Value As Integer)

            _column = Value

        End Set
    End Property
    Public Property Row() As Integer
        Get

            Return _row

        End Get
        Set(ByVal Value As Integer)

            _row = Value

        End Set
    End Property
    Public Property BoolValue() As Boolean
        Get

            Return _value

        End Get
        Set(ByVal Value As Boolean)

            _value = Value

        End Set
    End Property
End Class

