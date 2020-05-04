using System;
using System.Drawing;

namespace Joaqs.UI
{
	
internal struct DropDownColors
{
	readonly Color _topLeft1;
	readonly Color _topLeft2;
	readonly Color _bottomRight;
	readonly Color _corner;
	readonly Color _body1;
	readonly Color _body2;

	public DropDownColors(ControlState cs)
	{
		switch (cs)
		{
			case ControlState.Normal:
				_topLeft1 = Color.FromArgb(209, 224, 253);
				_topLeft2 = Color.FromArgb(175, 197, 244);
				_bottomRight = Color.FromArgb(178, 200, 244);
				_corner = Color.FromArgb(220, 230, 249);
				_body1 = Color.FromArgb(225, 234, 254);
				_body2 = Color.FromArgb(174, 200, 247);
				break;

			case ControlState.Hover:
				_topLeft1 = Color.FromArgb(180, 199, 235);
				_topLeft2 = Color.FromArgb(135, 160, 222);
				_bottomRight = Color.FromArgb(141, 169, 225);
				_corner = Color.FromArgb(194, 207, 234);
				_body1 = Color.FromArgb(253, 255, 255);
				_body2 = Color.FromArgb(179, 216, 251);
				break;

			case ControlState.Pressed:
				_topLeft1 = Color.FromArgb(165, 175, 220);
				_topLeft2 = Color.FromArgb(112, 126, 217);
				_bottomRight = Color.FromArgb(178, 200, 244);
				_corner = Color.FromArgb(187, 194, 220);
				_body1 = Color.FromArgb(110, 142, 241);
				_body2 = Color.FromArgb(218, 228, 235);
				break;

			case ControlState.Disabled:
				_topLeft1 = Color.FromArgb(242, 242, 236);
				_topLeft2 = Color.FromArgb(226, 226, 215);
				_bottomRight = Color.FromArgb(229, 229, 219);
				_corner = Color.FromArgb(243, 243, 238);
				_body1 = Color.FromArgb(247, 247, 247);
				_body2 = Color.FromArgb(229, 229, 219);
				break;

			default:
				// default returns colors for the normal state
				_topLeft1 = Color.FromArgb(209, 224, 253);
				_topLeft2 = Color.FromArgb(175, 197, 244);
				_bottomRight = Color.FromArgb(178, 200, 244);
				_corner = Color.FromArgb(220, 230, 249);
				_body1 = Color.FromArgb(225, 234, 254);
				_body2 = Color.FromArgb(174, 200, 247);
				break;
		}
	}

	public Color TopLeft1
	{
		get { return _topLeft1; }
	}

	public Color TopLeft2
	{
		get { return _topLeft2; }
	}

	public Color BottomRight
	{
		get { return _bottomRight; }
	}

	public Color Corner
	{
		get { return _corner; }
	}

	public Color Body1
	{
		get { return _body1; }
	}

	public Color Body2
	{
		get { return _body2; }
	}

}

}
