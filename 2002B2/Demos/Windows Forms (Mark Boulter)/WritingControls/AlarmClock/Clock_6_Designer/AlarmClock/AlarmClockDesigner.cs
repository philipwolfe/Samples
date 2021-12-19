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
namespace MyCompany.Controls.Design {
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;
    using System.Drawing.Design;
    using System.Collections;
    using MyCompany.Controls;

    /// 
    /// NOTE WELL:
    /// =========
    /// 
    /// THIS CLASS IS DESIGN TIME ONLY. IT SHOULD BE IN A SEPERATE 
    /// ASSEMBLY.
    /// 
    /// FOR THE SAKE OF SIMPLICITY IN THIS SAMPLE IT IS BUILT INTO THE
    /// SAME DLL AS THE CONTROL
    /// 

    /// <summary>
    ///    <para>
    ///       The Designer for the control - allows us to do special
    ///       things as design time.
    ///    </para>
    /// </summary>
    public sealed class AlarmClockDesigner : ControlDesigner {

        public AlarmClockDesigner() : base() {
            //MessageBox.Show("Created - 2");
        }

        // Properties we shadow.  A shadowed property has its get and
        // set methods re-routed to the designer, rather than the control.
        // This allows the designer to change the behavior of the property.

        /// <summary>
        ///     Accessor for ShowAlarms.  We want alarms to always show at design time
        ///     so we shadow it.
        /// </summary>
        private bool ShowAlarms {
            get {
                return (bool)ShadowProperties["ShowAlarms"];
            }
            set {
                ShadowProperties["ShowAlarms"] = value;
                Control.Invalidate();
            }
        }

        /// <summary>
        ///     Paint the alarms "shadowed" by drawing a hatch over them.
        /// </summary>
        private void DrawShadowedAlarms(Graphics g) {
            int LargeDotSize = 7;
            int clockRadius = Control.ClientRectangle.Width / 2 - (int)Math.Sqrt(2 * Math.Pow(LargeDotSize / 2 + 1, 2)) - 2;
            Point clockCenter = new Point(Control.ClientRectangle.Width / 2, Control.ClientRectangle.Height / 2);
            AlarmClock clock = (AlarmClock)(this.Control);

            foreach (AlarmTime alarm in clock.Alarms) {
                DrawShadowedAlarm(alarm, g, clockCenter, clockRadius);
            }
        }

        /// <summary>
        ///     Paint the alarm "shadowed" by drawing a hatch over it.
        /// </summary>
        private void DrawShadowedAlarm(AlarmTime at, Graphics g, Point clockCenter, int clockRadius) {

            int hour = at.Time.Hours;
            hour = (hour > 11) ? hour - 12 : hour;
            int pos = (hour * 5) + (at.Time.Minutes / 12);
            int radiusUpper = (clockRadius * 95) / 100;
            int radiusLower = (clockRadius * 80) / 100;
            HatchBrush hb = new HatchBrush(HatchStyle.DiagonalCross, at.Color, Color.Gray);
            Pen pen = new Pen(hb);
            pen.Width = 3;
            pen.EndCap = (LineCap)at.AlarmTimeShape;

            g.DrawLine(  pen
                , clockCenter.X + (DesignCircleTable.GetPoint(pos).X * radiusLower) / DesignCircleTable.SCALE
                , clockCenter.Y + (DesignCircleTable.GetPoint(pos).Y * radiusLower) / DesignCircleTable.SCALE
                , clockCenter.X + (DesignCircleTable.GetPoint(pos).X * radiusUpper) / DesignCircleTable.SCALE
                , clockCenter.Y + (DesignCircleTable.GetPoint(pos).Y * radiusUpper) / DesignCircleTable.SCALE
                );

            // Draw over again darker to show that they are not being shown.

            pen.Dispose();
            hb.Dispose();
    
            pen = new Pen(Color.FromArgb(120, Color.LightGray));
            pen.Width = 3;
            pen.EndCap = (LineCap)at.AlarmTimeShape;

            g.DrawLine(  pen
                , clockCenter.X + (DesignCircleTable.GetPoint(pos).X * radiusLower) / DesignCircleTable.SCALE
                , clockCenter.Y + (DesignCircleTable.GetPoint(pos).Y * radiusLower) / DesignCircleTable.SCALE
                , clockCenter.X + (DesignCircleTable.GetPoint(pos).X * radiusUpper) / DesignCircleTable.SCALE
                , clockCenter.Y + (DesignCircleTable.GetPoint(pos).Y * radiusUpper) / DesignCircleTable.SCALE
                );
        }


