//===========================================================================
//	File:		DisplayCardInfo.cs
//
//	Summary:	Interacts with a COM component (DirectX) to display the
//				capabilities of the current hardware.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================
using System;
using DxVBLib;

public class DisplayCardInfo
{
	private static DirectX7 DirectX;

	public static void Main()
	{
		DirectX = new DirectX7();
		GetDisplayCards();
	}

	private static void GetDisplayCards()
	{
		/* Some systems will have multiple display cards
		 * or daughter cards for 3D support.  If you want
		 * to draw to more than just the primary display
		 * or search for 3D hardware not on the primary
		 * display card, you can use this code to search
		 * for such devices.
		 * The Guid identifies the device.  On the primary
		 * primary display this will return an empty string.
		 */
    
		DirectDrawEnum ddEnum;
		string guid;
    
		ddEnum = DirectX.GetDDEnum();
		Console.WriteLine("Display Cards:");

		for (int i = 1; i <= ddEnum.GetCount(); i++)
		{
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(" Card Number  " + i.ToString());
			Console.WriteLine(" Description  " + ddEnum.GetDescription(i));
			Console.WriteLine(" Name         " + ddEnum.GetName(i));
			Console.WriteLine(" Guid         " + ddEnum.GetGuid(i));
        
			guid = ddEnum.GetGuid(i);

			GetDDCaps(guid);
			GetD3DDevices(guid);
			GetDisplayModes(guid);
	        }
	}

	private static void GetDDCaps(string guid)
	{
		DirectDraw7 DirectDraw;
		DDCAPS hwCaps = new DDCAPS();		// Hardware
		DDCAPS helCaps = new DDCAPS();		// Software Emulation

		DirectDraw = DirectX.DirectDrawCreate(guid);
    
		/* It's a good idea to see out if the hardware supports
		 * a feature.  Many unsupported features are emulated but
		 * are much slower.
		 */
		
		DirectDraw.GetCaps(ref hwCaps, ref helCaps);
    
		// How much video memory is available?
		Console.WriteLine("\n HW CAPS:\n");
		Console.WriteLine("   Total Video Memory " + hwCaps.lVidMemTotal.ToString());
		Console.WriteLine("   Free Video Memory  " + hwCaps.lVidMemFree.ToString());
    
   		// Palette Support

		CONST_DDPCAPSFLAGS value = hwCaps.lPalCaps;
		if (value == 0) Console.WriteLine("   No HW palette support.");
		if ((value & CONST_DDPCAPSFLAGS.DDPCAPS_1BIT) > 0) Console.WriteLine("   Palette supports 1bpp ");
		if ((value & CONST_DDPCAPSFLAGS.DDPCAPS_2BIT) > 0) Console.WriteLine("   Palette supports 2bit ");
		if ((value & CONST_DDPCAPSFLAGS.DDPCAPS_8BIT) > 0) Console.WriteLine("   Palette supports 8bit ");
		if ((value & CONST_DDPCAPSFLAGS.DDPCAPS_8BITENTRIES) > 0) Console.WriteLine("   Palette supports 8bit entries");
		if ((value & CONST_DDPCAPSFLAGS.DDPCAPS_ALLOW256) > 0) Console.WriteLine("   Palette supports setting all 256 colors.");

		// So we support the gamma ramp interface?
		if (((int)hwCaps.ddsCaps.lCaps2 & (int)CONST_DDCAPS2FLAGS.DDCAPS2_CANCALIBRATEGAMMA) > 0)
			Console.WriteLine("   Supports gamma correction.");
		else
			Console.WriteLine("   No support for gamma correction.");
	}

