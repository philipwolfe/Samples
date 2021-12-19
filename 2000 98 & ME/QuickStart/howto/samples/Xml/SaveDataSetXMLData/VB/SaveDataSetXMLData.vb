' Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

Option strict off

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Xml.Xsl

namespace HowTo.Samples.XML

public class SaveDataSetXMLDataSample

    private const m_Schema as String = "PersonPet.xsd" 
    private const m_NewDocument as String = "PersonPet.xml" 
    private const m_Stylesheet as String = "identity.xsl"

    public sub New ()

    MyBase.new            
        try
            'Load the DataSet with relation data
            dim ds as DataSet = new DataSet()
            LoadDataSet(ds)
            'Create an XmlDataDocument for the DataSet
            dim datadoc as XmlDataDocument = new System.Xml.XmlDataDocument(ds) 
            DisplayTables(datadoc.DataSet) 
            'Write out schema representation 
            WriteSchema(datadoc) 
            'Write out XML data form relational data
            WriteXMLData(datadoc) 
            'Display the XML
            DisplayXMLData(datadoc) 
        
        catch e as Exception
        
            Console.WriteLine("Exception: " & e.ToString()) 
        end try
    end sub

    shared sub Main()
        dim saveschema as SaveDataSetXMLDataSample = new SaveDataSetXMLDataSample() 
    end sub


    ' Load a DataSet with relational data
    private sub LoadDataSet(ds as DataSet)
    
        try       
            Console.WriteLine("Loading the DataSet ...")

            ' Set DataSet name
            ds.DataSetName = "PersonPet"

            ' Create tables for people and pets
            dim people as DataTable = new DataTable("Person")
            dim pets as DataTable = new DataTable("Pet")

            ' Set up the columns in the Tables
            dim personname as DataColumn = new DataColumn ("Name", GetType (System.String))
            dim personAge as DataColumn = new DataColumn ("Age", GetType (System.Int32))

            dim petname as DataColumn = new DataColumn ("Name", GetType (System.String))
            dim pettype as DataColumn = new DataColumn ("Type", GetType (System.String))

            ' Add columns to person table
            dim id as DataColumn = people.Columns.Add("ID", GetType (System.Int32))
            id.AutoIncrement = true
            dim primarykey as DataColumn() = new DataColumn() {id}
            people.PrimaryKey = primarykey
            people.Columns.Add (personname)
            people.Columns.Add (personAge)

            ' Add columns to pet table
            id = pets.Columns.Add("ID", GetType (System.Int32))
            id.AutoIncrement = true
            pets.PrimaryKey = new DataColumn() {id}
            id.AutoIncrement = true
            dim ownerid as DataColumn = pets.Columns.Add("OwnerID", GetType (System.Int32))
            dim foreignkey as DataColumn() = new DataColumn() {ownerid}
            pets.Columns.Add (petname)
            pets.Columns.Add (pettype)

            ' Add tables to the DataSet
            ds.Tables.Add (people)
            ds.Tables.Add (pets)

            ' Add people
            dim mark as DataRow = people.NewRow()
            mark(personname) = "Mark"
            mark(personAge) = 18
            people.Rows.Add(mark)

            dim william as DataRow = people.NewRow()
            william(personname) = "William"
            william(personAge) = 12
            people.Rows.Add(william)

            dim joann as DataRow = people.NewRow()
            joann(personname) = "Joann"
            joann(personAge) = 19
            people.Rows.Add(joann)

            dim levi as DataRow = people.NewRow()
            levi(personname) = "Levi"
            levi(personAge) = 4
            people.Rows.Add(levi)

            ' Add relationships
            Console.WriteLine("Creating relationships between people and pets ...")
            dim personpetrel as DataRelation = new DataRelation ("PersonPet", primarykey, foreignkey, false)
            ds.Relations.Add (personpetrel)

            ' Add pets
            dim row as DataRow = pets.NewRow()
            row("OwnerID") = mark("ID")
            row(petname) = "Frank"
            row(pettype) = "cat"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = william("ID")
            row(petname) = "Rex"
            row(pettype) = "dog"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = joann("ID")
            row(petname) = "Cottontail"
            row(pettype) = "rabbit"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = levi("ID")
            row(petname) = "Sid"
            row(pettype) = "snake"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = levi("ID")
            row(petname) = "Tickles"
            row(pettype) = "spider"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = william("ID")
            row(petname) = "Tweetie"
            row(pettype) = "canary"
            pets.Rows.Add(row)
                    
            ' commit changes
            ds.AcceptChanges()
        
        catch e as Exception
        
            Console.WriteLine("Exception: " & e.ToString())
        end try
    end sub


    'Display the contents of the DataSet
    private sub DisplayTables(ds as DataSet)    
        try        
            if (ds = nothing)        
                Console.WriteLine("The DataSet is null") 
                return 
            end if

            Console.WriteLine("DataSet: " &  ds.DataSetName  &" contains ...") 
            Console.WriteLine()
            'Navigate Dataset
            Console.WriteLine("No of Tables: {0}  Table content ...",  ds.Tables.Count.ToString()) 
            Console.WriteLine()
        
        dim table as Object
            for each table in  ds.Tables
            
                Console.WriteLine("TableName = " & table.TableName.ToString()) 
                Console.WriteLine ("{0}", "---------") 
                Console.WriteLine("Columns ...") 
        dim column as object
                for each column in table.Columns
                
                    Console.Write("{0,-22}",column.ColumnName) 
                next
                Console.WriteLine() 
                Console.WriteLine("Number of rows = " & table.Rows.Count.ToString()) 
                Console.WriteLine() 
                Console.WriteLine("Rows ...") 
        dim row as Object
                for each row in table.Rows
                    dim value as object
                    for each value in row.ItemArray
                    
                        Console.Write("{0,-22}",value.ToString()) 
                    next
                    Console.WriteLine() 
                next
                Console.WriteLine() 
            next

            'What relationships are there?
            dim relations as DataRelation() =  ds.Relations.All 
        dim i as long
            for i = 0 to (relations.Length - 1)
            
                Console.WriteLine(relations(i).RelationName.ToString()) 
            next

            Console.WriteLine() 

            'Who owns which pets ?
        dim person as Object
            for each person in  ds.Tables("Person").Rows
            
                Console.WriteLine ("Name = " & person("Name").ToString() & " owns") 
            dim personpet as Object
                for each personpet in person.GetChildRows( ds.Relations("PersonPet"))
                
                    Console.WriteLine(Strings.chr(9) & "Pet = " & personpet("Name") & " the " & personpet("Type")) 
                next
                Console.WriteLine() 
            next
        
        catch e as Exception 
        
            Console.WriteLine("Exception: " & e.ToString()) 
        end try
    end sub

    ' Write the schema for the dataset
    private sub WriteSchema(datadoc as System.Xml.XmlDataDocument)
    
        dim writer as StreamWriter = nothing

        try        
            Console.WriteLine("Writing the schema to {0} ...", m_Schema)
            writer = new StreamWriter(m_Schema)
            datadoc.DataSet.WriteXmlSchema(writer)
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())

        finally
            if not (writer = nothing)
                writer.Close()
            end if

        end try
    end sub 

    'Write data as XML
    private sub WriteXMLData(datadoc as System.Xml.XmlDataDocument)
    
        dim writer as StreamWriter = nothing

        try
        
            Console.WriteLine("Writing the XML data to {0} ...", m_NewDocument) 
            writer = new StreamWriter(m_NewDocument) 
            datadoc.Save (writer) 
        
        catch e as Exception
            Console.WriteLine("Exception: ", e.ToString()) 

        finally
            if not (writer = nothing)
                writer.Close()
            end if

        end try
    end sub

    'Display data as XML
    private sub DisplayXMLData(datadoc as XmlDataDocument)
    
        dim docreader as XmlReader = nothing

        try        
            Console.WriteLine("Displaying the XML ...") 
            Console.WriteLine() 

            dim xmlnodereader as XmlNodeReader = new XmlNodeReader (new DataDocumentNavigator(datadoc))
            FormatXml (xmlnodereader)

        catch e as Exception
            Console.WriteLine("Exception: " & e.ToString()) 

        finally
            if not (docreader = nothing)
                docreader.Close() 
            end if

        end try
    end sub

    private sub FormatXml (reader as XmlReader)
    
        while (reader.Read())
        
        select case reader.NodeType
            
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction") 
                
            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType") 
                
            case XmlNodeType.Document:
                Format (reader, "Document") 
                
            case XmlNodeType.Comment:
                Format (reader, "Comment") 
                
            case XmlNodeType.Element:
                Format (reader, "Element") 
                                
            case XmlNodeType.Text:
                Format (reader, "Text") 
                
            case XmlNodeType.Whitespace:
                Format (reader, "Whitespace") 
                
            end select
    end while

    end sub

    'Format the output
    private sub Format (reader as XmlReader, NodeType as String)
    
        dim value as String = System.String.Empty 
        dim i as long
        for i=0  to (reader.Depth - 1) 
            Console.Write("    ") 
        Next

        if (reader.HasValue)
            value = reader.Value 
        end if

        Console.WriteLine(NodeType & "<" & reader.Name & ">" + value) 
    end sub

End class
End namespace
