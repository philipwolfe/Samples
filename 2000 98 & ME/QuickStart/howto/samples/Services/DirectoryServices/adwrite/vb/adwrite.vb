imports System
imports System.DirectoryServices
	
public class ADWrite
        public shared sub Main() 
		if(Environment.GetCommandLineArgs().Length<>4) then
            		Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()(0) + " <ad_path> <property> <value>")
            		exit sub
        	end if

                Dim adPath as String = Environment.GetCommandLineArgs()(1)
                Dim propertyName As String = Environment.GetCommandLineArgs()(2)
                Dim newValue as string  = Environment.GetCommandLineArgs()(3)
                
        	Dim objDirEnt As DirectoryEntry = new DirectoryEntry(adPath)
        	Console.WriteLine("Name            = " + objDirEnt.Name)
        	Console.WriteLine("Path            = " + objDirEnt.Path)
        	Console.WriteLine("SchemaClassName = " + objDirEnt.SchemaClassName)
		Console.WriteLine(propertyName + " = " + objDirEnt.Properties(propertyName).Value.ToString())
		Console.WriteLine("... changing to ")
		objDirEnt.Properties(propertyName).Value = newValue
                objDirEnt.CommitChanges()
		Console.WriteLine(propertyName + " = " + objDirEnt.Properties(propertyName).Value.ToString())
       end sub     	
end class