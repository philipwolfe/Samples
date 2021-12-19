'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML
    
public class XmlDocumentSample

    private const m_Document as String = "books.xml"

    public shared sub Main()
        Dim xmldocument as XmlDocumentSample= new XmlDocumentSample()
    end sub

    public sub new ()
        mybase.new
        try                
            ' Load the XML from file
            Console.WriteLine ()
            Console.WriteLine ("Loading file {0} ...", m_Document)

            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (m_Document)

            Console.WriteLine ("XmlDocument loaded with XML data successfully ...")

            ' Get a DataNavigator from the XmlDocument
            Console.WriteLine ("Create a Navigator ...")
            Dim navigator as DocumentNavigator = new DocumentNavigator(xmldocument)

            ' Display contents
            Console.WriteLine ("Display contents of the file {0}", m_Document)
            Console.WriteLine ()

            navigator.MoveToDocument() ' Initialise the Navigator to start at the root
            DisplayTree(navigator) ' Display all the nodes
            
            'Find the price of the first book. Start at the root node
            Console.WriteLine ()
            Console.WriteLine ("Find the price of the first book by navigating nodes ...")
            navigator.MoveToDocument()
            DisplayNode (true, navigator) ' root node
            DisplayNode (navigator.MoveToFirstChild(), navigator) ' ?xml version='1.0'? node
            DisplayNode (navigator.MoveToNext(), navigator) '!-- This file ... node
            DisplayNode (navigator.MoveToNext(), navigator) ' bookstore element
            DisplayNode (navigator.MoveToFirstChild(), navigator) ' book element
            DisplayNode (navigator.MoveToFirstChild(), navigator) ' title element
            DisplayNode (navigator.MoveToNext(), navigator)' author element
            DisplayNode (navigator.MoveToNext(), navigator) ' price Element
            DisplayNode (navigator.MoveToFirstChild(), navigator) ' value of price element

            ' Select the book titles
            Console.WriteLine ()
            Console.WriteLine("Select the book titles ...")
            navigator.MoveToDocument()
            navigator.Select ("descendant::book/title")

            while navigator.MoveToNextSelected()
                Console.WriteLine("<" & navigator.Name & ">" & navigator.InnerText)
            end While
         
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub
        
    ' Walks the XmlNavigator tree recursively 
    public sub DisplayTree (navigator as XmlNavigator )
    
        if (navigator.HasChildren)
            navigator.MoveToChild(0)
            Format (navigator)
            DisplayTree (navigator) 
            navigator.MoveToParent()
        end if
        
        while (navigator.MoveToNext())        
            Format (navigator)
            DisplayTree (navigator)     
        end while
    end sub

    ' Format the output
    private sub Format (navigator as XmlNavigator )
        if Not (navigator.HasChildren)
            Console.WriteLine("<" & navigator.Name & ">" & navigator.Value)
        else
            Console.Write("<" & navigator.Name & ">")

            if (navigator.HasAttributes)
                Console.WriteLine ()
                Console.Write("Attributes of <" & navigator.Name & ">")
                Console.WriteLine ()
            end if
    
            dim i as Integer
            for i = 0 to navigator.AttributeCount-1
                navigator.PushPosition()
                navigator.MoveToAttribute(i)
                Console.Write("<" & navigator.Name & "> " & navigator.Value & " ")
                navigator.PopPosition()
            Next
            Console.WriteLine()
        end if
    end sub

    private sub DisplayNode(success as Boolean, navigator as XmlNavigator )
    
        if (success and (navigator.NodeType = XmlNodeType.Text))
            Console.WriteLine("<" & navigator.Name & ">" & navigator.Value)
        else if (success)
            Console.WriteLine("<" & navigator.Name & ">")
        else
            Console.WriteLine()
        end if    
    end sub    

end Class
end Namespace