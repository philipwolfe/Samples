' Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

imports System
imports System.IO
imports System.Xml
imports microsoft.visualbasic

namespace HowTo.Samples.XML

public class XmlDocumentSample

    private const  m_Document as String = "books.xml"

    public shared sub Main()
        dim xmldocument as XmlDocumentSample= new XmlDocumentSample()
    end sub

    public sub new()
    mybase.new()
    
        dim reader as XmlTextReader = nothing

        try
        
            ' Load the XML from file
            Console.WriteLine ("Reading file {0} ...", m_Document)
            reader = new XmlTextReader (m_Document)
			reader.WhitespaceHandling = WhitespaceHandling.None
            Console.WriteLine ("File {0} read sucessfully ...", m_Document)

            ' Create an XmlDocument from the XmlTextReader
            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (reader)
            Console.WriteLine ("XmlDocument loaded with XML data successfully ...")

            ' Process the supplied XML file
            Console.WriteLine ("Processing ...")
            Console.WriteLine ()

            ' Start from the document Element
            DisplayTree(xmldocument.DocumentElement)
        
        catch e as Exception
            Console.WriteLine ("Exception:" & e.ToString())

        finally
            if not (reader = nothing)
                reader.Close()
            end if

        end try
    end sub

    public sub DisplayTree( node as XmlNode)
    
        if not isnothing(node) then Format (node)

        if node.HasChildNodes then
            node = node.FirstChild
            while not isnothing(node)
                DisplayTree(node)
                node = node.NextSibling
            end While
        end if
    end sub

  ' Format the output
    private sub Format ( node as XmlNode)
    
        if not node.HasChildNodes then        
            Console.WriteLine( Strings.chr(9) & node.Name & "<" & node.Value & ">")
                    
        else        
            Console.Write(node.Name)
            if XmlNodeType.Element = node.NodeType then
                dim map as XmlNamedNodeMap = node.Attributes
                dim attrnode As Object
                    for each attrnode in map
                 Console.Write(" " & Ctype(attrnode,XmlNode).Name & "<" & Ctype(attrnode,XmlNode).Value & "> " )
                    next
            end if
            Console.WriteLine()
        end if
    end sub

end class 
end namespace 
