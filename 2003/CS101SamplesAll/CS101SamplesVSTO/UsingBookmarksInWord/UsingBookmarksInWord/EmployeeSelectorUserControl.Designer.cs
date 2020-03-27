namespace UsingBookmarksInWord
{
    partial class EmployeeSelectorUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label jobTitleLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSelectorUserControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jobTitleTextBox = new System.Windows.Forms.TextBox();
            this.vEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adventureWorks_DataDataSet = new UsingBookmarksInWord.AdventureWorks_DataDataSet();
            this.selectButton = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.vEmployeeTableAdapter = new UsingBookmarksInWord.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter();
            this.vEmployeeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            lastNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            jobTitleLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingNavigator)).BeginInit();
            this.vEmployeeBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // lastNameLabel
            // 
            lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(20, 29);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 0;
            lastNameLabel.Text = "Last Name:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(21, 55);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // jobTitleLabel
            // 
            jobTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            jobTitleLabel.AutoSize = true;
            jobTitleLabel.Location = new System.Drawing.Point(31, 81);
            jobTitleLabel.Name = "jobTitleLabel";
            jobTitleLabel.Size = new System.Drawing.Size(50, 13);
            jobTitleLabel.TabIndex = 5;
            jobTitleLabel.Text = "Job Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(jobTitleLabel);
            this.groupBox1.Controls.Add(this.jobTitleTextBox);
            this.groupBox1.Controls.Add(this.selectButton);
            this.groupBox1.Controls.Add(firstNameLabel);
            this.groupBox1.Controls.Add(this.firstNameTextBox);
            this.groupBox1.Controls.Add(lastNameLabel);
            this.groupBox1.Controls.Add(this.lastNameTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select an employee";
            // 
            // jobTitleTextBox
            // 
            this.jobTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.jobTitleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vEmployeeBindingSource, "JobTitle", true));
            this.jobTitleTextBox.Location = new System.Drawing.Point(87, 78);
            this.jobTitleTextBox.Name = "jobTitleTextBox";
            this.jobTitleTextBox.ReadOnly = true;
            this.jobTitleTextBox.Size = new System.Drawing.Size(100, 20);
            this.jobTitleTextBox.TabIndex = 6;
            // 
            // vEmployeeBindingSource
            // 
            this.vEmployeeBindingSource.DataMember = "vEmployee";
            this.vEmployeeBindingSource.DataSource = this.adventureWorks_DataDataSet;
            // 
            // adventureWorks_DataDataSet
            // 
            this.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet";
            this.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // selectButton
            // 
            this.selectButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.selectButton.Location = new System.Drawing.Point(67, 104);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vEmployeeBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(87, 52);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.ReadOnly = true;
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 3;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vEmployeeBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(87, 26);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.ReadOnly = true;
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 1;
            // 
            // vEmployeeTableAdapter
            // 
            this.vEmployeeTableAdapter.ClearBeforeFill = true;
            // 
            // vEmployeeBindingNavigator
            // 
            this.vEmployeeBindingNavigator.AddNewItem = null;
            this.vEmployeeBindingNavigator.BindingSource = this.vEmployeeBindingSource;
            this.vEmployeeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.vEmployeeBindingNavigator.DeleteItem = null;
            this.vEmployeeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.vEmployeeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.vEmployeeBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.vEmployeeBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.vEmployeeBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.vEmployeeBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.vEmployeeBindingNavigator.Name = "vEmployeeBindingNavigator";
            this.vEmployeeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.vEmployeeBindingNavigator.Size = new System.Drawing.Size(208, 25);
            this.vEmployeeBindingNavigator.TabIndex = 1;
            this.vEmployeeBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
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
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 20);
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
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // EmployeeSelectorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vEmployeeBindingNavigator);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeeSelectorUserControl";
            this.Size = new System.Drawing.Size(208, 168);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingNavigator)).EndInit();
            this.vEmployeeBindingNavigator.ResumeLayout(false);
            this.vEmployeeBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.BindingSource vEmployeeBindingSource;
        private AdventureWorks_DataDataSet adventureWorks_DataDataSet;
        private UsingBookmarksInWord.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter vEmployeeTableAdapter;
        private System.Windows.Forms.BindingNavigator vEmployeeBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox jobTitleTextBox;
        public System.Windows.Forms.Button selectButton;
    }
}
