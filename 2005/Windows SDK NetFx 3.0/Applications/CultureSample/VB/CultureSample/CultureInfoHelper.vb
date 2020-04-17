'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
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
'-----------------------------------------------------------------------
Imports System
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections


'/ <summary>
'/ Class which handled all the logic behind the sample.
'/ </summary>

Public Class CultureInfoHelper
    'Handle to display the newly created windows
    Private displayHelper As DisplayCulture
    
    
    Public Sub New(ByVal display As DisplayCulture) 
        displayHelper = display
    
    End Sub 'New
    
    
    '*
'                * Method to create a new culture either by mixing or inheriting from the
'                * InvariantCulture
'                
    Public Sub GetNewCultureInfo(ByVal numberFormat As NumberFormatInfo, ByVal dateFormat As DateTimeFormatInfo, ByVal locale As String, ByVal name As String) 
        Try
            Dim ci As New CultureInfo(locale)
            Dim ri As RegionInfo
            'In case the locale name is empty as is for Invariant culture
            If locale.Length = 0 Then
                ri = RegionInfo.CurrentRegion
            Else
                ri = New RegionInfo(locale)
            End If 'Split the name to language and region
            Dim lang As String() = name.Split(Constants.CharHyphen)
            'Use the builder to register the culture
'            Dim cib As New CultureAndRegionInfoBuilder(ci +  ri, lang(0), lang(1))

            Dim mods As New CultureAndRegionModifiers
            mods = CultureAndRegionModifiers.None
            
            ' check if the new culture is neutral
            If (name.IndexOf("-") < 0) Then
              mods = mods Or CultureAndRegionModifiers.Neutral
            End If

            Try
              Dim test As New CultureInfo(name)
              mods = mods Or CultureAndRegionModifiers.Replacement
            Catch ex As System.ArgumentException
              'Do nothing - the culture is not a replacement
            End Try
            
            Dim cib As New CultureAndRegionInfoBuilder(name, mods)

            cib.LoadDataFromCultureInfo(ci)
            cib.LoadDataFromRegionInfo(ri)

            cib.NumberFormat = numberFormat
            cib.GregorianDateTimeFormat = dateFormat
            cib.IetfLanguageTag = name
            cib.Register()
            
            'Add the new culture using the DisplayCulture
            Add(name)
            
            MessageBox.Show(Constants.SuccessMessage)
        Catch ex As System.IO.IOException
            'The .nlp file already exists
            MessageBox.Show(Constants.ErrorFileFound)
        Catch ex As System.ArgumentOutOfRangeException
            MessageBox.Show(ex.ToString())
        End Try
    
    End Sub 'GetNewCultureInfo
    
    
    '*
'                * Method to create a new culture instance by inheriting from 
'                * a culture
'                
    Public Sub NewCultureInstance(ByVal locale As String, ByVal name As String) 
        Try
            Dim ci As New CultureInfo(locale)
            Dim ri As RegionInfo
            'In case the locale name is empty as is for Invariant culture
            If locale.Length = 0 Then
                ri = RegionInfo.CurrentRegion
            Else
                ri = New RegionInfo(locale)
            End If 'Split the name to language and region
            Dim lang As String() = ci.Name.Split(Constants.CharHyphen)
            
            'Split the name to language and region
            '            Dim cib As New CultureAndRegionInfoBuilder(ci, ri, lang(0), lang(1), Name)


            Dim mods As New CultureAndRegionModifiers
            mods = CultureAndRegionModifiers.None
            
            ' check if the new culture is neutral
            
            If (name.IndexOf("-") < 0) Then
              mods = mods Or CultureAndRegionModifiers.Neutral
            End If
            Try
                Dim test As New CultureInfo(name)
                mods = mods Or CultureAndRegionModifiers.Replacement
            Catch ex As System.ArgumentException
                'Do nothing - since no name was found in the framework, the culture is not a replacement
            End Try

            Dim cib As New CultureAndRegionInfoBuilder(name, mods)

            cib.LoadDataFromCultureInfo(ci)

            If ((mods And CultureAndRegionModifiers.Neutral) = 0) Then
                cib.LoadDataFromRegionInfo(ri)
            End If


            cib.Register()

            'Add the new culture using the DisplayCulture
            Add(name)
            MessageBox.Show(Constants.SuccessMessage)
        Catch ex As System.ArgumentOutOfRangeException
            MessageBox.Show(ex.ToString())
        Catch exio As System.InvalidOperationException
            MessageBox.Show("That culture already exists. Please add a NEW instance of a culture")
        Catch exi As System.ArgumentException
            MessageBox.Show("That culture already exists. Please add a NEW instance of a culture")
        End Try
    
    End Sub 'NewCultureInstance
    
    
    '*
'                * Get all cultures of a particular type
'                * Used to load the Comboboxes
'                
    Public Function GetCultures(ByVal type As CultureTypes) As String() 
        Dim cis As CultureInfo() = CultureInfo.GetCultures(type)
        Dim names(cis.Length - 1) As String
        Dim i As Integer
        For i = 0 To cis.Length - 1
            names(i) = cis(i).Name
        Next i
        Return names
    
    End Function 'GetCultures
    
    
    Public Sub Add(ByVal cultureName As String) 
        displayHelper.AddSelectItem(cultureName)
    
    End Sub 'Add
End Class 'CultureInfoHelper
