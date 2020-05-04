using System;
using System.Drawing;
using System.Windows.Forms;


namespace Joaqs.UI
{

/// <summary>Represents a Windows XP group box control.</summary>
public class XpGroupBox : System.Windows.Forms.GroupBox
{
	private static Color clrBorder = Color.FromArgb(208, 208, 191);
	private Size szIndent;

	public XpGroupBox()
	{
		this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
		szIndent = new Size(8, 8);
	}


	public new FlatStyle FlatStyle
	{
		get { return base.FlatStyle;}
		set { base.FlatStyle = FlatStyle.Standard; }
	}


	protected override void OnPaint(PaintEventArgs ea)
	{
		Graphics g = ea.Graphics;
		Size szText = g.MeasureString(this.Text, this.Font).ToSize();
		int cyAdjust = szText.Height / 2;
		Rectangle rc = new Rectangle(0, cyAdjust, this.Width - 1, this.Height - cyAdjust - 1);

		ControlPaint.DrawRoundedRectangle(g, new Pen(clrBorder, 0),	rc, szIndent);
		g.FillRectangle(new SolidBrush(this.BackColor), 7, 0, szText.Width - 1, szText.Height);

		Color clrText = this.ForeColor;
		if (this.Enabled)
		{
			if (clrText == SystemColors.ControlText)
				clrText = Color.FromArgb(0, 70, 213);
		}
		else
		{
			clrText = ControlPaint.DisabledForeColor;
		}

		g.DrawString(this.Text, this.Font, new SolidBrush(clrText), 7, 0);
	}
}

}
