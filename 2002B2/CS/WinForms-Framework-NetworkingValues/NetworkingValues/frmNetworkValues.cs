using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
namespace NetworkingValues
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblIPAddress;
		private System.Windows.Forms.Label lblComputerName;
		private System.Windows.Forms.TextBox txtComputerName;
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.Button btnNetworkValues;
		/// <summary>
		/// Required designer variable.
		/// </summary>

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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblIPAddress = new System.Windows.Forms.Label();
			this.btnNetworkValues = new System.Windows.Forms.Button();
			this.lblComputerName = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.txtComputerName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblIPAddress
			// 
			this.lblIPAddress.Location = new System.Drawing.Point(16, 72);
			this.lblIPAddress.Name = "lblIPAddress";
			this.lblIPAddress.Size = new System.Drawing.Size(112, 16);
			this.lblIPAddress.TabIndex = 1;
			this.lblIPAddress.Text = "IP Address:";
			// 
			// btnNetworkValues
			// 
			this.btnNetworkValues.Location = new System.Drawing.Point(216, 120);
			this.btnNetworkValues.Name = "btnNetworkValues";
			this.btnNetworkValues.Size = new System.Drawing.Size(120, 24);
			this.btnNetworkValues.TabIndex = 3;
			this.btnNetworkValues.Text = "Get Network Values";
			this.btnNetworkValues.Click += new System.EventHandler(this.btnNetworkValues_Click);
			// 
			// lblComputerName
			// 
			this.lblComputerName.Location = new System.Drawing.Point(16, 32);
			this.lblComputerName.Name = "lblComputerName";
			this.lblComputerName.Size = new System.Drawing.Size(112, 16);
			this.lblComputerName.TabIndex = 1;
			this.lblComputerName.Text = "Computer Name:";
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(136, 72);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(200, 20);
			this.txtIPAddress.TabIndex = 2;
			this.txtIPAddress.Text = "";
			// 
			// txtComputerName
			// 
			this.txtComputerName.Location = new System.Drawing.Point(136, 32);
			this.txtComputerName.Name = "txtComputerName";
			this.txtComputerName.Size = new System.Drawing.Size(200, 20);
			this.txtComputerName.TabIndex = 2;
			this.txtComputerName.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(387, 152);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnNetworkValues,
																		  this.txtIPAddress,
																		  this.txtComputerName,
																		  this.lblIPAddress,
																		  this.lblComputerName});
			this.Name = "Form1";
			this.Text = "frmNetworkValues";
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

		
		private void btnNetworkValues_Click(object sender, System.EventArgs e)
		{
			string hostName;

			//Set string equal to value of System DNS Object value for GetHostName
			//This should be the localhost computer name
			hostName = System.Net.Dns.GetHostName();
			this.txtComputerName.Text = hostName;
			this.txtIPAddress.Text = getIPAddress();
		}
	
		private static string getIPAddress()
		{
			System.Net.IPAddress addr;
			
			// Get the IP address for this machine
			addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);		
		
			return addr.ToString();
		}


		

		
	}
}
