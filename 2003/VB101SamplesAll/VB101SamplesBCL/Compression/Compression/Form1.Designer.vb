<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.DestinationFile = New System.Windows.Forms.TextBox
        Me.BrowseDestination = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.SourceFile = New System.Windows.Forms.TextBox
        Me.BrowseSource = New System.Windows.Forms.Button
        Me.Decompress = New System.Windows.Forms.Button
        Me.Compress = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.DestinationFile)
        Me.groupBox1.Controls.Add(Me.BrowseDestination)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.SourceFile)
        Me.groupBox1.Controls.Add(Me.BrowseSource)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(435, 100)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Files"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 61)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "Destination File:"
        '
        'DestinationFile
        '
        Me.DestinationFile.Location = New System.Drawing.Point(96, 58)
        Me.DestinationFile.Name = "DestinationFile"
        Me.DestinationFile.Size = New System.Drawing.Size(236, 20)
        Me.DestinationFile.TabIndex = 11
        '
        'BrowseDestination
        '
        Me.BrowseDestination.Location = New System.Drawing.Point(348, 56)
        Me.BrowseDestination.Name = "BrowseDestination"
        Me.BrowseDestination.Size = New System.Drawing.Size(75, 23)
        Me.BrowseDestination.TabIndex = 10
        Me.BrowseDestination.Text = "Browse"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Source File:"
        '
        'SourceFile
        '
        Me.SourceFile.Location = New System.Drawing.Point(96, 23)
        Me.SourceFile.Name = "SourceFile"
        Me.SourceFile.Size = New System.Drawing.Size(236, 20)
        Me.SourceFile.TabIndex = 8
        '
        'BrowseSource
        '
        Me.BrowseSource.Location = New System.Drawing.Point(348, 21)
        Me.BrowseSource.Name = "BrowseSource"
        Me.BrowseSource.Size = New System.Drawing.Size(75, 23)
        Me.BrowseSource.TabIndex = 7
        Me.BrowseSource.Text = "Browse"
        '
        'Decompress
        '
        Me.Decompress.Enabled = False
        Me.Decompress.Location = New System.Drawing.Point(241, 118)
        Me.Decompress.Name = "Decompress"
        Me.Decompress.Size = New System.Drawing.Size(98, 23)
        Me.Decompress.TabIndex = 11
        Me.Decompress.Text = "Decompress"
        '
        'Compress
        '
        Me.Compress.Enabled = False
        Me.Compress.Location = New System.Drawing.Point(121, 118)
        Me.Compress.Name = "Compress"
        Me.Compress.Size = New System.Drawing.Size(98, 23)
        Me.Compress.TabIndex = 10
        Me.Compress.Text = "Compress"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 152)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.Decompress)
        Me.Controls.Add(Me.Compress)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compression Sample"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents DestinationFile As System.Windows.Forms.TextBox
    Friend WithEvents BrowseDestination As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents SourceFile As System.Windows.Forms.TextBox
    Friend WithEvents BrowseSource As System.Windows.Forms.Button
    Friend WithEvents Decompress As System.Windows.Forms.Button
    Friend WithEvents Compress As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
