Option Strict Off
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataGridNonEditableTextBoxColumn
    Inherits DataGridTextBoxColumn
 
    Private m_Editable As Boolean = True
    Public Sub New(ByVal pd As PropertyDescriptor, ByVal format As String, ByVal b As Boolean, ByVal Editable As Boolean)
        MyBase.New(pd, format, b)
        m_Editable = Editable
        AddHandler Me.TextBox.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf HandleKeyPress)

    End Sub

    Private Sub HandleKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If m_Editable = False Then
            e.Handled = True
            'Exit Sub
        End If
    End Sub

    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String)
        If rowNum = 5 Then
            Return
        End If
        MyBase.Edit(source, rowNum, bounds, True, instantText, True)
    End Sub
End Class
