using System;
using System.IO;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;
using System.Net;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Default implementation of the AGIRequest interface.
	/// </summary>
	public class AGIRequest : IAGIRequest
	{
		#region Variables
		private static Regex SCRIPT_PATTERN = new Regex("^([^\\?]*)\\?(.*)$");
		private static Regex PARAMETER_PATTERN = new Regex("^(.*)=(.*)$");

		private string rawCallerId;
		private IDictionary request;

		/// <summary> A map assigning the values of a parameter (an array of Strings) to the name of the parameter.</summary>
		private IDictionary parameterMap;

		private string parameters;
		private string script;
		private bool callerIdCreated;
		private IPAddress localAddress;
		private int localPort;
		private IPAddress remoteAddress;
		private int remotePort;
		private Util.ILog logger;
		#endregion

		#region Constructor - AGIRequest(ICollection environment)
		/// <summary>
		/// Creates a new AGIRequest.
		/// </summary>
		/// <param name="environment">the first lines as received from Asterisk containing the environment.</param>
		public AGIRequest(ICollection environment)
		{
			logger = Util.LogFactory.getLog(GetType());
			if (environment == null)
				throw new ArgumentException("Environment must not be null.");

			request = buildMap(environment);
		}
		#endregion

		#region Request
		virtual public IDictionary Request
		{
			get { return request; }
		}
		#endregion
		#region RequestURL
		/// <summary>
		/// Returns the full URL of the request in the form agi://host[:port][/script].
		/// </summary>
		virtual public string RequestURL
		{
			get { return (string) request["request"]; }
		}
		#endregion
		#region Channel
		/// <summary>
		/// Returns the name of the channel.
		/// </summary>
		/// <returns>the name of the channel.</returns>
		virtual public string Channel
		{
			get { return (string) request["channel"]; }
		}
		#endregion
		#region UniqueId
		/// <summary>
		/// Returns the unqiue id of the channel.
		/// </summary>
		/// <returns>the unqiue id of the channel.</returns>
		virtual public string UniqueId
		{
			get { return (string) request["uniqueid"]; }
		}
		#endregion
		#region Type
		/// <summary>
		/// Returns the type of the channel, for example "SIP".
		/// </summary>
		/// <returns>the type of the channel, for example "SIP".</returns>
		virtual public string Type
		{
			get { return (string) request["type"]; }
		}
		#endregion
		#region Language
		/// <summary>
		/// Returns the language, for example "en".
		/// </summary>
		virtual public string Language
		{
			get { return (string) request["language"]; }
		}
		#endregion
		#region CallerId
		virtual public string CallerId
		{
			get
			{
				int lbPosition;
				int rbPosition;
				
				if (!callerIdCreated)
				{
					rawCallerId = ((string) request["callerid"]);
					callerIdCreated = true;
				}
				
				if (rawCallerId == null)
				{
					return null;
				}
				
				lbPosition = rawCallerId.IndexOf('<');
				rbPosition = rawCallerId.IndexOf('>');
				
				if (lbPosition < 0 || rbPosition < 0)
				{
					return rawCallerId;
				}
				
				return rawCallerId.Substring(lbPosition + 1, (rbPosition) - (lbPosition + 1));
			}

		}
		#endregion
		#region CallerIdName
		virtual public string CallerIdName
		{
			get
			{
				int lbPosition;
				string callerIdName;
				
				if (!callerIdCreated)
				{
					rawCallerId = ((string) request["callerid"]);
					callerIdCreated = true;
				}
				
				if (rawCallerId == null)
					return null;
				
				lbPosition = rawCallerId.IndexOf('<');
				
				if (lbPosition < 0)
					return null;
				
				callerIdName = rawCallerId.Substring(0, (lbPosition) - (0)).Trim();
				if (callerIdName.StartsWith("\"") && callerIdName.EndsWith("\""))
					callerIdName = callerIdName.Substring(1, (callerIdName.Length - 1) - (1));
				
				if (callerIdName.Length == 0)
					return null;
				else
					return callerIdName;
			}
		}
		#endregion
		#region Dnid
		virtual public string Dnid
		{
			get
			{
				return (string) request["dnid"];
			}

		}
		#endregion
		#region Rdnis
		virtual public string Rdnis
		{
			get
			{
				return (string) request["rdnis"];
			}

		}
		#endregion
		#region Context
		/// <summary>
		/// Returns the context in the dial plan from which the AGI script was called.
		/// </summary>
		virtual public string Context
		{
			get { return (string) request["context"]; }
		}
		#endregion
		#region Extension
		/// <summary>
		/// Returns the extension in the dial plan from which the AGI script was called.
		/// </summary>
		virtual public string Extension
		{
			get { return (string) request["extension"]; }
		}
		#endregion
		#region Priority
		/// <summary>
		/// Returns the priority in the dial plan from which the AGI script was called.
		/// </summary>
		virtual public int Priority
		{
			get
			{
				if (request["priority"] != null)
				{
					return Int32.Parse((string) request["priority"]);
				}
				return -1;
			}

		}
		#endregion
		#region Enhanced
		/// <summary>
		/// Returns wheather this agi is passed audio (EAGI - Enhanced AGI).<br/>
		/// Enhanced AGI is currently not supported on FastAGI.<br/>
		/// <code>true</code> if this agi is passed audio, <code>false</code> otherwise.
		/// </summary>
		virtual public bool Enhanced
		{
			get
			{
				if (request["enhanced"] != null && (string)request["enhanced"] == "1.0")
						return true;
				return false;
			}
		}
		#endregion
		#region AccountCode
		/// <summary>
		/// Returns the account code set for the call.
		/// </summary>
		virtual public string AccountCode
		{
			get
			{
				return (string) request["accountCode"];
			}

		}
		#endregion

		#region LocalAddress
		public IPAddress LocalAddress
		{
			get { return localAddress; }
			set { this.localAddress = value; }
		}
		#endregion
		#region LocalPort
		public int LocalPort
		{
			get { return localPort; }
			set { this.localPort = value; }
		}
		#endregion
		#region RemoteAddress
		public IPAddress RemoteAddress
		{
			get { return remoteAddress; }
			set { this.remoteAddress = value; }
		}
		#endregion
		#region RemotePort
		public int RemotePort
		{
			get { return remotePort; }
			set { this.remotePort = value; }
		}
		#endregion

		#region Script()
		/// <summary>
		/// Returns the name of the script to execute.
		/// </summary>
		public virtual string Script()
		{
			lock (this)
			{
				if (script != null)
				{
					return script;
				}
				
				script = ((string) request["network_script"]);
				if (script != null)
				{
					Match scriptMatcher = SCRIPT_PATTERN.Match(script);
					if (scriptMatcher.Success)
					{
						script = scriptMatcher.Groups[1].Value;
						parameters = scriptMatcher.Groups[2].Value;
					}
				}
				return script;
			}
		}
		#endregion
		#region Parameter(string name)
		public virtual string Parameter(string name)
		{
			string[] values;
			values = ParameterValues(name);
			if (values == null || values.Length == 0)
				return null;
			
			return values[0];
		}
		#endregion
		#region ParameterValues(string name)
		public virtual string[] ParameterValues(string name)
		{
			if ((ParameterMap().Count == 0))
				return null;
			
			return (string[]) parameterMap[name];
		}
		#endregion
		#region ParameterMap()
		public virtual IDictionary ParameterMap()
		{
			lock (this)
			{
				if (parameterMap == null)
				{
					parameterMap = parseParameters(parameters);
				}
				return parameterMap;
			}
		}
		#endregion
		#region ToString()
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": script='" + Script());
			sb.Append("'; requestURL='" + RequestURL);
			sb.Append("'; channel='" + Channel);
			sb.Append("'; uniqueId='" + UniqueId);
			sb.Append("'; type='" + Type);
			sb.Append("'; language='" + Language);
			sb.Append("'; callerId='" + CallerId);
			sb.Append("'; callerIdName='" + CallerIdName);
			sb.Append("'; dnid='" + Dnid);
			sb.Append("'; rdnis='" + Rdnis);
			sb.Append("'; context='" + Context);
			sb.Append("'; extension='" + Extension);
			sb.Append("'; priority='" + Priority);
			sb.Append("'; enhanced='" + Enhanced.ToString());
			sb.Append("'; accountCode='" + AccountCode);
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
		#endregion

		#region buildMap(ICollection lines)
		/// <summary>
		/// Builds a map containing variable names as key (with the "agi_" prefix
		/// stripped) and the corresponding values.<br/>
		/// Syntactically invalid and empty variables are skipped.
		/// </summary>
		/// <param name="lines">the environment to transform.</param>
		/// <returns> a map with the variables set corresponding to the given environment.</returns>
		private IDictionary buildMap(ICollection lines)
		{
			int colonPosition;
			string key;
			string val;

			IDictionary map = new Hashtable();
			foreach (string line in lines)
			{
				colonPosition = line.IndexOf(':');
				if (colonPosition < 0)
					continue;
				if (!line.StartsWith("agi_"))
					continue;

				if (line.Length < colonPosition + 2)
					continue;

				key = line.Substring(4, colonPosition - 4).ToLower();
				val = line.Substring(colonPosition + 2);
				if (val.Length != 0)
					map[key] = val;
			}
			return map;
		}
		#endregion
		#region parseParameters(string s)
		/// <summary>
		/// Parses the given parameter string and caches the result.
		/// </summary>
		/// <param name="s">the parameter string to parse</param>
		/// <returns> a Map made up of parameter names their values</returns>
		private IDictionary parseParameters(string s)
		{
			lock (this)
			{
				IDictionary result;
				IEnumerator parameterIterator;
				Utils.Tokenizer st;

				IDictionary parameterMap = new Hashtable();
				if (s == null)
					return parameterMap;


				st = new Utils.Tokenizer(s, "&");
				while (st.HasMoreTokens())
				{
					string parameter;
					Match parameterMatcher;
					string name;
					string val;
					IList values;
					
					parameter = st.NextToken();
					parameterMatcher = PARAMETER_PATTERN.Match(parameter);
					if (parameterMatcher.Success)
					{
						try
						{
							name = HttpUtility.UrlDecode(parameterMatcher.Groups[1].Value);
							val = HttpUtility.UrlDecode(parameterMatcher.Groups[2].Value);
						}
						catch(IOException e)
						{
							logger.error("Unable to decode parameter '" + parameter + "'", e);
							continue;
						}
					}
					else
					{
						try
						{
							name = HttpUtility.UrlDecode(parameter);
							val = "";
						}
						catch(IOException e)
						{
							logger.error("Unable to decode parameter '" + parameter + "'", e);
							continue;
						}
					}
					
					if (parameterMap[name] == null)
					{
						values = new ArrayList();
						values.Add(val);
						parameterMap[name] = values;
					}
					else
					{
						values = (IList) parameterMap[name];
						values.Add(val);
					}
				}
				
				result = new Hashtable();
				parameterIterator = new Utils.HashSetSupport(parameterMap.Keys).GetEnumerator();
				while (parameterIterator.MoveNext())
				{
					string name;
					IList values;
					string[] valueArray;
					
					name = ((string) parameterIterator.Current);
					values = (IList) parameterMap[name];
					
					valueArray = new string[values.Count];
					result[name] = Utils.ICollectionSupport.ToArray(values, valueArray);
				}
				
				return result;
			}
		}
		#endregion
	}
}