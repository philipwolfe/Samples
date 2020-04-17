//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
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
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace Microsoft.Samples.Windows.Forms.ToolStripSamples 
{
	class ToolWindowHost : UserControl
	{
		// Control fields
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton closeToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton windowsDropDownButton;
		private System.Windows.Forms.Panel hostPanel;

		// Event fields
		static readonly object EventToolWindowChecked = new object();
		static readonly object EventToolWindowShown = new object();
		static readonly object EventToolWindowUnchecked = new object();

		// Fields
		int restoreSize;


		public ToolWindowHost()
		{
			InitializeComponent();

			// Initialize Fields
			restoreSize = this.Width;
		}

		// Events
		public event ToolWindowEventHandler ToolWindowChecked
		{
			add
			{
				Events.AddHandler(EventToolWindowChecked, value);
			}
			remove
			{
				Events.RemoveHandler(EventToolWindowChecked, value);
			}
		}

		public event ToolWindowEventHandler ToolWindowShown
		{
			add
			{
				Events.AddHandler(EventToolWindowShown, value);
			}
			remove
			{
				Events.RemoveHandler(EventToolWindowShown, value);
			}
		}

		public event ToolWindowEventHandler ToolWindowUnchecked
		{
			add
			{
				Events.AddHandler(EventToolWindowUnchecked, value);
			}
			remove
			{
				Events.RemoveHandler(EventToolWindowUnchecked, value);
			}
		}

		// Methods
		public void AddToolWindow(IToolWindow toolWindow)
		{
			// Add the IToolWindow to the drop down of available windows
			ToolStripMenuItem toolWindowEntry;

			toolWindowEntry = new ToolStripMenuItem();
			toolWindowEntry.Tag = toolWindow;
			toolWindowEntry.Text = toolWindow.Name;
			toolWindowEntry.Name = toolWindow.Name;
			toolWindowEntry.ToolTipText = toolWindow.Description;
			if (toolWindow.Image != null)
			{
				toolWindowEntry.Image = toolWindow.Image;
			}
			toolWindowEntry.Click += new EventHandler(toolWindowEntry_Click);
			this.windowsDropDownButton.DropDownItems.Add(toolWindowEntry);
		}

		public void CheckMenuItem(IToolWindow toolWindow)
		{
			foreach (ToolStripItem item in windowsDropDownButton.DropDownItems)
			{
				ToolStripMenuItem menuItem = item as ToolStripMenuItem;
				if (menuItem != null)
				{
					if (menuItem.Tag == toolWindow)
					{
						menuItem.Checked = true;
						OnToolWindowChecked(new ToolWindowEventArgs(toolWindow));
						break;
					}
				}
			}
		}

		private void CloseTab(ToolStripButton tab)
		{
			// Remove the tab from the collection
			this.toolStrip1.Items.Remove(tab);
			tab.Dispose();

			// Uncheck the corresponding tab in the drop down
			foreach (ToolStripItem dropDownItem in this.windowsDropDownButton.DropDownItems)
			{
				ToolStripMenuItem menuItem = dropDownItem as ToolStripMenuItem;
				if ((menuItem != null) && (menuItem.Text == tab.Text))
				{
					// Uncheck the item
					menuItem.Checked = false;

					IToolWindow toolWindow = menuItem.Tag as IToolWindow;
					if (toolWindow != null)
					{
						// Remove the ToolWindow
						hostPanel.Controls.Remove(toolWindow.View);

						// If this is the last toolwindow open, remove the panel
						if (hostPanel.Controls.Count == 0)
						{
							int tempSize = this.Width;
							this.Width = this.toolStrip1.Width;
							restoreSize = tempSize;
						}

						// Raise the unchecked event
						OnToolWindowUnchecked(new ToolWindowEventArgs(toolWindow));
					}
					break;
				}
			}

			// Set first tab to be active
			foreach (ToolStripItem item in this.toolStrip1.Items)
			{
				tab = item as ToolStripButton;
				if ((tab != null) && (tab.Text != "r"))
				{
					SetActiveTab(tab);
					break;
				}
			}
		}

		void closeToolStripButton_Click(object sender, EventArgs e)
		{
			// Find the active tab and close it
			ToolStripButton tab;
			foreach (ToolStripItem item in this.toolStrip1.Items)
			{
				tab = item as ToolStripButton;
				if ((tab != null) && (tab.Checked))
				{
					CloseTab(tab);
					break;
				}
			}
		}

		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.closeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.windowsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.hostPanel = new System.Windows.Forms.Panel();
			this.toolStrip1.SuspendLayout();
			
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.TextDirection = ToolStripTextDirection.Vertical90;
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Size = new Size(23, this.toolStrip1.Height);
			((ToolStripDropDownMenu)this.windowsDropDownButton.DropDown).ShowCheckMargin = true;
			this.toolStrip1.AllowItemReorder = true;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
					this.closeToolStripButton,
					this.windowsDropDownButton});

			// 
			// closeToolStripButton
			// 
			this.closeToolStripButton.AutoSize = false;
			this.closeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.closeToolStripButton.Font = new System.Drawing.Font("Marlett", 7F);
			this.closeToolStripButton.Name = "closeToolStripButton";
			this.closeToolStripButton.Size = new System.Drawing.Size(21, 22);
			this.closeToolStripButton.Text = "r";
			this.closeToolStripButton.ToolTipText = "Closes the current tool window";
			this.closeToolStripButton.Click += new EventHandler(this.closeToolStripButton_Click);

			// 
			// windowsDropDownButton
			// 
			this.windowsDropDownButton.DoubleClickEnabled = true;
			this.windowsDropDownButton.Name = "windowsDropDownButton";
			this.windowsDropDownButton.DropDownDirection = ToolStripDropDownDirection.Right;

			// 
			// hostPanel
			// 
			this.hostPanel.BackColor = ProfessionalColors.RaftingContainerGradientEnd;
			this.hostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hostPanel.Location = new System.Drawing.Point(402, 25);
			this.hostPanel.Name = "hostPanel";
			this.hostPanel.Padding = new System.Windows.Forms.Padding(1, 4, 4, 4);
			this.hostPanel.Size = new System.Drawing.Size(163, 418);
			this.hostPanel.TabIndex = 5;
			this.hostPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hostPanel_Paint);
			this.Controls.Add(hostPanel);

			this.Controls.Add(this.toolStrip1);
			this.DockChanged += new EventHandler(ToolWindowHost_DockChanged);
			this.SizeChanged += new EventHandler(ToolWindowHost_SizeChanged);
			
			this.toolStrip1.ResumeLayout();
		}

		private void hostPanel_Paint(object sender, PaintEventArgs e)
		{
			// Paint border
			Rectangle rect = new Rectangle(hostPanel.Padding.Left, hostPanel.Padding.Top, hostPanel.ClientRectangle.Width - hostPanel.Padding.Left - hostPanel.Padding.Right + 1, hostPanel.ClientRectangle.Height - hostPanel.Padding.Top - hostPanel.Padding.Bottom + 1);
			rect.Offset(-1, -1);
			e.Graphics.DrawRectangle(new Pen(ProfessionalColors.OverflowButtonGradientEnd), rect);
		}

		protected virtual void OnToolWindowChecked(ToolWindowEventArgs e)
		{
			EventHandler handler = (EventHandler)Events[EventToolWindowChecked];
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnToolWindowShown(ToolWindowEventArgs e)
		{
			EventHandler handler = (EventHandler)Events[EventToolWindowShown];
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnToolWindowUnchecked(ToolWindowEventArgs e)
		{
			EventHandler handler = (EventHandler)Events[EventToolWindowUnchecked];
			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void OpenTab(ToolStripMenuItem menuItem)
		{
			// Check the menu item
			menuItem.Checked = true;

			// Create a tab
			ToolStripButton tab = new ToolStripButton();
			tab.Name = menuItem.Name;
			tab.Text = menuItem.Text;
			tab.Image = menuItem.Image;
			tab.Tag = menuItem.Tag;
			tab.Click += new EventHandler(tab_Click);

			// Add it to the collection
			this.toolStrip1.Items.Add(tab);

			// Activate it
			SetActiveTab(tab);

			// Raise the ToolWindowChecked event
			OnToolWindowChecked(new ToolWindowEventArgs((IToolWindow)menuItem.Tag));
		}

		private void SetActiveTab(ToolStripButton tab)
		{
			// Uncheck all other tabs
			foreach (ToolStripItem item in this.toolStrip1.Items)
			{
				ToolStripButton tabButton = item as ToolStripButton;
				if (tabButton != null)
				{
					tabButton.Checked = false;
				}
			}

			// Check the current tab
			tab.Checked = true;

			// Get the IToolWindow
			IToolWindow toolWindow = tab.Tag as IToolWindow;
			if (toolWindow != null)
			{
				// If the hostPanel isn't showing, add it to the Controls collection
				if (this.hostPanel.Controls.Count == 0)
				{
					this.Width = restoreSize;
				}

				// If the IToolWindow's View isn't already in the collection
				// Add it and bring it to the front
				if (!hostPanel.Controls.Contains(toolWindow.View))
				{
					toolWindow.View.Dock = DockStyle.Fill;
					hostPanel.Controls.Add(toolWindow.View);
					toolWindow.View.BringToFront();
				}
				// If it is, just bring it to the front
				else
				{
					toolWindow.View.BringToFront();
				}
			}

			// Raise the ToolWindowShown event
			OnToolWindowShown(new ToolWindowEventArgs(toolWindow));
		}

		public void ShowToolWindow(IToolWindow toolWindow)
		{
			foreach (ToolStripItem item in windowsDropDownButton.DropDownItems)
			{
				ToolStripMenuItem menuItem = item as ToolStripMenuItem;
				if (menuItem != null)
				{
					if (menuItem.Tag == toolWindow)
					{
						OpenTab(menuItem);
						break;
					}
				}
			}
		}

		void toolWindowEntry_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
			ToolStripButton tab;
			if (menuItem != null)
			{
				// The toolwindow isn't already open, open it
				if (!menuItem.Checked)
				{
					OpenTab(menuItem);
				}
				// If it is already open, close it and remove it from the list of open windows
				else
				{
					tab = this.toolStrip1.Items[menuItem.Name] as ToolStripButton;
					// If the tab is in this window's collection, close it
					if (tab != null)
					{
						CloseTab(tab);
					}
					// If not, just uncheck it
					else
					{
						menuItem.Checked = false;
						OnToolWindowUnchecked(new ToolWindowEventArgs((IToolWindow)menuItem.Tag));
					}
				}
			}
		}

		void tab_Click(object sender, EventArgs e)
		{
			ToolStripButton tab = sender as ToolStripButton;
			if (tab != null)
			{
				SetActiveTab(tab);
			}
		}

		void ToolWindowHost_DockChanged(object sender, EventArgs e)
		{
			this.toolStrip1.Dock = this.Dock;
		}

		public void UncheckMenuItem(IToolWindow toolWindow)
		{
			foreach (ToolStripItem item in windowsDropDownButton.DropDownItems)
			{
				ToolStripMenuItem menuItem = item as ToolStripMenuItem;
				if (menuItem != null)
				{
					if (menuItem.Tag == toolWindow)
					{
						menuItem.Checked = false;
						OnToolWindowUnchecked(new ToolWindowEventArgs(toolWindow));
						break;
					}
				}
			}
		}

		void ToolWindowHost_SizeChanged(object sender, EventArgs e)
		{
			restoreSize = this.Width;
		}
	}
}
