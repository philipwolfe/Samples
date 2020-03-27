namespace UsingBindingSource
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label maritalStatusLabel;
            System.Windows.Forms.Label genderLabel;
            System.Windows.Forms.Label hireDateLabel;
            System.Windows.Forms.Label salariedFlagLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.employeeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adventureWorks_DataDataSet = new UsingBindingSource.AdventureWorks_DataDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salariedFlagCheckBox = new System.Windows.Forms.CheckBox();
            this.hireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.maritalStatusTextBox = new System.Windows.Forms.TextBox();
            this.birthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dbBirthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dbLastNameTextBox = new System.Windows.Forms.TextBox();
            this.dbFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.dbHireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dbMaritalStatusTextBox = new System.Windows.Forms.TextBox();
            this.dbTitleTextBox = new System.Windows.Forms.TextBox();
            this.dbEmployeeIdTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.classBirthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.classLastNameTextBox = new System.Windows.Forms.TextBox();
            this.classFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.classHireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.classMaritalStatusTextBox = new System.Windows.Forms.TextBox();
            this.classTitleTextBox = new System.Windows.Forms.TextBox();
            this.classEmployeeIdTextBox = new System.Windows.Forms.TextBox();
            this.employeeTableAdapter = new UsingBindingSource.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            employeeIDLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            birthDateLabel = new System.Windows.Forms.Label();
            maritalStatusLabel = new System.Windows.Forms.Label();
            genderLabel = new System.Windows.Forms.Label();
            hireDateLabel = new System.Windows.Forms.Label();
            salariedFlagLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingNavigator)).BeginInit();
            this.employeeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(26, 46);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(70, 13);
            employeeIDLabel.TabIndex = 0;
            employeeIDLabel.Text = "Employee ID:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(26, 72);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Title:";
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new System.Drawing.Point(26, 99);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new System.Drawing.Size(57, 13);
            birthDateLabel.TabIndex = 4;
            birthDateLabel.Text = "Birth Date:";
            // 
            // maritalStatusLabel
            // 
            maritalStatusLabel.AutoSize = true;
            maritalStatusLabel.Location = new System.Drawing.Point(26, 124);
            maritalStatusLabel.Name = "maritalStatusLabel";
            maritalStatusLabel.Size = new System.Drawing.Size(74, 13);
            maritalStatusLabel.TabIndex = 6;
            maritalStatusLabel.Text = "Marital Status:";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new System.Drawing.Point(26, 150);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new System.Drawing.Size(45, 13);
            genderLabel.TabIndex = 8;
            genderLabel.Text = "Gender:";
            // 
            // hireDateLabel
            // 
            hireDateLabel.AutoSize = true;
            hireDateLabel.Location = new System.Drawing.Point(26, 177);
            hireDateLabel.Name = "hireDateLabel";
            hireDateLabel.Size = new System.Drawing.Size(55, 13);
            hireDateLabel.TabIndex = 10;
            hireDateLabel.Text = "Hire Date:";
            // 
            // salariedFlagLabel
            // 
            salariedFlagLabel.AutoSize = true;
            salariedFlagLabel.Location = new System.Drawing.Point(24, 204);
            salariedFlagLabel.Name = "salariedFlagLabel";
            salariedFlagLabel.Size = new System.Drawing.Size(71, 13);
            salariedFlagLabel.TabIndex = 12;
            salariedFlagLabel.Text = "Salaried Flag:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 179);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 24;
            label2.Text = "Hire Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(27, 152);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 13);
            label4.TabIndex = 20;
            label4.Text = "Marital Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(27, 128);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(30, 13);
            label6.TabIndex = 16;
            label6.Text = "Title:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(27, 46);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(70, 13);
            label7.TabIndex = 14;
            label7.Text = "Employee ID:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(27, 72);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(60, 13);
            label8.TabIndex = 28;
            label8.Text = "First Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(27, 98);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(61, 13);
            label9.TabIndex = 30;
            label9.Text = "Last Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 205);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 32;
            label1.Text = "Birth Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(25, 207);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 13);
            label3.TabIndex = 46;
            label3.Text = "Birth Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(25, 100);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(61, 13);
            label5.TabIndex = 44;
            label5.Text = "Last Name:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(25, 74);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(60, 13);
            label10.TabIndex = 42;
            label10.Text = "First Name:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(25, 181);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(55, 13);
            label11.TabIndex = 40;
            label11.Text = "Hire Date:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(25, 154);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(74, 13);
            label12.TabIndex = 38;
            label12.Text = "Marital Status:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(25, 124);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(30, 13);
            label13.TabIndex = 36;
            label13.Text = "Title:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(25, 48);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(70, 13);
            label14.TabIndex = 34;
            label14.Text = "Employee ID:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.employeeBindingNavigator);
            this.tabPage1.Controls.Add(salariedFlagLabel);
            this.tabPage1.Controls.Add(this.salariedFlagCheckBox);
            this.tabPage1.Controls.Add(hireDateLabel);
            this.tabPage1.Controls.Add(this.hireDateDateTimePicker);
            this.tabPage1.Controls.Add(genderLabel);
            this.tabPage1.Controls.Add(this.genderTextBox);
            this.tabPage1.Controls.Add(maritalStatusLabel);
            this.tabPage1.Controls.Add(this.maritalStatusTextBox);
            this.tabPage1.Controls.Add(birthDateLabel);
            this.tabPage1.Controls.Add(this.birthDateDateTimePicker);
            this.tabPage1.Controls.Add(titleLabel);
            this.tabPage1.Controls.Add(this.titleTextBox);
            this.tabPage1.Controls.Add(employeeIDLabel);
            this.tabPage1.Controls.Add(this.employeeIDTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Design Time";
            // 
            // employeeBindingNavigator
            // 
            this.employeeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.employeeBindingNavigator.BindingSource = this.employeeBindingSource;
            this.employeeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.employeeBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.employeeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.employeeBindingNavigator.Location = new System.Drawing.Point(3, 3);
            this.employeeBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.employeeBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.employeeBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.employeeBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.employeeBindingNavigator.Name = "employeeBindingNavigator";
            this.employeeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.employeeBindingNavigator.Size = new System.Drawing.Size(528, 25);
            this.employeeBindingNavigator.TabIndex = 1;
            this.employeeBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.AllowNew = false;
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.adventureWorks_DataDataSet;
            // 
            // adventureWorks_DataDataSet
            // 
            this.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet";
            this.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // salariedFlagCheckBox
            // 
            this.salariedFlagCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.employeeBindingSource, "SalariedFlag", true));
            this.salariedFlagCheckBox.Location = new System.Drawing.Point(104, 199);
            this.salariedFlagCheckBox.Name = "salariedFlagCheckBox";
            this.salariedFlagCheckBox.Size = new System.Drawing.Size(104, 24);
            this.salariedFlagCheckBox.TabIndex = 13;
            // 
            // hireDateDateTimePicker
            // 
            this.hireDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "HireDate", true));
            this.hireDateDateTimePicker.Location = new System.Drawing.Point(104, 173);
            this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
            this.hireDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.hireDateDateTimePicker.TabIndex = 11;
            // 
            // genderTextBox
            // 
            this.genderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Gender", true));
            this.genderTextBox.Location = new System.Drawing.Point(104, 147);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(200, 20);
            this.genderTextBox.TabIndex = 9;
            this.genderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genderTextBox_Validating);
            // 
            // maritalStatusTextBox
            // 
            this.maritalStatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "MaritalStatus", true));
            this.maritalStatusTextBox.Location = new System.Drawing.Point(104, 121);
            this.maritalStatusTextBox.Name = "maritalStatusTextBox";
            this.maritalStatusTextBox.Size = new System.Drawing.Size(200, 20);
            this.maritalStatusTextBox.TabIndex = 7;
            this.maritalStatusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maritalStatusTextBox_Validating);
            // 
            // birthDateDateTimePicker
            // 
            this.birthDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "BirthDate", true));
            this.birthDateDateTimePicker.Location = new System.Drawing.Point(104, 95);
            this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            this.birthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.birthDateDateTimePicker.TabIndex = 5;
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(104, 69);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 3;
            this.titleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.titleTextBox_Validating);
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Location = new System.Drawing.Point(104, 43);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(200, 20);
            this.employeeIDTextBox.TabIndex = 1;
            this.employeeIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.employeeIDTextBox_Validating);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(label1);
            this.tabPage2.Controls.Add(this.dbBirthDateDateTimePicker);
            this.tabPage2.Controls.Add(label9);
            this.tabPage2.Controls.Add(this.dbLastNameTextBox);
            this.tabPage2.Controls.Add(label8);
            this.tabPage2.Controls.Add(this.dbFirstNameTextBox);
            this.tabPage2.Controls.Add(label2);
            this.tabPage2.Controls.Add(this.dbHireDateDateTimePicker);
            this.tabPage2.Controls.Add(label4);
            this.tabPage2.Controls.Add(this.dbMaritalStatusTextBox);
            this.tabPage2.Controls.Add(label6);
            this.tabPage2.Controls.Add(this.dbTitleTextBox);
            this.tabPage2.Controls.Add(label7);
            this.tabPage2.Controls.Add(this.dbEmployeeIdTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB data source";
            // 
            // dbBirthDateDateTimePicker
            // 
            this.dbBirthDateDateTimePicker.Location = new System.Drawing.Point(105, 201);
            this.dbBirthDateDateTimePicker.Name = "dbBirthDateDateTimePicker";
            this.dbBirthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dbBirthDateDateTimePicker.TabIndex = 33;
            // 
            // dbLastNameTextBox
            // 
            this.dbLastNameTextBox.Location = new System.Drawing.Point(105, 95);
            this.dbLastNameTextBox.Name = "dbLastNameTextBox";
            this.dbLastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.dbLastNameTextBox.TabIndex = 31;
            this.dbLastNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dbLastNameTextBox_Validating);
            // 
            // dbFirstNameTextBox
            // 
            this.dbFirstNameTextBox.Location = new System.Drawing.Point(105, 69);
            this.dbFirstNameTextBox.Name = "dbFirstNameTextBox";
            this.dbFirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.dbFirstNameTextBox.TabIndex = 29;
            this.dbFirstNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dbFirstNameTextBox_Validating);
            // 
            // dbHireDateDateTimePicker
            // 
            this.dbHireDateDateTimePicker.Location = new System.Drawing.Point(105, 175);
            this.dbHireDateDateTimePicker.Name = "dbHireDateDateTimePicker";
            this.dbHireDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dbHireDateDateTimePicker.TabIndex = 25;
            // 
            // dbMaritalStatusTextBox
            // 
            this.dbMaritalStatusTextBox.Location = new System.Drawing.Point(105, 149);
            this.dbMaritalStatusTextBox.Name = "dbMaritalStatusTextBox";
            this.dbMaritalStatusTextBox.Size = new System.Drawing.Size(200, 20);
            this.dbMaritalStatusTextBox.TabIndex = 21;
            this.dbMaritalStatusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dbMaritalStatusTextBox_Validating);
            // 
            // dbTitleTextBox
            // 
            this.dbTitleTextBox.Location = new System.Drawing.Point(105, 123);
            this.dbTitleTextBox.Name = "dbTitleTextBox";
            this.dbTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.dbTitleTextBox.TabIndex = 17;
            this.dbTitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dbTitleTextBox_Validating);
            // 
            // dbEmployeeIdTextBox
            // 
            this.dbEmployeeIdTextBox.Location = new System.Drawing.Point(105, 43);
            this.dbEmployeeIdTextBox.Name = "dbEmployeeIdTextBox";
            this.dbEmployeeIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.dbEmployeeIdTextBox.TabIndex = 15;
            this.dbEmployeeIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dbEmployeeIdTextBox_Validating);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(label3);
            this.tabPage3.Controls.Add(this.classBirthDateDateTimePicker);
            this.tabPage3.Controls.Add(label5);
            this.tabPage3.Controls.Add(this.classLastNameTextBox);
            this.tabPage3.Controls.Add(label10);
            this.tabPage3.Controls.Add(this.classFirstNameTextBox);
            this.tabPage3.Controls.Add(label11);
            this.tabPage3.Controls.Add(this.classHireDateDateTimePicker);
            this.tabPage3.Controls.Add(label12);
            this.tabPage3.Controls.Add(this.classMaritalStatusTextBox);
            this.tabPage3.Controls.Add(label13);
            this.tabPage3.Controls.Add(this.classTitleTextBox);
            this.tabPage3.Controls.Add(label14);
            this.tabPage3.Controls.Add(this.classEmployeeIdTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(534, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Class data source";
            // 
            // classBirthDateDateTimePicker
            // 
            this.classBirthDateDateTimePicker.Location = new System.Drawing.Point(103, 203);
            this.classBirthDateDateTimePicker.Name = "classBirthDateDateTimePicker";
            this.classBirthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.classBirthDateDateTimePicker.TabIndex = 47;
            // 
            // classLastNameTextBox
            // 
            this.classLastNameTextBox.Location = new System.Drawing.Point(103, 97);
            this.classLastNameTextBox.Name = "classLastNameTextBox";
            this.classLastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.classLastNameTextBox.TabIndex = 45;
            this.classLastNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classLastNameTextBox_Validating);
            // 
            // classFirstNameTextBox
            // 
            this.classFirstNameTextBox.Location = new System.Drawing.Point(103, 71);
            this.classFirstNameTextBox.Name = "classFirstNameTextBox";
            this.classFirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.classFirstNameTextBox.TabIndex = 43;
            this.classFirstNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classFirstNameTextBox_Validating);
            // 
            // classHireDateDateTimePicker
            // 
            this.classHireDateDateTimePicker.Location = new System.Drawing.Point(103, 177);
            this.classHireDateDateTimePicker.Name = "classHireDateDateTimePicker";
            this.classHireDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.classHireDateDateTimePicker.TabIndex = 41;
            // 
            // classMaritalStatusTextBox
            // 
            this.classMaritalStatusTextBox.Location = new System.Drawing.Point(103, 151);
            this.classMaritalStatusTextBox.Name = "classMaritalStatusTextBox";
            this.classMaritalStatusTextBox.Size = new System.Drawing.Size(200, 20);
            this.classMaritalStatusTextBox.TabIndex = 39;
            this.classMaritalStatusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classMaritalStatusTextBox_Validating);
            // 
            // classTitleTextBox
            // 
            this.classTitleTextBox.Location = new System.Drawing.Point(103, 125);
            this.classTitleTextBox.Name = "classTitleTextBox";
            this.classTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.classTitleTextBox.TabIndex = 37;
            this.classTitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classTitleTextBox_Validating);
            // 
            // classEmployeeIdTextBox
            // 
            this.classEmployeeIdTextBox.Location = new System.Drawing.Point(103, 45);
            this.classEmployeeIdTextBox.Name = "classEmployeeIdTextBox";
            this.classEmployeeIdTextBox.ReadOnly = true;
            this.classEmployeeIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.classEmployeeIdTextBox.TabIndex = 35;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Using BindingSource";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingNavigator)).EndInit();
            this.employeeBindingNavigator.ResumeLayout(false);
            this.employeeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.BindingSource employeeBindingSource;
		private UsingBindingSource.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
		private System.Windows.Forms.BindingNavigator employeeBindingNavigator;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.TextBox employeeIDTextBox;
		private System.Windows.Forms.CheckBox salariedFlagCheckBox;
		private System.Windows.Forms.DateTimePicker hireDateDateTimePicker;
		private System.Windows.Forms.TextBox genderTextBox;
		private System.Windows.Forms.TextBox maritalStatusTextBox;
		private System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox dbLastNameTextBox;
		private System.Windows.Forms.TextBox dbFirstNameTextBox;
		private System.Windows.Forms.DateTimePicker dbHireDateDateTimePicker;
		private System.Windows.Forms.TextBox dbMaritalStatusTextBox;
		private System.Windows.Forms.TextBox dbTitleTextBox;
		private System.Windows.Forms.TextBox dbEmployeeIdTextBox;
		private System.Windows.Forms.DateTimePicker dbBirthDateDateTimePicker;
		private System.Windows.Forms.DateTimePicker classBirthDateDateTimePicker;
		private System.Windows.Forms.TextBox classLastNameTextBox;
		private System.Windows.Forms.TextBox classFirstNameTextBox;
		private System.Windows.Forms.DateTimePicker classHireDateDateTimePicker;
		private System.Windows.Forms.TextBox classMaritalStatusTextBox;
		private System.Windows.Forms.TextBox classTitleTextBox;
		private System.Windows.Forms.TextBox classEmployeeIdTextBox;
		private AdventureWorks_DataDataSet adventureWorks_DataDataSet;
        private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}

