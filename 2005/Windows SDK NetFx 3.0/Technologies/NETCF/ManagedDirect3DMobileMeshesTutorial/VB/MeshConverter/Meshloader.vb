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
Imports System.Text
Imports System.Globalization

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Namespace Microsoft.Samples.MD3DM

    'An exception thrown by the meshloader if an error occurs during
    'loading/saving
    Public Class MeshSerializationException
        Inherits Exception
        
        Public Sub New()
        End Sub
        
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        
        Public Sub New(ByVal message As String, inner As Exception)
            MyBase.New(message, inner)
        End Sub

    End Class

    ' This class implements loading and saving functionality to/from a custom
    ' binary mesh format
    Public NotInheritable Class MeshLoader
        
        
        ' The mesh loader's binary format looks like this:
        ' Offset Size Name              Description
        ' 0      4    Magic Number      'xofm'					 
        ' 4      4    Version           The version MUST be 0x0001000
        ' 8      4    Fvf               Flexible Vertex Format MUST be 
        '                               a valid D3DM fvf
        ' 12     4    NumVertices       The number of vertices
        ' 16     4    NumIndices        The number of indices
        ' 20     4    Is16BitIndices    If 0 then the indices are 32 bit, 
        '                               if 1 the indices are 16 bit. Else 
        '                               the file is invalid
        ' 24     4    NumMaterials      The number of materials
        ' 28     4    NumAttrRanges     The number of attribute ranges
        ' 32     4    OffsetVertex      Offset to VertexData from the 
        '                               beginning of the file
        ' 36     4    OffsetIndices     Offset to Indices from the 
        '                               beginning of the file
        ' 40     4    OffsetAttrRange   Offset to the attribute range data 
        '                               from the beginning of the file.
        ' 44     4    OffsetMaterial    Offset to the start of the te material
        '                               data from the beginning of the file.
        ' 48     4    BytesMaterials    The size in bytes of the materials
        '                               region
        '
        ' Vertices are stored at their offset in a contiguous array of bytes.
        '
        ' Indices are stored at their offset in a contiguous array of bytes.
        '
        ' Attribute Ranges are stored in the following format
        '
        ' 0      4    AttribId          The attribute id for this range
        ' 4      4    FaceStart         The starting face
        ' 8      4    FaceCount         The count of faces
        ' 12     4    VertexStart       The starting vertex
        ' 16     4    VertexCount       The count of vertices
        '
        '    Materials are stored one after another in the following format
        ' 0      16   Diffuse color (Stored as RGBA as consecutive 
        '             32bit floats)
        ' 16     16   Ambient color (Stored as RGBA as consecutive 
        '             32bit floats)
        ' 32     16   Specular color (Stored as RGBA as consecutive 
        '             32bit floats)
        ' 48     4    Power (32 bit float)
        ' 52     4    Filename length in bytes
        ' 56     (FilenameLength) Texture filename encoded as UTF-16.
        '
        '
        '
        
        ' A private constructor because this class should never be
        ' instantiated
        Private Sub New()
        End Sub
        
        ' The magic number which is used to verify a file contains the
        ' binary mesh format
        Private Shared magicNumber As Integer = &H27391874
        
        ' The current version of this format
        Private Shared versionNumber As Integer = &H1000
        
        '  The size of header information in bytes for this format
        Private Shared sizeofHeader As Integer = 52
        
        '  The size of the attribute range in bytes for this format
        Private Shared sizeofAttributeRange As Integer = 20

        ' The size of the serialized material data not including the
        ' variable sized string but including the int which encodes the
        ' length of that string
        Private Shared sizeofMaterial As Integer = 56

        ' The vertex format constants in md3dm for normal, diffuse,
        ' specular, and textureCountShift. Referencing VertexFormats.XXX
        ' doesn't work when linked against Micorosft.DirectX because the
        ' constants are different than those in md3dm.
        Private Shared md3dmFvfNormal As Integer = &H8
        Private Shared md3dmFvfDiffuse As Integer = &H40
        Private Shared md3dmFvfSpecular As Integer = &H80
        Private Shared md3dmFvfTextureCountShift As Integer = &H8
        
        ' Loads a mesh from the given stream
        ' device is a d3d mobile device which will be displaying the mesh
        ' stream is the stream containing serialized mesh data
        ' flags are option flags
        ' materials is an output array is filled with any needed materials
        ' textures is an output array is filled with the filenames of any
        ' needed textures
        Public Shared Function LoadMesh(ByVal device As Device, _
            ByVal stream As Stream, ByVal flags As MeshFlags, _
            ByRef materials() As Material, ByRef textures() As String) As Mesh
            If device Is Nothing Then
                Throw New ArgumentException("Argument device was invalid")
            End If
            If stream Is Nothing Then
                Throw New ArgumentException("Argument stream was invalid")
            End If 
            Dim rgb() As Byte
            Dim rgbIb() As Byte
            Dim rgbVb() As Byte
            Dim meshRet As Mesh
            Dim vb As VertexBuffer
            Dim ib As IndexBuffer
            
            Dim fileMagicNumber As Integer
            Dim fileVersion As Integer
            Dim flexibleVertexFormat As VertexFormats
            Dim numberVertices As Integer
            Dim numberIndices As Integer
            Dim is16BitIndices As Integer
            Dim numberMaterials As Integer
            Dim numberAttrRanges As Integer
            Dim offsetVertex As Integer
            Dim offsetIndices As Integer
            Dim offsetAttrRange As Integer
            Dim offsetMaterial As Integer
            Dim bytesMaterials As Integer
            Dim bytesIndices As Integer
            
            
            Dim attributeTable() As Integer
            Dim attributeRanges() As AttributeRange
            
            rgb = New Byte(511) {}
            
            stream.Seek(0, SeekOrigin.Begin)
            
            ' Read header
            stream.Read(rgb, 0, sizeofHeader)
            
            ' read and verify magic number
            fileMagicNumber = BitConverter.ToInt32(rgb, 0)
            If fileMagicNumber <> magicNumber Then
                Throw New MeshSerializationException( _
                    "The serialized data does not represent a mesh")
            End If 
            ' read and verify version
            fileVersion = BitConverter.ToInt32(rgb, 4)
            If fileVersion <> versionNumber Then
                Throw New MeshSerializationException( _
                    "The format version was not recognized")
            End If 
            
            flexibleVertexFormat = _
                CType(BitConverter.ToInt32(rgb, 8), VertexFormats)
            numberVertices = BitConverter.ToInt32(rgb, 12)
            numberIndices = BitConverter.ToInt32(rgb, 16)
            is16BitIndices = BitConverter.ToInt32(rgb, 20)
            numberMaterials = BitConverter.ToInt32(rgb, 24)
            numberAttrRanges = BitConverter.ToInt32(rgb, 28)
            offsetVertex = BitConverter.ToInt32(rgb, 32)
            offsetIndices = BitConverter.ToInt32(rgb, 36)
            offsetAttrRange = BitConverter.ToInt32(rgb, 40)
            offsetMaterial = BitConverter.ToInt32(rgb, 44)
            bytesMaterials = BitConverter.ToInt32(rgb, 48)
            
            ' verify number of vertices
            If numberVertices < 0 Then
                Throw New MeshSerializationException( _
                    String.Format( CultureInfo.InvariantCulture, _
                    "Invalid number of vertices: {0}", numberVertices))
            End If 
            ' verify number of indices
            If numberIndices < 0 OrElse numberIndices Mod 3 <> 0 Then
                Throw New MeshSerializationException( _
                    String.Format( CultureInfo.InvariantCulture, _
                    "Invalid number of indices: {0}", numberIndices))
            End If 
            ' verify number of materials
            If numberMaterials < 0 Then
                Throw New MeshSerializationException( _
                    String.Format( CultureInfo.InvariantCulture, _
                    "Invalid number of materials: {0}", numberMaterials))
            End If 
            ' verify number of attribute ranges
            If numberAttrRanges < 0 Then
                Throw New MeshSerializationException( _
                    String.Format( CultureInfo.InvariantCulture, _
                    "Invalid number of attribute ranges: {0}", numberAttrRanges))
            End If 
            ' determine number of index bytes and verify Is16BitIndices
            If is16BitIndices = 1 Then
                bytesIndices = numberIndices * 2
            ElseIf is16BitIndices = 0 Then
                bytesIndices = numberIndices * 4
            Else
                Throw New MeshSerializationException( _
                    String.Format( CultureInfo.InvariantCulture, _
                    "Invalid value for Is16BitIndices: {0}", is16BitIndices))
            End If 

            ' md3dm uses different Fvf defines than desktop does
		    ' this snippet should convert Fvf to desktop conventions when
            ' the code is run on desktop.
		    ' If run on device the Fvf should end unchanged

		    ' determine the necessary Fvf
		    Dim sourceFormat As Integer = CType(flexibleVertexFormat, Integer)
		    Dim textureCount As Integer
		    flexibleVertexFormat = VertexFormats.Position
    	
		    If((sourceFormat And md3dmFvfNormal) <> 0)
			    flexibleVertexFormat = _
                    flexibleVertexFormat Or VertexFormats.Normal
            End If	

		    If((sourceFormat And md3dmFvfDiffuse) <> 0)
			    flexibleVertexFormat = _
                    flexibleVertexFormat Or VertexFormats.Diffuse
            End If	

		    If ((sourceFormat And md3dmFvfSpecular) <> 0)
			    flexibleVertexFormat = _
                    flexibleVertexFormat Or VertexFormats.Specular
            End If
    	
		    ' determine number of textures
            textureCount = Ctype(Fix(sourceFormat And _
                VertexFormats.TextureCountMask) / _
                2^Fix(md3dmFvfTextureCountShift), Integer)
    	
		    ' limit to 4 textures
		    If (textureCount > 4)
			    textureCount = 4
            End If	

		    ' set texture count
            flexibleVertexFormat = flexibleVertexFormat _
                Or CType(textureCount * _
                2^Fix(VertexFormats.TextureCountShift), VertexFormats)

            Dim bytesVertices As Integer = _
                VertexInformation.GetFormatSize(flexibleVertexFormat) _
                    * numberVertices
            
            ' Verify none of the data regions overlap
            ' The material section is variable size so we can't check that one
            ' yet
            If Not(offsetVertex >= sizeofHeader AndAlso _
                offsetIndices >= offsetVertex + BytesVertices AndAlso _
                offsetAttrRange >= offsetIndices + BytesIndices AndAlso _
                offsetMaterial >= offsetAttrRange + _
                numberAttrRanges * sizeofAttributeRange AndAlso _
                stream.Length >= offsetMaterial + bytesMaterials) Then
                Throw New MeshSerializationException( _
                    "The data regions are not within the stream or overlap")
            End If 
            ' create our data tables
            materials = New Material(numberMaterials-1) {}
            textures = New String(numberMaterials-1) {}
            attributeRanges = New attributeRange(numberAttrRanges-1) {}
            attributeTable = New Integer(CType(numberIndices/3, Integer)-1) {}
            
            ' move to the attribute range section
            stream.Seek(OffsetAttrRange, SeekOrigin.Begin)
            
            ' parse attribute ranges
            Dim i As Integer
            For i = 0 To numberAttrRanges-1
                Dim attribId As Integer
                Dim faceStart As Integer
                Dim faceCount As Integer
                Dim vertexStart As Integer
                Dim vertexCount As Integer
                
                ' read in the attribute range data
                stream.Read(rgb, 0, 20)
                attribId = BitConverter.ToInt32(rgb, 0)
                faceStart = BitConverter.ToInt32(rgb, 4)
                faceCount = BitConverter.ToInt32(rgb, 8)
                vertexStart = BitConverter.ToInt32(rgb, 12)
                vertexCount = BitConverter.ToInt32(rgb, 16)
                
                
                ' verify the data
                If vertexStart < 0 OrElse vertexCount < 0 OrElse _
                    vertexStart + vertexCount > numberVertices OrElse _
                    (faceStart < 0 OrElse faceCount < 0 OrElse _
                    (faceStart + faceCount) * 3 > numberIndices) Then
                    Throw New MeshSerializationException( _
                        "Invalid attribute range")
                End If 
                
                ' store the validated data
                attributeRanges(i).AttributeId = attribId
                attributeRanges(i).FaceStart = faceStart
                attributeRanges(i).FaceCount = faceCount
                attributeRanges(i).VertexStart = vertexStart
                attributeRanges(i).VertexCount = vertexCount
                Dim j As Integer
                For j = faceStart To faceStart+faceCount-1
                    attributeTable(j) = attribId
                Next j
            Next i
            
            ' move to the material section
            stream.Seek(offsetMaterial, SeekOrigin.Begin)
            
            ' parse materials
            For i = 0 To numberMaterials-1
                Dim cbTexture As Integer
                
                ' verify that we aren't reading past the end of the stream
                ' its possible an invalid filename length the
                If stream.Position + sizeofMaterial > stream.Length Then
                    Throw New MeshSerializationException( _
                        "Material data region is corrupt")
                End If 
                ' read  in the material color data
                stream.Read(rgb, 0, sizeofMaterial)
                materials(i).DiffuseColor = New ColorValue( _
                    BitConverter.ToSingle(rgb, 0), _
                    BitConverter.ToSingle(rgb, 4), _
                    BitConverter.ToSingle(rgb, 8), _
                    BitConverter.ToSingle(rgb, 12))
                
                materials(i).AmbientColor = New ColorValue( _
                    BitConverter.ToSingle(rgb, 16), _
                    BitConverter.ToSingle(rgb, 20), _
                    BitConverter.ToSingle(rgb, 24), _
                    BitConverter.ToSingle(rgb, 28))
                
                materials(i).SpecularColor = New ColorValue( _
                    BitConverter.ToSingle(rgb, 32), _
                    BitConverter.ToSingle(rgb, 36), _
                    BitConverter.ToSingle(rgb, 40), _
                    BitConverter.ToSingle(rgb, 44))
                
                materials(i).SpecularSharpness = _
                    BitConverter.ToSingle(rgb, 48)
                
                ' read in the size of the texture filename
                cbTexture = BitConverter.ToInt32(rgb, 52)
                
                ' verify that the texture filename hasa valid length
                If cbTexture < 0 OrElse _
                    stream.Position + cbTexture > stream.Length Then
                    Throw New MeshSerializationException( _
                        "Material data region is corrupt")
                End If 
                ' read the texture filename
                If cbTexture > 0 Then
                    stream.Read(rgb, 0, cbTexture)
                    textures(i) = Encoding.Unicode.GetString(rgb, 0, _
                        cbTexture)
                End If
            Next i
            
            ' create data buffers
            rgbIb = New Byte(bytesIndices-1) {}
            rgbVb = New Byte(bytesVertices-1) {}
            
            ' read in the index data
            stream.Seek(offsetIndices, SeekOrigin.Begin)
            stream.Read(rgbIb, 0, rgbIb.Length)
            
            ' read in the vertex data
            stream.Seek(offsetVertex, SeekOrigin.Begin)
            stream.Read(rgbVb, 0, rgbVb.Length)
            
            ' set the use 32 bit flag appropriately
            If(is16BitIndices = 1)
                flags = flags And Not MeshFlags.Use32Bit
            Else
                flags = flags Or MeshFlags.Use32Bit
            End if




            ' create a new empty mesh
            meshRet = New Mesh(Ctype(numberIndices / 3, Integer), _
                numberVertices, flags, flexibleVertexFormat, device)
            
            Try
                ' create the index and vertex buffer
                vb = meshRet.VertexBuffer
                ib = meshRet.IndexBuffer
                
                ' write the vertex data
                vb.Lock(0, bytesVertices, LockFlags.None).Write(rgbVb, _
                    0, bytesVertices)
                vb.Unlock()
                
                ' write the index data
                ib.Lock(0, bytesIndices, LockFlags.None).Write(rgbIb, _
                    0, bytesIndices)
                ib.Unlock()
                
                ' set the attributes
                meshRet.LockAttributeBuffer(LockFlags.None)
                meshRet.UnlockAttributeBuffer(AttributeTable)
                meshRet.SetAttributeTable(AttributeRanges)
            Catch e As DirectXException
                ' release the mesh if anything went wrong
                meshRet.Dispose()
                meshRet = Nothing
                Throw e
            End Try
            
            Return meshRet
        
        End Function 'LoadMesh
        
        ' Saves a mesh to the custom serialized format
        ' stream is the stream to which to serialize
        ' mesh is the mesh to be serialized
        ' materials are the materials for subparts of the mesh
        ' textures are the filenames for the textures on subparts of the mesh
        Public Shared Sub SaveMesh(ByVal stream As Stream, _
            ByVal mesh As Mesh, ByVal materials() As Material, _
            ByVal textures() As String) 
            Dim flexibleVertexFormat As Integer
            Dim numberVertices As Integer
            Dim vertices() As Byte
            Dim numberIndices As Integer
            Dim indices() As Byte
            Dim attributeRanges() As AttributeRange
            Dim sourceVertexFormat As VertexFormats
            Dim sourceFormat As VertexFormats
            Dim tempMesh As IDisposable
            
            tempMesh = Nothing
            
            Try
                ' determine the necessary Fvf
                sourceVertexFormat = mesh.VertexFormat
                Dim textureCount As Integer
                sourceFormat = VertexFormats.Position
                flexibleVertexFormat = 0
                
                If(sourceVertexFormat And VertexFormats.Normal) <> 0 Then
                    flexibleVertexFormat = _
                        flexibleVertexFormat Or md3dmFvfNormal
                    sourceFormat = sourceFormat Or VertexFormats.Normal
                End If
                
                If(sourceVertexFormat And VertexFormats.Diffuse) <> 0 Then
                    flexibleVertexFormat = _
                        flexibleVertexFormat Or md3dmFvfDiffuse
                    sourceFormat = sourceFormat Or VertexFormats.Diffuse
                End If
                
                If(sourceVertexFormat And VertexFormats.Specular) <> 0 Then
                    flexibleVertexFormat = _
                        flexibleVertexFormat Or md3dmFvfSpecular
                    sourceFormat = sourceFormat Or VertexFormats.Specular
                End If
                
                ' determine number of textures
                textureCount = Ctype(Fix(sourceVertexFormat And _
                    VertexFormats.TextureCountMask) / _
                    2^Fix(VertexFormats.TextureCountShift), Integer)
                
                'limit to 4 textures
                If textureCount > 4 Then
                    textureCount = 4
                End If
                
                ' continue setting up necessary Fvf
                sourceFormat = sourceFormat Or CType(textureCount * _
                    2^Fix(VertexFormats.TextureCountShift), VertexFormats)
                flexibleVertexFormat = _
                    Ctype(flexibleVertexFormat Or Ctype(textureCount * _
                    2^md3dmFvfTextureCountShift, Integer), Integer)
                
                If sourceFormat <> sourceVertexFormat Then
                    mesh = mesh.Clone(mesh.Options.Value, sourceFormat, _
                        mesh.Device)
                    tempMesh = CType(mesh, IDisposable)
                End If
                
                
                attributeRanges = mesh.GetAttributeTable()
                
                If attributeRanges Is Nothing Then
                    Throw New MeshSerializationException( _
                        "No Attribute table present")
                End If
                
                ' determine number of vertices and create buffer
                numberVertices = mesh.NumberVertices
                vertices = New Byte(numberVertices * _
                    VertexInformation.GetFormatSize(sourceFormat) - 1) {}
                
                ' copy vertices to buffer
                mesh.VertexBuffer.Lock(0, vertices.Length, _
                    LockFlags.None).Read(vertices, 0, vertices.Length)
                mesh.VertexBuffer.Unlock()
                
                ' determine number of indices
                numberIndices = mesh.NumberFaces * 3
                
                ' create index data buffer
                If(mesh.Options.Use32Bit)
                    indices = New Byte(numberIndices * 4 - 1) {}
                Else
                    indices = New Byte(numberIndices * 2 - 1) {}
                End If
                
                ' fill index data into buffer
                mesh.IndexBuffer.Lock(0, indices.Length, _
                    LockFlags.None).Read(indices, 0, indices.Length)
                mesh.IndexBuffer.Unlock()
                
                ' write the data out to file
                MeshLoader.SaveMeshData(stream, flexibleVertexFormat, _
                    numberVertices, vertices, numberIndices, indices, _
                    attributeRanges, materials, textures)
            Finally
                If Not (tempMesh Is Nothing) Then
                    tempMesh.Dispose()
                End If
            End Try
        
        End Sub 'SaveMesh
        
        
        ' Serializes mesh data to a custom format
        ' stream is the stream to which to serialize
        ' flexibleVertexFormat is the Fvf of the vertex data
        ' numberVertices are the number of vertices in the vertex data
        ' vertices is the buffer of vertex data
        ' numberIndices is the number of indices in the index data
        ' indices is the buffer of index data
        ' attributeRanges are the attribute ranges to serialize
        ' materials are the materials for the mesh subparts
        ' textures are the texture filenames for the mesh subparts
        Public Shared Sub SaveMeshData(ByVal stream As Stream, _
            ByVal flexibleVertexFormat As Integer, _
            ByVal numberVertices As Integer, _
            ByVal vertices() As Byte, ByVal numberIndices As Integer, _
            ByVal indices() As Byte, _
            ByVal attributeRanges() As AttributeRange, _
            ByVal materials() As Material, ByVal textures() As String) 
            
            If numberIndices <= 0
                Throw new ArgumentException("numberIndices <= 0")
            End If

            If numberVertices <= 0
                Throw new ArgumentException("numberVertices <= 0")
            End If


            ' calculate the size of the vertex buffer
            Dim bytesVertices As Integer = vertices.Length

            ' verify 16 or 32 bit indices
            Dim bytesPerIndex As Integer = _
                Ctype(indices.Length / numberIndices, Integer)
            If bytesPerIndex <> 2 AndAlso bytesPerIndex <> 4 Then
                Throw New MeshSerializationException( _
                    "Indices are neither 16 nor 32 bit")
            End If 

            Dim is16BitIndices As Integer
            If(bytesPerIndex = 2)
                is16BitIndices = 1
            Else
                is16BitIndices = 0
            End If        


            ' verify the same number of materials as texture names
            If materials.Length <> textures.Length Then
                Throw New MeshSerializationException( _
                    "The number of textures must match the number " + _
                    "of materials")
            End If 
            ' determine the number of materials and attribue ranges
            Dim numberMaterials As Integer = materials.Length
            Dim numberAttrRanges As Integer = attributeRanges.Length
            
            ' determine the offsets
            Dim offsetVertex As Integer = sizeofHeader
            Dim offsetIndices As Integer = offsetVertex + vertices.Length
            Dim offsetAttrRange As Integer = offsetIndices + indices.Length
            Dim offsetMaterial As Integer = offsetAttrRange + _
                numberAttrRanges * sizeofAttributeRange
            
            ' go to the beginning of the stream
            stream.Seek(0, SeekOrigin.Begin)
            
            ' write the header
            stream.Write(BitConverter.GetBytes(magicNumber), 0, 4)
            stream.Write(BitConverter.GetBytes(versionNumber), 0, 4)
            stream.Write(BitConverter.GetBytes(flexibleVertexFormat), 0, 4)
            stream.Write(BitConverter.GetBytes(numberVertices), 0, 4)
            stream.Write(BitConverter.GetBytes(numberIndices), 0, 4)
            stream.Write(BitConverter.GetBytes(is16BitIndices), 0, 4)
            stream.Write(BitConverter.GetBytes(numberMaterials), 0, 4)
            stream.Write(BitConverter.GetBytes(numberAttrRanges), 0, 4)
            stream.Write(BitConverter.GetBytes(offsetVertex), 0, 4)
            stream.Write(BitConverter.GetBytes(offsetIndices), 0, 4)
            stream.Write(BitConverter.GetBytes(offsetAttrRange), 0, 4)
            stream.Write(BitConverter.GetBytes(offsetMaterial), 0, 4)
            
            ' write a 0 length for BytesMaterials right now
            ' the correct value will be filled in once it is known
            stream.Write(BitConverter.GetBytes(0), 0, 4)
            
            ' write the vertex and index information
            stream.Write(vertices, 0, vertices.Length)
            stream.Write(indices, 0, indices.Length)
            
            ' write the attribute range information
            Dim attr As AttributeRange
            For Each attr In  attributeRanges
                stream.Write(BitConverter.GetBytes(attr.AttributeId), 0, 4)
                stream.Write(BitConverter.GetBytes(attr.FaceStart), 0, 4)
                stream.Write(BitConverter.GetBytes(attr.FaceCount), 0, 4)
                stream.Write(BitConverter.GetBytes(attr.VertexStart), 0, 4)
                stream.Write(BitConverter.GetBytes(attr.VertexCount), 0, 4)
            Next attr
            
            ' write the material information
            Dim i As Integer
            For i = 0 To materials.Length-1
                stream.Write(BitConverter.GetBytes( _
                    materials(i).DiffuseColor.Red), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).DiffuseColor.Green), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).DiffuseColor.Blue), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).DiffuseColor.Alpha), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).AmbientColor.Red), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).AmbientColor.Green), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).AmbientColor.Blue), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).AmbientColor.Alpha), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).SpecularColor.Red), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).SpecularColor.Green), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).SpecularColor.Blue), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).SpecularColor.Alpha), 0, 4)
                stream.Write(BitConverter.GetBytes( _
                    materials(i).SpecularSharpness), 0, 4)
                
                If Not (textures(i) Is Nothing) Then
                    Dim rgb As Byte() = Encoding.Unicode.GetBytes(textures(i))
                    stream.Write(BitConverter.GetBytes(rgb.Length), 0, 4)
                    stream.Write(rgb, 0, rgb.Length)
                Else
                    stream.Write(BitConverter.GetBytes(Fix(0)), 0, 4)
                End If
            Next i 
            ' go back to fill in the length of the materials section
            Dim currentPosition As Long = stream.Position
            Dim bytesMaterials As Integer = _
                Fix(Ctype(stream.Position - OffsetMaterial,Integer))
            stream.Seek(Fix(48), SeekOrigin.Begin)
            stream.Write(BitConverter.GetBytes(0), 0, 4)
            stream.Seek(currentPosition, SeekOrigin.Begin)
        
        End Sub 'SaveMeshData
    End Class 'MeshLoader
End Namespace