// Stephen Toub
// stoub@microsoft.com
// 10/03/02
//
// RemotingCache.cs
// v1.1

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Web.Caching;
using System.Threading;

namespace Toub.Remoting
{
	/// <summary>Allows a remoted method to dynamically add itself to the output cache.</summary>
	public class RemotingCache
	{
		#region Construction
		/// <summary>Prevent instantiation.</summary>
		private RemotingCache() { throw new NotSupportedException("RemotingCache is used only for its static methods."); }
		#endregion

		#region Methods
		/// <summary>Add the current remoting call's return message to the cache.</summary>
		/// <param name="cacheDuration">The number of seconds the response should be held in the cache. The default is 0, which means the response is not cached.</param>
		public static void AddEntry(double cacheDuration)
		{
			CallContext.SetData(AddEntryKey, new CacheEntry(cacheDuration));
		}

		/// <summary>Retrieves the entry for a method which has requested caching.</summary>
		/// <returns>The entry if one has been entered; null, otherwise.</returns>
		internal static CacheEntry GetEntry()
		{
			return CallContext.GetData(AddEntryKey) as CacheEntry;
		}

		/// <summary>
		/// Allows the caching sink to remove the call context entry after it has been processed.
		/// Failure to do so could allow the cache entry to be picked on future requests.
		/// </summary>
		internal static void ClearEntry()
		{
			CallContext.FreeNamedDataSlot(AddEntryKey);
		}
		#endregion

		#region Properties
		/// <summary>The name of the call context data slot used to store the CacheEntry.</summary>
		internal const string AddEntryKey = "rc_AddCacheEntry";
		#endregion

		/// <summary>Information on how the current method is requesting caching.</summary>
		internal class CacheEntry
		{
			#region Member Variables
			/// <summary>The number of seconds the response should be held in the cache. The default is 0, which means the response is not cached.</summary>
			private double _cacheDuration;
			#endregion

			#region Construction
			/// <summary>Used to store a cache request entry into call context.</summary>
			/// <param name="cacheDuration">The number of seconds the response should be held in the cache. The default is 0, which means the response is not cached.</param>
			public CacheEntry(double cacheDuration) { _cacheDuration = cacheDuration; }
			#endregion

			#region Properties
			/// <summary>The number of seconds the response should be held in the cache. The default is 0, which means the response is not cached.</summary>
			public double CacheDuration { get { return _cacheDuration; } }
			#endregion
		}
	}
}
