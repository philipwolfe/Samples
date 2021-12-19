' Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Option strict off

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data
Imports System.Xml

namespace HowTo.Samples.XML

public class LoadDataSetXMLDataSample

    private const m_Document as string = "books.xml"
    private const m_Schema as string = "books.xsd"
    private m_datadoc as XmlDataDocument 

    public sub New()        
    MyBase.new
        try
            Console.WriteLine("Creating an XmlDataDocument ...")
            m_datadoc = new XmlDataDocument()
            ParseSchema(m_Schema)
            DisplayTableStructure()

            m_datadoc.Load(m_Document)

            DisplayTables(m_datadoc.DataSet)
        
        catch e as exception
            Console.WriteLine ("Exception: " & e.ToString())
        end try
    end sub

    shared sub Main()
        Dim xmltransform = new LoadDataSetXMLDataSample()
    end sub

    ' Loads a specified schema into the DataSet
    public sub ParseSchema(schema as string)

        dim streamreader_schema as StreamReader = nothing
        try 
            streamreader_schema = new StreamReader(schema)
            Console.WriteLine("Reading Schema file ...")
            m_datadoc.DataSet.ReadXmlSchema(streamreader_schema)

        catch e as exception
            Console.WriteLine ("Exception: " & e.ToString())

        finally
            if not (streamreader_schema = nothing)
                streamreader_schema.Close()
            end if

        end try
    end sub

    ' Displays the DataSet tables structure
    private sub DisplayTableStructure()
    
        Console.WriteLine("Table structure ")
        Console.WriteLine()
        Console.WriteLine("Tables count=" & m_datadoc.DataSet.Tables.Count.ToString())
        dim i as Integer
        for i = 0 to (m_datadoc.DataSet.Tables.Count - 1)
        
            Console.WriteLine()
            Console.WriteLine("TableName='" & m_datadoc.DataSet.Tables(i).TableName + "'.")
            Console.WriteLine("Columns count=" & m_datadoc.DataSet.Tables(i).Columns.Count.ToString())

            Dim j As Integer
            for j = 0 to (m_datadoc.DataSet.Tables(i).Columns.Count - 1)            
                Console.WriteLine(Strings.chr(9) & "ColumnName='" & m_datadoc.DataSet.Tables(i).Columns(j).ColumnName.ToString() & "', type = " & m_datadoc.DataSet.Tables(i).Columns(j).DataType.ToString())
            Next
        Next
        
    end sub

    ' Displays the contents of the DataSet tables
    private sub DisplayTables(ds as DataSet)

        ' Navigate Dataset
        Console.WriteLine()
        Console.WriteLine("Content of Tables ...")

        dim table as object
        for each table in ds.Tables
        
            Console.WriteLine("TableName = " & table.TableName.ToString())
            Console.WriteLine ("---------")
            Console.WriteLine("Columns ...")

            dim column as object
            for each column in table.Columns
            
                Console.Write("{0,-22}",column.ColumnName.ToString())
            next
            Console.WriteLine()
            Console.WriteLine("Number of rows = {0}", table.Rows.Count.ToString())
            Console.WriteLine("Rows ...")

            dim row as object 
            for each row in table.Rows

            dim value as object            
                for each value in row.ItemArray
                    Console.Write("{0,-22}",value.ToString())
                Next
                Console.WriteLine()
            Next
            Console.WriteLine()
        Next
    end sub
end class 
End namespace 

