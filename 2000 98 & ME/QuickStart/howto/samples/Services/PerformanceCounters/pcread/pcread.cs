using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

public class PCRead {

    static string objectName; 
    static string counterName;
    static string instanceName;
    static PerformanceCounter theCounter;


    public static void Main(string[] args){

        string appName = Environment.GetCommandLineArgs()[0];

        if ( args.Length != 3 && args.Length != 2 ) {
            Console.WriteLine("Usage: " + appName + " <object> <counter> [<instance>]");
            return;
        }

        objectName  = args[0];
        counterName  = args[1]; 
        instanceName = "";
        if ( args.Length == 3 )
            instanceName = args[2];

        if ( !PerformanceCounter.CategoryExists(objectName) ) {
            Console.WriteLine("Object " + objectName + " does not exists!");
            return;
        }

        if ( !PerformanceCounter.Exists(objectName,counterName) ) {
            Console.WriteLine("Counter " + counterName + " does not exists!");
            return;
        }

        theCounter = new PerformanceCounter(objectName, counterName ,instanceName); 

        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Tick += new EventHandler(OnTimer);

        aTimer.Interval = 500;
        aTimer.Enabled = true;
        aTimer.AutoReset = false;

        Console.WriteLine("Press \'q\' to quit the sample");    
        while ( Console.Read()!='q' ) {
            Thread.Sleep(500);  
        } 
    }

    public static void OnTimer(Object source, EventArgs e)
    {       
        try {
            Console.WriteLine("Current value =  " + theCounter.NextValue().ToString());
        } catch {
            Console.WriteLine("Instance " + instanceName + " does not exist!");
            return;
        }

        System.Timers.Timer theTimer = (System.Timers.Timer)source;
        theTimer.Enabled = true;
    }
}