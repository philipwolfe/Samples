using System;

namespace XSLQueryBuilderApp
{
	public abstract class Field:IField
	{
		private string _label;
		private string _fieldName;
		private string _tableName;
		private bool _nullable;
		private IField _fieldReference;
		private string _connectionFieldName; 
		
		public Field():this("","",""){}

		public Field(string iLabel,string iFieldName,string iTableName)
		{
			_label = iLabel;
			_fieldName = iFieldName;
			_tableName = iTableName;
			_nullable = false;
			_fieldReference = null;
			_connectionFieldName = "";
		}

		public string label 
		{
			get
			{
				return _label;
			}
			set 
			{
				_label = value;
			}
		}
		public string fieldName 
		{
			get 
			{
				return _fieldName;
			}
			set 
			{
				_fieldName = value;
			}
		}
		public string tableName 
		{
			get 
			{
				return _tableName;
			}
			set 
			{
				_tableName = value;
			}
		}
		public bool nullable 
		{
			get 
			{
				return _nullable;
			}
			set
			{
				_nullable = value;
			}
		}
		public IField fieldReference 
		{
			get 
			{
				return _fieldReference;
			}
		}

		public string connectionFieldName 
		{
			get 
			{
				return _connectionFieldName;
			}
		}

		public void setFieldReference(IField iFieldReference,string iConnectionFieldName) 
		{
			_fieldReference = iFieldReference;
			_connectionFieldName = iConnectionFieldName;
		}

		public override string ToString() 
		{
			return label;
		}

		public abstract void accept(IFieldVisitor visitor);

	}
}
