using System;

namespace XSLQueryBuilderApp
{
	public class TableReference
	{
		public string fieldName;
		public string parentFieldName;
		public Table parent;

		public TableReference(
			string iFieldName,
			string iParentFieldName,
			Table iParent)
		{
			fieldName = iFieldName;
			parentFieldName = iParentFieldName;
			parent = iParent;
		}
	}
}
