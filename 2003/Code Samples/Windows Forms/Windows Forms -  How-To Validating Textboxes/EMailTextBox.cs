//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Text.RegularExpressions;

public class EMailTextBox: RegExTextBox
{
	// The various validating textboxes all inherit RegExTextBox
    // which can varify that the contents of any TextBox match
    // a regular expression.
    
	public EMailTextBox() 
	{        
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        
		//Add any initialization after the InitializeComponent() call

		// set {a default value for the ValidationExpression so
        // that this control will validate that the contents of
        // the TextBox look like an e-mail address.

        this.ValidationExpression = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";
        this.ErrorMessage = "The e-mail address must be in the form of abc@microsoft.com";
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
    private void InitializeComponent() 
	{
        components = new System.ComponentModel.Container();
    }

#endregion
}