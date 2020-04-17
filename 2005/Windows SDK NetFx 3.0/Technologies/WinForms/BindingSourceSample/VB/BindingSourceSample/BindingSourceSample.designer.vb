Partial Public Class BindingSourceSample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.flagsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.info = New System.Windows.Forms.TextBox
        Me.flagsCombo = New System.Windows.Forms.ComboBox
        Me.flagName = New System.Windows.Forms.Label
        Me.flagPicture = New System.Windows.Forms.PictureBox
        Me.addButton = New System.Windows.Forms.Button
        Me.positionIndicator = New System.Windows.Forms.TextBox
        Me.movePrevious = New System.Windows.Forms.Button
        Me.moveNext = New System.Windows.Forms.Button
        CType(Me.flagsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flagsBindingSource
        '
        Me.flagsBindingSource.DataSource = GetType(Microsoft.Samples.Windows.Forms.BindingSourceSample.Flag)
        '
        'info
        '
        Me.info.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.info.Location = New System.Drawing.Point(174, 13)
        Me.info.Multiline = True
        Me.info.Name = "info"
        Me.info.ReadOnly = True
        Me.info.Size = New System.Drawing.Size(254, 184)
        Me.info.TabIndex = 32
        Me.info.TabStop = False
        '
        'flagsCombo
        '
        Me.flagsCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flagsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flagsCombo.FormattingEnabled = True
        Me.flagsCombo.Location = New System.Drawing.Point(5, 176)
        Me.flagsCombo.Name = "flagsCombo"
        Me.flagsCombo.Size = New System.Drawing.Size(113, 21)
        Me.flagsCombo.Sorted = True
        Me.flagsCombo.TabIndex = 1
        '
        'flagName
        '
        Me.flagName.AutoSize = True
        Me.flagName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.flagsBindingSource, "Name", True))
        Me.flagName.Location = New System.Drawing.Point(5, 52)
        Me.flagName.Name = "flagName"
        Me.flagName.Size = New System.Drawing.Size(97, 13)
        Me.flagName.TabIndex = 30
        Me.flagName.Text = "No Flags to Display"
        '
        'flagPicture
        '
        Me.flagPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flagPicture.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.flagsBindingSource, "Image", True))
        Me.flagPicture.Location = New System.Drawing.Point(5, 73)
        Me.flagPicture.Name = "flagPicture"
        Me.flagPicture.Size = New System.Drawing.Size(163, 96)
        Me.flagPicture.TabIndex = 29
        Me.flagPicture.TabStop = False
        '
        'addButton
        '
        Me.addButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.addButton.Location = New System.Drawing.Point(123, 175)
        Me.addButton.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(45, 23)
        Me.addButton.TabIndex = 0
        Me.addButton.Text = "Add"
        '
        'positionIndicator
        '
        Me.positionIndicator.Location = New System.Drawing.Point(32, 15)
        Me.positionIndicator.Name = "positionIndicator"
        Me.positionIndicator.ReadOnly = True
        Me.positionIndicator.Size = New System.Drawing.Size(44, 21)
        Me.positionIndicator.TabIndex = 27
        Me.positionIndicator.TabStop = False
        '
        'movePrevious
        '
        Me.movePrevious.Location = New System.Drawing.Point(5, 13)
        Me.movePrevious.Name = "movePrevious"
        Me.movePrevious.Size = New System.Drawing.Size(20, 23)
        Me.movePrevious.TabIndex = 2
        Me.movePrevious.Text = "<"
        '
        'moveNext
        '
        Me.moveNext.Location = New System.Drawing.Point(83, 13)
        Me.moveNext.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.moveNext.Name = "moveNext"
        Me.moveNext.Size = New System.Drawing.Size(20, 23)
        Me.moveNext.TabIndex = 3
        Me.moveNext.Text = ">"
        '
        'BindingSourceSample
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(433, 205)
        Me.Controls.Add(Me.info)
        Me.Controls.Add(Me.flagsCombo)
        Me.Controls.Add(Me.flagName)
        Me.Controls.Add(Me.flagPicture)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.positionIndicator)
        Me.Controls.Add(Me.movePrevious)
        Me.Controls.Add(Me.moveNext)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.MaximumSize = New System.Drawing.Size(800, 300)
        Me.MinimumSize = New System.Drawing.Size(441, 239)
        Me.Name = "BindingSourceSample"
        Me.Text = "Binding Source Sample"
        CType(Me.flagsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flagsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents info As System.Windows.Forms.TextBox
    Friend WithEvents flagsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents flagName As System.Windows.Forms.Label
    Friend WithEvents flagPicture As System.Windows.Forms.PictureBox
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents positionIndicator As System.Windows.Forms.TextBox
    Friend WithEvents movePrevious As System.Windows.Forms.Button
    Friend WithEvents moveNext As System.Windows.Forms.Button

End Class
