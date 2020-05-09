Imports System.ComponentModel
Imports System.Data
Imports System.Drawing

'<Designer(GetType(MyGridDesigner)), DesignTimeVisible(True), ToolboxBitmap(GetType(grd), "grd.ico")> _
<ToolboxBitmap(GetType(grd), "grd.ico")> _
Public Class grd
    Inherits System.Windows.Forms.DataGrid

#Region " Declarations"
    Event BoolColumnChanged(ByVal sender As Object, ByVal e As BoolValueChangedEventArgs)
    Event ColumnHeaderMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    Event ColumnHeaderMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
    Event ColumnHeaderBeforeMove(ByVal sender As Object, ByVal e As MouseEventArgs)
    Event ColumnHeaderAfterMove(ByVal sender As Object, ByVal e As MouseEventArgs)
    Event StaticComboValueChanged(ByVal rowChanging As Integer, ByVal newValue As Object)
    Event DoubleClick2(ByVal sender As Object, ByVal e As MouseEventArgs)
    Event DoubleClick3(ByVal sender As Object, ByVal e As EventArgs)

    Dim bColumnClick As Boolean
    Dim ColumnClickIndex As Integer
    Dim bColumnMove As Boolean
    Dim LastColumnMouseMove As Integer = -1

    Dim tblStyle As New DataGridTableStyle()

    Enum eSelectionStyle
        Cell
        Row
    End Enum

    Private m_SelectionStyle As eSelectionStyle
    Private m_DeleteMessageEnabled As Boolean
    Private m_DeleteMessageText As String
    Private m_DeleteMessageCaption As String
    Private m_WriteRowHeader As Boolean
    Private m_WriteRowHeaderColor As Color
    Private m_WriteRowHeaderText As String


    Private pointInCell00 As Point
    Private Const WM_KEYDOWN = &H100
    Private gridMouseDownTime As DateTime
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Width = 400
        Me.Height = 175
        Me.CaptionBackColor = Color.FromKnownColor(KnownColor.Window)
        Me.CaptionForeColor = Color.DarkGray
        Me.GridLineColor = Color.FromKnownColor(KnownColor.ControlDark)
        Me.BackgroundColor = Color.FromKnownColor(KnownColor.Window)
        Me.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight)
        Me.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText)
        Me.PreferredRowHeight = 16
        Me.HeaderBackColor = Color.FromKnownColor(KnownColor.ControlLightLight)

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Public Sub BeginTableStyle(ByVal dsTemp As DataSet)
        Try
            Me.TableStyles.Clear()
            tblStyle.Dispose()
            tblStyle = New DataGridTableStyle()
            Me.TableStyles.Add(tblStyle)
            Dim i As Integer
            While i < dsTemp.Tables(Me.DataMember).Columns.Count
                'MsgBox(dsTemp.Tables(Me.DataMember).Columns(i).DataType.ToString)
                If dsTemp.Tables(Me.DataMember).Columns(i).DataType.ToString = "System.Boolean" Then
                    Dim boolCol As New MyDataGridBoolColumn(i)
                    boolCol.MappingName = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    boolCol.HeaderText = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    boolCol.Width = 120
                    CType(boolCol, DataGridBoolColumn).AllowNull = False
                    AddHandler boolCol.BoolValueChanged, New MyDataGridBoolColumn.BoolValueChangedEventHandler(AddressOf BoolColumnChanged1)
                    tblStyle.GridColumnStyles.Add(boolCol)
                ElseIf dsTemp.Tables(Me.DataMember).Columns(i).DataType.ToString = "System.DateTime" Then

                    Dim DateCol As New DataGridDateColumn()
                    DateCol.DataViewP = dsTemp.Tables(Me.DataMember).DefaultView
                    DateCol.ValueMemberP = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    DateCol.MappingName = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    DateCol.HeaderText = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    tblStyle.GridColumnStyles.Add(DateCol)
                Else
                    If dsTemp.Tables(Me.DataMember).Columns(i).ReadOnly = True Then
                        NonEditableColumn(i)
                    Else
                        Dim TextCol As New DataGridTextBoxColumn()
                        TextCol.MappingName = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                        TextCol.HeaderText = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                        If tblStyle.GridColumnStyles.Contains(TextCol.MappingName) = True Then
                            'MsgBox(tblStyle.GridColumnStyles.Contains(TextCol.MappingName))
                            'raise exception
                        End If
                        AddHandler TextCol.TextBox.MouseDown, New MouseEventHandler(AddressOf TextBoxMouseDownHandler)
                        AddHandler TextCol.TextBox.DoubleClick, New EventHandler(AddressOf TextBoxDoubleClickHandler)
                        tblStyle.GridColumnStyles.Add(TextCol)
                    End If
                End If
                i += 1
            End While
            tblStyle.MappingName = Me.DataMember
            Me.TableStyles.Add(tblStyle)
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub AddComboColumn(ByVal ColumnIndex As Integer, ByVal dsTemp As DataSet, ByVal dtReferenceMember As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        Try
            Dim i As Integer
            While i < dsTemp.Tables(Me.DataMember).Columns.Count
                If i <> ColumnIndex Then
                Else
                    Dim ComboTextCol As New DataGridComboBoxColumn()
                    ComboTextCol.MappingName = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    ComboTextCol.HeaderText = dsTemp.Tables(Me.DataMember).Columns(i).ColumnName
                    ComboTextCol.Width = 120
                    'DataView dv = new DataView(myDataSet.Tables["customerList"], "", "customerID", DataViewRowState.CurrentRows);
                    ComboTextCol.ColumnComboBox.DataSource = dsTemp.Tables(dtReferenceMember).DefaultView 'dv;
                    ComboTextCol.ColumnComboBox.DisplayMember = DisplayMember
                    ComboTextCol.ColumnComboBox.ValueMember = ValueMember
                    tblStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
                    If tblStyle.GridColumnStyles.Contains(ComboTextCol.MappingName) = True Then
                        Dim k As Integer
                        For k = 0 To tblStyle.GridColumnStyles.Count - 1
                            If tblStyle.GridColumnStyles(k).MappingName = ComboTextCol.MappingName Then
                                tblStyle.GridColumnStyles.RemoveAt(k)
                                Exit For
                            End If
                        Next
                    End If
                    tblStyle.GridColumnStyles.Add(ComboTextCol)
                End If
                i = i + 1
            End While

            tblStyle.DataGrid.Refresh()
            Me.Refresh()
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BoolColumnChanged1(ByVal sender As Object, ByVal e As BoolValueChangedEventArgs)
        RaiseEvent BoolColumnChanged(sender, e)

        'Dim s As String
        's = System.String.Format("Bool Changes: row {0}, col {1}   value {2}", e.Row, e.Column, e.BoolValue)
    End Sub

    Public Property SelectionStyle() As eSelectionStyle
        Get
            Return m_SelectionStyle
        End Get
        Set(ByVal Value As eSelectionStyle)
            m_SelectionStyle = Value
        End Set
    End Property

    Public Sub HideColumn(ByVal ColumnIndex As Integer)
        tblStyle.GridColumnStyles(ColumnIndex).Width = 0
        tblStyle.DataGrid.Refresh()
    End Sub

    Public Sub NonEditableColumn(ByVal ColumnIndex As Integer)
        Try
            Dim csIDInt As DataGridNonEditableTextBoxColumn
            Dim pdc As PropertyDescriptorCollection
            pdc = Me.BindingContext(Me.DataSource, Me.DataMember).GetItemProperties
            csIDInt = New DataGridNonEditableTextBoxColumn(pdc(Me.DataSource.Tables(Me.DataMember).Columns(ColumnIndex).ColumnName), "i", True, False)
            csIDInt.MappingName = Me.DataSource.Tables(Me.DataMember).Columns(ColumnIndex).ColumnName
            csIDInt.HeaderText = Me.DataSource.Tables(Me.DataMember).Columns(ColumnIndex).ColumnName
            csIDInt.Width = 60
            If tblStyle.GridColumnStyles.Contains(csIDInt.MappingName) = True Then
                Dim k As Integer
                For k = 0 To tblStyle.GridColumnStyles.Count - 1
                    If tblStyle.GridColumnStyles(k).MappingName = csIDInt.MappingName Then
                        tblStyle.GridColumnStyles.RemoveAt(k)
                        Exit For
                    End If
                Next
            End If
            AddHandler csIDInt.TextBox.MouseDown, New MouseEventHandler(AddressOf TextBoxMouseDownHandler)
            AddHandler csIDInt.TextBox.DoubleClick, New EventHandler(AddressOf TextBoxDoubleClickHandler)
            tblStyle.GridColumnStyles.Add(csIDInt)
            tblStyle.DataGrid.Refresh()
            'me.TableStyles.Clear  
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Try
            Dim pt As Point = Me.PointToClient(Cursor.Position)
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(pt)
            If hti.Type = Me.HitTestType.ColumnHeader Then
                'MessageBox.Show("double clicked clicked column header " + hti.Column.ToString())
                bColumnClick = True
                ColumnClickIndex = CInt(hti.Column)
                RaiseEvent ColumnHeaderMouseDown(sender, e)
                'Me.AllowDrop = True
                'Me.DoDragDrop(tblStyle.GridColumnStyles, DragDropEffects.Move)
                Dim cellRect As Rectangle
                cellRect = Me.GetCellBounds(0, hti.Column)

                Dim ColRect As Rectangle
                ColRect.Width = cellRect.Width
                ColRect.Height = 16 'cellRect.Height
                ColRect.X = cellRect.X - 1
                ColRect.Y = 22 'cellRect.Y - 18
                Dim gColumn As Graphics = Me.CreateGraphics
                gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect)
                Dim p As New Pen(Color.FromArgb(255, 192, 128), 1)
                gColumn.DrawLine(p, ColRect.X, 38, ColRect.X + ColRect.Width, 38)
                gColumn.DrawLine(p, ColRect.X + ColRect.Width, 38, ColRect.X + ColRect.Width, 22)
                p.Color = Color.DarkOrange
                p.Width = 2
                gColumn.DrawLine(p, ColRect.X, 38, ColRect.X, 22)
                gColumn.DrawLine(p, ColRect.X, 22, ColRect.X + ColRect.Width, 22)
            End If
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Try
            Dim pt As Point = Me.PointToClient(Cursor.Position)
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(pt)
            If hti.Type = Me.HitTestType.ColumnHeader Then
                If bColumnClick = True Then
                    If Not CInt(hti.Column) = ColumnClickIndex Then
                        If bColumnClick = True Then
                            bColumnMove = True
                            Me.Cursor = Cursors.Hand
                        End If
                    End If
                Else
                    Dim cellRect As Rectangle
                    cellRect = Me.GetCellBounds(0, hti.Column)
                    Dim ColRect As Rectangle
                    ColRect.Width = cellRect.Width
                    ColRect.Height = 16 'cellRect.Height
                    ColRect.X = cellRect.X - 1
                    ColRect.Y = 22 'cellRect.Y - 18
                    Dim gColumn As Graphics = Me.CreateGraphics
                    gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect)
                    Dim p As New Pen(Color.DarkOrange, 2)
                    gColumn.DrawLine(p, ColRect.X, 38, ColRect.X + ColRect.Width, 38)
                    gColumn.DrawLine(p, ColRect.X + ColRect.Width, 38, ColRect.X + ColRect.Width, 22)
                    p.Color = Color.FromArgb(255, 192, 128)
                    p.Width = 1
                    gColumn.DrawLine(p, ColRect.X, 38, ColRect.X, 22)
                    gColumn.DrawLine(p, ColRect.X, 22, ColRect.X + ColRect.Width, 22)
                    If Not LastColumnMouseMove = hti.Column AndAlso LastColumnMouseMove <> -1 Then
                        Dim cellRect2 As Rectangle
                        cellRect2 = Me.GetCellBounds(0, LastColumnMouseMove)
                        Dim ColRect2 As Rectangle
                        ColRect2.Width = cellRect2.Width
                        ColRect2.Height = 16 'cellRect.Height
                        ColRect2.X = cellRect2.X
                        ColRect2.Y = 22 'cellRect.Y - 18
                        gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect2)
                        p.Color = Color.LightGray
                        p.Width = 2
                        gColumn.DrawLine(p, ColRect2.X, 38, ColRect2.X + ColRect2.Width, 38)
                        gColumn.DrawLine(p, ColRect2.X + ColRect2.Width, 38, ColRect2.X + ColRect2.Width, 22)
                    End If
                    LastColumnMouseMove = hti.Column
                End If
            Else
                If LastColumnMouseMove <> -1 Then
                    Dim cellRect2 As Rectangle
                    cellRect2 = Me.GetCellBounds(0, LastColumnMouseMove)
                    Dim ColRect2 As Rectangle
                    ColRect2.Width = cellRect2.Width
                    ColRect2.Height = 16 'cellRect.Height
                    ColRect2.X = cellRect2.X - 1
                    ColRect2.Y = 22 'cellRect.Y - 18
                    Dim gColumn As Graphics = Me.CreateGraphics
                    gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect2)
                    Dim p As New Pen(Color.LightGray)
                    p.Color = Color.LightGray
                    p.Width = 2
                    gColumn.DrawLine(p, ColRect2.X, 38, ColRect2.X + ColRect2.Width, 38)
                    gColumn.DrawLine(p, ColRect2.X + ColRect2.Width, 38, ColRect2.X + ColRect2.Width, 22)
                End If
                'If hti.Type = Me.HitTestType.RowHeader Then
                '    Dim cellRect As Rectangle
                '    cellRect = Me.GetCellBounds(hti.Row, 0)
                '    Dim ColRect As Rectangle
                '    ColRect.Width = Me.RowHeaderWidth
                '    ColRect.Height = 16 'cellRect.Height
                '    ColRect.X = 1
                '    ColRect.Y = (hti.Row + 1) * 16 + 42
                '    Dim gColumn As Graphics = Me.CreateGraphics
                '    'gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect)
                '    Dim p As New Pen(Color.DarkOrange, 2)
                '    gColumn.DrawLine(p, ColRect.X, ColRect.Y, ColRect.X + ColRect.Width, ColRect.Y)
                '    gColumn.DrawLine(p, ColRect.X + ColRect.Width, ColRect.Y, ColRect.X + ColRect.Width, ColRect.Y - 16)
                '    p.Color = Color.FromArgb(255, 192, 128)
                '    p.Width = 1
                '    gColumn.DrawLine(p, ColRect.X, ColRect.Y, ColRect.X, ColRect.Y - 16)
                '    gColumn.DrawLine(p, ColRect.X, ColRect.Y - 16, ColRect.X + ColRect.Width, ColRect.Y - 16)
                'End If
            End If
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        Try
            Dim pt = New Point(e.X, e.Y)
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(pt)
            If m_SelectionStyle = eSelectionStyle.Row Then
                If hti.Type = Me.HitTestType.ColumnHeader Then
                    RaiseEvent ColumnHeaderMouseUp(sender, e)
                ElseIf hti.Type = DataGrid.HitTestType.Cell Then
                    Me.CurrentCell = New DataGridCell(hti.Row, hti.Column)
                    If Me.TableStyles(0).GridColumnStyles(Me.HitTest(pt).Column).ToString = "MyControls.MyDataGridBoolColumn" Then
                        'Me(hti.Row, hti.Column) = Not CBool(Me(hti.Row, hti.Column))
                    End If
                    Me.Select(hti.Row)
                End If
            End If
            If hti.Type = Windows.Forms.DataGrid.HitTestType.RowHeader Or hti.Type = Windows.Forms.DataGrid.HitTestType.None Then
                Exit Sub
            End If
            If bColumnClick = True And bColumnMove = True Then
                RaiseEvent ColumnHeaderBeforeMove(sender, e)
                MoveColumn(ColumnClickIndex, CInt(hti.Column))
                RaiseEvent ColumnHeaderAfterMove(sender, e)
            End If
            bColumnClick = False : bColumnMove = False
            If hti.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                If Me.TableStyles(0).GridColumnStyles(Me.HitTest(pt).Column).ToString = "MyControls.MyDataGridBoolColumn" Then
                    If Not hti.Row = -1 Then
                        If Not Me(hti.Row, hti.Column).GetType.ToString = "System.DBNull" Then
                            Me(hti.Row, hti.Column) = Not CBool(Me(hti.Row, hti.Column))
                        Else
                            Me(hti.Row, hti.Column) = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ' Throw New Exception("MyGridException")
        End Try
    End Sub

    Private Sub MoveColumn(ByVal fromCol As Integer, ByVal toCol As Integer)
        Try
            If fromCol = toCol Then
                Return
            End If
            Dim _mappingName As String = Me.DataMember
            Dim oldTS As DataGridTableStyle = Me.TableStyles(_mappingName)
            Dim newTS As New DataGridTableStyle()
            newTS.MappingName = _mappingName
            Dim i As Integer
            i = 0
            While i < oldTS.GridColumnStyles.Count
                If i <> fromCol And fromCol < toCol Then
                    newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
                End If
                If i = toCol Then
                    newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(fromCol))
                End If
                If i <> fromCol And fromCol > toCol Then
                    newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
                End If
                i = i + 1
            End While
            Me.TableStyles.Remove(oldTS)
            Me.TableStyles.Add(newTS)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Throw New Exception("MyGridException")
        End Try
    End Sub 'MoveColumn 

    Private Sub MyComboValueChanged(ByVal rowChanging As Integer, ByVal newValue As Object)
        'Console.WriteLine("index changed {0} {1}", rowChanging, newValue)
        RaiseEvent StaticComboValueChanged(rowChanging, newValue)
    End Sub

    Public ReadOnly Property NumberofRows() As Integer
        Get
            Return Me.BindingContext(Me.DataSource, Me.DataMember).Count
        End Get
    End Property

