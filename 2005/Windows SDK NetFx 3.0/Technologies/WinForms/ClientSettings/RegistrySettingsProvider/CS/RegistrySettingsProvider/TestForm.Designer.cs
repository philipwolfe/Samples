namespace Microsoft.Samples.Windows.Forms.RegistrySettingsProvider
{
    partial class formTestForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textTextSetting = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSetting1 = new System.Windows.Forms.CheckBox();
            this.checkSetting2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboIntSetting = new System.Windows.Forms.ComboBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Random Text";
            // 
            // textTextSetting
            // 
            this.textTextSetting.Location = new System.Drawing.Point(90, 9);
            this.textTextSetting.Name = "textTextSetting";
            this.textTextSetting.Size = new System.Drawing.Size(229, 20);
            this.textTextSetting.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSetting1);
            this.groupBox1.Controls.Add(this.checkSetting2);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Random Checkboxes";
            // 
            // checkSetting1
            // 
            this.checkSetting1.AutoSize = true;
            this.checkSetting1.Location = new System.Drawing.Point(8, 23);
            this.checkSetting1.Name = "checkSetting1";
            this.checkSetting1.Size = new System.Drawing.Size(127, 17);
            this.checkSetting1.TabIndex = 0;
            this.checkSetting1.Text = "Random CheckBox &1";
            // 
            // checkSetting2
            // 
            this.checkSetting2.AutoSize = true;
            this.checkSetting2.Location = new System.Drawing.Point(8, 46);
            this.checkSetting2.Name = "checkSetting2";
            this.checkSetting2.Size = new System.Drawing.Size(127, 17);
            this.checkSetting2.TabIndex = 1;
            this.checkSetting2.Text = "Random CheckBox &2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Random Choice:";
            // 
            // comboIntSetting
            // 
            this.comboIntSetting.FormattingEnabled = true;
            this.comboIntSetting.Items.AddRange(new object[] {
            "First Choice",
            "Second Choice",
            "Third Choice"});
            this.comboIntSetting.Location = new System.Drawing.Point(198, 76);
            this.comboIntSetting.Name = "comboIntSetting";
            this.comboIntSetting.Size = new System.Drawing.Size(121, 21);
            this.comboIntSetting.TabIndex = 2;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(91, 123);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(152, 23);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "&Save Settings";
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // formTestForm
            // 
            this.ClientSize = new System.Drawing.Size(328, 156);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.comboIntSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textTextSetting);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "formTestForm";
            this.Text = "RegistrySettingsProvider Sample";
            this.Load += new System.EventHandler(this.formTestForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTextSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSetting1;
        private System.Windows.Forms.CheckBox checkSetting2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboIntSetting;
        private System.Windows.Forms.Button buttonSaveSettings;
    }
}

