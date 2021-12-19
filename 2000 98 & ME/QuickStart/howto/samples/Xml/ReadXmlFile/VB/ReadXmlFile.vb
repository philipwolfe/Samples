'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class ReadXmlFileSample 

    private const m_Document as String = "books.xml"

    public shared Sub Main()

        Dim reader as XmlTextReader = nothing

        try
            ' Load the file with a XmlTextReader
            Console.WriteLine ("Reading file books.xml ...")
            reader = new XmlTextReader (m_Document)
            Console.WriteLine ("File books.xml read sucessfully ...")

            ' Process the supplied XML file
            Console.WriteLine ("Processing ...")
            Console.WriteLine ()
            FormatXml(reader, m_Document)

        catch e as Exception 
        
            Console.WriteLine ("Failed to read the file 0", m_Document)
            Console.WriteLine ("Exception: {0}", e.ToString())           

        finally 
            Console.WriteLine()
            Console.WriteLine("Processing of the file {0} complete.", m_Document)
            ' Finished with XmlTextReader
            if not (reader = nothing)
                reader.Close()
            end if

        End try
    End Sub

    private shared Sub FormatXml (reader as XmlTextReader, filename as String)
    
        Dim Decl_count, PI_count, Doc_count, comment_count, element_count as Integer
        Dim attribute_count, text_count, whitespace_count as Integer

        While reader.Read()
        
            Select (reader.NodeType)
            
            case XmlNodeType.XmlDeclaration:
                Format (reader, "XmlDeclaration")
                Decl_count += 1

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
        Console.WriteLine("XmlDeclaration: " & Decl_count)
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
        
        Console.Write(NodeType & "<" & reader.Name & ">" & reader.Value)

        'Display the attributes values for the current node
        if (reader.HasAttributes)
            Console.Write(" Attributes:")
            Dim j as Integer
            for j = 0 to reader.AttributeCount - 1
                Console.Write(" [{0}] " & reader(j), j)
            next
        End if

        Console.WriteLine()

    End Sub    

End Class
End Namespace
