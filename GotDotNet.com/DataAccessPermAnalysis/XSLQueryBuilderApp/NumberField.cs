using System;

namespace XSLQueryBuilderApp
{
	public class NumberField : Field
	{
		public bool ordinal;

		public NumberField():this("","",""){}
		public NumberField(string iLabel,string iFieldName,string iTableName):
			base(iLabel,iFieldName,iTableName){
				ordinal = false;
			}

		public override void accept(IFieldVisitor visitor) 
		{
			visitor.visit(this);
		}	
	}
}
