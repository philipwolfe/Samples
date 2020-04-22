using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Kokuti.EnterpriseLibrary.AppSettings;

namespace AppSettingsDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.TextBox txtValue;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtKey = new System.Windows.Forms.TextBox();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGet = new System.Windows.Forms.Button();
			this.btnSet = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(80, 8);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(256, 20);
			this.txtKey.TabIndex = 0;
			this.txtKey.Text = "TestKey";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(80, 40);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(256, 20);
			this.txtValue.TabIndex = 1;
			this.txtValue.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Key:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Value:";
			// 
			// btnGet
			// 
			this.btnGet.Location = new System.Drawing.Point(80, 72);
			this.btnGet.Name = "btnGet";
			this.btnGet.TabIndex = 4;
			this.btnGet.Text = "Get";
			this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
			// 
			// btnSet
			// 
			this.btnSet.Location = new System.Drawing.Point(176, 72);
			this.btnSet.Name = "btnSet";
			this.btnSet.TabIndex = 5;
			this.btnSet.Text = "Set";
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(264, 72);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 110);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnSet);
			this.Controls.Add(this.btnGet);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.txtKey);
			this.Name = "Form1";
			this.Text = "AppSettings Demo";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			AppSettingsHelper.AppSettingsChangedEvent += new AppSettingsHelper.AppSettingsChangedDelegate(AppSettingsChangedHandler);
		}

		private void AppSettingsChangedHandler()
		{
			// get settings value and display in the value field
			txtValue.Text = AppSettingsHelper.AppSettings[txtKey.Text];
		}

		private void btnGet_Click(object sender, System.EventArgs e)
		{
			// get settings value and display in the value field
			txtValue.Text = AppSettingsHelper.AppSettings[txtKey.Text];
		}

		private void btnSet_Click(object sender, System.EventArgs e)
		{
			// set settings value to the value in the value field
			AppSettingsHelper.AppSettings[txtKey.Text] = txtValue.Text;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// save setting to storage
			AppSettingsHelper.Save();
		}
	}
}
