namespace CreatingSetupCAB
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ReadRegistryButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(0, 157);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(240, 59);
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(240, 59);
            this.Label1.Text = "Tap the \"Read Registry\" button below to display the registry settings written by " +
                "the CAB file";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(0, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(236, 152);
            this.Label4.Text = resources.GetString("Label4.Text");
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(3, 239);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 20);
            this.Label3.Text = "Version:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(3, 219);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 20);
            this.Label2.Text = "Message:";
            // 
            // ReadRegistryButton
            // 
            this.ReadRegistryButton.Location = new System.Drawing.Point(0, 273);
            this.ReadRegistryButton.Name = "ReadRegistryButton";
            this.ReadRegistryButton.Size = new System.Drawing.Size(100, 20);
            this.ReadRegistryButton.TabIndex = 9;
            this.ReadRegistryButton.Text = "Read Registry";
            this.ReadRegistryButton.Click += new System.EventHandler(this.ReadRegistryButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Location = new System.Drawing.Point(76, 239);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(164, 20);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(76, 219);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(164, 20);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ReadRegistryButton);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.MessageLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button ReadRegistryButton;
        internal System.Windows.Forms.Label VersionLabel;
        internal System.Windows.Forms.Label MessageLabel;
    }
}

