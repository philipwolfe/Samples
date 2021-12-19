'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML
    
public class XmlDocumentSample

    private const m_Document as String = "books.xml"
    private const m_UpdatedDocument as String = "updatebooks.xml"

    public shared sub Main()
        Dim xmldocument as XmlDocumentSample= new XmlDocumentSample()
    end sub

    public sub new ()
        mybase.new
        try                
            ' Make file writable
            dim file as File = new File(m_UpdatedDocument)
            file.Attributes = FileSystemAttributes.Normal

            ' Load the XML from file
            Console.WriteLine ()
            Console.WriteLine ("Loading file {0} ...", m_Document)

            ' Create an XmlDocument
            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (m_Document)

            Console.WriteLine ("XmlDocument loaded with XML data successfully ...")

            ' Get a DataNavigator from the XmlDocument
            Console.WriteLine ("Create a Navigator ...")
            Dim navigator as DocumentNavigator = new DocumentNavigator(xmldocument)

            ' Display contents
            Console.WriteLine ("Display contents of file {0}", m_Document)
            Console.WriteLine ()

            navigator.MoveToDocument() ' Initialise the Navigator to start at the root
            DisplayTree(navigator) ' Display all the nodes
            
            ' Increase all the book prices by 2%
            Console.WriteLine()
            Console.WriteLine("Increase all the book prices by 2% ...")
            navigator.PushPosition()

            navigator.Select ("descendant::book/price")

            while (navigator.MoveToNextSelected())
                navigator.MoveToFirstChild()
                dim price as Double = System.Double.Parse(navigator.Value)
                navigator.Value = System.Double.Format(price * 1.02, "#.00")
                navigator.MoveToParent()
            end while

            navigator.PopPosition()        
                        
            Console.WriteLine()
            Console.WriteLine("Adding a new book to the bookstore ...")
            ' Navigate to add a new book at the start of the bookstore
	        navigator.MoveToDocumentElement()

            ' Insert the new book
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"book","","")
            navigator.SetAttribute ("genre","Object-Orientated Technology")
            navigator.SetAttribute ("publicationdate","1994")
            navigator.SetAttribute ("ISBN","0-201-63361-2")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"title","","")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"title","","")
            navigator.Value = "Design Patterns - Elements of Reusable Object-Orientated Software"
            navigator.MoveToParent() 'author element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"author","","")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"first-name","","")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"first-name","","")
            navigator.Value = "Eric"
            navigator.MoveToParent() 'author element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"last-name","","")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"last-name","","")
            navigator.Value = "Gamma"
            navigator.MoveToParent() 'author element node
            navigator.MoveToParent() 'title element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"price","","")
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"price","","")
            navigator.Value = "49.95"

            ' Write out data as XML
            xmldocument.Save(m_UpdatedDocument)
            Console.WriteLine()
            Console.WriteLine("New book and updated prices saved in file {0}", m_UpdatedDocument)
            Console.WriteLine()

            ' Display updated contents
            Console.WriteLine ("Updated contents of file {0}", m_Document)
            Console.WriteLine ()

            navigator.MoveToDocument()
            DisplayTree(navigator)
        
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

end Class
end Namespace
