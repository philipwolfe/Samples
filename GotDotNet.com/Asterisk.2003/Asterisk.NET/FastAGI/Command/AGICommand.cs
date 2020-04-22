using System.Text;
namespace Asterisk.NET.FastAGI.Command
{
	public abstract class AGICommand
	{
		public abstract string BuildCommand();
		protected internal virtual string EscapeAndQuote(string s)
		{
			string tmp;
			if (s == null || s.Length == 0)
				return "\"\"";
			tmp = s;
			tmp = tmp.Replace("\\\"", "\\\\\""); // escape quotes
			tmp = tmp.Replace("\\\n", ""); // filter newline
			return "\"" + tmp + "\""; // add quotes
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": command='" + BuildCommand());
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}
