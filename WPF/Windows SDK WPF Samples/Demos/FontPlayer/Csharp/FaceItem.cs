#region Using directives

using System;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


#endregion

namespace FontPlayer2
{
    class FaceItem
    {
        private Typeface myTypeface;
        public FaceItem(Typeface face)
        {
            myTypeface = face;
        }
        public FaceItem()
        {           
        }
        public override String ToString()
        {
            return "Weight: " + myTypeface.Weight.ToString() + " Style: " + myTypeface.Style.ToString() + " Stretch: " + myTypeface.Stretch.ToString();
        }
        public FontWeight FontWeight
        {   
            get{ return myTypeface.Weight;}
        }

        public FontStretch FontStretch
        {   
            get{ return myTypeface.Stretch;}
        }

        public FontStyle FontStyle
        {
            get { return myTypeface.Style; }
        }

    }
}
