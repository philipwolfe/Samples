using System;

namespace HtmlAgilityPack.Samples
{
	class Html2Xml
	{
		[STAThread]
		static void Main(string[] args)
		{
			HtmlDocument doc = new HtmlDocument();
//			doc.Load(@"..\..\mshome.htm");
			doc.Load(@"obout_tree.htm");
			doc.OptionOutputAsXml = true;
//			doc.Save("mshome.xml");
			doc.Save("obout.xml");
		}
	}
}
