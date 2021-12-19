'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl

namespace HowTo.Samples.XML

public class XmlDocumentSample

    private const m_Document as String = "books.xml"
    private const m_Stylesheet as String = "identity.xsl"

    public shared sub Main()
        Dim xmldocument as XmlDocumentSample= new XmlDocumentSample()
    end sub

    public sub new ()
        mybase.new

        dim docreader as XmlReader = nothing 
        try                        
            ' Load the XML from file
            Console.WriteLine ("Loading file {0} ...", m_Document)

            ' Create an XmlDocument
            dim xmldocument as XmlDataDocument = new XmlDataDocument()
            xmldocument.Load (m_Document)

            Console.WriteLine ("XmlDataDocument loaded with XML data successfully ...")

            'The use of an XslTransform is a work-around for getting an XmlReader from XmlDataDocument
            'until DataDocumentReader is implemented.
            'dim docreader as DataDocumentReader = DataDocumentReader(xmldocument)

            Console.WriteLine ("Reading XML ...")
            Console.WriteLine()

            dim xsltransform as XslTransform = new XslTransform()
            xsltransform.Load(m_Stylesheet)
            docreader = xsltransform.Transform(new DataDocumentNavigator(xmldocument), nothing)

            FormatXml (docreader)
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())

        finally
            ' Close the reader
            if not (docreader = nothing)
                docreader.Close() 
            end if

        end try
    end sub
        
    private sub FormatXml (reader as XmlReader)
    
        While reader.Read()
        
            Select (reader.NodeType)
            
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction")

            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType")

            case XmlNodeType.Comment:
                Format (reader, "Comment")

            case XmlNodeType.Element:
                Format (reader, "Element")
                While reader.MoveToNextAttribute()                
                    Format (reader, "Attribute")
                end While

            case XmlNodeType.Text:
                Format (reader, "Text")

            case XmlNodeType.Whitespace:
                Format (reader, "Whitespace")

            end Select
            
        end While    
    end sub

    private sub Format(byref reader as XmlReader, NodeType as String)
    
        ' Format the output
        Console.Write(reader.Depth & " ")
        Console.Write(reader.AttributeCount & " ")

        Dim i as Integer
        for i = 0 to reader.Depth
            Console.Write(Strings.chr(9))
        Next
        
        Console.Write(reader.Prefix & NodeType & "<" & reader.Name & ">" & reader.Value)
        Console.WriteLine()
    end sub    

end Class
end Namespace
