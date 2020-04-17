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
' File: Matrices.vb
'
' Desc: Now that we know how to create a device and render some 2D vertices,
'       this tutorial goes the next step and renders 3D geometry. To deal with
'       3D geometry we need to introduce the use of 4x4 matrices to transform
'       the geometry with translations, rotations, scaling, and setting up our
'       camera.
'
'       Geometry is defined in model space. We can move it (translation),
'       rotate it (rotation), or stretch it (scaling) imports a world
'       transform. The geometry is then said to be in world space. Next, we
'       need to position the camera, or eye point, somewhere to look at the
'       geometry. Another transform, via the view matrix, is used, to position
'       and rotate our view. With the geometry then in view space, our last
'       transform is the projection transform, which "projects" the 3D scene
'       into our 2D viewport.
'
'       Note that in this tutorial, we are introducing the use of D3DX, which
'       is a set of helper utilities for D3D. In this case, we are imports
'       some of D3DX's useful matrix initialization functions. To use D3DX,
'       simply include the D3DX reference in your project
'
'-----------------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D

Namespace Microsoft.Samples.MD3DM

    ' The application entry point
    Module MatricesMain
        Sub Main()

            Dim matrixForm As Matrices = New Matrices

            ' Initialize Direct3D
            If Not matrixForm.InitializeGraphics() Then 

                MessageBox.Show("Could not initialize Direct3D. " + _
                    "This tutorial will exit.")
                Return
            End If

            System.Windows.Forms.Application.Run(matrixForm)

        End Sub
    End Module

    ' The main class for this sample
    Public Class Matrices
        Inherits Form
        ' Our global variables for this project
        ' The rendering device
        Dim DeviceForm As Device = Nothing
        Dim VBuffer As VertexBuffer = Nothing
        Dim PParameters As PresentParameters = New PresentParameters()

        Public Sub New()
            ' Set the caption
            Me.Text = "Direct3D Tutorial 3 - Matrices"
            
            ' We want an Ok button
            Me.MinimizeBox = False
        End Sub

        ' Prepare the rendering device
        Public Function InitializeGraphics() As Boolean
            Try

                ' Now let's setup our D3D parameters
                PParameters.Windowed = True
                PParameters.SwapEffect = SwapEffect.Discard
                DeviceForm = New Device(0, DeviceType.Default, Me, _
                    CreateFlags.None, PParameters)
                AddHandler DeviceForm.DeviceReset, _
                    AddressOf Me.OnResetDevice

                Me.OnCreateDevice(DeviceForm, Nothing)
                Me.OnResetDevice(DeviceForm, Nothing)
                Return True

            Catch e As DirectXException
                Return False
            End Try

        End Function

        ' Called whenever the device is created (or recreated)
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
            
            ' Now Create the VB
            VBuffer = New VertexBuffer( _
                GetType(CustomVertex.PositionColored), 3, dev, 0, _
                CustomVertex.PositionColored.Format, vertexBufferPool)
            AddHandler VBuffer.Created, AddressOf Me.OnCreateVertexBuffer
            Me.OnCreateVertexBuffer(VBuffer, Nothing)

        End Sub

        ' Called whenever the device is reset
        Private Sub OnResetDevice(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim dev As Device = CType(sender, Device)
            ' Turn off culling, so we see the front and back of the triangle
            dev.RenderState.CullMode = Cull.None
            ' Turn off D3D lighting, since we are providing our own vertex
            ' colors
            dev.RenderState.Lighting = False
        End Sub

        ' Called whenever the vertex buffer is created (or recreated)
        Private Sub OnCreateVertexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            Dim verts() As CustomVertex.PositionColored = _
                CType(vb.Lock(0, 0), CustomVertex.PositionColored())


            verts(0).X = -1.0F
            verts(0).Y = -1.0F
            verts(0).Z = 0.0F
            verts(0).Color = System.Drawing.Color.DarkGoldenrod.ToArgb()

            verts(1).X = 1.0F
            verts(1).Y = -1.0F
            verts(1).Z = 0.0F
            verts(1).Color = System.Drawing.Color.MediumOrchid.ToArgb()

            verts(2).X = 0.0F
            verts(2).Y = 1.0F
            verts(2).Z = 0.0F
            verts(2).Color = System.Drawing.Color.Cornsilk.ToArgb()
            vb.Unlock()

        End Sub

        ' All rendering for a frame occurs here
        Private Sub Render()

            If Not IsNothing(DeviceForm) Then

                'Clear the backbuffer to a blue color
                DeviceForm.Clear(ClearFlags.Target, _
                    System.Drawing.Color.Blue, 1.0F, 0)
                'Begin the scene
                DeviceForm.BeginScene()
                ' Setup the world, view, and projection matrices
                SetupMatrices()

                DeviceForm.SetStreamSource(0, VBuffer, 0)
                DeviceForm.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
                'End the scene
                DeviceForm.EndScene()
                DeviceForm.Present()
            Else
                'DeviceForm is has not been set
            End If
        End Sub

        ' Sets the world view and projection matrices each frame
        Private Sub SetupMatrices()

            ' For our world matrix, we will just rotate the object about
            ' the y-axis. Set up the rotation matrix to generate 1 full
            ' rotation (2*PI radians) every 1000 ms. To avoid the loss
            ' of precision inherent in very high floating point numbers,
            ' the system time is modulated by the rotation period before
            ' conversion to a radian angle.
            Dim iTime As Int32 = Environment.TickCount And 1000
            Dim fAngle As Single
            fAngle = iTime * (2.0F * CSng(Math.PI) / 1000)

            DeviceForm.Transform.World = Matrix.RotationY(fAngle)

            ' Set up our view matrix. A view matrix can be defined given
            ' an eye point, a point to lookat, and a direction for which
            ' way is up. Here, we set the eye five units back along the
            ' z-axis and up three units, look at the origin, and define
            ' "up" to be in the y-direction.
            DeviceForm.Transform.View = Matrix.LookAtLH( _
                New Vector3(0.0F, 3.0F, -5.0F), _
                New Vector3(0.0F, 0.0F, 0.0F), _
                New Vector3(0.0F, 1.0F, 0.0F))

            ' For the projection matrix, we set up a perspective transform
            ' (which transforms geometry from 3D view space to 2D viewport
            ' space, with a perspective divide making objects smaller in the
            ' distance). To build a perpsective transform, we need the field
            ' of view (1/4 pi is common), the aspect ratio, and the near and
            ' far clipping planes (which define at what distances geometry
            ' should be no longer be rendered).
            DeviceForm.Transform.Projection = Matrix.PerspectiveFovLH( _
                CSng(Math.PI) / 4, 1.0F, 1.0F, 100.0F)
        End Sub

        ' Called when the window needs to be repainted
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            
            ' Render on painting
            Me.Render()
            
             ' Render again
            Me.Invalidate()
        End Sub

        ' Called when the window background needs to be repainted
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            ' Don't paint the background
        End Sub

        ' Called to handle and keyboard keys which have been pressed
        Protected Overrides Sub OnKeyPress( _
            ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Fix(System.Convert.ToByte(e.KeyChar)) = _
                Fix(System.Windows.Forms.Keys.Escape) Then
                ' Esc was pressed
                Me.Dispose()
            End If
        End Sub

    End Class
End Namespace