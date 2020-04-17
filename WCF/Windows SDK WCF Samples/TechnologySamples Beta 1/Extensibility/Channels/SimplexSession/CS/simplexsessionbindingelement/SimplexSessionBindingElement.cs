using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Collections.ObjectModel;

namespace Microsoft.ServiceModel.Samples
{
    public class SimplexSessionBindingElement : BindingElement
    {

        public override BindingElement Clone()
        {
            return new SimplexSessionBindingElement();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IOutputSessionChannel)
                && context.CanBuildInnerChannelFactory<IDuplexSessionChannel>());
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IInputSessionChannel)
                && context.CanBuildInnerChannelListener<IDuplexSessionChannel>());
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return (IChannelFactory<TChannel>)(object)new SimplexSessionChannelFactory(
                context.BuildInnerChannelFactory<IDuplexSessionChannel>());
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return (IChannelListener<TChannel>)(object)new SimplexSessionChannelListener(
                context.BuildInnerChannelListener<IDuplexSessionChannel>());
        }
    }
}
