Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

Namespace Slider_vb
	
      Partial Class Pane1
        Sub OnClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cv1.Children.Clear()
            Dim hslider As New Slider()
            hslider.Orientation = Controls.Orientation.Horizontal
            hslider.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft
            hslider.AutoToolTipPrecision = 2
            hslider.IsDirectionReversed = True
            hslider.Width = 100
            hslider.IsMoveToPointEnabled = False
            hslider.SelectionStart = 1.1
            hslider.SelectionEnd = 3
            hslider.IsSelectionRangeEnabled = False
            hslider.TickFrequency = 3
            hslider.TickPlacement = TickPlacement.Both
            hslider.Value = 0
            cv1.Children.Add(hslider)
        End Sub

        Sub OnClickNonUniform(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cv2.Children.Clear()
            Dim hslider As New Slider()
            hslider.Orientation = Controls.Orientation.Horizontal
            hslider.Width = 100
            hslider.IsMoveToPointEnabled = False
            Dim tickMarks As New DoubleCollection()
            tickMarks.Add(1.1)
            tickMarks.Add(1.3)
            tickMarks.Add(2.0)
            tickMarks.Add(7.0)
            tickMarks.Add(10.0)
            hslider.Ticks = tickMarks
            hslider.TickPlacement = TickPlacement.BottomRight
            hslider.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft
            hslider.AutoToolTipPrecision = 2
            hslider.IsSnapToTickEnabled = True
            cv2.Children.Add(hslider)
        End Sub

    End Class
	
End Namespace