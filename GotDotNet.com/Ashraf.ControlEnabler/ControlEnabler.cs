using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Ashraf
{
	/// <summary>
	/// Utility class that contains the utility methods for a ASP.NET page.
	/// Date Written: 29-10-2005; Date Modified: 02-11-200
	/// </summary>
	public class ControlEnabler
	{

		#region Page Control Enabling / Disabling Utility

		/// <summary>
		/// Sets ALL the controls of the page enabled or disabled.
		/// These includes asp.net server controls [ TextBox, CheckBox, Button, ImageButton, LinkButton, DropdownList, ListBox, ASP.NET all validation controls ]
		/// as well as html server controls [ HtmlInputText, HtmlTextArea, HtmlInputCheckBox, HtmlSelect, HtmlButton ]
		/// Date Written: 02-11-2005; Date Modified: 
		/// </summary>
		/// <param name="page">The page for which the enabling/ disabling operatin will be implied.</param>
		/// <param name="isEnable"></param>
		public static void SetControlsEnabled(Control page, bool isEnable)
		{
			SetControlsEnabled(page, ControlName.All, isEnable);
		}

		/// <summary>
		/// Sets the specified controls of the page enabled or disabled.
		/// These includes asp.net server controls [ TextBox, CheckBox, Button, ImageButton, LinkButton, DropdownList, ListBox, ASP.NET all validation controls ]
		/// as well as html server controls [ HtmlInputText, HtmlTextArea, HtmlInputCheckBox, HtmlSelect, HtmlButton ]
		/// Date Written: 02-11-2005; Date Modified: 
		/// </summary>
		/// <param name="page">The page for which the enabling/ disabling operatin will be implied.</param>
		/// <param name="controlName">The name of the control</param>
		/// <param name="isEnable"></param>
		public static void SetControlsEnabled(Control page, ControlName controlName, bool isEnable)

		{

			foreach (Control ctrl in page.Controls)
			{

				//==================== considering asp.net server controls ==================
				
				//Text Boxes
				if ( ctrl is TextBox && ( controlName == ControlName.TextBox || controlName == ControlName.All )  )
					((TextBox)(ctrl)).Enabled = isEnable;
				
				//Check Boxes
				if ( ctrl is  CheckBox && ( controlName == ControlName.CheckBox  || controlName == ControlName.All ) )
					((CheckBox)(ctrl)).Enabled = isEnable;
				
				//Buttons
				if ( ctrl is Button && ( controlName == ControlName.Button  || controlName == ControlName.All ) )
					((Button)(ctrl)).Enabled = isEnable;
				if ( ctrl is ImageButton && ( controlName == ControlName.Button  || controlName == ControlName.All ) )
					((ImageButton)(ctrl)).Enabled = isEnable;
				if ( ctrl is LinkButton && ( controlName == ControlName.Button  || controlName == ControlName.All ) )
					((LinkButton)(ctrl)).Enabled = isEnable;
				
				//List Controls
				if ( ctrl is DropDownList && ( controlName == ControlName.ListControl  || controlName == ControlName.All ) )
					((DropDownList)(ctrl)).Enabled = isEnable;
				if ( ctrl is ListBox && ( controlName == ControlName.ListControl  || controlName == ControlName.All ) )
					((ListBox)(ctrl)).Enabled = isEnable;

				//Validators
				if ( ctrl is RegularExpressionValidator && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((RegularExpressionValidator)(ctrl)).Enabled = isEnable;
				if ( ctrl is RequiredFieldValidator && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((RequiredFieldValidator)(ctrl)).Enabled = isEnable;
				if ( ctrl is CompareValidator && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((CompareValidator)(ctrl)).Enabled = isEnable;
				if ( ctrl is RangeValidator && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((RangeValidator)(ctrl)).Enabled = isEnable;
				if ( ctrl is CustomValidator && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((CustomValidator)(ctrl)).Enabled = isEnable;
				if ( ctrl is ValidationSummary && ( controlName == ControlName.Validator  || controlName == ControlName.All ) )
					((ValidationSummary)(ctrl)).Enabled = isEnable;
				
				
				//================== considering html server controls ==================
				
				//Text Boxes
				if ( ctrl is HtmlInputText && ( controlName == ControlName.TextBox  || controlName == ControlName.All ) )
					((HtmlInputText)(ctrl)).Disabled = ! isEnable;
				if ( ctrl is HtmlTextArea && ( controlName == ControlName.TextBox  || controlName == ControlName.All ) )
					((HtmlTextArea)(ctrl)).Disabled = ! isEnable;
				//Check Boxes
				if ( ctrl is HtmlInputCheckBox && ( controlName == ControlName.CheckBox  || controlName == ControlName.All ) )
					((HtmlInputCheckBox)(ctrl)).Disabled = ! isEnable;
				//Dropdown Lists
				if ( ctrl is HtmlSelect && ( controlName == ControlName.ListControl  || controlName == ControlName.All ) )
					((HtmlSelect)(ctrl)).Disabled = ! isEnable;
				//Buttons
				if ( ctrl is HtmlInputButton && ( controlName == ControlName.Button  || controlName == ControlName.All ) )
					((HtmlInputButton)(ctrl)).Disabled = ! isEnable;
				
				//=================== RECURSION =======================================
				
				//if the number of child controls is greater than zero then the current function is called recursively.
				//otherwise the recursion ends.
				if (ctrl.Controls.Count > 0)

				{
					SetControlsEnabled(ctrl, controlName, isEnable);
				}
			}
		}

		/// <summary>
		/// Sets all the textbox controls of the page read only, according to the passed parameter.
		/// These includes asp.net server controls [ TextBox].
		/// as well as html server controls [ HtmlInputText, HtmlTextArea ].
		/// For html textbox controls this is set to disabled/ enabled.
		/// Date Written: 02-11-2005; Date Modified: 
		/// </summary>
		/// <param name="page">The container page for which the textboxes will be considered.</param>
		/// <param name="isReadOnly">Whtether the textbox control should be in read-only mode.</param>
		public static void SetTextBoxReadOnly(Control page, bool isReadOnly)
		{
			
			foreach (Control ctrl in page.Controls)
			{

				//considering asp.net server controls
				if ( ctrl is TextBox)
					((TextBox)(ctrl)).ReadOnly = isReadOnly;
			
				//considering html server controls
				if ( ctrl is HtmlInputText)
					((HtmlInputText)(ctrl)).Disabled = isReadOnly;
				if ( ctrl is HtmlTextArea )
					((HtmlTextArea)(ctrl)).Disabled = isReadOnly;
				
				//if the number of child controls is greater than zero then the current function is called recursively.
				//otherwise the recursion ends.
				if (ctrl.Controls.Count > 0)

				{
					SetTextBoxReadOnly(ctrl, isReadOnly);
				}
			}
		}

		/// <summary>
		/// Sets the text box to label view.
		/// </summary>
		/// <param name="page">The container page for which the textboxes will be considered.</param>
		/// <param name="isToLabelView">if set to <c>true</c> [is to label view].</param>
		public static void SetTextBoxToLabelView(Control page, bool isToLabelView)
		{
			
			foreach (Control ctrl in page.Controls)
			{

				//considering asp.net server controls
				if ( ctrl is TextBox)
					((TextBox)(ctrl)).BorderWidth = (isToLabelView ? 0: 1);
			
				//if the number of child controls is greater than zero then the current function is called recursively.
				//otherwise the recursion ends.
				if (ctrl.Controls.Count > 0)

				{
					SetTextBoxReadOnly(ctrl, isToLabelView );
				}
			}
		}

		#endregion

		#region Test / Sampler Code 
		
		/// <summary>
		/// This is the tester class of the current parent class, which contains the sample code snippets to use this class properly in the real-world scenaris.
		/// </summary>
		/// <remarks>This class should NOT be present in the class doc.</remarks>
		class Tester
		{
			Tester()
			{
//				//### resetting the page 
//				Utils.PageUtils.ResetToCurrentPage();
//
//				//### setting page initial focus
//				Utils.PageUtils.SetInitialFocus(txtFirstName);

			}
		}

		#endregion
	
	}
}