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
Imports System.WinForms.ComponentModel
Imports System.WinForms.Design

Namespace Microsoft.Samples.WinForms.VB.FlashTrackBar 

    Public Class FlashTrackBarValueEditor 
        Inherits UITypeEditor 

        private edSvc As IWinFormsEditorService


        Overridable Protected Sub SetEditorProps(editingInstance As FlashTrackBar, editor As FlashTrackBar) 
            editor.ShowValue = true
            editor.StartColor = Color.Navy
            editor.EndColor = Color.White
            editor.ForeColor = Color.White
            editor.Min = editingInstance.Min
            editor.Max = editingInstance.Max
        End Sub
 
        Overrides OverLoads Public Function EditValue(context As ITypeDescriptorContext, provider As IServiceObjectProvider, value As object) As Object
 
            if (Not(context Is Nothing) AND Not(context.Instance Is Nothing) AND Not(provider Is Nothing)) Then
 
                edSvc = CType(provider.GetServiceObject(GetType(IWinFormsEditorService)),IWinFormsEditorService)
 
                if Not (edSvc Is Nothing) Then
                    
                    Dim trackBar As FlashTrackBar = new FlashTrackBar()
                    AddHandler trackBar.ValueChanged, AddressOf Me.ValueChanged
                    SetEditorProps(CType(context.Instance,FlashTrackBar), trackBar)
                    
                    Dim asInt As Boolean = true
                    
                    if (TypeOf value Is Integer) Then
                        trackBar.Value = CInt(value)
                    else if (TypeOf value Is System.Byte) Then
                        asInt = false
                        trackBar.Value = CType(value, Byte)
                    End If
                    
                    edSvc.DropDownControl(trackBar)
                    
                    if (asInt) Then
                        value = trackBar.Value
                    else 
                        value = CType(trackBar.Value, Byte)
                    End If
                    
                End If
                
            End If
 
             return value
            
         End Function

        Overrides OverLoads Public Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
            if (Not(context Is Nothing) AND Not(context.Instance Is Nothing)) Then
                return UITypeEditorEditStyle.DropDown
            End If
            return MyBase.GetEditStyle(context)
        End Function

        private Sub ValueChanged(sender As object, e As EventArgs) 
            if Not(edSvc Is Nothing) Then
                edSvc.CloseDropDown()
            End If
        End Sub
        
    End Class

End Namespace
