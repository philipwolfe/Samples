//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public partial class SplitButtonColorPickerForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.colorPickerToolStrip1 = new SplitButtonColorPickerToolStrip(this);
            this.SuspendLayout();
// 
// colorPickerToolStrip1
// 
            this.colorPickerToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.colorPickerToolStrip1.Name = "colorPickerToolStrip1";
            this.colorPickerToolStrip1.TabIndex = 0;
            this.colorPickerToolStrip1.Text = "colorPickerToolStrip1";
// 
// Form1
// 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(319, 293);
            this.Controls.Add(this.colorPickerToolStrip1);
            this.Name = "Form1";
            this.Text = "ColorPicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

        private SplitButtonColorPickerToolStrip colorPickerToolStrip1;
    }
}

