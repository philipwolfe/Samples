using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace DriveInfoSample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.driveReadyStatus.Text = "";

			// Get a DriveInfo object for each drive on the system
			DriveInfo[] drives = DriveInfo.GetDrives();

			// Populate the drives combo box with all drives
			drivesOnPc.Items.AddRange(drives);
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			// Rectangle to define size of Pie Chart
			Rectangle rect = new Rectangle(370, 20, 200, 200);

			// Rectangle to use as a border around Pie Chart
			Rectangle rect2 = new Rectangle(310, 10, 320, 320);

			// Rectangles for color legend
			Rectangle freeLegend = new Rectangle(315, 275, 20, 20);
			Rectangle usedLegend = new Rectangle(315, 300, 20, 20);

			// Draw Border
			e.Graphics.DrawRectangle(Pens.Black, rect2);

			if (isSpaceInfoAvailable == true)
			{
				// Draw Pie Chart
				e.Graphics.FillPie(Brushes.Green, rect, 0, sweep);
				e.Graphics.FillPie(Brushes.Red, rect, sweep, 360 - sweep);

				// Draw Legend
				e.Graphics.FillRectangle(Brushes.Green, freeLegend);
				e.Graphics.FillRectangle(Brushes.Red, usedLegend);

				// Add text
				e.Graphics.DrawString("Capacity:", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(350, 230));
				e.Graphics.DrawString("Used Space:", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(335, 275));
				e.Graphics.DrawString("Free Space:", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(335, 300));
				e.Graphics.DrawString(totalSpace.ToString("N") + " bytes", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(420, 230));
				e.Graphics.DrawString(usedSpace.ToString("N") + " bytes", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(420, 275));
				e.Graphics.DrawString(freeSpace.ToString("N") + " bytes", new Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, new PointF(420, 300));
			}
		}

		private void drivesOnPc_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Determine drive info for selected drive letter
			LoadDriveInfo(drivesOnPc.Items[drivesOnPc.SelectedIndex].ToString());

			// Redraw the pie chart
			this.Invalidate();
		}

		private void LoadDriveInfo(string driveLetter)
		{
			// Use the DriveInfo class to obtain information on drives. 
			// Drive name must be either an upper or lower case letter from 'a' to 'z'. 
			// You can not use this method to obtain information on drive names that are null or use UNC (\\server\share) paths.

			DriveInfo driveInfo;

			// Check for valid drive names
			try
			{
				driveInfo = new DriveInfo(driveLetter);
			}
			catch (ArgumentNullException ex1)
			{
				MessageBox.Show("The drive letter can not be null./n/r" + ex1.Message, "Drive Letter error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (ArgumentException ex2)
			{
				MessageBox.Show("The drive letter must be in the range of a-z./n/r" + ex2.Message, "Drive Letter error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.driveName.Text = driveInfo.Name;

			// Some drives do not provide all of the info
			// have to trap for exceptions and just move on to the next drive
			try
			{
				if (driveInfo.VolumeLabel.Length > 0)
					this.driveVolumeLabel.Text = driveInfo.VolumeLabel;
				else
					this.driveVolumeLabel.Text = "None";

				this.driveFormat.Text = driveInfo.DriveFormat;

				totalSpace = driveInfo.TotalSize;
				freeSpace = driveInfo.TotalFreeSpace;
				usedSpace = totalSpace - freeSpace;
				sweep = 360f * freeSpace / totalSpace;

				isSpaceInfoAvailable = true;
			}
			catch
			{
				this.driveVolumeLabel.Text = "Not available";
				this.driveFormat.Text = "Not available";

				isSpaceInfoAvailable = false;
			}

			this.driveType.Text = driveInfo.DriveType.ToString();

			this.driveRootDirectory.Text = driveInfo.RootDirectory.ToString();
			dirInfo = driveInfo.RootDirectory;


			if (driveInfo.IsReady == true)
				this.driveReadyStatus.Text = "Drive is Ready";
			else
				this.driveReadyStatus.Text = "Drive is NOT Ready";
		}

		private string ConvertBytesToMB(Int64 bytes)
		{
			long mb = bytes / 1048576;
			return mb.ToString("N");
		}

		private string ConvertBytesToGB(Int64 bytes)
		{
			long gb = bytes / 1073741824;
			return gb.ToString("N");
		}


		private DirectoryInfo dirInfo;
		private long totalSpace;
		private long freeSpace;
		private long usedSpace;
		private float sweep;
		private bool isSpaceInfoAvailable;
	}
}