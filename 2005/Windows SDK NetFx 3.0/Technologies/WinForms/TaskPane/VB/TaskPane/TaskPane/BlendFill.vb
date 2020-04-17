'=====================================================================
'  File:      BlendFill.vb
'
'  Summary:   A class that wraps into the UI in a nifty vb-friendly 
'             fashion a System.Drawing.Drawing2D.LinearGradientBrush.  
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
Imports System.Reflection
Imports System.Globalization
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.ComponentModel.Design.Serialization
Imports System.Security.Permissions

'=--------------------------------------------------------------------------=
' BlendFill
'=--------------------------------------------------------------------------=
''' <summary>
'''   A nifty little class that wraps a LinearGradientBrush into a VB-user
'''   friendly class that can be code gen'd and easily added to your controls.
''' </summary>
''' 
<Editor(GetType(Design.BlendFillEditor), GetType(System.Drawing.Design.UITypeEditor)), _
 TypeConverter(GetType(BlendFill.BlendFillTypeConverter)), _
 Serializable()> _
Public Class BlendFill


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                      Private types/data/goo/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    ''' 
    ''' <summary>
    '''   The style of blending this will use.
    ''' </summary>
    ''' 
    Private m_style As BlendStyle

    ''' 
    ''' <summary>
    '''   the start color of the blend.
    ''' </summary>
    ''' 
    Private m_startColor As Color

    ''' 
    ''' <summary>
    '''   The finish color of the blend.
    ''' </summary>
    ''' 
    Private m_finishColor As Color





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods/Properties/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' 
    ''' <summary>
    '''   Initializes a new instance of this class.  Requires the blend style,
    '''   as well as the start and finish color.
    ''' </summary>
    ''' 
    ''' <param name="in_blendStyle">
    '''   Style of blending we'll use.
    ''' </param>
    ''' 
    ''' <param name="in_startColor">
    '''   Color with which to begin blend.
    ''' </param>
    ''' 
    ''' <param name="in_finishColor">
    '''   Color with which to finish blend.
    ''' </param>
    ''' 
    Public Sub New(ByVal in_blendStyle As BlendStyle, _
                   ByVal in_startColor As Color, _
                   ByVal in_finishColor As Color)


        Me.m_startColor = in_startColor
        Me.m_finishColor = in_finishColor
        Me.m_style = in_blendStyle

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Style
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   What style of blend is this
    ''' </summary>
    ''' 
    ''' <value>
    '''   A value from the BlendStyle enumeration.
    ''' </value>
    '''
    <LocalisableDescription("BlendFill.Style"), _
     Category("Appearance"), DefaultValue(BlendStyle.Vertical)> _
    Public ReadOnly Property Style() As BlendStyle

        Get
            Return Me.m_style
        End Get

    End Property ' BlendStyle

    '=----------------------------------------------------------------------=
    ' StartColor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Controls which color is used to start the blend painting.
    ''' </summary>
    ''' 
    ''' <value>
    '''   A Color object control what color is used to start the blend.
    ''' </value>
    '''
    <LocalisableDescription("BlendFill.StartColor"), _
     Category("Appearance")> _
    Public ReadOnly Property StartColor() As Color

        Get
            Return Me.m_startColor
        End Get

    End Property ' StartColor


    '=----------------------------------------------------------------------=
    ' FinishColor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Indicates the ending color of the linear blend operation in the 
    '''   painting.
    ''' </summary>
    ''' 
    ''' <value>
    '''   The finishing color in the painting operation.
    ''' </value>
    '''
    <LocalisableDescription("BlendFill.FinishColor"), _
     Category("Appearance")> _
    Public ReadOnly Property FinishColor() As Color

        Get
            Return Me.m_finishColor
        End Get

    End Property ' FinishColor


    '=----------------------------------------------------------------------=
    ' GetLinearGradientBrush
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns a LinearGradientBrush for the currently chosen values.
    ''' </summary>
    ''' 
    ''' <param name="in_rect">
    '''   A rectangle for the area which the caller wishes painted.
    '''   This is necessary for the linear gradient code to know how to 
    '''   fill the brush.  Please note that this should be the rect of the
    '''   <em>full</em> area to be painted, not the clip rectangle.
    ''' </param>
    ''' 
    ''' <returns>
    '''    A LinearGradientBrush which can be used to paint.
    ''' </returns>
    ''' 
    <LocalisableDescription("BlendFill.GetLinearGradientBrush"), _
     Category("Appearance")> _
    Public Function GetLinearGradientBrush(ByVal in_rect As Rectangle) _
                                           As System.Drawing.Drawing2D.LinearGradientBrush

        '
        ' Use the overloaded version
        '
        Return Me.GetLinearGradientBrush(in_rect, False)

    End Function ' GetLinearGradientBrush


    '=----------------------------------------------------------------------=
    ' GetLinearGradientBrush
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns a LinearGradientBrush for the currently set values, letting
    '''   the caller specify whether we should reverse the values for RTL
    '''   painting.
    ''' </summary>
    ''' 
    ''' <param name="in_rect">
    '''   The bounding rectangle for painting.
    ''' </param>
    ''' 
    ''' <param name="in_reverseForRTL">
    '''   True == reverse the values for RightToLeft reading.
    ''' </param>
    ''' 
    ''' <returns>
    '''   A linearGradientBrush
    ''' </returns>
    '''
    <LocalisableDescription("BlendFill.GetLinearGradientBrush2"), _
     Category("Appearance")> _
    Public Function GetLinearGradientBrush(ByVal in_rect As Rectangle, _
                                           ByVal in_reverseForRTL As Boolean) _
                                           As LinearGradientBrush

        '
        ' When using LinearGradientBrush, if you specify an angle of 180 degrees, 
        ' it does not draw the left most pixel in the rectangle.  Thus, instead of 
        ' trying to fiddle with pixels and rect boundaries, we're just going to 
        ' swap the colors on RTL systems with a Horizontal Gradient.
        ' Otherwise, we'll go with the normal code paths to do this.
        '
        If in_reverseForRTL And Me.m_style = BlendStyle.Horizontal Then
            Return New LinearGradientBrush(in_rect, Me.m_finishColor, Me.m_startColor, 0)
        Else
            Return New LinearGradientBrush(in_rect, _
                                           Me.m_startColor, _
                                           Me.m_finishColor, _
                                           getAngle(Me.m_style, in_reverseForRTL))
        End If

    End Function ' GetLinearGradientBrush









    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private Methods/Properties/Subs
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' getAngle
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns an angle for a LinearGradientBrush given a direction/style.
    ''' </summary>
    ''' 
    ''' <param name="in_direction">
    '''   The BlendStyle or Direction of painting.
    ''' </param>
    ''' 
    ''' <param name="in_reverseForRTL">
    '''   Indicates wheter we should reverse for RightToLeftReading.
    ''' </param>
    ''' 
    ''' <returns>
    '''   Returns the Angle that should be used in drawing.
    ''' </returns>
    ''' 
    Private Shared Function getAngle(ByVal in_direction As Integer, _
                                     ByVal in_reverseForRTL As Boolean) _
                                     As Single

        Select Case in_direction

            Case BlendStyle.Horizontal
                If in_reverseForRTL Then
                    Return 180S
                Else
                    Return 0S
                End If

            Case BlendStyle.Vertical
                Return 90S

            Case BlendStyle.ForwardDiagonal
                If in_reverseForRTL Then
                    Return 135S
                Else
                    Return 45S
                End If

            Case BlendStyle.BackwardDiagonal
                If in_reverseForRTL Then
                    Return 45S
                Else
                    Return 135S
                End If

            Case Else
                System.Diagnostics.Debug.Fail("Bogus Direction")
                Return 0S
        End Select

    End Function ' getAngle








    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                            Nested Classes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' BlendFillTypeConverter
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This class provides a bunch of cool design time functionality for
    '''   our BlendFill class, as well as the ability to Code-Gen it.  Sweet!
    '''
    '''   To do this, it inherits and implements a bunch of the methods on the
    '''   TypeConverter class ...
    ''' </summary>
    ''' 

    <System.Security.Permissions.PermissionSet(SecurityAction.InheritanceDemand, Name:="FullTrust")> _
    <System.Security.Permissions.PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
    Public Class BlendFillTypeConverter
        Inherits TypeConverter

        '=------------------------------------------------------------------=
        ' CanConvertTo
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   We support conversion to String as well as InstanceDescriptor
        '''   format, which makes it a bit easier on us in code generation.
        ''' </summary>
        ''' 
        Public Overloads Overrides Function CanConvertTo( _
                                     ByVal context As ITypeDescriptorContext, _
                                     ByVal destinationType As Type) _
                                     As Boolean

            If destinationType Is GetType(String) _
               OrElse destinationType Is GetType(InstanceDescriptor) Then

                Return True
            End If

            Return MyBase.CanConvertTo(context, destinationType)

        End Function ' CanConvertTo


        '=------------------------------------------------------------------=
        ' ConvertTo
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   This is how we convert ourselves to a string or an Instance-
        '''   Descriptor, which is used in code generation.
        ''' </summary>
        ''' 
        Public Overloads Overrides Function ConvertTo( _
                                    ByVal context As ITypeDescriptorContext, _
                                    ByVal culture As System.Globalization.CultureInfo, _
                                    ByVal value As Object, _
                                    ByVal destinationType As System.Type) _
                                    As Object

            Dim ci As ConstructorInfo
            Dim bf As BlendFill

            '
            ' We'll only do something if they're asking us to convert a 
            ' BlendFill object, of course ...
            '
            If TypeOf value Is BlendFill Then
                bf = CType(value, BlendFill)
            Else
                bf = Nothing
            End If

            If Not bf Is Nothing Then
                '
                ' What type do they want???
                '
                If destinationType Is GetType(InstanceDescriptor) Then

                    '
                    ' Get the constructor that takes the style, and two
                    ' colors
                    '
                    ci = GetType(BlendFill).GetConstructor(New Type() { _
                                            GetType(BlendStyle), _
                                            GetType(Color), _
                                            GetType(Color)})

                    If Not ci Is Nothing Then

                        '
                        ' Return the values for this constructor.
                        '
                        Return New InstanceDescriptor(ci, New Object() { _
                                        bf.Style, _
                                        bf.StartColor, _
                                        bf.FinishColor})

                    End If

                ElseIf destinationType Is GetType(String) Then

                    Return blendFillToString(bf, culture)

                End If
            Else
                System.Diagnostics.Debug.WriteLine( _
                        "BlendFillTypeConverter.ConvertTo:Curious:  We've " _
                        & "been asked to code gen something that isn't: " _
                        & "of type BlendFill: " _
                        & value.GetType().ToString())
            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)

        End Function ' ConvertTo


        '=------------------------------------------------------------------=
        ' ConvertFrom
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   You can convert from Strings (of a certain type) to this object.
        ''' </summary>
        '''
        Public Overloads Overrides Function ConvertFrom( _
                                    ByVal context As ITypeDescriptorContext, _
                                    ByVal culture As System.Globalization.CultureInfo, _
                                    ByVal value As Object) _
                                    As Object

            Dim bf As String

            '
            ' If they gave us a string, then we'll try our best to parse it 
            ' out.
            '
            If TypeOf value Is String Then
                bf = CType(value, String)
            Else
                bf = Nothing
            End If

            If Not bf Is Nothing Then
                Return blendFillFromString(bf.Trim(), culture)
            End If

            Return MyBase.ConvertFrom(context, culture, value)

        End Function ' ConvertFrom


        '=------------------------------------------------------------------=
        ' CanConvertFrom
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   You can convert from Strings (of a certain type) to this object.
        ''' </summary>
        '''
        Public Overloads Overrides Function CanConvertFrom( _
                                    ByVal context As ITypeDescriptorContext, _
                                    ByVal sourceType As Type) _
                                    As Boolean

            If sourceType Is GetType(String) Then Return True
            Return MyBase.CanConvertFrom(context, sourceType)

        End Function ' CanConvertFrom


        '=------------------------------------------------------------------=
        ' parseBlendStyle
        '=------------------------------------------------------------------=
        ''' <summary>
        '''    Given the string value of a blend style, parse it back to an int
        ''' </summary>
        ''' 
        ''' <param name="in_val">
        '''   A BlendFill object as a string.
        ''' </param>
        ''' 
        ''' <returns>
        '''   A BlendFill object representing the value from the string.
        ''' </returns>
        ''' 
        Private Shared Function parseBlendStyle(ByVal in_val As String) _
                                                As BlendStyle

            Dim names() As String
            Dim x As Integer

            System.Diagnostics.Debug.Assert(Not in_val Is Nothing)
            in_val = in_val.Trim()

            '
            ' Okay, get the list of names in the Enumeration.
            '
            names = System.Enum.GetNames(GetType(BlendStyle))
            For x = 0 To names.Length - 1
                If names(x).Equals(in_val) Then Return CType(x, BlendStyle)
            Next

            Return BlendStyle.Horizontal

        End Function ' parseBlendStyle


        '=------------------------------------------------------------------=
        ' blendFillToString
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Converts a blend fill object to a string, using Culture 
        '''   Sensitive separators and using text values where possible.
        ''' </summary>
        ''' 
        ''' <param name="in_bf">
        '''   Convert me to a string.
        ''' </param>
        ''' 
        ''' <param name="in_culture">
        '''   From whence to get the cultural information.
        ''' </param>
        ''' 
        ''' <returns>
        '''   The object as s string.
        ''' </returns>
        ''' 
        Private Shared Function blendFillToString(ByVal in_bf As BlendFill, _
                                                  ByVal in_culture As CultureInfo) _
                                                  As String

            Dim sb As System.Text.StringBuilder
            Dim tci, tcc As TypeConverter
            Dim sep As String
            Dim args(2) As String

            '
            ' Get appropriate conveters and culture data
            '
            tci = TypeDescriptor.GetConverter(GetType(Integer))
            tcc = TypeDescriptor.GetConverter(GetType(Color))
            If in_culture Is Nothing Then in_culture = CultureInfo.CurrentCulture
            sep = in_culture.TextInfo.ListSeparator & " "

            '
            ' Get the style as a string
            '
            args(0) = System.Enum.GetName(GetType(BlendStyle), in_bf.Style)

            '
            ' start color
            '
            args(1) = tcc.ConvertToString(in_bf.StartColor)

            '
            ' Finish color
            '
            args(2) = tcc.ConvertToString(in_bf.FinishColor)

            '
            ' Generate the string.  We have to wrap the colors in () so that
            ' ARGB specified ones can be determined later ...
            '
            sb = New System.Text.StringBuilder

            sb.Append(args(0))
            sb.Append(sep)
            sb.Append("(")
            sb.Append(args(1))
            sb.Append(")")
            sb.Append(sep)
            sb.Append("(")
            sb.Append(args(2))
            sb.Append(")")

            Return sb.ToString()

        End Function ' blendFillToString


        '=------------------------------------------------------------------=
        ' blendFillFromString
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Given a string that we serialized out using blendFillToString,
        '''   this function attempts to parse in the given input and
        '''   regenerate a  BlendFill object.
        ''' </summary>
        ''' 
        ''' <param name="in_bf">
        '''   What to parse back into a BlendFill.
        ''' </param>
        ''' 
        ''' <param name="in_culture">
        '''   What cultural information to use for this parse.
        ''' </param>
        ''' 
        ''' <returns>
        '''   A BlendFill representing the data from the string.
        ''' </returns>
        '''
        Private Shared Function blendFillFromString(ByVal in_bf As String, _
                                                    ByVal in_culture As CultureInfo) _
                                                    As BlendFill
            Dim tcc As TypeConverter
            Dim style As BlendStyle
            Dim pieces() As String
            Dim c1, c2 As Color
            Dim sep As String

            '
            ' Get the various type converters and culture info we need
            '
            If in_culture Is Nothing Then in_culture = CultureInfo.CurrentCulture
            sep = in_culture.TextInfo.ListSeparator
            tcc = TypeDescriptor.GetConverter(GetType(Color))

            '
            ' Explode the string.  Unfortunately, we can't using String.Split
            ' since we need to preserve ()s around the colors.
            '
            pieces = MiscFunctions.ExplodePreservingSubObjects(in_bf, sep, "(", ")")

            If Not pieces.Length = 3 Then
                Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excBlendFillParse"), "value")
            End If

            style = parseBlendStyle(pieces(0))
            c1 = CType(tcc.ConvertFromString(pieces(1)), Color)
            c2 = CType(tcc.ConvertFromString(pieces(2)), Color)

            If style = -1 OrElse c1.Equals(Color.Empty) OrElse c2.Equals(Color.Empty) Then
                Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excBlendFillParse"), "value")
            End If

            Return New BlendFill(style, c1, c2)

        End Function ' blendFillFromString

    End Class ' BlendFillTypeConverter




End Class ' BlendFill





