using System;

namespace XSLQueryBuilderApp
{
	public class DateField : XSLQueryBuilderApp.Field
	{
		public string datePattern;

		public const string DEFAULT_DATE_PATTERN = "dd/mm/yyyy";

		public DateField():this("","",""){}
		public DateField(string iLabel,string iFieldName,string iTableName):
		base(iLabel,iFieldName,iTableName){
			datePattern = DEFAULT_DATE_PATTERN;
		}

		public override void accept(IFieldVisitor visitor) 
		{
			visitor.visit(this);
		}	
	}
}
