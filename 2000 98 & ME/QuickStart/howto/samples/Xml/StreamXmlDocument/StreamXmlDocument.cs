/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;    

public class XmlDocumentSample
{
    private const String m_Document = "books.xml";
    private const String m_Stylesheet = "identity.xsl";

    public static void Main()
    {
        XmlDocumentSample xmldocument = new XmlDocumentSample();
    }

    public XmlDocumentSample()
    {
        XmlReader docreader = null;

        try
        {
            // Load the XML from file
            Console.WriteLine ("Loading file {0} ...", m_Document);

            XmlDataDocument xmldocument = new XmlDataDocument();
            xmldocument.Load (m_Document);

            Console.WriteLine ("XmlDataDocument loaded with XML data successfully ...\r\n");

            // The use of an XslTransform is a work-around for getting an XmlReader from XmlDataDocument
            // until DataDocumentReader is implemented.
            // DataDocumentReader docreader = DataDocumentReader(xmldocument);

            Console.WriteLine ("Reading XML ...\r\n");

            XslTransform   xsltransform = new XslTransform();
            xsltransform.Load(m_Stylesheet);
            docreader = xsltransform.Transform(new DataDocumentNavigator(xmldocument), null);
            FormatXml (docreader);
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally
        {
            // Close the reader
            if (docreader != null)
                docreader.Close();
        }
    }

    private static void FormatXml (XmlReader reader)
    {
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction");
                break;
            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType");
                break;
            case XmlNodeType.Document:
                Format (reader, "Document");
                break;
            case XmlNodeType.Comment:
                Format (reader, "Comment");
                break;
            case XmlNodeType.Element:
                Format (reader, "Element");
				while(reader.MoveToNextAttribute())
                {
                    Format (reader, "Attribute");
				}
                break;
            case XmlNodeType.Text:
                Format (reader, "Text");
                break;
            case XmlNodeType.Whitespace:
                Format (reader, "Whitespace");
                break;
            }
        }
    }

    // Format the output
    private static void Format(XmlReader reader, String NodeType)
    {
        // Format the output
        Console.Write(reader.Depth + " ");
        Console.Write(reader.AttributeCount + " ");
        for (int i=0; i < reader.Depth; i++)
        { 
            Console.Write('\t');
        }

        Console.Write(NodeType + "<" + reader.Name + ">" + reader.Value);
        Console.WriteLine();
    }
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
