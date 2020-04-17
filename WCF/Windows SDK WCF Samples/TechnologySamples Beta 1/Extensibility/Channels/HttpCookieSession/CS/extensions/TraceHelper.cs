
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.Diagnostics;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class implements set of helper 
    /// methods for tracing and logging.
    /// </summary>
    class TraceHelper
    {
        #region Constructor

        static TraceHelper()
        {
        }

        #endregion

        #region Public Static Members

        /// <summary>
        /// Writes the specified message to the 
        /// trace listeners.
        /// </summary>        
        public static void WriteDebugMessage(string message)
        {            
            Trace.TraceInformation(message);
        }

        #endregion
    }
}
