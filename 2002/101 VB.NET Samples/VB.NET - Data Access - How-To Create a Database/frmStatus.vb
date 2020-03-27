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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStatus))
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.AccessibleDescription = CType(resources.GetObject("lblStatus.AccessibleDescription"), String)
        Me.lblStatus.AccessibleName = CType(resources.GetObject("lblStatus.AccessibleName"), String)
        Me.lblStatus.Anchor = CType(resources.GetObject("lblStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = CType(resources.GetObject("lblStatus.AutoSize"), Boolean)
        Me.lblStatus.Dock = CType(resources.GetObject("lblStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStatus.Enabled = CType(resources.GetObject("lblStatus.Enabled"), Boolean)
        Me.lblStatus.Font = CType(resources.GetObject("lblStatus.Font"), System.Drawing.Font)
        Me.lblStatus.Image = CType(resources.GetObject("lblStatus.Image"), System.Drawing.Image)
        Me.lblStatus.ImageAlign = CType(resources.GetObject("lblStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStatus.ImageIndex = CType(resources.GetObject("lblStatus.ImageIndex"), Integer)
        Me.lblStatus.ImeMode = CType(resources.GetObject("lblStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStatus.Location = CType(resources.GetObject("lblStatus.Location"), System.Drawing.Point)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = CType(resources.GetObject("lblStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStatus.Size = CType(resources.GetObject("lblStatus.Size"), System.Drawing.Size)
        Me.lblStatus.TabIndex = CType(resources.GetObject("lblStatus.TabIndex"), Integer)
        Me.lblStatus.Text = resources.GetString("lblStatus.Text")
        Me.lblStatus.TextAlign = CType(resources.GetObject("lblStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStatus.Visible = CType(resources.GetObject("lblStatus.Visible"), Boolean)
        '
        'frmStatus
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatus})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmStatus"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ShowInTaskbar = False
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Sub Show(ByVal Message As String)
        lblStatus.Text = Message
        Me.Show()
        Application.DoEvents()
    End Sub
End Class
