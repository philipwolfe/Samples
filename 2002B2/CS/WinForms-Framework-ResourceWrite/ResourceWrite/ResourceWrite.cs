using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Reflection;

namespace ResourceWrite
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnResource;
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
			this.btnResource = new System.Windows.Forms.Button();
			this.btnResource.Location = new System.Drawing.Point(32, 32);
			this.btnResource.Size = new System.Drawing.Size(112, 24);
			this.btnResource.TabIndex = 0;
			this.btnResource.Text = "Create Resource";
			this.btnResource.Click += new System.EventHandler(this.btnResource_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(179, 104);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnResource});
			this.Text = "ResourceWrite";

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

		private void btnResource_Click(object sender, System.EventArgs e)
		{
			
			ResourceWriter resourceWriter; 
			
	        //Create a .resources file and add one string.
		    resourceWriter = new ResourceWriter("Greeting.resources");
			resourceWriter.AddResource("Greeting", "Welcome to Microsoft .Net Framework !");
			resourceWriter.Generate();
			resourceWriter.Close();

			//Testing the resource file.
			
			ResourceReader rd = new ResourceReader("Greeting.resources");
			IDictionaryEnumerator en = rd.GetEnumerator();
 			 
			en.MoveNext();
			MessageBox.Show("Resource Added to /bin directory of ResoruceWrite: " +en.Value.ToString(), "Resource");


		}
	}
}
