'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class ValidationReadingXMLSample

    private const m_Document1 as String = "booksDTD.xml"
    private const m_Document2 as String = "booksDTDFail.xml"
    private const m_Document3 as String = "booksSchema.xml"
    private const m_Document4 as String = "booksSchemaFail.xml"

    private m_reader as XmlTextReader 
    private m_success as Boolean = true

    public sub new ()
        mybase.new

        try        
            ' Validate the XML file with the DTD
            Console.WriteLine()
            Console.WriteLine("Validating XML file booksDTD.xml with DTD file books.dtd ...")
            m_reader = new XmlTextReader (m_Document1)
            Validate()

            ' DTD Validation failure
            m_success = true
            Console.WriteLine()
            Console.WriteLine("Validation XML file booksDTDFail.xml with DTD file books.dtd ...")
            m_reader = new XmlTextReader (m_Document2)
            m_reader.Validation = System.Xml.Validation.DTD
            Validate()

            ' Validate the XML file with the schema
            m_success = true
            Console.WriteLine()
            Console.WriteLine("Validation XML file booksSchema.xml with schema file schema.xml ...")
            m_reader = new XmlTextReader (m_Document3)
            m_reader.Validation = System.Xml.Validation.Schema
            Validate()

            ' Schema Validaiton failure
            m_success = true
            Console.WriteLine()
            Console.WriteLine("Validation XML file booksSchemaFail.xml with schema file schema.xml ...")
            m_reader = new XmlTextReader (m_Document4)
            m_reader.Validation = System.Xml.Validation.Schema
            Validate()

        catch e as Exception
            Console.WriteLine ("Exception: {0}", e.ToString())

        finally
            ' Finished with XmlTextReader
            if not (m_reader = nothing)
                m_reader.Close()        
            end if

        end try
    end sub

    public shared sub Main ()
        Dim validation as ValidationReadingXMLSample = new ValidationReadingXMLSample()
    end sub
    
    private sub Validate()

        try        
            ' Set the validation event handler
            Dim valdel as ValidationEventHandler = new ValidationEventHandler(addressof ValidationEvent)
 
            AddHandler m_reader.ValidationEventHandler, valdel

            ' Read XML data
            while m_reader.Read()
            end While

            Dim s as String
            if (m_success = true)
                s = "successful"
            else
                s = "failed"
            end if
            Console.WriteLine ("Validation finished. Validation {0}", s)
        
        catch e as XmlException
            Console.WriteLine ("XmlException: {0} ", e.ToString())                        

        catch e as Exception
            Console.WriteLine ("Exception: {0} ", e.ToString())                        
        end try
    end sub        


    public sub ValidationEvent (errorid as object, args as ValidationEventArgs)

        m_success = false

        Console.Write(Strings.chr(9) & "Validation error: " & args.Message)

        if (m_reader.LineNumber > 0)        
            Console.WriteLine("Line: " & m_reader.LineNumber & " Position: " & m_reader.LinePos)
        end if
    end sub

end Class
end Namespace
