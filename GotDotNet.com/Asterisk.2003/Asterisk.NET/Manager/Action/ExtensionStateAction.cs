using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ExtensionStateAction queries the state of an extension in a given context.
	/// </summary>
	public class ExtensionStateAction : AbstractManagerAction
	{
		private string exten;
		private string context;

		/// <summary>
		/// Get the name of this action, i.e. "ExtensionState".
		/// </summary>
		override public string Action
		{
			get { return "ExtensionState"; }
		}
		/// <summary>
		/// Get/Set the extension to query.
		/// </summary>
		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the name of the context that contains the extension to query.
		/// </summary>
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}		
	}
}