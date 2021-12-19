' Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.
Option Strict off

Imports System
Imports System.IO
Imports System.Data
Imports System.Xml

Namespace HowTo.Samples.XML.DataSet

public class DataSetMapXMLDataSample

    private const m_Document as String = "books.xml"

    public sub New()
    MyBase.New
        try
            Console.WriteLine("Creating an XmlDataDocument ...")
            Dim datadoc as new System.Xml.XmlDataDocument

            ' Infer the DataSet schema from the XML data and load the XML Data
            datadoc.DataSet.ReadXml(new StreamReader(m_Document))

            DisplayTables(datadoc.DataSet)

        catch e as Exception
                Console.WriteLine ("Exception: " & e.toString() )
        end try
    end sub

    Shared sub Main
        dim args as String()
        dim xmltransform as DataSetMapXMLDataSample
        xmltransform = new DataSetMapXMLDataSample()
    end sub

    ' Displays the contents of the DataSet tables
    private sub DisplayTables(ds as system.data.DataSet)
    ' Navigate Dataset
        Console.WriteLine("Content of Tables ...")

        Dim table
        Console.writeline()

            for each table in ds.Tables
                Console.WriteLine("TableName = " & table.TableName.ToString())
                Console.WriteLine ("---------")
                Console.WriteLine("Columns ...")

            Dim column as object

                for each column in table.Columns            
                    Console.Write("{0,-22}",column.ColumnName.ToString())
                next
        
                Console.WriteLine()
                Console.WriteLine("Number of rows = " & table.Rows.Count.ToString())
                Console.WriteLine("Rows ...")
            
            Dim row as Object
                for each row in table.Rows

            Dim value as Object
                    for each value in row.ItemArray                
                        Console.Write("{0,-22}",value.ToString())
                    next
                    Console.WriteLine()
                next
                Console.WriteLine()
            next
    end sub
end class
end namespace
