//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Samples.CascadingCorrelation.SharedTypes
{
    public static class Constants
    {
        public const string ServiceAddress = "http://localhost:8080/Service";
        public static readonly Binding Binding = new BasicHttpBinding();
        public const string DefaultNamespace = "http://Microsoft.ServiceModel.Samples";
        public static readonly XName POContractName = XName.Get("IPurchaseOrder", DefaultNamespace);
        public const string SubmitPOName = "SubmitPO";
        public const string UpdatePOName = "UpdatePO";
        public const string AddCustomerInfoName = "AddCustomerInfo";
        public const string UpdateCustomerName = "UpdateCustomer";

        static XPathMessageContext xPathMessageContext;
        public static XPathMessageContext XPathMessageContext
        {
            get
            {
                if (xPathMessageContext == null)
                {
                    xPathMessageContext = new XPathMessageContext();
                    XPathMessageContext.AddNamespace("defns", DefaultNamespace);
                }
                return xPathMessageContext;
            }
        }
    }
}
