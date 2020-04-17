' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On

Public Class OrbHandler
    Implements IDisposable 'So we can dispose of this class and its resources later
    Implements INotifyPropertyChanged 'So we can use databinding

    Private m_Orbling As ILocalOrbling
    Private m_OrblingOptions As OrbOptions
    Private m_OrblingOptionValues As OrbOptionValues
    Private m_OptionCollection As Collection

    Private m_OrbList As Dictionary(Of String, ILocalOrbling)

    Private m_OrbElementList As Dictionary(Of ILocalOrbling, OrblingElement)

    Private m_OrblingTime As TimeSpan

    Public Function OrblingExists(ByVal orblingID As String) As Boolean

        Return m_OrbList.ContainsKey(orblingID)

    End Function

    Public Sub New()

        'Create a list of valid Orblings
	'NOTE: To add a new orbling, simply add it to this list below and 
	'it will appear in the options window
        m_OrbList = New Dictionary(Of String, ILocalOrbling)
        m_OrbList.Add("StockOrbling", New StockOrbling())
        m_OrbList.Add("LavaOrbling", New LavaOrbling())
        m_OrbList.Add("DiskOrbling", New DiskOrbling())
        m_OrbList.Add("LifeOutlook", New ServiceOrbling("LifeOutlook"))

        'Disabled due to a bug in framework for PDC (see WeatherService/Service.vb for more information):
        'm_OrbList.Add("WeatherService", New ServiceOrbling("WeatherService"))

        'Create an element list of these Orblings to be used in the options window
        m_OrbElementList = New Dictionary(Of ILocalOrbling, OrblingElement)

        Dim orbling As ILocalOrbling

        For Each orbling In m_OrbList.Values
            If Not orbling.GetName() = "LavaOrbling" Then
                m_OrbElementList.Add(orbling, New OrblingElement(orbling))
            End If
        Next

        'Reset the time
        m_OrblingTime = TimeSpan.FromDays(1)

        'Reset our current module to nothing
        m_Orbling = Nothing

    End Sub

    'Get the display information from the Orbling
    Public Function GetInformation() As OrbDisplay

        Dim displayInformation As OrbDisplay

        'Check to make sure a remote orbling is still there
        Try
            displayInformation = m_Orbling.GetInformation(m_OrblingOptionValues)
        Catch ex As ServiceModel.EndpointNotFoundException
	    'Nope, it isn't, display an error
            displayInformation = New OrbDisplay
            displayInformation.DisplayColor = New OrbColor(Colors.Red)
            displayInformation.DisplayType = OrbAnimationType.Pulse
            displayInformation.PulseInformation = OrbPulseDescriber.Forever
            displayInformation.DisplayMessage = "Remote Service Not Found."

        Catch exf As ServiceModel.FaultException
            'Something else odd occurred, display the error to the user
            displayInformation = New OrbDisplay
            displayInformation.DisplayColor = New OrbColor(Colors.Red)
            displayInformation.DisplayType = OrbAnimationType.Pulse
            displayInformation.PulseInformation = OrbPulseDescriber.Forever

            displayInformation.DisplayMessage = "Remote Service Error:" & exf.Message
        End Try

        Return displayInformation
    End Function

    'Retrieves an Orbling by name
    Public Function GetOrbling(ByVal orblingID As String) As ILocalOrbling

        If (Not m_OrbList.ContainsKey(orblingID)) Then
            Throw New ArgumentException("Invalid Orbling Identification")
        End If

        Return m_OrbList(orblingID)

    End Function

    'You can set an orbling by either its name (or a reference)
    Public Sub SetOrbling(ByVal orblingName As String)
        SetOrbling(GetOrbling(orblingName))
    End Sub

    'Refresh to change the orb after it was changed in the options window
    Public Sub Refresh()

        Try
            'Load the time
            m_OrblingTime = m_Orbling.GetTime()
        Catch ex As ServiceModel.EndpointNotFoundException
            MessageBox.Show("That Remote Service cannot be found. Please make sure that service is running and try again.")
            Exit Sub
        End Try

    End Sub

    'You can set an orbling by either (its name or) a reference
    Public Sub SetOrbling(ByVal orbling As ILocalOrbling)

        If Not orbling Is m_Orbling Then

            'Make sure the orbling is there, in case it is a remote service
            Try
                m_OrblingOptions = orbling.GetOptions()
            Catch ex As ServiceModel.EndpointNotFoundException
                MessageBox.Show("That Remote Service cannot be found. Please make sure that service is running and try again.")
                Exit Sub
            End Try

            'Load the options to be displayed
            m_OrblingOptionValues = New OrbOptionValues
            m_OrblingOptionValues.ComponentProperties = New Dictionary(Of String, Object)

            m_OptionCollection = New Collection

            Dim keyString As String

            'Create new options item for each option so they can be displated to the user
            For Each keyString In m_OrblingOptions.ComponentProperties.Keys

                Dim valueObject As OrbOption = CType(m_OrblingOptions.ComponentProperties(keyString), OrbOption)

                Dim optionItem As OptionElement = New OptionElement(keyString, valueObject)

                'Add it to the list
                m_OptionCollection.Add(optionItem)

                'Set the default value
                m_OrblingOptionValues.ComponentProperties.Add(keyString, valueObject)
            Next

            'Update databinding so it knows items changed
            OnPropertyChange("OrblingName")
            OnPropertyChange("OrblingDescription")
            OnPropertyChange("OrblingOptions")

            'Set the current orbling
            m_Orbling = orbling
        End If

    End Sub

    'Retrives the current orbling
    Public ReadOnly Property CurrentOrbling() As ILocalOrbling
        Get
            Return m_Orbling
        End Get
    End Property

    'Retrives the current orbling's refresh time in milliseconds
    Public ReadOnly Property OrblingTime() As Double
        Get
            If Not m_Orbling Is Nothing Then
                Return m_OrblingTime.TotalMilliseconds
            End If

            Return Nothing
        End Get
    End Property

    Public ReadOnly Property OrblingTimeSpan() As TimeSpan
        Get
            Return m_OrblingTime
        End Get
    End Property

    Public ReadOnly Property OrblingOptions() As Collection
        Get
            Return m_OptionCollection
        End Get
    End Property

    'Retrieves the list of orblings in a UI friendly manner (wrapped in OrblingElement class)
    Public ReadOnly Property OrblingList() As Collection
        Get

            Dim orbElementList As New Collection()

            Dim element As OrblingElement

            For Each element In m_OrbElementList.Values
                orbElementList.Add(element)
            Next

            Return orbElementList
        End Get
    End Property

    Public Property CurrentOrblingElement() As OrblingElement
        Get
            Return m_OrbElementList(m_Orbling)
        End Get
        Set(ByVal value As OrblingElement)

            If value Is Nothing Then
                Exit Property
            End If

            If Not (value.Orbling Is m_Orbling) Then
                SetOrbling(value.Orbling)
            End If
        End Set
    End Property


    Public ReadOnly Property OrblingName() As String
        Get
            Return m_OrblingOptions.ComponentName
        End Get
    End Property


    Public ReadOnly Property OrblingDescription() As String
        Get
            Return m_OrblingOptions.ComponentDescription
        End Get
    End Property



    'Property Changed Handler - used to update for DataBindings in the options window
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub OnPropertyChange(ByVal optionName As String)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(optionName))

    End Sub


    Private disposed As Boolean = False

    ' IDisposable
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                m_Orbling = Nothing
            End If

            ' TODO: put code to free unmanaged resources here
        End If
        Me.disposed = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region

End Class
