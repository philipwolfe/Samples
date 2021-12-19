//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace MyCompany.Controls {

    using System;
    using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Windows.Forms;

    /// <summary>
    ///    <para>
    ///       An alarm clock control that allows the user to set one or more 
    ///       alarms
    ///    </para>
    /// </summary>
    [
    DefaultProperty("Alarms"),
    DefaultEvent("AlarmSounded"),
    ]
    public class AlarmClock : Control {

        // Constants
        private static  int HandPositions = CircleTable.NumPoints;
        private const   int LargeDotSize = 7;
        private const   int SmallDotSize = 2;
        private const   int MinSize = 50 ;
        private const   int SecondHandScale = 94 ;
        private const   int MinuteHandScale = 87 ;
        private const   int HourHandScale = 65 ;
        private const   int SecondHandWidth = 1 ;
        private const   int MinuteHandWidth = 2 ;
        private const   int HourHandWidth = 3 ;

        // Instance variables
        private Point                clockCenter;   // the current center of the clock.
        private int                  clockRadius;   // the radius of the clock face.
        private Timer                clockTimer;    // the timer reponsible for updating the clock.
        private DateTime             currentTime;   // the current time.
        private bool                 showAlarms;    // true to show alarms, false to hide.
        private AlarmTimesCollection alarms;        // the collection of alarms.

        /// <summary>
        ///    <para>
        ///       Create an instance of the alarm clock control 
        ///    </para>
        /// </summary>
        public AlarmClock() {

            // Make the control completely re-draw on resize
            SetStyle(ControlStyles.ResizeRedraw, true);

            showAlarms=true;
            currentTime = DateTime.Now;

            clockTimer = new Timer();
            clockTimer.Interval=1000;
            clockTimer.Tick += new System.EventHandler(clockTimer_Tick);
        }
 
        /// <summary>
        ///    <para>
        ///       Alarm Sounded Event
        ///    </para>
        /// </summary>
        [
        Description("Raised when an alarm time is reached"),
        Category("Alarms")
        ]
        public event AlarmSoundedEventHandler AlarmSounded;
        
        /// <summary>
        ///    <para>
        ///       Collection of alarms
        ///       Marked with PersistContents(true) so that the designer 
        ///       knows to persist it in code view
        ///    </para>
        /// </summary>
        [
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Description("Collection of Alarms to sound"),
        Category("Alarms")
        ]
        public AlarmTimesCollection Alarms {
            get {
                // Demand create the alarm collection
                if (alarms == null) {
                    alarms = new AlarmTimesCollection(this);
                }
                return alarms;
            }
        }
        
        /// <summary>
        ///    <para>
        ///       Return the current hour hand position on the clock face 
        ///    </para>
        /// </summary>
        private int CurrentHourPosition {
            get {
                int currentHour = currentTime.Hour;
                currentHour = (currentHour > 11) ? currentHour - 12 : currentHour;
                int currentHourPos = (currentHour * 5) + (currentTime.Minute / 12);
                return currentHourPos;
            }
        }
       
        /// <summary>
        ///    <para>
        ///       Event handler for the timer we use to determine the time
        ///    </para>
        /// </summary>
        private void clockTimer_Tick(object sender, System.EventArgs e) {
            currentTime = DateTime.Now;
            RaiseAlarms();
            InvalidateHands();
        }

        /// <summary>
        ///    <para>
        ///       Override dispose to make sure we clean up properly
        ///    </para>
        /// </summary>
        override public void Dispose() {
            //TODO: Cleanup Dispose
            base.Dispose();
            clockTimer.Stop();
            clockTimer.Tick -= new System.EventHandler(clockTimer_Tick);
        }

        /// <summary>
        ///    <para>
        ///       Draw the alarm markers on the face 
        ///    </para>
        /// </summary>
        private void DrawAlarms(Graphics g) {
            if (ShowAlarms) {
                foreach (AlarmTime alarm in this.Alarms) {
                    alarm.DrawMe(g, clockCenter, clockRadius) ;
                }
            }
        }

        /// <summary>
        ///    <para>
        ///       Draw the clock border
        ///    </para>
        /// </summary>
        private void DrawBorder(Graphics g) {
            SmoothingMode oldSmoothingMode = g.SmoothingMode ;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(SystemColors.ControlLightLight);
            pen.Width=3;
            g.DrawEllipse(pen, ClientRectangle);

            pen = new Pen(SystemColors.ControlDark);
            pen.Width=1;
            Rectangle rc2 = ClientRectangle;
            rc2.Inflate(-2,-2);
            g.DrawEllipse(pen, rc2);

            g.SmoothingMode = oldSmoothingMode;
            pen.Dispose();
        }

        /// <summary>
        ///    <para>
        ///       Draw the center of the clock
        ///    </para>
        /// </summary>
        private void DrawCenter(Graphics g) {

            SmoothingMode oldSmoothingMode = g.SmoothingMode ;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle centerKnob = new Rectangle(clockCenter.X-4,clockCenter.Y-4,8,8);
            g.FillEllipse(new SolidBrush(this.ForeColor), centerKnob);
            Pen pen = new Pen(SystemColors.ControlDark);
            pen.Width=1;
            g.DrawEllipse(pen, centerKnob);

            g.SmoothingMode = oldSmoothingMode;
        }

        /// <summary>
        ///    <para>
        ///       Draw the clock face
        ///    </para>
        /// </summary>
        private void DrawFace(Graphics g) {

            Rectangle rc = new Rectangle();

            for (int pos = 0; pos < HandPositions; pos++) {
                rc.X = (CircleTable.GetPoint(pos).X * clockRadius) / CircleTable.SCALE + clockCenter.X;
                rc.Y  = (CircleTable.GetPoint(pos).Y * clockRadius) / CircleTable.SCALE + clockCenter.Y;

                if ((pos % 5) != 0) {
                    rc.Width  = SmallDotSize  / 3;
                    rc.Height = rc.Width;
                    rc.X -= rc.Width/2;
                    rc.Y -= rc.Height/2;
                    DrawSmallDot (g, rc);
                }
                else {
                    rc.Width  = LargeDotSize;
                    rc.Height = rc.Width;
                    rc.X -= rc.Width/2;
                    rc.Y -= rc.Height/2;
                    DrawLargeDot(g, rc);
                }
            }

        }

        /// <summary>
        ///    <para>
        ///       Draw the a clock hand
        ///    </para>
        /// </summary>
        private void DrawHand(Graphics g, Color color, int  pos, int scale, int width) { 
            int radius = (clockRadius * scale) / 100;
            Pen pen = new Pen(color);
            pen.Width=width;

            g.DrawLine(pen,clockCenter.X, clockCenter.Y,
                       clockCenter.X + (CircleTable.GetPoint(pos).X * radius) / CircleTable.SCALE,
                       clockCenter.Y + (CircleTable.GetPoint(pos).Y * radius) / CircleTable.SCALE);
                       
            pen.Dispose();
        }

        /// <summary>
        ///    <para>
        ///       Draw the hands
        ///    </para>
        /// </summary>
        private void DrawHands(Graphics g) {
            DrawSecondHand(g);
            DrawMinuteHand(g);
            DrawHourHand(g);
            DrawCenter(g);
        }

        /// <summary>
        ///    <para>
        ///       Draw the hour hand
        ///    </para>
        /// </summary>
        private void DrawHourHand(Graphics g) {
            DrawHand(g, ForeColor, CurrentHourPosition, HourHandScale, HourHandWidth);
        }

        /// <summary>
        ///    <para>
        ///       Draw the quarter hours
        ///    </para>
        /// </summary>
        private void DrawLargeDot(Graphics g, Rectangle rc) {
            ControlPaint.DrawButton(g, rc, ButtonState.Normal) ;
        }

        /// <summary>
        ///    <para>
        ///       Draw the minute hand
        ///    </para>
        /// </summary>
        private void DrawMinuteHand(Graphics g) {
            DrawHand(g, ForeColor, currentTime.Minute, MinuteHandScale, MinuteHandWidth);
        }

        /// <summary>
        ///    <para>
        ///       Draw the second hand
        ///    </para>
        /// </summary>
        private void DrawSecondHand(Graphics g) {
            DrawHand(g, ForeColor, currentTime.Second, SecondHandScale, SecondHandWidth);
        }

        /// <summary>
        ///    <para>
        ///       Draw the minor hours
        ///    </para>
        /// </summary>
        private void DrawSmallDot(Graphics g, Rectangle rc) {
            ControlPaint.DrawBorder3D(g, rc);
        }

        /// <summary>
        ///    <para>
        ///       Invalidate the clock hands.
        ///       Use regions to minimize the redrawing required.
        ///    </para>
        /// </summary>
        private void InvalidateHands() {
        
            Rectangle pieRect;
            GraphicsPath myGraphicsPath;
            int radius; 
            int inset;
            int angle;
            Region invalidRegion;

            angle = (currentTime.Second * 6) - 90 ;
            myGraphicsPath = new GraphicsPath();
            radius = (clockRadius * SecondHandScale) / 100;
            inset = (ClientRectangle.Width / 2) - radius;
            pieRect= new Rectangle(inset, inset, radius * 2, radius * 2); 
            myGraphicsPath.AddPie(pieRect, angle - 9, 18) ;
            invalidRegion = new Region(myGraphicsPath);

            // Only need to refresh hours and minute hands once per minute
            if (currentTime.Second == 0) {
                angle = (currentTime.Minute * 6) - 90 ;
                myGraphicsPath.Dispose();
                myGraphicsPath = new GraphicsPath();
                radius = (clockRadius * MinuteHandScale) / 100;
                inset = (ClientRectangle.Width / 2) - radius;
                pieRect= new Rectangle(inset, inset, radius * 2, radius * 2); 
                myGraphicsPath.AddPie(pieRect, angle - 15, 30) ;
                invalidRegion.Union(myGraphicsPath);

                angle = (CurrentHourPosition * 6) - 90 ;
                myGraphicsPath.Dispose();
                myGraphicsPath = new GraphicsPath();
                radius = (clockRadius * HourHandScale) / 100;
                inset = (ClientRectangle.Width / 2) - radius;
                pieRect= new Rectangle(inset, inset, radius * 2, radius * 2); 
                myGraphicsPath.AddPie(pieRect, angle - 15, 30) ;
                invalidRegion.Union(myGraphicsPath);
            }

            this.Invalidate(invalidRegion);
            
            invalidRegion.Dispose();
            myGraphicsPath.Dispose();
        }
              

        /// <summary>
        ///     Inheriting classes should override this method to handle this event.
        ///     Call base.OnAlarmSounded to send this event to any registered event listeners.
        /// </summary>
        protected virtual void OnAlarmSounded(AlarmSoundedEventArgs e) {
            if (AlarmSounded != null) AlarmSounded(this, e);
        }
        

        /// <summary>
        ///     Overridden to start timer firing.
        /// </summary>
        protected override void OnCreateControl() {
            // Make the control a circle
            GraphicsPath myGraphicsPath = new GraphicsPath();
            myGraphicsPath.AddEllipse(ClientRectangle) ;
            this.Region = new Region(myGraphicsPath);
            myGraphicsPath.Dispose();
            
            base.OnCreateControl();
            clockTimer.Start();
        }

        /// <summary>
        ///     Overridden to paint the control.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e) {

            // Call base paint to pick up background painting
            base.OnPaint(e);

            //Paint the alarm
            DrawBorder(e.Graphics);
            DrawFace(e.Graphics);
            DrawAlarms(e.Graphics);
            DrawHands(e.Graphics);
        }

        /// <summary>
        ///     Overridden to calculate radius and center whenever the clock resizes
        /// </summary>
        protected override void OnLayout(LayoutEventArgs e) {
            clockRadius = ClientRectangle.Width/2 - (int)Math.Sqrt(2*Math.Pow(LargeDotSize/2 + 1, 2)) - 2 ;
            clockCenter = new Point(ClientRectangle.Width/2, ClientRectangle.Height/2);
            base.OnLayout(e);
            
            // Make the control a circle
            GraphicsPath myGraphicsPath = new GraphicsPath();
            myGraphicsPath.AddEllipse(ClientRectangle) ;
            this.Region = new Region(myGraphicsPath);
            myGraphicsPath.Dispose();
        }

        /// <summary>
        ///     Walk across the collection of alarms looking for ones to raise
        /// </summary>
        private void RaiseAlarms() {
            TimePattern currentTP = new TimePattern(currentTime);

            foreach (AlarmTime alarm in this.Alarms) {
                if (alarm.Time == currentTP) {
                    OnAlarmSounded(new AlarmSoundedEventArgs(alarm.Time.AsTimeSpan()));
                }
            }
        }
        
        /// <summary>
        ///     Overridden to fix width and height to the same value with a natural minimum
        /// </summary>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
            if (width > height)
                height = width ;
            else
                width = height ;

            if (width < MinSize)
                width = height = MinSize ;

            base.SetBoundsCore(x, y, width, height, specified);
        }


        /// <summary>
        ///    <para>
        ///       Controls whether the alarms are displayed on the clock face
        ///    </para>
        /// </summary>
        [
        Description("Controls whether the alarms are displayed on the clock face"),
        DefaultValue(true),
        Category("Alarms")
        ]
        public bool ShowAlarms {
            get {
                return showAlarms;
            }
            set {
                showAlarms=value;
                Invalidate();
            }
        }

        /// <summary>
        ///    <para>
        ///       Control Text - not used
        ///    </para>
        /// </summary>
        [
        Browsable(false), 
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override string Text {
            get {
                return "Alarm Clock";
            }
            set {
                // NOOP
            }
        }

        /// <summary>
        ///    <para>
        ///       Collection of alarms
        ///    </para>
        /// </summary>
        public sealed class AlarmTimesCollection : CollectionBase {

            AlarmClock owner;
            bool bulkInvalidate = false ;

            internal AlarmTimesCollection(AlarmClock owner) {
                this.owner=owner;
            }

            public AlarmTime this[int index] {
                get {
                    return(AlarmTime)(List[index]);
                }
                set {
                    value.SetOwner(owner);
                    List[index] = value;
                    OwnerInvalidate();
                }
            }
        
            public int Add(AlarmTime value) {
                value.SetOwner(owner);
                int index = List.Add(value);
                OwnerInvalidate();
                return index;
            }

            public void AddRange(AlarmTime[] value) {
                try {
                    bulkInvalidate = true ; 
                    
                    if (value != null && value.Length > 0) {
                        foreach (AlarmTime at in value) {
                            this.Add(at);
                        }
                    }
                }
                finally {
                    bulkInvalidate = false ; 
                    OwnerInvalidate();
                }
            }

            public bool Contains(AlarmTime value) {
                return List.Contains(value);
            }

            public void CopyTo(AlarmTime[] array, int index) {
                List.CopyTo(array, index);
            }

            public int IndexOf(AlarmTime value) {
                return List.IndexOf(value);
            }

            public void Insert(int index, AlarmTime value) {
                value.SetOwner(owner);
                List.Insert(index, value);
                OwnerInvalidate();
            }

            internal void OwnerInvalidate() {
                if (owner != null && !bulkInvalidate) {
                    owner.Invalidate();
                }
            }

            public void Remove(AlarmTime value) {
                List.Remove(value);
                value.SetOwner(null);
                OwnerInvalidate();
            }
        }


    }
}

