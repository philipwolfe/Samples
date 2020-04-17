//#define simple

using System;
using System.Windows;
using System.Windows.Controls;

namespace MyUserControl
{
    public partial class NumericUpDown : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the NumericUpDownControl.
        /// </summary>
        public NumericUpDown()
        {
            InitializeComponent();

            UpdateTextBlock();
        }

        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public decimal Value
        {
#if simple
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    if (MinValue <= value && value <= MaxValue)
                    {
                        _value = value;
                        UpdateTextBlock();
                        OnValueChanged(EventArgs.Empty);
                    }
                }
            }
#else            
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
#endif
        }

#if simple
        private decimal _value = MinValue;
#else
        /// <summary>
        /// Identifies the Value dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value", typeof(decimal), typeof(NumericUpDown), 
                new FrameworkPropertyMetadata(MinValue,new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            NumericUpDown control = (NumericUpDown)obj;			
			control.UpdateTextBlock();

            RoutedPropertyChangedEventArgs<decimal> e = new RoutedPropertyChangedEventArgs<decimal>(
                (decimal)args.OldValue, (decimal)args.NewValue, ValueChangedEvent);
            control.OnValueChanged(e);
        }
#endif

#if simple
        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

#else
        /// <summary>
        /// Identifies the ValueChanged routed event.
        /// </summary>
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble, 
            typeof(RoutedPropertyChangedEventHandler<decimal>), typeof(NumericUpDown));

        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<decimal> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
#endif

#if simple
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">An EventArgs that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs args)
        {
            EventHandler<EventArgs> handler = ValueChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
#else
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<decimal> args)
        {
            RaiseEvent(args);
        }
#endif

        private void upButton_Click(object sender, EventArgs e)
        {
            if (Value < MaxValue)
            {
                Value++;
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (Value > MinValue)
            {
                Value--;
            }
        }

        private void UpdateTextBlock()
        {
            valueText.Text = Value.ToString();
        }

        private const decimal MinValue = 0, MaxValue = 100;
    }
}