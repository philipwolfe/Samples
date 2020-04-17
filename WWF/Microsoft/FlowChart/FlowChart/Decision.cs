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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Drawing.Drawing2D;
using System.Workflow.Activities.Rules.Design;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlowChart
{
    [ActivityValidator(typeof(DecisionValidator))]
    [Designer(typeof(DecisionDesigner),typeof(IDesigner))]
    public partial class Decision : System.Workflow.ComponentModel.Activity
    {
        public Decision()
        {
            InitializeComponent();
        }

        public static DependencyProperty FalseActivityNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("FalseActivityName", typeof(string), typeof(Decision));

        [Description("False Activity")]
        [Category("Action")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FalseActivityName
        {
            get
            {
                return ((string)(base.GetValue(Decision.FalseActivityNameProperty)));
            }
            set
            {
                base.SetValue(Decision.FalseActivityNameProperty, value);
            }
        }

        public static DependencyProperty TrueActivityNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TrueActivityName", typeof(string), typeof(Decision));

        [Description("True Activity")]
        [Category("Action")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TrueActivityName
        {
            get
            {
                return ((string)(base.GetValue(Decision.TrueActivityNameProperty)));
            }
            set
            {
                base.SetValue(Decision.TrueActivityNameProperty, value);
            }
        }
        public static DependencyProperty ConditionProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Condition", typeof(ActivityCondition), typeof(Decision), new PropertyMetadata(DependencyPropertyOptions.Metadata));

        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(null)]
        public ActivityCondition Condition
        {
            get
            {
                return base.GetValue(ConditionProperty) as ActivityCondition;
            }
            set
            {
                base.SetValue(ConditionProperty, value);
            }
        }

        public static DependencyProperty ResultProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Result", typeof(bool), typeof(Decision));

        [Description("Result")]
        [Category("Result")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Result
        {
            get
            {
                return ((bool)(base.GetValue(Decision.ResultProperty)));
            }
            set
            {
                base.SetValue(Decision.ResultProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.WriteLine(this.Name);
            Result = Condition.Evaluate(this, executionContext);
            return ActivityExecutionStatus.Closed;
        }
    }
    public class DecisionValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            Decision decision = obj as Decision;
            if (decision.Parent == null) return errors;

            foreach (string activity in new string[] { decision.FalseActivityName, decision.TrueActivityName })
            {
                if (!string.IsNullOrEmpty(activity))
                {
                    Activity act = decision.GetActivityByName(activity);
                    if (!(act is Decision || act is Action))
                    {
                        errors.Add(new ValidationError(string.Format("The activity '{0}' must be a valid Decision or Action.", act.GetType().FullName), 0));
                    }
                }
            }
            if (string.IsNullOrEmpty(decision.FalseActivityName) && string.IsNullOrEmpty(decision.TrueActivityName))
            {
                errors.Add(new ValidationError("A decision must have at least one True or False activity associated with it.", 0));
            }
            return errors;
        }
    }



    public class DecisionDesigner : FreeformActivityDesigner
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





        public DecisionDesigner()
        {
            BaseColor = this.DesignerTheme.BackColorStart;
            LightingColor = Color.FromArgb(255, 176, 186, 198);
            TitleBaseColor = Color.FromArgb(255, 0, 0, 0);
            TitleLightingColor = Color.FromArgb(255, 50, 50, 50);
            
        }

        


        protected override void OnPaint(System.Workflow.ComponentModel.Design.ActivityDesignerPaintEventArgs e)
        {
            if (!this.IsVisible)
                return;

            frameRect = new Rectangle(this.Location.X + 6, this.Location.Y + 3, this.Size.Width - 12, this.Size.Height - 13);
            Rectangle shadowRect = new Rectangle(frameRect.X + 4, frameRect.Y + 6, frameRect.Width - 8, frameRect.Height - 6);
            pageRect = new Rectangle(frameRect.X + 10, frameRect.Y + 22, frameRect.Width - 8, frameRect.Height - 28);
            Rectangle titleRect = new Rectangle(frameRect.X + frameRect.Width/2 - frameRect.Width/4, frameRect.Y + frameRect.Height/2 - 8 , frameRect.Width / 2, 15);
            Rectangle trueRect = new Rectangle(frameRect.X + 10, frameRect.Y  + frameRect.Height / 2 - 5, 20, 15);
            Rectangle falseRect = new Rectangle(frameRect.X + frameRect.Width - 20, frameRect.Y +  frameRect.Height / 2 - 5, 20, 15);



            Brush titleBrush = new LinearGradientBrush(new Point(frameRect.Left, frameRect.Top), new Point(frameRect.Left, frameRect.Top + 25), TitleBaseColor, TitleLightingColor);
            Brush frameBrush = new LinearGradientBrush(new Point(frameRect.Left, frameRect.Top), new Point(frameRect.Left, frameRect.Bottom), BaseColor, LightingColor);

          
            Graphics outputGraphics = e.Graphics;
            shadowRect = DropRoundedRectangleShadow(shadowRect, outputGraphics);

            e.Graphics.FillPath(frameBrush, RoundedDiamond(frameRect));
            e.Graphics.DrawPath(Pens.Gray, RoundedDiamond(frameRect));
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(Activity.QualifiedName, new Font("Calibri", 9), Brushes.Black, titleRect);
            e.Graphics.DrawString("T", new Font("Calibri", 9), Brushes.Black, trueRect);
            e.Graphics.DrawString("F", new Font("Calibri", 9), Brushes.Black, falseRect);
                     
            base.PaintContainedDesigners(e);

        }

        protected override bool ShowConnectorsInForeground
        {
            get
            {
                return true;
            }
        }
        protected override bool CanResizeContainedDesigner(ActivityDesigner containedDesigner)
        {
            return false;
        }


        protected override Connector CreateConnector(ConnectionPoint source, ConnectionPoint target)
        {
            Connector connector = base.CreateConnector(source, target);
            connector.Source.Bounds.Inflate(threshold, threshold);
            connector.Target.Bounds.Inflate(threshold, threshold);
            return connector;
        }
        private double distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Abs( x1 * x1 + y1 * y1 - x2 * x2 - y2 * y2));
        }

        private const int threshold = 10;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ConnectionPoint left = GetConnectionPoints(DesignerEdges.Left)[0];            
            
            base.OnMouseDown(e);
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            ActivityCondition activityCondition = (this.Activity as Decision).Condition;
            if (activityCondition == null)
            {
                (this.Activity as Decision).Condition = new RuleConditionReference();
                activityCondition = (this.Activity as Decision).Condition;
            }

            RuleConditionReference condition = (activityCondition as RuleConditionReference);
            if (condition != null)
            {
                RuleDefinitions defs = (RuleDefinitions)RootActivity.GetValue(RuleDefinitions.RuleDefinitionsProperty);
                RuleExpressionCondition expr = (RuleExpressionCondition)(defs.Conditions[condition.ConditionName]);
                RuleConditionDialog conditionDialog = new RuleConditionDialog(this.Activity, expr.Expression);
                conditionDialog.ShowDialog();
                expr.Expression = conditionDialog.Expression;
                RootActivity.SetValue(RuleDefinitions.RuleDefinitionsProperty, defs);

            }
        }

        private Activity RootActivity
        {
            get
            {
                Activity root = this.Activity;
                while (root.Parent != null)
                {
                    root = root.Parent;
                }
                return root;
            }
        }


        private Rectangle DropRoundedRectangleShadow(Rectangle shadowRect, Graphics outputGraphics)
        {
            int shadowIntensity = 1;
            Pen shadowPen = new Pen(Color.FromArgb(shadowIntensity, 0, 0, 0));
            Brush shadowBrush = new SolidBrush(shadowPen.Color);
            shadowPen.Width = 18;
            for (int i = 0; i < 9; i++)
            {
                outputGraphics.DrawPath(shadowPen, RoundedDiamond(shadowRect));
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


        private GraphicsPath RoundedDiamond(Rectangle frame)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 7;
            int diameter = radius * 2;
            int correction = 30;
            Rectangle arc = new Rectangle(frame.Left + frame.Width / 2 - radius, frame.Top, diameter, diameter);

            path.AddArc(arc, 180 + correction, 180-correction*2);

            arc.X = frame.Right - diameter;
            arc.Y = frame.Top + frame.Height / 2 - radius;

            path.AddArc(arc, 270 + correction, 180 - correction * 2);

            arc.Y = frame.Bottom - diameter;
            arc.X = frame.Left + frame.Width / 2 - radius;

            path.AddArc(arc, correction, 180 - correction * 2);

            arc.X = frame.Left;
            arc.Y = frame.Top + frame.Height / 2 - radius;

            path.AddArc(arc, 90 + correction, 180 - correction * 2);
            path.CloseFigure();

            return path;
        }

        protected override void OnConnected(ConnectionPoint source, ConnectionPoint target)
        {
            base.OnConnected(source, target);
            if (this == source.AssociatedDesigner)
            {
                if (source.ConnectionEdge == DesignerEdges.Left)
                    ((Decision)this.Activity).TrueActivityName = target.AssociatedDesigner.Activity.QualifiedName;

                if (source.ConnectionEdge == DesignerEdges.Right)
                    ((Decision)this.Activity).FalseActivityName = target.AssociatedDesigner.Activity.QualifiedName;
                
            }           
            
        }        

        protected override bool CanConnect(ConnectionPoint source, ConnectionPoint target)
        {
            if (this == source.AssociatedDesigner)
            {
                if (source.ConnectionEdge == DesignerEdges.Left &&
                    (!String.IsNullOrEmpty(((Decision)this.Activity).TrueActivityName)))
                    return false;

                if (source.ConnectionEdge == DesignerEdges.Right &&
                    (!String.IsNullOrEmpty(((Decision)this.Activity).FalseActivityName)))
                    return false;

                if (source.ConnectionEdge == DesignerEdges.Bottom)
                    return false;

                return true;
            }
            else
            {
                if (target.ConnectionEdge == DesignerEdges.Top) return true;
                else return false;
            }            
        }

        public override Size MinimumSize
        {
            get
            {
                return new Size(120, 120);
            }
        }
    }
}
