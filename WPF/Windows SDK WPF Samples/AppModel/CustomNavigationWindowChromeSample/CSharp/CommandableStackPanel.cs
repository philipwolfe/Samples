using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomNavigationWindowChromeSample
{
    /// <summary>
    /// A custom StackPanel that supports commanding, by implementing ICommandSource.
    /// </summary>
    public class CommandableStackPanel : StackPanel
    {
        static CommandableStackPanel()
        {
            CommandableStackPanel.CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandableStackPanel), new FrameworkPropertyMetadata(null));
            CommandableStackPanel.CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandableStackPanel), new FrameworkPropertyMetadata(null));
            CommandableStackPanel.CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(CommandableStackPanel), new FrameworkPropertyMetadata(null));
        }

        public static readonly DependencyProperty CommandProperty;
        public static readonly DependencyProperty CommandParameterProperty;
        public static readonly DependencyProperty CommandTargetProperty;

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            // Execute command
            if (this.Command != null && this.Command is RoutedCommand)
            {
                RoutedCommand routedCommand = this.Command as RoutedCommand;
                if (routedCommand.CanExecute(this.CommandParameter, this.CommandTarget))
                {
                    routedCommand.Execute(this.CommandParameter, this.CommandTarget);
                }
            }
        }

        [Category("Action"), Bindable(true), Localizability(LocalizationCategory.NeverLocalize)]
        public ICommand Command
        {
            get
            {
                return (ICommand)base.GetValue(CommandableStackPanel.CommandProperty);
            }
            set
            {
                base.SetValue(CommandableStackPanel.CommandProperty, value);
            }
        }

        [Bindable(true), Localizability(LocalizationCategory.NeverLocalize), Category("Action")]
        public object CommandParameter
        {
            get
            {
                return base.GetValue(CommandableStackPanel.CommandParameterProperty);
            }
            set
            {
                base.SetValue(CommandableStackPanel.CommandParameterProperty, value);
            }
        }

        [Bindable(true), Category("Action")]
        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)base.GetValue(CommandableStackPanel.CommandTargetProperty);
            }
            set
            {
                base.SetValue(CommandableStackPanel.CommandTargetProperty, value);
            }
        }
    }
}
