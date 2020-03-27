using System;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms; // needed for Notification events
using System.Text; // needed for StringBuilder

namespace HelpAndNotifications
{
	public partial class Form1 : Form
	{
		private int currentTickCount; // used with progress bar to show user progress

		public Form1()
		{
			InitializeComponent();

			// Display the OK button for closing the application.
			MinimizeBox = false;

			// Set timer interval
			TimerIntervalTrackBar.Value = 3; // init to 3 second interval
			StatusBar1.Text = string.Empty;

			// Set instructions in label
			StringBuilder builder = new StringBuilder();
			builder.Append("This sample demonstrates both Help and Notification features.\r\n\r\n");
			builder.Append("Click the Start Button to see a notification popup based on a timer that processes an HTML response.\r\n\r\n");
			builder.Append("Use the context menu of the track bar to see tool tip style context sensitive help using a notification popup.\r\n\r\n");
			builder.Append("Use the Pocket PC Start Menu -> Help to see a notification popup.\r\n");
			DescriptionLabel.Text = builder.ToString();
		}

		// Inits the Notification object based on caption and html string
		private void InitNotification(string caption, string html)
		{
			HelpNotification.Caption = caption;

			// Notification will display for 10 seconds before closing automatically
			HelpNotification.InitialDuration = 10;

			// If notification is urgent, set to true
			HelpNotification.Critical = false;

			// Set the Text property to the HTML string
			HelpNotification.Text = html;

			// Make the Notification visible
			HelpNotification.Visible = true;
		}

		private string GetTimerNotificationHtml()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("<html><body>");
			builder.Append("<font color=\"#0000FF\"><b>Timer Notification Enabled</b></font>");
			builder.Append("<form method=\"GET\" action=ChangeInterval>");
			builder.Append("<br>Use the track bar on the form to change ");
			builder.Append("the Notification Timer Interval.<br><br>");
			builder.Append("Or change it here...");
			builder.Append("<SELECT NAME=\"TimeListBox\">");
			builder.Append("<OPTION VALUE=\"1\">1 sec</OPTION>");
			builder.Append("<OPTION VALUE=\"2\">2 sec</OPTION>");
			builder.Append("<OPTION VALUE=\"3\">3 sec</OPTION>");
			builder.Append("<OPTION VALUE=\"4\">4 sec</OPTION>");
			builder.Append("<OPTION VALUE=\"5\">5 sec</OPTION></SELECT>");
			builder.Append("<br><br>");

			// Add submit to cause response
			builder.Append("<input type='submit'>");

			// Note if a link or element has a name of "cmd:n", where n is any integer, the following results:
			// 0 is reserved, 
			// 1 sends a notification but does not dismiss the bubble, 
			// 2 dismisses the bubble and places an icon in the title bar and the Microsoft.WindowsCE.Forms.Notification.ResponseSubmitted event is not raised.
			// 3 or greater closes the bubble the Microsoft.WindowsCE.Forms.Notification.ResponseSubmitted event is not raised.
			builder.Append("<input type=button name='cmd:2' value='Dismiss'>");
			builder.Append("<input type=button name='cmd:3' value='Close'>");
			builder.Append("</body></html>");

			return builder.ToString();
		}

		private string GetTrackBarHelpHtml()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("<html><body>");
			builder.Append("<font color=\"#0000FF\"><b>Track Bar Help</b></font>");
			builder.Append("<br>Use the Track Bar control to adjust the time it takes for a notification to popup.<form method=\"GET\" action=notify>");
			builder.Append("<br><br>");
			builder.Append("<input type=button name='cmd:3' value='Close'>"); // value of "cmd:3" closes notification with no response
			builder.Append("</body></html>");

			return builder.ToString();
		}

		private string GetFormHelpHtml()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("<html><body>");
			builder.Append("<font color=\"#0000FF\"><b>Form Help Notification</b></font>");
			builder.Append("<br>Place Form Help here...");
			builder.Append("<br><br>");
			builder.Append("<input type=button name='cmd:3' value='Close'>"); // value of "cmd:3" closes notification with no response
			builder.Append("</body></html>");

			return builder.ToString();
		}

		// The BalloonChanged event fires before the Notification is displayed or closed
		private void HelpNotification_BalloonChanged(object sender, BalloonChangedEventArgs e)
		{
			// Add Code here to update UI...in this case the status bar
			if (e.Visible == true)
				StatusBar1.Text = HelpNotification.Caption;
			else
				StatusBar1.Text = "Notification Closed";
		}

		// When a ResponseSubmitted event occurs, this event handler
		// parses the response to determine values in the HTML form.
		private void HelpNotification_ResponseSubmitted(object sender, ResponseSubmittedEventArgs e)
		{
			// Check the response.  If the action value of the form is "ChangeInterval", then
			// get the value of the selected option from the SELECT list. Based on how the 
			// GetFormHelpHtml method created the HTML form we should expect a reponse string like
			// this:  ChangeInterval?TimeListBox=1
			string resStr = e.Response;
			int len = resStr.Length; // get length once for efficiency

			if (resStr.Substring(0, len - 2) == "ChangeInterval?TimeListBox")
			{
				TimerIntervalTrackBar.Value = Convert.ToInt32(resStr.Substring(len - 1, 1));
				SecondsLabel.Text = TimerIntervalTrackBar.Value.ToString() + " s";
			}
		}

		// Similar to the context-sensitive F1 key on your desktop PC, which opens different help files 
		// depending on which application is active when you press it, the Start > Help command on your Pocket PC 
		// will fire the HelpRequested event so that a Help file that is specific to whichever application is 
		// "in front"
		private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
		    InitNotification("Form Help", GetFormHelpHtml());
		}

		// Poor man's tool tip on the Pocket PC can be implemented by using a context menu on a control and then
		// launching a Notification Window
		private void HelpMenuItem_Click(object sender, EventArgs e)
		{
	        InitNotification(HelpContextMenu.SourceControl.Name + " Help", GetTrackBarHelpHtml());
		}

		// Button event starts the timer.  When time is up the notification will display
		private void StartTimerButton_Click(object sender, EventArgs e)
		{
			int secs = TimerIntervalTrackBar.Value;

			// Init the progress bar
			currentTickCount = 0; // reset current tick counter
			ProgressBar1.Maximum = secs;
			ProgressBar1.Minimum = 0;
			ProgressBar1.Value = 0;

			// Init the status Bar
			StatusBar1.Text = "Waiting for Notification...";
			NotificationTimer.Interval = 1000; // interrupt every second
			NotificationTimer.Enabled = true;
		}

		// Tick event updates counter and progress bar until count is reached.
		private void NotificationTimer_Tick(object sender, EventArgs e)
		{
			currentTickCount += 1; // increment current tick count
			ProgressBar1.Value = currentTickCount; // set Progress Bar

			if (currentTickCount >= TimerIntervalTrackBar.Value)
			{
				// Display the notification because the time interval has been reached
				NotificationTimer.Enabled = false;
				StatusBar1.Text = "Timer Notification Enabled.";
				InitNotification("Timer Notification Enabled", GetTimerNotificationHtml());
			}
		}

		// Display the number of seconds selected by the TrackBar control by updating the SecondsLabel
		private void TimerIntervalTrackBar_ValueChanged(object sender, EventArgs e)
		{
	        SecondsLabel.Text = TimerIntervalTrackBar.Value.ToString() + " s";
		}
	}
}