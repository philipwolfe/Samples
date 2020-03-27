namespace MdlView
{
	using System;
	using System.Runtime.InteropServices;

	/// <summary>
	/// Enum for the current rendering format.  We only support wireframe and texture mapped at the moment.
	/// </summary>
	public enum enumRenderingMode 
	{
		Skins,
		TextureMap, 
		GouradShade,
		PhongShade,
		TextureGourad,
		WireFrame,
		AntiAliasedWireFrame
	}
		
	/// <summary>
	/// A structure that holds a vector (sequential)
	/// </summary>
	/// <remarks>
	/// This struct is marked with the sequential attribute so that we can blast bits into it from a cast (in unsafe blocks)
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	internal struct Vector 
	{		
		internal float x;
		internal float y;
		internal float z;
	}

	/// <summary>
	/// A basic triangle vertex; holds a normal as well (actually an offset into a table)
	/// </summary>
	/// <remarks>
	/// We don't actually use the normal because we don't do shading.
	/// </remarks>
	internal struct TriVertex
	{
		internal Vector points;
		internal int LightNormalIndex;
	}

	/// <summary>
	/// Structure that contains information about the texture of the model
	/// </summary>
	internal struct Skin 
	{
		// This is an offset into the palette array that the graphics object holds (0-3)
		internal int paletteIndex;
		// A flag indicating whether or not there are a group of textures in this skin (usually 1)
		internal int Group;
		internal int NextB;
		// If there are multiple textures in the skin this holds the length of time for the display of each
		internal float[] Time;
		// A simple byte array that holds the actual texture (these are offsets into a palette)
		internal byte[] SkinNode;
		// This is used if there are multiple textures 'per skin' (only used in Quake I models)
		internal byte[,] GroupSkinNodes;
	}

	/// <summary>
	/// Structure that contains information about vertices on the skin
	/// </summary>
	internal struct SkinVerts 
	{
		// Used in Quake I to indicate that the vert is located on the 'seam' between the front and back of the skin
		internal int OnSeam;
		// Offsets onto the texture
		internal int S, T;
	}

	/// <summary>
	/// Structure that describes a triangle (Quake II added a difference between triangles on the skin, and in the frame) 
	/// </summary>
	internal struct SkinTris
	{
		internal int FacesFront;
		// Holds offsets into the frame vert list (connects those verts to make triangles)
		internal int VerticesX, VerticesY, VerticesZ;
		// Holds offsets into the skin verts (these are the same as the VerticesX(Y)(Z), for Quake I models)
		internal int texIndexX, texIndexY, texIndexZ;
	}

	/// <summary>
	/// Structure that contains information about each frame (models have animation frames that are lists of vertices)
	/// </summary>
	internal struct FrameNodes
	{
		// Information about the bounding box for the frame (used in Quake I)
		internal TriVertex Min;
		internal TriVertex Max;
		// The name of the frame, we use this to create 'sequences' 
		internal byte[] Name;
		// A list of normals that we use for backface culling
		internal Vector[] normalList;
		// The meat of the frame, the actual vertex list
		internal TriVertex[] FrameData;
	}

	/// <summary>
	/// A basic structure that we use for user positions mostly
	/// </summary>
	public struct Position
	{
		public int X, Y, Z;
	}

	/// <summary>
	/// Header struct for the MDL File (Quake 1).
	/// </summary>
	/// <remarks>
	/// This struct is marked with the explicit attribute so that we can blast bits into it from a cast (in unsafe blocks)
	/// </remarks>
	[StructLayout(LayoutKind.Explicit)]
	internal struct MdlHeaderV6
	{
		[FieldOffset(0)]		
		internal int ID;
		[FieldOffset(4)]
		internal int Version;
		[FieldOffset(8)]				
		internal Vector scale;
		[FieldOffset(20)]
		internal Vector origin;
		[FieldOffset(32)]
		internal float Radius;
		[FieldOffset(36)]
		internal Vector offsets;
		[FieldOffset(48)]
		internal int NumSkins;
		[FieldOffset(52)]
		internal int SkinWidth;
		[FieldOffset(56)]
		internal int SkinHeight;
		[FieldOffset(60)]
		internal int NumVerts;
		[FieldOffset(64)]
		internal int NumTris;
		[FieldOffset(68)]
		internal int NumFrames;
		[FieldOffset(72)]
		internal int SyncType;
		[FieldOffset(76)]
		internal int Flags;
		[FieldOffset(80)]
		internal float Size;
	}

	/// <summary>
	/// Header struct for the MDL File (Quake 2).
	/// </summary>
	/// <remarks>
	/// This struct is marked with the sequential attribute so that we can blast bits into it from a cast (in unsafe blocks)
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	internal struct MdlHeaderV8
	{
		internal int ID;
		internal int Version;
		internal int SkinWidth;
		internal int SkinHeight;
		internal int FrameSize;
		internal int NumSkins;
		internal int NumVerts;
		internal int NumTexCoords;
		internal int NumTris;
		internal int NumGLCommands;
		internal int NumFrames;
		internal int offsetSkins;
		internal int offsetTexCoords;
		internal int offsetTriangles;
		internal int offsetFrames;
		internal int offsetGLCommands;
		internal int offsetEnd;
	}

	/// <summary>
	/// A "generic" Mdl header (versions 6, 8)
	/// </summary>
	internal struct GenericMdlHeader
	{
		internal int Version;
		internal string Filename;
		internal int NumMeshes;
		internal int SkinWidth;
		internal int SkinHeight;		
	}

	/// <summary>
	/// A header for a mesh, Quake I and II models really only have one mesh (per .mdl file anyhow)
	/// </summary>
	internal struct MeshHeader
	{
		internal byte[] Name;
		internal int NumFrames;
		internal int NumSkins;
		internal int NumVerts;
		internal int NumTris;
		internal int NumTexCoords;		
	}

	/// <summary>
	/// Generic header for a pcx file.  
	/// </summary>
	/// <remarks>
	/// Robust? nope.  This structure doesn't even have a definition for the 16-byte palette that can be in the header.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	internal struct PcxHeader
	{
		internal byte Manufacturer;
		internal byte Version;
		internal byte Encoding;
		internal byte BitsPerPixel;
		internal short XMin;
		internal short YMin;
		internal short XMax; 
		internal short YMax;
		internal short HDpi;
		internal short VDpi;
		// There should actually be an array of 48 in-between these two values, but we don't need it
		internal byte NPlanes;
		internal short BytesPerLine;
	}

	/// <summary>
	/// An enum that holds information about which part to animate per animation sequence
	/// </summary>
	/// <remarks>
	/// Not really used yet.
	/// </remarks>
	internal enum enumAnimationType
	{
		Both,
		Legs,
		Torso,
		Weapon,
		All
	}

	/// <summary>
	/// An enumeration that holds information about the footstep type of a given model
	/// </summary>
	/// <remarks>
	/// Not really used yet.
	/// </remarks>
	internal enum enumFootstepType
	{
		Default,
		Normal,
		Boot,
		Flesh,
		Mech,
		Energy,
		Unkown
	}

	/// <summary>
	/// Holds information about a given animation frame (a sequence)
	/// </summary>
	internal struct AnimationFrame
	{
		internal string AnimationName;
		internal enumAnimationType AnimationType;
		internal int FirstFrame;
		internal int NumFrames;
		internal int LoopFrames;
		internal int FramesPerSecond;
	}

	/// <summary>
	/// Holds information that is used before we fill out the more robust AnimationFrame structure
	/// </summary>
	internal struct TempAnimationFrame
	{
		internal string AnimationName;
		internal int frameOffset;
	}
}