Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

	public partial class Window1 
inherits Window

    Public Sub Window1()

        InitializeComponent()
    End Sub


    Sub PrintText(ByVal Sender As Object, ByVal e As SelectionChangedEventArgs)

        Dim lb As ListBox = CType(Sender, ListBox)
        If (Not (TypeOf lb.SelectedItem Is ListBox)) Then Return
        Dim lbi As ListBoxItem = CType(lb.SelectedItem, ListBoxItem)
        If (lbi Is Nothing) Then Return
        btn.Content = "You chose " + lbi.Content.ToString() + "."

    End Sub
End Class
     
    
    