        /// <summary>
        ///     Called when the control we're designing has finished painting.  This method
        ///     gives the designer a chance to paint any additional adornments on top of the
        ///     control.
        /// </summary>
        protected override void OnPaintAdornments(PaintEventArgs pe) {
            base.OnPaintAdornments(pe);
            if (!ShowAlarms) {
                DrawShadowedAlarms(pe.Graphics);
            }
        }

        /// <summary>
        ///     This is called the first time someone queries for the properties on 
        ///     the component we're designing.  The designer can add, remove, or
        ///     change any propertieson the component at this time.
        /// </summary>
        protected override void PreFilterProperties(IDictionary properties) {
            base.PreFilterProperties(properties);
            PropertyDescriptor prop = (PropertyDescriptor)properties["ShowAlarms"];
            if (prop != null) {
                properties["ShowAlarms"] = TypeDescriptor.CreateProperty(typeof(AlarmClockDesigner), prop, new Attribute[0]);

            }
        }

        /// <summary>
        ///     Data copied from the control but we don't want this to be public
        /// </summary>
        private class DesignCircleTable {

            public static int SCALE = 8000;

            private static Point[] circleTable = {
                                                        new Point(0, -7999),        new Point(836, -7956),
                                                        new Point(1663, -7825),     new Point(2472, -7608),
                                                        new Point(3253, -7308),     new Point(3999, -6928),
                                                        new Point(4702, -6472),     new Point(5353, -5945),
                                                        new Point(5945, -5353),     new Point(6472, -4702),
                                                        new Point(6928, -4000),     new Point(7308, -3253),
                                                        new Point(7608, -2472),     new Point(7825, -1663),
                                                        new Point(7956, -836),      new Point(8000, 0),
                                                        new Point(7956, 836),       new Point(7825, 1663),
                                                        new Point(7608, 2472),      new Point(7308, 3253),
                                                        new Point(6928, 4000),      new Point(6472, 4702),
                                                        new Point(5945, 5353),      new Point(5353, 5945),
                                                        new Point(4702, 6472),      new Point(3999, 6928),
                                                        new Point(3253, 7308),      new Point(2472, 7608),
                                                        new Point(1663, 7825),      new Point(836, 7956),
                                                        new Point(0, 7999),         new Point(-836, 7956),
                                                        new Point(-1663, 7825),     new Point(-2472, 7608),
                                                        new Point(-3253, 7308),     new Point(-4000, 6928),
                                                        new Point(-4702, 6472),     new Point(-5353, 5945),
                                                        new Point(-5945, 5353),     new Point(-6472, 4702),
                                                        new Point(-6928, 3999),     new Point(-7308, 3253),
                                                        new Point(-7608, 2472),     new Point(-7825, 1663),
                                                        new Point(-7956, 836),      new Point(-7999, 0),
                                                        new Point(-7956, -836),     new Point(-7825, -1663),
                                                        new Point(-7608, -2472),    new Point(-7308, -3253),
                                                        new Point(-6928, -4000),    new Point(-6472, -4702),
                                                        new Point(-5945, -5353),    new Point(-5353, -5945),
                                                        new Point(-4702, -6472),    new Point(-3999, -6928),
                                                        new Point(-3253, -7308),    new Point(-2472, -7608),
                                                        new Point(-1663, -7825),    new Point(-836, -7956)
                                                    };

            public static int NumPoints { 
                get { return circleTable.Length;}
            }

            public static Point GetPoint(int index) { 
                return circleTable[index]; 
            }
        }
    }
}

