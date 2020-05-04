using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace ParserEngine
{
	/// <summary>
	/// Summary description for RegexEngine.
	/// </summary>
	public class RegexEngine
	{
		
		#region Private Variables
		private string _html;
		private string _regexString;
		#endregion

		#region Public Properties
		public string Html
		{
			get
			{
				return _html;
			}
			set
			{
				_html = value;
			}
		}
		public string RegexString
		{
			get
			{
				return _regexString;
			}
			set
			{
				_regexString = value;
			}
		}
		#endregion
		
		#region  Constructors
		public RegexEngine()
		{
			
		}

		public RegexEngine(string html, string regexString)
		{
			this.RegexString = regexString;
			this.Html = html;
		}
		#endregion

		#region Methods
		public ArrayList ParseHtml()
		{
			ArrayList stringList = new ArrayList();

			Regex reg = new Regex(RegexString);

			MatchCollection matches = reg.Matches(Html);
			
			foreach ( Match match in matches )
			{
				foreach ( Group group in match.Groups )
				{
					string str = group.Value;
					stringList.Add(str);
				}
			}

			return stringList;
		}
		#endregion
	}
}
