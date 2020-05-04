using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP list box control.</remarks>
public class XpListBox : System.Windows.Forms.ListBox
{
	[DllImport("user32.dll")]
	private static extern IntPtr GetWindowDC(IntPtr hWnd);

	/// <summary>
	/// Initializes a new instance of the XpListBox class.
	/// </summary>
	public XpListBox()
	{
		this.ResizeRedraw = true;
	}


	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);

		if (m.Msg == 0x0085)  // WM_NCPAINT
		{
			Graphics g = Graphics.FromHdc(GetWindowDC(m.HWnd));
			
			ControlPaint.DrawBorder(g, 0, 0, this.Width - 1, this.Height - 1);
			this.DrawInnerBorder(g);
			g.Dispose();
		}
	}

	/// <summary>
	/// Draws the inner border of the XpListBox object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the inner border of the XpListBox.</param>
	private void DrawInnerBorder(Graphics g)
	{
		g.DrawRectangle(new Pen(this.BackColor, 0), 1, 1,
			this.Width - 3, this.Height - 3);
	}
}

}
