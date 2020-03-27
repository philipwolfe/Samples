'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Web.Services
Imports System.IO
Imports System.Drawing

<WebService(Namespace:="http://msdn.microsoft.com/vbasic/")> _
Public Class ImageService
	Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Web Services Designer.
		InitializeComponent()

		'Add your own initialization code after the InitializeComponent() call

	End Sub

	'Required by the Web Services Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Web Services Designer
	'It can be modified using the Web Services Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		components = New System.ComponentModel.Container()
	End Sub

	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		'CODEGEN: This procedure is required by the Web Services Designer
		'Do not modify it using the code editor.
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

#End Region

	Public Class ImageInfo
		Public Name As String
		Public Size As Long
		Public Height As Integer
		Public Width As Integer
		Public HorizontalResolution As Single
		Public VerticalResolution As Single
		Public PixelFormat As Imaging.PixelFormat
		Public Thumbnail As Byte()
	End Class

	<WebMethod(Description:="Retrieve an array of image file names.")> _
	Public Function Browse() As ImageInfo()
		Dim i As Integer

		Dim fi As FileInfo
		Dim aImages As ImageInfo()

		Dim di As New DirectoryInfo( _
		 Server.MapPath("./Images"))
		Dim afi As FileInfo() = _
		 di.GetFiles("*.jpg")

		ReDim Preserve aImages(afi.Length - 1)
		For Each fi In afi
			aImages(i) = New ImageInfo()
			aImages(i).Name = fi.Name
			aImages(i).Size = fi.Length
			FillImageInfo(aImages(i), fi.Name)
			i += 1
		Next
		Return aImages
	End Function

	Private Sub FillImageInfo(ByVal Info As ImageInfo, ByVal FileName As String)
		Dim ms As New MemoryStream()
		Dim bmp As New Bitmap(Server.MapPath("./Images/" & FileName))

		Info.Width = bmp.Width
		Info.Height = bmp.Height
		Info.HorizontalResolution = bmp.HorizontalResolution
		Info.VerticalResolution = bmp.VerticalResolution
		Info.Thumbnail = GetThumbnailInfo(bmp)
		Info.PixelFormat = bmp.PixelFormat
		bmp.Dispose()
	End Sub

	<WebMethod(Description:="Retrieve an individual thumbnail.")> _
	Public Function GetThumbnail(ByVal FileName As String) As Byte()
		Dim bmp As New Bitmap(Server.MapPath("./Images/" & FileName))
		Return GetThumbnailInfo(bmp)
	End Function

	Private Function ThumbnailCallback() As Boolean
		' You have to supply this delegate, even though the thumbnail
		' retrieval doesn't actually use it. See the documentation 
		' for more information.
		Return False
	End Function

	Private Function GetThumbnailInfo(ByVal bmp As Bitmap) As Byte()
		Dim ms As New MemoryStream()
		Dim intWidth As Integer
		Dim intHeight As Integer
		Dim decRatio As Decimal

		' We've selected 80 pixels as the arbitrary height 
		' for the thumbnails. The code preserves the size ratio, 
		' given this height. If you want larger thumbnails, you can 
		' modify this value.
		Const THUMBNAIL_HEIGHT As Integer = 80

		intWidth = bmp.Width
		intHeight = bmp.Height
		decRatio = CDec(intWidth / intHeight)

		Dim bmpTemp As Bitmap
		bmpTemp = CType(bmp.GetThumbnailImage(CInt(decRatio * THUMBNAIL_HEIGHT), THUMBNAIL_HEIGHT, AddressOf ThumbnailCallback, IntPtr.Zero), System.Drawing.Bitmap)
		bmpTemp.Save(ms, Imaging.ImageFormat.Jpeg)
		Return ms.ToArray
	End Function

	<WebMethod(Description:="Retrieve a single image.")> _
	Public Function GetImage(ByVal FileName As String) As Byte()
		Return ReadFile(Server.MapPath("./Images/" & FileName))
	End Function

	Private Shared Function ReadFile(ByVal FilePath As String) As Byte()
		Dim fs As FileStream

		Try
			' Read file and return contents
			fs = File.Open(FilePath, FileMode.Open, FileAccess.Read)

			Dim lngLen As Long = fs.Length
			Dim abytBuffer(CInt(lngLen - 1)) As Byte
			fs.Read(abytBuffer, 0, CInt(lngLen))
			Return abytBuffer

		Finally
			' Make sure that file stream is 
			' closed even if an error occurs.
			fs.Close()
		End Try
	End Function

#Region " Helper Function "
	<WebMethod(Description:="Retrieves version & copyright information about this web service.")> Public Function About() As String
		' Uses the StringWriter to build a string with carriage returns & line feeds to
		' return back to a calling client the Title, Version, and Description by
		' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
		' using the AssemblyInfo class defined in the same file.

		Try
			Dim sw As New System.IO.StringWriter()
			Dim ainfo As New AssemblyInfo()

			With sw
				.WriteLine(ainfo.Title)
				.WriteLine(String.Format("Version {0}", ainfo.Version))
				.WriteLine(ainfo.Copyright)
				.WriteLine("")
				.WriteLine(ainfo.Description)
				.WriteLine("")
				.WriteLine(ainfo.CodeBase)
			End With

			Dim strRetVal As String = sw.ToString
			sw.Close()

			Return strRetVal
		Catch exp As Exception
			Return exp.Message
		End Try
	End Function
#End Region

End Class
