// Stephen Toub
// stoub@microsoft.com
// 10/03/02
//
// RemotingCacheAttribute.cs
// v1.1

using System;
using System.Web;
using System.Web.Caching;

namespace Toub.Remoting
{
	/// <summary>Used to specify that a method or property should be cached by the CachingServerChannelSink.</summary>
	[AttributeUsage(
		 AttributeTargets.Method | AttributeTargets.Property,
		 AllowMultiple=false,
		 Inherited=false)]
	public class RemotingCacheAttribute : System.Attribute
	{
		#region Member Variables
		/// <summary>
		/// The interval in seconds between the time the inserted object was last accessed and 
		/// when that object expires.  A value less than or equal to zero means no expiration.</summary>
		private double _cacheDuration;
		#endregion

		#region Construction
		/// <summary>Initialize the attribute.  The cached item will not expire.</summary>
		public RemotingCacheAttribute()
		{
			// No expiration
			_cacheDuration = -1;
		}

		/// <summary>Initialize the attribute.  The cached item will expire after the specified number of seconds.</summary>
		/// <param name="cacheDuration">The number of seconds the response should be held in the cache. The default is 0, which means the response is not cached.</param>
		public RemotingCacheAttribute(double cacheDuration)
		{
			// Make sure the cache duration is valid.
			if (cacheDuration < 0) throw new ArgumentException("The cache duration must be at least 0 seconds.", "cacheDuration");
		
			// Set the sliding expiration
			_cacheDuration = cacheDuration;
		}
		#endregion

		#region Properties
		/// <summary>Gets the interval in seconds between the time the inserted object was last accessed and when that object expires.</summary>
		public double CacheDuration { get { return _cacheDuration; } }
		#endregion
	}
}
