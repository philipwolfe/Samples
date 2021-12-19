'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class XmlXPathSample

    private const m_Document as String = "books.xml"

    public sub new ()
        mybase.new
        Console.WriteLine()
        Console.WriteLine("XPath Test started ...")
        Console.WriteLine()

        ' Create an XmlDocument
        dim xmldocument as XmlDocument = new XmlDocument()
        xmldocument.Load (m_Document)
        dim navigator as DocumentNavigator = new DocumentNavigator(xmldocument)

        ' Get all the book prices
        XPathQuery(navigator, "descendant::book/price")
        ' Get the ISBN of the last book
        XPathQuery(navigator, "//book[last()]/@ISBN/text()")
    end sub    
    
    public shared sub Main()
        Dim xmltransform as XmlXPathSample= new XmlXPathSample()
    end sub   

    private sub XPathQuery(navigator as XmlNavigator, xpathexpr as String )
    
        try
            ' Save context node position
            navigator.PushPosition()
            Console.WriteLine("XPath query: " & xpathexpr)

            navigator.Select (xpathexpr)

            FormatXml(navigator)

            ' Restore context node position
            navigator.PopPosition()        
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub    
    
    private sub FormatXml (navigator as XmlNavigator)
    
        while (navigator.MoveToNextSelected())
        
            Select (navigator.NodeType)
            
            case XmlNodeType.ProcessingInstruction:
                Format (navigator, "ProcessingInstruction")

            case XmlNodeType.DocumentType:
                Format (navigator, "DocumentType")

            case XmlNodeType.Document:
                Format (navigator, "Document")

            case XmlNodeType.Comment:
                Format (navigator, "Comment")

            case XmlNodeType.Element:
                Format (navigator, "Element")

            case XmlNodeType.Text:
                Format (navigator, "Text")

            case XmlNodeType.Whitespace:
                Format (navigator, "Whitespace")
                    
            end Select
        end While    
        Console.WriteLine()
    end sub
    

    ' Format the output
    private sub Format (navigator as XmlNavigator, NodeType as String)
    
        dim value as String
        dim name as String
        if (navigator.HasChildren)
        
            name = navigator.Name
            navigator.MoveToFirstChild()
            if (navigator.HasValue)
                value = navigator.Value
            end if
        
        else if (navigator.HasValue)
                value = navigator.Value
                name = navigator.Name
        end if
        
        Console.WriteLine(NodeType & "<" & name & ">" & value)
    end sub    

end Class
end Namespace
