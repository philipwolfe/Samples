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

        Private Sub StatusClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            Dim Status As String

            Dim menu As MenuItem = CType(Sender, MenuItem)

            status = menu.Header.ToString
            Select Case status
                Case "Online"
                    mi1.IsChecked = True
                    mi2.IsChecked = False
                    mi3.IsChecked = False
                    mi4.IsChecked = False

                Case "Busy"
                    mi1.IsChecked = False
                    mi2.IsChecked = True
                    mi3.IsChecked = False
                    mi4.IsChecked = False


                Case "Be Right Back"
                    mi1.IsChecked = False
                    mi2.IsChecked = False
                    mi3.IsChecked = True
                    mi4.IsChecked = False

                Case "Away"
                    mi1.IsChecked = False
                    mi2.IsChecked = False
                    mi3.IsChecked = False
                    mi4.IsChecked = True

            End Select

        End Sub
    End Class

End Namespace

