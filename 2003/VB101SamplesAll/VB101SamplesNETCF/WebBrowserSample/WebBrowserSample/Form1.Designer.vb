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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.GoButton = New System.Windows.Forms.Button
        Me.URLTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.LocalContentLinkLabel = New System.Windows.Forms.LinkLabel
        Me.PocketPCLinkLabel = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 93)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(240, 175)
        '
        'GoButton
        '
        Me.GoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoButton.Location = New System.Drawing.Point(216, 3)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(24, 20)
        Me.GoButton.TabIndex = 10
        Me.GoButton.Text = "GO"
        '
        'URLTextBox
        '
        Me.URLTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.URLTextBox.Location = New System.Drawing.Point(40, 3)
        Me.URLTextBox.Name = "URLTextBox"
        Me.URLTextBox.Size = New System.Drawing.Size(170, 21)
        Me.URLTextBox.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 20)
        Me.Label1.Text = "URL:"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 90)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(240, 3)
        '
        'LocalContentLinkLabel
        '
        Me.LocalContentLinkLabel.Location = New System.Drawing.Point(0, 27)
        Me.LocalContentLinkLabel.Name = "LocalContentLinkLabel"
        Me.LocalContentLinkLabel.Size = New System.Drawing.Size(124, 20)
        Me.LocalContentLinkLabel.TabIndex = 13
        Me.LocalContentLinkLabel.Text = "Local Content (Help)"
        '
        'PocketPCLinkLabel
        '
        Me.PocketPCLinkLabel.Location = New System.Drawing.Point(0, 47)
        Me.PocketPCLinkLabel.Name = "PocketPCLinkLabel"
        Me.PocketPCLinkLabel.Size = New System.Drawing.Size(100, 20)
        Me.PocketPCLinkLabel.TabIndex = 17
        Me.PocketPCLinkLabel.Text = "PocketPC.COM"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.PocketPCLinkLabel)
        Me.Controls.Add(Me.LocalContentLinkLabel)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.URLTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Friend WithEvents URLTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents LocalContentLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents PocketPCLinkLabel As System.Windows.Forms.LinkLabel

End Class
