
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;

using System.ServiceModel.Channels;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class defines the default values 
    /// used in the HttpCookieSessionExtension.
    /// </summary>
    class HttpCookieSessionDefaults
    {
        #region Public Constants

        // Default session timeout is 10 minutes.
        public const int SessionTimeout = 10;

        // Binding does not exchange the terminate 
        // message by default.
        public const bool ExchangeTerminateMessage = false;

        // Name of the resource file.
        public const string ResourceFileName =
            "Microsoft.ServiceModel.Samples.Properties.Resources";

        // Name of the exchangeTerminateMessage binding 
        // property.
        public const string ExchangeTerminateMessageProperty =
            "exchangeTerminateMessage";

        // Name of the sessionTimeout binding 
        // property.
        public const string SessionTimeoutProperty =
            "sessionTimeout";

        public const string HttpCookieSessionBindingSectionName =
            "system.serviceModel/bindings/httpCookieSessionBinding";

        #endregion

        #region Static Constructor

        static HttpCookieSessionDefaults()
        {
        }

        #endregion
    }
}
