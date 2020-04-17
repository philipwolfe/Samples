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
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D


Namespace Microsoft.Samples.MD3DM

    ' Custom D3D vertex format used by the vertex buffer
    Structure MyVertex
        Public p As Vector3 ' vertex position
        Public n As Vector3 ' vertex normal
        Public Shared Format As VertexFormats = VertexFormats.Position _
            Or VertexFormats.Normal
    End Structure 'MyVertex


    ' Main form that renders this sample
    Public Class LightingForm
        Inherits System.Windows.Forms.Form
        Private device As Device = Nothing
        ' Tessellated plane to serve as the walls and floor
        Private wallMesh As Mesh = Nothing
        ' Representation of point light
        Private sphereMesh As Mesh = Nothing
        ' Representation of dir/spot light
        Private coneMesh As Mesh = Nothing
        ' Description of the D3D light
        Private lightData As Light
        ' Number of vertices in the wall mesh along X
        Private numberVertsX As System.Int32 = 16
        ' Number of vertices in the wall mesh along Z         
        Private numberVertsZ As System.Int32 = 16
        ' Number of triangles in the wall mesh                  
        Private numberTriangles As Integer = 0
        ' the tick count when the app started rendering
        Private tickStart As Integer = 0
        ' the number of seconds since rendering started
        Private appTime As Single
        ' a helper to record and render fps statistics
        Private fpsTimer As FpsTimerTool
        

        ' Application constructor. Sets attributes for the app.
        Public Sub New() 
            ' the number of traingles in the wall mesh
            numberTriangles = Fix((numberVertsX - 1) * (numberVertsZ - 1) * 2)
            
            ' Set the window text
            Me.Text = "Lighting"
            
            ' Now let's setup our D3D stuff
            Dim presentParams As New PresentParameters()
            presentParams.Windowed = True
            presentParams.SwapEffect = SwapEffect.Discard
            presentParams.AutoDepthStencilFormat = DepthFormat.D16
            presentParams.EnableAutoDepthStencil = True
            device = New Device(0, DeviceType.Default, Me, CreateFlags.None, _
                presentParams)
            
            ' setup those objects which persist through reset
            InitializeDeviceObjects()
            ' attach the device reset handler
            AddHandler device.DeviceReset, AddressOf RestoreDeviceObjects
            ' setup any device resources that will not persist through reset
            RestoreDeviceObjects(device, EventArgs.Empty)
        
        End Sub 'New
         
        ' Called once per frame, the call is the entry point for animating the
        ' scene.
        Public Sub FrameMove() 
            lightData = device.Lights(2)
            ' Rotate through the various light types
            If Fix(appTime) Mod 20 < 10 Then
                device.Lights(2).Type = LightType.Point
            Else
                device.Lights(2).Type = LightType.Directional
            End If 
            ' Make sure the light type is supported by the device.  If 
            ' VertexProcessingCaps.PositionAllLights is not set, the device
            ' does not support point or spot lights, so change light #2's type
            ' to a directional light.
            If Not _
            device.DeviceCaps.VertexProcessingCaps.SupportsPositionalLights _
                Then
                If device.Lights(2).Type = LightType.Point Then
                    device.Lights(2).Type = LightType.Directional
                End If
            End If 
            ' Values for the light position, direction, and color
            Dim x As Single = System.Convert.ToSingle(Math.Sin(appTime * 2F))
            Dim y As Single = System.Convert.ToSingle( _
                Math.Sin(appTime * 2.246F))
            Dim z As Single = System.Convert.ToSingle( _
                Math.Sin(appTime * 2.64F))
            
            Dim r As Byte = System.Convert.ToByte((0.5F + 0.5F * x) * &HFF)
            Dim g As Byte = System.Convert.ToByte((0.5F + 0.5F * y) * &HFF)
            Dim b As Byte = System.Convert.ToByte((0.5F + 0.5F * z) * &HFF)
            device.Lights(2).Diffuse = System.Drawing.Color.FromArgb(r, g, b)
            device.Lights(2).Range = 100F
            
            Select Case device.Lights(2).Type
                Case LightType.Point
                    device.Lights(2).Position = _
                        New Vector3(4.5F * x, 4.5F * y, 4.5F * z)
                    device.Lights(2).Attenuation1 = 0.4F
                Case LightType.Directional
                    device.Lights(2).Direction = New Vector3(x, y, z)
            End Select
            device.Lights(2).Update()
        End Sub 'FrameMove
        
        ' Called once per frame, the call is the entry point for 3d rendering.
        ' This function sets up render states, clears the viewport, and renders
        ' the scene.
        Public Sub Render() 
            Dim matWorld As Matrix
            Dim matTrans As Matrix
            Dim matRotate As Matrix

            fpsTimer.StartFrame()

            ' Clear the viewport
            device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, &HFF, 1F, 0)
            
            device.BeginScene()
            
            ' Turn on light #0 and #2, and turn off light #1
            device.Lights(0).Enabled = True
            device.Lights(1).Enabled = False
            device.Lights(2).Enabled = True
            
            ' Draw the floor
            matTrans = Matrix.Translation(-5F, -5F, -5F)
            matRotate = Matrix.RotationZ(0F)
            matWorld = matRotate * matTrans
            device.SetTransform(TransformType.World, matWorld)
            wallMesh.DrawSubset(0)
            
            ' Draw the back wall
            matTrans = Matrix.Translation(5F, -5F, -5F)
            matRotate = Matrix.RotationZ(System.Convert.ToSingle(Math.PI) / 2)
            matWorld = matRotate * matTrans
            device.SetTransform(TransformType.World, matWorld)
            wallMesh.DrawSubset(0)
            
            ' Draw the side wall
            matTrans = Matrix.Translation(-5F, -5F, 5F)
            matRotate = Matrix.RotationX( _
                System.Convert.ToSingle(- Math.PI) / 2)
            matWorld = matRotate * matTrans
            device.SetTransform(TransformType.World, matWorld)
            wallMesh.DrawSubset(0)
            
            ' Turn on light #1, and turn off light #0 and #2
            device.Lights(0).Enabled = False
            device.Lights(1).Enabled = True
            device.Lights(2).Enabled = False
            
            ' Draw the mesh representing the light
            If lightData.Type = LightType.Point Then
                ' Just position the point light -- no need to orient it
                matWorld = Matrix.Translation(lightData.Position.X, _
                    lightData.Position.Y, lightData.Position.Z)
                device.SetTransform(TransformType.World, matWorld)
                sphereMesh.DrawSubset(0)
            Else
                ' Position the light and point it in the light's direction
                Dim vecFrom As New Vector3(lightData.Position.X, _
                    lightData.Position.Y, lightData.Position.Z)
                Dim vecAt As New Vector3( _
                    lightData.Position.X + lightData.Direction.X, _
                    lightData.Position.Y + lightData.Direction.Y, _
                    lightData.Position.Z + lightData.Direction.Z)
                Dim vecUp As New Vector3(0, 1, 0)
                Dim matWorldInv As Matrix
                matWorldInv = Matrix.LookAtLH(vecFrom, vecAt, vecUp)
                matWorld = Matrix.Invert(matWorldInv)
                device.SetTransform(TransformType.World, matWorld)
                coneMesh.DrawSubset(0)
            End If
            
            ' Output statistics
            fpsTimer.Render()

            device.EndScene()
            device.Present()
            fpsTimer.StopFrame()    
        End Sub 'Render
        
        ' The device has been created.  Resources that are not lost on
        ' Reset() can be created here.
        Public Sub InitializeDeviceObjects() 
            fpsTimer = new FpsTimerTool(device)
        End Sub 'InitializeDeviceObjects
        
        ' The device exists, but may have just been Reset().  Resources
        ' and any other device state that persists during
        ' rendering should be set here.  Render states, matrices, textures,
        ' etc., that don't change during rendering can be set once here to
        ' avoid redundant state setting during Render() or FrameMove().
        Private Sub RestoreDeviceObjects(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) 
            Dim v() As MyVertex
            Dim pWallMeshTemp As Mesh
            
            ' Create a square grid numberVertsX*numberVertsZ for rendering the wall
            pWallMeshTemp = New Mesh(numberTriangles, numberTriangles * 3, _
                0, MyVertex.Format, device)
            
            ' Fill in the grid vertex data
            v = CType(pWallMeshTemp.VertexBuffer.Lock(0, _
                GetType(MyVertex), 0, numberTriangles * 3), MyVertex())
            Dim dX As Single = 1F / (numberVertsX - 1)
            Dim dZ As Single = 1F / (numberVertsZ - 1)
            Dim k As System.Int32 = 0
            Dim z As System.Int32
            For z = 0 To (numberVertsZ - 2)
                Dim x As System.Int32
                For x = 0 To (numberVertsX - 2)
                    v(k).p = New Vector3(10 * x * dX, 0F, 10 * z * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                    v(k).p = New Vector3(10 * x * dX, 0F, 10 *(z + 1) * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                    v(k).p = New Vector3(10 *(x + 1) * dX, 0F, _
                        10 *(z + 1) * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                    v(k).p = New Vector3(10 * x * dX, 0F, 10 * z * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                    v(k).p = New Vector3(10 *(x + 1) * dX, 0F, _
                        10 *(z + 1) * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                    v(k).p = New Vector3(10 *(x + 1) * dX, 0F, 10 * z * dZ)
                    v(k).n = New Vector3(0F, 1F, 0F)
                    k += 1
                Next x
            Next z
            pWallMeshTemp.VertexBuffer.Unlock()
            
            ' Fill in index data
            Dim pIndex() As System.Int16
            pIndex = CType(pWallMeshTemp.IndexBuffer.Lock(0, _
                GetType(System.Int16), 0, numberTriangles * 3), System.Int16())
            Dim iIndex As System.Int16
            For iIndex = 0 To CType((numberTriangles * 3)-1, Short)
                pIndex(iIndex) = iIndex
            Next iIndex
            pWallMeshTemp.IndexBuffer.Unlock()
            
            ' Eliminate redundant vertices
            Dim pdwAdjacency(3 * numberTriangles) As Integer
            pWallMeshTemp.GenerateAdjacency(0.01F, pdwAdjacency)
            
            ' Optimize the mesh
            wallMesh = pWallMeshTemp.Optimize(MeshFlags.OptimizeCompact Or _
                MeshFlags.OptimizeVertexCache Or MeshFlags.VbDynamic Or _
                MeshFlags.VbWriteOnly, pdwAdjacency)
            
            pWallMeshTemp = Nothing
            pdwAdjacency = Nothing
            
            ' Create sphere and cone meshes to represent the lights
            sphereMesh = Mesh.Sphere(device, 0.25F, 8, 8)
            coneMesh = Mesh.Cylinder(device, 0F, 0.25F, 0.5F, 8, 8)
            
            ' Set up a material
            Dim mtrl As Material = New Material()
            mtrl.Ambient = System.Drawing.Color.White
            mtrl.Diffuse = System.Drawing.Color.White
            device.Material = mtrl
            
            ' Set miscellaneous render states
            device.RenderState.DitherEnable = False
            device.RenderState.SpecularEnable = False
            
            device.TextureState(0).ColorOperation = TextureOperation.Disable
            device.TextureState(0).AlphaOperation = TextureOperation.Disable
            
            ' Set the world matrix
            Dim matIdentity As Matrix = Matrix.Identity
            device.SetTransform(TransformType.World, matIdentity)
            
            ' Set the view matrix.
            Dim matView As Matrix
            Dim vFromPt As New Vector3(- 10, 10, - 10)
            Dim vLookatPt As New Vector3(0F, 0F, 0F)
            Dim vUpVec As New Vector3(0F, 1F, 0F)
            matView = Matrix.LookAtLH(vFromPt, vLookatPt, vUpVec)
            device.SetTransform(TransformType.View, matView)
            
            ' Set the projection matrix
            Dim matProj As Matrix
            Dim fAspect As Single = System.Convert.ToSingle( _
                device.PresentationParameters.BackBufferWidth) / _
                device.PresentationParameters.BackBufferHeight
            matProj = Matrix.PerspectiveFovLH( _
                System.Convert.ToSingle(Math.PI) / 4, fAspect, 1F, 100F)
            device.SetTransform(TransformType.Projection, matProj)
            
            ' Turn on lighting.
            device.RenderState.Lighting = True
            
            ' Enable ambient lighting to a dim, grey light, so objects that
            ' are not lit by the other lights are not completely black
            device.RenderState.Ambient = System.Drawing.Color.Gray
            
            ' Set light #0 to be a simple, faint grey directional light so 
            ' the walls and floor are slightly different shades of grey
            device.Lights(0).Type = LightType.Directional
            device.Lights(0).Direction = New Vector3(0.3F, - 0.5F, 0.2F)
            device.Lights(0).Diffuse = System.Drawing.Color.FromArgb(64, _
                64, 64)
            device.Lights(0).Update()
            
            ' Set light #1 to be a simple, bright directional light to use 
            ' on the mesh representing light #2
            device.Lights(1).Type = LightType.Directional
            device.Lights(1).Direction = New Vector3(0.5F, - 0.5F, 0.5F)
            device.Lights(1).Diffuse = System.Drawing.Color.Blue
            device.Lights(1).Update()
        
        End Sub 'RestoreDeviceObjects
         
        ' Light #2 will be the light used to light the floor and walls.
        ' It will be set up in FrameMove() since it changes every frame.
        
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
            If tickStart = 0 Then
                tickStart = Environment.TickCount - 1
            End If
            
            appTime = _
                System.Convert.ToSingle(Environment.TickCount _
                - tickStart) / 1000F
            Me.FrameMove()
            Me.Render() ' Render on painting
            Me.Invalidate()
        ' Render again
        End Sub 'OnPaint
        
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
        End Sub 'OnPaintBackground
        
        
        ' The main entry point for the application.
        Shared Sub Main() 

            Try
            
                Dim d3dApp As New LightingForm()
                System.Windows.Forms.Application.Run(d3dApp)
            
            Catch e As NotSupportedException
            
                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")

            Catch e As DriverUnsupportedException
            
                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")
            Catch e As Exception

                MessageBox.Show("The sample has run into an error and" + _
                    " needs to close: " + e.Message)
            
            End Try    

        End Sub 'Main
    End Class
End Namespace