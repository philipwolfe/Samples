' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

''' <summary>
''' Project which contains Options Classes need by ALL Mood Orb-related projects, including 
''' remote services, local orblings and the Mood Orb itself
''' </summary>
''' <remarks></remarks>

Public MustInherit Class OrbOption

    'Displays the UI for the option within the options list
    Public MustOverride Function GetOptionUI() As UIElement

    'Serializes the option so it can be sent to a service orbling
    Public MustOverride Function SerializeData() As String

    'Deserializes the option so it can be sent to a service orbling
    Public MustOverride Sub DeserializeData(ByVal serializedData As String)

    'Serializes the option so it can be sent to a service orbling and adds the necessary data header
    Public Function Serialize() As String

        Dim finalData As String

        finalData = "{" & Me.GetType().Name & "}" & Me.SerializeData()

        Return finalData

    End Function

    'Deserializes the option so it can be sent to a service orbling and checks the necessary data header
    Public Sub Deserialize(ByVal serializedData As String)

        If serializedData Is Nothing Then
            Throw New IO.InvalidDataException("An Invalid String Data was sent to the deserializer.")
        End If

        'check if valid
        If serializedData.StartsWith("{" & Me.GetType().Name & "}") Then
            Me.DeserializeData(serializedData.Remove(0, Me.GetType().Name.Length + 2))
        Else
            Throw New IO.InvalidDataException("An Invalid String Data was sent to the deserializer.")
        End If


    End Sub

    'Deserializes a specific option into the correct option class
    Private Shared Function DeserializeOption(ByVal serializedData As String) As OrbOption

        If serializedData Is Nothing Then
            Throw New IO.InvalidDataException("An Invalid String Data was sent to the deserializer.")
        End If

	Dim stIndex=serializedData.IndexOf("}")

	Dim serializedType As String = serializedData.Substring(1,stIndex-1)

	If serializedType.StartsWith("Orb") And serializedType.EndsWith("Option") Then
            Dim optionHandle As Runtime.Remoting.ObjectHandle = Activator.CreateInstanceFrom("ExternalClasses.dll", "Microsoft.Samples.MoodOrb." & serializedType)
		Dim optionValue As OrbOption = CType(Activator.CreateInstance(optionHandle.Unwrap().GetType()),OrbOption)

		Return optionValue
	End If

        'Didn't find any matching option types, return Nothing
        Return Nothing
    End Function

    Public Shared Function DeserializeOptions(ByVal OptionsList As Dictionary(Of String, Object)) As Dictionary(Of String, Object)

        Dim optionKey As String
        Dim serializedValue As String

        Dim NewList As New Dictionary(Of String, Object)

        'Deserialize each option and store it in the new list
        For Each optionKey In OptionsList.Keys

            serializedValue = OptionsList(optionKey).ToString()

            Dim newOption As OrbOption = OrbOption.DeserializeOption(serializedValue)

            NewList.Add(optionKey, newOption)
        Next

        Return NewList

    End Function

    Public Shared Function SerializeOptions(ByVal OptionsList As Dictionary(Of String, Object)) As Dictionary(Of String, Object)

        Dim optionKey As String
        Dim serializedValue As String

        Dim NewList As New Dictionary(Of String, Object)

        'Serialize each option and store it in the new list
        For Each optionKey In OptionsList.Keys

            serializedValue = CType(OptionsList(optionKey), OrbOption).Serialize()

            NewList.Add(optionKey, serializedValue)
        Next

        Return NewList

    End Function

End Class

Public Class OrbPercentOption
    Inherits OrbOption

    Private m_Value As Double
    Private m_EntryBox As TextBox

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Double)
        Me.Value = value
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Return m_Value.ToString()

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        Dim doubleValue As Double

        If Double.TryParse(serializedData, doubleValue) Then
            m_Value = doubleValue

        Else
            m_Value = 0
        End If

    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement

        m_EntryBox = New TextBox

        m_EntryBox.Text = m_Value.ToString()

        AddHandler m_EntryBox.TextChanged, AddressOf EntryBlock_TextChanged

        Return m_EntryBox

    End Function


    Private Sub EntryBlock_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)

        m_EntryBox.Background = Brushes.White

        If Not OrbPercentOption.TryParse(m_EntryBox.Text, m_Value) Then
            m_EntryBox.Background = Brushes.LightCoral
        End If

    End Sub

    Private Shared Function TryParse(ByVal s As String, ByRef value As Double) As Boolean

        Dim oldValue As Double = value

        If Double.TryParse(s, value) Then
            If (value >= 0 And value <= 1) Then
                Return True
            Else
                value = oldValue
                Return False
            End If
        End If

        value = oldValue
        Return False

    End Function

    Public Property Value() As Double
        Get
            Return m_Value
        End Get
        Set(ByVal value As Double)
            If value > 1 Or value < 0 Then
                Throw New ArgumentOutOfRangeException("value", "A percentage can only be between 0 and 1")
            End If

            m_Value = value
        End Set
    End Property
End Class

Public Class OrbColorOption
    Inherits OrbOption

    Private m_Value As Color
    Private m_ComboColorBox As ComboBox

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Color)
        m_Value = value
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Return m_Value.R.ToString() & "," & m_Value.G.ToString() & "," & m_Value.B

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        If serializedData Is Nothing Then
            Throw New ArgumentNullException("serializedData")
        End If

        Dim colorParts As Array = serializedData.Split(","c)

        If (colorParts.Length <> 3) Then
            Throw New IO.InvalidDataException("The serialized color passed in is invalid")
        End If

        Dim rTry As Boolean = Byte.TryParse(colorParts(0), m_Value.R)
        Dim gTry As Boolean = Byte.TryParse(colorParts(1), m_Value.G)
        Dim bTry As Boolean = Byte.TryParse(colorParts(2), m_Value.B)

        If Not (rTry And gTry And bTry) Then
            Throw New IO.InvalidDataException("The serialized color passed in is invalid")
        End If

    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement
        Dim propertyList As Array = GetType(Colors).GetProperties()
        Dim colorProperty As System.Reflection.PropertyInfo

        m_ComboColorBox = New ComboBox

        For Each colorProperty In propertyList

            Dim colorItem As Color = CType(colorProperty.GetValue(Nothing, Nothing), Color)

            Dim colorElement As New ComboColorElement(colorProperty.Name, colorItem)

            m_ComboColorBox.Items.Add(colorElement)

            If (colorItem = m_Value) Then
                m_ComboColorBox.SelectedItem = colorElement
            End If
        Next

        AddHandler m_ComboColorBox.SelectionChanged, AddressOf ComboColorBox_SelectionChanged

        Return m_ComboColorBox

    End Function

    Public Property Value() As Color
        Get
            Return m_Value
        End Get
        Set(ByVal value As Color)
            m_Value = value
        End Set
    End Property

    Private Sub ComboColorBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

        Dim colorBox As ComboBox = CType(sender, ComboBox)

        Dim newValue As ComboColorElement = CType(colorBox.SelectedItem, ComboColorElement)

        m_Value = newValue.Color
    End Sub

    Private Class ComboColorElement
        Inherits ItemsControl

        Private m_Color As Color

        Public Sub New(ByVal itemName As String, ByVal itemColor As Color)
            m_Color = itemColor

            Dim layoutPanel As New StackPanel
            layoutPanel.Orientation = Orientation.Horizontal
            layoutPanel.VerticalAlignment = Windows.VerticalAlignment.Center

            Dim colorRect As New Rectangle
            colorRect.Fill = New SolidColorBrush(itemColor)
            colorRect.Stroke = Brushes.LightGray
            colorRect.Width = 20
            colorRect.Height = 14
            colorRect.RadiusX = 2
            colorRect.RadiusY = 2
            colorRect.Margin = New Thickness(2)

            Dim titleBlock As New TextBlock
            titleBlock.Text = itemName
            titleBlock.Height = 14
            titleBlock.Foreground = Brushes.Black

            layoutPanel.Children.Add(colorRect)
            layoutPanel.Children.Add(titleBlock)

            Me.AddChild(layoutPanel)
        End Sub

        Public ReadOnly Property Color() As Color
            Get
                Return m_Color
            End Get
        End Property
    End Class

End Class

Public Class OrbListOption
    Inherits OrbOption
    Implements IEnumerable

    Private m_List As List(Of String)
    Private m_ListOptionBox As ListBox

    Public Sub New()
        m_List = New List(Of String)
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Dim listBuilder As New StringBuilder

        Dim listItem As String

        For Each listItem In m_List
            listBuilder.AppendLine(listItem)
        Next

        Return listBuilder.ToString()

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        If (serializedData.Length > 0) Then
            m_List = New List(Of String)(serializedData.Split(vbCrLf))
        End If

    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement

        m_ListOptionBox = New ListBox()
        m_ListOptionBox.MaxHeight = 100
        m_ListOptionBox.Width = 200

        Dim item As String

        For Each item In m_List

            Dim stringElement As New StringListElement(item)

            AddHandler stringElement.ElementChanged, AddressOf StringListElement_Changed
            AddHandler stringElement.ElementEmptied, AddressOf StringListElement_Emptied

            m_ListOptionBox.Items.Add(stringElement)
        Next


        Dim addButton As New Button

        addButton.Content = "Add"
        addButton.Margin = New Thickness(4)
        AddHandler addButton.Click, AddressOf AddButton_Clicked

        Dim listLayoutPanel As New StackPanel

        listLayoutPanel.Orientation = Orientation.Horizontal

        listLayoutPanel.Children.Add(m_ListOptionBox)
        listLayoutPanel.Children.Add(addButton)

        Return listLayoutPanel

    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return m_List.GetEnumerator()
    End Function

    Public Sub Add(ByVal value As String)
        m_List.Add(value)
    End Sub

    Private Sub AddButton_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim stringElement As New StringListElement("")

        m_ListOptionBox.Items.Add(stringElement)

        AddHandler stringElement.ElementChanged, AddressOf StringListElement_Changed
        AddHandler stringElement.ElementEmptied, AddressOf StringListElement_Emptied

    End Sub

    Private Sub StringListElement_Emptied(ByVal sender As StringListElement)

        m_ListOptionBox.Items.Remove(sender)

        Dim itemList As New List(Of String)

        Dim stringElement As StringListElement

        For Each stringElement In m_ListOptionBox.Items
            itemList.Add(stringElement.Value)
        Next

        m_List = itemList
    End Sub

    Private Sub StringListElement_Changed(ByVal sender As StringListElement)

        Dim itemList As New List(Of String)

        Dim stringElement As StringListElement

        For Each stringElement In m_ListOptionBox.Items
            itemList.Add(stringElement.Value)
        Next

        m_List = itemList
    End Sub


    Public Function GetList() As List(Of String)
        Return New List(Of String)(m_List.ToArray())
    End Function

    Private Class StringListElement
        Inherits ItemsControl

        Delegate Sub ChangeDelegate(ByVal sender As StringListElement)
        Event ElementChanged As ChangeDelegate
        Event ElementEmptied As ChangeDelegate

        Private m_Value As String

        Public Sub New(ByVal itemValue As String)
            m_Value = itemValue

            Dim editBox As New TextBox

            editBox.Text = itemValue

            If editBox.Text.Length = 0 Then
                editBox.Text = "(Click Here to Enter)"
            End If

            editBox.BorderThickness = New Thickness(0)
            editBox.IsReadOnly = True
            editBox.Background = Brushes.Transparent
            editBox.HorizontalAlignment = Windows.HorizontalAlignment.Stretch

            AddHandler editBox.GotFocus, AddressOf EditBox_GotFocus
            AddHandler editBox.LostFocus, AddressOf EditBox_LostFocus

            Me.AddChild(editBox)

        End Sub

        Private Sub EditBox_GotFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim editBox As TextBox = CType(sender, TextBox)

            If (editBox.Text = "(Click Here to Enter)") Then
                editBox.Text = ""
            End If

            editBox.IsReadOnly = False
            editBox.BorderThickness = New Thickness(1)

            editBox.SelectAll()

        End Sub
        Private Sub EditBox_LostFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim editBox As TextBox = CType(sender, TextBox)

            If (editBox.Text.Length = 0) Then
                'delete this element
                RaiseEvent ElementEmptied(Me)
            Else
                editBox.IsReadOnly = True
                editBox.BorderThickness = New Thickness(0)
                Me.m_Value = editBox.Text
                editBox.Background = Brushes.Transparent

                RaiseEvent ElementChanged(Me)
            End If

        End Sub


        Public ReadOnly Property Value() As String
            Get
                Return m_Value
            End Get
        End Property
    End Class
End Class

Public Class OrbValuePairOption
    Inherits OrbOption
    Implements IEnumerable

    Private m_List As Dictionary(Of String, String)
    Private m_Value As String

    Public Sub New()
        m_List = New Dictionary(Of String, String)
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Dim listBuilder As New StringBuilder

        Dim keyItem As String

        listBuilder.AppendLine(m_Value)

        For Each keyItem In m_List.Keys
            listBuilder.AppendLine(keyItem + "\t" + m_List(keyItem))
        Next

        Return listBuilder.ToString()

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        Dim pairList As List(Of String) = New List(Of String)(serializedData.Split(vbCrLf))

        Dim itemData As String

        Dim i As Integer

        For i = 0 To pairList.Count
            itemData = pairList(i)

            If i = 0 Then
                'Get the selected item
                m_Value = itemData
            Else
                Dim pairData As Array = itemData.Split(Chr(9))

                m_List.Add(pairData(0), pairData(1))
            End If
        Next i
    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement

        Dim m_ComboOptionBox As New ComboBox
        Dim item As String

        For Each item In m_List.Keys
            m_ComboOptionBox.Items.Add(New ComboDictionaryElement(item, m_List(item)))
        Next

        AddHandler m_ComboOptionBox.SelectionChanged, AddressOf ComboOptionBox_SelectionChanged

        m_ComboOptionBox.SelectedIndex = 0

        Return m_ComboOptionBox

    End Function

    Public Sub Add(ByVal key As String, ByVal value As String)
        m_List.Add(key, value)
    End Sub

    Private Sub ComboOptionBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

        Dim optionBox As ComboBox = CType(sender, ComboBox)

        Dim newValue As ComboDictionaryElement = CType(optionBox.SelectedItem, ComboDictionaryElement)

        m_Value = newValue.Key

    End Sub

    Public ReadOnly Property Value() As String
        Get
            Return (m_Value)
        End Get
    End Property

    Private Class ComboDictionaryElement
        Inherits ItemsControl

        Private m_Key As String

        Public Sub New(ByVal itemKey As String, ByVal itemValue As Object)
            m_Key = itemKey

            Me.AddChild(itemValue)
        End Sub

        Public ReadOnly Property Key() As String
            Get
                Return m_Key
            End Get
        End Property
    End Class

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return m_List.GetEnumerator()
    End Function
End Class

Public Class OrbHoursOption
    Inherits OrbOption

    Private m_Value As Double
    Private m_EntryBox As TextBox

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Double)
        Me.Value = value
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Return m_Value.ToString()

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        Dim doubleValue As Double

        If Double.TryParse(serializedData, doubleValue) Then
            m_Value = doubleValue
        Else
            m_Value = 0
        End If

    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement

        m_EntryBox = New TextBox

        m_EntryBox.Text = m_Value.ToString()

        AddHandler m_EntryBox.TextChanged, AddressOf EntryBlock_TextChanged

        Return m_EntryBox

    End Function


    Private Sub EntryBlock_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)

        m_EntryBox.Background = Brushes.White

        If Not OrbHoursOption.TryParse(m_EntryBox.Text, m_Value) Then
            m_EntryBox.Background = Brushes.LightCoral
        End If

    End Sub

    Private Shared Function TryParse(ByVal s As String, ByRef value As Double) As Boolean

        Dim oldValue As Double = value

        If Double.TryParse(s, value) Then
            If (value >= 0 And value < 24) Then
                Return True
            Else
                value = oldValue
                Return False
            End If
        End If

        value = oldValue
        Return False

    End Function

    Public Property Value() As Double
        Get
            Return m_Value
        End Get
        Set(ByVal value As Double)
            If value >= 24 Or value < 0 Then
                Throw New ArgumentOutOfRangeException("value", "A hours option can only be between 0 inclusive and 24 exclusive")
            End If

            m_Value = value
        End Set
    End Property
End Class

Public Class OrbZipCodeOption
    Inherits OrbOption

    Private m_Value As Integer
    Private m_EntryBox As TextBox

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Double)
        Me.Value = value
    End Sub

    'Overrides the base function and serializes the data
    Public Overrides Function SerializeData() As String

        Return m_Value.ToString()

    End Function

    'Overrides the base function and deserializes the data
    Public Overrides Sub DeserializeData(ByVal serializedData As String)

        Dim zipValue As Integer

        If Integer.TryParse(serializedData, zipValue) Then
            m_Value = zipValue

        Else
            m_Value = 0
        End If

    End Sub

    'Overrides the base function and provides the user interface for the element
    Public Overrides Function GetOptionUI() As System.Windows.UIElement

        m_EntryBox = New TextBox

        m_EntryBox.Text = m_Value.ToString()

        AddHandler m_EntryBox.TextChanged, AddressOf EntryBlock_TextChanged

        Return m_EntryBox

    End Function


    Private Sub EntryBlock_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)

        m_EntryBox.Background = Brushes.White

        If Not OrbZipCodeOption.TryParse(m_EntryBox.Text, m_Value) Then
            m_EntryBox.Background = Brushes.LightCoral
        End If

    End Sub

    Private Shared Function TryParse(ByVal s As String, ByRef value As Double) As Boolean

        Dim oldValue As Double = value

        If Integer.TryParse(s, value) Then
            If s.Length = 5 And value > 0 And value < 100000 Then
                Return True
            Else
                value = oldValue
                Return False
            End If
        End If

        value = oldValue
        Return False

    End Function

    Public ReadOnly Property StringValue() As String
        Get
            Dim strValue As String
            strValue = m_Value.ToString()

            strValue = strValue.PadLeft(strValue.Length - 5, "0"c)

            Return strValue
        End Get
    End Property

    Public Property Value() As Integer
        Get
            Return m_Value
        End Get
        Set(ByVal value As Integer)
            If value < 0 Or value > 100000 Then
                Throw New ArgumentOutOfRangeException("value", "A zip code must be between 0 and 99999")
            End If

            m_Value = value
        End Set
    End Property
End Class
