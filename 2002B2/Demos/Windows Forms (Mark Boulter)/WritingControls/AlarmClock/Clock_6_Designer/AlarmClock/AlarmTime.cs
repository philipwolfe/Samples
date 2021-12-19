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
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
   
    [
    TypeConverter(typeof(AlarmTimeConverter)),
    DefaultProperty("Time")
    ]
    public class AlarmTime {

        static TimePattern     defaultTime = new TimePattern(12,0,0);

        private Color          color;
        private AlarmTimeShape alarmTimeShape;
        private AlarmClock     owner;
        private TimePattern    time;
        
        /// <summary>
        ///    <para>
        ///       Default shape for alarms
        ///    </para>
        /// </summary>
        internal static AlarmTimeShape DefaultAlarmTimeShape {
            get {
                return AlarmTimeShape.Arrow;
            }
        }
        
        /// <summary>
        ///    <para>
        ///       Default color for alarms
        ///    </para>
        /// </summary>
        internal static Color DefaultColor {
            get {
                return Color.LightGreen;
            }
        }

        /// <summary>
        ///    <para>
        ///       Default time for alarms
        ///    </para>
        /// </summary>
        internal static TimePattern DefaultTime {
            get {
                return defaultTime;
            }
        }

        /// <summary>
        ///    <para>
        ///       AlarmTime constructors
        ///       We need so many of these to support the various
        ///       property combinations that might be persisted at
        ///       designtime
        ///    </para>
        /// </summary>
        public AlarmTime() {
            color = DefaultColor;
            time = DefaultTime;
            alarmTimeShape = DefaultAlarmTimeShape;
        }

        public AlarmTime(TimePattern t) : this() {
            time = t;
        }

        public AlarmTime(TimePattern t, Color color) 
            : this(t) {

            this.color = color;
        }

        public AlarmTime(TimePattern t, Color color, AlarmTimeShape alarmTimeShape) 
            : this(t, color) {

            this.alarmTimeShape = alarmTimeShape;
        }

        public AlarmTime(TimePattern t, AlarmTimeShape alarmTimeShape) 
            : this(t) {

            this.alarmTimeShape = alarmTimeShape;
        }

        public AlarmTime(int hours, int minutes, int seconds) 
            : this(new TimePattern(hours, minutes, seconds)) {
        }

        public AlarmTime(int hours, int minutes, int seconds, Color color) 
            : this(new TimePattern(hours, minutes, seconds), color) {
        }

        public AlarmTime(int hours, int minutes, int seconds, Color color, AlarmTimeShape alarmTimeShape) 
            : this(new TimePattern(hours, minutes, seconds), color, alarmTimeShape) {
        }

        public AlarmTime(int hours, int minutes, int seconds, AlarmTimeShape alarmTimeShape) 
            : this(new TimePattern(hours, minutes, seconds), alarmTimeShape) {
        }


        /// <summary>
        ///    <para>
        ///       The shape to display for an alarm
        ///    </para>
        /// </summary>
        [
            DefaultValue(AlarmTimeShape.Arrow),
            Description("The shape to display for an alarm")
        ]
        public AlarmTimeShape AlarmTimeShape {
            get {
                return alarmTimeShape;
            }
            set {
                alarmTimeShape=value;
                OwnerInvalidate();
            }
        }

        /// <summary>
        ///    <para>
        ///       The color to paint an alarm
        ///    </para>
        /// </summary>
        [
            DefaultValue(AlarmTimeShape.Arrow),
            Description("The color to paint an alarm")
        ]
        public Color Color {
            get {
                return color;
            }
            set {
                color=value;
                OwnerInvalidate();
            }
        }
        
        /// <summary>
        ///    <para>
        ///       Draw this alarm on the clock
        ///    </para>
        /// </summary>
        internal void DrawMe(Graphics g, Point clockCenter, int clockRadius) {
            
            int hour = time.Hours ;
            hour = (hour > 11) ? hour - 12 : hour;
            int pos = (hour * 5) + (time.Minutes / 12);
            int radiusUpper = (clockRadius * 95) / 100;
            int radiusLower = (clockRadius * 80) / 100;
            Pen pen = new Pen(color);
            pen.Width=3;
            pen.EndCap=(LineCap)alarmTimeShape;

            g.DrawLine(  pen
                       , clockCenter.X + (CircleTable.GetPoint(pos).X * radiusLower) / CircleTable.SCALE
                       , clockCenter.Y + (CircleTable.GetPoint(pos).Y * radiusLower) / CircleTable.SCALE
                       , clockCenter.X + (CircleTable.GetPoint(pos).X * radiusUpper) / CircleTable.SCALE
                       , clockCenter.Y + (CircleTable.GetPoint(pos).Y * radiusUpper) / CircleTable.SCALE
                      );
                      
            // Graphics objects will garbage collect on their own, but this is
            // more efficient.
            pen.Dispose();
        }

        /// <summary>
        ///    <para>
        ///       Tell the Clock to invalidate itself
        ///    </para>
        /// </summary>
        internal void OwnerInvalidate() {
            if (owner != null) {
                owner.Invalidate(); // Note this should be more efficient!
            }
        }

        /// <summary>
        ///    <para>
        ///       Set the owning clock control
        ///    </para>
        /// </summary>
        internal void SetOwner(AlarmClock owner) {
            this.owner = owner;
        }

        /// <summary>
        ///    <para>
        ///       The time of the alarm
        ///    </para>
        /// </summary>
        [
            Description("The time of the alarm"),
        ]
        public TimePattern Time {
            get {
                return time;
            }
            set {
                time=value;
                OwnerInvalidate();
            }
        }
        
        /// <summary>
        ///    <para>
        ///       Return true is the time value needs to be persisted
        ///       Used to control persistance of properties that we 
        ///       can't use the DefaultValue attribute for
        ///    </para>
        /// </summary>
        public bool ShouldPersistTime() {
            return this.Time != DefaultTime;
        }

        /// <summary>
        ///    <para>
        ///       Return a string representation of the alarm
        ///    </para>
        /// </summary>
        public override string ToString() {
            return "Alarm set for: " + time.ToString();
        }
    }
}
