//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Web.Services;
using System.IO;
using System.Drawing;

[WebService(Namespace="http://msdn.microsoft.com/csharp/")]
public class ImageService: System.Web.Services.WebService
{

	#region " Web Services Designer Generated Code ";

	public ImageService () 
	{

		//This call is required by the Web Services Designer.
		InitializeComponent();
		//Add your own initialization code after the InitializeComponent() call

	}

	//Required by the Web Services Designer

	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Web Services Designer

	//It can be modified using the Web Services Designer.  

	//Do not modify it using the code editor.

	private void InitializeComponent() 
	{

		components = new System.ComponentModel.Container();

	}

	protected override void Dispose(bool disposing) 
	{

		//CODEGEN: This procedure is required by the Web Services Designer

		//Do not modify it using the code editor.

		if (disposing) 
		{

			if (components != null) 
			{

				components.Dispose();

			}

		}

		base.Dispose(disposing);

	}

	#endregion

	public class ImageInfo
	{

		public string Name;
		public Int64 Size;
		public int Height;
		public int Width;
		public float HorizontalResolution;
		public float VerticalResolution;
		public System.Drawing.Imaging.PixelFormat PixelFormat;
		public byte[] Thumbnail;
	}

	[WebMethod(Description="Retrieve an array of image file names.")]
	public ImageInfo[] Browse()
	{
		DirectoryInfo di = new DirectoryInfo(Server.MapPath("Images"));

		FileInfo[] afi = di.GetFiles("*.jpg");

		ImageInfo[] aImages = new ImageInfo[afi.Length];

		int i = 0;

		foreach(FileInfo fi in afi)
		{
			aImages[i] = new ImageInfo();
			aImages[i].Name = fi.Name;
			aImages[i].Size = fi.Length;
			FillImageInfo(aImages[i], fi.Name);
			i += 1;
		}

		return aImages;

	}

	private void FillImageInfo(ImageInfo Info, string FileName)
	{

		MemoryStream ms = new MemoryStream();
		Bitmap bmp = new Bitmap(Server.MapPath(@"Images/" + FileName));
		Info.Width = bmp.Width;
		Info.Height = bmp.Height;
		Info.HorizontalResolution = bmp.HorizontalResolution;
		Info.VerticalResolution = bmp.VerticalResolution;
		Info.Thumbnail = GetThumbnailInfo(bmp);
		Info.PixelFormat = bmp.PixelFormat;
		bmp.Dispose();

	}

	[WebMethod(Description="Retrieve an individual thumbnail.")]
	public byte[] GetThumbnail(string FileName)
	{

		Bitmap bmp = new Bitmap(Server.MapPath(@"./Images/" + FileName));
		return GetThumbnailInfo(bmp);

	}

	private bool ThumbnailCallback()
	{

		// You have to supply this delegate, even though the thumbnail
		// retrieval doesn't actually use it. See the documentation 
		// for more information.
		return false;

	}

	private byte[] GetThumbnailInfo(Bitmap bmp)
	{

		MemoryStream ms = new MemoryStream();
		int intWidth;
		int intHeight;
		decimal decRatio;

		// We've selected 80 pixels the arbitrary height 
		// for the thumbnails. The code preserves the size ratio, 
		// given this height. if you want larger thumbnails, you can 
		// modify this value.

		const int THUMBNAIL_HEIGHT = 80;
		intWidth = bmp.Width;
		intHeight = bmp.Height;
		//decRatio = Convert.ToDecimal(intWidth / intHeight);
		decRatio = decimal.Divide(intWidth,intHeight);
		
		Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);


		Bitmap bmpTemp = (Bitmap)(bmp.GetThumbnailImage(Convert.ToInt32(decRatio * THUMBNAIL_HEIGHT), THUMBNAIL_HEIGHT, myCallback, IntPtr.Zero));
		bmpTemp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
		return ms.ToArray();

	}

	[WebMethod(Description="Retrieve a single image.")]
	public byte[] GetImage(string FileName)
	{

		return ReadFile(Server.MapPath(@"./Images/" + FileName));

	}

	private static byte[] ReadFile(string FilePath)
	{
		FileStream fs = null;
		try 
		{
			// Read file and return contents

			fs = File.Open(FilePath, FileMode.Open, FileAccess.Read);
			long lngLen = fs.Length;
			byte[] abytBuffer = new byte[(int) lngLen];

			fs.Read(abytBuffer, 0, (int) lngLen);

			return abytBuffer;
		}
		finally
		{
			// Make sure that file stream is 
			// closed even if an error occurs.
			fs.Close();
		}

	}

	#region " Helper Class ";

	[WebMethod(Description="Retrieves version + copyright information about this web service.")]
	public string About()
	{

		// Uses the stringWriter to build a string with carriage returns + line feeds to
		// return back to a calling client the Title, Version, and Description by
		// reading Assembly meta-data originally entered in the AssemblyInfo.cs file
		// using the AssemblyInfo class defined in the same file.

		try 
		{

			StringWriter sw = new StringWriter();
			AssemblyInfo ainfo  = new AssemblyInfo();

			sw.WriteLine(ainfo.Title);
			sw.WriteLine(string.Format("Version {0}", ainfo.Version));
			sw.WriteLine(ainfo.Copyright);
			sw.WriteLine("");
			sw.WriteLine(ainfo.Description);
			sw.WriteLine("");
			sw.WriteLine(ainfo.CodeBase);
			
			string strRetVal = sw.ToString();
			sw.Close();
			return strRetVal;
		}
		catch (Exception exp) 
		{

			return exp.Message;

		}

	}

	#endregion

}

