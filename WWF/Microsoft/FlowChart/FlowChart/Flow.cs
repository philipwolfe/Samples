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
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace FlowChart
{
    [Designer(typeof(FlowDesigner),typeof(IDesigner))]
    [ActivityValidator(typeof(FlowValidator))]
    public partial class Flow : System.Workflow.ComponentModel.CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>
	{
        public Flow()
		{
			InitializeComponent();
		}

        public static DependencyProperty ActivitiesToCloseProperty = System.Workflow.ComponentModel.DependencyProperty.Register("ActivitiesToClose", typeof(int), typeof(Flow));

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]        
        internal int ActivitiesToClose
        {
            get
            {
                return ((int)(base.GetValue(Flow.ActivitiesToCloseProperty)));
            }
            set
            {
                base.SetValue(Flow.ActivitiesToCloseProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {                        
            Activity toExecute = this.EnabledActivities[0];
            ExecuteInNewContext(executionContext, toExecute);
            
            return ActivityExecutionStatus.Executing;
        }

        private void ExecuteInNewContext(ActivityExecutionContext executionContext, Activity toExecute)
        {
            ActivitiesToClose++;            
            ActivityExecutionContext context = executionContext.ExecutionContextManager.CreateExecutionContext(toExecute);
            context.Activity.Closed += OnEvent;
            context.ExecuteActivity(context.Activity);            
        }

        #region IActivityEventListener<ActivityExecutionStatusChangedEventArgs> Members

        public void OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            Debug.Assert(e.ExecutionStatus == ActivityExecutionStatus.Closed);

            ActivityExecutionContext context = sender as ActivityExecutionContext;

            ActivitiesToClose--; //This activity is closed

            Activity actToExecute = null;

            if (e.Activity is Action)
            {
                Action lastAction = e.Activity as Action;

                if (!String.IsNullOrEmpty(lastAction.NextActivityName))
                {
                    actToExecute = this.GetActivityByName(lastAction.NextActivityName);
                }
            }
            else if (e.Activity is Decision)
            {
                Decision decision = e.Activity as Decision;

                if (decision.Result)
                {
                    if (!string.IsNullOrEmpty(decision.TrueActivityName))
                    {
                        actToExecute = this.GetActivityByName(decision.TrueActivityName);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(decision.FalseActivityName))
                    {
                        actToExecute = this.GetActivityByName(decision.FalseActivityName);
                    }
                }
            }

            e.Activity.Closed -= OnEvent;

            ActivityExecutionContextManager contextManager = context.ExecutionContextManager;

            ActivityExecutionContext childContext = contextManager.GetExecutionContext(e.Activity);

            contextManager.CompleteExecutionContext(childContext);

            if (actToExecute != null)
                ExecuteInNewContext(context, actToExecute);

            if (ActivitiesToClose == 0)
            {
                context.CloseActivity();
            }
        }

        #endregion
	}

    public class FlowValidator : ActivityValidator
    {

        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            Flow flow = obj as Flow;
            foreach (Activity activity in flow.EnabledActivities)
            {
                if (!(activity is Action) && !(activity is Decision))
                {
                    errors.Add(new ValidationError("All flow children must be either Decisions or Actions", 0));
                }
            }
            return errors;
        }
    }


    public class CustomConnector : Connector
    {
        private Pen pen;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        public static readonly Color DefaultColor = Color.FromArgb(255, 120, 20, 20);

        public CustomConnector(ConnectionPoint source, ConnectionPoint target, Color penColor)
            : base(source, target)
        {
            Pen = new Pen(penColor);

            Pen.Width = 2.5F;
            Pen.EndCap = LineCap.Custom;
            Pen.CustomEndCap = new AdjustableArrowCap(3, 3);
            Pen.LineJoin = LineJoin.Round;                                   

        }
            
        protected override void OnPaint(ActivityDesignerPaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int numPoints = ConnectorSegments.Count;
            for (int i = 1; i < ConnectorSegments.Count; i++)
            {
                path.AddLine(ConnectorSegments[i-1],ConnectorSegments[i]);
            }
            e.Graphics.DrawPath(Pen, path);
        }

        protected override void OnPaintEdited(ActivityDesignerPaintEventArgs e, Point[] segments, Point[] segmentEditPoints)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points = new Point[segments.Length];
            int numPoints = segments.Length;
            for (int i = 1; i < segments.Length; i++)
            {
                path.AddLine(segments[i - 1], segments[i]);
            }

            e.Graphics.DrawPath(Pen, path);
        }

    }

    public class FlowDesigner : FreeformActivityDesigner
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


        public FlowDesigner()
        {
            BaseColor = this.DesignerTheme.BackColorStart;
            LightingColor = Color.FromArgb(255, 176, 186, 198);
            TitleBaseColor = Color.FromArgb(255, 0, 0, 0);
            TitleLightingColor = Color.FromArgb(255, 50, 50, 50);
        }


        protected override Connector CreateConnector(ConnectionPoint source, ConnectionPoint target)
        {            
            if (source.AssociatedDesigner.Activity is Decision)
            {
                if (((source.AssociatedDesigner.Activity as Decision).TrueActivityName == target.AssociatedDesigner.Activity.QualifiedName))
                {
                    return new CustomConnector(source, target, Color.FromArgb(200,150,150));
                }
                else
                {
                    return new CustomConnector(source, target, Color.FromArgb(150,200,150));
                }
            }
            return new CustomConnector(source, target, Color.FromArgb(150,150,150));        
        }


        protected override void OnPaint(System.Workflow.ComponentModel.Design.ActivityDesignerPaintEventArgs e)
        {
            if (!this.IsVisible)
                return;

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
            
            e.Graphics.FillPath(titleBrush, RoundedRectTopHalf(frameRect, 24));
            e.Graphics.DrawString(Activity.QualifiedName, new Font("Calibri", 9), Brushes.White, titleRect);

            

            e.Graphics.FillPath(glossBrush, RoundedRectTopHalf(frameRect, 12));
          
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
                return new Size(200, 200);
            }
        }
    }
}
