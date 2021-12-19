/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class XslTransformSample
{
    private const string m_Stylesheet = "books.xsl";
    private const string m_Document = "books.xml";

    public XslTransformSample()
    {
        Console.WriteLine();
        Console.WriteLine("Read XML data file, transform and format display ...");
        Console.WriteLine();

        ReadTransform();

        Console.WriteLine();
        Console.WriteLine("Read XML data file, transform and write ...");
        Console.WriteLine();

        ReadTransformWrite();
        Console.WriteLine();
    }

    public static void Main()
    {
        XslTransformSample xsltransform = new XslTransformSample();
    }

    public void ReadTransform()
    {
        try
        {
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load (m_Document);
            DocumentNavigator navigator = new DocumentNavigator(xmldocument);

            XslTransform   xsltransform = new XslTransform();
            xsltransform.Load(m_Stylesheet);
            XmlReader reader = xsltransform.Transform(navigator, null);

            FormatXml(reader);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    public void ReadTransformWrite()
    {
        StreamReader stream = null;

        try
        {
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load (m_Document);
            DocumentNavigator navigator = new DocumentNavigator(xmldocument);

            XslTransform xsltransform = new XslTransform();
            XmlTextWriter writer = new XmlTextWriter("transform.xml", null);

            xsltransform.Load(m_Stylesheet);
            xsltransform.Transform(navigator, null, writer);

			writer.Close();

            stream = new StreamReader ("transform.xml");
            Console.Write(stream.ReadToEnd());
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally
        {
            if (stream != null)
                stream.Close();
        }
    }

    private void FormatXml (XmlReader reader)
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
                Boolean flag = false;
                // Do not display whitespace text nodes
                for (int i=0; i < reader.Value.Length; i++)
                {
                    if (!System.Char.IsWhiteSpace(reader.Value[i]))
                        flag = true;
                }
                if(flag)
                    Format (reader, "Text");
                break;
            }
        }
    }

    // Format the output
    private static void Format(XmlReader reader, String NodeType)
    {
        // Format the output
        for (int i=0; i < reader.Depth; i++)
        { 
            Console.Write('\t');
        }

        Console.Write(NodeType + "<" + reader.Name + ">" + reader.Value);
        Console.WriteLine();
    }
} // End class XslTransformSample
} // End namespace HowTo.Samples.XML
