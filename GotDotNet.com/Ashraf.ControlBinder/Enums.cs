using System;

namespace Ashraf
{
	/// <summary>
	/// This enum is used to indicate the display name of the extra field that should be inserted into a dropdown list.
	/// Date Written: 29-10-2005;
	/// Written By: Mohammad Ashraful Alam [ joy_csharp@hotmail.com ]
	/// Last Update: Mar 24, 2006
	/// </summary>
	public enum TopField 
	{ 
		/// <summary>
		/// No specific text should be inserted for the list control, as the default item.
		/// </summary>
		NoTopField = 0, 
		/// <summary>
		/// 'None' will be displayed as the first item of the list control, which will also trated as the default item/ 'required' check item.
		/// </summary>
		None, 
		/// <summary>
		/// 'All' will be displayed as the first item of the list control.
		/// </summary>
		All 
		
	}
}
