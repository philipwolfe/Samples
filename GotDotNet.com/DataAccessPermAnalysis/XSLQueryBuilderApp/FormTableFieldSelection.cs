using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;

namespace XSLQueryBuilderApp
{
	public class FormTableFieldSelection : System.Windows.Forms.Form
	{
		public DataAccessProvider dataAccessProvider;
		public string tableName;
		private ArrayList fieldTypes;
		private ArrayList nullable;
		private ArrayList _resultFields;
		private const string FIELDS_RETRIEVE_QUERY = 
			@"SELECT utc.column_name,utc.data_type,utc.nullable
			 FROM	user_tab_columns utc
			 WHERE utc.table_name = ?";

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ListBox lstFields;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTableFieldSelection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_resultFields = new ArrayList();
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

		public ArrayList resultFields
		{
			get 
			{
				return _resultFields;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lstFields = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(180, 307);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Enabled = false;
			this.btnSelect.Location = new System.Drawing.Point(28, 307);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(80, 23);
			this.btnSelect.TabIndex = 4;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lstFields
			// 
			this.lstFields.Location = new System.Drawing.Point(20, 19);
			this.lstFields.Name = "lstFields";
			this.lstFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstFields.Size = new System.Drawing.Size(240, 277);
			this.lstFields.TabIndex = 3;
			this.lstFields.DoubleClick += new System.EventHandler(this.lstFields_DoubleClick);
			this.lstFields.SelectedIndexChanged += new System.EventHandler(this.lstFields_SelectedIndexChanged);
			// 
			// FormTableFieldSelection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnSelect,
																		  this.lstFields});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormTableFieldSelection";
			this.ShowInTaskbar = false;
			this.Text = "Select Fields";
			this.Load += new System.EventHandler(this.FormTableFieldSelection_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormTableFieldSelection_Load(object sender, System.EventArgs e)
		{
			loadFieldsToList();
		}

		private void loadFieldsToList() 
		{
			OleDbCommand fieldsRetrieve = new OleDbCommand();
			OleDbConnection connection = dataAccessProvider.getOpenConnection();
			OleDbDataReader fieldsListIterator;
			OleDbParameter tableNameParam = new OleDbParameter("tableName",OleDbType.VarChar);
		
			fieldsRetrieve.CommandText = FIELDS_RETRIEVE_QUERY;
			fieldsRetrieve.Connection = connection;
			tableNameParam.Value = tableName;
			fieldsRetrieve.Parameters.Add(tableNameParam);

			fieldsListIterator = fieldsRetrieve.ExecuteReader();
			fieldTypes = new ArrayList();
			nullable = new ArrayList();

			while(fieldsListIterator.Read()) 
			{
				lstFields.Items.Add(fieldsListIterator.GetString(0));			
				fieldTypes.Add(FieldDBTypeTranslator.getFieldTypeNameFromDBType(fieldsListIterator.GetString(1)));
				nullable.Add((fieldsListIterator.GetString(2) == "Y"));
			}
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}

		private void onSelectionMade() 
		{
			int i;

			for(i=0;i<lstFields.Items.Count;++i)
				if(lstFields.GetSelected(i)) 
					_resultFields.Add(createFieldFromIndex(i));
			DialogResult = DialogResult.OK;
			Close();
		}

		private IField createFieldFromIndex(int i) 
		{
			PDOClassFactory pdoClassFactory = PDOClassFactory.getClassFactory();
			string fieldName = lstFields.Items[i].ToString();
			string dataType = (string)fieldTypes[i];
			bool nullableValue = (bool)nullable[i];
			IField field;
			
			field = pdoClassFactory.createField(dataType);
			field.label = fieldName;
			field.fieldName = fieldName;
			field.tableName = tableName;
			field.nullable = nullableValue;

			return field;
		}

		private void lstFields_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnSelect.Enabled = (lstFields.SelectedIndex != -1);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{

			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void lstFields_DoubleClick(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}

	}
}
