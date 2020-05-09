using System;
using System.Xml;

namespace XSLQueryBuilderApp
{
	public abstract class RetrieveSubSectionWriter
	{
		protected RetrieveTrack track;
		private Table relationsTableRoot;
		protected XSLTextWriter output;

		protected abstract string  getSectionSelectClause();
		protected abstract bool isOfSection(IField aField);
		protected abstract void writeFieldDescription(Table tableOfField,IField fieldToWrite);

		public RetrieveSubSectionWriter(RetrieveTrack iTrack, Table iRelationsTableRoot,XSLTextWriter iOutput)
		{
			track = iTrack;
			relationsTableRoot = iRelationsTableRoot;
			output = iOutput;
		}

		public void writeSubSection() 
		{ 
			output.WriteStartForEachClause();
			output.WriteString(getSectionSelectClause());
			output.WriteEndAttribute();
			writeFieldsPreface();
			output.WriteStartChooseElement();
			writeSectionFields();
			output.WriteEndChooseElement();
			output.WriteEndForEachClause();
		}

		protected virtual void writeFieldsPreface() {}

		private void writeSectionFields() 
		{
			relationsTableRoot.enumSubTree(new TableMethod(writeSectionFieldsOfTable));
		}

		private void writeSectionFieldsOfTable(Table tableToWrite) 
		{
			foreach(IField fieldOfTable in tableToWrite.fields)
				if(isOfSection(fieldOfTable))
					writeSectionField(fieldOfTable,tableToWrite);
		}

		private void writeSectionField(IField fieldToWrite,Table tableOfField) 
		{
			output.WriteStartWhenClause();
			output.WriteString("self::" + fieldToWrite.label);
			output.WriteEndAttribute();
			writeFieldDescription(tableOfField,fieldToWrite);
			output.WriteEndWhenClause();
		}

	}
}
