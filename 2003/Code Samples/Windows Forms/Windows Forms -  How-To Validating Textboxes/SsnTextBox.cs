//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Text.RegularExpressions;

public class SsnTextBox: RegExTextBox
{
    // The various validating textboxes all inherit RegExTextBox
    // which can varify that the contents of any TextBox match
    // a regular expression.

    public SsnTextBox() 
	{       
        //This call is required by the Windows Form Designer.
        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
        // set a default value for the ValidationExpression so
        // that this control will validate that the contents of
        // the TextBox look like a social security number.

        this.ValidationExpression = @"^\d{3}-\d{2}-\d{4}$";
        this.ErrorMessage = "The social security number must be in the form of 555-55-5555";
    }

#region " Windows Form Designer generated code "

    //UserControl overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
	{
		if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private void InitializeComponent() {
        components = new System.ComponentModel.Container();
    }

#endregion
}