#Region " AutoSizing Columns "
    Public Sub AutoSizeAllColumns()
        Dim numCols As Integer
        numCols = CType(Me.DataSource, DataTable).Columns.Count
        Dim i As Integer
        i = 0
        Do While (i < numCols)
            AutoSizeCol(i)
            i = (i + 1)
        Loop
    End Sub
    Private Sub AutoSizeCol(ByVal col As Integer)
        Dim width As Single
        width = 0
        Dim numRows As Integer
        numRows = CType(Me.DataSource, DataTable).Rows.Count
        Dim g As Graphics
        g = Graphics.FromHwnd(Me.Handle)
        Dim sf As StringFormat
        sf = New StringFormat(StringFormat.GenericTypographic)
        Dim size As SizeF
        Dim i As Integer
        i = 0
        Do While (i < numRows)
            size = g.MeasureString(Me(i, col).ToString, Me.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width
            End If
            i = (i + 1)
        Loop
        g.Dispose()
        Me.TableStyles("customers").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub
    Public Sub AutoSizeColumn(ByVal ColumnIndex As Integer)
        AutoSizeCol(ColumnIndex)
    End Sub
#End Region
#Region " Delete Message "
    <Category("Delete Message"), Description("If True a delete confirmation message appears.")> _
    Public Property DeleteMessageEnabled() As Boolean
        Get
            Return m_DeleteMessageEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_DeleteMessageEnabled = Value
        End Set
    End Property
    <Category("Delete Message")> _
Public Property DeleteMessageText() As String
        Get
            Return m_DeleteMessageText
        End Get
        Set(ByVal Value As String)
            m_DeleteMessageText = Value
        End Set
    End Property
    <Category("Delete Message")> _
    Public Property DeleteMessageCaption() As String
        Get
            Return m_DeleteMessageCaption
        End Get
        Set(ByVal Value As String)
            m_DeleteMessageCaption = Value
        End Set
    End Property
    Public Overrides Function PreProcessMessage(ByRef msg As System.Windows.Forms.Message) As Boolean
        Dim keyCode As Keys = CType((msg.WParam.ToInt32 And Keys.KeyCode), Keys)
        If m_DeleteMessageEnabled = False Then Exit Function
        If msg.Msg = WM_KEYDOWN And keyCode = Keys.Delete Then
            If MessageBox.Show(m_DeleteMessageText, m_DeleteMessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return True
            End If
        End If
        Return MyBase.PreProcessMessage(msg)
    End Function
#End Region

    Private Sub grd_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim i As Integer
            If Not Me.DataSource Is Nothing Then
                For i = 0 To Me.DataSource.tables(Me.DataMember).columns.count - 1
                    Dim cellRect As Rectangle
                    cellRect = Me.GetCellBounds(0, i)
                    Dim ColRect As Rectangle
                    ColRect.Width = cellRect.Width - 1
                    ColRect.Height = 16 'cellRect.Height
                    ColRect.X = cellRect.X
                    ColRect.Y = 22 'cellRect.Y - 18
                    Dim gColumn As Graphics = Me.CreateGraphics
                    gColumn.DrawRectangle(New Pen(Color.FromKnownColor(KnownColor.Control), 2), ColRect)
                    Dim p As New Pen(Color.LightGray, 2)
                    gColumn.DrawLine(p, ColRect.X, 38, ColRect.X + ColRect.Width, 38)
                    gColumn.DrawLine(p, ColRect.X + ColRect.Width, 38, ColRect.X + ColRect.Width, 22)
                    'p.Color = Color.White
                    'p.Width = 1
                    'gColumn.DrawLine(p, ColRect.X, 38, ColRect.X, 22)
                    'gColumn.DrawLine(p, ColRect.X, 22, ColRect.X + ColRect.Width, 22)
                Next
            End If
            If m_WriteRowHeader = True Then

                Dim row As Integer
                row = TopRow()
                Dim yDelta As Integer
                yDelta = (Me.GetCellBounds(row, 0).Height + 1)
                Dim y As Integer
                y = (Me.GetCellBounds(row, 0).Top + 2)
                Dim cm As CurrencyManager
                cm = CType(Me.BindingContext(Me.DataSource, Me.DataMember), CurrencyManager)
                Do While ((y < (Me.Height - yDelta)) AndAlso (row < cm.Count))
                    'get & draw the header text...
                    Dim text1 As String
                    text1 = System.String.Format(m_WriteRowHeaderText + "{0}", row)
                    e.Graphics.DrawString(text1, Me.Font, New SolidBrush(m_WriteRowHeaderColor), 6, y)
                    Dim p As New Pen(Color.LightGray, 2)
                    e.Graphics.DrawLine(p, 2, yDelta + y - 3, Me.RowHeaderWidth, yDelta + y - 3)
                    e.Graphics.DrawLine(p, Me.RowHeaderWidth, yDelta + y - 3, Me.RowHeaderWidth, y - 3)
                    y = (y + yDelta)
                    row = (row + 1)
                Loop
            End If
        Catch ex As Exception
            'Throw New Exception("MyGridException")
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function TopRow() As Integer
        Try
            pointInCell00 = New Point((Me.GetCellBounds(0, 0).X + 4), (Me.GetCellBounds(0, 0).Y + 4))
            Dim hti As DataGrid.HitTestInfo
            hti = Me.HitTest(Me.pointInCell00)
            If Not hti.Row = -1 Then
                Return hti.Row
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Property WriteRowHeader() As Boolean
        Get
            Return m_WriteRowHeader
        End Get
        Set(ByVal Value As Boolean)
            m_WriteRowHeader = Value
        End Set
    End Property
    <DefaultValue("Color.ControlText")> _
    Public Property WriteRowHeaderColor() As Color
        Get
            Return m_WriteRowHeaderColor
        End Get
        Set(ByVal Value As Color)
            m_WriteRowHeaderColor = Value
        End Set
    End Property
    <DefaultValue("Row")> _
    Public Property WriteRowHeaderText() As String
        Get
            Return m_WriteRowHeaderText
        End Get
        Set(ByVal Value As String)
            m_WriteRowHeaderText = Value
        End Set
    End Property
    Public Sub SetMyColorStyle()
        Me.CaptionBackColor = Color.FromKnownColor(KnownColor.Window)
        Me.CaptionForeColor = Color.DarkGray
        Me.tblStyle.GridLineColor = Color.FromKnownColor(KnownColor.ControlDark)
        Me.BackgroundColor = Color.FromKnownColor(KnownColor.Window)
        Me.tblStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight)
        Me.tblStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText)
        Me.tblStyle.PreferredRowHeight = 16
        Me.tblStyle.HeaderBackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
    End Sub
