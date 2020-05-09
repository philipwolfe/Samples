/*
 * Paresh Gheewala - pareshgh@hotmail.com
 * 
 * The program will search a string within the tree 
 * you can expand upto your needs meaning that modify the search routine and include your 
 * complex search algorithm there.
 * so if the node fits in the category then it will return the node
 * */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinTreeViewSearchData
{

	/// <summary>
	/// SearchCriteria Class is used to fill the search criteria and perform the search
	/// </summary>
	public class SearchCriteria
	{
		/// <summary>
		/// This is a Search String Source where it can be any source text to search into
		/// </summary>
		public string strSearchSource = "";
		/// <summary>
		/// the search text (you can expanded upto arbitary search pattern with using regular expressions)
		/// </summary>
		public string strSearchText = "" ;
		/// <summary>
		/// Search options
		/// </summary>
		public bool bSearchExact = false;
		/// <summary>
		///  you can modify to your advance search or use Regex-Regular Expressions
		/// </summary>
		/// <returns></returns>
		internal bool SearchTheTextWithCriteria()
		{
			if ( bSearchExact==true && strSearchSource.CompareTo(strSearchText) == 0)
			{
				return true;
			}
			else if ( bSearchExact == false && strSearchSource.IndexOf(strSearchText)!=-1 )
			{
				return true;
			}
			else return false;
		}
			


	}


	/// <summary>
	/// Summary description for FrmTreeSrch.
	/// </summary>
	public class FrmTreeSrch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelSearchData;
		private System.Windows.Forms.Label labelSearch;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.TreeView treeViewSearch;
		private System.Windows.Forms.CheckBox checkBoxSearchExact;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmTreeSrch()
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
			this.panelSearchData = new System.Windows.Forms.Panel();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.labelSearch = new System.Windows.Forms.Label();
			this.treeViewSearch = new System.Windows.Forms.TreeView();
			this.checkBoxSearchExact = new System.Windows.Forms.CheckBox();
			this.panelSearchData.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelSearchData
			// 
			this.panelSearchData.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.checkBoxSearchExact,
																						  this.textBoxSearch,
																						  this.buttonSearch,
																						  this.labelSearch});
			this.panelSearchData.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSearchData.DockPadding.All = 5;
			this.panelSearchData.Name = "panelSearchData";
			this.panelSearchData.Size = new System.Drawing.Size(512, 56);
			this.panelSearchData.TabIndex = 0;
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxSearch.Location = new System.Drawing.Point(133, 5);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(286, 22);
			this.textBoxSearch.TabIndex = 1;
			this.textBoxSearch.Text = "";
			// 
			// buttonSearch
			// 
			this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.buttonSearch.Location = new System.Drawing.Point(419, 5);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(88, 46);
			this.buttonSearch.TabIndex = 2;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// labelSearch
			// 
			this.labelSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelSearch.Location = new System.Drawing.Point(5, 5);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(128, 46);
			this.labelSearch.TabIndex = 0;
			this.labelSearch.Text = "Enter Search Text";
			// 
			// treeViewSearch
			// 
			this.treeViewSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeViewSearch.ImageIndex = -1;
			this.treeViewSearch.Location = new System.Drawing.Point(0, 56);
			this.treeViewSearch.Name = "treeViewSearch";
			this.treeViewSearch.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					   new System.Windows.Forms.TreeNode("Chapter 1", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("Page 1", new System.Windows.Forms.TreeNode[] {
																																																																  new System.Windows.Forms.TreeNode("Para 1", new System.Windows.Forms.TreeNode[] {
																																																																																					  new System.Windows.Forms.TreeNode("This is a story")})}),
																																											  new System.Windows.Forms.TreeNode("Page 2", new System.Windows.Forms.TreeNode[] {
																																																																  new System.Windows.Forms.TreeNode("Para 1", new System.Windows.Forms.TreeNode[] {
																																																																																					  new System.Windows.Forms.TreeNode("Story Continues")}),
																																																																  new System.Windows.Forms.TreeNode("Para 2", new System.Windows.Forms.TreeNode[] {
																																																																																					  new System.Windows.Forms.TreeNode("Sentence 1")})})}),
																					   new System.Windows.Forms.TreeNode("Chapter 2", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("Page 3", new System.Windows.Forms.TreeNode[] {
																																																																  new System.Windows.Forms.TreeNode("Image 1"),
																																																																  new System.Windows.Forms.TreeNode("Para 1"),
																																																																  new System.Windows.Forms.TreeNode("Para 2")}),
																																											  new System.Windows.Forms.TreeNode("Page 4")}),
																					   new System.Windows.Forms.TreeNode("Chapter 3"),
																					   new System.Windows.Forms.TreeNode("Chapter 4")});
			this.treeViewSearch.SelectedImageIndex = -1;
			this.treeViewSearch.Size = new System.Drawing.Size(512, 333);
			this.treeViewSearch.TabIndex = 1;
			// 
			// checkBoxSearchExact
			// 
			this.checkBoxSearchExact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBoxSearchExact.Location = new System.Drawing.Point(132, 32);
			this.checkBoxSearchExact.Name = "checkBoxSearchExact";
			this.checkBoxSearchExact.Size = new System.Drawing.Size(280, 18);
			this.checkBoxSearchExact.TabIndex = 3;
			this.checkBoxSearchExact.Text = "Search Exact";
			// 
			// FrmTreeSrch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.treeViewSearch,
																		  this.panelSearchData});
			this.Name = "FrmTreeSrch";
			this.Text = "Search Your Tree Data";
			this.Load += new System.EventHandler(this.FrmTreeSrch_Load);
			this.panelSearchData.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmTreeSrch());
		}



		private void FrmTreeSrch_Load(object sender, System.EventArgs e)
		{
			treeViewSearch.ExpandAll();
		}



		private void buttonSearch_Click(object sender, System.EventArgs e)
		{
			// fill the critera and modify the SearchTheTextWithCriteria algorithm/logic
			SearchCriteria oSearch = new SearchCriteria();
			oSearch.bSearchExact = checkBoxSearchExact.Checked;
			oSearch.strSearchText = textBoxSearch.Text;

			TreeNode tFound = null;

			TreeTextSearch(treeViewSearch.Nodes, oSearch, ref tFound);
			if ( tFound == null ) // do the required steps
				MessageBox.Show("No Text was found");
			else
				MessageBox.Show(tFound.Text); // show parent nodes or whatever :-))
		}

		/// <summary>
		/// TreeTextSearch Method searches with in the inner nodes untill arbitary length and finds the first node
		/// </summary>
		/// <param name="tNodes"> expects the initial Treenodes to start with you can include the inner node/branches also - the search starts from there - will limit to that level</param>
		/// <param name="oSearch">SearchCriteria object - which is filled with search patterns and search logic, source can be changed, pattern may be changed too</param>
		/// <param name="tFound"> reference to the current found tree object</param>
		private void TreeTextSearch(TreeNodeCollection tNodes, SearchCriteria oSearch,  ref TreeNode tFound)
		{
			if ( tNodes == null ) 	tFound = null;
			else
			{
				foreach( TreeNode tCurrent in tNodes)
				{
					oSearch.strSearchSource = tCurrent.Text;
					if ( oSearch.SearchTheTextWithCriteria() ) {		tFound = tCurrent; 		return; 		}
					TreeTextSearch(tCurrent.Nodes,oSearch,ref tFound);	// recursively call again to process innner nodes
				}
			}
		} // TreeTextSearch
	}  // class FrmTreeSrch : System.Windows.Forms.Form
} // namespace WinTreeViewSearchData
