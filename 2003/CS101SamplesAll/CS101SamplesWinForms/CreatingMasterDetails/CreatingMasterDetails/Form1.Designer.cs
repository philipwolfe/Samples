namespace CreatingMasterDetails
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
            System.Windows.Forms.Label departmentIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label groupNameLabel;
            System.Windows.Forms.Label departmentIDLabel1;
            System.Windows.Forms.Label nameLabel1;
            System.Windows.Forms.Label groupNameLabel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.departmentIDTextBox1 = new System.Windows.Forms.TextBox();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.adventureWorks_DataDataSet = new CreatingMasterDetails.AdventureWorks_DataDataSet();
            this.groupNameTextBox1 = new System.Windows.Forms.TextBox();
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.employeeDataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.departmentBindingSource1BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.departmentIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.departmentIDTextBox2 = new System.Windows.Forms.TextBox();
            this.nameTextBox2 = new System.Windows.Forms.TextBox();
            this.groupNameTextBox2 = new System.Windows.Forms.TextBox();
            this.employeeDataGridView2 = new System.Windows.Forms.DataGridView();
            this.departmentTableAdapter = new CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.DepartmentTableAdapter();
            this.employeeTableAdapter = new CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter();
            this.employeeTableAdapter1 = new CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter();
            departmentIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            groupNameLabel = new System.Windows.Forms.Label();
            departmentIDLabel1 = new System.Windows.Forms.Label();
            nameLabel1 = new System.Windows.Forms.Label();
            groupNameLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1BindingNavigator)).BeginInit();
            this.departmentBindingSource1BindingNavigator.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentIDLabel
            // 
            departmentIDLabel.AutoSize = true;
            departmentIDLabel.Location = new System.Drawing.Point(8, 11);
            departmentIDLabel.Name = "departmentIDLabel";
            departmentIDLabel.Size = new System.Drawing.Size(79, 13);
            departmentIDLabel.TabIndex = 0;
            departmentIDLabel.Text = "Department ID:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(8, 38);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(67, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Dept. Name:";
            // 
            // groupNameLabel
            // 
            groupNameLabel.AutoSize = true;
            groupNameLabel.Location = new System.Drawing.Point(8, 65);
            groupNameLabel.Name = "groupNameLabel";
            groupNameLabel.Size = new System.Drawing.Size(70, 13);
            groupNameLabel.TabIndex = 4;
            groupNameLabel.Text = "Group Name:";
            // 
            // departmentIDLabel1
            // 
            departmentIDLabel1.AutoSize = true;
            departmentIDLabel1.Location = new System.Drawing.Point(9, 11);
            departmentIDLabel1.Name = "departmentIDLabel1";
            departmentIDLabel1.Size = new System.Drawing.Size(79, 13);
            departmentIDLabel1.TabIndex = 9;
            departmentIDLabel1.Text = "Department ID:";
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(8, 37);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(67, 13);
            nameLabel1.TabIndex = 11;
            nameLabel1.Text = "Dept. Name:";
            // 
            // groupNameLabel1
            // 
            groupNameLabel1.AutoSize = true;
            groupNameLabel1.Location = new System.Drawing.Point(8, 63);
            groupNameLabel1.Name = "groupNameLabel1";
            groupNameLabel1.Size = new System.Drawing.Size(70, 13);
            groupNameLabel1.TabIndex = 13;
            groupNameLabel1.Text = "Group Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 13);
            label1.TabIndex = 6;
            label1.Text = "Department ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 41);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 13);
            label2.TabIndex = 8;
            label2.Text = "Dept. Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 68);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 13);
            label3.TabIndex = 10;
            label3.Text = "Group Name:";
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
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Controls.Add(this.departmentBindingSource1BindingNavigator);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Design time";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 28);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(departmentIDLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.departmentIDTextBox1);
            this.splitContainer3.Panel1.Controls.Add(nameLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.groupNameTextBox1);
            this.splitContainer3.Panel1.Controls.Add(this.nameTextBox1);
            this.splitContainer3.Panel1.Controls.Add(groupNameLabel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.employeeDataGridView1);
            this.splitContainer3.Size = new System.Drawing.Size(528, 359);
            this.splitContainer3.SplitterDistance = 92;
            this.splitContainer3.TabIndex = 10;
            this.splitContainer3.Text = "splitContainer3";
            // 
            // departmentIDTextBox1
            // 
            this.departmentIDTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource1, "DepartmentID", true));
            this.departmentIDTextBox1.Enabled = false;
            this.departmentIDTextBox1.Location = new System.Drawing.Point(90, 8);
            this.departmentIDTextBox1.Name = "departmentIDTextBox1";
            this.departmentIDTextBox1.Size = new System.Drawing.Size(200, 20);
            this.departmentIDTextBox1.TabIndex = 10;
            // 
            // departmentBindingSource1
            // 
            this.departmentBindingSource1.AllowNew = false;
            this.departmentBindingSource1.DataMember = "Department";
            this.departmentBindingSource1.DataSource = this.adventureWorks_DataDataSet;
            // 
            // adventureWorks_DataDataSet
            // 
            this.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet";
            this.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupNameTextBox1
            // 
            this.groupNameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource1, "GroupName", true));
            this.groupNameTextBox1.Enabled = false;
            this.groupNameTextBox1.Location = new System.Drawing.Point(90, 60);
            this.groupNameTextBox1.Name = "groupNameTextBox1";
            this.groupNameTextBox1.Size = new System.Drawing.Size(200, 20);
            this.groupNameTextBox1.TabIndex = 14;
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource1, "Name", true));
            this.nameTextBox1.Enabled = false;
            this.nameTextBox1.Location = new System.Drawing.Point(90, 34);
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.Size = new System.Drawing.Size(200, 20);
            this.nameTextBox1.TabIndex = 12;
            // 
            // employeeDataGridView1
            // 
            this.employeeDataGridView1.AllowUserToAddRows = false;
            this.employeeDataGridView1.AllowUserToOrderColumns = true;
            this.employeeDataGridView1.AutoGenerateColumns = false;
            this.employeeDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.employeeDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.ContactID,
            this.DepartmentID,
            this.Title});
            this.employeeDataGridView1.DataSource = this.employeeBindingSource1;
            this.employeeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.employeeDataGridView1.Name = "employeeDataGridView1";
            this.employeeDataGridView1.Size = new System.Drawing.Size(528, 263);
            this.employeeDataGridView1.TabIndex = 17;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 92;
            // 
            // ContactID
            // 
            this.ContactID.DataPropertyName = "ContactID";
            this.ContactID.HeaderText = "Contact ID";
            this.ContactID.Name = "ContactID";
            this.ContactID.Width = 83;
            // 
            // DepartmentID
            // 
            this.DepartmentID.DataPropertyName = "DepartmentID";
            this.DepartmentID.HeaderText = "Dept ID";
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.Width = 69;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 52;
            // 
            // employeeBindingSource1
            // 
            this.employeeBindingSource1.DataMember = "FK_Employee_Department_DepartmentID";
            this.employeeBindingSource1.DataSource = this.departmentBindingSource1;
            // 
            // departmentBindingSource1BindingNavigator
            // 
            this.departmentBindingSource1BindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.departmentBindingSource1BindingNavigator.BindingSource = this.departmentBindingSource1;
            this.departmentBindingSource1BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.departmentBindingSource1BindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.departmentBindingSource1BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.departmentBindingSource1BindingNavigator.Location = new System.Drawing.Point(3, 3);
            this.departmentBindingSource1BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.departmentBindingSource1BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.departmentBindingSource1BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.departmentBindingSource1BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.departmentBindingSource1BindingNavigator.Name = "departmentBindingSource1BindingNavigator";
            this.departmentBindingSource1BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.departmentBindingSource1BindingNavigator.Size = new System.Drawing.Size(528, 25);
            this.departmentBindingSource1BindingNavigator.TabIndex = 9;
            this.departmentBindingSource1BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Run time w/ Relations";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(departmentIDLabel);
            this.splitContainer1.Panel1.Controls.Add(this.departmentIDTextBox);
            this.splitContainer1.Panel1.Controls.Add(nameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel1.Controls.Add(groupNameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.groupNameTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.employeeDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(528, 384);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // departmentIDTextBox
            // 
            this.departmentIDTextBox.Enabled = false;
            this.departmentIDTextBox.Location = new System.Drawing.Point(90, 8);
            this.departmentIDTextBox.Name = "departmentIDTextBox";
            this.departmentIDTextBox.Size = new System.Drawing.Size(200, 20);
            this.departmentIDTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(90, 35);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.Enabled = false;
            this.groupNameTextBox.Location = new System.Drawing.Point(90, 62);
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.groupNameTextBox.TabIndex = 5;
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.Size = new System.Drawing.Size(528, 291);
            this.employeeDataGridView.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(534, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Run time w/ Events";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(label1);
            this.splitContainer4.Panel1.Controls.Add(this.departmentIDTextBox2);
            this.splitContainer4.Panel1.Controls.Add(label2);
            this.splitContainer4.Panel1.Controls.Add(this.nameTextBox2);
            this.splitContainer4.Panel1.Controls.Add(label3);
            this.splitContainer4.Panel1.Controls.Add(this.groupNameTextBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.employeeDataGridView2);
            this.splitContainer4.Size = new System.Drawing.Size(534, 390);
            this.splitContainer4.SplitterDistance = 92;
            this.splitContainer4.TabIndex = 0;
            this.splitContainer4.Text = "splitContainer4";
            // 
            // departmentIDTextBox2
            // 
            this.departmentIDTextBox2.Enabled = false;
            this.departmentIDTextBox2.Location = new System.Drawing.Point(93, 11);
            this.departmentIDTextBox2.Name = "departmentIDTextBox2";
            this.departmentIDTextBox2.Size = new System.Drawing.Size(200, 20);
            this.departmentIDTextBox2.TabIndex = 7;
            // 
            // nameTextBox2
            // 
            this.nameTextBox2.Enabled = false;
            this.nameTextBox2.Location = new System.Drawing.Point(93, 38);
            this.nameTextBox2.Name = "nameTextBox2";
            this.nameTextBox2.Size = new System.Drawing.Size(200, 20);
            this.nameTextBox2.TabIndex = 9;
            // 
            // groupNameTextBox2
            // 
            this.groupNameTextBox2.Enabled = false;
            this.groupNameTextBox2.Location = new System.Drawing.Point(93, 65);
            this.groupNameTextBox2.Name = "groupNameTextBox2";
            this.groupNameTextBox2.Size = new System.Drawing.Size(200, 20);
            this.groupNameTextBox2.TabIndex = 11;
            // 
            // employeeDataGridView2
            // 
            this.employeeDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.employeeDataGridView2.Name = "employeeDataGridView2";
            this.employeeDataGridView2.Size = new System.Drawing.Size(534, 294);
            this.employeeDataGridView2.TabIndex = 1;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // employeeTableAdapter1
            // 
            this.employeeTableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creating a Master-Details View";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1BindingNavigator)).EndInit();
            this.departmentBindingSource1BindingNavigator.ResumeLayout(false);
            this.departmentBindingSource1BindingNavigator.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView2)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox departmentIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox groupNameTextBox;
		private System.Windows.Forms.BindingSource employeeBindingSource1;
        private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.DataGridView employeeDataGridView1;
        private System.Windows.Forms.TextBox departmentIDTextBox1;
        private System.Windows.Forms.TextBox groupNameTextBox1;
        private System.Windows.Forms.TextBox nameTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox departmentIDTextBox2;
        private System.Windows.Forms.TextBox nameTextBox2;
		private System.Windows.Forms.TextBox groupNameTextBox2;
		private System.Windows.Forms.BindingNavigator departmentBindingSource1BindingNavigator;
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
		private System.Windows.Forms.DataGridView employeeDataGridView;
		private System.Windows.Forms.DataGridView employeeDataGridView2;
		private System.Windows.Forms.BindingSource departmentBindingSource1;
		private AdventureWorks_DataDataSet adventureWorks_DataDataSet;
		private CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
		private CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
		private CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
    }
}

