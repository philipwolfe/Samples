using System;
using System.Xml;

namespace XSLQueryBuilderApp
{
	public class RetrieveProfileSectionWriter:RetrieveSubSectionWriter
	{
		private FieldProfileTemplateAdvisor templateAdvisor;

		public RetrieveProfileSectionWriter(RetrieveTrack iTrack, Table iRelationsTableRoot,XSLTextWriter iOutput):
			base(iTrack,iRelationsTableRoot,iOutput)
		{
			templateAdvisor = new FieldProfileTemplateAdvisor();
		}

		protected override string  getSectionSelectClause() 
		{
			return "Request/Profile/*";
		}

		protected override bool isOfSection(IField aField) 
		{
			return track.profileFields.Contains(aField);
		}

		protected override void writeFieldDescription(Table tableOfField,IField fieldToWrite) 
		{
			output.WriteTextElement(tableOfField.label + "." + fieldToWrite.fieldName + "\n");
			templateAdvisor.writeProfileTemplate(fieldToWrite,output,track.bindProfile);
		}
		
		protected override void writeFieldsPreface() 
		{
			output.WriteStartIfClause();
			output.WriteString("position()!=1");
			output.WriteEndAttribute();
			output.WriteString(" AND ");
			output.WriteEndIfClause();
		}
	}
}
