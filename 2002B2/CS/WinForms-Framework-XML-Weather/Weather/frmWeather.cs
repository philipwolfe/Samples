using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace Weather
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cboCity;
		private System.Windows.Forms.Button btnGetWeather;
		private System.Windows.Forms.Label Label1;
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
			this.cboCity = new System.Windows.Forms.ComboBox();
			this.btnGetWeather = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCity.DropDownWidth = 121;
			this.cboCity.Location = new System.Drawing.Point(56, 12);
			this.cboCity.Size = new System.Drawing.Size(121, 21);
			this.cboCity.TabIndex = 3;
			this.btnGetWeather.Location = new System.Drawing.Point(72, 56);
			this.btnGetWeather.Size = new System.Drawing.Size(104, 23);
			this.btnGetWeather.TabIndex = 0;
			this.btnGetWeather.Text = "Get Weather";
			this.btnGetWeather.Click += new System.EventHandler(this.btnGetWeather_Click);
			this.Label1.Location = new System.Drawing.Point(16, 16);
			this.Label1.Size = new System.Drawing.Size(32, 23);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "City:";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(235, 104);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnGetWeather,
																		  this.Label1,
																		  this.cboCity});
			this.Text = "Forcast";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void btnGetWeather_Click(object sender, System.EventArgs e)
		{
			try
			{
				//declarations
				string strCity  = this.cboCity.Text.Trim();
				string strWeather;
				XmlDocument doc = new XmlDocument();
				System.Xml.XPath.XPathNavigator nav;//= new System.Xml.XPath.XPathNavigator();
				System.Xml.XPath.XPathNodeIterator iterator;// = new System.Xml.XPath.XPathNodeIterator();

				//validation
				if (strCity == "")
				{
					throw new ArgumentNullException("City", "You must enter a city.");
				}

				//load document
				doc.Load("..\\..\\xml\\weather.xml");
				
				//set nav object
				nav = ((System.Xml.XPath.IXPathNavigable)(doc)).CreateNavigator();

				//set node iterator
				iterator = nav.Select("weather/" + strCity);

				//move to the desired node
				iterator.MoveNext();

				//get the value of the current node
				strWeather = iterator.Current.Value;

				//display weather
				MessageBox.Show(strWeather, "Today's Weather for: " + strCity);
			}
			catch(System.Exception err)
			{
				//display error
				MessageBox.Show(err.Message, "ERROR!");
			}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
			//populate the valid cities
			this.cboCity.Items.Add("Chicago");
			this.cboCity.Items.Add("Houston");
			this.cboCity.Items.Add("LA");
		}
	}
}
