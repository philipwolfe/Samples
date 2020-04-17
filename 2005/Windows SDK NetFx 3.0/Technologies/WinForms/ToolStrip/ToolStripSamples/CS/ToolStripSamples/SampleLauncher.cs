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
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    partial class SampleLauncher : Form
    {
        public SampleLauncher()
        {
            InitializeComponent();
            PopulateToolStrip();
            toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);
        }
        void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form form = Activator.CreateInstance(((SampleLaunchButton)(e.ClickedItem)).LaunchForm) as Form;
            form.Show();
        }

        private void PopulateToolStrip()
        {
            toolStrip1.Items.Add(
                new SampleLaunchButton(
                    "&SplitButtonColorPickerForm",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample1,
                    typeof(SplitButtonColorPickerForm),
                    "Demonstrates different layous and population to create a custom editor to set backcolor."
                    ));
            toolStrip1.Items.Add(
            new SampleLaunchButton(
                    "&RendererSwitcherForm",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample2,
                    typeof(RendererSwitcherForm),
                    "Demonstrates different stock render modes and impact of Visual Styles."
                    ));
            toolStrip1.Items.Add(
            new SampleLaunchButton(
                    "&PropertyGridForm",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample3,
                    typeof(ToolStripPropertyGridForm),
                    "Shows standard ToolStrip bound to DataGridView to edit properties interactively."
                    ));
            toolStrip1.Items.Add(
            new SampleLaunchButton(
                    "&DynamicOverflow",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample4,
                    typeof(DynamicOverflowForm),
                    "Implements custom overflow logic to resize items via DisplayStyle and enable overflow."
                    ));
            toolStrip1.Items.Add(
            new SampleLaunchButton(
                    "&VerticalToolTabs",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample5,
                    typeof(VerticalToolTabsForm),
                    "Uses a slick vertical tab layering implementation. Also used ContextMenuStrip as control on form."
                    ));
            toolStrip1.Items.Add(
                    new SampleLaunchButton(
                    "D&esignerVisibilityForm",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample6,
                    typeof(DesignerVisibilityForm),
                    "Design time focus - shows designer visibility attribute and how to set custom text/bitmap at DT"
                    ));
            toolStrip1.Items.Add(
                    new SampleLaunchButton(
                    "D&ynamicContextMenuForm",
                    Microsoft.Samples.Windows.Forms.ToolStripSamples.Configuration.Resources.Sample7,
                    typeof(DynamicContextMenuStripForm),
                    "Dynamically populates ContextMenuStrip based on source control or ToolStrip item visibility."
                    ));
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Table;
            ((TableLayoutSettings)(toolStrip1.LayoutSettings)).ColumnCount = 3;
        }

        private void bottomUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            ((FlowLayoutSettings)(toolStrip1.LayoutSettings)).FlowDirection = FlowDirection.BottomUp;

        }

        private void topDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            ((FlowLayoutSettings)(toolStrip1.LayoutSettings)).FlowDirection = FlowDirection.TopDown;

        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            ((FlowLayoutSettings)(toolStrip1.LayoutSettings)).FlowDirection = FlowDirection.LeftToRight;

        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            ((FlowLayoutSettings)(toolStrip1.LayoutSettings)).FlowDirection = FlowDirection.RightToLeft;

        }

        private void DockButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "&Top":
                    toolStrip1.Dock = DockStyle.Top;
                    break;
                case "&Bottom":
                    toolStrip1.Dock = DockStyle.Bottom;
                    break;
                case "&Left":
                    toolStrip1.Dock = DockStyle.Left;
                    break;
                case "&Right":
                    toolStrip1.Dock = DockStyle.Right;
                    break;
                case "&Fill":
                    toolStrip1.Dock = DockStyle.Fill;
                    break;
                default:
                    toolStrip1.Dock = DockStyle.Left;
                    break;

            }

        }

        private void TextImageRelationButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TextImageRelation tir;

            switch (e.ClickedItem.Text)
            {
                case "&ImageBeforeText":
                    tir = TextImageRelation.ImageBeforeText;
                    break;
                case "&TextBeforeImage":
                    tir = TextImageRelation.TextBeforeImage;
                    break;
                case "Image&AboveText":
                    tir = TextImageRelation.ImageAboveText;
                    break;
                case "TextA&boveImage":
                    tir = TextImageRelation.TextAboveImage;
                    break;
                case "&Overlay":
                    tir = TextImageRelation.Overlay;
                    break;
                default:
                    tir = TextImageRelation.ImageBeforeText;
                    break;
            }
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                tsi.TextImageRelation = tir;
            }

        }

        private void TextAlignButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContentAlignment textAlign;

            switch (e.ClickedItem.Text)
            {
                case "&Left":
                    textAlign = ContentAlignment.MiddleLeft;
                    break;
                case "&Center":
                    textAlign = ContentAlignment.MiddleCenter;
                    break;
                case "&Right":
                    textAlign = ContentAlignment.MiddleRight;
                    break;
                default:
                    textAlign = ContentAlignment.MiddleCenter;
                    break;
            }
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                tsi.TextAlign = textAlign;
            }


        }

        private void ImageAlignButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ContentAlignment imageAlign;

            switch (e.ClickedItem.Text)
            {
                case "&Left":
                    imageAlign = ContentAlignment.MiddleLeft;
                    break;
                case "&Center":
                    imageAlign = ContentAlignment.MiddleCenter;
                    break;
                case "&Right":
                    imageAlign = ContentAlignment.MiddleRight;
                    break;
                default:
                    imageAlign = ContentAlignment.MiddleCenter;
                    break;
            }
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                tsi.ImageAlign = imageAlign;
            }
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.StackWithOverflow;
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        }
    }

    public class SampleLaunchButton : ToolStripButton
    {
        private Type launchForm;

        public SampleLaunchButton(string text, Image image, Type launchForm, string description)
            : base(text, image)
        {
            this.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.ImageAlign = ContentAlignment.MiddleLeft;

            this.launchForm = launchForm;
            this.ToolTipText = description;
        }

        public Type LaunchForm
        {
            get { return launchForm; }
        }

    }
}