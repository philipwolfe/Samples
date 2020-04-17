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
using System.ComponentModel;
using System.Text;


namespace Microsoft.Samples.Windows.Forms.UnifiedCommands
{
    //=----------------------------------------------------------------------=
    // LocalizableDescriptionAttribute
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   An overridden version of the DescriptionAttribute that, instead of
    ///   the description text, takes a key to look up in the localised 
    ///   resources for this project instead.  Thus, you can get localised
    ///   descriptions in the IDE.
    /// </summary>
    /// 
    public class LocalizableDescriptionAttribute : DescriptionAttribute
    {
        //=------------------------------------------------------------------=
        // LocalizableDescriptionAttribute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this class, taking the specified
        ///   key and obtaining the string from the resources file.
        /// </summary>
        /// 
        /// <param name="key">
        ///   Key of the string resource to look for in the .resx file.
        /// </param>
        /// 
        public LocalizableDescriptionAttribute(string key)
          : base(UnifiedCommandsMain.GetResourceManager().GetString(key))
        {
        }
    }
}
