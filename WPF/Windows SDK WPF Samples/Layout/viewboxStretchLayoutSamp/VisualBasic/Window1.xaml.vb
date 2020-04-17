Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

namespace Viewbox_Stretch_Layout_Samp

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window

        Public Sub stretchNone(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.Stretch = System.Windows.Media.Stretch.None
            txt1.Text = "Stretch is now set to None."
        End Sub

        Public Sub stretchFill(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.Stretch = System.Windows.Media.Stretch.Fill
            txt1.Text = "Stretch is now set to Fill."
        End Sub

        Public Sub stretchUni(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.Stretch = System.Windows.Media.Stretch.Uniform
            txt1.Text = "Stretch is now set to Uniform."
        End Sub

        Public Sub stretchUniFill(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.Stretch = System.Windows.Media.Stretch.UniformToFill
            txt1.Text = "Stretch is now set to UniformToFill."
        End Sub

        Public Sub sdUpOnly(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.StretchDirection = System.Windows.Controls.StretchDirection.UpOnly
            txt2.Text = "StretchDirection is now UpOnly."
        End Sub

        Public Sub sdDownOnly(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.StretchDirection = System.Windows.Controls.StretchDirection.DownOnly
            txt2.Text = "StretchDirection is now DownOnly."
        End Sub

        Public Sub sdBoth(ByVal sender As Object, ByVal args As RoutedEventArgs)

            vb1.StretchDirection = System.Windows.Controls.StretchDirection.Both
            txt2.Text = "StretchDirection is now Both."
        End Sub

    End Class
    End Namespace
