using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP date time picker control.</remarks>
public class XpDateTimePicker : System.Windows.Forms.DateTimePicker
{
	// Why is the BackColor property missing???
	private ControlState enmState = ControlState.Normal;
	private Label lblButton;
	

	[DllImport("user32")]
	private static extern IntPtr GetWindowDC(IntPtr hWnd);
	[DllImport("user32")]
	private static extern int PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

	/// <summary>
	/// Initializes a new instance of the XpDateTimePicker class.
	/// </summary>
	public XpDateTimePicker()
	{
		lblButton = new System.Windows.Forms.Label();
		lblButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		lblButton.BackColor = SystemColors.Window;
		lblButton.Location = new Point(this.Width - 21, 0);
		lblButton.Paint += new PaintEventHandler(this.OnDropDownPaint);
		lblButton.MouseEnter += new EventHandler(this.OnDropDownMouseEnter);
		lblButton.MouseDown += new MouseEventHandler(this.OnDropDownMouseDown);
		lblButton.MouseUp += new MouseEventHandler(this.OnDropDownMouseUp);
		lblButton.MouseLeave += new EventHandler(this.OnDropDownMouseLeave);
		
		this.Controls.Add(lblButton);
		this.ResizeRedraw = true;
	}



	#region Properties
	public new Font Font
	{
		get { return base.Font; }
		set 
		{
			base.Font = value;
			lblButton.Height = this.Height - 4;
		}
	}

	/// <value>Indicates the state of the XpDateTimePicker.</value>
	protected ControlState ControlState
	{
		get { return enmState; }
	}

	/// <value>Gets the clipping rectangle for the drop down button of the XpDateTimePicker.</value>
	protected Rectangle DropDownRectangle
	{
		get { return new Rectangle(2, 0, lblButton.Width - 3, lblButton.Height - 1); }
	}

	#endregion


	#region Methods
	protected override void OnHandleCreated(EventArgs ea)
	{
		base.OnHandleCreated(ea);
		lblButton.Size = new Size(17, this.Height - 4);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 0x0085)  // WM_NCPAINT
		{
			Graphics g = Graphics.FromHdc(GetWindowDC(m.HWnd));
			
			ControlPaint.DrawBorder(g, 0, 0, this.Width - 1, this.Height - 1);
			this.DrawInnerBorder(g);
			g.Dispose();

			m.Result = IntPtr.Zero;
			return;
		}

		base.WndProc(ref m);
	}

	
	private void OnDropDownMouseEnter(object sender, EventArgs ea)
	{
		enmState = ControlState.Hover;
		lblButton.Invalidate();
	}

	private void OnDropDownMouseDown(object sender, MouseEventArgs ea)
	{
		if (ea.Button == MouseButtons.Left)
		{
			enmState = ControlState.Pressed;
			lblButton.Invalidate();

			// The exact coordinates aren't really important.
			// Just make sure that it falls inside the drop down button.
			int x = lblButton.Left + 3;
			int y = 3 << 16;

			// 0x0201 == WM_LBUTTONDOWN, 0x0202 == WM_LBUTTONUP
			PostMessage(this.Handle, 0x0201, 0, y | x);
			PostMessage(this.Handle, 0x0202, 0, y | x);
		}	
	}

	private void OnDropDownMouseUp(object sender, MouseEventArgs ea)
	{
		enmState = ControlState.Normal;
		lblButton.Invalidate();
	}

	private void OnDropDownMouseLeave(object sender, EventArgs ea)
	{
		enmState = ControlState.Normal;
		lblButton.Invalidate();
	}

	private void OnDropDownPaint(object sender, PaintEventArgs ea)
	{
		Graphics g = ea.Graphics;
		ControlState cs;
		if (this.Enabled)
			cs = this.ControlState;
		else
			cs = ControlState.Disabled;

		ControlPaint.DrawArrow(g, this.DropDownRectangle, 
			ArrowDirection.Down, cs);
	}

	/// <summary>
	/// Draws the inner border of the XpDateTimePicker object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the inner border of the XpDateTimePicker.</param>
	private void DrawInnerBorder(Graphics g)
	{
		g.DrawRectangle(new Pen(SystemColors.Window, 0), 1, 1,
			this.Width - 3, this.Height - 3);
	}
	#endregion

}

}
