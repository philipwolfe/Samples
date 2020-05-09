/* 
 * Program : SqlJobs.exe
 * Date	   : 5/8/2003
 * Author  : Rafat Sarosh rsarosh@hotmail.com
 * This program shows the SQL Job Secheduling heat map, helps in Server maintainance
 * and in distributing your jobs evenly.
 */



using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data .SqlClient ;
using System.Diagnostics ;

namespace SqlJobs
{


	

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colDb;
		private System.Windows.Forms.ColumnHeader colDesc;
		private System.Windows.Forms.ColumnHeader colNextRunDate;
		private System.Windows.Forms.ColumnHeader colEnable;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkTrusted;
		private System.Windows.Forms.TextBox txtPassWord;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSQLServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CmdPrepareData;
		private System.Windows.Forms.Button CmdOK;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuPrepareData;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuExclude;
		private System.Windows.Forms.MenuItem mnuShowOnly;
		private System.Windows.Forms.MenuItem mnuShowAllJobs;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuItem mnuHeatMaP;
		private System.Windows.Forms.StatusBar SB;
		private System.Windows.Forms.StatusBarPanel SBP1;
		private System.Windows.Forms.StatusBarPanel SBP2;
		private System.Windows.Forms.StatusBarPanel SBP3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;

		struct SqlJobData 
		{
			public string Name;
			public bool Enabled;
			public string Next_Run_Date;
			public string Next_Run_Time;
			public string Description;
			public string DatabaseName;
			public string Active_End_time;
		};


		struct ControlDetail 
		{
			public string name;
			public long index;
			public ArrayList TaskDescriptionList;
			public int NoOfTask;

			
		}

