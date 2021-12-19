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

    /// <summary>
    ///    <para>
    ///       Contains information about the alarm that sounded
    ///    </para>
    /// </summary>
    public class AlarmSoundedEventArgs : EventArgs {
        
        private TimeSpan time ;

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the AlarmSoundedEventArgs class
        ///    </para>
        /// </summary>
        public AlarmSoundedEventArgs(TimeSpan time) {
            this.time = time;
        }

        /// <summary>
        ///    <para>
        ///       The time of the alarm
        ///    </para>
        /// </summary>
        public TimeSpan Time {
            get {
                return time;
            }
        }

    }
}

