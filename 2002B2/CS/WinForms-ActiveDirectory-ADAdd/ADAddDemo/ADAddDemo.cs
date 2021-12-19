using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ADAddDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtBase;
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
			this.txtServer = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtBase = new System.Windows.Forms.TextBox();
			this.txtServer.Location = new System.Drawing.Point(8, 32);
			this.txtServer.Size = new System.Drawing.Size(252, 20);
			this.txtServer.TabIndex = 2;
			this.txtServer.Text = "servername.domain.com";
			this.Label1.Location = new System.Drawing.Point(8, 16);
			this.Label1.Size = new System.Drawing.Size(224, 16);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Specify your Active Directory Server/Domain:";
			this.Label2.Location = new System.Drawing.Point(8, 64);
			this.Label2.Size = new System.Drawing.Size(236, 12);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Specify the base container to modify:";
			this.btnAdd.Location = new System.Drawing.Point(172, 116);
			this.btnAdd.Size = new System.Drawing.Size(88, 24);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add User";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.txtBase.Location = new System.Drawing.Point(12, 80);
			this.txtBase.Size = new System.Drawing.Size(248, 20);
			this.txtBase.TabIndex = 4;
			this.txtBase.Text = "cn=ContainerName,dc=DomainName,dc=com";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(268, 157);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnAdd,
																		  this.Label2,
																		  this.txtBase,
																		  this.Label1,
																		  this.txtServer});
			this.Text = "Active Directory Add User";

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

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			System.DirectoryServices.DirectoryEntry objADe;
			System.DirectoryServices.DirectoryEntry objADeNew;
			string strServerName;
			string strBase;
			//The container that ContainerName points to must be one which the
			//code has permission to change.  

			try
			{
				//grab the values from the text boxes
				strServerName = txtServer.Text;
				strBase = txtBase.Text;

				objADe = new System.DirectoryServices.DirectoryEntry("LDAP://"  + strServerName + "/" + strBase);
				//In this case the AD has a class TestUser which has one mandatory attribut: name.
				//In order to use this demo this class must be created or the code changed to 
				//an existing one.
				objADeNew = objADe.Children.Add("CN=Tester Test2", "Contact");
				//objADeNew.Properties().Item("name") = "username2"
				//... Continue setting the properties required for your class

				//All mandatory attributes must be set before .CommitChanges is called.
				//If you catch an exception make sure that you are setting all mandatory attribs.
				objADeNew.CommitChanges();
			}
			catch (Exception excp)
			{
				MessageBox.Show(excp.Message);
			}
		}
	}
}
