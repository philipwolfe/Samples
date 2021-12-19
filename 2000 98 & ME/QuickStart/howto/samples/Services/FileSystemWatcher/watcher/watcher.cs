using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

public class Watcher
{
    public static void Main(String[] args) 
    {
        if(args.Length < 1)
            Console.WriteLine("Usage: Watcher.exe <directory>");

        else {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path= args[0];
            watcher.Target = WatcherTarget.File;
            watcher.ChangedFilter = ChangedFilters.Attributes | ChangedFilters.LastAccess | ChangedFilters.LastWrite | ChangedFilters.Security | ChangedFilters.Size;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.Enabled = true;
        }

        Console.WriteLine("Press Enter to quit the sample\r\n");
        Console.ReadLine();
    }

    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType.Format());
    }

    public static void OnRenamed(Object source, RenamedEventArgs e)
    {
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
    }
}