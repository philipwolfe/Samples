using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Shapes;


namespace FontDialog
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private TextSelection selection;
        private WPFFont CurrentFont;
        private SolidColorBrush textcolor = Brushes.Black;
        private Control controlForHelp = null;
        public event DialogAppliedEventHandler DialogApplied;

        #region public methods
        public Window2() : base()
        {   
        }
        public Window2(TextSelection s) : this()
        {
            selection=s;
            InitializeComponent();
            InitializeContent();

        }
        #endregion 
        #region private methods
        void OnwindowRendered(object o, EventArgs e)
        {
            ScrollIntoView();
        }
        void InitializeContent()
        {
            string DefaultFont = null ;
            //Set fonts
            Object temp;
            if (selection != null)
            {
                temp = selection.Start.Parent.GetValue(TextElement.FontFamilyProperty);
                if ((temp is string))
                {
                   DefaultFont = (string)temp;
                }
                else 
                    DefaultFont = ((FontFamily)temp).Source;
                int index = DefaultFont.IndexOf(','); 
                if(index >0)
                    DefaultFont = DefaultFont.Substring(0, index);
            }
            ICollection Fonts = System.Windows.Media.Fonts.SystemFontFamilies as ICollection;
            CurrentFont = new WPFFont();
            foreach (FontFamily obj in Fonts)
            {
                FontFamilyItem item = new FontFamilyItem(obj);
                FontFamilyListBox.Items.Add(item);
                 if(obj.Source == DefaultFont)
                 {
                     CurrentFont.FontFamily=obj;
                     CurrentFont.FontStyle = (FontStyle)selection.Start.Parent.GetValue(TextElement.FontStyleProperty);
                     CurrentFont.FontWeight = (FontWeight)selection.Start.Parent.GetValue(TextElement.FontWeightProperty);
                     CurrentFont.FontStretch = (FontStretch)selection.Start.Parent.GetValue(TextElement.FontStretchProperty);
                     CurrentFont.FontSize = (double)selection.Start.Parent.GetValue(TextElement.FontSizeProperty);

                     CurrentFont.TextDecorationCollection = (TextDecorationCollection)selection.Start.Parent.GetValue(Paragraph.TextDecorationsProperty);//IB: wasTextElement.TextDecorationsProperty
                     CurrentFont.Foreground = new SolidColorBrush(((SolidColorBrush)selection.Start.Parent.GetValue(TextElement.ForegroundProperty)).Color);
                     textcolor = CurrentFont.Foreground;
                     FontFamilyListBox.SelectedItem = item;
                 }
            }
            SetTypeFaces(FontSizeListBox, WPFFont.FontSizes);
            SetTypeFaces(FontStyleListBox, WPFFont.FontStyles);
            SetTypeFaces(FontWeightListBox, WPFFont.FontWeights);
            SetTypeFaces(FontStretchListBox, WPFFont.FontStretchs);
            SetDecoration();
            SetColorList();

            
        }
        void WindowInitialized(object o, EventArgs args)
        {
        }
        void OnOkButtonClicked(object obj, RoutedEventArgs args)
        {
          this.DialogResult = true;
            this.Close();
            if (DialogApplied != null)
            {
                DialogApplied(this, new DialogAppliedEventsArgs(CurrentFont));
            }
            if (selection != null)
            {
                ApplyFontOnRange(selection);
            }
        }
        void OnCancelButtonClicked(object obj, RoutedEventArgs args)
        {
            //Apply = false;

          this.DialogResult = false;// System.Windows.Forms.DialogResult.Cancel; 
            this.Close();


        }
        void FontFamilyChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, FontFamilyListBox);
        }
        void TextColorChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, TextColorListBox);
        }
        void FontWeightChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, FontWeightListBox);
        }
        void FontStretchChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, FontStretchListBox);
        }
        void FontStyleChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, FontStyleListBox);
        }
        void FontSizeChanged(object obj, TextChangedEventArgs args)
        {
            PerformFiltering(obj as TextBox, FontSizeListBox);
        }

        void FontFaimlySelected(object o, SelectionChangedEventArgs args)
        {
          ListBox lBox = o as ListBox;
          
            if (lBox.SelectedItems == null || lBox.SelectedItems.Count <= 0)
                return;          
            CurrentFont.FontFamily =((FontFamilyItem) lBox.SelectedItems[0]).FontFamily;

            ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
           
            FontFamilyTextBox.Text = CurrentFont.FontFamily.Source;

        }
        void FontStyleSelected(object o, SelectionChangedEventArgs args)
        {
            object obj = FontStyleListBox.SelectedItem ;
            if (null != obj)
            {
                CurrentFont.FontStyle = (FontStyle)obj;

                ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
                FontStyleTextBox.Text = obj.ToString();
            }

        }
        void FontWeightSelected(object o, SelectionChangedEventArgs args)
        {
            object obj = FontWeightListBox.SelectedItem;
            if (null != obj)
            {
                CurrentFont.FontWeight = (FontWeight)obj;
                ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
                FontWeightTextBox.Text = obj.ToString();
            }
           
        }
        void FontStretchSelected(object o, SelectionChangedEventArgs args)
        {
            object obj = FontStretchListBox.SelectedItem;
            if (null != obj)
            {
                CurrentFont.FontStretch = (FontStretch)obj;
                ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
                FontStretchTextBox.Text = obj.ToString();
            }
            
        }
        void FontSizeSelected(object o, SelectionChangedEventArgs args)
        {

            object obj = FontSizeListBox.SelectedItem;
            if (null != obj)
            {
                double size = (double)(FontSizeListBox.SelectedItem);//IB: changed to double
                CurrentFont.FontSize = (double)FontSizeListBox.SelectedItem;//IB: many changes changed from Fontsize( and , FontSizeType.Point
                ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
                FontSizeTextBox.Text = FontSizeListBox.SelectedItem.ToString();
            }
        }
        void TextColorSelected(object o, SelectionChangedEventArgs args)
        {
          ListBox lBox = o as ListBox;
            object obj = TextColorListBox.SelectedItem;     
            if (null != obj)
            {
                ColorSelectionItem colorItem = lBox.SelectedItems[0] as ColorSelectionItem;
                CurrentFont.Foreground = colorItem.Color;
                ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
                TextColorTextBox.Text = TextColorListBox.SelectedItem.ToString();
            }
           
        }

        void PerformFiltering(TextBox textbox, ListBox listBox)
        {

            string str1 = textbox.Text.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                string str2 = listBox.Items[i].ToString().ToLower(System.Globalization.CultureInfo.InvariantCulture);
                if (str1 == str2)
                {
                    if (listBox.SelectedItem != listBox.Items[i])
                    {
                        listBox.SelectedItem = listBox.Items[i];
                        listBox.ScrollIntoView(listBox.Items[i]);
                        break;
                    }
                }
                else if (str1.Length < str2.Length)
                {
                    str2 = str2.Substring(0, str1.Length);
                    if (str2 == str1)
                    {
                        listBox.ScrollIntoView(listBox.Items[i]);
                        break;
                    }
                }
            }
        }
        void SetTypeFaces(ListBox lBox, ICollection IC)
        {
            if (null == lBox || IC == null)
                return;
            foreach (object obj in IC)
            {
                lBox.Items.Add(obj);
                if ((obj is FontStyle && (FontStyle)obj == CurrentFont.FontStyle) ||
                    (obj is FontStretch && (FontStretch)obj == CurrentFont.FontStretch) ||
                    (obj is FontWeight && (FontWeight)obj == CurrentFont.FontWeight) ||
                    (obj is double && (double)obj == (CurrentFont.FontSize)))//IB: old: .Amount changed to double(double)
                {
                    lBox.SelectedItem=lBox.Items[lBox.Items.Count-1];
                }
            }
            if (lBox.SelectedItem == null && lBox.Items.Count>0)
            {
                lBox.SelectedItem = lBox.Items[0];
            }
        }
        void DecorationsChanged(object Sender, RoutedEventArgs e)
        {
            TextDecorationCollection decorations = new TextDecorationCollection();
            if (StrikeCheckBox.IsChecked == true)
            {
                decorations.Add(TextDecorations.Strikethrough[0]);
            }
            if (UnderLineCheckBox.IsChecked == true)
            {
                decorations.Add(TextDecorations.Underline[0]);
            }
            if (OverLineCheckBox.IsChecked == true)
            {
                decorations.Add(TextDecorations.OverLine[0]);
            }
            if (BaseLineCheckBox.IsChecked == true)
            {
                decorations.Add(TextDecorations.Baseline[0]);
            }
            CurrentFont.TextDecorationCollection = decorations;
            ApplyFontOnRange(new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd));
        }

        void ApplyFontOnRange(TextRange range)
        {
            if (range == null)
                return; 

            range.ApplyPropertyValue(TextElement.FontStyleProperty, CurrentFont.FontStyle);
            range.ApplyPropertyValue(TextElement.FontWeightProperty, CurrentFont.FontWeight);
            range.ApplyPropertyValue(TextElement.FontStretchProperty, CurrentFont.FontStretch);
            range.ApplyPropertyValue(TextElement.FontSizeProperty, CurrentFont.FontSize);
            range.ApplyPropertyValue(Paragraph.TextDecorationsProperty, CurrentFont.TextDecorationCollection);
            range.ApplyPropertyValue(TextElement.ForegroundProperty, CurrentFont.Foreground);
        }

        void SetDecoration()
        {
            if (CurrentFont.TextDecorationCollection != null)
            {

                bool strike = false, underline = false, overline = false, baseline = false;
                TextDecorationCollection td = CurrentFont.TextDecorationCollection;
                foreach (TextDecoration obj in td)
                {
                    if (obj.Equals(System.Windows.TextDecorations.Strikethrough[0] as TextDecoration))
                    {
                        strike = true;
                    }
                    else if (obj.Equals(System.Windows.TextDecorations.Underline[0] as TextDecoration))
                    {
                        underline = true;
                    }
                    else if (obj.Equals(System.Windows.TextDecorations.OverLine[0] as TextDecoration))
                    {
                        overline = true;
                    }
                    else if (obj.Equals(System.Windows.TextDecorations.Baseline[0] as TextDecoration))
                    {
                        baseline = true;
                    }
                }
                if (strike)
                {
                    StrikeCheckBox.IsChecked = true;
                }
                else
                {
                    StrikeCheckBox.IsChecked = false;
                }
                if (underline)
                {
                    UnderLineCheckBox.IsChecked = true;
                }
                else
                {
                    UnderLineCheckBox.IsChecked = false;
                }
                if (overline)
                {
                    OverLineCheckBox.IsChecked = true;
                }
                else
                {
                    OverLineCheckBox.IsChecked = false;
                }
                if (baseline)
                {
                    BaseLineCheckBox.IsChecked = true;
                }
                else
                {
                    BaseLineCheckBox.IsChecked = false;
                }
            }
        }
        void ScrollIntoView()
        {
            if (FontFamilyListBox.SelectedItem != null)
                FontFamilyListBox.ScrollIntoView(FontFamilyListBox.SelectedItem);
            if (FontStyleListBox.SelectedItem != null)
                FontStyleListBox.ScrollIntoView(FontStyleListBox.SelectedItem);
            if (FontWeightListBox.SelectedItem != null)
                FontWeightListBox.ScrollIntoView(FontWeightListBox.SelectedItem);
            if (FontStretchListBox.SelectedItem != null)
                FontStretchListBox.ScrollIntoView(FontStretchListBox.SelectedItem);
            if (FontSizeListBox.SelectedItem != null)
                FontSizeListBox.ScrollIntoView(FontSizeListBox.SelectedItem);
            if (TextColorListBox.SelectedItem != null)
                TextColorListBox.ScrollIntoView(TextColorListBox.SelectedItem);
        }
        void SetColorList()
        {
            Hashtable ht = WPFFont.ColorTable;
            string[] colorNames = WPFFont.ColorNames;
            for (int i = 0; i < colorNames.Length; i++)
            {
                SolidColorBrush color = ht[colorNames[i]] as SolidColorBrush;
                if (ht.Contains(colorNames[i]))
                {
                    TextColorListBox.Items.Add(new ColorSelectionItem(colorNames[i], color));
                }
            }
            for (int j = 0; j < TextColorListBox.Items.Count; j++)
            {
                if ((((ColorSelectionItem)TextColorListBox.Items[j]).Color.Color) == textcolor.Color)
                {
                    TextColorListBox.SelectedItem = TextColorListBox.Items[j];
                }
            }
        }
        void CreateContextMenu(object obj, System.Windows.Input.MouseButtonEventArgs e)
        {
            controlForHelp = obj as Control;
            ContextMenu menu = new ContextMenu();
            MenuItem item=new MenuItem();
            item.Click +=new RoutedEventHandler(item_Click);
            item.Header = "What's this?";

            menu.Items.Add(item);
            controlForHelp.ContextMenu = menu;
        }
        void item_Click(object o, RoutedEventArgs args)
        {
            ToolTip tp = new ToolTip();
            tp.Content = ToolTipMessage.GetToolTipMessage( controlForHelp.Name);
            controlForHelp.ToolTip = tp;
            tp.IsOpen = true;
            tp.Closed += new RoutedEventHandler(tp_Closed);
            tp.StaysOpen = false;
        }
        void tp_Closed(object obj, RoutedEventArgs e)
        {
            controlForHelp.ToolTip = null;
        }
        #endregion 
    }
}