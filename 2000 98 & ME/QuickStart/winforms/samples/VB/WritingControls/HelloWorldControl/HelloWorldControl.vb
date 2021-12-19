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

Namespace Microsoft.Samples.WinForms.VB.HelloWorldControl 

    public class HelloWorldControl 
        Inherits RichControl 
        
        Overrides Protected Sub OnPaint(e As PaintEventArgs) 

            'Paint the Text property on the control
            Dim rect As RectangleF = new RectangleF(ClientRectangle.X, ClientRectangle.Y,ClientRectangle.Width,ClientRectangle.Height) 
            e.Graphics.DrawString(Me.Text, Font, new SolidBrush(ForeColor), rect)
            
       End Sub
       
   End Class
   
End Namespace

