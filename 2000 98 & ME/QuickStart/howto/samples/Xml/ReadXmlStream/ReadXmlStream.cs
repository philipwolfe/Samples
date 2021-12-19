/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class ReadXmlStreamSample 
{
    public static void Main()
    {
        StringReader stream;
    XmlTextReader reader = null;

        try
        {
            Console.WriteLine ("Initializing StringReader ...");

            stream = new StringReader("<?xml version='1.0'?>" +
                                      "<!-- This file represents a fragment of a book store inventory database -->" +
                                      "<bookstore>" +
                                      " <book genre=\"autobiography\" publicationdate=\"1981\" ISBN=\"1-861003-11-0\">" +
                                      "   <title>The Autobiography of Benjamin Franklin</title>" +
                                      "   <author>" +
                                      "       <first-name>Benjamin</first-name>" +
                                      "       <last-name>Franklin</last-name>" +
                                      "   </author>" +
                                      "   <price>8.99</price>" +
                                      " </book>" +
                                      " <book genre=\"novel\" publicationdate=\"1967\" ISBN=\"0-201-63361-2\">" +
                                      "   <title>The Confidence Man</title>" +
                                      "   <author>" +
                                      "       <first-name>Herman</first-name>" +
                                      "       <last-name>Melville</last-name>" +
                                      "   </author>" +
                                      "   <price>11.99</price>" +
                                      " </book>" +
                                      "  <book genre=\"philosophy\" publicationdate=\"1991\" ISBN=\"1-861001-57-6\">" +
                                      "   <title>The Gorgias</title>" +
                                      "   <author>" +
                                      "       <name>Plato</name>" +
                                      "   </author>" +
                                      "   <price>9.99</price>" +
                                      " </book>" +
                                      "</bookstore>");

            // Load the XmlTextReader from the stream
            reader = new XmlTextReader (stream);

            Console.WriteLine ("Processing ...");
            Console.WriteLine ();
            FormatXml(reader);
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }        

        finally 
        {
            Console.WriteLine();
            Console.WriteLine("Processing of stream complete.");
            // Finished with XmlTextReader
            if (reader != null)
                reader.Close();
        }
    }

private static void FormatXml (XmlReader reader)
{
    int PI_count=0, Doc_count=0, comment_count=0, element_count=0, attribute_count=0, text_count=0, whitespace_count=0;

    while (reader.Read())
    {
            switch (reader.NodeType)
            {
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
                while(reader.MoveToNextAttribute())
                {
                    Format (reader, "Attribute");
                }
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

        // Display the Statistics 
        Console.WriteLine ();
        Console.WriteLine("Statistics for stream");
        Console.WriteLine ();
        Console.WriteLine("ProcessingInstruction: {0}",PI_count++);
        Console.WriteLine("DocumentType: {0}",Doc_count++);
        Console.WriteLine("Comment: {0}",comment_count++);
        Console.WriteLine("Element: {0}",element_count++);
        Console.WriteLine("Attribute: {0}",attribute_count++);
        Console.WriteLine("Text: {0}",text_count++);
        Console.WriteLine("Whitespace: {0}",whitespace_count++);
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

} // End class ReadXmlStreamSample
} // End namespace HowTo.Samples.XML
