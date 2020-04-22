using System.Text;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// This class implements the ManagerAction interface
	/// and can serve as base class for your concrete Action implementations.
	/// </summary>
	public abstract class AbstractManagerAction : IManagerAction
	{
		private string actionId;

		public abstract string Action
		{
			get;
		}
		virtual public string ActionId
		{
			get { return actionId; }
			set { this.actionId = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": action='" + Action);
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}
