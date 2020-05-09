using System;
using System.Collections;
using System.Data.OleDb;

namespace XSLQueryBuilderApp
{
	public class FieldNodeModel : TreeNodeModel
	{
		public DataAccessProvider dataAccessProvider;
		public string fieldName;
		public string dataType;
		private TableNodeModel _parent;
		private string _referencedFieldName;

		public FieldNodeModel(
				string iFieldName,
				string iDataType,
				TableNodeModel iParent,
				DataAccessProvider iDataAccessProvider)
		{
			fieldName = iFieldName;
			dataType = iDataType;
			_parent = iParent;
			dataAccessProvider = iDataAccessProvider;
			_referencedFieldName = "";
		}

		public TableNodeModel parent 
		{
			get 
			{
				return _parent;
			}
		}

		public override string label 
		{
			get 
			{
				return fieldName.Substring(0,1).ToUpper() + fieldName.Substring(1).ToLower();
			}
		}

		public string referencedFieldName
		{
			get 
			{
				return _referencedFieldName;
			}
		}

		public void setReference(string referencedTableName,string referencedFieldName) 
		{
			_childNodes.Add(new TableNodeModel(referencedTableName,this,dataAccessProvider));
			_referencedFieldName = referencedFieldName;
		}

		public override IField generateSelection() 
		{
			IField rootField = generateFieldFromModel(this);
			
			return rootField;
		}

		private IField generateFieldFromModel(FieldNodeModel fieldNodeModel) 
		{
			PDOClassFactory pdoClassFactory = PDOClassFactory.getClassFactory();
			IField generatedField = 
				pdoClassFactory.createField(fieldNodeModel.dataType);
			IField referencingField;

			generatedField.label = fieldNodeModel.fieldName;
			generatedField.fieldName = fieldNodeModel.fieldName;
			generatedField.tableName = fieldNodeModel.parent.tableName;

			if(fieldNodeModel.parent.referencedField != null) 
			{
				referencingField = generateFieldFromModel(fieldNodeModel.parent.referencedField);
				generatedField.setFieldReference(referencingField,
					fieldNodeModel.parent.referencedField.referencedFieldName);
			}
			return generatedField;
		}

		public override bool mayBeSelected
		{
			get 
			{
					return true;
			}
		}
	}
}
