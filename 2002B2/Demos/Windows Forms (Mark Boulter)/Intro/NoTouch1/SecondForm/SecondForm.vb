Public Class SecondForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Private WithEvents Button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.DataGrid1 = New System.Windows.Forms.DataGrid
Me.Button1 = New System.Windows.Forms.Button
CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).BeginInit
Me.DataGrid1.SuspendLayout
Me.SuspendLayout
'
'DataGrid1
'
Me.DataGrid1.DataMember = ""
Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
Me.DataGrid1.Name = "DataGrid1"
Me.DataGrid1.Size = New System.Drawing.Size(408, 224)
Me.DataGrid1.TabIndex = 0
'
'Button1
'
Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me.Button1.Location = New System.Drawing.Point(328, 264)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(80, 40)
Me.Button1.TabIndex = 1
Me.Button1.Text = "Save"
'
'SecondForm
'
Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
Me.BackColor = System.Drawing.Color.RosyBrown
Me.ClientSize = New System.Drawing.Size(424, 325)
Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.DataGrid1})
Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Name = "SecondForm"
Me.Text = "Second Form"
CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).EndInit
Me.DataGrid1.ResumeLayout(false)
Me.ResumeLayout(false)

    End Sub

#End Region

End Class
