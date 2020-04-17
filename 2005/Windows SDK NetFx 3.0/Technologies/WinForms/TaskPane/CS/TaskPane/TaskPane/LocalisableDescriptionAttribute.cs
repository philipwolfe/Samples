//=====================================================================
//  File:      LocalisableDescriptionAttribute.vb
//
//  Summary:   This is an inheriting class from the DescriptionAttribute
//             class that will let us localize strings for descriptions.
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

using System.ComponentModel;
using System.Resources;


namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    //=----------------------------------------------------------------------=
    // LocalisableDescriptionAttribute
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is a subclass of the Description Attribute that will let use
    ///   localize these values.
    /// </summary>
    /// 
    public class LocalisableDescriptionAttribute : DescriptionAttribute
    {

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //               Public Members/Methods/Functions/etc...
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Goes and initializes a new instance of this class given the XML key
        ///   to find for the actual localized description text.
        /// </summary>
        /// 
        /// <param name="in_key">
        ///   Key for which to search in the resources.
        /// </param>
        /// 
        public LocalisableDescriptionAttribute(string in_key) 
        : base(TaskPaneMain.GetResourceManager().GetString(in_key))
        {
        }
    }

}


