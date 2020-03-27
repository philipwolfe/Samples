namespace DrawingAttributes
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
            if (disposing && !isDisposed && inkOverlay != null)
            {
                inkOverlay.Dispose();
                isDisposed = true;
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
            this.antiAliasedCheckBox = new System.Windows.Forms.CheckBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.pressureSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.penTipRectangle = new System.Windows.Forms.RadioButton();
            this.penTipBall = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.transparencyUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // antiAliasedCheckBox
            // 
            this.antiAliasedCheckBox.AutoSize = true;
            this.antiAliasedCheckBox.Checked = true;
            this.antiAliasedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antiAliasedCheckBox.Location = new System.Drawing.Point(13, 13);
            this.antiAliasedCheckBox.Name = "antiAliasedCheckBox";
            this.antiAliasedCheckBox.Size = new System.Drawing.Size(81, 17);
            this.antiAliasedCheckBox.TabIndex = 0;
            this.antiAliasedCheckBox.Text = "Anti-Aliased";
            this.antiAliasedCheckBox.UseVisualStyleBackColor = true;
            this.antiAliasedCheckBox.CheckedChanged += new System.EventHandler(this.SetAttributes);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(13, 37);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pressureSensitiveCheckBox
            // 
            this.pressureSensitiveCheckBox.AutoSize = true;
            this.pressureSensitiveCheckBox.Checked = true;
            this.pressureSensitiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pressureSensitiveCheckBox.Location = new System.Drawing.Point(12, 66);
            this.pressureSensitiveCheckBox.Name = "pressureSensitiveCheckBox";
            this.pressureSensitiveCheckBox.Size = new System.Drawing.Size(113, 17);
            this.pressureSensitiveCheckBox.TabIndex = 2;
            this.pressureSensitiveCheckBox.Text = "Pressure Sensitive";
            this.pressureSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.pressureSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.SetAttributes);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.penTipRectangle);
            this.groupBox1.Controls.Add(this.penTipBall);
            this.groupBox1.Location = new System.Drawing.Point(13, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen Tip";
            // 
            // penTipRectangle
            // 
            this.penTipRectangle.AutoSize = true;
            this.penTipRectangle.Location = new System.Drawing.Point(7, 44);
            this.penTipRectangle.Name = "penTipRectangle";
            this.penTipRectangle.Size = new System.Drawing.Size(74, 17);
            this.penTipRectangle.TabIndex = 1;
            this.penTipRectangle.Text = "Rectangle";
            this.penTipRectangle.UseVisualStyleBackColor = true;
            this.penTipRectangle.CheckedChanged += new System.EventHandler(this.SetAttributes);
            // 
            // penTipBall
            // 
            this.penTipBall.AutoSize = true;
            this.penTipBall.Checked = true;
            this.penTipBall.Location = new System.Drawing.Point(7, 20);
            this.penTipBall.Name = "penTipBall";
            this.penTipBall.Size = new System.Drawing.Size(42, 17);
            this.penTipBall.TabIndex = 0;
            this.penTipBall.TabStop = true;
            this.penTipBall.Text = "Ball";
            this.penTipBall.UseVisualStyleBackColor = true;
            this.penTipBall.CheckedChanged += new System.EventHandler(this.SetAttributes);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transparency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Width";
            // 
            // transparencyUpDown
            // 
            this.transparencyUpDown.Location = new System.Drawing.Point(99, 158);
            this.transparencyUpDown.Name = "transparencyUpDown";
            this.transparencyUpDown.Size = new System.Drawing.Size(120, 20);
            this.transparencyUpDown.TabIndex = 7;
            this.transparencyUpDown.ValueChanged += new System.EventHandler(this.SetAttributes);
            // 
            // heightUpDown
            // 
            this.heightUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightUpDown.Location = new System.Drawing.Point(99, 184);
            this.heightUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightUpDown.Name = "heightUpDown";
            this.heightUpDown.Size = new System.Drawing.Size(120, 20);
            this.heightUpDown.TabIndex = 8;
            this.heightUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.heightUpDown.ValueChanged += new System.EventHandler(this.SetAttributes);
            // 
            // widthUpDown
            // 
            this.widthUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthUpDown.Location = new System.Drawing.Point(99, 210);
            this.widthUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(120, 20);
            this.widthUpDown.TabIndex = 9;
            this.widthUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.widthUpDown.ValueChanged += new System.EventHandler(this.SetAttributes);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(20, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 209);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raster Operation";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(625, 190);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Location = new System.Drawing.Point(256, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 217);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 463);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.heightUpDown);
            this.Controls.Add(this.transparencyUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pressureSensitiveCheckBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.antiAliasedCheckBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox antiAliasedCheckBox;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.CheckBox pressureSensitiveCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton penTipRectangle;
        private System.Windows.Forms.RadioButton penTipBall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown transparencyUpDown;
        private System.Windows.Forms.NumericUpDown heightUpDown;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}

