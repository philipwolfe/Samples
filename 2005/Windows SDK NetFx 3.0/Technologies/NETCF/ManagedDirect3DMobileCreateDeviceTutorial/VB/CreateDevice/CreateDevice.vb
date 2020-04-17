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

'----------------------------------------------------------------------------
' File: CreateDevice.vb
'
' Desc: This is the first tutorial for using Direct3D. In this tutorial, all
'       we are doing is creating a Direct3D device and using it to clear the
'       window.
'
'----------------------------------------------------------------------------

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.MD3DM

    Module CreateDeviceMain
        Sub Main()
            Dim frm As New CreateDevice

            If Not frm.InitializeGraphics() Then ' Initialize Direct3D

                MessageBox.Show("Could not initialize Direct3D. " + _
                    "This tutorial will exit.")
                Return
            End If

            System.Windows.Forms.Application.Run(frm)
        End Sub
    End Module

    Public Class CreateDevice
        Inherits Form
        ' Our global variables for this project
        Dim DeviceForm As Device = Nothing ' Our rendering device

        Sub New()
            ' Set the caption
            Me.Text = "D3D Tutorial 01: CreateDevice"
            Me.MinimizeBox = False
        End Sub

        Function InitializeGraphics() As Boolean
            Try
                ' Now let's setup our D3D parameters
                Dim Parameters As PresentParameters = New PresentParameters()
                Parameters.Windowed = True
                Parameters.SwapEffect = SwapEffect.Discard

                DeviceForm = New Device(0, DeviceType.Default, Me, _
                    CreateFlags.None, Parameters)
            Catch
                Return False
            End Try

            Return True
        End Function


        Sub Render()
            If IsNothing(DeviceForm) Then Return

            'Clear the backbuffer to a blue color
            DeviceForm.Clear(ClearFlags.Target, _
                System.Drawing.Color.Blue, 1.0F, 0)
            'Begin the scene
            DeviceForm.BeginScene()

            ' Rendering of scene objects can happen here

            'End the scene
            DeviceForm.EndScene()
            DeviceForm.Present()
        End Sub

        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs)

            Me.Render() ' Render on painting
            Me.Invalidate() ' Render again
        End Sub

        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
        End Sub

        Protected Overrides Sub OnKeyPress( _ 
            ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Fix(System.Convert.ToByte(e.KeyChar)) = _
                Fix(System.Windows.Forms.Keys.Escape) Then
                Me.Dispose() ' Esc was pressed
            End If
        End Sub

    End Class
End Namespace








