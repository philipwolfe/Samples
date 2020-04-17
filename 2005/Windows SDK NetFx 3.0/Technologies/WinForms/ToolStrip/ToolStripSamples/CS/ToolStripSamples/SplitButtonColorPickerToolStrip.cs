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
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

#endregion

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public class SplitButtonColorPickerToolStrip : System.Windows.Forms.ToolStrip
    {

        public SplitButtonColorPickerToolStrip(Form parentForm)
        {
            this.Items.Add(new SplitButtonColorPicker(false, parentForm));
            this.Items.Add(new SplitButtonColorPicker(true, parentForm));
        }

    }

    class SplitButtonColorPicker : System.Windows.Forms.ToolStripSplitButton
    {
        private int dropDownColumnCountValue = 4;
        public bool createMenu;
        private Form parentForm;

        public SplitButtonColorPicker(bool createMenu, Form parentForm)
        {
            ParentForm = parentForm;
            this.createMenu = createMenu;


            if (createMenu)
            {
                this.DropDown = createToolStripDropDownMenu();
                this.Text = "ProColors &Menu";
            }
            else
            {
                this.DropDown = createToolStripDropDown();
                this.Text = "ProColors &DropDown";
            }

            this.DropDownItemClicked += new ToolStripItemClickedEventHandler(SplitButtonColorPicker_DropDownItemClicked);
        }

        public Form ParentForm
        {
            get
            {
                return parentForm;
            }
            set
            {
                parentForm = value;
            }
        }

        private ToolStripDropDownMenu createToolStripDropDownMenu()
        {
            ToolStripDropDownMenu tsddm = new ToolStripDropDownMenu();
            PopulateDropDown(tsddm);

            return tsddm;
        }

        private ToolStripDropDown createToolStripDropDown()
        {
            ToolStripDropDown tsdd = new ToolStripDropDown();
            PopulateDropDown(tsdd);
            tsdd.LayoutStyle = ToolStripLayoutStyle.Table;
            TableLayoutSettings tableLayoutSettings = (TableLayoutSettings)(tsdd.LayoutSettings);
            tableLayoutSettings.ColumnCount = dropDownColumnCountValue;

            return tsdd;
        }

        public int dropDownColumnCount
        {
            get
            {
                return dropDownColumnCountValue;
            }
            set
            {
                dropDownColumnCountValue = value;
            }
        }

        private void PopulateDropDown(ToolStripDropDown dd)
        {
            // start with array of colors
            PropertyInfo[] props = typeof(ProfessionalColors).GetProperties();

            foreach (PropertyInfo prop in props)
            {
                try
                {
                    // build a bitmap based on the color
                    Color c = (Color)(prop.GetValue(new System.Windows.Forms.ProfessionalColorTable(), null));
                    Bitmap bitmap = new Bitmap(32, 32);

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(c);
                        g.DrawRectangle(SystemPens.ControlText, 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                    }

                    if (createMenu)
                    {
                        // menuitems go in drop down menus
                        ToolStripItem item = new ToolStripMenuItem();
                        item.Image = bitmap;
                        item.Text = prop.Name;
                        item.Tag = c;
                        dd.Items.Add(item);
                    }
                    else 
                    {
                        // buttons go in dropdowns
                        ToolStripItem item = new ToolStripButton();
                        item.Image = bitmap;
                        item.Text = prop.Name;
                        item.Tag = c;
                        item.TextImageRelation = TextImageRelation.Overlay;
                        item.Anchor = AnchorStyles.None;
                        dd.Items.Add(item);
                    }

                }
                catch
                {
                }
            }

        }

        void SplitButtonColorPicker_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ParentForm.BackColor = (Color)(e.ClickedItem.Tag);
            this.DefaultItem = e.ClickedItem;
        }


    }

}
