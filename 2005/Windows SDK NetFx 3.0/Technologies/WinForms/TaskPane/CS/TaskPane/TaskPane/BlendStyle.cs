//=====================================================================
//  File:      BlendStyle.vb
//
//  Summary:   An enumeration indicating how blend operations should be
//             performed on those controls with a BlendStyle property.
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


namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    //=----------------------------------------------------------------------=
    // BlendStyle
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is a simple enumeration controlling the way in which a background
    ///   is blended on the BlendPanel or other similar controls.
    /// </summary>
    /// 
    /// <remarks>
    ///   These values mirror System.Drawing.Drawing2D.LinearGradientMode
    /// </remarks>
    /// 
    [LocalisableDescription("BlendStyle")]
    public enum BlendStyle
    {

        [LocalisableDescription("BlendStyle.Horizontal")] Horizontal = 0,

        [LocalisableDescription("BlendStyle.Vertical")] Vertical,

        [LocalisableDescription("BlendStyle.ForwardDiagonal")] ForwardDiagonal,

        [LocalisableDescription("BlendStyle.BackwardDiagonal")] BackwardDiagonal

    };



}
