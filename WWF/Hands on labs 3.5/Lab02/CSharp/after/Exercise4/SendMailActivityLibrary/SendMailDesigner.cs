//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SendMailActivityLibrary
{
	public class SendMailDesigner : ActivityDesigner
	{
		SendMailActivity parentActivity;

		protected override void Initialize(Activity activity)
		{
			base.Initialize(activity);
			parentActivity = (SendMailActivity)activity;
		}
		protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
		{
			return new Size(230, 100);
		}
		protected override void OnPaint(ActivityDesignerPaintEventArgs e)
		{
			Rectangle frameRect = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width - 5, this.Size.Height - 5);
			Rectangle shadowRect = new Rectangle(frameRect.X + 5, frameRect.Y + 5, frameRect.Width, frameRect.Height);
			Rectangle pageRect = new Rectangle(frameRect.X + 4, frameRect.Y + 24, frameRect.Width - 8, frameRect.Height - 28);
			Rectangle titleRect = new Rectangle(frameRect.X + 15, frameRect.Y + 4, frameRect.Width / 2, 20);

			Brush frameBrush = new LinearGradientBrush(frameRect, Color.DarkBlue, Color.LightBlue, 45);

			e.Graphics.FillPath(Brushes.LightGray, RoundedRect(shadowRect));
			e.Graphics.FillPath(frameBrush, RoundedRect(frameRect));
			e.Graphics.FillPath(new LinearGradientBrush(pageRect, Color.White, Color.WhiteSmoke, 45), RoundedRect(pageRect));
			e.Graphics.DrawString(Activity.QualifiedName, new Font("Segoe UI", 9), Brushes.White, titleRect);
			frameRect.Inflate(20, 20);

			string textToDisplay = String.Format("To : \'{0}\'\r\nFrom : \'{1}\'\r\nSubject : \'{2}\'\r\n", parentActivity.To, parentActivity.From, parentActivity.Subject);
			e.Graphics.DrawString(String.Format(textToDisplay, parentActivity.Subject), new Font("Segoe UI", 8), Brushes.Black, pageRect.X, pageRect.Y + 15);
		}
		private GraphicsPath RoundedRect(Rectangle frame)
		{
			GraphicsPath path = new GraphicsPath();
			int radius = 7;
			int diameter = radius * 2;

			Rectangle arc = new Rectangle(frame.Left, frame.Top, diameter, diameter);

			path.AddArc(arc, 180, 90);

			arc.X = frame.Right - diameter;
			path.AddArc(arc, 270, 90);

			arc.Y = frame.Bottom - diameter;
			path.AddArc(arc, 0, 90);

			arc.X = frame.Left;
			path.AddArc(arc, 90, 90);

			path.CloseFigure();

			return path;
		}

	}
}
