using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Drawing
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtX1;
		private System.Windows.Forms.TextBox txtY1;
		private System.Windows.Forms.TextBox txtY2;
		private System.Windows.Forms.TextBox txtX2;
		private System.Windows.Forms.Button cmdDrawLine;
		private System.Windows.Forms.Button cmdDrawRectangle;
		private System.Windows.Forms.Button cmdFillRectangle;
		private System.Windows.Forms.ComboBox cboColor;
		private System.Windows.Forms.PictureBox picCanvas;
		private System.Windows.Forms.CheckBox chkAutoredraw;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCircleX;
		private System.Windows.Forms.TextBox txtCircleY;
		private System.Windows.Forms.TextBox txtRadius;
		private System.Windows.Forms.ComboBox cboCircleColor;
		private System.Windows.Forms.Button cmdDrawCircle;
		private System.Windows.Forms.Button cmdFillCircle;
		private System.Windows.Forms.Button cmdDrawArc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtY2 = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cboColor = new System.Windows.Forms.ComboBox();
			this.cmdFillRectangle = new System.Windows.Forms.Button();
			this.cmdDrawRectangle = new System.Windows.Forms.Button();
			this.cmdDrawLine = new System.Windows.Forms.Button();
			this.txtX2 = new System.Windows.Forms.TextBox();
			this.txtY1 = new System.Windows.Forms.TextBox();
			this.txtX1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.picCanvas = new System.Windows.Forms.PictureBox();
			this.chkAutoredraw = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCircleX = new System.Windows.Forms.TextBox();
			this.txtCircleY = new System.Windows.Forms.TextBox();
			this.txtRadius = new System.Windows.Forms.TextBox();
			this.cboCircleColor = new System.Windows.Forms.ComboBox();
			this.cmdDrawCircle = new System.Windows.Forms.Button();
			this.cmdFillCircle = new System.Windows.Forms.Button();
			this.cmdDrawArc = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtY2
			// 
			this.txtY2.Location = new System.Drawing.Point(80, 32);
			this.txtY2.Name = "txtY2";
			this.txtY2.Size = new System.Drawing.Size(24, 20);
			this.txtY2.TabIndex = 0;
			this.txtY2.Text = "50";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(464, 86);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {this.label4,
																				   this.label3,
																				   this.label2,
																				   this.label1,
																				   this.cboColor,
																				   this.cmdFillRectangle,
																				   this.cmdDrawRectangle,
																				   this.cmdDrawLine,
																				   this.txtX2,
																				   this.txtY2,
																				   this.txtY1,
																				   this.txtX1});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(456, 60);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Lines and Rectangles";
			// 
			// cboColor
			// 
			this.cboColor.DropDownWidth = 152;
			this.cboColor.Location = new System.Drawing.Point(192, 8);
			this.cboColor.Name = "cboColor";
			this.cboColor.Size = new System.Drawing.Size(152, 21);
			this.cboColor.TabIndex = 2;
			// 
			// cmdFillRectangle
			// 
			this.cmdFillRectangle.Location = new System.Drawing.Point(344, 32);
			this.cmdFillRectangle.Name = "cmdFillRectangle";
			this.cmdFillRectangle.Size = new System.Drawing.Size(88, 24);
			this.cmdFillRectangle.TabIndex = 1;
			this.cmdFillRectangle.Text = "Fill Rectangle";
			this.cmdFillRectangle.Click += new System.EventHandler(this.cmdFillRectangle_Click);
			// 
			// cmdDrawRectangle
			// 
			this.cmdDrawRectangle.Location = new System.Drawing.Point(232, 32);
			this.cmdDrawRectangle.Name = "cmdDrawRectangle";
			this.cmdDrawRectangle.Size = new System.Drawing.Size(96, 24);
			this.cmdDrawRectangle.TabIndex = 1;
			this.cmdDrawRectangle.Text = "Draw Rectangle";
			this.cmdDrawRectangle.Click += new System.EventHandler(this.cmdDrawRectangle_Click);
			// 
			// cmdDrawLine
			// 
			this.cmdDrawLine.Location = new System.Drawing.Point(128, 32);
			this.cmdDrawLine.Name = "cmdDrawLine";
			this.cmdDrawLine.Size = new System.Drawing.Size(88, 24);
			this.cmdDrawLine.TabIndex = 1;
			this.cmdDrawLine.Text = "Draw Line";
			this.cmdDrawLine.Click += new System.EventHandler(this.cmdDrawLine_Click);
			// 
			// txtX2
			// 
			this.txtX2.Location = new System.Drawing.Point(24, 32);
			this.txtX2.Name = "txtX2";
			this.txtX2.Size = new System.Drawing.Size(24, 20);
			this.txtX2.TabIndex = 0;
			this.txtX2.Text = "50";
			// 
			// txtY1
			// 
			this.txtY1.Location = new System.Drawing.Point(80, 8);
			this.txtY1.Name = "txtY1";
			this.txtY1.Size = new System.Drawing.Size(24, 20);
			this.txtY1.TabIndex = 0;
			this.txtY1.Text = "10";
			// 
			// txtX1
			// 
			this.txtX1.Location = new System.Drawing.Point(24, 8);
			this.txtX1.Name = "txtX1";
			this.txtX1.Size = new System.Drawing.Size(24, 20);
			this.txtX1.TabIndex = 0;
			this.txtX1.Text = "10";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {this.label7,
																				   this.label6,
																				   this.label5,
																				   this.cmdDrawArc,
																				   this.cmdFillCircle,
																				   this.cmdDrawCircle,
																				   this.cboCircleColor,
																				   this.txtRadius,
																				   this.txtCircleY,
																				   this.txtCircleX});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(456, 60);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Circles";
			// 
			// picCanvas
			// 
			this.picCanvas.BackColor = System.Drawing.Color.White;
			this.picCanvas.Location = new System.Drawing.Point(8, 120);
			this.picCanvas.Name = "picCanvas";
			this.picCanvas.Size = new System.Drawing.Size(464, 256);
			this.picCanvas.TabIndex = 1;
			this.picCanvas.TabStop = false;
			// 
			// chkAutoredraw
			// 
			this.chkAutoredraw.Location = new System.Drawing.Point(16, 104);
			this.chkAutoredraw.Name = "chkAutoredraw";
			this.chkAutoredraw.Size = new System.Drawing.Size(120, 16);
			this.chkAutoredraw.TabIndex = 2;
			this.chkAutoredraw.Text = "Use AutoRedraw";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "X1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "X2";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(56, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Y2";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Y1";
			// 
			// txtCircleX
			// 
			this.txtCircleX.Location = new System.Drawing.Point(32, 8);
			this.txtCircleX.Name = "txtCircleX";
			this.txtCircleX.Size = new System.Drawing.Size(24, 20);
			this.txtCircleX.TabIndex = 0;
			this.txtCircleX.Text = "60";
			// 
			// txtCircleY
			// 
			this.txtCircleY.Location = new System.Drawing.Point(88, 8);
			this.txtCircleY.Name = "txtCircleY";
			this.txtCircleY.Size = new System.Drawing.Size(24, 20);
			this.txtCircleY.TabIndex = 0;
			this.txtCircleY.Text = "60";
			// 
			// txtRadius
			// 
			this.txtRadius.Location = new System.Drawing.Point(56, 32);
			this.txtRadius.Name = "txtRadius";
			this.txtRadius.Size = new System.Drawing.Size(24, 20);
			this.txtRadius.TabIndex = 0;
			this.txtRadius.Text = "35";
			// 
			// cboCircleColor
			// 
			this.cboCircleColor.DropDownWidth = 184;
			this.cboCircleColor.Location = new System.Drawing.Point(168, 8);
			this.cboCircleColor.Name = "cboCircleColor";
			this.cboCircleColor.Size = new System.Drawing.Size(184, 21);
			this.cboCircleColor.TabIndex = 1;
			// 
			// cmdDrawCircle
			// 
			this.cmdDrawCircle.Location = new System.Drawing.Point(136, 32);
			this.cmdDrawCircle.Name = "cmdDrawCircle";
			this.cmdDrawCircle.Size = new System.Drawing.Size(88, 24);
			this.cmdDrawCircle.TabIndex = 2;
			this.cmdDrawCircle.Text = "Draw Circle";
			this.cmdDrawCircle.Click += new System.EventHandler(this.cmdDrawCircle_Click);
			// 
			// cmdFillCircle
			// 
			this.cmdFillCircle.Location = new System.Drawing.Point(240, 32);
			this.cmdFillCircle.Name = "cmdFillCircle";
			this.cmdFillCircle.Size = new System.Drawing.Size(88, 24);
			this.cmdFillCircle.TabIndex = 2;
			this.cmdFillCircle.Text = "Fill Circle";
			this.cmdFillCircle.Click += new System.EventHandler(this.cmdFillCircle_Click);
			// 
			// cmdDrawArc
			// 
			this.cmdDrawArc.Location = new System.Drawing.Point(344, 32);
			this.cmdDrawArc.Name = "cmdDrawArc";
			this.cmdDrawArc.Size = new System.Drawing.Size(88, 24);
			this.cmdDrawArc.TabIndex = 2;
			this.cmdDrawArc.Text = "Draw Arc";
			this.cmdDrawArc.Click += new System.EventHandler(this.cmdDrawArc_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 16);
			this.label5.TabIndex = 3;
			this.label5.Text = "X";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(64, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Y";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Radius";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkAutoredraw,
																		  this.picCanvas,
																		  this.tabControl1});
			this.Name = "Form1";
			this.Text = "Drawing";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			AddColors(this.cboColor);
			this.cboColor.SelectedItem = "Green";
			AddColors(this.cboCircleColor);
			this.cboCircleColor.SelectedItem = "Blue";
		}

		public void DemoCircleDrawing(string sDrawItemType)
		{
			float circleTop;
			float circleLeft;
			float circleRadius;
			float circleWidth;
			float circleHeight ;
			
			// Drawing circles and ovals requires a bounding rectangle
			// This is a quick conversion from focus/radius to a bouding rectangle
			circleRadius = Convert.ToSingle(this.txtRadius.Text);
			circleTop = Convert.ToSingle(this.txtCircleX.Text) - circleRadius;
			circleLeft = Convert.ToSingle(this.txtCircleY.Text) - circleRadius;
			circleWidth = circleRadius * 2;
			circleHeight = circleRadius * 2;

			// Default angles for drawing arc
			int angleFrom;
			int angleTo;
        
			angleFrom = 90;
			angleTo = 90;

			// Extract color from name      
			System.Drawing.Color oColor;
			string sColorName;
		
			sColorName = this.cboCircleColor.SelectedItem.ToString();
			oColor = Color.FromName(sColorName);

			// Create pen from color and set width to 2px
			//Create pen from color and set width to 2px
			System.Drawing.Pen hPen;
			System.Drawing.Graphics oGraphics; 
		
			hPen = new System.Drawing.Pen(oColor, 2);
			if (this.chkAutoredraw.Checked == true)
			{
				oGraphics = this.CreateAutoRedrawGraphics(this.picCanvas);
			}
			else
			{
				
				oGraphics = this.picCanvas.CreateGraphics();
			}

			switch(sDrawItemType)
			{
				case "DrawCircle":
					// Draw Circle
					oGraphics.DrawEllipse(hPen, circleLeft, circleTop, circleWidth, circleHeight);
					break;
				case "FillCircle":
					// Fill Circle
					oGraphics.FillEllipse(hPen.Brush, circleLeft, circleTop, circleWidth, circleHeight);
					break;
				case "DrawArc":
					// Draw Arc
					oGraphics.DrawArc(hPen, circleLeft, circleTop, circleWidth, circleHeight, angleFrom, angleTo);
					break;
				default:
					// Double check to make sure I didn't misspell anything
					MessageBox.Show("DrawItemType:'" + sDrawItemType + "' was not found.");
					break;
			}
			oGraphics.Dispose();

		}

		public void AddColors(System.Windows.Forms.ComboBox cboCombo)
		{
		
			
			cboCombo.Items.Add("AntiqueWhite");
			cboCombo.Items.Add("Aqua");
			cboCombo.Items.Add("Aquamarine");
			cboCombo.Items.Add("Azure");
			cboCombo.Items.Add("Beige");
			cboCombo.Items.Add("Bisque");
			cboCombo.Items.Add("Black");
			cboCombo.Items.Add("BlanchedAlmond");
			cboCombo.Items.Add("Blue");
			cboCombo.Items.Add("BlueViolet");
			cboCombo.Items.Add("Brown");
			cboCombo.Items.Add("BurlyWood");
			cboCombo.Items.Add("CadetBlue");
			cboCombo.Items.Add("Chartreuse");
			cboCombo.Items.Add("Chocolate");
			cboCombo.Items.Add("Coral");
			cboCombo.Items.Add("Cornflower");
			cboCombo.Items.Add("Cornsilk");
			cboCombo.Items.Add("Crimson");
			cboCombo.Items.Add("Cyan");
			cboCombo.Items.Add("DarkBlue");
			cboCombo.Items.Add("DarkCyan");
			cboCombo.Items.Add("DarkGoldenrod");
			cboCombo.Items.Add("DarkGray");
			cboCombo.Items.Add("DarkGreen");
			cboCombo.Items.Add("DarkKhaki");
			cboCombo.Items.Add("DarkMagenta");
			cboCombo.Items.Add("DarkOliveGreen");
			cboCombo.Items.Add("DarkOrange");
			cboCombo.Items.Add("DarkOrchid");
			cboCombo.Items.Add("DarkRed");
			cboCombo.Items.Add("DarkSalmon");
			cboCombo.Items.Add("DarkSeaGreen");
			cboCombo.Items.Add("DarkSlateBlue");
			cboCombo.Items.Add("DarkSlateGray");
			cboCombo.Items.Add("DarkTurquoise");
			cboCombo.Items.Add("DarkViolet");
			cboCombo.Items.Add("DeepPink");
			cboCombo.Items.Add("DeepSkyBlue");
			cboCombo.Items.Add("DimGray");
			cboCombo.Items.Add("DodgerBlue");
			cboCombo.Items.Add("Firebrick");
			cboCombo.Items.Add("FloralWhite");
			cboCombo.Items.Add("ForestGreen");
			cboCombo.Items.Add("Fuchsia");
			cboCombo.Items.Add("Gainsboro");
			cboCombo.Items.Add("GhostWhite");
			cboCombo.Items.Add("Gold");
			cboCombo.Items.Add("Goldenrod");
			cboCombo.Items.Add("Gray");
			cboCombo.Items.Add("Green");
			cboCombo.Items.Add("GreenYellow");
			cboCombo.Items.Add("Honeydew");
			cboCombo.Items.Add("HotPink");
			cboCombo.Items.Add("IndianRed");
			cboCombo.Items.Add("Indigo");
			cboCombo.Items.Add("Ivory");
			cboCombo.Items.Add("Khaki");
			cboCombo.Items.Add("Lavender");
			cboCombo.Items.Add("LavenderBlush");
			cboCombo.Items.Add("LawnGreen");
			cboCombo.Items.Add("LemonChiffon");
			cboCombo.Items.Add("LightBlue");
			cboCombo.Items.Add("LightCoral");
			cboCombo.Items.Add("LightCyan");
			cboCombo.Items.Add("LightGoldenrodYellow");
			cboCombo.Items.Add("LightGray");
			cboCombo.Items.Add("LightGreen");
			cboCombo.Items.Add("LightPink");
			cboCombo.Items.Add("LightSalmon");
			cboCombo.Items.Add("LightSeaGreen");
			cboCombo.Items.Add("LightSkyBlue");
			cboCombo.Items.Add("LightSlateGray");
			cboCombo.Items.Add("LightSteelBlue");
			cboCombo.Items.Add("LightYellow");
			cboCombo.Items.Add("Lime");
			cboCombo.Items.Add("LimeGreen");
			cboCombo.Items.Add("Linen");
			cboCombo.Items.Add("Magenta");
			cboCombo.Items.Add("Maroon");
			cboCombo.Items.Add("MediumAquamarine");
			cboCombo.Items.Add("MediumBlue");
			cboCombo.Items.Add("MediumOrchid");
			cboCombo.Items.Add("MediumPurple");
			cboCombo.Items.Add("MediumSeaGreen");
			cboCombo.Items.Add("MediumSlateBlue");
			cboCombo.Items.Add("MediumSpringGreen");
			cboCombo.Items.Add("MediumTurquoise");
			cboCombo.Items.Add("MediumVioletRed");
			cboCombo.Items.Add("MidnightBlue");
			cboCombo.Items.Add("MintCream");
			cboCombo.Items.Add("MistyRose");
			cboCombo.Items.Add("Moccasin");
			cboCombo.Items.Add("NavajoWhite");
			cboCombo.Items.Add("Navy");
			cboCombo.Items.Add("OldLace");
			cboCombo.Items.Add("Olive");
			cboCombo.Items.Add("OliveDrab");
			cboCombo.Items.Add("Orange");
			cboCombo.Items.Add("OrangeRed");
			cboCombo.Items.Add("Orchid");
			cboCombo.Items.Add("PaleGoldenrod");
			cboCombo.Items.Add("PaleGreen");
			cboCombo.Items.Add("PaleTurquoise");
			cboCombo.Items.Add("PaleVioletRed");
			cboCombo.Items.Add("PapayaWhip");
			cboCombo.Items.Add("PeachPuff");
			cboCombo.Items.Add("Peru");
			cboCombo.Items.Add("Pink");
			cboCombo.Items.Add("Plum");
			cboCombo.Items.Add("PowderBlue");
			cboCombo.Items.Add("Purple");
			cboCombo.Items.Add("Red");
			cboCombo.Items.Add("RosyBrown");
			cboCombo.Items.Add("RoyalBlue");
			cboCombo.Items.Add("SaddleBrown");
			cboCombo.Items.Add("Salmon");
			cboCombo.Items.Add("SandyBrown");
			cboCombo.Items.Add("SeaGreen");
			cboCombo.Items.Add("SeaShell");
			cboCombo.Items.Add("Sienna");
			cboCombo.Items.Add("Silver");
			cboCombo.Items.Add("SkyBlue");
			cboCombo.Items.Add("SlateBlue");
			cboCombo.Items.Add("SlateGray");
			cboCombo.Items.Add("Snow");
			cboCombo.Items.Add("SpringGreen");
			cboCombo.Items.Add("SteelBlue");
			cboCombo.Items.Add("Tan");
			cboCombo.Items.Add("Teal");
			cboCombo.Items.Add("Thistle");
			cboCombo.Items.Add("Tomato");
			cboCombo.Items.Add("Transparent");
			cboCombo.Items.Add("Turquoise");
			cboCombo.Items.Add("Violet");
			cboCombo.Items.Add("Wheat");
			cboCombo.Items.Add("White");
			cboCombo.Items.Add("WhiteSmoke");
			cboCombo.Items.Add("Yellow");
			cboCombo.Items.Add("YellowGreen");
        
		}

		public void DemoRectBasedDrawing(string sDrawItemType)
		{
			//Take the setting in the form under the rectangle tab
			//and draws the requested shape
			float x1;
			float x2;
			float y1;
			float y2;
		
			x1 = Convert.ToSingle(this.txtX1.Text);
			y1 = Convert.ToSingle(this.txtY1.Text);
			x2 = Convert.ToSingle(this.txtX2.Text);
			y2 = Convert.ToSingle(this.txtY2.Text);

			//Extrace color from name      
			System.Drawing.Color oColor;
			string sColorName;
		
			sColorName = this.cboColor.SelectedItem.ToString();
			oColor = Color.FromName(sColorName);

			//Create pen from color and set width to 2px
			System.Drawing.Pen hPen;
			System.Drawing.Graphics oGraphics; 
		
			hPen = new System.Drawing.Pen(oColor, 2);
			   
			if (this.chkAutoredraw.Checked == true)
			{
				oGraphics = this.CreateAutoRedrawGraphics(this.picCanvas);
				
			}
			else
			{
				oGraphics = this.picCanvas.CreateGraphics();
			}
			
			switch (sDrawItemType)
			{
				case "DrawLine":
					//Draw Line
					oGraphics.DrawLine(hPen, x1, y1, x2, y2);
					break;
				case "DrawRectangle":
					//Draw Line
					oGraphics.DrawRectangle(hPen, x1, y1, x2, y2);
					break;
				case "FillRectangle":
					//Draw Line
					oGraphics.FillRectangle(hPen.Brush, x1, y1, x2, y2);
					break;
				default:
					//Double check to make sure I didn't misspell anything
					MessageBox.Show("DrawItemType:" + sDrawItemType + " was not found.");
					break;	
			}
			//oGraphics.Dispose();
		}


		public System.Drawing.Graphics CreateAutoRedrawGraphics(System.Windows.Forms.PictureBox oPic)
		{
			// Autoredraw will keep your drawing changes if your form is repainted.
			// When you use the normal createGraphics function off a picture box, 
			// your drawing commands run directly against the screen.  If your form 
			// is covered and the uncovered, your changes will need to be redrawn.  
			// With autoredraw you are drawing against a memory based image
			// which is then drawn automatically when your form is repainted.

			// If a background image if one does not exist one will be created
			// Check to see if our pic has an image
			System.Drawing.Bitmap oBitmap;
			
			if (oPic.Image == null) 
			{
				oBitmap = new System.Drawing.Bitmap(oPic.ClientRectangle.Width, oPic.ClientRectangle.Height);
				// Create the image as a bitmap (to be painted in the background)
				oPic.Image = oBitmap;
				
			}
			oPic.Invalidate();
			return Graphics.FromImage(oPic.Image);
			
		}

		private void cmdDrawLine_Click(object sender, System.EventArgs e)
		{
			DemoRectBasedDrawing("DrawLine");
		}

		private void cmdDrawRectangle_Click(object sender, System.EventArgs e)
		{
			DemoRectBasedDrawing("DrawRectangle");
		}

		private void cmdFillRectangle_Click(object sender, System.EventArgs e)
		{
			DemoRectBasedDrawing("FillRectangle");
		}

		private void cmdDrawCircle_Click(object sender, System.EventArgs e)
		{
			DemoCircleDrawing("DrawCircle");
		}

		private void cmdFillCircle_Click(object sender, System.EventArgs e)
		{
			DemoCircleDrawing("FillCircle");
		}

		private void cmdDrawArc_Click(object sender, System.EventArgs e)
		{
			DemoCircleDrawing("DrawArc");
		}

	}
}
