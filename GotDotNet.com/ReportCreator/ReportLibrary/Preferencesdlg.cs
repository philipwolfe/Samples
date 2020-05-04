using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region Preferences
	public class Preferences : System.Windows.Forms.Form
	{
		#region class variables
		public Units Units;
		public double GridX;
		public double GridY;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public Preferences()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Grid Size &X";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(80, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(88, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "textBox2";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Grid Size &Y";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(8, 88);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(144, 88);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "&Cancel";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(176, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(176, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "label4";
			// 
			// Preferences
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(256, 134);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label4,
																		  this.label3,
																		  this.button2,
																		  this.button1,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Name = "Preferences";
			this.ShowInTaskbar = false;
			this.Text = "Preferences";
			this.Load += new System.EventHandler(this.Preferences_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void Preferences_Load(object sender, System.EventArgs e)
		{
			textBox1.Text=string.Format("{0:F2}",GridX);
			textBox2.Text=string.Format("{0:F2}",GridY);
			label3.Text=Generic.UnitsShortName(Units);
			label4.Text=Generic.UnitsShortName(Units);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			GridX=Convert.ToDouble(textBox1.Text);
			GridY=Convert.ToDouble(textBox2.Text);
		}
		#endregion
	}
	#endregion
}
