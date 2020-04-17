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
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public partial class DynamicOverflowForm : Form
    {
        // live count of items in overflow
        GrowShrinkLevel toolStripGrowShrinkLevel;

        int growThreshold = 50;

        public DynamicOverflowForm()
        {
            InitializeComponent();
        }

        internal GrowShrinkLevel ToolStripGrowShrinkLevel
        {
            get
            {
                ToolStripItemDisplayStyle firstDisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                ToolStripItemDisplayStyle lastDisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                // Store first display style
                foreach (ToolStripItem tsi in toolStrip1.Items)
                {
                    if (!(tsi is ToolStripSeparator))
                    {
                        firstDisplayStyle = tsi.DisplayStyle;
                        break;
                    }
                }

                // Store last display style
                foreach (ToolStripItem tsi in toolStrip1.Items)
                {
                    if (!(tsi is ToolStripSeparator))
                    {
                        lastDisplayStyle = tsi.DisplayStyle;
                    }
                }

                switch (firstDisplayStyle)
                {
                    case ToolStripItemDisplayStyle.ImageAndText:
                        switch (lastDisplayStyle)
                        {
                            case ToolStripItemDisplayStyle.ImageAndText:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.AllImageAndText;
                                break;
                            case ToolStripItemDisplayStyle.Text:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.ImageAndTextOrText;
                                break;
                        }
                        break;

                    case ToolStripItemDisplayStyle.Text:
                        switch (lastDisplayStyle)
                        {
                            case ToolStripItemDisplayStyle.ImageAndText:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.AllImageAndText;
                                break;
                            case ToolStripItemDisplayStyle.Text:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.AllText;
                                break;
                            case ToolStripItemDisplayStyle.Image:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.ImageOrText;
                                break;
                        }
                        break;

                    case ToolStripItemDisplayStyle.Image:
                        switch (lastDisplayStyle)
                        {
                            case ToolStripItemDisplayStyle.Text:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.ImageOrText;
                                break;
                            case ToolStripItemDisplayStyle.Image:
                                toolStripGrowShrinkLevel = GrowShrinkLevel.AllImage;
                                break;
                        }
                        break;

                }
                return toolStripGrowShrinkLevel;
            }
            set
            {
                toolStripGrowShrinkLevel = value;
            }
        }

        private void toolStrip1_Layout(object sender, LayoutEventArgs e)
        {
            int totalItemWidth = 0;
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                totalItemWidth += tsi.Bounds.Width + tsi.Margin.Horizontal;
            }

            // If we have room, grow ToolStripItems
            if (toolStrip1.DisplayRectangle.Width - totalItemWidth > growThreshold)
            {
                GrowToolStripItems(toolStrip1);
            }
        }

        private void toolStrip1_LayoutCompleted(object sender, EventArgs e)
        {
            // look for which items that overflowed
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                // if anything overflowed
                if (tsi.Placement != ToolStripItemPlacement.Main)
                {
                    // something overflowed...
                    if (ShrinkToolStripItems(toolStrip1))
                    {
                        toolStrip1.CanOverflow = false;
                    }
                    else
                    {
                        toolStrip1.CanOverflow = true;
                    }
                    return;
                }
            }
        }

        private bool ShrinkToolStripItems(ToolStrip ts)
        {
            // start at the bottom and work backwards
            for (int i = ts.Items.Count - 1; i >= 0; i--)
            {
                ToolStripItem tsi = ts.Items[i];
                if (tsi is ToolStripSeparator)
                {
                    // skip over separators
                }
                else
                {
                    switch (ToolStripGrowShrinkLevel)
                    {
                        case GrowShrinkLevel.AllImageAndText:
                        case GrowShrinkLevel.ImageAndTextOrText:
                            if (ShrinkToText(tsi))
                            {
                                return true;
                            }
                            break;
                        case GrowShrinkLevel.AllText:
                        case GrowShrinkLevel.ImageOrText:
                            if (ShrinkToImage(tsi))
                            {
                                return true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return false;
        }

        private void GrowToolStripItems(ToolStrip ts)
        {
            // start at the top and work forward
            for (int i = 0; i < ts.Items.Count; i++)
            {
                ToolStripItem tsi = ts.Items[i];
                if (tsi is ToolStripSeparator)
                {
                    // skip over separators
                }
                else
                {
                    switch (ToolStripGrowShrinkLevel)
                    {
                        case GrowShrinkLevel.AllImage:
                        case GrowShrinkLevel.ImageOrText:
                            if (GrowToText(tsi))
                            {
                                return;
                            }
                            break;
                        case GrowShrinkLevel.AllText:
                        case GrowShrinkLevel.ImageAndTextOrText:
                            if (GrowToTextAndImage(tsi))
                            {
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private bool ShrinkToText(ToolStripItem tsi)
        {
            if (tsi.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText)
            {
                tsi.DisplayStyle = ToolStripItemDisplayStyle.Text;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ShrinkToImage(ToolStripItem tsi)
        {
            if (tsi.DisplayStyle == ToolStripItemDisplayStyle.Text)
            {
                tsi.DisplayStyle = ToolStripItemDisplayStyle.Image;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GrowToTextAndImage(ToolStripItem tsi)
        {
            if (tsi.DisplayStyle == ToolStripItemDisplayStyle.Text)
            {
                tsi.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GrowToText(ToolStripItem tsi)
        {
            if (tsi.DisplayStyle == ToolStripItemDisplayStyle.Image)
            {
                tsi.DisplayStyle = ToolStripItemDisplayStyle.Text;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    enum GrowShrinkLevel
    {
        AllImageAndText,
        ImageAndTextOrText,
        AllText,
        ImageOrText,
        AllImage
    }
}