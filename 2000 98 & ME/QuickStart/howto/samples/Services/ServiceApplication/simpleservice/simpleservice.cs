using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Timers;

public class SimpleService: ServiceBase {
    protected Timer timer;

    public static void Main() {
        ServiceBase.Run(new SimpleService());
    }

    public SimpleService()
    {
        CanPauseAndContinue = true;
        ServiceName = "Hello-World Service";

        timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new EventHandler(OnTimer);
    }

    protected override void OnStart(string[] args)
    {
        EventLog.WriteEntry("Hello-World Service started");
        timer.Enabled = true;
    }

    protected override void OnStop()
    {
        EventLog.WriteEntry("Hello-World Service stopped");
        timer.Enabled = false;
    }

    protected override void OnPause()
    {
        EventLog.WriteEntry("Hello-World Service paused");
        timer.Enabled = false;
    }

    protected override void OnContinue()
    {
        EventLog.WriteEntry("Hello-World Service continued");
        timer.Enabled = true;
    }

    protected void OnTimer(Object source, EventArgs e)
    {
        EventLog.WriteEntry("Hello World!");
    }
}

