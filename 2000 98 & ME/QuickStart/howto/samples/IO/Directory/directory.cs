using System;
using System.IO;



class DirectoryLister
{
    
    public static void Main(String[] args)
    {
        Directory dir = new Directory(".");
        PrintFiles (dir);
        
        Console.WriteLine ("\r\nPress Return to exit.");
        Console.Read();
    }
    public static void PrintFiles (Directory dir)
    {
        foreach (FileSystemEntry d in dir.GetFileSystemEntries ()) {
            if (d is File)
            {
                File f = (File) d;
                string name = f.FullName;
                long size = f.Length;
                DateTime creationTime = f.CreationTime;
                Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", size, creationTime, name);
            }
            else //it must be a directory
            {
                PrintFiles ((Directory) d);
            }
            
        }
    }
}


