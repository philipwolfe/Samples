Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub


       Public Sub StatusClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            Dim menu As MenuItem
            Dim status As String
            menu = CType(Sender, MenuItem)
            status = (menu.Header.ToString())
            If (status.Equals("Online")) Then
                mi1.IsChecked = True
                mi2.IsChecked = False
                mi3.IsChecked = False
                mi4.IsChecked = False

            ElseIf (status.Equals("Busy")) Then
                mi1.IsChecked = False
                mi2.IsChecked = True
                mi3.IsChecked = False
                mi4.IsChecked = False

            ElseIf (status.Equals("Be Right Back")) Then
                mi1.IsChecked = False
                mi2.IsChecked = False
                mi3.IsChecked = True
                mi4.IsChecked = False

            ElseIf (status.Equals("Away")) Then
                mi1.IsChecked = False
                mi2.IsChecked = False
                mi3.IsChecked = False
                mi4.IsChecked = True

            End If
        End Sub


    End Class


End Namespace
