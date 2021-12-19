'Copyright (c) 2000, Microsoft Corporation. All Rights Reserved
Option Strict off

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Data.DataSet

Namespace HowTo.Samples.XML

public class SaveDataSetMapXSDSchemaSample

    private const m_Schema as String = "PersonPet.xsd"

    public sub New()
    MyBase.New
            
        try        
            ' Load the DataSet with relation data and write out a schema representation
            dim datadoc as XmlDataDocument = new XmlDataDocument()
            LoadDataSet(datadoc.DataSet)
            DisplayTables(datadoc.DataSet)
            WriteSchema(datadoc)
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
     end sub       

    Shared sub Main
        dim saveschema as SaveDataSetMapXSDSchemaSample = new SaveDataSetMapXSDSchemaSample()
    end sub

    ' Load a DataSet with relational data
    private sub LoadDataSet(dataset as DataSet)
    
        try
            Console.WriteLine("Loading the DataSet ...")

            ' Set DataSet name
            dataset.DataSetName = "PersonPet"

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
            dataset.Tables.Add (people)
            dataset.Tables.Add (pets)

            ' Add people
            dim mark as DataRow = people.NewRow()
            mark(personname) = "Mark"
            mark(personAge) = 18
            people.Rows.Add(mark)

            dim william as DataRow = people.NewRow()
            william(personname) = "William"
            william(personAge) = 12
            people.Rows.Add(william)

            dim james as DataRow = people.NewRow()
            james(personname) = "James"
            james(personAge) = 19
            people.Rows.Add(james)

            dim levi as DataRow = people.NewRow()
            levi(personname) = "Levi"
            levi(personAge) = 4
            people.Rows.Add(levi)

            ' Add relationships
            Console.WriteLine("Creating relationships between people and pets ...")
            dim personpetrel as DataRelation = new DataRelation ("PersonPet", primarykey, foreignkey, false)
            dataset.Relations.Add (personpetrel)

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
            row("OwnerID") = james("ID")
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
            dataset.AcceptChanges()
        
        catch e as Exception        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub 

    ' Displays the contents of the DataSet tables
    private sub DisplayTables(ds as system.data.DataSet)
        try        
            if (ds = nothing)
            
                Console.WriteLine("The DataSet is null") 
                return 
            end if

            Console.WriteLine("DataSet: " &  ds.DataSetName  &" contains ...") 

            'Navigate Dataset
            Console.WriteLine("Content of Tables ...")

            Dim table as object
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
            
            ' What relationships are there?
            dim relations() as DataRelation = ds.Relations.All

            dim i as Integer
            for i = 0 to (relations.Length - 1)            
                Console.WriteLine(relations(i).RelationName.ToString())
            next

            Console.WriteLine()

            ' Who owns which pets ?
            Dim person as Object
            for each person in ds.Tables("Person").Rows
            
                Console.WriteLine ("Name = " & person("Name") & " owns")
                Dim personpet as Object
                for each personpet in person.GetChildRows(ds.Relations("PersonPet"))                
                    Console.WriteLine(Strings.chr(9) & "Pet = " & personpet("Name") & " the " & personpet("Type"))
                next
                Console.WriteLine()
            next
        catch e as Exception 
        
            Console.WriteLine ("Exception: {0}", e.ToString())
        end try
    end sub 
    
    ' Write the schema for the dataset
    private sub WriteSchema(datadoc as System.Xml.XmlDataDocument)
    
        dim writer as StreamWriter

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

end Class
end Namespace
