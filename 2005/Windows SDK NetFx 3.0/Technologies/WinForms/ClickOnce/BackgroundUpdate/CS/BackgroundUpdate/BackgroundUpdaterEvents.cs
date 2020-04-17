//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;

namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdate
{
    //=----------------------------------------------------------------------=
    // UpdateCompletedEventHandler
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   Signature of the UpdateCompleted event on the BackgroundUpdater
    ///   component.
    /// </summary>
    /// 
    /// <param name="sender">
    ///   From whence cometh the event.
    /// </param>
    /// 
    /// <param name="e">
    ///   Details about the event, including information about version, 
    ///   errors, and user cancellation.
    /// 
    /// </param>
    /// 
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);




    //=----------------------------------------------------------------------=
    // UpdateCompletedEventArgs
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This object holds the details that are passed to the 
    ///   BackgroundUpdater.UpdateCompleted event.
    /// </summary>
    /// 
    public class UpdateCompletedEventArgs : EventArgs
    {

        #region Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary>
        ///   The newly downloaded version.
        /// </summary>
        /// 
        private Version m_updatedVersion;

        /// 
        /// <summary>
        ///   Was there an error?  If null, nope.
        /// </summary>
        /// 
        private Exception m_error;

        /// 
        /// <summary>
        ///   Was the operation cancelled?
        /// </summary>
        /// 
        private bool m_cancelled;

        #endregion // Private data types/constants/etc.







        #region Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // UpdateCompletedEventArgs
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this object, taking a few pieces
        ///   of information which we will expose to the user.
        /// </summary>
        /// 
        /// <param name="v">
        ///   The updated version downloaded.
        /// </param>
        /// 
        /// <param name="ex">
        ///   The error that prevented the download from succeeding, or null 
        ///   meaning all went well.
        /// </param>
        /// 
        /// <param name="cancelled">
        ///   A boolean indicating whether the operation was cancelled or not.
        /// </param>
        /// 
        public UpdateCompletedEventArgs
        (
            Version v,
            Exception ex,
            bool cancelled
        )
        {
            this.m_updatedVersion = v;
            this.m_error = ex;
            this.m_cancelled = cancelled;
        }


        //=------------------------------------------------------------------=
        // UpdatedVersion
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The updated version of the application that was downloaded.
        /// </summary>
        /// 
        /// <value>
        ///   A System.Version object with the newly downloaded version.
        /// </value>
        /// 
        public Version UpdatedVersion
        {
            get
            {
                return this.m_updatedVersion;
            }
        }


        //=------------------------------------------------------------------=
        // Error
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Indicates whether an error occurred or not during the download
        ///   of the application update.
        /// </summary>
        /// 
        /// <value>
        ///   An Exception object indicating what error occurred during the
        ///   update.  A value of null/Nothing means there were no problems.
        /// </value>
        /// 
        public Exception Error
        {
            get
            {
                return this.m_error;
            }
        }


        //=------------------------------------------------------------------=
        // Cancelled
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Indicates whether or not the download operation was cancelled.
        /// </summary>
        /// 
        /// <value>
        ///   True means the operation was cancelled.  False means that it
        ///   completed normally.
        /// </value>
        /// 
        public bool Cancelled
        {
            get
            {
                return this.m_cancelled;
            }
        }

        #endregion // Public Methods/Properties/etc
    }
}
