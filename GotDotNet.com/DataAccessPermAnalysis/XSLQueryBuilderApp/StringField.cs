using System;

namespace XSLQueryBuilderApp
{
	public class StringField : Field
	{
		public StringField():this("","",""){}
		public StringField(string iLabel,string iFieldName,string iTableName):
			base(iLabel,iFieldName,iTableName){}

		public override void accept(IFieldVisitor visitor) 
		{
			visitor.visit(this);
		}	
	}
}
