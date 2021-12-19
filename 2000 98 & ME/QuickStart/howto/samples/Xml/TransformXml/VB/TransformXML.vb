'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Option strict off
 
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl

namespace HowTo.Samples.XML

public class XslTransformSample

    private const m_Stylesheet as string= "books.xsl"
    private const m_Document as string = "books.xml"

    public shared sub Main()
        Dim XslTransform as XslTransformSample = new XslTransformSample()
    end sub

    public sub new ()
        mybase.new

        Console.WriteLine()
        Console.WriteLine("Read XML data file, transform and format display ...")
        Console.WriteLine()

        ReadTransform()

        Console.WriteLine()
        Console.WriteLine("Read XML data file, transform and write ...")
        Console.WriteLine()

        ReadTransformWrite()
        Console.WriteLine()
    end sub

    public sub ReadTransform()
    
        try        
            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (m_Document)
            dim navigator as DocumentNavigator = new DocumentNavigator(xmldocument)

            dim xsltransform as XslTransform = new XslTransform()
            xsltransform.Load(m_Stylesheet)
            dim reader as XmlReader = xsltransform.Transform(navigator, nothing)

            FormatXml(reader)
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub

    public sub ReadTransformWrite()
    
        dim stream as StreamReader = nothing

        try        
            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (m_Document)
            dim navigator as DocumentNavigator = new DocumentNavigator(xmldocument)

            dim xsltransform as XslTransform = new XslTransform()
            dim writer as XmlTextWriter = new XmlTextWriter("transform.xml", nothing)

            xsltransform.Load(m_Stylesheet)
            xsltransform.Transform(navigator, nothing, writer)

			writer.Close()

            stream = new StreamReader ("transform.xml")
            Console.Write(stream.ReadToend())

        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())

        finally
            if not (stream = nothing)
                stream.Close()        
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
                dim flag as Boolean = false
                'Do not display whitespace text nodes
                dim i as Integer
                dim array as char() = reader.Value.ToCharArray()
                for i = 0 to reader.Value.Length - 1
                    if not (System.Char.IsWhiteSpace(array(i)))
                        flag = true
                    end if
                Next
                if(flag)
                    Format (reader, "Text")
                end if

            end Select
            
        end While    
    end sub

    private sub Format(byref reader as XmlReader, NodeType as String)
    
        ' Format the output
        Dim i as Integer
        for i = 0 to reader.Depth
            Console.Write(Strings.chr(9))
        Next
        
        Console.Write(reader.Prefix & NodeType & "<" & reader.Name & ">" & reader.Value)
        Console.WriteLine()

    end sub    

end Class
end Namespace
