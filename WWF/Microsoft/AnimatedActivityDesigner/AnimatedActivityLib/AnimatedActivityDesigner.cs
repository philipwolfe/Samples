//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AnimatedActivityLib
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AnimatedActivityDesignerAttribute : Attribute
    {
        private string gifResourceName = String.Empty;

        public string EmbeddedGifResourceName
        {
            get { return gifResourceName; }
            set { gifResourceName = value; }
        }
    }

    class AnimatedActivityDesigner : ActivityDesigner
    {
        private Bitmap animatedGif = null;

        public AnimatedActivityDesigner()
        {
        }

        protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
        {
            if (this.animatedGif != null)
            {
                return this.animatedGif.Size;
            }
            else
            {
                return new Size(128, 128);
            }
        }

        protected override void Initialize(System.Workflow.ComponentModel.Activity activity)
        {
            // retrieve attribute for the animated gif image applied to activity using this designer
            Type activityType = this.Activity.GetType();
            object[] customAttributes = 
                activityType.GetCustomAttributes(typeof(AnimatedActivityDesignerAttribute), false);

            if( customAttributes.Length != 0 )
            {
                // get the resource name
                string gifResourceName = (customAttributes[0] as AnimatedActivityDesignerAttribute).EmbeddedGifResourceName;

                // load the resource
                Stream imgStream = Assembly.GetAssembly(this.Activity.GetType()).GetManifestResourceStream(gifResourceName);
                if (imgStream != null)
                {
                    this.animatedGif = new Bitmap(imgStream);
                    
                    // for some reason, loading the stream of an embedded resource doesn't work right
                    // save the animated gif to the temp directory and reload it from there
                    string tempFileName = Path.GetTempFileName();
                    this.animatedGif.Save(tempFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    this.animatedGif = new Bitmap(tempFileName);
                    
                    imgStream.Close();
                    imgStream = null;
                }
                else
                {
                    this.animatedGif = null;
                }
            }

            base.Initialize(activity);
            
            ImageAnimator.Animate(this.animatedGif,
                new EventHandler(NextFrame));
        }

        private void NextFrame(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(ActivityDesignerPaintEventArgs e)
        {
            ActivityDesignerTheme compositeDesignerTheme = (ActivityDesignerTheme)e.DesignerTheme;

            if (this.animatedGif == null)
            {
                base.OnPaint(e);
                return;
            }

            ActivityDesignerPaint.DrawRoundedRectangle(e.Graphics, compositeDesignerTheme.BorderPen, this.Bounds, compositeDesignerTheme.BorderWidth);

            ImageAnimator.UpdateFrames();
            e.Graphics.DrawImage(this.animatedGif,
                                this.Bounds.X,
                                this.Bounds.Y,
                                this.animatedGif.Width,
                                this.animatedGif.Height);

            string text = this.Text;

            Rectangle textRectangle = this.TextRectangle;

            if (!String.IsNullOrEmpty(text) && !textRectangle.IsEmpty)
            {
                ActivityDesignerPaint.DrawText(e.Graphics, compositeDesignerTheme.Font, text, textRectangle, StringAlignment.Center, e.AmbientTheme.TextQuality, compositeDesignerTheme.ForegroundBrush);
            }
        }
    }
}

