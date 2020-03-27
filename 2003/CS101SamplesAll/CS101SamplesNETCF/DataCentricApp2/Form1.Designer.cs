namespace DataCentricApp2
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
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.LastTextBox = new System.Windows.Forms.TextBox();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.MasterListBox = new System.Windows.Forms.ListBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.FirstTextBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.StateTextBox = new System.Windows.Forms.TextBox();
            this.ZipTextBox = new System.Windows.Forms.TextBox();
            this.MainMenu1 = new System.Windows.Forms.MainMenu();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 20);
            this.Label1.Text = "First";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Enabled = false;
            this.AddressTextBox.Location = new System.Drawing.Point(4, 117);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(203, 21);
            this.AddressTextBox.TabIndex = 4;
            // 
            // LastTextBox
            // 
            this.LastTextBox.Enabled = false;
            this.LastTextBox.Location = new System.Drawing.Point(107, 23);
            this.LastTextBox.Name = "LastTextBox";
            this.LastTextBox.Size = new System.Drawing.Size(100, 21);
            this.LastTextBox.TabIndex = 2;
            // 
            // CityTextBox
            // 
            this.CityTextBox.Enabled = false;
            this.CityTextBox.Location = new System.Drawing.Point(3, 164);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(100, 21);
            this.CityTextBox.TabIndex = 5;
            // 
            // Label8
            // 
            this.Label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label8.Location = new System.Drawing.Point(0, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(100, 20);
            this.Label8.Text = "Contacts";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Panel2.Controls.Add(this.Label8);
            this.Panel2.Controls.Add(this.MasterListBox);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(100, 268);
            // 
            // MasterListBox
            // 
            this.MasterListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MasterListBox.Location = new System.Drawing.Point(0, 20);
            this.MasterListBox.Name = "MasterListBox";
            this.MasterListBox.Size = new System.Drawing.Size(100, 268);
            this.MasterListBox.TabIndex = 0;
            this.MasterListBox.SelectedValueChanged += new System.EventHandler(this.MasterListBox_SelectedValueChanged);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Enabled = false;
            this.PhoneTextBox.Location = new System.Drawing.Point(4, 70);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(100, 21);
            this.PhoneTextBox.TabIndex = 3;
            // 
            // FirstTextBox
            // 
            this.FirstTextBox.Enabled = false;
            this.FirstTextBox.Location = new System.Drawing.Point(3, 23);
            this.FirstTextBox.Name = "FirstTextBox";
            this.FirstTextBox.Size = new System.Drawing.Size(100, 21);
            this.FirstTextBox.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(107, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 20);
            this.Label2.Text = "Last";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(143, 141);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 20);
            this.Label7.Text = "Zip";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(107, 141);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(30, 20);
            this.Label6.Text = "ST";
            // 
            // StateTextBox
            // 
            this.StateTextBox.Enabled = false;
            this.StateTextBox.Location = new System.Drawing.Point(107, 164);
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.Size = new System.Drawing.Size(30, 21);
            this.StateTextBox.TabIndex = 6;
            // 
            // ZipTextBox
            // 
            this.ZipTextBox.Enabled = false;
            this.ZipTextBox.Location = new System.Drawing.Point(143, 164);
            this.ZipTextBox.Name = "ZipTextBox";
            this.ZipTextBox.Size = new System.Drawing.Size(64, 21);
            this.ZipTextBox.TabIndex = 7;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(3, 141);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(100, 20);
            this.Label5.Text = "City";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(3, 94);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 20);
            this.Label4.Text = "Address";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.AutoScroll = true;
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.StateTextBox);
            this.Panel1.Controls.Add(this.ZipTextBox);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.AddressTextBox);
            this.Panel1.Controls.Add(this.CityTextBox);
            this.Panel1.Controls.Add(this.LastTextBox);
            this.Panel1.Controls.Add(this.PhoneTextBox);
            this.Panel1.Controls.Add(this.FirstTextBox);
            this.Panel1.Location = new System.Drawing.Point(100, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(140, 268);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(4, 47);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 20);
            this.Label3.Text = "Phone";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Menu = this.MainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox AddressTextBox;
        internal System.Windows.Forms.TextBox LastTextBox;
        internal System.Windows.Forms.TextBox CityTextBox;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ListBox MasterListBox;
        internal System.Windows.Forms.TextBox PhoneTextBox;
        internal System.Windows.Forms.TextBox FirstTextBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox StateTextBox;
        internal System.Windows.Forms.TextBox ZipTextBox;
        internal System.Windows.Forms.MainMenu MainMenu1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label3;
    }
}

