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
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.WinForms
Imports System.Diagnostics

Namespace Microsoft.Samples.WinForms.VB.FlashTrackBar 

   Public Class FlashTrackBarDarkenByEditor 
        Inherits FlashTrackBarValueEditor 
   
       Overrides Protected Sub SetEditorProps(editingInstance As FlashTrackBar, editor As FlashTrackBar) 
           MyBase.SetEditorProps(editingInstance, editor)
           editor.Min = 0
           editor.Max = System.Byte.MaxValue
       End Sub
   
   End Class
   
end Namespace
