namespace MdlView
{
	using System;
	using System.IO;
	using System.Text;
	using System.Runtime.InteropServices;

	/// <summary>
	/// Generic loader for an mdl file (version 6 and 8)
	/// </summary>
	internal class MdlFile
	{
		internal GenericMdlHeader Header;
		internal Mesh[] meshList;
		// Only useful for version 6 files!
		internal long[] SkinOffsets;
		// Only using this for V6 & V8 quake models
		internal AnimationFrame[] fAnimationSequences;
		internal string Filename;
		private int fCurrentFrameInMdl;
	
		/// <summary>
		/// Construtor for the file - allocates a generic header
		/// </summary>
		public MdlFile()
		{
			// Header information that is shared between Quake I & II file formats
			Header = new GenericMdlHeader();
			fCurrentFrameInMdl = 0;
		}

		/// <summary>
		/// Property that gets and sets the current frame in a given file
		/// </summary>
		/// <remarks>
		/// Meshs are not always going to be guarenteed to have the same # of frames.  This
		/// isn't a problem with only version 6 and 8 files though (they only have one mesh)
		/// </remarks>
		public int CurrentFrameInMdl
		{
			get
			{
				return meshList[0].CurrentFrame;
			}
			set
			{
				int count;
				for (count = 0; count < Header.NumMeshes; count++)
					meshList[count].CurrentFrame = value;
			}
		}

		/// <summary>
		/// Property that gets the list of sequences
		/// </summary>
		public AnimationFrame[] Sequences
		{
			get
			{
				return fAnimationSequences;
			}
		}

		/// <summary>
		/// Property that gets the file version
		/// </summary>
		/// <remarks>
		/// We limit the model so that you can only load .mdls of the same version into that one model
		/// </remarks>
		public int Version
		{
			get
			{
				return Header.Version;
			}
		}

		/// <summary>
		/// A through point that adds all the meshes in the current model to the world list
		/// </summary>
		/// <param name="WorldList">List that collects all triangles that will be displayed</param>
		/// <param name="renderType">The current rendering type</param>
		/// <param name="TransX">Local X translation (in screen coordinates)</param>
		/// <param name="TransY">Local Y translation (in screen coordinates)</param>
		/// <param name="GlobalView">The viewer's orientation</param>
		/// <param name="objectViewer">Vector used for backface culling</param>
		internal void AddModelToList(ref RenderList WorldList, enumRenderingMode renderType, int TransX, int TransY, Matrix GlobalView, Vector objectViewer)
		{
			for (int count = 0; count < Header.NumMeshes; count++)
				meshList[count].AddMeshToList(ref WorldList, renderType, TransX, TransY, GlobalView, Header.SkinWidth, objectViewer);
		}

		/// <summary>
		/// Sets the rotation, scaling, and translation stats for the mdlfile
		/// </summary>
		/// <param name="Rotate">Pre-calculated rotation matrix</param>
		/// <param name="scaleFactor">Scale of mdlfile</param>
		/// <param name="worldPos">Position of mdlfile in world</param>
		internal void setRotateMdl(Matrix Rotate, float scaleFactor, Position worldPos)
		{
			for (int count = 0; count < Header.NumMeshes; count++)
				meshList[count].setRotateMesh(Rotate, scaleFactor, worldPos);
		}

		/// <summary>
		/// Loads an .mdl from disk - works on both Quake I and II models
		/// </summary>
		/// <param name="Filename">The file and path name of the .mdl (.md2)</param>
		public bool LoadFromFile(string Filename)
		{
			FileInfo fileHandle = new FileInfo(Filename);
			int ID;
			int Version;
			bool returnValue = false;

			// Can't find the file!
			if (!fileHandle.Exists) 
			{
				return false;
			}

			BinaryReader InFile = null;

			try
			{
				InFile = new BinaryReader(fileHandle.OpenRead());
				byte[] buffer = new byte[(int)fileHandle.Length];

				ID = InFile.ReadInt32();
				Version = InFile.ReadInt32();
				InFile.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				this.Filename = Filename;

				switch(ID)
				{
					// IDPO <- Quake 1
					case 1330660425:
						// Sanity check
						if (Version == 6)
							returnValue = MdlFileV6.loadV6File(this, InFile);
						break;
					// IDP2 <- Quake 2!
					case 844121161:
						// Sanity check
						if (Version == 8)
							returnValue = MdlFileV8.loadV8File(this, InFile);
						break;
					default:
						returnValue = false;
						break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.ToString() + " occurred!");
				returnValue = false;
			}
			finally
			{
				// Always close the file!
				InFile.Close();
			}

			return returnValue;
		}		
	}

