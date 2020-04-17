﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;


namespace Microsoft.Ajax.Samples
{
    public class JsonpBindingExtension : BindingElementExtensionElement
    {
        public override Type BindingElementType
        {
            get { return typeof(JSONPBindingElement); }

        }

        protected override System.ServiceModel.Channels.BindingElement CreateBindingElement()
        {
            return new JSONPBindingElement();
        }
    }
}
