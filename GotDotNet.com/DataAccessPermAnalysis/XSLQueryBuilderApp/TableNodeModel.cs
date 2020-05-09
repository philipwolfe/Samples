using System;
using System.Collections;
using System.Data.OleDb;

namespace XSLQueryBuilderApp
{

	public class TableNodeModel : TreeNodeModel
	{
		public string tableName;
		public FieldNodeModel referencedField;
		public DataAccessProvider dataAccessProvider;
		private FieldDBTypeTranslator fieldTypeTranslator;

		private const string FIELDS_RETRIEVE_QUERY = 
			@"SELECT utc.column_name,urc.r_table,urc.r_column_name ,utc.data_type
			 FROM	user_tab_columns utc,
					(SELECT ucc.column_name column_name,
							ucc1.table_name r_table,
							ucc1.column_name r_column_name
					 FROM	user_constraints uc,
							user_cons_columns ucc,
							user_cons_columns ucc1
					 WHERE
							uc.table_name = ? 
					 AND uc.constraint_type = 'R'
					 AND ucc.constraint_name = uc.constraint_name
					 AND ucc1.constraint_name = uc.r_constraint_name) urc
			 WHERE utc.table_name = ?
			 AND urc.column_name (+) = utc.column_name";

		public TableNodeModel(
			string iTableName,
			FieldNodeModel iReferencedField,
			DataAccessProvider iDataAccessProvider)
		{
			tableName = iTableName;
			referencedField = iReferencedField;
			dataAccessProvider = iDataAccessProvider;
			fieldTypeTranslator = new FieldDBTypeTranslator();
		}

		public override string label 
		{
			get 
			{
				return tableName.Substring(0,1).ToUpper() + tableName.Substring(1).ToLower();
			}
		}

		private void loadFieldsFromDB(OleDbConnection connection) 
		{
			OleDbDataReader fieldsReader;
			string fieldName;
			
			clearFields();
			fieldsReader = getFieldsReader(connection);
			if(referencedField == null) 
				while(fieldsReader.Read())
					addChildField(fieldsReader);
			else 
				while(fieldsReader.Read()) 
				{
					fieldName = fieldsReader.GetString(0);
					if(fieldName != referencedField.fieldName) 
						addChildField(fieldsReader);
				}
		}

		private void addChildField(OleDbDataReader childRecordReader) 
		{
			FieldNodeModel tableField = new FieldNodeModel(
				childRecordReader.GetString(0),
				FieldDBTypeTranslator.getFieldTypeNameFromDBType(
					childRecordReader.GetString(3)),
				this,
				dataAccessProvider);
			if(!childRecordReader.IsDBNull(1))
				tableField.setReference(
					childRecordReader.GetString(1),	
					childRecordReader.GetString(2)
					);
			_childNodes.Add(tableField);
		}

		private void clearFields() 
		{
			foreach (FieldNodeModel field in _childNodes)  
				if(field.childNodes[0]!= null)
					((TableNodeModel)field.childNodes[0]).clearFields();
			_childNodes.Clear();
		}

		private OleDbDataReader getFieldsReader(OleDbConnection connection) 
		{
			OleDbCommand fieldsRetrieve = new OleDbCommand();
			OleDbParameter tableNameParam1 = new OleDbParameter("table_name1",OleDbType.VarChar);
			OleDbParameter tableNameParam2 = new OleDbParameter("table_name2",OleDbType.VarChar);
			
			fieldsRetrieve.Connection = connection;
			fieldsRetrieve.CommandText = FIELDS_RETRIEVE_QUERY;
			tableNameParam1.Value = tableName;
			tableNameParam2.Value = tableName;
			fieldsRetrieve.Parameters.Add(tableNameParam1);
			fieldsRetrieve.Parameters.Add(tableNameParam2);
			return fieldsRetrieve.ExecuteReader();
		}

		public override void onInitialExpose()
		{
			base.onInitialExpose();
			OleDbConnection aConnection = dataAccessProvider.getOpenConnection();

			loadFieldsFromDB(dataAccessProvider.getOpenConnection());
			aConnection.Close();
		}

		public override IField generateSelection() 
		{
			return null;
		}

		public override bool mayBeSelected
		{
			get 
			{
				return false;
			}
		}
	}
}
