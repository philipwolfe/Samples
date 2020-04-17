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
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	class BackColorWindow : UserControl, IToolWindow
	{
		private RichTextBox rtb;
		private ContextMenuStrip cms;

		public BackColorWindow(Control textBox)
		{
			this.rtb = textBox as RichTextBox;
			this.AutoScroll = true;

			cms = new ContextMenuStrip();
			cms.TopLevel = false;
			cms.AutoClose = false;

			ToolStripMenuItem tsmi;
			Bitmap bmp;
			Graphics g;
			Color c;
			Type colorType = typeof(Color);
			PropertyInfo[] infos = colorType.GetProperties(BindingFlags.Public | BindingFlags.Static);
			foreach (PropertyInfo info in infos)
			{
				// Don't add Transparent to the list
				if (info.Name == "Transparent")
				{
					continue;
				}
				if (info.PropertyType == typeof(Color)) 
				{
					c = (Color)info.GetValue(Color.Empty, null);
					bmp = new Bitmap(32, 32);
					g = Graphics.FromImage(bmp);
					g.FillRectangle(new SolidBrush(c), g.ClipBounds); 
					tsmi = new ToolStripMenuItem(info.Name, bmp);
					tsmi.Click += new EventHandler(tsmi_Click);
					tsmi.Tag = c;
					cms.Items.Add(tsmi);
				}
			}

			this.Controls.Add(cms);
			cms.Show();
			this.HorizontalScroll.Visible = false;
		}

		void tsmi_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if (tsmi != null)
			{
				rtb.BackColor = (Color)tsmi.Tag;
			}
		}

		UserControl IToolWindow.View
		{
			get { return this; }
		}

		string IToolWindow.Name
		{
			get { return "BackColor"; }
		}

		string IToolWindow.Description
		{
			get { return "Sets the background color of the text."; }
		}

		Image IToolWindow.Image
		{
			get { return null; }
		}
	}
}
