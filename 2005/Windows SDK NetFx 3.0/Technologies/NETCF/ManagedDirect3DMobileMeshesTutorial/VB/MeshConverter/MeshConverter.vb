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
' File: MeshConverter.vb
'
' Desc: This is a small command line utility for converting .x files into
'       a custom binary format used in this tutorial.
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'-----------------------------------------------------------------------------

Imports System
Imports System.IO
Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.Text
Imports System.Windows.Forms
Imports System.Globalization

Namespace Microsoft.Samples.MD3DM

    Public NotInheritable Class MeshConverter
        
        ' A private constructor prevents ny instances of this class
        ' from being instantiated
        Private Sub New()
        End Sub

        ' The main entry point for the application.
        Shared Sub Main(ByVal args() As String) 
            ' the D3D render device
            Dim device As Device = Nothing
            
            ' stores the materials and texture filenames for the mesh
            Dim exmat As ExtendedMaterial() = Nothing
            
            ' The D3D materials extracted from the mesh
            Dim mat As Material() = Nothing
            
            ' The texture filenames extracted from the mesh
            Dim tex As String() = Nothing
            
            ' the mesh to be converted
            Dim convertMesh As Mesh = Nothing
            
            ' Some usage help if there are inappropriate command
            ' line arguments
            If args.Length <> 2 Then
                System.Console.Write( _
                "Usage: MeshConverter <input_mesh> <output_mesh>" + vbLf + _
                "This program converts .X files into a smaller " + _
                "binary format" + vbLf)
            End If

            Try
                ' create the D3D device
                Dim presentParams As New PresentParameters()
                presentParams.SwapEffect = SwapEffect.Discard
                presentParams.Windowed = True
                device = New Device(0, DeviceType.NullReference, _
                    New Form(), CreateFlags.SoftwareVertexProcessing, _
                    presentParams)
            Catch e As Exception
                ' handle any errors
                System.Console.WriteLine( _
                    String.Format( CultureInfo.CurrentCulture, _
                    "Error initializing D3D: {0}", e.Message))
                Return
            End Try
            
            ' load the mesh
            Try
                convertMesh = Mesh.FromFile(args(0), MeshFlags.Dynamic, _
                    device, exmat)
            Catch e As Exception
                System.Console.WriteLine( _
                    String.Format( CultureInfo.CurrentCulture, _
                    "Error loading the mesh: {0}", e.Message))
                Return
            End Try

            Try
                ' optimize the mesh
                Dim gx As GraphicsStream = Nothing
                convertMesh.OptimizeInPlace( _
                    MeshFlags.OptimizeDeviceIndependent Or _
                    MeshFlags.OptimizeAttributeSort Or _
                    MeshFlags.OptimizeCompact, gx)
                
                ' extract the materials and texture filenames
                mat = New Material(exmat.Length-1) {}
                tex = New String(exmat.Length-1) {}
                
                Dim i As Integer
                For i = 0 To exmat.Length-1
                    mat(i) = exmat(i).Material3D
                    tex(i) = exmat(i).TextureFilename
                Next i
            Catch e As Exception
                ' handle any errors
                System.Console.WriteLine( _
                    String.Format( CultureInfo.CurrentCulture, _
                    "Error optimizing the mesh: {0}", e.Message))
            End Try
            
            ' save the mesh
            Dim fstream As New FileStream(args(1), FileMode.Create)
            MeshLoader.SaveMesh(fstream, convertMesh, mat, tex)
            fstream.Close()

        
        End Sub 'Main
    End Class 'MeshConverter
End Namespace