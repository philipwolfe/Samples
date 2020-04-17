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
' File: Meshes.vb
'
' Desc: For advanced geometry, most apps will prefer to load pre-authored
'       meshes from a file. Unlike desktop there is no support for loading
'       a mesh from the .x file format. To deal with this, this sample
'       uses a custom mesh file format and a MeshLoader class to read and
'       write this format. An app can still use .x meshes by converting them
'       to this unofficial format with the MeshConverter utility, then
'       loading the mesh from the converted file at runtime.
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'-----------------------------------------------------------------------------

Imports System
Imports System.IO
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Reflection


Namespace Microsoft.Samples.MD3DM

    Public Class Meshes
        Inherits Form
        ' The d3d rendering device
        Private device As Device = Nothing
        
        ' The mesh object in sysmem
        Private mesh As Mesh = Nothing
        
        ' Materials for the mesh
        Private meshMaterials() As Material
        
        ' Textures for the mesh
        Private meshTextures() As Texture
        
        ' the display parameters for drawing a d3d window
        Private presentParams As New PresentParameters()
        
        
        Public Sub New() 
            ' Set the caption
            Me.Text = "Direct3D Tutorial 6 - Meshes"
            Me.MinimizeBox = False
        
        End Sub 'New

        ' Prepares the d3d system for display
        Function InitializeGraphics() As Boolean 
            Try
                ' draw the graphics inside a standard window
                presentParams.Windowed = True
                
                ' discard the current frame when drawing a new one
                presentParams.SwapEffect = SwapEffect.Discard
                
                ' create a 16 bit depth buffer 
                presentParams.EnableAutoDepthStencil = True
                presentParams.AutoDepthStencilFormat = DepthFormat.D16
                
                ' Create the D3DDevice
                device = New Device(0, DeviceType.Default, Me, _
                CreateFlags.None, presentParams)
                AddHandler device.DeviceReset, AddressOf Me.OnResetDevice
                Me.OnResetDevice(device, Nothing)
            
            Catch 
                Return False
            End Try
            
            Return True
        End Function 'InitializeGraphics

        ' Handles device reset events
        Private Sub OnResetDevice(ByVal sender As Object, ByVal e As EventArgs) 
            Dim textureFilenames As String() = Nothing
            
            Dim dev As Device = CType(sender, Device)
            
            ' Turn on the zbuffer
            dev.RenderState.ZBufferEnable = True
            
            ' Turn on ambient lighting 
            dev.RenderState.Ambient = System.Drawing.Color.White

            ' Turn on perspective correction for textures
            ' This provides a more accurate visual at the cost
            ' of a small performance overhead
            dev.RenderState.TexturePerspective = True
            
            ' Load the mesh from the specified file
            mesh = MeshLoader.LoadMesh(device, _
                Assembly.GetExecutingAssembly().GetManifestResourceStream( _
                "Meshes.tiger.md3dm"), MeshFlags.SystemMemory, meshMaterials, _
                textureFilenames)
            
            
            ' Extract the material properties and texture names
            meshTextures = New Texture(meshMaterials.Length-1) {}
            Dim i As Integer
            For i = 0 To meshMaterials.Length-1
                
                ' Set the ambient color for the material
                ' (D3DX does not do this)
                meshMaterials(i).Ambient = meshMaterials(i).Diffuse
                
                ' Create the texture
                meshTextures(i) = TextureLoader.FromStream(dev, _
                  Assembly.GetExecutingAssembly().GetManifestResourceStream( _
                    "Meshes." + textureFilenames(i)))
            Next i
        
        End Sub 'OnResetDevice
        
        
        ' Loads the matrices with appropriate transformations
        Sub SetupMatrices() 
            ' For our world matrix, we will just leave it as the identity
            device.Transform.World = Matrix.RotationY( _
                Environment.TickCount / 1000F)
            
            ' Set up our view matrix. A view matrix can be defined given an
            ' eye point, a point to lookat, and a direction for which way is
            ' up. Here, we set the eye five units back along the z-axis and up
            ' three units, look at the origin, and define "up" to be in the
            ' y-direction.
            device.Transform.View = Matrix.LookAtLH( _
                New Vector3(0F, 2F, - 3F), _
                New Vector3(0F, 0F, 0F), _
                New Vector3(0F, 1F, 0F))
            
            ' For the projection matrix, we set up a perspective transform
            ' (which transforms geometry from 3D view space to 2D viewport
            ' space, with a perspective divide making objects smaller in the
            ' distance). To build a perpsective transform, we need the field
            ' of view (1/4 pi is common), the aspect ratio, and the near and
            ' far clipping planes (which define at what distances geometry
            ' should be no longer be rendered).
            device.Transform.Projection = Matrix.PerspectiveFovLH( _
                System.Convert.ToSingle(Math.PI / 4), 1F, 1F, 100F)
        
        End Sub 'SetupMatrices
        

        ' Draws the mesh to the screen
        Private Sub Render() 
            If device Is Nothing Then
                Return
            End If 
            'Clear the backbuffer to a blue color 
            device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, _
                System.Drawing.Color.Blue, 1F, 0)
            'Begin the scene
            device.BeginScene()
            ' Setup the world, view, and projection matrices
            SetupMatrices()
            
            ' Meshes are divided into subsets, one for each material.
            ' Render them in a loop
            Dim i As Integer
            For i = 0 To meshMaterials.Length-1
                ' Set the material and texture for this subset
                device.Material = meshMaterials(i)
                device.SetTexture(0, meshTextures(i))
                
                ' Draw the mesh subset
                mesh.DrawSubset(i)
            Next i
            
            'End the scene
            device.EndScene()
            device.Present()
        End Sub 'Render
        
        ' Called whenever the window needs to be repainted
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
            ' Render the mesh to the screen
            Render()
            
            ' Invalidating the window will cause it to be redrawn
            ' in the future
            Invalidate()
        
        End Sub 'OnPaint
        
        
        ' Called whenever the background of the window needs to be repainted
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
        ' Doing nothing ensures the background will never overdraw
        ' the previous rendering        
        End Sub 'OnPaintBackground
        

        ' Called whenever a keystroke is made
        Protected Overrides Sub OnKeyPress( _
            ByVal e As System.Windows.Forms.KeyPressEventArgs) 
            ' if Escape was pressed then shutdown
            If Fix(System.Convert.ToByte(e.KeyChar)) = _
                Fix(System.Windows.Forms.Keys.Escape) Then
                Dispose()
            End If
        End Sub 'OnKeyPress
         
        ' Called whenever the window is being resized
        Protected Overrides Sub OnResize(ByVal e As System.EventArgs) 
            MyBase.OnResize(e)
        End Sub 'OnResize
        
        ' The main entry point for the application.
        Shared Sub Main() 
            Dim frm As New Meshes()
            
            ' Initialize Direct3D
            If Not frm.InitializeGraphics() Then
                MessageBox.Show("Could not initialize Direct3D. " + _
                    "This tutorial will exit.")
                Return
            End If
            
            ' Run the form
            Try
                Application.Run(frm)
            Catch e As Exception
                MessageBox.Show("An error occured and this sample " + _
                    "needs to close:" + e.Message)
            End Try

        End Sub 'Main
    End Class 'Meshes
End Namespace