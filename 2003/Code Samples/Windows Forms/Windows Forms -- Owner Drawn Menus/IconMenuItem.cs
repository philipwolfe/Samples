using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

public class IconMenuItem : MenuItem
{
    private Icon m_Icon;
    private Font m_Font;

    // By default these are set to the SystemColors Highight and Control values.
    // This allows the appropriate color to be displayed if the user changes 
    // themes or display settings.
    // These can be overriden by calling the appropriate constructor for this 
    // class.

    private Color m_Gradient_Color1 = SystemColors.Highlight;
    private Color m_Gradient_Color2 = SystemColors.Control;

    public IconMenuItem():this("", null, null, System.Windows.Forms.Shortcut.None)
	{
    }

    public IconMenuItem(string text, Icon icon, EventHandler onClick, 
		Shortcut shortcut):base(text, onClick, shortcut)
	{
        // Owner Draw Property allows you to modify the menu item by handling
        // OnMeasureItem and OnDrawItem

        OwnerDraw = true;
        m_Font = new Font("Times new Roman", 8);
        m_Icon = icon;

    }

    // Additional constructor allows the setting of custom colors for each part of the menu
    // color gradient.

	public IconMenuItem(string text, System.Drawing.Color GradientColor1, 
		System.Drawing.Color GradientColor2, Icon icon, EventHandler onClick, 
		Shortcut shortcut):base(text, onClick, shortcut)
	{

		// Key Property
		OwnerDraw = true;

		m_Font = new Font("Times new Roman", 8);
		m_Gradient_Color1 = GradientColor1;
		m_Gradient_Color2 = GradientColor2;
		m_Icon = icon;

	}

    private string GetRealText()
	{

        string s = Text;

        // Append shortcut if one is set and it should be visible

		if (ShowShortcut && Shortcut != Shortcut.None) 
		{

			// To get a string representation of a Shortcut value, cast
			// it into a Keys value and use the KeysConverter class (via TypeDescriptor).

			Keys k = (Keys) Shortcut;
			s = s + Convert.ToChar(9) + TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString(k);

		}
        return s;

    }

    protected override void OnDrawItem(DrawItemEventArgs e)
	{

        // OnDrawItem perfoms the task of actually drawing the item after
        // measurement is complete

        base.OnDrawItem(e);

        Brush br;

        if (m_Icon != null) 
			{
            e.Graphics.DrawIcon(m_Icon, e.Bounds.Left + 2, e.Bounds.Top + 2);
        }

        Rectangle rcBk = e.Bounds;

        rcBk.X += 22;

        // Draw a background to the menu item with a linear gradient.
        // This will use system defaults unless colors and have been
        // passed on menu item instantiation

		if ((e.State & DrawItemState.Selected) != 0)
		{
			float f = 0;
			br = new LinearGradientBrush(rcBk, m_Gradient_Color1, m_Gradient_Color2, f);
		}
		else 
		{
			br = SystemBrushes.Control;
		}

        // Draw the main rectangle

        e.Graphics.FillRectangle(br, rcBk);

        // Leave room for accelerator key

        StringFormat sf = new StringFormat();
        sf.HotkeyPrefix = HotkeyPrefix.Show;

        // Draw the actual menu text

        br = new SolidBrush(e.ForeColor);

        e.Graphics.DrawString(GetRealText(), m_Font, br, e.Bounds.Left + 25, e.Bounds.Top + 2, sf);

    }

    protected override void OnMeasureItem(MeasureItemEventArgs e)
	{

        // The MeasureItem event along with the OnDrawItem event are the two key events
        // that need to be handled in order to create owner drawn menus.
        // Measure the string that makes up a given menu item and use it to set the 
        // size of the menu item being drawn.

        StringFormat sf = new StringFormat();
        sf.HotkeyPrefix = HotkeyPrefix.Show;
        base.OnMeasureItem(e);
        e.ItemHeight = 22;
        e.ItemWidth = Convert.ToInt32(e.Graphics.MeasureString(GetRealText(), m_Font, 10000, sf).Width) + 10;

    }

}

