using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

namespace HandleScreenOrientation
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Display the OK button for closing the application.
			MinimizeBox = false;

			// Init ScreenOrientation to default Angle0 (standard portrait view)
			// by setting the index to 0
			OrientationComboBox.SelectedIndex = 0;
		}

		private void ChangeOrientation(ScreenOrientation orientation)
		{
			// Set Orientation
			SystemSettings.ScreenOrientation = orientation;

			// Calculate the height of TextBox2 based on the ClientRectangle and the 2 panels
			// so that the Textbox uses all available space.
			TextBox2.Height = ClientRectangle.Height - Panel1.Height - Panel2.Height;
		}

		private void OrientationComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (OrientationComboBox.SelectedIndex == 1)
			{
				// Landscape
				ChangeOrientation(ScreenOrientation.Angle90);
			}
			else
			{
				// Portrait (default anything other than value of 1 to portrait)
				ChangeOrientation(ScreenOrientation.Angle0);
			}
		}
	}
}