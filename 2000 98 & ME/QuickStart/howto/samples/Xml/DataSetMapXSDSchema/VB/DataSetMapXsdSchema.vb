' Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class DataSetMapXSDSchemaSample

    private const m_Schema as String = "books.xsd"
    private m_datadoc as System.Data.DataSet

    public sub New()

    MyBase.New
    try
        m_datadoc = new System.Data.DataSet    
        Console.WriteLine("Creating an XmlDataDocument ...")
        ParseSchema(m_Schema)
        DisplayTableStructure()

        catch e as exception
            Console.WriteLine ("Exception: " & e.ToString())
        end try
    end sub

    shared sub Main()
        dim args as String()
        dim xmltransform as DataSetMapXSDSchemaSample
        xmltransform = new DataSetMapXSDSchemaSample()
    end sub

    ' Loads a specified schema into the DataSet
    public sub ParseSchema(schema as string)

        dim streamreader_schema as StreamReader = nothing
        try 
            streamreader_schema = new StreamReader(schema)
            Console.WriteLine("Reading Schema file ...")
            m_datadoc.ReadXmlSchema(streamreader_schema)

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

        Console.WriteLine()
        Console.WriteLine("Table structure")
        Console.WriteLine()
        Console.WriteLine("Tables count=" & m_datadoc.Tables.Count.ToString())

        Dim i,j as integer

            for i = 0 to (m_datadoc.Tables.Count - 1)
                Console.WriteLine("TableName='" & m_datadoc.Tables(i).TableName & "'.")
                Console.WriteLine("Columns count=" & m_datadoc.Tables(i).Columns.Count.ToString())

                for j = 0 to (m_datadoc.Tables(i).Columns.Count - 1)
                    Console.WriteLine(Strings.chr(9) & "ColumnName='" & m_datadoc.Tables(i).Columns(j).ColumnName & "', type = " & m_datadoc.Tables(i).Columns(j).DataType.ToString())
            next
            Console.WriteLine()
        next
    end sub

end class
end namespace
