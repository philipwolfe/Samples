Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.Util

Namespace TemplateControlSamples

    Public Class RepeaterItemCollectionVB : Implements ICollection

        Private Items As ArrayList

        Public Sub New(Items As ArrayList)
            MyBase.New()
            Me.Items = Items
        End Sub

        Public ReadOnly Property All As RepeaterItemVB()
            Get
                return CType(Items.ToArray(), RepeaterItemVB())
            End Get
        End Property

        Public ReadOnly Property Count As Integer Implements ICollection.Count
            Get
                Return Items.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection.IsReadOnly
            Get 
                Return false
            End Get
        End Property

        Public ReadOnly Property IsSynchronized As Boolean  Implements ICollection.IsSynchronized
            Get
                Return false
            End Get
        End Property

        Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
            Get
                Return Me
            End Get
        End Property

        Public Default ReadOnly Property Item(Index As Integer) As RepeaterItemVB 
            Get
                Return CType(Items(Index), RepeaterItemVB)
            End Get
        End Property
        
        Public Sub CopyTo(OutputArray As Array, Index As Integer)  Implements ICollection.CopyTo
            Dim E As IEnumerator = Me.GetEnumerator()
            Do While (E.MoveNext())
                OutputArray.SetValue(E.Current, Index)
                Index = Index + 1
            Loop
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements ICollection.GetEnumerator
            Return Items.GetEnumerator()
        End Function

    End Class

End Namespace
