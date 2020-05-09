using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class FieldDBTypeTranslator
	{
		public static string getFieldTypeNameFromDBType(string dbType) 
		{
			string fieldType;

			switch (dbType) 
			{
				case "VARCHAR2":
					fieldType = "StringField";
					break;
				case "DATE":
					fieldType = "DateField";
					break;
				case "NUMBER":
					fieldType = "NumberField";
					break;
				default:
					fieldType = "UnTypedField";
					break;
			}

			return fieldType;
		}
	}
}
