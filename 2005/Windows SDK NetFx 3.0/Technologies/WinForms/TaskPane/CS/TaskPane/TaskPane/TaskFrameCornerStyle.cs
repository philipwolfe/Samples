//=====================================================================
//  File:      TaskFrameCornerStyle.cs
//
//  Summary:   Controls how the top corners of TaskFrame frames
//             are drawn within the TaskPane class.
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
    /// <summary>
    ///   These are the possible corner styles for a TaskFrame in a TaskPane
    ///   control.
    /// </summary>
    /// 
    [LocalisableDescription("TaskFrameCornerStyle")]
    public enum TaskFrameCornerStyle
    {

        [LocalisableDescription("TaskFrameCornerStyle.Rounded")]
        Rounded = 0,

        [LocalisableDescription("TaskFrameCornerStyle.Squared")]
        Squared,

        [LocalisableDescription("TaskFrameCornerStyle.SystemDefault")]
        SystemDefault

    };
}



