'=====================================================================
'  File:      TaskFrameCornerStyle.vb
'
'  Summary:   Controls how the top corners of TaskFrame frames
'             are drawn within the TaskPane class.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System.ComponentModel

<LocalisableDescription("TaskFrameCornerStyle")> _
Public Enum TaskFrameCornerStyle

    <LocalisableDescription("TaskFrameCornerStyle.Rounded")> _
    Rounded = 0

    <LocalisableDescription("TaskFrameCornerStyle.Squared")> _
    Squared

    <LocalisableDescription("TaskFrameCornerStyle.SystemDefault")> _
    SystemDefault

End Enum ' TaskFrameCornerStyle




