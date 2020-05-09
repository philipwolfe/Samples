using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormFieldsView.
	/// </summary>
	public class FormFieldsView : System.Windows.Forms.Form
	{
		public ArrayList fieldsList;
		public string fieldsMainTableName;
		public DataAccessProvider dataAccessProvider;
		public bool allowReferencingFields;
		private PDOUIPicker uiPicker;

		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListBox listFields;
		private System.Windows.Forms.Button btnProperties;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormFieldsView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			allowReferencingFields = false;
			uiPicker = new PDOUIPicker();
			uiPicker.parentWindow = this;
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
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.listFields = new System.Windows.Forms.ListBox();
			this.btnProperties = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(256, 64);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 10;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(256, 32);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(40, 272);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(112, 24);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(192, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// listFields
			// 
			this.listFields.Location = new System.Drawing.Point(40, 16);
			this.listFields.Name = "listFields";
			this.listFields.Size = new System.Drawing.Size(208, 238);
			this.listFields.TabIndex = 13;
			this.listFields.DoubleClick += new System.EventHandler(this.listFields_DoubleClick);
			// 
			// btnProperties
			// 
			this.btnProperties.Location = new System.Drawing.Point(256, 96);
			this.btnProperties.Name = "btnProperties";
			this.btnProperties.TabIndex = 14;
			this.btnProperties.Text = "Properties";
			this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
			// 
			// FormFieldsView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(344, 309);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnProperties,
																		  this.listFields,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.btnRemove,
																		  this.btnAdd});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormFieldsView";
			this.ShowInTaskbar = false;
			this.Text = "Fields View";
			this.Load += new System.EventHandler(this.FormFieldsView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(allowReferencingFields)
				addSingleTableFields();
			else
				addTableTreeFields();

		}

		private void addSingleTableFields() 
		{
			FormTableFieldSelection frmTableFieldSelection = new FormTableFieldSelection();

			frmTableFieldSelection.dataAccessProvider = dataAccessProvider;
			frmTableFieldSelection.tableName = fieldsMainTableName;
			if(frmTableFieldSelection.ShowDialog(this) == DialogResult.OK)
				addFieldItems(frmTableFieldSelection.resultFields);
		}

		private void addTableTreeFields() 
		{
			FormTreeFieldSelection frmFieldSelection = new FormTreeFieldSelection();

			frmFieldSelection.dataAccessProvider = dataAccessProvider;
			frmFieldSelection.fieldsMainTableName = fieldsMainTableName;
			if(frmFieldSelection.ShowDialog(this) == DialogResult.OK)  
				addFieldItems(frmFieldSelection.resultFields);
		}

		private void addFieldItems(ArrayList fieldsList) 
		{
			foreach(IField field in fieldsList)
				listFields.Items.Add(field);
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(listFields.SelectedIndex != -1) 
				listFields.Items.Remove(listFields.Items[listFields.SelectedIndex]);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			saveFieldsList();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void saveFieldsList() 
		{
			fieldsList.Clear();
			foreach(IField field in listFields.Items)
				fieldsList.Add(field);
		}

		private void FormFieldsView_Load(object sender, System.EventArgs e)
		{
			addFieldItems(fieldsList);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnProperties_Click(object sender, System.EventArgs e)
		{
			editFieldProperties();
		}

		private void editFieldProperties() 
		{
			IField field;

			if(listFields.SelectedIndex != -1) 
			{
				field = (IField)listFields.Items[listFields.SelectedIndex];
				field.accept(uiPicker);
				if(uiPicker.uiResult == DialogResult.OK) 
					refreshSelectedFieldLabel();
			}
		}

		private void refreshSelectedFieldLabel() 
		{
			listFields.Items[listFields.SelectedIndex] = listFields.SelectedItem;
		}

		private void listFields_DoubleClick(object sender, System.EventArgs e)
		{
			editFieldProperties();
		}

	}
}
