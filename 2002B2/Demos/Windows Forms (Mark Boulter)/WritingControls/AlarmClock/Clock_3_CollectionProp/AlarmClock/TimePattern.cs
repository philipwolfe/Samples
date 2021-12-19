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
    using System.Windows.Forms;
   
    public struct TimePattern  {

        private int hours;
        private int minutes;
        private int seconds;

        public static TimePattern Parse(string timeString) {
            return new TimePattern(TimeSpan.Parse(timeString));
        }
        
        internal TimePattern(TimeSpan ts) : this(ts.Hours, ts.Minutes, ts.Seconds) {
        }

        public TimePattern(DateTime dt) : this(dt.Hour, dt.Minute, dt.Second) {
        }

        public TimePattern(int nhours, int nminutes, int nseconds) {
            // Use properties to get error checking
            hours = minutes = seconds = 0;
            this.Hours = nhours ;
            this.Minutes = nminutes ;
            this.Seconds = nseconds ;
        }

        public int Hours {
            get {
                return hours;
            }
            set {
                if (hours > 23) {
                    throw new Exception("There are a maximum of 24 hours in a day."); 
                }
                hours=value;
            }
        }

        public int Minutes {
            get {
                return minutes;
            }
            set {
                if (minutes > 59) {
                    throw new Exception("There are a maximum of 60 minutes in an hour."); 
                }
                minutes=value;
            }
        }

        public int Seconds {
            get {
                return seconds;
            }
            set {
                if (seconds > 59) {
                    throw new Exception("There are a maximum of 60 seconds in a minute."); 
                }
                seconds=value;
            }
        }

        public override string ToString() {
            TimeSpan ts = this.AsTimeSpan();
            return ts.ToString();
        }

        internal TimeSpan AsTimeSpan() {
            return new TimeSpan(hours,minutes,seconds);
        }

        public static bool operator ==(TimePattern left, TimePattern right) {
            return left.Hours == right.Hours && left.Minutes == right.Minutes && left.Seconds == right.Seconds;
        }
        
        public static bool operator !=(TimePattern left, TimePattern right) {
            return !(left == right);
        }

        public override bool Equals(object obj) {
            if (!(obj is TimePattern)) return false;
            TimePattern comp = (TimePattern)obj;
            return (   comp.Hours == this.Hours 
                    && comp.Minutes == this.Minutes 
                    && comp.Seconds == this.Seconds 
                    && comp.GetType().Equals(GetType())
                   );
        }

        //GetHashCode should return the same value for 2 TimePatterns for which Equals returns true
        //We will take a short cut and return the hashcode for the equivalent TimeSpan
        public override int GetHashCode() {
            return (new TimeSpan(hours,minutes,seconds)).GetHashCode();
        }

    }
}

