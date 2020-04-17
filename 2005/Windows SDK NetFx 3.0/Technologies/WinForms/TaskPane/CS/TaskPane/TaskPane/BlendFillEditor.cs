//=====================================================================
//  File:      BlendFillEditor.cs
//
//  Summary:   Provides more of the Design time functionality of the 
//             BlendFill class by implementing a UI Type Editor for the
//             property browser in the IDE.
//
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
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Windows.Forms.ComponentModel;


namespace Microsoft.Samples.Windows.Forms.TaskPane.Design
{
    //=------------------------------------------------------------------=
    // BlendFillEditor
    //=------------------------------------------------------------------=
    /// <summary>
    ///   This is a drop down editor for the BlendFill type, which gives us a 
    ///   cool way to show the various ways to blend as well as let the user
    ///   select the colors to blend.
    /// </summary>
    /// 
	[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
	public class BlendFillEditor :
        UITypeEditor
    {


        //=------------------------------------------------------------------=
        // GetEditStyle
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We use this method to indicate that we're going to be using a
        ///   drop down editor for our value.
        /// </summary>
        /// 
        public override UITypeEditorEditStyle GetEditStyle
        (
            ITypeDescriptorContext context
        )
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }

            return base.GetEditStyle(context);
        } 



        //=------------------------------------------------------------------=
        // EditValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Instructs us to pop up our dropdown editor and let the user
        ///   edit the value for this class.
        /// </summary>
        ///
        public override object EditValue
        (
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value
        )
        {
            IWindowsFormsEditorService editorService;
            BlendFillEditorUI editor;
            bool reverse;
            BlendFill blend;

            if (context != null 
                && context.Instance != null 
                && provider != null)
            {
                editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null)
                {

                    //
                    // get the current values and create an editor
                    //
                    blend = (BlendFill) value;
                    reverse = getReverseValue(context);
                    editor = new BlendFillEditorUI(editorService, blend, reverse);

                    //
                    // Now use the host service to show the editor.
                    //
                    editorService.DropDownControl(editor);

                    //
                    // Finally, get the new value and return it.
                    //
                    value = editor.GetValue();
                }
            }

            return value;
        }


        //=------------------------------------------------------------------=
        // GetPaintValueSupported
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We want to support cool painting in the property browser.
        /// </summary>
        /// 
        public override bool GetPaintValueSupported
        (
            ITypeDescriptorContext context
        )
        {
            return true;
        }


        //=------------------------------------------------------------------=
        // PaintValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Paints our cool value in the property browser.
        /// </summary>
        /// 
        public override void PaintValue(PaintValueEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush lgb;
            BlendFill bf;

            lgb = null;

            //
            // i'm going to be quite surprised if they give us something 
            // that ISN'T a BlendFill, but it's worth checking, just to be
            // safe.
            //
            if (e.Value is BlendFill)
            {
                bf = (BlendFill) e.Value;
            }
            else
            {
                bf = null;
            }

            if (bf != null)
            {
                try
                {
                    lgb = bf.GetLinearGradientBrush(e.Bounds);

                    e.Graphics.FillRectangle(lgb, e.Bounds);
                }
                finally
                {
                    if (lgb != null)
                    {
                        lgb.Dispose();
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("BlendFillEditor.Paint: " +
                      "Curious:  We've been asked to paint something " +
                      "that's not a BlendFill: "+e.Value.GetType().ToString());
            }
        }








        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Private Methods/Functions/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // getReverseValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Indicates whether or not the given instance behind this editor
        ///   has RightToLeft reading set to true.
        /// </summary>
        /// 
        private bool getReverseValue(ITypeDescriptorContext context)
        {
            PropertyDescriptorCollection pdc;
            PropertyDescriptor pd;
            Control ctl = null;
            RightToLeft rtl;

            //
            // We have to look at context.Instance, and see if it has a 
            // property named "RightToLeft".  If so, then use that value,
            // otherwise, just assume no RTL.
            //
            if (context != null)
            {
                if (context.Instance != null)

                {
                    //
                    // Look through its properties.
                    //
                    pdc = TypeDescriptor.GetProperties(context.Instance);
                    if (pdc != null)
                    {
                        pd = pdc["RightToLeft"];
                        rtl = (RightToLeft) pd.GetValue(context.Instance);
                        
                        try
                        {
                            ctl = (Control) context.Instance;
                        }
                        catch
                        {
                        }

                        if (ctl != null)
                        {
                            return MiscFunctions.GetRightToLeftValue(ctl);
                        }
                        else
                        {
                            return rtl != RightToLeft.No;
                        }
                    }
                }
            }

            return false;
        }
    }

}

