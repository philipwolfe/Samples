using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Tao.OpenGl;
using System.Collections;
using System.IO;


namespace General
{


	public interface ISolutionManager
	{

		void InitRemote(Parameters p);

		Solution GetSolution(byte[,,] chromosome, int name, int mom, int dad, string machineName);
	
	}

	[Serializable]
	public class Load 
	{

		public Load(float alongX, float alongY, float alongZ) 
		{
			
			this.alongX = alongX;
			this.alongY = alongY;
			this.alongZ = alongZ;

		}

		public float alongX;
		public float alongY;
		public float alongZ;

	}

	[Serializable]
	public class Support 
	{

		public Support(bool fixedAlongX, bool fixedAlongY, bool fixedAlongZ) 
		{
			
			this.fixedAlongX = fixedAlongX;
			this.fixedAlongY = fixedAlongY;
			this.fixedAlongZ = fixedAlongZ;

			belongToSolid = false;

		}

		public bool	fixedAlongX;
		public bool	fixedAlongY;
		public bool	fixedAlongZ;

		public bool belongToSolid;

	}

	[Serializable]
	public struct CellStatus 
	{
		public bool voidCell;
		public bool solidCell;
		public sbyte forceMat;

	}

	[Serializable]
	public class Parameters 
	{

		public Parameters (){}

		public byte  loadcases;
		public float elementSize;

		public int pointsAlongX;				
		public int pointsAlongY;				
		public int pointsAlongZ;	

		public Support[,,] supports;
		public Load[][,,] loads;

		public bool[,,] restrained;
		public bool[][,,] loaded;

		public CellStatus[,,] domain;

		public Material[] materials;

		public float cgError;

		public float desiredFOS;
		public float penaltyFactor;

		public bool loadedOnX;
		public bool loadedOnY;
		public bool loadedOnZ;

		public int minHoleSize;

	}

	public enum RenderType 
	{
		stressLevel, fos, materialDistribution

	}

	//	public delegate void Delegate2(int x, int y, int z, params object[] pList);

	[Serializable]
	public class Solution
	{

		[NonSerialized] public byte  activeLoadcase;

		[NonSerialized] public int   cellsAlongX;				
		[NonSerialized] public int   cellsAlongY;				
		[NonSerialized] public int   cellsAlongZ;	
		[NonSerialized] public		 RenderType displayMode;
		[NonSerialized] public float elSize;

		static byte dof = 3;

		public int name, mom, dad;
		public string machineName;

		public float cost;
			
		public float weight;
		public float surfaceArea;

		public byte[,,] weights;
		public byte[,,] chromosome;
	
		public float[] maxDispl;
		public float[] maxFOS;
		public float[] minFOS;

		public int[,,] nodes;
		public int[,,] elements;
		public float[][] unknowns;
		public float[][,,] FOS;

		public string reason;
		public TimeSpan totalTime;
		public int reqMemory;


		int pointsPerRow;
		int pointsPerLayer;
		ArrayList faces;
		ArrayList edges;

		
		public Solution ()
		{

			faces = new ArrayList();
			edges = new ArrayList();
		
		}

		public bool IsValid() 
		{

			return (nodes != null);

		}

		public void CopyTo(ref Solution s) 
		{

			s.cost		  = cost;
			s.name		  = name;
			s.mom		  = mom;
			s.dad		  = dad;
			s.machineName = machineName;

			s.weight	  = weight;
			s.surfaceArea = surfaceArea;

			s.reason	  = reason;
			s.totalTime	  = totalTime;
			s.reqMemory	  = reqMemory;

			s.chromosome  = (byte[,,]) chromosome.Clone();

			if (IsValid()) 
			{

				s.weights     = (byte[,,])		weights.Clone();

				s.maxDispl    = (float[])		maxDispl.Clone();
				s.maxFOS      = (float[])		maxFOS.Clone();
				s.minFOS      = (float[])		minFOS.Clone();

				s.nodes	      = (int[,,])		nodes.Clone();
				s.unknowns    = (float[][])		unknowns.Clone();
				s.elements    = (int[,,])		elements.Clone();

				s.FOS	      = (float[][,,])	FOS.Clone();

			}



		}

