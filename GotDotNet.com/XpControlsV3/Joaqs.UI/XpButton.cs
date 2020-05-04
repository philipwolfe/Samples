using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Joaqs.UI
{

/// <remarks>Represents a Windows XP button control.</remarks>
public class XpButton : System.Windows.Forms.Button
{
	#region Instance fields
	private ControlState enmState = ControlState.Normal;
	private bool bCanClick = false;
	#endregion

	#region Static members
	// Fields
	private static readonly Size sizeBorderPixelIndent;
	private static readonly Color clrOuterShadow1;
	private static readonly Color clrOuterShadow2;
	private static readonly Color clrBackground1;
	private static readonly Color clrBackground2;
	private static readonly Color clrBorder;
	private static readonly Color clrInnerShadowBottom1;
	private static readonly Color clrInnerShadowBottom2;
	private static readonly Color clrInnerShadowBottom3;
	private static readonly Color clrInnerShadowRight1a;
	private static readonly Color clrInnerShadowRight1b;
	private static readonly Color clrInnerShadowRight2a;
	private static readonly Color clrInnerShadowRight2b;
	private static readonly Color clrInnerShadowBottomPressed1;
	private static readonly Color clrInnerShadowBottomPressed2;
	private static readonly Color clrInnerShadowTopPressed1;
	private static readonly Color clrInnerShadowTopPressed2;
	private static readonly Color clrInnerShadowLeftPressed1;
	private static readonly Color clrInnerShadowLeftPressed2;
	#endregion
	
	#region Constructors
	/// <summary>
	/// Initializes all static fields of the XpButton class.
	/// </summary>
	static XpButton()
	{
		// 1 pixel indent in the roundness of the border (from XP Visual Design Guidelines)
		// To make pixel indentation larger, change by a factor of 4,
		// i. e., 2 pixels indent = Size(8, 8);
		sizeBorderPixelIndent = new Size(4, 4);

		// Normal colors
		clrOuterShadow1 = Color.FromArgb(64, 164, 164, 164);
		clrOuterShadow2 = Color.FromArgb(64, Color.White);
		clrBackground1 = Color.FromArgb(250, 250, 248);
		clrBackground2 = Color.FromArgb(240, 240, 234);
		clrBorder = Color.FromArgb(0, 60, 116);
		clrInnerShadowBottom1 = Color.FromArgb(236, 235, 230);
		clrInnerShadowBottom2 = Color.FromArgb(226, 223, 214);
		clrInnerShadowBottom3 = Color.FromArgb(214, 208, 197);
		clrInnerShadowRight1a = Color.FromArgb(128, 236, 234, 230);
		clrInnerShadowRight1b = Color.FromArgb(128, 224, 220, 212);
		clrInnerShadowRight2a = Color.FromArgb(128, 234, 228, 218);
		clrInnerShadowRight2b = Color.FromArgb(128, 212, 208, 196);

		// Pressed colors
		clrInnerShadowBottomPressed1 = Color.FromArgb(234, 233, 227);
		clrInnerShadowBottomPressed2 = Color.FromArgb(242, 241, 238);
		clrInnerShadowTopPressed1 = Color.FromArgb(209, 204, 193);
		clrInnerShadowTopPressed2 = Color.FromArgb(220, 216, 207);
		clrInnerShadowLeftPressed1 = Color.FromArgb(216, 213, 203);
		clrInnerShadowLeftPressed2 = Color.FromArgb(222, 220, 211);
	}

	/// <summary>
	/// Initializes a new instance of the XpButton class.
	/// </summary>
	public XpButton()
	{
		this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	#endregion

	#region Properties
	public new FlatStyle FlatStyle
	{
		get { return base.FlatStyle;}
		set { base.FlatStyle = FlatStyle.Standard; }
	}

	/// <value>Gets the clipping rectangle of the XpButton object's border.</value>
	private Rectangle BorderRectangle
	{
		get
		{ 
			Rectangle rc = this.ClientRectangle;
			return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
		}
	}
	
	#endregion

	#region Methods
	// Overridden Event Handlers
	protected override void OnClick(EventArgs ea)
	{
		this.Capture = false;
		bCanClick = false;

		if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
			enmState = ControlState.Hover;
		else
			enmState = ControlState.Normal;

		this.Invalidate();

		base.OnClick(ea);
	}

	protected override void OnMouseEnter(EventArgs ea)
	{
		base.OnMouseEnter(ea);

		enmState = ControlState.Hover;
		this.Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs mea)
	{
		base.OnMouseDown(mea);

		if (mea.Button == MouseButtons.Left)
		{
			bCanClick = true;
			enmState = ControlState.Pressed;
			this.Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		base.OnMouseMove(mea);

		if (ClientRectangle.Contains(mea.X, mea.Y)) 
		{
			if (enmState == ControlState.Hover && this.Capture && !bCanClick)
			{
				bCanClick = true;
				enmState = ControlState.Pressed;
				this.Invalidate();
			}
		}
		else
		{
			if (enmState == ControlState.Pressed)
			{
				bCanClick = false;
				enmState = ControlState.Hover;
				this.Invalidate();
			}
		}
	}

	protected override void OnMouseLeave(EventArgs ea)
	{
		base.OnMouseLeave(ea);

		enmState = ControlState.Normal;
		this.Invalidate();
	}

	protected override void OnPaint(PaintEventArgs pea)
	{
		this.OnPaintBackground(pea);
        		
		switch (enmState)
		{
			case ControlState.Normal:
				if (this.Enabled) 
				{
					if (this.Focused || this.IsDefault)
					{
						OnDrawDefault(pea.Graphics);
					}
					else
					{
						OnDrawNormal(pea.Graphics);
					}
				}
				else
				{
					OnDrawDisabled(pea.Graphics);
				}

				break;

			case ControlState.Hover:
				OnDrawHover(pea.Graphics);
				break;

			case ControlState.Pressed:
				OnDrawPressed(pea.Graphics);
				break;
		}

		// enmState will never be == ControlState.Default
		// When (IsDefault == true), enmState will be == ControlState.Normal
		// So when (IsDefault == true), pass ControlState.Default instead of enmState
		OnDrawText(pea.Graphics);

		// Not really needed!
		/*if (this.Focused)
		{
			Rectangle rcFocus = this.ClientRectangle;
			rcFocus.Inflate(-3, -3);
			System.Windows.Forms.ControlPaint.DrawFocusRectangle(pea.Graphics, rcFocus,
				this.ForeColor, Color.Transparent);
		}*/
	}

	protected override void OnEnabledChanged(EventArgs ea)
	{
		base.OnEnabledChanged(ea);
		enmState = ControlState.Normal;
		this.Invalidate();
	}


	/// <summary>
	/// Draws the normal state of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawNormal(Graphics g)
	{
		DrawNormalButton(g);
		// no need to call base class implementation
	}

	/// <summary>
	/// Draws the hover state of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawHover(Graphics g)
	{
		DrawNormalButton(g);

		//
		// Need to draw only the "thick border" for hover buttons
		//
		
		Rectangle rcBorder = this.BorderRectangle;

		// Top
		Pen penTop1 = new Pen(Color.FromArgb(255, 240, 207));
		Pen penTop2 = new Pen(Color.FromArgb(253, 216, 137));

		g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1,
			rcBorder.Right - 2, rcBorder.Top + 1);
		g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2,
			rcBorder.Right - 1, rcBorder.Top + 2);

		penTop1.Dispose();
		penTop2.Dispose();

		// Bottom
		Pen penBottom1 = new Pen(Color.FromArgb(248, 178, 48));
		Pen penBottom2 = new Pen(Color.FromArgb(229, 151, 0));

		g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2,
			rcBorder.Right - 1, rcBorder.Bottom - 2);
		g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1,
			rcBorder.Right - 2, rcBorder.Bottom - 1);

		penBottom1.Dispose();
		penBottom2.Dispose();

		// Left and Right
		Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3,
			2, rcBorder.Height - 5); 
		Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3,
			2, rcBorder.Height - 5); 
		
		LinearGradientBrush brushSide = new LinearGradientBrush(
			rcLeft, Color.FromArgb(254, 221, 149), Color.FromArgb(249, 180, 53),
			LinearGradientMode.Vertical);
		
		g.FillRectangle(brushSide, rcLeft);
		g.FillRectangle(brushSide, rcRight);

		brushSide.Dispose();
	}

	/// <summary>
	/// Draws the pressed state of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawPressed(Graphics g)
	{
		Rectangle rcBorder = this.BorderRectangle;
		
		//			
		// Outer shadow
		//
		DrawOuterShadow(g);
		
		//
		// Background
		//
		Rectangle rcBackground = new Rectangle(
			rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
		SolidBrush brushBackground = new SolidBrush(Color.FromArgb(226, 225, 218));
		g.FillRectangle(brushBackground, rcBackground);
		brushBackground.Dispose();
		
		//
		// Border
		//
		DrawBorder(g);

		//
		// Inner shadow above the bottom border (2 solid lines)
		//
		Pen penInnerShadowBottomPressed1 = new Pen(clrInnerShadowBottomPressed1);
		Pen penInnerShadowBottomPressed2 = new Pen(clrInnerShadowBottomPressed2);

		g.DrawLine(penInnerShadowBottomPressed1, rcBorder.Left + 1, rcBorder.Bottom - 2, 
			rcBorder.Right - 1, rcBorder.Bottom - 2);
		g.DrawLine(penInnerShadowBottomPressed2, rcBorder.Left + 2, rcBorder.Bottom - 1, 
			rcBorder.Right - 2, rcBorder.Bottom - 1);
		
		penInnerShadowBottomPressed1.Dispose();
		penInnerShadowBottomPressed2.Dispose();

		//
		// Inner shadow below the top border (2 solid lines)
		//
		Pen penInnerShadowTopPressed1 = new Pen(clrInnerShadowTopPressed1);
		Pen penInnerShadowTopPressed2 = new Pen(clrInnerShadowTopPressed2);

		g.DrawLine(penInnerShadowTopPressed1, rcBorder.Left + 2, rcBorder.Top + 1,
			rcBorder.Right - 2, rcBorder.Top + 1);
		g.DrawLine(penInnerShadowTopPressed2, rcBorder.Left + 1, rcBorder.Top + 2,
			rcBorder.Right - 1, rcBorder.Top + 2);
		
		penInnerShadowTopPressed1.Dispose();
		penInnerShadowTopPressed2.Dispose();
	
		//
		// Inner shadow right the left border (2 solid lines)
		//
		Pen penInnerShadowLeftPressed1 = new Pen(clrInnerShadowLeftPressed1);
		Pen penInnerShadowLeftPressed2 = new Pen(clrInnerShadowLeftPressed2);

		g.DrawLine(penInnerShadowLeftPressed1, rcBorder.Left + 1, rcBorder.Top + 3,
			rcBorder.Left + 1, rcBorder.Bottom - 3);
		g.DrawLine(penInnerShadowLeftPressed2, rcBorder.Left + 2, rcBorder.Top + 3,
			rcBorder.Left + 2, rcBorder.Bottom - 3);
		
		penInnerShadowLeftPressed1.Dispose();
		penInnerShadowLeftPressed2.Dispose();
	}

	/// <summary>
	/// Draws the default state of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawDefault(Graphics g)
	{
		DrawNormalButton(g);

		//
		// Need to draw only the "thick border" for default buttons
		//
		
		Rectangle rcBorder = this.BorderRectangle;

		// Top
		Pen penTop1 = new Pen(Color.FromArgb(206, 231, 255));
		Pen penTop2 = new Pen(Color.FromArgb(188, 212, 246));

		g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1,
			rcBorder.Right - 2, rcBorder.Top + 1);
		g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2,
			rcBorder.Right - 1, rcBorder.Top + 2);

		penTop1.Dispose();
		penTop2.Dispose();

		// Bottom
		Pen penBottom1 = new Pen(Color.FromArgb(137, 173, 228));
		Pen penBottom2 = new Pen(Color.FromArgb(105, 130, 238));

		g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2,
			rcBorder.Right - 1, rcBorder.Bottom - 2);
		g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1,
			rcBorder.Right - 2, rcBorder.Bottom - 1);

		penBottom1.Dispose();
		penBottom2.Dispose();

		// Left and Right
		Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3,
			2, rcBorder.Height - 5); 
		Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3,
			2, rcBorder.Height - 5); 
		
		LinearGradientBrush brushSide = new LinearGradientBrush(
			rcLeft, Color.FromArgb(186, 211, 245), Color.FromArgb(137, 173, 228),
			LinearGradientMode.Vertical);
		
		g.FillRectangle(brushSide, rcLeft);
		g.FillRectangle(brushSide, rcRight);

		brushSide.Dispose();
	}

	/// <summary>
	/// Draws the disabled state of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawDisabled(Graphics g)
	{
		Rectangle rcBorder = this.BorderRectangle;

		//
		// Background
		//
		Rectangle rcBackground = new Rectangle(
			rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
		SolidBrush brushBackground = new SolidBrush(Color.FromArgb(245, 244, 234));

		g.FillRectangle(brushBackground, rcBackground);
		brushBackground.Dispose();
		
		//
		// Border
		//
		Pen penBorder = new Pen(Color.FromArgb(201, 199, 186));
		ControlPaint.DrawRoundedRectangle(g, penBorder, rcBorder, 
			sizeBorderPixelIndent);
		penBorder.Dispose();
	}

	/// <summary>
	/// Draws the text of the XpButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void OnDrawText(Graphics g)
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
			this.ClientRectangle, 
			sf);
		
		brushText.Dispose();
		sf.Dispose();
	}


	/// <summary>
	/// Draws the ordinary look of the XpButton object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
	private void DrawNormalButton(Graphics g)
	{
		Rectangle rcBorder = this.BorderRectangle;
		
		//			
		// Outer shadow
		//
		DrawOuterShadow(g);
		
		//
		// Background
		//
		Rectangle rcBackground = new Rectangle(
			rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 4);
		LinearGradientBrush brushBackground = new LinearGradientBrush(rcBackground, clrBackground1, clrBackground2,
			LinearGradientMode.Vertical);

		g.FillRectangle(brushBackground, rcBackground);
		brushBackground.Dispose();
		
		//
		// Border
		//
		DrawBorder(g);

		//
		// Inner shadow above the bottom border (3 solid lines)
		//
		Pen penInnerShadowBottom1 = new Pen(clrInnerShadowBottom1);
		Pen penInnerShadowBottom2 = new Pen(clrInnerShadowBottom2);
		Pen penInnerShadowBottom3 = new Pen(clrInnerShadowBottom3);

		g.DrawLine(penInnerShadowBottom1, rcBorder.Left + 1, rcBorder.Bottom - 3, 
			rcBorder.Right - 1, rcBorder.Bottom - 3);
		g.DrawLine(penInnerShadowBottom2, rcBorder.Left + 1, rcBorder.Bottom - 2, 
			rcBorder.Right - 1, rcBorder.Bottom - 2);
		g.DrawLine(penInnerShadowBottom3, rcBorder.Left + 2, rcBorder.Bottom - 1, 
			rcBorder.Right - 2, rcBorder.Bottom - 1);
		
		penInnerShadowBottom1.Dispose();
		penInnerShadowBottom2.Dispose();
		penInnerShadowBottom3.Dispose();

		//
		// Inner shadow to the left of the right border (2 gradient lines)
		//
		Point ptInnerShadowRight1a = new Point(rcBorder.Right - 2, rcBorder.Top + 1);
		Point ptInnerShadowRight1b = new Point(rcBorder.Right - 2, rcBorder.Bottom - 1);
		Point ptInnerShadowRight2a = new Point(rcBorder.Right - 1, rcBorder.Top + 2);
		Point ptInnerShadowRight2b = new Point(rcBorder.Right - 1, rcBorder.Bottom - 2);

		LinearGradientBrush brushInnerShadowRight1 = new LinearGradientBrush(
			ptInnerShadowRight1a , ptInnerShadowRight1b ,
			clrInnerShadowRight1a, clrInnerShadowRight1b);
		Pen penInnerShadowRight1 = new Pen(brushInnerShadowRight1);
		
		LinearGradientBrush brushInnerShadowRight2 = new LinearGradientBrush(
			ptInnerShadowRight2a , ptInnerShadowRight2b ,
			clrInnerShadowRight2a, clrInnerShadowRight2b);
		Pen penInnerShadowRight2 = new Pen(brushInnerShadowRight2);

		g.DrawLine(penInnerShadowRight1, ptInnerShadowRight1a, ptInnerShadowRight1b);
		g.DrawLine(penInnerShadowRight2, ptInnerShadowRight2a, ptInnerShadowRight2b);
			
		penInnerShadowRight1.Dispose();
		penInnerShadowRight2.Dispose();
		brushInnerShadowRight1.Dispose();
		brushInnerShadowRight2.Dispose();

		// Top showing light source
		Pen penTop = new Pen(Color.White);
		
		g.DrawLine(penTop, rcBorder.Left + 2, rcBorder.Top + 1,
			rcBorder.Right - 2, rcBorder.Top + 1);
		g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 2,
			rcBorder.Right - 1, rcBorder.Top + 2);
		g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 3,
			rcBorder.Right - 1, rcBorder.Top + 3);

		penTop.Dispose();
	}
	
	/// <summary>
	/// Draws the outer shadow of the XpButton object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the outer shadow.</param>
	private void DrawOuterShadow(Graphics g)
	{
		LinearGradientBrush brushOuterShadow = new LinearGradientBrush(
			ClientRectangle, clrOuterShadow1, clrOuterShadow2, LinearGradientMode.Vertical);
		g.FillRectangle(brushOuterShadow, ClientRectangle);
		brushOuterShadow.Dispose();
	}

	/// <summary>
	/// Draws the dark blue border of the XpButton object.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the border.</param>
	private void DrawBorder(Graphics g)
	{
		Pen penBorder = new Pen(clrBorder);
		ControlPaint.DrawRoundedRectangle(g, penBorder, this.BorderRectangle, 
			sizeBorderPixelIndent);
		penBorder.Dispose();
	}

	#endregion
}


}  // Namespace
