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

Friend Class ConditionControl
    Inherits System.Windows.Forms.UserControl

    Private mColumn As DataColumn
    Private mConditionFormat As ConditionFormatEnum
    Private mInitialCondition As Hashtable

    Public Property ConditionFormat() As ConditionFormatEnum
        Get
            Return Me.mConditionFormat
        End Get
        Set(ByVal Value As ConditionFormatEnum)
            Me.mConditionFormat = Value
        End Set
    End Property

    Public Property Column() As DataColumn
        Get
            Return mColumn
        End Get
        Set(ByVal Value As DataColumn)
            mColumn = Value
            Me.lblFieldName.Text = IIf(Value.Caption = "", Value.ColumnName, Value.Caption)
            Me.LoadOperatorList()
        End Set
    End Property

    Private Sub LoadOperatorList()
        Dim op As Operator
        With cbOperator.Items
            .Clear()
            If Types.IsBoolean(Column.DataType) Then
                .Add(New Operator(OperatorsEnum.IsTrue))
                .Add(New Operator(OperatorsEnum.IsFalse))
            ElseIf Types.IsString(Column.DataType) Then
                .Add(New Operator(OperatorsEnum.Equal))
                .Add(New Operator(OperatorsEnum.Different))
                .Add(New Operator(OperatorsEnum.StartBy))
                .Add(New Operator(OperatorsEnum.Contain))
                .Add(New Operator(OperatorsEnum.Between))
                .Add(New Operator(OperatorsEnum.BiggerThan))
                .Add(New Operator(OperatorsEnum.BiggerEqual))
                .Add(New Operator(OperatorsEnum.LessThan))
                .Add(New Operator(OperatorsEnum.LessEqual))
                If Column.AllowDBNull Then
                    .Add(New Operator(OperatorsEnum.IsNull))
                    .Add(New Operator(OperatorsEnum.NotIsNull))
                End If
            Else ' I suppose a numeric or date value
                .Add(New Operator(OperatorsEnum.Equal))
                .Add(New Operator(OperatorsEnum.Different))
                .Add(New Operator(OperatorsEnum.Between))
                .Add(New Operator(OperatorsEnum.BiggerThan))
                .Add(New Operator(OperatorsEnum.BiggerEqual))
                .Add(New Operator(OperatorsEnum.LessThan))
                .Add(New Operator(OperatorsEnum.LessEqual))
                If Column.AllowDBNull Then
                    .Add(New Operator(OperatorsEnum.IsNull))
                    .Add(New Operator(OperatorsEnum.NotIsNull))
                End If
            End If
        End With
    End Sub

    Public Property InitialCondition() As Hashtable
        Get
            Return Me.mInitialCondition
        End Get
        Set(ByVal Value As Hashtable)
            Me.mInitialCondition = Value
            If Me.HasState Then
                Dim cs As ConditionState = Me.mInitialCondition(Me.Column.ColumnName)
                Me.cbOperator.SelectedItem = cs.Op
                Select Case cs.Op.Cardinality
                    Case OperatorCardinalityEnum.Binary
                        If Not cs.Value Is Nothing Then
                            If Types.IsDate(Me.Column.DataType) Then
                                Me.calendario.Value = cs.Value
                            Else
                                Me.txtValue.Text = cs.Value.ToString()
                            End If
                        End If
                    Case OperatorCardinalityEnum.Ternary
                        If Types.IsDate(Me.Column.DataType) Then
                            If Not cs.Value1 Is Nothing Then Me.calendario.Value = cs.Value1
                            If Not cs.Value2 Is Nothing Then Me.calendario2.Value = cs.Value2
                        Else
                            If Not cs.Value1 Is Nothing Then Me.txtValue1.Text = cs.Value1.ToString()
                            If Not cs.Value2 Is Nothing Then Me.txtValue2.Text = cs.Value2.ToString()
                        End If
                End Select
            Else
                Me.cbOperator.SelectedIndex = -1
            End If
        End Set
    End Property

    Private ReadOnly Property HasState() As Boolean
        Get
            Return Me.InitialCondition.ContainsKey(Me.Column.ColumnName) AndAlso _
                    Not Me.InitialCondition(Me.Column.ColumnName) Is Nothing
        End Get
    End Property

    Private ReadOnly Property State() As ConditionState
        Get
            If Not Me.HasState Then
                Me.InitialCondition(Me.Column.ColumnName) = New ConditionState()
            End If
            Return DirectCast(Me.InitialCondition(Me.Column.ColumnName), ConditionState)
        End Get
    End Property

    Public Sub New(ByVal Column As DataColumn, ByVal InitialCondition As Hashtable)
        Me.New()
        Me.Column = Column
        Me.InitialCondition = InitialCondition
    End Sub

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents cbOperator As System.Windows.Forms.ComboBox
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAnd As System.Windows.Forms.Label
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents calendario As System.Windows.Forms.DateTimePicker
    Friend WithEvents calendario2 As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFieldName = New System.Windows.Forms.Label
        Me.cbOperator = New System.Windows.Forms.ComboBox
        Me.txtValue1 = New System.Windows.Forms.TextBox
        Me.lblAnd = New System.Windows.Forms.Label
        Me.txtValue2 = New System.Windows.Forms.TextBox
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.calendario = New System.Windows.Forms.DateTimePicker
        Me.calendario2 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'lblFieldName
        '
        Me.lblFieldName.Location = New System.Drawing.Point(0, 2)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(150, 16)
        Me.lblFieldName.TabIndex = 0
        '
        'cbOperator
        '
        Me.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOperator.Location = New System.Drawing.Point(154, 0)
        Me.cbOperator.Name = "cbOperator"
        Me.cbOperator.Size = New System.Drawing.Size(115, 21)
        Me.cbOperator.TabIndex = 1
        '
        'txtValue1
        '
        Me.txtValue1.Location = New System.Drawing.Point(276, 0)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(120, 20)
        Me.txtValue1.TabIndex = 2
        Me.txtValue1.Text = ""
        Me.txtValue1.Visible = False
        '
        'lblAnd
        '
        Me.lblAnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnd.Location = New System.Drawing.Point(403, 5)
        Me.lblAnd.Name = "lblAnd"
        Me.lblAnd.Size = New System.Drawing.Size(15, 16)
        Me.lblAnd.TabIndex = 3
        Me.lblAnd.Text = "Y"
        Me.lblAnd.Visible = False
        '
        'txtValue2
        '
        Me.txtValue2.Location = New System.Drawing.Point(422, 0)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(120, 20)
        Me.txtValue2.TabIndex = 4
        Me.txtValue2.Text = ""
        Me.txtValue2.Visible = False
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(276, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(266, 20)
        Me.txtValue.TabIndex = 5
        Me.txtValue.Text = ""
        Me.txtValue.Visible = False
        '
        'calendario
        '
        Me.calendario.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.calendario.Location = New System.Drawing.Point(276, 0)
        Me.calendario.Name = "calendario"
        Me.calendario.ShowCheckBox = True
        Me.calendario.Size = New System.Drawing.Size(120, 20)
        Me.calendario.TabIndex = 6
        Me.calendario.Visible = False
        '
        'calendario2
        '
        Me.calendario2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.calendario2.Location = New System.Drawing.Point(422, 0)
        Me.calendario2.Name = "calendario2"
        Me.calendario2.ShowCheckBox = True
        Me.calendario2.Size = New System.Drawing.Size(120, 20)
        Me.calendario2.TabIndex = 7
        Me.calendario2.Visible = False
        '
        'ConditionControl
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.calendario2, Me.txtValue2, Me.lblAnd, Me.cbOperator, Me.lblFieldName, Me.calendario, Me.txtValue1, Me.txtValue})
        Me.Name = "ConditionControl"
        Me.Size = New System.Drawing.Size(546, 24)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cbOperator_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbOperator.KeyDown
        If (e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back) And Not Me.cbOperator.DroppedDown Then
            Me.cbOperator.SelectedIndex = -1
        End If
    End Sub

    Sub HideAllControls()
        Me.txtValue.Visible = False
        Me.txtValue1.Visible = False
        Me.txtValue2.Visible = False
        Me.lblAnd.Visible = False
        Me.calendario.Visible = False
        Me.calendario2.Visible = False
    End Sub

    Sub ShowTwoControls()
        If Types.IsDate(Column.DataType) Then
            Me.calendario.Visible = True
            Me.calendario2.Visible = True
            Me.txtValue1.Visible = False
            Me.txtValue2.Visible = False
        Else
            Me.calendario.Visible = False
            Me.calendario2.Visible = False
            Me.txtValue1.Visible = True
            Me.txtValue2.Visible = True
        End If

        Me.txtValue.Visible = False
        Me.lblAnd.Visible = True
    End Sub

    Sub ShowOneControl()
        If Types.IsDate(Column.DataType) Then
            Me.calendario.Visible = True
            Me.txtValue.Visible = False
        Else
            Me.txtValue.Visible = True
            Me.calendario.Visible = False
        End If

        Me.txtValue1.Visible = False
        Me.txtValue2.Visible = False
        Me.lblAnd.Visible = False
    End Sub

    Private Sub cbOperator_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOperator.SelectedIndexChanged
        If cbOperator.SelectedIndex = -1 Then
            HideAllControls()
            If Me.HasState Then
                Me.InitialCondition.Remove(Me.Column.ColumnName)
            End If
            Return
        End If
        Dim c As Operator = cbOperator.SelectedItem
        Me.State.Op = c
        Select Case c.Cardinality
            Case OperatorCardinalityEnum.Unary
                HideAllControls()
            Case OperatorCardinalityEnum.Ternary
                Me.ShowTwoControls()
            Case OperatorCardinalityEnum.Binary
                Me.ShowOneControl()
        End Select
    End Sub

    Private Sub txtValues_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtValue.KeyDown, txtValue1.KeyDown, txtValue2.KeyDown, calendario.KeyDown, calendario2.KeyDown
        If e.KeyCode = Keys.Escape Then
            If TypeOf sender Is DateTimePicker Then
                DirectCast(sender, DateTimePicker).Value = Now
                DirectCast(sender, DateTimePicker).Checked = False
            Else
                DirectCast(sender, TextBox).Text = ""
            End If
        End If
    End Sub

    Private Sub txtValues_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles txtValue.Validating, txtValue1.Validating, txtValue2.Validating, calendario.Validating, calendario2.Validating
        Dim Texto As String

        If TypeOf sender Is DateTimePicker Then
            Texto = Me.calendario.Text
        Else
            Texto = DirectCast(sender, TextBox).Text
        End If

        If Texto = "" Then Return
        Try
            Dim Value As Object = Convert.ChangeType(Texto, Me.Column.DataType)
            If Me.State.Op.Cardinality = OperatorCardinalityEnum.Binary Then
                Me.State.Value = Value
            Else
                If sender Is Me.txtValue1 Or sender Is Me.calendario Then
                    Me.State.Value1 = Value
                Else
                    Me.State.Value2 = Value
                End If
            End If
        Catch
            MessageBox.Show("'" & Texto & "' doesn't a correct value for the field '" & _
                    Me.lblFieldName.Text & "'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End Try

    End Sub

    Private Function IsConditionEmpty() As Boolean
        If Me.cbOperator.SelectedIndex = -1 Then Return True
        Dim op As Operator = Me.cbOperator.SelectedItem
        Select Case op.Cardinality
            Case OperatorCardinalityEnum.Unary
                Return False
            Case OperatorCardinalityEnum.Binary
                If Types.IsDate(Column.DataType) Then
                    Return (Not Me.calendario.Checked)
                Else
                    Return (Me.txtValue.Text = "")
                End If
            Case OperatorCardinalityEnum.Ternary
                If Types.IsDate(Column.DataType) Then
                    Return (Not Me.calendario.Checked Or Not Me.calendario2.Checked)
                Else
                    Return (Me.txtValue1.Text = "" Or Me.txtValue2.Text = "")
                End If
        End Select
    End Function


    Private Function FormatValue(ByVal txt As String) As String
        Dim Value As Object = Convert.ChangeType(txt, Me.Column.DataType)
        If Types.IsString(Me.Column.DataType) Then
            Dim V As String = Replace(txt, "'", "''")
            Dim Op As Operator = Me.cbOperator.SelectedItem
            Select Case Op.Op
                Case OperatorsEnum.StartBy
                    Return "'" & V & "%'"
                Case OperatorsEnum.Contain
                    Return "'%" & V & "%'"
                Case Else
                    Return "'" & V & "'"
            End Select
        End If
        If Types.IsDate(Me.Column.DataType) Then
            If Me.ConditionFormat = ConditionFormatEnum.ADO Then
                Return Format(Value, "\#MM\/dd\/yyyy\#")
            Else
                Return Format(Value, "\'yyyyMMdd HH\:mm\:ss\.fff\'")
            End If
        End If
        If Types.IsBoolean(Me.Column.DataType) Then
            If Me.ConditionFormat = ConditionFormatEnum.ADO Then
                Return IIf(Value, "true", "false")
            Else
                Return IIf(Value, "1", "0")
            End If
        End If
        ' I suppose a numeric value
        Return Str(Value)
    End Function

    Public ReadOnly Property Value() As String
        Get
            If Types.IsDate(Column.DataType) Then
                Return Me.FormatValue(Me.calendario.Text)
            Else
                Return Me.FormatValue(Me.txtValue.Text)
            End If
        End Get
    End Property

    Public ReadOnly Property Value1() As String
        Get
            If Types.IsDate(Column.DataType) Then
                Return Me.FormatValue(Me.calendario.Text)
            Else
                Return Me.FormatValue(Me.txtValue1.Text)
            End If
        End Get
    End Property

    Public ReadOnly Property Value2() As String
        Get
            If Types.IsDate(Column.DataType) Then
                Return Me.FormatValue(Me.calendario2.Text)
            Else
                Return Me.FormatValue(Me.txtValue2.Text)
            End If
        End Get
    End Property

    Public ReadOnly Property Condition() As String
        Get
            If Me.IsConditionEmpty Then Return ""
            Dim op As Operator = Me.cbOperator.SelectedItem
            Dim ColumnName = "[" & Me.Column.ColumnName & "]"
            Select Case op.Cardinality
                Case OperatorCardinalityEnum.Unary
                    If Me.ConditionFormat = ConditionFormatEnum.ADO Then
                        Select Case op.Op
                            Case OperatorsEnum.IsFalse
                                Return ColumnName & " = false "
                            Case OperatorsEnum.IsTrue
                                Return ColumnName & " = true "
                            Case Else
                                Return ColumnName & " " & op.AsString
                        End Select
                    Else
                        Return ColumnName & " " & op.AsString
                    End If
                Case OperatorCardinalityEnum.Binary
                    Return ColumnName & " " & op.AsString & " " & Me.Value
                Case OperatorCardinalityEnum.Ternary
                    Return "(" & ColumnName & " >= " & Me.Value1 & " AND " & ColumnName & " <= " & Me.Value2 & ")"
            End Select
        End Get
    End Property

End Class

Public Enum ConditionFormatEnum
    SQL
    ADO
End Enum