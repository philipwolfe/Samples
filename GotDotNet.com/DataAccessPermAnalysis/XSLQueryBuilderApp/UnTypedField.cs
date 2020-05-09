using System;

namespace XSLQueryBuilderApp
{
	public class UnTypedField : Field
	{
		public UnTypedField():this("","",""){}
		public UnTypedField(string iLabel,string iFieldName,string iTableName):
			base(iLabel,iFieldName,iTableName){}

		public override void accept(IFieldVisitor visitor) 
		{
			visitor.visit(this);
		}
	}
}
