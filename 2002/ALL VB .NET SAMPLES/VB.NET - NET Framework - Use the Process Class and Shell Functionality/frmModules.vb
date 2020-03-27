Public Class frmModules
    Inherits System.Windows.Forms.Form
    Private _processID As Integer

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
    Friend WithEvents rchText As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rchText = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rchText
        '
        Me.rchText.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.rchText.Location = New System.Drawing.Point(16, 16)
        Me.rchText.Name = "rchText"
        Me.rchText.Size = New System.Drawing.Size(264, 232)
        Me.rchText.TabIndex = 0
        Me.rchText.Text = ""
        '
        'frmModules
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rchText})
        Me.Name = "frmModules"
        Me.Text = "Loaded Modules:"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property ProcessID() As Integer
        Get
            Return (_processID)
        End Get
        Set(ByVal Value As Integer)
            _processID = Value
        End Set
    End Property

    Private Sub frmModules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Takes the string of modules built up by the btnModules_Click event procedure in 
        ' frmTaskManager and displays into the user in the RichTextBox
        Dim ProcessInfo As Process = _
            Process.GetProcessById(ProcessID)
        Dim modl As ProcessModuleCollection = ProcessInfo.Modules
        Dim strMod As New System.Text.StringBuilder()
        Dim proMod As ProcessModule
        For Each proMod In modl
            strMod.Append("Module Name: " + proMod.ModuleName + vbCrLf)
        Next proMod
        rchText.Text = strMod.ToString
    End Sub
End Class
