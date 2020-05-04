using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region StyleDlg
	public class StyleDlg : System.Windows.Forms.Form
	{
		#region class variables
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ListBox listBox1;

		public ArrayList StyleList;
		public EditRep Rep;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public StyleDlg()
		{
			InitializeComponent();
			StyleList=new ArrayList();
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(16, 224);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(192, 224);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "&Cancel";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(104, 224);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Text = "&Apply";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(192, 48);
			this.button4.Name = "button4";
			this.button4.TabIndex = 4;
			this.button4.Text = "New";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(192, 104);
			this.button5.Name = "button5";
			this.button5.TabIndex = 5;
			this.button5.Text = "Remove";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(192, 160);
			this.button6.Name = "button6";
			this.button6.TabIndex = 6;
			this.button6.Text = "Edit";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(168, 186);
			this.listBox1.TabIndex = 7;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// StyleDlg
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(280, 266);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "StyleDlg";
			this.ShowInTaskbar = false;
			this.Text = "Styles";
			this.Load += new System.EventHandler(this.StyleDlg_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region  class methods
		private void button4_Click(object sender, System.EventArgs e)
		{
			bool flag=false;
			inputbox d=new inputbox();
			d.Text="New style type";
			d.label1.Text="Input style name";
			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<listBox1.Items.Count;i++)
				{
					if(d.textBox1.Text==(string)listBox1.Items[i])
					{
						MessageBox.Show("Style names can not be same");
						flag=true;
						break;
					}
				}
				if(flag==false)
				{
					listBox1.Items.Add(d.textBox1.Text);
					StyleList.Add(new Style(d.textBox1.Text));
				}
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			if(listBox1.SelectedItem!=null)
			{
				for(int i=0;i<StyleList.Count;i++)
				{
					if((string)listBox1.SelectedItem==((Style)StyleList[i]).Name)
					{
						StyleList.RemoveAt(i);
						listBox1.Items.Remove(listBox1.SelectedItem);
						button3.Enabled=false;
						button6.Enabled=false;
						break;
					}
				}
			}
		}

		private void StyleDlg_Load(object sender, System.EventArgs e)
		{
			for(int i=0;i<StyleList.Count;i++)
				listBox1.Items.Add(((Style)StyleList[i]).Name);
			button3.Enabled=false;
			button6.Enabled=false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Style style=null;
			for(int i=0;i<StyleList.Count;i++)
			{
				if((string)listBox1.SelectedItem==((Style)StyleList[i]).Name)
				{
					style=(Style)StyleList[i];
					break;
				}
			}
			for(int i=0;i<Rep.SelList.Count;i++)
			{
				ApplyStyle(Rep.GetSel(i),style);
			}
			button3.Enabled=false;	
		}

		void ApplyStyle(Cell cell,Style style)
		{
			cell.PictureFileName=style.PictureFileName;
			cell.LinkPictureToFile=style.LinkToFile;
			cell.AutoSize=style.FitToCell;
			cell.Tile=style.TilesPicture;
			cell.ShapeType=style.ShapeType;
			cell.ShapeColor=style.ShapeColor;
			cell.ShapeBorderColor=style.ShapeBorderColor;
			cell.Shape=style.Shape;
			cell.ShapeBorderStyle=style.ShapeBorderStyle;
			cell.ShapeBorderWidth=style.ShapeBorderWidth;
			cell.ShapeGraident=style.ShapeGraident;
			cell.ShapeGraidentColor=style.ShapeGraidentColor;
			cell.ShapeFillDirection=style.ShapeFillDirection;
			cell.WordWrap=style.WordWrap;
			cell.TextAngle=style.TextAngle;
			cell.FontName=style.FontName;
			cell.FontSize=style.FontSize;
			cell.FontStyle=style.FontStyle;
			cell.FontColor=style.FontColor;
			cell.HAlign=style.HAlign;
			cell.VAlign=style.VAlign;
			cell.SetBorderStyles(0,style.LeftStyle);
			cell.SetFrameColors(0,style.LeftColor);
			cell.SetFrameWidths(0,style.LeftWidth);
			cell.SetBorderStyles(2,style.RightStyle);
			cell.SetFrameColors(2,style.RightColor);
			cell.SetFrameWidths(2,style.RightWidth);
			cell.SetBorderStyles(1,style.TopStyle);
			cell.SetFrameColors(1,style.TopColor);
			cell.SetFrameWidths(1,style.TopWidth);
			cell.SetBorderStyles(3,style.BottomStyle);
			cell.SetFrameColors(3,style.BottomColor);
			cell.SetFrameWidths(3,style.BottomWidth);
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(listBox1.Items.Count>0 && listBox1.SelectedItem!=null)
			{
				button3.Enabled=true;
				button6.Enabled=true;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(listBox1.SelectedItem!=null)
				button3_Click(this,EventArgs.Empty);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			EditStyleDlg dlg=new EditStyleDlg();
			if(listBox1.SelectedItem!=null)
			{
				for(int i=0;i<StyleList.Count;i++)
				{
					if((string)listBox1.SelectedItem==((Style)StyleList[i]).Name)
					{
						dlg.style=(Style)StyleList[i];
						break;
					}
				}
			}
			if(dlg.style!=null)
			{
				if(dlg.ShowDialog()==DialogResult.OK)
					button3.Enabled=true;
			}
		}
		#endregion		
	}
	#endregion
}
