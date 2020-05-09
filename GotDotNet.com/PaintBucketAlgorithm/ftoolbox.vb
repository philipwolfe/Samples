Public Class ftoolbox
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
	Friend WithEvents chkpbucket As System.Windows.Forms.CheckBox
	Friend WithEvents lbltolarance As System.Windows.Forms.Label
	Friend WithEvents trktolarance As System.Windows.Forms.TrackBar
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.chkpbucket = New System.Windows.Forms.CheckBox
		Me.trktolarance = New System.Windows.Forms.TrackBar
		Me.lbltolarance = New System.Windows.Forms.Label
		CType(Me.trktolarance, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'chkpbucket
		'
		Me.chkpbucket.Appearance = System.Windows.Forms.Appearance.Button
		Me.chkpbucket.Checked = True
		Me.chkpbucket.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkpbucket.Location = New System.Drawing.Point(8, 8)
		Me.chkpbucket.Name = "chkpbucket"
		Me.chkpbucket.Size = New System.Drawing.Size(92, 32)
		Me.chkpbucket.TabIndex = 0
		Me.chkpbucket.Text = "Paint Bucket"
		Me.chkpbucket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'trktolarance
		'
		Me.trktolarance.Location = New System.Drawing.Point(96, 4)
		Me.trktolarance.Maximum = 100
		Me.trktolarance.Name = "trktolarance"
		Me.trktolarance.Size = New System.Drawing.Size(164, 45)
		Me.trktolarance.SmallChange = 5
		Me.trktolarance.TabIndex = 1
		Me.trktolarance.TickFrequency = 10
		Me.trktolarance.TickStyle = System.Windows.Forms.TickStyle.Both
		Me.trktolarance.Value = 20
		'
		'lbltolarance
		'
		Me.lbltolarance.Location = New System.Drawing.Point(260, 16)
		Me.lbltolarance.Name = "lbltolarance"
		Me.lbltolarance.Size = New System.Drawing.Size(36, 16)
		Me.lbltolarance.TabIndex = 2
		Me.lbltolarance.Text = "20%"
		'
		'ftoolbox
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(302, 48)
		Me.ControlBox = False
		Me.Controls.Add(Me.chkpbucket)
		Me.Controls.Add(Me.lbltolarance)
		Me.Controls.Add(Me.trktolarance)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ftoolbox"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Toolbox"
		CType(Me.trktolarance, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub trktolarance_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trktolarance.Scroll
		lbltolarance.Text = trktolarance.Value & "%"
	End Sub
End Class
