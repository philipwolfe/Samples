namespace ClientConfiguration
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
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.appSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.appStringTextBox = new System.Windows.Forms.TextBox();
			this.appIntNumPicker = new System.Windows.Forms.NumericUpDown();
			this.userIdentityTextBox = new System.Windows.Forms.TextBox();
			this.userSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.userIntNumPicker = new System.Windows.Forms.NumericUpDown();
			this.setUserIntDefaultButton = new System.Windows.Forms.Button();
			this.userStringTextBox = new System.Windows.Forms.TextBox();
			this.setUserStringDefaultButton = new System.Windows.Forms.Button();
			this.setCheckBox1DefaultButton = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.setComboBoxDefaultButton = new System.Windows.Forms.Button();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.appSettingsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.appIntNumPicker)).BeginInit();
			this.userSettingsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.userIntNumPicker)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.appSettingsGroupBox);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.userIdentityTextBox);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.userSettingsGroupBox);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(542, 416);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// appSettingsGroupBox
			// 
			this.appSettingsGroupBox.Controls.Add(this.appStringTextBox);
			this.appSettingsGroupBox.Controls.Add(this.appIntNumPicker);
			this.appSettingsGroupBox.Location = new System.Drawing.Point(140, 87);
			this.appSettingsGroupBox.Name = "appSettingsGroupBox";
			this.appSettingsGroupBox.Size = new System.Drawing.Size(265, 77);
			this.appSettingsGroupBox.TabIndex = 25;
			this.appSettingsGroupBox.TabStop = false;
			this.appSettingsGroupBox.Text = "Application-Scoped (changes do not persist)";
			// 
			// appStringTextBox
			// 
			this.appStringTextBox.Location = new System.Drawing.Point(28, 19);
			this.appStringTextBox.Name = "appStringTextBox";
			this.appStringTextBox.Size = new System.Drawing.Size(209, 20);
			this.appStringTextBox.TabIndex = 29;
			// 
			// appIntNumPicker
			// 
			this.appIntNumPicker.Location = new System.Drawing.Point(29, 45);
			this.appIntNumPicker.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.appIntNumPicker.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.appIntNumPicker.Name = "appIntNumPicker";
			this.appIntNumPicker.Size = new System.Drawing.Size(38, 20);
			this.appIntNumPicker.TabIndex = 30;
			this.appIntNumPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// userIdentityTextBox
			// 
			this.userIdentityTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.userIdentityTextBox.Location = new System.Drawing.Point(217, 42);
			this.userIdentityTextBox.Name = "userIdentityTextBox";
			this.userIdentityTextBox.ReadOnly = true;
			this.userIdentityTextBox.Size = new System.Drawing.Size(160, 20);
			this.userIdentityTextBox.TabIndex = 24;
			// 
			// userSettingsGroupBox
			// 
			this.userSettingsGroupBox.Controls.Add(this.setComboBoxDefaultButton);
			this.userSettingsGroupBox.Controls.Add(this.comboBox1);
			this.userSettingsGroupBox.Controls.Add(this.userIntNumPicker);
			this.userSettingsGroupBox.Controls.Add(this.setUserIntDefaultButton);
			this.userSettingsGroupBox.Controls.Add(this.userStringTextBox);
			this.userSettingsGroupBox.Controls.Add(this.setUserStringDefaultButton);
			this.userSettingsGroupBox.Controls.Add(this.setCheckBox1DefaultButton);
			this.userSettingsGroupBox.Controls.Add(this.checkBox1);
			this.userSettingsGroupBox.Location = new System.Drawing.Point(142, 189);
			this.userSettingsGroupBox.Name = "userSettingsGroupBox";
			this.userSettingsGroupBox.Size = new System.Drawing.Size(265, 152);
			this.userSettingsGroupBox.TabIndex = 23;
			this.userSettingsGroupBox.TabStop = false;
			this.userSettingsGroupBox.Text = "User-Scoped";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Lorem",
            "ipsum",
            "dolor",
            "sit",
            "amet",
            "consectetuer",
            "adipiscing",
            "elit"});
			this.comboBox1.Location = new System.Drawing.Point(28, 104);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 26;
			// 
			// userIntNumPicker
			// 
			this.userIntNumPicker.Location = new System.Drawing.Point(28, 75);
			this.userIntNumPicker.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.userIntNumPicker.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.userIntNumPicker.Name = "userIntNumPicker";
			this.userIntNumPicker.Size = new System.Drawing.Size(42, 20);
			this.userIntNumPicker.TabIndex = 25;
			// 
			// setUserIntDefaultButton
			// 
			this.setUserIntDefaultButton.Location = new System.Drawing.Point(155, 75);
			this.setUserIntDefaultButton.Name = "setUserIntDefaultButton";
			this.setUserIntDefaultButton.Size = new System.Drawing.Size(81, 23);
			this.setUserIntDefaultButton.TabIndex = 24;
			this.setUserIntDefaultButton.Text = "Set as Default";
			this.setUserIntDefaultButton.Click += new System.EventHandler(this.setUserIntDefaultButton_Click);
			// 
			// userStringTextBox
			// 
			this.userStringTextBox.Location = new System.Drawing.Point(28, 46);
			this.userStringTextBox.Name = "userStringTextBox";
			this.userStringTextBox.Size = new System.Drawing.Size(121, 20);
			this.userStringTextBox.TabIndex = 22;
			// 
			// setUserStringDefaultButton
			// 
			this.setUserStringDefaultButton.Location = new System.Drawing.Point(155, 46);
			this.setUserStringDefaultButton.Name = "setUserStringDefaultButton";
			this.setUserStringDefaultButton.Size = new System.Drawing.Size(81, 23);
			this.setUserStringDefaultButton.TabIndex = 21;
			this.setUserStringDefaultButton.Text = "Set as Default";
			this.setUserStringDefaultButton.Click += new System.EventHandler(this.setUserStringDefaultButton_Click);
			// 
			// setCheckBox1DefaultButton
			// 
			this.setCheckBox1DefaultButton.Location = new System.Drawing.Point(155, 19);
			this.setCheckBox1DefaultButton.Name = "setCheckBox1DefaultButton";
			this.setCheckBox1DefaultButton.Size = new System.Drawing.Size(81, 23);
			this.setCheckBox1DefaultButton.TabIndex = 20;
			this.setCheckBox1DefaultButton.Text = "Set as Default";
			this.setCheckBox1DefaultButton.Click += new System.EventHandler(this.setCheckBox1DefaultButton_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(28, 23);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(76, 17);
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "checkBox1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(148, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Current user:";
			// 
			// toolStrip1
			// 
			this.toolStrip1.AllowItemReorder = true;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(542, 25);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			this.toolTip1.SetToolTip(this.toolStrip1, "Move and resize the ToolStrip, then restart the sample the changes persisted.");
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// setComboBoxDefaultButton
			// 
			this.setComboBoxDefaultButton.Location = new System.Drawing.Point(155, 104);
			this.setComboBoxDefaultButton.Name = "setComboBoxDefaultButton";
			this.setComboBoxDefaultButton.Size = new System.Drawing.Size(81, 23);
			this.setComboBoxDefaultButton.TabIndex = 27;
			this.setComboBoxDefaultButton.Text = "Set as Default";
			this.setComboBoxDefaultButton.Click += new System.EventHandler(this.setComboBoxDefaultButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 416);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Client Configuration";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.appSettingsGroupBox.ResumeLayout(false);
			this.appSettingsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.appIntNumPicker)).EndInit();
			this.userSettingsGroupBox.ResumeLayout(false);
			this.userSettingsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.userIntNumPicker)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.GroupBox appSettingsGroupBox;
		private System.Windows.Forms.TextBox appStringTextBox;
		private System.Windows.Forms.NumericUpDown appIntNumPicker;
		private System.Windows.Forms.TextBox userIdentityTextBox;
		private System.Windows.Forms.GroupBox userSettingsGroupBox;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.NumericUpDown userIntNumPicker;
		private System.Windows.Forms.Button setUserIntDefaultButton;
		private System.Windows.Forms.TextBox userStringTextBox;
		private System.Windows.Forms.Button setUserStringDefaultButton;
		private System.Windows.Forms.Button setCheckBox1DefaultButton;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button setComboBoxDefaultButton;
    }
}

