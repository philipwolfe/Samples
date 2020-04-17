'=====================================================================
'  File:      BlendFillEditor.vb
'
'  Summary:   Provides more of the Design time functionality of the 
'             BlendFill class by implementing a UI Type Editor for the
'             property browser in the IDE.
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

Imports System.Windows.Forms
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.Windows.Forms.ComponentModel
Imports System.Security.Permissions


Namespace Design

    '=----------------------------------------------------------------------=
    ' BlendFillEditor
    '=----------------------------------------------------------------------=
    ' 
    '
    ''' <summary>
    '''   This is a drop down editor for the BlendFill type, which gives us a 
    '''   cool way to show the various ways to blend as well as let the user
    '''   select the colors to blend.
    ''' </summary>
    '''
    <System.Security.Permissions.PermissionSet(SecurityAction.InheritanceDemand, Name:="FullTrust")> _
    <System.Security.Permissions.PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
    Public Class BlendFillEditor
        Inherits UITypeEditor


        '=------------------------------------------------------------------=
        ' GetEditStyle
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   We use this method to indicate that we're going to be using a
        '''   drop down editor for our value.
        ''' </summary>
        ''' 
        Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) _
                                                         As UITypeEditorEditStyle

            If Not (context Is Nothing) AndAlso Not (context.Instance Is Nothing) Then
                Return UITypeEditorEditStyle.DropDown
            End If

            Return MyBase.GetEditStyle(context)

        End Function ' GetEditStyle



        '=------------------------------------------------------------------=
        ' EditValue
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Instructs us to pop up our dropdown editor and let the user
        '''   edit the value for this class.
        ''' </summary>
        '''
        Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, _
                                                      ByVal provider As IServiceProvider, _
                                                      ByVal value As Object) _
                                                      As Object

            Dim editorService As IWindowsFormsEditorService
            Dim editor As BlendFillEditorUI
            Dim reverse As Boolean
            Dim blend As BlendFill

            If (Not (context Is Nothing) _
                AndAlso Not (context.Instance Is Nothing) _
                AndAlso Not (provider Is Nothing)) Then

                editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If Not (editorService Is Nothing) Then

                    '
                    ' get the current values and create an editor
                    '
                    blend = CType(value, BlendFill)
                    reverse = getReverseValue(context)
                    editor = New BlendFillEditorUI(editorService, blend, reverse)

                    '
                    ' Now use the host service to show the editor.
                    '
                    editorService.DropDownControl(editor)

                    '
                    ' Finally, get the new value and return it.
                    '
                    value = editor.GetValue()

                End If
            End If

            Return value

        End Function ' EditValue



        '=------------------------------------------------------------------=
        ' GetPaintValueSupported
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   We want to support cool painting in the property browser.
        ''' </summary>
        ''' 
        Public Overloads Overrides Function GetPaintValueSupported( _
                        ByVal context As ITypeDescriptorContext) _
                        As Boolean

            Return True

        End Function ' GetPaintValueSupported



        '=------------------------------------------------------------------=
        ' PaintValue
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Paints our cool value in the property browser.
        ''' </summary>
        ''' 
        Public Overloads Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)

            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim bf As BlendFill

            lgb = Nothing

            '
            ' i'm going to be quite surprised if they give us something 
            ' that ISN'T a BlendFill, but it's worth checking, just to be
            ' safe.
            '
            If TypeOf e.Value Is BlendFill Then
                bf = CType(e.Value, BlendFill)
            Else
                bf = Nothing
            End If

            If Not bf Is Nothing Then
                Try
                    lgb = bf.GetLinearGradientBrush(e.Bounds)

                    e.Graphics.FillRectangle(lgb, e.Bounds)
                Finally
                    If Not lgb Is Nothing Then lgb.Dispose()
                End Try
            Else
                System.Diagnostics.Debug.WriteLine("BlendFillEditor.Paint: " _
                        & "Curious:  We've been asked to paint something " _
                        & "that's not a BlendFill: " _
                        & e.Value.GetType().ToString())
            End If

        End Sub ' PaintValue








        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                   Private Methods/Functions/etc.
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' getReverseValue
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Indicates whether or not the given instance behind this editor
        '''   has RightToLeft reading set to true.
        ''' </summary>
        ''' 
        Private Function getReverseValue(ByVal context As ITypeDescriptorContext) _
                                         As Boolean

            Dim pdc As PropertyDescriptorCollection
            Dim pd As PropertyDescriptor
            Dim ctl As Control = Nothing
            Dim rtl As RightToLeft

            '
            ' We have to look at context.Instance, and see if it has a 
            ' property named "RightToLeft".  If so, then use that value,
            ' otherwise, just assume no RTL.
            '
            If Not context Is Nothing Then
                If Not context.Instance Is Nothing Then

                    '
                    ' Look through its properties.
                    '
                    pdc = TypeDescriptor.GetProperties(context.Instance)
                    If Not pdc Is Nothing Then
                        pd = pdc("RightToLeft")
                        rtl = CType(pd.GetValue(context.Instance), RightToLeft)
                        Try
                            ctl = CType(context.Instance, Control)
                        Catch ex As Exception
                        End Try
                        If Not ctl Is Nothing Then
                            Return MiscFunctions.GetRightToLeftValue(ctl)
                        Else
                            Return Not rtl = RightToLeft.No
                        End If
                    End If

                End If
            End If

            Return False

        End Function ' getReverseValue



    End Class ' BlendFillEditor



End Namespace ' Design
