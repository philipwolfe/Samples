imports System
imports System.DirectoryServices
        
public class ADRead
        public shared sub Main()
        if(Environment.GetCommandLineArgs().Length<>2)
                Console.WriteLine("Usage: " & Environment.GetCommandLineArgs()(0) & " <ad_path>")
                exit sub
        end if

        Dim objDirEnt As DirectoryEntry = new DirectoryEntry(Environment.GetCommandLineArgs(1))
        Console.WriteLine("Name            = " & objDirEnt.Name)
        Console.WriteLine("Path            = " & objDirEnt.Path)
        Console.WriteLine("SchemaClassName = " & objDirEnt.SchemaClassName)
        Console.WriteLine("")
        Console.WriteLine("Properties:")

        Dim tab As string = "    "
        Dim objP as DirectoryEntryProperty
        Dim objValue as object

        for each objP in objDirEnt.Properties
            Console.Write(tab & objP.Name & " = ")
            Console.WriteLine("")
            for each objValue in objP.Values
                    Console.WriteLine(tab & tab & objValue.ToString())
            next objValue
        next objP
    end sub             
end class