#region Using directives
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections;
using System.Windows.Shapes;
#endregion

namespace FontDialog
{
    /// <summary>
    /// This class defines the WPF font. 
    /// </summary>
    public class WPFFont
    {
        private FontFamily font = new FontFamily("Arial");
      private FontStyle currentStyle = System.Windows.FontStyles.Normal;
      private FontWeight currentWeight = System.Windows.FontWeights.Normal;
      private FontStretch currentStretch = System.Windows.FontStretches.Normal;
        private double currentSize = 8d;
        private TextDecorationCollection textDecorationCollection;
        private SolidColorBrush textColor = Brushes.Black;
        /// <summary>
        /// Get and set the font family.
        /// </summary>
        public FontFamily FontFamily
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        /// <summary>
        /// Get and set the font styles
        /// </summary>
        public FontStyle FontStyle
        {
            get
            {
                return currentStyle;
            }
            set
            {
                currentStyle = value;
            }
        }
        /// <summary>
        /// Get and set the font weight
        /// </summary>
        public FontWeight FontWeight
        {
            get
            {
                return currentWeight;
            }
            set
            {
                currentWeight = value;
            }
        }
        /// <summary>
        /// get and set the font Stretch
        /// </summary>
        public FontStretch FontStretch
        {
            get
            {
                return currentStretch;
            }
            set
            {
                currentStretch = value;
            }
        }
        /// <summary>
        /// Get and set Font size IB: switched from Fontsize
        /// </summary>
        public double FontSize
        {
            get
            {
                return currentSize;
            }
            set
            {
                currentSize = value;
            }
        }
        /// <summary>
        /// Get and set the Text color
        /// </summary>
        public SolidColorBrush Foreground
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value; 
            }
        }
        /// <summary>
        /// Return a collection of avaliable font styles 
        /// </summary>
        public static ICollection FontStyles
        {
            get
            {
                ArrayList aList = new ArrayList();
                aList.Add(System.Windows.FontStyles.Italic);
                aList.Add(System.Windows.FontStyles.Normal);
                aList.Add(System.Windows.FontStyles.Oblique);
                return aList;
                //return FontTypeface("Style");
            }
        }
        /// <summary>
        /// return a array of color names
        /// </summary>
        public static string [] ColorNames
        {
            get
            {
                return KnowColor.ColorNames; 
            }

        }
        /// <summary>
        /// Return a hastable that contains colors
        /// </summary>
        public static Hashtable ColorTable
        {
            get
            {
                return KnowColor.ColorTable; 
            }
        }
        /// <summary>
        /// return a collection of avaliable FontWeight
        /// </summary>
        public static ICollection FontWeights
        {
            get
            {
                ArrayList aList = new ArrayList();
                aList.Add(System.Windows.FontWeights.Black);
                aList.Add(System.Windows.FontWeights.Bold);
                aList.Add(System.Windows.FontWeights.ExtraBold);
                aList.Add(System.Windows.FontWeights.ExtraLight);
                aList.Add(System.Windows.FontWeights.Light);
                aList.Add(System.Windows.FontWeights.Medium);
                aList.Add(System.Windows.FontWeights.Normal);
                aList.Add(System.Windows.FontWeights.SemiBold);
                aList.Add(System.Windows.FontWeights.Thin);
                return aList; 
                //return FontTypeface("Weight");
            }
        }
        /// <summary>
        /// return a collection of avaliable Font stretches
        /// </summary>
        public static ICollection FontStretchs
        {
            get
            {
                ArrayList aList = new ArrayList();
                aList.Add(System.Windows.FontStretches.Condensed);
                aList.Add(System.Windows.FontStretches.Expanded);
                aList.Add(System.Windows.FontStretches.ExtraCondensed);
                aList.Add(System.Windows.FontStretches.ExtraExpanded);
                aList.Add(System.Windows.FontStretches.Normal);
                aList.Add(System.Windows.FontStretches.SemiCondensed);
                aList.Add(System.Windows.FontStretches.SemiExpanded);
                aList.Add(System.Windows.FontStretches.UltraCondensed);
                aList.Add(System.Windows.FontStretches.UltraExpanded);
                return aList;
                //return FontTypeface("Stretch");
            }
        }
        /// <summary>
        /// return a collection of font sizes.
        /// </summary>
        public static ICollection FontSizes
        {
            get
            {
                ArrayList aList = new ArrayList();
                for(double i =1; i<=108; i++)
                {
                    aList.Add(i);
                }
                return aList;
            }
        }
        /// <summary>
        /// get and set text decorations
        /// </summary>
        public TextDecorationCollection TextDecorationCollection
        {
            get
            {
                return textDecorationCollection; 
            }
            set
            {
                textDecorationCollection = value;
            }
        }
        ICollection FontTypeface(string typefaceName)
        {
          ICollection enumTypefaces = font.GetTypefaces() as ICollection;
            ArrayList aList = new ArrayList();
            foreach (Typeface typeface in enumTypefaces)
            {
                if (typefaceName == "Style")
                {
                    if (!aList.Contains(typeface.Style))
                        aList.Add(typeface.Style);
                }
                else if (typefaceName == "Weight")
                {
                    if (!aList.Contains(typeface.Weight))
                        aList.Add(typeface.Weight);
                }
                else if (typefaceName == "Strech")
                {
                    if (!aList.Contains(typeface.Stretch))
                        aList.Add(typeface.Stretch);
                }
            }
            if (aList.Count == 0)
            {
                if (typefaceName == "Style")
                  aList.Add(System.Windows.FontStyles.Normal);
                else if (typefaceName == "Weight")
                  aList.Add(System.Windows.FontWeights.Normal);
                else if (typefaceName == "Stretch")
                    aList.Add(System.Windows.FontStretches.Normal);
            }
            return aList;
        }
    }
}
