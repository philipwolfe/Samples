''===========================================================================
''	File:		Sample3Form.vb
''
''	Summary:	Interacts with a COM component (DirectX) in full-screen mode.
''
''---------------------------------------------------------------------------
''	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
''===========================================================================
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports Microsoft.VisualBasic
Imports DxVBLib

Public Class Sample3Form
	Inherits Form
    
	Private components As Container

	Dim DirectX As DirectX7
	Dim DirectDraw As DirectDraw7
	Dim lakesurf As DirectDrawSurface7
	Dim spritesurf As DirectDrawSurface7
	Dim primary As DirectDrawSurface7
	Dim backbuffer As DirectDrawSurface7

	Dim ddsd1 As DDSURFACEDESC2
	Dim ddsd2 As DDSURFACEDESC2
	Dim ddsd3 As DDSURFACEDESC2
	Dim ddsd4 As DDSURFACEDESC2
	Dim binit As Boolean
	Dim CurModeActiveStatus As Boolean
	Dim running As Boolean

	Shared a As Double
	Shared t As Double
	Shared t2 As Double
	Shared i As Integer
	Shared tLast As Double
	Shared tNow As Double
	Shared fps As Double

	Public Sub New()
		MyBase.New

		' This call is required for support of the WFC Form Designer.
		InitializeComponent

		DirectX = new DirectX7

		InitializeDirectX
	End Sub
    
	Private Sub InitializeComponent() 
		Me.components = New Container

		Me.BorderStyle = System.WinForms.FormBorderStyle.None
		Me.WindowState = System.WinForms.FormWindowState.Maximized
		Me.Text = "Interoperability with DirectX"

		' Event handlers
		Me.AddOnClick(New EventHandler(AddressOf Me.Form_Click))
		Me.AddOnPaint(New PaintEventHandler(AddressOf Me.Form_Paint))
	End Sub

	Private Sub Form_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		DirectDraw.RestoreDisplayMode
		DirectDraw.SetCooperativeLevel(Me.Handle, CONST_DDSCLFLAGS.DDSCL_NORMAL)
		Application.Exit()
		running = False
	End Sub

	Public Sub Form_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs)
	    Blt
	End Sub

	Private Sub InitializeDirectX()

		' The empty string parameter means to use the active display driver	
		DirectDraw = DirectX.DirectDrawCreate("")
		Me.Show
        
		' Indicate that this will be a full screen application
		' with the same display depth as the current display
		DirectDraw.SetCooperativeLevel(Me.Handle, CONST_DDSCLFLAGS.DDSCL_FULLSCREEN BitOr CONST_DDSCLFLAGS.DDSCL_ALLOWMODEX BitOr CONST_DDSCLFLAGS.DDSCL_EXCLUSIVE)
    
		DirectDraw.SetDisplayMode(640, 480, 16, 0, CONST_DDSDMFLAGS.DDSDM_DEFAULT)
    
		' Get the screen surface and create a back buffer
		ddsd1.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS BitOr CONST_DDSURFACEDESCFLAGS.DDSD_BACKBUFFERCOUNT
		ddsd1.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_PRIMARYSURFACE BitOr CONST_DDSURFACECAPSFLAGS.DDSCAPS_FLIP BitOr CONST_DDSURFACECAPSFLAGS.DDSCAPS_COMPLEX
		ddsd1.lBackBufferCount = 1
        
		primary = DirectDraw.CreateSurface(ddsd1)

		Dim caps As DDSCAPS2
		caps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_BACKBUFFER
		backbuffer = primary.GetAttachedSurface(caps)
    
		backbuffer.GetSurfaceDesc(ddsd4)
		backbuffer.SetFontTransparency(True)

		If Not InitializeSurfaces Then Exit Sub
		
		binit = True    
		running = True
		Do While running
			Blt
			Application.DoEvents
		Loop
	End Sub

	Function InitializeSurfaces() As Boolean
		lakesurf = Nothing
		spritesurf = Nothing
    
		' Load the bitmap into the second surface
		' (same size as the back buffer)

		ddsd2.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS BitOr CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT BitOr CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH
		ddsd2.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN
		ddsd2.lWidth = ddsd4.lWidth
		ddsd2.lHeight = ddsd4.lHeight

		Try		
			lakesurf = DirectDraw.CreateSurfaceFromFile("background.bmp", ddsd2)
		Catch e as System.Runtime.InteropServices.COMException
			' File Not Found
			If (e.ErrorCode = &H800A0035) Then
				MessageBox.Show("Could not find the file 'background.bmp'.  This must be placed in the current directory.", "Picture Not Found")
				Application.Exit()
				InitializeSurfaces = False
				Exit Function
			Else
				MessageBox.Show("Unexpected exception: " + e.ToString(), "Unexpected Exception")
				Application.Exit()
				InitializeSurfaces = False
				Exit Function
			End If
		End Try

		' Load the sprite bitmap into the second surface
		ddsd3.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS
		ddsd3.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN

		Try		
			spritesurf = DirectDraw.CreateSurfaceFromFile("sprite.bmp", ddsd3)
		Catch e as System.Runtime.InteropServices.COMException
			' File Not Found
			If (e.ErrorCode = &H800A0035) Then
				MessageBox.Show("Could not find the file 'sprite.bmp'.  This must be placed in the current directory.", "Picture Not Found")
				Application.Exit()
				InitializeSurfaces = False
				Exit Function
			Else
				MessageBox.Show("Unexpected exception: " + e.ToString(), "Unexpected Exception")
				Application.Exit()
				InitializeSurfaces = False
				Exit Function
			End If
		End Try
    
		' Use black for transparent color key
		Dim key As DDCOLORKEY
		key.low = 0
		key.high = 0

		' Assign the transparent color to the sprite object.
		' DDCKEY_SRCBLT specifies that when a blt is done the
		' transparent color is associated with the surface being
		' blitted and not the one being blitted to.
		SpriteSurf.SetColorKey(CONST_DDCKEYFLAGS.DDCKEY_SRCBLT, key)

		InitializeSurfaces = True
	End Function

	Sub Blt()
		If binit = False Then Exit Sub

		Dim rSprite As RECT
		Dim rSprite2 As RECT
		Dim rPrim As RECT

		Dim x As Double
		Dim y As Double
   
		' This will keep us from trying to blt in case we lose the surfaces (another app takes over)
		Dim bRestore As Boolean = False
		bRestore = False
		Do Until ExModeActive
			Application.DoEvents
			bRestore = True
		Loop

		' If we lost and got back the surfaces, then restore them
		Application.DoEvents
		If bRestore Then
			bRestore = False
			DirectDraw.RestoreAllSurfaces
			InitializeSurfaces ' must initialize the surfaces again if they were lost
		End If

		'get the rectangle for our source sprite
		rSprite.Bottom = ddsd3.lHeight
		rSprite.Right = ddsd3.lWidth

		' Calculate the angle for placing the sprite
		t2 = DateAndTime.Timer		
		If t <> 0 Then
		a = a + (t2 - t) * 80
			If a > 360 Then	a = a - 360		
		End If
		t = t2

		' Calculate the x y coordinate of where we place the sprite
		x = Math.Cos((a / 360) * 2 * 3.141) * 100
		y = Math.Sin((a / 360) * 2 * 3.141) * 100

		' Location on the screen where we want the sprite
		rSprite2.Top = CInt(y + Me.ClientSize.Height / 2)
		rSprite2.Left = CInt(x + Me.ClientSize.Width / 2)

		' Paint the background onto our back buffer.
		Dim rLake As RECT
		Dim rback As RECT
		rLake.Bottom = ddsd2.lHeight
		rLake.Right = ddsd2.lWidth
		rback.Bottom = ddsd4.lHeight
		rback.Right = ddsd4.lWidth
		backbuffer.BltFast(0, 0, lakesurf, rLake, CONST_DDBLTFASTFLAGS.DDBLTFAST_WAIT)

		' Calculate Frames Per Second
		If i = 30 Then
		        If tLast <> 0 Then fps = 30 / (DateAndTime.Timer - tLast)
		        tLast = DateAndTime.Timer
		        i = 0
		End If
		i = i + 1
		backbuffer.DrawText(10, 10, "640x480x16", False)
		backbuffer.DrawText(10, 30, "Frames Per Second = " + System.Double.Format(fps, "####.0"), False)
		backbuffer.DrawText(10, 50, "Click Screen to Exit", False)
 
		' Blt to the backbuffer from our surface
		backbuffer.BltFast(rSprite2.Left, rSprite2.Top, spritesurf, rSprite, CONST_DDBLTFASTFLAGS.DDBLTFAST_SRCCOLORKEY BitOr CONST_DDBLTFASTFLAGS.DDBLTFAST_WAIT)
    
		' Flip the backbuffer to the screen
		primary.Flip(Nothing, CONST_DDFLIPFLAGS.DDFLIP_WAIT)
	End Sub

	Function ExModeActive() As Boolean
		Dim TestCoopResult As Integer = DirectDraw.TestCooperativeLevel
    
		If (TestCoopResult = CONST_DDRAWERR.DD_OK) Then
			ExModeActive = True
		Else
			ExModeActive = False
		End If
	End Function

	Public Shared Sub Main() 
		Try
			Application.Run(new Sample3Form())
		Catch e as Exception
		End Try
	End Sub

End Class