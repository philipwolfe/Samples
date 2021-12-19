Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports System.Web.UI.WebControls

Namespace NonCompositionSampleControls

    Public Class NonComposition2VB : Inherits Control : Implements IPostBackDataHandler : Implements IPostBackEventHandler

        Private _value As Integer = 0

        public Property Value As Integer

           Get
               Return _value
           End Get
           Set 
               _value = Value
           End Set

        End Property

        Public Function LoadPostData(PostDataKey As String, Values As NameValueCollection) As Boolean Implements IPostBackDataHandler.LoadPostData

           _value = Int32.Parse(values(Me.UniqueID))
           Return false
        End Function

        Public Sub RaisePostDataChangedEvent() Implements IPostBackDataHandler.RaisePostDataChangedEvent

           ' Part of the IPostBackDataHandler contract.  Invoked if we ever returned true from the
           ' LoadPostData method (indicates that we want a change notification raised).  Since we
           ' always return false, this method is just a no-op.
        End Sub

        Public Sub RaisePostBackEvent(EventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent
           
           If (eventArgument = "Add")
              Me.Value = Me.Value + 1
           Else
              Me.Value = Me.Value - 1
           End If
        End Sub

        Protected Overrides Overloads Sub OnPreRender(E As EventArgs)
           Page.RegisterPostBackScript()
        End Sub

        Protected Overrides Sub Render(Output As HtmlTextWriter)
           Output.Write("<h3>Value: <input name=" & Me.UniqueID & " type=text value=" & Me.Value & "> </h3>")
           Output.Write("<input type=button value=Add OnClick=""jscript:" & Page.GetPostBackEventReference(Me, "Add") & """> |")
           Output.Write("<input type=button value=Subtract OnClick=""jscript:" & Page.GetPostBackEventReference(Me, "Subtract") & """>")
        End Sub    

    End Class

End Namespace
