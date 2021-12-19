using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace GDIPlusShape
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ButtonStop;
		private System.Windows.Forms.Button ButtonVisibility;
		private System.Windows.Forms.Button ButtonStart;
		private System.Windows.Forms.Button ButtonShape;
		private System.Windows.Forms.Timer Timer1;
		private System.ComponentModel.IContainer components;

		private bool ShowDotNet = true;
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
			this.ButtonStop = new System.Windows.Forms.Button();
			this.ButtonVisibility = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonShape = new System.Windows.Forms.Button();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.ButtonStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonStop.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.ButtonStop.ForeColor = System.Drawing.Color.RosyBrown;
			this.ButtonStop.Location = new System.Drawing.Point(16, 8);
			this.ButtonStop.Size = new System.Drawing.Size(144, 104);
			this.ButtonStop.TabIndex = 1;
			this.ButtonStop.Text = "Stop Me!";
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			this.ButtonVisibility.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ButtonVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonVisibility.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.ButtonVisibility.ForeColor = System.Drawing.Color.RosyBrown;
			this.ButtonVisibility.Location = new System.Drawing.Point(16, 136);
			this.ButtonVisibility.Size = new System.Drawing.Size(144, 104);
			this.ButtonVisibility.TabIndex = 3;
			this.ButtonVisibility.Text = "Thin Me!";
			this.ButtonVisibility.Click += new System.EventHandler(this.ButtonVisibility_Click);
			this.ButtonStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonStart.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.ButtonStart.ForeColor = System.Drawing.Color.RosyBrown;
			this.ButtonStart.Location = new System.Drawing.Point(16, 256);
			this.ButtonStart.Size = new System.Drawing.Size(144, 104);
			this.ButtonStart.TabIndex = 0;
			this.ButtonStart.Text = "Start Me!";
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			this.ButtonShape.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ButtonShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonShape.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.ButtonShape.ForeColor = System.Drawing.Color.RosyBrown;
			this.ButtonShape.Location = new System.Drawing.Point(184, 8);
			this.ButtonShape.Size = new System.Drawing.Size(144, 104);
			this.ButtonShape.TabIndex = 2;
			this.ButtonShape.Text = "Shape Me!";
			this.ButtonShape.Click += new System.EventHandler(this.ButtonShape_Click);
			this.Timer1.Interval = 500;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Orange;
			this.ClientSize = new System.Drawing.Size(856, 527);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.ButtonShape,
																		  this.ButtonStart,
																		  this.ButtonStop,
																		  this.ButtonVisibility});
			this.Text = "Form1";

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

		private void ButtonStop_Click(object sender, System.EventArgs e)
		{
			// End the application
			Application.Exit();
		}

		private void ButtonShape_Click(object sender, System.EventArgs e)
		{
			// Alter the shape of the form
			applyInitialRegion();
		}

		private void ButtonVisibility_Click(object sender, System.EventArgs e)
		{	
			// Change the forms opacity
			this.Opacity = 0.4;
		}

		private void ButtonStart_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			this.Opacity = 1;
			this.Region = null;
			
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.BackgroundImage = (System.Drawing.Image) (resources.GetObject("$this.BackgroundImage"));
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			Timer1.Start();
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			if (ShowDotNet)
			{
				this.applyDotNetRegion();
				ShowDotNet = false;
			}
			else
            {
				this.applyRocksRegion();
				ShowDotNet = true;
			}
		}
		private void applyInitialRegion()
		{
			GraphicsPath myGraphicsPath = new GraphicsPath();
			string stringText = ".net";
			FontFamily  family = new FontFamily("Arial");
			int style  = Convert.ToInt16(FontStyle.Bold);
			int emSize = 300;
			PointF origin = new PointF(97, 50);
			StringFormat format = StringFormat.GenericDefault;
			
			myGraphicsPath.AddString(stringText, family, style, emSize, origin, format);
			myGraphicsPath.AddEllipse(new Rectangle(0, 0, 200, 450));
			this.Region = new Region(myGraphicsPath); // [Region](myGraphicsPath);
		}
    
    
		private void applyDotNetRegion()
		{
			GraphicsPath myGraphicsPath = new GraphicsPath();
			string stringText= ".net";
			FontFamily  family= new FontFamily("Arial");
			int style = Convert.ToInt16(FontStyle.Bold);
			int emSize = 300;
			PointF origin = new PointF(90, 50);
			StringFormat format = StringFormat.GenericDefault;
			
			myGraphicsPath.AddString(stringText, family, style, emSize, origin, format);
			myGraphicsPath.AddEllipse(new Rectangle(0, 0, 150, 150));
			this.Region = new Region(myGraphicsPath);
		}
    
		private void applyRocksRegion()
		{
			GraphicsPath myGraphicsPath = new GraphicsPath();
			string stringText = "Rocks!";
			FontFamily family = new FontFamily("Arial");
			int style = Convert.ToInt16(FontStyle.Bold | FontStyle.Italic);
			int emSize= 250;
			PointF origin= new PointF(120, 250);
			StringFormat format = StringFormat.GenericDefault;
			
			myGraphicsPath.AddString(stringText, family, style, emSize, origin, format);
			myGraphicsPath.AddEllipse(new Rectangle(0, 0, 150, 150));
			this.Region = new Region(myGraphicsPath);
		}
	}
}
