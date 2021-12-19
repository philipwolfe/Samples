''===========================================================================
''	File:		Sample2Form.vb
''
''	Summary:	Interacts with a COM component (DirectX).
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

Public Class Sample2Form
	Inherits Form
    
	Private components As Container
	Private PictureBox1 As PictureBox

	Dim DirectX As DirectX7
	Dim DirectDraw As DirectDraw7
	Dim BackgroundSurface As DirectDrawSurface7
	Dim SpriteSurface As DirectDrawSurface7
	Dim ScreenSurface As DirectDrawSurface7
	Dim BackBufferSurface As DirectDrawSurface7
	Dim Clipper As DirectDrawClipper

	Dim ddsdLake        As DDSURFACEDESC2
	Dim ddsdSprite      As DDSURFACEDESC2
	Dim ddsdScreen      As DDSURFACEDESC2
	Dim ddsdBackBuffer  As DDSURFACEDESC2
	Dim rBackBuffer     As RECT
	Dim rLake           As RECT
	Dim rSprite         As RECT
	Dim lastX As Integer
	Dim lastY As Integer
	Dim fps As Double
	Dim running As Boolean

	Shared a As Double
	Shared t1 As Double
	Shared t2 As Double
	Shared i As Integer
	Shared tLast As Double
	Shared tNow As Double

	Public Sub New()
		MyBase.New

		' This call is required for support of the WFC Form Designer.
		InitializeComponent

		DirectX = new DirectX7

		InitializeDirectX
	End Sub
    
	Private Sub InitializeComponent() 
		Me.components = New Container
		Me.PictureBox1 = New PictureBox

		PictureBox1.Location = New Point(0, 0)
		PictureBox1.Size = New Size(430, 330)
		PictureBox1.TabStop = False

		Me.Controls.Add(PictureBox1)
		Me.Text = "Interoperability with DirectX"
		Me.ClientSize = New Size(430, 330)
		Me.BorderStyle = System.WinForms.FormBorderStyle.Fixed3D
		Me.MaximizeBox = False
		Me.MinimizeBox = False

		' Event handlers
		Me.AddOnClosing(New CancelEventHandler(AddressOf Me.Form_Closing))
		PictureBox1.AddOnPaint(New PaintEventHandler(AddressOf Me.PictureBox1_Paint))
	End Sub

	Private Sub Form_Closing(ByVal sender As System.Object, ByVal e As CancelEventArgs)
	    running = False
	End Sub
	
	Public Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs)
		If running = True then DoFrame
	End Sub

	Private Sub InitializeDirectX()
      
	    ' The empty string parameter means to use the active display driver
	    DirectDraw = DirectX.DirectDrawCreate("")
	Me.Show
        
	    ' Indicate that this will be a normal windowed application
	    ' with the same display depth as the current display
	    DirectDraw.SetCooperativeLevel(Me.Handle, CONST_DDSCLFLAGS.DDSCL_NORMAL)
    
		' Indicate that the ddsCaps member is valid
		ddsdScreen.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS
		
		' This surface is the primary surface (the one visible to the user)
		ddsdScreen.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_PRIMARYSURFACE

		' Create the primary surface with the surface description we just set
		ScreenSurface = DirectDraw.CreateSurface(ddsdScreen)
    
		' Create a clipper object (used to set the writable region of the screen)
		Clipper = DirectDraw.CreateClipper(0)

		' Associate the PictureBox handle with the clipper
		Clipper.SetHWnd(PictureBox1.Handle)
    
		' Have the blts to the screen clipped to the PictureBox
		ScreenSurface.SetClipper(Clipper)

		'----- Create an invisible surface to draw to.
		'----- Use it as a compositing surface in system memory.
    
		' Indicate that we want to specify the ddscaps height and width.
		' The format of the surface (bits per pixel) will be the same as the primary.
		ddsdBackBuffer.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS BitOr CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT BitOr CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH
    
		' Indicate that we want a surface that is not visible and that
		' we want it in system memory.
		ddsdBackBuffer.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN BitOr CONST_DDSURFACECAPSFLAGS.DDSCAPS_SYSTEMMEMORY
    
		' Specify the height and width of the surface to be the same as the PictureBox.
		ddsdBackBuffer.lWidth = PictureBox1.Width
		ddsdBackBuffer.lHeight = PictureBox1.Height
    
		' Create the requested surface
		BackBufferSurface = DirectDraw.CreateSurface(ddsdBackBuffer)
                                                                        
		If Not InitializeSurfaces Then Exit Sub

		rBackBuffer.Bottom = ddsdBackBuffer.lHeight
		rBackBuffer.Right = ddsdBackBuffer.lWidth
    
		' Get the area of the bitmap we want to blt
		rLake.Bottom = ddsdLake.lHeight
		rLake.Right = ddsdLake.lWidth

		rSprite.Bottom = ddsdSprite.lHeight
		rSprite.Right = ddsdSprite.lWidth
    
		RepaintEntireBackground

		running = True
		Do While running
			DoFrame
			Application.DoEvents
	    Loop
	End Sub

	Sub RepaintEntireBackground()
		' Copy the backround bitmap to the background surface
		BackBufferSurface.BltFast(0, 0, BackgroundSurface, rLake, CONST_DDBLTFASTFLAGS.DDBLTFAST_WAIT)
	End Sub

	Function InitializeSurfaces() as Boolean
	    '----- Load the background image
            
	    ' Indicate that we want to create an offscreen surface.
	    ' An offscreen surface is one that is available in memory
	    ' (video or system memory) but is not visible to the user.
	    ddsdLake.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS BitOr CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH BitOr CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT
	    ddsdLake.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN
	    ddsdLake.lWidth = PictureBox1.Width
	    ddsdLake.lHeight = PictureBox1.Height
    
	    ' Create the surface and load the bitmap onto the surface
		Try		
			BackgroundSurface = DirectDraw.CreateSurfaceFromFile("background.bmp", ddsdLake)
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

		' Copy the background to the compositing surface
		RepaintEntireBackground
                                                                        
		'----- Load the sprite image
    
	    ' Load the bitmap into the second surface
        
	    ' Specify that the ddsCaps field is valid
		ddsdSprite.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS BitOr CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH BitOr CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT
		ddsdSprite.lWidth = 64
		ddsdSprite.lHeight = 64
		' Indicate we want an offscreen surface

		ddsdSprite.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN
    
	    ' Create the surface and load the bitmap onto the surface
		Try		
			SpriteSurface = DirectDraw.CreateSurfaceFromFile("sprite.bmp", ddsdSprite)
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
    
		'----- Set the transparent color of the sprite

		Dim key As DDCOLORKEY
		key.low = 0
		key.high = 0
    
		' Assign the transparent color to the sprite object.
		' DDCKEY_SRCBLT specifies that when a blt is done the
		' transparent color is associated with the surface being
		' blitted and not the one being blitted to.
		SpriteSurface.SetColorKey(CONST_DDCKEYFLAGS.DDCKEY_SRCBLT, key)

		InitializeSurfaces = True

	End Function

	Sub DoFrame()
		Dim ddrval As Integer
		Dim rPrim As RECT
		Dim x As Single
		Dim y As Single
	    
		' Calculate the angle for placing the sprite
		t2 = DateAndTime.Timer		
		If t1 <> 0 Then
		a = a + (t2 - t1) * 100
			If a > 360 Then	a = a - 360		
		End If
		t1 = t2
	
		' This will keep us from trying to blt in case we lose the surfaces (another fullscreen app takes over)
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
	    
		' Calculate Frames Per Second
		i = i + 1
		If i = 30 Then
			tNow = DateAndTime.Timer
			If tNow <> tLast Then
				fps = 30 / (DateAndTime.Timer - tLast)
				tLast = DateAndTime.Timer
				i = 0
				Me.Text = "Interoperability with DirectX - Frames per Second = " + System.Double.Format(fps, "####.0")
			End If
		End If
	
		' Calculate the x y coordinate of where we place the sprite
		x = CSng(Math.Cos((a / 360) * 2 * 3.141) * PictureBox1.Width / 8)
		y = CSng(Math.Sin((a / 360) * 2 * 3.141) * PictureBox1.Height / 8)
		x = CSng(x + PictureBox1.Width / 2)
		y = CSng(y + PictureBox1.Height / 2)
	    
		' Clean up background from last frame
		' by only reparing the background where it needs it
		' (We don't need to reblit the whole thing.)
		Dim rClean As RECT
		If lastX <> 0 Then
			rClean.Left = lastX
			rClean.Top = lastY
			rClean.Right = lastX + ddsdSprite.lWidth
			rClean.Bottom = lastY + ddsdSprite.lHeight
			BackBufferSurface.BltFast(lastX, lastY, BackgroundSurface, rClean, CONST_DDBLTFASTFLAGS.DDBLTFAST_WAIT)
		End If
	    
		lastX = CInt(x)
		lastY = CInt(y)
	
		' Blt to the backbuffer from our sprite.
		' Use the color key on the source (our sprite).
		' Wait for the blt to finish before moving one.
		Dim rtemp As RECT
		rtemp.Left = CInt(x)
		rtemp.Top = CInt(y)
		rtemp.Right = CInt(x + ddsdSprite.lWidth)
		rtemp.Bottom = CInt(y + ddsdSprite.lHeight)
	    	
		BackBufferSurface.Blt(rtemp, SpriteSurface, rSprite, CONST_DDBLTFLAGS.DDBLT_KEYSRC BitOr CONST_DDBLTFLAGS.DDBLT_WAIT)
	        
		' Get the position of the PictureBox in screen coordinates
		DirectX.GetWindowRect(PictureBox1.Handle, rPrim)
	        
		' Blt the back buffer to the screen
		ScreenSurface.Blt(rPrim, BackBufferSurface, rBackBuffer, CONST_DDBLTFLAGS.DDBLT_WAIT)
	End Sub

	Function ExModeActive() As Boolean
		Dim TestCoopResult As Integer
	
		TestCoopResult = DirectDraw.TestCooperativeLevel
    
		If (TestCoopResult = CONST_DDRAWERR.DD_OK) Then
			ExModeActive = True
		Else
			ExModeActive = False
		End If
	End Function

	Public Shared Sub Main() 
		Try
			Application.Run(new Sample2Form())
		Catch e as Exception
		End Try
	End Sub

End Class