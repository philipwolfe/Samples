using System;

namespace Toub.Remoting
{
	/// <summary>Dummy object with methods that can be cached with the CachingServerMessageSink.</summary>
	public class SampleObject : MarshalByRefObject
	{
		private string _testStr = "Remoting a string. ";

		public SampleObject() {}

		/// <summary>Result is cached for 30 seconds.</summary>
		[RemotingCache(45)]
		public string GetString(int i)
		{
			i %= _testStr.Length;
			System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1.0)); // take extra time
			return _testStr.Substring(i, _testStr.Length-i) + _testStr.Substring(0, i);
		}

		/// <summary>Result is cached for 45 seconds.</summary>
		public string GetString2(int i)
		{
			RemotingCache.AddEntry(45);

			i %= _testStr.Length;
			System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1.0)); // take extra time
			return _testStr.Substring(i, _testStr.Length-i) + _testStr.Substring(0, i);
		}
	}
}
