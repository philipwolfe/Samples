namespace HandleScreenOrientation
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
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Label3 = new System.Windows.Forms.Label();
			this.OrientationComboBox = new System.Windows.Forms.ComboBox();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Panel1.Controls.Add(this.Label3);
			this.Panel1.Controls.Add(this.OrientationComboBox);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(240, 30);
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label3.Location = new System.Drawing.Point(3, 5);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(82, 20);
			this.Label3.Text = "Orientation";
			// 
			// OrientationComboBox
			// 
			this.OrientationComboBox.Items.Add("Portrait");
			this.OrientationComboBox.Items.Add("Landscape");
			this.OrientationComboBox.Location = new System.Drawing.Point(91, 3);
			this.OrientationComboBox.Name = "OrientationComboBox";
			this.OrientationComboBox.Size = new System.Drawing.Size(142, 22);
			this.OrientationComboBox.TabIndex = 4;
			this.OrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.OrientationComboBox_SelectedIndexChanged);
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.White;
			this.Panel2.Controls.Add(this.Label1);
			this.Panel2.Controls.Add(this.TextBox1);
			this.Panel2.Controls.Add(this.Label2);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel2.Location = new System.Drawing.Point(0, 30);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(240, 69);
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.White;
			this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label1.Location = new System.Drawing.Point(0, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(240, 20);
			this.Label1.Text = "TextBox Anchor Left, Top,  Right";
			// 
			// TextBox1
			// 
			this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox1.Location = new System.Drawing.Point(1, 23);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(240, 21);
			this.TextBox1.TabIndex = 1;
			this.TextBox1.Text = "Some Text Here...";
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.Color.White;
			this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label2.Location = new System.Drawing.Point(0, 47);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(240, 20);
			this.Label2.Text = "TextBox Dock Bottom";
			// 
			// TextBox2
			// 
			this.TextBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TextBox2.Location = new System.Drawing.Point(0, 101);
			this.TextBox2.Multiline = true;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(240, 193);
			this.TextBox2.TabIndex = 4;
			this.TextBox2.Text = "Significant amount of text here in a mulit-line format...";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 294);
			this.Controls.Add(this.TextBox2);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.Panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.ComboBox OrientationComboBox;
		private System.Windows.Forms.Panel Panel2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.TextBox TextBox2;
	}
}

