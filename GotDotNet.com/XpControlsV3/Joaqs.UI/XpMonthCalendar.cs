using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Joaqs.UI
{

/// <summary>Represents a Windows XP month calendar control.</summary>
public class XpMonthCalendar : System.Windows.Forms.MonthCalendar
{
	[DllImport("user32")]
	private static extern int PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

	private ControlState enmLeftState = ControlState.Normal;
	private ControlState enmRightState = ControlState.Normal;
	private Label lblLeftButton;
	private Label lblRightButton;


	/// <summary>
	/// Initializes a new instance of the XpMonthCalendar class.
	/// </summary>
	public XpMonthCalendar()
	{
		lblLeftButton = new System.Windows.Forms.Label();
		lblRightButton = new System.Windows.Forms.Label();

		lblLeftButton.BackColor = this.TitleBackColor;
		lblLeftButton.Size = new Size(22, 17);
		lblLeftButton.Paint += new PaintEventHandler(this.OnLeftButtonPaint);
		lblLeftButton.MouseMove += new MouseEventHandler(this.OnLeftButtonMouseMove);
		lblLeftButton.MouseDown += new MouseEventHandler(this.OnLeftButtonMouseDown);
		lblLeftButton.MouseUp += new MouseEventHandler(this.OnLeftButtonMouseUp);
		lblLeftButton.MouseLeave += new EventHandler(this.OnLeftButtonMouseLeave);


		lblRightButton.BackColor = this.TitleBackColor;
		lblRightButton.Size = lblLeftButton.Size;
		lblRightButton.Paint += new PaintEventHandler(this.OnRightButtonPaint);
		lblRightButton.MouseMove += new MouseEventHandler(this.OnRightButtonMouseMove);
		lblRightButton.MouseDown += new MouseEventHandler(this.OnRightButtonMouseDown);
		lblRightButton.MouseUp += new MouseEventHandler(this.OnRightButtonMouseUp);
		lblRightButton.MouseLeave += new EventHandler(this.OnRightButtonMouseLeave);

		this.Controls.Add(lblLeftButton);
		this.Controls.Add(lblRightButton);
		this.ResizeRedraw = true;
	}



	public new Font Font
	{
		get { return base.Font; }
		set 
		{
			base.Font = value;
			int top = this.ButtonTop;
			lblLeftButton.Top = top;
			lblRightButton.Location = new Point(this.Width - 28, top);
		}
	}

	public new Color TitleBackColor
	{
		get { return base.TitleBackColor; }
		set 
		{
			base.TitleBackColor = value;
			lblLeftButton.BackColor = value;
			lblRightButton.BackColor = value;
		}
	}

	/// <value>Get the y-coordinate of the next and previous buttons' top edge in pixels. </value>
	protected int ButtonTop
	{
		get { return (Convert.ToInt32(this.Height * 0.2f) - 17) / 2; }
	}

	/// <value>Indicates the state of the left button of the XpMonthCalendar object.</value>
	protected ControlState LeftButtonState
	{
		get { return enmLeftState; }
	}

	/// <value>Indicates the state of the right button of the XpMonthCalendar object.</value>
	protected ControlState RightButtonState
	{
		get { return enmRightState; }
	}

	/// <value>Gets the clipping rectangle for the next and previous buttons of the XpMonthCalendar object.</value>
	protected Rectangle ButtonRectangle
	{
		get { return new Rectangle(1, 2, 19, 12); }
	}

		

	protected override void OnHandleCreated(EventArgs ea)
	{
		base.OnHandleCreated(ea);

		int top = this.ButtonTop;
		lblLeftButton.Location = new Point(6, top);
		lblRightButton.Location = new Point(this.Width - 28, top);
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);

		if (m.Msg == 0x000F)  // WM_PAINT
		{
			Graphics g = this.CreateGraphics();
			ControlPaint.DrawBorder(g, 0, 0, 
				this.Width - 1, this.Height - 1);
			g.Dispose();
		}
	}

	
	
	private void OnLeftButtonPaint(object sender, PaintEventArgs ea)
	{
		Graphics g = ea.Graphics;
		Rectangle rc = this.ButtonRectangle;

		ControlState cs;
		if (this.Enabled)
			cs = this.LeftButtonState;
		else
			cs = ControlState.Disabled;

		ControlPaint.DrawArrow(g, rc, ArrowDirection.Left, cs);
		rc.Inflate(1, 1);
		g.DrawRectangle(new Pen(SystemColors.Window, 0), rc);
	}

	private void OnLeftButtonMouseMove(object sender, MouseEventArgs ea)
	{
		Rectangle rc = this.ButtonRectangle;

		if (rc.Contains(ea.X, ea.Y))
		{
			if (enmLeftState == ControlState.Normal)
			{
				enmLeftState = ControlState.Hover;
				lblLeftButton.Invalidate(rc);
			}
		}
		else
		{
			if (enmLeftState == ControlState.Hover ||
				enmLeftState == ControlState.Pressed)
			{
				enmLeftState = ControlState.Normal;
				lblLeftButton.Invalidate(rc);
			}
		}
	}

	private void OnLeftButtonMouseDown(object sender, MouseEventArgs ea)
	{
		if (enmLeftState == ControlState.Hover &&
			ea.Button == MouseButtons.Left)
		{
			enmLeftState = ControlState.Pressed;
			lblLeftButton.Invalidate(this.ButtonRectangle);

			// The exact coordinates aren't really important.
			// Just make sure that it falls inside the button.
			int x = lblLeftButton.Left + 5;
			int y = (lblLeftButton.Top + 5) << 16;

			// 0x0201 == WM_LBUTTONDOWN, 0x0202 == WM_LBUTTONUP
			// This disables the option of holding down the mouse button
			// and letting the months continously change. No other solution!
			PostMessage(this.Handle, 0x0201, 1, y | x);
			PostMessage(this.Handle, 0x0202, 1, y | x);
		}
	}

	private void OnLeftButtonMouseUp(object sender, MouseEventArgs ea)
	{
		enmLeftState = ControlState.Hover;
		lblLeftButton.Invalidate(this.ButtonRectangle);
	}

	private void OnLeftButtonMouseLeave(object sender, EventArgs ea)
	{
		enmLeftState = ControlState.Normal;
		lblLeftButton.Invalidate(this.ButtonRectangle);
	}


	private void OnRightButtonPaint(object sender, PaintEventArgs ea)
	{
		Graphics g = ea.Graphics;
		Rectangle rc = this.ButtonRectangle;

		ControlState cs;
		if (this.Enabled)
			cs = this.RightButtonState;
		else
			cs = ControlState.Disabled;

		ControlPaint.DrawArrow(g, rc, ArrowDirection.Right, cs);
		rc.Inflate(1, 1);
		g.DrawRectangle(new Pen(SystemColors.Window, 0), rc);
	}

	private void OnRightButtonMouseMove(object sender, MouseEventArgs ea)
	{
		Rectangle rc = this.ButtonRectangle;

		if (rc.Contains(ea.X, ea.Y))
		{
			if (enmRightState == ControlState.Normal)
			{
				enmRightState = ControlState.Hover;
				lblRightButton.Invalidate(rc);
			}
		}
		else
		{
			if (enmRightState == ControlState.Hover ||
				enmRightState == ControlState.Pressed)
			{
				enmRightState = ControlState.Normal;
				lblRightButton.Invalidate(rc);
			}
		}
	}

	private void OnRightButtonMouseDown(object sender, MouseEventArgs ea)
	{
		if (enmRightState == ControlState.Hover &&
			ea.Button == MouseButtons.Left)
		{
			enmRightState = ControlState.Pressed;
			lblRightButton.Invalidate(this.ButtonRectangle);

			// The exact coordinates aren't really important.
			// Just make sure that it falls inside the button.
			int x = lblRightButton.Left + 5;
			int y = (lblRightButton.Top + 5) << 16;

			// 0x0201 == WM_LBUTTONDOWN, 0x0202 == WM_LBUTTONUP
			// This disables the option of holding down the mouse button
			// and letting the months continously change. No other solution!
			PostMessage(this.Handle, 0x0201, 1, y | x);
			PostMessage(this.Handle, 0x0202, 1, y | x);
		}
	}

	private void OnRightButtonMouseUp(object sender, MouseEventArgs ea)
	{
		enmRightState = ControlState.Hover;
		lblRightButton.Invalidate(this.ButtonRectangle);
	}

	private void OnRightButtonMouseLeave(object sender, EventArgs ea)
	{
		enmRightState = ControlState.Normal;
		lblRightButton.Invalidate(this.ButtonRectangle);
	}

}

}
