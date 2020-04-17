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

        Public Sub Increase(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            Dim Num As Int32

            Num = Convert.ToInt32(btn.Content)
            btn.Content = ((Num + 1).ToString())
        End Sub

    End Class





End Namespace
