
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains the implementation of ISession.
    /// </summary>
    class HttpCookieSession : ISession
    {
        #region Private Fields

        private string id;

        #endregion

        #region Constructor

        public HttpCookieSession()
        {
            // Construct the unique id for this session.
            id = string.Format(
                ResourceHelper.GetString("SessionIdFormat"), 
                Guid.NewGuid().ToString());
        }

        #endregion

        #region ISession Members

        /// <summary>
        /// Gets the session id.
        /// </summary>
        public string Id
        {
            get { return this.id; }
        }

        #endregion
    }

    /// <summary>
    /// This class contains the implementation 
    /// for IInputSession. 
    /// </summary>
    /// <remarks>
    /// This class inherits HttpCookieSession.
    /// </remarks>
    class HttpCookieReplySession : HttpCookieSession, IInputSession
    {
        public HttpCookieReplySession()
        {
        }
    }
}
