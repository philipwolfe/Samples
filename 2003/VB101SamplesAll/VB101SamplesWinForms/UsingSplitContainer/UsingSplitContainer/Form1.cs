using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingSplitContainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Turn off form layout while form elements are rearranged
            this.SuspendLayout();

            // Take design time form elements and arrange them in SplitContainer controls
            // The vertically aligned SplitContainer has been created at design time
            // Orientation is Vertical by default
            VerticalSplitContainer.SuspendLayout();
            VerticalSplitContainer.BorderStyle = BorderStyle.Fixed3D;
			// The vertical splitter moves in 10 pixel increments
			VerticalSplitContainer.SplitterIncrement = 10;

            // Create a horizontally aligned SplitContainer
            System.Windows.Forms.SplitContainer HorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            HorizontalSplitContainer.Name = "HorizontalSplitContainer";
            HorizontalSplitContainer.Orientation = Orientation.Horizontal;
            HorizontalSplitContainer.SuspendLayout();
            HorizontalSplitContainer.BorderStyle = BorderStyle.FixedSingle;
            HorizontalSplitContainer.SplitterWidth = 6;

            // Layout controls
            // VerticalSplitContainer fills the form
            VerticalSplitContainer.Dock = DockStyle.Fill;

            // SalesTreeView fills the left panel of VerticalSplitContainer
            VerticalSplitContainer.Panel1.Controls.Add(SalesTreeView);
            SalesTreeView.Dock = DockStyle.Fill;

            // Require a minimum size of 100 pixels for the width of the left panel
            VerticalSplitContainer.Panel1MinSize = 100;

            // HorizontalSplitContainer fills the right panel of VerticalSplitContainer
            VerticalSplitContainer.Panel2.Controls.Add(HorizontalSplitContainer);
            HorizontalSplitContainer.Dock = DockStyle.Fill;

            // SalesPerson details fills the upper panel of HorizontalSplitContainer
            HorizontalSplitContainer.Panel1.Controls.Add(DetailsGroupBox);
            DetailsGroupBox.Dock = DockStyle.None;

			// Provide a graphical backdrop on the top panel of the HorizontalSplitContainer
			HorizontalSplitContainer.Panel1.BackgroundImage = UsingSplitContainer.Properties.Resources.graybackground;
			HorizontalSplitContainer.Panel1.BackgroundImageLayout = ImageLayout.Tile;
			HorizontalSplitContainer.Panel1.Margin = new System.Windows.Forms.Padding(50);
			HorizontalSplitContainer.Panel1MinSize = 125;

            // The top panel should not resize during form resizing
            HorizontalSplitContainer.FixedPanel = FixedPanel.Panel1;

            // Sales details fill the lower panel of HorizontalSplitContainer
            HorizontalSplitContainer.Panel2.Controls.Add(SalesGroupBox);
            SalesGroupBox.Dock = DockStyle.Fill;
            
            // Add the VerticalSplitContainer to the form
            this.Controls.Add(VerticalSplitContainer);

            // Turn on layout
            VerticalSplitContainer.ResumeLayout();
            HorizontalSplitContainer.ResumeLayout();
            this.ResumeLayout();

            // Set the initial size of the panels
            VerticalSplitContainer.SplitterDistance = 175;
            HorizontalSplitContainer.SplitterDistance = 125;

			// Expand the Treeview 
			SalesTreeView.Nodes[0].Expand();
			SalesTreeView.Nodes[0].Nodes[0].Expand();

        }

    }
}