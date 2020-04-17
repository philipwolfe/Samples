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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel.Design;


namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	class Properties : UserControl, IToolWindow
	{
		// fields
		PropertyGrid _propertyGrid;
		RichTextBox rtb;

		public Properties(Control textBox)
		{
			rtb = textBox as RichTextBox;

			_propertyGrid = new PropertyGrid();
			_propertyGrid.SelectedObject = new TextProperties(rtb);
			_propertyGrid.Dock = DockStyle.Fill;
			this.Controls.Add(_propertyGrid);

			_propertyGrid.PropertyTabs.AddTabType(typeof(System.Windows.Forms.Design.EventsTab));
		}

		public string Description
		{
			get
			{
				return "Properties for the text";
			}
		}

		public new string Name
		{
			get
			{
				return "Properties";
			}
		}

		public UserControl View
		{
			get
			{
				return this;
			}
		}

		public Image Image
		{
			get
			{
				return null;
			}
		}

		class TextProperties
		{
			private RichTextBox rtb;

			public TextProperties(RichTextBox rtb)
			{
				this.rtb = rtb;
			}

			public Color BackColor
			{
				get
				{
					return rtb.BackColor;
				}
				set
				{
					rtb.BackColor = value;
				}
			}

			public Color ForeColor
			{
				get
				{
					return rtb.ForeColor;
				}
				set
				{
					rtb.ForeColor = value;
				}
			}

			public Font Font
			{
				get
				{
					return rtb.Font;
				}
				set
				{
					rtb.Font = value;
				}
			}

			public bool WordWrap
			{
				get
				{
					return rtb.WordWrap;
				}
				set
				{
					rtb.WordWrap = value;
				}
			}
		}
	}
}
