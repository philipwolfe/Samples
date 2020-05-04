using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP check box control.</remarks>
public class XpCheckBox : System.Windows.Forms.CheckBox
{
	#region Instance members
	private readonly Size sizeBox;
	private bool bCanClick = false;
	private ControlState enmState = ControlState.Normal;
	#endregion

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the XpCheckBox class.
	/// </summary>
	public XpCheckBox()
	{
		sizeBox = new Size(12, 12);  // Up to and including the last coordinate
	}

	#endregion

	#region Properties
	public new FlatStyle FlatStyle
	{
		get { return base.FlatStyle;}
		set { base.FlatStyle = FlatStyle.Standard; }
	}

	/// <value>Indicates the state of the XpCheckBox.</value>
	protected ControlState ControlState
	{
		get { return enmState; }
	}
	
	/// <value>Gets the clipping rectangle for the box of the XpCheckBox.</value>
	protected Rectangle BoxRectangle
	{
		get
		{
			StringFormat sfBox = ControlPaint.GetStringFormat(this.CheckAlign);
			int x = 0;
			int y = 0;

			if (sfBox.Alignment == StringAlignment.Near)
				x = 0;
			else if (sfBox.Alignment == StringAlignment.Center)
                x = ((ClientRectangle.Width - sizeBox.Width) / 2);
			else
				// sfBox.Alignment == StringAlignment.Far
				x = ClientRectangle.Width - sizeBox.Width - 1;

			switch (sfBox.LineAlignment)
			{
				case StringAlignment.Center:
					y = ((ClientRectangle.Height - sizeBox.Height) / 2) - 1;
					break;

				case StringAlignment.Near:
					y = 0;
					break;

				case StringAlignment.Far:
					y = ClientRectangle.Height - sizeBox.Height - 2;
					break;
			}

			return new Rectangle(x, y, sizeBox.Width, sizeBox.Height);
		}
	}

	/// <value>Gets the clipping rectangle for the text of the XpCheckBox.</value>
	protected Rectangle TextRectangle
	{
		get
		{
			Rectangle rcBox = BoxRectangle;
			Rectangle rcClient = ClientRectangle;
			StringFormat sf = ControlPaint.GetStringFormat(this.CheckAlign);

			if (sf.Alignment == StringAlignment.Near)
				return new Rectangle(rcBox.Width + 3, 0, rcClient.Width - rcBox.Width - 4, rcClient.Height - 1);
			else if (sf.Alignment == StringAlignment.Center)
			{
				if (sf.LineAlignment == StringAlignment.Near)
					return new Rectangle(0, rcBox.Height + 1, rcClient.Width - 1, rcClient.Height - rcBox.Height - 2);
				else if (sf.LineAlignment == StringAlignment.Center)
					return new Rectangle(0, 0, this.Width - 1, this.Height - 1);
				else
					// sf.LineAlignment == StringAlignment.Far
					return new Rectangle(0, 0, this.Width - 1, this.Height - rcBox.Height - 1);
			}
			else
				// sf.Alignment == StringAlignment.Far
				return new Rectangle(0, 0, rcClient.Width - rcBox.Width, rcClient.Height - 1);
		}
	}

	/// <value>Gets the image that reflects the control state of the XpCheckBox.</value>
	protected Image BoxImage
	{
		get
		{
			// The longest file is 53 characters:
			// "Joaqs.UI.CheckBoxImages.CheckBox - Unchecked Disabled.bmp"
			System.Text.StringBuilder sb = new System.Text.StringBuilder(
				"Joaqs.UI.CheckBoxes.CheckBox - ", 64);

			// Determine the check state of the object
			switch (this.CheckState)
			{
				case CheckState.Unchecked:
					sb.Append("Unchecked ");
					break;

				case CheckState.Checked:
					sb.Append("Checked ");
					break;

				case CheckState.Indeterminate:
					sb.Append("Mixed ");
					break;
			}

			// Determine the control state of the object
			switch (this.ControlState)
			{
				case ControlState.Normal:
					if (this.Enabled)
					{
						if (this.Focused)
							sb.Append("Hover");
						else
							sb.Append("Normal");
					}
					else
					{
						sb.Append("Disabled");
					}
					break;

				case ControlState.Hover:
					sb.Append("Hover");
					break;

				case ControlState.Pressed:
					sb.Append("Pressed");
					break;
			}

			sb.Append(".bmp");
			return new Bitmap(GetType().Assembly.GetManifestResourceStream(sb.ToString()));
		}
	}

	
	#endregion

	#region Methods
	// Overridden event handlers
	protected override void OnMouseEnter(EventArgs ea)
	{
		base.OnMouseEnter(ea);

		enmState = ControlState.Hover;
		this.Invalidate(this.BoxRectangle);
	}

	protected override void OnMouseDown(MouseEventArgs ea)
	{
		base.OnMouseDown(ea);

		if (ea.Button == MouseButtons.Left)
		{
			bCanClick = true;
			enmState = ControlState.Pressed;
		}
	
		this.Invalidate(this.BoxRectangle);
	}

	protected override void OnMouseMove(MouseEventArgs ea)
	{
		base.OnMouseMove(ea);

		if (ClientRectangle.Contains(ea.X, ea.Y)) 
		{
			if (enmState == ControlState.Hover && this.Capture && !bCanClick)
			{
				bCanClick = true;
				enmState = ControlState.Pressed;
			}
		}
		else
		{
			bCanClick = false;
			enmState = ControlState.Hover;
		}

		this.Invalidate(this.BoxRectangle);
	}

	protected override void OnMouseUp(MouseEventArgs mea)
	{
		if (bCanClick && mea.Button == MouseButtons.Left) 
		{
			bCanClick = false;
			enmState = ControlState.Hover;
		}

		this.Invalidate(this.BoxRectangle);
		base.OnMouseUp(mea);
	}

	protected override void OnMouseLeave(EventArgs ea)
	{
		base.OnMouseLeave(ea);

		enmState = ControlState.Normal;
		this.Invalidate(this.BoxRectangle);
	}

	protected override void OnPaint(PaintEventArgs ea)
	{
		base.OnPaintBackground(ea);

		DrawBox(ea.Graphics);
		DrawText(ea.Graphics);
	}


	// Helpers
	/// <summary>
	/// Draws the box part of the XpCheckBox.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpCheckBox.</param>
	private void DrawBox(Graphics g)
	{
		Rectangle rcBox = this.BoxRectangle;

		//
		// Box's border
		//
		Pen pen;
		if (this.Enabled)
			pen = new Pen(ControlPaint.ButtonBorderColor, 0);
		else
			pen = new Pen(ControlPaint.DisabledButtonBorderColor, 0);

		g.DrawRectangle(pen, rcBox);
		pen.Dispose();
		
		//
		// The box itself
		//
		Image image = this.BoxImage;
		g.DrawImage(image, rcBox.X + 1, rcBox.Y + 1, rcBox.Width - 1, rcBox.Height - 1);
		image.Dispose();
	}

	/// <summary>
	/// Draws the text part of the XpCheckBox.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpCheckBox.</param>
	private void DrawText(Graphics g)
	{
		SolidBrush brushText;
		
		if (Enabled)
			brushText = new SolidBrush(ForeColor);
		else
			brushText = new SolidBrush(ControlPaint.DisabledForeColor);

		StringFormat sf = ControlPaint.GetStringFormat(this.TextAlign);
		sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

		g.DrawString(
			this.Text, 
			this.Font, 
			brushText, 
			TextRectangle, 
			sf);

		brushText.Dispose();
		sf.Dispose();
	}

	#endregion
}


}
