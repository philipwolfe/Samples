/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class XmlXPathSample
{
    private const String m_Document = "books.xml";

    public XmlXPathSample()
    {
        Console.WriteLine();
        Console.WriteLine("XPath Test started ...");
        Console.WriteLine();

        XmlDocument xmldocument = new XmlDocument();
        xmldocument.Load (m_Document);
        DocumentNavigator navigator = new DocumentNavigator(xmldocument);

        // Get all the book prices
        XPathQuery(navigator, "descendant::book/price");
        // Get the ISBN of the last book
        XPathQuery(navigator, "//book[last()]/@ISBN/text()");
    }

    public static void Main()
    {
        XmlXPathSample xmltransform = new XmlXPathSample();
    }

    private void XPathQuery(XmlNavigator navigator, String xpathexpr )
    {
        try
        {
            // Save context node position
            navigator.PushPosition();
            Console.WriteLine("XPath query: " + xpathexpr);

            navigator.Select (xpathexpr);

            FormatXml(navigator);

            // Restore context node position
            navigator.PopPosition();        
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }
    
    private void FormatXml (XmlNavigator navigator)
    {
        while (navigator.MoveToNextSelected())
        {
            switch (navigator.NodeType)
            {
            case XmlNodeType.ProcessingInstruction:
                Format (navigator, "ProcessingInstruction");
                break;
            case XmlNodeType.DocumentType:
                Format (navigator, "DocumentType");
                break;
            case XmlNodeType.Document:
                Format (navigator, "Document");
                break;
            case XmlNodeType.Comment:
                Format (navigator, "Comment");
                break;
            case XmlNodeType.Element:
                Format (navigator, "Element");
                break;
            case XmlNodeType.Text:
                Format (navigator, "Text");
                break;
            case XmlNodeType.Whitespace:
                Format (navigator, "Whitespace");
                break;
            }
        }
        Console.WriteLine();
    }

    // Format the output
    private void Format (XmlNavigator navigator, String NodeType)
    {
        String value = String.Empty;
        String name = String.Empty;

        if (navigator.HasChildren)
        {
            name = navigator.Name;
            navigator.MoveToFirstChild();
            if (navigator.HasValue)
            {
                value = navigator.Value;
            }
        }
        else
        {
            if (navigator.HasValue)
            {
                value = navigator.Value;
                name = navigator.Name;
            }
        }
        Console.WriteLine(NodeType + "<" + name + ">" + value);
    }
} // End class XmlXPathSample
} // End namespace HowTo.Samples.XML
