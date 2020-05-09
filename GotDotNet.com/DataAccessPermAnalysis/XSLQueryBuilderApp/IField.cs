using System;

namespace XSLQueryBuilderApp
{
	public interface IField
	{

		string label 
		{
			get;
			set;
		}
		string fieldName 
		{
			get;
			set;
		}
		string tableName 
		{
			get;
			set;
		}
		bool nullable 
		{
			get;
			set;
		}
		IField fieldReference 
		{
			get;
		}
		string connectionFieldName 
		{
			get;
		}
		void setFieldReference(IField iFieldReference,string iConnectionFieldName);
		string ToString();
		void accept(IFieldVisitor visitor);
	}
}
