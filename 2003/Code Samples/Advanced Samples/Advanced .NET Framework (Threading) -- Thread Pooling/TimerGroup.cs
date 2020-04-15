using System;
using System.Threading;
using System.Windows.Forms;

// This class encapsulates the functionality of the Threading.Timer class.  The main
// purpose to put this in a class is to allow the OnTimer subroutine to be able to 
// know which labels to update, since you can! pass parameters to it.  

public class TimerGroup
{
    // Constructor
    public TimerGroup(Label OutputLabel,
                   Label ThreadNumLabel,
                   Label IsPoolThreadLabel)
	{
        lblOutput = OutputLabel;
        lblThreadNum = ThreadNumLabel;
        lblIsPoolThread = IsPoolThreadLabel;
    }

    private Label lblIsPoolThread ;
    private Label lblOutput ;
    private Label lblThreadNum ;
    private System.Threading.Timer myTimer;

    // This subroutine is the callback function for myTimer, called everytime timer fires
    private void OnTimer(object State )
	{
        // Update the Output label with the time.
        lblOutput.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + "." +DateTime.Now.Second;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblThreadNum.Text = Thread.CurrentThread.GetHashCode().ToString();
        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread )
		{
			lblIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblIsPoolThread.Text = "No";
		}
    }

    // This subroutine start the timer, by creating a Threading.Timer object with
    // a callback to OnTimer.  
    public void StartTimer(int period)
	{
        
		{
            // Create a callback to subroutine OnTimer
            TimerCallback callback = new TimerCallback(OnTimer);
            // && start the timer, passing frequency specified in period.  Note: 
            // Threading.Timer should not be confused with Timers.Timer.
            myTimer = new System.Threading.Timer(callback, null, 0, period);
        }
    }

    // This subroutine ends the timer by killing the Threading.Timer object. 
    public void StopTimer()
	{
        myTimer.Dispose();
        myTimer = null;
    }
}

