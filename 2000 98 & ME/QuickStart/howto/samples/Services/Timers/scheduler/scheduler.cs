using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Timers.Design;
using System.WinForms;
	
public class Scheduler
{
    static string executablePath;
    
    public static void Main(String[] args) 
    {
        string sampleName = Environment.GetCommandLineArgs()[0];

        if(args.Length != 1)
        {
            Console.WriteLine("Usage: " + sampleName +" <executable>");
            return;
        }
        
        executablePath = args[0];
        
        Schedule aSchedule = new Schedule(); 
        RecurrencePatternsDialog dlg = new RecurrencePatternsDialog();
        dlg.RecurrencePatterns = aSchedule.RecurrencePatterns;
        dlg.ShowDialog();
        
        aSchedule.RecurrencePatterns.All = dlg.RecurrencePatterns.All; 
        aSchedule.EventOccurred += new OccurredEventHandler(OnScheduledEvent);
        aSchedule.Enabled = true;
                
        Console.WriteLine("Press \'q\' to quit the sample");	
        while(Console.Read()!='q')
        {
            Thread.Sleep(500);	
        }
    }

	public static void OnScheduledEvent(Object source, OccurredEventArgs e)
	{
        Process.Start(executablePath);		
    }
}