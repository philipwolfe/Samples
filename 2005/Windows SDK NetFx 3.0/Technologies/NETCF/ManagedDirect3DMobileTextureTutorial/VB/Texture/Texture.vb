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
' File: Texture.vb
'
' Desc: Better than just lights and materials, 3D objects look much more
'       convincing when TextureImage-mapped. Textures can be thought of as a
'       sort of wallpaper, that is shrinkwrapped to fit a TextureImage.
'       Textures are typically loaded from image files, and D3DX provides a
'       utility to function to do me for us. Like a vertex buffer, 
'       D3DTextures have Lock() and Unlock() functions to access (read or
'       write) the image data. Textures have a width, height, miplevel,
'       and pixel format. The  miplevel is for "mipmapped" D3DTextures, an
'       advanced performance-enhancing feature which uses lower resolutions of
'       the TextureImage for objects in the distance where detail is less
'       noticeable. The pixel format determines how the colors are stored in
'       a texel. The most common formats are the 16-bit R5G6B5 format (5 bits
'       of red, 6-bits of green and 5 bits of blue) and the 32-bit A8R8G8B8
'       format (8 bits each of alpha, red, green, and blue).
'
'       Textures are associated with geometry through TextureImage
'       coordinates. Each vertex has one or more sets of TextureImage
'       coordinates, which are named tu and tv and range from 0.0 to 1.0.
'       Texture coordinates can be supplied by the geometry, or can be
'       automatically generated imports Direct3D TextureImage coordinate
'       generation (which is an advanced feature).
'-----------------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D

