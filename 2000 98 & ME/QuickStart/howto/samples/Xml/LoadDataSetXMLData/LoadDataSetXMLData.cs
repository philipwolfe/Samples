/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Data;
using System.Xml;

public class LoadDataSetXMLDataSample
{
    private const String m_Document = "books.xml";
    private const String m_Schema = "books.xsd";
    private XmlDataDocument m_datadoc;

    public LoadDataSetXMLDataSample()
    {        
        try
        {
            Console.WriteLine("Creating an XmlDataDocument ...");
            m_datadoc = new XmlDataDocument();
            ParseSchema(m_Schema);
            DisplayTableStructure();

            m_datadoc.Load(m_Document);

            DisplayTables(m_datadoc.DataSet);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    public static void Main()
    {
        LoadDataSetXMLDataSample xmltransform = new LoadDataSetXMLDataSample();
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

    // Displays the contents of the DataSet tables
    private void DisplayTables(DataSet dataset)
    {
        // Navigate Dataset
        Console.WriteLine("Content of Tables ...\r\n");

        foreach(DataTable table in dataset.Tables)
        {
            Console.WriteLine("TableName = " + table.TableName);
            Console.WriteLine ("{0}", "---------");
            Console.WriteLine("Columns ...\r\n");

            foreach(DataColumn column in table.Columns)
            {
                Console.Write("{0,-22}",column.ColumnName);
            }
            Console.WriteLine();
            Console.WriteLine("\r\nNumber of rows = {0}", table.Rows.All.Length);
            Console.WriteLine("Rows ...\r\n");

            foreach(DataRow row in table.Rows)
            {
                foreach(Object value in row.ItemArray)
                {
                    Console.Write("{0,-22}",value.ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
} // End class LoadDataSetXMLDataSample
} // End namespace HowTo.Samples.XML
