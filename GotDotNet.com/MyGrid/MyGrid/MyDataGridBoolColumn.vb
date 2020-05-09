Option Strict Off
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms


Public Class MyDataGridBoolColumn
    Inherits DataGridBoolColumn

    Public Delegate Sub BoolValueChangedEventHandler(ByVal sender As Object, ByVal e As BoolValueChangedEventArgs)

    Private saveValue As Boolean
    Private saveRow As Integer
    Private lockValue As Boolean
    Private beingEdited As Boolean
    Private _column As Integer
    Public Const VK_SPACE As Integer = 32

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function GetKeyState(ByVal nVirtKey As Integer) As Short
    End Function

    'Fields
    'Constructors
    'Events
    'Methods
    Public Sub New(ByVal column As Integer)
        MyBase.New()
        saveValue = False
        saveRow = -(1)
        lockValue = False
        beingEdited = False
        _column = column
    End Sub

    Public Event BoolValueChanged As BoolValueChangedEventHandler

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
        Dim changing As Boolean
        Dim mousePos As Point = Me.DataGridTableStyle.DataGrid.PointToClient(Control.MousePosition)
        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim isClickInCell As Boolean = ((Control.MouseButtons = MouseButtons.Left) And _
         dg.GetCellBounds(dg.CurrentCell).Contains(mousePos))

        changing = dg.Focused And (isClickInCell Or GetKeyState(VK_SPACE) < 0)   ' or spacebar

        If ((Not lockValue) And beingEdited And changing And saveRow = rowNum) Then
            saveValue = Not (saveValue)
            lockValue = False
            Dim e As New BoolValueChangedEventArgs(rowNum, _column, saveValue)
            RaiseEvent BoolValueChanged(Me, e)
        End If

        If (saveRow = rowNum) Then
            lockValue = False
        End If
        'Dim foreBrush2 As New SolidBrush(Color.Red)
        'Dim backBrush2 As New SolidBrush(Color.FromKnownColor(KnownColor.Red))
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'g.FillRectangle(backBrush2, bounds)
    End Sub
    Protected Overloads Overrides Sub Edit(ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        lockValue = True
        beingEdited = True
        saveRow = rowNum
        If Not (MyBase.GetColumnValueAtRow(source, rowNum).GetType.ToString) = "System.DBNull" Then
            saveValue = CType(MyBase.GetColumnValueAtRow(source, rowNum), Boolean)
        Else
            saveValue = True
        End If
        'MsgBox(bounds.Width)
        Dim backBrush2 As New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
        Dim foreBrush2 As New SolidBrush(Color.Red)

        MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
    End Sub
    Protected Overloads Overrides Function Commit(ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) As Boolean

        lockValue = True
        beingEdited = False
        Return MyBase.Commit(dataSource, rowNum)

    End Function

End Class

