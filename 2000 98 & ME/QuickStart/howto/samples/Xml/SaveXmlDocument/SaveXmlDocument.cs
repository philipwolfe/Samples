/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;
    
public class XmlDocumentSample
{
    private const String m_Document = "books.xml";
    private const String m_UpdatedDocument = "updatebooks.xml";

    public static void Main()
    {
        XmlDocumentSample xmldocument = new XmlDocumentSample();
    }

    public XmlDocumentSample()
    {
        try
        {
            // Create XmlDocument and load the XML from file
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load (new XmlTextReader (m_Document));
            Console.WriteLine ("XmlDocument loaded with XML data successfully ...");
            Console.WriteLine();

            IncreasePrice(xmldocument.DocumentElement);

            // Write out data as XML
            xmldocument.Save(m_UpdatedDocument);
            Console.WriteLine();
            Console.WriteLine("Updated prices saved in file {0}", m_UpdatedDocument);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    public void IncreasePrice(XmlNode node)
    {       
        if (node.Name == "price")
        {
            node = node.FirstChild;
            Decimal price = Decimal.Parse(node.Value);
            // Increase all the book prices by 2%
            String newprice = Decimal.Format(price*(new Decimal(1.02)),"#.00");
            Console.WriteLine("Old Price = " + node.Value + "\tNew price = " + newprice);
            node.Value = newprice;
        }

        node = node.FirstChild;
        while (node != null)
        {
            IncreasePrice(node);
            node = node.NextSibling;
        }
    }
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
