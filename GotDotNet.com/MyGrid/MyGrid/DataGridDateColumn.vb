Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms

Public Class NoKeyUpDateTimePicker
    Inherits DateTimePicker
    Private WM_KEYUP As Integer = &H101

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_KEYUP Then
            'ignore keyup to avoid problem with tabbing & dropdownlist;
            Return
        End If
        MyBase.WndProc(m)
    End Sub 'WndProc
End Class 'NoKeyUpDateTimePicker

' Step 1. Derive a custom column style from DataGridTextBoxColumn
'	a) add a ComboBox member
'  b) track when the combobox has focus in Enter and Leave events
'  c) override Edit to allow the ComboBox to replace the TextBox
'  d) override Commit to save the changed data
Public Class DataGridDateColumn
    Inherits DataGridTextBoxColumn
    Public ColumnDatePicker As NoKeyUpDateTimePicker
    Private _source As System.Windows.Forms.CurrencyManager
    Private _rowNum As Integer
    Private _isEditing As Boolean
    Public Shared _RowCount As Integer


    Public Sub New()
        _source = Nothing
        _isEditing = False
        _RowCount = -1

        ColumnDatePicker = New NoKeyUpDateTimePicker()
        ColumnDatePicker.CalendarTitleBackColor = System.Drawing.SystemColors.Window
        ColumnDatePicker.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText

        AddHandler ColumnDatePicker.Leave, AddressOf LeaveDateTimePicker
        AddHandler ColumnDatePicker.CloseUp, AddressOf DateTimePickerStartEditing
    End Sub 'New

    Private Sub HandleScroll(ByVal sender As Object, ByVal e As EventArgs)
        If ColumnDatePicker.Visible Then
            ColumnDatePicker.Hide()
        End If
    End Sub 'HandleScroll

    Private Sub DateTimePickerStartEditing(ByVal sender As Object, ByVal e As EventArgs)
        _isEditing = True
        MyBase.ColumnStartedEditing(sender)
    End Sub 'ComboMadeCurrent


    Private Sub LeaveDateTimePicker(ByVal sender As Object, ByVal e As EventArgs)
        If _isEditing Then
            SetColumnValueAtRow(_source, _rowNum, ColumnDatePicker.Text)
            _isEditing = False
            Invalidate()

        End If
        ColumnDatePicker.Hide()
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf HandleScroll)
    End Sub 'LeaveDateTimePicker


    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        MyBase.Edit([source], rowNum, bounds, [readOnly], instantText, cellIsVisible)

        _rowNum = rowNum
        _source = [source]

        ColumnDatePicker.Parent = Me.TextBox.Parent
        'ColumnDatePicker.Location = Me.TextBox.Location
        ColumnDatePicker.Left = Me.TextBox.Left - 2
        ColumnDatePicker.Top = Me.TextBox.Top - 2
        ColumnDatePicker.Size = New Size(Me.TextBox.Size.Width + 2, ColumnDatePicker.Size.Height)
        'ColumnDatePicker.SelectedIndex = ColumnDatePicker.FindStringExact(Me.TextBox.Text)
        If Not Me.TextBox.Text = "(null)" Then
            ColumnDatePicker.Text = Me.TextBox.Text
        Else
            ColumnDatePicker.Text = DateTime.Today
        End If

        Me.TextBox.Visible = False
        ColumnDatePicker.Visible = True
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf HandleScroll

        ColumnDatePicker.BringToFront()
        ColumnDatePicker.Focus()
    End Sub 'Edit


    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        If _isEditing Then
            _isEditing = False
            SetColumnValueAtRow(dataSource, rowNum, ColumnDatePicker.Text)
        End If
        Return True
    End Function 'Commit


    Protected Overrides Sub ConcedeFocus()
        Console.WriteLine("ConcedeFocus")
        MyBase.ConcedeFocus()
    End Sub 'ConcedeFocus

    Protected Overrides Function GetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Object

        Dim s As Object = MyBase.GetColumnValueAtRow([source], rowNum)
        Dim dv As DataView = m_DataView
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object

        'if things are slow, you could order your dataview
        '& use binary search instead of this linear one
        While i < rowCount
            s1 = dv(i)(m_ValueMember)
            If (Not s1 Is DBNull.Value) AndAlso (Not s Is DBNull.Value) AndAlso s = s1 Then
                Exit While
            End If
            i = i + 1
        End While
        If i < rowCount Then
            Return dv(i)(m_ValueMember)
        End If
        Return DBNull.Value
    End Function 'GetColumnValueAtRow


    Protected Overrides Sub SetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
        Dim s As Object = value

    
        MyBase.SetColumnValueAtRow([source], rowNum, s)
    End Sub 'SetColumnValueAtRow 

    Dim m_DataView As DataView
    Public Property DataViewP() As DataView
        Get
            Return m_DataView
        End Get
        Set(ByVal Value As DataView)
            m_DataView = Value
        End Set
    End Property
    Dim m_ValueMember As String
    Public Property ValueMemberP() As String
        Get
            Return m_ValueMember
        End Get
        Set(ByVal Value As String)
            m_ValueMember = Value
        End Set
    End Property
End Class 'DataGridComboBoxColumn


