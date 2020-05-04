using System;
using System.Collections.Generic;
using System.Text;

namespace UrlBuddy
{
	public class UrlInfo
	{
		public string Url;
		public string Title;

		public UrlInfo()
		{}

		public UrlInfo(string url) : this(url, url)
		{}

		public UrlInfo(string url, string title)
		{
			Url = url;
			Title = title;
		}
	}
}
