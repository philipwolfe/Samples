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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.tabPageStandard = New System.Windows.Forms.TabPage
        Me.tabPageCustom = New System.Windows.Forms.TabPage
        Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.employeeIDLabel = New System.Windows.Forms.Label
        Me.employeeIDTextBox = New System.Windows.Forms.TextBox
        Me.titleLabel = New System.Windows.Forms.Label
        Me.titleTextBox = New System.Windows.Forms.TextBox
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.birthDateLabel = New System.Windows.Forms.Label
        Me.tabPageToolbox = New System.Windows.Forms.TabPage
        Me.EmployeesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.bindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.birthDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.maritalStatusLabel = New System.Windows.Forms.Label
        Me.maritalStatusTextBox = New System.Windows.Forms.TextBox
        Me.genderLabel = New System.Windows.Forms.Label
        Me.genderTextBox = New System.Windows.Forms.TextBox
        Me.hireDateLabel = New System.Windows.Forms.Label
        Me.hireDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.salariedFlagLabel = New System.Windows.Forms.Label
        Me.salariedFlagCheckBox = New System.Windows.Forms.CheckBox
        Me.vacationHoursLabel = New System.Windows.Forms.Label
        Me.vacationHoursTextBox = New System.Windows.Forms.TextBox
        Me.sickLeaveHoursLabel = New System.Windows.Forms.Label
        Me.sickLeaveHoursTextBox = New System.Windows.Forms.TextBox
        Me.currentFlagLabel = New System.Windows.Forms.Label
        Me.currentFlagCheckBox = New System.Windows.Forms.CheckBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabPageToolbox.SuspendLayout()
        CType(Me.EmployeesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmployeesBindingNavigator.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabPageStandard
        '
        Me.tabPageStandard.Location = New System.Drawing.Point(4, 22)
        Me.tabPageStandard.Name = "tabPageStandard"
        Me.tabPageStandard.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageStandard.Size = New System.Drawing.Size(534, 27)
        Me.tabPageStandard.TabIndex = 1
        Me.tabPageStandard.Text = "Standard UI"
        '
        'tabPageCustom
        '
        Me.tabPageCustom.Location = New System.Drawing.Point(4, 22)
        Me.tabPageCustom.Name = "tabPageCustom"
        Me.tabPageCustom.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageCustom.Size = New System.Drawing.Size(534, 27)
        Me.tabPageCustom.TabIndex = 2
        Me.tabPageCustom.Text = "Custom UI"
        '
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 21)
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorMoveNextItem.Text = "Move next"
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorMoveLastItem.Text = "Move last"
        '
        'employeeIDLabel
        '
        Me.employeeIDLabel.AutoSize = True
        Me.employeeIDLabel.Location = New System.Drawing.Point(17, 60)
        Me.employeeIDLabel.Name = "employeeIDLabel"
        Me.employeeIDLabel.Size = New System.Drawing.Size(70, 13)
        Me.employeeIDLabel.TabIndex = 72
        Me.employeeIDLabel.Text = "Employee ID:"
        '
        'employeeIDTextBox
        '
        Me.employeeIDTextBox.Location = New System.Drawing.Point(138, 57)
        Me.employeeIDTextBox.Name = "employeeIDTextBox"
        Me.employeeIDTextBox.Size = New System.Drawing.Size(192, 20)
        Me.employeeIDTextBox.TabIndex = 73
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Location = New System.Drawing.Point(17, 88)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(30, 13)
        Me.titleLabel.TabIndex = 74
        Me.titleLabel.Text = "Title:"
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New System.Drawing.Point(138, 85)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(192, 20)
        Me.titleTextBox.TabIndex = 75
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 21)
        '
        'birthDateLabel
        '
        Me.birthDateLabel.AutoSize = True
        Me.birthDateLabel.Location = New System.Drawing.Point(17, 124)
        Me.birthDateLabel.Name = "birthDateLabel"
        Me.birthDateLabel.Size = New System.Drawing.Size(57, 13)
        Me.birthDateLabel.TabIndex = 78
        Me.birthDateLabel.Text = "Birth Date:"
        '
        'tabPageToolbox
        '
        Me.tabPageToolbox.Controls.Add(Me.EmployeesBindingNavigator)
        Me.tabPageToolbox.Location = New System.Drawing.Point(4, 22)
        Me.tabPageToolbox.Name = "tabPageToolbox"
        Me.tabPageToolbox.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageToolbox.Size = New System.Drawing.Size(534, 27)
        Me.tabPageToolbox.TabIndex = 0
        Me.tabPageToolbox.Text = "Toolbox"
        '
        'EmployeesBindingNavigator
        '
        Me.EmployeesBindingNavigator.AddNewItem = Me.bindingNavigatorAddNewItem
        Me.EmployeesBindingNavigator.CountItem = Me.bindingNavigatorCountItem
        Me.EmployeesBindingNavigator.DeleteItem = Me.bindingNavigatorDeleteItem
        Me.EmployeesBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmployeesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator2, Me.bindingNavigatorAddNewItem, Me.bindingNavigatorDeleteItem})
        Me.EmployeesBindingNavigator.Location = New System.Drawing.Point(3, 3)
        Me.EmployeesBindingNavigator.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.EmployeesBindingNavigator.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.EmployeesBindingNavigator.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.EmployeesBindingNavigator.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.EmployeesBindingNavigator.Name = "EmployeesBindingNavigator"
        Me.EmployeesBindingNavigator.PositionItem = Me.bindingNavigatorPositionItem
        Me.EmployeesBindingNavigator.Size = New System.Drawing.Size(528, 21)
        Me.EmployeesBindingNavigator.TabIndex = 1
        Me.EmployeesBindingNavigator.Text = "bindingNavigator1"
        '
        'bindingNavigatorAddNewItem
        '
        Me.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
        Me.bindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorAddNewItem.Text = "Add new"
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(36, 18)
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'bindingNavigatorDeleteItem
        '
        Me.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorDeleteItem.Image = CType(resources.GetObject("bindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem"
        Me.bindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorDeleteItem.Text = "Delete"
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 18)
        Me.bindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 21)
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(100, 21)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'birthDateDateTimePicker
        '
        Me.birthDateDateTimePicker.Location = New System.Drawing.Point(138, 120)
        Me.birthDateDateTimePicker.Name = "birthDateDateTimePicker"
        Me.birthDateDateTimePicker.Size = New System.Drawing.Size(192, 20)
        Me.birthDateDateTimePicker.TabIndex = 79
        '
        'maritalStatusLabel
        '
        Me.maritalStatusLabel.AutoSize = True
        Me.maritalStatusLabel.Location = New System.Drawing.Point(17, 152)
        Me.maritalStatusLabel.Name = "maritalStatusLabel"
        Me.maritalStatusLabel.Size = New System.Drawing.Size(74, 13)
        Me.maritalStatusLabel.TabIndex = 80
        Me.maritalStatusLabel.Text = "Marital Status:"
        '
        'maritalStatusTextBox
        '
        Me.maritalStatusTextBox.Location = New System.Drawing.Point(138, 149)
        Me.maritalStatusTextBox.Name = "maritalStatusTextBox"
        Me.maritalStatusTextBox.Size = New System.Drawing.Size(192, 20)
        Me.maritalStatusTextBox.TabIndex = 81
        '
        'genderLabel
        '
        Me.genderLabel.AutoSize = True
        Me.genderLabel.Location = New System.Drawing.Point(17, 184)
        Me.genderLabel.Name = "genderLabel"
        Me.genderLabel.Size = New System.Drawing.Size(45, 13)
        Me.genderLabel.TabIndex = 82
        Me.genderLabel.Text = "Gender:"
        '
        'genderTextBox
        '
        Me.genderTextBox.Location = New System.Drawing.Point(138, 177)
        Me.genderTextBox.Name = "genderTextBox"
        Me.genderTextBox.Size = New System.Drawing.Size(192, 20)
        Me.genderTextBox.TabIndex = 83
        '
        'hireDateLabel
        '
        Me.hireDateLabel.AutoSize = True
        Me.hireDateLabel.Location = New System.Drawing.Point(17, 210)
        Me.hireDateLabel.Name = "hireDateLabel"
        Me.hireDateLabel.Size = New System.Drawing.Size(55, 13)
        Me.hireDateLabel.TabIndex = 84
        Me.hireDateLabel.Text = "Hire Date:"
        '
        'hireDateDateTimePicker
        '
        Me.hireDateDateTimePicker.Location = New System.Drawing.Point(138, 206)
        Me.hireDateDateTimePicker.Name = "hireDateDateTimePicker"
        Me.hireDateDateTimePicker.Size = New System.Drawing.Size(192, 20)
        Me.hireDateDateTimePicker.TabIndex = 85
        '
        'salariedFlagLabel
        '
        Me.salariedFlagLabel.AutoSize = True
        Me.salariedFlagLabel.Location = New System.Drawing.Point(17, 237)
        Me.salariedFlagLabel.Name = "salariedFlagLabel"
        Me.salariedFlagLabel.Size = New System.Drawing.Size(71, 13)
        Me.salariedFlagLabel.TabIndex = 86
        Me.salariedFlagLabel.Text = "Salaried Flag:"
        '
        'salariedFlagCheckBox
        '
        Me.salariedFlagCheckBox.Location = New System.Drawing.Point(138, 232)
        Me.salariedFlagCheckBox.Name = "salariedFlagCheckBox"
        Me.salariedFlagCheckBox.Size = New System.Drawing.Size(192, 24)
        Me.salariedFlagCheckBox.TabIndex = 87
        '
        'vacationHoursLabel
        '
        Me.vacationHoursLabel.AutoSize = True
        Me.vacationHoursLabel.Location = New System.Drawing.Point(17, 265)
        Me.vacationHoursLabel.Name = "vacationHoursLabel"
        Me.vacationHoursLabel.Size = New System.Drawing.Size(83, 13)
        Me.vacationHoursLabel.TabIndex = 92
        Me.vacationHoursLabel.Text = "Vacation Hours:"
        '
        'vacationHoursTextBox
        '
        Me.vacationHoursTextBox.Location = New System.Drawing.Point(138, 262)
        Me.vacationHoursTextBox.Name = "vacationHoursTextBox"
        Me.vacationHoursTextBox.Size = New System.Drawing.Size(192, 20)
        Me.vacationHoursTextBox.TabIndex = 93
        '
        'sickLeaveHoursLabel
        '
        Me.sickLeaveHoursLabel.AutoSize = True
        Me.sickLeaveHoursLabel.Location = New System.Drawing.Point(17, 293)
        Me.sickLeaveHoursLabel.Name = "sickLeaveHoursLabel"
        Me.sickLeaveHoursLabel.Size = New System.Drawing.Size(95, 13)
        Me.sickLeaveHoursLabel.TabIndex = 94
        Me.sickLeaveHoursLabel.Text = "Sick Leave Hours:"
        '
        'sickLeaveHoursTextBox
        '
        Me.sickLeaveHoursTextBox.Location = New System.Drawing.Point(138, 290)
        Me.sickLeaveHoursTextBox.Name = "sickLeaveHoursTextBox"
        Me.sickLeaveHoursTextBox.Size = New System.Drawing.Size(192, 20)
        Me.sickLeaveHoursTextBox.TabIndex = 95
        '
        'currentFlagLabel
        '
        Me.currentFlagLabel.AutoSize = True
        Me.currentFlagLabel.Location = New System.Drawing.Point(17, 321)
        Me.currentFlagLabel.Name = "currentFlagLabel"
        Me.currentFlagLabel.Size = New System.Drawing.Size(67, 13)
        Me.currentFlagLabel.TabIndex = 96
        Me.currentFlagLabel.Text = "Current Flag:"
        '
        'currentFlagCheckBox
        '
        Me.currentFlagCheckBox.Location = New System.Drawing.Point(138, 314)
        Me.currentFlagCheckBox.Name = "currentFlagCheckBox"
        Me.currentFlagCheckBox.Size = New System.Drawing.Size(192, 24)
        Me.currentFlagCheckBox.TabIndex = 97
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPageToolbox)
        Me.tabControl1.Controls.Add(Me.tabPageStandard)
        Me.tabControl1.Controls.Add(Me.tabPageCustom)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 53)
        Me.tabControl1.TabIndex = 71
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 345)
        Me.Controls.Add(Me.employeeIDLabel)
        Me.Controls.Add(Me.employeeIDTextBox)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.titleTextBox)
        Me.Controls.Add(Me.birthDateLabel)
        Me.Controls.Add(Me.birthDateDateTimePicker)
        Me.Controls.Add(Me.maritalStatusLabel)
        Me.Controls.Add(Me.maritalStatusTextBox)
        Me.Controls.Add(Me.genderLabel)
        Me.Controls.Add(Me.genderTextBox)
        Me.Controls.Add(Me.hireDateLabel)
        Me.Controls.Add(Me.hireDateDateTimePicker)
        Me.Controls.Add(Me.salariedFlagLabel)
        Me.Controls.Add(Me.salariedFlagCheckBox)
        Me.Controls.Add(Me.vacationHoursLabel)
        Me.Controls.Add(Me.vacationHoursTextBox)
        Me.Controls.Add(Me.sickLeaveHoursLabel)
        Me.Controls.Add(Me.sickLeaveHoursTextBox)
        Me.Controls.Add(Me.currentFlagLabel)
        Me.Controls.Add(Me.currentFlagCheckBox)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.tabPageToolbox.ResumeLayout(False)
        Me.tabPageToolbox.PerformLayout()
        CType(Me.EmployeesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmployeesBindingNavigator.ResumeLayout(False)
        Me.EmployeesBindingNavigator.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabPageStandard As System.Windows.Forms.TabPage
    Friend WithEvents tabPageCustom As System.Windows.Forms.TabPage
    Friend WithEvents bindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents employeeIDLabel As System.Windows.Forms.Label
    Friend WithEvents employeeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents titleLabel As System.Windows.Forms.Label
    Friend WithEvents titleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents birthDateLabel As System.Windows.Forms.Label
    Friend WithEvents tabPageToolbox As System.Windows.Forms.TabPage
    Friend WithEvents EmployeesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents bindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents birthDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents maritalStatusLabel As System.Windows.Forms.Label
    Friend WithEvents maritalStatusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents genderLabel As System.Windows.Forms.Label
    Friend WithEvents genderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hireDateLabel As System.Windows.Forms.Label
    Friend WithEvents hireDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents salariedFlagLabel As System.Windows.Forms.Label
    Friend WithEvents salariedFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents vacationHoursLabel As System.Windows.Forms.Label
    Friend WithEvents vacationHoursTextBox As System.Windows.Forms.TextBox
    Friend WithEvents sickLeaveHoursLabel As System.Windows.Forms.Label
    Friend WithEvents sickLeaveHoursTextBox As System.Windows.Forms.TextBox
    Friend WithEvents currentFlagLabel As System.Windows.Forms.Label
    Friend WithEvents currentFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class
