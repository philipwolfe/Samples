'@ Code taken from Andy Smith's DialogWindow control.  Refer http://www.metabuilders.com/

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI


'@ <summary>
'@ Gives better designer support for the ContextMenuToOpen properties of the ContextMenuLink.
'@ </summary>
Public Class MenuControlConverter
    Inherits StringConverter

    Public Sub New()

    End Sub

#Region " Make It A ComboBox "

    '@ <summary>
    '@ Indicates this type converter provides a list of standard values.
    '@ </summary>
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function 'GetStandardValuesSupported

    ' Returns a StandardValuesCollection of standard value objects.
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim serverControls As Object() = Me.GetControls(context.Container)
        If Not (serverControls Is Nothing) Then
            Return New StandardValuesCollection(serverControls)
        End If
        Return Nothing
    End Function 'GetStandardValues


#End Region

#Region " Display Control IDs In List "


    Private Function GetControls(ByVal container As IContainer) As Object()
        Dim availableControls As New ArrayList
        For Each component As IComponent In container.Components
            If (TypeOf component Is Control) Then
                Dim serverControl As Control = CType(component, Control)

                If Not (TypeOf (serverControl) Is Page) AndAlso Not serverControl.ID Is Nothing AndAlso _
                    serverControl.ID.Length > 0 AndAlso IncludeControl(serverControl) Then
                    availableControls.Add(serverControl.ID)
                End If

            End If
        Next
        availableControls.Sort(Comparer.Default)
        Return availableControls.ToArray()
    End Function


    Private Function IncludeControl(ByVal serverControl As Control) As Boolean
        Return TypeOf (serverControl) Is ContextMenu
    End Function

#End Region

End Class