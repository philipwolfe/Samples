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

Friend Class frmFilterBuilder
    Inherits System.Windows.Forms.Form

    Private ConditionControls As ConditionControl()
    Private Table As DataTable
    Private ConditionControlCount As Integer
    Private Filter As Filter
    Private mInitialCondition As Hashtable

    Private mConditionFormat As ConditionFormatEnum
    Public Property ConditionFormat() As ConditionFormatEnum
        Get
            Return Me.mConditionFormat
        End Get
        Set(ByVal Value As ConditionFormatEnum)
            Me.mConditionFormat = Value
        End Set
    End Property

    Private Function IsSuitable(ByVal i As Integer) As Boolean
        Dim ColumnType As Type = Me.Table.Columns(i).DataType
        Return (ColumnType.IsValueType And _
            Not ColumnType.Equals(Type.GetType("System.Guid"))) Or _
            ColumnType.Equals(Type.GetType("System.String"))
    End Function

    Public Sub New(ByVal Table As DataTable, ByVal Filter As Filter, ByVal InitialCondition As Hashtable, Optional ByVal ConditionFormat As ConditionFormatEnum = ConditionFormatEnum.ADO)
        Me.New()
        Me.Filter = Filter
        Me.ConditionFormat = ConditionFormat
        Dim FieldsCount As Integer = Table.Columns.Count
        Me.Table = Table
        Me.mInitialCondition = InitialCondition
        ReDim Me.ConditionControls(FieldsCount)
        Dim i, YPos, ControlIndex, Tab As Integer
        Dim ConditionControl As ConditionControl
        Me.SuspendLayout()
        For i = 0 To FieldsCount - 1
            Dim Column As DataColumn = Table.Columns(i)
            If IsSuitable(i) Then
                ConditionControl = New ConditionControl(Column, InitialCondition)
                ConditionControl.Tag = ControlIndex
                ConditionControls(ControlIndex) = ConditionControl
                ControlIndex += 1
                YPos = 24 * ControlIndex

                With ConditionControl
                    .ConditionFormat = Me.ConditionFormat
                    .Location = New System.Drawing.Point(10, YPos)
                    .Size = New System.Drawing.Size(546, 22)
                    .Name = "cc" & Column.ColumnName
                    .TabIndex = Tab
                    Tab += 1
                End With
            End If
            Me.pnControls.Controls.AddRange(Me.ConditionControls)
        Next
        Me.ConditionControlCount = ControlIndex
        Me.ResumeLayout(False)
    End Sub

    Private Sub SetFilter()
        Dim i As Integer, CondIndex As Integer
        Me.Filter.Condition = ""
        For i = 0 To Me.ConditionControlCount - 1
            Dim Condition As String = Me.ConditionControls(i).Condition
            If Condition <> "" Then
                If CondIndex > 0 Then
                    Me.Filter.Condition &= " AND "
                End If
                Me.Filter.Condition &= Condition
                CondIndex += 1
            End If
        Next
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

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnControls As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFilterBuilder))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.pnControls = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 161)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 36)
        Me.Panel1.TabIndex = 3
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(369, 9)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Delete All"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(264, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(157, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Accept"
        '
        'pnControls
        '
        Me.pnControls.AutoScroll = True
        Me.pnControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnControls.Location = New System.Drawing.Point(0, 0)
        Me.pnControls.Name = "pnControls"
        Me.pnControls.Size = New System.Drawing.Size(584, 161)
        Me.pnControls.TabIndex = 4
        '
        'frmFilterBuilder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(584, 197)
        Me.Controls.Add(Me.pnControls)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFilterBuilder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Condition of Searching or Filtre"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.SetFilter()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim i As Integer
        Me.mInitialCondition.Clear()
        For i = 0 To Me.ConditionControlCount - 1
            Me.ConditionControls(i).InitialCondition = Me.mInitialCondition
        Next
    End Sub
End Class