	/// <summary>
	/// Loader for version 6 mdl files
	/// </summary>
	internal class MdlFileV6
	{
		private static MdlHeaderV6 Header;

		/// <summary>
		/// Read the header from the byte buffer
		/// </summary>
		/// <param name="headerBuffer">The Buffer that contains the file contents</param>
		private unsafe static void parseHeader(byte[] headerBuffer)
		{
			// Fix the header buffer 
			fixed(byte* pBuffer = headerBuffer)
			{
				// Blast the bytes into the header through a cast
				Header = *((MdlHeaderV6*)pBuffer);
			}
		}

		/// <summary>
		/// Load the Quake I mdl from the binary file.
		/// </summary>
		/// <param name="mdlInfo">The MDL Information </param>
		/// <param name="fileIn">The Binary File to read from</param>
		internal static bool loadV6File(MdlFile mdlInfo, BinaryReader fileIn)
		{
	
			bool SkinLoaded = false, returnValue = false;
			int count, offsetCount, Group, NB, unpackFrame, polCount, frameType;
			string LastGroupName, GroupName;
			Vector u, v;
			int numberOfSequences;
			TempAnimationFrame[] sequenceList;

			// Allocate a buffer for the header
			byte[] buffer = new byte[Marshal.SizeOf(Header)];

			try
			{
				buffer = fileIn.ReadBytes(Marshal.SizeOf(Header));
				// Blast the buffer into the header
				parseHeader(buffer);

				// Use the generic header to persist useful information
				mdlInfo.Header.Version = Header.Version;
				// Quake I models only have 1 mesh
				mdlInfo.Header.NumMeshes = 1;
				mdlInfo.Header.SkinHeight = Header.SkinHeight;
				mdlInfo.Header.SkinWidth = Header.SkinWidth;
				mdlInfo.meshList = new Mesh[mdlInfo.Header.NumMeshes];

				for(count = 0; count < mdlInfo.Header.NumMeshes; count++)
					mdlInfo.meshList[count] = new Mesh();

				mdlInfo.meshList[0].meshHeader.NumFrames = Header.NumFrames;
				mdlInfo.meshList[0].meshHeader.NumSkins = Header.NumSkins;
				mdlInfo.meshList[0].meshHeader.NumVerts = Header.NumVerts;
				mdlInfo.meshList[0].meshHeader.NumTris = Header.NumTris;

				mdlInfo.SkinOffsets = new long[Header.NumSkins];
				for(count = 0; count < Header.NumSkins; count++)
				{
					// Keep track of where skins are in file, to load later
					mdlInfo.SkinOffsets[count] = fileIn.BaseStream.Position;
					Group = fileIn.ReadInt32();
					if (!SkinLoaded)
						mdlInfo.meshList[0].skin.Group = Group;
					// If there are multiple skins in a group...
					if (Group == 1) 
					{
						NB = fileIn.ReadInt32();
						if (!SkinLoaded)
						{
							mdlInfo.meshList[0].skin.NextB = NB;
							mdlInfo.meshList[0].skin.Time = new float[mdlInfo.meshList[0].skin.NextB];
							mdlInfo.meshList[0].skin.GroupSkinNodes = new byte[mdlInfo.meshList[0].skin.NextB, Header.SkinHeight * Header.SkinWidth];
							mdlInfo.meshList[0].skin.SkinNode = null;
							for (offsetCount = 0; offsetCount < mdlInfo.meshList[0].skin.NextB; offsetCount++)
								mdlInfo.meshList[0].skin.Time[offsetCount] = fileIn.ReadSingle();

							for (offsetCount = 0; offsetCount < mdlInfo.meshList[0].skin.NextB; offsetCount++)
								for (int cursor = 0; cursor < Header.SkinHeight * Header.SkinWidth; cursor++)
									mdlInfo.meshList[0].skin.GroupSkinNodes[offsetCount, cursor] = fileIn.ReadByte();
						}
						else
							fileIn.BaseStream.Seek((NB * 4) + (NB * Header.SkinHeight * Header.SkinWidth), System.IO.SeekOrigin.Current);
					}
					// Just one skin...
					else
					{
						if (!SkinLoaded)
						{
							mdlInfo.meshList[0].skin.NextB = 1;
							mdlInfo.meshList[0].skin.Time = null;
							mdlInfo.meshList[0].skin.GroupSkinNodes = null;
							mdlInfo.meshList[0].skin.SkinNode = new byte[Header.SkinHeight * Header.SkinWidth];
							for(offsetCount = 0; offsetCount < Header.SkinHeight * Header.SkinWidth; offsetCount++)
								mdlInfo.meshList[0].skin.SkinNode[offsetCount] = fileIn.ReadByte();
						}
						else
							fileIn.BaseStream.Seek(Header.SkinHeight * Header.SkinWidth, System.IO.SeekOrigin.Current);
					}
					SkinLoaded = true;
				}				
				mdlInfo.meshList[0].SkinVertices = new SkinVerts[Header.NumVerts];
				// Load the skin vertices from the file
				for (count = 0; count < Header.NumVerts; count++)
				{
					mdlInfo.meshList[0].SkinVertices[count].OnSeam = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinVertices[count].S = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinVertices[count].T = fileIn.ReadInt32();
				}
				mdlInfo.meshList[0].SkinTriangles = new SkinTris[Header.NumTris];
				// Load the triangles from the file, notice that texture and frame vertices are the same in Quake I mdls
				for (count = 0; count < Header.NumTris; count++)
				{
					mdlInfo.meshList[0].SkinTriangles[count].FacesFront = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinTriangles[count].VerticesX = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexX = mdlInfo.meshList[0].SkinTriangles[count].VerticesX;
					mdlInfo.meshList[0].SkinTriangles[count].VerticesY = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexY = mdlInfo.meshList[0].SkinTriangles[count].VerticesY;
					mdlInfo.meshList[0].SkinTriangles[count].VerticesZ = fileIn.ReadInt32();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexZ = mdlInfo.meshList[0].SkinTriangles[count].VerticesZ;
				}
				
				mdlInfo.meshList[0].Frames = new FrameNodes[Header.NumFrames];
				
				// Make it too big on purpose =-)
				sequenceList = new TempAnimationFrame[Header.NumFrames];
				numberOfSequences = 0;
				LastGroupName = "";
				for (count = 0; count < Header.NumFrames; count++)
				{
					frameType = fileIn.ReadInt32();
					if (frameType != 0) 
					{
						// Don't handle this... this is a rare form of grouping for frame.
						// Frame sequences are mostly based off naming conventions
						return false;
					}
					else
					{
						mdlInfo.meshList[0].Frames[count].FrameData = new TriVertex[Header.NumVerts];
						mdlInfo.meshList[0].Frames[count].normalList = new Vector[Header.NumTris];

						// Read in the bounding box for the frame
						mdlInfo.meshList[0].Frames[count].Min.points.x = fileIn.ReadByte() *
							Header.scale.x + Header.origin.x + Header.offsets.x;
						mdlInfo.meshList[0].Frames[count].Min.points.y = fileIn.ReadByte() *
							Header.scale.y + Header.origin.y + Header.offsets.y;
						mdlInfo.meshList[0].Frames[count].Min.points.z = fileIn.ReadByte() *
							Header.scale.z + Header.origin.z + Header.offsets.z;
						fileIn.ReadByte();
						mdlInfo.meshList[0].Frames[count].Max.points.x = fileIn.ReadByte() *
							Header.scale.x + Header.origin.x + Header.offsets.x;
						mdlInfo.meshList[0].Frames[count].Max.points.y = fileIn.ReadByte() *
							Header.scale.y + Header.origin.y + Header.offsets.y;
						mdlInfo.meshList[0].Frames[count].Max.points.z = fileIn.ReadByte() *
							Header.scale.z + Header.origin.z + Header.offsets.z;
						fileIn.ReadByte();
						// Read in the frame name
						mdlInfo.meshList[0].Frames[count].Name = new byte[16];
						for (offsetCount = 0; offsetCount < 16; offsetCount++)
							mdlInfo.meshList[0].Frames[count].Name[offsetCount] = fileIn.ReadByte();
						GroupName = parseGroupName(mdlInfo.meshList[0].Frames[count].Name);
						// Create sequences based off parsed group name (if two frames belong in the same
						// sequence, they'll have the same parsed name)
						if (GroupName != LastGroupName)
						{
							sequenceList[numberOfSequences].AnimationName = GroupName;
							sequenceList[numberOfSequences].frameOffset = count;
							numberOfSequences++;
							LastGroupName = GroupName;
						}
						// Unpack the frame (multiply it by the scale and add the origin)
						for (unpackFrame = 0; unpackFrame < Header.NumVerts; unpackFrame++)
						{
							mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.x = 
								fileIn.ReadByte() * Header.scale.x + Header.origin.x;
							mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.y = 
								fileIn.ReadByte() * Header.scale.y + Header.origin.y;
							mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.z = 
								fileIn.ReadByte() * Header.scale.z + Header.origin.z;
							mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].LightNormalIndex =
								fileIn.ReadByte();
						}
						// Calculate normals for backface culling
						for (polCount = 0; polCount < Header.NumTris; polCount++)
						{
							u = Model.MakeVector(mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesX].points,
								mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesY].points);
							v = Model.MakeVector(mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesY].points,
								mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesZ].points);
							mdlInfo.meshList[0].Frames[count].normalList[polCount] = Model.CrossProduct(v, u);
						}
					}
				}

				mdlInfo.fAnimationSequences = new AnimationFrame[numberOfSequences];
				for (count = 0; count < numberOfSequences - 1; count++)
				{
					mdlInfo.fAnimationSequences[count].AnimationName = sequenceList[count].AnimationName;
					mdlInfo.fAnimationSequences[count].AnimationType = enumAnimationType.All;
					mdlInfo.fAnimationSequences[count].FirstFrame = sequenceList[count].frameOffset;
					mdlInfo.fAnimationSequences[count].NumFrames = sequenceList[count + 1].frameOffset -
						sequenceList[count].frameOffset;
					// *Very* arbitrary #
					mdlInfo.fAnimationSequences[count].FramesPerSecond = 20;
				}
				mdlInfo.fAnimationSequences[numberOfSequences - 1].AnimationName = sequenceList[numberOfSequences - 1].AnimationName;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].FirstFrame = sequenceList[numberOfSequences - 1].frameOffset;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].AnimationType = enumAnimationType.All;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].NumFrames = Header.NumFrames - 
					sequenceList[numberOfSequences - 1].frameOffset;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].FramesPerSecond = 20;

				MainFrm.graphicsObject.paletteIndex = MainFrm.graphicsObject.paletteCount;

				// Load the palette (should be in pal.bin)
				if (System.IO.File.Exists(MainFrm.palPath))
					MainFrm.graphicsObject.MakePal(MainFrm.palPath);
				else
					if (System.IO.File.Exists(MainFrm.AppPath + "\\" + MainFrm.palPath))
						MainFrm.graphicsObject.MakePal(MainFrm.AppPath + "\\" + MainFrm.palPath);
					else 
						Console.WriteLine("Unable to load the palette from: " + MainFrm.AppPath + "\\" + MainFrm.palPath);
				
				mdlInfo.meshList[0].skin.paletteIndex = MainFrm.graphicsObject.paletteCount;
				MainFrm.graphicsObject.paletteCount++;

				mdlInfo.meshList[0].worldCoords = new Vector[Header.NumVerts];
				mdlInfo.meshList[0].cameraCoords = new Vector[Header.NumVerts];
				mdlInfo.meshList[0].rotateList = new byte[Header.NumVerts];

				returnValue = true;
			}
			catch(Exception e)
			{
				Console.WriteLine("Exception: " + e.ToString() + " occurred!");
			}

		
			return returnValue;
		}

		/// <summary>
		/// Parse the Group Name
		/// </summary>
		/// <param name="groupName">The frame name to be parsed</param>
		/// <remarks>
		/// Frame names usually follow the form
		/// stand1
		/// stand2
		/// etc.
		/// So if they belong in a sequence together they'll have the same root + number.
		/// </remarks>
		internal static string parseGroupName(byte[] groupName)
		{
			StringBuilder nameBuilder = new StringBuilder();
			int count = 0;
			
			while (Char.IsLetter((char)groupName[count]) && (count < groupName.Length))
				nameBuilder.Append((char)groupName[count++]);

			return nameBuilder.ToString();
		}
	}


	/// <summary>
	/// Loader for version 8 mdl files
	/// </summary>
	internal class MdlFileV8
	{
		private static MdlHeaderV8 Header;
		private static PcxHeader pcxHeader;

		/// <summary>
		/// Parse the header
		/// </summary>
		/// <param name="headerBuffer">Buffer holding info about the header</param>
		private unsafe static void parseHeader(byte[] headerBuffer)
		{
			fixed(byte* pBuffer = headerBuffer)
			{
				// Copy the buffer contents over the Header structure
				Header = *((MdlHeaderV8*)pBuffer);
			}
		}

		/// <summary>
		/// Load a Quake 2 Model from the passed file.
		/// </summary>
		/// <param name="mdlInfo">Info about the generic mdlFile</param>
		/// <param name="fileIn">The reader for the file</param>
		internal static bool loadV8File(MdlFile mdlInfo, BinaryReader fileIn)
		{
			bool returnValue = false;
			int count, offsetCount, unpackFrame, polCount;
			string LastGroupName, GroupName, associatedPcx;
			Vector u, v;
			int numberOfSequences;
			TempAnimationFrame[] sequenceList;

			float ScaleX, ScaleY, ScaleZ;
			float OffsetX, OffsetY, OffsetZ;
			
			try
			{
				byte[] buffer = fileIn.ReadBytes(Marshal.SizeOf(Header));
				// Blast the buffer into the header struct
				parseHeader(buffer);

				mdlInfo.Header.Version = Header.Version;
				mdlInfo.Header.NumMeshes = 1;
				mdlInfo.Header.SkinHeight = Header.SkinHeight;
				mdlInfo.Header.SkinWidth = Header.SkinWidth;
				mdlInfo.meshList = new Mesh[mdlInfo.Header.NumMeshes];
				for(count = 0; count < mdlInfo.Header.NumMeshes; count++)
					mdlInfo.meshList[count] = new Mesh();

				mdlInfo.meshList[0].meshHeader.NumFrames = Header.NumFrames;
				mdlInfo.meshList[0].meshHeader.NumSkins = Header.NumSkins;
				mdlInfo.meshList[0].meshHeader.NumVerts = Header.NumVerts;
				mdlInfo.meshList[0].meshHeader.NumTris = Header.NumTris;

				// Maybe no skins!! (EEK!) -> Allow them to load later... (from .pcx's this version)
				if (Header.NumSkins > 0)
					fileIn.BaseStream.Seek(Header.offsetSkins, System.IO.SeekOrigin.Begin);
				
				// Set this up even if there are no skins associated, so that if we load them later we don't have to do it
				mdlInfo.meshList[0].skin.NextB = 1;
				mdlInfo.meshList[0].skin.Time = null;
				mdlInfo.meshList[0].skin.GroupSkinNodes = null;
				mdlInfo.meshList[0].skin.SkinNode = new byte[Header.SkinHeight * Header.SkinWidth];
				
				// Load skins (== Load one skin, and the paths to the rest)
				for(count = 0; count < Header.NumSkins; count++)
				{
					// No .md2 seem to use this, just associated filenames
				}

				// This only works if the pcx name is the same as the mdl + .pcx (i.e. tris.md2 and tris.pcx)
				associatedPcx = Path.ChangeExtension(mdlInfo.Filename, "pcx");
				if (File.Exists(associatedPcx)) 
					pcxSkinLoader(associatedPcx, mdlInfo);

				// Load texture coordinates
				fileIn.BaseStream.Seek(Header.offsetTexCoords, System.IO.SeekOrigin.Begin);
				mdlInfo.meshList[0].SkinVertices = new SkinVerts[Header.NumTexCoords];
				for (count = 0; count < Header.NumTexCoords; count++)
				{
					// Quake 2 mdls don't have the concept of OnSeam! (Yeah!)
					mdlInfo.meshList[0].SkinVertices[count].OnSeam = 0;
					mdlInfo.meshList[0].SkinVertices[count].S = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinVertices[count].T = (int)fileIn.ReadInt16();
				}

				// Load Triangls!
				mdlInfo.meshList[0].SkinTriangles = new SkinTris[Header.NumTris];
				for (count = 0; count < Header.NumTris; count++)
				{
					// Quake 2 mdls don't have the concept of 'faces front'! (Yeah!)
					mdlInfo.meshList[0].SkinTriangles[count].FacesFront = 1;
					mdlInfo.meshList[0].SkinTriangles[count].VerticesX = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinTriangles[count].VerticesY = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinTriangles[count].VerticesZ = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexX = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexY = (int)fileIn.ReadInt16();
					mdlInfo.meshList[0].SkinTriangles[count].texIndexZ = (int)fileIn.ReadInt16();
				}

				mdlInfo.meshList[0].Frames = new FrameNodes[Header.NumFrames];
				LastGroupName = "";
				sequenceList = new TempAnimationFrame[Header.NumFrames];
				numberOfSequences = 0;
				for (count = 0; count < Header.NumFrames; count++)
				{
					// Quake 2 .mdls don't have different frame types (or bounding boxes, or group frames!)
					mdlInfo.meshList[0].Frames[count].FrameData = new TriVertex[Header.NumVerts];
					mdlInfo.meshList[0].Frames[count].normalList = new Vector[Header.NumTris];

					ScaleX = fileIn.ReadSingle();
					ScaleY = fileIn.ReadSingle();
					ScaleZ = fileIn.ReadSingle();
					OffsetX = fileIn.ReadSingle();
					OffsetY = fileIn.ReadSingle();
					OffsetZ = fileIn.ReadSingle();

					// Read in the frame name
					mdlInfo.meshList[0].Frames[count].Name = new byte[16];
					for (offsetCount = 0; offsetCount < 16; offsetCount++)
						mdlInfo.meshList[0].Frames[count].Name[offsetCount] = fileIn.ReadByte();
					GroupName = MdlFileV6.parseGroupName(mdlInfo.meshList[0].Frames[count].Name);
					// Generate sequences based on groupnames
					if (GroupName != LastGroupName)
					{
						sequenceList[numberOfSequences].AnimationName = GroupName;
						sequenceList[numberOfSequences].frameOffset = count;
						numberOfSequences++;
						LastGroupName = GroupName;
					}
					for (unpackFrame = 0; unpackFrame < Header.NumVerts; unpackFrame++)
					{
						mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.x = 
							fileIn.ReadByte() * ScaleX + OffsetX;
						mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.y = 
							fileIn.ReadByte() * ScaleY + OffsetY;
						mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].points.z = 
							fileIn.ReadByte() * ScaleZ + OffsetZ;
						mdlInfo.meshList[0].Frames[count].FrameData[unpackFrame].LightNormalIndex =
							fileIn.ReadByte();
					}
					// Calculate normals for later backface culling
					for (polCount = 0; polCount < Header.NumTris; polCount++)
					{
						u = Model.MakeVector(mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesX].points,
							mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesY].points);
						v = Model.MakeVector(mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesY].points,
							mdlInfo.meshList[0].Frames[count].FrameData[mdlInfo.meshList[0].SkinTriangles[polCount].VerticesZ].points);
						mdlInfo.meshList[0].Frames[count].normalList[polCount] = Model.CrossProduct(v, u);
					}
				}

				mdlInfo.fAnimationSequences = new AnimationFrame[numberOfSequences];
				for (count = 0; count < numberOfSequences - 1; count++)
				{
					mdlInfo.fAnimationSequences[count].AnimationName = sequenceList[count].AnimationName;
					mdlInfo.fAnimationSequences[count].AnimationType = enumAnimationType.All;
					mdlInfo.fAnimationSequences[count].FirstFrame = sequenceList[count].frameOffset;
					mdlInfo.fAnimationSequences[count].NumFrames = sequenceList[count + 1].frameOffset -
						sequenceList[count].frameOffset;
					// *Very* arbitrary #
					mdlInfo.fAnimationSequences[count].FramesPerSecond = 20;
				}
				mdlInfo.fAnimationSequences[numberOfSequences - 1].AnimationName = sequenceList[numberOfSequences - 1].AnimationName;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].FirstFrame = sequenceList[numberOfSequences - 1].frameOffset;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].AnimationType = enumAnimationType.All;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].NumFrames = Header.NumFrames - 
					sequenceList[numberOfSequences - 1].frameOffset;
				mdlInfo.fAnimationSequences[numberOfSequences - 1].FramesPerSecond = 20;

				mdlInfo.meshList[0].worldCoords = new Vector[Header.NumVerts];
				mdlInfo.meshList[0].cameraCoords = new Vector[Header.NumVerts];
				mdlInfo.meshList[0].rotateList = new byte[Header.NumVerts];

				returnValue = true;
			}
			catch(Exception e)
			{
				Console.WriteLine("Exception: " + e.ToString() + " occurred!");
			}

			return returnValue;
		}			

		/// <summary>
		/// Reads a pcx header from a buffer into a pcxheader structure
		/// </summary>
		/// <param name="headerBuffer">A buffer that holds info about the header</param>
		private unsafe static void parsePcxHeader(byte[] headerBuffer)
		{

			fixed(byte* pBuffer = headerBuffer)
			{
				// Get all information for header from byte buffer 
				pcxHeader = *((PcxHeader*)pBuffer);
				pcxHeader.NPlanes = *(pBuffer + 65);
				pcxHeader.BytesPerLine = *((short*)(pBuffer + 66));
			}
		}

		/// <summary>
		/// Very simplistic pcx loader
		/// </summary>
		/// <param name="FileName">The filename of the pcx to load</param>
		/// <param name="mdlInfo">Info about the mdlfile</param>
		/// <remarks>
		/// We currently only support one kind of pcx type (256 palette, encoded files)
		/// </remarks>
		internal static bool pcxSkinLoader(string FileName, MdlFile mdlInfo)
		{
			byte[] palette = new byte[768];

			FileInfo fileHandle = new FileInfo(FileName);
			bool returnValue = false;

			if (!fileHandle.Exists)
			{
				return false;
			}

			BinaryReader InFile = null;

			pcxHeader = new PcxHeader();
 
			try
			{
				InFile = new BinaryReader(fileHandle.OpenRead());
				byte[] buffer = new byte[128];
				int XSize, YSize, count, index;
				byte processByte, colorByte;

				buffer = InFile.ReadBytes(128);
				parsePcxHeader(buffer);
				
				// We currently only support one kind of pcx type (256 palette, encoded files)
				if ((pcxHeader.Version == 5) && (pcxHeader.BitsPerPixel == 8) && 
					(pcxHeader.Encoding == 1) && (pcxHeader.NPlanes == 1)
					&& (pcxHeader.BytesPerLine == Header.SkinWidth))
				{
					XSize = pcxHeader.XMax - pcxHeader.XMin + 1;
					YSize = pcxHeader.YMax - pcxHeader.YMin + 1;					
					// Sanity check -> Make sure this skin should be associated with the .mdl
					if ((XSize * YSize) <= (Header.SkinHeight * Header.SkinWidth))
					{
						count = 0;
						while(count < XSize * YSize)
						{
							processByte = InFile.ReadByte();
							// Run length encoding
							if ((processByte & 192) == 192)
							{
								processByte &= 63;
								colorByte = InFile.ReadByte();
								for (index = 0; index < processByte; index++)
								{
									mdlInfo.meshList[0].skin.SkinNode[count] = colorByte;
									count++;
								}
							}
							else
							{
								mdlInfo.meshList[0].skin.SkinNode[count] = processByte;
								count++;
							}
						}

						// Now the palette!!!!
						InFile.BaseStream.Seek(-769, System.IO.SeekOrigin.End);
						processByte = InFile.ReadByte();
						if (processByte == 12)
						{
							for (count = 0; count < 768; count++)
								palette[count] = InFile.ReadByte();
							
							MainFrm.graphicsObject.paletteIndex = MainFrm.graphicsObject.paletteCount;
							MainFrm.graphicsObject.MakePal(palette);
							mdlInfo.meshList[0].skin.paletteIndex = MainFrm.graphicsObject.paletteCount;
							MainFrm.graphicsObject.paletteCount++;
						
							returnValue = true;
						}
						else 
							returnValue = false;
					}
					else 
						returnValue = false;
				}
				else
					returnValue = false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Exception: " + e.ToString() + " occurred!");
				returnValue = false;
			}
			finally
			{
				InFile.Close();
			}

			return returnValue;
		}
	}

}
