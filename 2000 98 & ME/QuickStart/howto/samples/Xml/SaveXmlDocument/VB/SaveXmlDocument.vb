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
            ' Create an XmlDocument
            dim xmldocument as XmlDocument = new XmlDocument()
            xmldocument.Load (m_Document)
            Console.WriteLine ("XmlDocument loaded with XML data successfully ...")
            Console.WriteLine()

            IncreasePrice(xmldocument.DocumentElement)

            ' Write out data as XML
            xmldocument.Save(m_UpdatedDocument)
            Console.WriteLine()
            Console.WriteLine("Updated prices saved in file {0}", m_UpdatedDocument)
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub    

    public sub IncreasePrice(node as XmlNode)
           
        if (node.Name = "price")
        
            node = node.FirstChild
            dim price as Decimal
            price = System.Decimal.Parse(node.Value)

            ' Increase all the book prices by 2%
            dim newprice as String
            newprice = System.Decimal.Format(price*(new Decimal(1.02)),"#.00")
            Console.WriteLine("Old Price = " & node.Value & Strings.chr(9) & "New price = " & newprice)
            node.Value = newprice
        end if
                
        node = node.FirstChild
        while not (node = nothing)            
            IncreasePrice(node)
            node = node.NextSibling
        end while            
    
    end sub    

end Class
end Namespace
