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

'-----------------------------------------------------------------------------
' File: Vertices.vb
'
' Desc: In this tutorial, we are rendering some vertices. This introduces the
'       concept of the vertex buffer, a Direct3D object used to store
'       vertices. Vertices can be defined any way we want by defining a
'       custom structure and a custom FVF (flexible vertex format). In this
'       tutorial, we are using vertices that are transformed (meaning they
'       are already in 2D window coordinates) and lit (meaning we are not
'       using Direct3D lighting, but are supplying our own colors).
'
'-----------------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Namespace Microsoft.Samples.MD3DM

    ' The application entry point
    Module VerticesMain
        Sub Main()
            Dim frm As New Vertices

            ' Initialize Direct3D
            If Not frm.InitializeGraphics() Then
                MessageBox.Show("Could not initialize Direct3D. " + _
                    "This tutorial will exit.")
                Return
            End If

            System.Windows.Forms.Application.Run(frm)

        End Sub
    End Module

    ' The main application class
    Public Class Vertices

        Inherits Form
        ' Our global variables for this project
        Dim DeviceForm As Device = Nothing
        Dim VBuffer As VertexBuffer = Nothing

        Public Sub New()
            ' Set the caption of the form
            Me.Text = "Direct3D Tutorial 2 - Vertices"

            ' We want an OK Button.
            Me.MinimizeBox = False
        End Sub

        'Called when the device has been created (or recreated)
        Private Sub OnCreateDevice(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim Dev As Device = CType(sender, Device)
            Dim caps as Caps
            Dim vertexBufferPool as Pool
            
            ' Get the device capabilities
            
            caps = Dev.DeviceCaps
            
            If (caps.SurfaceCaps.SupportsVidVertexBuffer) Then
                vertexBufferPool = Pool.VideoMemory
            Else
                vertexBufferPool = Pool.SystemMemory
            End If
            
            'Now Create the VB
            VBuffer = New VertexBuffer( _
                GetType(CustomVertex.TransformedColored), _
                3, Dev, 0, CustomVertex.TransformedColored.Format, _
                vertexBufferPool)
            AddHandler VBuffer.Created, AddressOf Me.OnCreateVertexBuffer
            Me.OnCreateVertexBuffer(VBuffer, Nothing)

        End Sub

        ' Called whenever the vertex buffer is created (or recreated)
        Private Sub OnCreateVertexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)

            ' retrive the vertex buffer
            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            
            ' get a graphics stream to write into the buffer
            Dim stm As GraphicsStream = vb.Lock(0, 0, 0)

            ' create an array of vertices which can be written into the stream
            Dim verts(2) As CustomVertex.TransformedColored

            ' initialize the vertex array with position and color data
            verts(0).X = 150
            verts(0).Y = 50
            verts(0).Z = 0.5F
            verts(0).Rhw = 1
            verts(0).Color = System.Drawing.Color.Aqua.ToArgb()

            verts(1).X = 250
            verts(1).Y = 250
            verts(1).Z = 0.5F
            verts(1).Rhw = 1
            verts(1).Color = System.Drawing.Color.Brown.ToArgb()

            verts(2).X = 50
            verts(2).Y = 250
            verts(2).Z = 0.5F
            verts(2).Rhw = 1
            verts(2).Color = System.Drawing.Color.LightPink.ToArgb()

            ' write the vertices to the buffer
            stm.Write(verts)
            ' unlock the buffer
            vb.Unlock()
        End Sub

        ' All scene rendering for a frame occurs here
        Private Sub Render()
            If Not IsNothing(DeviceForm) Then
                'Clear the backbuffer to a blue color
                DeviceForm.Clear(ClearFlags.Target, _
                    System.Drawing.Color.Blue, 1.0F, 0)
                'Begin the scene
                DeviceForm.BeginScene()

                ' Set the stream from which to pull vertex data
                DeviceForm.SetStreamSource(0, VBuffer, 0)

                ' Draw 1 triangle
                DeviceForm.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
                
                'End the scene
                DeviceForm.EndScene()
                DeviceForm.Present()
            End If
        End Sub

        ' Prepare the rendering device
        Public Function InitializeGraphics() As Boolean
            Try
                ' Now let's setup our D3D parameters
                Dim PresentParm As PresentParameters = New PresentParameters
                PresentParm.Windowed = True
                PresentParm.SwapEffect = SwapEffect.Discard
                DeviceForm = New Device(0, DeviceType.Default, Me, _
                    CreateFlags.None, PresentParm)
                
                ' The device was just created so call our callback
                Me.OnCreateDevice(DeviceForm, Nothing)
            Catch
                Return False
            End Try
            Return True
        End Function

        ' Called whenever the window needs to repaint itself
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            
            'Render on painting
            Me.Render()

            'Render again by queuing a future paint message
            Me.Invalidate()
        End Sub
        
        ' Called when the window background needs to be repainted
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            ' Do nothing so that the rendered area is not overdrawn
        End Sub

        ' Handle any keys pressed on the keyboard
        Protected Overrides Sub OnKeyPress( _
            ByVal e As System.Windows.Forms.KeyPressEventArgs)
            
            ' Esc was pressed
            If Fix(System.Convert.ToByte(e.KeyChar)) = _
                Fix(System.Windows.Forms.Keys.Escape) Then
                Me.Close()
            End If
        End Sub

    End Class
End Namespace

