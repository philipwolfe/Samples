using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using Microsoft.Samples.ChannelHelpers;
namespace Microsoft.Samples.Channels.ChunkingChannel
{

    internal class ChunkingChannelFactory : ChannelFactoryBase<IDuplexSessionChannel>
    {
        IChannelFactory<IDuplexSessionChannel> innerChannelFactory;
        ICollection<string> operationParams;
        TraceSourceHelper trace;
        int maxBufferedChunks;
        internal ChunkingChannelFactory(IChannelFactory<IDuplexSessionChannel> innerChannelFactory, ICollection<string> operationParams,int maxBufferedChunks)
        {
            this.innerChannelFactory = innerChannelFactory;
            this.operationParams = operationParams;
            this.maxBufferedChunks = maxBufferedChunks;
            trace = new TraceSourceHelper(ChunkingUtils.ChunkingTraceSource);
        }
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerChannelFactory.BeginOpen(timeout, callback, state);
        }
        protected override void OnEndOpen(IAsyncResult result)
        {
             innerChannelFactory.EndOpen(result);
        }
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerChannelFactory.BeginClose(timeout, callback, state);
        }
        protected override void OnEndClose(IAsyncResult result)
        {
             innerChannelFactory.EndClose(result);
        }
        protected override void OnOpen(TimeSpan timeout)
        {
            trace.TraceMethod(System.Diagnostics.TraceEventType.Information, "ChunkingChannelFactory.OnOpen");
            innerChannelFactory.Open(timeout);
        }
        protected override void OnAbort()
        {
            trace.TraceMethod(System.Diagnostics.TraceEventType.Information, "ChunkingChannelFactory.OnAbort");
            innerChannelFactory.Abort();
        }
        protected override void OnClose(TimeSpan timeout)
        {
            trace.TraceMethod(System.Diagnostics.TraceEventType.Information, "ChunkingChannelFactory.OnClose");
            innerChannelFactory.Close(timeout);
        }
        protected override IDuplexSessionChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            trace.TraceMethod(System.Diagnostics.TraceEventType.Information, "ChunkingChannelFactory.OnCreateChannel");
            IDuplexSessionChannel innerChannel = this.innerChannelFactory.CreateChannel(address, via) as IDuplexSessionChannel; 
            ChunkingDuplexSessionChannel channel = new ChunkingDuplexSessionChannel(this, innerChannel, operationParams,maxBufferedChunks);
            return channel;
            
        }
        public override T GetProperty<T>()
        {
            return innerChannelFactory.GetProperty<T>();
        }
        //public override MessageVersion MessageVersion
        //{
        //    get { return this.innerChannelFactory.MessageVersion; }
        //}

        //public override string Scheme
        //{
        //    get { return this.innerChannelFactory.Scheme; }
        //}
    }
}