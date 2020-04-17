//=====================================================================
//  File:      MiscFunctions.cs
//
//  Summary:   Miscellaneous functions to do things we really need.
//
//
//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System.Windows.Forms;
using System.Drawing;



namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    //=----------------------------------------------------------------------=
    // MiscFunctions
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   Module (not class) to do some random goo we need done.
    /// </summary>
    /// 
    internal class MiscFunctions
    {
        //=-----------------------------------------------------------------=
        // ExplodePreservingSubObjects
        //=-----------------------------------------------------------------=
        /// <summary>
        ///    Given a string that contains a bunch of values separated by a
        ///    given list separator, split them out, with the added twist of
        ///    keeping objects wrapped in the specified start and end wrappers
        ///    intact.
        /// 
        ///    I.e.
        /// 
        ///    If the separator were ",", and start and end wrappers were '(' and ')', then:
        /// 
        ///    One, (Two, Three, Four), (5, 6, 7)
        /// 
        ///    would return:
        ///
        ///    One
        ///    Two, Three, Four
        ///    5, 6, 7
        /// 
        /// </summary>
        /// 
        /// <param name="in_str">
        ///   String to explode.
        /// </param>
        /// 
        /// <param name="in_sep">
        ///   Separator.
        /// </param>
        /// 
        /// <param name="in_start">
        ///   Sub-object start marker.
        /// </param>
        /// 
        /// <param name="in_finish">
        ///   Sub-object finish marker.
        /// </param>
        /// 
        /// <returns>
        ///   An array of strings.
        /// </returns>
        /// 
        public static string[] ExplodePreservingSubObjects
        (
            string in_str,
            string in_sep,
            char in_start,
            char in_finish
        )
        {
            System.Collections.ArrayList al;
            int inSubObject = 0;
            int start = 0;
            int idx = 0;
            string s = null;

            al = new System.Collections.ArrayList();

            //
            // loop through one character at a time looking for separator, etc
            //
            while (idx < in_str.Length)
            {
                if (in_str[idx] == in_start)
                {
                    inSubObject += 1;
                }
                else if (in_str[idx] == in_finish)
                {
                    inSubObject -= 1;
                }

                //
                // If we are at a separator, and aren't in a sub-object, then
                // split out the string, stripping off the sub-object markers.
                //
                if (in_str[idx].ToString().Equals(in_sep) && inSubObject == 0)
                {
                    s = in_str.Substring(start, idx - start).Trim();
                    if (s[0] == in_start)
                    {
                        s = s.Substring(1, s.Length - 2);
                    }
                    al.Add(s);
                    start = idx + 1;
                }

                idx += 1;

            }

            //
            // Finally add what's left!
            //
            s = in_str.Substring(start, idx - start).Trim();
            if (s[0] == in_start)
            {
                s = s.Substring(1, s.Length - 2);
            }
            al.Add(s);

            return ((string[])al.ToArray(typeof(string)));
        }


        //=-----------------------------------------------------------------=
        // GetRightToLeftValue
        //=-----------------------------------------------------------------=
        /// <summary>
        ///   Given a control, figure out if it should be drawn Right To Left,
        ///   which might involve going up the parent chain.
        /// </summary>
        /// 
        /// <param name="in_ctl">
        ///   Control whose RTL value we want to explore.
        /// </param>
        /// 
        /// <returns>
        ///   True means we should be drawing RTL.
        /// </returns>
        /// 
        public static bool GetRightToLeftValue(Control in_ctl)
        {
            switch (in_ctl.RightToLeft)
            {
                case RightToLeft.Yes:
                    return true;

                case RightToLeft.No:
                    return false;

                case RightToLeft.Inherit:
                    if (in_ctl.Parent == null)
                    {
                        return false;
                    }
                    else
                    {
                        return GetRightToLeftValue(in_ctl.Parent);
                    }
            }

            //
            // dead code
            //
            return false;
        }


        //=-----------------------------------------------------------------=
        // FlipColor
        //=-----------------------------------------------------------------=
        /// <summary>
        ///   Takes a color and returns a new one with all the values inverted 
        ///  inside of 255.
        /// </summary>
        /// 
        /// <param name="in_color">
        ///   Invert me please.
        /// </param>
        /// 
        /// <returns>
        ///   Inverted.
        /// </returns>
        /// 
        public static Color FlipColor(Color in_color)
        {
            return Color.FromArgb(in_color.A, 255 - in_color.R, 255 - in_color.G, 255 - in_color.B);
        }

        //=-----------------------------------------------------------------=
        // IconToBitmap
        //=-----------------------------------------------------------------=
        /// <summary>
        ///   Converts a System.Drawing.Icon to a System.Drawing.Bitmap
        /// </summary>
        /// 
        /// <param name="in_color">
        ///   Mask color to use as background.
        /// </param>
        /// 
        /// <param name="in_icon">
        ///   Icon to convert.
        /// </param>
        /// 
        /// <returns>
        ///   Bitmap object.
        /// </returns>
        /// 
        public static Bitmap IconToBitmap(Color in_color, Icon in_icon)
        {
            Graphics g;
            Bitmap b;

            b = new Bitmap(in_icon.Width, in_icon.Height, 
                         System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(Color.Black), 
                            new Rectangle(0, 0, b.Width, b.Height));
            g.DrawIcon(in_icon, 0, 0);
            g.Dispose();

            b.MakeTransparent(Color.Black);

            return b;
        }


        //=-----------------------------------------------------------------=
        // ScaleColor
        //=-----------------------------------------------------------------=
        /// <summary>
        ///   A function for scaling a color down a certain percentage
        /// </summary>
        /// 
        /// <param name="in_color">
        ///   Color to be scaled.
        /// </param>
        /// 
        /// <param name="in_pct">
        ///   Percentage to scale it.
        /// </param>
        /// 
        /// <returns>
        ///   New color object.
        /// </returns>
        /// 
        public static Color ScaleColor(Color in_color, int in_pct)
        {
            double d;
            int r, g, b;

            d = in_pct / 100.0;

            r = (int)(in_color.R * d);
            if (r > 255) { r = 255; }
            if (r < 0) { r = 0; }
            g = (int)(in_color.G * d);
            if (g > 255) { g = 255; }
            if (g < 0) { g = 0; }
            b = (int)(in_color.B * d);
            if (b > 255) { b = 255; }
            if (b < 0) { b = 0; }

            return Color.FromArgb(in_color.A, r, g, b);
        }
    
    }
}


