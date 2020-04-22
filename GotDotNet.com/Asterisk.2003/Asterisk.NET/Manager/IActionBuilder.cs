using Asterisk.NET.Manager.Action;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Transforms ManagerActions to Strings suitable to be sent to Asterisk.<br/>
	/// The attributes are determined using reflection.
	/// </summary>
	public interface IActionBuilder
	{
		AsteriskVersion TargetVersion
		{
			get;
			set;
		}
		/// <summary>
		/// Builds a String suitable to be sent to Asterisk based on the given action object.<br/>
		/// Asterisk actions consist of an unordered set of key value pairs corresponding to the
		/// attributes of the ManagerActions. Key and value are separated by a colon (":"), key value
		/// pairs by a CR/LF ("\r\n"). An action is terminated by an empty line ("\r\n\r\n").
		/// </summary>
		/// <param name="action">the action to transform</param>
		/// <returns> a String representing the given action in an asterisk compatible format</returns>
		string BuildAction(IManagerAction action);
	}
}