using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
	
// Every Wednesday from 7:00am till 6:00pm prints "Hello World" every 5 seconds

public class Scheduler
{
       	public static void Main(String[] args) 
	{
		Schedule aSchedule = new Schedule();
	    aSchedule.Enabled = false;
        
		aSchedule.EventOccurred += new OccurredEventHandler(OnScheduledEvent);

		WeeklyPattern days = new WeeklyPattern(DaysOfWeek.Wednesday,1);
		days.StartTime = new TimeSpan(7,0,0);
		days.EndTime = new TimeSpan(18,0,0);
		days.Interval = new TimeSpan(0,0,5);
		days.ValidFrom = new DateTime(1900,1,1);

		aSchedule.RecurrencePatterns.Add(days);

        aSchedule.Enabled = false;
		Console.WriteLine("Move the system clock to a Wednesday between 7:00am and 6:00pm and press \'r\'");
		while(Console.In.Read()!='r');
		aSchedule.Enabled = true;
				
		Console.WriteLine("Press \'q\' and Enter to quit the sample");	
		while(Console.Read()!='q');
    }

	public static void OnScheduledEvent(Object source, OccurredEventArgs e)
	{
		Console.WriteLine("Hello World!");
	}
}