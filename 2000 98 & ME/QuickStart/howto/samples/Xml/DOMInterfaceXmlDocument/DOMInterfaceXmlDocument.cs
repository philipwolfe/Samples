/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;
    
public class XmlDocumentSample
{
    private const String m_Document = "books.xml";

    public static void Main()
    {
        XmlDocumentSample xmldocument = new XmlDocumentSample();
    }

    public XmlDocumentSample()
    {
        XmlTextReader reader = null;

        try
        {
            // Load the XML from file
            Console.WriteLine ("Reading file {0} ...", m_Document);
            reader = new XmlTextReader (m_Document);
			reader.WhitespaceHandling = WhitespaceHandling.None;
            Console.WriteLine ("File {0} read sucessfully ...", m_Document);

            // Create an XmlDocument from the XmlTextReader
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load (reader);
            Console.WriteLine ("XmlDocument loaded with XML data successfully ...");

            // Process the supplied XML file
            Console.WriteLine ("Processing ...");
            Console.WriteLine ();

            // Start from the document Element
            DisplayTree(xmldocument.DocumentElement);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public void DisplayTree(XmlNode node)
    {       
        if (node != null)
            Format (node);

        if (node.HasChildNodes)
        {
            node = node.FirstChild;
            while (node != null)
            {
                DisplayTree(node);
                node = node.NextSibling;
            }
        }
    }

    // Format the output
    private void Format (XmlNode node)
    {
        if (!node.HasChildNodes)
        {
            Console.WriteLine("\t" + node.Name + "<" + node.Value + ">");
        }

        else
        {
            Console.Write(node.Name);
            if (XmlNodeType.Element == node.NodeType)
            {
                XmlNamedNodeMap map = node.Attributes;
                foreach (XmlNode attrnode in map)
                    Console.Write(" " + attrnode.Name + "<" + attrnode.Value + "> ");
            }
            Console.WriteLine();
        }
    }
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
