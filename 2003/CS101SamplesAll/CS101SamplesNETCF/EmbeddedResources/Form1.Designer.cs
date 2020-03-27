namespace EmbeddedResources
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Thumb4PictureBox = new System.Windows.Forms.PictureBox();
            this.Thumb3PictureBox = new System.Windows.Forms.PictureBox();
            this.Thumb2PictureBox = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.Thumb1PictureBox = new System.Windows.Forms.PictureBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(5, 239);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(231, 20);
            this.Label1.Text = "Click on thumbnail to see in viewer.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Thumb4PictureBox
            // 
            this.Thumb4PictureBox.Location = new System.Drawing.Point(180, 175);
            this.Thumb4PictureBox.Name = "Thumb4PictureBox";
            this.Thumb4PictureBox.Size = new System.Drawing.Size(50, 50);
            this.Thumb4PictureBox.Click += new System.EventHandler(this.Thumb4PictureBox_Click);
            // 
            // Thumb3PictureBox
            // 
            this.Thumb3PictureBox.Location = new System.Drawing.Point(124, 175);
            this.Thumb3PictureBox.Name = "Thumb3PictureBox";
            this.Thumb3PictureBox.Size = new System.Drawing.Size(50, 50);
            this.Thumb3PictureBox.Click += new System.EventHandler(this.Thumb3PictureBox_Click);
            // 
            // Thumb2PictureBox
            // 
            this.Thumb2PictureBox.Location = new System.Drawing.Point(65, 175);
            this.Thumb2PictureBox.Name = "Thumb2PictureBox";
            this.Thumb2PictureBox.Size = new System.Drawing.Size(50, 50);
            this.Thumb2PictureBox.Click += new System.EventHandler(this.Thumb2PictureBox_Click);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Black;
            this.MainPictureBox.Location = new System.Drawing.Point(5, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(210, 150);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // Thumb1PictureBox
            // 
            this.Thumb1PictureBox.Location = new System.Drawing.Point(9, 175);
            this.Thumb1PictureBox.Name = "Thumb1PictureBox";
            this.Thumb1PictureBox.Size = new System.Drawing.Size(50, 50);
            this.Thumb1PictureBox.Click += new System.EventHandler(this.Thumb1PictureBox_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Black;
            this.Panel1.Controls.Add(this.MainPictureBox);
            this.Panel1.Location = new System.Drawing.Point(9, 9);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(220, 160);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Thumb4PictureBox);
            this.Controls.Add(this.Thumb3PictureBox);
            this.Controls.Add(this.Thumb2PictureBox);
            this.Controls.Add(this.Thumb1PictureBox);
            this.Controls.Add(this.Panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox Thumb4PictureBox;
        internal System.Windows.Forms.PictureBox Thumb3PictureBox;
        internal System.Windows.Forms.PictureBox Thumb2PictureBox;
        private System.Windows.Forms.MainMenu mainMenu1;
        internal System.Windows.Forms.PictureBox MainPictureBox;
        internal System.Windows.Forms.PictureBox Thumb1PictureBox;
        internal System.Windows.Forms.Panel Panel1;
    }
}

