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
            'Load the XML from file
            Console.WriteLine ()
            Console.WriteLine ("Loading file {0} ...", m_Document)

            Dim xmldocument as XmlDataDocument = new XmlDataDocument()
            xmldocument.Load (m_Document)

            Console.WriteLine ("XmlDataDocument loaded with XML data successfully ...")
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub
        
end Class
end Namespace
