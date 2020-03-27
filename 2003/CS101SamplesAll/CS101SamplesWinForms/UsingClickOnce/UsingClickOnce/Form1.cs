using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace UsingClickOnce
{
	public partial class Form1 : Form
	{
		private System.Deployment.Application.ApplicationDeployment appDeployment;

		public Form1()
		{
			InitializeComponent();

			// Retrieve the current deployment.
			// An InvalidDeploymentException is thrown if the application hasn't been deployed
			// as, for instance, when running in debug mode.
			try
			{
				appDeployment = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;

				// Add event handlers for asynchronous operations

				// Handler for when an asynchronous check for updates completes
				appDeployment.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(appDeployment_CheckForUpdateCompleted);
				// Handler for asynchronous checks progress reports
				appDeployment.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(appDeployment_CheckForUpdateProgressChanged);

				// Handler for when an asynchronous update completes
				appDeployment.UpdateCompleted += new AsyncCompletedEventHandler(appDeployment_UpdateCompleted);
				// Handler for asynchronous update progress reports
				appDeployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(appDeployment_UpdateProgressChanged);

			}
			catch (System.Deployment.Application.DeploymentException)
			{
				MessageBox.Show(this, "This sample will not run in debug mode.  In Visual Studio 2005, use ClickOnce to deploy the compiled sample, then run the sample.  View the sample ReadMe for details.", this.Text);
			}

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// appDeployment == null if running in Visual Studio 2005.
			// This sample will not run in Visual Studio 2005.  
			if (appDeployment != null)
			{
				// Display the version number
				// The ApplicationDeployment.CurrentVersion is the version
				// in the Publish tab of the Project Properties window.
				this.versionLabel.Text += appDeployment.CurrentVersion.ToString();

				// Display when the application last checked for an update.
				// Time is given in Universal Time.
				this.timeOfLastCheckLabel.Text += appDeployment.TimeOfLastUpdateCheck.ToString();
			}
		}

		public void FeedbackNoUpdateAvailable()
		{
			// Provide feedback that no update is available
			MessageBox.Show(this, "The application is up to date.", "No update available.");
		}

		public void FeedbackUpdateAvailable(Version availableVersion, bool isUpdateRequired, Version minimumRequiredVersion, long updateSizeBytes)
		{
			// Provide details about the available update
			StringBuilder message = new StringBuilder();
			message.AppendLine("An update is available.");
			message.AppendLine("Details:");
			message.AppendLine("   Available version: " + availableVersion.ToString());
			message.AppendLine("   The update is " + (isUpdateRequired ? " " : "not ") + "required.");
			if (minimumRequiredVersion == null)
				message.AppendLine("   Minimum version required: None");
			else
				message.AppendLine("   Minimum version required: " + minimumRequiredVersion.ToString());
			message.AppendLine("   Update size: " + updateSizeBytes.ToString() + " bytes");

			MessageBox.Show(this, message.ToString(), "Update available.");
		}

		public void QueryRestart()
		{
			// Once an update has been installed,
			// the application must be restarted to see the new version.
			// Query the user to restart now.  If don't restart now,
			// the next time the application is run, it will install the update.
			if (DialogResult.Yes == MessageBox.Show("The application must be restarted to see the changes.  You can restart now, or continue working and restart it later.  Restart now?", "Restart Application?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
			{
				Application.Restart();
			}
		}

		public void ShowError(Exception ex)
		{
			MessageBox.Show("The following error occurred: " + ex.Message, ex.GetType().ToString());
		}

		private void checkForUpdatesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// There are two methods for checking for updates synchronously:
			//   CheckForUpdate()
			//   CheckForDetailedUpdate()
			// This sample uses CheckForDetailedUpdate().

			// CheckForUpdate() checks for an update, but retrieves no details, 
			// and returns a boolean indicating whether an update is available.
			// Use CheckForUpdate() if details are not desired.
			//MessageBox.Show("An update is " + (appDeployment.CheckForUpdate() ? "" : "not ") + "available.");

			// CheckForDetailedUpdate() checks for an update, and retrieves details about it
			try
			{
				UpdateCheckInfo updateInfo = appDeployment.CheckForDetailedUpdate();
				if (updateInfo.UpdateAvailable)
					FeedbackUpdateAvailable(updateInfo.AvailableVersion, updateInfo.IsUpdateRequired, updateInfo.MinimumRequiredVersion, updateInfo.UpdateSizeBytes);
				else
					FeedbackNoUpdateAvailable();
			}
			catch (System.Deployment.Application.DeploymentException deployEx)
			{
				ShowError(deployEx);
			}
			catch (InvalidOperationException invalidEx)
			{
				// If an Async operation is already in place,
				// an InvalidOperationException will be thrown.
				ShowError(invalidEx);
			}
			catch (ApplicationException ex)
			{
				ShowError(ex);
			}

		}

		private void asyncCheckForUpdatesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			asyncCheckStatusLabel.Text = "Checking...";

			try
			{
				// Initiate an asynchronous process to check for application updates
				appDeployment.CheckForUpdateAsync();
			}
			catch (System.Deployment.Application.DeploymentException deployEx)
			{
				ShowError(deployEx);
			}
			catch (InvalidOperationException invalidEx)
			{
				// If an Async operation is already in place,
				// an InvalidOperationException will be thrown.
				ShowError(invalidEx);
			}
			catch (ApplicationException ex)
			{
				ShowError(ex);
			}

		}

		private void stopAsyncCheckLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Cancel the asynchronous check for application updates
			appDeployment.CheckForUpdateAsyncCancel();
		}

		private void updateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				// Synchronously update the application
				if (!appDeployment.Update())
				{
					// ApplicationDeployment.Update() will return false if no update is available.
					// 
					FeedbackNoUpdateAvailable();
				}
				else
				{
					// The update has been installed
					// Must restart the application to see the update
					QueryRestart();
				}
			}
			catch (System.Deployment.Application.DeploymentException deployEx)
			{
				ShowError(deployEx);
			}
			catch (InvalidOperationException invalidEx)
			{
				// If an Async operation is already in place,
				// an InvalidOperationException will be thrown.
				ShowError(invalidEx);
			}
			catch (ApplicationException ex)
			{
				ShowError(ex);
			}


		}

		private void updateAsyncLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			asyncUpdateStatusLabel.Text = "Updating...";

			try
			{
				// Initiate asynchronous process to update the application
				appDeployment.UpdateAsync();
			}
			catch (System.Deployment.Application.DeploymentException deployEx)
			{
				ShowError(deployEx);
			}
			catch (InvalidOperationException invalidEx)
			{
				// If an Async operation is already in place,
				// an InvalidOperationException will be thrown.
				ShowError(invalidEx);
			}
			catch (ApplicationException ex)
			{
				ShowError(ex);
			}

		}

		private void appDeployment_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
		{
			// Report progress on the asynchronous Update
			asyncUpdateStatusLabel.Text = e.ProgressPercentage.ToString() + "% " + "[" + e.BytesCompleted.ToString() + " bytes]";
		}

		private void appDeployment_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
		{
			// Asynchronous update complete.  Report results.
			// An update download can be cancelled...
			if (e.Cancelled)
			{
				asyncUpdateStatusLabel.Text = "Cancelled.";
			}
			// complete with errors...
			else if (e.Error != null)
			{
				asyncCheckStatusLabel.Text = "ERROR: " + e.Error.Message;
			}
			// or complete successfully
			else
			{
				asyncCheckStatusLabel.Text = "Complete.";

				// UpdateAsync() will indicate success even if no
				// update is available.  Use ApplicationDeployment.UpdatedVersion
				// to check the versions.
				if (appDeployment.UpdatedVersion == appDeployment.CurrentVersion)
					FeedbackNoUpdateAvailable();
				else
				{
					// Must restart the application to see the changes
					QueryRestart();
				}
			}

		}

		private void appDeployment_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
		{
			// Report progress on the asynchronous CheckForUpdate call
			asyncCheckStatusLabel.Text = e.ProgressPercentage.ToString() + "% " + "[" + e.BytesCompleted.ToString() + " bytes]";
		}

		private void appDeployment_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
		{
			// Asynchronous CheckForUpdate call complete.  Report results.
			// CheckForUpdateAsync can be cancelled...
			if (e.Cancelled)
			{
				asyncCheckStatusLabel.Text = "Cancelled.";
			}
			// complete with errors...
			else if (e.Error != null)
			{
				asyncCheckStatusLabel.Text = "ERROR: " + e.Error.Message;
			}
			// or complete successfully
			else
			{
				asyncCheckStatusLabel.Text = "Complete.";

				// Provide details on results of the check
				if (e.UpdateAvailable)
				{
					FeedbackUpdateAvailable(e.AvailableVersion, e.IsUpdateRequired, e.MinimumRequiredVersion, e.UpdateSizeBytes);
				}
				else
				{
					FeedbackNoUpdateAvailable();
				}
			}

		}

		private void stopAsyncUpdateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Cancel the asynchronous update.
			appDeployment.UpdateAsyncCancel();
		}

	}
}