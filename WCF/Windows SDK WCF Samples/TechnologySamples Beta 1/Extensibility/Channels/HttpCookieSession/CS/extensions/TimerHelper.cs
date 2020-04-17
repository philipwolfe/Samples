
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This is a value type with basic timer functionality.
    /// </summary>
    struct TimerHelper
    {
        #region Private Fields

        private DateTime deadLine;

        #endregion

        #region Constructor

        public TimerHelper(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("timeout");
            }
            if (timeout == TimeSpan.MaxValue)
            {
                this.deadLine = DateTime.MaxValue;
            }
            else
            {
                this.deadLine = DateTime.UtcNow + timeout;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Returns an the remaining time in 
        /// the current timer.
        /// </summary>        
        public TimeSpan RemainingTime()
        {
            if (deadLine == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            TimeSpan remainingTime = 
                (TimeSpan)(this.deadLine - DateTime.UtcNow);
            
            if (remainingTime <= TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return remainingTime;
        }

        #endregion
    }
}
