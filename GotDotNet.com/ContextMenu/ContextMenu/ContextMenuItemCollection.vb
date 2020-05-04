Imports System.Web.UI
Imports System.Collections


'@ <summary>
'@ A collection of ContextMenuItem objects in a ContextMenu control
'@ </summary>
Public Class ContextMenuItemCollection
    Inherits CollectionBase

#Region " CollectionBase overrides "

    Default Public Property Item(ByVal index As Integer) As ContextMenuItem
        Get
            Return CType(List(index), ContextMenuItem)
        End Get
        Set(ByVal Value As ContextMenuItem)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal value As ContextMenuItem) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As ContextMenuItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As ContextMenuItem)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As ContextMenuItem)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As ContextMenuItem) As Boolean
        ' If value is not of type ContextMenuItem, this will return false.
        Return List.Contains(value)
    End Function 'Contains


    Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("MarkItUp.WebControls.ContextMenuItem") Then
            Throw New ArgumentException("value must be of type MarkItUp.WebControls.ContextMenuItem.", "value")
        End If
    End Sub 'OnInsert


    Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("MarkItUp.WebControls.ContextMenuItem") Then
            Throw New ArgumentException("value must be of type MarkItUp.WebControls.ContextMenuItem.", "value")
        End If
    End Sub 'OnRemove


    Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As [Object], ByVal newValue As [Object])
        If Not newValue.GetType() Is Type.GetType("MarkItUp.WebControls.ContextMenuItem") Then
            Throw New ArgumentException("newValue must be of type MarkItUp.WebControls.ContextMenuItem.", "newValue")
        End If
    End Sub 'OnSet


    Protected Overrides Sub OnValidate(ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("MarkItUp.WebControls.ContextMenuItem") Then
            Throw New ArgumentException("value must be of type MarkItUp.WebControls.ContextMenuItem.")
        End If
    End Sub 'OnValidate



#End Region

End Class
