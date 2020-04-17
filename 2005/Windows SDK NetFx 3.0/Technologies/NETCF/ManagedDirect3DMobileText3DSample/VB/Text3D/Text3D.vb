'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

'-----------------------------------------------------------------------------
' File: Text3D.vb
'
' Desc: Demosntrates text drawing features available in Managed D3D Mobile
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'-----------------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D


Namespace Microsoft.Samples.MD3DM

    ' Main sample class that displays the demo
    Public Class TextSampleForm
        Inherits Form
        ' Fonts for drawing text
        Private font1 As _
            Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font = _
            Nothing
        Private font2 As _
            Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font = _
            Nothing

        
        ' The d3d device
        Private device As Device = Nothing
        
        ' A sprite object for batching text draw calls
        Private textDrawerSprite As Sprite = Nothing
        
        ' the name and sizes of the fonts we will be drawing
        Private fontName As String = "Arial"
        Private Const fontSize1 As Integer = 15
        Private Const fontSize2 As Integer = 11
        
        ' A big string of text to test with
        Private Const bigText As String = _
            "This is a single call to Font.DrawText() with a large text " + _
            "buffer. It shows that Font supports word wrapping. If you " + _
            "resize the window, the words will automatically " + _
            "wrap to the next line.  It also supports" + vbCr + vbLf + _
            "hard line breaks.  Font also supports Unicode text " + _
            "with correct word wrapping for right-to-left languages."
        
        ' a helper which tracks and displays fps information
        private fpsTimer As FpsTimerTool = Nothing
        
        
        ' Application constructor.
        Public Sub New() 
            ' Set the window text
            Me.Text = "Text 3D"
            
            ' Now let's setup our D3D parameters
            Dim presentParams As New PresentParameters()
            presentParams.Windowed = True
            presentParams.SwapEffect = SwapEffect.Discard
            presentParams.AutoDepthStencilFormat = DepthFormat.D16
            presentParams.EnableAutoDepthStencil = True
            ' create the device
            device = New Device(0, DeviceType.Default, Me, _
                CreateFlags.None, presentParams)
            
            
            ' setup objects that can persist through device reset
            InitializeDeviceObjects()
            ' attach the the device reset handler
            AddHandler device.DeviceReset, AddressOf RestoreDeviceObjects
            ' setup objects that won't persist through device reset
            RestoreDeviceObjects(device, EventArgs.Empty)
        
        End Sub 'New
        

        ' Called once per frame, the call is the entry point for 3d
        ' rendering. This function sets up render states, clears the
        ' viewport, and renders the scene.
        Public Sub Render() 
            fpsTimer.StartFrame()
     
            ' clears the frame
            device.Clear(ClearFlags.Target, 0, 1F, 0)
            Try
                ' start drawing commands
                device.BeginScene()
                
                Dim height As Integer = ClientRectangle.Height
                Dim width As Integer = ClientRectangle.Width
                Dim rect As System.Drawing.Rectangle
                ' Demonstration 1
                ' Draw a simple line using DrawText
                ' Pass in DrawTextFormat.NoClip so we don't have to calc
                ' the bottom/right of the rect
                font1.DrawText(Nothing, _
                    "This is a trivial call to Font.DrawText", _
                    New System.Drawing.Rectangle(5, 150, 0, 0), _
                    DrawTextFormat.NoClip, System.Drawing.Color.Red)
                
                
                ' Demonstration 2
                ' Allow multiple draw calls to sort by texture changes
                ' by Sprite when drawing 2D text use flags:
                ' SpriteFlags.AlphaBlend | SpriteFlags.SortTexture.
                textDrawerSprite.Begin( _
                    SpriteFlags.AlphaBlend Or SpriteFlags.SortTexture)
                rect = New System.Drawing.Rectangle(5, height - 15 * 6, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "These are multiple calls to Font.DrawText()", _
                    rect, DrawTextFormat.NoClip, Color.White)
                rect = New System.Drawing.Rectangle(5, height - 15 * 5, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "using the same Sprite. The font now caches", _
                    rect, DrawTextFormat.NoClip, Color.White)
                rect = New System.Drawing.Rectangle(5, height - 15 * 4, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "letters on one or more textures. In order", _
                    rect, DrawTextFormat.NoClip, Color.White)
                rect = New System.Drawing.Rectangle(5, height - 15 * 3, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "to sort by texturestate changes on multiple", _
                    rect, DrawTextFormat.NoClip, Color.White)
                rect = New System.Drawing.Rectangle(5, height - 15 * 2, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "calls to DrawText() pass a Sprite and use flags", _
                    rect, DrawTextFormat.NoClip, Color.White)
                rect = New System.Drawing.Rectangle(5, height - 15 * 1, 0, 0)
                font2.DrawText(textDrawerSprite, _
                    "SpriteFlags.AlphaBlend | SpriteFlags.SortTexture", _
                    rect, DrawTextFormat.NoClip, Color.White)
                
                textDrawerSprite.End()
                
                ' Demonstration 3:
                ' Word wrapping and unicode text.  
                ' Note that not all fonts support dynamic font linking. 
                Dim rc As New System.Drawing.Rectangle(10, 35, _
                    width - 30, height - 10)
                
                font2.DrawText(Nothing, bigText, rc, _
                    DrawTextFormat.Left Or DrawTextFormat.WordBreak _
                    Or DrawTextFormat.ExpandTabs, _
                    System.Drawing.Color.CornflowerBlue)
                
                ' write the fps
                fpsTimer.Render()
            
            
            Finally
                ' end the drawing commands and copy to screen
                device.EndScene()
                device.Present()
                fpsTimer.StopFrame()
            End Try
        
        End Sub 'Render

        ' The device has been created.  Resources that are not lost on
        ' Reset() can be created here.
        Public Sub InitializeDeviceObjects() 

            ' a little different than desktop, on device we make
            ' use of a FontDescription structure to hold all the
            ' font parameters
            Dim fontDesc As New FontDescription()
            fontDesc.CharSet = CharacterSet.Default
            fontDesc.FaceName = fontName
            fontDesc.Height = fontSize1
            fontDesc.OutputPrecision = Precision.Default
            fontDesc.PitchAndFamily = PitchAndFamily.DefaultPitch _
                Or PitchAndFamily.FamilyDoNotCare
            fontDesc.Quality = FontQuality.Default
            fontDesc.Weight = FontWeight.Bold
            fontDesc.Width = 0
            
            ' initialize our sample fonts
            font1 = New _
                Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font( _
                device, fontDesc)
            
            fontDesc.Height = fontSize2
            font2 = New _
                Global.Microsoft.WindowsMobile.DirectX.Direct3D.Font( _
                device, fontDesc)
            

            ' make the sprite object which can batch and sort multiple
            ' DrawText() calls
            textDrawerSprite = New Sprite(device)

            fpsTimer = new FpsTimerTool(device)
        
        End Sub 'InitializeDeviceObjects
         

        ' The device exists, but may have just been Reset().  Resources
        ' and any other device state that persists during
        ' rendering should be set here.  Render states, matrices, textures,
        ' etc., that don't change during rendering can be set once here to
        ' avoid redundant state setting during Render() or FrameMove().
        Private Sub RestoreDeviceObjects(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) 
            ' restore our fonts and sprite object
            font1.OnResetDevice()
            font2.OnResetDevice()
            textDrawerSprite.OnResetDevice()
        
        End Sub 'RestoreDeviceObjects
        
        
        ' Called when the window needs to be repainted
        Protected Overrides Sub OnPaint( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
            ' Render on painting
            Me.Render()
            ' Render again
            Me.Invalidate()
        End Sub 'OnPaint
        
        ' Called when the window needs to repaint the background
        Protected Overrides Sub OnPaintBackground( _
            ByVal e As System.Windows.Forms.PaintEventArgs) 
        End Sub 'OnPaintBackground
        
        ' The main entry point for the application.
        Shared Sub Main() 
            Try
                Dim d3dApp As New TextSampleForm()
                Application.Run(d3dApp)

            Catch e As DriverUnsupportedException
            
                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")

            Catch e As NotSupportedException
            
                MessageBox.Show("Your device does not have the " + _
                    "needed 3d support to run this sample")

            Catch e As Exception

                MessageBox.Show("The sample has run into an error " + _
                    "and needs to close: " + e.Message)

            End Try  
        
        End Sub 'Main
    End Class 'TextSampleForm
End Namespace