using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace CultureRegion
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCultureRegion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

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
			this.btnCultureRegion = new System.Windows.Forms.Button();
			this.btnCultureRegion.Location = new System.Drawing.Point(24, 32);
			this.btnCultureRegion.Size = new System.Drawing.Size(112, 24);
			this.btnCultureRegion.TabIndex = 0;
			this.btnCultureRegion.Text = "CultureRegion";
			this.btnCultureRegion.Click += new System.EventHandler(this.btnCultureRegion_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(171, 96);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCultureRegion});
			this.Text = "frmCultureRegion";

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

		private void btnCultureRegion_Click(object sender, System.EventArgs e)
		{
			//set the culture to English - US and retrieve the information
			System.Globalization.CultureInfo c;
			string strReturn;
			c = new System.Globalization.CultureInfo("en-us");

			strReturn = "The CultureInfo is set to: " + c.DisplayName + Convert.ToChar(10);
			strReturn = strReturn + "The parent culture is: " + c.Parent.DisplayName + Convert.ToChar(10);
			strReturn = strReturn + "The three letter ISO language name is: " + c.ThreeLetterISOLanguageName + Convert.ToChar(10);
			strReturn = strReturn + "The default calendar for this culture is: " + c.Calendar.ToString() + Convert.ToChar(10);
		    strReturn = strReturn + Convert.ToChar(10);

			System.Globalization.RegionInfo r;
			r = new System.Globalization.RegionInfo("us");

			strReturn = strReturn + "The name of this region is: " + r.Name + Convert.ToChar(10);
			strReturn = strReturn + "The currency symbol for the region is: " + r.CurrencySymbol + Convert.ToChar(10);
			strReturn = strReturn + "Is this region metric : " + r.IsMetric + Convert.ToChar(10);
			strReturn = strReturn + Convert.ToChar(10);

			//Set the Culture to German - Switzerland and retrieve the information        
			System.Globalization.CultureInfo c2;
			c2 = new System.Globalization.CultureInfo("de-ch");
			strReturn = strReturn + "The CultureInfo is set to: " + c2.DisplayName + Convert.ToChar(10);
			strReturn = strReturn + "The parent culture is: " + c2.Parent.DisplayName + Convert.ToChar(10);
			strReturn = strReturn + "The three leter ISO language name is:" + c2.ThreeLetterISOLanguageName + Convert.ToChar(10);
			strReturn = strReturn + "The default calendar for this culture is: " + c2.Calendar.ToString() + Convert.ToChar(10);
			strReturn = strReturn + Convert.ToChar(10);

			System.Globalization.RegionInfo r2;
		    r2 = new System.Globalization.RegionInfo("de");
			strReturn = strReturn + "The name of this region is: " + r2.Name + Convert.ToChar(10);
			strReturn = strReturn + "The currency symbol for the region is: " + r2.CurrencySymbol + Convert.ToChar(10);
			strReturn = strReturn + "Is this region metric : " + r2.IsMetric + Convert.ToChar(10);

	        MessageBox.Show(strReturn, "CultureRegion Information");
		}
	}
}
