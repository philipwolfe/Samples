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
        try
        {
            // Load the XML from file
            Console.WriteLine ();
            Console.WriteLine ("Loading file {0} ...", m_Document);

            XmlDataDocument xmldocument = new XmlDataDocument();
            xmldocument.Load (m_Document);

            Console.WriteLine ("XmlDataDocument loaded with XML data successfully ...");
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
