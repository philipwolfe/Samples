using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Runtime.Serialization.Formatters;

namespace Microsoft.ServiceModel.Samples
{
    class SimplexSessionBindingElementExtension : BindingElementExtensionElement
    {
        public SimplexSessionBindingElementExtension()
            : base()
        {
        }

        public override Type BindingElementType
        {
            get { return typeof(SimplexSessionBindingElementExtension); }
        }

        protected override BindingElement CreateBindingElement()
        {
            return new SimplexSessionBindingElement();
        }
    }
}
