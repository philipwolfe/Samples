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

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	class FontWindow : UserControl, IToolWindow
	{
		private RichTextBox rtb;
		private ContextMenuStrip cms;

		public FontWindow(Control textBox)
		{
			this.rtb = textBox as RichTextBox;
			this.AutoScroll = true;
			
			cms = new ContextMenuStrip();
			cms.TopLevel = false;
			cms.AutoClose = false;

			ToolStripMenuItem tsmi;
			Bitmap bmp;
			Graphics g;
			Font f;
			foreach (FontFamily ff in FontFamily.Families)
			{
				try
				{
					f = new Font(ff, 16.0f);
				}
				catch 
				{
					continue;
				}

				bmp = new Bitmap(32, 32);
				g = Graphics.FromImage(bmp);
				g.DrawString("F", f, new SolidBrush(Color.Black), new PointF(0, 0));
				tsmi = new ToolStripMenuItem(f.Name, bmp);
				tsmi.Click += new EventHandler(tsmi_Click);
				tsmi.Tag = ff;
				cms.Items.Add(tsmi);
			}

			this.Controls.Add(cms);
			cms.Show();
			this.HorizontalScroll.Visible = false;
		}

		void tsmi_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if (tsmi != null) {
				rtb.Font = new Font(tsmi.Tag as FontFamily, rtb.Font.Size);
			}
		}

		UserControl IToolWindow.View
		{
			get { return this; }
		}

		string IToolWindow.Name
		{
			get { return "Font"; }
		}

		string IToolWindow.Description
		{
			get { return "Sets the font of the text."; }
		}

		Image IToolWindow.Image
		{
			get { return null; }
		}
	}
}
