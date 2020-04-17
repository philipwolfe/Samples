Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Input

' Interaction logic for Window1.xaml
Namespace WCSamples
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Sub OpenCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
            MessageBox.Show("The command has been invoked.")
        End Sub
        Sub OpenCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
            e.CanExecute = True
        End Sub


    End Class
End Namespace

