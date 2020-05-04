using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP text box control.</remarks>
public class XpTextBox : System.Windows.Forms.TextBox
{
	[DllImport("user32.dll")]
	private static extern IntPtr GetWindowDC(IntPtr hWnd);

	/// <summary>
	/// Initializes a new instance of the XpTextBox class.
	/// </summary>
	public XpTextBox()
	{
	}



	protected override void WndProc(ref Message m)
	{
		// Base class implementation has to be called no matter what
		// because the scroll bars of multiline textboxes are drawn
		// in WM_NCPAINT
		base.WndProc(ref m);

		if (m.Msg == 0x0085)  // WM_NCPAINT
		{
			Graphics gNcPaint = Graphics.FromHdc(GetWindowDC(this.Handle));
			ControlPaint.DrawBorder(gNcPaint, 0, 0, this.Width - 1, this.Height - 1);
			this.DrawInnerBorder(gNcPaint);
			gNcPaint.Dispose();
		}
	}

	/// <summary>
	/// Draws the inner border of the XpTextBox object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the inner border of the XpTextBox.</param>
	private void DrawInnerBorder(Graphics g)
	{
		g.DrawRectangle(new Pen(this.BackColor, 0), 1, 1,
			this.Width - 3, this.Height - 3);
	}
}

}
