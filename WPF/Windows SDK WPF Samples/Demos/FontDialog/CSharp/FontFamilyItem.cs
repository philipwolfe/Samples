#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

#endregion

namespace FontDialog
{
    public class FontFamilyItem
    {
        private FontFamily font;
        public FontFamilyItem(FontFamily Font)
        {
            font = Font;
        }
        /// <summary>
        /// The string returned is used to create the list item.
        /// </summary>
        /// <returns>font family name</returns>
        public override string ToString()
        {
            return font.Source;
        }
        /// <summary>
        /// return the font family
        /// </summary>
        public FontFamily FontFamily
        {
            get
            {
                return font;
            }
        }
    }
}
