Imports System
Imports System.Web
Imports System.Web.UI

Namespace TemplateControlSamples

    Public Class Template1VB : Inherits Control : Implements INamingContainer

        Private _messageTemplate As ITemplate = Nothing
        Private _message As String = Nothing   

        Public Property Message As String

           Get
              Return _message
           End Get
           Set
              _message = Value
           End Set
        End Property

        
        Public Property <Template(GetType(Template1VB))> MessageTemplate As ITemplate

           Get
              Return _messageTemplate
           End Get
           Set
              _messageTemplate = Value
           End Set
        End Property

        Protected Overrides Sub CreateChildControls()

           ' If a template has been specified, use it to create children.
           ' Otherwise, create a single literalcontrol with message value

           If Not (MessageTemplate Is Nothing)
              MessageTemplate.Initialize(Me)
           Else
              Me.Controls.Add(New LiteralControl(Me.Message))
           End If
        End Sub

    End Class

End Namespace