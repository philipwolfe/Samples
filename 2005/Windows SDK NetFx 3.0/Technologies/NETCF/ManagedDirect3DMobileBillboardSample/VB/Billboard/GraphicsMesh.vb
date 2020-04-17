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
Imports System.IO
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D
Imports System.Text
Imports System.Reflection

Namespace Microsoft.Samples.MD3DM

    'Encapsulates some basic functionality to load and render meshes
    Class GraphicsMesh

        ' The rendering device
        Private device As Device

        ' The mesh this class loads and renders
        Private meshValue As Mesh = Nothing

        ' Materials for our mesh
        Private meshMaterials() As Material

        ' Textures for our mesh
        Private meshTextures() As Texture

        ' The assembly which has the resources embedded
        Private embeddedResourceAssembly As [Assembly]

        ' The string which will be prepended to filenames
        ' to produce valid resource names
        Private resourcePrefix As String

        ' Name of the mesh
        Private meshName As String

        ' The vertex format to load the mesh with
        Private vf As VertexFormats

        ' True if a vertex format has been set
        Private vfSet As Boolean = False
        
        Public ReadOnly Property Mesh() As Mesh
            Get
                Return meshValue
            End Get
        End Property        

        'Creates a new mesh
        Public Sub Create(ByVal device As Device, _
            ByVal resourcePrefix As String, _
            ByVal filename As String, ByVal [assembly] As [Assembly])
            Me.device = device
            embeddedResourceAssembly = [assembly]
            Me.meshName = filename
            Me.resourcePrefix = resourcePrefix

        End Sub 'Create
        
        'Sets the mesh vertex format
        Public Sub SetVertexFormat(ByVal format As VertexFormats) 
            vf = format
            vfSet = True
        End Sub 'SetVertexFormat
        
        ' Restores any needed data after a device reset
        Public Sub RestoreDeviceObjects(ByVal obj As Object, _
            ByVal eventg As EventArgs) 
            Dim textureFilenames As String() = Nothing
            
            meshValue = MeshLoader.LoadMesh(device, _
                embeddedResourceAssembly.GetManifestResourceStream( _
                resourcePrefix + meshName), _
                MeshFlags.SystemMemory, meshMaterials, textureFilenames)
            
            meshTextures = New Texture(meshMaterials.Length-1) {}
            Dim i As Integer
            For i = 0 To meshMaterials.Length-1
                ' Set the ambient color for the material 
                ' (D3DX does not do this)
                meshMaterials(i).Ambient = meshMaterials(i).Diffuse
                
                ' Create the texture
                If Not (textureFilenames(i) Is Nothing) Then
                    meshTextures(i) = TextureLoader.FromStream(device, _
                        embeddedResourceAssembly.GetManifestResourceStream( _
                        resourcePrefix + textureFilenames(i)))
                End If
            Next i
            
            If vf <> meshValue.VertexFormat AndAlso vfSet Then
                Dim temp As Mesh
                temp = meshValue.Clone(0, vf, meshValue.Device)
                meshValue.Dispose()
                meshValue = temp
            End If
        End Sub 'RestoreDeviceObjects
         
        'Renders the mesh
        Overloads Public Sub Render(ByVal canDrawOpaque As Boolean, _
            ByVal canDrawAlpha As Boolean) 
            Dim rs As RenderStateManager = device.RenderState
            ' Frist, draw the subsets without alpha
            If canDrawOpaque Then
                Dim i As Integer
                For i = 0 To meshMaterials.Length-1
                    If Not canDrawAlpha or meshMaterials(i).Diffuse.A >= _
                        &HFF Then
                        ' Set the material and texture for this subset
                        device.Material = meshMaterials(i)
                        If Not (meshTextures(i) Is Nothing) Then
                            device.SetTexture(0, meshTextures(i))
                        End If
                    
                        ' Draw the mesh subset
                        meshValue.DrawSubset(i)
                    End If 
                Next i
            End If
            
            ' Then, draw the subsets with alpha
            If canDrawAlpha Then
                ' Enable alpha blending
                rs.AlphaBlendEnable = True
                rs.SourceBlend = Blend.SourceAlpha
                rs.DestinationBlend = Blend.InvSourceAlpha
                Dim i As Integer
                For i = 0 To meshMaterials.Length-1
                    If meshMaterials(i).Diffuse.A <> &HFF Then
                        ' Set the material and texture for this subset
                        device.Material = meshMaterials(i)
                        If Not (meshTextures(i) Is Nothing) Then
                            device.SetTexture(0, meshTextures(i))
                        End If
                    
                        ' Draw the mesh subset
                        meshValue.DrawSubset(i)
                    End If 
                Next i
                ' Restore state
                rs.AlphaBlendEnable = False
            End If
        End Sub 'Render
        
        ' Renders the mesh
        Overloads Public Sub Render() 
            Me.Render(True, True)
        
        End Sub 'Render
    End Class 'GraphicsMesh 
End Namespace