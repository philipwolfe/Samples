using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region ShapeDialog
	public class ShapeDialog : System.Windows.Forms.Form
	{
		#region class variables
		public Color BackgroundColor;
		public Color GraidentColor;
		public Color BorderColor;

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button5;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public ShapeDialog()
		{
			InitializeComponent();

			FillDirection[] fill=(FillDirection[])Enum.GetValues(typeof(FillDirection));
			for(int i=0;i<fill.Length;i++)
			{
				FillDirection a=(FillDirection)fill[i];
				comboBox1.Items.Add(a);
			}

			ShapeType[] shape=(ShapeType[])Enum.GetValues(typeof(ShapeType));
			for(int i=0;i<shape.Length;i++)
			{
				ShapeType a=(ShapeType)shape[i];
				comboBox2.Items.Add(a);
			}

			DashStyle[] dash=(DashStyle[])Enum.GetValues(typeof(DashStyle));
			for(int i=0;i<dash.Length;i++)
			{
				DashStyle a=(DashStyle)dash[i];
				if(a!=DashStyle.Custom)
					comboBox3.Items.Add(a);
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(432, 96);
			this.button2.Name = "button2";
			this.button2.TabIndex = 21;
			this.button2.Text = "&Cancel";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(432, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 20;
			this.button1.Text = "&OK";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.comboBox3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.comboBox2);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Location = new System.Drawing.Point(0, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 152);
			this.panel1.TabIndex = 29;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(280, 120);
			this.button5.Name = "button5";
			this.button5.TabIndex = 42;
			this.button5.Text = "Set color";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(280, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 41;
			this.label7.Text = "Border color";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(280, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 40;
			this.label6.Text = "Border Style";
			// 
			// comboBox3
			// 
			this.comboBox3.Location = new System.Drawing.Point(280, 72);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 39;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(280, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 38;
			this.label5.Text = "Border Width";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(280, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 37;
			this.textBox1.Text = "";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(144, 120);
			this.button3.Name = "button3";
			this.button3.TabIndex = 36;
			this.button3.Text = "Set color";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 16);
			this.label4.TabIndex = 35;
			this.label4.Text = "Background color";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 34;
			this.label2.Text = "Shape type";
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(8, 56);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 33;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 120);
			this.button4.Name = "button4";
			this.button4.TabIndex = 32;
			this.button4.Text = "&Set color";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(144, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 31;
			this.label3.Text = "Graident color";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 30;
			this.label1.Text = "Fill Direction";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(144, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 29;
			// 
			// ShapeDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(512, 166);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "ShapeDialog";
			this.ShowInTaskbar = false;
			this.Text = "ShapeDialog";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button4_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=BackgroundColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				BackgroundColor=colorDialog1.Color;
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=GraidentColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				GraidentColor=colorDialog1.Color;
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=BorderColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				BorderColor=colorDialog1.Color;
			}
		}
		#endregion
	}
	#endregion
}
