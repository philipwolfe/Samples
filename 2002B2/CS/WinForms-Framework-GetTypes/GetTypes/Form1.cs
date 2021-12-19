using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace GetTypes
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGetTypes;
		private System.Windows.Forms.TextBox txtTypes;
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
			this.btnGetTypes = new System.Windows.Forms.Button();
			this.txtTypes = new System.Windows.Forms.TextBox();
			this.btnGetTypes.Location = new System.Drawing.Point(8, 8);
			this.btnGetTypes.TabIndex = 0;
			this.btnGetTypes.Text = "Get Types";
			this.btnGetTypes.Click += new System.EventHandler(this.btnGetTypes_Click);
			this.txtTypes.AcceptsReturn = true;
			this.txtTypes.AcceptsTab = true;
			this.txtTypes.Location = new System.Drawing.Point(8, 40);
			this.txtTypes.Multiline = true;
			this.txtTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTypes.Size = new System.Drawing.Size(584, 480);
			this.txtTypes.TabIndex = 1;
			this.txtTypes.Text = "";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 549);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtTypes,
																		  this.btnGetTypes});
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

		private void btnGetTypes_Click(object sender, System.EventArgs e)
		{
			string s = "";
			//List all the types from the mscorlib assembly.
			//Get the mscorlib assembly, it's the one Object is defined in
			Assembly a = typeof(Object).Module.Assembly;

			//Get all the types in this assembly
			Type[] types = a.GetTypes();

			//let's take a look at them, and gather a little bit of data as we do it.
			int numValueTypes = 0;
			int numInterfaces = 0;
	        
			s = s + "Get all the types from the assembly: " + a.GetName().ToString() + "\r\n";
			foreach (Type t in types)
			{
				s = s + t.FullName + "\r\n";
				if (t.IsInterface)
				{
					numInterfaces += 1;
				}
				if (t.IsValueType)
				{
					numValueTypes += 1;
				}
			}
			
			s = s + "Out of " + types.Length + " types, " + numInterfaces + " are interfaces and " + numValueTypes + " are value types" + "\r\n";
			
			//Load an assembly from disk, just so happens it's THIS assembly
			System.Reflection.Assembly b = System.Reflection.Assembly.LoadFrom("gettypes.exe");
			Type[] types2 = b.GetTypes();

			foreach (Type t2 in types2)
			{
				s = s + t2.FullName + "\r\n";
			}

			txtTypes.Text = s;
		}
	}
}
