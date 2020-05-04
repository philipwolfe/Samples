using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region BorderDlg
	public class Borderdlg : System.Windows.Forms.Form
	{
		#region class variables
		public Color Color;
		private System.Windows.Forms.ColorDialog colorDialog1;
		public System.Windows.Forms.ComboBox comboBox2;
		public System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button4;
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public Borderdlg()
		{
			InitializeComponent();

			LineStyle[] o=(LineStyle[])Enum.GetValues(typeof(LineStyle));
			for(int i=0;i<o.Length;i++)
			{
				LineStyle a=(LineStyle)o[i];
				comboBox2.Items.Add(a);
			}
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
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			this.colorDialog1.FullOpen = true;
			this.colorDialog1.ShowHelp = true;
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(136, 32);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 2;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// comboBox3
			// 
			this.comboBox3.Items.AddRange(new object[] {
														   "0",
														   "1",
														   "2",
														   "3",
														   "4",
														   "5",
														   "6",
														   "7"});
			this.comboBox3.Location = new System.Drawing.Point(8, 32);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(8, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "&OK";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(96, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Border width";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Border style";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(264, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Border color";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(264, 32);
			this.button4.Name = "button4";
			this.button4.TabIndex = 10;
			this.button4.Text = "&Set color";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Borderdlg
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(360, 110);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.button2,
																		  this.button1,
																		  this.comboBox3,
																		  this.comboBox2});
			this.Name = "Borderdlg";
			this.Text = "Borderdlg";
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button4_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=Color;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				Color=colorDialog1.Color;
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((LineStyle)comboBox2.SelectedItem==LineStyle.Dash)
			{
				comboBox3.SelectedItem="1";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.Dot)
			{
				comboBox3.SelectedItem="1";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.DashDot)
			{
				comboBox3.SelectedItem="1";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.DashDotDot)
			{
				comboBox3.SelectedItem="1";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.Double11)
			{
				comboBox3.SelectedItem="3";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.Double21)
			{
				comboBox3.SelectedItem="4";
				comboBox3.Enabled=false;
			}
			else if((LineStyle)comboBox2.SelectedItem==LineStyle.Double12)
			{
				comboBox3.SelectedItem="4";
				comboBox3.Enabled=false;
			}
			else
			{
				comboBox3.Enabled=true;
			}
		}
		#endregion
	}
	#endregion
}
