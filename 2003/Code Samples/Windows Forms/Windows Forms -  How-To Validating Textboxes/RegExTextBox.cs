//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

public class RegExTextBox: System.Windows.Forms.TextBox
{
    // string representation of the RegEx that will be used to 
    // validate the text in the TextBox.  This is needed because
    // the property needs to be exposed as a string to be set
    // at design time.
	protected string validationPattern;

    // Message that should be available if the text does not 
    // match the pattern.
    protected string mErrorMessage;

    // RegEx object that's used to perform the validation.
    protected Regex mValidationExpression;

    // Default color to use if the text in the TextBox is not
    // valid.
    protected Color mErrorColor = Color.Red;

    // Allow the developer to set the error message
    // at design time or run time.
    public string ErrorMessage
	{
        get {
            return mErrorMessage;
        }

        set {
            mErrorMessage = value;
        }
    }

    // if the TextBox text does not match the RegEx, then it
    // will be changed to this color.
    public Color ErrorColor
	{
        get {
            return mErrorColor;
        }

        set {
            mErrorColor = value;
        }
    }

    // Let's the developer determine if the text in the TextBox
    // is valid.
    public bool IsValid
	{
        get {
			if (mValidationExpression != null)
			{
				return mValidationExpression.IsMatch(this.Text);
			}
			else 
			{
				return true;
			}
        }
    }

    // Lets the developer specify the regular expression (as
    // a string) that will be used to validate the text in the
    // TextBox.  It's important that this be setable as a string
    // (vs. a RegEx object) so that the developer can specify 
    // the RegEx pattern using the properties window.
    public string ValidationExpression
	{
        get {
            return validationPattern;
        }

        set {
            mValidationExpression = new Regex(value);
            validationPattern = value;
        }

    }

    // if the text does not match the RegEx, then change the
    // color of the text to the ErrorColor.  if it does match
    // then make sure it's displayed using the default color.
    protected override void OnValidated(System.EventArgs e)
	{
		if (!this.IsValid)
		{
			this.ForeColor = mErrorColor;
		}
		else 
		{
			this.ForeColor = this.ForeColor;
		}

        // Any time you inherit a control, and override one of
        // the On... subs, it's critical that you call the On...
        // method of the base class, or the control won't fire
        // events like it's supposed to.
        base.OnValidated(e);
	}
}