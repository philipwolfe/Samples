using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

namespace HardwareButtonScreenOrientation
{
	public partial class Form1 : Form
	{
		// Keeps track of what next screen angle should be
		private ScreenOrientation CurrentAngle = ScreenOrientation.Angle0;
		private HardwareButton HardButton1;
		private HardwareButton HardButton2;
		private HardwareButton HardButton3;
		private HardwareButton HardButton4;
		private HardwareButton HardButton5;
		private HardwareButton HardButton6;
 
		public Form1()
		{
			// Init Controls
			InitializeComponent();

			 // Display the OK button for closing the application.
			MinimizeBox = false;

			// Anchor / Dock Controls
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((  
                System.Windows.Forms.AnchorStyles.Bottom)|  
                System.Windows.Forms.AnchorStyles.Left) |   
                System.Windows.Forms.AnchorStyles.Right)));
			InstructionsLabel.Dock = DockStyle.Top;

			// Init instructions
			InstructionsLabel.Text = "Click the buttons to rotate the screen orientation.\r\n\r\n" +
				"Click the Left or Right Hardware rocker buttons to rotate the screen orientation.\r\n\r\n" +
				"Click the other Hardware buttons and view the status bar to see which hardware buttons your device supports.";

			// Init ScreenOrientation to default Angle0 (standard portrait view)
			SetOrientation(CurrentAngle);

			// Set KeyPreview to true so that the form sees the events first
			KeyPreview = true;

			// Init the hardware buttons
			HardButton1 = new HardwareButton();
			HardButton2 = new HardwareButton();
			HardButton3 = new HardwareButton();
			HardButton4 = new HardwareButton();
			HardButton5 = new HardwareButton();
			HardButton6 = new HardwareButton();

			try
			{
				// Set the AssociatedControl property to the form
				HardButton1.AssociatedControl = this;
				HardButton2.AssociatedControl = this;
				HardButton3.AssociatedControl = this;
				HardButton4.AssociatedControl = this;
				HardButton5.AssociatedControl = this;
				HardButton6.AssociatedControl = this;
				// Init HardwareKey value to the appropriate enum value
				HardButton1.HardwareKey = HardwareKeys.ApplicationKey1;
				HardButton2.HardwareKey = HardwareKeys.ApplicationKey2;
				HardButton3.HardwareKey = HardwareKeys.ApplicationKey3;
				HardButton4.HardwareKey = HardwareKeys.ApplicationKey4;
				HardButton5.HardwareKey = HardwareKeys.ApplicationKey5;
				HardButton6.HardwareKey = HardwareKeys.ApplicationKey6;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + " Hardware button not physically available on this device.");
			}
		}
		// Set the orientation and update status bar with the current angle.
		private void SetOrientation(ScreenOrientation orientation)
		{
	        SystemSettings.ScreenOrientation = orientation;
		    StatusBar1.Text = SystemSettings.ScreenOrientation.ToString();
		}

		private void RotateClockwise()
		{
	        // init next angle value for next click
		    switch (CurrentAngle)
			{
				case ScreenOrientation.Angle90: CurrentAngle = ScreenOrientation.Angle180; break;
				case ScreenOrientation.Angle180: CurrentAngle = ScreenOrientation.Angle270; break;
				case ScreenOrientation.Angle270: CurrentAngle = ScreenOrientation.Angle0; break;
				default: CurrentAngle = ScreenOrientation.Angle90; break;
			}
			SetOrientation(CurrentAngle);
		}

		private void RotateCounterClockwise()
		{
			// init next angle value for next click
			switch (CurrentAngle)
			{
				case ScreenOrientation.Angle90: CurrentAngle = ScreenOrientation.Angle0; break;
				case ScreenOrientation.Angle180: CurrentAngle = ScreenOrientation.Angle90; break;
				case ScreenOrientation.Angle270: CurrentAngle = ScreenOrientation.Angle180; break;
				default: CurrentAngle = ScreenOrientation.Angle270; break;
			}
			SetOrientation(CurrentAngle);
		}

	    // Each click moves the screen orientation clockwise 90 degrees
		private void ClockwiseButton_Click(object sender, EventArgs e)
		{
			RotateClockwise();
		}

	    // Each click moves the screen orientation clockwise 90 degrees
		private void CounterClockwiseButton_Click(object sender, EventArgs e)
		{
			RotateCounterClockwise();
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			// Determine which hardware key was pressed.  Note that not all application keys are supported
			// on every emulator or device, yet all are implemented here to assist in determining what your
			// emulator or device supports.
			switch ((HardwareKeys) e.KeyCode)
			{
				case HardwareKeys.ApplicationKey1: StatusBar1.Text = "ApplicationKey1"; break;
				case HardwareKeys.ApplicationKey2 : StatusBar1.Text = "ApplicationKey2"; break;
				case HardwareKeys.ApplicationKey3: StatusBar1.Text = "ApplicationKey3"; break;
				case HardwareKeys.ApplicationKey4: StatusBar1.Text = "ApplicationKey4"; break;
				case HardwareKeys.ApplicationKey5: StatusBar1.Text = "ApplicationKey5"; break;
				case HardwareKeys.ApplicationKey6: StatusBar1.Text = "ApplicationKey6"; break;
			}

			// Process the left and right arrow keys
			if (e.KeyCode == System.Windows.Forms.Keys.Left)
			{
				RotateCounterClockwise();
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Right)
			{
				RotateClockwise();
			}
			e.Handled = true; // mark event as handled here
		}

	}
}