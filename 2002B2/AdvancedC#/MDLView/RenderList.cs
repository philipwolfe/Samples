namespace MdlView
{
	using System;
	using System.Collections;

	/// <summary>
	/// Stores plain old two-dimensional cartesian points
	/// </summary>
	internal struct CartesianXY
	{
		internal int x;
		internal int y;
	}

	/// <summary>
	/// Structure that describes the face of a triangle
	/// </summary>
	internal struct Face
	{
		internal CartesianXY[] triVerts;
		internal CartesianXY[] skinVerts;
	}

	/// <summary>
	/// Structure that associates a texture map with a particular triangle
	/// </summary>
	internal struct TextureMapData
	{
		internal int mapIndex;
		internal Face face;
	}

	/// <summary>
	/// Structure that completely describes a single 'node' (triangle) that needs to be rendered
	/// </summary>
	internal struct RenderNode
	{
		internal enumRenderingMode ShadeType;
		internal int ZCenter;
		internal TextureMapData Data;
	}

	/// <summary>
	/// Structure that holds information about a texture
	/// </summary>
	internal struct TextureMapInfo
	{
		internal byte[] TextureMap;
		internal int TextureWidth;
		internal int paletteIndex;
	}

	/// <summary>
	/// Render list class that descends from the generic object list
	/// </summary>
	public class RenderList: ArrayList
	{
		public int ViewingDistance;
		public Position ViewerPos;
		public Position ViewerAngle;
		private int numberOfTextures;
		internal TextureMapInfo[] TextureMapList;

		/// <summary>
		/// Empty the list so that we can start adding again!
		/// </summary>
		public void Empty()
		{
			numberOfTextures = 0;
			this.Clear();
		}

		/// <summary>
		/// Constructor for the list, just allocates memory for the texture maps
		/// </summary>
		public RenderList()
		{
			// 20 is probably a bit of an overkill
			TextureMapList = new TextureMapInfo[20];
		}

		/// <summary>
		/// Add a texture that can be referenced from a triangle (mapIndex)
		/// </summary>
		/// <param name="newTexture">Information about the texture (the width, the actual bytes!)</param>
		internal void addTexture(TextureMapInfo newTexture)
		{
			TextureMapList[numberOfTextures++] = newTexture;
		}

		/// <summary>
		/// Returns the number of textures that have been added
		/// </summary>
		public int textureCount()
		{
			return numberOfTextures;
		}

		/// <summary>
		/// Quick sorts triangles based on average z depth
		/// </summary>
		/// <param name="Bottom">Bottom index</param>
		/// <param name="Top">Top index</param>
		private void QSortList(int Bottom, int Top)
		{
			int Index1;
			int Index2;
			int Pivot;
			object TempObject;

			do
			{
				Index1 = Bottom;
				Index2 = Top;
				Pivot = ((RenderNode)this[(Bottom + Top) >> 1]).ZCenter;
				do 
				{
					while(((RenderNode)this[Index1]).ZCenter > Pivot)
						Index1++;
					while(((RenderNode)this[Index2]).ZCenter < Pivot)
						Index2--;
					if (Index1 <= Index2)
					{
						TempObject = this[Index1];
						this[Index1] = this[Index2];
						this[Index2] = TempObject;
						Index1++;
						Index2--;
					}
				} while (Index1 <= Index2);
				if (Bottom < Index2)
					QSortList(Bottom, Index2);
				Bottom = Index1;
			} while (Index1 < Top);
		}

		/// <summary>
		/// Draw all of the triangles onto the specified DirectDrawSurface
		/// </summary>
		/// <param name="DDPtr">The address of the surface</param>
		public void DisplayAll(int DDPtr)
		{
			int listOffset;
			RenderNode renderNode;
			Face WireframeInfo;
			TextureMapInfo textureMapInfo;

			if (this.Count == 0) 
				return;

			// Sort the triangles into the correct order 
			QSortList(0, this.Count - 1);

			// Iterate over the list of triangles and draw them appropriately
			for (listOffset = 0; listOffset < this.Count; listOffset++)
			{
				renderNode = (RenderNode)this[listOffset];

				switch (renderNode.ShadeType)
				{
					// Use the graphics object to draw a textured triangle
					case enumRenderingMode.TextureMap:
					{
						textureMapInfo = TextureMapList[((TextureMapData)renderNode.Data).mapIndex];
						MainFrm.graphicsObject.paletteIndex = textureMapInfo.paletteIndex;

						MainFrm.graphicsObject.DrawTexTriangle(
							DDPtr, 
							textureMapInfo.TextureMap, 
							textureMapInfo.TextureWidth, 
							((TextureMapData)renderNode.Data).face);
					}
					break;

					// Draw the edges of the triangle
					case enumRenderingMode.WireFrame:
					{
						WireframeInfo = ((TextureMapData)renderNode.Data).face;

						MainFrm.graphicsObject.LineDraw(WireframeInfo.triVerts[0].x,
							WireframeInfo.triVerts[0].y, WireframeInfo.triVerts[1].x,
							WireframeInfo.triVerts[1].y, MainFrm.wireframeColor, DDPtr);

						MainFrm.graphicsObject.LineDraw(WireframeInfo.triVerts[1].x,
							WireframeInfo.triVerts[1].y, WireframeInfo.triVerts[2].x,
							WireframeInfo.triVerts[2].y, MainFrm.wireframeColor, DDPtr);

						MainFrm.graphicsObject.LineDraw(WireframeInfo.triVerts[2].x,
							WireframeInfo.triVerts[2].y, WireframeInfo.triVerts[0].x,
							WireframeInfo.triVerts[0].y, MainFrm.wireframeColor, DDPtr);
					}
					break;
				}
			}
		}
	}
}
