namespace MdlView
{
	using System;
	using System.Runtime.InteropServices;
	using DxVBLib;

	/// <summary>
	/// Redefine IDirectDrawSurface7 so that it supports marshaling
	/// </summary>
	/// <remarks>
	/// We don't have to write the signatures of methods we're not going to use
	/// </remarks>
	[Guid("9F76FDE8-8E92-11D1-8808-00C04FC2C602")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectDrawSurface7
	{
		void reserved1();
		void reserved2();
		void reserved3();

		/// <summary>
		/// Blit the rectangle from the source DirectDraw surface 
		/// to this DirectDraw surface
		/// </summary>
		/// <param name="destRect">The destination rectangle</param>
		/// <param name="dds">The source DirectDraw surface</param>
		/// <param name="srcRect">The source rectangle</param>
		/// <param name="flags">Flags</param>
		int Blt( ref RECT destRect, 
			     IDirectDrawSurface7 ddS, 
			     ref RECT srcRect, 
				 CONST_DDBLTFLAGS flags);

		/// <summary>
		/// Fill the surface with a color
		/// </summary>
		/// <param name="destRect">The destination rect for the fill</param>
		/// <param name="fillValue">The color to fill with</param>
		int BltColorFill([In, Out] ref RECT destRect, 
			              int fillvalue);

		void reserved6();
		void reserved7();
		void reserved8();
		void reserved9();
		void reserved10();
		void reserved11();
		void reserved12();
		void reserved13();
		void reserved14();
		void reserved15();
		void reserved16();
		void reserved17();
		void reserved18();
		void reserved19();
		void reserved20();
		void reserved21();
		void reserved22();
		void reserved23();
		void reserved24();
		void reserved25();
		void reserved26();
		void reserved27();
		void reserved28();
		void reserved29();
		void reserved30();
		void reserved31();
		void reserved32();
		void reserved33();
		void reserved34();
		void reserved35();
		void reserved36();
		void reserved37();
		void reserved38();
		void reserved39();
		void reserved40();

		/// <summary>
		/// Locks a surface and allows direct memory access
		/// </summary>
		/// <param name="r">The rectangle that should be locked</param>
		/// <param name="desc">A description of the surface, returns the pointer</param>
		/// <param name="flags">Flags for locking</param>
		/// <param name="hnd">Should be 0</param>
		[PreserveSig(true)]
		uint Lock( [In, Out, ParamArray] ref RECT r, 
			       [In, Out] ref DDSURFACEDESC2 desc,
			       [In] CONST_DDLOCKFLAGS flags, 
				   [In] long hnd);

		void reserved42();
		void reserved43();

		/// <summary>
		/// Sets a clipper to a surface
		/// </summary>
		/// <param name="val">A directDraw clipper</param>
		void SetClipper([In, ParamArray] DirectDrawClipper val);

		void reserved45();
		void reserved46();
		void reserved47();
		void reserved48();
		void reserved49();
		void reserved50();
		void reserved51();
		void reserved52();
		void reserved53();
		void reserved54();

		/// <summary>
		/// Unlock needs to be called after lock
		/// </summary>
		/// <param name="r">The rect that should be unlocked</param>
		void Unlock([In, Out, ParamArray] ref RECT r);

		void reserved56();
		void reserved57();
		void reserved58();

		/// <summary>
		/// Returns a byte array of the surface.  This function should not be used in the managed environment 
		/// because the array gets marshaled (copied)
		/// </summary>
		/// <param name="array">The byte array that gets returned</param>
		void GetLockedArray([In, Out, ParamArray] ref byte[] array);

		void reserved61();
		void reserved62();
		void reserved63();
		void reserved64();
		void reserved65();
		void reserved66();
		void reserved67();
		void reserved68();
	}
}