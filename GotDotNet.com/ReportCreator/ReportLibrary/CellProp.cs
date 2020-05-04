using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region CellPropDlg
	public class CellPropDlg : System.Windows.Forms.Form
	{
		#region class variables
		private System.ComponentModel.Container components = null;

		public EditRep Rep;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label4;
		public bool Modified;
		#endregion

		#region constructor
		public CellPropDlg()
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(305, 105);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cell &text";
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.Location = new System.Drawing.Point(8, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(289, 81);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(320, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(121, 57);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Text orientation";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(64, 32);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(48, 16);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "&270";
			this.radioButton4.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 32);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(40, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "&90";
			this.radioButton3.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(64, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "&180";
			this.radioButton2.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(32, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "&0";
			this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox3.Location = new System.Drawing.Point(320, 64);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(57, 49);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Height";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(33, 20);
			this.textBox2.TabIndex = 0;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox3);
			this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox4.Location = new System.Drawing.Point(384, 64);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(57, 49);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Width";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(33, 20);
			this.textBox3.TabIndex = 0;
			this.textBox3.Text = "";
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.checkBox1);
			this.groupBox5.Controls.Add(this.button1);
			this.groupBox5.Controls.Add(this.textBox4);
			this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox5.Location = new System.Drawing.Point(8, 112);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(433, 49);
			this.groupBox5.TabIndex = 5;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "&Image";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(294, 20);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(131, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "&Link to file";
			this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.button1.Location = new System.Drawing.Point(264, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 21);
			this.button1.TabIndex = 1;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(257, 20);
			this.textBox4.TabIndex = 0;
			this.textBox4.Text = "";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(136, 224);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(97, 25);
			this.button2.TabIndex = 7;
			this.button2.Text = "&OK";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(240, 224);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(97, 25);
			this.button3.TabIndex = 8;
			this.button3.Text = "&Apply";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button4.Location = new System.Drawing.Point(344, 224);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(97, 25);
			this.button4.TabIndex = 9;
			this.button4.Text = "&Cancel";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.textBox8);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.textBox7);
			this.groupBox6.Controls.Add(this.label3);
			this.groupBox6.Controls.Add(this.textBox6);
			this.groupBox6.Controls.Add(this.label2);
			this.groupBox6.Controls.Add(this.textBox5);
			this.groupBox6.Controls.Add(this.label1);
			this.groupBox6.Location = new System.Drawing.Point(8, 168);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(432, 48);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Cell margins";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Left";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(32, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(40, 20);
			this.textBox5.TabIndex = 1;
			this.textBox5.Text = "";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(136, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(40, 20);
			this.textBox6.TabIndex = 3;
			this.textBox6.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(104, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Right";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(232, 16);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(32, 20);
			this.textBox7.TabIndex = 5;
			this.textBox7.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(208, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Top";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(344, 16);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(40, 20);
			this.textBox8.TabIndex = 7;
			this.textBox8.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(304, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Bottom";
			// 
			// CellPropDlg
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button4;
			this.ClientSize = new System.Drawing.Size(472, 270);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CellPropDlg";
			this.ShowInTaskbar = false;
			this.Text = "Cell Properties";
			this.Load += new System.EventHandler(this.CellPropDlg_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button3_Click(object sender, System.EventArgs e)
		{
			Cell cell1;
			Cell cell2=null;
			int band1;
			Band band2=null;

			Rep.CurrCell.PictureFileName=textBox4.Text;
			Rep.CurrCell.LinkPictureToFile=checkBox1.Checked;
			Rep.CurrCell.Value=textBox1.Text;
			if(radioButton1.Checked)
				Rep.CurrCell.TextAngle=0;
			if(radioButton2.Checked)
				Rep.CurrCell.TextAngle=180;
			if(radioButton3.Checked)
				Rep.CurrCell.TextAngle=90;
			if(radioButton4.Checked)
				Rep.CurrCell.TextAngle=270;
			Rep.CurrCell.CellMargins.Left=Convert.ToInt32(textBox5.Text);
			Rep.CurrCell.CellMargins.Right=Convert.ToInt32(textBox6.Text);
			Rep.CurrCell.CellMargins.Top=Convert.ToInt32(textBox7.Text);
			Rep.CurrCell.CellMargins.Bottom=Convert.ToInt32(textBox8.Text);

			cell1=Rep.CurrCell;
			for(int i=Rep.CurrCellIdx+1;i<Rep.CurrBand.CellCount;i++)
			{
				if(Rep.CurrBand.GetCell(i).LockWidth==false)
				{
					cell2=Rep.CurrBand.GetCell(i);
					break;
				}
			}
			if(cell2==null)
			{
				for(int i=0;i<Rep.CurrCellIdx;i++)
				{
					if(Rep.CurrBand.GetCell(i).LockWidth==false)
					{
						cell2=Rep.CurrBand.GetCell(i);
						break;
					}
				}
			}
			if(cell2!=null)
			{
				float DifferenceCell=Convert.ToSingle(textBox3.Text)-(cell1.Width/Generic.ZoomFactor);
				Rep.SetCellWidth(cell1,Convert.ToSingle(textBox3.Text)*Generic.ZoomFactor);
				Rep.SetCellWidth(cell2,(((cell2.Width/Generic.ZoomFactor)-DifferenceCell)*Generic.ZoomFactor));
			}

			band1=Rep.CurrBandIdx;			
			
			for(int i=Rep.CurrBandIdx+1;i<Rep.SrcRep.BandCount;i++)
			{
				if(Rep.SrcRep.GetBand(i).LockHeight==false)
				{
					band2=Rep.SrcRep.GetBand(i);
					break;
				}
			}
			if(band2==null)
			{
				for(int i=0;i<Rep.CurrBandIdx;i++)
				{
					if(Rep.SrcRep.GetBand(i).LockHeight==false)
					{
						band2=Rep.SrcRep.GetBand(i);
						break;
					}
				}
			}
			if(band2!=null)
			{
				int bandidx=Rep.SrcRep.IndexOfBand(band2);
				float DifferenceBand=Convert.ToSingle(textBox2.Text)-(Rep.SrcRep.GetBand(band1).Height/Generic.ZoomFactor);
				Rep.SetBandHeight(band1,(Convert.ToSingle(textBox2.Text)*Generic.ZoomFactor));
				Rep.SetBandHeight(bandidx,(((band2.Height/Generic.ZoomFactor)-DifferenceBand)*Generic.ZoomFactor));
			}
			button3.Enabled=false;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			button3_Click(this,EventArgs.Empty);			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg=new OpenFileDialog();
			dlg.Filter="All (*.bmp;*.jpeg;*.jpg*.ico)|*.bmp;*.jpeg;*.jpg*;.ico|Bitmaps (*.bmp)|*.bmp|Jpeg (*.jpeg;*.jpg*)|*.jpeg;*.jpg*;|Icons (*.ico)|*.ico";
			dlg.FileName=textBox4.Text;
			if(dlg.ShowDialog()==DialogResult.OK)
				textBox4.Text=dlg.FileName;
			dlg.Dispose();
		}

		public void SomeChange()
		{
			Modified=true;
			button3.Enabled=true;
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			if(textBox1.Text!=Rep.CurrCell.Value)
				SomeChange();
		}

		private void checkBox1_Click(object sender, System.EventArgs e)
		{
			SomeChange();
		}

		private void checkBox2_Click(object sender, System.EventArgs e)
		{
			SomeChange();
		}

		private void radioButton1_Click(object sender, System.EventArgs e)
		{
			SomeChange();
		}

		private void CellPropDlg_Load(object sender, System.EventArgs e)
		{
			if(Rep.SelCount>0)
			{
				textBox4.Text=Rep.CurrCell.PictureFileName;
				checkBox1.Checked=Rep.CurrCell.LinkPictureToFile;
				textBox1.Text=Rep.CurrCell.Value;
				if(Rep.CurrCell.TextAngle==0)
					radioButton1.Checked=true;
				else if(Rep.CurrCell.TextAngle==90)
					radioButton3.Checked=true;
				else if(Rep.CurrCell.TextAngle==180)
					radioButton2.Checked=true;
				else if(Rep.CurrCell.TextAngle==270)
					radioButton4.Checked=true;

				textBox3.Text=Convert.ToString(Math.Round(Rep.CurrCell.Width/Generic.ZoomFactor,0));
				textBox2.Text=Convert.ToString(Math.Round(Rep.CurrCell.Owner.Height/Generic.ZoomFactor,0));
				if(Rep.CurrBand.LockHeight==true)
					textBox2.Enabled=false;
				if(Rep.CurrCell.LockWidth==true)
					textBox3.Enabled=false;
				textBox5.Text=Convert.ToString(Rep.CurrCell.CellMargins.Left);
				textBox6.Text=Convert.ToString(Rep.CurrCell.CellMargins.Right);
				textBox7.Text=Convert.ToString(Rep.CurrCell.CellMargins.Top);
				textBox8.Text=Convert.ToString(Rep.CurrCell.CellMargins.Bottom);

				if(Rep.SelCount==1)
					textBox1.Focus();
			}
			else
				Close();
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
			if(textBox2.Text!=Rep.CurrCell.Owner.Height.ToString())
				SomeChange();
		}

		private void textBox3_TextChanged(object sender, System.EventArgs e)
		{
			if(textBox3.Text!=Rep.CurrCell.Width.ToString())
				SomeChange();
		}
		#endregion
	}
	#endregion
}
