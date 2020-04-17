using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace FontPlayer2
{

    public partial class Page1 : Page
    {

        private Span myInline = new Span(); //Used to hold all the font info settings.   
        private TextBlock myTextBlock = new TextBlock(); //Used to hold styling info 
        private ArrayList myFaceList = new ArrayList();
        private ArrayList myVariantList = new ArrayList(); //Holds the context menuitems for glyph variants

        public Page1(): base()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, EventArgs e) 
        {
            
            // Enumerate the fonts into the FontFamilyComboBox
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyComboBox.Items.Add(fontFamily.Source);
            }
            //FontFamilyComboBox.SelectedIndex = 1;
        }

        //Event handler to deal with any selection events in the UI
        //Only used by glyph variant listbox will most likely remove.
        private void SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (RichTextEditor.Selection != null)
            {
				ApplySettingsOnRange(RichTextEditor.Selection);
            }
        }
        //Click event handler for the context menu
        void ContextMenuOpen(object o, RoutedEventArgs e)
        {
            //Create new menuItems using the RichTextBox selected text.
            myVariantList.Clear();
            for (int j = 0; j <= 8; j++)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Name = "Variant" + j;
                menuItem.Click += new RoutedEventHandler(ContextMenuClick);
                TextBlock sampleText = new TextBlock();
                sampleText.FontSize = 16.0D;
                sampleText.Text = RichTextEditor.Selection.Text; //will be overwritten with selected text.
                sampleText.FontFamily = RichTextEditor.FontFamily;
                sampleText.Typography.StylisticAlternates = j;
                menuItem.Header = sampleText;
                myVariantList.Add(menuItem);
            }
            
            VariantMenu.Items.Clear();
            foreach (MenuItem menuItem in myVariantList)
            {
                VariantMenu.Items.Add(menuItem);
            }

        }
        //To handle clicks in the context menu
        void ContextMenuClick(object o, RoutedEventArgs e)
        {
            //Glyph Variants click            
            MenuItem item = (MenuItem)o;
            int variant = 0;
            switch (item.Name)
            {
                case "Variant0":
                    variant = 0;
                    break;
                case "Variant1":
                    variant = 1;
                    break;
                case "Variant2":
                    variant = 2;
                    break;
                case "Variant3":
                    variant = 3;
                    break;
                case "Variant4":
                    variant = 4;
                    break;
                case "Variant5":
                    variant = 5;
                    break;
                case "Variant6":
                    variant = 6;
                    break;
                case "Variant7":
                    variant = 7;
                    break;
                case "Variant8":
                    variant = 8;
                    break;
                default:
                    variant = 0;
                    break;
            }

            myInline.Typography.StylisticAlternates = variant;
            ApplySettingsOnRange(RichTextEditor.Selection);
        }

        //Special event handler for the FontFamily combobox because the Typeface listbox is populated based on it.
        private void FontFamilySelectionChanged(object sender, SelectionChangedEventArgs args)
        {            
            FontFamily family = (FontFamilyComboBox.SelectedItem != null) ? 
                                new FontFamily(FontFamilyComboBox.SelectedItem.ToString()) :
                                new FontFamily("Arial");

            //Clear the previous family's typefaces
            TypefaceListBox.Items.Clear();
            myFaceList.Clear();

            //For each typeface in the font create my new FaceItem object
            //Using this class to return a good string description and the actual typeface object
            foreach (Typeface face in family.GetTypefaces())
            {
                FaceItem myFaceItem = new FaceItem(face);
                myFaceList.Add(myFaceItem);         
            }
            
            foreach (FaceItem faceItem in myFaceList)
            {
                TypefaceListBox.Items.Add(faceItem);
            }

            if (RichTextEditor.Selection != null)
            {
                ApplySettingsOnRange(RichTextEditor.Selection);
            }
        }

        //Event handler to deal with any checked events in the UI
        private void CheckedChanged(object sender, RoutedEventArgs args)
        {
            //Ligatures
            myInline.Typography.StandardLigatures = (StandardLigaturesCheck.IsChecked == true) ? true : false;
            myInline.Typography.DiscretionaryLigatures = (DiscretionaryLigaturesCheck.IsChecked == true) ? true : false;
            myInline.Typography.ContextualLigatures = (ContextualLigaturesCheck.IsChecked == true) ? true : false;

            if (RichTextEditor.Selection != null)
            {
                ApplySettingsOnRange(RichTextEditor.Selection);
            }
        }
        private void TypefaceSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (TypefaceListBox.SelectedItem != null)
            {
                FaceItem temp = new FaceItem();
                temp = (FaceItem)TypefaceListBox.SelectedItem;
                myInline.FontWeight = temp.FontWeight;
                myInline.FontStyle = temp.FontStyle;
                myInline.FontStretch = temp.FontStretch;
            }
            if (RichTextEditor.Selection != null)
            {
                ApplySettingsOnRange(RichTextEditor.Selection);
            }
        }
        
        void ApplySettingsOnRange(TextRange range)
        {
            //Apply FontFamily
			myInline.FontFamily = new FontFamily((FontFamilyComboBox.SelectedItem != null) ? FontFamilyComboBox.SelectedItem.ToString() : "Arial");
            range.ApplyPropertyValue(TextElement.FontFamilyProperty, myInline.FontFamily);

            //Apply Typefaces
            if (TypefaceListBox.SelectedItem != null)
            {
                range.ApplyPropertyValue(TextElement.FontWeightProperty, myInline.FontWeight);
				range.ApplyPropertyValue(TextElement.FontStyleProperty, myInline.FontStyle);
				range.ApplyPropertyValue(TextElement.FontStretchProperty, myInline.FontStretch);
            }            

            //Apply Ligatures 
			range.ApplyPropertyValue(Typography.StandardLigaturesProperty, myInline.Typography.StandardLigatures);
			range.ApplyPropertyValue(Typography.DiscretionaryLigaturesProperty, myInline.Typography.DiscretionaryLigatures);
			range.ApplyPropertyValue(Typography.ContextualAlternatesProperty, myInline.Typography.ContextualAlternates);
            
            //Apply Stylistic Alternatives         
			range.ApplyPropertyValue(Typography.StylisticAlternatesProperty, myInline.Typography.StylisticAlternates);      
        }

    }
}