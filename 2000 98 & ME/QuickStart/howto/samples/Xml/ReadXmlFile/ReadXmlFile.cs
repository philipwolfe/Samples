/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class ReadXmlFileSample 
{
    private const string m_Document = "books.xml";

    public static void Main()
    {
        XmlTextReader reader = null;

        try
        {
            // Load the file with a XmlTextReader
            Console.WriteLine ("Reading file {0} ...", m_Document);
            reader = new XmlTextReader (m_Document);
            Console.WriteLine ("File {0} read sucessfully ...", m_Document);

            // Process the supplied XML file
            Console.WriteLine ("Processing ...");
            Console.WriteLine ();
            FormatXml(reader, m_Document);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Failed to read the file {0}", m_Document);
            Console.WriteLine ("Exception: {0}", e.ToString());
        }        

        finally 
        {
            Console.WriteLine();
            Console.WriteLine("Processing of the file {0} complete.", m_Document);
            // Finished with XmlTextReader
            if (reader != null)
                reader.Close();
        }
    }

    private static void FormatXml (XmlReader reader, String filename)
    {
        int Decl_count=0, PI_count=0, Doc_count=0, comment_count=0, element_count=0, attribute_count=0, text_count=0, whitespace_count=0;

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
            case XmlNodeType.XmlDeclaration:
                Format (reader, "XmlDeclaration");
                Decl_count++;
                break;
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction");
                PI_count++;
                break;
            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType");
                Doc_count++;
                break;
            case XmlNodeType.Comment:
                Format (reader, "Comment");
                comment_count++;
                break;
            case XmlNodeType.Element:
                Format (reader, "Element");
                element_count++;
                if (reader.HasAttributes)
                    attribute_count += reader.AttributeCount;
                break;
            case XmlNodeType.Text:
                Format (reader, "Text");
                text_count++;
                break;
            case XmlNodeType.Whitespace:
                whitespace_count++;
                break;
            }
        }

        // Display the Statistics for the file.
        Console.WriteLine ();
        Console.WriteLine("Statistics for {0} file", filename);
        Console.WriteLine ();
        Console.WriteLine("XmlDeclaration: {0}",Decl_count++);
        Console.WriteLine("ProcessingInstruction: {0}",PI_count++);
        Console.WriteLine("DocumentType: {0}",Doc_count++);
        Console.WriteLine("Comment: {0}",comment_count++);
        Console.WriteLine("Element: {0}",element_count++);
        Console.WriteLine("Attribute: {0}",attribute_count++);
        Console.WriteLine("Text: {0}",text_count++);
        Console.WriteLine("Whitespace: {0}",whitespace_count++);
    }

    private static void Format(XmlReader reader, String NodeType)
    {
        // Format the output
        Console.Write(reader.Depth + " ");
        Console.Write(reader.AttributeCount + " ");
        for (int i=0; i < reader.Depth; i++)
        { 
            Console.Write('\t');
        }

        Console.Write(reader.Prefix + NodeType + "<" + reader.Name + ">" + reader.Value);

        // Display the attributes values for the current node
        if (reader.HasAttributes)
        {
            Console.Write(" Attributes:");

            for (int j=0; j < reader.AttributeCount; j++)
            {
                Console.Write(" [{0}] " + reader[j], j);
            }
        }
        Console.WriteLine();
    }

} // End class ReadXmlFileSample
} // End namespace HowTo.Samples.XML