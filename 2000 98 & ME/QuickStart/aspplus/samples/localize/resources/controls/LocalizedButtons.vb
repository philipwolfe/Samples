Imports System
Imports System.Globalization
Imports System.Reflection
Imports System.Resources
Imports System.Threading
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls



Namespace LocalizedControls_VB 

Friend Class ResourceFactory 
    Shared _rm As ResourceManager

    Public Shared ReadOnly Property RManager As ResourceManager
        Get
                If(_rm Is Nothing) Then
                    _rm = new ResourceManager("LocalizedStrings", System.Reflection.Assembly.GetExecutingAssembly(), Nothing, True)
                End If
                RManager = _rm
        End Get
    End Property
End Class
    


Class LocalizedButton
Inherits System.Web.UI.WebControls.Button 

    Overrides Protected Sub Render (writer As HtmlTextWriter) 
            Me.Text = ResourceFactory.RManager.GetString(Me.Text)
            MyBase.Render(writer)
    End Sub
    
End Class

End Namespace

