using System;
using System.Collections;
using System.Net;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Defines an object to provide client request information to an AGIScript.<br/>
	/// This includes information about the channel the script is invoked on and
	/// parameters passed from the dialplan.
	/// </summary>
	public interface IAGIRequest
	{
		/// <summary>
		/// Returns a Map containing the raw request name/value pairs.
		/// </summary>
		IDictionary Request
		{
			get;
		}
		/// <summary>
		/// Returns the full URL of the requestURL in the form
		/// agi://host[:port][/script][?param1=value1&param2=value2].
		/// </summary>
		string RequestURL
		{
			get;
		}
		/// <summary>
		/// Returns the name of the channel.
		/// </summary>
		string Channel
		{
			get;
		}
		/// <summary> Returns the unqiue id of the channel.
		/// 
		/// </summary>
		string UniqueId
		{
			get;
		}
		/// <summary>
		/// Returns the type of the channel, for example "SIP".
		/// </summary>
		string Type
		{
			get;
		}
		/// <summary>
		/// Returns the language, for example "en".
		/// </summary>
		string Language
		{
			get;
		}
		/// <summary>
		/// Returns the Caller*ID, for example "1234".
		/// </summary>
		string CallerId
		{
			get;
		}
		/// <summary>
		/// Returns the the Caller*ID Name, for example "John Doe".
		/// </summary>
		string CallerIdName
		{
			get;
		}
		/// <summary>
		/// Returns the number, that has been dialed by the user.
		/// </summary>
		string Dnid
		{
			get;
		}
		/// <summary>
		/// If this call has been forwared, the number of the person doing the
		/// redirect is returned (Redirected dialed number identification service).<br/>
		/// This is usally only only available on PRI.
		/// </summary>
		/// <returns>the number of the person doing the redirect.</returns>
		string Rdnis
		{
			get;
		}
		/// <summary>
		/// Returns the context in the dial plan from which the AGI script was called.
		/// </summary>
		string Context
		{
			get;
		}
		/// <summary>
		/// Returns the extension in the dial plan from which the AGI script was called.
		/// </summary>
		string Extension
		{
			get;
		}
		/// <summary>
		/// Returns the priority in the dial plan from which the AGI script was called.
		/// </summary>
		int Priority
		{
			get;
		}
		/// <summary>
		/// Returns wheather this agi is passed audio (EAGI - Enhanced AGI).<br/>
		/// Enhanced AGI is currently not supported on FastAGI.
		/// </summary>
		/// <returns><code>true</code> if this agi is passed audio, <code>false</code> otherwise.</returns>
		bool Enhanced
		{
			get;
		}
		/// <summary>
		/// Returns the account code set for the call.
		/// </summary>
		string AccountCode
		{
			get;
		}
		
		/// <summary>
		/// Returns the name of the script to execute including its full path.<br/>
		/// This corresponds to the request url with protocol, host, port and
		/// parameters stripped off.
		/// </summary>
		/// <returns>the name of the script to execute.</returns>
		string Script();
		
		/// <summary>
		/// Returns the value of a request parameter as a String, or
		/// <code>null</code> if the parameter does not exist. You should only use
		/// this method when you are sure the parameter has only one value.<br/>
		/// If the parameter might have more than one value, use getParameterValues(String).<br/>
		/// If you use this method with a multivalued parameter, the value returned
		/// is equal to the first value in the array returned by <code>getParameterValues</code>.
		/// </summary>
		/// <param name="name">a String containing the name of the parameter whose value is requested.</param>
		/// <returns>a String representing the single value of the parameter.</returns>
		/// <seealso cref="getParameterValues(String)" />
		string Parameter(string name);
		
		/// <summary>
		/// Returns an array of String objects containing all of the values the given
		/// request parameter has, or
		/// <code>null</coder> if the parameter does not exist.<br/>
		/// If the parameter has a single value, the array has a length of 1.
		/// </summary>
		/// <param name="name">a String containing the name of the parameter whose value is requested.</param>
		/// <returns> an array of String objects containing the parameter's values.</returns>
		string[] ParameterValues(string name);
		
		/// <summary>
		/// Returns a IDictionary of the parameters of this request.
		/// </summary>
		/// <returns>
		/// a IDictionary containing parameter names as keys and parameter
		/// values as map values. The keys in the parameter map are of type
		/// String. The values in the parameter map are of type String array.
		/// </returns>
		IDictionary ParameterMap();

		/// <summary>
		/// Get the local address this channel, that is the IP address of the AGI server.
		/// </summary>
		IPAddress LocalAddress
		{
			get;
		}

		/// <summary>
		/// Returns the local port this channel, that is the port of the AGI server.
		/// </summary>
		int LocalPort
		{
			get;
		}

		/// <summary>
		/// Returns the remote address this channel, that is the IP address of the Asterisk server.
		/// </summary>
		IPAddress RemoteAddress
		{
			get;
		}

		/// <summary>
		/// Returns the remote port this channel, that is the port of the Asterisk server.
		/// </summary>
		int RemotePort
		{
			get;
		}
	}
}