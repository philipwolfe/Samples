using System;

namespace Ashraf
{
	/// <summary>
	/// This enum is used to indicate the type of control [ considering both asp.net and html server control ]
	/// Date Written: 02-11-2005; Date Modified: 
	/// </summary>
	public enum ControlName 
	{ 
		/// <summary>
		/// Includes asp.net button, image button, link button, html button.
		/// </summary>
		Button, 
		/// <summary>
		/// Includes asp.net text box, html input text, html text area server controls.
		/// </summary>
		TextBox, 
		/// <summary>
		/// Includes asp.net check box and html input check box.
		/// </summary>
		CheckBox, 
		/// <summary>
		///	Includes asp.net drop down list, list box, html select.
		/// </summary>
		ListControl, 
		/// <summary>
		/// Includes asp.net validators.
		/// </summary>
		Validator, 
		/// <summary>
		/// All the controls that are defined in this enum.
		/// </summary>
		All 
	}
}
