using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Web.Services;



namespace BrowseViewsClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox dbName;
		private System.Windows.Forms.ComboBox views;
		private System.Windows.Forms.Button Query;
		private System.Windows.Forms.Button Login;
		private System.Windows.Forms.DataGrid Result;

		
		private localhost.Service1 browseService = new localhost.Service1();
		private System.Windows.Forms.TextBox serverName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		
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
		public override void Dispose()
		{
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.views = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.userName = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.Query = new System.Windows.Forms.Button();
			this.dbName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Login = new System.Windows.Forms.Button();
			this.serverName = new System.Windows.Forms.TextBox();
			this.Result = new System.Windows.Forms.DataGrid();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
			this.Result.SuspendLayout();
			this.SuspendLayout();
			// 
			// views
			// 
			this.views.DropDownWidth = 232;
			this.views.Location = new System.Drawing.Point(96, 88);
			this.views.Name = "views";
			this.views.Size = new System.Drawing.Size(232, 21);
			this.views.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Server";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(224, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "UserID:";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(224, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Password:";
			// 
			// userName
			// 
			this.userName.Location = new System.Drawing.Point(336, 24);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(104, 20);
			this.userName.TabIndex = 1;
			this.userName.Text = "sa";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(336, 56);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(104, 20);
			this.password.TabIndex = 1;
			this.password.Text = "";
			// 
			// Query
			// 
			this.Query.Location = new System.Drawing.Point(344, 88);
			this.Query.Name = "Query";
			this.Query.Size = new System.Drawing.Size(80, 24);
			this.Query.TabIndex = 3;
			this.Query.Text = "Get Query";
			this.Query.Click += new System.EventHandler(this.Query_Click);
			// 
			// dbName
			// 
			this.dbName.Location = new System.Drawing.Point(112, 56);
			this.dbName.Name = "dbName";
			this.dbName.Size = new System.Drawing.Size(104, 20);
			this.dbName.TabIndex = 1;
			this.dbName.Text = "Northwind";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.label4,
																					this.label3,
																					this.label2,
																					this.label1,
																					this.Login,
																					this.Query,
																					this.views,
																					this.userName,
																					this.password,
																					this.serverName,
																					this.dbName});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Database Connection";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "DB:";
			// 
			// Login
			// 
			this.Login.Location = new System.Drawing.Point(8, 88);
			this.Login.Name = "Login";
			this.Login.Size = new System.Drawing.Size(80, 24);
			this.Login.TabIndex = 3;
			this.Login.Text = "Get Views";
			this.Login.Click += new System.EventHandler(this.Login_Click);
			// 
			// serverName
			// 
			this.serverName.Location = new System.Drawing.Point(112, 24);
			this.serverName.Name = "serverName";
			this.serverName.Size = new System.Drawing.Size(104, 20);
			this.serverName.TabIndex = 1;
			this.serverName.Text = "localhost";
			// 
			// Result
			// 
			this.Result.DataMember = "";
			this.Result.Location = new System.Drawing.Point(8, 136);
			this.Result.Name = "Result";
			this.Result.Size = new System.Drawing.Size(456, 136);
			this.Result.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Result,
																		  this.groupBox1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
			this.Result.ResumeLayout(false);
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

		private void Login_Click(object sender, System.EventArgs e)
		{
			DataSet viewsSet = new DataSet();
			
			//Prepare parameters for web service
			localhost.DBConnData dbConn = new localhost.DBConnData();
			dbConn.serverName = serverName.Text.ToString();
			dbConn.dbName = dbName.Text.ToString();
			dbConn.userName = userName.Text.ToString();
			dbConn.pwd = password.Text.ToString();
        
			//Call web service
			viewsSet = browseService.GetAllViews(dbConn);

	        //Fill combo box with view names
			views.Items.Clear();
			foreach (DataRow viewRow in viewsSet.Tables[0].Rows)
			{
				views.Items.Add("[" + viewRow[0].ToString() + "].[" + viewRow[1].ToString() + "]");
			}
			views.SelectedIndex = 0;
		}

		private void Query_Click(object sender, System.EventArgs e)
		{
			if (views.SelectedIndex != (-1)) 
			{
				DataSet viewsSet = new DataSet();
				//Prepare parameters for web service
				localhost.DBConnData dbConn = new localhost.DBConnData();
				dbConn.serverName = serverName.Text.ToString();
				dbConn.dbName = dbName.Text.ToString();
				dbConn.userName = userName.Text.ToString();
				dbConn.pwd = password.Text.ToString();
				//Call web service
				viewsSet = browseService.QueryView(dbConn, views.Text.ToString());
				Result.SetDataBinding(viewsSet, "Result");
			}
		}
	}
}
