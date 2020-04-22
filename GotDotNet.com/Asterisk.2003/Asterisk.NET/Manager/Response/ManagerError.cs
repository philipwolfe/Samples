namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Represents an "Response: Error" response received from the asterisk server.
	/// The cause for the error is given in the message attribute.
	/// </summary>
	public class ManagerError : ManagerResponse
	{
		/// <summary> Creates a new ManagerError.</summary>
		public ManagerError()
		{
		}
	}
}