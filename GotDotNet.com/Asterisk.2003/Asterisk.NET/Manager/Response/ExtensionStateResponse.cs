using System.Text;

namespace Asterisk.NET.Manager.Response
{
	public class ExtensionStateResponse : ManagerResponse
	{
		private string exten;
		private string context;
		private string hint;
		private int status;

		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		virtual public string Hint
		{
			get { return hint; }
			set { this.hint = value; }
		}
		virtual public int Status
		{
			get { return status; }
			set { this.status = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": actionId='" + ActionId);
			sb.Append("'; message='" + Message);
			sb.Append("'; response='" + Response);
			sb.Append("'; uniqueId='" + UniqueId);
			sb.Append("'; exten='" + Exten);
			sb.Append("'; context='" + Context);
			sb.Append("'; hint='" + Hint);
			sb.Append("'; status='" + Status);
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}
