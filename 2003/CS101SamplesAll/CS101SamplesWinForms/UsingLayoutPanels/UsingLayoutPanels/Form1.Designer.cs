namespace UsingLayoutPanels
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.TableTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.FirstNameLabel = new System.Windows.Forms.Label();
			this.FirstName = new System.Windows.Forms.TextBox();
			this.LastNameLabel = new System.Windows.Forms.Label();
			this.LastName = new System.Windows.Forms.TextBox();
			this.BiographyLabel = new System.Windows.Forms.Label();
			this.Biography = new System.Windows.Forms.TextBox();
			this.DepartmentLabel = new System.Windows.Forms.Label();
			this.Departments = new System.Windows.Forms.ComboBox();
			this.tableLabel = new System.Windows.Forms.Label();
			this.TableToolStrip = new System.Windows.Forms.ToolStrip();
			this.cellBorderStyleDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.noneBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.singleBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insetBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outsetBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FlowTabPage = new System.Windows.Forms.TabPage();
			this.LayoutToolStrip = new System.Windows.Forms.ToolStrip();
			this.flowDirectionDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLabel = new System.Windows.Forms.Label();
			this.UserInfo = new System.Windows.Forms.GroupBox();
			this.DepartmentInfo = new System.Windows.Forms.GroupBox();
			this.SalesForcastInfo = new System.Windows.Forms.GroupBox();
			this.tabControl1.SuspendLayout();
			this.TableTabPage.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.TableToolStrip.SuspendLayout();
			this.FlowTabPage.SuspendLayout();
			this.LayoutToolStrip.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.TableTabPage);
			this.tabControl1.Controls.Add(this.FlowTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(542, 416);
			this.tabControl1.TabIndex = 0;
			// 
			// TableTabPage
			// 
			this.TableTabPage.Controls.Add(this.tableLayoutPanel1);
			this.TableTabPage.Controls.Add(this.TableToolStrip);
			this.TableTabPage.Location = new System.Drawing.Point(4, 22);
			this.TableTabPage.Name = "TableTabPage";
			this.TableTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.TableTabPage.Size = new System.Drawing.Size(534, 390);
			this.TableTabPage.TabIndex = 0;
			this.TableTabPage.Text = "TableLayoutPanel";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.FirstNameLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.FirstName, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.LastNameLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.LastName, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.BiographyLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.Biography, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.DepartmentLabel, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.Departments, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLabel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 359);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// FirstNameLabel
			// 
			this.FirstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.FirstNameLabel.AutoSize = true;
			this.FirstNameLabel.Location = new System.Drawing.Point(3, 65);
			this.FirstNameLabel.Name = "FirstNameLabel";
			this.FirstNameLabel.Size = new System.Drawing.Size(56, 13);
			this.FirstNameLabel.TabIndex = 0;
			this.FirstNameLabel.Text = "First Name:";
			// 
			// FirstName
			// 
			this.FirstName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FirstName.Location = new System.Drawing.Point(103, 61);
			this.FirstName.Name = "FirstName";
			this.FirstName.Size = new System.Drawing.Size(98, 20);
			this.FirstName.TabIndex = 1;
			// 
			// LastNameLabel
			// 
			this.LastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LastNameLabel.AutoSize = true;
			this.LastNameLabel.Location = new System.Drawing.Point(3, 91);
			this.LastNameLabel.Name = "LastNameLabel";
			this.LastNameLabel.Size = new System.Drawing.Size(57, 13);
			this.LastNameLabel.TabIndex = 2;
			this.LastNameLabel.Text = "Last Name:";
			// 
			// LastName
			// 
			this.LastName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LastName.Location = new System.Drawing.Point(103, 88);
			this.LastName.Name = "LastName";
			this.LastName.Size = new System.Drawing.Size(98, 20);
			this.LastName.TabIndex = 3;
			// 
			// BiographyLabel
			// 
			this.BiographyLabel.AutoSize = true;
			this.BiographyLabel.Location = new System.Drawing.Point(3, 111);
			this.BiographyLabel.Name = "BiographyLabel";
			this.BiographyLabel.Size = new System.Drawing.Size(53, 13);
			this.BiographyLabel.TabIndex = 4;
			this.BiographyLabel.Text = "Biography:";
			// 
			// Biography
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.Biography, 3);
			this.Biography.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Biography.Location = new System.Drawing.Point(103, 114);
			this.Biography.Multiline = true;
			this.Biography.Name = "Biography";
			this.Biography.Size = new System.Drawing.Size(302, 242);
			this.Biography.TabIndex = 5;
			// 
			// DepartmentLabel
			// 
			this.DepartmentLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.DepartmentLabel.AutoSize = true;
			this.DepartmentLabel.Location = new System.Drawing.Point(207, 65);
			this.DepartmentLabel.Name = "DepartmentLabel";
			this.DepartmentLabel.Size = new System.Drawing.Size(61, 13);
			this.DepartmentLabel.TabIndex = 6;
			this.DepartmentLabel.Text = "Department:";
			// 
			// Departments
			// 
			this.Departments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Departments.FormattingEnabled = true;
			this.Departments.Location = new System.Drawing.Point(307, 61);
			this.Departments.Name = "Departments";
			this.Departments.Size = new System.Drawing.Size(98, 21);
			this.Departments.TabIndex = 7;
			// 
			// tableLabel
			// 
			this.tableLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLabel, 4);
			this.tableLabel.Location = new System.Drawing.Point(3, 0);
			this.tableLabel.Name = "tableLabel";
			this.tableLabel.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.tableLabel.Size = new System.Drawing.Size(398, 58);
			this.tableLabel.TabIndex = 8;
			this.tableLabel.Text = resources.GetString("tableLabel.Text");
			// 
			// TableToolStrip
			// 
			this.TableToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cellBorderStyleDropDown});
			this.TableToolStrip.Location = new System.Drawing.Point(3, 3);
			this.TableToolStrip.Name = "TableToolStrip";
			this.TableToolStrip.Size = new System.Drawing.Size(528, 25);
			this.TableToolStrip.TabIndex = 0;
			this.TableToolStrip.Text = "TableToolStrip";
			// 
			// cellBorderStyleDropDown
			// 
			this.cellBorderStyleDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cellBorderStyleDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneBorderToolStripMenuItem,
            this.singleBorderToolStripMenuItem,
            this.insetBorderToolStripMenuItem,
            this.outsetBorderToolStripMenuItem});
			this.cellBorderStyleDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cellBorderStyleDropDown.Image")));
			this.cellBorderStyleDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cellBorderStyleDropDown.Name = "cellBorderStyleDropDown";
			this.cellBorderStyleDropDown.Text = "Cell Border";
			// 
			// noneBorderToolStripMenuItem
			// 
			this.noneBorderToolStripMenuItem.Name = "noneBorderToolStripMenuItem";
			this.noneBorderToolStripMenuItem.Text = "None";
			this.noneBorderToolStripMenuItem.Click += new System.EventHandler(this.borderStyleToolStripMenuItem_Click);
			// 
			// singleBorderToolStripMenuItem
			// 
			this.singleBorderToolStripMenuItem.Name = "singleBorderToolStripMenuItem";
			this.singleBorderToolStripMenuItem.Text = "Single";
			this.singleBorderToolStripMenuItem.Click += new System.EventHandler(this.borderStyleToolStripMenuItem_Click);
			// 
			// insetBorderToolStripMenuItem
			// 
			this.insetBorderToolStripMenuItem.Name = "insetBorderToolStripMenuItem";
			this.insetBorderToolStripMenuItem.Text = "Inset";
			this.insetBorderToolStripMenuItem.Click += new System.EventHandler(this.borderStyleToolStripMenuItem_Click);
			// 
			// outsetBorderToolStripMenuItem
			// 
			this.outsetBorderToolStripMenuItem.Name = "outsetBorderToolStripMenuItem";
			this.outsetBorderToolStripMenuItem.Text = "Outset";
			this.outsetBorderToolStripMenuItem.Click += new System.EventHandler(this.borderStyleToolStripMenuItem_Click);
			// 
			// FlowTabPage
			// 
			this.FlowTabPage.Controls.Add(this.LayoutToolStrip);
			this.FlowTabPage.Controls.Add(this.flowLayoutPanel1);
			this.FlowTabPage.Location = new System.Drawing.Point(4, 22);
			this.FlowTabPage.Name = "FlowTabPage";
			this.FlowTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.FlowTabPage.Size = new System.Drawing.Size(534, 390);
			this.FlowTabPage.TabIndex = 1;
			this.FlowTabPage.Text = "FlowLayoutPanel";
			// 
			// LayoutToolStrip
			// 
			this.LayoutToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flowDirectionDropDown,
            this.toolStripSeparator3});
			this.LayoutToolStrip.Location = new System.Drawing.Point(3, 3);
			this.LayoutToolStrip.Name = "LayoutToolStrip";
			this.LayoutToolStrip.Size = new System.Drawing.Size(528, 25);
			this.LayoutToolStrip.TabIndex = 0;
			this.LayoutToolStrip.Text = "toolStrip1";
			// 
			// flowDirectionDropDown
			// 
			this.flowDirectionDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.flowDirectionDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
			this.flowDirectionDropDown.Image = ((System.Drawing.Image)(resources.GetObject("flowDirectionDropDown.Image")));
			this.flowDirectionDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.flowDirectionDropDown.Name = "flowDirectionDropDown";
			this.flowDirectionDropDown.Text = "Flow Direction";
			// 
			// horizontalToolStripMenuItem
			// 
			this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
			this.horizontalToolStripMenuItem.Text = "Horizontal";
			this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
			// 
			// verticalToolStripMenuItem
			// 
			this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
			this.verticalToolStripMenuItem.Text = "Vertical";
			this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.flowLabel);
			this.flowLayoutPanel1.Controls.Add(this.UserInfo);
			this.flowLayoutPanel1.Controls.Add(this.DepartmentInfo);
			this.flowLayoutPanel1.Controls.Add(this.SalesForcastInfo);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 300, 3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 384);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// flowLabel
			// 
			this.flowLabel.AutoSize = true;
			this.flowLabel.Location = new System.Drawing.Point(3, 25);
			this.flowLabel.Name = "flowLabel";
			this.flowLabel.Size = new System.Drawing.Size(515, 39);
			this.flowLabel.TabIndex = 3;
			this.flowLabel.Text = resources.GetString("flowLabel.Text");
			// 
			// UserInfo
			// 
			this.UserInfo.Location = new System.Drawing.Point(3, 67);
			this.UserInfo.Name = "UserInfo";
			this.UserInfo.Size = new System.Drawing.Size(146, 65);
			this.UserInfo.TabIndex = 0;
			this.UserInfo.TabStop = false;
			this.UserInfo.Text = "User Information";
			// 
			// DepartmentInfo
			// 
			this.DepartmentInfo.Location = new System.Drawing.Point(155, 67);
			this.DepartmentInfo.Name = "DepartmentInfo";
			this.DepartmentInfo.Size = new System.Drawing.Size(111, 65);
			this.DepartmentInfo.TabIndex = 1;
			this.DepartmentInfo.TabStop = false;
			this.DepartmentInfo.Text = "Department";
			// 
			// SalesForcastInfo
			// 
			this.SalesForcastInfo.Location = new System.Drawing.Point(3, 138);
			this.SalesForcastInfo.Name = "SalesForcastInfo";
			this.SalesForcastInfo.Size = new System.Drawing.Size(356, 141);
			this.SalesForcastInfo.TabIndex = 2;
			this.SalesForcastInfo.TabStop = false;
			this.SalesForcastInfo.Text = "Sales Forecast";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 416);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Using Layout Panels";
			this.tabControl1.ResumeLayout(false);
			this.TableTabPage.ResumeLayout(false);
			this.TableTabPage.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.TableToolStrip.ResumeLayout(false);
			this.FlowTabPage.ResumeLayout(false);
			this.FlowTabPage.PerformLayout();
			this.LayoutToolStrip.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TableTabPage;
        private System.Windows.Forms.TabPage FlowTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip LayoutToolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripDropDownButton flowDirectionDropDown;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label BiographyLabel;
        private System.Windows.Forms.TextBox Biography;
        private System.Windows.Forms.Label DepartmentLabel;
        private System.Windows.Forms.ComboBox Departments;
        private System.Windows.Forms.Label tableLabel;
        private System.Windows.Forms.GroupBox UserInfo;
        private System.Windows.Forms.GroupBox DepartmentInfo;
        private System.Windows.Forms.GroupBox SalesForcastInfo;
        private System.Windows.Forms.ToolStrip TableToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton cellBorderStyleDropDown;
        private System.Windows.Forms.ToolStripMenuItem singleBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insetBorderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outsetBorderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem noneBorderToolStripMenuItem;
		private System.Windows.Forms.Label flowLabel;
    }
}

