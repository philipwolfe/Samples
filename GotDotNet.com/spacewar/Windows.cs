namespace SpaceWar
{
	using System;
	using System.Runtime.InteropServices;

	/// <summary>
	///		Summary description for Windows.
	/// </summary>
	public class Windows
	{
		private Windows()
		{
		}

		const int BITSPIXEL = 12;	// from wingdi.h

		public static int GetBitsPerPixel()
		{
			int ScreenDC = CreateIC("Display", null, null, 0);
			int bitsPerPixel = GetDeviceCaps(ScreenDC, BITSPIXEL);
			DeleteDC(ScreenDC);

			return(bitsPerPixel);
		}

		[DllImport("GDI32.dll")]
		private static extern int CreateIC(
			string driverName,
			string deviceName,
			string outputName,
			int unusedInitData);

		[DllImport("GDI32.dll")]
		private static extern int GetDeviceCaps(
			int hdc, 
			int nIndex );

		[DllImport("GDI32.dll")]
		private static extern bool DeleteDC(int hdc);
	}
}
