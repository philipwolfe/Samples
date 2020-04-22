using System.Collections;
namespace Asterisk.NET.Manager
{
	/// <summary>
	/// The AsteriskManager is built on top of the ManagerConnection and is an
	/// attempt to simplify interaction with Asterisk by abstracting the interface.<br/>
	/// You will certainly have less freedom using AsteriskManager but it will make
	/// life easier for easy things (like originating a call or getting a list of
	/// open channels).<br/>
	/// AsteriskManager is still in an early state of development. So, when using
	/// AsteriskManager be aware that it might change in the future.
	/// </summary>
	public interface IAsteriskManager
	{
		/// <summary>
		/// Returns a Map of active channels.<br/>
		/// The map contain the channel names as keys and objects of type Manager.Channel as values.
		/// </summary>
		/// <returns> a Map of active channels.</returns>
		IDictionary Channels
		{
			get;
		}
		/// <summary>
		/// Returns a Map of all queues.<br/>
		/// The map contains the queue names as keys and objects of type Queue as values.
		/// </summary>
		/// <returns>a Map of queues.</returns>
		IDictionary Queues
		{
			get;
		}
		/// <summary>
		/// Generates an outgoing call.
		/// </summary>
		/// <param name="originate">conatins the details of the call to originate</param>
		/// <returns> a Call object representing the originated call</returns>
		/// <throws>  TimeoutException if the originated call is not answered in time </throws>
		/// <throws>  IOException if the action cannot be sent to the asterisk server </throws>
		Call OriginateCall(Originate originate);
		
		/// <summary>
		/// Returns the version of the Asterisk server you are connected to.<br/>
		/// This typically looks like "Asterisk 1.0.9 built by root@host on a i686 running Linux".
		/// </summary>
		/// <returns> the version of the Asterisk server you are connected to</returns>
		string Version();
		
		/// <summary>
		/// Returns the CVS revision of a given source file of the Asterisk server you are connected to.<br/>
		/// For example Version("app_meetme.c") may return {1, 102} for CVS revision "1.102".<br/>
		/// Note that this feature is not available with Asterisk 1.0.x.<br/>
		/// You can use this feature if you need to write applications that behave
		/// different depending on specific modules being available in a specific
		/// version or not.
		/// </summary>
		/// <param name="file">the file for which to get the version like "app_meetme.c"</param>
		/// <returns> the CVS revision of the file, or <code>null</code> if that file
		/// is not part of the Asterisk instance you are connected to (maybe
		/// due to a module that provides it has not been loaded) or if you
		/// are connected to an Astersion 1.0.x
		/// </returns>
		int[] Version(string file);
	}
}