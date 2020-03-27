using System;
using System.ServiceProcess;

public class HowTo_TimeTrackerService : System.ServiceProcess.ServiceBase
{
    // Declare the variables that will be used to contain the various
    //   required DateTime and TimeSpan objects

    private DateTime timeStart;  //Used to note the start time of the service
    private DateTime timeEnd;    //Used to note the end time of the service
    private TimeSpan timeElapsed = new TimeSpan(0);   //' Initialize to 0;
    // Used to calculate difference between timeEnd and TimeStart
    private TimeSpan timeDifference;
    private bool isPaused = false;  // Notes whether the service is paused;

#region " Component Designer generated code ";

    public HowTo_TimeTrackerService()
	{
        // This call is required by the Component Designer.
        InitializeComponent();
        // Add any initialization after the InitializeComponent() call
    }
    //UserService overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
    // The main entry point for the process
    [MTAThread()]static void Main()
	{
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        // More than one NT Service may run within the same process. To add
        // another service to this process, change the following line to
        // create a second service object. For example,
        //
        //   ServicesToRun = new System.ServiceProcess.ServiceBase () {new C#_NET_HowTo_TimeTrackerService, new MySecondUserService}
        //
        ServicesToRun = new System.ServiceProcess.ServiceBase[] {new HowTo_TimeTrackerService()};
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    }

    //Required by the Component Designer
    private System.ComponentModel.IContainer components = null;
    // NOTE: The following procedure is required by the Component Designer
    // It can be modified using the Component Designer.  
    // Do not modify it using the code editor.
    private void InitializeComponent() {
        //
        //VB_NET_HowTo_TimeTrackerService
        //
        this.CanPauseAndContinue = true;
        this.CanShutdown = true;
        this.ServiceName = "C#_NET_HowTo_TimeTrackerService";
    }

#endregion

    // OnContinue occurs when the user asks a paused Service to continue. In order 
    //   for this method to be called the CanPauseAndContinue property must be 
    //   set to true. (It is false by default.)
    protected override void OnContinue()
	{
        // Begin measuring the elapsed time. This means setting the
        //   timeStart back to the current time, and resetting isPaused
        //   to false

        if (isPaused)
		{
            timeStart = DateTime.Now;
        }
        isPaused = false;
        EventLog.WriteEntry("How-To Service Continued at " + 
            DateTime.Now.ToString());
    }

    // OnPause occurs when the user asks a running Service to pause. In order 
    //   for this method to be called the CanPauseAndContinue property must be 
    //   set to true. (It is false by default.)
    protected override void OnPause()
	{
        // Save the time that's elapsed so far in timeElapsed,
        //   and wait for the user to either Stop the service or 
        //   resume it.
        timeEnd = DateTime.Now;

        if (! isPaused)
		{
            timeDifference = timeEnd.Subtract(timeStart);
            timeElapsed = timeElapsed.Add(timeDifference);
        }
        isPaused = true;
        EventLog.WriteEntry("How-To Service was Paused at " + 
            DateTime.Now.ToString());
    }

    // OnShutdown occurs when the computer is powered off and the 
    //   Service has not been stopped. In order for this method to be called
    //   the CanShutdown property must be set to true. (It is false by default.)
    protected override void OnShutdown()
	{
        // Treat the service being stopped.
        this.OnStop();
    }

    // OnStart is called whenever the service is started.
    protected override void OnStart(string[] args)
	{
        // Add code here to start your service. This method should set things
        // in motion so your service can do its work.
        // Reset timeElapsed to zero. This is necessary since the used can
        //   call Restart without pausing or stopping the service
        timeElapsed = new TimeSpan(0);
        // Initialize the Start time
        timeStart = DateTime.Now;
        isPaused = false;
        EventLog.WriteEntry("How-To Service was Started at " + 
            timeStart.ToString());
    }

    // OnStop is called whenever the service is stopped.
    protected override void OnStop()
	{
        // Add code here to perform any tear-down necessary to stop your service.
        // Calculate the necessary times. if the Service is not currently paused
        //   the timeElapsed must be changed to consider the time its been
        //   running since a start or continue.
        timeEnd = DateTime.Now;
        if (! isPaused) 
		{
            timeDifference = timeEnd.Subtract(timeStart);
            timeElapsed = timeElapsed.Add(timeDifference);
        }
        EventLog.WriteEntry("How-To Service was Stopped at " + 
            timeEnd.ToString());
        EventLog.WriteEntry("How-To ran for a total time of " + 
            timeElapsed.ToString());
    }
}

