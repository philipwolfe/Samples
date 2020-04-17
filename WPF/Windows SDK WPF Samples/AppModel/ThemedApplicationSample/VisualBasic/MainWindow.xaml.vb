Imports System
Imports System.Windows

Public Class MainWindow
    Inherits Window

    Public Sub New()
        Me.InitializeComponent()
        Me.themeComboBox.Items.Add("Blue")
        Me.themeComboBox.Items.Add("Yellow")
        Me.themeComboBox.SelectedIndex = 0
        Application.Current.Resources = DirectCast(Application.Current.Properties.Item("Blue"), ResourceDictionary)
        AddHandler Me.themeComboBox.SelectionChanged, New SelectionChangedEventHandler(AddressOf Me.themeComboBox_SelectionChanged)
    End Sub

    Private Sub newChildWindowButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim window As ChildWindow = New ChildWindow
        window.Show()
    End Sub

    Private Sub themeComboBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Dim theme As String = CStr(e.AddedItems.Item(0))
        Application.Current.Resources = DirectCast(Application.Current.Properties.Item(theme), ResourceDictionary)
    End Sub
End Class