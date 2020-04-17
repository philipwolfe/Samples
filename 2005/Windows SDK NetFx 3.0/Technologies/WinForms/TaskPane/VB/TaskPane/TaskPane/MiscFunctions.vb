'=====================================================================
'  File:      MiscFunctions.vb
'
'  Summary:   Miscellaneous functions to do things we really need.
'
'
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

Imports System.Drawing
Imports System.Windows.Forms


'=--------------------------------------------------------------------------=
' MiscFunctions
'=--------------------------------------------------------------------------=
''' <summary>
'''   Module (not class) to do some random goo we need done.
''' </summary>
''' 
''' 
Friend Module MiscFunctions



    '=---------------------------------------------------------------------=
    ' ExplodePreservingSubObjects
    '=---------------------------------------------------------------------=
    ''' <summary>
    '''    Given a string that contains a bunch of values separated by a
    '''    given list separator, split them out, with the added twist of
    '''    keeping objects wrapped in the specified start and end wrappers
    '''    intact.
    ''' 
    '''    I.e.
    ''' 
    '''     If the separator were ",", and start and end wrappers were '(' and ')', then:
    ''' 
    '''     One, (Two, Three, Four), (5, 6, 7)
    ''' 
    '''     would return:
    ''' 
    '''     One
    '''     Two, Three, Four
    '''     5, 6, 7
    ''' 
    ''' 
    ''' </summary>
    ''' 
    ''' <param name="in_str">
    '''   String to explode.
    ''' </param>
    ''' 
    ''' <param name="in_sep">
    '''   Separator.
    ''' </param>
    ''' 
    ''' <param name="in_start">
    '''   Sub-object start marker.
    ''' </param>
    ''' 
    ''' <param name="in_finish">
    '''   Sub-object finish marker.
    ''' </param>
    ''' 
    ''' <returns>
    '''   An array of strings.
    ''' </returns>
    ''' 
    Public Function ExplodePreservingSubObjects(ByVal in_str As String, _
                                                ByVal in_sep As String, _
                                                ByVal in_start As String, _
                                                ByVal in_finish As String) _
                                                As String()

        Dim al As System.Collections.ArrayList
        Dim inSubObject As Integer
        Dim start As Integer
        Dim idx As Integer
        Dim s As String

        al = New System.Collections.ArrayList

        '
        ' loop through one character at a time looking for separator, etc.
        '
        While idx < in_str.Length

            If in_str.Chars(idx) = in_start Then
                inSubObject += 1
            ElseIf in_str.Chars(idx) = in_finish Then
                inSubObject -= 1
            End If

            '
            ' If we are at a separator, and aren't in a sub-object, then
            ' split out the string, stripping off the sub-object markers.
            '
            If in_str.Chars(idx) = in_sep AndAlso inSubObject = 0 Then
                s = in_str.Substring(start, idx - start).Trim()
                If s.Chars(0) = in_start Then
                    s = s.Substring(1, s.Length - 2)
                End If
                al.Add(s)
                start = idx + 1
            End If

            idx += 1

        End While

        '
        ' Finally add what's left!
        '
        s = in_str.Substring(start, idx - start).Trim()
        If s.Chars(0) = in_start Then
            s = s.Substring(1, s.Length - 2)
        End If
        al.Add(s)

        Return CType(al.ToArray(GetType(String)), String())

    End Function ' ExplodePreservingSubObjects


    '=---------------------------------------------------------------------=
    ' GetRightToLeftValue
    '=---------------------------------------------------------------------=
    ''' <summary>
    '''   Given a control, figure out if it should be drawn Right To Left,
    '''   which might involve going up the parent chain.
    ''' </summary>
    ''' 
    ''' <param name="in_ctl">
    '''   Control whose RTL value we want to explore.
    ''' </param>
    ''' 
    ''' <returns>
    '''   True means we should be drawing RTL.
    ''' </returns>
    ''' 
    Public Function GetRightToLeftValue(ByVal in_ctl As System.Windows.Forms.Control) _
                                        As Boolean

        If in_ctl.RightToLeft = System.Windows.Forms.RightToLeft.Yes Then Return True
        If in_ctl.RightToLeft = System.Windows.Forms.RightToLeft.No Then Return False
        If in_ctl.Parent Is Nothing Then Return False

        If in_ctl.RightToLeft = System.Windows.Forms.RightToLeft.Inherit Then
            Return GetRightToLeftValue(in_ctl.Parent)
        End If

    End Function ' GetRightToLeftValue


    '=---------------------------------------------------------------------=
    ' FlipColor
    '=---------------------------------------------------------------------=
    ''' <summary>
    '''   Takes a color and returns a new one with all the values inverted 
    '''  inside of 255.
    ''' </summary>
    ''' 
    ''' <param name="in_color">
    '''   Invert me please.
    ''' </param>
    ''' 
    ''' <returns>
    '''   Inverted.
    ''' </returns>
    ''' 
    Public Function FlipColor(ByVal in_color As Color) As Color

        Return Color.FromArgb(in_color.A, 255 - in_color.R, 255 - in_color.G, _
                              255 - in_color.B)

    End Function ' FlipColor

    '=---------------------------------------------------------------------=
    ' IconToBitmap
    '=---------------------------------------------------------------------=
    ''' <summary>
    '''   Converts a System.Drawing.Icon to a System.Drawing.Bitmap
    ''' </summary>
    ''' 
    ''' <param name="in_color">
    '''   Mask color to use as background.
    ''' </param>
    ''' 
    ''' <param name="in_icon">
    '''   Icon to convert.
    ''' </param>
    ''' 
    ''' <returns>
    '''   Bitmap object.
    ''' </returns>
    ''' 
    Public Function IconToBitmap(ByVal in_color As Color, ByVal in_icon As Icon) As Bitmap

        Dim g As Graphics
        Dim b As Bitmap

        b = New Bitmap(in_icon.Width, in_icon.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
        g = Graphics.FromImage(b)
        g.FillRectangle(New SolidBrush(Color.Black), New Rectangle(0, 0, b.Width, b.Height))
        g.DrawIcon(in_icon, 0, 0)
        g.Dispose()

        b.MakeTransparent(Color.Black)

        Return b

    End Function ' IconToBitmap


    '=---------------------------------------------------------------------=
    ' ScaleColor
    '=---------------------------------------------------------------------=
    ''' <summary>
    '''   A function for scaling a color down a certain percentage
    ''' </summary>
    ''' 
    ''' <param name="in_color">
    '''   Color to be scaled.
    ''' </param>
    ''' 
    ''' <param name="in_pct">
    '''   Percentage to scale it.
    ''' </param>
    ''' 
    ''' <returns>
    '''   New color object.
    ''' </returns>
    ''' 
    Public Function ScaleColor(ByVal in_color As Color, ByVal in_pct As Integer) As Color

        Dim d As Double
        Dim r, g, b As Integer

        d = in_pct / 100.0

        r = CInt(in_color.R * d)
        If r > 255 Then r = 255
        If g < 0 Then g = 0
        g = CInt(in_color.G * d)
        If g > 255 Then g = 255
        If g < 0 Then g = 0
        b = CInt(in_color.B * d)
        If b > 255 Then b = 255
        If b < 0 Then b = 0

        Return Color.FromArgb(in_color.A, r, g, b)

    End Function ' ScaleColor

End Module ' MiscFunctions
