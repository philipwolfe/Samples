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

Friend Class frmGoToRecord
    Inherits System.Windows.Forms.Form

    Private mRecordNumber As GetRecordNumber.RecordNumberClass
    Private mMaxRecord As Integer

    Public Sub New(ByVal RecordNumber As GetRecordNumber.RecordNumberClass, ByVal MaxRecord As Integer)
        Me.New()
        mRecordNumber = RecordNumber
        mMaxRecord = MaxRecord
    End Sub

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecordNumber As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRecordNumber = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(8, 60)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Accept"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(92, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Go to record..."
        '
        'txtRecordNumber
        '
        Me.txtRecordNumber.Location = New System.Drawing.Point(96, 20)
        Me.txtRecordNumber.Name = "txtRecordNumber"
        Me.txtRecordNumber.Size = New System.Drawing.Size(72, 20)
        Me.txtRecordNumber.TabIndex = 1
        Me.txtRecordNumber.Text = ""
        '
        'frmGoToRecord
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(176, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtRecordNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Name = "frmGoToRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Go to record number..."
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Me.mRecordNumber.Number = Integer.Parse(Me.txtRecordNumber.Text)
            If mRecordNumber.Number < 1 Or mRecordNumber.Number > mMaxRecord Then
                MessageBox.Show("You should write an integer number between 1 and " & mMaxRecord.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("You should write an integer number between 1 and " & mMaxRecord.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class

Public Class GetRecordNumber
    Friend Class RecordNumberClass
        Public Number As Integer
    End Class
    Private mRecordNumber As New RecordNumberClass()

    Public ReadOnly Property RecordNumber() As Integer
        Get
            Return mRecordNumber.Number
        End Get
    End Property

    Public Function ShowDialog(ByVal MaxRecord As Integer) As DialogResult
        Dim frm As New frmGoToRecord(Me.mRecordNumber, MaxRecord)
        Return frm.ShowDialog()
    End Function
End Class