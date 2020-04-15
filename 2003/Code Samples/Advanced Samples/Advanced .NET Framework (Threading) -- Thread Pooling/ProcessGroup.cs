using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

// This class encapsulates a two second process for non-threaded, threaded, and thread-
// pool operations.

public delegate void OnProcessesComplete();

public class ProcessGroup
{
	// Constructor
	public ProcessGroup(Label ActiveLabel,Label ThreadNumLabel,Label IsPoolThreadLabel)
	{
		lblActive = ActiveLabel;
		lblThreadNum = ThreadNumLabel;
		lblIsPoolThread = IsPoolThreadLabel;
		// Add one to the shared property numberOfProcesses.
		numberOfProcesses += 1;
	}
	private Label lblActive;
	private Label lblIsPoolThread;
	private Label lblThreadNum;

	// static members
	private static bool highIntensity ;
	private static int numberOfProcesses  = 0;
	private static int processesCompleted;
	private static int ticksElapsed;

	public static int GetTicksElapsed
	{
		get 
		{
			return ticksElapsed;
		}
	}

	public static bool SetHighIntensity
	{
		set
		{
			highIntensity = value;
		}
	}
	
	public event OnProcessesComplete Completed;
	
	// Initialize static members for another run
	public static void PrepareToRun()
	{
		processesCompleted = 0;
		ticksElapsed = Environment.TickCount;
	}

	// This procedure runs a two second process, updating the appropriate labels, 
	// forcing refresh in case Main thread is starved.
	 public void Run()
	{
		// Show that we are active in green.
		lblActive.Text = "Active";
		lblActive.ForeColor = Color.Green;
		lblActive.Refresh();
		// Update ThreadNum label with current thread number.  GetHashCode will contain
		// a unique value for each thread.
		lblThreadNum.Text = Thread.CurrentThread.GetHashCode().ToString();
		lblThreadNum.Refresh();
		// Update the IsThreadPooled label with Yes/No depending on whether the current
		// thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread) 
		{
			lblIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblIsPoolThread.Text = "No";
		}
		lblIsPoolThread.Refresh();
		// if highIntensity is selected loop based on TickCount for two seconds to max 
		// out the CPU, otherwise let this thread sleep for 2 seconds. 

		if (highIntensity)
		{
			int ticks  = Environment.TickCount;
			while (Environment.TickCount - ticks < 2000)
			{
			}
		}
		else 
		{
			System.Threading.Thread.Sleep(2000);
		}

		// Process is finished, display inactive in red
		lblActive.Text = "Inactive";
		lblActive.ForeColor = Color.Red;
		lblActive.Refresh();
		// Add to the shared property ProcessCompleted.  if all processes are done, 
		// raise a completed event.  This is necessary for the threaded processes,
		// to allow the user interface to know when to enable buttons, and update
		// time elapsed, since they return immediately.
		processesCompleted += 1;

		if (processesCompleted == numberOfProcesses) 
		{
			ticksElapsed = Environment.TickCount - ticksElapsed;
			Completed();
		}
	}

	// This subroutine is callback for Threadpool.QueueWorkItem.  This is the necessary
	// subroutine signiture for QueueWorkItem, and run is proper for creating a Thread
	// so the two subroutines can! be combined, so instead just call Run from here.

	private void RunPooledThread(object state)
	{
		Run();
	}

	// Add a queue request to Threadpool with a callback to RunPooledThread (which calls
	// Run()
	public void StartPooledThread()
	{
		// Create a callback to subroutine RunPooledThread
		WaitCallback callback = new WaitCallback(RunPooledThread);
		// && put in a request to ThreadPool to run the process.
		ThreadPool.QueueUserWorkItem(callback, null);
	}

	// Start a new thread, running subroutine Run.
	public void StartThread()
	{
		Thread newThread;
		newThread = new Thread(new ThreadStart(Run));
		newThread.Start();

	}
}

