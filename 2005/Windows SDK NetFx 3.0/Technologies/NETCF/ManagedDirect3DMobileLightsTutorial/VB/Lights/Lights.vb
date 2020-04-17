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
' File: Lights.vb
'
' Desc: Rendering 3D geometry is much more interesting when dynamic lighting
'       is added to the scene. To use lighting in D3D, you must create one or
'       more lights, setup a material, and make sure your geometry contains
'       surface normals. Lights may have a position, a color, and be of a
'       certain type such as directional (light comes from one direction),
'       point (light comes from a specific x,y,z coordinate and radiates in
'       all directions) or spotlight. Materials describe the surface of your
'       geometry, specifically, how it gets lit (diffuse color, ambient color,
'       etc.). Surface normals are part of a vertex, and are needed for the
'       D3D's internal lighting calculations.
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
    Module LightsMain
        Sub Main()
            Dim lightForm As Lights = New Lights

            ' Initialize Direct3D
            If Not lightForm.InitializeGraphics() Then

                MessageBox.Show("Could not initialize Direct3D. This" + _
                    " tutorial will exit.")
                Return
            End If

            System.Windows.Forms.Application.Run(lightForm)
        End Sub
    End Module

    ' The main class for this sample
    Public Class Lights
        Inherits Form
        ' Our global variables for me project
        Dim DeviceForm As Device = Nothing
        Dim VBuffer As VertexBuffer = Nothing
        Dim PParameters As New PresentParameters

        ' Application constructor
        Public Sub New()
            ' Set the caption
            Me.Text = "Direct3D Tutorial 4 - Lights"
            
            ' We want an Ok button
            Me.MinimizeBox = False
        End Sub

        ' Setup the rendering device
        Public Function InitializeGraphics() As Boolean
            Try
                ' We don't want to run fullscreen
                PParameters.Windowed = True 
                ' Discard the frames
                PParameters.SwapEffect = SwapEffect.Discard 
                ' Turn on a Depth stencil
                PParameters.EnableAutoDepthStencil = True 
                ' And the stencil format
                PParameters.AutoDepthStencilFormat = DepthFormat.D16 
                'Create a DeviceForm
                DeviceForm = New Device(0, DeviceType.Default, Me, _
                    CreateFlags.None, PParameters)

                AddHandler DeviceForm.DeviceReset, AddressOf Me.OnResetDevice
                Me.OnCreateDevice(DeviceForm, Nothing)
                Me.OnResetDevice(DeviceForm, Nothing)
            Catch
                ' Catch any errors and return a failure
                Return False
            End Try
            
            Return True
        End Function

        ' Called whenever the device is created
        Private Sub OnCreateDevice(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim Dev As Device = CType(Sender, Device)
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

            VBuffer = New VertexBuffer(GetType(CustomVertex.PositionNormal), _
                100, dev, Usage.WriteOnly, _
                CustomVertex.PositionNormal.Format, vertexBufferPool)

            AddHandler VBuffer.Created, AddressOf Me.OnCreateVertexBuffer
            Me.OnCreateVertexBuffer(VBuffer, Nothing)
        End Sub

        'Called whenever the device is reset
        Private Sub OnResetDevice(ByVal sender As Object, _
            ByVal e As EventArgs)
            Dim dev As Device = CType(sender, Device)
            ' Turn off culling, so we see the front and back of the triangle
            DeviceForm.RenderState.CullMode = Cull.None
            ' Turn on the ZBuffer
            DeviceForm.RenderState.ZBufferEnable = True
            'make sure lighting is enabled
            DeviceForm.RenderState.Lighting = True    
        End Sub

        ' Fills a vertex buffer with vertex data to make a cylinder
        Private Sub OnCreateVertexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            ' Create a vertex buffer (100 customervertex)
            Dim verts() As CustomVertex.PositionNormal = _
                CType(vb.Lock(0, 0), CustomVertex.PositionNormal()) 
            Dim i As Int32

            For i = 0 To 49

                ' Fill up our structs
                Dim theta As Single = CSng((2 * Math.PI * i)) / 49
                verts(2 * i).X = CSng(Math.Sin(theta))
                verts(2 * i).Y = -1
                verts(2 * i).Z = CSng(Math.Cos(theta))
                verts(2 * i).Nx = CSng(Math.Sin(theta))
                verts(2 * i).Ny = 0
                verts(2 * i).Nz = CSng(Math.Cos(theta))
                verts(2 * i + 1).X = CSng(Math.Sin(theta))
                verts(2 * i + 1).Y = 1
                verts(2 * i + 1).Z = CSng(Math.Cos(theta))
                verts(2 * i + 1).Nx = CSng(Math.Sin(theta))
                verts(2 * i + 1).Ny = 0
                verts(2 * i + 1).Nz = CSng(Math.Cos(theta))
            Next i
            ' Unlock (and copy) the data
            vb.Unlock()
        End Sub

        ' Sets the world, view, and perspective matrices for each frame
        Private Sub SetupMatrices()
            DeviceForm.Transform.World = _
                Matrix.RotationAxis( _
                New Vector3(CSng(Math.Cos(Environment.TickCount / 250.0F)), _
                1, CSng(Math.Sin(Environment.TickCount / 250.0F))), _
                Environment.TickCount / 3000.0F)

            ' Set up our view matrix. A view matrix can be defined given an
            ' eye point, a point to lookat, and a direction for which way is
            ' up. Here, we set the eye five units back along the z-axis and
            ' up three units, look at the origin, and define "up" to be in
            ' the y-direction.
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
                CSng(Math.PI) / 4.0F, 1.0F, 1.0F, 100.0F)
        End Sub

        'Prepares the lights for each frame
        Private Sub SetupLights()

            Dim col As System.Drawing.Color = System.Drawing.Color.White
            'Set up a material. The material here just has the diffuse _
            'and ambient colors set to yellow. Note that only one material _
            'can be used at a time.
            Dim mtrl As New Direct3D.Material
            mtrl.Diffuse = col
            mtrl.Ambient = col
            DeviceForm.Material = mtrl

            'Set up a white, directional light, with an oscillating direction.
            'Note that many lights may be active at a time (but each one _
            'slows down the rendering of our scene). However, here we are _
            'just imports one. Also, we need to set the D3DRS_LIGHTING _
            'renderstate to enable lighting

            DeviceForm.Lights(0).Type = LightType.Directional
            DeviceForm.Lights(0).Diffuse = System.Drawing.Color.DarkTurquoise
            DeviceForm.Lights(0).Direction = _
                New Vector3(CSng(Math.Cos(Environment.TickCount / 250.0F)), _
                1.0F, CSng(Math.Sin(Environment.TickCount / 250.0F)))

            'turn it on
            DeviceForm.Lights(0).Enabled = True 

            'Finally, turn on some ambient light.
            'Ambient light is light that scatters and lights all objects
            'evenly
            DeviceForm.RenderState.Ambient = _
                System.Drawing.Color.FromArgb(&H202020)
        End Sub

        'All rendering for each frame occurs here
        Private Sub Render()
            If Not IsNothing(DeviceForm) Then
                'Clear the backbuffer to a blue color
                DeviceForm.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, _
                    System.Drawing.Color.Blue, 1.0F, 0)
                'Begin the scene
                DeviceForm.BeginScene()
                ' Setup the lights and materials
                SetupLights()
                ' Setup the world, view, and projection matrices
                SetupMatrices()

                DeviceForm.SetStreamSource(0, VBuffer, 0)
                ' The number of triangles in a triangle-strip is
                ' numberVertices-2
                DeviceForm.DrawPrimitives(PrimitiveType.TriangleStrip, _
                 0, 100 - 2)
                'End the scene
                DeviceForm.EndScene()
                ' Update the screen
                DeviceForm.Present()
            Else
                'DeviceForm is has not been set
            End If
        End Sub

        'Called when a window needs to be repainted
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs)

            ' Render on painting
            Me.Render()

             ' Render again
            Me.Invalidate()
        End Sub

        'Called when the window background needs to be repainted
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            ' Don't paint the background
        End Sub

        'Handles any keyboard keys which have been pressed
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