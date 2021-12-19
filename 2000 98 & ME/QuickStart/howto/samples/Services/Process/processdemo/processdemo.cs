using System;
using System.Diagnostics;
using System.Threading;

public class ProcessDemo
{
    public static void Main(String[] args) 
    {
        string appName = Environment.GetCommandLineArgs()[0];
        
        if(args.Length != 1)
        {
            Console.WriteLine("Usage: " + appName +" <executable>");
            return;
        }
        string executableFilename = args[0];
        
        Process process = new Process();
        process.StartInfo.FileName = executableFilename;
        process.Start();
        
        process.WaitForInputIdle();
        
        Thread.Sleep(1000);
        if(!process.CloseMainWindow())
        {
            process.Kill();
        }
    }
}

