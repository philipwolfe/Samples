//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------


using System;
using System.IO;
using System.Text;
using System.Globalization;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace Microsoft.Samples.MD3DM
{

    /// <summary>
    /// An exception thrown by the mesh loader if an error occurs
    /// during loading/saving
    /// </summary>
    public class MeshSerializationException : Exception
    {
        public MeshSerializationException() {}
        public MeshSerializationException(string message) : base(message) {}
        public MeshSerializationException(string message, Exception inner) :
            base(message, inner) {}
    }


    /// <summary>
    /// This class implements loading and saving functionality to/from a 
    /// custom binary mesh format
    /// </summary>
    sealed public class MeshLoader
    {

        // The mesh loader's binary format looks like this:
        // Offset Size Name              Description
        // 0      4    Magic Number      'xofm'                  
        // 4      4    Version           The version MUST be 0x0001000
        // 8      4    Fvf               Flexible Vertex Format MUST be a
        //                               valid D3DM fvf
        // 12     4    NumVertices       The number of vertices
        // 16     4    NumIndices        The number of indices
        // 20     4    Is16BitIndices    If 0 then the indices are 32 bit,  
        //                               if 1 the indices are 16 bit. Else  
        //                               the file is invalid
        // 24     4    NumMaterials      The number of materials
        // 28     4    NumAttrRanges     The number of attribute ranges
        // 32     4    OffsetVertex      Offset to VertexData from the 
        //                               beginning of the file
        // 36     4    OffsetIndices     Offset to Indices from the beginning
        //                               of the file
        // 40     4    OffsetAttrRange   Offset to the attribute range data 
        //                               from the beginning of the file.
        // 44     4    OffsetMaterial    Offset to the start of the material 
        //                               data from the beginning of the file.
        // 48     4    BytesMaterials    The size in bytes of the materials
        //                               region
        //
        // Vertices are stored at their offset in a contiguous array of bytes.
        //
        // Indices are stored at their offset in a contiguous array of bytes.
        //
        // Attribute Ranges are stored in the following format
        //
        // 0      4    AttribId          The attribute id for this range
        // 4      4    FaceStart         The starting face
        // 8      4    FaceCount         The count of faces
        // 12     4    VertexStart       The starting vertex
        // 16     4    VertexCount       The count of vertices
        //
        //    Materials are stored one after another in the following format
        // 0      16   Diffuse color (Stored as RGBA as consecutive 32bit
        //             floats)
        // 16     16   Ambient color (Stored as RGBA as consecutive 32bit 
        //             floats)
        // 32     16   Specular color (Stored as RGBA as consecutive 32bit 
        //             floats)
        // 48     4    Power (32 bit float)
        // 52     4    Filename length in bytes
        // 56     (FilenameLength) Texture filename encoded as UTF-16.
        //
        //
        //

        /// <summary>
        /// A private contructor because this class should never be
        /// instantiated
        /// </summary>
        private MeshLoader() {}

        /// <summary>
        /// The magic number which is used to verify a file contains the 
        /// binary mesh format
        /// </summary>
        private static readonly int magicNumber = 0x27391874;

        /// <summary>
        /// The current version of this format
        /// </summary>
        private static readonly int versionNumber = 0x1000;

        /// <summary>
        ///  The size of header information in bytes for this format
        /// </summary>
        private static readonly int sizeofHeader = 52;

        /// <summary>
        ///  The size of the attribute range in bytes for this format
        /// </summary>
        private static readonly int sizeofAttributeRange = 20;

        /// <summary>
        /// The size of an encoded material excluding the variable length
        /// string. This size does include space for the value which encodes
        /// the string length though.
        /// </summary>
        private static readonly int sizeofMaterial = 56;

        /// <summary>
        /// The vertex format constants in md3dm for normal, diffuse,
        /// specular, and textureCountShift. Referencing VertexFormats.XXX
        /// doesn't work when linked against Micorosft.DirectX because the
        /// constants are different than those in md3dm.
        /// </summary>
        private static readonly int md3dmFvfNormal = 0x0008;
        private static readonly int md3dmFvfDiffuse = 0x0040;
        private static readonly int md3dmFvfSpecular = 0x0080;
        private static readonly int md3dmFvfTextureCountShift = 0x0008;

        /// <summary>
        /// Loads a mesh from the given stream
        /// </summary>
        /// <param name="device">A d3d mobile device which will be displaying
        /// the mesh</param>
        /// <param name="stream">The stream containing serialized mesh data
        /// </param>
        /// <param name="flags">Option flags</param>
        /// <param name="materials">Output array is filled with any needed 
        /// materials</param>
        /// <param name="textures">Output array is filled with the filenames
        /// of any needed textures</param>
        /// <returns></returns>
        public static Mesh LoadMesh(Device device, Stream stream, 
            MeshFlags flags, out Material [] materials, 
            out string [] textures)
        {
            if(device == null)
                throw new ArgumentException("Argument device was invalid");
            if(stream == null)
                throw new ArgumentException("Argument stream was invalid");

            byte [] rgb;
            byte [] rgbIb;
            byte [] rgbVb;
            Mesh meshRet;
            VertexBuffer vb;
            IndexBuffer ib;

            int fileMagicNumber;
            int fileVersion;
            VertexFormats flexibleVertexFormat;
            int numberVertices;
            int numberIndices;
            int is16BitIndices;
            int numberMaterials;
            int numberAttrRanges;
            int offsetVertex;
            int offsetIndices;
            int offsetAttrRange;
            int offsetMaterial;
            int bytesMaterials;
            int bytesIndices;


            int [] attributeTable;
            AttributeRange [] attributeRanges;

            rgb = new byte [512];

            stream.Seek(0, SeekOrigin.Begin);

            // Read header, any errors will be propagated up
            stream.Read(rgb, 0, sizeofHeader);

            // read and verify magic number
            fileMagicNumber = BitConverter.ToInt32(rgb, 0);
            if(fileMagicNumber != magicNumber)
                throw new MeshSerializationException(
                    "The serialized data does not represent a mesh");

            // read and verify version
            fileVersion = BitConverter.ToInt32(rgb, 4);
            if(fileVersion != versionNumber)
                throw new MeshSerializationException(
                    "The format version was not recognized");

            flexibleVertexFormat = (VertexFormats)
                BitConverter.ToInt32(rgb, 8);
            numberVertices = BitConverter.ToInt32(rgb, 12);  
            numberIndices = BitConverter.ToInt32(rgb, 16);
            is16BitIndices  = BitConverter.ToInt32(rgb, 20);
            numberMaterials = BitConverter.ToInt32(rgb, 24);
            numberAttrRanges = BitConverter.ToInt32(rgb, 28);
            offsetVertex = BitConverter.ToInt32(rgb, 32);
            offsetIndices = BitConverter.ToInt32(rgb, 36);
            offsetAttrRange = BitConverter.ToInt32(rgb, 40);
            offsetMaterial = BitConverter.ToInt32(rgb, 44);
            bytesMaterials = BitConverter.ToInt32(rgb, 48);

            // verify number of vertices
            if(numberVertices < 0)
                throw new MeshSerializationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Invalid number of  vertices: {0}", numberVertices));

            // verify number of indices
            if(numberIndices < 0 || numberIndices % 3 != 0)
                throw new MeshSerializationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Invalid number of indices: {0}", numberIndices));

            // verify number of materials
            if(numberMaterials < 0)
                throw new MeshSerializationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Invalid number of materials: {0}", numberMaterials));

            // verify number of attribute ranges
            if(numberAttrRanges < 0)
                throw new MeshSerializationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Invalid number of attribute ranges: {0}",
                    numberAttrRanges));

            // determine number of index bytes and verify Is16BitIndices
            if(is16BitIndices == 1)
                bytesIndices = numberIndices*2;
            else if(is16BitIndices == 0)
                bytesIndices = numberIndices*4;
            else
                throw new MeshSerializationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Invalid value for is16BitIndices: {0}",
                    is16BitIndices));
        
            // Managed Direct3D mobile uses different Fvf defines than
            // managed Direct3D for the desktop
            // when this code is linked against the desktop version
            // this will convert the Fvf to match MD3DM constants
            // when this code is linked against MD3DM this section will
            // not have changed anything.

            // determine the necessary Fvf
            int sourceFormat = (int)flexibleVertexFormat;
            int textureCount;
            flexibleVertexFormat = VertexFormats.Position;
    
            if((sourceFormat & md3dmFvfNormal) != 0)
                flexibleVertexFormat |= VertexFormats.Normal;
    
            if((sourceFormat & md3dmFvfDiffuse) != 0)
                flexibleVertexFormat |= VertexFormats.Diffuse;
    
            if ((sourceFormat & md3dmFvfSpecular) != 0)
                flexibleVertexFormat |= VertexFormats.Specular;
    
            // determine number of textures
            textureCount = (sourceFormat & 
                (int)VertexFormats.TextureCountMask)
                >> (int)md3dmFvfTextureCountShift;
    
            //limit to 4 textures
            if (textureCount > 4)
                textureCount = 4;
    
            // continue setting up necessary Fvf
            flexibleVertexFormat |= (VertexFormats)(
                textureCount << (int)VertexFormats.TextureCountShift);

            int bytesVertices = 
                VertexInformation.GetFormatSize(flexibleVertexFormat) *
                numberVertices;

            // Verify none of the data regions overlap
            // the material section is variable size so we can't check 
            // that one yet
            if(! ((offsetVertex >= sizeofHeader) &&
                (offsetIndices >= offsetVertex + bytesVertices) &&
                (offsetAttrRange >= offsetIndices + bytesIndices) &&
                (offsetMaterial >= offsetAttrRange + numberAttrRanges * 
                sizeofAttributeRange) &&
                (stream.Length >= offsetMaterial + bytesMaterials)))
                throw new MeshSerializationException(
                    "The data regions are not " +
                    "within the stream or overlap");

            // create our data tables
            materials = new Material[numberMaterials];
            textures = new string[numberMaterials];
            attributeRanges = new AttributeRange[numberAttrRanges];
            attributeTable = new int[numberIndices / 3];

            // move to the attribute range section, propagate up
            // any exception
            stream.Seek(offsetAttrRange, SeekOrigin.Begin);

            // parse attribute ranges
            for (int i = 0; i < numberAttrRanges; i++)
            {
                int attribId;
                int faceStart;
                int faceCount;
                int vertexStart;
                int vertexCount;

                // read in the attribute range data
                stream.Read(rgb, 0, sizeofAttributeRange);
                attribId = BitConverter.ToInt32(rgb, 0);
                faceStart = BitConverter.ToInt32(rgb, 4);
                faceCount = BitConverter.ToInt32(rgb, 8);
                vertexStart = BitConverter.ToInt32(rgb, 12);
                vertexCount = BitConverter.ToInt32(rgb, 16);


                // verify the data
                if( (vertexStart < 0 || vertexCount < 0 || 
                    vertexStart + vertexCount > numberVertices) ||
                    (faceStart < 0 || faceCount < 0 || 
                    (faceStart + faceCount)*3 > numberIndices))
                    throw new ApplicationException(
                        "Invalid attribute range");
            
                // store the validated data
                attributeRanges[i].AttributeId = attribId;
                attributeRanges[i].FaceStart = faceStart;
                attributeRanges[i].FaceCount = faceCount;
                attributeRanges[i].VertexStart = vertexStart;
                attributeRanges[i].VertexCount = vertexCount;
                for (int j = faceStart; j < faceStart + faceCount; j++)
                    attributeTable[j] = attribId;
            }

            // move to the material section
            stream.Seek(offsetMaterial, SeekOrigin.Begin);

            // parse materials
            for (int i = 0; i < numberMaterials; i++)
            {
                int cbTexture;

                // verify that we aren't reading past the end of the stream
                // its possible an invalid filename length the
                if(stream.Position + sizeofMaterial > stream.Length)
                    throw new MeshSerializationException(
                        "Material data region is" +
                        " corrupt");

                // read  in the material color data
                stream.Read(rgb, 0, sizeofMaterial);
                materials[i].DiffuseColor = new ColorValue(
                    BitConverter.ToSingle(rgb, 0), 
                    BitConverter.ToSingle(rgb, 4), 
                    BitConverter.ToSingle(rgb, 8),
                    BitConverter.ToSingle(rgb, 12));

                materials[i].AmbientColor = new ColorValue(
                    BitConverter.ToSingle(rgb, 16), 
                    BitConverter.ToSingle(rgb, 20), 
                    BitConverter.ToSingle(rgb, 24),
                    BitConverter.ToSingle(rgb, 28));

                materials[i].SpecularColor = new ColorValue(
                    BitConverter.ToSingle(rgb, 32), 
                    BitConverter.ToSingle(rgb, 36), 
                    BitConverter.ToSingle(rgb, 40),
                    BitConverter.ToSingle(rgb, 44));

                materials[i].SpecularSharpness = 
                    BitConverter.ToSingle(rgb, 48);

                // read in the size of the texture filename
                cbTexture = BitConverter.ToInt32(rgb, 52);

                // verify that the texture filename has a valid length
                if (cbTexture < 0 || stream.Position + cbTexture > 
                    stream.Length)
                    throw new MeshSerializationException(
                        "Material data region is corrupt");

                // read the texture filename
                if (cbTexture > 0)
                {
                    stream.Read(rgb, 0, cbTexture);
                    textures[i] = Encoding.Unicode.GetString(rgb, 0, 
                        cbTexture);
                }
            }

            // create data buffers
            rgbIb = new byte[bytesIndices];
            rgbVb = new byte[bytesVertices];

            // read in the index data
            stream.Seek(offsetIndices, SeekOrigin.Begin);
            stream.Read(rgbIb, 0, rgbIb.Length);

            // read in the vertex data
            stream.Seek(offsetVertex, SeekOrigin.Begin);
            stream.Read(rgbVb, 0, rgbVb.Length);

            // set the use 32 bit flag appropriately
            flags = (flags & ~(MeshFlags.Use32Bit)) | 
                ((is16BitIndices == 0) ? MeshFlags.Use32Bit : 0);

            // create a new empty mesh
            meshRet = new Mesh(numberIndices / 3, numberVertices,
                flags, flexibleVertexFormat, device);

            try
            {
                // create the index and vertex buffer
                vb = meshRet.VertexBuffer;
                ib = meshRet.IndexBuffer;
    
                // write the vertex data
                vb.Lock(0, bytesVertices, LockFlags.None).Write(rgbVb, 0, 
                    bytesVertices);
                vb.Unlock();
    
                // write the index data
                ib.Lock(0, rgbIb.Length, LockFlags.None).Write(rgbIb, 0,
                    rgbIb.Length);
                ib.Unlock();
    
                // set the attributes
                meshRet.LockAttributeBuffer(LockFlags.None);
                meshRet.UnlockAttributeBuffer(attributeTable);
                meshRet.SetAttributeTable(attributeRanges);
            }
            catch (DirectXException e)
            {
                // release the mesh if anything went wrong
                meshRet.Dispose();
                meshRet = null;
                throw e;
            }

            return(meshRet);
        }

        /// <summary>
        /// Saves a mesh to the custom serialized format
        /// </summary>
        /// <param name="stream">The stream to which to serialize</param>
        /// <param name="mesh">The mesh to be serialized</param>
        /// <param name="materials">The materials for subparts of the mesh
        /// </param>
        /// <param name="textures">The filenames for the textures on 
        /// subparts of the mesh</param>
        public static void SaveMesh(Stream stream, Mesh mesh, 
            Material [] materials, string [] textures)
        {
            int flexibleVertexFormat;
            int numberVertices;
            byte [] vertices;
            int numberIndices;
            byte [] indices;
            AttributeRange [] attributeRanges;
            VertexFormats sourceVertexFormat;
            VertexFormats sourceFormat;
            
            IDisposable tempMesh;

            tempMesh = null;

            try
            {
                // Managed Direct3D mobile uses different Fvf defines than
                // managed Direct3D for the desktop
                // when this code is linked against the desktop version
                // this will convert the Fvf to match MD3DM constants
                // when this code is linked against MD3DM this section will
                // not have changed anything.

                // determine the necessary Fvf
                sourceVertexFormat = mesh.VertexFormat;
                int textureCount;
                sourceFormat = VertexFormats.Position;
                flexibleVertexFormat = 0;
    
                if ((sourceVertexFormat & VertexFormats.Normal) != 0)
                {
                    flexibleVertexFormat |= md3dmFvfNormal;
                    sourceFormat |= VertexFormats.Normal;
                }
    
                if ((sourceVertexFormat & VertexFormats.Diffuse) != 0)
                {
                    flexibleVertexFormat |= md3dmFvfDiffuse;
                    sourceFormat |= VertexFormats.Diffuse;
                }
    
                if ((sourceVertexFormat & VertexFormats.Specular) != 0)
                {
                    flexibleVertexFormat |= md3dmFvfDiffuse;
                    sourceFormat |= VertexFormats.Specular;
                }
    
                // determine number of textures
                textureCount = (int)(sourceVertexFormat & 
                    VertexFormats.TextureCountMask) >> 
                    (int)VertexFormats.TextureCountShift;
    
                //limit to 4 textures
                if (textureCount > 4)
                    textureCount = 4;
    
                // continue setting up necessary fvf
                sourceFormat |= (VertexFormats)(textureCount << 
                    (int)VertexFormats.TextureCountShift);
                flexibleVertexFormat |= 
                    (textureCount << md3dmFvfTextureCountShift);
    
                if (sourceFormat != sourceVertexFormat)
                {
                    mesh = mesh.Clone(mesh.Options.Value, sourceFormat, 
                        mesh.Device);
                    tempMesh = (IDisposable)mesh;
                }

                attributeRanges = mesh.GetAttributeTable();
            
                if (attributeRanges == null)
                {
                    throw new MeshSerializationException(
                        "No Attribute table present");
                }
    
                // determine number of vertices and create buffer
                numberVertices = mesh.NumberVertices;
                vertices = new byte[numberVertices * 
                    VertexInformation.GetFormatSize(sourceFormat)];

                // copy vertices to buffer
                mesh.VertexBuffer.Lock(0, vertices.Length, 
                    LockFlags.None).Read(vertices, 0, vertices.Length);
                mesh.VertexBuffer.Unlock();

                // determine number of indices
                numberIndices = mesh.NumberFaces * 3;
            
                // create index data buffer
                indices = new byte[numberIndices * 
                    (mesh.Options.Use32Bit ? 4 : 2)];

                // fill index data into buffer
                mesh.IndexBuffer.Lock(0, indices.Length, 
                    LockFlags.None).Read(indices, 0, indices.Length);
                mesh.IndexBuffer.Unlock();

                // write the data out to file
                MeshLoader.SaveMeshData(stream, flexibleVertexFormat, 
                    numberVertices, vertices,
                    numberIndices, indices, attributeRanges, materials,
                    textures);
            }
            finally
            {
                if (tempMesh != null)
                {
                    tempMesh.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes mesh data to a custom format
        /// </summary>
        /// <param name="stream">The stream to which to serialize</param>
        /// <param name="flexibleVertexFormat">The Fvf of the vertex data
        /// </param>
        /// <param name="numberVertices">The number of vertices in the vertex
        /// data</param>
        /// <param name="vertices">The buffer of vertex data</param>
        /// <param name="numberIndices">The number of indices in the index
        /// data</param>
        /// <param name="indices">The buffer of index data</param>
        /// <param name="attributeRanges">The attribute ranges to
        /// serialize</param>
        /// <param name="materials">The materials for the mesh subparts
        /// </param>
        /// <param name="textures">The texture filenames for the mesh
        /// subparts</param>
        /// 
        public static void SaveMeshData(Stream stream, 
            int flexibleVertexFormat, int numberVertices,
            byte [] vertices, int numberIndices, 
            byte [] indices, AttributeRange [] attributeRanges, 
            Material [] materials, string [] textures)
        {

            if(numberIndices <= 0)
                throw new ArgumentException("NumberIndices <= 0");
            if(numberVertices <= 0)
                throw new ArgumentException("NumberVertices <= 0");

            // calculate the size of the vertex buffer
            int bytesVertices = vertices.Length;

            // verify 16 or 32 bit indices
            int bytesPerIndex = indices.Length / numberIndices;
            if ((bytesPerIndex != 2) && (bytesPerIndex != 4))
                throw new MeshSerializationException(
                    "Indices are neither 16 nor 32 bit");

            int is16BitIndices = (bytesPerIndex == 2) ? 1 : 0;

            // verify the same number of materials as texture names
            if (materials.Length != textures.Length)
                throw new MeshSerializationException(
                    "The number of textures must" +
                    " match the number of materials");

            // determine the number of materials and attribue ranges
            int numberMaterials = materials.Length;
            int numberAttrRanges = attributeRanges.Length;

            // determine the offsets
            int offsetVertex = sizeofHeader;
            int offsetIndices = offsetVertex + vertices.Length;
            int offsetAttrRange = offsetIndices + indices.Length;
            int offsetMaterial = offsetAttrRange + numberAttrRanges * 
                sizeofAttributeRange;

            // go to the beginning of the stream
            stream.Seek(0, SeekOrigin.Begin);

            // write the header
            stream.Write(BitConverter.GetBytes(magicNumber), 0, 4);
            stream.Write(BitConverter.GetBytes(versionNumber), 0, 4);
            stream.Write(BitConverter.GetBytes(flexibleVertexFormat), 0, 4);
            stream.Write(BitConverter.GetBytes(numberVertices), 0, 4);
            stream.Write(BitConverter.GetBytes(numberIndices), 0, 4);
            stream.Write(BitConverter.GetBytes(is16BitIndices), 0, 4);
            stream.Write(BitConverter.GetBytes(numberMaterials), 0, 4);
            stream.Write(BitConverter.GetBytes(numberAttrRanges), 0, 4);
            stream.Write(BitConverter.GetBytes(offsetVertex), 0, 4);
            stream.Write(BitConverter.GetBytes(offsetIndices), 0, 4);
            stream.Write(BitConverter.GetBytes(offsetAttrRange), 0, 4);
            stream.Write(BitConverter.GetBytes(offsetMaterial), 0, 4);
        
            // write a 0 length for BytesMaterials right now
            // the correct value will be filled in once it is known
            stream.Write(BitConverter.GetBytes(0), 0, 4); 

            // write the vertex and index information
            stream.Write(vertices, 0, vertices.Length);
            stream.Write(indices, 0, indices.Length);

            // write the attribute range information
            foreach (AttributeRange attr in attributeRanges)
            {
                stream.Write(BitConverter.GetBytes(attr.AttributeId), 0, 4);
                stream.Write(BitConverter.GetBytes(attr.FaceStart), 0, 4);
                stream.Write(BitConverter.GetBytes(attr.FaceCount), 0, 4);
                stream.Write(BitConverter.GetBytes(attr.VertexStart), 0, 4);
                stream.Write(BitConverter.GetBytes(attr.VertexCount), 0, 4);
            }

            // write the material information
            for (int i = 0; i < materials.Length; i++)
            {
                stream.Write(BitConverter.GetBytes(
                    materials[i].DiffuseColor.Red  ), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].DiffuseColor.Green), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].DiffuseColor.Blue ), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].DiffuseColor.Alpha), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].AmbientColor.Red  ), 0, 4);                  
                stream.Write(BitConverter.GetBytes(
                    materials[i].AmbientColor.Green), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].AmbientColor.Blue ), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].AmbientColor.Alpha), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].SpecularColor.Red  ), 0, 4); 
                stream.Write(BitConverter.GetBytes(
                    materials[i].SpecularColor.Green), 0, 4);
                stream.Write(BitConverter.GetBytes(
                    materials[i].SpecularColor.Blue ), 0, 4);
                stream.Write(BitConverter.GetBytes(
                    materials[i].SpecularColor.Alpha), 0, 4);
                stream.Write(BitConverter.GetBytes(
                    materials[i].SpecularSharpness), 0, 4);

                if (textures[i] != null)
                {
                    byte [] rgb = Encoding.Unicode.GetBytes(textures[i]);
                    stream.Write(BitConverter.GetBytes(rgb.Length), 0, 4);
                    stream.Write(rgb, 0, rgb.Length);
                }
                else
                    stream.Write(BitConverter.GetBytes((int)0), 0, 4);
            }

            // go back to fill in the length of the materials section
            long currentPosition = stream.Position;
            int bytesMaterials = (int)(stream.Position - offsetMaterial);
            stream.Seek((int)48, SeekOrigin.Begin);
            stream.Write(BitConverter.GetBytes(0), 0, 4);
            stream.Seek(currentPosition, SeekOrigin.Begin);
        }
    }
}
