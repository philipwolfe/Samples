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
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.Text

Imports System.Drawing


#End Region


Class Flag
    Private flagName As String
    Private flagImage As Image
    
    
    Public Sub New(ByVal name As String, ByVal image As Image) 
        Me.flagName = name
        Me.flagImage = image
    
    End Sub 'New
    
    
    Public ReadOnly Property Name() As String 
        Get
            Return Me.flagName
        End Get
    End Property 
    
    Public ReadOnly Property Image() As Image 
        Get
            Return Me.flagImage
        End Get
    End Property
End Class 'Flag
