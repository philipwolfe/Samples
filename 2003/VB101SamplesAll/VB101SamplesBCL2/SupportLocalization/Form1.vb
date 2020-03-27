Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Resources

Namespace SupportLocalization
End Namespace 'SupportLocalization

Public Class Form1
    ' Flag to toggle CultureInfo from one locale to another
    ' in order to affect the language change on the form
    Private Shared isChange As Boolean = False


    ' When the button is clicked, the CultureInfo is toggled back and
    ' forth between language display on the form.  The ComponentResourceManager
    ' is used to load the appropriate resource for the specified CultureInfo.
    ' The mechanisim appends the locale to the resource file name to select the
    ' proper resource.  For example; an empty string causes the default Resource1.resx
    ' to be applied and constructing a CultureInfo with the "de" culture name causes the 
    ' Resource1.de.resx file to be used.  When ApplyResources is called on a particular component 
    ' with the current CultureInfo, reflection is used to extract the properties
    ' from the resource file and apply it to the component.  Typically, the CultureInfo would
    ' be extracted from system settings.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim ci As New CultureInfo("") 'invariant culture
        isChange = Not isChange
        If isChange Then
            ci = New CultureInfo("de")
        End If
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Resource1))
        resources.ApplyResources(Me.button1, "button1", ci)
        resources.ApplyResources(Me.label1, "label1", ci)
        resources.ApplyResources(Me.radioButton1, "radioButton1", ci)
        resources.ApplyResources(Me.textBox1, "textBox1", ci)
    End Sub 'button1_Click
End Class 'Form1


