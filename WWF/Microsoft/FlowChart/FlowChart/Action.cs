//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Drawing.Drawing2D;

namespace FlowChart
{
    [ActivityValidator(typeof(ActionValidator))]
    [Designer(typeof(ActionDesigner),typeof(IDesigner))]
	public partial class Action: SequenceActivity
	{
        public Action()
        {
            InitializeComponent();
        }

        public static DependencyProperty NextActivityNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("NextActivityName", typeof(string), typeof(Action));

        [Description("The Next Activity")]
        [Category("Flow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        public string NextActivityName
        {
            get
            {
                return ((string)(base.GetValue(Action.NextActivityNameProperty)));
            }
            set
            {
                base.SetValue(Action.NextActivityNameProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.WriteLine(this.Name);
            return base.Execute(executionContext);
        }
	}

    public class ActionValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = new ValidationErrorCollection();// base.Validate(manager, obj);
            Action action = obj as Action;
            if (action.Parent == null) return errors;
            if (!string.IsNullOrEmpty(action.NextActivityName))
            {

                Activity activity = action.GetActivityByName(action.NextActivityName);
                if (activity == null)
                {
                    errors.Add(new ValidationError(string.Format("The activity '{0}' does not exist", action.NextActivityName),0));
                }
            }

            return errors;
        }
    }



    public class ActionDesigner : SequenceDesigner
    {
        protected Rectangle frameRect;
        protected Rectangle pageRect;

        private Color _baseColor;

        private Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; }
        }

        private Color _lightingColor;

        private Color LightingColor
        {
            get { return _lightingColor; }
            set { _lightingColor = value; }
        }

        private Color _titleLightingColor;

        private Color TitleLightingColor
        {
            get { return _titleLightingColor; }
            set { _titleLightingColor = value; }
        }

        private Color _titleBaseColor;

        private Color TitleBaseColor
        {
            get { return _titleBaseColor; }
            set { _titleBaseColor = value; }
        }


        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set { _isExecuting = value; }
        }





        public ActionDesigner()
        {
            BaseColor =  Color.FromArgb(255, 255, 255, 255);
            LightingColor = Color.FromArgb(255, 176, 186, 198);
            TitleBaseColor = Color.FromArgb(255, 0, 0, 0);
            TitleLightingColor = Color.FromArgb(255, 50, 50, 50);
        }

        protected override void OnPaint(System.Workflow.ComponentModel.Design.ActivityDesignerPaintEventArgs e)
        {
            frameRect = new Rectangle(this.Location.X + 6, this.Location.Y + 3, this.Size.Width - 12, this.Size.Height - 13);
            Rectangle shadowRect = new Rectangle(frameRect.X + 4, frameRect.Y + 6, frameRect.Width - 8, frameRect.Height - 6);
            pageRect = new Rectangle(frameRect.X + 10, frameRect.Y + 22, frameRect.Width - 8, frameRect.Height - 28);
            Rectangle titleRect = new Rectangle(frameRect.X + 20, frameRect.Y + 5, frameRect.Width / 2 + 15, 15);
            Rectangle imageRect = new Rectangle(frameRect.X + 20, frameRect.Y + frameRect.Height / 2 - 20, 40, 40);
           

            Brush titleBrush = new LinearGradientBrush(new Point(frameRect.Left, frameRect.Top), new Point(frameRect.Left, frameRect.Top + 25), TitleBaseColor, TitleLightingColor);
            Brush glossBrush = new LinearGradientBrush(new Point(frameRect.Left, frameRect.Top), new Point(frameRect.Left, frameRect.Top + 13), Color.FromArgb(120, 255, 255, 255), Color.FromArgb(16, 255, 255, 255));// SolidBrush(Color.FromArgb(32, 255, 255, 255));
            Brush frameBrush = new LinearGradientBrush(new Point(frameRect.Left, frameRect.Top), new Point(frameRect.Left, frameRect.Bottom), BaseColor, LightingColor);

         
            Graphics outputGraphics = e.Graphics;
            shadowRect = DropRoundedRectangleShadow(shadowRect, outputGraphics);

            e.Graphics.FillPath(frameBrush, RoundedRect(frameRect));
            e.Graphics.DrawPath(Pens.Gray, RoundedRect(frameRect));
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(Activity.QualifiedName, new Font("Calibri", 9), Brushes.Black, titleRect);

            base.PaintContainedDesigners(e);

        }



        private Rectangle DropRoundedRectangleShadow(Rectangle shadowRect, Graphics outputGraphics)
        {
            int shadowIntensity = 1;
            Pen shadowPen = new Pen(Color.FromArgb(shadowIntensity, 0, 0, 0));
            Brush shadowBrush = new SolidBrush(shadowPen.Color);
            shadowPen.Width = 24;
            for (int i = 0; i < 12; i++)
            {
                outputGraphics.DrawPath(shadowPen, RoundedRect(shadowRect));
                if (IsExecuting)
                    shadowPen.Color = Color.FromArgb(10 + shadowIntensity - 1, 0, 120, 255);
                else
                    shadowPen.Color = Color.FromArgb(shadowIntensity - 1, 0, 0, 0);
                shadowIntensity += 4;
                shadowPen.Width = shadowPen.Width - 2; ;
                //shadowRect = Rectangle.Inflate(shadowRect, -1, -1);
            }
            return shadowRect;
        }


        private GraphicsPath RoundedRectTopHalf(Rectangle frame, int height)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 7;
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(frame.Left, frame.Top, diameter, diameter);
            path.AddArc(arc, 180, 90);
            arc.X = frame.Right - diameter;
            path.AddArc(arc, 270, 90);
            Point[] curvePoints = new Point[3];
            curvePoints[0] = new Point(frame.Right, frame.Top + height);
            curvePoints[1] = new Point((frame.Left + frame.Right) / 2, frame.Top + height);
            curvePoints[2] = new Point(frame.Left, frame.Top + height);
            path.AddCurve(curvePoints);
            //path.AddLine(new Point(frame.Right, frame.Top + 26), new Point(frame.Left, frame.Top + 26));
            path.CloseFigure();
            return path;
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
        public override Size MinimumSize
        {
            get
            {
                return new Size(100, 80);
            }
        }


        protected override void OnConnected(ConnectionPoint source, ConnectionPoint target)
        {
            base.OnConnected(source, target);
            if (this == source.AssociatedDesigner)
            {
               ((Action)this.Activity).NextActivityName = target.AssociatedDesigner.Activity.QualifiedName;

            }
        }
    }
}
