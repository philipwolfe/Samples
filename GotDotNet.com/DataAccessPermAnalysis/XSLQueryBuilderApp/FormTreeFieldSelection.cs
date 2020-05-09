using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormTreeFieldSelection.
	/// </summary>
	public class FormTreeFieldSelection : System.Windows.Forms.Form
	{
		public string fieldsMainTableName;
		public DataAccessProvider dataAccessProvider;

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TreeView treeFields;
		private System.Windows.Forms.Button btnSelect;
		private ArrayList _resultFields;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTreeFieldSelection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_resultFields = new ArrayList();
		}

		public ArrayList resultFields
		{
			get 
			{
				return _resultFields;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.treeFields = new System.Windows.Forms.TreeView();
			this.btnSelect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 299);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// treeFields
			// 
			this.treeFields.CheckBoxes = true;
			this.treeFields.ImageIndex = -1;
			this.treeFields.Location = new System.Drawing.Point(40, 19);
			this.treeFields.Name = "treeFields";
			this.treeFields.SelectedImageIndex = -1;
			this.treeFields.Size = new System.Drawing.Size(384, 272);
			this.treeFields.TabIndex = 4;
			this.treeFields.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFields_BeforeCheck);
			this.treeFields.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFields_BeforeExpand);
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(128, 299);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.TabIndex = 3;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// FormTreeFieldSelection
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.treeFields,
																		  this.btnSelect});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormTreeFieldSelection";
			this.ShowInTaskbar = false;
			this.Text = "Select Fields";
			this.Load += new System.EventHandler(this.FormTreeFieldSelection_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormTreeFieldSelection_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			treeFields.BeginUpdate();
			buildRootNode(fieldsMainTableName,treeFields);
			Cursor.Current = Cursors.Default;
			treeFields.EndUpdate();			
		}

		private void buildRootNode(string sTableName,TreeView treeView) 
		{
			TableNodeModel TableNodeModel = new TableNodeModel(sTableName,null,dataAccessProvider);
			TreeNode tableTreeNode = generateTreeNodeModel(TableNodeModel);

			treeView.Nodes.Add(tableTreeNode);
			onNodeExposed(tableTreeNode);
		}

		private TreeNode generateTreeNodeModel(TreeNodeModel nodeModel) 
		{
			TreeNode TreeNodeModel = new TreeNode(nodeModel.label);

			TreeNodeModel.Tag = nodeModel;
			return TreeNodeModel;
		}

		private void onNodeExposed(TreeNode treeNode) 
		{
			TreeNodeModel TreeNodeModel = (TreeNodeModel)treeNode.Tag;

			if(!TreeNodeModel.initialExposeOccured) 
			{
				TreeNodeModel.onInitialExpose();
				foreach(TreeNodeModel childNode in TreeNodeModel.childNodes) 
					treeNode.Nodes.Add(generateTreeNodeModel(childNode));
			}
		}

		private void treeFields_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode parentNode = e.Node;

			foreach(TreeNode childNode in parentNode.Nodes)
				onNodeExposed(childNode);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			addCheckedNodes(treeFields.Nodes[0]);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void addCheckedNodes(TreeNode node) 
		{
			if(node.Checked)
				_resultFields.Add(((TreeNodeModel)node.Tag).generateSelection());
			foreach(TreeNode childNode in node.Nodes)
				addCheckedNodes(childNode);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void treeFields_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			e.Cancel = !(((TreeNodeModel)e.Node.Tag).mayBeSelected);
		}
	}
}
