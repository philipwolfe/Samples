using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP combo box control.</remarks>
public class XpComboBox : System.Windows.Forms.ComboBox
{
	private ControlState enmState = ControlState.Normal;


	[DllImport("user32.dll")]
	private static extern IntPtr GetWindowDC(IntPtr hWnd);

	/// <summary>
	/// Initializes a new instance of the XpComboBox class.
	/// </summary>
	public XpComboBox()
	{
	}



	#region Properties
	/// <value>Indicates the state of the XpComboBox.</value>
	protected ControlState ControlState
	{
		get { return enmState; }
	}

	/// <value>Gets the clipping rectangle for the drop down button of the XpCheckBox.</value>
	protected Rectangle DropDownRectangle
	{
		get 
		{
			// Button's width is 15 pixels. There is a 2 pixel margin on the right, top, and 
			// bottom. Height is this.Height - 5 (4 pixels margin on top and bottom).
			// NOTE: In GDI+, all shapes are drawn up to and INCLUDING the last coordinate.
			// Thus, for drawing purposes, actual width is 14 pixels.
			return new Rectangle(this.Width - 17, 2, 14, this.Height - 5);
		}
	}

	#endregion Properties


	#region Methods
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 0x0201)  // WM_LBUTTONDOWN
		{
			// This must be done before the base class does anything to ensure that the 
			// pressed button is shown without any delay. If this were done after the base
			// class' implementation (or in OnMouseDown(...)), the pressed button is shown
			// only after the drop down list is completely visible.
			if ((this.DropDownStyle == ComboBoxStyle.DropDownList) ||
					(this.DropDownStyle == ComboBoxStyle.DropDown &&
					this.DropDownRectangle.Contains(this.PointToClient(Control.MousePosition)))) 
			{
				enmState = ControlState.Pressed;
				this.Invalidate(this.DropDownRectangle);
			}
		}

		base.WndProc(ref m);
		
		if (m.Msg == 0x000F)  // WM_PAINT
		{
			Graphics g = Graphics.FromHdc(GetWindowDC(this.Handle));
			ControlState cs;
			if (this.Enabled)
				cs = this.ControlState;
			else
				cs = ControlState.Disabled;

			ControlPaint.DrawBorder(g, 0, 0, this.Width - 1, this.Height - 1);
			this.DrawInnerBorder(g);
			ControlPaint.EraseExcessOldDropDown(g, DropDownRectangle);
			ControlPaint.DrawArrow(g, this.DropDownRectangle, 
				ArrowDirection.Down, cs);
			g.Dispose();
		}
	}

	protected override void OnMouseEnter(EventArgs ea)
	{
		base.OnMouseEnter(ea);

		if (this.DropDownStyle == ComboBoxStyle.DropDownList) 
		{
			enmState = ControlState.Hover;
			this.Invalidate(this.DropDownRectangle);
		}
	}

	protected override void OnMouseMove(MouseEventArgs ea)
	{
		base.OnMouseMove(ea);
		Rectangle rc = this.DropDownRectangle;

		if (this.DropDownStyle == ComboBoxStyle.DropDown) 
		{
			if (rc.Contains(ea.X, ea.Y))
			{
				if (this.ControlState == ControlState.Normal)
				{
					enmState = ControlState.Hover;
					this.Invalidate(rc);
				}
			}
			else if (this.ControlState == ControlState.Hover)
			{
				enmState = ControlState.Normal;
				this.Invalidate(rc);
			}
		}
	}

	protected override void OnMouseUp(MouseEventArgs mea)
	{
		base.OnMouseUp(mea);

		enmState = ControlState.Normal;
		this.Invalidate(this.DropDownRectangle);
	}

	protected override void OnMouseLeave(EventArgs ea)
	{
		base.OnMouseLeave(ea);

		if (this.ControlState != ControlState.Pressed)
		{
			enmState = ControlState.Normal;
			this.Invalidate(this.DropDownRectangle);
		}
	}

	
	/// <summary>
	/// Draws the inner border of the XpComboBox object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the inner border of the XpComboBox.</param>
	private void DrawInnerBorder(Graphics g)
	{
		g.DrawRectangle(new Pen(this.BackColor, 0), 1, 1,
			this.Width - 3, this.Height - 3);
	}

	#endregion Methods
}

}
