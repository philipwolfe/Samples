using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Joaqs.UI
{


/// <remarks>
/// Represents a skinned Windows button control.
/// </remarks>
public class SkinnedButton : System.Windows.Forms.Button 
{
	#region Instance fields
	private Image imgNormal = null;
	private Image imgHover = null;
	private Image imgPressed = null;
	private Image imgDisabled = null;
	private Image imgDefault = null;
	private ControlState enmState = ControlState.Normal;
	private SkinSizeMode enmSizeMode = SkinSizeMode.Normal;
    private Rectangle textRectangle = Rectangle.Empty;
	private bool bDrawText = true;
	private Color clrDisabledText = Joaqs.UI.ControlPaint.DisabledForeColor;
	private bool bCanClick = false;
	#endregion

	#region Contructors
	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	/// <param name="normal">The image to be displayed when the SkinnedButton is in the normal state.</param>
	/// <param name="pressed">The image to be displayed when the SkinnedButton is in the pressed state.</param>
	/// <param name="Default">The image to be displayed when the SkinnedButton is in the default state.</param>
	/// <param name="disabled">The image to be displayed when the SkinnedButton is in the disabled state.</param>
	/// <param name="hover">The image to be displayed when the SkinnedButton is in the hover state.</param>
	public SkinnedButton(Image normal, Image pressed, Image Default, Image disabled, Image hover)
	{
		imgNormal = normal;
		imgPressed = pressed;
		imgDefault = Default;
		imgHover = hover;
		imgDisabled = disabled;
		
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	/// <param name="normal">The image to be displayed when the SkinnedButton is in the normal and hover states.</param>
	/// <param name="pressed">The image to be displayed when the SkinnedButton is in the pressed state.</param>
	/// <param name="Default">The image to be displayed when the SkinnedButton is in the default state.</param>
	/// <param name="disabled">The image to be displayed when the SkinnedButton is in the disabled state.</param>
	public SkinnedButton(Image normal, Image pressed, Image Default, Image disabled)
	{
		imgNormal = imgHover = normal;
		imgPressed = pressed;
		imgDefault = Default;
		imgDisabled = disabled;
		
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	/// <param name="normal">The image to be displayed when the SkinnedButton is in the normal and disabled states.</param>
	/// <param name="pressed">The image to be displayed when the SkinnedButton is in the pressed state.</param>
	/// <param name="Default">The image to be displayed when the SkinnedButton is in the default and hover states.</param>
	public SkinnedButton(Image normal, Image pressed, Image Default)
	{
		imgNormal = imgDisabled = normal;
		imgPressed = pressed;
		imgDefault = imgHover = Default;
		
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	/// <param name="normal">The image to be displayed when the SkinnedButton is in the normal, hover, default, and disabled states.</param>
	/// <param name="pressed">The image to be displayed when the SkinnedButton is in the pressed state.</param>
	public SkinnedButton(Image normal, Image pressed)
	{
		imgNormal = imgHover = imgDisabled = imgDefault = normal;
		imgPressed = pressed;

		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	/// <param name="normal">The image to be displayed for all states of the SkinnedButton.</param>
	public SkinnedButton(Image image)
	{
		imgNormal = imgPressed = imgHover = imgDisabled = imgDefault = image;
		
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}

	/// <summary>
	/// Initializes a new instance of the SkinnedButton class.
	/// </summary>
	public SkinnedButton()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer, true);
	}
	#endregion
	
	#region Properties
	[Description("Indicates the state of the SkinnedButton.")]
	protected ControlState ControlState
	{
		get { return enmState; }
	}


	[Description("Indicates the image to be displayed when the SkinnedButton is in the normal state.")]
	public Image NormalImage
	{
		get { return imgNormal; }
		set { imgNormal = value; }
	}

	[Description("Indicates the image to be displayed when the SkinnedButton is in the hover state.")]
	public Image HoverImage
	{
		get { return imgHover; }
		set { imgHover = value; }
	}

	[Description("Indicates the image to be displayed when the SkinnedButton is in the pressed state.")]
	public Image PressedImage
	{
		get { return imgPressed; }
		set { imgPressed = value; }
	}

	[Description("Indicates the image to be displayed when the SkinnedButton is in the default state.")]
	public Image DefaultImage
	{
		get { return imgDefault; }
		set { imgDefault = value; }
	}

	[Description("Indicates the image to be displayed when the SkinnedButton is in the disabled state.")]
	public Image DisabledImage
	{
		get { return imgDisabled; }
		set { imgDisabled = value; }
	}

	
	[DefaultValue(SkinSizeMode.Normal), Description("Gets or sets a value indicating how skins will be displayed.")]
	public SkinSizeMode SizeMode 
	{
		get { return enmSizeMode; }
		set 
		{ 
			if (Enum.IsDefined(typeof(SkinSizeMode), value))
				enmSizeMode = value; 
			else
				throw new System.ComponentModel.InvalidEnumArgumentException
					("value", (int) value, typeof(SkinSizeMode));
		}
	}

	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Gets or sets the clipping rectangle of the SkinnedButton's text.")]
	public Rectangle TextRectangle
	{
		get { return textRectangle; }
		set { textRectangle = value; }
	}

	[DefaultValue(true), Description("Gets or sets a value indicating whether the SkinnedButton object is to draw its text.")]
	public bool DrawText
	{
		get { return bDrawText; }
		set { bDrawText = value; }
	}

	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Gets or sets the color of the text when the SkinnedButton is in the disabled state.")]
	public Color DisabledTextColor
	{
		get { return clrDisabledText; }
		set { clrDisabledText = value; }
	}

	#endregion

	#region Methods
	/// <summary>
	/// Draws a skin.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to draw the skin.</param>
	/// <param name="img">The System.Drawing.Image to display.</param>
	private void DrawSkin(Graphics g, Image img)
	{
		if (img == null) return;

		switch (enmSizeMode)
		{
			case SkinSizeMode.Normal:
				g.DrawImage(img, 0, 0, img.Width, img.Height);
				break;

			case SkinSizeMode.StretchImage:
				g.DrawImage(img, this.ClientRectangle);
				break;
		}
	}


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

		if (this.DesignMode && this.NormalImage == null)
		{
            System.Windows.Forms.ControlPaint.DrawFocusRectangle(pea.Graphics,
				this.ClientRectangle, Color.Black, Color.Transparent);

			return;
		}
		
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

		OnDrawText(pea.Graphics);
	}

	protected override void OnEnabledChanged(EventArgs ea)
	{
		base.OnEnabledChanged(ea);
		enmState = ControlState.Normal;
		this.Invalidate();
	}
	

	// New Event Handlers

	/// <summary>
	/// Draws the normal state of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawNormal(Graphics g)
	{
		DrawSkin(g, imgNormal);
	}

	/// <summary>
	/// Draws the hover state of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawHover(Graphics g)
	{
		DrawSkin(g, imgHover);
	}

	/// <summary>
	/// Draws the pressed state of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawPressed(Graphics g)
	{
		DrawSkin(g, imgPressed);
	}

	/// <summary>
	/// Draws the default state of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawDefault(Graphics g)
	{
		DrawSkin(g, imgDefault);
	}

	/// <summary>
	/// Draws the disabled state of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawDisabled(Graphics g)
	{
		DrawSkin(g, imgDisabled);
	}

	/// <summary>
	/// Draws the text of the SkinnedButton.
	/// </summary>
	/// <param name="g">The System.Drawing.Graphics object to be used to paint the SkinnedButton.</param>
	protected virtual void OnDrawText(Graphics g)
	{
		if (this.DrawText) 
		{
			Rectangle rc = TextRectangle;
			if (rc.IsEmpty)
				rc = ClientRectangle;

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
		}  // AllowDrawText == true
	}

	#endregion
}


}  // Namespace
