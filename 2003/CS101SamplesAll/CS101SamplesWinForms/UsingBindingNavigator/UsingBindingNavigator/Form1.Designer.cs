namespace UsingBindingNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageToolbox = new System.Windows.Forms.TabPage();
            this.EmployeesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.tabPageStandard = new System.Windows.Forms.TabPage();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.employeeIDLabel = new System.Windows.Forms.Label();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.birthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.maritalStatusLabel = new System.Windows.Forms.Label();
            this.maritalStatusTextBox = new System.Windows.Forms.TextBox();
            this.genderLabel = new System.Windows.Forms.Label();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.hireDateLabel = new System.Windows.Forms.Label();
            this.hireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.salariedFlagLabel = new System.Windows.Forms.Label();
            this.salariedFlagCheckBox = new System.Windows.Forms.CheckBox();
            this.vacationHoursLabel = new System.Windows.Forms.Label();
            this.vacationHoursTextBox = new System.Windows.Forms.TextBox();
            this.sickLeaveHoursLabel = new System.Windows.Forms.Label();
            this.sickLeaveHoursTextBox = new System.Windows.Forms.TextBox();
            this.currentFlagLabel = new System.Windows.Forms.Label();
            this.currentFlagCheckBox = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesBindingNavigator)).BeginInit();
            this.EmployeesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageToolbox);
            this.tabControl1.Controls.Add(this.tabPageStandard);
            this.tabControl1.Controls.Add(this.tabPageCustom);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 53);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageToolbox
            // 
            this.tabPageToolbox.Controls.Add(this.EmployeesBindingNavigator);
            this.tabPageToolbox.Location = new System.Drawing.Point(4, 22);
            this.tabPageToolbox.Name = "tabPageToolbox";
            this.tabPageToolbox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToolbox.Size = new System.Drawing.Size(534, 27);
            this.tabPageToolbox.TabIndex = 0;
            this.tabPageToolbox.Text = "Toolbox";
            // 
            // EmployeesBindingNavigator
            // 
            this.EmployeesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.EmployeesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.EmployeesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.EmployeesBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.EmployeesBindingNavigator.Location = new System.Drawing.Point(3, 3);
            this.EmployeesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.EmployeesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.EmployeesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.EmployeesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.EmployeesBindingNavigator.Name = "EmployeesBindingNavigator";
            this.EmployeesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.EmployeesBindingNavigator.Size = new System.Drawing.Size(528, 21);
            this.EmployeesBindingNavigator.TabIndex = 1;
            this.EmployeesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 18);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 21);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 21);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 18);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 21);
            // 
            // tabPageStandard
            // 
            this.tabPageStandard.Location = new System.Drawing.Point(4, 22);
            this.tabPageStandard.Name = "tabPageStandard";
            this.tabPageStandard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStandard.Size = new System.Drawing.Size(534, 27);
            this.tabPageStandard.TabIndex = 1;
            this.tabPageStandard.Text = "Standard UI";
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustom.Size = new System.Drawing.Size(534, 27);
            this.tabPageCustom.TabIndex = 2;
            this.tabPageCustom.Text = "Custom UI";
            // 
            // employeeIDLabel
            // 
            this.employeeIDLabel.AutoSize = true;
            this.employeeIDLabel.Location = new System.Drawing.Point(17, 80);
            this.employeeIDLabel.Name = "employeeIDLabel";
            this.employeeIDLabel.Size = new System.Drawing.Size(70, 13);
            this.employeeIDLabel.TabIndex = 45;
            this.employeeIDLabel.Text = "Employee ID:";
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.Location = new System.Drawing.Point(138, 77);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(192, 20);
            this.employeeIDTextBox.TabIndex = 46;
            this.employeeIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.employeeIDTextBox_Validating);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(17, 110);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 47;
            this.titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(138, 107);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(192, 20);
            this.titleTextBox.TabIndex = 48;
            this.titleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.titleTextBox_Validating);
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Location = new System.Drawing.Point(17, 147);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(57, 13);
            this.birthDateLabel.TabIndex = 51;
            this.birthDateLabel.Text = "Birth Date:";
            // 
            // birthDateDateTimePicker
            // 
            this.birthDateDateTimePicker.Location = new System.Drawing.Point(138, 143);
            this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            this.birthDateDateTimePicker.Size = new System.Drawing.Size(192, 20);
            this.birthDateDateTimePicker.TabIndex = 52;
            // 
            // maritalStatusLabel
            // 
            this.maritalStatusLabel.AutoSize = true;
            this.maritalStatusLabel.Location = new System.Drawing.Point(17, 176);
            this.maritalStatusLabel.Name = "maritalStatusLabel";
            this.maritalStatusLabel.Size = new System.Drawing.Size(74, 13);
            this.maritalStatusLabel.TabIndex = 53;
            this.maritalStatusLabel.Text = "Marital Status:";
            // 
            // maritalStatusTextBox
            // 
            this.maritalStatusTextBox.Location = new System.Drawing.Point(138, 173);
            this.maritalStatusTextBox.Name = "maritalStatusTextBox";
            this.maritalStatusTextBox.Size = new System.Drawing.Size(192, 20);
            this.maritalStatusTextBox.TabIndex = 54;
            this.maritalStatusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maritalStatusTextBox_Validating);
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(17, 210);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(45, 13);
            this.genderLabel.TabIndex = 55;
            this.genderLabel.Text = "Gender:";
            // 
            // genderTextBox
            // 
            this.genderTextBox.Location = new System.Drawing.Point(138, 203);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(192, 20);
            this.genderTextBox.TabIndex = 56;
            this.genderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genderTextBox_Validating);
            // 
            // hireDateLabel
            // 
            this.hireDateLabel.AutoSize = true;
            this.hireDateLabel.Location = new System.Drawing.Point(17, 237);
            this.hireDateLabel.Name = "hireDateLabel";
            this.hireDateLabel.Size = new System.Drawing.Size(55, 13);
            this.hireDateLabel.TabIndex = 57;
            this.hireDateLabel.Text = "Hire Date:";
            // 
            // hireDateDateTimePicker
            // 
            this.hireDateDateTimePicker.Location = new System.Drawing.Point(138, 233);
            this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
            this.hireDateDateTimePicker.Size = new System.Drawing.Size(192, 20);
            this.hireDateDateTimePicker.TabIndex = 58;
            // 
            // salariedFlagLabel
            // 
            this.salariedFlagLabel.AutoSize = true;
            this.salariedFlagLabel.Location = new System.Drawing.Point(17, 268);
            this.salariedFlagLabel.Name = "salariedFlagLabel";
            this.salariedFlagLabel.Size = new System.Drawing.Size(71, 13);
            this.salariedFlagLabel.TabIndex = 59;
            this.salariedFlagLabel.Text = "Salaried Flag:";
            // 
            // salariedFlagCheckBox
            // 
            this.salariedFlagCheckBox.Location = new System.Drawing.Point(138, 263);
            this.salariedFlagCheckBox.Name = "salariedFlagCheckBox";
            this.salariedFlagCheckBox.Size = new System.Drawing.Size(192, 24);
            this.salariedFlagCheckBox.TabIndex = 60;
            // 
            // vacationHoursLabel
            // 
            this.vacationHoursLabel.AutoSize = true;
            this.vacationHoursLabel.Location = new System.Drawing.Point(17, 296);
            this.vacationHoursLabel.Name = "vacationHoursLabel";
            this.vacationHoursLabel.Size = new System.Drawing.Size(83, 13);
            this.vacationHoursLabel.TabIndex = 65;
            this.vacationHoursLabel.Text = "Vacation Hours:";
            // 
            // vacationHoursTextBox
            // 
            this.vacationHoursTextBox.Location = new System.Drawing.Point(138, 293);
            this.vacationHoursTextBox.Name = "vacationHoursTextBox";
            this.vacationHoursTextBox.Size = new System.Drawing.Size(192, 20);
            this.vacationHoursTextBox.TabIndex = 66;
            this.vacationHoursTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.vacationHoursTextBox_Validating);
            // 
            // sickLeaveHoursLabel
            // 
            this.sickLeaveHoursLabel.AutoSize = true;
            this.sickLeaveHoursLabel.Location = new System.Drawing.Point(17, 326);
            this.sickLeaveHoursLabel.Name = "sickLeaveHoursLabel";
            this.sickLeaveHoursLabel.Size = new System.Drawing.Size(95, 13);
            this.sickLeaveHoursLabel.TabIndex = 67;
            this.sickLeaveHoursLabel.Text = "Sick Leave Hours:";
            // 
            // sickLeaveHoursTextBox
            // 
            this.sickLeaveHoursTextBox.Location = new System.Drawing.Point(138, 323);
            this.sickLeaveHoursTextBox.Name = "sickLeaveHoursTextBox";
            this.sickLeaveHoursTextBox.Size = new System.Drawing.Size(192, 20);
            this.sickLeaveHoursTextBox.TabIndex = 68;
            this.sickLeaveHoursTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.sickLeaveHoursTextBox_Validating);
            // 
            // currentFlagLabel
            // 
            this.currentFlagLabel.AutoSize = true;
            this.currentFlagLabel.Location = new System.Drawing.Point(17, 358);
            this.currentFlagLabel.Name = "currentFlagLabel";
            this.currentFlagLabel.Size = new System.Drawing.Size(67, 13);
            this.currentFlagLabel.TabIndex = 69;
            this.currentFlagLabel.Text = "Current Flag:";
            // 
            // currentFlagCheckBox
            // 
            this.currentFlagCheckBox.Location = new System.Drawing.Point(138, 353);
            this.currentFlagCheckBox.Name = "currentFlagCheckBox";
            this.currentFlagCheckBox.Size = new System.Drawing.Size(192, 24);
            this.currentFlagCheckBox.TabIndex = 70;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(542, 384);
            this.Controls.Add(this.employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.birthDateLabel);
            this.Controls.Add(this.birthDateDateTimePicker);
            this.Controls.Add(this.maritalStatusLabel);
            this.Controls.Add(this.maritalStatusTextBox);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.genderTextBox);
            this.Controls.Add(this.hireDateLabel);
            this.Controls.Add(this.hireDateDateTimePicker);
            this.Controls.Add(this.salariedFlagLabel);
            this.Controls.Add(this.salariedFlagCheckBox);
            this.Controls.Add(this.vacationHoursLabel);
            this.Controls.Add(this.vacationHoursTextBox);
            this.Controls.Add(this.sickLeaveHoursLabel);
            this.Controls.Add(this.sickLeaveHoursTextBox);
            this.Controls.Add(this.currentFlagLabel);
            this.Controls.Add(this.currentFlagCheckBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Using BindingNavigator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageToolbox.ResumeLayout(false);
            this.tabPageToolbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesBindingNavigator)).EndInit();
            this.EmployeesBindingNavigator.ResumeLayout(false);
            this.EmployeesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageToolbox;
        private System.Windows.Forms.BindingNavigator EmployeesBindingNavigator;
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
        private System.Windows.Forms.TabPage tabPageStandard;
        private System.Windows.Forms.TabPage tabPageCustom;
        private System.Windows.Forms.Label employeeIDLabel;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
        private System.Windows.Forms.Label maritalStatusLabel;
        private System.Windows.Forms.TextBox maritalStatusTextBox;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.TextBox genderTextBox;
        private System.Windows.Forms.Label hireDateLabel;
        private System.Windows.Forms.DateTimePicker hireDateDateTimePicker;
        private System.Windows.Forms.Label salariedFlagLabel;
        private System.Windows.Forms.CheckBox salariedFlagCheckBox;
        private System.Windows.Forms.Label vacationHoursLabel;
        private System.Windows.Forms.TextBox vacationHoursTextBox;
        private System.Windows.Forms.Label sickLeaveHoursLabel;
        private System.Windows.Forms.TextBox sickLeaveHoursTextBox;
        private System.Windows.Forms.Label currentFlagLabel;
		private System.Windows.Forms.CheckBox currentFlagCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;

	}
}

