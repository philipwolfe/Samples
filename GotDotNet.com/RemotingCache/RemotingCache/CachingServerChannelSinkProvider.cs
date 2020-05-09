// Stephen Toub
// stoub@microsoft.com
// 10/03/02
//
// CachingServerChannelSinkProvider.cs
// v1.1

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Toub.Remoting
{
	/// <summary>Creates CachingServerChannelSinks for use in a remoting server chain.</summary>
	public class CachingServerChannelSinkProvider : IServerFormatterSinkProvider
	{
		#region Private Members
		/// <summary>The next provider in the chain.</summary>
		private IServerChannelSinkProvider _next = null;
		#endregion

		#region Construction
		/// <summary>Initialize the provider.</summary>
		public CachingServerChannelSinkProvider()
		{
		}

		/// <summary>Initialize the provider.</summary>
		/// <param name="properties">Properties that can be used to modify sink construction behavior.</param>
		/// <param name="providerData">Sink provider data.</param>
		public CachingServerChannelSinkProvider(IDictionary properties, ICollection providerData)
		{
		}
		#endregion

		#region Sink Construction
		/// <summary>Creates the sink.</summary>
		/// <param name="channel">The channel of which the sink is a part.</param>
		/// <returns>The created sink or null if something went wrong.</returns>
		public IServerChannelSink CreateSink(IChannelReceiver channel)
		{
			IServerChannelSink nextSink = null;

			// Get the next sink in the chain
			if (_next != null &&
				(nextSink = _next.CreateSink(channel)) == null) return null;

			// Create the new sink with a reference to the next sink.
			return new CachingServerChannelSink(nextSink);
		}

		/// <summary>Gets channel data.</summary>
		/// <param name="channelData">The channel data store.</param>
		public void GetChannelData(IChannelDataStore channelData)
		{
		}

		/// <summary>Gets or sets the next provider in the chain.</summary>
		public IServerChannelSinkProvider Next
		{
			get { return _next; }
			set { _next = value; }
		}
		#endregion
	}
}
