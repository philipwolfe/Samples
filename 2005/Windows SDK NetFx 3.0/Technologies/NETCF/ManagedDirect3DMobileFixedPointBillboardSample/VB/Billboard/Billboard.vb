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
' File: Billboard.vb
'
' Desc: Example code showing how to do billboarding. The sample uses
'       billboarding to draw some trees.
'
'       Note: This implementation is for billboards that are fixed to rotate
'       about the Y-axis, which is good for things like trees. For
'       unconstrained billboards, like explosions in a flight sim, the
'       technique is the same, but the the billboards are positioned slightly
'       differently. Try using the inverse of the view matrix, TL-vertices, or
'       some other technique.
'
'       Note: This code uses the D3D Framework helper library.
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'-----------------------------------------------------------------------------
Imports System
Imports System.Windows.Forms
Imports System.Reflection
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D

Namespace Microsoft.Samples.MD3DM

    ' Simple class to hold data for rendering a tree
Public Class Tree
    ' Four corners of billboard quad
    Private corners() As CustomVertex.PositionColoredTextured = _
        New CustomVertex.PositionColoredTextured(3) {}
    
    Public Property V0() As CustomVertex.PositionColoredTextured 
        Get
            Return corners(0)
        End Get
        Set
            corners(0) = value
        End Set
    End Property 
    
    Public Property V1() As CustomVertex.PositionColoredTextured 
        Get
            Return corners(1)
        End Get
        Set
            corners(1) = value
        End Set
    End Property 
    
    Public Property V2() As CustomVertex.PositionColoredTextured 
        Get
            Return corners(2)
        End Get
        Set
            corners(2) = value
        End Set
    End Property 
    
    Public Property V3() As CustomVertex.PositionColoredTextured 
        Get
            Return corners(3)
        End Get
        Set
            corners(3) = value
        End Set
    End Property 
    ' Origin of tree
    Private positionValue As Vector3Fixed
    
    Public Property Position() As Vector3Fixed 
        Get
            Return positionValue
        End Get
        Set
            positionValue = value
        End Set
    End Property 
    ' Which texture map to use
    Private treeTextureIndexValue As Integer
    
    Public Property TreeTextureIndex() As Integer 
        Get
            Return treeTextureIndexValue
        End Get
        Set
            treeTextureIndexValue = value
        End Set
    End Property 
    ' Offset into vertex buffer of tree's vertices
    Private offsetIndexValue As Integer
    
    Public Property OffsetIndex() As Integer 
        Get
            Return offsetIndexValue
        End Get
        Set
            offsetIndexValue = value
        End Set
    End Property
