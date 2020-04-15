//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

public class frmProtected: System.Windows.Forms.Form 
{
	#region " Windows Form Designer generated code "

	public frmProtected() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
		if (disposing) 
		{
			if (components != null) 
			{
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
	internal System.Windows.Forms.TextBox txtProtected;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProtected));

		this.txtProtected = new System.Windows.Forms.TextBox();

		this.SuspendLayout();

		//

		//txtProtected

		//

		this.txtProtected.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtProtected.Multiline = true;

		this.txtProtected.Name = "txtProtected";

		this.txtProtected.Size = new System.Drawing.Size(268, 112);

		this.txtProtected.TabIndex = 0;

		this.txtProtected.Text = "";

		//

		//frmProtected

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(264, 106);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtProtected});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.Name = "frmProtected";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "protected Form";

		this.ResumeLayout(false);
	}
	#endregion
}

