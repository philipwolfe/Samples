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
        Dim label1 As System.Windows.Forms.Label
        Dim label9 As System.Windows.Forms.Label
        Dim label8 As System.Windows.Forms.Label
        Dim label2 As System.Windows.Forms.Label
        Dim label4 As System.Windows.Forms.Label
        Dim label6 As System.Windows.Forms.Label
        Dim label7 As System.Windows.Forms.Label
        Dim label3 As System.Windows.Forms.Label
        Dim label5 As System.Windows.Forms.Label
        Dim label10 As System.Windows.Forms.Label
        Dim label11 As System.Windows.Forms.Label
        Dim label12 As System.Windows.Forms.Label
        Dim label13 As System.Windows.Forms.Label
        Dim label14 As System.Windows.Forms.Label
        Dim salariedFlagLabel As System.Windows.Forms.Label
        Dim hireDateLabel As System.Windows.Forms.Label
        Dim genderLabel As System.Windows.Forms.Label
        Dim maritalStatusLabel As System.Windows.Forms.Label
        Dim birthDateLabel As System.Windows.Forms.Label
        Dim titleLabel As System.Windows.Forms.Label
        Dim employeeIDLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.salariedFlagCheckBox = New System.Windows.Forms.CheckBox
        Me.employeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.adventureWorks_DataDataSet = New UsingBindingSource.AdventureWorks_DataDataSet
        Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.hireDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.dbBirthDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.dbLastNameTextBox = New System.Windows.Forms.TextBox
        Me.dbFirstNameTextBox = New System.Windows.Forms.TextBox
        Me.dbHireDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.dbMaritalStatusTextBox = New System.Windows.Forms.TextBox
        Me.dbTitleTextBox = New System.Windows.Forms.TextBox
        Me.dbEmployeeIdTextBox = New System.Windows.Forms.TextBox
        Me.genderTextBox = New System.Windows.Forms.TextBox
        Me.maritalStatusTextBox = New System.Windows.Forms.TextBox
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.birthDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.titleTextBox = New System.Windows.Forms.TextBox
        Me.employeeIDTextBox = New System.Windows.Forms.TextBox
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.classBirthDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.classLastNameTextBox = New System.Windows.Forms.TextBox
        Me.classFirstNameTextBox = New System.Windows.Forms.TextBox
        Me.classHireDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.classMaritalStatusTextBox = New System.Windows.Forms.TextBox
        Me.classTitleTextBox = New System.Windows.Forms.TextBox
        Me.classEmployeeIdTextBox = New System.Windows.Forms.TextBox
        Me.employeeTableAdapter = New UsingBindingSource.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.employeeBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.bindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        label1 = New System.Windows.Forms.Label
        label9 = New System.Windows.Forms.Label
        label8 = New System.Windows.Forms.Label
        label2 = New System.Windows.Forms.Label
        label4 = New System.Windows.Forms.Label
        label6 = New System.Windows.Forms.Label
        label7 = New System.Windows.Forms.Label
        label3 = New System.Windows.Forms.Label
        label5 = New System.Windows.Forms.Label
        label10 = New System.Windows.Forms.Label
        label11 = New System.Windows.Forms.Label
        label12 = New System.Windows.Forms.Label
        label13 = New System.Windows.Forms.Label
        label14 = New System.Windows.Forms.Label
        salariedFlagLabel = New System.Windows.Forms.Label
        hireDateLabel = New System.Windows.Forms.Label
        genderLabel = New System.Windows.Forms.Label
        maritalStatusLabel = New System.Windows.Forms.Label
        birthDateLabel = New System.Windows.Forms.Label
        titleLabel = New System.Windows.Forms.Label
        employeeIDLabel = New System.Windows.Forms.Label
        CType(Me.employeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.employeeBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.employeeBindingNavigator.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        label1.AutoSize = True
        label1.Location = New System.Drawing.Point(25, 205)
        label1.Name = "label1"
        label1.Size = New System.Drawing.Size(57, 13)
        label1.TabIndex = 32
        label1.Text = "Birth Date:"
        '
        'label9
        '
        label9.AutoSize = True
        label9.Location = New System.Drawing.Point(25, 98)
        label9.Name = "label9"
        label9.Size = New System.Drawing.Size(61, 13)
        label9.TabIndex = 30
        label9.Text = "Last Name:"
        '
        'label8
        '
        label8.AutoSize = True
        label8.Location = New System.Drawing.Point(25, 72)
        label8.Name = "label8"
        label8.Size = New System.Drawing.Size(60, 13)
        label8.TabIndex = 28
        label8.Text = "First Name:"
        '
        'label2
        '
        label2.AutoSize = True
        label2.Location = New System.Drawing.Point(25, 179)
        label2.Name = "label2"
        label2.Size = New System.Drawing.Size(55, 13)
        label2.TabIndex = 24
        label2.Text = "Hire Date:"
        '
        'label4
        '
        label4.AutoSize = True
        label4.Location = New System.Drawing.Point(25, 152)
        label4.Name = "label4"
        label4.Size = New System.Drawing.Size(74, 13)
        label4.TabIndex = 20
        label4.Text = "Marital Status:"
        '
        'label6
        '
        label6.AutoSize = True
        label6.Location = New System.Drawing.Point(25, 126)
        label6.Name = "label6"
        label6.Size = New System.Drawing.Size(30, 13)
        label6.TabIndex = 16
        label6.Text = "Title:"
        '
        'label7
        '
        label7.AutoSize = True
        label7.Location = New System.Drawing.Point(25, 46)
        label7.Name = "label7"
        label7.Size = New System.Drawing.Size(70, 13)
        label7.TabIndex = 14
        label7.Text = "Employee ID:"
        '
        'label3
        '
        label3.AutoSize = True
        label3.Location = New System.Drawing.Point(25, 206)
        label3.Name = "label3"
        label3.Size = New System.Drawing.Size(57, 13)
        label3.TabIndex = 46
        label3.Text = "Birth Date:"
        '
        'label5
        '
        label5.AutoSize = True
        label5.Location = New System.Drawing.Point(25, 99)
        label5.Name = "label5"
        label5.Size = New System.Drawing.Size(61, 13)
        label5.TabIndex = 44
        label5.Text = "Last Name:"
        '
        'label10
        '
        label10.AutoSize = True
        label10.Location = New System.Drawing.Point(25, 73)
        label10.Name = "label10"
        label10.Size = New System.Drawing.Size(60, 13)
        label10.TabIndex = 42
        label10.Text = "First Name:"
        '
        'label11
        '
        label11.AutoSize = True
        label11.Location = New System.Drawing.Point(25, 180)
        label11.Name = "label11"
        label11.Size = New System.Drawing.Size(55, 13)
        label11.TabIndex = 40
        label11.Text = "Hire Date:"
        '
        'label12
        '
        label12.AutoSize = True
        label12.Location = New System.Drawing.Point(25, 153)
        label12.Name = "label12"
        label12.Size = New System.Drawing.Size(74, 13)
        label12.TabIndex = 38
        label12.Text = "Marital Status:"
        '
        'label13
        '
        label13.AutoSize = True
        label13.Location = New System.Drawing.Point(25, 127)
        label13.Name = "label13"
        label13.Size = New System.Drawing.Size(30, 13)
        label13.TabIndex = 36
        label13.Text = "Title:"
        '
        'label14
        '
        label14.AutoSize = True
        label14.Location = New System.Drawing.Point(25, 47)
        label14.Name = "label14"
        label14.Size = New System.Drawing.Size(70, 13)
        label14.TabIndex = 34
        label14.Text = "Employee ID:"
        '
        'salariedFlagLabel
        '
        salariedFlagLabel.AutoSize = True
        salariedFlagLabel.Location = New System.Drawing.Point(24, 204)
        salariedFlagLabel.Name = "salariedFlagLabel"
        salariedFlagLabel.Size = New System.Drawing.Size(71, 13)
        salariedFlagLabel.TabIndex = 12
        salariedFlagLabel.Text = "Salaried Flag:"
        '
        'hireDateLabel
        '
        hireDateLabel.AutoSize = True
        hireDateLabel.Location = New System.Drawing.Point(26, 177)
        hireDateLabel.Name = "hireDateLabel"
        hireDateLabel.Size = New System.Drawing.Size(55, 13)
        hireDateLabel.TabIndex = 10
        hireDateLabel.Text = "Hire Date:"
        '
        'genderLabel
        '
        genderLabel.AutoSize = True
        genderLabel.Location = New System.Drawing.Point(26, 150)
        genderLabel.Name = "genderLabel"
        genderLabel.Size = New System.Drawing.Size(45, 13)
        genderLabel.TabIndex = 8
        genderLabel.Text = "Gender:"
        '
        'maritalStatusLabel
        '
        maritalStatusLabel.AutoSize = True
        maritalStatusLabel.Location = New System.Drawing.Point(26, 124)
        maritalStatusLabel.Name = "maritalStatusLabel"
        maritalStatusLabel.Size = New System.Drawing.Size(74, 13)
        maritalStatusLabel.TabIndex = 6
        maritalStatusLabel.Text = "Marital Status:"
        '
        'birthDateLabel
        '
        birthDateLabel.AutoSize = True
        birthDateLabel.Location = New System.Drawing.Point(26, 99)
        birthDateLabel.Name = "birthDateLabel"
        birthDateLabel.Size = New System.Drawing.Size(57, 13)
        birthDateLabel.TabIndex = 4
        birthDateLabel.Text = "Birth Date:"
        '
        'titleLabel
        '
        titleLabel.AutoSize = True
        titleLabel.Location = New System.Drawing.Point(26, 72)
        titleLabel.Name = "titleLabel"
        titleLabel.Size = New System.Drawing.Size(30, 13)
        titleLabel.TabIndex = 2
        titleLabel.Text = "Title:"
        '
        'employeeIDLabel
        '
        employeeIDLabel.AutoSize = True
        employeeIDLabel.Location = New System.Drawing.Point(26, 46)
        employeeIDLabel.Name = "employeeIDLabel"
        employeeIDLabel.Size = New System.Drawing.Size(70, 13)
        employeeIDLabel.TabIndex = 0
        employeeIDLabel.Text = "Employee ID:"
        '
        'salariedFlagCheckBox
        '
        Me.salariedFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.employeeBindingSource, "SalariedFlag", True))
        Me.salariedFlagCheckBox.Location = New System.Drawing.Point(104, 199)
        Me.salariedFlagCheckBox.Name = "salariedFlagCheckBox"
        Me.salariedFlagCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.salariedFlagCheckBox.TabIndex = 13
        '
        'employeeBindingSource
        '
        Me.employeeBindingSource.AllowNew = False
        Me.employeeBindingSource.DataMember = "Employee"
        Me.employeeBindingSource.DataSource = Me.adventureWorks_DataDataSet
        '
        'adventureWorks_DataDataSet
        '
        Me.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet"
        Me.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'hireDateDateTimePicker
        '
        Me.hireDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.employeeBindingSource, "HireDate", True))
        Me.hireDateDateTimePicker.Location = New System.Drawing.Point(104, 173)
        Me.hireDateDateTimePicker.Name = "hireDateDateTimePicker"
        Me.hireDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.hireDateDateTimePicker.TabIndex = 11
        '
        'dbBirthDateDateTimePicker
        '
        Me.dbBirthDateDateTimePicker.Location = New System.Drawing.Point(103, 201)
        Me.dbBirthDateDateTimePicker.Name = "dbBirthDateDateTimePicker"
        Me.dbBirthDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.dbBirthDateDateTimePicker.TabIndex = 33
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(label1)
        Me.tabPage2.Controls.Add(Me.dbBirthDateDateTimePicker)
        Me.tabPage2.Controls.Add(label9)
        Me.tabPage2.Controls.Add(Me.dbLastNameTextBox)
        Me.tabPage2.Controls.Add(label8)
        Me.tabPage2.Controls.Add(Me.dbFirstNameTextBox)
        Me.tabPage2.Controls.Add(label2)
        Me.tabPage2.Controls.Add(Me.dbHireDateDateTimePicker)
        Me.tabPage2.Controls.Add(label4)
        Me.tabPage2.Controls.Add(Me.dbMaritalStatusTextBox)
        Me.tabPage2.Controls.Add(label6)
        Me.tabPage2.Controls.Add(Me.dbTitleTextBox)
        Me.tabPage2.Controls.Add(label7)
        Me.tabPage2.Controls.Add(Me.dbEmployeeIdTextBox)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(534, 390)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "DB data source"
        '
        'dbLastNameTextBox
        '
        Me.dbLastNameTextBox.Location = New System.Drawing.Point(103, 95)
        Me.dbLastNameTextBox.Name = "dbLastNameTextBox"
        Me.dbLastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.dbLastNameTextBox.TabIndex = 31
        '
        'dbFirstNameTextBox
        '
        Me.dbFirstNameTextBox.Location = New System.Drawing.Point(103, 69)
        Me.dbFirstNameTextBox.Name = "dbFirstNameTextBox"
        Me.dbFirstNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.dbFirstNameTextBox.TabIndex = 29
        '
        'dbHireDateDateTimePicker
        '
        Me.dbHireDateDateTimePicker.Location = New System.Drawing.Point(103, 175)
        Me.dbHireDateDateTimePicker.Name = "dbHireDateDateTimePicker"
        Me.dbHireDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.dbHireDateDateTimePicker.TabIndex = 25
        '
        'dbMaritalStatusTextBox
        '
        Me.dbMaritalStatusTextBox.Location = New System.Drawing.Point(103, 149)
        Me.dbMaritalStatusTextBox.Name = "dbMaritalStatusTextBox"
        Me.dbMaritalStatusTextBox.Size = New System.Drawing.Size(200, 20)
        Me.dbMaritalStatusTextBox.TabIndex = 21
        '
        'dbTitleTextBox
        '
        Me.dbTitleTextBox.Location = New System.Drawing.Point(103, 123)
        Me.dbTitleTextBox.Name = "dbTitleTextBox"
        Me.dbTitleTextBox.Size = New System.Drawing.Size(200, 20)
        Me.dbTitleTextBox.TabIndex = 17
        '
        'dbEmployeeIdTextBox
        '
        Me.dbEmployeeIdTextBox.Location = New System.Drawing.Point(103, 43)
        Me.dbEmployeeIdTextBox.Name = "dbEmployeeIdTextBox"
        Me.dbEmployeeIdTextBox.Size = New System.Drawing.Size(200, 20)
        Me.dbEmployeeIdTextBox.TabIndex = 15
        '
        'genderTextBox
        '
        Me.genderTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.employeeBindingSource, "Gender", True))
        Me.genderTextBox.Location = New System.Drawing.Point(104, 147)
        Me.genderTextBox.Name = "genderTextBox"
        Me.genderTextBox.Size = New System.Drawing.Size(200, 20)
        Me.genderTextBox.TabIndex = 9
        '
        'maritalStatusTextBox
        '
        Me.maritalStatusTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.employeeBindingSource, "MaritalStatus", True))
        Me.maritalStatusTextBox.Location = New System.Drawing.Point(104, 121)
        Me.maritalStatusTextBox.Name = "maritalStatusTextBox"
        Me.maritalStatusTextBox.Size = New System.Drawing.Size(200, 20)
        Me.maritalStatusTextBox.TabIndex = 7
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveNextItem.Text = "Move next"
        '
        'birthDateDateTimePicker
        '
        Me.birthDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.employeeBindingSource, "BirthDate", True))
        Me.birthDateDateTimePicker.Location = New System.Drawing.Point(104, 95)
        Me.birthDateDateTimePicker.Name = "birthDateDateTimePicker"
        Me.birthDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.birthDateDateTimePicker.TabIndex = 5
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveLastItem.Text = "Move last"
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'titleTextBox
        '
        Me.titleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.employeeBindingSource, "Title", True))
        Me.titleTextBox.Location = New System.Drawing.Point(104, 69)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(200, 20)
        Me.titleTextBox.TabIndex = 3
        '
        'employeeIDTextBox
        '
        Me.employeeIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.employeeBindingSource, "EmployeeID", True))
        Me.employeeIDTextBox.Location = New System.Drawing.Point(104, 43)
        Me.employeeIDTextBox.Name = "employeeIDTextBox"
        Me.employeeIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.employeeIDTextBox.TabIndex = 1
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(label3)
        Me.tabPage3.Controls.Add(Me.classBirthDateDateTimePicker)
        Me.tabPage3.Controls.Add(label5)
        Me.tabPage3.Controls.Add(Me.classLastNameTextBox)
        Me.tabPage3.Controls.Add(label10)
        Me.tabPage3.Controls.Add(Me.classFirstNameTextBox)
        Me.tabPage3.Controls.Add(label11)
        Me.tabPage3.Controls.Add(Me.classHireDateDateTimePicker)
        Me.tabPage3.Controls.Add(label12)
        Me.tabPage3.Controls.Add(Me.classMaritalStatusTextBox)
        Me.tabPage3.Controls.Add(label13)
        Me.tabPage3.Controls.Add(Me.classTitleTextBox)
        Me.tabPage3.Controls.Add(label14)
        Me.tabPage3.Controls.Add(Me.classEmployeeIdTextBox)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(534, 390)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Class data source"
        '
        'classBirthDateDateTimePicker
        '
        Me.classBirthDateDateTimePicker.Location = New System.Drawing.Point(103, 202)
        Me.classBirthDateDateTimePicker.Name = "classBirthDateDateTimePicker"
        Me.classBirthDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.classBirthDateDateTimePicker.TabIndex = 47
        '
        'classLastNameTextBox
        '
        Me.classLastNameTextBox.Location = New System.Drawing.Point(103, 96)
        Me.classLastNameTextBox.Name = "classLastNameTextBox"
        Me.classLastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.classLastNameTextBox.TabIndex = 45
        '
        'classFirstNameTextBox
        '
        Me.classFirstNameTextBox.Location = New System.Drawing.Point(103, 70)
        Me.classFirstNameTextBox.Name = "classFirstNameTextBox"
        Me.classFirstNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.classFirstNameTextBox.TabIndex = 43
        '
        'classHireDateDateTimePicker
        '
        Me.classHireDateDateTimePicker.Location = New System.Drawing.Point(103, 176)
        Me.classHireDateDateTimePicker.Name = "classHireDateDateTimePicker"
        Me.classHireDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.classHireDateDateTimePicker.TabIndex = 41
        '
        'classMaritalStatusTextBox
        '
        Me.classMaritalStatusTextBox.Location = New System.Drawing.Point(103, 150)
        Me.classMaritalStatusTextBox.Name = "classMaritalStatusTextBox"
        Me.classMaritalStatusTextBox.Size = New System.Drawing.Size(200, 20)
        Me.classMaritalStatusTextBox.TabIndex = 39
        '
        'classTitleTextBox
        '
        Me.classTitleTextBox.Location = New System.Drawing.Point(103, 124)
        Me.classTitleTextBox.Name = "classTitleTextBox"
        Me.classTitleTextBox.Size = New System.Drawing.Size(200, 20)
        Me.classTitleTextBox.TabIndex = 37
        '
        'classEmployeeIdTextBox
        '
        Me.classEmployeeIdTextBox.Location = New System.Drawing.Point(103, 44)
        Me.classEmployeeIdTextBox.Name = "classEmployeeIdTextBox"
        Me.classEmployeeIdTextBox.ReadOnly = True
        Me.classEmployeeIdTextBox.Size = New System.Drawing.Size(200, 20)
        Me.classEmployeeIdTextBox.TabIndex = 35
        '
        'employeeTableAdapter
        '
        Me.employeeTableAdapter.ClearBeforeFill = True
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.employeeBindingNavigator)
        Me.tabPage1.Controls.Add(salariedFlagLabel)
        Me.tabPage1.Controls.Add(Me.salariedFlagCheckBox)
        Me.tabPage1.Controls.Add(hireDateLabel)
        Me.tabPage1.Controls.Add(Me.hireDateDateTimePicker)
        Me.tabPage1.Controls.Add(genderLabel)
        Me.tabPage1.Controls.Add(Me.genderTextBox)
        Me.tabPage1.Controls.Add(maritalStatusLabel)
        Me.tabPage1.Controls.Add(Me.maritalStatusTextBox)
        Me.tabPage1.Controls.Add(birthDateLabel)
        Me.tabPage1.Controls.Add(Me.birthDateDateTimePicker)
        Me.tabPage1.Controls.Add(titleLabel)
        Me.tabPage1.Controls.Add(Me.titleTextBox)
        Me.tabPage1.Controls.Add(employeeIDLabel)
        Me.tabPage1.Controls.Add(Me.employeeIDTextBox)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(534, 390)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Design Time"
        '
        'employeeBindingNavigator
        '
        Me.employeeBindingNavigator.AddNewItem = Me.bindingNavigatorAddNewItem
        Me.employeeBindingNavigator.BindingSource = Me.employeeBindingSource
        Me.employeeBindingNavigator.CountItem = Me.bindingNavigatorCountItem
        Me.employeeBindingNavigator.DeleteItem = Me.bindingNavigatorDeleteItem
        Me.employeeBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator2, Me.bindingNavigatorAddNewItem, Me.bindingNavigatorDeleteItem})
        Me.employeeBindingNavigator.Location = New System.Drawing.Point(3, 3)
        Me.employeeBindingNavigator.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.employeeBindingNavigator.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.employeeBindingNavigator.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.employeeBindingNavigator.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.employeeBindingNavigator.Name = "employeeBindingNavigator"
        Me.employeeBindingNavigator.PositionItem = Me.bindingNavigatorPositionItem
        Me.employeeBindingNavigator.Size = New System.Drawing.Size(528, 25)
        Me.employeeBindingNavigator.TabIndex = 1
        Me.employeeBindingNavigator.Text = "bindingNavigator1"
        '
        'bindingNavigatorAddNewItem
        '
        Me.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
        Me.bindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorAddNewItem.Text = "Add new"
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'bindingNavigatorDeleteItem
        '
        Me.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorDeleteItem.Image = CType(resources.GetObject("bindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem"
        Me.bindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorDeleteItem.Text = "Delete"
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 416)
        Me.tabControl1.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using BindingSource"
        CType(Me.employeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        CType(Me.employeeBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.employeeBindingNavigator.ResumeLayout(False)
        Me.employeeBindingNavigator.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents salariedFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents employeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents adventureWorks_DataDataSet As UsingBindingSource.AdventureWorks_DataDataSet
    Friend WithEvents bindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents hireDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents dbBirthDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dbLastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dbFirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dbHireDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents dbMaritalStatusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dbTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dbEmployeeIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents genderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents maritalStatusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents birthDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents titleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents employeeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents classBirthDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents classLastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents classFirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents classHireDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents classMaritalStatusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents classTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents classEmployeeIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents employeeTableAdapter As UsingBindingSource.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
    Friend WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents employeeBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents bindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class
