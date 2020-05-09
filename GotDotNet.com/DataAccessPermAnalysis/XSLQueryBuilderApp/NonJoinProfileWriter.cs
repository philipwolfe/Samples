using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class NonJoinProfileWriter
	{
		public IProfileableTrack profileableTrack;
		public XSLTextWriter output;
		public string mainTableLabel;
		private FieldProfileTemplateAdvisor templateAdvisor;

		public NonJoinProfileWriter()
		{
			templateAdvisor = new FieldProfileTemplateAdvisor();
		}

		public void writeProfile() 
		{
			writeConditionedWhere();
			writeFieldsProfile();
		}

		private void writeConditionedWhere() 
		{
			output.WriteStartIfClause();
			output.WriteString("Request/Profile");
			output.WriteEndAttribute();
			output.WriteString(" WHERE ");
			output.WriteEndIfClause();
		}

		private void writeFieldsProfile() 
		{
			output.WriteStartForEachClause();
			output.WriteString("Request/Profile/*");
			output.WriteEndAttribute();
			output.WriteStartIfClause();
			output.WriteString("position()!=1");
			output.WriteEndAttribute();
			output.WriteString(" AND ");
			output.WriteEndIfClause();
			output.WriteStartChooseElement();
			writeFields();
			output.WriteEndChooseElement();
			output.WriteEndForEachClause();
		}

		private void writeFields() 
		{
			foreach(IField field in profileableTrack.profileFields) 
				writeField(field);
		}

		private void writeField(IField field) 
		{
			output.WriteStartWhenClause();
			output.WriteString("self::" + field.label);
			output.WriteEndAttribute();
			if(field.fieldReference == null)
				writeMainTableField(field);
			else
				writeReferencedField(field);
			output.WriteEndWhenClause();
		}

		private void writeMainTableField(IField field) 
		{
			writeFieldWithValue(mainTableLabel,field);
		}

		private void writeFieldWithValue(string tableLabel,IField field) 
		{
			output.WriteTextElement(tableLabel + "." + field.fieldName +"\n");
			templateAdvisor.writeProfileTemplate(field,output,profileableTrack.bindProfile);
		}

		private void writeReferencedField(IField field) 
		{
			writeReferencedFieldExist(field);
		}

		private void writeReferencedFieldExist(IField field) 
		{
			ArrayList shortNames = new ArrayList();

			generateShortNamesForReferencingTables(shortNames,field);
			output.WriteStartTextElement();
			output.WriteString("EXISTS (SELECT 1 \n");
			output.WriteString("FROM \n");
			writeFromTableSeparated(shortNames,field);
			output.WriteString(" WHERE \n");
			writeJoins(shortNames,field);
			writeFieldWithValue((string)shortNames[0],field);
			output.WriteString(")");
			output.WriteEndTextElement();
		}

		private void generateShortNamesForReferencingTables(ArrayList shortNamesArray,IField field) 
		{
			IField referenceField = field;
			ShortNamesGenerator generator = ShortNamesGenerator.getGenerator();

			while(referenceField.fieldReference!=null) 
			{
				shortNamesArray.Add(generator.generateShortName(referenceField.tableName));
				referenceField = referenceField.fieldReference;
			}
		}

		private void writeFromTableSeparated(ArrayList shortNamesArray,IField field) 
		{
			IField referenceField = field;
			IEnumerator enumerator = shortNamesArray.GetEnumerator();

			enumerator.MoveNext();
			output.WriteString(field.tableName + " " + (string)enumerator.Current);
			referenceField = field.fieldReference;
			while(enumerator.MoveNext()) 
			{
				output.WriteString("," + referenceField.tableName + " " + (string)enumerator.Current);
				referenceField = referenceField.fieldReference;
			}
		}


		private void writeJoins(ArrayList shortNamesArray,IField field) 
		{
			IField Field = field;
			IField referenceField = field.fieldReference;
			int i;

			for(i=0;i<shortNamesArray.Count-1;++i) 
			{
				writeJoinString((string)shortNamesArray[i],
					field.connectionFieldName,
					(string)shortNamesArray[i+1],
					referenceField.fieldName);
				field = referenceField;
				referenceField = referenceField.fieldReference;
			}
		
			writeJoinString((string)shortNamesArray[shortNamesArray.Count - 1],
				field.connectionFieldName,
				mainTableLabel,
				referenceField.fieldName);
		}

		private void writeJoinString(string leftTableName,string leftFieldName,
			string rightTableName,string rightFieldName) 
		{
			output.WriteString(
				leftTableName +	"." + leftFieldName + " = " +
				rightTableName + "." + rightFieldName + " AND ");

		}
	}
}
