using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace UrlBuddy
{
	public class UrlMenuItem : ToolStripMenuItem
	{
		private UrlInfo _urlInfo;

		public UrlMenuItem(UrlInfo urlInfo) : base(urlInfo.Title)
		{
			_urlInfo = urlInfo;
		}

		protected override void OnClick(EventArgs e)
		{
			Process.Start(_urlInfo.Url);
		}

		public UrlInfo UrlInfo
		{
			get { return _urlInfo; }
		}
	}
}
