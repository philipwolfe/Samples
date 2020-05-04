namespace BE.pinvoke2006
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.label1 = new System.Windows.Forms.Label();
            this.functionTextBox = new System.Windows.Forms.TextBox();
            this.moduleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contentTabControl = new System.Windows.Forms.TabControl();
            this.insertButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.languageCombo = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.pinvokelogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pinvokelogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What function do you need?";
            // 
            // functionTextBox
            // 
            this.functionTextBox.Location = new System.Drawing.Point(16, 72);
            this.functionTextBox.Name = "functionTextBox";
            this.functionTextBox.Size = new System.Drawing.Size(268, 21);
            this.functionTextBox.TabIndex = 1;
            // 
            // moduleTextBox
            // 
            this.moduleTextBox.Location = new System.Drawing.Point(303, 72);
            this.moduleTextBox.Name = "moduleTextBox";
            this.moduleTextBox.Size = new System.Drawing.Size(268, 21);
            this.moduleTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "What module does it live in?";
            // 
            // contentTabControl
            // 
            this.contentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTabControl.Location = new System.Drawing.Point(16, 118);
            this.contentTabControl.Name = "contentTabControl";
            this.contentTabControl.SelectedIndex = 0;
            this.contentTabControl.Size = new System.Drawing.Size(744, 413);
            this.contentTabControl.TabIndex = 4;
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.Enabled = false;
            this.insertButton.Location = new System.Drawing.Point(602, 537);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 5;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(683, 537);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // btnGo
            // 
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Image = global::BE.pinvoke2006.Properties.Resources.go;
            this.btnGo.Location = new System.Drawing.Point(589, 56);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(54, 37);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // languageCombo
            // 
            this.languageCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCombo.FormattingEnabled = true;
            this.languageCombo.Location = new System.Drawing.Point(600, 111);
            this.languageCombo.Name = "languageCombo";
            this.languageCombo.Size = new System.Drawing.Size(158, 21);
            this.languageCombo.TabIndex = 8;
            this.languageCombo.Visible = false;
            this.languageCombo.SelectedIndexChanged += new System.EventHandler(this.languageCombo_SelectedIndexChanged);
            // 
            // languageLabel
            // 
            this.languageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageLabel.Location = new System.Drawing.Point(502, 114);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(92, 13);
            this.languageLabel.TabIndex = 9;
            this.languageLabel.Text = "Language";
            this.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.languageLabel.Visible = false;
            // 
            // pinvokelogo
            // 
            this.pinvokelogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pinvokelogo.Image = global::BE.pinvoke2006.Properties.Resources.pinvokelogo;
            this.pinvokelogo.Location = new System.Drawing.Point(16, 4);
            this.pinvokelogo.Name = "pinvokelogo";
            this.pinvokelogo.Size = new System.Drawing.Size(203, 38);
            this.pinvokelogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pinvokelogo.TabIndex = 10;
            this.pinvokelogo.TabStop = false;
            this.toolTip.SetToolTip(this.pinvokelogo, "Go to www.pinvoke.net");
            this.pinvokelogo.Click += new System.EventHandler(this.pinvokelogo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.pinvokelogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 53);
            this.panel1.TabIndex = 11;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.Location = new System.Drawing.Point(101, 534);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(238, 33);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here for more information, \r\nsuch as sample code or type definitions";
            this.toolTip.SetToolTip(this.linkLabel1, "Go to www.pinvoke.net");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // logoBox
            // 
            this.logoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoBox.Image = global::BE.pinvoke2006.Properties.Resources.logo;
            this.logoBox.Location = new System.Drawing.Point(16, 539);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(79, 15);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoBox.TabIndex = 11;
            this.logoBox.TabStop = false;
            this.toolTip.SetToolTip(this.logoBox, "Go to www.pinvoke.net");
            this.logoBox.Click += new System.EventHandler(this.pinvokelogo_Click);
            // 
            // DownloadForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(772, 566);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.languageCombo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.contentTabControl);
            this.Controls.Add(this.moduleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.functionTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bernhard Elbl´s pinvoke.net Add-In | Insert PInvoke Signatures";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pinvokelogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox functionTextBox;
        private System.Windows.Forms.TextBox moduleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl contentTabControl;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox languageCombo;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.PictureBox pinvokelogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}