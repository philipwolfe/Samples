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

//----------------------------------------------------------------------------
// File: MeshConverter.cs
//
// Desc: This is a small command line utility for converting .x files into
//       a custom binary format used in this tutorial.
//
//----------------------------------------------------------------------------


using System;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Microsoft.Samples.MD3DM
{
    sealed public class MeshConverter
    {
        /// <summary>
        /// A private constructor prevents any instances of this class from
        /// being instantiated
        /// </summary>
        private MeshConverter() {}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) 
        {
            // the D3D render device
            Device device = null;

            // stores the materials and texture filenames for the mesh
            ExtendedMaterial [] exmat = null;

            // The D3D materials extracted from the mesh
            Material [] mat = null;

            // The texture filenames extracted from the mesh
            String [] tex = null;

            // the mesh to be converted
            Mesh mesh = null;

            // Some usage help if there are inappropriate command line 
            // arguments
            if(args.Length != 2)
            {
                System.Console.Write("Usage: MeshConverter <input_mesh> " +
                    "<output_mesh>\n" +
                    "This program converts .X files into a smaller " +
                    "binary format\n");
                return;
            }

            try
            {
                // create the D3D device
                PresentParameters presentParams = new PresentParameters();
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.Windowed = true;
                device = new Device(0, DeviceType.NullReference, new Form(),
                    CreateFlags.SoftwareVertexProcessing, presentParams);
            }
            catch(Exception e)
            {
                // handle any errors
                System.Console.WriteLine(
                    String.Format(CultureInfo.CurrentCulture,
                    "Error initializing D3D: {0}", e.Message));
                return;
            }

            // load the mesh
            try
            {
                mesh = Mesh.FromFile(args[0], MeshFlags.Dynamic, device,
                    out exmat);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(
                    String.Format(CultureInfo.CurrentCulture,
                    "Error loading the mesh: {0}", e.Message));
                return;
            }

            try
            {
                // optimize the mesh
                GraphicsStream gx = null;
                mesh.OptimizeInPlace(MeshFlags.OptimizeDeviceIndependent |
                    MeshFlags.OptimizeAttributeSort |
                    MeshFlags.OptimizeCompact, gx);

                // extract the materials and texture filenames
                mat = new Material[exmat.Length];
                tex = new string[exmat.Length];
                          
                for (int i = 0; i < exmat.Length; i++)
                {
                    mat[i] = exmat[i].Material3D;
                    tex[i] = exmat[i].TextureFilename;
                }
            }
            catch(Exception e)
            {
                // handle any errors
                System.Console.WriteLine(
                    String.Format(CultureInfo.CurrentCulture,
                    "Error optimizing the mesh: {0}", e.Message));
            }

            try
            {
                // save the mesh
                FileStream fstream = new FileStream(args[1], FileMode.Create);
                MeshLoader.SaveMesh(fstream, mesh, mat, tex);
                fstream.Close();
            }
            catch(Exception e)
            {
                // handle any errors
                System.Console.WriteLine(
                    String.Format(CultureInfo.CurrentCulture,
                    "Error saving the mesh: {0}", e.Message));
            }
        }
    }
}

