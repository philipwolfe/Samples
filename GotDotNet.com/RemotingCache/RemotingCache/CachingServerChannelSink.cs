// Stephen Toub
// stoub@microsoft.com
// 10/03/02
//
// CachingServerChannelSink.cs
// v1.1
//
// DESCRIPTION:
// ============
// Server-side sink to cache remoting call return messages.
//
// TO USE:
// =======
// 1. Add the following to the <serverProviders> configuration AFTER the formatter:
//		<provider 
//			type="Toub.Remoting.CachingServerChannelSinkProvider,
//			Toub.Remoting.RemotingCache" />
//
// 2. Add a RemotingCacheAttribute to all methods that should be cached:
//
//			[RemotingCache(30)] // cache the response for 30 seconds
//			public long GetLong(int i, int j) { ... }
//
//	  or in code use the RemotingCache class to dynamically ask the sink to cache the response:
//
//			public long GetLong(int i, int j)
//			{
//				if (i == j) RemotingCache.AddEntry(30); // cache this response for 30 seconds
//			}
//
// IMPORTANT NOTES: 
// ================
// 1. As this sink uses HttpRuntime.Cache for caching, ASP.NET must be installed
// on the system.  To remove this restriction, substitute another caching
// mechanism for HttpRuntime.Cache.
//
// 2. This tracks value type parameters by their ToString() value and reference type
// parameters by their GetHashCode() value.  Methods will not be correctly cached
// in the current version if GetHashCode() is not implemented.
//
// 3. This sink does not synchronize the incoming messages as it doesn't need to
// for caching purposes, and there are no known negative side effects from not
// doing so.  However, if the same method is requested at the same time, both 
// could execute at the same time and only the latest result will be cached.  
// Class designers should not assume that just because they put a 
// RemotingCacheAttribute(time) on their method that it will only be called once in 
// that timespan.  Hopefully that will be the case, but could happen otherwise.  This
// situation could be remedied by locking in ProcessMessage, but I think the negative
// performance would counteract the possible benefits.

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Reflection;

