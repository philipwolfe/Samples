using System;
using System.DirectoryServices;
	
public class ADRead
{
    public static void Main(String[] args) 
	{
		if(args.Length!=1)
        {
         	Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " <ad_path>");
         	return;
        }

        DirectoryEntry objDirEnt=new DirectoryEntry(args[0]);
        Console.WriteLine("Name            = " + objDirEnt.Name);
        Console.WriteLine("Path            = " + objDirEnt.Path);
        Console.WriteLine("SchemaClassName = " + objDirEnt.SchemaClassName);
        Console.WriteLine("");
        Console.WriteLine("Properties:");
            	
		string tab = "    ";
        foreach(DirectoryEntryProperty objP in objDirEnt.Properties)
        {
            Console.Write(tab + objP.Name + " = ");
            Console.WriteLine("");	
            foreach(Object objValue in objP.Values) 
                Console.WriteLine(tab + tab + objValue);
        }
    }		
}