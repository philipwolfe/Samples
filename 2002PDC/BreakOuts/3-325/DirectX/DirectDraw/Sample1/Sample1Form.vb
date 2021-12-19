''===========================================================================
''	File:		Sample1Form.vb
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
Imports DxVBLib

Public Class Sample1Form
	Inherits Form
    
	Private components As Container
	Private PictureBox1 As PictureBox

	Dim DirectX As DirectX7
	Dim DirectDraw As DirectDraw7
	Dim Surface As DirectDrawSurface7
	Dim PrimarySurface As DirectDrawSurface7
	Dim Surface1 As DDSURFACEDESC2
	Dim Surface2 As DDSURFACEDESC2
	Dim Clipper As DirectDrawClipper

	Dim bInit As Boolean

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
		PictureBox1.Size = New Size(255, 255)
		PictureBox1.TabStop = False

		Me.Controls.Add(PictureBox1)
		Me.Text = "Interoperability with DirectX"
		Me.ClientSize = New Size(255, 255)
		
		' Event handlers
		Me.AddOnResize(New EventHandler(AddressOf Me.Form_Resize))
		PictureBox1.AddOnPaint(New PaintEventHandler(AddressOf Me.PictureBox1_Paint))
	End Sub

	Private Sub Form_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
	    PictureBox1.Width = Me.ClientSize.Width
	    PictureBox1.Height = Me.ClientSize.Height
	    Blt
	End Sub
	
	'
	' Called during run-time when the form is moved or resized.
	'
	Public Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs)
	    DirectDraw.RestoreAllSurfaces
	    InitializeDirectX
	    Blt
	End Sub

	Private Sub Blt()
	    ' Has DirectX been initialized? If not, exit.
	    If bInit = False Then Exit Sub
    
	    Dim r1 As RECT
	    Dim r2 As RECT
    
	    ' Gets the bounding rectangle for the entire window handle and stores it in r1
	    DirectX.GetWindowRect(PictureBox1.Handle, r1)
    
	    r2.Bottom = Surface2.lHeight
	    r2.Right = Surface2.lWidth
    
	    PrimarySurface.Blt(r1, Surface, r2, CONST_DDBLTFLAGS.DDBLT_WAIT)
	End Sub

	Private Sub InitializeDirectX()
      
	    ' The empty string parameter means to use the active display driver
	    DirectDraw = DirectX.DirectDrawCreate("")
        
	    ' Indicate that this will be a normal windowed application
	    ' with the same display depth as the current display
	    DirectDraw.SetCooperativeLevel(Me.Handle, CONST_DDSCLFLAGS.DDSCL_NORMAL)
    
		' Indicate that the ddsCaps member is valid
		Surface1.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS
		
		' This surface is the primary surface (the one visible to the user)
		Surface1.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_PRIMARYSURFACE

		' Create the primary surface with the surface description we just set
		PrimarySurface = DirectDraw.CreateSurface(Surface1)
    
		' Set the second surface description
		Surface2.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS

		' This is going to be a plain off-screen surface
		Surface2.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN

		'Create the off-screen surface

		Try		
			Surface = DirectDraw.CreateSurfaceFromFile("background.bmp", Surface2)
		Catch e as System.Runtime.InteropServices.COMException
			' File Not Found
			If (e.ErrorCode = &H800A0035) Then
				MessageBox.Show("Could not find the file 'background.bmp'.  This must be placed in the current directory.", "Picture Not Found")
				Application.Exit()
				Exit Sub
			Else
				MessageBox.Show("Unexpected exception: " + e.ToString(), "Unexpected Exception")
				Application.Exit()
				Exit Sub
			End If
		End Try
    
		Clipper = DirectDraw.CreateClipper(0)
		Clipper.SetHWnd(PictureBox1.Handle)
		PrimarySurface.SetClipper(Clipper)

		' We've finished initialization
		bInit = True
		Blt
	End Sub

	Public Shared Sub Main()
		Try
			Application.Run(new Sample1Form())
		Catch e as Exception
		End Try
	End Sub

End Class