		public void Fill(int pointsPerRow, int pointsPerLayer, float[][] vertices, ArrayList materials, byte strOffset, byte fosOffset, byte matOffset) 
		{

			faces.Clear();
			edges.Clear();

			this.pointsPerRow   = pointsPerRow;
			this.pointsPerLayer = pointsPerLayer;

			for (int z = 0; z < cellsAlongZ; z++) 

				for (int y = 0; y < cellsAlongY; y++) 

					for (int x = 0; x < cellsAlongX; x++) 
					{

						#region not calculated individual drawing handling

						bool isSolid = false;

						if (IsValid())

							isSolid = IsSolid(x,y,z);

						else

							isSolid = ((Material) materials[chromosome[x,y,z]]).Density != 0.0;

						#endregion

						if (isSolid) 
						{

							#region faces

						

							Face toAdd;

							// Bottom
							toAdd = new Face((x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer,
								(x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);

							}

							// Front
							toAdd = new Face((x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer,
								(x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);							

							}

							// Left
							toAdd = new Face((x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer,
								(x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);

							}

							// Right
							toAdd = new Face((x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer,
								(x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);

							}

							// Back
							toAdd = new Face((x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, 
								(x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer,
								(x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);

							}

							// Top
							toAdd = new Face((x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, 
								(x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, 
								(x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer,
								(x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, GetColor(x,y,z, 0, materials, strOffset, fosOffset, matOffset));

							if (toAdd.IsOnSurface(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd.CalcCentroid(vertices);

								if (faces.Contains(toAdd))

									faces.Remove(toAdd);

								else

									faces.Add(toAdd);

							}

							#endregion

							#region edges

						

							Edge toAdd1;
							
							// Bottom 1
							toAdd1 = new Edge((x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, (x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
								 
							}
							// Bottom 2
							toAdd1 = new Edge((x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, (x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
								 
							}
							// Bottom 3
							toAdd1 = new Edge((x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, (x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
								 
							}
							// Bottom 4
							toAdd1 = new Edge((x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, (x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
								 
							}
							// Top 1
							toAdd1 = new Edge((x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, (x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
							}
							// Top 2
							toAdd1 = new Edge((x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, (x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
							}
							// Top 3
							toAdd1 = new Edge((x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, (x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);
							}
							// Top 4
							toAdd1 = new Edge((x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, (x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);

							}

							// Front 2
							toAdd1 = new Edge((x+1)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer, (x+1)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);

							}
							// Front 4
							toAdd1 = new Edge((x+0)+(y+0)*pointsPerRow+(z+1)*pointsPerLayer, (x+0)+(y+0)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);

							}
							// Back 2
							toAdd1 = new Edge((x+0)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer, (x+0)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);

							}
							// Back 4
							toAdd1 = new Edge((x+1)+(y+1)*pointsPerRow+(z+1)*pointsPerLayer, (x+1)+(y+1)*pointsPerRow+(z+0)*pointsPerLayer);

							if (toAdd1.IsOnBorder(weights, pointsPerRow, pointsPerLayer)) 
							{

								toAdd1.CalcCentroid(vertices);

								if (edges.Contains(toAdd1))

									edges.Remove(toAdd1);

								else

									edges.Add(toAdd1);

							}

						

							#endregion
					
						}

					}

		}


		public void Draw(bool showEdges, float[][] vertices, byte loadcase, float scaleFactor, float dAmplFactor, Color[] colorTable) 
		{
Console.WriteLine("Solution Draw");
	//		if (unknowns == null || unknowns[loadcase] == null)

	//			return;

			Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
			Gl.glPolygonOffset(1f, 1f);
            
			foreach(Face face in faces) 

				face.Draw(vertices, nodes, unknowns, loadcase, scaleFactor, dAmplFactor, pointsPerRow, pointsPerLayer, colorTable);
				
			Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
			Gl.glDisable(Gl.GL_LIGHTING);

			Gl.glColor3ub(0, 0, 0);
			Gl.glLineWidth(1.5f);

	
			if (showEdges)

				foreach(Edge edge in edges) 

					edge.Draw(vertices, nodes, unknowns, loadcase, scaleFactor, dAmplFactor, dof, pointsPerRow, pointsPerLayer);

			Gl.glEnable(Gl.GL_LIGHTING);
			Gl.glLineWidth(1.0f);
		}

		public void WriteEdges(float[][] vertices, float scaleFactor, TextWriter tw, byte color) 
		{

			foreach(Edge edge in edges) 

				edge.WriteLine(vertices, scaleFactor, dof, tw, color);


		}

		public void FillIgesEntitiesArray(ArrayList igesEntities, float[][] vertices, byte loadcase, TextWriter tw, ref int entCount, ref int rowCount) 
		{

			foreach(Face face in faces) 

				igesEntities.Add(face.GetIgesEntity(vertices, loadcase, pointsPerRow, pointsPerLayer));


		}

		
		public void WriteSTLFaces(float[][] vertices, TextWriter tw) 
		{

			foreach(Face face in faces) 

				face.WriteSTL(vertices, tw);


		}

		public Color GetColor(int x, int y, int z, byte loadcase, ArrayList materials, byte strOffset, byte fosOffset, byte matOffset) 
		{

			byte faceColor = 0;

			Color c = Color.White;

			byte matID = chromosome[x,y,z];

			Material mat = (Material) materials[chromosome[x,y,z]];
			
			float step;
			float percentUsed;

			float mpa = 0;

			if (FOS != null && FOS[loadcase] != null)
			{

				// mpa = 250 / 2;
				mpa =  (float) mat.tensYield / FOS[loadcase][x,y,z];
				percentUsed = 100 * ((float) mat.tensYield / FOS[loadcase][x,y,z]) / (float) mat.tensYield;
			}
		//	else 
				
		//		return faceColor;


			#region gradient definition


			switch(displayMode) 
			{

				case RenderType.stressLevel: 

					if (mpa > 100 && mpa < 150)
						c = Color.FromArgb(255, 255, 255);
					else if (mpa > 50 && mpa < 100)
						c = Color.FromArgb(127, 127, 255);
					else if (mpa > 0 && mpa < 50)
						c = Color.FromArgb(0, 0, 255);
					else if (mpa > 150 && mpa < 200)
						c = Color.FromArgb(255, 127, 127);
					else if (mpa > 200)
						c = Color.FromArgb(255, 0, 0);



/*
					step = 100.0f / 34.0f;

					if (percentUsed <  1 * step)
						faceColor = (byte) (strOffset + 0);

					else if (percentUsed <  2 * step)
						faceColor = (byte) (strOffset + 1);
					else if (percentUsed <  3 * step)
						faceColor = (byte) (strOffset + 2);
					else if (percentUsed <  4 * step)
						faceColor = (byte) (strOffset + 3);
					else if (percentUsed <  5 * step)
						faceColor = (byte) (strOffset + 4);
					else if (percentUsed <  6 * step)
						faceColor = (byte) (strOffset + 5);
					else if (percentUsed <  7 * step)
						faceColor = (byte) (strOffset + 6);
					else if (percentUsed <  8 * step)
						faceColor = (byte) (strOffset + 7);
					else if (percentUsed <  9 * step)
						faceColor = (byte) (strOffset + 8);

					else if (percentUsed < 10 * step)
						faceColor = (byte) (strOffset + 9);

					else if (percentUsed < 11 * step)
						faceColor = (byte) (strOffset + 10);
					else if (percentUsed < 12 * step)
						faceColor = (byte) (strOffset + 11);
					else if (percentUsed < 13 * step)
						faceColor = (byte) (strOffset + 12);
					else if (percentUsed < 14 * step)
						faceColor = (byte) (strOffset + 13);
					else if (percentUsed < 15 * step)
						faceColor = (byte) (strOffset + 14);
					else if (percentUsed < 16 * step)
						faceColor = (byte) (strOffset + 15);
					else if (percentUsed < 17 * step)
						faceColor = (byte) (strOffset + 16);

					else if (percentUsed < 18 * step)
						faceColor = (byte) (strOffset + 17);

					else if (percentUsed < 19 * step)
						faceColor = (byte) (strOffset + 18);
					else if (percentUsed < 20 * step)
						faceColor = (byte) (strOffset + 19);
					else if (percentUsed < 21 * step)
						faceColor = (byte) (strOffset + 20);
					else if (percentUsed < 22 * step)
						faceColor = (byte) (strOffset + 21);
					else if (percentUsed < 23 * step)
						faceColor = (byte) (strOffset + 22);
					else if (percentUsed < 24 * step)
						faceColor = (byte) (strOffset + 23);
					else if (percentUsed < 25 * step)
						faceColor = (byte) (strOffset + 24);

					else if (percentUsed < 26 * step)
						faceColor = (byte) (strOffset + 25);

					else if (percentUsed < 27 * step)
						faceColor = (byte) (strOffset + 26);
					else if (percentUsed < 28 * step)
						faceColor = (byte) (strOffset + 27);
					else if (percentUsed < 29 * step)
						faceColor = (byte) (strOffset + 28);
					else if (percentUsed < 30 * step)
						faceColor = (byte) (strOffset + 29);
					else if (percentUsed < 31 * step)
						faceColor = (byte) (strOffset + 30);
					else if (percentUsed < 32 * step)
						faceColor = (byte) (strOffset + 31);
					else if (percentUsed < 33 * step)
						faceColor = (byte) (strOffset + 32);

					else if (percentUsed < 34 * step)
						faceColor = (byte) (strOffset + 33);

					else
						faceColor = (byte) (strOffset + 34);
*/
					break;

				case RenderType.fos:

					float fos = FOS[activeLoadcase][x,y,z];

					if (fos < 1)
						faceColor = (byte) (fosOffset + 0);
					else if (fos < 5)
						faceColor = (byte) (fosOffset + 1);
					else 
						faceColor = (byte) (fosOffset + 2);
					break;

					
				case RenderType.materialDistribution:

						faceColor = (byte) (matOffset + matID);

					break;

			}

			#endregion

			return c;

		}	

		public static void DefineNormal(float[] p1, float[] p2, float[] p3) 
		{

			Vector v1 = new Vector(p2[0]-p1[0], p2[1]-p1[1], p2[2]-p1[2]);
			Vector v2 = new Vector(p3[0]-p1[0], p3[1]-p1[1], p3[2]-p1[2]);

			Vector normal = new Vector(0, 0, 0);

			normal = v1 * v2;

			Gl.glNormal3f(normal.x, normal.y, normal.z);

			
		}

		private bool IsSolid(int x, int y, int z) 
		{

			// we don't use the chromosome here
			// because has been changed from the
			// CanLive func on the Server Side
			return elements[x,y,z] != -1;
	
		}

		public void WriteText(float x, float y, string text, float textHeight, TextWriter fs, byte color)
		{

			fs.WriteLine("  0");
			fs.WriteLine("TEXT");
			fs.WriteLine("  8");
			fs.WriteLine("MN");
			fs.WriteLine("  62");
			fs.WriteLine(color);

			fs.WriteLine(" 10");
			fs.WriteLine(x);
			fs.WriteLine(" 20");
			fs.WriteLine(y);
			fs.WriteLine(" 30");
			fs.WriteLine("0.0");

			fs.WriteLine(" 40");
			fs.WriteLine(textHeight);
			fs.WriteLine("  1");
			fs.WriteLine(text);

		}

	

		#region Properties

		[CategoryAttribute("0 - Identity")]
		public string Name
		{
			get 
			{

				return name.ToString(); 

			}

		}
		//
		//		[CategoryAttribute("0 - Identity")]
		//		public string Age
		//		{
		//			get 
		//			{
		//
		//				int age = (int) (MainForm.generation - bornInGeneration);
		//
		//				return age.ToString(); 
		//
		//			}
		//
		//		}

		[CategoryAttribute("1 - Parents")]
		public string Mom
		{
			get 
			{

				return mom.ToString(); 

			}

		}
		[CategoryAttribute("1 - Parents")]
		public string Dad
		{
			get 
			{

				return dad.ToString(); 

			}

		}

		[CategoryAttribute("2 - Performances")]
		public string Weight
		{
			get 
			{

				return weight.ToString("f3") + " Kg"; 

			}

		}
		[CategoryAttribute("2 - Performances")]
		public string SurfaceArea
		{
			get 
			{

				return surfaceArea.ToString("f3") + " mm²"; 
			
			}
		}

		[CategoryAttribute("2 - Performances")]
		public string Cost
		{
			get 
			{
				
				return cost.ToString(); ;

			}
		
		}
		[CategoryAttribute("2 - Performances")]
		public string MaxDisplacement
		{
			get 
			{
				if (maxDispl != null)
					return maxDispl[activeLoadcase].ToString("f6") + " mm"; 
				else 
					return "(not available)";

			
			}
		}
		[CategoryAttribute("2 - Performances")]
		public string CostToWeightRatio
		{
			get 
			{
				if (cost != float.MaxValue)
					return (cost / weight).ToString("f3"); 
				else 
					return "(not available)";

			
			}
		}
		[CategoryAttribute("2 - Performances")]
		public string MaxFOS
		{
			get 
			{
				if (maxFOS != null)
					return maxFOS[activeLoadcase].ToString("f3"); 
				else 
					return "(not available)";

			
			}
		}
		[CategoryAttribute("2 - Performances")]
		public string MinFOS
		{
			get 
			{
				if (minFOS != null)
					return minFOS[activeLoadcase].ToString("f3"); 
				else 
					return "(not available)";

			
			}
		}
		[CategoryAttribute("3 - Troubleshooting")]
		public string CalculatedOn
		{
			get 
			{
			
	
				return machineName.ToString(); 


			}
		
		}
		[CategoryAttribute("3 - Troubleshooting")]
		public string Reason
		{
			get 
			{
			
	
				return reason; 


			}
		
		}
		[CategoryAttribute("3 - Troubleshooting")]
		public string TotalTime
		{
			get 
			{
			
	
				return totalTime.ToString(); 


			}
		
		}
		[CategoryAttribute("3 - Troubleshooting")]
		public string RequiredMemory
		{
			get 
			{
			
	
				return (reqMemory / 1024).ToString("n0") + " KB"; 


			}
		
		}


		#endregion


	}

	public class MU
	{
		
		const float epsilon = 0.001f;

		public static float zeroClamp(float val)	
		{
			return (epsilon > Math.Abs(val)) ? 0.0f : val;	
		}

		public static bool floatEqualityTest(float x, float val) 
		{
			return (val - epsilon) < x && x < (val + epsilon);	
		}

		public static void limitRange(float low, ref float val, float high)
		{

			if (val < low)

				val = low;	

			else if (val > high)

				val = high;	

		}

		public static float radToDeg(float angle) 
		{
			
			return (float) (angle * 180.0 / Math.PI);
			
		}

		public static float degToRad(float angle) 
		{
			
			return (float) (angle * Math.PI / 180.0);
			
		}

	}



	public class Utilities 
	{

		public static float Max(float[] array) 
		{

			float max = float.MinValue;

			foreach (float v in array)
                
				if (v > max) 

					max = v;

			return max;

		}

		public static double Max(double[] array) 
		{

			double max = double.MinValue;

			foreach (double v in array)
                
				if (v > max) 

					max = v;

			return max;

		}

		public static float Min(float[] array) 
		{

			float min = float.MaxValue;

			foreach (float v in array)
                
				if (v < min) 

					min = v;

			return min;

		}

		public static uint Max(uint[] array) 
		{

			uint max = uint.MinValue;

			foreach (uint i in array)
                
				if (i > max) 

					max = i;

			return max;

		}

		public static uint Min(uint[] array) 
		{

			uint min = uint.MaxValue;

			foreach (uint i in array)
                
				if (i < min) 

					min = i;

			return min;

		}


		public static float MaxAbs(float[] array) 
		{

			float max = float.MinValue;

			foreach (float i in array) 
			{
             
				float absVal = Math.Abs(i);

				if (absVal > max) 

					max = absVal;

			}

			return max;

		}

		public static float Max(float[,,] array) 
		{

			float max = float.MinValue;

			for (int z = 0; z < array.GetLength(2); z++) 
			
				for (int y = 0; y < array.GetLength(1); y++) 
				
					for (int x = 0; x < array.GetLength(0); x++) 
                
						if (array[x,y,z] > max) 

							max = array[x,y,z];

			return max;

		}

		public static float Min(float[,,] array) 
		{

			float min = float.MaxValue;

			for (int z = 0; z < array.GetLength(2); z++) 
			
				for (int y = 0; y < array.GetLength(1); y++) 
				
					for (int x = 0; x < array.GetLength(0); x++) 
                
						if (array[x,y,z] < min) 

							min = array[x,y,z];

			return min;

		}

		public static float MinNotZero(float[,,] array) 
		{

			float min = float.MaxValue;

			for (int z = 0; z < array.GetLength(2); z++) 
			
				for (int y = 0; y < array.GetLength(1); y++) 
				
					for (int x = 0; x < array.GetLength(0); x++) 
                
						if (array[x,y,z] < min && array[x,y,z] != 0) 

							min = array[x,y,z];

			return min;

		}


		
	}

	[Serializable]
	public class Face
	{

		const byte dof = 3;

		Color color1;

		public int[] connections = {-1, -1, -1, -1};
		byte[] color = {0, 0, 0, 0};

		float[] centroid = {0.0f, 0.0f, 0.0f};


		public Face(int v1, int v2, int v3, int v4, byte colorA, byte colorB, byte colorC, byte colorD) 
		{

			connections[0] = v1;
			connections[1] = v2;
			connections[2] = v3;
			connections[3] = v4;

			this.color[0] = colorA;
			this.color[1] = colorB;
			this.color[2] = colorC;
			this.color[3] = colorD;
				
		}

		public Face(int v1, int v2, int v3, int v4, Color c) 
		{

			connections[0] = v1;
			connections[1] = v2;
			connections[2] = v3;
			connections[3] = v4;

			color1 = c;
				
		}


		public bool IsOnSurface(byte[,,] weights, int pointsPerRow, int pointsPerLayer) 
		{

			// if not calculated we don't know if the face is 
			// on surface, so return always true and take a little
			// more to draw the part
			if (weights == null)

				return true;

			bool[] yesItIs = new bool[4];

			for (byte i = 0; i < 4; i++) 
			{

				int x, y, z;

				z = connections[i] / pointsPerLayer;
				y = connections[i] % pointsPerLayer / pointsPerRow;
				x = connections[i] % pointsPerLayer % pointsPerRow;

				if (weights[x,y,z] < 8)

					yesItIs[i] = true;

			}

			return (yesItIs[0] && yesItIs[1] && yesItIs[2] && yesItIs[3]);

		}

		public void CalcCentroid(float[][] vertices) 
		{

			float[] p1 = vertices[connections[0]];
			float[] p2 = vertices[connections[2]];

			centroid[0] = p1[0] + (p2[0] - p1[0]) / 2;
			centroid[1] = p1[1] + (p2[1] - p1[1]) / 2;
			centroid[2] = p1[2] + (p2[2] - p1[2]) / 2;

		}

		public override bool Equals(object o)
		{
			
			Face temp = (Face) o;

			if (this.centroid[0] == temp.centroid[0] &&
				this.centroid[1] == temp.centroid[1] &&
				this.centroid[2] == temp.centroid[2]) 

				return true;

			return false;

		}

		public void Draw(float[][] vertices, int[,,] nodes, float[][] unknowns, byte loadcase, float scaleFactor, float dAmplFactor, int pointsPerRow, int pointsPerLayer, Color[] colorTable) 
		{


			float[][] v = new float[4][];

			if (nodes != null) 
			{

				for (byte i = 0; i < 4; i++) 
				{

					int x, y, z;

					z = connections[i] / pointsPerLayer;
					y = connections[i] % pointsPerLayer / pointsPerRow;
					x = connections[i] % pointsPerLayer % pointsPerRow;

					int node = nodes[x,y,z];

					v[i] = new float[dof];
 
					v[i][0] = (vertices[connections[i]][0] + unknowns[loadcase][node*dof+0]*dAmplFactor) * scaleFactor;
					v[i][1] = (vertices[connections[i]][1] + unknowns[loadcase][node*dof+1]*dAmplFactor) * scaleFactor;
					v[i][2] = (vertices[connections[i]][2] + unknowns[loadcase][node*dof+2]*dAmplFactor) * scaleFactor;

				}

			}

			else 
			{

				for (byte i = 0; i < 4; i++) 
				{

					int x, y, z;

					z = connections[i] / pointsPerLayer;
					y = connections[i] % pointsPerLayer / pointsPerRow;
					x = connections[i] % pointsPerLayer % pointsPerRow;

					v[i] = new float[dof];
 
					v[i][0] = (vertices[connections[i]][0]) * scaleFactor;
					v[i][1] = (vertices[connections[i]][1]) * scaleFactor;
					v[i][2] = (vertices[connections[i]][2]) * scaleFactor;

				}

			}

//			Gl.glColor3ub(colorTable[color[loadcase]].R, colorTable[color[loadcase]].G, colorTable[color[loadcase]].B);
			Gl.glColor3ub(color1.R, color1.G, color1.B);

			Gl.glBegin(Gl.GL_TRIANGLE_FAN);	
			
			// first triangle
			General.Vector.DefineNormal(v[0], v[1], v[2]);


					
			Gl.glVertex3fv(v[0]);
			Gl.glVertex3fv(v[1]);
			Gl.glVertex3fv(v[2]);

			// second triangle
			General.Vector.DefineNormal(v[0], v[2], v[3]);

			Gl.glVertex3fv(v[3]);

			Gl.glEnd();

		}

		public igesEntity GetIgesEntity(float[][] vertices, byte loadcase, int pointsPerRow, int pointsPerLayer) 
		{

			igesRuledSurface ruled = new igesRuledSurface(-(color[loadcase]*2 + 1));

			float[][] v = new float[4][];

			for (byte i = 0; i < 4; i++) 
			{

				int x, y, z;

				z = connections[i] / pointsPerLayer;
				y = connections[i] % pointsPerLayer / pointsPerRow;
				x = connections[i] % pointsPerLayer % pointsPerRow;

				v[i] = new float[dof];
 
				v[i][0] = vertices[connections[i]][0];
				v[i][1] = vertices[connections[i]][1];
				v[i][2] = vertices[connections[i]][2];

			}

			ruled.SetFirstEdge(v[0], v[1]);
			ruled.SetSecondEdge(v[3], v[2]); // reverse order to avoid candy

			return ruled;

		}

		public void WriteSTL(float[][] vertices, TextWriter tw) 
		{

			Vector norm = Vector.GetNormal(vertices[connections[0]], vertices[connections[1]], vertices[connections[2]]);

			tw.WriteLine("  facet normal " + norm.x + " " +  norm.y + " " +  norm.z);
			tw.WriteLine("    outer loop");
			tw.WriteLine("      vertex " + vertices[connections[0]][0] + " " + vertices[connections[0]][1] + " " +  vertices[connections[0]][2]);
			tw.WriteLine("      vertex " + vertices[connections[1]][0] + " " + vertices[connections[1]][1] + " " +  vertices[connections[1]][2]);
			tw.WriteLine("      vertex " + vertices[connections[2]][0] + " " + vertices[connections[2]][1] + " " +  vertices[connections[2]][2]);
			tw.WriteLine("    endloop");
			tw.WriteLine("  endfacet");

			tw.WriteLine("  facet normal " + norm.x + " " + norm.y + " " +  norm.z);
			tw.WriteLine("    outer loop");
			tw.WriteLine("      vertex " + vertices[connections[0]][0] + " " +  vertices[connections[0]][1] + " " +  vertices[connections[0]][2]);
			tw.WriteLine("      vertex " + vertices[connections[2]][0] + " " +  vertices[connections[2]][1] + " " +  vertices[connections[2]][2]);
			tw.WriteLine("      vertex " + vertices[connections[3]][0] + " " +  vertices[connections[3]][1] + " " +  vertices[connections[3]][2]);
			tw.WriteLine("    endloop");
			tw.WriteLine("  endfacet");

		}


	}

	public class DomainFace : Face, IComparable
	{

		Color color;
		byte matID;
		float distance;
		bool solid;

		public DomainFace(int v1, int v2, int v3, int v4, Color faceColor, bool solidCell, byte materialID) : base(v1, v2, v3, v4, 0,0,0,0)
		{
			
			this.color = faceColor;
			this.matID = materialID;
			this.solid = solidCell;

		}

		public void CalcDistance(float[][] vertices, float[] m) 
		{

			float[] p1 = vertices[connections[0]];
			float[] p2 = vertices[connections[2]];

			float[] p =	new float[3];	// centroid
			
			p[0] = p1[0] + (p2[0] - p1[0]) / 2;
			p[1] = p1[1] + (p2[1] - p1[1]) / 2;
			p[2] = p1[2] + (p2[2] - p1[2]) / 2;

			float[] np = new float[3];	// centroid after transform

			np[0] = p[0] * m[0] + p[1] * m[4] + p[2] * m[8] + m[12];
			np[1] = p[0] * m[1] + p[1] * m[5] + p[2] * m[9] + m[13];
			np[2] = p[0] * m[2] + p[1] * m[6] + p[2] * m[10] + m[14];

			distance = (float) Math.Sqrt(np[0]*np[0] + np[1]*np[1] + np[2]*np[2]);

		}

		public override bool Equals(object o)
		{
			
			DomainFace temp = (DomainFace) o;

			if (base.Equals(o) && 
				this.matID == temp.matID && 
				this.solid == temp.solid) 

				return true;

			return false;

		}

		int IComparable.CompareTo(object o)
		{

			DomainFace temp = (DomainFace) o;

			// if they are at the same distance we discriminate by material
		//	if (this.distance == temp.distance) 

		//		return (this.matID > temp.matID) ? +1 : -1;

		//	else

				return (this.distance < temp.distance) ? +1 : -1;

		}

		public void Draw(float[][] vertices, float scaleFactor) 
		{

			Gl.glColor4ub(color.R, color.G, color.B, color.A);

			Gl.glBegin(Gl.GL_QUADS);	
			
			// first triangle
			General.Vector.DefineNormal(vertices[connections[0]], vertices[connections[1]], vertices[connections[2]]);
					
			Gl.glVertex3f(vertices[connections[0]][0]*scaleFactor, vertices[connections[0]][1]*scaleFactor, vertices[connections[0]][2]*scaleFactor);
			Gl.glVertex3f(vertices[connections[1]][0]*scaleFactor, vertices[connections[1]][1]*scaleFactor, vertices[connections[1]][2]*scaleFactor);
			Gl.glVertex3f(vertices[connections[2]][0]*scaleFactor, vertices[connections[2]][1]*scaleFactor, vertices[connections[2]][2]*scaleFactor);
			Gl.glVertex3f(vertices[connections[3]][0]*scaleFactor, vertices[connections[3]][1]*scaleFactor, vertices[connections[3]][2]*scaleFactor);

			Gl.glEnd();

		}



	}

	[Serializable]
	public class Edge
	{

		int[] connections = {-1, -1};

		float[] centroid = {0.0f, 0.0f, 0.0f};

		public Edge(int v1, int v2) 
		{

			connections[0] = v1;
			connections[1] = v2;
				
		}

		public void CalcCentroid(float[][] vertices) 
		{

			float[] p1 = vertices[connections[0]];
			float[] p2 = vertices[connections[1]];

			centroid[0] = p1[0] + (p2[0] - p1[0]) / 2;
			centroid[1] = p1[1] + (p2[1] - p1[1]) / 2;
			centroid[2] = p1[2] + (p2[2] - p1[2]) / 2;

		}

		public override bool Equals(object o)
		{
			
			Edge temp = (Edge) o;

			if (this.centroid[0] == temp.centroid[0] &&
				this.centroid[1] == temp.centroid[1] &&
				this.centroid[2] == temp.centroid[2])  

				return true;

			return false;

		}

		public bool IsOnBorder(byte[,,] weights, int pointsPerRow, int pointsPerLayer) 
		{

			// if not calculated we don't know if the edge is 
			// on border, so return always true and take a little
			// more to draw the part
			if (weights == null)

				return true;


			bool[] yesItIs = new bool[2];

			for (byte i = 0; i < 2; i++) 
			{

				int x, y, z;

				z = connections[i] / pointsPerLayer;
				y = connections[i] % pointsPerLayer / pointsPerRow;
				x = connections[i] % pointsPerLayer % pointsPerRow;

				if (weights[x,y,z] < 8)

					yesItIs[i] = true;

			}

			return (yesItIs[0] && yesItIs[1]);

		}

		public void Draw(float[][] vertices, int[,,] nodes, float[][] unknowns, byte loadcase, float scaleFactor, float dAmplFactor, byte dof, int pointsPerRow, int pointsPerLayer) 
		{

			float[][] v = new float[2][];

			if (nodes != null) 
			{

				for (byte i = 0; i < 2; i++) 
				{

					int x, y, z;

					z = connections[i] / pointsPerLayer;
					y = connections[i] % pointsPerLayer / pointsPerRow;
					x = connections[i] % pointsPerLayer % pointsPerRow;

					int node = nodes[x,y,z];

					v[i] = new float[dof];
 
					v[i][0] = (vertices[connections[i]][0] + unknowns[loadcase][node*dof+0]*dAmplFactor) * scaleFactor;
					v[i][1] = (vertices[connections[i]][1] + unknowns[loadcase][node*dof+1]*dAmplFactor) * scaleFactor;
					v[i][2] = (vertices[connections[i]][2] + unknowns[loadcase][node*dof+2]*dAmplFactor) * scaleFactor;

				}

			}

			else 
			{

				for (byte i = 0; i < 2; i++) 
				{

					int x, y, z;

					z = connections[i] / pointsPerLayer;
					y = connections[i] % pointsPerLayer / pointsPerRow;
					x = connections[i] % pointsPerLayer % pointsPerRow;

					v[i] = new float[dof];
 
					v[i][0] = (vertices[connections[i]][0]) * scaleFactor;
					v[i][1] = (vertices[connections[i]][1]) * scaleFactor;
					v[i][2] = (vertices[connections[i]][2]) * scaleFactor;

				}

			}

			Gl.glBegin(Gl.GL_LINES);	
			
			Gl.glVertex3fv(v[0]);
			Gl.glVertex3fv(v[1]);

			Gl.glEnd();

		}

		public void WriteLine(float[][] vertices, float scaleFactor, byte dof, TextWriter fs, byte color) 
		{

			float[][] v = new float[2][];

			for (byte i = 0; i < 2; i++) 
			{

				v[i] = new float[dof];
 
				v[i][0] = vertices[connections[i]][0];
				v[i][1] = vertices[connections[i]][1];
				v[i][2] = vertices[connections[i]][2];

			}

			fs.WriteLine("  0");
			fs.WriteLine("LINE");
			fs.WriteLine("  8");
			fs.WriteLine("MN");
			fs.WriteLine("  62");
			fs.WriteLine(color);

			fs.WriteLine(" 10");
			fs.WriteLine(v[0][0]);
			fs.WriteLine(" 20");
			fs.WriteLine(v[0][1]);
			fs.WriteLine(" 30");
			fs.WriteLine(v[0][2]);

			fs.WriteLine(" 11");
			fs.WriteLine(v[1][0]);
			fs.WriteLine(" 21");
			fs.WriteLine(v[1][1]);
			fs.WriteLine(" 31");
			fs.WriteLine(v[1][2]);

		}


	}


}
