/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;

public class DataSetMapXSDSchemaSample
{
    private const String m_Schema = "books.xsd";
    private XmlDataDocument m_datadoc;

    public DataSetMapXSDSchemaSample()
    {
        try
        {
			Console.WriteLine("Creating an XmlDataDocument ...");
            m_datadoc = new XmlDataDocument();
            ParseSchema(m_Schema);
            DisplayTableStructure();
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    public static void Main()
    {
        DataSetMapXSDSchemaSample xmltransform = new DataSetMapXSDSchemaSample();
    }

    // Loads a specified schema into the DataSet
    public void ParseSchema(String schema)
    {
        StreamReader streamreader_schema = null;

        try 
        {
            Console.WriteLine("Reading Schema file ...");
            streamreader_schema = new StreamReader(schema);
            m_datadoc.DataSet.ReadXmlSchema(streamreader_schema);
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally 
        {
            if (streamreader_schema != null)
                streamreader_schema.Close();
        }
    }    

    // Displays the DataSet tables structure
    private void DisplayTableStructure()
    {
        Console.WriteLine("\r\nTable structure \r\n");
        Console.WriteLine("Tables count=" + m_datadoc.DataSet.Tables.Count.ToString());
        for (int i = 0; i < m_datadoc.DataSet.Tables.Count; i++)
        {
            Console.WriteLine("\tTableName='" + m_datadoc.DataSet.Tables[i].TableName + "'.");
            Console.WriteLine("\tColumns count=" + m_datadoc.DataSet.Tables[i].Columns.Count.ToString());

            for (int j = 0; j < m_datadoc.DataSet.Tables[i].Columns.Count; j++)
            {
                Console.WriteLine("\t\tColumnName='" + m_datadoc.DataSet.Tables[i].Columns[j].ColumnName + "', type = " + m_datadoc.DataSet.Tables[i].Columns[j].DataType.ToString());
            }
        }
    }
} // End class DataSetMapXSDSchemaSample
} // End namespace HowTo.Samples.XML