End Class 'Tree 


    ' The main form class which renders this demo
    Public Class BillboardForm
        Inherits System.Windows.Forms.Form
        ' the number of trees distributed on the terrain
        Private Const numberTrees As Integer = 75
        
        ' the direction the camera is facing
        Public Shared GlobalDirection As Vector3Fixed
        
        ' Tree textures to use
        Private Shared treeTextureFileNames() As String = {"tree01S.png"}
        
        ' mesh objects for terrain and skybox
        Private terrainMesh As GraphicsMesh = Nothing
        Private skyBoxMesh As GraphicsMesh = Nothing
        
        ' Vertex buffer for rendering a tree
        Private treeVertexBuffer As VertexBuffer = Nothing
        ' Tree images
        Private treeTextures(treeTextureFileNames.Length) As Texture
        ' Used for billboard orientation
        Private billboardMatrix As MatrixFixed
        ' Array of tree info
        Private trees As New System.Collections.ArrayList()
        
        ' Vectors defining the camera
        Private eyePart As New Vector3(0F, 2F, - 6.5F)
        Private lookAtPart As New Vector3(0F, 0F, 0F)
        Private upVector As New Vector3(0F, 1F, 0F)
        
        ' data for timing, used to move camera and calculate fps
        Private tickCount As Integer = 0
        Private appTime As Single
        
        ' a helper to track display the current fps
        Private fpsTimer As FpsTimerTool = Nothing
        
        ' the d3d rendering device and device state
        Private device As Device
        Private renderState As RenderStateManager
        
        ' Application constructor. Sets attributes for the app.
        Public Sub New() 
            ' Set the window text
            Me.Text = "Billboard: D3D Billboarding Example"
            Me.MinimizeBox = False
            
            skyBoxMesh = New GraphicsMesh()
            terrainMesh = New GraphicsMesh()
            
            OnetimeSceneInitialization()
            
            ' Now let's setup our D3D stuff
            Dim presentParams As New PresentParameters()
            presentParams.Windowed = True
            presentParams.SwapEffect = SwapEffect.Discard
            presentParams.AutoDepthStencilFormat = DepthFormat.D16
            presentParams.EnableAutoDepthStencil = True
            
            ' create the device
            device = New Device(0, DeviceType.Default, Me, _
                CreateFlags.None, presentParams)
            ' store the render state
            renderState = device.RenderState
            ' initialize any device resources that aren't lost on reset
            InitializeDeviceObjects()
            ' attach the reset callback
            AddHandler device.DeviceReset, AddressOf RestoreDeviceObjects
            ' initialize any device resources that are lost on reset
            RestoreDeviceObjects(device, EventArgs.Empty)
        End Sub 'New
         

        ' Verifies that the tree at the given position is sufficiently spaced
        ' from the other trees. If trees are placed too closely, one tree
        ' can quickly pop in front of the other as the camera angle changes.
        Function IsTreePositionValid(ByVal pos As Vector3Fixed) As Boolean 
            If trees.Count < 1 Then
                Return True
            End If 
            Dim x As Single = System.Convert.ToSingle(pos.X)
            Dim z As Single = System.Convert.ToSingle(pos.Z)
            
            Dim i As Integer
            For i = 0 To trees.Count-1
                Dim fDeltaX As Double = _
                    Math.Abs(x - System.Convert.ToSingle( _
                    CType(trees(i), Tree).Position.X))
                Dim fDeltaZ As Double = _
                    Math.Abs(z - System.Convert.ToSingle( _
                    CType(trees(i), Tree).Position.Z))
                If 3.0 > Math.Pow(fDeltaX, 2) + Math.Pow(fDeltaZ, 2) Then
                    Return False
                End If
            Next i 
            Return True
        End Function 'IsTreePositionValid
        
        ' The window has been created, but the device has not been created
        ' yet. Here you can perform application-related initialization and
        ' cleanup that does not depend on a device.
        Public Sub OnetimeSceneInitialization() 
            Dim rand As New System.Random()
            ' Initialize the tree data
            Dim i As Integer
            For i = 0 To numberTrees-1
                Dim t As New Tree()
                ' Position the trees randomly
                Do
                    Dim fTheta As Single = 2F * _
                        System.Convert.ToSingle(Math.PI) * _
                        System.Convert.ToSingle(rand.NextDouble())
                    Dim fRadius As Single = 25F + 55F * _
                        System.Convert.ToSingle(rand.NextDouble())
                    Dim position As Vector3Fixed
                    position.X = CType(fRadius * _
                        System.Convert.ToSingle( _
                        Math.Sin(fTheta)), FixedPoint)
                    position.Z = CType(fRadius * _
                        System.Convert.ToSingle(Math.Cos(fTheta)), FixedPoint)
                    position.Y = CType(HeightField( _
                        System.Convert.ToSingle(position.X), _
                        System.Convert.ToSingle(position.Z)), FixedPoint)
                    t.Position = position
                Loop While Not IsTreePositionValid(t.Position)
                
                ' Size the trees randomly
                Dim fWidth As Single = 1F + 0.2F * _
                    System.Convert.ToSingle( _
                    rand.NextDouble() - rand.NextDouble())
                Dim fHeight As Single = 1.4F + 0.4F * _
                    System.Convert.ToSingle(rand.NextDouble() _
                    - rand.NextDouble())
                
                ' Each tree is a random color between red and green
                Dim r As Integer = CType(255 - 190 + _
                    Fix(190 * System.Convert.ToSingle( _
                    rand.NextDouble())), Integer)
                Dim g As Integer = Ctype(255 - 190 + _
                    Fix(190 * System.Convert.ToSingle( _
                    rand.NextDouble())), Integer)
                Dim b As Integer = 0
                Dim color As Integer = Ctype(Fix(&HFF000000 + _
                    r*2^16 + g*2^8 + b), Integer)
                
                Dim v0, v1, v2, v3 As CustomVertex.PositionColoredTextured 
                v0.X = -fWidth
                v0.Y = 0 * fHeight
                v0.Z = 0.0
                v0.Color = color
                v0.Tu = 0.0
                v0.Tv = 1.0
                t.V0 = v0
                v1.X = -fWidth
                v1.Y = 2 * fHeight
                v1.Z = 0.0
                v1.Color = color
                v1.Tu = 0.0
                v1.Tv = 0.0
                t.V1 = v1
                v2.X = fWidth
                v2.Y = 0 * fHeight
                v2.Z = 0.0
                v2.Color = color
                v2.Tu = 1.0
                v2.Tv = 1.0
                t.V2 = v2
                v3.X = fWidth
                v3.Y = 2 * fHeight
                v3.Z = 0.0
                v3.Color = color
                v3.Tu = 1.0
                v3.Tv = 0.0
                t.V3 = v3
                
                ' Pick a random texture for the tree
                t.TreeTextureIndex = _
                    CType(Fix(treeTextureFileNames.Length * _
                    rand.NextDouble()), Integer)
                trees.Add(t)
            Next i
        End Sub 'OnetimeSceneInitialization
        
        ' Called once per frame, the call is the entry point for animating
        ' the scene.
        Public Sub FrameMove() 
            ' Get the eye and lookat points from the camera's path
            Dim vUpVec As New Vector3(0F, 1F, 0F)
            Dim vEyePt As New Vector3()
            Dim vLookatPt As New Vector3()
            
            vEyePt.X = 30F * System.Convert.ToSingle(Math.Cos(0.8F * appTime))
            vEyePt.Z = 30F * System.Convert.ToSingle(Math.Sin(0.8F * appTime))
            vEyePt.Y = 4 + HeightField(vEyePt.X, vEyePt.Z)
            
            vLookatPt.X = 30F * System.Convert.ToSingle(Math.Cos(0.8F _
                *(appTime + 0.5F)))
            vLookatPt.Z = 30F * System.Convert.ToSingle(Math.Sin(0.8F _
                *(appTime + 0.5F)))
            vLookatPt.Y = vEyePt.Y - 1F
            
            ' Set the app view matrix for normal viewing
            device.Transform.View = Matrix.LookAtLH(vEyePt, vLookatPt, _
                vUpVec)
            
            ' Set up a rotation matrix to orient the billboard towards 
            ' the camera.
            Dim vDir As Vector3 = Vector3.Subtract(vLookatPt, vEyePt)
            If vDir.X > 0F Then
                billboardMatrix = New MatrixFixed(Matrix.RotationY( _
                    System.Convert.ToSingle(-Math.Atan(vDir.Z / vDir.X) _
                    + Math.PI / 2)))
            Else
                billboardMatrix = New MatrixFixed(Matrix.RotationY( _
                    System.Convert.ToSingle(-Math.Atan(vDir.Z / vDir.X) _
                    - Math.PI / 2)))
            End If
            GlobalDirection.X = CType(vDir.X, FixedPoint)
            GlobalDirection.Z = CType(vDir.Z, FixedPoint)
            
            ' Sort trees in back-to-front order
            trees.Sort(CType(New TreeSortClass(), _
                System.Collections.IComparer))
            
            ' Store vectors
            eyePart = vEyePt
        End Sub 'FrameMove
        
        ' Called once per frame, the call is the entry point for 3d rendering.
        ' This function sets up render states, clears the viewport, and
        ' renders the scene.
        Public Sub Render() 
            fpsTimer.StartFrame()

            device.BeginScene()
            ' Clear the viewport
            device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, _
                System.Drawing.Color.Black, 1F, 0)
            
            ' Center view matrix for skybox and disable zbuffer
            Dim matView, matViewSave As Matrix
            matViewSave = device.Transform.View
            matView = matViewSave
            matView.M41 = 0F
            matView.M42 = - 0.3F
            matView.M43 = 0F
            device.Transform.View = matView
            device.RenderState.ZBufferEnable = False
            ' Some cards do not disable writing to Z when 
            ' D3DRS_ZENABLE is FALSE. So do it explicitly
            device.RenderState.ZBufferWriteEnable = False
            
            ' Render the skybox
            skyBoxMesh.Render()
            
            ' Restore the render states
            device.Transform.View = matViewSave
            device.RenderState.ZBufferEnable = True
            device.RenderState.ZBufferWriteEnable = True
            
            ' Draw the terrain
            terrainMesh.Render()
            
            ' Draw the trees
            DrawTrees()
            
            ' Output statistics
            fpsTimer.Render()
            
            device.EndScene()
            device.Present()

            fpsTimer.StopFrame()
        End Sub 'Render
        
        ' Render the trees in the sample
        Protected Sub DrawTrees() 
            Dim eyePartFixed As Vector3Fixed
            
            eyePartFixed = New Vector3Fixed()
            eyePartFixed.X = CType(eyePart.X, FixedPoint)
            eyePartFixed.Y = CType(eyePart.Y, FixedPoint)
            eyePartFixed.Z = CType(eyePart.Z, FixedPoint)
            
            ' Set diffuse blending for alpha set in vertices.
            renderState.AlphaBlendEnable = True
            renderState.SourceBlend = Blend.SourceAlpha
            renderState.DestinationBlend = Blend.InvSourceAlpha
            
            ' Enable alpha testing (skips pixels with less than a certain
            ' alpha.)
            If device.DeviceCaps.AlphaCompareCaps.SupportsGreaterEqual Then
                device.RenderState.AlphaTestEnable = True
                device.RenderState.ReferenceAlpha = &H8
                device.RenderState.AlphaFunction = [Compare].GreaterEqual
            End If
            
            ' Loop through and render all trees
            device.SetStreamSource(0, treeVertexBuffer, 0)
            Dim t As Tree
            For Each t In  trees
                ' Quick culling for trees behind the camera
                ' This calculates the tree position relative to the camera,
                ' and projects that vector against the camera's direction
                ' vector. A negative dot product indicates a non-visible tree.
                If 0 >(t.Position.X - eyePartFixed.X) * GlobalDirection.X _
                    + (t.Position.Z - eyePartFixed.Z) * GlobalDirection.Z Then
                    Exit For
                End If
                
                ' Set the tree texture
                device.SetTexture(0, treeTextures(t.TreeTextureIndex))
                
                ' Translate the billboard into place
                billboardMatrix.M41 = t.Position.X
                billboardMatrix.M42 = t.Position.Y
                billboardMatrix.M43 = t.Position.Z
                device.Transform.WorldFixed = billboardMatrix
                
                ' Render the billboard
                device.DrawPrimitives(PrimitiveType.TriangleStrip, _
                    t.OffsetIndex, 2)
            Next t
            
            ' Restore state
            device.Transform.World = Matrix.Identity
            device.RenderState.AlphaTestEnable = False
            device.RenderState.AlphaBlendEnable = False
        End Sub 'DrawTrees
        
        ' The device has been created.  Resources that are not lost on
        ' Reset() can be created here.
        Sub InitializeDeviceObjects() 
            ' Load the skybox                                                                             
            skyBoxMesh.Create(device, "Billboard.", "skybox2.md3dm", _
                System.Reflection.Assembly.GetExecutingAssembly())
            
            ' Load the terrain
            terrainMesh.Create(device, "Billboard.", "seafloor.md3dm", _
                System.Reflection.Assembly.GetExecutingAssembly())
            
            fpsTimer = New FpsTimerTool(device)
        
        End Sub 'InitializeDeviceObjects
        
        ' Fill the trees vertex buffer
        Private Sub CreateTreeData(ByVal sender As Object, _
            ByVal e As EventArgs) 
            Dim vb As VertexBuffer = CType(sender, VertexBuffer)
            ' Copy tree mesh data into vertexbuffer
            Dim v(numberTrees * 4 - 1) As _
                CustomVertex.PositionColoredTextured
            Dim iTree As Integer
            Dim offsetIndex As Integer = 0
            For iTree = 0 To numberTrees-1
                v((offsetIndex + 0)) = CType(trees(iTree), Tree).V0
                v((offsetIndex + 1)) = CType(trees(iTree), Tree).V1
                v((offsetIndex + 2)) = CType(trees(iTree), Tree).V2
                v((offsetIndex + 3)) = CType(trees(iTree), Tree).V3
                Dim t As Tree = CType(trees(iTree), Tree)
                t.OffsetIndex = offsetIndex
                trees(iTree) = t
                offsetIndex += 4
            Next iTree
            vb.SetData(v, 0, 0)
        End Sub 'CreateTreeData
        
        ' The device exists, but may have just been Reset().  Resources
        ' and any other device state that persists during
        ' rendering should be set here.  Render states, matrices, textures,
        ' etc., that don't change during rendering can be set once here to
        ' avoid redundant state setting during Render() or FrameMove().
        Private Sub RestoreDeviceObjects(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) 
            ' Create the tree textures
            Dim i As Integer
            Dim asm As [Assembly] = [Assembly].GetExecutingAssembly()
            For i = 0 To treeTextureFileNames.Length-1
                treeTextures(i) = TextureLoader.FromStream(device, _
                     asm.GetManifestResourceStream( _
                     "Billboard." + treeTextureFileNames(i)))
            Next i
            
            If treeVertexBuffer Is Nothing OrElse _
                treeVertexBuffer.Disposed Then
                
                Dim vertexBufferPool As Pool
                Dim caps As Caps

                ' Get the device capabilities

                caps = device.DeviceCaps

                If (caps.SurfaceCaps.SupportsVidVertexBuffer) Then
                    vertexBufferPool = Pool.VideoMemory
                Else
                    vertexBufferPool = Pool.SystemMemory
                End If

                ' Create a quad for rendering each tree
                treeVertexBuffer = New VertexBuffer( _
                    GetType(CustomVertex.PositionColoredTextured), _
                    numberTrees * 4, device, Usage.WriteOnly, _
                    CustomVertex.PositionColoredTextured.Format, _
                    vertexBufferPool)
                
                AddHandler treeVertexBuffer.Created, _
                    AddressOf Me.CreateTreeData
                Me.CreateTreeData(treeVertexBuffer, Nothing)
            End If
            
            ' Restore the device objects for the meshes and fonts
            terrainMesh.RestoreDeviceObjects(device, Nothing)
            skyBoxMesh.RestoreDeviceObjects(device, Nothing)
            
            ' Add some "hilliness" to the terrain
            Dim tempVertexBuffer As VertexBuffer
            tempVertexBuffer = terrainMesh.Mesh.VertexBuffer
            Dim pVertices() As CustomVertex.PositionTextured
            Dim numberVertices As Integer = _
                terrainMesh.Mesh.NumberVertices
            pVertices = CType(tempVertexBuffer.Lock(0, _
                GetType(CustomVertex.PositionTextured), 0, _
                numberVertices), CustomVertex.PositionTextured())
            For i = 0 To numberVertices-1
                pVertices(i).Y = HeightField(pVertices(i).X, pVertices(i).Z)
            Next i
            tempVertexBuffer.Unlock()
            
            
            ' Set the transform matrices (view and world are updated per
            ' frame)
            Dim matProj As Matrix
            Dim fAspect As Single = 1F
            matProj = Matrix.PerspectiveFovLH( _
                System.Convert.ToSingle(Math.PI) / 4, fAspect, 1F, 100F)
            device.Transform.Projection = matProj
            
            ' Set up the default texture states
            device.TextureState(0).ColorOperation = TextureOperation.Modulate
            device.TextureState(0).ColorArgument1 = _
                TextureArgument.TextureColor
            device.TextureState(0).ColorArgument2 = TextureArgument.Diffuse
            device.TextureState(0).AlphaOperation = _
                TextureOperation.SelectArg1
            device.TextureState(0).AlphaArgument1 = _
                TextureArgument.TextureColor
            device.TextureState(0).MinFilter = TextureFilter.Linear
            device.TextureState(0).MagFilter = TextureFilter.Linear
            device.TextureState(0).MipFilter = TextureFilter.Linear
            device.TextureState(0).AddressU = TextureAddress.Clamp
            device.TextureState(0).AddressV = TextureAddress.Clamp
            
            device.RenderState.DitherEnable = True
            device.RenderState.ZBufferEnable = True
            device.RenderState.Lighting = False

            ' Turn on perspective correction for textures
            ' This provides a more accurate visual at the cost
            ' of a small performance overhead
            device.RenderState.TexturePerspective = True

        End Sub 'RestoreDeviceObjects
        
        ' Simple function to define "hilliness" for terrain
        Function HeightField(ByVal x As Single, ByVal y As Single) As Single 
            Return 9 *(System.Convert.ToSingle(Math.Cos(x / 20 + 0.2F)) _
                * System.Convert.ToSingle(Math.Cos(y / 15 - 0.2F)) + 1F)
        End Function 'HeightField
        
        ' Called when the window needs to repaint itself
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
            If tickCount = 0 Then
                tickCount = Environment.TickCount - 1
            End If
            
            appTime = System.Convert.ToSingle( _
                Environment.TickCount - tickCount) / 1000F
            Me.FrameMove()
            ' Render on painting
            Me.Render()
            ' Render again
            Me.Invalidate()
        End Sub 'OnPaint
        
        ' Called when the window needs to repaint the background
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
        End Sub 'OnPaintBackground
        
        
        ' The main entry point for the application.
        Shared Sub Main() 
            Try
            
                Dim d3dApp As New BillboardForm()
                System.Windows.Forms.Application.Run(d3dApp)
            
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
        End Sub 'Main
    End Class

    ' A class to sort our trees in back-to-front order
    Public Class TreeSortClass
        Implements System.Collections.IComparer
        
        ' Compare two trees
        Public Function Compare(left As Object, right As Object) _
            As Integer Implements System.Collections.IComparer.Compare
            Dim l As Tree = CType(left, Tree)
            Dim r As Tree = CType(right, Tree)
            
            Dim d1 As FixedPoint = _
                l.Position.X * BillboardForm.GlobalDirection.X + _
                l.Position.Z * BillboardForm.GlobalDirection.Z
            Dim d2 As FixedPoint = _
                r.Position.X * BillboardForm.GlobalDirection.X + _
                r.Position.Z * BillboardForm.GlobalDirection.Z
            
            If d1 = d2 Then
                Return 0
            End If 
            If d1 < d2 Then
                Return + 1
            End If 
            Return - 1
        
        End Function 'Compare
    End Class 'TreeSortClass
End Namespace