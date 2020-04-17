﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;


#endregion

namespace Microsoft.Samples.WPFNotepad
{
    /// <summary>
    /// Define delegate 
    /// </summary>
    /// <param name="sender">the send object for the event</param>
    /// <param name="e">the argument for the call back</param>
    public delegate void FontChosenEventHandler(object sender, FontChooserDialogAppliedEventsArgs e);

    /// <summary>
    /// Define the event arg for DialogApplied event
    /// </summary>
    public class FontChooserDialogAppliedEventsArgs : EventArgs
    {
        FontChoice _choice;

        /// <summary>
        /// constructor for the event arg
        /// </summary>
        /// <param name="aitem"></param>
        public FontChooserDialogAppliedEventsArgs(FontChoice choice)
        {
            if (choice == null)
            {
                throw new Exception("FontChooserDialogAppliedEventArgs: choice must be non-null");
            }
            _choice = choice;
        }

        /// <summary>
        /// Return a Typeface object that identifies the family, style, weight and stretch of the font selected by the user.
        /// </summary>
        public FontChoice FontChoice
        {
            get
            {
                return _choice;
            }
        }
    }
}
