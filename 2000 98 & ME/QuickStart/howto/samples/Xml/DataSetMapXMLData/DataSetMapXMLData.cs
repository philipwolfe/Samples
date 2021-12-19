/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML.DataSet
{

using System;
using System.IO;
using System.Data;
using System.Xml;

public class DataSetMapXMLDataSample
{
    private const String m_Document = "books.xml";

    public DataSetMapXMLDataSample()
    {        
        try
        {
            Console.WriteLine("Creating an XmlDataDocument ...");
            XmlDataDocument datadoc = new XmlDataDocument();

            // Infer the DataSet schema from the XML data and load the XML Data
            datadoc.DataSet.ReadXml(new StreamReader(m_Document));

            DisplayTables(datadoc.DataSet);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    public static void Main()
    {
        DataSetMapXMLDataSample xmltransform = new DataSetMapXMLDataSample();
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
} // End class DataSetMapXMLDataSample
} // End namespace HowTo.Samples.XML.DataSet
