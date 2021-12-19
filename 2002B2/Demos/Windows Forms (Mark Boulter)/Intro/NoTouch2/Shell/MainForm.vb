Public Class MainForm
    Inherits System.Windows.Forms.Form
    Implements IAppOwningControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        DisplayFormList()

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(168, 421)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(168, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 421)
        Me.Panel2.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Splitter1.Location = New System.Drawing.Point(168, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 421)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(584, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Splitter1, Me.Panel2, Me.Panel1})
        Me.Name = "MainForm"
        Me.Text = "Dynamic Loading Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub DisplayFormList()

        Dim Forms() As localhost.FormInfo = (New localhost.FormsListWebService()).GetFormsList()

        Dim fi As localhost.FormInfo

        If (Forms Is Nothing) Then
            Return
        End If

        If (Forms.Length = 0) Then
            Return
        End If

        For Each fi In Forms
            If Not (fi Is Nothing) Then
                Dim AppPanel1 As AppPanel
                AppPanel1 = New AppPanel(Me, fi)
                AppPanel1.Dock = DockStyle.Top
                Panel1.Controls.Add(AppPanel1)
            End If
        Next

    End Sub

    'Add a Panel to the display panel                          
    Public Sub AddPanel(ByVal c As Control) Implements IAppOwningControl.AddPanel
        Me.Panel2.Controls.Add(c)
        c.Dock = DockStyle.Fill
        c.BringToFront()
    End Sub

    'Show an existing panel        
    Public Sub ShowPanel(ByVal c As Control) Implements IAppOwningControl.ShowPanel
        c.BringToFront()
    End Sub

End Class
