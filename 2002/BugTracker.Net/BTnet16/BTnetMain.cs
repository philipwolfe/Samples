////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.IO;

namespace com.mikelehman.bugtracker
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class BTnetMain : System.Windows.Forms.Form
	{
		#region ControlsOnForm
		private System.Windows.Forms.Button toggleFilterButton;
		private System.Windows.Forms.TextBox txtCreatedBy;
		private System.Windows.Forms.MenuItem moveToReleaseMenuItem;
		private System.Windows.Forms.MenuItem moveNonClosedMenuItem;
		private System.Windows.Forms.MenuItem releaseStatusMenu;
		private System.Windows.Forms.MenuItem markReleaseCompleteMenuItem;
		private System.Windows.Forms.MenuItem toggleIncompleteFilterMenuItem;
		private System.Windows.Forms.MenuItem importMenuItem;
		private System.Windows.Forms.MenuItem bugReportMenuItem;
		private System.Windows.Forms.Button resolveBugButton;
		private System.Windows.Forms.Button updateBugBtn;
		private System.Windows.Forms.MenuItem bugStatusMenu;
		private System.Windows.Forms.MenuItem changeToOpenMenuItem;
		private System.Windows.Forms.MenuItem changeToPostponedMenuItem;
		private System.Windows.Forms.MenuItem changeToVerifiedMenuItem;
		private System.Windows.Forms.MenuItem changeToIgnoreMenuItem;
		private System.Windows.Forms.MenuItem toggleOpenFilterMenuItem;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private BugDataSet1 bugDataSet11;
		private BTnet1.PersonDataSet1 personDataSet11;
		private BTnet1.ReleaseDataSet1 releaseDataSet11;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button addUserBtn;
		private System.Windows.Forms.Button addReleaseBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtOpened;
		private System.Windows.Forms.RichTextBox txtDescription;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.OleDb.OleDbDataAdapter bugDataAdapter;
		private System.Data.OleDb.OleDbDataAdapter personDataAdapter;
		private System.Data.OleDb.OleDbDataAdapter releaseDataAdapter;
		private System.Windows.Forms.ListView lvRelease;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListView lvBug;
		private System.Windows.Forms.Button addBugButton;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private propertiesDataSet1 PropertiesDataSet11;
		private System.Data.OleDb.OleDbDataAdapter propertiesDataAdapter1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RichTextBox txtResolution;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label txtBugID;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button aboutButton;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenu;
		private System.Windows.Forms.MenuItem helpMenu;
		private System.Windows.Forms.MenuItem fileExitMenuItem;
		private System.Windows.Forms.MenuItem helpAboutMenuItem;

		#endregion

		public static BTSession session = null;
		//
		// DataTable variables for DB I/O
		private DataTable bugDT;
		private DataTable releaseDT;
		private DataTable peopleDT;
		private DataTable propertiesDT;

		//
		// Info defining how we display the release table in a ListView
		//
		private string[] releaseDisplayColNames = {"Due","Version","Name","Status","Desc."};
		private string[] releaseDbColNames = {"deadlineTimestamp","version","name","extra1","description"};
		private int[] releaseColWidths = {125,60,80,75,204};

		//
		// Info defining how we display the bugs for a specific release in a ListView
		private string[] bugDisplayColNames = {"#","P","S","Status","Created","Assigned","Desc."};
		private string[] bugDbColNames = {"@","priority","severity","status","creatorOID","ownerOID","description"};
		private int[] bugColWidths = {30,20, 20,55,85,85,249};

		//
		// Last row (if any) selected in the "Release" list view
		//
		private DataRow curReleaseRow;

		//
		// Last row (if any) selected in the "Bug" list view
		//
		private DataRow curBugRow;

		private static string myPersonOID;
		private static string myPersonName;
		private Hashtable props;
		private Hashtable personToOID;
		private System.Windows.Forms.TextBox txtResolvedDate;
		private System.Windows.Forms.TextBox txtResolved;
		private Hashtable OIDtoPerson;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private BTExec theExecutor;
		private ArrayList peopleNames;
		private ArrayList peopleOIDs;
		private static BTnetMain instance;
		private string startupPath;
		private bool hideNonOpenBugs = false;
		private System.Windows.Forms.MenuItem reopenCompletedReleaseMenuItem;
		private bool showIncompleteReleasesOnly = false;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BTnetMain));
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.bugDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.personDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.releaseDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.bugDataSet11 = new BugDataSet1();
			this.personDataSet11 = new BTnet1.PersonDataSet1();
			this.releaseDataSet11 = new BTnet1.ReleaseDataSet1();
			this.label1 = new System.Windows.Forms.Label();
			this.addUserBtn = new System.Windows.Forms.Button();
			this.addReleaseBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lvRelease = new System.Windows.Forms.ListView();
			this.lvBug = new System.Windows.Forms.ListView();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtOpened = new System.Windows.Forms.TextBox();
			this.txtCreatedBy = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.RichTextBox();
			this.txtResolvedDate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.resolveBugButton = new System.Windows.Forms.Button();
			this.addBugButton = new System.Windows.Forms.Button();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.PropertiesDataSet11 = new propertiesDataSet1();
			this.propertiesDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.label8 = new System.Windows.Forms.Label();
			this.txtResolution = new System.Windows.Forms.RichTextBox();
			this.txtResolved = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtBugID = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.aboutButton = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.importMenuItem = new System.Windows.Forms.MenuItem();
			this.bugReportMenuItem = new System.Windows.Forms.MenuItem();
			this.fileExitMenuItem = new System.Windows.Forms.MenuItem();
			this.bugStatusMenu = new System.Windows.Forms.MenuItem();
			this.changeToOpenMenuItem = new System.Windows.Forms.MenuItem();
			this.changeToPostponedMenuItem = new System.Windows.Forms.MenuItem();
			this.changeToVerifiedMenuItem = new System.Windows.Forms.MenuItem();
			this.changeToIgnoreMenuItem = new System.Windows.Forms.MenuItem();
			this.toggleOpenFilterMenuItem = new System.Windows.Forms.MenuItem();
			this.moveToReleaseMenuItem = new System.Windows.Forms.MenuItem();
			this.moveNonClosedMenuItem = new System.Windows.Forms.MenuItem();
			this.releaseStatusMenu = new System.Windows.Forms.MenuItem();
			this.markReleaseCompleteMenuItem = new System.Windows.Forms.MenuItem();
			this.reopenCompletedReleaseMenuItem = new System.Windows.Forms.MenuItem();
			this.toggleIncompleteFilterMenuItem = new System.Windows.Forms.MenuItem();
			this.helpMenu = new System.Windows.Forms.MenuItem();
			this.helpAboutMenuItem = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.updateBugBtn = new System.Windows.Forms.Button();
			this.toggleFilterButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bugDataSet11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personDataSet11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.releaseDataSet11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PropertiesDataSet11)).BeginInit();
			this.SuspendLayout();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=btnet1.mdb;Mode=ReadWrite;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
			// 
			// bugDataAdapter
			// 
			this.bugDataAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.bugDataAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.bugDataAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.bugDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "BT_BUG", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("bugOID", "bugOID"),
																																																			   new System.Data.Common.DataColumnMapping("completionTimestamp", "completionTimestamp"),
																																																			   new System.Data.Common.DataColumnMapping("creationTimestamp", "creationTimestamp"),
																																																			   new System.Data.Common.DataColumnMapping("creatorOID", "creatorOID"),
																																																			   new System.Data.Common.DataColumnMapping("description", "description"),
																																																			   new System.Data.Common.DataColumnMapping("priority", "priority"),
																																																			   new System.Data.Common.DataColumnMapping("releaseOID", "releaseOID"),
																																																			   new System.Data.Common.DataColumnMapping("resolvedByOID", "resolvedByOID"),
																																																			   new System.Data.Common.DataColumnMapping("ownerOID", "ownerOID"),
																																																			   new System.Data.Common.DataColumnMapping("severity", "severity"),
																																																			   new System.Data.Common.DataColumnMapping("status", "status")})});
			this.bugDataAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM BT_BUG WHERE (bugOID = ?) AND (completionTimestamp = ? OR ? IS NULL AND completionTimestamp IS NULL) AND (creationTimestamp = ? OR ? IS NULL AND creationTimestamp IS NULL) AND (creatorOID = ? OR ? IS NULL AND creatorOID IS NULL) AND (description = ? OR ? IS NULL AND description IS NULL) AND (priority = ? OR ? IS NULL AND priority IS NULL) AND (releaseOID = ? OR ? IS NULL AND releaseOID IS NULL) AND (resolvedByOID = ? OR ? IS NULL AND resolvedByOID IS NULL) AND (ownerOID = ? OR ? IS NULL AND ownerOID IS NULL) AND (severity = ? OR ? IS NULL AND severity IS NULL) AND (status = ? OR ? IS NULL AND status IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_bugOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "bugOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_priority", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "priority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_priority1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "priority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_resolvedByOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "resolvedByOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_resolvedByOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "resolvedByOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ownerOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ownerOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ownerOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ownerOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_severity", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "severity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_severity1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "severity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "status", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "status", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO BT_BUG(bugOID, completionTimestamp, creationTimestamp, creatorOID, de" +
				"scription, priority, releaseOID, resolvedByOID, ownerOID, severity, status) VALU" +
				"ES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("bugOID", System.Data.OleDb.OleDbType.VarWChar, 50, "bugOID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "completionTimestamp"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "creationTimestamp"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, "creatorOID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("description", System.Data.OleDb.OleDbType.VarWChar, 0, "description"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("priority", System.Data.OleDb.OleDbType.VarWChar, 50, "priority"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, "releaseOID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("resolvedByOID", System.Data.OleDb.OleDbType.VarWChar, 50, "resolvedByOID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ownerOID", System.Data.OleDb.OleDbType.VarWChar, 50, "ownerOID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("severity", System.Data.OleDb.OleDbType.VarWChar, 50, "severity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("status", System.Data.OleDb.OleDbType.VarWChar, 50, "status"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT * FROM BT_BUG";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE BT_BUG SET bugOID = ?, completionTimestamp = ?, creationTimestamp = ?, creatorOID = ?, description = ?, priority = ?, releaseOID = ?, resolvedByOID = ?, severity = ?, status = ? WHERE (bugOID = ?) AND (completionTimestamp = ? OR ? IS NULL AND completionTimestamp IS NULL) AND (creationTimestamp = ? OR ? IS NULL AND creationTimestamp IS NULL) AND (creatorOID = ? OR ? IS NULL AND creatorOID IS NULL) AND (description = ? OR ? IS NULL AND description IS NULL) AND (priority = ? OR ? IS NULL AND priority IS NULL) AND (releaseOID = ? OR ? IS NULL AND releaseOID IS NULL) AND (resolvedByOID = ? OR ? IS NULL AND resolvedByOID IS NULL) AND (ownerOID = ? OR ? IS NULL AND ownerOID IS NULL) AND (severity = ? OR ? IS NULL AND severity IS NULL) AND (status = ? OR ? IS NULL AND status IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("bugOID", System.Data.OleDb.OleDbType.VarWChar, 50, "bugOID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "completionTimestamp"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "creationTimestamp"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, "creatorOID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.InputOutput, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("priority", System.Data.OleDb.OleDbType.VarWChar, 50, "priority"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, "releaseOID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("resolvedByOID", System.Data.OleDb.OleDbType.VarWChar, 50, "resolvedByOID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ownerOID", System.Data.OleDb.OleDbType.VarWChar, 50, "ownerOID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("severity", System.Data.OleDb.OleDbType.VarWChar, 50, "severity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("status", System.Data.OleDb.OleDbType.VarWChar, 50, "status"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_bugOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "bugOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_priority", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "priority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_priority1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "priority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_resolvedByOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "resolvedByOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_resolvedByOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "resolvedByOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ownerOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ownerOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ownerOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ownerOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_severity", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "severity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_severity1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "severity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "status", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "status", System.Data.DataRowVersion.Original, null));
			// 
			// personDataAdapter
			// 
			this.personDataAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.personDataAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.personDataAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.personDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "BT_PERSON", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("email", "email"),
																																																					 new System.Data.Common.DataColumnMapping("name", "name"),
																																																					 new System.Data.Common.DataColumnMapping("personOID", "personOID"),
																																																					 new System.Data.Common.DataColumnMapping("phone", "phone")})});
			this.personDataAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM BT_PERSON WHERE (personOID = ?) AND (email = ? OR ? IS NULL AND email" +
				" IS NULL) AND (name = ? OR ? IS NULL AND name IS NULL) AND (phone = ? OR ? IS NU" +
				"LL AND phone IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_personOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "personOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_email", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "email", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_email1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "email", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_phone", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_phone1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO BT_PERSON(email, name, personOID, phone) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("email", System.Data.OleDb.OleDbType.VarWChar, 50, "email"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("personOID", System.Data.OleDb.OleDbType.VarWChar, 50, "personOID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("phone", System.Data.OleDb.OleDbType.VarWChar, 50, "phone"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT email, name, personOID, phone FROM BT_PERSON";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE BT_PERSON SET email = ?, name = ?, personOID = ?, phone = ? WHERE (personO" +
				"ID = ?) AND (email = ? OR ? IS NULL AND email IS NULL) AND (name = ? OR ? IS NUL" +
				"L AND name IS NULL) AND (phone = ? OR ? IS NULL AND phone IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("email", System.Data.OleDb.OleDbType.VarWChar, 50, "email"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("personOID", System.Data.OleDb.OleDbType.VarWChar, 50, "personOID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("phone", System.Data.OleDb.OleDbType.VarWChar, 50, "phone"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_personOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "personOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_email", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "email", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_email1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "email", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_phone", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_phone1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			// 
			// releaseDataAdapter
			// 
			this.releaseDataAdapter.DeleteCommand = this.oleDbDeleteCommand3;
			this.releaseDataAdapter.InsertCommand = this.oleDbInsertCommand3;
			this.releaseDataAdapter.SelectCommand = this.oleDbSelectCommand3;
			this.releaseDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "BT_RELEASE", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("completionTimestamp", "completionTimestamp"),
																																																					   new System.Data.Common.DataColumnMapping("creationTimestamp", "creationTimestamp"),
																																																					   new System.Data.Common.DataColumnMapping("creatorOID", "creatorOID"),
																																																					   new System.Data.Common.DataColumnMapping("deadlineTimestamp", "deadlineTimestamp"),
																																																					   new System.Data.Common.DataColumnMapping("description", "description"),
																																																					   new System.Data.Common.DataColumnMapping("name", "name"),
																																																					   new System.Data.Common.DataColumnMapping("releaseOID", "releaseOID"),
																																																					   new System.Data.Common.DataColumnMapping("version", "version")})});
			this.releaseDataAdapter.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = @"DELETE FROM BT_RELEASE WHERE (releaseOID = ?) AND (completionTimestamp = ? OR ? IS NULL AND completionTimestamp IS NULL) AND (creationTimestamp = ? OR ? IS NULL AND creationTimestamp IS NULL) AND (creatorOID = ? OR ? IS NULL AND creatorOID IS NULL) AND (deadlineTimestamp = ? OR ? IS NULL AND deadlineTimestamp IS NULL) AND (description = ? OR ? IS NULL AND description IS NULL) AND (name = ? OR ? IS NULL AND name IS NULL) AND (version = ? OR ? IS NULL AND version IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_deadlineTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deadlineTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_deadlineTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deadlineTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_version", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "version", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_version1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "version", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO BT_RELEASE(completionTimestamp, creationTimestamp, creatorOID, deadli" +
				"neTimestamp, description, name, releaseOID, version) VALUES (?, ?, ?, ?, ?, ?, ?" +
				", ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "completionTimestamp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "creationTimestamp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, "creatorOID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("deadlineTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "deadlineTimestamp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("description", System.Data.OleDb.OleDbType.VarWChar, 0, "description"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, "releaseOID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("version", System.Data.OleDb.OleDbType.VarWChar, 50, "version"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT * FROM BT_RELEASE";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE BT_RELEASE SET completionTimestamp = ?, creationTimestamp = ?, creatorOID = ?, deadlineTimestamp = ?, description = ?, name = ?, releaseOID = ?, version = ? WHERE (releaseOID = ?) AND (completionTimestamp = ? OR ? IS NULL AND completionTimestamp IS NULL) AND (creationTimestamp = ? OR ? IS NULL AND creationTimestamp IS NULL) AND (creatorOID = ? OR ? IS NULL AND creatorOID IS NULL) AND (deadlineTimestamp = ? OR ? IS NULL AND deadlineTimestamp IS NULL) AND (description = ? OR ? IS NULL AND description IS NULL) AND (name = ? OR ? IS NULL AND name IS NULL) AND (version = ? OR ? IS NULL AND version IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "completionTimestamp"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "creationTimestamp"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, "creatorOID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("deadlineTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, "deadlineTimestamp"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("description", System.Data.OleDb.OleDbType.VarWChar, 0, "description"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, "releaseOID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("version", System.Data.OleDb.OleDbType.VarWChar, 50, "version"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_releaseOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "releaseOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_completionTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "completionTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creationTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creationTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_creatorOID1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "creatorOID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_deadlineTimestamp", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deadlineTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_deadlineTimestamp1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deadlineTimestamp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_version", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "version", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_version1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "version", System.Data.DataRowVersion.Original, null));
			// 
			// bugDataSet11
			// 
			this.bugDataSet11.DataSetName = "BugDataSet1";
			this.bugDataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			this.bugDataSet11.Namespace = "http://www.tempuri.org/BugDataSet1.xsd";
			// 
			// personDataSet11
			// 
			this.personDataSet11.DataSetName = "PersonDataSet1";
			this.personDataSet11.EnforceConstraints = false;
			this.personDataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			this.personDataSet11.Namespace = "http://www.tempuri.org/PersonDataSet1.xsd";
			// 
			// releaseDataSet11
			// 
			this.releaseDataSet11.DataSetName = "ReleaseDataSet1";
			this.releaseDataSet11.EnforceConstraints = false;
			this.releaseDataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			this.releaseDataSet11.Namespace = "http://www.tempuri.org/ReleaseDataSet1.xsd";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(16, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(761, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mike Lehman\'s BugTracker.net  1.6                                                " +
				"     http://www.mikelehman.com";
			// 
			// addUserBtn
			// 
			this.addUserBtn.BackColor = System.Drawing.SystemColors.Control;
			this.addUserBtn.Location = new System.Drawing.Point(16, 40);
			this.addUserBtn.Name = "addUserBtn";
			this.addUserBtn.Size = new System.Drawing.Size(96, 23);
			this.addUserBtn.TabIndex = 1;
			this.addUserBtn.Text = "New User...";
			this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
			// 
			// addReleaseBtn
			// 
			this.addReleaseBtn.BackColor = System.Drawing.SystemColors.Control;
			this.addReleaseBtn.Location = new System.Drawing.Point(16, 112);
			this.addReleaseBtn.Name = "addReleaseBtn";
			this.addReleaseBtn.Size = new System.Drawing.Size(96, 23);
			this.addReleaseBtn.TabIndex = 1;
			this.addReleaseBtn.Text = "New Release...";
			this.addReleaseBtn.Click += new System.EventHandler(this.addReleaseBtn_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Releases:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lvRelease
			// 
			this.lvRelease.FullRowSelect = true;
			this.lvRelease.Location = new System.Drawing.Point(192, 40);
			this.lvRelease.MultiSelect = false;
			this.lvRelease.Name = "lvRelease";
			this.lvRelease.Size = new System.Drawing.Size(568, 92);
			this.lvRelease.TabIndex = 5;
			this.lvRelease.SelectedIndexChanged += new System.EventHandler(this.lvRelease_SelectedIndexChanged);
			// 
			// lvBug
			// 
			this.lvBug.FullRowSelect = true;
			this.lvBug.Location = new System.Drawing.Point(192, 144);
			this.lvBug.MultiSelect = false;
			this.lvBug.Name = "lvBug";
			this.lvBug.Size = new System.Drawing.Size(568, 104);
			this.lvBug.TabIndex = 6;
			this.lvBug.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBug_ColumnClick);
			this.lvBug.SelectedIndexChanged += new System.EventHandler(this.lvBug_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(128, 296);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Opened:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(408, 296);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "By:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(120, 336);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Description:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(120, 536);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Resolved:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtOpened
			// 
			this.txtOpened.Location = new System.Drawing.Point(192, 296);
			this.txtOpened.Name = "txtOpened";
			this.txtOpened.ReadOnly = true;
			this.txtOpened.Size = new System.Drawing.Size(176, 20);
			this.txtOpened.TabIndex = 8;
			this.txtOpened.Text = "";
			// 
			// txtCreatedBy
			// 
			this.txtCreatedBy.Location = new System.Drawing.Point(440, 296);
			this.txtCreatedBy.Name = "txtCreatedBy";
			this.txtCreatedBy.ReadOnly = true;
			this.txtCreatedBy.Size = new System.Drawing.Size(176, 20);
			this.txtCreatedBy.TabIndex = 8;
			this.txtCreatedBy.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(192, 328);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtDescription.Size = new System.Drawing.Size(568, 112);
			this.txtDescription.TabIndex = 8;
			this.txtDescription.Text = "";
			// 
			// txtResolvedDate
			// 
			this.txtResolvedDate.Location = new System.Drawing.Point(192, 536);
			this.txtResolvedDate.Name = "txtResolvedDate";
			this.txtResolvedDate.ReadOnly = true;
			this.txtResolvedDate.Size = new System.Drawing.Size(168, 20);
			this.txtResolvedDate.TabIndex = 8;
			this.txtResolvedDate.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(152, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Bugs:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// resolveBugButton
			// 
			this.resolveBugButton.BackColor = System.Drawing.SystemColors.Control;
			this.resolveBugButton.Location = new System.Drawing.Point(16, 256);
			this.resolveBugButton.Name = "resolveBugButton";
			this.resolveBugButton.Size = new System.Drawing.Size(96, 23);
			this.resolveBugButton.TabIndex = 1;
			this.resolveBugButton.Text = "Resolve Bug...";
			this.resolveBugButton.Click += new System.EventHandler(this.resolveBugButton_Click);
			// 
			// addBugButton
			// 
			this.addBugButton.BackColor = System.Drawing.SystemColors.Control;
			this.addBugButton.Location = new System.Drawing.Point(16, 184);
			this.addBugButton.Name = "addBugButton";
			this.addBugButton.Size = new System.Drawing.Size(96, 23);
			this.addBugButton.TabIndex = 1;
			this.addBugButton.Text = "New Bug...";
			this.addBugButton.Click += new System.EventHandler(this.addBugButton_Click);
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM BT_PROPERTIES WHERE (id = ?) AND (name = ? OR ? IS NULL AND name IS N" +
				"ULL) AND (value = ? OR ? IS NULL AND value IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_value", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "value", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_value1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "value", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO BT_PROPERTIES(id, name, value) VALUES (?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("value", System.Data.OleDb.OleDbType.VarWChar, 255, "value"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT * FROM BT_PROPERTIES";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE BT_PROPERTIES SET id = ?, name = ?, value = ? WHERE (id = ?) AND (name = ?" +
				" OR ? IS NULL AND name IS NULL) AND (value = ? OR ? IS NULL AND value IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("value", System.Data.OleDb.OleDbType.VarWChar, 255, "value"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_value", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "value", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_value1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "value", System.Data.DataRowVersion.Original, null));
			// 
			// PropertiesDataSet11
			// 
			this.PropertiesDataSet11.DataSetName = "PropertiesDataSet1";
			this.PropertiesDataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			this.PropertiesDataSet11.Namespace = "http://www.tempuri.org/propertiesDataSet1.xsd";
			// 
			// propertiesDataAdapter1
			// 
			this.propertiesDataAdapter1.DeleteCommand = this.oleDbDeleteCommand4;
			this.propertiesDataAdapter1.InsertCommand = this.oleDbInsertCommand4;
			this.propertiesDataAdapter1.SelectCommand = this.oleDbSelectCommand4;
			this.propertiesDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "BT_PROPERTIES", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("id", "id"),
																																																							  new System.Data.Common.DataColumnMapping("name", "name"),
																																																							  new System.Data.Common.DataColumnMapping("value", "value")})});
			this.propertiesDataAdapter1.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(120, 456);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 7;
			this.label8.Text = "Resolution:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtResolution
			// 
			this.txtResolution.Location = new System.Drawing.Point(192, 448);
			this.txtResolution.Name = "txtResolution";
			this.txtResolution.ReadOnly = true;
			this.txtResolution.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtResolution.Size = new System.Drawing.Size(568, 80);
			this.txtResolution.TabIndex = 8;
			this.txtResolution.Text = "";
			// 
			// txtResolved
			// 
			this.txtResolved.Location = new System.Drawing.Point(440, 536);
			this.txtResolved.Name = "txtResolved";
			this.txtResolved.ReadOnly = true;
			this.txtResolved.Size = new System.Drawing.Size(176, 20);
			this.txtResolved.TabIndex = 8;
			this.txtResolved.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(408, 536);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 23);
			this.label9.TabIndex = 7;
			this.label9.Text = "By:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(128, 256);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 23);
			this.label10.TabIndex = 7;
			this.label10.Text = "BUG ID:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBugID
			// 
			this.txtBugID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtBugID.Location = new System.Drawing.Point(192, 256);
			this.txtBugID.Name = "txtBugID";
			this.txtBugID.Size = new System.Drawing.Size(152, 23);
			this.txtBugID.TabIndex = 7;
			this.txtBugID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label11.Location = new System.Drawing.Point(24, 376);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 112);
			this.label11.TabIndex = 9;
			this.label11.Text = "(c) 2002, Mike Lehman, Free for non-commercial use.";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// aboutButton
			// 
			this.aboutButton.BackColor = System.Drawing.Color.Gold;
			this.aboutButton.Location = new System.Drawing.Point(16, 510);
			this.aboutButton.Name = "aboutButton";
			this.aboutButton.Size = new System.Drawing.Size(96, 48);
			this.aboutButton.TabIndex = 1;
			this.aboutButton.Text = "About Mike Lehman\'s Bug Tracker.Net...";
			this.aboutButton.Click += new System.EventHandler(this.AboutBox_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenu,
																					  this.bugStatusMenu,
																					  this.releaseStatusMenu,
																					  this.helpMenu});
			// 
			// fileMenu
			// 
			this.fileMenu.Index = 0;
			this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.importMenuItem,
																					 this.bugReportMenuItem,
																					 this.fileExitMenuItem});
			this.fileMenu.Text = "&File";
			// 
			// importMenuItem
			// 
			this.importMenuItem.Index = 0;
			this.importMenuItem.Text = "&Import MLBT File...";
			this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
			// 
			// bugReportMenuItem
			// 
			this.bugReportMenuItem.Index = 1;
			this.bugReportMenuItem.Text = "&Generate Bug Report...";
			this.bugReportMenuItem.Click += new System.EventHandler(this.bugReportMenuItem_Click);
			// 
			// fileExitMenuItem
			// 
			this.fileExitMenuItem.Index = 2;
			this.fileExitMenuItem.Text = "E&xit";
			this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
			// 
			// bugStatusMenu
			// 
			this.bugStatusMenu.Index = 1;
			this.bugStatusMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.changeToOpenMenuItem,
																						  this.changeToPostponedMenuItem,
																						  this.changeToVerifiedMenuItem,
																						  this.changeToIgnoreMenuItem,
																						  this.toggleOpenFilterMenuItem,
																						  this.moveToReleaseMenuItem,
																						  this.moveNonClosedMenuItem});
			this.bugStatusMenu.Text = "&BugStatus";
			// 
			// changeToOpenMenuItem
			// 
			this.changeToOpenMenuItem.Index = 0;
			this.changeToOpenMenuItem.Text = "Change to &Open";
			this.changeToOpenMenuItem.Click += new System.EventHandler(this.changeToOpenMenuItem_Click);
			// 
			// changeToPostponedMenuItem
			// 
			this.changeToPostponedMenuItem.Index = 1;
			this.changeToPostponedMenuItem.Text = "Change to Fix &Later";
			this.changeToPostponedMenuItem.Click += new System.EventHandler(this.changeToPostponedMenuItem_Click);
			// 
			// changeToVerifiedMenuItem
			// 
			this.changeToVerifiedMenuItem.Index = 2;
			this.changeToVerifiedMenuItem.Text = "Change to OK to &Fix";
			this.changeToVerifiedMenuItem.Click += new System.EventHandler(this.changeToVerifiedMenuItem_Click);
			// 
			// changeToIgnoreMenuItem
			// 
			this.changeToIgnoreMenuItem.Index = 3;
			this.changeToIgnoreMenuItem.Text = "Change to &Ignore";
			this.changeToIgnoreMenuItem.Click += new System.EventHandler(this.changeToIgnoreMenuItem_Click);
			// 
			// toggleOpenFilterMenuItem
			// 
			this.toggleOpenFilterMenuItem.Index = 4;
			this.toggleOpenFilterMenuItem.Text = "&Toggle OPEN Filter";
			this.toggleOpenFilterMenuItem.Click += new System.EventHandler(this.toggleOpenFilterMenuItem_Click);
			// 
			// moveToReleaseMenuItem
			// 
			this.moveToReleaseMenuItem.Index = 5;
			this.moveToReleaseMenuItem.Text = "&Move to another Release";
			this.moveToReleaseMenuItem.Click += new System.EventHandler(this.moveToReleaseMenuItem_Click);
			// 
			// moveNonClosedMenuItem
			// 
			this.moveNonClosedMenuItem.Index = 6;
			this.moveNonClosedMenuItem.Text = "Move &Non-CLOSED to another Release";
			this.moveNonClosedMenuItem.Click += new System.EventHandler(this.moveNonClosedMenuItem_Click);
			// 
			// releaseStatusMenu
			// 
			this.releaseStatusMenu.Index = 2;
			this.releaseStatusMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.markReleaseCompleteMenuItem,
																							  this.reopenCompletedReleaseMenuItem,
																							  this.toggleIncompleteFilterMenuItem});
			this.releaseStatusMenu.Text = "&ReleaseStatus";
			// 
			// markReleaseCompleteMenuItem
			// 
			this.markReleaseCompleteMenuItem.Index = 0;
			this.markReleaseCompleteMenuItem.Text = "Mark Release &Complete";
			this.markReleaseCompleteMenuItem.Click += new System.EventHandler(this.markReleaseCompleteMenuItem_Click);
			// 
			// reopenCompletedReleaseMenuItem
			// 
			this.reopenCompletedReleaseMenuItem.Index = 1;
			this.reopenCompletedReleaseMenuItem.Text = "&Reopen Completed Release";
			this.reopenCompletedReleaseMenuItem.Click += new System.EventHandler(this.reopenCompletedReleaseMenuItem_Click);
			// 
			// toggleIncompleteFilterMenuItem
			// 
			this.toggleIncompleteFilterMenuItem.Index = 2;
			this.toggleIncompleteFilterMenuItem.Text = "&Toggle Show Only Incomplete Releases Filter";
			this.toggleIncompleteFilterMenuItem.Click += new System.EventHandler(this.toggleIncompleteFilterMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.Index = 3;
			this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.helpAboutMenuItem});
			this.helpMenu.Text = "&Help";
			// 
			// helpAboutMenuItem
			// 
			this.helpAboutMenuItem.Index = 0;
			this.helpAboutMenuItem.Text = "&About Mike Lehman\'s BugTracker.Net...";
			this.helpAboutMenuItem.Click += new System.EventHandler(this.helpAboutMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "*.mdb";
			this.openFileDialog1.FileName = "btnet1.mdb";
			this.openFileDialog1.Filter = "Database files|*.mdb|All files|*.*";
			this.openFileDialog1.Title = "Select BugTracker.net Database...";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.DefaultExt = "mlbt";
			this.openFileDialog2.Filter = "MLBT Sesssion files|*.mlbt|All files|*.*";
			this.openFileDialog2.Multiselect = true;
			this.openFileDialog2.Title = "Select Mike Lehman\'s BugTracker.net Session File...";
			// 
			// updateBugBtn
			// 
			this.updateBugBtn.BackColor = System.Drawing.SystemColors.Control;
			this.updateBugBtn.Location = new System.Drawing.Point(16, 328);
			this.updateBugBtn.Name = "updateBugBtn";
			this.updateBugBtn.Size = new System.Drawing.Size(96, 23);
			this.updateBugBtn.TabIndex = 1;
			this.updateBugBtn.Text = "Update Bug...";
			this.updateBugBtn.Click += new System.EventHandler(this.updateBugBtn_Click);
			// 
			// toggleFilterButton
			// 
			this.toggleFilterButton.Location = new System.Drawing.Point(360, 256);
			this.toggleFilterButton.Name = "toggleFilterButton";
			this.toggleFilterButton.Size = new System.Drawing.Size(120, 23);
			this.toggleFilterButton.TabIndex = 10;
			this.toggleFilterButton.Text = "Toggle Open Filter";
			this.toggleFilterButton.Click += new System.EventHandler(this.toggleFilterButton_Click);
			// 
			// BTnetMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(768, 597);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.toggleFilterButton,
																		  this.label11,
																		  this.txtOpened,
																		  this.label3,
																		  this.lvBug,
																		  this.lvRelease,
																		  this.label2,
																		  this.addUserBtn,
																		  this.label1,
																		  this.addReleaseBtn,
																		  this.label4,
																		  this.label5,
																		  this.label6,
																		  this.txtCreatedBy,
																		  this.txtDescription,
																		  this.txtResolvedDate,
																		  this.label7,
																		  this.resolveBugButton,
																		  this.addBugButton,
																		  this.label8,
																		  this.txtResolution,
																		  this.txtResolved,
																		  this.label9,
																		  this.label10,
																		  this.txtBugID,
																		  this.aboutButton,
																		  this.updateBugBtn});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(776, 624);
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(776, 624);
			this.Name = "BTnetMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mike Lehman\'s BugTracker.net";
			((System.ComponentModel.ISupportInitialize)(this.bugDataSet11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personDataSet11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.releaseDataSet11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PropertiesDataSet11)).EndInit();
			this.ResumeLayout(false);

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		////////////////////////////////////////////////////////////
		protected override void Dispose( bool disposing )
		{
			string drXML;

			if (session != null && session.getTransactionCount() > 0)
			{
				foreach(DataRow dr in this.peopleDT.Rows)
				{
					drXML = BTXML.rowToXML(dr);
					session.addUpdate(new BTTransaction("update.person",drXML));
				}
				
				foreach(DataRow dr in this.releaseDT.Rows)
				{
					drXML = BTXML.rowToXML(dr);
					session.addUpdate(new BTTransaction("update.release",drXML));
				}
				
				session.close();
			}

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get the OID of the active user (from config file)
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
			public static string getOwnerOID()
		{
			return(myPersonOID);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return name of the default person
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static string getOwnerName()
		{
			return(myPersonName);
		}			   

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor for our form
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTnetMain()
		{
			InitializeComponent();
			BTnetINIT();
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get a handle (via a static method) to our instance
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static BTnetMain getInstance()
		{
			return(instance);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Initialize the application.
		/// Select database
		/// Load people and releases
		/// Ask user to pick the default user
		/// </summary>
		////////////////////////////////////////////////////////////
		public void BTnetINIT()
		{
			string mdbName;
			int peopleCount;
			StreamWriter sw;
			StreamReader sr;

			startupPath = Application.StartupPath;

			instance = this;
			this.Text = "Initializing...";

			this.Show();
			this.BringToFront();
			Application.DoEvents();

			this.openFileDialog1.InitialDirectory = Application.StartupPath;
			this.openFileDialog1.ShowDialog(this);
			if (this.openFileDialog1.FileName != null && this.openFileDialog1.FileName != "")
				mdbName = this.openFileDialog1.FileName;
			else
				mdbName = "btnet1.mdb";

			this.oleDbConnection1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=";
			this.oleDbConnection1.ConnectionString += mdbName + @";Mode=ReadWrite;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";

			Console.WriteLine(this.oleDbConnection1.ConnectionString);
			Application.DoEvents();

			loadProperties();
			peopleCount = loadPeople();
			loadAndShowReleases(false);

			session = new BTSession();

			theExecutor = new BTExec(this.personDataAdapter,
				                     this.personDataSet11,
				                     this.releaseDataAdapter,
								     this.releaseDataSet11,
									 this.bugDataAdapter,
									 this.bugDataSet11,
									 props);
			this.BringToFront();
			if (peopleCount > 1)
			{
				myPersonOID = "";
				try
				{
					sr = new StreamReader(Application.StartupPath+"\\user.txt");
					myPersonOID = sr.ReadLine();
					sr.Close();
				}
				catch
				{
				}

				if (myPersonOID == "")
				{
					BTPickUser.setUserList(peopleNames);
					new BTPickUser().ShowDialog();
					if (BTPickUser.getSelection() != -1)
					{
						myPersonOID = (string) peopleOIDs[BTPickUser.getSelection()];
						if (BTPickUser.getRemember())
						{
							sw = new StreamWriter(Application.StartupPath+"\\user.txt");
							sw.WriteLine(myPersonOID);
							sw.Close();
						}
					}
				}
			}
			myPersonName  = "";
			if (peopleDT.Rows.Find(myPersonOID) != null)
			{
				myPersonName = (string) peopleDT.Rows.Find(myPersonOID)["name"];
			}

			this.Text = "Mike Lehman's BugTracker.net -- Version: " + Version.number + " (" + myPersonName + ")";
			if (releaseDT.Rows.Count > 0)
			{
				lvRelease.Focus();
				lvRelease.Items[0].Selected = true;
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Load the contents of the BT_RELEASES table and
		/// show it in the topmost ListView
		/// </summary>
		////////////////////////////////////////////////////////////
		protected void loadAndShowReleases(bool tryToSelect)
		{

			if (this.showIncompleteReleasesOnly)
				oleDbSelectCommand3.CommandText = "SELECT * FROM BT_RELEASE WHERE extra1 <> 'COMPLETE'";
			else
				oleDbSelectCommand3.CommandText = "SELECT * FROM BT_RELEASE";

			releaseDataSet11.Clear();
			releaseDataAdapter.Fill(releaseDataSet11);
			releaseDT = releaseDataSet11.Tables["BT_RELEASE"];
			lvRelease.Clear();
			clearBugTxtBoxes();
			fillLVfromDT(lvRelease,releaseDisplayColNames,releaseDbColNames, releaseColWidths,releaseDT);
			if (releaseDT.Rows.Count > 0 && tryToSelect)
			{
				lvRelease.Focus();
				lvRelease.Items[0].Selected = true;
			}
			else
				curReleaseRow = null;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Load the contents of the BT_PROPERTIES table into
		/// the props Hashtable
		/// </summary>
		////////////////////////////////////////////////////////////
		protected void loadProperties()
		{
			string propName;
			string propVal;

			props = new Hashtable();

			propertiesDataAdapter1.Fill(PropertiesDataSet11);
			propertiesDT = PropertiesDataSet11.Tables["BT_PROPERTIES"];
			foreach (DataRow dr in propertiesDT.Rows)
			{
				propName = (string) dr["name"];
				propVal = (string) dr["value"];
				props.Add(propName,propVal);
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Load the correspondance from people names to OIDs
		/// into the personToOID and OIDtoPerson Hashtable
		/// </summary>
		////////////////////////////////////////////////////////////
		protected int loadPeople()
		{
			//
			// and get the list of people we know about
			//
			personDataAdapter.Fill(personDataSet11);
			personToOID = new Hashtable();
			OIDtoPerson = new Hashtable();
			peopleDT = this.personDataSet11.Tables["BT_PERSON"];
			peopleNames = new ArrayList();
			peopleOIDs = new ArrayList();

			foreach(DataRow dr in peopleDT.Rows)
			{
				peopleNames.Add(dr["name"]);
				peopleOIDs.Add(dr["personOID"]);
				personToOID.Add(dr["name"],dr["personOID"]);
				OIDtoPerson.Add(dr["personOID"],dr["name"]);
			}
			return(peopleNames.Count);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		////////////////////////////////////////////////////////////
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.Run(new BTnetMain());
			}
			catch(Exception e)
			{
				MessageBox.Show("An error has occurred.  Please e-mail bugs@mikelehman.com with this information:\n\n\n"+e.ToString());
			}
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Fill in a ListView control from a DataTable
		/// </summary>
		/// <param name="myListView">ListView to be filled in</param>
		/// <param name="columnNames">String array containing display column names</param>
		/// <param name="dbColumnNames">String array containing column names from DB</param>
		/// <param name="colWidths">int array containing initial column widths</param>
		/// <param name="myDT">DataTable containing the data</param>
		////////////////////////////////////////////////////////////
		protected void fillLVfromDT(ListView myListView,
									string[] columnNames,
									string[] dbColumnNames,
									int[] colWidths,
									DataTable myDT)
		{
			ListViewItem lvi;
			string[] strA;
			ColumnHeader[] chArray;
			int i;
			int j;
			int k;
			int itemNo;
			int indx;
			ColumnHeader ch;

			//
			// First build an array of ColumnHeader objects
			//
			chArray = new ColumnHeader[columnNames.Length];

			for(i=0; i < columnNames.Length; i++)
			{
				ch = new ColumnHeader();
				ch.Text = columnNames[i];
				ch.Width = colWidths[i];
				ch.TextAlign = HorizontalAlignment.Left;
				chArray[i] = ch;
			}

			strA = new string[columnNames.Length];

			//
			// Then build an array of the items in each row
			// and then create a ListViewItem containing that data
			//
			itemNo = 1;

			for(i=0; i < myDT.Rows.Count; i++)
			{
				for(j=0; j < dbColumnNames.Length; j++)
				{
					if (dbColumnNames[j].EndsWith("OID"))
					{
						strA[j] = (string) OIDtoPerson[myDT.Rows[i].ItemArray[getDBColumnIndex(myDT,dbColumnNames[j])]];
					}
					else if (dbColumnNames[j] == "@")
						strA[j] = itemNo.ToString();
					else
					{
						indx = getDBColumnIndex(myDT,dbColumnNames[j]);
						try
						{
							strA[j] = myDT.Rows[i].ItemArray[indx].ToString();
						}
						catch // handle DB nulls
						{
							strA[j] = "";
						}

						k = strA[j].IndexOf("\x0A");
						if (k != -1)
							strA[j] = strA[j].Substring(0,k);
					}
				}
				lvi = new ListViewItem(strA);
				myListView.Items.Add(lvi);
				itemNo++;
			}

			myListView.Columns.AddRange( chArray);
			myListView.View = View.Details;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle user selecting a different row in BUG ListView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void lvBug_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			curBugRow = null;
			if (lvBug.SelectedItems.Count > 0)
			{
				curBugRow = bugDT.Rows[int.Parse(lvBug.SelectedItems[0].SubItems[0].Text)-1];
				clearBugTxtBoxes();
				fillBugTxtBoxes(curBugRow);
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get the index of a column in a datatable by name
		/// </summary>
		/// <param name="dt">DataTable we are focused on</param>
		/// <param name="colName">DB name of column</param>
		/// <returns>0..n index of specified column or -1 if not found</returns>
		////////////////////////////////////////////////////////////
		protected int getDBColumnIndex(DataTable dt, string colName)
		{
			int k;
			int indx;

			indx = -1;
			for(k=0; k < dt.Columns.Count+1; k++)
			{
				if (dt.Columns[k].ColumnName == colName)
				{
					indx = k;
					break;
				}
			}
			return(indx);
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Fill in fields from specified row of a dataset
		/// </summary>
		/// <param name="dt">DataTable containin the data we want</param>
		/// <param name="indx">Index of row containing the data</param>
		////////////////////////////////////////////////////////////
		protected void fillBugTxtBoxes(DataRow dr)
		{
			string resolvedByOID = null; 

			this.txtBugID.Text = (string) dr["bugOID"];
			this.txtOpened.Text = (string) dr["creationTimestamp"].ToString();
			this.txtCreatedBy.Text = (string) OIDtoPerson[dr["creatorOID"]];
			this.txtDescription.Text = (string) dr["description"];

			if (dr["resolvedByOID"] != System.DBNull.Value)
				resolvedByOID =  (string) dr["resolvedByOID"];
		    
			if ((resolvedByOID == null) || (resolvedByOID.Length < 1))
				this.txtResolved.Text = "";
			else
				this.txtResolved.Text = (string) OIDtoPerson[resolvedByOID];
			if (dr["resolution"] != System.DBNull.Value)
				this.txtResolution.Text = (string) dr["resolution"];
			this.txtResolvedDate.Text = dr["completionTimestamp"].ToString();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Clear the display fields
		/// </summary>
		////////////////////////////////////////////////////////////
		protected void clearBugTxtBoxes()
		{
			this.txtBugID.Text = "";
			this.txtOpened.Text = "";
			this.txtCreatedBy.Text = "";
			this.txtDescription.Text = "";
			this.txtResolved.Text = "";
			this.txtResolvedDate.Text = "";
			this.txtResolution.Text = "";
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle user selecting a new row in the RELEASE ListView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void lvRelease_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string releaseOID;
			int indx;

			releaseOID = "";
			if (lvRelease.SelectedItems.Count > 0)
			{
				//Console.WriteLine(lvRelease.SelectedIndices[0].ToString());
				indx = lvRelease.SelectedIndices[0];
				curReleaseRow = releaseDT.Rows[indx];
				releaseOID = (string) curReleaseRow["releaseOID"];
			}
			else
				curReleaseRow = null;

			if (releaseOID == "")
				return;

			bugDT = getBugTableFromRelease(releaseOID);
			lvBug.Clear();
			clearBugTxtBoxes();
			fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Extract a set of rows from the BUG table that match
		/// the supplied release's OID.
		/// Created to support both the main display and reports
		/// </summary>
		/// <param name="releaseOID"></param>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public DataTable getBugTableFromRelease(string releaseOID)
		{
			DataTable result;

			if (this.hideNonOpenBugs)
				oleDbSelectCommand1.CommandText = "SELECT * FROM BT_BUG WHERE releaseOID='" + releaseOID + "' AND status='OPEN'";
			else
				oleDbSelectCommand1.CommandText = "SELECT * FROM BT_BUG WHERE releaseOID='" + releaseOID + "'";
			bugDataSet11.Clear();
			bugDataAdapter.Fill(bugDataSet11);
			result = bugDataSet11.Tables["BT_BUG"];
			return(result);
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the "Resolve Bug" button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void resolveBugButton_Click(object sender, System.EventArgs e)
		{
			com.mikelehman.bugtracker.ResolveBug rb;
			string releaseOID;

			if (this.curBugRow!= null)
			{
				if (((string)curBugRow["status"]) == "CLOSED")
				{
					MessageBox.Show("You cannot resolve a closed bug");
					return;
				}
															  
				try
				{
					curBugRow = bugDT.Rows[int.Parse(lvBug.SelectedItems[0].SubItems[0].Text)-1];
					releaseOID = (string) curReleaseRow["releaseOID"];
					rb = new ResolveBug(this.bugDataAdapter,
						this.bugDataSet11,
						props,
						curReleaseRow["name"].ToString(),
						curReleaseRow["releaseOID"].ToString(),
						this.personToOID,
						this.OIDtoPerson,
						curBugRow);
					rb.ShowDialog();
					bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
					lvBug.Clear();
					fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
					clearBugTxtBoxes();
					curBugRow = null;
				}
				catch
				{
					MessageBox.Show("You must select a bug before you can resolve it");
				}
			}
			else
				MessageBox.Show("You must select a bug before you can resolve it");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the "New Bug" button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void addBugButton_Click(object sender, System.EventArgs e)
		{
			com.mikelehman.bugtracker.NewBug nb;
			int indx;
			string releaseOID;

			if (this.curReleaseRow != null)
			{
				try
				{
					//Console.WriteLine(lvRelease.SelectedIndices[0].ToString());
					indx = lvRelease.SelectedIndices[0];
					curReleaseRow = releaseDT.Rows[indx];
					releaseOID = (string) curReleaseRow["releaseOID"];
					nb = new NewBug(this.bugDataAdapter,
								    this.bugDataSet11,
									props,
									curReleaseRow["name"].ToString(),
									curReleaseRow["releaseOID"].ToString(),
									this.personToOID,
									null,
									null);
					nb.ShowDialog();
					bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
					lvBug.Clear();
					fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
					clearBugTxtBoxes();
					curBugRow = null;
				}
				catch
				{
					MessageBox.Show("You must select a release before you can add a bug");
				}
			}
			else
				MessageBox.Show("You must select a release before you can add a bug");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle "About button"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void AboutBox_Click(object sender, System.EventArgs e)
		{
			AboutBox ab;

			ab = new com.mikelehman.bugtracker.AboutBox();
			ab.ShowDialog();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle "Add User..." button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void addUserBtn_Click(object sender, System.EventArgs e)
		{
			NewUser nu;

			nu = new com.mikelehman.bugtracker.NewUser(this.personDataAdapter,this.personDataSet11,props);
			nu.ShowDialog();
			//
			// now, reload the people data
			//
			this.loadPeople();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle Help/About menu item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		///////////////////////////////////////////////////////////
		private void helpAboutMenuItem_Click(object sender, System.EventArgs e)
		{
			AboutBox_Click(null,null);		
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle File/Exit menu item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void fileExitMenuItem_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a new "Release" button handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void addReleaseBtn_Click(object sender, System.EventArgs e)
		{
			NewRelease nr;

			nr = new com.mikelehman.bugtracker.NewRelease(this.releaseDataAdapter,this.releaseDataSet11,props);
			nr.ShowDialog();
			//
			// now, reload the people data
			//
			this.loadAndShowReleases(true);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle column clicks in BUG ListView to support sorting
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvBug_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) 
		{ 
			SorterClass sc = new SorterClass(e.Column,this.lvBug.Sorting); 
			lvBug.ListViewItemSorter = sc; 
			if (this.lvBug.Sorting == System.Windows.Forms.SortOrder.Ascending)
				this.lvBug.Sorting = System.Windows.Forms.SortOrder.Descending;
			else
				this.lvBug.Sorting = System.Windows.Forms.SortOrder.Ascending;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Select all bugs into bugDT
		/// </summary>
		////////////////////////////////////////////////////////////
		private void selectAllBugs()
		{
			this.hideNonOpenBugs = false;
			oleDbSelectCommand1.CommandText = "SELECT * FROM BT_BUG";
			bugDataSet11.Clear();
			bugDataAdapter.Fill(bugDataSet11);
			bugDT = bugDataSet11.Tables["BT_BUG"];

		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Handle "Import MLBT File..." menu item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void importMenuItem_Click(object sender, System.EventArgs e)
		{
			string[] fileNames;
			BTProcessing btp;

			this.openFileDialog2.ShowDialog(this);
			fileNames = this.openFileDialog2.FileNames;

			btp = new BTProcessing();
			btp.Show();
			Application.DoEvents();

			foreach(string fn in fileNames)
			{
				if (fn != null &&
					fn != "" &&
					fn.EndsWith(".mlbt"))
				{
					//
					// First we have to make the bugDataTable contain all the
					// bugs so in case we get in a duplicate we can update instead
					// of throwing an exception

					selectAllBugs();
					//
					// Then we import the session file
					//
					session.loadMLBTfile(fn,btp);
				}
			}
			btp.Hide();
			//
			// now, reload all the data
			//
			loadPeople();
			lvBug.Clear();
			clearBugTxtBoxes();
			loadAndShowReleases(true);
		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Handle Generate Bug Report menu item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		///////////////////////////////////////////////////////////
		private void bugReportMenuItem_Click(object sender, System.EventArgs e)
		{
			string HTMLdata;
			BTBugReport br;
			StreamWriter rptW;
			BTReportOptions btro;
			System.Windows.Forms.DialogResult dResult;
			BTReleasePicker rp;
			string releaseOID;


			selectAllBugs();

			if (bugDT.Rows == null)
			{
				MessageBox.Show("There are no bugs on which to report");
				return;
			}

			rp = new BTReleasePicker(releaseDT);
			rp.Text = "Create Bug Report for which Release?";
			dResult = rp.ShowDialog();
			if (dResult != DialogResult.OK)
				return;

			releaseOID = BTReleasePicker.getSelectionOID();

			btro = new BTReportOptions();
			dResult = btro.ShowDialog(this);
			if (dResult == DialogResult.OK)
			{
				bugDT = this.getBugTableFromRelease(releaseOID);
				br = new BTBugReport(releaseDT,peopleDT.Rows.Find(myPersonOID), releaseOID);
				HTMLdata = br.getReport();
				rptW = new StreamWriter(startupPath + "report.html");
				rptW.WriteLine(HTMLdata);
				rptW.Close();
				System.Diagnostics.Process.Start(startupPath + "report.html");
			}
		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Update a bug.  i.e. generate an update.bug.data transaction
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		///////////////////////////////////////////////////////////
		private void updateBugBtn_Click(object sender, System.EventArgs e)
		{
			com.mikelehman.bugtracker.NewBug rb;
			string releaseOID;

			if (this.curBugRow!= null)
			{
				if (((string)curBugRow["status"]) == "CLOSED")
				{
					MessageBox.Show("You cannot update a closed bug");
					return;
				}
															  
				try
				{
					curBugRow = bugDT.Rows[int.Parse(lvBug.SelectedItems[0].SubItems[0].Text)-1];
					releaseOID = (string) curReleaseRow["releaseOID"];
					rb = new NewBug(this.bugDataAdapter,
						this.bugDataSet11,
						props,
						curReleaseRow["name"].ToString(),
						curReleaseRow["releaseOID"].ToString(),
						this.personToOID,
						this.OIDtoPerson,
						curBugRow);
					rb.ShowDialog();
					bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
					lvBug.Clear();
					fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
					clearBugTxtBoxes();
					curBugRow = null;
				}
				catch
				{
					MessageBox.Show("You must select a bug before you can update it");
				}
			}
			else
				MessageBox.Show("You must select a bug before you can update it");
		
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle menu item changing state of current bug (the real work method)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void changeBugState(string newState)
		{
			if (this.curBugRow!= null)
			{
				if (((string)curBugRow["status"]) == "CLOSED")
				{
					MessageBox.Show("You cannot update a closed bug");
					return;
				}
															  
				try
				{
					curBugRow = bugDT.Rows[int.Parse(lvBug.SelectedItems[0].SubItems[0].Text)-1];
					curBugRow["status"] = newState;
					BTExec.getSingleton().exec("update.bug.data",BTXML.rowToXML(curBugRow));
					bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
					lvBug.Clear();
					fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
					clearBugTxtBoxes();
					curBugRow = null;
				}
				catch
				{
					MessageBox.Show("You must select a bug before you can update it");
				}
			}
			else
				MessageBox.Show("You must select a bug before you can update it");
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle menu item changing state of current bug
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void changeToOpenMenuItem_Click(object sender, System.EventArgs e)
		{
			changeBugState("OPEN");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle menu item changing state of current bug
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void changeToPostponedMenuItem_Click(object sender, System.EventArgs e)
		{
			changeBugState("LATER");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle menu item changing state of current bug
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void changeToVerifiedMenuItem_Click(object sender, System.EventArgs e)
		{
			changeBugState("OK2FIX");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle menu item changing state of current bug
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void changeToIgnoreMenuItem_Click(object sender, System.EventArgs e)
		{
			changeBugState("IGNORE");
		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Toggle the hiding and showing of non-OPEN bugs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		///////////////////////////////////////////////////////////
		private void toggleOpenFilterMenuItem_Click(object sender, System.EventArgs e)
		{
			hideNonOpenBugs = !hideNonOpenBugs;
			if (this.curReleaseRow == null)
				return;

			bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
			lvBug.Clear();
			fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
			clearBugTxtBoxes();
			curBugRow = null;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the Toggle OPEN Filter button.
		/// Duplicates the Bug Status/Toggle menu item logic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void toggleFilterButton_Click(object sender, System.EventArgs e)
		{
			toggleOpenFilterMenuItem_Click(null,null);
		}

		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Move the currently selected bug to a different release
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void moveToReleaseMenuItem_Click(object sender, System.EventArgs e)
		{
			BTReleasePicker rp;
			System.Windows.Forms.DialogResult dResult;

			rp = new BTReleasePicker(releaseDT);
			rp.Text = "Move this bug to which release??";
			dResult = rp.ShowDialog(this);

			if (dResult != DialogResult.OK)
				return;

			if (this.curBugRow!= null)
			{
				if (((string)curBugRow["status"]) == "CLOSED")
				{
					MessageBox.Show("You cannot move a closed bug");
					return;
				}
															  
				try
				{
					curBugRow = bugDT.Rows[int.Parse(lvBug.SelectedItems[0].SubItems[0].Text)-1];
					curBugRow["releaseOID"] = BTReleasePicker.getSelectionOID();
					BTExec.getSingleton().exec("update.bug.data",BTXML.rowToXML(curBugRow));
					bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
					lvBug.Clear();
					fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
					clearBugTxtBoxes();
					curBugRow = null;
					loadAndShowReleases(true);
				}
				catch
				{
					MessageBox.Show("You must select a bug before you can move it");
				}
			}
			else
				MessageBox.Show("You must select a bug before you can move it");

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Move ALL the non-CLOSED bugs to a different release
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void moveNonClosedMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dResult2;
			DataRow theRow;
			BTReleasePicker rp;
			System.Windows.Forms.DialogResult dResult;


			dResult2 = MessageBox.Show(this,"Do you want to move all the non-closed bugs to another release?","CONFIRM NON-CLOSED BUG MOVES",MessageBoxButtons.YesNo);
			if (dResult2 != DialogResult.Yes)
				return;

			rp = new BTReleasePicker(releaseDT);
			rp.Text = "Move all NON-CLOSED bugs to which release?";
			dResult = rp.ShowDialog(this);

			if (dResult != DialogResult.OK)
				return;


			while((theRow = findNonClosedBug()) != null)
			{
				try
				{
					theRow["releaseOID"] = BTReleasePicker.getSelectionOID();
					BTExec.getSingleton().exec("update.bug.data",BTXML.rowToXML(theRow));
				}
				catch
				{
					MessageBox.Show("Error trying to move bug!");
				}

			}

			bugDT = getBugTableFromRelease((string)curReleaseRow["releaseOID"]);
			lvBug.Clear();
			fillLVfromDT(lvBug,bugDisplayColNames,bugDbColNames,bugColWidths,bugDT);
			clearBugTxtBoxes();
			curBugRow = null;
			loadAndShowReleases(true);
			return;

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Find a non-CLOSED bug, if any in the current dataset
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		private DataRow findNonClosedBug()
		{
			this.hideNonOpenBugs = false;

			//
			// First, let's see if we can find a non-closed bug
			//
			bugDT = this.getBugTableFromRelease(curReleaseRow["releaseOID"] as string);
			foreach(DataRow dr in bugDT.Rows)
			{
				if ((dr["status"] as string) != "CLOSED")
				{
					return(dr);
				}
			}
			return(null);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Toggle the "show incomplete releases only" flag
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void toggleIncompleteFilterMenuItem_Click(object sender, System.EventArgs e)
		{
			showIncompleteReleasesOnly = !showIncompleteReleasesOnly;		
			clearBugTxtBoxes();
			curBugRow = null;
			loadAndShowReleases(true);

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Change the state of a release to COMPLETE
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void markReleaseCompleteMenuItem_Click(object sender, System.EventArgs e)
		{
			changeReleaseStatus("COMPLETE");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Change the state of a release to OPEN
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void reopenCompletedReleaseMenuItem_Click(object sender, System.EventArgs e)
		{
			changeReleaseStatus("OPEN");
		}

		private void changeReleaseStatus(string newStatus)
		{
			BTReleasePicker rp;
			System.Windows.Forms.DialogResult dResult;
			DataRow dr;

			rp = new BTReleasePicker(releaseDT);
			rp.Text = "Change status to: " + newStatus + " on which release?";
			dResult = rp.ShowDialog(this);

			if (dResult != DialogResult.OK)
				return;

			dr = releaseDT.Rows.Find(BTReleasePicker.getSelectionOID());
			if (dr != null)
			{
				dr["extra1"] = newStatus;
				BTExec.getSingleton().exec("update.release",BTXML.rowToXML(dr));
			}

			clearBugTxtBoxes();
			curBugRow = null;
			loadAndShowReleases(true);

		}

	}


}
////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