namespace Toub.Remoting
{
	/// <summary>Server-side message sink to cache the results of method calls.</summary>
	internal class CachingServerChannelSink : 
		BaseChannelSinkWithProperties, IServerChannelSink
	{
		#region Member Variables
		/// <summary>The next sink in the chain.</summary>
		private readonly IServerChannelSink _next = null;
		#endregion

		#region Construction
		/// <summary>Initialize the sink.</summary>
		/// <param name="nextSink">The next sink in the chain.</param>
		public CachingServerChannelSink(IServerChannelSink nextSink)
		{
			_next = nextSink;
		}
		#endregion

		#region Synchronous Processing
		/// <summary>Processes the incoming message.</summary>
		/// <param name="sinkStack">The stack of sinks in the sink chain.</param>
		/// <param name="requestMsg">The incoming request message.</param>
		/// <param name="requestHeaders">The incoming request transport headers.</param>
		/// <param name="requestStream">The incoming request stream.</param>
		/// <param name="responseMsg">The outbound response message.</param>
		/// <param name="responseHeaders">The outbound transport headers.</param>
		/// <param name="responseStream">The outbound response stream.</param>
		/// <returns>The status of the server processing.</returns>
		public ServerProcessing ProcessMessage(
			IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, 
			out IMessage responseMsg, out ITransportHeaders responseHeaders, out Stream responseStream)
		{
			ServerProcessing processingResult;

			// Push ourself onto the sink stack.  As v1.0 of the framework does not support
			// asynchronous processing, this is purely for the benefit of other sinks down the chain.
			sinkStack.Push(this, null);
			
			// Get the current cache; this could be an expensive operation the first time it is run.
			// That said, we don't want to cache it (HttpRuntime itself caches it) because the cache
			// could theoretically change.
			Cache cache = HttpRuntime.Cache;

			// We only want special processing if this is a method call message.  Otherwise,
			// we'll just hand it off and do nothing special about caching.
			IMethodCallMessage methodCall = requestMsg as IMethodCallMessage;
			IMessage returnMessage;

			// We want to use what's in the cache if the following conditions are all met:
			// 1. The cache exists
			// 2. The object is in the cache
			// 3. The message is a ReturnMessage
			// 4. The sent message is an IMethodCallMessage
			if (methodCall != null && 
				cache != null &&
				((returnMessage = (IMessage)cache[ComputeMessageKey(methodCall)]) != null) &&
				returnMessage is ReturnMessage)
			{
				// Set all of the return values.  The response message is what we got from
				// the cache.  We're performing synchronous processing.  And we haven't created
				// a stream or headers yet (that'll be up to the formatter).
				responseMsg = returnMessage;
				responseStream = null;
				responseHeaders = null;
				processingResult = ServerProcessing.Complete;
			} 
			else
			{
				// The method return message wasn't in the cache, so we'll process the message
				// normally, sending it down the chain.
				processingResult = _next.ProcessMessage(
					sinkStack, requestMsg, requestHeaders, requestStream,
					out responseMsg, out responseHeaders, out responseStream);

				// We'll put the response into the cache if the following conditions are met:
				// 1. We have a valid cache.
				// 2. The message was a method call.
				// 3. The response is a ReturnMessage (this is a formallity).
				// 4. There is RemotingCacheAttribute on the method being called, or, it was a dynamic request
				if (cache != null && 
					methodCall != null && 
					responseMsg is ReturnMessage) 
				{
					RemotingCacheAttribute attr;
					RemotingCache.CacheEntry entry;

					// If the method has requested caching at runtime...
					if ((entry = RemotingCache.GetEntry()) != null)
					{
						// Insert the response message into the cache
						// Then clear the entry so that we don't accidentally use it again.
						AddToCache(cache, methodCall, responseMsg, entry.CacheDuration);
						RemotingCache.ClearEntry(); 
					}
						// If the method has requested caching at compile time...
					else if ((attr = GetRemotingAttribute(methodCall.MethodBase)) != null) 
					{
						// Insert the response message into the cache
						AddToCache(cache, methodCall, responseMsg, attr.CacheDuration);
					}
				}
			}
			
			// Pop ourself off the stack and return the processing result.
			sinkStack.Pop(this);
			return processingResult;
		}

		/// <summary>Gets the next sink in the chain.</summary>
		public IServerChannelSink NextChannelSink
		{
			get { return _next; }
		}

		/// <summary>Gets the stream onto which the response should be written.</summary>
		/// <param name="sinkStack">The sink stack of sinks in the chain.</param>
		/// <param name="state">State pushed onto the sink state.</param>
		/// <param name="msg">The message.</param>
		/// <param name="headers">The headers.</param>
		/// <returns>The stream onto which the response should be written.</returns>
		public Stream GetResponseStream(
			IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers)
		{
			return null;
		}
		#endregion

		#region Caching Related
		/// <summary>Adds a response message to the cache.</summary>
		/// <param name="cache">The cache object in which to store the response.</param>
		/// <param name="methodCall">The message call whose response should be cached.</param>
		/// <param name="responseMsg">The actual response message to be cached.</param>
		/// <param name="cacheDuration">
		/// The number of seconds from now that the message should expire; 0 to never expire.</param>
		private void AddToCache(
			Cache cache, IMethodCallMessage methodCall, IMessage responseMsg, double cacheDuration)
		{
			cache.Insert(
				ComputeMessageKey(methodCall), responseMsg, null,							
				cacheDuration <= 0 ? Cache.NoAbsoluteExpiration : DateTime.Now.AddSeconds(cacheDuration), 
				Cache.NoSlidingExpiration);
		}


		/// <summary>Gets the RemotingCacheAttribute on the method.</summary>
		/// <param name="mb">The method to check for attributes.</param>
		/// <returns>The RemotingCacheAttribute if one exists; null, otherwise.</returns>
		private RemotingCacheAttribute GetRemotingAttribute(MethodBase mb)
		{
			// Get all RemotingCacheAttribute's on the member (there should at most be 1)
			object [] attrs = mb.GetCustomAttributes(typeof(RemotingCacheAttribute), false);

			// If there wasn't any, return null.
			if (attrs == null || attrs.Length == 0) return null;
			
			// Return the first one found;  AllowMultiple is false on the attribute
			// so there should only be one.  However, if there are multiple will ignore
			// every one but the first.
			return (RemotingCacheAttribute)attrs[0];
		}

		/// <summary>Gets a key for the method call suitable for a cache key.</summary>
		/// <param name="msg">The method call for which we need a key.</param>
		/// <returns>A key for the given method call.</returns>
		private string ComputeMessageKey(IMethodCallMessage msg)
		{
			System.Text.StringBuilder key = new System.Text.StringBuilder();

			// Start out with something that we can differentiate by in the cache
			key.Append("RemotingCache_");

			// Get a hash code for the method base itself.  Since the MethodBase object
			// is unique for a method in an appdomain, this will always be unique for
			// the method.  We'll then need to worry about parameters.
			key.Append(msg.MethodBase.GetHashCode().ToString());

			// For each argument, add on a representation
			foreach(object obj in msg.Args)
			{
				// Put a separate between each parameter
				key.Append("_");
				
				// If this is a value type, we'll trust that its string representation will be adequate
				if (obj is ValueType) key.Append(obj.ToString());

					// If this is a reference type, just use its hash code... hopefully
					// the implementer followed good coding guidelines and provided a useful
					// implementation of GetHashCode().
				else key.Append(obj.GetHashCode());
			}
			
			// Get the string representation
			return key.ToString();
		}
		#endregion

		#region Asynchronous Processing
		/// <summary>Asynchronously process the message response.</summary>
		/// <param name="sinkStack">The sink stack of sinks who requested response processing.</param>
		/// <param name="state">State as pushed onto the sink stack in ProcessMessage.</param>
		/// <param name="msg">The response message.</param>
		/// <param name="headers">The response headers.</param>
		/// <param name="stream">The response stream.</param>
		public void AsyncProcessResponse(
			IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers, Stream stream)
		{
			// In v1.0 of the framework, asynchronous processing is not supported.  Everything
			// server-side will be synchronous.
			throw new NotSupportedException();
		}
		#endregion
	}
}
