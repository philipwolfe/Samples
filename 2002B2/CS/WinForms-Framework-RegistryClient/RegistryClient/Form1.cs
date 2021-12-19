using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
namespace RegistryClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.TextBox txtEntry;
		private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.TextBox txtGetEntry;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.Label Label7;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Label Label6;
		private System.Windows.Forms.TextBox txtKey;
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
			this.components = new System.ComponentModel.Container();
			this.Label3 = new System.Windows.Forms.Label();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnGet = new System.Windows.Forms.Button();
			this.txtEntry = new System.Windows.Forms.TextBox();
			this.lblValue = new System.Windows.Forms.Label();
			this.txtGetEntry = new System.Windows.Forms.TextBox();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.btnSet = new System.Windows.Forms.Button();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3.Location = new System.Drawing.Point(16, 124);
			this.Label3.Size = new System.Drawing.Size(68, 16);
			this.Label3.TabIndex = 15;
			this.Label3.Text = "Value:";
			this.btnCreate.Location = new System.Drawing.Point(264, 36);
			this.btnCreate.TabIndex = 11;
			this.btnCreate.Text = "Create";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			this.btnGet.Location = new System.Drawing.Point(268, 208);
			this.btnGet.TabIndex = 20;
			this.btnGet.Text = "Get";
			this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
			this.txtEntry.Location = new System.Drawing.Point(84, 92);
			this.txtEntry.Size = new System.Drawing.Size(172, 20);
			this.txtEntry.TabIndex = 13;
			this.txtEntry.Text = "SampleValue";
			this.lblValue.Location = new System.Drawing.Point(92, 216);
			this.lblValue.Size = new System.Drawing.Size(168, 16);
			this.lblValue.TabIndex = 24;
			this.txtGetEntry.Location = new System.Drawing.Point(88, 184);
			this.txtGetEntry.Size = new System.Drawing.Size(172, 20);
			this.txtGetEntry.TabIndex = 19;
			this.txtGetEntry.Text = "SampleValue";
			this.txtValue.Location = new System.Drawing.Point(84, 120);
			this.txtValue.Size = new System.Drawing.Size(172, 20);
			this.txtValue.TabIndex = 16;
			this.txtValue.Text = "My Test Value";
			this.btnSet.Location = new System.Drawing.Point(264, 116);
			this.btnSet.TabIndex = 14;
			this.btnSet.Text = "Set";
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			this.Label7.Location = new System.Drawing.Point(16, 164);
			this.Label7.Size = new System.Drawing.Size(340, 16);
			this.Label7.TabIndex = 23;
			this.Label7.Text = "Specify the Registry value to read:";
			this.Label4.Location = new System.Drawing.Point(12, 72);
			this.Label4.Size = new System.Drawing.Size(340, 16);
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Specify the Registry value to set:";
			this.Label5.Location = new System.Drawing.Point(20, 188);
			this.Label5.Size = new System.Drawing.Size(68, 16);
			this.Label5.TabIndex = 18;
			this.Label5.Text = "Entry:";
			this.Label6.Location = new System.Drawing.Point(20, 216);
			this.Label6.Size = new System.Drawing.Size(68, 16);
			this.Label6.TabIndex = 21;
			this.Label6.Text = "Value:";
			this.txtKey.Location = new System.Drawing.Point(16, 36);
			this.txtKey.Size = new System.Drawing.Size(240, 20);
			this.txtKey.TabIndex = 10;
			this.txtKey.Text = "Software\\CSharp Registry Test";
			this.Label1.Location = new System.Drawing.Point(16, 16);
			this.Label1.Size = new System.Drawing.Size(340, 16);
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Specify the HKEY_CURRENT_USER Registry Key to Create:";
			this.Label2.Location = new System.Drawing.Point(16, 96);
			this.Label2.Size = new System.Drawing.Size(68, 16);
			this.Label2.TabIndex = 12;
			this.Label2.Text = "Entry:";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 265);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2,
																		  this.Label1,
																		  this.txtKey,
																		  this.Label7,
																		  this.txtEntry,
																		  this.txtValue,
																		  this.btnGet,
																		  this.Label5,
																		  this.btnSet,
																		  this.Label4,
																		  this.Label6,
																		  this.txtGetEntry,
																		  this.lblValue,
																		  this.btnCreate,
																		  this.Label3});
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

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
		   //create the requested registry key
			RegistryKey oReg;

			//create the new registry key under HKEY_CURRENT_USER
			oReg = Registry.CurrentUser.CreateSubKey(txtKey.Text);

			//let the user know it//s done
			MessageBox.Show("Registry Key " + oReg.Name + " was created.", "Registry Client");

		}


		private void btnSet_Click(object sender, System.EventArgs e)
		{
			//Set the new registry value
			RegistryKey oReg;

			//open the key with write access
			oReg = Registry.CurrentUser.OpenSubKey(txtKey.Text, true);
			//setup the value
			oReg.SetValue(txtEntry.Text, txtValue.Text);

			//let the user know it//s done
			MessageBox.Show("Registry Value " + txtEntry.Text + " - " + txtValue.Text + " saved.", "Registry Client");

			//close the key
			oReg.Close();
		}

		private void btnGet_Click(object sender, System.EventArgs e)
		{
		   //get the requested registry value
			RegistryKey oReg;

			//open the registry key
			oReg = Registry.CurrentUser.OpenSubKey(txtKey.Text);

			//get the requested value
			lblValue.Text = oReg.GetValue(txtGetEntry.Text).ToString();

			//close the key
			oReg.Close();
		}
	}
}
