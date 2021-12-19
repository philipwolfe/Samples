Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Namespace TemplateControlSamples

    Public Class Repeater1VB : Inherits Control : Implements INamingContainer

        Private _itemTemplate As ITemplate = Nothing
        Private _dataSource As ICollection = Nothing 

        Public Property DataSource As ICollection
            Get
               Return _dataSource
            End Get
            Set
               _dataSource = Value
            End Set
        End Property
        
        public Property <Template(GetType(RepeaterItemVB))> ItemTemplate As ITemplate
            Get
               return _itemTemplate
            End Get
            Set
               _itemTemplate = value
            End Set
        End Property

        ' override to prevent literal controls from being added as children
        Public Overrides Sub AddParsedSubObject(O As Object)
        End Sub

        ' override to create repeated items
        Protected Overrides Sub CreateChildControls()
            Dim O As Object = State("NumItems")
            If Not (O = Nothing)
               ' clear any existing child controls
               Controls.Clear()

               Dim I As Integer
               Dim NumItems As Integer = CInt(O)
               For I = 0 To NumItems - 1
                  ' create item
                  Dim Item As RepeaterItemVB = New RepeaterItemVB(I, Nothing)
                  ' initialize item from template
                  ItemTemplate.Initialize(Item)
                  ' add item to the child controls collection
                  Controls.Add(Item)
               Next
            End If
        End Sub

        ' override to create repeated items from DataSource
        Protected Overrides Sub OnDataBinding(E As EventArgs)

            If Not DataSource Is Nothing
                ' clear any existing child controls
                Controls.Clear()
                ' clear any previous viewstate for existing child controls
                ClearChildViewState()

                ' iterate DataSource creating a new item for each data item
                Dim DataEnum As IEnumerator = DataSource.GetEnumerator()
                Dim I As Integer = 0
                Do While (DataEnum.MoveNext())

                    ' create item
                    Dim Item As RepeaterItemVB = New RepeaterItemVB(I, DataEnum.Current)
                    ' initialize item from template
                    ItemTemplate.Initialize(Item)
                    ' add item to the child controls collection
                    Controls.Add(Item)

                    I = I + 1
                Loop

                ' prevent child controls from being created again
                ChildControlsCreated = true
                ' store the number of items created in viewstate for postback scenarios
                State("NumItems") = I
            End If
        End Sub

    End Class

End Namespace