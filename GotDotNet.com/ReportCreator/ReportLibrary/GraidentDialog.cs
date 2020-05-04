using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region GraidentDialog
	public class GraidentDialog : System.Windows.Forms.Form
	{
		#region class variables
		public Color GraidentColor;
		public Color BackgroundColor;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;

		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public GraidentDialog()
		{
			InitializeComponent();

			FillDirection[] o=(FillDirection[])Enum.GetValues(typeof(FillDirection));
			for(int i=0;i<o.Length;i++)
			{
				FillDirection a=(FillDirection)o[i];
				comboBox1.Items.Add(a);
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
			this.button4 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(224, 32);
			this.button4.Name = "button4";
			this.button4.TabIndex = 18;
			this.button4.Text = "&Set color";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 17;
			this.label3.Text = "Graident color";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "Fill Direction";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(128, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 14;
			this.button2.Text = "&Cancel";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(24, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 13;
			this.button1.Text = "&OK";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(136, 32);
			this.button3.Name = "button3";
			this.button3.TabIndex = 20;
			this.button3.Text = "&Set color";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 19;
			this.label2.Text = "Back color";
			// 
			// GraidentDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(328, 118);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Name = "GraidentDialog";
			this.ShowInTaskbar = false;
			this.Text = "GraidentDialog";
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button4_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=GraidentColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				GraidentColor=colorDialog1.Color;
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=BackgroundColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				BackgroundColor=colorDialog1.Color;
			}
		}
		#endregion
	}
	#endregion
}
