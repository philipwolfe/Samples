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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public partial class DesignerVisibilityForm : Form
    {
        public DesignerVisibilityForm()
        {
            InitializeComponent();
        }
    }

    // Changing the lists the item appears in:
    // By default, if you inherit from a class, the base class attributes will be inherited.  E.g. if you inherit from a ToolStripButton, the custom item will show up in all the same lists as the ToolStripButton.  
    // To change this behavior, use the ToolStripItemDesignerAvailabilityAttribute (System.Windows.Forms.Design).

    // Changing the Bitmap and Display Name:

    // Specify a bitmap only:
    //
    //-	Add a bitmap to the project – in this case named “CustomToolStripButtonImage.bmp”
    //-	Select the bitmap in the solution explorer
    //-	In the property grid, switch the build action type to Embedded Resource 
    //-	Add a ToolboxBitmap attribute above the class (in System.Drawing.Design)
    //
    //  [ToolboxBitmap(typeof(CustomToolStripButton), "CustomToolStripButtonImage.bmp")]
    //

    // Change the bitmap and the display text:
    //
    // 1. Add a bitmap to the project – in this case named “CustomToolStripButtonImage.bmp”
    // 2. Select the bitmap in the solution explorer
    // 3. In the property grid, switch the build action type to Embedded Resource 
    // 4. Add a class called CustomControlToolboxItem which inherits from ToolboxItem. 
    // 5. Override Initialize, call base and set the DisplayName and Bitmap properties.
    // 6. Add a ToolboxItem attribute above the class, specifying the full name of the type of ToolBoxItem you’ve created. 
    //
    // [ToolboxItem("ToolStripDesignerAttribute.CustomControlToolboxItem")]
    //

    //[ToolboxItem("CustomControlToolboxItem")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    [ToolboxBitmap(typeof(CustomToolStripButton), "Resources.CustomToolStripButton.bmp")]
    public class CustomToolStripButton : ToolStripButton
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(Color.Red);
        }
    }

    [ToolboxBitmap(typeof(CustomToolStripMenuItem), "Resources.CustomToolStripMenuItem.bmp")]
    public class CustomToolStripMenuItem : ToolStripMenuItem
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(Color.Green);
        }
    }


    [ToolboxBitmap(typeof(CustomStatusStripLabel), "Resources.CustomToolStripStatusLabel.bmp")]
    public class CustomStatusStripLabel : ToolStripStatusLabel
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(Color.CornflowerBlue);
        }
    }




    public class CustomControlToolboxItem : ToolboxItem
    {
        public CustomControlToolboxItem()
        {
        }

        public override void Initialize(Type type)
        {
            base.Initialize(type);
 ////           this.Description = "Descriptive Text for Custom ToolStrip Button";
 ////           this.DisplayName = "Display Text for Custom ToolStrip Button";
 //           this.Bitmap = new Bitmap(typeof(CustomControlToolboxItem), "Resources.CustomToolStripButton.bmp");
       }
    }
}