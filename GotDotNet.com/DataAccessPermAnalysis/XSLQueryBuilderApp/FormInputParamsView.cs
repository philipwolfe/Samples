using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormInputParamsView.
	/// </summary>
	public class FormInputParamsView : System.Windows.Forms.Form
	{

		public ArrayList viewedParams;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.ListBox listParams;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormInputParamsView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.btnEdit = new System.Windows.Forms.Button();
			this.listParams = new System.Windows.Forms.ListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(242, 93);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.TabIndex = 20;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// listParams
			// 
			this.listParams.Location = new System.Drawing.Point(26, 13);
			this.listParams.Name = "listParams";
			this.listParams.Size = new System.Drawing.Size(208, 238);
			this.listParams.TabIndex = 19;
			this.listParams.DoubleClick += new System.EventHandler(this.listParams_DoubleClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(178, 269);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(26, 269);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(112, 24);
			this.btnOK.TabIndex = 17;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(242, 61);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 16;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(242, 29);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// FormInputParamsView
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(342, 307);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnEdit,
																		  this.listParams,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.btnRemove,
																		  this.btnAdd});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormInputParamsView";
			this.ShowInTaskbar = false;
			this.Text = "Input Parameters";
			this.Load += new System.EventHandler(this.FormInputParamsView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormInputParamsView_Load(object sender, System.EventArgs e)
		{
			foreach(CommandParam param in viewedParams)
				addParam(param);
		}

		private void addParam(CommandParam param) 
		{
			listParams.Items.Add(param);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			FormInputParamView inputParameterView = new FormInputParamView();

			if(inputParameterView.ShowDialog(this) == DialogResult.OK)
				addParam(inputParameterView.viewedParam);
		
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(listParams.SelectedIndex != -1) 
				listParams.Items.Remove(listParams.Items[listParams.SelectedIndex]);
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			editParam();
		}

		private void editParam() 
		{
			FormInputParamView inputParameterView;


			if(listParams.SelectedIndex != -1) 
			{
				inputParameterView = new FormInputParamView();
				inputParameterView.viewedParam = (CommandParam)listParams.Items[listParams.SelectedIndex];
				if(inputParameterView.ShowDialog(this) == DialogResult.OK)
					refreshSelectedParamLabel();
			}
		}

		private void refreshSelectedParamLabel() 
		{
			listParams.Items[listParams.SelectedIndex] = listParams.SelectedItem;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			saveParamsList();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void saveParamsList() 
		{
			viewedParams.Clear();
			foreach(CommandParam param in listParams.Items)
				viewedParams.Add(param);
		}

		private void listParams_DoubleClick(object sender, System.EventArgs e)
		{
			editParam();
		}

	}
}
