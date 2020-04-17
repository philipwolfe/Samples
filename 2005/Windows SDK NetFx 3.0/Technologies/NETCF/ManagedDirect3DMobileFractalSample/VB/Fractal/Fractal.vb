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

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D


Namespace Microsoft.Samples.MD3DM

    ' Main sample class that displays the demo
    Public Class MyGraphicsSample
        Inherits Form

        ' Font for drawing text
        Private drawingFont As _
            Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font = Nothing

        ' The d3d device
        Private device As Device = Nothing

        ' Fractal
        Private fracpatch As ElevationPoints = Nothing
        Private shape As Double = 0.5
        Private maxLevel As Integer = 6
        Private bufferSize As Integer = 0
        Private vert_size As Integer = 0
        Private indexX, indexY As Integer
        Private points(,) As Double
        Private fracScale As Double

        ' indices buffer
        Private indexBuffer As IndexBuffer = Nothing
        Private indices() As Short
        ' Vertexbuffer
        Private vertexBuffer As VertexBuffer = Nothing
        ' A helper tool for tracking and displaying fps
        Private fpsTimer As FpsTimerTool = Nothing

        ' Application constructor.
        Public Sub New()
            ' Set the window text
            Me.Text = "Fractal"

            Me.MinimizeBox = False

            ' Now let's setup our D3D parameters
            Dim presentParams As New PresentParameters()
            presentParams.Windowed = True
            presentParams.SwapEffect = SwapEffect.Discard
            presentParams.AutoDepthStencilFormat = DepthFormat.D16
            presentParams.EnableAutoDepthStencil = True
            device = New Device(0, DeviceType.Default, Me, _
                CreateFlags.None, presentParams)

            ' setup objects that can persist through device reset
            InitializeDeviceObjects()
            ' attach the the device reset handler
            AddHandler device.DeviceReset, AddressOf RestoreDeviceObjects
            ' setup objects that won't persist through device reset
            RestoreDeviceObjects(device, EventArgs.Empty)

        End Sub 'New


        ' Called once per frame, the call is the entry point for 
        ' animating the scene.
        Public Sub FrameMove()
            ' Setup the lights and materials
            SetupLights()
            ' Setup the world, view, and projection matrices
            SetupMatrices()
        End Sub ' FrameMove


        ' Called once per frame, the call is the entry point for 3d
        ' rendering. This function sets up render states, clears the
        ' viewport, and renders the scene.
        Public Sub Render()
            fpsTimer.StartFrame()

            ' Clear the backbuffer to a black color 
            device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, _
                Color.Black, 1.0F, 0)
            ' Begin the scene
            device.BeginScene()

            ' set the vertexbuffer stream source
            device.SetStreamSource(0, vertexBuffer, 0)
            ' set fill mode
            device.RenderState.FillMode = FillMode.Solid
            ' set the indices			
            device.Indices = indexBuffer
            ' use the indices buffer
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _
                bufferSize * bufferSize, 0, CType(vert_size / 3, Integer))

            ' Write instructions on the screen
            drawingFont.DrawText(Nothing, _
                "Tap screen to generate" + vblf + vbcr + "new fractal.", _
                New Point(2, 40), System.Drawing.Color.White)

            ' Output statistics
            fpsTimer.Render()
            device.EndScene()
            device.Present()
            fpsTimer.StopFrame()
        End Sub 'Render

        ' The device has been created.  Resources that are not lost on
        ' Reset() can be created here
        Public Sub InitializeDeviceObjects()

            Dim indexBufferPool As Pool
            Dim vertexBufferPool As Pool
            Dim caps As Caps

            drawingFont = _
                New Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font( _
                    device, _
                    New System.Drawing.Font("Arial", 12.0F, _
                    System.Drawing.FontStyle.Bold))
            fpsTimer = New FpsTimerTool(device)

            FractSetup()

            ' Get the device capabilities

            caps = device.DeviceCaps

            ' create the vertex buffer
            
            If (caps.SurfaceCaps.SupportsVidVertexBuffer) Then
                vertexBufferPool = Pool.VideoMemory
            Else
                vertexBufferPool = Pool.SystemMemory
            End If
            
            vertexBuffer = New VertexBuffer( _
                GetType(CustomVertex.PositionNormalColored), _
                bufferSize * bufferSize, device, Usage.WriteOnly, _
                CustomVertex.PositionNormalColored.Format, vertexBufferPool)
            AddHandler vertexBuffer.Created, _
                AddressOf Me.OnCreateVertexBuffer
            Me.OnCreateVertexBuffer(vertexBuffer, Nothing)

            ' create the indices buffer
            
            If (caps.SurfaceCaps.SupportsVidIndexBuffer) Then
                indexBufferPool = Pool.VideoMemory
            Else
                indexBufferPool = Pool.SystemMemory
            End If
            
            indexBuffer = New IndexBuffer(GetType(Short), vert_size, _
                device, Usage.WriteOnly, indexBufferPool)
            indices = New Short(vert_size - 1) {}
            AddHandler indexBuffer.Created, AddressOf Me.OnCreateIndexBuffer
            Me.OnCreateIndexBuffer(indexBuffer, Nothing)
        End Sub 'InitializeDeviceObjects

        ' The device exists, but may have just been Reset().  Resources
        ' and any other device state that persists during
        ' rendering should be set here.  Render states, matrices, textures,
        ' etc., that don't change during rendering can be set once here to
        ' avoid redundant state setting during Render() or FrameMove().
        Private Sub RestoreDeviceObjects(ByVal sender As System.Object, _
            ByVal e As System.EventArgs)
            ' Turn off culling, so we see the front and back of the triangle
            device.RenderState.CullMode = Cull.None
            ' Turn on the ZBuffer
            device.RenderState.ZBufferEnable = True
            ' make sure lighting is turned off
            device.RenderState.Lighting = False
        End Sub ' RestoreDeviceObjects

        ' Event Handler for windows messages
        Protected Overrides Sub OnClick( _
            ByVal e As EventArgs)
            FractSetup()
            OnCreateVertexBuffer(vertexBuffer, Nothing)
            OnCreateIndexBuffer(indexBuffer, Nothing)
        End Sub 'OnMouseClick

        ' Setup the matrices
        Private Sub SetupMatrices()
            ' move the object
            Dim temp As Matrix = Matrix.Translation( _
                -(bufferSize * 0.5F), 0, -(bufferSize * 0.5F))

            ' For our world matrix, we will just rotate the object about
            ' the indexY-axis.
            device.Transform.World = Matrix.Multiply(temp, _
                Matrix.RotationAxis(New Vector3(0, _
                System.Convert.ToSingle(Environment.TickCount) / 2150.0F, 0), _
                Environment.TickCount / 3000.0F))

            ' Set up our view matrix. A view matrix can be defined given
            ' an eye point, a point to lookat, and a direction for which
            ' way is up. Here, we set the eye five units back along the
            ' z-axis and up three units, look at the origin, and define
            ' "up" to be in the indexY-direction.
            device.Transform.View = Matrix.LookAtLH( _
                New Vector3(0.0F, 25.0F, -30.0F), _
                New Vector3(0.0F, 0.0F, 0.0F), _
                New Vector3(0.0F, 1.0F, 0.0F))

            ' For the projection matrix, we set up a perspective transform
            ' (which transforms geometry from 3D view space to 2D viewport
            ' space, with a perspective divide making objects smaller in the
            ' distance). To build a perpsective transform, we need the field
            ' of view (1/4 pi is common), the aspect ratio, and the near and
            ' far clipping planes (which define at what distances geometry
            ' should be no longer be rendered).
            device.Transform.Projection = Matrix.PerspectiveFovLH( _
                System.Convert.ToSingle(Math.PI) / 4.0F, 1.0F, 1.0F, 100.0F)
        End Sub 'SetupMatrices

        ' Setup the lights
        Private Sub SetupLights()
            Dim col As Color = Color.White
            ' Set up a material. The material here just has the diffuse and
            ' ambient colors set to yellow. Note that only one material can
            ' be used at a time.
            Dim mtrl As New Material()
            mtrl.Diffuse = col
            mtrl.Ambient = col
            device.Material = mtrl

            ' Set up a white, directional light, with an oscillating
            ' direction. Note that many lights may be active at a time
            ' (but each one slows down the rendering of our scene). However,
            ' here we are just using one. Also, we need to set the 
            ' D3DRS_LIGHTING renderstate to enable lighting
            device.Lights(0).Type = LightType.Directional
            device.Lights(0).Diffuse = Color.Purple
            device.Lights(0).Direction = New Vector3(0, 1.0F, 0)

            device.Lights(0).Update()
            device.Lights(0).Enabled = True

            ' Finally, turn on some ambient light.
            ' Ambient light is light that scatters and lights all objects
            ' evenly
            device.RenderState.Ambient = Color.Gray
        End Sub 'SetupLights

        ' Setup the fractal
        Public Sub FractSetup()
            ' create the fractal patch
            fracpatch = New ElevationPoints(maxLevel, False, 2.5, shape)
            fracpatch.CalcMidpointFM2D()

            bufferSize = CType(Fix(Math.Pow(2, maxLevel)) + 1, Integer)

            Dim max As Double = 0
            fracScale = 1.0
            points = fracpatch.GetHeights()

            ' clip points to >0 and find maximum to use for scaling
            For indexX = 0 To bufferSize - 1
                For indexY = 0 To bufferSize - 1
                    If points(indexX, indexY) < 0 Then
                        points(indexX, indexY) = 0
                    End If
                    If points(indexX, indexY) > max Then
                        max = points(indexX, indexY)
                    End If
                Next indexY
            Next indexX ' set the scaling factor
            fracScale = 12.0 / max
            vert_size = bufferSize * 6 * bufferSize
        End Sub 'FractSetup

        ' Handle the vertex creation event
        Private Sub OnCreateVertexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)
            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            ' Lock the buffer (which will return our structs)
            Dim verts As CustomVertex.PositionNormalColored() = _
                CType(vb.Lock(0, 0), CustomVertex.PositionNormalColored())

            For indexX = 0 To bufferSize - 1
                For indexY = 0 To bufferSize - 1
                    ' set the position and normal
                    verts((indexY + indexX * bufferSize)).X = indexX
                    verts((indexY + indexX * bufferSize)).Y = _
                        System.Convert.ToSingle(points(indexX, indexY))
                    verts((indexY + indexX * bufferSize)).Z = indexY
                    verts((indexY + indexX * bufferSize)).Nx = indexX
                    verts((indexY + indexX * bufferSize)).Ny = _
                        -System.Convert.ToSingle(points(indexX, indexY))
                    verts((indexY + indexX * bufferSize)).Nz = indexY

                    ' set the color of the vertices
                    If points(indexX, indexY) * fracScale = 0 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                        Color.Blue.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale > 0 And _
                        points(indexX, indexY) * fracScale < 1 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.MediumBlue.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale >= 1 And _
                        points(indexX, indexY) < 3 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.Green.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale >= 3 And _
                        points(indexX, indexY) < 5 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.DarkGreen.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale >= 5 And _
                        points(indexX, indexY) < 7 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.Gray.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale >= 7 And _
                        points(indexX, indexY) < 10 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.DarkGray.ToArgb()
                    End If
                    If points(indexX, indexY) * fracScale >= 10 And _
                        points(indexX, indexY) < 12 Then
                        verts((indexY + indexX * bufferSize)).Color = _
                            Color.White.ToArgb()
                    End If
                Next indexY
            Next indexX
            ' Unlock (and copy) the data
            vb.Unlock()
        End Sub ' OnCreateVertexBuffer

        ' Handle the index buffer creation event
        Private Sub OnCreateIndexBuffer(ByVal sender As Object, _
            ByVal e As EventArgs)

            Dim g As IndexBuffer = CType(sender, IndexBuffer)
            For indexY = 1 To (bufferSize - 1)
                For indexX = 1 To (bufferSize - 1)
                    ' Map each pair of traingles to a quad
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize))) _
                        = CType(Fix((indexY - 1) * _
                        bufferSize + (indexX - 1)), Short)
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize) _
                        + 1)) = CType(Fix((indexY - 0) * _
                        bufferSize + (indexX - 1)), Short)
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize) _
                        + 2)) = CType(Fix((indexY - 1) * _
                        bufferSize + (indexX - 0)), Short)
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize) _
                        + 3)) = CType(Fix((indexY - 1) * _
                        bufferSize + (indexX - 0)), Short)
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize) _
                        + 4)) = CType(Fix((indexY - 0) * _
                        bufferSize + (indexX - 1)), Short)
                    indices((6 * (indexX - 1 + (indexY - 1) * bufferSize) _
                        + 5)) = CType(Fix((indexY - 0) * _
                        bufferSize + (indexX - 0)), Short)
                Next indexX
            Next indexY
            g.SetData(indices, 0, 0)

        End Sub ' OnCreateIndexBuffer

        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs)
            Me.FrameMove()
            ' Render on painting
            Me.Render()
            ' Render again
            Me.Invalidate()
        End Sub ' OnPaint

        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs)

        End Sub ' OnPaintBackground

        ' The main entry point for the application.
        Shared Sub Main()

            Try

                Dim d3dApp As New MyGraphicsSample()
                Application.Run(d3dApp)

            Catch e As NotSupportedException
            
                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")

            Catch e As DriverUnsupportedException

                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")

            Catch e As Exception

                MessageBox.Show("The sample has run into an error and " + _
                             "needs to close: " + e.Message)

            End Try

        End Sub ' Main
    End Class ' MyGraphicsSample
End Namespace