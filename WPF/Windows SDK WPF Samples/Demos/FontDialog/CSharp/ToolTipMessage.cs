#region Using directives

using System;
using System.Collections;
using System.Text;

#endregion

namespace FontDialog
{
    /// <summary>
    /// define tool tip message for font dialog
    /// </summary>
    class ToolTipMessage
    {
        /// <summary>
        /// hashtable to hold all the message.
        /// </summary>
        static Hashtable table = new Hashtable();
        /// <summary>
        /// method to fill up the hastable.
        /// </summary>
        static ToolTipMessage()
        {
            table.Add("OKButton", "Close the dialg and save any change you have made");
            table.Add("CancelButton", "Close the dialg without saving any change you have made");
            
            table.Add("StrikeCheckBox", "Check/uncheck to draw/undraw StrikeLine");
            table.Add("UnderLineCheckBox", "Check/uncheck to draw/undraw UnderLine");
            table.Add("BaseLineCheckBox", "Check/uncheck to draw/undraw BaseLine");
            table.Add("OverLineCheckBox", "Check/uncheck to draw/undraw OverLine");
            table.Add("TestRichTextBox", "Sample font, size, weight, color, etc");
            table.Add("TextColorListBox", "List popular colors for text");
            table.Add("TextColorTextBox", "Input to find an avaliable color");
            table.Add("FontSizeListBox", "List avaliable sizes in point for specified font");
            table.Add("FontStretchListBox", "List avaliable stretchs for specified font");
            table.Add("FontWeightListBox", "List avaliable weights for specified font");
            table.Add("FontStyleListBox", "List avaliable styles for specified font");
            table.Add("FontFamilyListBox", "List avaliable System fonts");
            table.Add("FontSizeTextBox", "Input to find an avaliable font Size");
            table.Add("FontStretchTextBox", "Input to find an avaliable font Stretch");
            table.Add("FontWeightTextBox", "input to find an avaliable font Weigth");
            table.Add("FontStyleTextBox", "Input to find an avaliable font Style");
            table.Add("FontFamilyTextBox", "Input to find an avaliable System font");
        }
        /// <summary>
        /// return the hastable containing all the tooltip messages. using the Control ID as key to retrieve the message.
        /// </summary>
        /// <param name="ControlID">the key to return a specific message.</param>
        /// <returns>return a string that describle the usage of each control in the Font dialog</returns>
        public static string GetToolTipMessage(string ControlID)
        {
            return (string)table[ControlID];

        }
    }
}
