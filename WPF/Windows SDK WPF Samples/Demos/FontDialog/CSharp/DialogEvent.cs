#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace FontDialog
{
    /// <summary>
    /// Define delegate 
    /// </summary>
    /// <param name="sender">the send object for the event</param>
    /// <param name="e">the argument for the call back</param>
    public delegate void DialogAppliedEventHandler(object sender, DialogAppliedEventsArgs e);

    /// <summary>
    /// Define the event arg for DialogApplied event
    /// </summary>
    public class DialogAppliedEventsArgs : EventArgs
    {
        WPFFont item;
        /// <summary>
        /// constructor for the event arg
        /// </summary>
        /// <param name="aitem"></param>
        public DialogAppliedEventsArgs(WPFFont aitem)
        {
            if (null == aitem)
            {
                throw new Exception("Argument can't be null!!!");
            }
            item = aitem;
        }
        /// <summary>
        /// return WPFFont object that contains all the font message.
        /// </summary>
        public WPFFont FontItem
        {
            get
            {
                return item;
            }
        }
    }
}
