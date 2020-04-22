using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Deletes an entry in the Asterisk database for a given family and key.<br/>
	/// Returns 1 if successful, 0 otherwise.
	/// </summary>
	public class DatabaseDelTreeCommand : AGICommand
	{
		/// <summary> The family of the key to delete.</summary>
		private string family;
		/// <summary> The key to delete.</summary>
		private string varKey;

		/// <summary>
		/// Get/Set the family of the key to delete.
		/// </summary>
		virtual public string Family
		{
			get { return family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the the key to delete.
		/// </summary>
		virtual public string Key
		{
			get { return varKey; }
			set { this.varKey = value; }
		}
		/// <summary>
		/// Creates a new DatabaseDelCommand.
		/// </summary>
		/// <param name="family">the family of the key to delete.</param>
		/// <param name="key">the key to delete.</param>
		public DatabaseDelTreeCommand(string family, string key)
		{
			this.family = family;
			this.varKey = key;
		}

		public override string BuildCommand()
		{
			return "DATABASE DEL " + EscapeAndQuote(family) + " " + EscapeAndQuote(varKey);
		}
	}
}