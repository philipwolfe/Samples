using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingLayoutPanels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Configure layout panels with defaults

			// CellBorder
			// By default, no grid lines are shown.
			exclusiveCheck(cellBorderStyleDropDown, noneBorderToolStripMenuItem);
			tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

			// FlowLayout
			// The FlowLayoutPanel flows horizontally, left to right by default.
			flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
			exclusiveCheck(flowDirectionDropDown, horizontalToolStripMenuItem);

			// Break the layout flow at the header label.
			// For FlowDirection.Horizontal, controls after the 
			// header label control will be placed on a new row
			// For FlowDirection.Vertical, controls after the 
			// header label control will be placed on a new column
			this.flowLayoutPanel1.SetFlowBreak(tableLabel, true);
        }

        // UI interaction event handlers
		private void exclusiveCheck(ToolStripDropDownButton parent, ToolStripMenuItem menuItem)
		{
			// Grow styles are exclusive.
			// Uncheck sibling menu items and check current one
			foreach (ToolStripItem item in parent.DropDownItems)
			{
				if (item.GetType() == typeof(ToolStripMenuItem))
					((ToolStripMenuItem)item).Checked = false;
			}
			menuItem.Checked = true;

		}

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
			exclusiveCheck(flowDirectionDropDown, (ToolStripMenuItem)sender);
			// Flow horizontally, left to right
			// Right to left flow is also supported
			this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
			exclusiveCheck(flowDirectionDropDown, (ToolStripMenuItem)sender);
			// Flow vertically, top to bottom
			// Bottom to top flow is also supported.
			this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        }

		private void borderStyleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem styleSelected = (ToolStripMenuItem)sender;
			exclusiveCheck(cellBorderStyleDropDown, styleSelected);
			
			// Set the style based on the selected item
			switch( styleSelected.Text )
			{
				case "None":
					this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
					break;
				case "Single":
					this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
					break;
				case "Inset":
					this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
					break;
				case "Outset":
					this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
					break;
			}
		}
    }
}