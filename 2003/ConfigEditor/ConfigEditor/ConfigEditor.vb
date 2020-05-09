Public Class ConfigEditor
	Inherits CollectionBase

#Region " Declarations "
	Private _FilePath As String = ""
	Private _ItemNodeName As String = "add"
	Private _KeyName As String = "key"
	Private _ValueName As String = "value"
	Private _AllowDuplicateKeys As Boolean = False
#End Region

#Region " Properties "
	Public Property FilePath() As String
		Get
			Return _FilePath
		End Get
		Set(ByVal Value As String)
			_FilePath = Value
			LoadConfigFile()
		End Set
	End Property

	Public Property ItemNodeName() As String
		Get
			Return _ItemNodeName
		End Get
		Set(ByVal Value As String)
			_ItemNodeName = Value
		End Set
	End Property

	Public Property KeyName() As String
		Get
			Return _KeyName
		End Get
		Set(ByVal Value As String)
			_KeyName = Value
		End Set
	End Property

	Public Property ValueName() As String
		Get
			Return _ValueName
		End Get
		Set(ByVal Value As String)
			_ValueName = Value
		End Set
	End Property

	Public Property AllowDuplicateKeys() As Boolean
		Get
			Return _AllowDuplicateKeys
		End Get
		Set(ByVal Value As Boolean)
			_AllowDuplicateKeys = Value
		End Set
	End Property
#End Region

#Region " Constructors "
	Public Sub New()
		'don't do anything
	End Sub

	Public Sub New(ByVal FilePath As String)
		Me.FilePath = FilePath
	End Sub

	Public Sub New(ByVal FilePath As String, ByVal KeyName As String, ByVal ValueName As String)
		Me.KeyName = KeyName
		Me.ValueName = ValueName
		Me.FilePath = FilePath
	End Sub
#End Region

#Region " Public Methods "
	Public Sub Load(ByVal FilePath As String)
		Me.FilePath = FilePath
	End Sub

	Public Sub Save()
		Dim TempXML As New XmlDocument()
		TempXML.Load(FilePath)
		Dim TempNode As XmlNode = GetAppSettingsNode(TempXML)
		Dim TempNodeList As XmlNodeList = TempNode.SelectNodes("child::" & ItemNodeName & "[attribute::" & KeyName & " and attribute::" & ValueName & "]")
		Dim ItemNode As XmlNode
		For Each ItemNode In TempNodeList
			TempNode.RemoveChild(ItemNode)
		Next
		Dim Item As ConfigItem
		For Each Item In Me.InnerList
			TempNode.AppendChild(TempXML.CreateElement(ItemNodeName))
			TempNode.LastChild.Attributes.Append(TempXML.CreateAttribute(KeyName)).Value = Item.Key
			TempNode.LastChild.Attributes.Append(TempXML.CreateAttribute(ValueName)).Value = Item.Value
		Next
		TempXML.Save(FilePath)
	End Sub

	Public Overloads Function Add(ByVal Key As String, ByVal Value As String) As ConfigItem
		If Not Me.Item(Key) Is Nothing And Not AllowDuplicateKeys Then
			Throw New Exception("Duplicate Keys not allowed!")
		Else
			Dim Temp As New ConfigItem(Key, Value)
			Me.InnerList.Add(Temp)
			Return Temp
		End If
	End Function

	Public Overloads Function Add(ByVal ConfigItem As ConfigItem) As ConfigItem
		If Not Me.Item(ConfigItem.Key) Is Nothing <> -1 And Not AllowDuplicateKeys Then
			Throw New Exception("Duplicate Keys not allowed!")
		Else
			Me.InnerList.Add(ConfigItem)
			Return ConfigItem
		End If
	End Function

	Public Overloads Function Item(ByVal Index As Integer) As ConfigItem
		Return CType(Me.InnerList.Item(Index), ConfigItem)
	End Function

	Public Overloads Function Item(ByVal ConfigItem As ConfigItem) As ConfigItem
		Return CType(Me.InnerList.Item(Me.InnerList.IndexOf(ConfigItem)), ConfigItem)
	End Function

	Public Overloads Function Item(ByVal Key As String) As ConfigItem
		Dim ConfigItem As ConfigItem
		For Each ConfigItem In Me.InnerList
			If ConfigItem.Key = Key Then
				Return ConfigItem
			End If
		Next
	End Function

	Public Overloads Sub Remove(ByVal ConfigItem As ConfigItem)
		Me.InnerList.Remove(ConfigItem)
	End Sub

	Public Overloads Sub Remove(ByVal Index As Integer)
		Dim ConfigItem As ConfigItem = CType(Me.InnerList.Item(Index), ConfigItem)
		If Not ConfigItem Is Nothing Then
			Me.InnerList.Remove(ConfigItem)
		End If
	End Sub
#End Region

#Region " Private Methods "
	Private Sub LoadConfigFile()
		If Not AllParameters() Then
			Exit Sub
		End If
		Dim i As Integer
		Dim TempXML As New XmlDocument()
		TempXML.Load(FilePath)
		Dim TempNodeList As XmlNodeList = GetAppSettingsNode(TempXML).SelectNodes("child::" & ItemNodeName & "[attribute::" & KeyName & " and attribute::" & ValueName & "]")
		Me.Clear()
		For i = 0 To TempNodeList.Count - 1
			Me.Add(TempNodeList.Item(i).Attributes.GetNamedItem(KeyName).Value, TempNodeList.Item(i).Attributes.GetNamedItem(ValueName).Value)
		Next
		TempXML = Nothing
		TempNodeList = Nothing
	End Sub

	Private Function AllParameters() As Boolean
		If FilePath = "" Then
			Throw New Exception("You must specify a FilePath to the XML file you want to load!")
			Return False
		End If
		If ItemNodeName = "" Then
			Throw New Exception("You must specify an ItemNodeName, which is the NodeName of the items you want to load!")
			Return False
		End If
		If KeyName = "" Then
			Throw New Exception("You must specify a KeyName for the key of the Item collection!")
			Return False
		End If
		If ValueName = "" Then
			Throw New Exception("You must specify a ValueName for the value of the Item collection!")
			Return False
		End If
		Return True
	End Function

	Private Function GetAppSettingsNode(ByVal XMLDoc As XmlDocument) As XmlNode
		Dim Temp As XmlNode = XMLDoc.SelectSingleNode("child::configuration/child::appSettings")
		If Temp Is Nothing Then
			Throw New Exception("'configuration' and/or 'appSettings' node not found in XML file!")
		End If
		Return Temp
	End Function
#End Region

End Class

Public Class ConfigItem

#Region " Declarations "
	Private _Key As String
	Private _Value As String
#End Region

#Region " Properties "
	Public Property Key() As String
		Get
			Return _Key
		End Get
		Set(ByVal Value As String)
			_Key = Value
		End Set
	End Property

	Public Property Value() As String
		Get
			Return _Value
		End Get
		Set(ByVal Value As String)
			_Value = Value
		End Set
	End Property
#End Region

#Region " Constructors "
	Public Sub New()
		'don't do anything
	End Sub

	Public Sub New(ByVal Key As String, ByVal Value As String)
		Me.Key = Key
		Me.Value = Value
	End Sub
#End Region

#Region " Public Methods "
	Public Overrides Function ToString() As String
		Return Me.Key
	End Function
#End Region

End Class