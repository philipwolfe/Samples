/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Xsl;    

public class SaveDataSetXMLDataSample
{
    private const String m_Schema = "PersonPet.xsd";
    private const String m_NewDocument = "PersonPet.xml";
    private const String m_Stylesheet = "identity.xsl";

    public SaveDataSetXMLDataSample()
    {        
        try
        {
            // Load the DataSet with relation data
            DataSet dataset = new DataSet();
            LoadDataSet(dataset);
            //Create an XmlDataDocument for the DataSet
            XmlDataDocument datadoc = new XmlDataDocument(dataset);
            DisplayTables(datadoc.DataSet);
            // Write out schema representation 
            WriteSchema(datadoc);
            // Write out XML data form relational data
            WriteXMLData(datadoc);
            // Display the XML
            DisplayXMLData(datadoc);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.ToString());
        }
    }

    public static void Main()
    {
        SaveDataSetXMLDataSample saveschema = new SaveDataSetXMLDataSample();
    }

    // Load a DataSet with relational data
    private void LoadDataSet(DataSet dataset)
    {
        try
        {
            Console.WriteLine("Loading the DataSet ...");

            // Set DataSet name
            dataset.DataSetName = "PersonPet";

            // Create tables for people and pets
            DataTable people = new DataTable("Person");
            DataTable pets = new DataTable("Pet");

            // Set up the columns in the Tables
            DataColumn personname = new DataColumn ("Name", typeof(String));
            DataColumn personAge = new DataColumn ("Age", typeof(Int32));

            DataColumn petname = new DataColumn ("Name", typeof(String));
            DataColumn pettype = new DataColumn ("Type", typeof(String));

            // Add columns to person table
            DataColumn id = people.Columns.Add("ID", typeof(Int32));
            id.AutoIncrement = true;
            people.PrimaryKey = new DataColumn[] {id};
            people.Columns.Add (personname);
            people.Columns.Add (personAge);

            // Add columns to pet table
            id = pets.Columns.Add("ID", typeof(Int32));
            id.AutoIncrement = true;
            pets.PrimaryKey = new DataColumn[] {id};
            id.AutoIncrement = true;
            DataColumn ownerid = pets.Columns.Add("OwnerID", typeof(Int32));
            DataColumn[] foreignkey = new DataColumn[] {ownerid};
            pets.Columns.Add (petname);
            pets.Columns.Add (pettype);

            // Add tables to the DataSet
            dataset.Tables.Add (people);
            dataset.Tables.Add (pets);

            // Add people
            DataRow mark = people.NewRow();
            mark[personname] = "Mark";
            mark[personAge] = 18;
            people.Rows.Add(mark);

            DataRow william = people.NewRow();
            william[personname] = "William";
            william[personAge] = 12;
            people.Rows.Add(william);

            DataRow james = people.NewRow();
            james[personname] = "James";
            james[personAge] = 7;
            people.Rows.Add(james);

            DataRow levi = people.NewRow();
            levi[personname] = "Levi";
            levi[personAge] = 4;
            people.Rows.Add(levi);

            // Add relationships
            Console.WriteLine("Creating relationships between people and pets ...");
            DataRelation personpetrel = new DataRelation ("PersonPet",people.PrimaryKey, foreignkey);
            dataset.Relations.Add (personpetrel);

            // Add pets
            DataRow row = pets.NewRow();
            row["OwnerID"] = mark["ID"];
            row[petname] = "Frank";
            row[pettype] = "cat";
            pets.Rows.Add(row);

            row = pets.NewRow();
            row["OwnerID"] = william["ID"];
            row[petname] = "Rex";
            row[pettype] = "dog";
            pets.Rows.Add(row);

            row = pets.NewRow();
            row["OwnerID"] = james["ID"];
            row[petname] = "Cottontail";
            row[pettype] = "rabbit";
            pets.Rows.Add(row);

            row = pets.NewRow();
            row["OwnerID"] = levi["ID"];
            row[petname] = "Sid";
            row[pettype] = "snake";
            pets.Rows.Add(row);

            row = pets.NewRow();
            row["OwnerID"] = levi["ID"];
            row[petname] = "Tickles";
            row[pettype] = "spider";
            pets.Rows.Add(row);

            row = pets.NewRow();
            row["OwnerID"] = william["ID"];
            row[petname] = "Tweetie";
            row[pettype] = "canary";
            pets.Rows.Add(row);
                    
            // commit changes
            dataset.AcceptChanges();
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    // Display the contents of the DataSet
    internal void DisplayTables(DataSet dataset)
    {
        try
        {
            if (dataset == null)
            {
                Console.WriteLine("The DataSet is null");
                return;
            }

            Console.WriteLine("\r\nDataSet: \r\n" + dataset.DataSetName +" contains ...");

            // Navigate Dataset
            Console.WriteLine("No of Tables: {0}  Table content ...\r\n", dataset.Tables.Count);
            foreach(DataTable table in dataset.Tables)
            {
                Console.WriteLine("TableName = " + table.TableName);
                Console.WriteLine ("{0}", "---------");
                Console.WriteLine("Columns ...\r\n");
                foreach(DataColumn column in table.Columns)
                {
                    Console.Write("{0,-22}",column.ColumnName);
                }
                Console.WriteLine("\r\nNumber of rows = " + table.Rows.All.Length);
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

            // What relationships are there?
            DataRelation[] relations = dataset.Relations.All;
            for (int i = 0; i < relations.Length; i++)
            {
                Console.WriteLine(relations[i].RelationName);
            }

            Console.WriteLine();

            // Who owns which pets ?
            foreach (DataRow person in dataset.Tables["Person"].Rows)
            {
                Console.WriteLine ("Name = " + person["Name"]+" owns");
                foreach (DataRow personpet in person.GetChildRows(dataset.Relations["PersonPet"]))
                {
                    Console.WriteLine("\tPet = " + personpet["Name"]+" the "+personpet["Type"]);
                }
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    // Write the schema for the dataset
    internal void WriteSchema(XmlDataDocument datadoc)
    {
        StreamWriter writer = null;

        try
        {
            Console.WriteLine("Writing the schema to {0} ...", m_Schema);
            writer = new StreamWriter(m_Schema);
            datadoc.DataSet.WriteXmlSchema(writer);
        }

        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.ToString());
        }

        finally
        {
            if (writer != null)
                writer.Close();
        }
    }

    // Write data as XML
    internal void WriteXMLData(XmlDataDocument datadoc)
    {
        StreamWriter writer = null;

        try
        {
            Console.WriteLine("Writing the XML data to {0} ...", m_NewDocument);
            writer = new StreamWriter(m_NewDocument);
            datadoc.Save(writer);
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally
        {
            if (writer != null)
                writer.Close();
        }
    }

    // Display data as XML
    internal void DisplayXMLData(XmlDataDocument datadoc)
    {
        XmlReader docreader = null;

        try
        {
            Console.WriteLine("Displaying the XML ...\r\n");
            XmlNodeReader xmlnodereader = new XmlNodeReader (new DataDocumentNavigator(datadoc));
            FormatXml (xmlnodereader);
        }

        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }

        finally
        {
            if (docreader != null)
                docreader.Close();
        }
    }

    private static void FormatXml (XmlReader reader)
    {
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction");
                break;
            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType");
                break;
            case XmlNodeType.Document:
                Format (reader, "Document");
                break;
            case XmlNodeType.Comment:
                Format (reader, "Comment");
                break;
            case XmlNodeType.Element:
                Format (reader, "Element");
                while(reader.MoveToNextAttribute())
                {
                    Format (reader, "Attribute");
                }
                break;
            case XmlNodeType.Text:
                Format (reader, "Text");
                break;
            case XmlNodeType.Whitespace:
                Format (reader, "Whitespace");
                break;
            }
        }
    }

    // Format the output
    private static void Format(XmlReader reader, String NodeType)
    {
        // Format the output
        for (int i=0; i < reader.Depth; i++)
        { 
            Console.Write('\t');
        }

        Console.Write(NodeType + "<" + reader.Name + ">" + reader.Value);
        Console.WriteLine();
    }
} // End class SaveDataSetXMLDataSample
} // End namespace HowTo.Samples.XML
