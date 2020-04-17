using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.Threading;

namespace FontDialog
{
    public partial class Window1 : Window
    {
        Window2 fontdialog;

        public Window1(): base()
        {
            InitializeComponent();
        }

        void ShowDialog(object sender, RoutedEventArgs args)
        {
            fontdialog = new Window2(RichTextEditor.Selection);
            fontdialog.DialogApplied += new DialogAppliedEventHandler(fontdialog_DialogApplied);
            fontdialog.ShowDialog();
        }

        void fontdialog_DialogApplied(object o, DialogAppliedEventsArgs args)
        {
            TextRange range = new TextRange(RichTextEditor.Selection.Start, RichTextEditor.Selection.End);
            range.ApplyPropertyValue(TextElement.FontFamilyProperty, args.FontItem.FontFamily.Source);
            range.ApplyPropertyValue(TextElement.FontStyleProperty, args.FontItem.FontStyle);
            range.ApplyPropertyValue(TextElement.FontWeightProperty, args.FontItem.FontWeight);
            range.ApplyPropertyValue(TextElement.FontStretchProperty, args.FontItem.FontStretch);
            range.ApplyPropertyValue(TextElement.FontSizeProperty, args.FontItem.FontSize);
            range.ApplyPropertyValue(Paragraph.TextDecorationsProperty, args.FontItem.TextDecorationCollection);
            range.ApplyPropertyValue(TextElement.ForegroundProperty, args.FontItem.Foreground);
        }
    }
}