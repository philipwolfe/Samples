using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region PageBackground
	public class PageBackground : System.Windows.Forms.Form
	{
		#region class variables
		private System.Windows.Forms.GroupBox groupBox5;
		public System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.TextBox textBox4;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public PageBackground()
		{
			InitializeComponent();
			ImagePosition[] pos=(ImagePosition[])Enum.GetValues(typeof(ImagePosition));
			for(int i=0;i<pos.Length;i++)
			{
				ImagePosition a=(ImagePosition)pos[i];
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label1,
																					this.comboBox1,
																					this.checkBox1,
																					this.button1,
																					this.textBox4});
			this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox5.Location = new System.Drawing.Point(0, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(424, 104);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "&Image";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(296, 20);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(131, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "&Link to file";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.button1.Location = new System.Drawing.Point(264, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 21);
			this.button1.TabIndex = 1;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 40);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(257, 20);
			this.textBox4.TabIndex = 0;
			this.textBox4.Text = "";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(296, 72);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(104, 120);
			this.button2.Name = "button2";
			this.button2.TabIndex = 7;
			this.button2.Text = "&Ok";
			// 
			// button3
			// 
			this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button3.Location = new System.Drawing.Point(200, 120);
			this.button3.Name = "button3";
			this.button3.TabIndex = 8;
			this.button3.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(296, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 4;
			this.label1.Text = "Position:";
			// 
			// PageBackground
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button3;
			this.ClientSize = new System.Drawing.Size(432, 150);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button3,
																		  this.button2,
																		  this.groupBox5});
			this.Name = "PageBackground";
			this.ShowInTaskbar = false;
			this.Text = "Page Background";
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg=new OpenFileDialog();
			dlg.Filter="All (*.bmp;*.jpeg;*.jpg*.ico)|*.bmp;*.jpeg;*.jpg*;.ico|Bitmaps (*.bmp)|*.bmp|Jpeg (*.jpeg;*.jpg*)|*.jpeg;*.jpg*;|Icons (*.ico)|*.ico";
			dlg.FileName=textBox4.Text;
			if(dlg.ShowDialog()==DialogResult.OK)
				textBox4.Text=dlg.FileName;
			dlg.Dispose();
		}
		#endregion
	}
	#endregion
}
