namespace PlatformInvoke
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
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.BottomRightYUpDown = new System.Windows.Forms.NumericUpDown();
            this.BottomRightXUpDown = new System.Windows.Forms.NumericUpDown();
            this.TopLeftYUpDown = new System.Windows.Forms.NumericUpDown();
            this.TopLeftXUpDown = new System.Windows.Forms.NumericUpDown();
            this.CalcAreaCallBackButton = new System.Windows.Forms.Button();
            this.CalcAreaLabel = new System.Windows.Forms.Label();
            this.CalcAreaButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftXUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(18, 22);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(37, 13);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "Area:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(21, 199);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(419, 13);
            this.Label5.TabIndex = 44;
            this.Label5.Text = "Send Rectangle to Unmanaged DLL method and have callback return calculated Area.";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(21, 141);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(354, 13);
            this.Label4.TabIndex = 43;
            this.Label4.Text = "Send Rectangle to Unmanaged DLL method that returns calculated Area.";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.AreaLabel);
            this.Panel1.Location = new System.Drawing.Point(169, 26);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(132, 65);
            this.Panel1.TabIndex = 42;
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(57, 22);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(13, 13);
            this.AreaLabel.TabIndex = 25;
            this.AreaLabel.Text = "0";
            // 
            // BottomRightYUpDown
            // 
            this.BottomRightYUpDown.Location = new System.Drawing.Point(421, 92);
            this.BottomRightYUpDown.Name = "BottomRightYUpDown";
            this.BottomRightYUpDown.Size = new System.Drawing.Size(40, 20);
            this.BottomRightYUpDown.TabIndex = 41;
            // 
            // BottomRightXUpDown
            // 
            this.BottomRightXUpDown.Location = new System.Drawing.Point(375, 92);
            this.BottomRightXUpDown.Name = "BottomRightXUpDown";
            this.BottomRightXUpDown.Size = new System.Drawing.Size(40, 20);
            this.BottomRightXUpDown.TabIndex = 40;
            // 
            // TopLeftYUpDown
            // 
            this.TopLeftYUpDown.Location = new System.Drawing.Point(123, 7);
            this.TopLeftYUpDown.Name = "TopLeftYUpDown";
            this.TopLeftYUpDown.Size = new System.Drawing.Size(40, 20);
            this.TopLeftYUpDown.TabIndex = 39;
            // 
            // TopLeftXUpDown
            // 
            this.TopLeftXUpDown.Location = new System.Drawing.Point(78, 7);
            this.TopLeftXUpDown.Name = "TopLeftXUpDown";
            this.TopLeftXUpDown.Size = new System.Drawing.Size(40, 20);
            this.TopLeftXUpDown.TabIndex = 38;
            // 
            // CalcAreaCallBackButton
            // 
            this.CalcAreaCallBackButton.Location = new System.Drawing.Point(24, 215);
            this.CalcAreaCallBackButton.Name = "CalcAreaCallBackButton";
            this.CalcAreaCallBackButton.Size = new System.Drawing.Size(106, 23);
            this.CalcAreaCallBackButton.TabIndex = 35;
            this.CalcAreaCallBackButton.Text = "Calc Area Callback";
            this.CalcAreaCallBackButton.UseVisualStyleBackColor = true;
            this.CalcAreaCallBackButton.Click += new System.EventHandler(this.CalcAreaCallBackButton_Click);
            // 
            // CalcAreaLabel
            // 
            this.CalcAreaLabel.AutoSize = true;
            this.CalcAreaLabel.Location = new System.Drawing.Point(136, 162);
            this.CalcAreaLabel.Name = "CalcAreaLabel";
            this.CalcAreaLabel.Size = new System.Drawing.Size(13, 13);
            this.CalcAreaLabel.TabIndex = 34;
            this.CalcAreaLabel.Text = "0";
            // 
            // CalcAreaButton
            // 
            this.CalcAreaButton.Location = new System.Drawing.Point(24, 157);
            this.CalcAreaButton.Name = "CalcAreaButton";
            this.CalcAreaButton.Size = new System.Drawing.Size(106, 23);
            this.CalcAreaButton.TabIndex = 33;
            this.CalcAreaButton.Text = "Calc Area";
            this.CalcAreaButton.UseVisualStyleBackColor = true;
            this.CalcAreaButton.Click += new System.EventHandler(this.CalcAreaButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(301, 94);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 13);
            this.Label2.TabIndex = 37;
            this.Label2.Text = "BottomLeft:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(21, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 36;
            this.Label1.Text = "TopLeft:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 286);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.BottomRightYUpDown);
            this.Controls.Add(this.BottomRightXUpDown);
            this.Controls.Add(this.TopLeftYUpDown);
            this.Controls.Add(this.TopLeftXUpDown);
            this.Controls.Add(this.CalcAreaCallBackButton);
            this.Controls.Add(this.CalcAreaLabel);
            this.Controls.Add(this.CalcAreaButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftXUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label AreaLabel;
        internal System.Windows.Forms.NumericUpDown BottomRightYUpDown;
        internal System.Windows.Forms.NumericUpDown BottomRightXUpDown;
        internal System.Windows.Forms.NumericUpDown TopLeftYUpDown;
        internal System.Windows.Forms.NumericUpDown TopLeftXUpDown;
        internal System.Windows.Forms.Button CalcAreaCallBackButton;
        internal System.Windows.Forms.Label CalcAreaLabel;
        internal System.Windows.Forms.Button CalcAreaButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

