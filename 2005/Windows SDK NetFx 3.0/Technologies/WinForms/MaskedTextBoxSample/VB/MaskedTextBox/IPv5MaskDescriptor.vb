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

Imports System
Imports System.Windows.Forms.Design


'<summary>
' Summary description for IPv5MaskDescriptor.
'</summary>

Public Class IPv5MaskDescriptor
    Inherits MaskDescriptor
    
    Public Overrides ReadOnly Property Mask() As String 
        Get
            Return "099.099.099.099"
        End Get
    End Property 
    
    Public Overrides ReadOnly Property Name() As String 
        Get
            Return "IPv5 IP address"
        End Get
    End Property 
    
    Public Overrides ReadOnly Property Sample() As String 
        Get
            Return "128.128.1.0"
        End Get
    End Property 
    
    Public Overrides ReadOnly Property ValidatingType() As Type 
        Get
            Return GetType(IPv5)
        End Get
    End Property

End Class 'IPv5MaskDescriptor