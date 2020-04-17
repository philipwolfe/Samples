//=====================================================================
//  File:      BlendFill.cs
//
//  Summary:   A class that wraps into the UI in a nifty vb-friendly 
//             fashion a System.Drawing.Drawing2D.LinearGradientBrush.  
//
//---------------------------------------------------------------------
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

using System;
using System.Drawing;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design.Serialization;


namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    //=----------------------------------------------------------------------=
    // BlendFill
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   A nifty little class that wraps a LinearGradientBrush into a 
    ///   VB-user friendly class that can be code gen'd and easily added
    ///   to your controls.
    /// </summary>
    ///
    [Editor(typeof(Design.BlendFillEditor), 
            typeof(System.Drawing.Design.UITypeEditor)), 
     TypeConverter(typeof(BlendFill.BlendFillTypeConverter)), 
     Serializable]
    public class BlendFill
    {
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                      Private types/data/goo/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary>
        ///   Blend style
        /// </summary>
        /// 
        private BlendStyle m_style;

        /// 
        /// <summary>
        /// Start Color
        /// </summary>
        /// 
        private Color m_startColor;

        ///
        /// <summary>
        /// End Color
        /// </summary>
        /// 
        private Color m_finishColor;





        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                     Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        // 
        /// <summary>
        ///   Initializes a new instance of this class.  Requires the blend
        ///   style, as well as the start and finish color.
        /// </summary>
        /// 
        /// <param name="in_blendStyle">
        ///   Style of blending we'll use.
        /// </param>
        /// 
        /// <param name="in_startColor">
        ///   Color with which to begin blend.
        /// </param>
        /// 
        /// <param name="in_finishColor">
        ///   Color with which to finish blend.
        /// </param>
        /// 
        public BlendFill
        (
            BlendStyle in_blendStyle,
            Color in_startColor,
            Color in_finishColor
        )
        {
            this.m_startColor = in_startColor;
            this.m_finishColor = in_finishColor;
            this.m_style = in_blendStyle;
        }


        //=------------------------------------------------------------------=
        // Style
        //=------------------------------------------------------------------=
        /// <summary>
        ///   What style of blend is this
        /// </summary>
        /// 
        /// <value>
        ///   A value from the BlendStyle enumeration.
        /// </value>
        ///
        [LocalisableDescription("BlendFill.Style"), 
         Category("Appearance"), 
         DefaultValue(BlendStyle.Vertical)]
        public BlendStyle Style
        {
            get
            {
                return this.m_style;
            }
        }

        //=------------------------------------------------------------------=
        // StartColor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls which color is used to start the blend painting.
        /// </summary>
        /// 
        /// <value>
        ///   A Color object control what color is used to start the blend.
        /// </value>
        ///
        [LocalisableDescription("BlendFill.StartColor"), 
         Category("Appearance")]
        public Color StartColor
        {
            get
            {
                return this.m_startColor;
            }
        }


        //=------------------------------------------------------------------=
        // FinishColor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Indicates the ending color of the linear blend operation in the 
        ///   painting.
        /// </summary>
        /// 
        /// <value>
        ///   The finishing color in the painting operation.
        /// </value>
        ///
        [LocalisableDescription("BlendFill.FinishColor"), 
         Category("Appearance")]
        public Color FinishColor
        {
            get
            {
                return this.m_finishColor;
            }
        }


        //=------------------------------------------------------------------=
        // GetLinearGradientBrush
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns a LinearGradientBrush for the currently chosen values.
        /// </summary>
        /// 
        /// <param name="in_rect">
        ///   A rectangle for the area which the caller wishes painted.
        ///   This is necessary for the linear gradient code to know how to 
        ///   fill the brush.  Please note that this should be the rect of the
        ///   <em>full</em> area to be painted, not the clip rectangle.
        /// </param>
        /// 
        /// <returns>
        ///    A LinearGradientBrush which can be used to paint.
        /// </returns>
        /// 
        [LocalisableDescription("BlendFill.GetLinearGradientBrush"), 
         Category("Appearance")]
        public System.Drawing.Drawing2D.LinearGradientBrush 
            GetLinearGradientBrush(Rectangle in_rect)
        {
            //
            // Use the overloaded version
            //
            return this.GetLinearGradientBrush(in_rect, false);
        }


        //=------------------------------------------------------------------=
        // GetLinearGradientBrush
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns a LinearGradientBrush for the currently set values,
        ///   letting the caller specify whether we should reverse the
        ///   values for RTL painting.
        /// </summary>
        /// 
        /// <param name="in_rect">
        ///   The bounding rectangle for painting.
        /// </param>
        /// 
        /// <param name="in_reverseForRTL">
        ///   True == reverse the values for RightToLeft reading.
        /// </param>
        /// 
        /// <returns>
        ///   A linearGradientBrush
        /// </returns>
        ///
        [LocalisableDescription("BlendFill.GetLinearGradientBrush2"), 
         Category("Appearance")]
        public LinearGradientBrush GetLinearGradientBrush
        (
            Rectangle in_rect, 
            bool in_reverseForRTL
        )
        {
            // Note: When using LinearGradientBrush, if you specify an angle 
            // of 180 degrees, it doesn't draw the left most pixel in
            // the rectangle.  Thus, instead of  trying to fiddle with
            // pixels and rect boundaries, we're just going to swap the 
            // colors on RTL systems with a Horizontal Gradient.
            // Otherwise, we'll go with the normal code paths
            // to do this.
            //
            if (in_reverseForRTL && this.m_style == BlendStyle.Horizontal)
            {
                return new LinearGradientBrush(in_rect, this.m_finishColor,
                    this.m_startColor, 0.0f);
            }
            else
            {
                return new LinearGradientBrush(in_rect, this.m_startColor,
                    this.m_finishColor, getAngle(this.m_style, in_reverseForRTL));
            }
        }









        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Private Methods/Properties/Subs
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // getAngle
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns an angle for a LinearGradientBrush given a 
        ///   direction/style.
        /// </summary>
        /// 
        /// <param name="in_direction">
        ///   The BlendStyle or Direction of painting.
        /// </param>
        /// 
        /// <param name="in_reverseForRTL">
        ///   Indicates wheter we should reverse for RightToLeftReading.
        /// </param>
        /// 
        /// <returns>
        ///   Returns the Angle that should be used in drawing.
        /// </returns>
        /// 
        private static float getAngle
        (
            BlendStyle in_direction,
            bool in_reverseForRTL
        )
        {
            switch (in_direction)
            {
                case BlendStyle.Horizontal:
                    if (in_reverseForRTL)
                    {
                        return 180;
                    }
                    else
                    {
                        return 0;
                    }

                case BlendStyle.Vertical:
                    return 90;

                case BlendStyle.ForwardDiagonal:
                    if (in_reverseForRTL)
                    {
                        return 135;
                    }
                    else
                    {
                        return 45;
                    }

                case BlendStyle.BackwardDiagonal:
                    if (in_reverseForRTL)
                    {
                        return 45;
                    }
                    else
                    {
                        return 135;
                    }

                default:
                    System.Diagnostics.Debug.Fail("Bogus Direction");
                    return 0;
            }
        }







        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                            Nested Classes
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // BlendFillTypeConverter
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This class provides a bunch of cool design time functionality 
        ///   for our BlendFill class, as well as the ability to Code-Gen it. 
        ///   Sweet!
        ///
        ///   To do this, it inherits and implements a bunch of the methods
        ///   on the  TypeConverter class ...
        /// </summary>
        /// 
		[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name = "FullTrust")]
		[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public class BlendFillTypeConverter :
            TypeConverter
        {

            //=--------------------------------------------------------------=
            // CanConvertTo
            //=--------------------------------------------------------------=
            //
            /// <summary>
            ///   We support conversion to String as well as
            ///   InstanceDescriptor format, which makes it a bit easier 
            ///   on us in code generation.
            /// </summary>
            /// 
            public override bool CanConvertTo
            (
                ITypeDescriptorContext context,
                Type destinationType
            )
            {
                if (destinationType == typeof(string) 
                    || destinationType == typeof(InstanceDescriptor))
                {
                    return true;
                }

                return base.CanConvertTo(context, destinationType);
            }


            //=--------------------------------------------------------------=
            // ConvertTo
            //=--------------------------------------------------------------=
            /// <summary>
            ///   This is how we convert ourselves to a string or an Instance-
            ///   Descriptor, which is used in code generation.
            /// </summary>
            /// 
            public override object ConvertTo
            (
                ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture,
                object value,
                System.Type destinationType
            )
            {
                ConstructorInfo ci;
                BlendFill bf;

                //
                // We'll only do something if they're asking us to convert a 
                // BlendFill object, of course ...
                //
                if (value is BlendFill)
                {
                    bf = (BlendFill)value;
                }
                else
                {
                    bf = null;
                }

                if (bf != null)
                {
                    //
                    // What type do they want???
                    //
                    if (destinationType == typeof(InstanceDescriptor))
                    {
                        //
                        // Get the constructor that takes the style, and two
                        // colors
                        //
                        ci = typeof(BlendFill).GetConstructor(new Type[] { 
                        typeof(BlendStyle),
                        typeof(Color),
                        typeof(Color) 
                    });

                        if (ci != null)
                        {
                            //
                            // Return the values for this constructor.
                            //
                            return new InstanceDescriptor(ci, new object[] {
                                bf.Style, bf.StartColor, bf.FinishColor
                            });
                        }
                    }
                    else if (destinationType == typeof(string))
                    {
                        return blendFillToString(bf, culture);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        "BlendFillTypeConverter.ConvertTo:Curious:  We've " +
                        "been asked to code gen something that isn't: " +
                        "of type BlendFill: " + value.GetType().ToString());
                }

                return base.ConvertTo(context, culture, value, destinationType);
            }


            //=--------------------------------------------------------------=
            // ConvertFrom
            //=--------------------------------------------------------------=
            /// <summary>
            ///   You can convert from Strings (of a certain type) to
            ///   this object.
            /// </summary>
            ///
            public override object ConvertFrom
            (
                ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture,
                object value
            )
            {

                string bf;

                //
                // If they gave us a string, then we'll try our best
                // to parse it  out.
                //
                if (value is string)
                {
                    bf = (string)value;
                }
                else
                {
                    bf = null;
                }

                if (bf != null)
                {
                    return blendFillFromString(bf.Trim(), culture);
                }

                return base.ConvertFrom(context, culture, value);
            }


            //=--------------------------------------------------------------=
            // CanConvertFrom
            //=--------------------------------------------------------------=
            /// <summary>
            ///   You can convert from Strings (of a certain type) to
            ///   this object.
            /// </summary>
            ///
            public override bool CanConvertFrom
            (
                ITypeDescriptorContext context,
                Type sourceType
            )
            {
                if (sourceType == typeof(string)) { return true; }
                return base.CanConvertFrom(context, sourceType);
            }


            //=--------------------------------------------------------------=
            // parseBlendStyle
            //=--------------------------------------------------------------=
            /// <summary>
            ///    Given the string value of a blend style, parse it back
            ///    to an int
            /// </summary>
            /// 
            /// <param name="in_val">
            ///   A BlendFill object as a string.
            /// </param>
            /// 
            /// <returns>
            ///   A BlendFill object representing the value from the string.
            /// </returns>
            /// 
            private static BlendStyle parseBlendStyle(string in_val)
            {
                string[] names;
                int x;

                System.Diagnostics.Debug.Assert(in_val != null);
                in_val = in_val.Trim();

                //
                // Okay, get the list of names in the Enumeration.
                //
                names = System.Enum.GetNames(typeof(BlendStyle));
                for (x = 0; x < names.Length; x++)
                {
                    if (names[x].Equals(in_val)) { return ((BlendStyle)x); }
                }

                return BlendStyle.Horizontal;
            }


            //=--------------------------------------------------------------=
            // blendFillToString
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Converts a blend fill object to a string, using Culture 
            ///   Sensitive separators and using text values where possible.
            /// </summary>
            /// 
            /// <param name="in_bf">
            ///   Convert me to a string.
            /// </param>
            /// 
            /// <param name="in_culture">
            ///   From whence to get the cultural information.
            /// </param>
            /// 
            /// <returns>
            ///   The object as s string.
            /// </returns>
            /// 
            private static string blendFillToString
            (
                BlendFill in_bf,
                CultureInfo in_culture
            )
            {
                System.Text.StringBuilder sb;
                TypeConverter tci, tcc;
                string sep;
                string[] args = new string[2];

                //
                // Get appropriate conveters and culture data
                //
                tci = TypeDescriptor.GetConverter(typeof(int));
                tcc = TypeDescriptor.GetConverter(typeof(Color));
                if (in_culture == null)
                {
                    in_culture = CultureInfo.CurrentCulture; 
                }
                sep = in_culture.TextInfo.ListSeparator + " ";

                //
                // Get the style as a string
                //
                args[0] = System.Enum.GetName(typeof(BlendStyle), in_bf.Style);

                //
                // start color
                //
                args[1] = tcc.ConvertToString(in_bf.StartColor);

                //
                // Finish color
                //
                args[2] = tcc.ConvertToString(in_bf.FinishColor);

                //
                // Generate the string.  We have to wrap the colors in () so that
                // ARGB specified ones can be determined later ...
                //
                sb = new System.Text.StringBuilder();

                sb.Append(args[0]);
                sb.Append(sep);
                sb.Append("(");
                sb.Append(args[1]);
                sb.Append(")");
                sb.Append(sep);
                sb.Append("(");
                sb.Append(args[2]);
                sb.Append(")");

                return sb.ToString();
            }


            //=--------------------------------------------------------------=
            // blendFillFromString
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Given a string that we serialized out using
            ///   blendFillToString, this function attempts to parse in the
            ///   given input and regenerate a  BlendFill object.
            /// </summary>
            /// 
            /// <param name="in_bf">
            ///   What to parse back into a BlendFill.
            /// </param>
            /// 
            /// <param name="in_culture">
            ///   What cultural information to use for this parse.
            /// </param>
            /// 
            /// <returns>
            ///   A BlendFill representing the data from the string.
            /// </returns>
            ///
            private static BlendFill blendFillFromString
            (
                string in_bf,
                CultureInfo in_culture
            )
            {
                TypeConverter tcc;
                BlendStyle style;
                string[] pieces;
                Color c1, c2;
                string sep;

                //
                // Get the various type converters and culture info we need
                //
                if (in_culture == null) 
                {
                    in_culture = CultureInfo.CurrentCulture; 
                }
                sep = in_culture.TextInfo.ListSeparator;
                tcc = TypeDescriptor.GetConverter(typeof(Color));

                //
                // Explode the string.  Unfortunately, we can't use 
                // String.Split() since we need to preserve ()s around 
                // the colors.
                //
                pieces = MiscFunctions.ExplodePreservingSubObjects(in_bf, 
                    sep, '(', ')');

                if (pieces.Length != 3)
                {
                    throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excBlendFillParse"), "value");
                }

                style = parseBlendStyle(pieces[0]);
                c1 = (Color)tcc.ConvertFromString(pieces[1]);
                c2 = (Color)tcc.ConvertFromString(pieces[2]);

                if ((int)style == -1
                    || c1.Equals(Color.Empty)
                    || c2.Equals(Color.Empty))
                {
                    throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excBlendFillParse"), "value");
                }

                return new BlendFill(style, c1, c2);
            }
        }
    }
}