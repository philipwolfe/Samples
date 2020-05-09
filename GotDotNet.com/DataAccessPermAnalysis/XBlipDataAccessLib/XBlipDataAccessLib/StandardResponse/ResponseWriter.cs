using System;
using System.Xml;
using System.IO;
using System.Text;

namespace XBLIP.StandardResponse
{
	/// <summary>
	/// a standard response writer. The class uses an XMLTextWriter to
	/// write a standard response string. when the response is done, use 
	/// <c>ToString()</c> to get the final response string
	/// <newPara>
	///	The following example shows how to use the class:
	///	<pre>
	///	
	///	ResponseWriter responseWriter = new ResponseWriter();
	///		
	///	// write response begin
	///	responseWriter.writeResponseStart("Employee","Retrieve");
	///
	///	// write item representing employee 1234
	///	responseWriter.writeItemBegin("1234");
	///	responseWriter.writeField("&lt;Name&gt;joe&lt;/Name&gt;");
	///	responseWriter.writeItemEnd();
	///		
	///	// write item representing employee 5678
	///	responseWriter.writeItemBegin("1234");
	///	responseWriter.writeField("&lt;Name&gt;john&lt;/Name&gt;");
	///	responseWriter.writeItemEnd();
	///		
	///	// end response
	///	responseWriter.writeResponseEnd();
	///		
	///	Console.Write("The result response : {0}",responseWriter.ToString());
	///		
	///	The result is the following xml:
	///		
	///	&lt;Response id="Employee" action="Retrieve"&gt;
	///			&lt;Item id="1234"&gt;
	///				&lt;Name&gt;joe&lt;/Name&gt;
	///			&lt;/Item&gt;
	///			&lt;Item id="5678"&gt;
	///				&lt;Name&gt;john&lt;/Name&gt;
	///			&lt;/Item&gt;
	///	&lt;/Response&gt;
	///	</pre>
	/// </newPara>
	/// </summary>
	public class ResponseWriter
	{
		/// <summary>
		/// a string builder on which the response is build
		/// </summary>
		StringBuilder stringBuilder;
		/// <summary>
		/// a stream proxy to stringBuilder
		/// </summary>
		StringWriter textWriter;
		/// <summary>
		/// an XML writer proxy to <c>textWriter</c>
		/// </summary>
		XmlTextWriter xmlWriter;

		/// <summary>
		/// constructor. creates the xml writing objects
		/// </summary>
		public ResponseWriter() 
		{
			stringBuilder = new StringBuilder();
			textWriter = new StringWriter(stringBuilder);

			xmlWriter = new XmlTextWriter(textWriter);
		}

		/// <summary>
		/// write a response start tag. Provide id and action attribute values
		/// </summary>
		/// <param name="strID">id attribute value</param>
		/// <param name="strAction">action attribute value</param>
		public void writeResponseStart(string strID, string strAction) 
		{
			xmlWriter.WriteStartElement("Response");
			xmlWriter.WriteStartAttribute("id","");
			xmlWriter.WriteString(strID);
			xmlWriter.WriteEndAttribute();
			xmlWriter.WriteStartAttribute("action","");
			xmlWriter.WriteString(strAction);
			xmlWriter.WriteEndAttribute();
		}

		/// <summary>
		/// write a repsonse end tag
		/// </summary>
		public void writeResponseEnd() 
		{
			xmlWriter.WriteEndElement();
		}

		/// <summary>
		/// write an item begin tag. Provide an item id
		/// </summary>
		/// <param name="strItemID">the item id attribute value</param>
		public void writeItemStart(string strItemID) 
		{
			xmlWriter.WriteStartElement("Item");
			xmlWriter.WriteStartAttribute("id","");
			xmlWriter.WriteString(strItemID);
			xmlWriter.WriteEndAttribute();
		}

		/// <summary>
		/// write an item end
		/// </summary>
		public void writeItemEnd() 
		{
			xmlWriter.WriteEndElement();
		}

		/// <summary>
		/// write a full item definition
		/// </summary>
		/// <param name="strItemDefinition">an XML string holding a complete
		/// "Item" tag</param>
		public void writeFullItem(string strItemDefinition) 
		{
			xmlWriter.WriteRaw(strItemDefinition);
		}

		/// <summary>
		/// write an item field definition
		/// </summary>
		/// <param name="strFieldDefinition">an XML string holding a complete
		/// definition of a field</param>
		public void writeField(string strFieldDefinition) 
		{
			xmlWriter.WriteRaw(strFieldDefinition);
		}

		/// <summary>
		/// return the builder string. Use this after ending the response writing, to
		/// get the result standard response
		/// </summary>
		/// <returns>a standard response</returns>
		public override string ToString()  
		{
			return stringBuilder.ToString();
		}
	}
}
