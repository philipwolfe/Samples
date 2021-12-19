using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace ADDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtBaseDN;
		private System.Windows.Forms.TextBox txtProperties;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
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
			this.Label3 = new System.Windows.Forms.Label();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtBaseDN = new System.Windows.Forms.TextBox();
			this.txtProperties = new System.Windows.Forms.TextBox();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3.Location = new System.Drawing.Point(48, 88);
			this.Label3.Size = new System.Drawing.Size(32, 16);
			this.Label3.TabIndex = 4;
			this.Label3.Text = "Filter";
			this.txtResult.Location = new System.Drawing.Point(72, 200);
			this.txtResult.Size = new System.Drawing.Size(208, 20);
			this.txtResult.TabIndex = 7;
			this.txtResult.Text = "";
			this.btnSearch.Location = new System.Drawing.Point(120, 168);
			this.btnSearch.Size = new System.Drawing.Size(76, 24);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.txtBaseDN.Location = new System.Drawing.Point(88, 116);
			this.txtBaseDN.Size = new System.Drawing.Size(160, 20);
			this.txtBaseDN.TabIndex = 7;
			this.txtBaseDN.Text = "cn=Container,dc=domain,dc=com";
			this.txtProperties.Location = new System.Drawing.Point(88, 20);
			this.txtProperties.Size = new System.Drawing.Size(160, 20);
			this.txtProperties.TabIndex = 0;
			this.txtProperties.Text = "mail";
			this.txtServerName.Location = new System.Drawing.Point(88, 52);
			this.txtServerName.Size = new System.Drawing.Size(160, 20);
			this.txtServerName.TabIndex = 2;
			this.txtServerName.Text = "ServerName";
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtBaseDN,
																					this.txtFilter,
																					this.Label4,
																					this.Label3,
																					this.Label2,
																					this.txtServerName,
																					this.Label1,
																					this.txtProperties});
			this.GroupBox1.Location = new System.Drawing.Point(8, 8);
			this.GroupBox1.Size = new System.Drawing.Size(280, 152);
			this.GroupBox1.TabIndex = 5;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Specify Search Parameters:";
			this.txtFilter.Location = new System.Drawing.Point(88, 84);
			this.txtFilter.Size = new System.Drawing.Size(160, 20);
			this.txtFilter.TabIndex = 6;
			this.txtFilter.Text = "cn=user@domain.com";
			this.Label4.Location = new System.Drawing.Point(32, 120);
			this.Label4.Size = new System.Drawing.Size(48, 16);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "BaseDN";
			this.Label5.Location = new System.Drawing.Point(24, 204);
			this.Label5.Size = new System.Drawing.Size(48, 16);
			this.Label5.TabIndex = 6;
			this.Label5.Text = "Result";
			this.Label1.Location = new System.Drawing.Point(24, 24);
			this.Label1.Size = new System.Drawing.Size(64, 16);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Properties";
			this.Label2.Location = new System.Drawing.Point(8, 56);
			this.Label2.Size = new System.Drawing.Size(80, 16);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Server Name";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtResult,
																		  this.Label5,
																		  this.GroupBox1,
																		  this.btnSearch});
			this.Text = "Active Directory Search";

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

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			System.DirectoryServices.DirectorySearcher objDS;
			System.DirectoryServices.DirectoryEntry objDE;
			string[] strPropertiesToLoad = new string[1];
			string strServerName;
			string strFilter;
			string strBase;

			//Store values from form in local variables
			strPropertiesToLoad[0] = txtProperties.Text;
			strServerName = txtServerName.Text;
			strFilter = txtFilter.Text;
			strBase = txtBaseDN.Text;

			try
			{
				//Create a Directory Entry object.  This stores the path
				//to our server and the baseDN.  There are multiple overloads to 
				//accomodate secure logon as well.
				objDE = new System.DirectoryServices.DirectoryEntry("LDAP://" + strServerName + "/" + strBase);

				//Create a DirectorySearcher object.  In this case we pass a DirectoryEntry
				//object as the search root, a string for the filter and an array of properties
				//which we want the search to return.
				objDS = new System.DirectoryServices.DirectorySearcher(objDE, strFilter, strPropertiesToLoad);

				//DirectorySearcher.FindAll returns a SearchResult collection of 
				//SearchResultsEntrys
				foreach (System.DirectoryServices.SearchResult objResultsEntry in objDS.FindAll())
				{
					txtResult.Text = Convert.ToString(objResultsEntry.Properties[strPropertiesToLoad[0]].ToString());
					
				}
			}
			catch (Exception excp)
			{
				MessageBox.Show(excp.Message, "Exception Caught");
			}
		}
	}
}
