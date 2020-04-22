using System;
using System.Drawing;
using System.Windows.Forms;

namespace openglFramework
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ToggleButton : CheckBox
	{
		public ToggleButton()
		{
			// Make the check box appear like a toggle button.
			this.Appearance = Appearance.Button;

			// Center the text on the button.
			this.TextAlign = ContentAlignment.MiddleCenter;
		}

	}

}
