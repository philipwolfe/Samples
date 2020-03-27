<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MainPictureBox = New System.Windows.Forms.PictureBox
        Me.Thumb1PictureBox = New System.Windows.Forms.PictureBox
        Me.Thumb2PictureBox = New System.Windows.Forms.PictureBox
        Me.Thumb3PictureBox = New System.Windows.Forms.PictureBox
        Me.Thumb4PictureBox = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.MainPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 160)
        '
        'MainPictureBox
        '
        Me.MainPictureBox.BackColor = System.Drawing.Color.Black
        Me.MainPictureBox.Location = New System.Drawing.Point(5, 3)
        Me.MainPictureBox.Name = "MainPictureBox"
        Me.MainPictureBox.Size = New System.Drawing.Size(210, 150)
        Me.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Thumb1PictureBox
        '
        Me.Thumb1PictureBox.Location = New System.Drawing.Point(10, 176)
        Me.Thumb1PictureBox.Name = "Thumb1PictureBox"
        Me.Thumb1PictureBox.Size = New System.Drawing.Size(50, 50)
        '
        'Thumb2PictureBox
        '
        Me.Thumb2PictureBox.Location = New System.Drawing.Point(66, 176)
        Me.Thumb2PictureBox.Name = "Thumb2PictureBox"
        Me.Thumb2PictureBox.Size = New System.Drawing.Size(50, 50)
        '
        'Thumb3PictureBox
        '
        Me.Thumb3PictureBox.Location = New System.Drawing.Point(125, 176)
        Me.Thumb3PictureBox.Name = "Thumb3PictureBox"
        Me.Thumb3PictureBox.Size = New System.Drawing.Size(50, 50)
        '
        'Thumb4PictureBox
        '
        Me.Thumb4PictureBox.Location = New System.Drawing.Point(181, 176)
        Me.Thumb4PictureBox.Name = "Thumb4PictureBox"
        Me.Thumb4PictureBox.Size = New System.Drawing.Size(50, 50)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 20)
        Me.Label1.Text = "Click on thumbnail to see in viewer."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Thumb4PictureBox)
        Me.Controls.Add(Me.Thumb3PictureBox)
        Me.Controls.Add(Me.Thumb2PictureBox)
        Me.Controls.Add(Me.Thumb1PictureBox)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MainPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Thumb1PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Thumb2PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Thumb3PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Thumb4PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
