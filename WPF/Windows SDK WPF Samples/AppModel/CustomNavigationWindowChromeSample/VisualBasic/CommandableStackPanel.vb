Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Public Class CommandableStackPanel
    Inherits StackPanel

    ' Methods
    Shared Sub New()
        CommandableStackPanel.CommandProperty = DependencyProperty.Register("Command", GetType(ICommand), GetType(CommandableStackPanel), New FrameworkPropertyMetadata(Nothing))
        CommandableStackPanel.CommandParameterProperty = DependencyProperty.Register("CommandParameter", GetType(Object), GetType(CommandableStackPanel), New FrameworkPropertyMetadata(Nothing))
        CommandableStackPanel.CommandTargetProperty = DependencyProperty.Register("CommandTarget", GetType(IInputElement), GetType(CommandableStackPanel), New FrameworkPropertyMetadata(Nothing))
    End Sub

    Protected Overrides Sub OnPreviewMouseUp(ByVal e As System.Windows.Input.MouseButtonEventArgs)

        MyBase.OnPreviewMouseUp(e)

        ' Execute command
        If ((Not Me.Command Is Nothing) AndAlso TypeOf Me.Command Is RoutedCommand) Then
            Dim command As RoutedCommand = TryCast(Me.Command, RoutedCommand)
            If command.CanExecute(Me.CommandParameter, Me.CommandTarget) Then
                command.Execute(Me.CommandParameter, Me.CommandTarget)
            End If
        End If

    End Sub

    <Category("Action"), Localizability(LocalizationCategory.NeverLocalize), Bindable(True)> _
    Property Command() As ICommand
        Get
            Return DirectCast(MyBase.GetValue(CommandableStackPanel.CommandProperty), ICommand)
        End Get
        Set(ByVal value As ICommand)
            MyBase.SetValue(CommandableStackPanel.CommandProperty, value)
        End Set
    End Property

    <Category("Action"), Bindable(True), Localizability(LocalizationCategory.NeverLocalize)> _
    Property CommandParameter() As Object
        Get
            Return MyBase.GetValue(CommandableStackPanel.CommandParameterProperty)
        End Get
        Set(ByVal value As Object)
            MyBase.SetValue(CommandableStackPanel.CommandParameterProperty, value)
        End Set
    End Property

    <Category("Action"), Bindable(True)> _
    Property CommandTarget() As IInputElement
        Get
            Return DirectCast(MyBase.GetValue(CommandableStackPanel.CommandTargetProperty), IInputElement)
        End Get
        Set(ByVal value As IInputElement)
            MyBase.SetValue(CommandableStackPanel.CommandTargetProperty, value)
        End Set
    End Property

    Public Shared ReadOnly CommandParameterProperty As DependencyProperty
    Public Shared ReadOnly CommandProperty As DependencyProperty
    Public Shared ReadOnly CommandTargetProperty As DependencyProperty

End Class