using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

using Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdate;

namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo
{
	public partial class BackgroundUpdateDemoForm : Form
	{
		public BackgroundUpdateDemoForm()
		{
			InitializeComponent();

            this.label1.Text = "Currently Running Version = " + this.backgroundUpdater1.CurrentVersion.ToString();

            // Set UI
            this.startToolStripMenuItem.Enabled = true;
            this.stopToolStripMenuItem.Enabled = false;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			startUpdating();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stopUpdating();
		}

		private void updateIntervalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateIntervalDialog uid;

			uid = new UpdateIntervalDialog();
			uid.UpdateInterval = this.backgroundUpdater1.UpdateInterval / 60000;
			uid.ShowDialog(this);
			this.backgroundUpdater1.UpdateInterval = uid.UpdateInterval * 60000;
		}
		
		private void startUpdating()
		{
			this.startToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Enabled = true;
			this.backgroundUpdater1.Start();
		}

		private void stopUpdating()
		{
			this.startToolStripMenuItem.Enabled = true;
			this.stopToolStripMenuItem.Enabled = false;
			this.backgroundUpdater1.Stop();
		}

		private void backgroundUpdater1_UpdateCompleted(object sender, 
				BackgroundUpdate.UpdateCompletedEventArgs e)
		{
			ResourceManager rm;
			DialogResult dr;

			rm = BackgroundUpdateDemoMain.GetResourceManager();

			if (e.Error != null)
			{
				dr = MessageBox.Show(rm.GetString("msgUpdateCompletedErr")
										+ e.Error.Message,
										rm.GetString("msgUpdateCompletedErrT"),
										MessageBoxButtons.OK);
			}
			else if (e.Cancelled)
			{
				dr = MessageBox.Show(rm.GetString("msgUpdateCompletedCan"),
										rm.GetString("msgUpdateCompletedCanT"),
										MessageBoxButtons.OK);
			}
			else
			{
                // Check to see if a newer version was installed
                //if (e.UpdatedVersion > backgroundUpdater1.CurrentVersion)
                //{
                    dr = MessageBox.Show(rm.GetString("msgUpdateCompleted"),
                                        rm.GetString("msgUpdateCompletedT"),
                                        MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                //}
			}
		}
	}
}