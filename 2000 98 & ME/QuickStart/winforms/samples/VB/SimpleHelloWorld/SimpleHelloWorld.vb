'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Namespace Microsoft.Samples.WinForms.VB.SimpleHelloWorld 

    Public Class SimpleHelloWorld
        Inherits System.WinForms.Form

        'Run the application
        Shared Sub Main()
            System.WinForms.Application.Run(New SimpleHelloWorld())
        End Sub

        Public Sub New() 
            MyBase.New
            Me.Text = "Hello World"
        End Sub
        
    End Class
    
End Namespace






