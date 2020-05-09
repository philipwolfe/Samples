using System;

namespace XSLQueryBuilderApp
{
	public class BVQEncapsulationWriter
	{
		public IProfileableTrack profileableTrack;
		public XSLTextWriter output;
		private BVQProfileParamsWriter paramsWriter;

		public BVQEncapsulationWriter()
		{
			paramsWriter =  new BVQProfileParamsWriter();
		}

		public void writeBVQHeader(string returnType) 
		{
			output.WriteStartTextElement();
			output.WriteString("DB_FUNC_START\n");
			output.WriteString("<Function type=\"text\">\n");
			if("" != returnType)
				output.WriteString("<Return type=\"" + returnType + "\" name=\"Return\"/>\n");
			output.WriteEndTextElement();
			paramsWriter.output = output;
			paramsWriter.profileableTrack = profileableTrack;
			paramsWriter.writeParamsSection();
			output.WriteTextElement("<Text><![CDATA[\n");
		}

		public void writeBVQFooter() 
		{
			output.WriteStartTextElement();
			output.WriteString("]]></Text>\n");
			output.WriteString("</Function>\n");
			output.WriteString("DB_FUNC_END\n");
			output.WriteEndTextElement();
		}
	}
}
