
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// Configuration class for InspectingBindingElement. To make your InspectingBindingElement
    /// configurable, derive from InspectingElementInspectingElement and override CreateMessageInspector()
    /// </summary>
    public abstract class InspectingElement : BindingElementExtensionElement
    {
        protected InspectingElement()
            : base()
        {
        }

        public override Type BindingElementType
        {
            get
            {
                return typeof(InspectingBindingElement);
            }
        }

        protected abstract IChannelMessageInspector CreateMessageInspector();

        protected override BindingElement CreateBindingElement()
        {
            return new InspectingBindingElement(CreateMessageInspector());
        }
    }
}