		Hashtable ControlHashList;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colDb = new System.Windows.Forms.ColumnHeader();
			this.colDesc = new System.Windows.Forms.ColumnHeader();
			this.colNextRunDate = new System.Windows.Forms.ColumnHeader();
			this.colEnable = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.chkTrusted = new System.Windows.Forms.CheckBox();
			this.txtPassWord = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSQLServer = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CmdOK = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuHeatMaP = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.SB = new System.Windows.Forms.StatusBar();
			this.SBP1 = new System.Windows.Forms.StatusBarPanel();
			this.SBP2 = new System.Windows.Forms.StatusBarPanel();
			this.SBP3 = new System.Windows.Forms.StatusBarPanel();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuExclude = new System.Windows.Forms.MenuItem();
			this.mnuShowOnly = new System.Windows.Forms.MenuItem();
			this.mnuShowAllJobs = new System.Windows.Forms.MenuItem();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SBP1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SBP2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SBP3)).BeginInit();
			this.SuspendLayout();
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 50000;
			this.toolTip1.InitialDelay = 50;
			this.toolTip1.ReshowDelay = 100;
			this.toolTip1.ShowAlways = true;
			// 
			// listView1
			// 
			this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listView1.BackColor = System.Drawing.Color.White;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colName,
																						this.colDb,
																						this.colDesc,
																						this.colNextRunDate,
																						this.colEnable});
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(32, 348);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(796, 184);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 10;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 150;
			// 
			// colDb
			// 
			this.colDb.Text = "DataBase";
			this.colDb.Width = 100;
			// 
			// colDesc
			// 
			this.colDesc.Text = "Description";
			this.colDesc.Width = 330;
			// 
			// colNextRunDate
			// 
			this.colNextRunDate.Text = "Next Run Date";
			this.colNextRunDate.Width = 100;
			// 
			// colEnable
			// 
			this.colEnable.Text = "Enable";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button1,
																					this.chkTrusted,
																					this.txtPassWord,
																					this.label3,
																					this.txtUserName,
																					this.label2,
																					this.txtSQLServer,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(824, 64);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(704, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 15;
			this.button1.Text = "Show Heat Map";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chkTrusted
			// 
			this.chkTrusted.Checked = true;
			this.chkTrusted.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTrusted.Location = new System.Drawing.Point(560, 24);
			this.chkTrusted.Name = "chkTrusted";
			this.chkTrusted.Size = new System.Drawing.Size(104, 32);
			this.chkTrusted.TabIndex = 3;
			this.chkTrusted.Text = "Trusted Connection";
			this.chkTrusted.CheckedChanged += new System.EventHandler(this.chkTrusted_CheckedChanged);
			// 
			// txtPassWord
			// 
			this.txtPassWord.Enabled = false;
			this.txtPassWord.Location = new System.Drawing.Point(407, 30);
			this.txtPassWord.Name = "txtPassWord";
			this.txtPassWord.PasswordChar = '*';
			this.txtPassWord.Size = new System.Drawing.Size(144, 20);
			this.txtPassWord.TabIndex = 2;
			this.txtPassWord.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(407, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 14;
			this.label3.Text = "Password:";
			// 
			// txtUserName
			// 
			this.txtUserName.Enabled = false;
			this.txtUserName.Location = new System.Drawing.Point(211, 30);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(144, 20);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(215, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "UserName:";
			// 
			// txtSQLServer
			// 
			this.txtSQLServer.Location = new System.Drawing.Point(15, 30);
			this.txtSQLServer.Name = "txtSQLServer";
			this.txtSQLServer.Size = new System.Drawing.Size(144, 20);
			this.txtSQLServer.TabIndex = 0;
			this.txtSQLServer.Text = "";
			this.txtSQLServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQLServer_KeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "SQL Server:";
			// 
			// CmdOK
			// 
			this.CmdOK.Location = new System.Drawing.Point(368, 544);
			this.CmdOK.Name = "CmdOK";
			this.CmdOK.TabIndex = 5;
			this.CmdOK.Text = "OK";
			this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuHeatMaP,
																					  this.menuItem3,
																					  this.menuItem5,
																					  this.menuItem2,
																					  this.mnuAbout});
			this.menuItem1.Text = "Main Menu";
			// 
			// mnuHeatMaP
			// 
			this.mnuHeatMaP.Index = 0;
			this.mnuHeatMaP.Text = "Heat Map";
			this.mnuHeatMaP.Click += new System.EventHandler(this.mnuHeatMaP_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "E&xit";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.Text = "-";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 4;
			this.mnuAbout.Text = "&About";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// SB
			// 
			this.SB.Location = new System.Drawing.Point(0, 583);
			this.SB.Name = "SB";
			this.SB.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																				  this.SBP1,
																				  this.SBP2,
																				  this.SBP3});
			this.SB.ShowPanels = true;
			this.SB.Size = new System.Drawing.Size(856, 22);
			this.SB.TabIndex = 13;
			// 
			// SBP1
			// 
			this.SBP1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.SBP1.Text = "Total Jobs:";
			this.SBP1.Width = 280;
			// 
			// SBP2
			// 
			this.SBP2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.SBP2.Width = 280;
			// 
			// SBP3
			// 
			this.SBP3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.SBP3.Text = "Recursive:";
			this.SBP3.Width = 280;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuExclude,
																						 this.mnuShowOnly,
																						 this.mnuShowAllJobs});
			// 
			// mnuExclude
			// 
			this.mnuExclude.Index = 0;
			this.mnuExclude.Text = "Exclude this Job from heat Map";
			// 
			// mnuShowOnly
			// 
			this.mnuShowOnly.Index = 1;
			this.mnuShowOnly.Text = "Show only this Job";
			// 
			// mnuShowAllJobs
			// 
			this.mnuShowAllJobs.Index = 2;
			this.mnuShowAllJobs.Text = "Show all Jobs";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(248, 328);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "1 Job";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(304, 328);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "2 Jobs";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Blue;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(360, 328);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "3 Jobs";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(416, 328);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 17;
			this.label7.Text = "4 Jobs";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Red;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(528, 328);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 18;
			this.label8.Text = "6-10 Jobs";
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Black;
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(584, 328);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "> 10 Jobs";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Yellow;
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(472, 328);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 20;
			this.label10.Text = "5 Jobs";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 605);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label10,
																		  this.label9,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.SB,
																		  this.CmdOK,
																		  this.groupBox1,
																		  this.listView1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SQL Job Schedule Heat Map";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SBP1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SBP2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SBP3)).EndInit();
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
			
			DrawTimeBlocks ();
		}

		private void MouseLeaveEvent (object sender, System.EventArgs e)
		{
//			TextBox t = (TextBox ) sender;
//			t.BorderStyle = BorderStyle .FixedSingle ;
		}

		private void MouseHoverEvent(object sender, System.EventArgs e)
		{
			TextBox t = (TextBox ) sender;
			ControlDetail  cd = (ControlDetail ) ControlHashList [t.Name ];
			toolTip1 .SetToolTip ( t, "Total Jobs: " +  cd.NoOfTask.ToString () );
		}

		TextBox LastControl;

		private void ClickEvent(object sender, System.EventArgs e)
		{
			TextBox t = (TextBox ) sender;
			ControlDetail  cd = (ControlDetail ) ControlHashList [t.Name ];
			
			if (LastControl != null) 
			{
				LastControl.Font = new Font ("Microsoft Sans Serif", 8,FontStyle.Regular  );
				LastControl.BorderStyle = BorderStyle .FixedSingle ;
			}
			t.BorderStyle = BorderStyle .Fixed3D ;
			LastControl = t;
			toolTip1 .SetToolTip ( t, "Total Jobs: " +  cd.NoOfTask.ToString () );
			listView1.AllowColumnReorder = true;
			listView1.FullRowSelect = true;
			listView1.MultiSelect = true;
			listView1.Sorting = SortOrder.Ascending ;
		
			ListViewItem  lvi;
			int i = 0;
			listView1 .Items .Clear ();
			foreach ( string s in cd.TaskDescriptionList ) 
			{
				string [] sValues =  s.Split ('|');
				lvi = listView1.Items .Add ( sValues [0]);  //Add a row, with a first column
				for ( int j = 1; j < sValues.Length ; j ++ ) 
				{   
					lvi.SubItems.Add ( sValues [j]); //Add second column
				}
			}

		}

		ArrayList AL;

		private void button1_Click(object sender, System.EventArgs e)
		{
			PrepareData();
		}

		/// <summary>
		/// This function reads SQL server systables.
		/// </summary>
		/// 

		private void PrepareData (){

			
			this.Cursor = Cursors.WaitCursor ;

			WashControls();

			if ( txtSQLServer .Text .Length == 0 ) 
			{
				MessageBox.Show  ("Come on, at least tell me the SQL server name","SQL Server Job Scheduling Heat Map",MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
				txtSQLServer.Focus ();
				this.Cursor = Cursors.Default  ;
				return;
			}

				//"server=TACSQL;database=dbBSPData; TRUSTED_CONNECTION=true
			SqlConnection cn = new SqlConnection ();
			if (chkTrusted.Checked )
				cn.ConnectionString = "server=" + txtSQLServer.Text + " ;database= msdb; TRUSTED_CONNECTION=true" ;
			else
				cn.ConnectionString = "server=" + txtSQLServer.Text + " ; database=msdb; UID = " + txtUserName.Text + "; Pwd =" + txtPassWord.Text  ;

			string sql = "SELECT dbo.sysjobschedules.active_end_time, dbo.sysjobschedules.freq_subday_interval, dbo.sysjobschedules.freq_subday_type, dbo.sysjobschedules.job_id, dbo.sysjobs.name, dbo.sysjobschedules.enabled, dbo.sysjobschedules.next_run_date,  dbo.sysjobschedules.next_run_time, dbo.sysjobs.description, dbo.sysjobs.job_id AS Expr1, dbo.sysjobsteps.database_name,  dbo.sysjobsteps.server FROM   dbo.sysjobschedules INNER JOIN  dbo.sysjobs ON dbo.sysjobschedules.job_id = dbo.sysjobs.job_id INNER JOIN dbo.sysjobsteps ON dbo.sysjobs.job_id = dbo.sysjobsteps.job_id  where dbo.sysjobschedules.enabled = 1 and dbo.sysjobsteps.Step_ID = 1 ";
			SqlCommand cmd ;
			SqlDataReader dr;
			DataSet dsHelpJob = new DataSet ();
			SqlDataAdapter sda;
			try
			{
				cn.Open ();

				//There is a delay in SQL server 2000 sysjobschedule tables
				//updation. So to get the Next_run_Date lets use this 
				//sp_help_job stored procedure
				cmd = new SqlCommand ("msdb.dbo.sp_help_job ",cn );
				cmd.CommandType = CommandType.StoredProcedure ;
				sda = new SqlDataAdapter ( cmd );
				sda.Fill ( dsHelpJob );

				sda.Dispose ();
				cmd = new SqlCommand ( sql,cn);
				cmd.CommandType = CommandType .Text ;
				dr = cmd.ExecuteReader ();
				AL = new ArrayList  (100);
				int Ctr=0;
				string jobID= "";
				while (dr.Read ()) 
				{
					SqlJobData sjd = new SqlJobData ();
					sjd.DatabaseName = Convert.ToString ( dr["DataBase_Name"] );
					sjd.Description =  Convert.ToString ( dr["Description"]);
					sjd.Enabled = Convert.ToBoolean ( dr["Enabled"]);
					sjd.Name =  Convert.ToString ( dr["Name"]);
					sjd.Active_End_time = Convert.ToString ( dr["Active_End_time"]);
					SBP2.Text = "Processing: " + sjd.Name ;
					Ctr++;
					SBP1.Text = "Total Jobs: " + Ctr.ToString();
					string sNextRunDate = "0";
					jobID =  Convert.ToString ( dr["Job_ID"]);
					#region GetNextTime
					foreach ( DataRow dRow in  dsHelpJob.Tables [0].Rows )
						{
							if ( Convert.ToString (dRow ["Job_ID"]).CompareTo (jobID) == 0 ) 
							{
								sNextRunDate = Convert.ToString ( dRow["Next_Run_Date"]);
								if ( sNextRunDate.CompareTo ("0") == 0 )
									break; //Job is disabled or it is some SQL system job like SQL started
                 
								sjd.Next_Run_Date =   sNextRunDate.Substring (4,2) + "/" + sNextRunDate.Substring (6,2) + "/" + sNextRunDate.Substring (0,4);
								sjd.Next_Run_Time =  Convert.ToString ( dRow["Next_Run_Time"]);
								break;
					
							}

						}
					#endregion
					if ( sNextRunDate.CompareTo ("0") == 0 )
						continue; //Job is disabled or it is some SQL system job like SQL started
                 

					#region FixTime

					//Some time 4 is written as 40000 and we understand only
					//HHMMSS

					switch ( sjd.Next_Run_Time.Length )
					{
						case 1 :
							sjd.Next_Run_Time = "00000" + sjd.Next_Run_Time ;
							break;
						case 2 :
							sjd.Next_Run_Time = "0000" + sjd.Next_Run_Time ;
							break;
						case 3 :
							sjd.Next_Run_Time = "000" + sjd.Next_Run_Time ;
							break;
						case 4 :
							sjd.Next_Run_Time = "00" + sjd.Next_Run_Time ;
							break;
						case 5 :
							sjd.Next_Run_Time = "0" + sjd.Next_Run_Time ;
							break;

						case 0:
							sjd.Next_Run_Time = "000000"  ;
							break;

					}

					//Some time 4 is written as 40000 and we understand only
					//HHMMSS
					switch (sjd.Active_End_time.Length)
					{
						case 5 :
							sjd.Active_End_time = "0" + sjd.Active_End_time ;
							break;
						case  4 :
							sjd.Active_End_time = "00" + sjd.Active_End_time ;
							break;
						case 3 :
							sjd.Active_End_time = "000" + sjd.Active_End_time ;
							break;
						case 2 :
							sjd.Active_End_time = "0000" + sjd.Active_End_time ;
							break;
						case 1 :
							sjd.Active_End_time = "00000" + sjd.Active_End_time ;
							break;
						case 0:
							sjd.Active_End_time = "000000" ;
							break;



					}
					#endregion
					int repeate  = Convert.ToInt16 ( dr["freq_subday_type"]); //2-seconds, 4-min 8=hours
					int Interval = Convert.ToInt16 ( dr["freq_subday_interval"]);
					try
					{
						AL.Add ( sjd );
						if ( repeate >= 2 ) 
						{
							#region repeate
							//Repeate as per repeate for interval
							int hh , starthh ,mm , startmm;
							int Endhh, Endmm;
						
							Endhh = Convert .ToInt16 ( sjd.Active_End_time.Substring (0,2));
							Endmm = Convert .ToInt16 ( sjd.Active_End_time .Substring (2,2));
							hh = Convert .ToInt16 ( sjd.Next_Run_Time.Substring (0,2));
							mm = Convert .ToInt16 ( sjd.Next_Run_Time.Substring (2,2));
							
							DateTime StartDateTime =  Convert.ToDateTime ( DateTime.Today .ToShortDateString () + " " + hh.ToString () + ":" + mm.ToString () +":00" );
							DateTime EndDateTime;

							if (Endhh == 23 && Endmm == 59 )	
								EndDateTime =  Convert.ToDateTime ( DateTime.Today .AddDays (1). ToShortDateString () + " " + hh.ToString () + ":" + mm.ToString ());
							 else
								EndDateTime =  Convert.ToDateTime ( DateTime.Today . ToShortDateString () + " " + Endhh.ToString () + ":" + Endmm.ToString ());

							 while ( EndDateTime >= StartDateTime) 
								{
									if (repeate == 4 )
										StartDateTime = StartDateTime.AddMinutes ( Interval );
									else
										StartDateTime = StartDateTime.AddHours ( Interval );

									#region makeRepeate
									sjd = new SqlJobData ();
									sjd.DatabaseName = Convert.ToString ( dr["DataBase_Name"] );
									sjd.Description =  Convert.ToString ( dr["Description"]);
									sjd.Enabled = Convert.ToBoolean ( dr["Enabled"]);
									sjd.Name =  Convert.ToString ( dr["Name"]);
									sjd.Next_Run_Date =   StartDateTime.ToShortDateString (); //Convert.ToString ( dr["Next_Run_Date"]);
									sjd.Next_Run_Time =  String.Format ( "{0:d2}",  StartDateTime.Hour  ) + String.Format ( "{0:d2}",StartDateTime.Minute  );
									SBP3.Text = sjd.Next_Run_Time ;
									AL.Add ( sjd );
									#endregion

								}
							#endregion
						}//repeate
					}//try 
					catch 
					{
						//Just ignore the duplicates - why the hell they are there?
					}

				}//while DataRead
				dr.Close ();
				cn.Close ();
				this.Cursor = Cursors.Default  ;
			} 
			catch ( Exception ex ) 
			{
				cn.Close ();
				MessageBox .Show ("Error: " +  ex.Message + " Check the SQL server name.", "SqlJobs",MessageBoxButtons .OK ,MessageBoxIcon.Error );
				this.Cursor = Cursors.Default  ;
				return;
			}
			DrawHeatMap();
		}



		void DrawHeatMap () 

		{

			this.Cursor = Cursors.WaitCursor ;
			for (int i = 0 ; i  < AL.Count ; i ++ ) 
			{
				SqlJobData sjd = (SqlJobData ) AL [i] ;
				switch ( sjd.Next_Run_Time.Length )
				{
					case 1 :
						sjd.Next_Run_Time = "00000" + sjd.Next_Run_Time ;
						break;
					case 2 :
						sjd.Next_Run_Time = "0000" + sjd.Next_Run_Time ;
						break;
					case 3 :
						sjd.Next_Run_Time = "000" + sjd.Next_Run_Time ;
						break;
					case 4 :
						sjd.Next_Run_Time = "00" + sjd.Next_Run_Time ;
						break;
					case 5 :
						sjd.Next_Run_Time = "0" + sjd.Next_Run_Time ;
						break;

					case 0 :
						sjd.Next_Run_Time = "000000"  ;
						break;

				}

				sjd.Next_Run_Time =  sjd.Next_Run_Time.Substring (0,4) ;
				int InWhileLoop = 0;
				ControlDetail cd ;
				while (true) 
				{
					try
					{
						cd = (ControlDetail) ControlHashList [ sjd.Next_Run_Time ];
						break;
					}  
					catch 
					{
						#region 5Boundary
						//Control did not find, because control name was 2305 and Next_Run_Time
						//is looking for 2305
						//so lets bump Next_run_time to boundry of 5 to get to the proper control

						//boundry of 5 
						int b5 = Convert.ToInt16 ( sjd.Next_Run_Time .Substring (2,2));
						while ( ( ++b5 % 5 ) != 0 ) ;
						//here b5 sits on the boundry of 5
						sjd.Next_Run_Time = sjd.Next_Run_Time .Substring (0,2) + String.Format ("{0:d2}", b5);
						continue;
						if (++InWhileLoop == 2) 
						{
							InWhileLoop = 0;
							break; //enough i cannot tolrate any more
						}
						#endregion
					}

				}//~while
				TextBox t = (TextBox ) this.Controls [ (int) cd.index ];
				
		

				if (t != null ) 
				{
					#region ColorBoxes
					switch (cd.NoOfTask ) 
					{
						case 0:
							t.BackColor = Color.Pink   ;	
							break;
						case 1:
							t.BackColor = Color.DeepPink    ;	
							t.ForeColor = Color.White ;
							break;
						case 2:
							t.BackColor = Color.Blue    ;	
							t.ForeColor = Color.White ;
							break;
						case 3:
							t.BackColor = Color.Green       ;	
							t.ForeColor = Color.White ;
							break;
						case 4:
							t.BackColor = Color.Yellow   ;	
							t.ForeColor = Color.Black  ;
							break;
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
							t.BackColor = Color.Red     ;	
							t.ForeColor = Color.White ;
							break;

						default:
							t.BackColor = Color.Black      ;	
							t.ForeColor = Color.White ;
							break;
					}
					#endregion
					cd.TaskDescriptionList .Add (  sjd.Name +  " |  "  + sjd.DatabaseName + " |  " + sjd.Description  + " |  " + sjd.Next_Run_Date  + " |  " + Convert.ToString ( sjd.Enabled )); 
					cd.NoOfTask ++;
					ControlHashList.Remove (sjd.Next_Run_Time);
					ControlHashList.Add  (sjd.Next_Run_Time ,cd );
				} else
					Debug.WriteLine ( sjd.Next_Run_Time + " Not found");
			}
			this.Cursor = Cursors.Default  ;
		}


		void RemoveControls () 
		{
			if (ControlHashList != null)
				ControlHashList .Clear ();
		}


		void WashControls () 
		{
			
			if (ControlHashList != null && ControlHashList .Count > 0 ) 
			{
				for ( int Hours = 0; Hours < 24; Hours ++ ) 
				{
					for ( int Minute = 5; Minute < 65; Minute +=5  ) 
					{
						try
						{
							ControlDetail	cd = (ControlDetail) ControlHashList [String.Format ( "{0:d2}",  Hours) + String.Format ( "{0:d2}",  Minute)];
							//Lets reset the colors
							TextBox t = (TextBox ) this.Controls [ (int) cd.index ];
							t.BackColor = Color.White   ;	
							t.ForeColor = Color.Black  ;

							//cd.index = 0;
							//cd.name = ""; Oouch dont wipe out controls name
							cd.NoOfTask = 0;
							cd.TaskDescriptionList.Clear ();
							ControlHashList.Remove (String.Format ( "{0:d2}",  Hours) + String.Format ( "{0:d2}",  Minute));
							ControlHashList.Add  (String.Format ( "{0:d2}",  Hours) + String.Format ( "{0:d2}",  Minute) ,cd );
							
						} 
						catch 
						{
							//I really dont care
						}
					}

					    
				}
			}

		}
		void DrawTimeBlocks()
		{

			RemoveControls();

			int intialY = groupBox1 .Height/2 ;
			int VerticleMove = 50;
			int HorizontolMove = 0;
			int Column = 0;
			ControlHashList = new Hashtable (289);

			for ( int Hours = 0; Hours < 24; Hours ++ ) 
			{
				Column++;
				for ( int Minute = 5; Minute < 65; Minute +=5  )
				{
					TextBox t = new TextBox ();
					t.BorderStyle = BorderStyle .FixedSingle ;
					t.Enabled = true;
					t.Click  += new System.EventHandler(this.ClickEvent);
					t.MouseHover +=  new System.EventHandler(this.MouseHoverEvent);
					t.MouseLeave +=  new System.EventHandler(this.MouseLeaveEvent);
					t.BackColor = Color.White  ;
					if ( Column == 3 ) 
					{
						VerticleMove += t.Height ;
						HorizontolMove = 0;
						Column = 1;
					}
					t.Top =+ (VerticleMove + intialY );
					t.Width /= 3;
					t.Name = String.Format ( "{0:d2}",  Hours) + String.Format ( "{0:d2}",  Minute);
					t.Left = HorizontolMove + t.Width ;
					HorizontolMove += t.Width ;
					t.Cursor  = Cursors.Arrow ;
					t.Text = String.Format ( "{0:d2}",  Hours) + ":" + String.Format ( "{0:d2}",  Minute);
					this.Controls .Add (t);
					ControlDetail  Ctl = new ControlDetail ();
					Ctl.TaskDescriptionList = new ArrayList (2);
					Ctl.name = t.Name ;
					Ctl.index = this.Controls .IndexOf ( t );
					try
					{
						ControlHashList.Add ( Ctl.name , Ctl );
						Debug.WriteLine ( "Adding Control: " + Ctl.name );
					} 
					catch 
					{
						Debug.WriteLine ( "ControlName already exist: " + Ctl.name );
					}
				}//Min
			}//Hours
		}

		private void CmdOK_Click(object sender, System.EventArgs e)
		{
			Application.Exit ();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			About a = new About();
			a.Show();
		}

		private void mnuPrepareData_Click(object sender, System.EventArgs e)
		{
		
			PrepareData();
		}

		



		private void chkTrusted_CheckedChanged(object sender, System.EventArgs e)
		{
			txtPassWord .Enabled = !chkTrusted .Checked ;
			txtUserName .Enabled = !chkTrusted .Checked ;
		}

		private void txtSQLServer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter ){
				PrepareData ();
			}
		}

		private void mnuHeatMaP_Click(object sender, System.EventArgs e)
		{
			PrepareData();
		}
	}
}
