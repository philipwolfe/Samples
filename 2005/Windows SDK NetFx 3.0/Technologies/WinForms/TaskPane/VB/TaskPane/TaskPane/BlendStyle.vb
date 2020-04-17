'=====================================================================
'  File:      BlendStyle.vb
'
'  Summary:   An enumeration indicating how blend operations should be
'             performed on those controls with a BlendStyle property.
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



'=--------------------------------------------------------------------------=
' BlendStyle
'=--------------------------------------------------------------------------=
''' <summary>
'''   This is a simple enumeration controlling the way in which a background
'''   is blended on the BlendPanel or other similar controls.
''' </summary>
''' 
''' <remarks>
'''   These values mirror System.Drawing.Drawing2D.LinearGradientMode
''' </remarks>
''' 
<LocalisableDescription("BlendStyle")> _
Public Enum BlendStyle

    <LocalisableDescription("BlendStyle.Horizontal")> _
    Horizontal = 0

    <LocalisableDescription("BlendStyle.Vertical")> _
    Vertical

    <LocalisableDescription("BlendStyle.ForwardDiagonal")> _
    ForwardDiagonal

    <LocalisableDescription("BlendStyle.BackwardDiagonal")> _
    BackwardDiagonal

End Enum ' BlendStyle


