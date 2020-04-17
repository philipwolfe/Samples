
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    public class InspectingBindingElement : BindingElement
    {
        IChannelMessageInspector inspector;

        public InspectingBindingElement(IChannelMessageInspector inspector)
        {
            this.inspector = inspector;
        }

        protected InspectingBindingElement(InspectingBindingElement other) 
            : base(other)
        {
            this.inspector = other.Inspector;
        }

        public IChannelMessageInspector Inspector
        {
            get
            {
                if (this.inspector != null)
                {
                    return this.inspector.Clone();
                }
                else
                {
                    return new NullMessageInterceptor();
                }
            }
        }

        public override BindingElement Clone()
        {
            return new InspectingBindingElement(this);
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelFactory<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return new InspectingChannelFactory<TChannel>(this.Inspector, context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return new InspectingChannelListener<TChannel>(this.Inspector, context);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(IChannelMessageInspector))
            {
                return (T)(object)this.Inspector;
            }

            return context.GetInnerProperty<T>();
        }

        class NullMessageInterceptor : IChannelMessageInspector
        {
            public void OnSend(ref Message message)
            {
            }

            public void OnReceive(ref Message message)
            {
            }

            public IChannelMessageInspector Clone()
            {
                return new NullMessageInterceptor();
            }
        }
    }
}

