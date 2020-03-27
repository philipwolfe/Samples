namespace MdlView
{
	using System;

	/// <summary>
	/// Contains information for a mesh (there is only one mesh per .mdl file for Quake I & II files)
	/// </summary>
	internal class Mesh
	{
		// An array that holds the intrim 'world coords' (verticies after local rotation, before global rotation)
		internal Vector[] worldCoords;
		// An array that holds the intrim 'camera coords' (verticies after global rotation, but before projection)
		internal Vector[] cameraCoords;
		// An array that identifies whether a given vertex should be rotated (only rotates the ones that can be seen)
		internal byte[] rotateList;
		
		// We use these to put the model near the center of the viewing window
		internal static int HalfScreenX;
		internal static int HalfScreenY;
		internal MeshHeader meshHeader;
		// A list of vertices that are offsets onto the loaded skin
		internal SkinVerts[] SkinVertices;
		// A list of triangles that connect the vertices
		internal SkinTris[] SkinTriangles;
		// The animation frames!
		internal FrameNodes[] Frames;
		internal Skin skin;
		Matrix Rotate;
		// The current scale
		float scaleFactor;
		// The models position in our 'world'
		Position worldPos;
		private int fCurrentFrame;

		/// <summary>
		/// Constructor for the mesh; allocates memory for the header
		/// </summary>
		public Mesh()
		{
			meshHeader = new MeshHeader();
			fCurrentFrame = 0;
		}

		/// <summary>
		/// Property that gets and sets the (absolute) current frame of the mesh
		/// </summary>
		public int CurrentFrame
		{
			get
			{
				return fCurrentFrame;
			}
			set
			{
				// Make sure that it's an actual frame
				if (fCurrentFrame >= (meshHeader.NumFrames - 1))
				{
					fCurrentFrame = 0;
				}
				else	
					fCurrentFrame = value;
			}
		}

		/// <summary>
		/// Adds a mesh to the 'world' list that contains all triangles that need to be sorted and rendered
		/// </summary>
		/// <param name="WorldList">A list that contains all triangles that need to be sorted and rendered</param>
		/// <param name="renderType">The current rendering type (wireframe or texutre map)</param>
		/// <param name="TransX">The 'screen' x offset (in screen coords, not world or camera)</param>
		/// <param name="TransY">The 'screen' y offset (in screen coords, not world or camera)</param>
		/// <param name="GlobalView">A matrix that contains the 'camera' rotations</param>
		/// <param name="SkinWidth">The width of the selected skin</param>
		/// <param name="objectViewer">A vector that contains the viewer (rotated in the oppisite direction of the model)</param>
		internal void AddMeshToList(ref RenderList WorldList, enumRenderingMode renderType, int TransX, int TransY, Matrix GlobalView, int SkinWidth, Vector objectViewer)
		{
			int count;
			int NumberRotated;
			Position rotation;
			TextureMapData TextureInfo;
			TextureMapInfo textureMapInfo;
			// Basically we fill this structure and add it to the world list
			RenderNode renderNode;
			int[] MarkedList;

			NumberRotated = 0;
			MarkedList = new int[meshHeader.NumTris];			
			if (renderType != enumRenderingMode.WireFrame)
			{
				// Set rotate list to 0 (if rotatelist[index] = 0, that means that vertex doesn't need to be rotated).
				for (count = 0; count < meshHeader.NumVerts; count++)
					rotateList[count] = 0;
				// Check to see if viewer can see triangle
				for (count = 0; count < meshHeader.NumTris; count++)
				{
					// The dot (inner) product of two vectors can be used to calculate the angle between 
					// those vectors.  We can actually simplify this formula, because all we're really interested
					// in is the sign (positive or negative) of the product.  That'll tell us if we can see the 
					// triangle or not (if it's normal is perpendicular to object viewer).
					if (Model.DotProduct(objectViewer, Frames[fCurrentFrame].normalList[count]) >= -0.001)
					{   
						// This might be clearer if the DotProduct returned 0 exactly.  It should really be >=0 if we 
						// can see the triangle.  However, we use floats and the percision can be slightly off.  It's
						// possible to get more triangles removed with a slightly lower # (-0.0005 for instance), but 
						// it's also possible to start losing triangles you're supposed to see =-)  Play around with it.
						rotateList[SkinTriangles[count].VerticesX] = 1;
						rotateList[SkinTriangles[count].VerticesY] = 1;
						rotateList[SkinTriangles[count].VerticesZ] = 1;
						MarkedList[NumberRotated] = count;
						NumberRotated++;
					}
				}
			}
			else
			{
				// If we're rendernig wireframe we want to draw all of the lines
				for (count = 0; count < meshHeader.NumVerts; count++)
					rotateList[count] = 1;
				for (count = 0; count < meshHeader.NumTris; count++)
					MarkedList[count] = count;
				NumberRotated = meshHeader.NumTris;
			}
			// Rotate all the visible vetices
			RotateMesh();
			// Convert the world coords to camera coords (basically orient the model based on the camera)
			WorldToCamera(GlobalView);
			textureMapInfo.TextureMap = skin.SkinNode;
			textureMapInfo.TextureWidth = SkinWidth;
			textureMapInfo.paletteIndex = skin.paletteIndex;
			WorldList.addTexture(textureMapInfo);
			for (count = 0; count < NumberRotated; count++)
			{
				// Make a new node that we'll have to render
				renderNode = new RenderNode();
				renderNode.ShadeType = renderType;
				renderNode.ZCenter = (int)((cameraCoords[SkinTriangles[MarkedList[count]].VerticesX].y 
					+ cameraCoords[SkinTriangles[MarkedList[count]].VerticesY].y
					+ cameraCoords[SkinTriangles[MarkedList[count]].VerticesZ].y) / 3);
				TextureInfo = new TextureMapData();
				TextureInfo.face = new Face();
				TextureInfo.face.skinVerts = new CartesianXY[3];
				TextureInfo.face.triVerts = new CartesianXY[3];
				TextureInfo.mapIndex = WorldList.textureCount() - 1;
				// Start populating the screen triangle information
				TextureInfo.face.triVerts[0].x = (int)(HalfScreenX +
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesX].x *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesX].y)
					+ TransX;
				TextureInfo.face.triVerts[1].x = (int)(HalfScreenX +
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesY].x *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesY].y)
					+ TransX;
				TextureInfo.face.triVerts[2].x = (int)(HalfScreenX +
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesZ].x *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesZ].y)
					+ TransX;
				TextureInfo.face.triVerts[0].y = (int)(HalfScreenY -
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesX].z *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesX].y)
					+ TransY;
				TextureInfo.face.triVerts[1].y = (int)(HalfScreenY -
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesY].z *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesY].y)
					+ TransY;
				TextureInfo.face.triVerts[2].y = (int)(HalfScreenY -
					cameraCoords[SkinTriangles[MarkedList[count]].VerticesZ].z *
					WorldList.ViewingDistance / cameraCoords[SkinTriangles[MarkedList[count]].VerticesZ].y)
					+ TransY;
				TextureInfo.face.skinVerts[0].x = SkinVertices[SkinTriangles[MarkedList[count]].texIndexX].S;
				TextureInfo.face.skinVerts[1].x = SkinVertices[SkinTriangles[MarkedList[count]].texIndexY].S;
				TextureInfo.face.skinVerts[2].x = SkinVertices[SkinTriangles[MarkedList[count]].texIndexZ].S;
				TextureInfo.face.skinVerts[0].y = SkinVertices[SkinTriangles[MarkedList[count]].texIndexX].T;
				TextureInfo.face.skinVerts[1].y = SkinVertices[SkinTriangles[MarkedList[count]].texIndexY].T;
				TextureInfo.face.skinVerts[2].y = SkinVertices[SkinTriangles[MarkedList[count]].texIndexZ].T;
				// The following is only used in Quake I models
				if (SkinTriangles[MarkedList[count]].FacesFront == 0) 
				{
					if (SkinVertices[SkinTriangles[MarkedList[count]].texIndexX].OnSeam != 0)
						TextureInfo.face.skinVerts[0].x += SkinWidth / 2;
					if (SkinVertices[SkinTriangles[MarkedList[count]].texIndexY].OnSeam != 0)
						TextureInfo.face.skinVerts[1].x += SkinWidth / 2;
					if (SkinVertices[SkinTriangles[MarkedList[count]].texIndexZ].OnSeam != 0)
						TextureInfo.face.skinVerts[2].x += SkinWidth / 2;
				}
				renderNode.Data = TextureInfo;
				// Add it to the list!
				WorldList.Add(renderNode);
			}
		}

		/// <summary>
		/// Sets the local rotation, scale, and world position information
		/// </summary>
		/// <param name="Rotate">The pre-calculated rotation matrix</param>
		/// <param name="scaleFactor">The scale of the model</param>
		/// <param name="worldPos">The world position (translation) of the model</param>
		internal void setRotateMesh(Matrix Rotate, float scaleFactor, Position worldPos)
		{
			this.Rotate = Rotate;
			this.scaleFactor = scaleFactor;
			this.worldPos = worldPos;
		}

		/// <summary>
		/// Converts the vertices to world coordinates by scaling, rotating, and translating them
		/// </summary>
		internal void RotateMesh()
		{
			Vector result = new Vector();
			TriVertex[] FramePtr = Frames[fCurrentFrame].FrameData;
			int Index;

			if (Rotate.AllOnes)
			{
				for (Index = 0; Index < meshHeader.NumVerts; Index++)
				{
					if (rotateList[Index] == 1) 
					{
						worldCoords[Index].x = FramePtr[Index].points.x * scaleFactor + worldPos.X;
						worldCoords[Index].y = FramePtr[Index].points.y * scaleFactor + worldPos.Y;
						worldCoords[Index].z = FramePtr[Index].points.z * scaleFactor + worldPos.Z;
					}
				}
			}
			else
			{
				for (Index = 0; Index < meshHeader.NumVerts; Index++)
				{
					if (rotateList[Index] == 1) {

						result.x = FramePtr[Index].points.x * scaleFactor * Rotate[0, 0] +
							FramePtr[Index].points.y * scaleFactor * Rotate[1, 0] +
							FramePtr[Index].points.z * scaleFactor * Rotate[2, 0];

						result.y = FramePtr[Index].points.x * scaleFactor * Rotate[0, 1] +
							FramePtr[Index].points.y * scaleFactor * Rotate[1, 1] +
							FramePtr[Index].points.z * scaleFactor * Rotate[2, 1];

						result.z = FramePtr[Index].points.x * scaleFactor * Rotate[0, 2] +
							FramePtr[Index].points.y * scaleFactor * Rotate[1, 2] +
							FramePtr[Index].points.z * scaleFactor * Rotate[2, 2];

						worldCoords[Index].x = result.x + worldPos.X;
						worldCoords[Index].y = result.y + worldPos.Y;
						worldCoords[Index].z = result.z + worldPos.Z;
					}
				}
			}
		}

		/// <summary>
		/// Converts the world coordinates to camera coordinates by applying the global transformation (add viewer orientation)
		/// </summary>
		/// <param name="GlobalView">A pre-calculated matrix of user orientation</param>
		protected internal void WorldToCamera(Matrix GlobalView)
		{
			for (int vertCount = 0; vertCount < meshHeader.NumVerts; vertCount++)
			{
				if (rotateList[vertCount] == 1)
				{
					cameraCoords[vertCount].x = worldCoords[vertCount].x * GlobalView[0, 0] +
						worldCoords[vertCount].y * GlobalView[1, 0] +
						worldCoords[vertCount].z * GlobalView[2, 0] + 
						GlobalView[3, 0];

					cameraCoords[vertCount].y = worldCoords[vertCount].x * GlobalView[0, 1] +
						worldCoords[vertCount].y * GlobalView[1, 1] + 
						worldCoords[vertCount].z * GlobalView[2, 1] +
						GlobalView[3, 1];

					cameraCoords[vertCount].z = worldCoords[vertCount].x * GlobalView[0, 2] +
						worldCoords[vertCount].y * GlobalView[1, 2] +
						worldCoords[vertCount].z * GlobalView[2, 2] +
						GlobalView[3, 2];
				}
			}
		}
	}
}
