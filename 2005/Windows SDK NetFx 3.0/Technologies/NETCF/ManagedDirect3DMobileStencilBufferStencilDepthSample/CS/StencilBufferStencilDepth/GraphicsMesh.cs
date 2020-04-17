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
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Text;
using System.Reflection;


namespace Microsoft.Samples.MD3DM
{

    /// <summary>
    /// A class for loading and displaying meshes
    /// </summary>
    class GraphicsMesh
    {
        // The rendering device
        Device device;

        // The mesh this class loads and renders
        Mesh meshValue = null;

        // Materials for our mesh
        Material[] meshMaterials; 
        
        // Textures for our mesh
        Texture[] meshTextures; 
        
        // The assembly which has the resources embedded
        Assembly embeddedResourceAssembly;
        
        // name of the mesh
        string meshName;

		// the name that must be prepended to filenames
		// in order to reference the resources from the
		// assembly
		string resourcePrefix;
        
        // the vertex format to load the mesh with
        VertexFormats vf;

        // true if a vertex format has been set
        bool vfSet = false;

        public Mesh Mesh
        {
            get { return meshValue; }
        }

        /// <summary>
        /// Creates a new mesh
        /// </summary>
        public void Create(Device device, string resourcePrefix,
			string filename, Assembly assembly)
        {
            this.device = device;
            embeddedResourceAssembly = assembly;
            this.meshName = filename;
			this.resourcePrefix = resourcePrefix;
        }

        /// <summary>
        /// Sets the desired vertex format for the mesh
        /// </summary>
        public void SetVertexFormat(VertexFormats format)
        {
            vf = format;
            vfSet = true;
        }

        /// <summary>
        /// The device exists, but may have just been Reset().  Resources
        /// and any other device state that persists during
        /// rendering should be set here.  Render states, matrices, textures,
        /// etc., that don't change during rendering can be set once here to
        /// avoid redundant state setting during Render() or FrameMove().
        /// </summary>
        public void RestoreDeviceObjects(object obj, EventArgs eventg)
        {
            string[] textureFilenames = null;

            meshValue = MeshLoader.LoadMesh(device, 
                embeddedResourceAssembly.GetManifestResourceStream(
				resourcePrefix + meshName), 
                MeshFlags.SystemMemory, out meshMaterials, 
                out textureFilenames);

            meshTextures  = new Texture[meshMaterials.Length];
            for( int i=0; i<meshMaterials.Length; i++ )
            {
                // Set the ambient color for the material 
                // (D3DX does not do this)
                meshMaterials[i].Ambient = meshMaterials[i].Diffuse;

                // Create the texture
                if (textureFilenames[i] != null)
                {
                    meshTextures[i] = TextureLoader.FromStream(device, 
                        embeddedResourceAssembly.GetManifestResourceStream(
                        resourcePrefix + textureFilenames[i]));
                }
            }
            
            // if the mesh was not loaded in the desired vertex format
            // it can be changed here
            if ((vf != meshValue.VertexFormat) && vfSet)
            {
                Mesh temp = meshValue.Clone(0, vf, meshValue.Device);
                meshValue.Dispose();
                meshValue = temp;
            }
        }
    
        /// <summary>
        /// Renders the mesh
        /// </summary>
        /// <param name="canDrawOpaque">Enables drawing opaque portions
        /// of the mesh</param>
        /// <param name="canDrawAlpha">Enables drawing alpha blended portions
        /// of the mesh</param>
        public void Render(bool canDrawOpaque, bool canDrawAlpha)
        {
            RenderStateManager rs = device.RenderState;
            // Frist, draw the subsets without alpha
            if (canDrawOpaque)
            {
                for( int i=0; i<meshMaterials.Length; i++ )
                {
                    if (canDrawAlpha)
                    {
                        if (meshMaterials[i].Diffuse.A < 0xff)
                            continue;
                    }
                    // Set the material and texture for this subset
                    device.Material = meshMaterials[i];

                    if( meshTextures[i] != null)
                        device.SetTexture(0, meshTextures[i]);

                    // Draw the mesh subset
                    meshValue.DrawSubset(i);
                }
            }

            // Then, draw the subsets with alpha
            if (canDrawAlpha)
            {
                // Enable alpha blending
                rs.AlphaBlendEnable = true;
                rs.SourceBlend = Blend.SourceAlpha;
                rs.DestinationBlend = Blend.InvSourceAlpha;
                for( int i=0; i<meshMaterials.Length; i++ )
                {
                    if (meshMaterials[i].Diffuse.A == 0xff)
                        continue;

                    // Set the material and texture for this subset
                    device.Material = meshMaterials[i];

                    if(meshTextures[i] != null)
                        device.SetTexture(0, meshTextures[i]);

                    // Draw the mesh subset
                    meshValue.DrawSubset(i);
                }
                // Restore state
                rs.AlphaBlendEnable = false;
            }
        }

        /// <summary>
        /// Renders the mesh
        /// </summary>
        public void Render()
        {
            this.Render(true, true);
        }
    }
}