Namespace Microsoft.Samples.MD3DM

    ' The application entry point
    Module TextureMain
        Sub Main()
            Dim frm As New Textures
             ' Initialize Direct3D
            If Not frm.InitializeGraphics() Then
                MessageBox.Show("Could not initialize Direct3D. This " + _
                    " tutorial will exit.")
                Return
            Else
                Application.Run(frm)
            End If
        End Sub
    End Module

    ' The main class for this sample
    Public Class Textures
        Inherits Form
        ' Our global variables for me project
        Dim DeviceForm As Device = Nothing ' Our rendering DeviceForm
        Dim VBuffer As VertexBuffer = Nothing
        Dim TextureImage As Texture = Nothing
        Dim PParameters As PresentParameters = New PresentParameters()

        Public Sub New()

            ' Set the caption
            Me.Text = "Direct3D Tutorial 5 - Textures"
            
            ' We want an Ok button
            Me.MinimizeBox = False
        End Sub

        ' Prepares the rendering device
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
                ' Create a DeviceForm
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

        ' Called whenever the device is created (or recreated)
        Private Sub OnCreateDevice( _
            ByVal sender As Object, ByVal e As EventArgs)
            
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
                GetType(CustomVertex.PositionNormalTextured), 100, dev, _
                Usage.WriteOnly, CustomVertex.PositionNormalTextured.Format, _
                vertexBufferPool)
            AddHandler VBuffer.Created, AddressOf Me.OnCreateVertexBuffer
            Me.OnCreateVertexBuffer(VBuffer, Nothing)
        End Sub

        ' Called whenever the device is reset
        Private Sub OnResetDevice(ByVal sender As Object, ByVal e As EventArgs)
            Dim dev As Device = CType(sender, Device)
            ' Turn off culling, so we see the front and back of the triangle
            dev.RenderState.CullMode = Cull.None
            ' Turn off D3D lighting
            dev.RenderState.Lighting = False
            ' Turn on the ZBuffer
            dev.RenderState.ZBufferEnable = True
            ' Turn on perspective correction for textures
            ' This provides a more accurate visual at the cost
            ' of a small performance overhead
            dev.RenderState.TexturePerspective = True
            ' Now create our TextureImage
            TextureImage = TextureLoader.FromStream(dev, _
                Assembly.GetExecutingAssembly().GetManifestResourceStream( _
                "Textures.Banana.bmp"))
        End Sub

        ' Called whenever the vertex buffer is created (or recreated)
        Private Sub OnCreateVertexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)
            Dim i As Int16
            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            ' Create a vertex buffer (100 customervertex)
            Dim verts() As CustomVertex.PositionNormalTextured = _
                CType(vb.Lock(0, 0), CustomVertex.PositionNormalTextured())
            For i = 0 To 49

                ' Fill up our structs
                Dim theta As Single = CSng(2 * Math.PI * i) / 49
                verts(2 * i).X = CSng(Math.Sin(theta))
                verts(2 * i).Y = -1
                verts(2 * i).Z = CSng(Math.Cos(theta))
                verts(2 * i).Nx = CSng(Math.Sin(theta))
                verts(2 * i).Ny = 0
                verts(2 * i).Nz = CSng(Math.Cos(theta))
                verts(2 * i).Tu = CSng(i) / (50 - 1)
                verts(2 * i).Tv = 1.0F
                verts(2 * i + 1).X = CSng(Math.Sin(theta))
                verts(2 * i + 1).Y = 1
                verts(2 * i + 1).Z = CSng(Math.Cos(theta))
                verts(2 * i + 1).Nx = CSng(Math.Sin(theta))
                verts(2 * i + 1).Ny = 0
                verts(2 * i + 1).Nz = CSng(Math.Cos(theta))
                verts(2 * i + 1).Tu = CSng(i) / (50 - 1)
                verts(2 * i + 1).Tv = 0.0F
            Next i
            ' Unlock (and copy) the data
            vb.Unlock()
        End Sub

        ' Called to set the world, view, and projection matrices each frame
        Private Sub SetupMatrices()
            ' For our world matrix, we will just rotate the object 
            ' about the y-axis.
            DeviceForm.Transform.World = Matrix.RotationAxis( _
                New Vector3(CSng(Math.Cos(Environment.TickCount / 250.0F)), _
                1, CSng(Math.Sin(Environment.TickCount / 250.0F))), _
                Environment.TickCount / 1000.0F)

            ' Set up our view matrix. A view matrix can be defined given an
            ' eye point, a point to look at, and a direction for which way is
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

        ' All rendering for each frame occurs here
        Private Sub Render()
            If Not IsNothing(DeviceForm) Then
                'Clear the backbuffer to a blue color
                DeviceForm.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, _
                    System.Drawing.Color.Blue, 1.0F, 0)
                'Begin the scene
                DeviceForm.BeginScene()
                ' Setup the world, view, and projection matrices
                SetupMatrices()
                ' Setup our TextureImage. Using D3DTextures introduces the 
                ' TextureImage stage states, which govern how D3DTextures get
                ' blended together (in the case of multiple D3DTextures) and
                ' lighting information. In me case, we are modulating 
                ' (blending) our TextureImage with the diffuse color of the
                ' vertices.
                DeviceForm.SetTexture(0, TextureImage)
                DeviceForm.TextureState(0).ColorOperation = _
                    TextureOperation.Modulate
                DeviceForm.TextureState(0).ColorArgument1 = _
                    TextureArgument.TextureColor
                DeviceForm.TextureState(0).ColorArgument2 = _
                    TextureArgument.Diffuse
                DeviceForm.TextureState(0).AlphaOperation = _
                    TextureOperation.Disable

                DeviceForm.SetStreamSource(0, VBuffer, 0)
                DeviceForm.DrawPrimitives(PrimitiveType.TriangleStrip, 0, _
                    (4 * 25) - 2)
                'End the scene
                DeviceForm.EndScene()
                ' Update the screen
                DeviceForm.Present()
            End If
        End Sub

        'Called when the window needs to be repainted
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

        'Called to handle any keyboard keys which have been pressed
        Protected Overrides Sub OnKeyPress( _
            ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Fix(System.Convert.ToByte(e.KeyChar)) = _
            Fix(System.Windows.Forms.Keys.Escape) Then
                ' Esc was pressed
                Me.Close() 
            End If
        End Sub

    End Class
End Namespace
