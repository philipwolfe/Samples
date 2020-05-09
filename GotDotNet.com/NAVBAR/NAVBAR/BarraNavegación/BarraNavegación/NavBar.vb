'***********************************************************************************************************
' From Spain: November 2002
'
' All code has been developed by:
' Jesús López is MCP SQL Server and Microsoft .NET MVP
' You can contact with Jesús in his web site (SqlRanger - http://www.sqlranger.com/)
'
' With a little contribution of:
' Jorge Serrano is Microsoft .NET MVP
' You can contact with Jorge in his web site (PortalVB.com - http://www.portalvb.com/)
'***********************************************************************************************************

Imports System.Windows.Forms
Imports System.Data
Imports System.ComponentModel
Imports System.Threading

Public Class NavBar

    Inherits System.Windows.Forms.UserControl

    Public Event ErrorsOcurred(ByVal Sender As Object, ByVal e As NavBarErrorEventArgs)
    Public Event RowDeleting(ByVal Sender As Object, ByVal e As NavBarDeletingRowEventArgs)
    Public Event BeforeNav(ByVal Sender As Object, ByVal e As NavBarBeforeNavEventArgs)
    Public Event AfterNav(ByVal Sender As Object, ByVal e As NavBarAfterNavEventArgs)

    Private WithEvents BindingManager As CurrencyManager
    Private WithEvents mDataView As DataView
    Private WithEvents mTable As DataTable
    Private WithEvents Bindings As BindingsCollection
    Private mCurrentRowView As DataRowView
    Private InternalEnabled As Boolean
    Private mErrorsOcurred As Boolean
    Private mIgnoreRowDeleting As Boolean
    Private mLastTimeDeleted As Date
    Private mLastRowDeleted As DataRow
    Private fb As FilterBuilder

    Private Shared ExHandler As ExceptionHandler

    Shared Sub New()
        ExHandler = New ExceptionHandler()
        AddHandler Application.ThreadException, AddressOf ExHandler.OnThreadException
    End Sub

    Public ReadOnly Property ErrorOcurred() As Boolean
        Get
            Return Me.mErrorsOcurred
        End Get
    End Property

    Public Property DataView() As DataView
        Get
            Return mDataView
        End Get
        Set(ByVal Value As DataView)
            Me.mDataView = Value
            If Value Is Nothing Then
                Me.Panel1.Enabled = False
                Me.mTable = Nothing
                Me.fb = Nothing
            Else
                Me.mTable = Value.Table
                Me.Panel1.Enabled = True
                If Not Me.ParentForm Is Nothing Then
                    Me.BindingManager = Me.ParentForm.BindingContext(Value)
                    Me.ControlsEnabled = New Hashtable(8)
                    Dim i As Integer, c As Control
                    For i = 0 To BindingManager.Bindings.Count - 1
                        c = BindingManager.Bindings(i).Control
                        If Not c Is Me Then _
                            Me.ControlsEnabled.Add(c, c.Enabled)
                    Next
                    Me.Bindings = Me.BindingManager.Bindings
                    Me.BindingManager_CurrentChanged(Me, EventArgs.Empty)
                    Me.NavEliminar.Enabled = Me.AllowDelete
                    Me.fb = New FilterBuilder()
                Else
                    Me.BindingManager = Nothing
                    Me.Bindings = Nothing
                    Me.ControlsEnabled = Nothing
                    Me.fb = Nothing
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property CurrentRowView() As DataRowView
        Get
            Return Me.mCurrentRowView
        End Get
    End Property

    Public ReadOnly Property CurrencyManager() As CurrencyManager
        Get
            Return Me.BindingManager
        End Get
    End Property


    Private mAllowDelete As Boolean
    Public Property AllowDelete() As Boolean
        Get
            Return Me.mAllowDelete
        End Get
        Set(ByVal Value As Boolean)
            If mAllowDelete = Value Then Return
            mAllowDelete = Value
            If Value Then
                If Not Me.DataView Is Nothing Then
                    Me.NavEliminar.Enabled = True
                End If
            Else
                Me.NavEliminar.Enabled = False
            End If
        End Set
    End Property

    Private mAllowAddNew As Boolean
    Public Property AllowAddNew() As Boolean
        Get
            Return Me.mAllowAddNew
        End Get
        Set(ByVal Value As Boolean)
            If Me.mAllowAddNew = Value Then Return
            Me.mAllowAddNew = Value
            If Not Value Then
                Me.NavNew.Enabled = False
            Else
                Me.BindingManager_CurrentChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        Me.InternalEnabled = True
        Me.AllowDelete = True
        Me.AllowAddNew = True
        Me.mLastTimeDeleted = Now()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NavNew As SqlRanger.NavButton
    Friend WithEvents NavLast As SqlRanger.NavButton
    Friend WithEvents navNext As SqlRanger.NavButton
    Friend WithEvents NavPrevious As SqlRanger.NavButton
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents NavEliminar As SqlRanger.NavButton
    Friend WithEvents NavFirst As SqlRanger.NavButton
    Friend WithEvents NavUndo As SqlRanger.NavButton
    Friend WithEvents NavFilter As SqlRanger.NavButton
    Friend WithEvents NavCancelFilter As SqlRanger.NavButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NavBar))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NavCancelFilter = New SqlRanger.NavButton
        Me.NavFilter = New SqlRanger.NavButton
        Me.NavUndo = New SqlRanger.NavButton
        Me.NavEliminar = New SqlRanger.NavButton
        Me.lblCurrent = New System.Windows.Forms.Label
        Me.NavNew = New SqlRanger.NavButton
        Me.NavLast = New SqlRanger.NavButton
        Me.navNext = New SqlRanger.NavButton
        Me.NavPrevious = New SqlRanger.NavButton
        Me.NavFirst = New SqlRanger.NavButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.NavCancelFilter)
        Me.Panel1.Controls.Add(Me.NavFilter)
        Me.Panel1.Controls.Add(Me.NavUndo)
        Me.Panel1.Controls.Add(Me.NavEliminar)
        Me.Panel1.Controls.Add(Me.lblCurrent)
        Me.Panel1.Controls.Add(Me.NavNew)
        Me.Panel1.Controls.Add(Me.NavLast)
        Me.Panel1.Controls.Add(Me.navNext)
        Me.Panel1.Controls.Add(Me.NavPrevious)
        Me.Panel1.Controls.Add(Me.NavFirst)
        Me.Panel1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 24)
        Me.Panel1.TabIndex = 6
        '
        'NavCancelFilter
        '
        Me.NavCancelFilter.DisabledImage = CType(resources.GetObject("NavCancelFilter.DisabledImage"), System.Drawing.Bitmap)
        Me.NavCancelFilter.HilightedImage = Nothing
        Me.NavCancelFilter.Location = New System.Drawing.Point(300, -1)
        Me.NavCancelFilter.Name = "NavCancelFilter"
        Me.NavCancelFilter.NormalImage = CType(resources.GetObject("NavCancelFilter.NormalImage"), System.Drawing.Bitmap)
        Me.NavCancelFilter.PushedImage = Nothing
        Me.NavCancelFilter.Repeater = False
        Me.NavCancelFilter.Size = New System.Drawing.Size(24, 24)
        Me.NavCancelFilter.TabIndex = 15
        Me.NavCancelFilter.Text = "NavButton1"
        Me.NavCancelFilter.TooltipText = "Erase Filter"
        '
        'NavFilter
        '
        Me.NavFilter.DisabledImage = CType(resources.GetObject("NavFilter.DisabledImage"), System.Drawing.Bitmap)
        Me.NavFilter.HilightedImage = Nothing
        Me.NavFilter.Location = New System.Drawing.Point(276, -1)
        Me.NavFilter.Name = "NavFilter"
        Me.NavFilter.NormalImage = CType(resources.GetObject("NavFilter.NormalImage"), System.Drawing.Bitmap)
        Me.NavFilter.PushedImage = Nothing
        Me.NavFilter.Repeater = False
        Me.NavFilter.Size = New System.Drawing.Size(24, 24)
        Me.NavFilter.TabIndex = 14
        Me.NavFilter.Text = "NavButton1"
        Me.NavFilter.TooltipText = "Search or Filter"
        '
        'NavUndo
        '
        Me.NavUndo.DisabledImage = CType(resources.GetObject("NavUndo.DisabledImage"), System.Drawing.Bitmap)
        Me.NavUndo.HilightedImage = Nothing
        Me.NavUndo.Location = New System.Drawing.Point(252, -1)
        Me.NavUndo.Name = "NavUndo"
        Me.NavUndo.NormalImage = CType(resources.GetObject("NavUndo.NormalImage"), System.Drawing.Bitmap)
        Me.NavUndo.PushedImage = Nothing
        Me.NavUndo.Repeater = False
        Me.NavUndo.Size = New System.Drawing.Size(24, 24)
        Me.NavUndo.TabIndex = 13
        Me.NavUndo.TooltipText = "Undo"
        '
        'NavEliminar
        '
        Me.NavEliminar.DisabledImage = CType(resources.GetObject("NavEliminar.DisabledImage"), System.Drawing.Bitmap)
        Me.NavEliminar.HilightedImage = Nothing
        Me.NavEliminar.Location = New System.Drawing.Point(228, -1)
        Me.NavEliminar.Name = "NavEliminar"
        Me.NavEliminar.NormalImage = CType(resources.GetObject("NavEliminar.NormalImage"), System.Drawing.Bitmap)
        Me.NavEliminar.PushedImage = Nothing
        Me.NavEliminar.Repeater = False
        Me.NavEliminar.Size = New System.Drawing.Size(24, 24)
        Me.NavEliminar.TabIndex = 12
        Me.NavEliminar.TooltipText = "Delete"
        '
        'lblCurrent
        '
        Me.lblCurrent.BackColor = System.Drawing.SystemColors.Window
        Me.lblCurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrent.Location = New System.Drawing.Point(48, 1)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(100, 20)
        Me.lblCurrent.TabIndex = 11
        Me.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblCurrent, "Double Click to Go to record...")
        '
        'NavNew
        '
        Me.NavNew.DisabledImage = CType(resources.GetObject("NavNew.DisabledImage"), System.Drawing.Bitmap)
        Me.NavNew.HilightedImage = Nothing
        Me.NavNew.Location = New System.Drawing.Point(196, -1)
        Me.NavNew.Name = "NavNew"
        Me.NavNew.NormalImage = CType(resources.GetObject("NavNew.NormalImage"), System.Drawing.Bitmap)
        Me.NavNew.PushedImage = Nothing
        Me.NavNew.Repeater = False
        Me.NavNew.Size = New System.Drawing.Size(32, 24)
        Me.NavNew.TabIndex = 10
        Me.NavNew.Text = "NavButton5"
        Me.NavNew.TooltipText = "New"
        '
        'NavLast
        '
        Me.NavLast.DisabledImage = CType(resources.GetObject("NavLast.DisabledImage"), System.Drawing.Bitmap)
        Me.NavLast.HilightedImage = Nothing
        Me.NavLast.Location = New System.Drawing.Point(172, -1)
        Me.NavLast.Name = "NavLast"
        Me.NavLast.NormalImage = CType(resources.GetObject("NavLast.NormalImage"), System.Drawing.Bitmap)
        Me.NavLast.PushedImage = Nothing
        Me.NavLast.Repeater = False
        Me.NavLast.Size = New System.Drawing.Size(24, 24)
        Me.NavLast.TabIndex = 9
        Me.NavLast.Text = "NavButton4"
        Me.NavLast.TooltipText = "Last"
        '
        'navNext
        '
        Me.navNext.DisabledImage = CType(resources.GetObject("navNext.DisabledImage"), System.Drawing.Bitmap)
        Me.navNext.HilightedImage = Nothing
        Me.navNext.Location = New System.Drawing.Point(148, -1)
        Me.navNext.Name = "navNext"
        Me.navNext.NormalImage = CType(resources.GetObject("navNext.NormalImage"), System.Drawing.Bitmap)
        Me.navNext.PushedImage = Nothing
        Me.navNext.Repeater = False
        Me.navNext.Size = New System.Drawing.Size(24, 24)
        Me.navNext.TabIndex = 8
        Me.navNext.Text = "NavButton3"
        Me.navNext.TooltipText = "Next"
        '
        'NavPrevious
        '
        Me.NavPrevious.DisabledImage = CType(resources.GetObject("NavPrevious.DisabledImage"), System.Drawing.Bitmap)
        Me.NavPrevious.HilightedImage = Nothing
        Me.NavPrevious.Location = New System.Drawing.Point(23, -1)
        Me.NavPrevious.Name = "NavPrevious"
        Me.NavPrevious.NormalImage = CType(resources.GetObject("NavPrevious.NormalImage"), System.Drawing.Bitmap)
        Me.NavPrevious.PushedImage = Nothing
        Me.NavPrevious.Repeater = False
        Me.NavPrevious.Size = New System.Drawing.Size(24, 24)
        Me.NavPrevious.TabIndex = 7
        Me.NavPrevious.TooltipText = "Back"
        '
        'NavFirst
        '
        Me.NavFirst.DisabledImage = CType(resources.GetObject("NavFirst.DisabledImage"), System.Drawing.Bitmap)
        Me.NavFirst.HilightedImage = Nothing
        Me.NavFirst.Location = New System.Drawing.Point(-1, -1)
        Me.NavFirst.Name = "NavFirst"
        Me.NavFirst.NormalImage = CType(resources.GetObject("NavFirst.NormalImage"), System.Drawing.Bitmap)
        Me.NavFirst.PushedImage = Nothing
        Me.NavFirst.Repeater = False
        Me.NavFirst.Size = New System.Drawing.Size(24, 24)
        Me.NavFirst.TabIndex = 6
        Me.NavFirst.Text = "NavButton1"
        Me.NavFirst.TooltipText = "First"
        '
        'NavBar
        '
        Me.Controls.Add(Me.Panel1)
        Me.Name = "NavBar"
        Me.Size = New System.Drawing.Size(326, 26)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InternalEnable()
        If Me.InternalEnabled Then Return
        Me.InternalEnabled = True
        Dim i As Integer
        Dim b As Binding
        For Each b In BindingManager.Bindings
            If Not b.Control Is Me Then
                b.Control.Enabled = ControlsEnabled(b.Control)
            End If
        Next
    End Sub

    Private ControlsEnabled As System.Collections.Hashtable

    Private Sub InternalDisable()
        If Not Me.InternalEnabled Then Return
        Me.InternalEnabled = False
        Dim i As Integer
        Dim b As Binding
        For Each b In BindingManager.Bindings
            If Not b.Control Is Me Then
                b.Control.Enabled = False
            End If
        Next
    End Sub

    Private Sub BindingManager_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BindingManager.CurrentChanged
        If Me.DataView Is Nothing OrElse Me.BindingManager Is Nothing Then Return
        If Me.DesignMode Then Return
        Dim Count As Integer = Me.BindingManager.Count
        If Me.BindingManager.Position = -1 Or Count = 0 Then
            Me.InternalDisable()
        Else
            Me.InternalEnable()
        End If
        Try
            Me.mCurrentRowView = DirectCast(Me.BindingManager.Current, DataRowView)
        Catch ex As IndexOutOfRangeException
            Me.mCurrentRowView = Nothing
        End Try

        Dim Pos As Integer = IIf(Count = 0, 0, Me.BindingManager.Position + 1)

        Me.lblCurrent.Text = Pos & " of " & Count
        If Me.DataView.RowFilter <> "" Then
            Me.lblCurrent.Text &= " (filter)"
        End If
        If Pos <= 1 Then
            Me.NavFirst.Enabled = False
            Me.NavPrevious.Enabled = False
        Else
            If Not Me.NavFirst.Enabled Then Me.NavFirst.Enabled = True
            If Not Me.NavPrevious.Enabled Then Me.NavPrevious.Enabled = True
        End If

        If Pos = Count Then
            If Me.navNext.Enabled Then Me.navNext.Enabled = False
            If Me.NavLast.Enabled Then Me.NavLast.Enabled = False
        Else
            If Not Me.navNext.Enabled Then Me.navNext.Enabled = True
            If Not Me.NavLast.Enabled Then Me.NavLast.Enabled = True
        End If

        If Me.AllowAddNew Then
            If Not Me.CurrentRowView Is Nothing AndAlso CurrentRowView.IsNew AndAlso Not Me.IsRowChanged() Then
                If Me.NavNew.Enabled Then Me.NavNew.Enabled = False
            ElseIf Not Me.NavNew.Enabled Then
                Me.NavNew.Enabled = True
            End If
        Else
            If Me.NavNew.Enabled Then Me.NavNew.Enabled = False
        End If

        If Me.DataView.RowFilter = "" Then
            If Me.NavCancelFilter.Enabled Then Me.NavCancelFilter.Enabled = False
        Else
            If Not Me.NavCancelFilter.Enabled Then Me.NavCancelFilter.Enabled = True
        End If
    End Sub

    Private Function AreEqual(ByVal a As Object, ByVal b As Object) As Boolean
        If a Is Nothing And b Is Nothing Then Return True
        If TypeOf a Is DBNull And TypeOf b Is DBNull Then Return True
        If TypeOf a Is DBNull And b Is Nothing Then Return True
        If a Is Nothing And TypeOf b Is DBNull Then Return True
        If TypeOf a Is DBNull And TypeOf b Is String AndAlso b = "" Then Return True
        If TypeOf b Is DBNull And TypeOf a Is String AndAlso a = "" Then Return True
        If Not a.GetType().Equals(b.GetType()) Then Return False
        If TypeOf a Is IComparable Then
            Return DirectCast(a, IComparable).CompareTo(b) = 0
        ElseIf TypeOf a Is Array Then
            Dim Aa As Array = DirectCast(a, Array)
            Dim Ab As Array = DirectCast(b, Array)
            If Aa.Length <> Ab.Length Then Return False
            Dim i As Integer
            For i = 0 To Aa.Length - 1
                If DirectCast(Aa.GetValue(i), IComparable).CompareTo(Ab.GetValue(i)) <> 0 _
                    Then Return False
            Next
            Return True
        Else
            Throw New NotSupportedException("Data types don't supported: it isn't compare")
        End If
    End Function

    Private Function IsRowChanged() As Boolean
        If Not CurrentRowView.Row.HasVersion(DataRowVersion.Proposed) Then Return False
        Dim CurrentRow As DataRow = CurrentRowView.Row
        Dim i As Integer, Column As DataColumn
        If CurrentRowView.IsNew Then
            For i = 0 To CurrentRow.Table.Columns.Count - 1
                Column = CurrentRow.Table.Columns(i)
                If Not Column.ReadOnly AndAlso Not Column.AutoIncrement AndAlso _
                    Not Me.AreEqual(Column.DefaultValue, _
                            CurrentRow(i, DataRowVersion.Proposed)) Then
                    Return True
                End If
            Next
            Return False
        Else
            For i = 0 To CurrentRow.Table.Columns.Count - 1
                If Not Me.AreEqual(CurrentRow(i, DataRowVersion.Current), CurrentRow(i, DataRowVersion.Proposed)) Then
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    ' Sends the changes to the DataSet, EndEdit receives the call
    ' but if it is a new record that it hasn't been changed, the edition will be cancelled
    ' if there is an error, an event will be fired returned a False value
    Public Function PostChanges() As Boolean
        Me.mErrorsOcurred = False
        If CurrentRowView Is Nothing Then
            Return False
        End If
        If Not CurrentRowView.IsEdit Then Return True
        Dim c As Control = ParentForm.ActiveControl
        Try
            ParentForm.ActiveControl = Me
            If Not ParentForm.ActiveControl Is Me Then
                MessageBox.Show("The focus has been losted")
                'TODO: you can do something if the focus is losted
            End If

            If CurrentRowView.IsNew AndAlso Not Me.IsRowChanged Then
                CurrentRowView.CancelEdit()
                If Not c Is Nothing Then
                    ParentForm.ActiveControl = c
                End If
                Return False
            Else
                If Not c Is Nothing AndAlso Not TypeOf (c) Is DataGrid Then
                    ParentForm.ActiveControl = c
                    Application.DoEvents()
                End If
                CurrentRowView.EndEdit()
            End If

        Catch e As Exception
            If Not c Is Nothing Then
                ParentForm.ActiveControl = c
                Application.DoEvents()
                Me.BindingManager.Refresh()
            End If
            Me.mErrorsOcurred = True
            RaiseEvent ErrorsOcurred(Me, New NavBarErrorEventArgs(CurrentRowView, e))
            Return False
        End Try
        Return True
    End Function

    Private Sub NavPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavPrevious.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Previous)
        RaiseEvent BeforeNav(Me, ebn)
        If Not ebn.Cancel Then
            If Me.PostChanges Then
                Me.BindingManager.Position -= 1
            End If
            If Not Me.mErrorsOcurred Then
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Previous)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub navFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavFirst.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.First)
        RaiseEvent BeforeNav(Me, ebn)
        If Not ebn.Cancel Then
            Me.PostChanges()
            If Not Me.mErrorsOcurred Then
                Me.BindingManager.Position = 0
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.First)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub NavLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavLast.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Last)
        RaiseEvent BeforeNav(Me, ebn)
        If Not ebn.Cancel Then
            If Me.PostChanges Then
                Me.BindingManager.Position = Me.BindingManager.Count
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Last)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub NavNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavNew.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.[New])
        RaiseEvent BeforeNav(Me, ebn)
        If Not ebn.Cancel Then
            If Me.PostChanges Or Me.BindingManager.Count = 0 Then
                Me.BindingManager.AddNew()
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.[New])
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub navNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles navNext.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Next)
        RaiseEvent BeforeNav(Me, ebn)
        If Not ebn.Cancel Then
            If Me.PostChanges() Then
                Me.BindingManager.Position += 1
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Next)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub mDataView_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles mDataView.ListChanged
        Select Case e.ListChangedType
            Case ListChangedType.ItemDeleted, ListChangedType.ItemAdded, ListChangedType.ItemChanged, ListChangedType.ItemMoved, ListChangedType.Reset
                Me.BindingManager_CurrentChanged(Me, e.Empty)
        End Select
    End Sub

    Private Sub mTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles mTable.ColumnChanging
        If TypeOf e.ProposedValue Is String AndAlso e.ProposedValue = "" Then e.ProposedValue = DBNull.Value
    End Sub

    Private Sub mTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles mTable.ColumnChanged
        If Me.CurrentRowView Is Nothing OrElse Not e.Row Is Me.CurrentRowView.Row Then Exit Sub
        If Not Me.NavNew.Enabled Then Me.NavNew.Enabled = True
    End Sub

    Protected Overrides Sub OnBindingContextChanged(ByVal e As System.EventArgs)
        MyBase.OnBindingContextChanged(e)
        Me.DataView = Me.mDataView
    End Sub

    Private Sub Bindings_CollectionChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs) Handles Bindings.CollectionChanged
        Select Case e.Action
            Case CollectionChangeAction.Add
                Me.ControlsEnabled.Add(e.Element.Control, e.Element.Control.Enabled)
            Case CollectionChangeAction.Remove
                Me.ControlsEnabled.Remove(e.Element.Control)
        End Select
    End Sub

    Private Sub mTable_RowDeleting(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles mTable.RowDeleting
        If Me.mIgnoreRowDeleting Then
            Me.mIgnoreRowDeleting = False
            Return
        End If
        Dim ed As New NavBarDeletingRowEventArgs(e.Row)
        If Me.mLastRowDeleted Is e.Row And _
            System.DateTime.Now.Subtract(Me.mLastTimeDeleted).Milliseconds < 200 Then
            ed.Cancel = True
        Else
            RaiseEvent RowDeleting(Me, ed)
        End If
        Me.mLastTimeDeleted = System.DateTime.Now
        Me.mLastRowDeleted = e.Row
        If ed.Cancel Then
            Throw New CancelException
        End If
    End Sub

    Private Sub NavEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavEliminar.Click
        If Me.CurrentRowView Is Nothing Then Return
        Dim DeletingRow As DataRow = Me.CurrentRowView.Row
        If Me.CurrentRowView.IsNew Then
            If Not Me.IsRowChanged Then
                Me.CurrentRowView.CancelEdit()
            Else
                Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Delete)
                RaiseEvent BeforeNav(Me, ebn)
                If Not ebn.Cancel Then
                    Dim ed As New NavBarDeletingRowEventArgs(DeletingRow)
                    RaiseEvent RowDeleting(Me, ed)
                    If Not ed.Cancel Then
                        Me.CurrentRowView.CancelEdit()
                        Dim ean As New NavBarAfterNavEventArgs(Nothing, NavBarButtonEnum.Delete)
                        RaiseEvent AfterNav(Me, ean)
                    End If
                End If
            End If
        Else
            Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Delete)
            RaiseEvent BeforeNav(Me, ebn)
            If Not ebn.Cancel Then
                Dim ed As New NavBarDeletingRowEventArgs(DeletingRow)
                RaiseEvent RowDeleting(Me, ed)
                If Not ed.Cancel Then
                    Me.mIgnoreRowDeleting = True
                    Try
                        Me.CurrentRowView.Delete()
                        Dim ean As New NavBarAfterNavEventArgs(Nothing, NavBarButtonEnum.Delete)
                        RaiseEvent AfterNav(Me, ean)
                    Catch ex As Exception
                        Me.mIgnoreRowDeleting = False
                        RaiseEvent ErrorsOcurred(Me, New NavBarErrorEventArgs(Me.CurrentRowView, ex))
                    End Try
                    Me.mIgnoreRowDeleting = False
                End If
            End If
        End If
    End Sub

    Private Sub NavUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavUndo.Click
        If Me.CurrentRowView Is Nothing Then Return
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Undo)
        RaiseEvent BeforeNav(Me, ebn)
        If ebn.Cancel Then Return
        Dim Row As DataRow = Me.CurrentRowView.Row
        If Me.CurrentRowView.IsNew Then
            Me.CurrentRowView.CancelEdit()
            Dim ean1 As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Undo)
            RaiseEvent AfterNav(Me, ean1)
            Return
        End If
        If Me.CurrentRowView.IsEdit Then
            Me.CurrentRowView.CancelEdit()
        End If
        If Row.RowState = DataRowState.Modified Then
            Row.RejectChanges()
        End If
        Me.BindingManager.Refresh()
        Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Undo)
        RaiseEvent AfterNav(Me, ean)
    End Sub

    Private Sub NavFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavFilter.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Filter)
        RaiseEvent BeforeNav(Me, ebn)
        If ebn.Cancel Then Return
        Me.PostChanges()
        If Not Me.mErrorsOcurred Then
            If fb.ShowDialog(Me.mTable, ConditionFormatEnum.ADO) = DialogResult.OK Then
                Dim dv As New DataView(Me.DataView.Table, fb.Filter, "", DataViewRowState.CurrentRows)
                If dv.Count = 0 Then
                    MessageBox.Show("It hasn't been found any record for the condition selected, is impossible to apply the filter", MsgBoxStyle.Information)
                    Return
                End If
                Me.DataView.RowFilter = fb.Filter
                Me.BindingManager_CurrentChanged(Me, EventArgs.Empty)
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.Filter)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub lblCurrent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCurrent.DoubleClick
        If Me.DataView Is Nothing OrElse Me.BindingManager.Count = 0 Then Return
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.GoRecord)
        If ebn.Cancel Then Return
        Me.PostChanges()
        If Not Me.mErrorsOcurred Then
            Dim gr As New GetRecordNumber
            If gr.ShowDialog(Me.BindingManager.Count) = DialogResult.OK Then
                Me.BindingManager.Position = gr.RecordNumber - 1
                Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.GoRecord)
                RaiseEvent AfterNav(Me, ean)
            End If
        End If
    End Sub

    Private Sub NavCancelFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavCancelFilter.Click
        Dim ebn As New NavBarBeforeNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.CancelFilter)
        RaiseEvent BeforeNav(Me, ebn)
        If ebn.Cancel Then Return
        Me.PostChanges()
        If Not Me.mErrorsOcurred Then
            Me.DataView.RowFilter = ""
            Dim ean As New NavBarAfterNavEventArgs(Me.CurrentRowView, NavBarButtonEnum.CancelFilter)
            RaiseEvent AfterNav(Me, ean)
        End If
    End Sub
End Class