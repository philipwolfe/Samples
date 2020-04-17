
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Configuration;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// Binding Section for HttpCookieSession. Implements 
    /// configuration for HttpCookieSessionBinding.
    /// </summary>
    public class HttpCookieSessionBindingCollectionElement  : 
        StandardBindingCollectionElement<HttpCookieSessionBinding, 
        HttpCookieSessionBindingConfigurationElement>
    {     
    }
}
