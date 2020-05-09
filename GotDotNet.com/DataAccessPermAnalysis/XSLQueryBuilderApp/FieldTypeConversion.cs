using System;

namespace XSLQueryBuilderApp
{
	public class FieldTypeConversion:IFieldVisitor
	{
		public bool getMode;
		public XSLTextWriter output;
		public string tableLabel;
		public string fieldValuePath;

		public FieldTypeConversion() 
		{
			getMode = false;
		}

		public void visit(UnTypedField field) 
		{
			visitSimpleField(field);
		}

		private void visitSimpleField(IField field) 
		{
			if(getMode)
				writeSimpleTypeToStringConversion(field);
			else
				writeSimpleStringToTypeConversion();
		}

		private void writeSimpleTypeToStringConversion(IField field) 
		{
			output.WriteString(tableLabel + "." + field.fieldName);
		}

		private void writeSimpleStringToTypeConversion() 
		{
			output.WriteValueOfElement(fieldValuePath);			
		}

		public void visit(StringField field) 
		{
			if(getMode)
				writeSimpleTypeToStringConversion(field);
			else
				writeStringToTypeConversion(field);
		}

		private void writeStringToTypeConversion(StringField field) 
		{
			output.WriteTextElement("'");
			output.WriteValueOfElement(fieldValuePath);
			output.WriteTextElement("'");
		}

		public void visit(DateField field) 
		{
			if(getMode)
				writeTypeToStringConversion(field);
			else
				writeStringToTypeConversion(field);
		}

		private void writeTypeToStringConversion(DateField field) 
		{
			output.WriteString("TO_CHAR(" + tableLabel + "." + field.fieldName + ",'" + field.datePattern + "')");

		}

		private void writeStringToTypeConversion(DateField field) 
		{
			output.WriteTextElement("TO_DATE('");
			output.WriteValueOfElement(fieldValuePath);
			output.WriteTextElement("','" + field.datePattern + "')");
		}

		public void visit(NumberField field) 
		{
			visitSimpleField(field);
		}
	}
}
