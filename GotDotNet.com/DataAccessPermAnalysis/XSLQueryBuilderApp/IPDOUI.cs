using System;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	public interface IPDOUI
	{
		DialogResult ShowDialog(IWin32Window parent);
	}
}
