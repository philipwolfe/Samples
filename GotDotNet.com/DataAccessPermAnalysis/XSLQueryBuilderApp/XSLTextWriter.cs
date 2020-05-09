using System;
using System.Xml;

namespace XSLQueryBuilderApp
{
	public class XSLTextWriter:XmlTextWriter
	{

		private const string XSL_URN = "http://www.w3.org/1999/XSL/Transform";
		
		public XSLTextWriter(string filename,System.Text.Encoding encoding):
			base(filename,encoding){}

		public void WriteStartStylesheetElement() 
		{
			WriteStartElement("xsl","stylesheet",XSL_URN);
			WriteAttributeString("xmlns","xsl",null,XSL_URN);
			WriteAttributeString("","version",null,"1.0");
		}

		public void WriteEndStylesheetElement() {
			WriteEndElement();
		}

		public void WriteOutputOmitXMLElement() 
		{
			WriteStartElement("xsl","output",null);
			WriteAttributeString("","method",null,"text");
			WriteAttributeString("","omit-xml-declaration",null,"yes");
			WriteEndElement();
		}

		public void WriteStartMatchTemplate(string match) 
		{
			WriteStartElement("xsl","template",null);
			WriteAttributeString("","match",null,match);
		}

		public void WriteEndMatchTemplate() 
		{
			WriteEndElement();
		}

		public void WriteTextElement(string text) 
		{
			WriteStartTextElement();
			WriteString(text);
			WriteEndTextElement();
		}

		public void WriteStartTextElement() 
		{
			WriteStartElement("xsl","text",null);
		}

		public void WriteEndTextElement() 
		{
			WriteEndElement();
		}

		public void WriteStartIfClause() 
		{
			WriteStartElement("xsl","if",null);
			WriteStartAttribute("test","");
		}

		public void WriteEndIfClause() 
		{
			WriteEndElement();
		}

		public void WriteStartForEachClause() 
		{
			WriteStartElement("xsl","for-each",null);
			WriteStartAttribute("select","");
		}

		public void WriteEndForEachClause() 
		{
			WriteEndElement();
		}

		public void WriteStartChooseElement() 
		{
			WriteStartElement("xsl","choose",null);
		}

		public void WriteEndChooseElement() 
		{
			WriteEndElement();
		}

		public void WriteStartWhenClause() 
		{
			WriteStartElement("xsl","when",null);
			WriteStartAttribute("test","");
		}

		public void WriteEndWhenClause() 
		{
			WriteEndElement();
		}

		public void WriteStartOtherwiseElement() 
		{
			WriteStartElement("xsl","otherwise",null);
		}

		public void WriteEndOtherwiseElement() 
		{
			WriteEndElement();
		}

		public void WriteIncludeElement(string href) 
		{
			WriteStartElement("xsl","include",null);
			WriteAttributeString("href","",href);
			WriteEndElement();
		}

		public void WriteValueOfElement(string select) 
		{
			WriteStartElement("xsl","value-of",null);
			WriteAttributeString("select","",select);
			WriteEndElement();
		}

		public void WriteCallNameTemplate(string name) 
		{
			WriteStartCallNameTemplateElement(name);
			WriteEndCallNameTemplateElement();
		}

		public void WriteStartCallNameTemplateElement(string name) 
		{
			WriteStartElement("xsl","call-template",null);
			WriteAttributeString("name","",name);
		}

		public void WriteEndCallNameTemplateElement() 
		{
			WriteEndElement();
		}

		public void WriteStartWithParamElement(string name) 
		{
			WriteStartElement("xsl","with-param",null);
			WriteAttributeString("name","",name);
		}

		public void WriteEndWithParamElement() 
		{
			WriteEndElement();
		}

	}
}
