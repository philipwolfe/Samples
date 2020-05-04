using System;
using System.Drawing;


namespace Joaqs.UI
{

/// <summary>
/// Specifies how skins will be displayed relative to the size of the SkinnedButton.
/// </summary>
public enum SkinSizeMode 
{
	/// <summary>
	/// The images will be placed in the upper-left corner of the SkinnedButton.
	/// Images are clipped if they are larger than the SkinnedButton they are contained in.
	/// </summary>
	Normal,
	/// <summary>
	/// The images within the SkinnedButton are stretched or shrunk to fit the size of the SkinnedButton.
	/// </summary>
	StretchImage
}


/// <remarks>
/// Specifies the state of the SkinnedButton object.
/// </remarks>
public enum ControlState
{
	/// <summary>The XP control is in the normal state.</summary>
	Normal,
	/// <summary>The XP control is in the hover state.</summary>
	Hover,
	/// <summary>The XP control is in the pressed state.</summary>
	Pressed,
	/// <summary>The XP control object is in the default state.</summary>
	Default,
	/// <summary>The XP control object is in the disabled state.</summary>
	Disabled		
}


/// <remarks>
/// Specifies the direction the arrow points to.
/// </remarks>
internal enum ArrowDirection
{
	/// <summary>Arrow points to the left.</summary>
	Left,
	/// <summary>Arrow points upward.</summary>
	Up,
	/// <summary>Arrow points to the right.</summary>
	Right,
	/// <summary>Arrow points downward.</summary>
	Down
}


/// <remarks>
/// Specifies the set of characters accepted by the InputTextBox
/// </remarks>
public enum InputType
{
	/// <summary>The InputTextBox accepts all characters entered.</summary>
	Normal,
	/// <summary>The InputTextBox accepts only numbers.</summary>
	Number,
	/// <summary>The InputTextBox accepts numbers, '-', and '.' characters.</summary>
	Amount,
	/// <summary>The InputTextBox accepts numbers, parentheses, spaces, and '+' characters.</summary>
	PhoneNumber
}

}