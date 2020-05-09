using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public delegate void TableMethod(Table node);

	public class Table
	{
	
		public string label;
		public string name;
		public TableReference referenceToParent;

		private ArrayList _fields;
		private Hashtable _referencingTables;
		


		public Table(string iLabel,string iName)
		{
			label = iLabel;
			name = iName;
			referenceToParent = null;
			_fields = new ArrayList();
			_referencingTables = new Hashtable();
		}

		public ArrayList fields 
		{
			get 
			{
				return _fields;
			}
		}

		public Hashtable referencingTables 
		{
			get 
			{
				return _referencingTables;
			}
		}

		public void insertFieldToPath(IField newChild) 
		{
			Table tableOfPath = findTableOfFieldPath(newChild);

			tableOfPath.fields.Add(newChild);

		}

		private Table findTableOfFieldPath(IField fieldPath) 
		{
			Table  directParent;
			Table grandParent;
			string parentKey;

			if(null == fieldPath.fieldReference)
				directParent = this;
			else 
			{
				parentKey = fieldPath.tableName + ";" + fieldPath.fieldReference.fieldName;
				grandParent = findTableOfFieldPath(fieldPath.fieldReference);
				if(grandParent.referencingTables.ContainsKey(parentKey))
					directParent = (Table)grandParent.referencingTables[parentKey];
				else 
					directParent = addReferencingTable(
						grandParent,
						fieldPath.tableName,
						fieldPath.connectionFieldName,
						fieldPath.fieldReference.fieldName);
			}

			return directParent;
		}

		private Table addReferencingTable(Table parentOfReference,string tableName,string connectionFieldName,string fieldName) 
		{
			Table referencingTable = new Table(
				ShortNamesGenerator.getGenerator().generateShortName(tableName),
				tableName
			);

			referencingTable.referenceToParent = new TableReference(connectionFieldName,fieldName,this);
			parentOfReference.referencingTables.Add(tableName + ";" + fieldName,referencingTable);
			return referencingTable;
		}

		public void enumSubTree(TableMethod enumMethod) 
		{
			enumMethod(this);
			foreach(Table childTable in referencingTables.Values)
				childTable.enumSubTree(enumMethod);
		}

	}
}
