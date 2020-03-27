using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingMenusStatusStripsToolStrips
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Load some default text.
			EntryArea.Rtf = @"{\rtf1\ansi \b This\b0  is a \ul RichTextBox\ul0. \i Try\i0  some \b formatting\b0!  Also try the right-click Context Menu.}";
			// By default the Form's opacity is set to 100%, so show this option checked.
			this.onehundredPercent.Checked = true;
		}

		private void fileMenuItem_Click(object sender, EventArgs e)
		{
			manipulateFile(((ToolStripMenuItem)sender).Text);
		}

		private void fileToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			manipulateFile(((ToolStripItem)e.ClickedItem).Text);
		}

		private void formatMenuItem_Click(object sender, EventArgs e)
		{
			formatText(((ToolStripMenuItem)sender).Text);
 		}

		private void formatToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			formatText(((ToolStripItem)e.ClickedItem).Text);
		}

		private void changeOpacityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
			double opacity = Convert.ToDouble(menuItem.Tag.ToString());
			this.Opacity = opacity;

			// The Opacity settings are exclusive of each other. Ensure only the current 
			// setting is checked.
			ToolStripMenuItem menuChangeOpacity = (ToolStripMenuItem)optionsToolStripMenuItem.DropDownItems[1];
			foreach (ToolStripMenuItem item in menuChangeOpacity.DropDownItems)
			{
				item.Checked = false;
			}
			menuItem.Checked = true;
		}

		// This method handles the text formatting operations for the 
		// Format menu strip, tool bar, and context menu.
		private void formatText(string menuItemText)
		{
			Font fontOfSelectedText = this.EntryArea.SelectionFont;
			FontStyle styleApplied;

			switch (menuItemText)
			{
				case "&Bold":
					if (this.EntryArea.SelectionFont.Bold == true)
						styleApplied = FontStyle.Regular;
					else
						styleApplied = FontStyle.Bold;

					break;
				case "&Italics":
					if (this.EntryArea.SelectionFont.Italic == true)
						styleApplied = FontStyle.Regular;
					else
						styleApplied = FontStyle.Italic;

					break;

				default:
					if (this.EntryArea.SelectionFont.Underline == true)
						styleApplied = FontStyle.Regular;
					else
						styleApplied = FontStyle.Underline;

					break;
			}

			Font FontToApply = new Font(fontOfSelectedText, styleApplied);
			this.EntryArea.SelectionFont = FontToApply;
		}

		// This method handles the file manipulation operations for both the 
		// File menu strip and tool bar.
		private void manipulateFile(string menuItemText)
		{
			switch (menuItemText)
			{
				case "&New":
					// Simulate creating a new document by merely clearing the existing text.
					EntryArea.Text = "";
					EntryArea.Focus();

					break;
				case "&Open":
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						MessageBox.Show("The Open button was clicked, but for sample purposes " +
							"\nthe " + this.openFileDialog.FileName + " file does not open.", "Sample Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					break;
				case "&Save":
					if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						MessageBox.Show("The Save button was clicked, but for sample purposes " +
							"\nthe " + this.saveFileDialog.FileName + " file does not save.", "Sample Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					break;
				default:
					this.Close();
					this.Dispose();

					break;
			}
		}

		public void TestProgressBar()
		{
			// Do a loop to simulate a lengthy task and make the progress bar
			// show progress to its maximum value.
			while (toolStripProgressBar.Value < toolStripProgressBar.Maximum)
			{
				System.Threading.Thread.Sleep(10);
				toolStripProgressBar.Value++;
			}

			// Reset the progress bar.
			toolStripProgressBar.Value = toolStripProgressBar.Minimum;
		}

		private void testProgressBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TestProgressBar();
		}
	}
}