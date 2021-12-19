Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Namespace CustomParsingControlSamples

    Public Class CustomParse2ControlBuilderVB : Inherits ControlBuilder

       Public Overrides Function GetChildControlType(TagName As String, Attributes As IDictionary) As Type

          If TagName = "customitem"
             Return GetType(CustomParsingControlSamples.ItemVB)
          End If

          Return Nothing
       End Function
    End Class

    Public Class <ControlBuilderAttribute(GetType(CustomParse2ControlBuilderVB))> CustomParse2VB : Inherits Control 

       Private _items As New ArrayList
       Private _selectedIndex As Integer = 0

       Public Property SelectedIndex As Integer 
           Get 
              Return _selectedIndex
           End Get
           Set
              _selectedIndex = Value
           End Set
       End Property

       Public Overrides Sub AddParsedSubObject(Obj As Object)

           If (TypeOf Obj Is ItemVB)
              _items.Add(Obj)
           End If
       End Sub

       Protected Overrides Sub Render(Output As HtmlTextWriter)

           If (SelectedIndex < _items.Count)
              Dim SelectedItem As ItemVB = CType(_items(SelectedIndex), ItemVB)
              Output.Write(SelectedItem.Message)
           End If
       End Sub

    End Class    

End Namespace