	private static void GetD3DDevices(string guid)
	{
		Direct3DEnumDevices d3dEnum;
		D3DDEVICEDESC7 hwDesc = new D3DDEVICEDESC7();
		DirectDraw7 DirectDraw;
		Direct3D7 d3d;

		DirectDraw = DirectX.DirectDrawCreate(guid);
		d3d = DirectDraw.GetDirect3D();

		Console.WriteLine("\n D3D devices:\n");
    
		d3dEnum = d3d.GetDevicesEnum();

		for (int i = 1; i <= d3dEnum.GetCount(); i++)
		{
			d3dEnum.GetDesc(i, ref hwDesc);
        
			Console.WriteLine(" Description  " + d3dEnum.GetDescription(i));
			Console.WriteLine(" Name         " + d3dEnum.GetName(i));
			Console.WriteLine(" Guid         " + d3dEnum.GetGuid(i));
			Console.WriteLine(" Device:");

			Console.WriteLine("     Max Texture Height  " + hwDesc.lMaxTextureHeight.ToString());
			Console.WriteLine("     Max Texture Width   " + hwDesc.lMaxTextureWidth.ToString());

			if ((hwDesc.lDeviceRenderBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_8) > 0) Console.WriteLine("     Supports rendering to 8 bit.");
			if ((hwDesc.lDeviceRenderBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_16) > 0) Console.WriteLine("     Supports rendering to 16 bit.");
			if ((hwDesc.lDeviceRenderBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_24) > 0) Console.WriteLine("     Supports rendering to 24 bit.");
			if ((hwDesc.lDeviceRenderBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_32) > 0) Console.WriteLine("     Supports rendering to 32 bit.");

			if ((hwDesc.lDeviceZBufferBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_8) > 0) Console.WriteLine("     Supports 8 bit Z Buffer.");
			if ((hwDesc.lDeviceZBufferBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_16) > 0) Console.WriteLine("     Supports 16 bit Z Buffer.");
			if ((hwDesc.lDeviceZBufferBitDepth & (int)(int)CONST_DDBITDEPTHFLAGS.DDBD_24) > 0) Console.WriteLine("     Supports 24 bit Z Buffer.");
			if ((hwDesc.lDeviceZBufferBitDepth & (int)CONST_DDBITDEPTHFLAGS.DDBD_32) > 0) Console.WriteLine("     Supports 32 bit Z Buffer.");
			if (hwDesc.lDeviceZBufferBitDepth == 0) Console.WriteLine("     No Z Buffer support.");

			if ((hwDesc.lDevCaps & CONST_D3DDEVICEDESCCAPS.D3DDEVCAPS_TEXTURENONLOCALVIDMEM) > 0) Console.WriteLine("     Supports AGP textures.");
			if ((hwDesc.lDevCaps & CONST_D3DDEVICEDESCCAPS.D3DDEVCAPS_SORTDECREASINGZ) > 0) Console.WriteLine("     IM triangles must be sorted by decreasing depth.");
			if ((hwDesc.lDevCaps & CONST_D3DDEVICEDESCCAPS.D3DDEVCAPS_SORTEXACT) > 0) Console.WriteLine("     IM triangles must be sorted exactly.");
			if ((hwDesc.lDevCaps & CONST_D3DDEVICEDESCCAPS.D3DDEVCAPS_SORTINCREASINGZ) > 0) Console.WriteLine("     IM triangles must be sorted by increasing depth.");
			if ((hwDesc.lDevCaps & CONST_D3DDEVICEDESCCAPS.D3DDEVCAPS_TEXTUREVIDEOMEMORY) > 0) Console.WriteLine("     IM can use video memory to store textures.");

			Console.WriteLine("");
        	}
	}

	public static void GetDisplayModes(string guid)
	{
		/* This is how to determine what resoultions are supported.
		 * Some cards will report zero for the refresh rate.
		 */

		DirectDrawEnumModes DisplayModesEnum;
		DDSURFACEDESC2 ddsd2 = new DDSURFACEDESC2();
		DirectDraw7 DirectDraw;

		DirectDraw = DirectX.DirectDrawCreate(guid);
		DisplayModesEnum = DirectDraw.GetDisplayModesEnum(0, ref ddsd2);
		Console.WriteLine(" Display Modes:\n");

		for (int i = 1; i <= DisplayModesEnum.GetCount(); i++)
		{
			DisplayModesEnum.GetItem(i, ref ddsd2);
			Console.WriteLine("  Display Mode   " + i.ToString());
			Console.WriteLine("  Width          " + ddsd2.lWidth.ToString());
			Console.WriteLine("  Height         " + ddsd2.lHeight.ToString());
			Console.WriteLine("  Bits Per Pixel " + ddsd2.ddpfPixelFormat.lRGBBitCount.ToString());
			Console.WriteLine("  Refresh Rate   " + ddsd2.lRefreshRate.ToString() + "\n");
		}
	}
}