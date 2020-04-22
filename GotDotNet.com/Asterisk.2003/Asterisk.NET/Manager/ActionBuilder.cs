using System;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Asterisk.NET.Manager
{
	public enum AsteriskVersion
	{
		ASTERISK_1_0 = 10,
		ASTERISK_1_2 = 12
	}
	/// <summary>
	/// Default implementation of the ActionBuilder interface.
	/// </summary>
	public class ActionBuilder : IActionBuilder
	{
		private const string LINE_SEPARATOR = "\r\n";

		private Util.ILog logger;
		private AsteriskVersion targetVersion;

		#region Constructor - ActionBuilder()
		public ActionBuilder()
		{
			this.targetVersion = AsteriskVersion.ASTERISK_1_0;
			logger = Util.LogFactory.getLog(GetType());
		}
		#endregion

		#region TargetVersion
		/// <summary>
		/// Get/Set the version of the Asterisk server to built the action for.
		/// </summary>
		public AsteriskVersion TargetVersion
		{
			get { return targetVersion; }
			set { this.targetVersion = value; }
		}
		#endregion

		#region BuildAction(action)
		public string BuildAction(Action.IManagerAction action)
		{
			MethodInfo getter;
			object val;
			StringBuilder sb = new StringBuilder();
			string strVal;
			IDictionary getters = getGetters(action.GetType());

			foreach (string name in getters.Keys)
			{
				if (name == "class")
					continue;
				getter = (MethodInfo)getters[name];
				try
				{
					val = getter.Invoke(action, new object[] { });
				}
				catch (UnauthorizedAccessException ex)
				{
					logger.error("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
					continue;
				}
				catch (TargetInvocationException ex)
				{
					logger.error("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
					continue;
				}

				if (val == null)
					continue;
				else if (val is Type)
					continue;
				else if (val is IDictionary)
				{
					// appendMap(sb, name, (IList)val);
					continue;
				}
				else if (val is string)
					strVal = (string)val;
				else
					strVal = val.ToString();
				appendString(sb, name, strVal);
			}
			sb.Append(LINE_SEPARATOR);
			return sb.ToString();
		}
		#endregion

		#region getGetters(class)
		/// <summary>
		/// Returns a Map of getter methods of the given class.<br/>
		/// The key of the map contains the name of the attribute that can be accessed by the getter, the
		/// value the getter itself . A method is considered a getter if its name starts with "get",
		/// it is declared public and takes no arguments.
		/// </summary>
		/// <param name="clazz">the class to return the getters for</param>
		/// <returns> a Map of attributes and their accessor methods (getters)</returns>
		private IDictionary getGetters(Type clazz)
		{
			IDictionary accessors = new Hashtable();
			MethodInfo[] methods = clazz.GetMethods();
			string name;
			string methodName;
			MethodInfo method;

			for (int i = 0; i < methods.Length; i++)
			{
				method = methods[i];
				methodName = method.Name;

				// skip not "get..." methods and  skip methods with != 0 parameters
				if (!methodName.StartsWith("get_") || method.GetParameters().Length != 0) continue;

				name = methodName.Substring("get_".Length).ToLower();
				if (name.Length == 0) continue;
				accessors[name] = method;
			}
			return accessors;
		}
		#endregion

		private void appendString(StringBuilder sb, string key, string val)
		{
	        sb.Append(key);
		    sb.Append(": ");
			sb.Append(val);
			sb.Append(LINE_SEPARATOR);
		}
	}
}