#Region " Grid DoubleClick Events "
    Private Sub TextBoxDoubleClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DoubleClick3(sender, e)
    End Sub
    Private Sub TextBoxMouseDownHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (DateTime.Now < gridMouseDownTime.AddMilliseconds(SystemInformation.DoubleClickTime)) Then
            RaiseEvent DoubleClick2(sender, e)
        End If
    End Sub
    Private Sub Me_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        gridMouseDownTime = DateTime.Now
    End Sub
#End Region

    Public Function Value(ByVal Row As Integer, ByVal Col As Integer) As String
        If Not Me.Item(Me.CurrentCell.RowNumber, Me.CurrentCell.ColumnNumber).GetType.ToString = "System.DBNull" Then
            Return Me.Item(Row, Col)
        Else
            Return ""
        End If
    End Function
    Public Function CurrentValue() As String
        If Not Me.Item(Me.CurrentCell.RowNumber, Me.CurrentCell.ColumnNumber).GetType.ToString = "System.DBNull" Then
            Return Me.Item(Me.CurrentCell.RowNumber, Me.CurrentCell.ColumnNumber)
        Else
            Return ""
        End If
    End Function
    Public Sub AddNewRowVisible(ByVal Val As Boolean)
        Dim cm As CurrencyManager = CType(Me.BindingContext(Me.DataSource, Me.DataMember), CurrencyManager)
        CType(cm.List, DataView).AllowNew = Val
    End Sub
    'Public Property DefaultColumnValue(ByVal ColumnIndex As Integer) As String
    '    Get
    '        Return Me.DataSource.tables(Me.DataMember).columns(ColumnIndex).defaultvalue
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.DataSource.tables(Me.DataMember).columns(ColumnIndex).defaultvalue = Value
    '    End Set
    'End Property

End Class
