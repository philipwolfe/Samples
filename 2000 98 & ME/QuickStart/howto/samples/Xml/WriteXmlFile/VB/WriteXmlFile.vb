'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class WriteXmlFileSample 

    private const m_Document as string = "newbooks.xml"

    public shared Sub Main()
    
        dim reader as XmlTextReader = nothing
        dim writer as XmlTextWriter = nothing

        try        
            writer = new XmlTextWriter (m_Document, nothing)

            writer.Formatting = System.Xml.Formatting.Indented
            writer.WriteStartDocument(false)
            writer.WriteDocType("bookstore", nothing, "books.dtd", nothing)
            writer.WriteComment("This file represents another fragment of a book store inventory database")
            writer.WriteStartElement("bookstore")
                writer.WriteStartElement("book", nothing)
                    writer.WriteAttribute("genre","autobiography")
                    writer.WriteAttribute("publicationdate","1979")
                    writer.WriteAttribute("ISBN","0-7356-0562-9")
                    writer.WriteElementString("title", nothing, "The Autobiography of Mark Twain")
                    writer.WriteStartElement("Author", nothing)
                        writer.WriteElementString("first-name", "Mark")
                        writer.WriteElementString("last-name", "Twain")
                    writer.WriteEndElement()
                    writer.WriteElementString("price", "7.99")
                writer.WriteEndElement()
            writer.WriteEndElement()

            'Write the XML to file and close the writer
            writer.Flush()
            writer.Close()

            ' Read the file back in and parse to ensure well formed XML
            reader = new XmlTextReader (m_Document)
            FormatXml (reader, m_Document)
        
        catch e as Exception
            Console.WriteLine ("Exception: {0}", e.ToString())                

        finally 
            Console.WriteLine()
            Console.WriteLine("Processing of the file {0} complete.", m_Document)
    
            if not (reader = nothing)
                reader.Close()
            end if
    
            'Close the writer
            if not (reader = nothing)
                writer.Close()
            end if

        End try
    End Sub

    private shared Sub FormatXml (reader as XmlTextReader, filename as String)
    
        Dim PI_count, Doc_count, comment_count, element_count as Integer
        Dim attribute_count, text_count, whitespace_count as Integer

        While reader.Read()
        
            Select (reader.NodeType)
            
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction")
                PI_count += 1

            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType")
                Doc_count += 1

            case XmlNodeType.Comment:
                Format (reader, "Comment")
                comment_count += 1

            case XmlNodeType.Element:
                Format (reader, "Element")
                element_count += 1
                While reader.MoveToNextAttribute()                
                    Format (reader, "Attribute")
                end While

                if (reader.HasAttributes)
                    attribute_count += reader.AttributeCount
                end if

            case XmlNodeType.Text:
                Format (reader, "Text")
                text_count += 1 

            case XmlNodeType.Whitespace:
                whitespace_count += 1

            End Select
            
        End While    
            
        ' Display the Statistics for the file 
        Console.WriteLine ()
        Console.WriteLine("Statistics for {0} file", filename)
        Console.WriteLine ()
        Console.WriteLine("ProcessingInstruction: " & PI_count)
        Console.WriteLine("DocumentType: " & Doc_count)
        Console.WriteLine("Comment: " & comment_count)
        Console.WriteLine("Element: " & element_count)
        Console.WriteLine("Attribute: " & attribute_count)
        Console.WriteLine("Text: " & text_count)
        Console.WriteLine("Whitespace: " & whitespace_count)
    End Sub
    
    private shared Sub Format(byref reader as XmlTextReader , NodeType as String)
    
        ' Format the output
        Console.Write(reader.Depth & " ")
        Console.Write(reader.AttributeCount & " ")

        Dim i as Integer
        for i = 0 to reader.Depth
            Console.Write(Strings.chr(9))
        Next
        
        Console.Write(reader.Prefix & NodeType & "<" & reader.Name & ">" & reader.Value)
        Console.WriteLine()

    End Sub    

End Class
End Namespace
