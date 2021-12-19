Imports System.Reflection

Public Class Form1
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
    Friend WithEvents Button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(48, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load Form"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim formAsm As [Assembly] = [Assembly].LoadFrom("http://localhost/FirstForm.dll")
        Dim formtype As Type = formAsm.GetType("FirstForm.FirstForm")

        Dim FormObj As Object
        FormObj = Activator.CreateInstance(formtype)
        Dim Form1 As Form = CType(FormObj, Form)
        Form1.Show()

    End Sub
End Class
