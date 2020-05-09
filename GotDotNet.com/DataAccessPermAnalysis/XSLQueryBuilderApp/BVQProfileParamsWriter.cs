using System;

namespace XSLQueryBuilderApp
{
	public class BVQProfileParamsWriter
	{

		public IProfileableTrack profileableTrack;
		public XSLTextWriter output;
		private FieldProfileTemplateAdvisor templateAdvisor;

		public BVQProfileParamsWriter()
		{
			templateAdvisor	= new FieldProfileTemplateAdvisor();
		}

		public void writeParamsSection() 
		{
			output.WriteStartForEachClause();
			output.WriteString("Request/Profile/*");
			output.WriteEndAttribute();
			output.WriteStartChooseElement();
			writeParams();
			output.WriteEndChooseElement();
			output.WriteEndForEachClause();
		}

		private void writeParams() 
		{
			foreach(IField field in profileableTrack.profileFields) 
			{
				output.WriteStartWhenClause();
				output.WriteString("self::" + field.label);
				output.WriteEndAttribute();
				output.WriteStartCallNameTemplateElement(templateAdvisor.getBVQParamTemplate(field));
				output.WriteStartWithParamElement("itemSeq");
				output.WriteValueOfElement("position()");
				output.WriteEndWithParamElement();
				output.WriteEndCallNameTemplateElement();
				output.WriteEndWhenClause();
			}
		}
	}
}
