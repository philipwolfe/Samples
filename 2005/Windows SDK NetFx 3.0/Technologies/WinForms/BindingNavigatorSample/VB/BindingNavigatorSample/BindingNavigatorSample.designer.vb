Partial Public Class BindingNavigatorSample
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BindingNavigatorSample))
        Me.info = New System.Windows.Forms.TextBox
        Me.flagName = New System.Windows.Forms.Label
        Me.flagPicture = New System.Windows.Forms.PictureBox
        Me.flagsNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.addComboBox = New System.Windows.Forms.ToolStripComboBox
        Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.flagsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.flagPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flagsNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flagsNavigator.SuspendLayout()
        CType(Me.flagsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'info
        '
        Me.info.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.info.Location = New System.Drawing.Point(174, 34)
        Me.info.Multiline = True
        Me.info.Name = "info"
        Me.info.ReadOnly = True
        Me.info.Size = New System.Drawing.Size(445, 126)
        Me.info.TabIndex = 0
        Me.info.TabStop = False
        '
        'flagName
        '
        Me.flagName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flagName.AutoSize = True
        Me.flagName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.flagsBindingSource, "Name", True))
        Me.flagName.Location = New System.Drawing.Point(5, 34)
        Me.flagName.Name = "flagName"
        Me.flagName.Size = New System.Drawing.Size(98, 13)
        Me.flagName.TabIndex = 26
        Me.flagName.Text = "No Flags to Display"
        '
        'flagPicture
        '
        Me.flagPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flagPicture.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.flagsBindingSource, "Image", True))
        Me.flagPicture.Location = New System.Drawing.Point(5, 55)
        Me.flagPicture.Name = "flagPicture"
        Me.flagPicture.Size = New System.Drawing.Size(163, 105)
        Me.flagPicture.TabIndex = 25
        Me.flagPicture.TabStop = False
        '
        'flagsNavigator
        '
        Me.flagsNavigator.AddNewItem = Nothing
        Me.flagsNavigator.BindingSource = Me.flagsBindingSource
        Me.flagsNavigator.CountItem = Me.bindingNavigatorCountItem
        Me.flagsNavigator.DeleteItem = Nothing
        Me.flagsNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.flagsNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator3, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator4, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator5, Me.addComboBox, Me.bindingNavigatorAddNewItem})
        Me.flagsNavigator.Location = New System.Drawing.Point(0, 0)
        Me.flagsNavigator.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.flagsNavigator.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.flagsNavigator.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.flagsNavigator.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.flagsNavigator.Name = "flagsNavigator"
        Me.flagsNavigator.PositionItem = Me.bindingNavigatorPositionItem
        Me.flagsNavigator.Size = New System.Drawing.Size(624, 25)
        Me.flagsNavigator.TabIndex = 0
        Me.flagsNavigator.TabStop = True
        Me.flagsNavigator.Text = "BindingNavigator1"
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(75, 22)
        Me.bindingNavigatorMoveFirstItem.Text = "Move &first"
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(97, 22)
        Me.bindingNavigatorMovePreviousItem.Text = "Move &previous"
        '
        'bindingNavigatorSeparator3
        '
        Me.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3"
        Me.bindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'bindingNavigatorSeparator4
        '
        Me.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4"
        Me.bindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(78, 22)
        Me.bindingNavigatorMoveNextItem.Text = "Move &next"
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(73, 22)
        Me.bindingNavigatorMoveLastItem.Text = "Move &last"
        '
        'bindingNavigatorSeparator5
        '
        Me.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5"
        Me.bindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'addComboBox
        '
        Me.addComboBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.addComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.addComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.addComboBox.Name = "addComboBox"
        Me.addComboBox.Size = New System.Drawing.Size(121, 25)
        Me.addComboBox.Sorted = True
        '
        'bindingNavigatorAddNewItem
        '
        Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
        Me.bindingNavigatorAddNewItem.Size = New System.Drawing.Size(69, 20)
        Me.bindingNavigatorAddNewItem.Text = "&Add new"
        '
        'flagsBindingSource
        '
        Me.flagsBindingSource.DataSource = GetType(Microsoft.Samples.Windows.Forms.BindingNavigatorSample.Flag)
        '
        'BindingNavigatorSample
        '
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(624, 166)
        Me.Controls.Add(Me.flagsNavigator)
        Me.Controls.Add(Me.info)
        Me.Controls.Add(Me.flagName)
        Me.Controls.Add(Me.flagPicture)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "BindingNavigatorSample"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Binding Navigator Sample"
        CType(Me.flagPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flagsNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flagsNavigator.ResumeLayout(False)
        Me.flagsNavigator.PerformLayout()
        CType(Me.flagsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents info As System.Windows.Forms.TextBox
    Friend WithEvents flagName As System.Windows.Forms.Label
    Friend WithEvents flagPicture As System.Windows.Forms.PictureBox
    Friend WithEvents flagsNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents addComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents bindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents flagsBindingSource As System.Windows.Forms.BindingSource
End Class
