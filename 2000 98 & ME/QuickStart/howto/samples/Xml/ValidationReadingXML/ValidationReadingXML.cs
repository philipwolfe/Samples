/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class ValidationReadingXMLSample
{
    private const String m_Document1 = "booksDTD.xml";
    private const String m_Document2 = "booksDTDFail.xml";
    private const String m_Document3 = "booksSchema.xml";
    private const String m_Document4 = "booksSchemaFail.xml";

    private XmlTextReader m_reader = null;
    private Boolean m_success = true;

    public ValidationReadingXMLSample ()
    {
        try
        {
            // Validate the XML file with the DTD
            Console.WriteLine();
            Console.WriteLine("Validating XML file booksDTD.xml with DTD file books.dtd ...");
            m_reader = new XmlTextReader (m_Document1);
            Validate();

            // DTD Validation failure
            m_success = true;
            Console.WriteLine();
            Console.WriteLine("Validation XML file booksDTDFail.xml with DTD file books.dtd ...");
            m_reader = new XmlTextReader (m_Document2);
            m_reader.Validation = Validation.DTD;
            Validate();

            // Validate the XML file with the schema
            m_success = true;
            Console.WriteLine();
            Console.WriteLine("Validation XML file booksSchema.xml with schema file schema.xml ...");
            m_reader = new XmlTextReader (m_Document3);
            m_reader.Validation = Validation.Schema;
            Validate();

            // Schema Validaiton failure
            m_success = true;
            Console.WriteLine();
            Console.WriteLine("Validation XML file booksSchemaFail.xml with schema file schema.xml ...");
            m_reader = new XmlTextReader (m_Document4);
            m_reader.Validation = Validation.Schema;
            Validate();
        }

        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.ToString());
        }

        finally
        {
            // Finished with XmlTextReader
            if (m_reader != null)
                m_reader.Close();
        }
    }    

    public static void Main ()
    {
        ValidationReadingXMLSample validation = new ValidationReadingXMLSample();
    }

    private void Validate()
    {
        try
        {
            // Set the validation event handler
            m_reader.ValidationEventHandler += new ValidationEventHandler (this.ValidationEventHandle);

            // Read XML data
            while (m_reader.Read()){}
            Console.WriteLine ("Validation finished. Validation {0}", (m_success==true ? "successful" : "failed"));
        }
        catch (XmlException e)
        {
            Console.WriteLine ("XmlException: " + e.ToString());
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: " + e.ToString());
        }
    }

    public void ValidationEventHandle (object sender, ValidationEventArgs args)
    {
        m_success = false;

        Console.Write("\r\n\tValidation error: " + args.Message);

        if (m_reader.LineNumber > 0)
        {
            Console.WriteLine("Line: "+ m_reader.LineNumber + " Position: " + m_reader.LinePos);
        }
    }

}// End class ValidationReadingXMLSample
}// End of HowTo.Samples.XML

