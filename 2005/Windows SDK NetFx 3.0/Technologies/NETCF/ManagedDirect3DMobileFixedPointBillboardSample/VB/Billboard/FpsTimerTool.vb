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

Imports System
Imports System.Collections
Imports System.IO
Imports System.Reflection
Imports Microsoft.WindowsMobile.DirectX
Imports Microsoft.WindowsMobile.DirectX.Direct3D
Imports System.Globalization

Namespace Microsoft.Samples.MD3DM

    ' This class implements an fps (frames per second) timer together with an
    ' optional display and file logger.
    Public Class FpsTimerTool
        ' The number of recent frames to average time over
        Private recentFramesToTrack As Integer = 50
        
        ' The update frquency in seconds of the graphical fps display
        Private fpsDisplayUpdateFrequency As New TimeSpan(0, 0, 1)
        
        ' The update frquency in seconds of the file logged fps
        Private fpsFileDumpUpdateFrequency As New TimeSpan(0, 0, 1)
        
        ' Whether or not Fps information will be displayed to the screen
        Private fpsDisplayEnabled As Boolean = False
        
        ' Whether or not Fps information will be dumped to file
        Private fpsFileDumpEnabled As Boolean = False
        
        ' An array of TimeSpans which tracks the rendering time
        ' of the most recent frames
        Private recentFrameTimes As New ArrayList()
        
        ' The time rendering of the most recent frame started
        Private startFrameTime As DateTime
        
        ' The stream to which to dump fps information
        Private loggingStream As StreamWriter = Nothing
        
        ' The last time fps information was dumped to file
        Private lastFpsFileDumpTime As DateTime = DateTime.Now
        
        ' The last time the Fps display was drawn
        Private lastFpsDisplayTime As DateTime = DateTime.Now
        
        ' The font used for drawing the fps to screen
        Private fpsDisplayFont As Font = Nothing
        
        ' The value displayed on screen for fps
        Private fpsDisplayValue As Single
        
        
        Public Sub New(ByVal d As Device) 
        If fpsFileDumpEnabled Then
            Try
                Dim filename As String = GetFullPath("fps_dump.txt")
                loggingStream = New StreamWriter(filename)
            Catch e As IOException
                fpsFileDumpEnabled = false
            End Try
        End If
        fpsDisplayFont = New Font(d, New System.Drawing.Font("Arial", _
            12F, System.Drawing.FontStyle.Regular))
        End Sub 'New
        
        
        ' Called when frame rendering begins
        Public Sub StartFrame() 
            startFrameTime = DateTime.Now
        End Sub 'StartFrame
        
        
        ' Called when frame rendering ends
        Public Sub StopFrame() 
            ' determine elapsed frame time
            Dim TimeElapsedInFrame As TimeSpan = _
                DateTime.Now - startFrameTime
            
            ' store the most recent frame and possibly evict the least
            ' recent one so that there are never more than 
            ' RecentFramesToTrack frame times in the array
            If recentFrameTimes.Count = recentFramesToTrack Then
                recentFrameTimes.RemoveAt(0)
            End If
            recentFrameTimes.Add(TimeElapsedInFrame)
            
            If fpsFileDumpEnabled Then
                If DateTime.Now - lastFpsFileDumpTime > _
                    fpsFileDumpUpdateFrequency Then
                    lastFpsFileDumpTime = DateTime.Now
                    Try
                        loggingStream.WriteLine( _
                            AverageFps.ToString(CultureInfo.CurrentCulture))
                        loggingStream.Flush()
                    Catch e As IOException
                        ' Just ignore the error
                    End Try
                End If
            End If
            
            If fpsDisplayEnabled Then
                If DateTime.Now - lastFpsDisplayTime > _
                    fpsDisplayUpdateFrequency Then
                    fpsDisplayValue = AverageFps
                    lastFpsDisplayTime = DateTime.Now
                End If
            End If
        
        End Sub 'StopFrame
        
        
        ' Called to draw the fps string onto the screen
        Public Sub Render() 
            If fpsDisplayEnabled Then
                fpsDisplayFont.DrawText(Nothing, _
                    fpsDisplayValue.ToString(CultureInfo.CurrentCulture), _
                    0, 0, System.Drawing.Color.Red)
            End If    
        End Sub 'Render
        
        ' The average fps of recent frames
        Public ReadOnly Property AverageFps() As Single 
            Get
                Dim totalTimeElapsed As New TimeSpan(0)
                Dim frameTime As TimeSpan
                For Each frameTime In  recentFrameTimes
                    totalTimeElapsed += frameTime
                Next frameTime 
                If totalTimeElapsed.TotalMilliseconds = 0 Then
                    Return 0
                Else
                    Return System.Convert.ToSingle(1000.0 * _
                        recentFrameTimes.Count / _
                        totalTimeElapsed.TotalMilliseconds)
                End If
            End Get
        End Property
         
        ' Get the full path to the specified file by prepending it
        ' with the directory of the executable.
        Private Function GetFullPath(ByVal fileName As String) As String 
            Dim asm As [Assembly] = [Assembly].GetExecutingAssembly()
            Dim str As String = asm.GetModules()(0).FullyQualifiedName
            Dim fullName As String = Path.GetDirectoryName(str)
            Dim uri As New Uri(Path.Combine(fullName, fileName))
            Return uri.AbsolutePath
        End Function 'GetFullPath
        
        
        Overloads Protected Overrides Sub Finalize() 
            If Not (loggingStream Is Nothing) Then
                loggingStream.Close()
            End If
            MyBase.Finalize()
        
        End Sub 'Finalize
    End Class 'FpsTimerTool
End Namespace