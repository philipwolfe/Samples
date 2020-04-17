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

using System.Resources;
using System.ComponentModel;


namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdate
{
    //=-----------------------------------------------------------------------=
    // LocalizableDescriptionAttribute
    //=-----------------------------------------------------------------------=
    /// <summary>
    ///   This is a handy little sub-class of the regular Description
    ///   attribute that lets us localize the strings of the descriptions.
    /// </summary>
    public class LocalizableDescriptionAttribute : DescriptionAttribute
    {
        //=-------------------------------------------------------------------=
        // LocalizableDescriptionAttribute
        //=-------------------------------------------------------------------=
        /// <summary>
        ///   Initializes a new instance of this class, passing the fully
        ///   localized string to the base class constructor.
        /// </summary>
        /// 
        /// <param name="key">
        ///   They key to use to get the localized string from the .resx
        ///   file.
        /// </param>
        /// 
        public LocalizableDescriptionAttribute(string key)
            : base(BackgroundUpdateMain.GetResourceManager().GetString(key))
        {
        }
    }
}
