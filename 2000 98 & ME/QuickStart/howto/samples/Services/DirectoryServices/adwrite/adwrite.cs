using System;
using System.DirectoryServices;

public class ADWrite {
    public static void Main(String[] args) 
    {
        if ( args.Length!=3 ) {
            Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " <ad_path> <property> <value>");
            return;
        }

        DirectoryEntry objDirEnt=new DirectoryEntry(args[0]);
        Console.WriteLine("Name            = " + objDirEnt.Name);
        Console.WriteLine("Path            = " + objDirEnt.Path);
        Console.WriteLine("SchemaClassName = " + objDirEnt.SchemaClassName);
        Console.WriteLine(args[1] + " = " + objDirEnt.Properties[args[1]].Value);
        Console.WriteLine("... changing to ");
        objDirEnt.Properties[args[1]].Value = args[2];
        objDirEnt.CommitChanges();
        Console.WriteLine(args[1] + " = " + objDirEnt.Properties[args[1]].Value);

    }       
}