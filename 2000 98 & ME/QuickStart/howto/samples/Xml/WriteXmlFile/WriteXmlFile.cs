/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class WriteXmlFileSample 
{
    private const string m_Document = "newbooks.xml";

    public static void Main()
    {
        XmlTextWriter writer = null;
        XmlTextReader reader = null;

        try
        {
            writer = new XmlTextWriter (m_Document, null);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(false);
            writer.WriteDocType("bookstore", null, "books.dtd", null);
            writer.WriteComment("This file represents another fragment of a book store inventory database");
            writer.WriteStartElement("bookstore");
                writer.WriteStartElement("book", null);
                    writer.WriteAttribute("genre","autobiography");
                    writer.WriteAttribute("publicationdate","1979");
                    writer.WriteAttribute("ISBN","0-7356-0562-9");
                    writer.WriteElementString("title", null, "The Autobiography of Mark Twain");
                    writer.WriteStartElement("Author", null);
                        writer.WriteElementString("first-name", "Mark");
                        writer.WriteElementString("last-name", "Twain");
                    writer.WriteEndElement();
                    writer.WriteElementString("price", "7.99");
                writer.WriteEndElement();
            writer.WriteEndElement();

            //Write the XML to file and close the writer
            writer.Flush();
            writer.Close();

            // Read the file back in and parse to ensure well formed XML
            reader = new XmlTextReader (m_Document);
            FormatXml (reader, m_Document);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }        

        finally 
        {
            Console.WriteLine();
            Console.WriteLine("Processing of the file {0} complete.", m_Document);
            if (reader != null)
                reader.Close();
            //Close the writer
            if (writer != null)
                writer.Close();
        }
    }

    private static void FormatXml (XmlTextReader reader, String filename)
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
                break;
            case XmlNodeType.Text:
                Format (reader, "Text");
                text_count++;
                break;
            case XmlNodeType.Whitespace:
                whitespace_count++;
                break;
            }
            if (reader.AttributeCount > 0)
                attribute_count+=reader.AttributeCount;
        }

        // Display the Statistics for the file 
        Console.WriteLine ();
        Console.WriteLine("Statistics for {0} file", filename);
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
        for (int i=0; i < reader.Depth; i++)
        { 
            Console.Write('\t');
        }

        Console.Write(NodeType + "<" + reader.Name + ">" + reader.Value);
        Console.WriteLine();
    }
} // End class WriteXmlFileSample
} // End namespace HowTo.Samples.XML
