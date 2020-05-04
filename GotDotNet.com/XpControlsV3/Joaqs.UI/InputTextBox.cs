using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace Joaqs.UI
{

/// <remarks>Represents a text box control that accepts only a specific set of characters.</remarks>
public class InputTextBox : Joaqs.UI.XpTextBox
{
	InputType _inputType = InputType.Normal;
	bool _allowPaste = false;
	string _allowKeys;

	public InputTextBox()
	{
		// 24 == ctrl+x (cut), 3 == ctrl+c (copy), 22 == ctrl+v (paste), 26 == ctrl+z (undo)
		_allowKeys = new String(new char[] { ((char)(int)Keys.Back), ((char)(int)Keys.Enter), 
			((char)(int)Keys.Escape), (char)24, (char)3, (char)22, (char)26 });
	}


	[DefaultValue(InputType.Normal), Description("Specifies the set of characters accepted by the InputTextBox.")]
	public InputType InputType
	{
		get { return _inputType; }
		set { _inputType = value; }
	}

	[DefaultValue(false), Description("Determines if the user can paste text into the InputTextBox.")]
	public bool AllowPaste
	{
		get { return _allowPaste; }
		set { _allowPaste = value; }
	}

	private string AcceptCharacters
	{
		get
		{
			switch (this.InputType)
			{
				case Joaqs.UI.InputType.Number:
					return "0123456789" + _allowKeys;

				case Joaqs.UI.InputType.Amount:
					return "0123456789.," + _allowKeys;

				case Joaqs.UI.InputType.PhoneNumber:
					return "0123456789()+-loc.;, " + _allowKeys;

				default:
					return String.Empty;
			}
		}
	}


	protected override void WndProc(ref Message m)
	{
		// 0x0302 == WM_PASTE
		if (m.Msg == 0x0302 && !this.AllowPaste)
			return;

		base.WndProc(ref m);
	}

	protected override void OnKeyPress(KeyPressEventArgs ea)
	{
		base.OnKeyPress(ea);

		if (this.InputType == Joaqs.UI.InputType.Normal) 
			return;
		if (this.AcceptCharacters.IndexOf(ea.KeyChar) == -1)
			ea.Handled = true;
	}
}

}
