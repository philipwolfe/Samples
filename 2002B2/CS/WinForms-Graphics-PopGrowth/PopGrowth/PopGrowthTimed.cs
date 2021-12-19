using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Timed_PopGrowth
{
	/// <summary>
	/// Summary description for PopGrowthTimed.
	/// </summary>
	public class PopGrowthTimed : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Panel pnlDisplay;
		private System.Windows.Forms.TextBox txtK;
		private System.Windows.Forms.Panel pnlEmpty;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.Panel pnlControl;
		private System.Windows.Forms.TrackBar TrackBar;
		private System.Windows.Forms.TextBox txtFormula;
		private System.Windows.Forms.Label lblK;
		private System.Windows.Forms.Label lblFormula;
		private System.ComponentModel.IContainer components;

		const byte Generations = 100;
		private System.Windows.Forms.CheckBox chkAuto;
		private System.Windows.Forms.RadioButton optPoint;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.RadioButton optLine;
		private System.Windows.Forms.CheckBox chkPause;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.CheckBox chkRun;
		private System.Windows.Forms.NumericUpDown updnSpeed;
		const int Margin = 3;

		public PopGrowthTimed()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//define a layout event handler for form
			chkAuto.Checked = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.pic = new System.Windows.Forms.PictureBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.chkAuto = new System.Windows.Forms.CheckBox();
			this.updnSpeed = new System.Windows.Forms.NumericUpDown();
			this.chkPause = new System.Windows.Forms.CheckBox();
			this.pnlControl = new System.Windows.Forms.Panel();
			this.txtFormula = new System.Windows.Forms.TextBox();
			this.TrackBar = new System.Windows.Forms.TrackBar();
			this.lblK = new System.Windows.Forms.Label();
			this.optLine = new System.Windows.Forms.RadioButton();
			this.pnlEmpty = new System.Windows.Forms.Panel();
			this.lblFormula = new System.Windows.Forms.Label();
			this.txtK = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdStop = new System.Windows.Forms.Button();
			this.chkRun = new System.Windows.Forms.CheckBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.optPoint = new System.Windows.Forms.RadioButton();
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.updnSpeed)).BeginInit();
			this.updnSpeed.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
			this.pnlEmpty.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.pnlDisplay.SuspendLayout();
			this.SuspendLayout();
			// 
			// Timer
			// 
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(468, 176);
			this.pic.TabIndex = 1;
			this.pic.TabStop = false;
			// 
			// GroupBox1
			// 
			this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.chkAuto,
																					this.updnSpeed});
			this.GroupBox1.Location = new System.Drawing.Point(360, 296);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(112, 72);
			this.GroupBox1.TabIndex = 12;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Speed";
			// 
			// chkAuto
			// 
			this.chkAuto.Location = new System.Drawing.Point(8, 48);
			this.chkAuto.Name = "chkAuto";
			this.chkAuto.TabIndex = 1;
			this.chkAuto.Text = "Automatic";
			// 
			// updnSpeed
			// 
			this.updnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.updnSpeed.Location = new System.Drawing.Point(8, 20);
			this.updnSpeed.Maximum = new System.Decimal(new int[] {
																	  10,
																	  0,
																	  0,
																	  0});
			this.updnSpeed.Minimum = new System.Decimal(new int[] {
																	  1,
																	  0,
																	  0,
																	  0});
			this.updnSpeed.Name = "updnSpeed";
			this.updnSpeed.Size = new System.Drawing.Size(96, 23);
			this.updnSpeed.TabIndex = 0;
			this.updnSpeed.Value = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			// 
			// chkPause
			// 
			this.chkPause.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkPause.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkPause.BackColor = System.Drawing.SystemColors.Control;
			this.chkPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.chkPause.Location = new System.Drawing.Point(200, 312);
			this.chkPause.Name = "chkPause";
			this.chkPause.Size = new System.Drawing.Size(70, 40);
			this.chkPause.TabIndex = 19;
			this.chkPause.Text = "Pause";
			this.chkPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.chkPause.Click += new System.EventHandler(this.chkPause_Click);
			this.chkPause.CheckedChanged += new System.EventHandler(this.chkPause_CheckedChanged);
			// 
			// pnlControl
			// 
			this.pnlControl.BackColor = System.Drawing.Color.Transparent;
			this.pnlControl.Location = new System.Drawing.Point(8, 264);
			this.pnlControl.Name = "pnlControl";
			this.pnlControl.Size = new System.Drawing.Size(464, 16);
			this.pnlControl.TabIndex = 23;
			// 
			// txtFormula
			// 
			this.txtFormula.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtFormula.Location = new System.Drawing.Point(5, 254);
			this.txtFormula.Name = "txtFormula";
			this.txtFormula.ReadOnly = true;
			this.txtFormula.Size = new System.Drawing.Size(114, 20);
			this.txtFormula.TabIndex = 3;
			this.txtFormula.Text = "x2 = Kx(1-x)";
			// 
			// TrackBar
			// 
			this.TrackBar.AutoSize = false;
			this.TrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TrackBar.Location = new System.Drawing.Point(0, 194);
			this.TrackBar.Maximum = 4000;
			this.TrackBar.Name = "TrackBar";
			this.TrackBar.Size = new System.Drawing.Size(468, 42);
			this.TrackBar.SmallChange = 100;
			this.TrackBar.TabIndex = 0;
			this.TrackBar.TickFrequency = 100;
			this.TrackBar.ValueChanged += new System.EventHandler(this.TrackBar_ValueChanged);
			this.TrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
			// 
			// lblK
			// 
			this.lblK.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblK.Location = new System.Drawing.Point(5, 366);
			this.lblK.Name = "lblK";
			this.lblK.Size = new System.Drawing.Size(114, 24);
			this.lblK.TabIndex = 1;
			this.lblK.Text = "K Value";
			// 
			// optLine
			// 
			this.optLine.Location = new System.Drawing.Point(16, 40);
			this.optLine.Name = "optLine";
			this.optLine.Size = new System.Drawing.Size(64, 16);
			this.optLine.TabIndex = 1;
			this.optLine.Text = "Line";
			// 
			// pnlEmpty
			// 
			this.pnlEmpty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlEmpty.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lblFormula,
																				   this.txtFormula,
																				   this.txtK,
																				   this.lblK,
																				   this.Label2});
			this.pnlEmpty.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlEmpty.DockPadding.All = 5;
			this.pnlEmpty.Location = new System.Drawing.Point(488, 0);
			this.pnlEmpty.Name = "pnlEmpty";
			this.pnlEmpty.Size = new System.Drawing.Size(128, 399);
			this.pnlEmpty.TabIndex = 22;
			// 
			// lblFormula
			// 
			this.lblFormula.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFormula.Location = new System.Drawing.Point(5, 274);
			this.lblFormula.Name = "lblFormula";
			this.lblFormula.Size = new System.Drawing.Size(114, 24);
			this.lblFormula.TabIndex = 2;
			this.lblFormula.Text = "Formula";
			// 
			// txtK
			// 
			this.txtK.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtK.Location = new System.Drawing.Point(5, 346);
			this.txtK.Name = "txtK";
			this.txtK.ReadOnly = true;
			this.txtK.Size = new System.Drawing.Size(114, 20);
			this.txtK.TabIndex = 0;
			this.txtK.Text = "";
			// 
			// Label2
			// 
			this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.Label2.Location = new System.Drawing.Point(5, 5);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(114, 249);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "where x2, the population at the next generation, is equal to the population in th" +
				"is generation times a constant times the difference between this generations pop" +
				"ulation and one";
			// 
			// cmdStop
			// 
			this.cmdStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmdStop.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.cmdStop.Location = new System.Drawing.Point(272, 312);
			this.cmdStop.Name = "cmdStop";
			this.cmdStop.Size = new System.Drawing.Size(70, 40);
			this.cmdStop.TabIndex = 18;
			this.cmdStop.Text = "Stop";
			this.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
			// 
			// chkRun
			// 
			this.chkRun.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkRun.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkRun.BackColor = System.Drawing.SystemColors.Control;
			this.chkRun.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.chkRun.Location = new System.Drawing.Point(136, 312);
			this.chkRun.Name = "chkRun";
			this.chkRun.Size = new System.Drawing.Size(70, 40);
			this.chkRun.TabIndex = 20;
			this.chkRun.Text = "Run";
			this.chkRun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.chkRun.Click += new System.EventHandler(this.chkRun_Click);
			this.chkRun.CheckedChanged += new System.EventHandler(this.chkRun_CheckedChanged);
			// 
			// GroupBox2
			// 
			this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.optLine,
																					this.optPoint});
			this.GroupBox2.Location = new System.Drawing.Point(24, 296);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(112, 72);
			this.GroupBox2.TabIndex = 13;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Graph";
			// 
			// optPoint
			// 
			this.optPoint.Checked = true;
			this.optPoint.Location = new System.Drawing.Point(16, 20);
			this.optPoint.Name = "optPoint";
			this.optPoint.Size = new System.Drawing.Size(72, 16);
			this.optPoint.TabIndex = 0;
			this.optPoint.TabStop = true;
			this.optPoint.Text = "Points";
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlDisplay.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.pic,
																					 this.TrackBar});
			this.pnlDisplay.Location = new System.Drawing.Point(8, 8);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Size = new System.Drawing.Size(472, 240);
			this.pnlDisplay.TabIndex = 24;
			// 
			// PopGrowthTimed
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 399);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkPause,
																		  this.cmdStop,
																		  this.chkRun,
																		  this.GroupBox2,
																		  this.GroupBox1,
																		  this.pnlControl,
																		  this.pnlEmpty,
																		  this.pnlDisplay});
			this.Name = "PopGrowthTimed";
			this.Text = "Form1";
			this.GroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.updnSpeed)).EndInit();
			this.updnSpeed.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
			this.pnlEmpty.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.pnlDisplay.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PopGrowthTimed());
		}

		private void chkRun_CheckedChanged(object sender, System.EventArgs e)
		{

		}

		private void chkRun_Click(object sender, System.EventArgs e)
		{
			if (this.chkRun.Checked)
			{
				//user just checked the buton - start the demo
				EnableButtons(true);				
				TrackBar.Value = 0;
				Timer.Enabled = true;			
			}
		}

		private void chkPause_CheckedChanged(object sender, System.EventArgs e)
		{

		}

		private void chkPause_Click(object sender, System.EventArgs e)
		{
			Timer.Enabled = !chkPause.Checked;
		}

		private void cmdStop_Click(object sender, System.EventArgs e)
		{
			StopNow();
		}

		private void chkAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			updnSpeed.Enabled = !chkAuto.Checked;
		}

		private void SingleCycle()
		{
			int iGen;
			Single fPopSize;
			Graphics oGraphic;
			System.Drawing.Pen oPen = new System.Drawing.Pen(Color.Black, 20);
			Single x;
			Single y;
			Single xLast = 0;
			Single yLast = 0;
			Single k;
			Single fHeight;
			Single fWidth;
			bool bLines;

			fPopSize = Convert.ToSingle(0.02); // starting population
			
			pic.Refresh();
			oGraphic = pic.CreateGraphics();
			oPen = System.Drawing.Pens.Black;
			
			bLines = optLine.Checked;

			k = Convert.ToSingle(TrackBar.Value / 1000);
			fHeight = (oGraphic.VisibleClipBounds.Height) - 10;
			fWidth = (oGraphic.VisibleClipBounds.Width);
			yLast = fHeight;

			for (iGen = 1; iGen <= Generations; iGen++)
			{
				fPopSize = (k * fPopSize) * (1 - fPopSize);
				x = iGen * fWidth / Generations;
				y = fHeight - (fPopSize * fHeight) + 5;
				if (bLines)
				{
					oGraphic.DrawLine(oPen, xLast, yLast, x, y);
					yLast = y;
					xLast = x;
				}
				else
				{
					oGraphic.DrawRectangle(oPen, x, y, 2, 2);
				}
			}
        
			oGraphic.Dispose();
		}
    
		private void EnableButtons(bool bStart)
		{	
			//chkPause.Enabled = !bStart;
			chkRun.Checked = false;
		}											

		private void TrackBar_Scroll(object sender, System.EventArgs e)
		{

		}

		private void TrackBar_ValueChanged(object sender, System.EventArgs e)
		{
			double fValue;

			fValue = TrackBar.Value / 1000;
			txtK.Text = fValue.ToString("0.0000");
			SingleCycle();
		}

		private void Timer_Tick(object sender, System.EventArgs e)
		{
			int iInterval;
			int iMultiplier;
			int iValue;

			if (chkAuto.Checked)
			{
				if (TrackBar.Value < 1000)
				{
					iMultiplier = 1000;
				}
				else if (TrackBar.Value < 3400)
				{
					iMultiplier = 100;
				}
				else if (TrackBar.Value < 3700)
				{
					iMultiplier = 10;
				}
				else
				{
					iMultiplier = 1;
				}
			}
			else
			{
				iMultiplier = Convert.ToInt16(updnSpeed.Value * 10);
			}
			iInterval = iMultiplier;

			iValue = TrackBar.Value + iInterval;
			if (iValue < TrackBar.Maximum)
			{
				TrackBar.Value = iValue;
			}
			else
			{
				StopNow();
			}
		}

		private void StopNow()
		{
			TrackBar.Value = 0;
			EnableButtons(false);
			Timer.Enabled = false;
		}
	}
}
