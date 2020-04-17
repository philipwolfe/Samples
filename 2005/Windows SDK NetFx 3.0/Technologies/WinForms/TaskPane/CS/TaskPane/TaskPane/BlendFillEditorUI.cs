//=====================================================================
//  File:      BlendFillEditorUI.cs
//
//  Summary:   This is the design type UITypeEditor for the BlendFill
//             class.  Very cool.
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
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;



namespace Microsoft.Samples.Windows.Forms.TaskPane
{

    //=----------------------------------------------------------------------=
    // BlendFillEditorUI
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is the design time UITypeEditor for the BlendFill class.
    /// </summary>
    /// 
    [ToolboxItem(false)]
    public class BlendFillEditorUI :
        System.Windows.Forms.UserControl
    {

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                      Private types/data/goo/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //
        // current blend direction.
        //
        private BlendStyle m_direction;

        //
        // Start Color
        //
        private Color m_startColor;

        //
        // Finish Color
        //
        private Color m_finishColor;

        //
        // Are we reversed for RTL?
        //
        private bool m_reverse;


        private IWindowsFormsEditorService m_svc;


        #region " Windows Form Designer generated code "

        public BlendFillEditorUI(IWindowsFormsEditorService in_svc, BlendFill in_blendFill, bool in_reverse) : base()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call

            this.m_svc = in_svc;

            //
            // Save out the values we were given.
            //
            this.m_direction = in_blendFill.Style;
            this.m_startColor = in_blendFill.StartColor;
            this.m_finishColor = in_blendFill.FinishColor;
            this.m_reverse = in_reverse;

            //
            // Populate and select values in the appropriate list boxes.
            //
            System.Resources.ResourceManager rm;
            rm = new System.Resources.ResourceManager(typeof(BlendFillEditorUI));
            populateDirectionListBox(rm);
            populateAndSelectColorList(this.startColorList, this.m_startColor, rm);
            populateAndSelectColorList(this.finishColorList, this.m_finishColor, rm);

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
        internal System.Windows.Forms.TabControl mainTab;
        internal System.Windows.Forms.TabPage directionPage;
        internal System.Windows.Forms.TabPage startColorPage;
        internal System.Windows.Forms.TabPage finishColorPage;
        internal System.Windows.Forms.ComboBox directionComboBox;
        internal System.Windows.Forms.ListBox startColorList;
        internal System.Windows.Forms.ListBox finishColorList;
        internal System.Windows.Forms.Panel blendSamplePanel;
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BlendFillEditorUI));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.directionPage = new System.Windows.Forms.TabPage();
            this.blendSamplePanel = new System.Windows.Forms.Panel();
            this.directionComboBox = new System.Windows.Forms.ComboBox();
            this.startColorPage = new System.Windows.Forms.TabPage();
            this.startColorList = new System.Windows.Forms.ListBox();
            this.finishColorPage = new System.Windows.Forms.TabPage();
            this.finishColorList = new System.Windows.Forms.ListBox();
            this.mainTab.SuspendLayout();
            this.directionPage.SuspendLayout();
            this.startColorPage.SuspendLayout();
            this.finishColorPage.SuspendLayout();
            this.SuspendLayout();
            //
            //mainTab
            //
            this.mainTab.AccessibleDescription = resources.GetString("mainTab.AccessibleDescription");
            this.mainTab.AccessibleName = resources.GetString("mainTab.AccessibleName");
            this.mainTab.Alignment = (System.Windows.Forms.TabAlignment)resources.GetObject("mainTab.Alignment");
            this.mainTab.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("mainTab.Anchor");
            this.mainTab.Appearance = (System.Windows.Forms.TabAppearance)resources.GetObject("mainTab.Appearance");
            this.mainTab.BackgroundImage = (System.Drawing.Image)resources.GetObject("mainTab.BackgroundImage");
            this.mainTab.Controls.Add(this.directionPage);
            this.mainTab.Controls.Add(this.startColorPage);
            this.mainTab.Controls.Add(this.finishColorPage);
            this.mainTab.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("mainTab.Dock");
            this.mainTab.Enabled = (bool)resources.GetObject("mainTab.Enabled");
            this.mainTab.Font = (System.Drawing.Font)resources.GetObject("mainTab.Font");
            this.mainTab.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("mainTab.ImeMode");
            this.mainTab.ItemSize = (System.Drawing.Size)resources.GetObject("mainTab.ItemSize");
            this.mainTab.Location = (System.Drawing.Point)resources.GetObject("mainTab.Location");
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = (System.Drawing.Point)resources.GetObject("mainTab.Padding");
            this.mainTab.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("mainTab.RightToLeft");
            this.mainTab.SelectedIndex = 0;
            this.mainTab.ShowToolTips = (bool)resources.GetObject("mainTab.ShowToolTips");
            this.mainTab.Size = (System.Drawing.Size)resources.GetObject("mainTab.Size");
            this.mainTab.TabIndex = (int)resources.GetObject("mainTab.TabIndex");
            this.mainTab.Text = resources.GetString("mainTab.Text");
            this.mainTab.Visible = (bool)resources.GetObject("mainTab.Visible");
            //
            //directionPage
            //
            this.directionPage.AccessibleDescription = resources.GetString("directionPage.AccessibleDescription");
            this.directionPage.AccessibleName = resources.GetString("directionPage.AccessibleName");
            this.directionPage.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("directionPage.Anchor");
            this.directionPage.AutoScroll = (bool)resources.GetObject("directionPage.AutoScroll");
            this.directionPage.AutoScrollMargin = (System.Drawing.Size)resources.GetObject("directionPage.AutoScrollMargin");
            this.directionPage.AutoScrollMinSize = (System.Drawing.Size)resources.GetObject("directionPage.AutoScrollMinSize");
            this.directionPage.BackgroundImage = (System.Drawing.Image)resources.GetObject("directionPage.BackgroundImage");
            this.directionPage.Controls.Add(this.blendSamplePanel);
            this.directionPage.Controls.Add(this.directionComboBox);
            this.directionPage.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("directionPage.Dock");
            this.directionPage.Enabled = (bool)resources.GetObject("directionPage.Enabled");
            this.directionPage.Font = (System.Drawing.Font)resources.GetObject("directionPage.Font");
            this.directionPage.ImageIndex = (int)resources.GetObject("directionPage.ImageIndex");
            this.directionPage.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("directionPage.ImeMode");
            this.directionPage.Location = (System.Drawing.Point)resources.GetObject("directionPage.Location");
            this.directionPage.Name = "directionPage";
            this.directionPage.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("directionPage.RightToLeft");
            this.directionPage.Size = (System.Drawing.Size)resources.GetObject("directionPage.Size");
            this.directionPage.TabIndex = (int)resources.GetObject("directionPage.TabIndex");
            this.directionPage.Text = resources.GetString("directionPage.Text");
            this.directionPage.ToolTipText = resources.GetString("directionPage.ToolTipText");
            this.directionPage.Visible = (bool)resources.GetObject("directionPage.Visible");
            //
            //blendSamplePanel
            //
            this.blendSamplePanel.AccessibleDescription = resources.GetString("blendSamplePanel.AccessibleDescription");
            this.blendSamplePanel.AccessibleName = resources.GetString("blendSamplePanel.AccessibleName");
            this.blendSamplePanel.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("blendSamplePanel.Anchor");
            this.blendSamplePanel.AutoScroll = (bool)resources.GetObject("blendSamplePanel.AutoScroll");
            this.blendSamplePanel.AutoScrollMargin = (System.Drawing.Size)resources.GetObject("blendSamplePanel.AutoScrollMargin");
            this.blendSamplePanel.AutoScrollMinSize = (System.Drawing.Size)resources.GetObject("blendSamplePanel.AutoScrollMinSize");
            this.blendSamplePanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("blendSamplePanel.BackgroundImage");
            this.blendSamplePanel.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("blendSamplePanel.Dock");
            this.blendSamplePanel.Enabled = (bool)resources.GetObject("blendSamplePanel.Enabled");
            this.blendSamplePanel.Font = (System.Drawing.Font)resources.GetObject("blendSamplePanel.Font");
            this.blendSamplePanel.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("blendSamplePanel.ImeMode");
            this.blendSamplePanel.Location = (System.Drawing.Point)resources.GetObject("blendSamplePanel.Location");
            this.blendSamplePanel.Name = "blendSamplePanel";
            this.blendSamplePanel.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("blendSamplePanel.RightToLeft");
            this.blendSamplePanel.Size = (System.Drawing.Size)resources.GetObject("blendSamplePanel.Size");
            this.blendSamplePanel.TabIndex = (int)resources.GetObject("blendSamplePanel.TabIndex");
            this.blendSamplePanel.Text = resources.GetString("blendSamplePanel.Text");
            this.blendSamplePanel.Visible = (bool)resources.GetObject("blendSamplePanel.Visible");
            //
            //directionComboBox
            //
            this.directionComboBox.AccessibleDescription = resources.GetString("directionComboBox.AccessibleDescription");
            this.directionComboBox.AccessibleName = resources.GetString("directionComboBox.AccessibleName");
            this.directionComboBox.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("directionComboBox.Anchor");
            this.directionComboBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("directionComboBox.BackgroundImage");
            this.directionComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.directionComboBox.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("directionComboBox.Dock");
            this.directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionComboBox.Enabled = (bool)resources.GetObject("directionComboBox.Enabled");
            this.directionComboBox.Font = (System.Drawing.Font)resources.GetObject("directionComboBox.Font");
            this.directionComboBox.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("directionComboBox.ImeMode");
            this.directionComboBox.IntegralHeight = (bool)resources.GetObject("directionComboBox.IntegralHeight");
            this.directionComboBox.ItemHeight = (int)resources.GetObject("directionComboBox.ItemHeight");
            this.directionComboBox.Location = (System.Drawing.Point)resources.GetObject("directionComboBox.Location");
            this.directionComboBox.MaxDropDownItems = (int)resources.GetObject("directionComboBox.MaxDropDownItems");
            this.directionComboBox.MaxLength = (int)resources.GetObject("directionComboBox.MaxLength");
            this.directionComboBox.Name = "directionComboBox";
            this.directionComboBox.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("directionComboBox.RightToLeft");
            this.directionComboBox.Size = (System.Drawing.Size)resources.GetObject("directionComboBox.Size");
            this.directionComboBox.TabIndex = (int)resources.GetObject("directionComboBox.TabIndex");
            this.directionComboBox.Text = resources.GetString("directionComboBox.Text");
            this.directionComboBox.Visible = (bool)resources.GetObject("directionComboBox.Visible");
            //
            //startColorPage
            //
            this.startColorPage.AccessibleDescription = resources.GetString("startColorPage.AccessibleDescription");
            this.startColorPage.AccessibleName = resources.GetString("startColorPage.AccessibleName");
            this.startColorPage.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("startColorPage.Anchor");
            this.startColorPage.AutoScroll = (bool)resources.GetObject("startColorPage.AutoScroll");
            this.startColorPage.AutoScrollMargin = (System.Drawing.Size)resources.GetObject("startColorPage.AutoScrollMargin");
            this.startColorPage.AutoScrollMinSize = (System.Drawing.Size)resources.GetObject("startColorPage.AutoScrollMinSize");
            this.startColorPage.BackgroundImage = (System.Drawing.Image)resources.GetObject("startColorPage.BackgroundImage");
            this.startColorPage.Controls.Add(this.startColorList);
            this.startColorPage.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("startColorPage.Dock");
            this.startColorPage.Enabled = (bool)resources.GetObject("startColorPage.Enabled");
            this.startColorPage.Font = (System.Drawing.Font)resources.GetObject("startColorPage.Font");
            this.startColorPage.ImageIndex = (int)resources.GetObject("startColorPage.ImageIndex");
            this.startColorPage.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("startColorPage.ImeMode");
            this.startColorPage.Location = (System.Drawing.Point)resources.GetObject("startColorPage.Location");
            this.startColorPage.Name = "startColorPage";
            this.startColorPage.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("startColorPage.RightToLeft");
            this.startColorPage.Size = (System.Drawing.Size)resources.GetObject("startColorPage.Size");
            this.startColorPage.TabIndex = (int)resources.GetObject("startColorPage.TabIndex");
            this.startColorPage.Text = resources.GetString("startColorPage.Text");
            this.startColorPage.ToolTipText = resources.GetString("startColorPage.ToolTipText");
            this.startColorPage.Visible = (bool)resources.GetObject("startColorPage.Visible");
            //
            //startColorList
            //
            this.startColorList.AccessibleDescription = resources.GetString("startColorList.AccessibleDescription");
            this.startColorList.AccessibleName = resources.GetString("startColorList.AccessibleName");
            this.startColorList.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("startColorList.Anchor");
            this.startColorList.BackgroundImage = (System.Drawing.Image)resources.GetObject("startColorList.BackgroundImage");
            this.startColorList.ColumnWidth = (int)resources.GetObject("startColorList.ColumnWidth");
            this.startColorList.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("startColorList.Dock");
            this.startColorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startColorList.Enabled = (bool)resources.GetObject("startColorList.Enabled");
            this.startColorList.Font = (System.Drawing.Font)resources.GetObject("startColorList.Font");
            this.startColorList.HorizontalExtent = (int)resources.GetObject("startColorList.HorizontalExtent");
            this.startColorList.HorizontalScrollbar = (bool)resources.GetObject("startColorList.HorizontalScrollbar");
            this.startColorList.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("startColorList.ImeMode");
            this.startColorList.IntegralHeight = (bool)resources.GetObject("startColorList.IntegralHeight");
            this.startColorList.ItemHeight = (int)resources.GetObject("startColorList.ItemHeight");
            this.startColorList.Location = (System.Drawing.Point)resources.GetObject("startColorList.Location");
            this.startColorList.Name = "startColorList";
            this.startColorList.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("startColorList.RightToLeft");
            this.startColorList.ScrollAlwaysVisible = (bool)resources.GetObject("startColorList.ScrollAlwaysVisible");
            this.startColorList.Size = (System.Drawing.Size)resources.GetObject("startColorList.Size");
            this.startColorList.TabIndex = (int)resources.GetObject("startColorList.TabIndex");
            this.startColorList.Visible = (bool)resources.GetObject("startColorList.Visible");
            //
            //finishColorPage
            //
            this.finishColorPage.AccessibleDescription = resources.GetString("finishColorPage.AccessibleDescription");
            this.finishColorPage.AccessibleName = resources.GetString("finishColorPage.AccessibleName");
            this.finishColorPage.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("finishColorPage.Anchor");
            this.finishColorPage.AutoScroll = (bool)resources.GetObject("finishColorPage.AutoScroll");
            this.finishColorPage.AutoScrollMargin = (System.Drawing.Size)resources.GetObject("finishColorPage.AutoScrollMargin");
            this.finishColorPage.AutoScrollMinSize = (System.Drawing.Size)resources.GetObject("finishColorPage.AutoScrollMinSize");
            this.finishColorPage.BackgroundImage = (System.Drawing.Image)resources.GetObject("finishColorPage.BackgroundImage");
            this.finishColorPage.Controls.Add(this.finishColorList);
            this.finishColorPage.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("finishColorPage.Dock");
            this.finishColorPage.Enabled = (bool)resources.GetObject("finishColorPage.Enabled");
            this.finishColorPage.Font = (System.Drawing.Font)resources.GetObject("finishColorPage.Font");
            this.finishColorPage.ImageIndex = (int)resources.GetObject("finishColorPage.ImageIndex");
            this.finishColorPage.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("finishColorPage.ImeMode");
            this.finishColorPage.Location = (System.Drawing.Point)resources.GetObject("finishColorPage.Location");
            this.finishColorPage.Name = "finishColorPage";
            this.finishColorPage.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("finishColorPage.RightToLeft");
            this.finishColorPage.Size = (System.Drawing.Size)resources.GetObject("finishColorPage.Size");
            this.finishColorPage.TabIndex = (int)resources.GetObject("finishColorPage.TabIndex");
            this.finishColorPage.Text = resources.GetString("finishColorPage.Text");
            this.finishColorPage.ToolTipText = resources.GetString("finishColorPage.ToolTipText");
            this.finishColorPage.Visible = (bool)resources.GetObject("finishColorPage.Visible");
            //
            //finishColorList
            //
            this.finishColorList.AccessibleDescription = resources.GetString("finishColorList.AccessibleDescription");
            this.finishColorList.AccessibleName = resources.GetString("finishColorList.AccessibleName");
            this.finishColorList.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("finishColorList.Anchor");
            this.finishColorList.BackgroundImage = (System.Drawing.Image)resources.GetObject("finishColorList.BackgroundImage");
            this.finishColorList.ColumnWidth = (int)resources.GetObject("finishColorList.ColumnWidth");
            this.finishColorList.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("finishColorList.Dock");
            this.finishColorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.finishColorList.Enabled = (bool)resources.GetObject("finishColorList.Enabled");
            this.finishColorList.Font = (System.Drawing.Font)resources.GetObject("finishColorList.Font");
            this.finishColorList.HorizontalExtent = (int)resources.GetObject("finishColorList.HorizontalExtent");
            this.finishColorList.HorizontalScrollbar = (bool)resources.GetObject("finishColorList.HorizontalScrollbar");
            this.finishColorList.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("finishColorList.ImeMode");
            this.finishColorList.IntegralHeight = (bool)resources.GetObject("finishColorList.IntegralHeight");
            this.finishColorList.ItemHeight = (int)resources.GetObject("finishColorList.ItemHeight");
            this.finishColorList.Location = (System.Drawing.Point)resources.GetObject("finishColorList.Location");
            this.finishColorList.Name = "finishColorList";
            this.finishColorList.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("finishColorList.RightToLeft");
            this.finishColorList.ScrollAlwaysVisible = (bool)resources.GetObject("finishColorList.ScrollAlwaysVisible");
            this.finishColorList.Size = (System.Drawing.Size)resources.GetObject("finishColorList.Size");
            this.finishColorList.TabIndex = (int)resources.GetObject("finishColorList.TabIndex");
            this.finishColorList.Visible = (bool)resources.GetObject("finishColorList.Visible");
            //
            //BlendFillEditorUI
            //
            this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
            this.AccessibleName = resources.GetString("$this.AccessibleName");
            this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            this.ClientSize = (System.Drawing.Size)resources.GetObject("$this.ClientSize");
            this.Controls.Add(this.mainTab);
            this.Enabled = (bool)resources.GetObject("$this.Enabled");
            this.Font = (System.Drawing.Font)resources.GetObject("$this.Font");
            this.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("$this.ImeMode");
            this.Location = (System.Drawing.Point)resources.GetObject("$this.Location");
            this.Name = "BlendFillEditorUI";
            this.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("$this.RightToLeft");
            this.Text = resources.GetString("$this.Text");
            this.mainTab.ResumeLayout(false);
            this.directionPage.ResumeLayout(false);
            this.startColorPage.ResumeLayout(false);
            this.finishColorPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion




        //=------------------------------------------------------------------=
        // GetValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns what this editor currently has represented as a value.
        /// </summary>
        /// 
        /// <returns>
        ///   A BlendFill object representing the current value of the editor.
        /// </returns>
        /// 
        internal BlendFill GetValue()
        {
            ColorAndNameListItem canli;
            Color startColor, finishColor;
            BlendStyle direction;

            startColor = Color.Empty;
            finishColor = Color.Empty;

            //
            // Get the start color
            //
            canli = (ColorAndNameListItem)this.startColorList.Items[this.startColorList.SelectedIndex];
            if (canli != null)
            {
                startColor = canli.Color;
            }

            // 
            // Finish Color
            //
            canli = (ColorAndNameListItem)this.finishColorList.Items[this.finishColorList.SelectedIndex];
            if (canli != null)
            {
                finishColor = canli.Color;
            }

            //
            // blend direction
            //
            direction = (BlendStyle)this.directionComboBox.SelectedIndex;

            return new BlendFill(direction, startColor, finishColor);
        }



        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Private Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // populateDirectionListBox
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Populates and initializes the direction list box with the
        ///   appropriate values.
        /// </summary>
        /// 
        /// <param name="in_resources">
        ///   From where to obtain localized strings.
        /// </param>
        /// 
        private void populateDirectionListBox
        (
            System.Resources.ResourceManager in_resources
        )
        {
            string s;

            //
            // Please note that these keys match the values/order of BlendStyle
            // exactly !!!!
            //
            string[] keys = new string [] { 
                "directionHorizontal",
                "directionVertical",
                "directionForwardDiagonal",
                "directionBackwardDiagonal"
            };

            //
            // okay, whip through the list of values, and put them into the list
            // box.
            //
            for (int x = 0; x < keys.Length; x++)
            {
                s = in_resources.GetString(keys[x]);
                System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(s));
                this.directionComboBox.Items.Add(s);
            }

            //
            // Finally, select the appropriate item
            //
            this.directionComboBox.SelectedIndex = (int)this.m_direction;
        }


        //=------------------------------------------------------------------=
        // populateAndSelectColorList
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Sets up an owner draw listbox to contain most of the interesting
        ///   colors currently available on the system.  It will then select
        ///   the given color.
        /// </summary>
        /// 
        /// <param name="in_listBox">
        ///   The owner-draw ListBox to populate.
        /// </param>
        /// 
        /// <param name="in_selectMe">
        ///   The Color to select.
        /// </param>
        /// 
        /// <param name="in_resources">
        ///   From where to get localized strings.
        /// </param>
        /// 
        private void populateAndSelectColorList
        (
            ListBox in_listBox,
            Color in_selectMe,
            System.Resources.ResourceManager in_resources
        )
        {
            ColorAndNameListItem canli = new ColorAndNameListItem();
            string s;

            //
            // 1. Add SystemColors to list box.  Please note that we'r
            //    going to pass in the color to select so that we can
            //    compare against the colors in their native format, and
            //    not have to go back and  regenerate the colors from
            //    the type strings, etc ...
            //
            addColorsToList(in_listBox, typeof(SystemColors), in_selectMe);

            //
            // 2. Add Regular colors to the list box.
            //
            addColorsToList(in_listBox, typeof(Color), in_selectMe);

            //
            // 3. If the user gave us a color that isn't one of the predefined
            //    system-y colors, then go and add a "Custom" entry for their
            //    color.
            //
            if (in_listBox.SelectedIndex == -1)
            {
                s = in_resources.GetString("customColor");
                System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(s));

                canli = new ColorAndNameListItem();
                canli.Color = in_selectMe;
                canli.Name = s;

                in_listBox.Items.Insert(0, canli);
                in_listBox.SelectedIndex = 0;
            }
        }


        //=------------------------------------------------------------------=
        // addColorsToList
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Given an object with a tonne of static color objects, go and
        ///   get those and add them to the list of colors.  We will also
        ///   do an optimisation, and select the appropriate color if it's
        ///   in our list.
        /// </summary>
        /// 
        /// <param name="in_listBox">
        ///   Where to add the colors.
        /// </param>
        /// 
        /// <param name="in_colorSource">
        ///   From which class to get the colors.
        /// </param>
        /// 
        /// <param name="in_selectMe">
        ///   Indicates which color to select when showing the list.
        /// </param>
        /// 
        private void addColorsToList
        (
            ListBox in_listBox,
            Type in_colorSource,
            Color in_selectMe
        )
        {
            System.Reflection.PropertyInfo[] pic;
            ColorAndNameListItem canli;
            int i;

            pic = in_colorSource.GetProperties();

            //
            // Loop through all the properties looking for Color properties.
            //
            foreach (System.Reflection.PropertyInfo pi in pic)
            {

                if (pi.PropertyType == typeof(Color))
                {
                    canli = new ColorAndNameListItem();
                    canli.Color = (Color)pi.GetValue(null, null);
                    canli.Name = pi.Name;

                    i = in_listBox.Items.Add(canli);
                    if (in_selectMe.Equals(canli.Color))
                    {
                        in_listBox.SelectedIndex = i;
                    }
                }
            }
        }


        //=------------------------------------------------------------------=
        // startColorList_DrawItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We are supposed to draw an item in the list box now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about it, including the Graphics object.
        /// </param>
        /// 
        private void startColorList_DrawItem
        (
            object sender,
            DrawItemEventArgs e
        )
        {
            drawItemForListBox(((ListBox)sender), e);
        }


        //=------------------------------------------------------------------=
        // finishColorList_DrawItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We are supposed to draw an item in the list box now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about it, including the Grahpics object.
        /// </param>
        /// 
        private void finishColorList_DrawItem
        (
            object sender,
            DrawItemEventArgs e
        )
        {
            drawItemForListBox(((ListBox)sender), e);
        }


        //=------------------------------------------------------------------=
        // drawItemForListBox
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Draws an item for one of the two color list boxes.  We're just
        ///   going to try and look as much like the regular Color UITypeEditor
        ///   as possible.
        /// </summary>
        /// 
        /// <param name="in_listBox">
        ///   The ListBox being drawn.
        /// </param>
        /// 
        /// <param name="in_args">
        ///   Detailsa bout the painting event.
        /// </param>
        /// 
        private void drawItemForListBox
        (
            ListBox in_listBox, 
            DrawItemEventArgs in_args
        )
        {
            ColorAndNameListItem canli;
            SolidBrush b;
            Rectangle r;
            Graphics g;
            Pen p;

            b = null;
            g = null;
            p = null;

            if (in_listBox == null)
            {
                System.Diagnostics.Debug.Fail("DrawItem event for something that isn't a ListBox!");
                return;
            }

            //
            // draw the background
            //
            in_args.DrawBackground();

            g = in_args.Graphics;
            r = in_args.Bounds;

            //
            // Get the ColorAndNameListItem for the details of what we're doing.
            //
            canli = (ColorAndNameListItem)in_listBox.Items[in_args.Index];
            if (canli == null)
            {
                System.Diagnostics.Debug.Fail("A bogus item was inserted into the " + in_listBox.Name + " ListBox.");
                return;
            }

            //
            // Now, go and draw the color in a little framed box.
            //
            try
            {
                b = new SolidBrush(canli.Color);
                p = new Pen(Color.Black);

                g.FillRectangle(b, r.Left + 2, r.Top + 2, 22, in_listBox.ItemHeight - 4);
                g.DrawRectangle(p, r.Left + 2, r.Top + 2, 22, in_listBox.ItemHeight - 4);

            }
            finally
            {
                if (b != null)
                {
                    b.Dispose();
                }
                if (p != null)
                {
                    p.Dispose();
                }
            }

            //
            // Finally, go and draw the text next to the color !
            //
            try
            {
                if ((in_args.State & DrawItemState.Selected) != 0)
                {
                    b = new SolidBrush(in_listBox.BackColor);
                }
                else
                {
                    b = new SolidBrush(SystemColors.ControlText);
                }

                g.DrawString(canli.Name, in_listBox.Font, b, r.Left + 26,
                             in_args.Bounds.Top + 2);
            }
            finally
            {
                if (b != null)
                {
                    b.Dispose();
                }
            }
        }


        //=------------------------------------------------------------------=
        // blendSamplePanel_Paint
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Paints a little preview of the blend operation for the user.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Deatils about the event, including the Graphics object.
        /// </param>
        /// 
        private void blendSamplePanel_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb;
            Rectangle[] rects;
            Graphics g;
            Pen p;

            lgb = null;
            p = null;
            g = e.Graphics;

            //
            // Draw the four sample rects.
            //
            rects = getPanelRects();

            for (int x = 0; x < rects.Length; x++)
            {
                try
                {
                    lgb = new LinearGradientBrush(rects[x], this.m_startColor,
                                                  this.m_finishColor,
                                                  getAngle((BlendStyle)x));
                    g.FillRectangle(lgb, rects[x]);

                    //
                    // Draw a rect around it.
                    //
                    if (x == (int)this.m_direction)
                    {
                        p = new Pen(Color.Black, 3);
                    }
                    else
                    {
                        p = new Pen(Color.Black, 1);
                    }

                    g.DrawRectangle(p, rects[x]);

                }
                finally
                {
                    if (lgb != null)
                    {
                        lgb.Dispose();
                    }
                    if (p != null)
                    {
                        p.Dispose();
                    }
                }
            }
        }


        //=------------------------------------------------------------------=
        // getAngle
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns an angle for a LinearGradientBrush given a direction/style.
        /// </summary>
        /// 
        /// <param name="in_direction">
        ///   The style or direction for which we wish to query the angle.
        /// </param>
        /// 
        /// <returns>
        ///   The angle to draw.
        /// </returns>
        /// 
        private float getAngle(BlendStyle in_direction)
        {
            switch (in_direction)
            {
                case BlendStyle.Horizontal:
                    if (this.m_reverse == false)
                    {
                        return 0;
                    }
                    else
                    {
                        return 180;
                    }

                case BlendStyle.Vertical:
                    return 90;

                case BlendStyle.ForwardDiagonal:
                    if (this.m_reverse == false)
                    {
                        return 45;
                    }
                    else
                    {
                        return 135;
                    }

                case BlendStyle.BackwardDiagonal:
                    if (this.m_reverse == false)
                    {
                        return 135;
                    }
                    else
                    {
                        return 45;
                    }

                default:
                    System.Diagnostics.Debug.Fail("Bogus Direction");
                    return 0;
            }
        }


        //=------------------------------------------------------------------=
        // getPanelRects
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the rectangles in which to draw the samples.
        /// </summary>
        /// 
        /// <returns>
        ///   An array of rectangles in which to draw the samples.
        /// </returns>
        /// 
        private Rectangle[] getPanelRects()
        {
            Rectangle[] rects;
            int w, h;

            w = ((int)(blendSamplePanel.Width / 2)) - 8;
            h = ((int)(blendSamplePanel.Height / 2)) - 8;
            rects = new Rectangle[3];

            rects[0] = new Rectangle(4, 4, w, h);
            rects[1] = new Rectangle(w + 8, 4, w, h);
            rects[2] = new Rectangle(4, h + 8, w, h);
            rects[3] = new Rectangle(w + 8, h + 8, w, h);

            return rects;
        }


        //=------------------------------------------------------------------=
        // directionComboBox_SelectedIndexChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Update the sample panel with the new selection.
        /// </summary>
        /// 
        private void directionComboBox_SelectedIndexChanged
        (
            object sender,
            System.EventArgs e
        )
        {
            this.m_direction = (BlendStyle)this.directionComboBox.SelectedIndex;
            this.blendSamplePanel.Refresh();
        }


        //=------------------------------------------------------------------=
        // finishColorList_SelectedIndexChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Update the sample box.
        /// </summary>
        /// 
        private void finishColorList_SelectedIndexChanged
        (
            object sender,
            System.EventArgs e
        )
        {
            ColorAndNameListItem canli;

            canli = (ColorAndNameListItem)this.finishColorList.Items[this.finishColorList.SelectedIndex];
            if (canli != null)
            {
                this.m_finishColor = canli.Color;
            }

            this.blendSamplePanel.Refresh();
        }


        //=------------------------------------------------------------------=
        // startColorList_SelectedIndexChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Update the sample box.
        /// </summary>
        /// 
        private void startColorList_SelectedIndexChanged
        (
            object sender,
            System.EventArgs e
        )
        {
            ColorAndNameListItem canli;

            canli = (ColorAndNameListItem)this.startColorList.Items[this.startColorList.SelectedIndex];
            if (canli != null)
            {
                this.m_startColor = canli.Color;
            }

            this.blendSamplePanel.Refresh();
        }


        //=------------------------------------------------------------------=
        // blendSamplePanel_MouseUp
        //=------------------------------------------------------------------=
        /// <summary>
        ///   They've clicked on the sample panel.  Update the selection if
        ///   necessary.
        /// </summary>
        /// 
        private void blendSamplePanel_MouseUp
        (
            object sender,
            System.Windows.Forms.MouseEventArgs e
        )
        {
            Rectangle[] rects;

            rects = getPanelRects();

            for (int x = 0; x < rects.Length; x++)
            {
                if (rects[x].Contains(e.X, e.Y))
                {
                    this.m_direction = (BlendStyle)x;
                    this.blendSamplePanel.Refresh();
                    this.directionComboBox.SelectedIndex = x;
                }
            }
        }


        //=------------------------------------------------------------------=
        // blendSamplePanel_DoubleClick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Close down the editor.
        /// </summary>
        /// 
        private void blendSamplePanel_DoubleClick
        (
            object sender,
            System.EventArgs e
        )
        {
            if (this.m_svc != null)
            {
                this.m_svc.CloseDropDown();
            }
        }



        //=------------------------------------------------------------------=
        // startColorList_DoubleClick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Close down the editor.
        /// </summary>
        /// 
        private void startColorList_DoubleClick
        (
            object sender,
            System.EventArgs e
        )
        {
            if (this.m_svc != null)
            {
                this.m_svc.CloseDropDown();
            }
        }


        //=------------------------------------------------------------------=
        // finishColorList_DoubleClick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Close down the editor.
        /// </summary>
        /// 
        private void finishColorList_DoubleClick
        (
            object sender,
            System.EventArgs e
        )
        {
            if (this.m_svc != null)
            {
                this.m_svc.CloseDropDown();
            }
        }






        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                           Private Types
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // ColorAndNameListItem
        //=------------------------------------------------------------------=
        // Wraps a list item in our two color list boxes.
        //
        private class ColorAndNameListItem
        {
            public Color Color;
            public string Name;

            public override string ToString()
            {
                return this.Name;
            }
        }

    }

}

