Option Strict On
Public Class frmStatus
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(192, 77)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Label1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(192, 77)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatus})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Sub Show(ByVal Message As String)
        lblStatus.Text = Message
        Me.Show()
        Application.DoEvents()
    End Sub

End Class
