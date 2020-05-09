using System;
using System.Xml;
using System.Text;

namespace XSLQueryBuilderApp
{
	public class RetrieveDataSectionWriter:RetrieveSubSectionWriter
	{
		FieldTypeConversion typeConversion;		

		public RetrieveDataSectionWriter(RetrieveTrack iTrack, Table iRelationsTableRoot,XSLTextWriter iOutput):
			base(iTrack,iRelationsTableRoot,iOutput)
		{
			typeConversion= new FieldTypeConversion();
			typeConversion.getMode = true;
		}

		protected override string  getSectionSelectClause() 
		{
			return "Request/Data/*";
		}

		protected override bool isOfSection(IField aField) 
		{
			return track.dataFields.Contains(aField);
		}

		protected override void writeFieldDescription(Table tableOfField,IField fieldToWrite) 
		{
			output.WriteString(	"'<" + fieldToWrite.label + ">' || ");
			typeConversion.output = output;
			typeConversion.tableLabel = tableOfField.label;
			fieldToWrite.accept(typeConversion);			
			output.WriteString(	" || '</" + fieldToWrite.label + ">' || ");
		}

	}
}
